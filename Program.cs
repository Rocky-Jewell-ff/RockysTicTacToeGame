using System;
using System.Windows.Forms;
using TicTacToeLibrary.DataAccess;

namespace RockysTicTacToeGame
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GlobalConfig.InitializeConnection(DatabaseType.TextFile);
            Application.Run(new SetUpForm());
        }
    }
}
