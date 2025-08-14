# Secure Transaction Processing

## Overview
This DEMO is a **secure financial transaction processing** built in C# WinForms. It demonstrates how to handle sensitive transaction data by converting it to JSON, applying cryptographic security, and preparing it for safe storage or transmission.

Go to Tools → NuGet Package Manager → Package Manager Console:
Install-Package Newtonsoft.Json -Version 13.0.3
---

## Approach & Steps

### **1. Data Preparation – DataTable Creation**
- A `DataTable` is initialized to store:
  - **TransactionID** – Generated as a GUID.
  - **Amount** – Decimal value with two decimal precision.
  - **Currency** – ISO currency code (e.g., MYR, USD).
  - **Timestamp** – UTC date/time in `yyyy-MM-ddTHH:mm:ssZ` format.
- Sample data is inserted for demonstration.

### **2. Convert DataTable to JSON**
- The `SecurityService.DataTableToJson()` method uses **Newtonsoft.Json** to serialize the DataTable into a compact JSON string.

### **3. Base64 Encode JSON**
- The JSON string is encoded into **Base64** using UTF-8 bytes.

### **4. Compute SHA-256 Hash**
- The Base64-encoded JSON is hashed using **SHA-256**.

### **5. Digitally Sign the Hash**
- A `.pfx` certificate is loaded, containing an **RSA private key**.
- The SHA-256 hash is signed with **RSASSA-PKCS1-v1_5** and SHA-256.

### **6. Build Final JSON Output**
- The output JSON includes:
  - Original JSON and Base64
  - Hash (Hex & Base64)
  - Signature and certificate info
  - UTC timestamp

---

## Security Concepts Used
- **Base64 Encoding** – Converts binary/JSON into a safe text format.
- **SHA-256 Hashing** – Ensures data integrity.
- **Digital Signatures (RSA + .pfx)** – Confirms authenticity & integrity.
- **UTC Timestamps** – Provides consistent, timezone-independent tracking.

---

## Login Page (Additional Feature)**
- **Purpose**: Restrict access to the main application using username/password authentication.
- **Implementation**:
  - Uses an **in-memory mock database** (`DataSet`) with a `Users` table.
  - Stores usernames and passwords as **MD5 hashes**.
  - Supports multiple roles (e.g., `admin`, `cashier`, `manager`).
  - Pressing **Enter** in username or password fields moves focus or triggers login.
- **Security Note**: MD5 is used here for demonstration purposes. For production, use stronger password hashing (e.g., bcrypt, PBKDF2, Argon2).

---

