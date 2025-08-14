using System.Drawing;
using System.Windows.Forms;

namespace SecureTransactionApp_DataGrid
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtPfxPath;
        private System.Windows.Forms.TextBox txtPfxPassword;
        private System.Windows.Forms.Button btnBrowseCert;
        private System.Windows.Forms.Button btnLoadCert;
        private System.Windows.Forms.Label lblCertStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelTransaction;
        private System.Windows.Forms.Panel panelCert;

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExit;
     

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.panelTransaction = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.panelCert = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPfxPath = new System.Windows.Forms.TextBox();
            this.btnBrowseCert = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPfxPassword = new System.Windows.Forms.TextBox();
            this.btnLoadCert = new System.Windows.Forms.Button();
            this.lblCertStatus = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.panelTransaction.SuspendLayout();
            this.panelCert.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataGrid.GridColor = System.Drawing.Color.LightGray;
            this.dataGrid.Location = new System.Drawing.Point(15, 15);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(870, 250);
            this.dataGrid.TabIndex = 0;
            // 
            // panelTransaction
            // 
            this.panelTransaction.BackColor = System.Drawing.Color.White;
            this.panelTransaction.Controls.Add(this.label1);
            this.panelTransaction.Controls.Add(this.txtAmount);
            this.panelTransaction.Controls.Add(this.label2);
            this.panelTransaction.Controls.Add(this.txtCurrency);
            this.panelTransaction.Controls.Add(this.btnAddRow);
            this.panelTransaction.Controls.Add(this.btnProcess);
            this.panelTransaction.Location = new System.Drawing.Point(15, 275);
            this.panelTransaction.Name = "panelTransaction";
            this.panelTransaction.Padding = new System.Windows.Forms.Padding(10);
            this.panelTransaction.Size = new System.Drawing.Size(870, 60);
            this.panelTransaction.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(75, 15);
            this.txtAmount.MaxLength = 8;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(150, 25);
            this.txtAmount.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Currency:";
            // 
            // txtCurrency
            // 
            this.txtCurrency.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCurrency.Location = new System.Drawing.Point(310, 15);
            this.txtCurrency.MaxLength = 3;
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(100, 25);
            this.txtCurrency.TabIndex = 3;
            // 
            // btnAddRow
            // 
            this.btnAddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAddRow.FlatAppearance.BorderSize = 0;
            this.btnAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRow.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRow.ForeColor = System.Drawing.Color.White;
            this.btnAddRow.Location = new System.Drawing.Point(430, 12);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(120, 35);
            this.btnAddRow.TabIndex = 4;
            this.btnAddRow.Text = "Add Row";
            this.btnAddRow.UseVisualStyleBackColor = false;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnProcess.FlatAppearance.BorderSize = 0;
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.ForeColor = System.Drawing.Color.White;
            this.btnProcess.Location = new System.Drawing.Point(690, 9);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(150, 35);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "Generate JSON";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // panelCert
            // 
            this.panelCert.BackColor = System.Drawing.Color.White;
            this.panelCert.Controls.Add(this.label3);
            this.panelCert.Controls.Add(this.txtPfxPath);
            this.panelCert.Controls.Add(this.btnBrowseCert);
            this.panelCert.Controls.Add(this.label4);
            this.panelCert.Controls.Add(this.txtPfxPassword);
            this.panelCert.Controls.Add(this.btnLoadCert);
            this.panelCert.Location = new System.Drawing.Point(15, 345);
            this.panelCert.Name = "panelCert";
            this.panelCert.Padding = new System.Windows.Forms.Padding(10);
            this.panelCert.Size = new System.Drawing.Size(870, 65);
            this.panelCert.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "PFX Path (*.pfx):";
            // 
            // txtPfxPath
            // 
            this.txtPfxPath.Location = new System.Drawing.Point(120, 17);
            this.txtPfxPath.Name = "txtPfxPath";
            this.txtPfxPath.Size = new System.Drawing.Size(250, 25);
            this.txtPfxPath.TabIndex = 1;
            // 
            // btnBrowseCert
            // 
            this.btnBrowseCert.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseCert.Location = new System.Drawing.Point(380, 17);
            this.btnBrowseCert.Name = "btnBrowseCert";
            this.btnBrowseCert.Size = new System.Drawing.Size(80, 25);
            this.btnBrowseCert.TabIndex = 2;
            this.btnBrowseCert.Text = "Browse…";
            this.btnBrowseCert.Click += new System.EventHandler(this.btnBrowseCert_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(480, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "PFX Password:";
            // 
            // txtPfxPassword
            // 
            this.txtPfxPassword.Location = new System.Drawing.Point(590, 17);
            this.txtPfxPassword.Name = "txtPfxPassword";
            this.txtPfxPassword.PasswordChar = '*';
            this.txtPfxPassword.Size = new System.Drawing.Size(120, 25);
            this.txtPfxPassword.TabIndex = 4;
            // 
            // btnLoadCert
            // 
            this.btnLoadCert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnLoadCert.FlatAppearance.BorderSize = 0;
            this.btnLoadCert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadCert.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadCert.ForeColor = System.Drawing.Color.White;
            this.btnLoadCert.Location = new System.Drawing.Point(720, 15);
            this.btnLoadCert.Name = "btnLoadCert";
            this.btnLoadCert.Size = new System.Drawing.Size(120, 27);
            this.btnLoadCert.TabIndex = 5;
            this.btnLoadCert.Text = "Load Cert";
            this.btnLoadCert.UseVisualStyleBackColor = false;
            this.btnLoadCert.Click += new System.EventHandler(this.btnLoadCert_Click);
            // 
            // lblCertStatus
            // 
            this.lblCertStatus.AutoSize = true;
            this.lblCertStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.lblCertStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCertStatus.ForeColor = System.Drawing.Color.White;
            this.lblCertStatus.Location = new System.Drawing.Point(602, 413);
            this.lblCertStatus.Name = "lblCertStatus";
            this.lblCertStatus.Size = new System.Drawing.Size(76, 17);
            this.lblCertStatus.TabIndex = 4;
            this.lblCertStatus.Text = "Not loaded";
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOutput.ForeColor = System.Drawing.Color.Black;
            this.txtOutput.Location = new System.Drawing.Point(15, 433);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(870, 417);
            this.txtOutput.TabIndex = 3;
            this.txtOutput.WordWrap = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(605, 856);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 39);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(735, 856);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 39);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(900, 900);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.panelTransaction);
            this.Controls.Add(this.panelCert);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.lblCertStatus);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secure Transaction UI ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.panelTransaction.ResumeLayout(false);
            this.panelTransaction.PerformLayout();
            this.panelCert.ResumeLayout(false);
            this.panelCert.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
