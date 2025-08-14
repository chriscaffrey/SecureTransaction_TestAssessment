using System;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace SecureTransactionApp_DataGrid
{
    /// <summary>
    /// Simple login form that authenticates users against an in-memory mock database (DataSet)
    /// with passwords stored as MD5 hashes.
    /// </summary>
    public partial class LoginForm : Form
    {
        // Simulated database (in-memory dataset)
        private DataSet _mockDb;

        public LoginForm()
        {
            InitializeComponent();

            // Bind Enter key events to move between fields or trigger login
            txtUsername.KeyDown += TxtUsername_KeyDown;
            txtPassword.KeyDown += TxtPassword_KeyDown;

            // Run setup code when the form loads
            this.Load += LoginForm_Load;
        }

        /// <summary>
        /// Generates an MD5 hash from a plain text string.
        /// </summary>
        /// <param name="text">Input string (e.g., password).</param>
        /// <returns>Hexadecimal lowercase MD5 hash string.</returns>
        private string MD5Encrypt(string text)
        {
            using (MD5 md5 = MD5.Create())
            {
                // Convert text to bytes
                byte[] inputBytes = Encoding.UTF8.GetBytes(text);

                // Compute MD5 hash
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert bytes to lowercase hex string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Initializes the mock database with a "Users" table containing usernames and MD5-hashed passwords.
        /// </summary>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            _mockDb = new DataSet();

            // Create the Users table with Username and PasswordHash columns
            DataTable usersTable = new DataTable("Users");
            usersTable.Columns.Add("Username", typeof(string));
            usersTable.Columns.Add("PasswordHash", typeof(string));

            // Insert sample users (passwords hashed with MD5)
            usersTable.Rows.Add("admin", MD5Encrypt("password"));
            usersTable.Rows.Add("cashier", MD5Encrypt("123456"));
            usersTable.Rows.Add("manager", MD5Encrypt("securepass"));

            // Add the table to the mock dataset
            _mockDb.Tables.Add(usersTable);

            // Put cursor focus on username input at startup
            txtUsername.Focus();
        }

        /// <summary>
        /// Handles Enter key in username box: moves focus to password box.
        /// </summary>
        private void TxtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();     // Move to password field
                e.Handled = true;        // Mark event as handled
                e.SuppressKeyPress = true; // Prevent the 'ding' sound
            }
        }

        /// <summary>
        /// Handles Enter key in password box: triggers login button click.
        /// </summary>
        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick(); // Simulate login button click
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Verifies entered username and password against the mock database.
        /// If valid, opens MainForm; otherwise, shows error message.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string passwordHash = MD5Encrypt(txtPassword.Text.Trim()); // Hash entered password

            // Query mock database for a matching username/password hash
            DataTable users = _mockDb.Tables["Users"];
            DataRow[] foundUsers = users.Select($"Username = '{username}' AND PasswordHash = '{passwordHash}'");

            if (foundUsers.Length > 0)
            {
                // Successful login → open main application form
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                // Failed login → show alert
                MessageBox.Show("Invalid credentials!");
            }
        }
    }
}
