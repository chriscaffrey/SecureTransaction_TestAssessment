using System;
using System.Data;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace SecureTransactionApp_DataGrid
{
    public partial class MainForm : Form
    {
        private readonly DataTable _transactions = new DataTable("Transactions");
        private X509Certificate2 _loadedCert;

        public MainForm()
        {
            InitializeComponent();
            InitializeDataTable();
        }


        private void InitializeDataTable()
        {
            _transactions.Columns.Add("TransactionID", typeof(string));
            _transactions.Columns.Add("Amount", typeof(decimal));
            _transactions.Columns.Add("Currency", typeof(string));
            _transactions.Columns.Add("Timestamp", typeof(string));

            dataGrid.DataSource = _transactions;
            AddSampleRow();
        }

        private void AddSampleRow()
        {
            var id = Guid.NewGuid().ToString();
            var tsUtc = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            _transactions.Rows.Add(id, 123.45m, "USD", tsUtc);
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Guid.NewGuid().ToString();
                var tsUtc = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
                decimal amount = 0m;
                decimal.TryParse(txtAmount.Text.Trim(), out amount);
                var currency = string.IsNullOrWhiteSpace(txtCurrency.Text) ? "USD" : txtCurrency.Text.Trim().ToUpperInvariant();

                _transactions.Rows.Add(id, amount, currency, tsUtc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add row: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void btnLoadCert_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(txtPfxPath.Text)) { MessageBox.Show("PFX path not found."); return; }
                _loadedCert = new X509Certificate2(txtPfxPath.Text, txtPfxPassword.Text, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
                lblCertStatus.Text = "Loaded ✔ " + _loadedCert.Subject;
            }
            catch (Exception ex)
            {
                _loadedCert = null;
                lblCertStatus.Text = "Not loaded";
                MessageBox.Show("Failed to load certificate: " + ex.Message, "Cert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
           
            {
                //string json = SecurityService.DataTableToJson(_transactions);
                string json = "";

                    if (dataGrid.SelectedRows.Count > 0)
                {
                    int rowIndex = dataGrid.SelectedRows[0].Index;
                    DataRow selectedRow = _transactions.Rows[rowIndex];

                    // Create a new DataTable with the same structure
                    DataTable singleRowTable = _transactions.Clone();
                    singleRowTable.ImportRow(selectedRow);

                    // Convert only that row to JSON
                  json = SecurityService.DataTableToJson(singleRowTable);

                    //MessageBox.Show(json);
                }
                else
                {
                    MessageBox.Show("Please select a row first.");
                }

                string jsonB64 = SecurityService.Base64Encode(json);

                var jsonB64Bytes = System.Text.Encoding.UTF8.GetBytes(jsonB64);
                var sha = SecurityService.Sha256(jsonB64Bytes);

                if (_loadedCert == null)
                {
                    MessageBox.Show("Load a .pfx certificate first.", "Certificate Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var signature = SecurityService.SignHashWithPfx(sha, txtPfxPath.Text, txtPfxPassword.Text);

                string output = SecurityService.BuildOutputJson(json, jsonB64, sha, signature, _loadedCert);
                txtOutput.Text = output;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Processing failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
