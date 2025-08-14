using System;
using System.Data;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace SecureTransactionApp_DataGrid
{
    public partial class MainForm : Form
    {
        // In-memory table to store transactions
        private readonly DataTable _transactions = new DataTable("Transactions");

        // Loaded certificate (.pfx) for signing operations
        private X509Certificate2 _loadedCert;

        public MainForm()
        {
            InitializeComponent();
            InitializeDataTable();
        }

        /// <summary>
        /// Set up the transaction DataTable structure and bind to DataGridView
        /// </summary>
        private void InitializeDataTable()
        {
            _transactions.Columns.Add("TransactionID", typeof(string)); // Unique transaction identifier
            _transactions.Columns.Add("Amount", typeof(decimal));       // Transaction amount
            _transactions.Columns.Add("Currency", typeof(string));      // Currency code (e.g., MYR, USD)
            _transactions.Columns.Add("Timestamp", typeof(string));     // UTC timestamp in ISO 8601 format

            dataGrid.DataSource = _transactions;

            AddSampleRow(); // Add an initial example row
        }

        /// <summary>
        /// Adds one sample transaction row to the DataTable
        /// </summary>
        private void AddSampleRow()
        {
            var id = Guid.NewGuid().ToString(); // Generate unique ID
            var tsUtc = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"); // Current UTC time
            _transactions.Rows.Add(id, 1000.00m, "MYR", tsUtc);

            // Format Amount column with 2 decimal places
            dataGrid.Columns["Amount"].DefaultCellStyle.Format = "N2";
        }

        /// <summary>
        /// Add new row from user input
        /// </summary>
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Guid.NewGuid().ToString();
                var tsUtc = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");

                // Parse amount from text box; default to 0 if invalid
                decimal.TryParse(txtAmount.Text.Trim(), out decimal amount);

                // Default to MYR if no currency provided
                var currency = string.IsNullOrWhiteSpace(txtCurrency.Text)
                    ? "MYR"
                    : txtCurrency.Text.Trim().ToUpperInvariant();

                _transactions.Rows.Add(id, amount, currency, tsUtc);

                // Clear inputs after adding
                txtAmount.Text = "";
                txtCurrency.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add row: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Browse for a .pfx certificate file
        /// </summary>
        private void btnBrowseCert_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "PFX files (*.pfx)|*.pfx|All files (*.*)|*.*";
                ofd.Title = "Select .pfx certificate";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtPfxPath.Text = ofd.FileName;
                }
            }
        }

        /// <summary>
        /// Load the selected .pfx certificate into memory
        /// </summary>
        private void btnLoadCert_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(txtPfxPath.Text))
                {
                    MessageBox.Show("PFX path not found.");
                    return;
                }

                _loadedCert = new X509Certificate2(
                    txtPfxPath.Text,
                    txtPfxPassword.Text,
                    X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable
                );

                lblCertStatus.Text = "Loaded ✔ " + _loadedCert.Subject;
            }
            catch (Exception ex)
            {
                _loadedCert = null;
                lblCertStatus.Text = "Not loaded";
                MessageBox.Show("Failed to load certificate: " + ex.Message, "Cert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Process the selected transaction:
        /// 1. Extract row → JSON
        /// 2. Base64 encode JSON
        /// 3. SHA256 hash
        /// 4. Sign with loaded .pfx certificate
        /// 5. Build output JSON package
        /// </summary>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string json = "";

                // Ensure a row is selected
                if (dataGrid.SelectedRows.Count > 0)
                {
                    int rowIndex = dataGrid.SelectedRows[0].Index;
                    DataRow selectedRow = _transactions.Rows[rowIndex];

                    // Create a table with only the selected row
                    DataTable singleRowTable = _transactions.Clone();
                    singleRowTable.ImportRow(selectedRow);

                    // Convert row to JSON
                    json = SecurityService.DataTableToJson(singleRowTable);
                }
                else
                {
                    MessageBox.Show("Please select a row first.");
                    return;
                }

                // Encode JSON to Base64
                string jsonB64 = SecurityService.Base64Encode(json);

                // Hash Base64 string
                var jsonB64Bytes = System.Text.Encoding.UTF8.GetBytes(jsonB64);
                var sha = SecurityService.Sha256(jsonB64Bytes);

                // Ensure certificate is loaded
                if (_loadedCert == null)
                {
                    MessageBox.Show("Load a .pfx certificate first.", "Certificate Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Sign the hash using the PFX certificate
                var signature = SecurityService.SignHashWithPfx(sha, txtPfxPath.Text, txtPfxPassword.Text);

                // Build final JSON output
                string output = SecurityService.BuildOutputJson(json, jsonB64, sha, signature, _loadedCert);

                txtOutput.Text = output;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Processing failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Clear all transaction data
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetDataGrid();
        }

        private void ResetDataGrid()
        {
            txtOutput.Text = "";
            _transactions.Clear();
            // Optionally re-add sample row:
            // AddSampleRow();
        }

        /// <summary>
        /// Exit the application
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
