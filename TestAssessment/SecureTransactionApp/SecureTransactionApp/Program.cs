using System;
using System.Windows.Forms;

namespace SecureTransactionApp_DataGrid
{
    internal static class Program
    {
        // Entry point of the application
        [STAThread] // Ensures the app uses a single-threaded apartment model (needed for Windows Forms)
        private static void Main()
        {
            // Enable Windows XP visual styles (modern UI look)
            Application.EnableVisualStyles();

            // Ensure text rendering is consistent across controls
            Application.SetCompatibleTextRenderingDefault(false);

            // Start the application with the LoginForm as the first screen
            Application.Run(new LoginForm());
        }
    }
}
