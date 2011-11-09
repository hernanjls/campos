using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using EzPos.GUIs.Forms;
using EzPos.Model;
using EzPos.Model.Common;
using EzPos.Model.User;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Service.User;
using EzPos.Utility;

namespace EzPos.GUIs.Controls
{
    public partial class CtrlUser : UserControl
    {
        private CommonService _CommonService;
        private BindingList<User> _UserList;
        private UserService _UserService;

        public CtrlUser()
        {
            InitializeComponent();
        }

        public UserService UserService
        {
            set { _UserService = value; }
        }

        public CommonService CommonService
        {
            set { _CommonService = value; }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionAddUser))
            {
                const string briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                var detailMsg = Resources.MsgUserPermissionDeny;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                    return;
                }

                //ExtendedMessageBox.InformMessage(Resources.MsgUserPermissionDeny);
                //return;
            }

            UserManagement(Resources.OperationRequestInsert);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string briefMsg, detailMsg;

            if (!UserService.AllowToPerform(Resources.PermissionDeleteUser))
            {
                briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                detailMsg = Resources.MsgUserPermissionDeny;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                    return;
                }

                //ExtendedMessageBox.InformMessage(Resources.MsgUserPermissionDeny);
                //return;
            }

            //if (!ExtendedMessageBox.ConfirmMessage(
            //    "MsgOperationRequestDelete",
            //    "\n\n" + dgvUser.CurrentRow.Cells["UserName"].Value))
            //    return;
            //string briefMsg, detailMsg;
            briefMsg = "អំពីការលុប";
            detailMsg = Resources.MsgOperationRequestDelete + "\n" +
                        dgvUser.CurrentRow.Cells["UserName"].Value + " ?";
            using (var frmMessageBox = new FrmExtendedMessageBox())
            {
                frmMessageBox.BriefMsgStr = briefMsg;
                frmMessageBox.DetailMsgStr = detailMsg;
                if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            try
            {
                _UserService.UserManagement(
                    _UserList[dgvUser.CurrentRow.Index],
                    null,
                    Resources.OperationRequestDelete);

                _UserList.RemoveAt(dgvUser.CurrentRow.Index);
                dgvUser.Refresh();
                UpdateResultInfo();
                EnableActionButton();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void CtrlUser_Load(object sender, EventArgs e)
        {
            if (_UserService == null)
                _UserService = ServiceFactory.GenerateServiceInstance().GenerateUserService();

            if (_CommonService == null)
                _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();
            if (!UserService.AllowToPerform(Resources.PermissionViewUserResultInfo))
            {
                lblResultInfo.Visible = false;
            }
            if (!UserService.AllowToPerform(Resources.PermissionViewUserResultInfo))
            {
                lblResultInfo.Visible = false;
            }
            InitializeUserList();

            ThreadStart threadStart = UpdateControlContent;
            var thread = new Thread(threadStart) {IsBackground = true};
            thread.Start();

            IListToBindingList(_UserService.GetUsers());
            dgvUser.Refresh();
        }

        private void dgvUser_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            FrmExtendedMessageBox.UnknownErrorMessage(
                Resources.MsgCaptionUnknownError,
                e.Exception.Message);
        }

        private void dgvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionEditUser))
            {
                const string briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                var detailMsg = Resources.MsgUserPermissionDeny;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                    return;
                }

                //ExtendedMessageBox.InformMessage(Resources.MsgUserPermissionDeny);
                //return;
            }

            UserManagement(Resources.OperationRequestUpdate);
        }

        private void InitializeUserList()
        {
            try
            {
                if (_UserList == null)
                    _UserList = new BindingList<User>();

                dgvUser.DataSource = _UserList;
                dgvUser.Columns["UserName"].DisplayIndex = 0;
                dgvUser.Columns["PhoneNumber"].DisplayIndex = 1;
                dgvUser.Columns["GenderStr"].DisplayIndex = 2;
                dgvUser.Columns["PositionStr"].DisplayIndex = 3;
                dgvUser.Columns["LogInName"].DisplayIndex = 4;
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void IListToBindingList(IList userList)
        {
            if (userList == null)
                throw new ArgumentNullException("userList", "User List");

            if (_UserList == null)
                return;

            _UserList.Clear();
            foreach (User user in userList)
                _UserList.Add(user);

            UpdateResultInfo();
            EnableActionButton();
        }

        private void EnableActionButton()
        {
            btnDelete.Enabled = _UserList.Count != 0;

            SetFocusToUserList();
        }

        private void SetFocusToUserList()
        {
            if (dgvUser.CanFocus)
                dgvUser.Focus();
        }

        private void UserManagement(IEquatable<string> operationRequest)
        {
            using (var frmUser = new FrmUser())
            {
                if (operationRequest.Equals(Resources.OperationRequestUpdate))
                    if (dgvUser.CurrentRow != null) frmUser.User = _UserList[dgvUser.CurrentRow.Index];

                if (frmUser.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        if ((operationRequest.Equals(Resources.OperationRequestInsert)))
                            _UserList.Add(frmUser.User);
                        dgvUser.Refresh();
                        UpdateResultInfo();
                        EnableActionButton();
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

        private void UpdateResultInfo()
        {
            var resultNum = 0;
            if (_UserList != null)
                resultNum = _UserList.Count;

            var strResultInfo = string.Format(
                "ការសែ្វងរករបស់អ្នកផ្តល់លទ្ឋផលចំនួន {0}",
                resultNum.ToString("N0", AppContext.CultureInfo));
            lblResultInfo.Text = strResultInfo;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUserName.Text = string.Empty;
            cmbGender.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            txtPhoneNumber.Text = string.Empty;
            btnSearch_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchCriteria = new List<string>();
            if (StringHelper.Length(txtUserName.Text) != 0)
                searchCriteria.Add("UserName LIKE '%" + txtUserName.Text + "%'");

            if (cmbGender.SelectedIndex != -1)
                searchCriteria.Add("GenderId|" + cmbGender.SelectedValue);

            if (cmbPosition.SelectedIndex != -1)
                searchCriteria.Add("PositionId|" + cmbPosition.SelectedValue);

            if (StringHelper.Length(txtPhoneNumber.Text) != 0)
                searchCriteria.Add("PhoneNumber LIKE '%" + txtPhoneNumber.Text + "%'");

            IListToBindingList(
                _UserService.GetUsers(searchCriteria));
            dgvUser.Refresh();
        }

        private void UpdateControlContent()
        {
            SafeCrossCallBackDelegate safeCrossCallBackDelegate = null;
            if ((cmbGender.InvokeRequired) || (cmbPosition.InvokeRequired))
                safeCrossCallBackDelegate = UpdateControlContent;

            if (cmbGender.InvokeRequired)
                Invoke(safeCrossCallBackDelegate);
            else
            {
                var searchCriteria = new List<string> {"ParameterTypeId IN (8, 10)"};

                var objList = _CommonService.GetAppParameters(searchCriteria);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbGender, objList, int.Parse(Resources.AppParamGender, AppContext.CultureInfo), false);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbPosition, objList, int.Parse(Resources.AppParamPosition, AppContext.CultureInfo), false);
            }
        }

        private void btnNew_MouseEnter(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = Resources.background_9;
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackgroundImage = Resources.background_9;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackgroundImage = null;
        }

        private void btnNew_MouseLeave(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = null;
        }

        #region Nested type: SafeCrossCallBackDelegate

        private delegate void SafeCrossCallBackDelegate();

        #endregion
    }
}