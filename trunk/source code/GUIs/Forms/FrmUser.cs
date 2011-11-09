using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using EzPos.Model.Common;
using EzPos.Model.User;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Service.User;

namespace EzPos.GUIs.Forms
{
    public partial class FrmUser : Form
    {
        private CommonService _commonService;
        private bool _isModified;
        private User _user;
        private UserService _userService;

        public FrmUser()
        {
            InitializeComponent();
        }

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        private void SetModifydStatus(bool modifyStatus)
        {
            _isModified = modifyStatus;
            btnSave.Enabled = modifyStatus;
        }

        private void ModificationHandler(object sender, EventArgs e)
        {
            SetModifydStatus(true);
        }

        private void CmbCategoryEnter(object sender, EventArgs e)
        {
            cmbGender.SelectedIndexChanged += ModificationHandler;
        }

        private void CmbMaritalStatus_Enter(object sender, EventArgs e)
        {
            cmbMaritalStatus.SelectedIndexChanged += ModificationHandler;
        }

        private void CmbPositionEnter(object sender, EventArgs e)
        {
            cmbPosition.SelectedIndexChanged += ModificationHandler;
        }

        private void TxtPhotoPathTextChanged(object sender, EventArgs e)
        {
            SetModifydStatus(true);
        }

        private void CmbCategoryLeave(object sender, EventArgs e)
        {
            cmbGender.SelectedIndexChanged -= ModificationHandler;
            cmbGender.TextChanged -= ModificationHandler;
        }

        private void CmbMaritalStatusLeave(object sender, EventArgs e)
        {
            cmbMaritalStatus.SelectedIndexChanged -= ModificationHandler;
        }

        private void CmbPositionLeave(object sender, EventArgs e)
        {
            cmbPosition.SelectedIndexChanged -= ModificationHandler;
        }

        private void TxtSalaryLeave(object sender, EventArgs e)
        {
            txtSalary.TextChanged -= ModificationHandler;
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            if (_userService == null)
                _userService = ServiceFactory.GenerateServiceInstance().GenerateUserService();
            if (_commonService == null)
                _commonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

            ThreadStart threadStart = UpdateControlContent;
            var thread = new Thread(threadStart);
            thread.Start();

            SetUserInfo();
            txtPhotoPath.TextChanged += TxtPhotoPathTextChanged;
        }

        private void SetUserInfo()
        {
            if (_user == null)
                return;

            txtUserName.Text = _user.UserName;
            dtpBirthDate.Value = _user.BirthDate;
            txtPhoneNumber.Text = _user.PhoneNumber;
            txtAddress.Text = _user.Address;
            dtpStartingDate.Value = _user.StartingDate;
            txtSalary.Text = _user.Salary.ToString("N");
            txtLogInName.Text = _user.LogInName;
            txtPassword.Text = _user.Password;
            txtPhotoPath.Text = _user.PhotoPath;
            if (_user.PhotoPath == null)
                ptbUser.Image = Resources.NoImage;
            else
                ptbUser.ImageLocation = _user.PhotoPath;
        }

        private void PtbProductClick(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
                                     {
                                         Filter = Resources.ConstExtensionImage,
                                         Multiselect = false
                                     };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ptbUser.ImageLocation = openFileDialog.FileName;
                txtPhotoPath.Text = openFileDialog.FileName;
            }
            openFileDialog.Dispose();
        }

        private void BtnSaveClick(object sender, EventArgs e)
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
                                                 PermissionId =
                                                     ((Permission) clbPermission.Items[counter]).PermissionId
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

                if (_user == null)
                    _user = new User();
                _user.UserName = txtUserName.Text;
                _user.GenderId = int.Parse(cmbGender.SelectedValue.ToString());
                _user.GenderStr = cmbGender.Text;
                _user.MaritalStatusId = int.Parse(cmbMaritalStatus.SelectedValue.ToString());
                _user.MaritalStatusStr = cmbMaritalStatus.Text;
                _user.BirthDate = dtpBirthDate.Value;
                _user.PhoneNumber = txtPhoneNumber.Text;
                _user.Address = txtAddress.Text;
                _user.PositionId = int.Parse(cmbPosition.SelectedValue.ToString());
                _user.PositionStr = cmbPosition.Text;
                _user.ContractId = int.Parse(cmbContractType.SelectedValue.ToString());
                _user.ContractStr = cmbContractType.Text;
                _user.StartingDate = dtpStartingDate.Value;
                _user.Salary = float.Parse(txtSalary.Text);
                _user.LogInName = txtLogInName.Text;
                _user.Password = txtPassword.Text;
                _user.PhotoPath = txtPhotoPath.Text.Length == 0 ? _user.PhotoPath : txtPhotoPath.Text;

                if (_userService == null)
                    _userService = ServiceFactory.GenerateServiceInstance().GenerateUserService();

                _userService.UserManagement(_user, permissionList,
                                            _user.UserId != 0
                                                ? Resources.OperationRequestUpdate
                                                : Resources.OperationRequestInsert);

                if (AppContext.User == null)
                    return;

                if (_user.UserId == AppContext.User.UserId)
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

        private void ClbFeatureItemCheck(object sender, ItemCheckEventArgs e)
        {
            SetModifydStatus(true);
        }

        private void ClbPermissionEnter(object sender, EventArgs e)
        {
            clbPermission.ItemCheck += ClbFeatureItemCheck;
        }

        private void ClbPermissionLeave(object sender, EventArgs e)
        {
            clbPermission.ItemCheck -= ClbFeatureItemCheck;
        }

        private void TxtSalaryEnter(object sender, EventArgs e)
        {
            txtSalary.TextChanged += ModificationHandler;
        }

        private void UpdateControlContent()
        {
            if (_userService == null)
                _userService = ServiceFactory.GenerateServiceInstance().GenerateUserService();

            SafeCrossCallBackDelegate safeCrossCallBackDelegate = null;
            if (cmbGender.InvokeRequired)
                safeCrossCallBackDelegate = UpdateControlContent;

            if (cmbGender.InvokeRequired)
                Invoke(safeCrossCallBackDelegate);
            else
            {
                var searchCriteria = new List<string> {"ParameterTypeId IN (8, 10, 11, 12)"};
                var objList = _commonService.GetAppParameters(searchCriteria);

                _commonService.PopAppParamExtendedCombobox(
                    ref cmbGender, objList, int.Parse(Resources.AppParamGender), true);

                _commonService.PopAppParamExtendedCombobox(
                    ref cmbMaritalStatus, objList, int.Parse(Resources.AppParamMaritalStatus), true);

                _commonService.PopAppParamExtendedCombobox(
                    ref cmbPosition, objList, int.Parse(Resources.AppParamPosition), true);

                _commonService.PopAppParamExtendedCombobox(
                    ref cmbContractType, objList, int.Parse(Resources.AppParamContractType), true);

                objList = _userService.GetPermissions();
                clbPermission.DataSource = objList;
                if (((IList) clbPermission.DataSource).Count != 0)
                {
                    clbPermission.DisplayMember = Permission.ConstPermissionLabel;
                    clbPermission.ValueMember = Permission.ConstPermissionId;
                }

                if (_user != null)
                {
                    if (((IList) cmbGender.DataSource).Count != 0)
                        cmbGender.SelectedValue = _user.GenderId;
                    if (((IList) cmbMaritalStatus.DataSource).Count != 0)
                        cmbMaritalStatus.SelectedValue = _user.MaritalStatusId;
                    if (((IList) cmbPosition.DataSource).Count != 0)
                        cmbPosition.SelectedValue = _user.PositionId;
                    if (((IList) cmbContractType.DataSource).Count != 0)
                        cmbContractType.SelectedValue = _user.ContractId;

                    objList = _userService.GetPermissionsByUser(_user.UserId);
                    if (objList.Count != 0)
                    {
                        foreach (UserPermission usrPermission in objList)
                        {
                            for (int counter = 0; counter < clbPermission.Items.Count; counter++)
                            {
                                if (usrPermission.PermissionId ==
                                    ((Permission) clbPermission.Items[counter]).PermissionId)
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

        private void TxtUserNameEnter(object sender, EventArgs e)
        {
            txtUserName.TextChanged += ModificationHandler;
        }

        private void TxtUserNameLeave(object sender, EventArgs e)
        {
            txtUserName.TextChanged -= ModificationHandler;
        }

        private void DtpBirthDateEnter(object sender, EventArgs e)
        {
            dtpBirthDate.ValueChanged += ModificationHandler;
        }

        private void DtpBirthDateLeave(object sender, EventArgs e)
        {
            dtpBirthDate.ValueChanged -= ModificationHandler;
        }

        private void TxtPhoneNumberEnter(object sender, EventArgs e)
        {
            txtPhoneNumber.TextChanged += ModificationHandler;
        }

        private void TxtPhoneNumberLeave(object sender, EventArgs e)
        {
            txtPhoneNumber.TextChanged -= ModificationHandler;
        }

        private void TxtAddressEnter(object sender, EventArgs e)
        {
            txtAddress.TextChanged += ModificationHandler;
        }

        private void TxtAddressLeave(object sender, EventArgs e)
        {
            txtAddress.TextChanged -= ModificationHandler;
        }

        private void CmbContractTypeEnter(object sender, EventArgs e)
        {
            cmbContractType.SelectedIndexChanged += ModificationHandler;
        }

        private void CmbContractTypeLeave(object sender, EventArgs e)
        {
            cmbContractType.SelectedIndexChanged -= ModificationHandler;
        }

        private void DtpStartingDateEnter(object sender, EventArgs e)
        {
            dtpStartingDate.ValueChanged += ModificationHandler;
        }

        private void DtpStartingDateLeave(object sender, EventArgs e)
        {
            dtpStartingDate.ValueChanged -= ModificationHandler;
        }

        private void TxtLogInNameEnter(object sender, EventArgs e)
        {
            txtLogInName.TextChanged += ModificationHandler;
        }

        private void TxtLogInNameLeave(object sender, EventArgs e)
        {
            txtLogInName.TextChanged -= ModificationHandler;
        }

        private void TxtPasswordEnter(object sender, EventArgs e)
        {
            txtPassword.TextChanged += ModificationHandler;
        }

        private void TxtPasswordLeave(object sender, EventArgs e)
        {
            txtPassword.TextChanged -= ModificationHandler;
        }

        private void FrmUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((DialogResult == DialogResult.Cancel) && (_isModified))
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

            if (_isModified) 
                return;

            DialogResult = DialogResult.Cancel;
            return;
        }

        private void BtnSaveMouseEnter(object sender, EventArgs e)
        {
            btnSave.BackgroundImage = Resources.background_9;
        }

        private void BtnSaveMouseLeave(object sender, EventArgs e)
        {
            btnSave.BackgroundImage = Resources.background_2;
        }

        private void BtnCancelMouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_9;
        }

        private void BtnCancelMouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_2;
        }

        #region Nested type: SafeCrossCallBackDelegate

        private delegate void SafeCrossCallBackDelegate();

        #endregion
    }
}