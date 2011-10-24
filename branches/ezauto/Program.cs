using System;
using System.Windows.Forms;
using EzPos.GUIs.Forms;

namespace EzPos
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var frmSplash = new FrmSplash();
            Application.Run(frmSplash);
        }
    }
}