using System;
using System.Data;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Newtonsoft.Json;

namespace SecureTransactionApp_DataGrid
{
    public static class SecurityService
    {
        public static string DataTableToJson(DataTable table)
        {
            return JsonConvert.SerializeObject(table, Formatting.None);
        }

        public static string Base64Encode(string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        }

        public static byte[] Sha256(byte[] data)
        {
            using (var sha = SHA256.Create())
            {
                return sha.ComputeHash(data);
            }
        }

        public static string Base64OfHash(byte[] hash)
        {
            return Convert.ToBase64String(hash);
        }

        public static byte[] SignHashWithPfx(byte[] hash, string pfxPath, string pfxPassword)
        {
            var cert = new X509Certificate2(pfxPath, pfxPassword, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
            using (var rsa = cert.GetRSAPrivateKey())
            {
                if (rsa == null) throw new InvalidOperationException("Certificate does not contain an RSA private key.");
                return rsa.SignHash(hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
        }

        public static string BuildOutputJson(string jsonRaw, string jsonBase64, byte[] shaBytes, byte[] signature, X509Certificate2 cert)
        {
            var output = new
            {
                data = new { json = jsonRaw, jsonBase64 = jsonBase64 },
                integrity = new
                {
                    sha256Hex = BitConverter.ToString(shaBytes).Replace("-", "").ToLowerInvariant(),
                    sha256Base64 = Convert.ToBase64String(shaBytes)
                },
                signature = new
                {
                    algorithm = "RSASSA-PKCS1-v1_5 with SHA-256",
                    valueBase64 = Convert.ToBase64String(signature),
                    certificateThumbprint = cert?.Thumbprint,
                    certificateSubject = cert?.Subject
                },
                generatedAtUtc = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")
            };

            return JsonConvert.SerializeObject(output, Formatting.Indented);
        }
    }
}
