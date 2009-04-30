using System;
using System.Windows.Forms;
using EzPos.Control;
using EzPos.GUI.Forms;

namespace EzPos
{
    internal static class Program
    {
        //public static ApplicationContext applicationContext;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmSplash());
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }
    }
}