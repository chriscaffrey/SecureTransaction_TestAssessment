using System;
using System.Data;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Newtonsoft.Json;

namespace SecureTransactionApp_DataGrid
{
    /// <summary>
    /// SecurityService provides helper functions for:
    /// - Converting data to JSON
    /// - Encoding/decoding in Base64
    /// - Computing SHA-256 hashes
    /// - Digitally signing data with a PFX certificate
    /// - Building structured output JSON with integrity and signature details
    /// </summary>
    public static class SecurityService
    {
        /// <summary>
        /// Converts a DataTable into a JSON string.
        /// </summary>
        /// <param name="table">The DataTable to serialize.</param>
        /// <returns>JSON string without extra formatting (compact).</returns>
        public static string DataTableToJson(DataTable table)
        {
            return JsonConvert.SerializeObject(table, Formatting.None);
        }

        /// <summary>
        /// Encodes a UTF-8 string to Base64.
        /// </summary>
        /// <param name="input">The string to encode.</param>
        /// <returns>Base64-encoded string.</returns>
        public static string Base64Encode(string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        }

        /// <summary>
        /// Computes a SHA-256 hash for the given byte array.
        /// </summary>
        /// <param name="data">The byte array to hash.</param>
        /// <returns>SHA-256 hash as byte array (32 bytes).</returns>
        public static byte[] Sha256(byte[] data)
        {
            using (var sha = SHA256.Create())
            {
                return sha.ComputeHash(data);
            }
        }

        /// <summary>
        /// Converts a hash (byte array) to its Base64 string form.
        /// </summary>
        /// <param name="hash">Byte array representing the hash.</param>
        /// <returns>Base64-encoded string of the hash.</returns>
        public static string Base64OfHash(byte[] hash)
        {
            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Digitally signs a hash using a PFX certificate's RSA private key.
        /// </summary>
        /// <param name="hash">The precomputed SHA-256 hash to sign.</param>
        /// <param name="pfxPath">Path to the .pfx certificate file.</param>
        /// <param name="pfxPassword">Password for the .pfx file.</param>
        /// <returns>Signature as byte array.</returns>
        /// <exception cref="InvalidOperationException">Thrown if RSA private key is missing.</exception>
        public static byte[] SignHashWithPfx(byte[] hash, string pfxPath, string pfxPassword)
        {
            // Load the certificate from the provided path
            var cert = new X509Certificate2(
                pfxPath,
                pfxPassword,
                X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable
            );

            // Extract the RSA private key
            using (var rsa = cert.GetRSAPrivateKey())
            {
                if (rsa == null)
                    throw new InvalidOperationException("Certificate does not contain an RSA private key.");

                // Sign the given hash with SHA-256 using PKCS#1 v1.5 padding
                return rsa.SignHash(hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
        }

        /// <summary>
        /// Builds a structured JSON output containing:
        /// - Original data and Base64-encoded data
        /// - SHA-256 integrity details (Hex & Base64)
        /// - Signature metadata and certificate info
        /// - UTC timestamp of generation
        /// </summary>
        /// <param name="jsonRaw">Original JSON string.</param>
        /// <param name="jsonBase64">Base64 of original JSON.</param>
        /// <param name="shaBytes">SHA-256 hash bytes.</param>
        /// <param name="signature">Signature bytes.</param>
        /// <param name="cert">Loaded certificate used for signing.</param>
        /// <returns>Formatted JSON string with all details.</returns>
        public static string BuildOutputJson(string jsonRaw, string jsonBase64, byte[] shaBytes, byte[] signature, X509Certificate2 cert)
        {
            var output = new
            {
                data = new
                {
                    json = jsonRaw,
                    jsonBase64 = jsonBase64
                },
                integrity = new
                {
                    sha256Hex = BitConverter.ToString(shaBytes).Replace("-", "").ToLowerInvariant(), // Hash in lowercase hex
                    sha256Base64 = Convert.ToBase64String(shaBytes) // Hash in Base64
                },
                signature = new
                {
                    algorithm = "RSASSA-PKCS1-v1_5 with SHA-256", // Signature algorithm description
                    valueBase64 = Convert.ToBase64String(signature), // Signature in Base64
                    certificateThumbprint = cert?.Thumbprint, // Cert fingerprint
                    certificateSubject = cert?.Subject // Cert subject (owner)
                },
                generatedAtUtc = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ") // Timestamp
            };

            // Output JSON with indentation for readability
            return JsonConvert.SerializeObject(output, Formatting.Indented);
        }
    }
}
