using System;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;

namespace EzPos.GUIs.Forms
{
    public partial class FrmLogIn : Form
    {
        private User _User;
        private UserService _UserService;

        public FrmLogIn()
        {
            InitializeComponent();
        }

        public UserService UserService
        {
            set { _UserService = value; }
        }

        public User User
        {
            get { return _User; }
        }

        private void FrmLogIn_Load(object sender, EventArgs e)
        {
            if (_UserService == null)
                _UserService = ServiceFactory.GenerateServiceInstance().GenerateUserService();
        }

        private void ShowErrorMessage()
        {
            const string briefMsg = "អំពីការចូលទៅក្នុងប្រព័ន្ឋ";
            var detailMsg = Resources.MsgOperationRequestLogInFail;
            using (var frmMessageBox = new ExtendedMessageBox())
            {
                frmMessageBox.BriefMsgStr = briefMsg;
                frmMessageBox.DetailMsgStr = detailMsg;
                frmMessageBox.IsCanceledOnly = true;
                frmMessageBox.ShowDialog(this);
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogIn.Text) || string.IsNullOrEmpty(txtPwd.Text))
            {
                ShowErrorMessage();
                return;
            }

            try
            {
                _User = _UserService.GetUser(txtLogIn.Text, txtPwd.Text);
                if (_User == null)
                {
                    const string briefMsg = "អំពីការចូលទៅក្នុងប្រព័ន្ឋ";
                    var detailMsg = Resources.MsgOperationRequestLogInFail;
                    using (var frmMessageBox = new ExtendedMessageBox())
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
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }
    }
}