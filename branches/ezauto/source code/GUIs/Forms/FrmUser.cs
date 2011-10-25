using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;

namespace EzPos.GUIs.Forms
{
    public partial class FrmUser : Form
    {
        private CommonService _CommonService;
        private bool _IsModified;
        private User _User;
        private UserService _UserService;

        public FrmUser()
        {
            InitializeComponent();
        }

        public User User
        {
            get { return _User; }
            set { _User = value; }
        }

        private void SetModifydStatus(bool modifyStatus)
        {
            _IsModified = modifyStatus;
            btnSave.Enabled = modifyStatus;
        }

        private void ModificationHandler(object sender, EventArgs e)
        {
            SetModifydStatus(true);
        }

        private void cmbCategory_Enter(object sender, EventArgs e)
        {
            cmbGender.SelectedIndexChanged += ModificationHandler;
        }

        private void CmbMaritalStatus_Enter(object sender, EventArgs e)
        {
            cmbMaritalStatus.SelectedIndexChanged += ModificationHandler;
        }

        private void cmbPosition_Enter(object sender, EventArgs e)
        {
            cmbPosition.SelectedIndexChanged += ModificationHandler;
        }

        private void txtPhotoPath_TextChanged(object sender, EventArgs e)
        {
            SetModifydStatus(true);
        }

        private void cmbCategory_Leave(object sender, EventArgs e)
        {
            cmbGender.SelectedIndexChanged -= ModificationHandler;
            cmbGender.TextChanged -= ModificationHandler;
        }

        private void cmbMaritalStatus_Leave(object sender, EventArgs e)
        {
            cmbMaritalStatus.SelectedIndexChanged -= ModificationHandler;
        }

        private void cmbPosition_Leave(object sender, EventArgs e)
        {
            cmbPosition.SelectedIndexChanged -= ModificationHandler;
        }

        private void txtSalary_Leave(object sender, EventArgs e)
        {
            txtSalary.TextChanged -= ModificationHandler;
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            if (_UserService == null)
                _UserService = ServiceFactory.GenerateServiceInstance().GenerateUserService();
            if (_CommonService == null)
                _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

            ThreadStart threadStart = UpdateControlContent;
            var thread = new Thread(threadStart);
            thread.Start();

            SetUserInfo();
            txtPhotoPath.TextChanged += txtPhotoPath_TextChanged;
        }

        private void SetUserInfo()
        {
            if (_User == null)
                return;

            txtUserName.Text = _User.UserName;
            dtpBirthDate.Value = _User.BirthDate;
            txtPhoneNumber.Text = _User.PhoneNumber;
            txtAddress.Text = _User.Address;
            dtpStartingDate.Value = _User.StartingDate;
            txtSalary.Text = _User.Salary.ToString("N");
            txtLogInName.Text = _User.LogInName;
            txtPassword.Text = _User.Password;
            txtPhotoPath.Text = _User.PhotoPath;
            if (_User.PhotoPath == null)
                ptbUser.Image = Resources.NoImage;
            else
                ptbUser.ImageLocation = _User.PhotoPath;
        }

        private void ptbProduct_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
                                     {
                                         Filter = "All Pictures|*.bmp;*.gif;*.jpg|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg",
                                         Multiselect = false
                                     };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ptbUser.ImageLocation = openFileDialog.FileName;
                txtPhotoPath.Text = openFileDialog.FileName;
            }
            openFileDialog.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cmbGender.SelectedIndex == -1) || (cmbMaritalStatus.SelectedIndex == -1)
                    || (cmbPosition.SelectedIndex == -1) || (cmbContractType.SelectedIndex == -1)
                    || (String.IsNullOrEmpty(txtUserName.Text)) || (String.IsNullOrEmpty(txtLogInName.Text))
                    || (String.IsNullOrEmpty(txtPassword.Text)))
                {
                    const string briefMsg = "អំពីពត៌មាន";
                    var detailMsg = Resources.MsgInvalidData;
                    using (var frmMessageBox = new FrmExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }

                var permissionList = new List<UserPermission>();
                var permissionNum = ((IList) clbPermission.DataSource).Count;
                for (var counter = 0; counter < permissionNum; counter++)
                {
                    if (!clbPermission.GetItemChecked(counter)) 
                        continue;

                    var userPermission = new UserPermission
                                             {
                                                 PermissionID =
                                                     ((Permission) clbPermission.Items[counter]).PermissionID
                                             };
                    permissionList.Add(userPermission);
                }

                if (permissionList.Count == 0)
                {
                    const string briefMsg = "អំពីពត៌មាន";
                    var detailMsg = Resources.MsgInvalidData;
                    using (var frmMessageBox = new FrmExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }

                if (_User == null)
                    _User = new User();
                _User.UserName = txtUserName.Text;
                _User.GenderID = int.Parse(cmbGender.SelectedValue.ToString());
                _User.GenderStr = cmbGender.Text;
                _User.MaritalStatusID = int.Parse(cmbMaritalStatus.SelectedValue.ToString());
                _User.MaritalStatusStr = cmbMaritalStatus.Text;
                _User.BirthDate = dtpBirthDate.Value;
                _User.PhoneNumber = txtPhoneNumber.Text;
                _User.Address = txtAddress.Text;
                _User.PositionID = int.Parse(cmbPosition.SelectedValue.ToString());
                _User.PositionStr = cmbPosition.Text;
                _User.ContractID = int.Parse(cmbContractType.SelectedValue.ToString());
                _User.ContractStr = cmbContractType.Text;
                _User.StartingDate = dtpStartingDate.Value;
                _User.Salary = float.Parse(txtSalary.Text);
                _User.LogInName = txtLogInName.Text;
                _User.Password = txtPassword.Text;
                _User.PhotoPath = txtPhotoPath.Text.Length == 0 ? _User.PhotoPath : txtPhotoPath.Text;

                if (_UserService == null)
                    _UserService = ServiceFactory.GenerateServiceInstance().GenerateUserService();

                if (_User.UserID != 0)
                    _UserService.UserManagement(_User, permissionList,
                                                Resources.OperationRequestUpdate);
                else
                    _UserService.UserManagement(_User, permissionList,
                                                Resources.OperationRequestInsert);

                if (AppContext.User == null)
                    return;

                if (_User.UserID == AppContext.User.UserID)
                    AppContext.UserPermissionList = permissionList;

                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void clbFeature_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            SetModifydStatus(true);
        }

        private void clbPermission_Enter(object sender, EventArgs e)
        {
            clbPermission.ItemCheck += clbFeature_ItemCheck;
        }

        private void clbPermission_Leave(object sender, EventArgs e)
        {
            clbPermission.ItemCheck -= clbFeature_ItemCheck;
        }

        private void txtSalary_Enter(object sender, EventArgs e)
        {
            txtSalary.TextChanged += ModificationHandler;
        }

        private void UpdateControlContent()
        {
            if (_UserService == null)
                _UserService = ServiceFactory.GenerateServiceInstance().GenerateUserService();

            SafeCrossCallBackDelegate safeCrossCallBackDelegate = null;
            if (cmbGender.InvokeRequired)
                safeCrossCallBackDelegate = UpdateControlContent;

            if (cmbGender.InvokeRequired)
                Invoke(safeCrossCallBackDelegate);
            else
            {
                var searchCriteria = new List<string> {"ParameterTypeID IN (8, 10, 11, 12)"};
                var objList = _CommonService.GetAppParameters(searchCriteria);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbGender, objList, int.Parse(Resources.AppParamGender), true);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbMaritalStatus, objList, int.Parse(Resources.AppParamMaritalStatus), true);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbPosition, objList, int.Parse(Resources.AppParamPosition), true);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbContractType, objList, int.Parse(Resources.AppParamContractType), true);

                objList = _UserService.GetPermissions();
                clbPermission.DataSource = objList;
                if (((IList) clbPermission.DataSource).Count != 0)
                {
                    clbPermission.DisplayMember = Permission.CONST_PERMISSION_LABEL;
                    clbPermission.ValueMember = Permission.CONST_PERMISSION_ID;
                }

                if (_User != null)
                {
                    if (((IList) cmbGender.DataSource).Count != 0)
                        cmbGender.SelectedValue = _User.GenderID;
                    if (((IList) cmbMaritalStatus.DataSource).Count != 0)
                        cmbMaritalStatus.SelectedValue = _User.MaritalStatusID;
                    if (((IList) cmbPosition.DataSource).Count != 0)
                        cmbPosition.SelectedValue = _User.PositionID;
                    if (((IList) cmbContractType.DataSource).Count != 0)
                        cmbContractType.SelectedValue = _User.ContractID;

                    objList = _UserService.GetPermissionsByUser(_User.UserID);
                    if (objList.Count != 0)
                    {
                        foreach (UserPermission usrPermission in objList)
                        {
                            for (int counter = 0; counter < clbPermission.Items.Count; counter++)
                            {
                                if (usrPermission.PermissionID ==
                                    ((Permission) clbPermission.Items[counter]).PermissionID)
                                {
                                    clbPermission.SetItemChecked(counter, true);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            txtUserName.TextChanged += ModificationHandler;
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            txtUserName.TextChanged -= ModificationHandler;
        }

        private void dtpBirthDate_Enter(object sender, EventArgs e)
        {
            dtpBirthDate.ValueChanged += ModificationHandler;
        }

        private void dtpBirthDate_Leave(object sender, EventArgs e)
        {
            dtpBirthDate.ValueChanged -= ModificationHandler;
        }

        private void txtPhoneNumber_Enter(object sender, EventArgs e)
        {
            txtPhoneNumber.TextChanged += ModificationHandler;
        }

        private void txtPhoneNumber_Leave(object sender, EventArgs e)
        {
            txtPhoneNumber.TextChanged -= ModificationHandler;
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            txtAddress.TextChanged += ModificationHandler;
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            txtAddress.TextChanged -= ModificationHandler;
        }

        private void cmbContractType_Enter(object sender, EventArgs e)
        {
            cmbContractType.SelectedIndexChanged += ModificationHandler;
        }

        private void cmbContractType_Leave(object sender, EventArgs e)
        {
            cmbContractType.SelectedIndexChanged -= ModificationHandler;
        }

        private void dtpStartingDate_Enter(object sender, EventArgs e)
        {
            dtpStartingDate.ValueChanged += ModificationHandler;
        }

        private void dtpStartingDate_Leave(object sender, EventArgs e)
        {
            dtpStartingDate.ValueChanged -= ModificationHandler;
        }

        private void txtLogInName_Enter(object sender, EventArgs e)
        {
            txtLogInName.TextChanged += ModificationHandler;
        }

        private void txtLogInName_Leave(object sender, EventArgs e)
        {
            txtLogInName.TextChanged -= ModificationHandler;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.TextChanged += ModificationHandler;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtPassword.TextChanged -= ModificationHandler;
        }

        private void FrmUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((DialogResult == DialogResult.Cancel) && (_IsModified))
            {
                const string briefMsg = "អំពីការបោះបង់";
                var detailMsg = Resources.MsgOperationRequestCancel;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            if (_IsModified) 
                return;

            DialogResult = DialogResult.Cancel;
            return;
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackgroundImage = Resources.background_9;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackgroundImage = Resources.background_2;
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_9;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_2;
        }

        #region Nested type: SafeCrossCallBackDelegate

        private delegate void SafeCrossCallBackDelegate();

        #endregion
    }
}