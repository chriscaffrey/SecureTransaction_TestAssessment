README – Creating a Test .pfx Certificate

Purpose
-------
This application uses a `.pfx` certificate to digitally sign transaction data for security purposes.
You need a valid `.pfx` file (with a password) before running the application.

1) Generate a `.pfx` Certificate Using PowerShell
-------------------------------------------------
Open PowerShell (Run as Administrator) and run:

$cert = New-SelfSignedCertificate `
    -Type CodeSigningCert `
    -Subject "CN=SecureTransactionApp Test Certificate" `
    -KeyAlgorithm RSA `
    -KeyLength 2048 `
    -HashAlgorithm SHA256 `
    -CertStoreLocation "Cert:\CurrentUser\My"

$pwd = ConvertTo-SecureString -String "123456" -Force -AsPlainText

Export-PfxCertificate `
    -Cert $cert `
    -FilePath "C:\Path\To\Your\TestCert.pfx" `
    -Password $pwd


2) Parameters Explained
-----------------------
- `-Type CodeSigningCert` → Creates a certificate suitable for signing code/data.
- `-Subject` → The "name" of your certificate.
- `-KeyAlgorithm` → RSA encryption.
- `-KeyLength` → 2048-bit key size (recommended for security).
- `-HashAlgorithm` → SHA256 for modern security standards.
- `-CertStoreLocation` → Where the certificate is stored temporarily.
- `-Password` → Protects the `.pfx` file.

3) Usage in This App
--------------------
1. Place `TestCert.pfx` inside the project folder (e.g., `SecureTransactionApp_DataGrid\Certificates\`).
2. In the application, set:

   string pfxPath = @"Certificates\TestCert.pfx";
   string pfxPassword = "123456";

3. The app will load the certificate to sign transaction data.

4) Notes
--------
- This certificate is self-signed — suitable for testing only.
- For production, you should purchase a real code-signing certificate from a trusted Certificate Authority.
- Keep your `.pfx` file and password secure — they can be used to impersonate your application.


