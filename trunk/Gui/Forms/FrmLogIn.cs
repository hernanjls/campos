using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;

namespace EzPos.GUI.Forms
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
            var briefMsg = "អំពីការចូលទៅក្នុងប្រព័ន្ឋ";
            var detailMsg = Resources.MsgOperationRequestLogInFail;
            using (var frmMessageBox = new FrmMessageBox())
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
                var searchCriteria = new List<string> {"LogInName|" + txtLogIn.Text, "Password|" + txtPwd.Text};
                var userList = _UserService.GetUsers(searchCriteria);
                if(userList == null)
                {
                    var briefMsg = "អំពីការចូលទៅក្នុងប្រព័ន្ឋ";
                    var detailMsg = Resources.MsgOperationRequestLogInFail;
                    using (var frmMessageBox = new FrmMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }

                if(userList.Count == 0)
                {
                    var briefMsg = "អំពីការចូលទៅក្នុងប្រព័ន្ឋ";
                    var detailMsg = Resources.MsgOperationRequestLogInFail;
                    using (var frmMessageBox = new FrmMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }

                _User = userList[0] as User;
                if (_User == null)
                {
                    var briefMsg = "អំពីការចូលទៅក្នុងប្រព័ន្ឋ";
                    var detailMsg = Resources.MsgOperationRequestLogInFail;
                    using (var frmMessageBox = new FrmMessageBox())
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