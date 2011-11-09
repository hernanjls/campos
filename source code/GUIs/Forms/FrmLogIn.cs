using System;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Model.User;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.User;

namespace EzPos.GUIs.Forms
{
    public partial class FrmLogIn : Form
    {
        private UserService _userService;

        public FrmLogIn()
        {
            InitializeComponent();
        }

        public UserService UserService
        {
            set { _userService = value; }
        }

        public User User { get; private set; }

        private void FrmLogIn_Load(object sender, EventArgs e)
        {
            if (_userService == null)
                _userService = ServiceFactory.GenerateServiceInstance().GenerateUserService();
        }

        private void ShowErrorMessage()
        {
            const string briefMsg = "អំពីការចូលទៅក្នុងប្រព័ន្ឋ";
            var detailMsg = Resources.MsgOperationRequestLogInFail;
            using (var frmMessageBox = new FrmExtendedMessageBox())
            {
                frmMessageBox.BriefMsgStr = briefMsg;
                frmMessageBox.DetailMsgStr = detailMsg;
                frmMessageBox.IsCanceledOnly = true;
                frmMessageBox.ShowDialog(this);
            }
        }

        private void BtnLogInClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogIn.Text) || string.IsNullOrEmpty(txtPwd.Text))
            {
                ShowErrorMessage();
                return;
            }

            try
            {
                User = _userService.GetUser(txtLogIn.Text, txtPwd.Text);
                if (User == null)
                {
                    const string briefMsg = "អំពីការចូលទៅក្នុងប្រព័ន្ឋ";
                    var detailMsg = Resources.MsgOperationRequestLogInFail;
                    using (var frmMessageBox = new FrmExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }
    }
}