using System;
using System.Drawing;
using System.Windows.Forms;
using EzPos.Control;
using EzPos.Service;

namespace EzPos.GUI
{
    public partial class FrmLogIn_ : Form
    {
        public static ApplicationContext _ApplicationContext;
        UserService _UserService;
        
        public FrmLogIn_()
        {
            InitializeComponent();
        }

        [STAThread]
        private static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var frmLogIn = new FrmLogIn_();

                //Keep application context
                _ApplicationContext = new ApplicationContext(frmLogIn);
                Application.Run(_ApplicationContext);
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        private void cmdQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdLogIn_Click(object sender, EventArgs e)
        {
			//Cancel login action if login or pwd is empty
			if (txtLogIn.TextLength == 0)
                MessageBoxHandler.InformMessage("Operation.Request.LogIn.Fail");
			else if (txtPwd.TextLength == 0)
                MessageBoxHandler.InformMessage("Operation.Request.LogIn.Fail");
			
            //Authentication
            try
            {                
                _UserService = ServiceFactory.GenerateServiceInstance().GenerateUserService();

                var _User = _UserService.GetUsers(txtLogIn.Text, txtPwd.Text);
                if (_User == null)
                    MessageBoxHandler.InformMessage("Operation.Request.LogIn.Fail");
                else
                {
                    //Change MainForm of application context                    
                    _ApplicationContext.MainForm = new FrmMain_();
                    CommonService.StoreUserContext(_User);
                    CommonService.StoreApplicationContext();
                    
                    //Close LogIn form
                    Close();

                    if (UserService.AllowToPerform(Properties.Resources.PermissionRCDSAL))
                    {
                        //Open sale form
                        var frmSaleOrder = new FrmSaleOrder();
                        frmSaleOrder.Show();                
                    }                    
                    else
                    {
                        //Open configuration form
                        var frmAvancedOption = new FrmAvancedOption();
                        frmAvancedOption.Show();                                                
                    }
                }
            }
            catch(Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        private void txtLogIn_Enter(object sender, EventArgs e)
        {
            lblLogIn.Font = new Font("Arial", 9F, FontStyle.Bold);
        }

        private void txtLogIn_Leave(object sender, EventArgs e)
        {
            lblLogIn.Font = new Font("Arial", 9F, FontStyle.Regular);
        }

        private void txtPwd_Enter(object sender, EventArgs e)
        {
            lblPassword.Font = new Font("Arial", 9F, FontStyle.Bold);
        }

        private void txtPwd_Leave(object sender, EventArgs e)
        {
            lblPassword.Font = new Font("Arial", 9F, FontStyle.Regular);
        }
    }
}