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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtPfxPath = new System.Windows.Forms.TextBox();
            this.txtPfxPassword = new System.Windows.Forms.TextBox();
            this.btnBrowseCert = new System.Windows.Forms.Button();
            this.btnLoadCert = new System.Windows.Forms.Button();
            this.lblCertStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.Location = new System.Drawing.Point(12, 12);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(760, 220);
            this.dataGrid.TabIndex = 0;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(86, 246);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(120, 20);
            this.txtAmount.TabIndex = 1;
            // 
            // txtCurrency
            // 
            this.txtCurrency.Location = new System.Drawing.Point(302, 246);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(80, 20);
            this.txtCurrency.TabIndex = 2;
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(400, 244);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(90, 23);
            this.btnAddRow.TabIndex = 3;
            this.btnAddRow.Text = "Add Row";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(682, 244);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(90, 23);
            this.btnProcess.TabIndex = 6;
            this.btnProcess.Text = "Generate JSON";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(12, 309);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(760, 240);
            this.txtOutput.TabIndex = 7;
            this.txtOutput.WordWrap = false;
            // 
            // txtPfxPath
            // 
            this.txtPfxPath.Location = new System.Drawing.Point(103, 276);
            this.txtPfxPath.Name = "txtPfxPath";
            this.txtPfxPath.Size = new System.Drawing.Size(371, 20);
            this.txtPfxPath.TabIndex = 4;
            // 
            // txtPfxPassword
            // 
            this.txtPfxPassword.Location = new System.Drawing.Point(566, 275);
            this.txtPfxPassword.Name = "txtPfxPassword";
            this.txtPfxPassword.PasswordChar = '*';
            this.txtPfxPassword.Size = new System.Drawing.Size(120, 20);
            this.txtPfxPassword.TabIndex = 5;
            // 
            // btnBrowseCert
            // 
            this.btnBrowseCert.Location = new System.Drawing.Point(480, 273);
            this.btnBrowseCert.Name = "btnBrowseCert";
            this.btnBrowseCert.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseCert.TabIndex = 8;
            this.btnBrowseCert.Text = "Browse…";
            this.btnBrowseCert.UseVisualStyleBackColor = true;
            this.btnBrowseCert.Click += new System.EventHandler(this.btnBrowseCert_Click);
            // 
            // btnLoadCert
            // 
            this.btnLoadCert.Location = new System.Drawing.Point(692, 273);
            this.btnLoadCert.Name = "btnLoadCert";
            this.btnLoadCert.Size = new System.Drawing.Size(80, 23);
            this.btnLoadCert.TabIndex = 9;
            this.btnLoadCert.Text = "Load Cert";
            this.btnLoadCert.UseVisualStyleBackColor = true;
            this.btnLoadCert.Click += new System.EventHandler(this.btnLoadCert_Click);
            // 
            // lblCertStatus
            // 
            this.lblCertStatus.AutoSize = true;
            this.lblCertStatus.Location = new System.Drawing.Point(12, 555);
            this.lblCertStatus.Name = "lblCertStatus";
            this.lblCertStatus.Size = new System.Drawing.Size(59, 13);
            this.lblCertStatus.TabIndex = 10;
            this.lblCertStatus.Text = "Not loaded";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Currency:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "PFX Path (*.pfx):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(484, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "PFX Password:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 581);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCertStatus);
            this.Controls.Add(this.btnLoadCert);
            this.Controls.Add(this.btnBrowseCert);
            this.Controls.Add(this.txtPfxPassword);
            this.Controls.Add(this.txtPfxPath);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.txtCurrency);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.dataGrid);
            this.Name = "MainForm";
            this.Text = "Secure Transaction UI (DataGrid + Crypto)";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
