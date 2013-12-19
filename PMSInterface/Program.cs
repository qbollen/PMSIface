using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PMSInterface
{
    static class Program
    {
        public static string _username = string.Empty;
        public static string _password = string.Empty;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmLogin frmLogin = new FrmLogin();
            Application.Run(frmLogin);
            if (frmLogin.DialogResult == DialogResult.OK)
            {
                Application.Run(new FrmMain());
            }   
        }
    }
}
