using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using EzPos.Control;
using EzPos.GUI.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;

namespace EzPos.GUI
{
    /// <summary>
    /// Summary description for FrmUser.
    /// </summary>
    public class FrmUser : FrmBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private readonly Container components;

        private User _CurrentUser;
        private bool _IsModified;
        private IList _PermissionList;
        private bool _SkipAllowed;
        private BindingList<object> _UserBindingList;
        private UserService _UserService;
        private ComboBox cbbContractType;
        private ComboBox cbbMaritalStatus;
        private ComboBox cbbPosition;
        private ComboBox cbbSex;
        private CheckedListBox clbPermission;
        private Button cmdCancel;

        private Button cmdDeleteUser;
        private Button cmdNewUser;
        private Button cmdReset;
        private Button cmdSave;
        private Button cmdSearchUser;
        private DateTimePicker dtpBirthDate;
        private DateTimePicker dtpContractStartDate;
        private GroupBox grbLine_1;
        private GroupBox grbLine_2;
        private GroupBox grbPurchaseHistory;
        private GroupBox grbUserInfo;
        private Label lblAddress;
        private Label lblBaseSalary;
        private Label lblBirthDate;
        private Label lblContractStartDate;
        private Label lblContractType;
        private Label lblIDNumber;
        private Label lblLogIn;
        private Label lblMaritalStatus;
        private Label lblPassword;
        private Label lblPhoneNumber;
        private Label lblPosition;
        private Label lblSex;
        private Label lblUserName;
        private ListBox lsbUser;
        private RichTextBox rtbAddress;
        private TextBox txtBaseSalary;
        private TextBox txtIDNumber;
        private TextBox txtLogIn;
        private TextBox txtPassword;
        private TextBox txtPhoneNumber;
        private TextBox txtUserName;
        private TextBox txtUserSearch;

        public FrmUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            if (txtUserSearch.CanFocus)
                txtUserSearch.Focus();

            try
            {
                //if (!UserService.AllowToPerform(global::PharmaStock.Properties.Resources.PermissionUSRMNG))
                //    Application.Exit();

                if (_UserService == null)
                    _UserService = ServiceFactory.GenerateServiceInstance().GenerateUserService();

                IList objectList;
                objectList = _UserService.GetSex();
                cbbSex.DataSource = objectList;
                cbbSex.ValueMember = Sex.CONST_SEX_ID;
                cbbSex.DisplayMember = Sex.CONST_SEX_LABEL;

                objectList = _UserService.GetMaritalStatus();
                cbbMaritalStatus.DataSource = objectList;
                cbbMaritalStatus.ValueMember = MaritalStatus.CONST_MARITALSTATUS_ID;
                cbbMaritalStatus.DisplayMember = MaritalStatus.CONST_MARITALSTATUS_LABEL;

                objectList = _UserService.GetPositions();
                cbbPosition.DataSource = objectList;
                cbbPosition.ValueMember = Position.CONST_POSITION_ID;
                cbbPosition.DisplayMember = Position.CONST_POSITION_LABEL;

                objectList = _UserService.GetContractTypes();
                cbbContractType.DataSource = objectList;
                cbbContractType.ValueMember = ContractType.CONST_CONCTRACT_TYPE_ID;
                cbbContractType.DisplayMember = ContractType.CONST_CONCTRACT_TYPE_LABEL;

                _PermissionList = _UserService.GetPermissions();
                clbPermission.DataSource = _PermissionList;
                clbPermission.ValueMember = Permission.CONST_PERMISSION_ID;
                clbPermission.DisplayMember = Permission.CONST_PERMISSION_LABEL;

                PopulateUserList();
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }

            lblHeader.Text = "User management";
            cmd3.Enabled = false;
        }

        private void PopulateUserList()
        {
            _UserBindingList = CommonService.IListToBindingList(_UserService.GetUsers());
            lsbUser.ValueMember = User.CONST_USER_ID;
            lsbUser.DisplayMember = User.CONST_USER_NAME;
            lsbUser.DataSource = _UserBindingList;
        }

        private void cmdDeleteUser_Click(object sender, EventArgs e)
        {
            if (lsbUser.SelectedIndex == -1)
                return;

            if (!MessageBoxHandler.ConfirmMessage("Operation.Request.Delete",
                                                  _CurrentUser.LogInName))
                return;
            object objResult;
            objResult = _UserService.UserManagement(
                _CurrentUser,
                null,
                Resources.OperationRequestDelete);
            if (objResult != null)
            {
                MessageBoxHandler.UnknownErrorMessage(
                    Resources.MessageCaptionUnknownError,
                    objResult.ToString());
                return;
            }
            _UserBindingList.RemoveAt(lsbUser.SelectedIndex);
        }

        private void lsbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_SkipAllowed)
            {
                _SkipAllowed = false;
                return;
            }

            //If there is anything changed
            if (_IsModified)
            {
                if (!MessageBoxHandler.ConfirmMessage("Operation.Request.Cancel", ""))
                {
                    _SkipAllowed = true;
                    lsbUser.SelectedValue = _CurrentUser.UserID;
                    return;
                }
            }

            if ((lsbUser.DisplayMember == "") || (lsbUser.ValueMember == ""))
                return;

            if (lsbUser.SelectedIndex == -1)
            {
                _CurrentUser = new User();
                cmdDeleteUser.Enabled = false;
                return;
            }

            SetUserInfo(true);
        }

        private void SetUserInfo(bool refreshUserPermission)
        {
            _CurrentUser = (User) lsbUser.SelectedItem;
            txtLogIn.Text = _CurrentUser.LogInName;
            txtPassword.Text = _CurrentUser.Password;
            txtIDNumber.Text = _CurrentUser.IDNumber;
            txtUserName.Text = _CurrentUser.UserName;
            cbbSex.SelectedValue = _CurrentUser.SexID;
            dtpBirthDate.Value = (DateTime) _CurrentUser.BirthDate;
            cbbMaritalStatus.SelectedValue = _CurrentUser.MaritalStatusID;
            cbbPosition.SelectedValue = _CurrentUser.PositionID;
            txtPhoneNumber.Text = _CurrentUser.PhoneNumber;
            rtbAddress.Text = _CurrentUser.Address;

            dtpContractStartDate.Value = (DateTime) _CurrentUser.ContractStartDate;
            txtBaseSalary.Text = _CurrentUser.BaseSalary.ToString();
            cbbContractType.SelectedValue = _CurrentUser.ContractTypeID;

            _IsModified = false;
            cmdNewUser.Enabled = true;
            cmdDeleteUser.Enabled = true;
            cmdSave.Enabled = false;
            cmdCancel.Enabled = false;
            cmdReset.Enabled = false;

            if (refreshUserPermission)
                SetUserPermission();
        }

        private void ModificationHandler(object sender, EventArgs e)
        {
            SetModifydStatus(true);
        }

        private void SetModifydStatus(bool modifyStatus)
        {
            if (_CurrentUser == null)
                return;
            _IsModified = modifyStatus;
            cmdSave.Enabled = _IsModified;
            cmdCancel.Enabled = _IsModified;
            cmdNewUser.Enabled = !_IsModified;
            cmdDeleteUser.Enabled = !_IsModified;
        }

        private void txtIDNumber_Enter(object sender, EventArgs e)
        {
            txtIDNumber.TextChanged += ModificationHandler;
        }

        private void txtIDNumber_Leave(object sender, EventArgs e)
        {
            txtIDNumber.TextChanged -= ModificationHandler;
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            txtUserName.TextChanged += ModificationHandler;
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            txtUserName.TextChanged -= ModificationHandler;
        }

        private void cbbSex_Enter(object sender, EventArgs e)
        {
            cbbSex.SelectedIndexChanged += ModificationHandler;
        }

        private void cbbSex_Leave(object sender, EventArgs e)
        {
            cbbSex.SelectedIndexChanged -= ModificationHandler;
        }

        private void dtpBirthDate_Enter(object sender, EventArgs e)
        {
            dtpBirthDate.TextChanged += ModificationHandler;
        }

        private void dtpBirthDate_Leave(object sender, EventArgs e)
        {
            dtpBirthDate.TextChanged -= ModificationHandler;
        }

        private void cbbMaritalStatus_Enter(object sender, EventArgs e)
        {
            cbbMaritalStatus.SelectedIndexChanged += ModificationHandler;
        }

        private void cbbMaritalStatus_Leave(object sender, EventArgs e)
        {
            cbbMaritalStatus.SelectedIndexChanged -= ModificationHandler;
        }

        private void cbbPosition_Enter(object sender, EventArgs e)
        {
            cbbPosition.SelectedIndexChanged += ModificationHandler;
        }

        private void cbbPosition_Leave(object sender, EventArgs e)
        {
            cbbPosition.SelectedIndexChanged -= ModificationHandler;
        }

        private void txtPhoneNumber_Enter(object sender, EventArgs e)
        {
            txtPhoneNumber.TextChanged += ModificationHandler;
        }

        private void txtPhoneNumber_Leave(object sender, EventArgs e)
        {
            txtPhoneNumber.TextChanged -= ModificationHandler;
        }

        private void rtbAddress_Enter(object sender, EventArgs e)
        {
            rtbAddress.TextChanged += ModificationHandler;
        }

        private void rtbAddress_Leave(object sender, EventArgs e)
        {
            rtbAddress.TextChanged -= ModificationHandler;
        }

        private void dtpContractStartDate_Enter(object sender, EventArgs e)
        {
            dtpContractStartDate.TextChanged += ModificationHandler;
        }

        private void dtpContractStartDate_Leave(object sender, EventArgs e)
        {
            dtpContractStartDate.TextChanged -= ModificationHandler;
        }

        private void txtBaseSalary_Enter(object sender, EventArgs e)
        {
            txtBaseSalary.TextChanged += ModificationHandler;
        }

        private void txtBaseSalary_Leave(object sender, EventArgs e)
        {
            txtBaseSalary.TextChanged -= ModificationHandler;
        }

        private void cbbContractType_Enter(object sender, EventArgs e)
        {
            cbbContractType.SelectedIndexChanged += ModificationHandler;
        }

        private void cbbContractType_Leave(object sender, EventArgs e)
        {
            cbbContractType.SelectedIndexChanged -= ModificationHandler;
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            ResetUserInfo();
        }

        private void ResetUserInfo()
        {
            txtLogIn.Text = "";
            txtPassword.Text = "";
            txtIDNumber.Text = "";
            txtUserName.Text = "";
            cbbSex.SelectedIndex = -1;
            dtpBirthDate.Value = DateTime.Now;
            cbbMaritalStatus.SelectedIndex = -1;
            cbbPosition.SelectedIndex = -1;
            txtPhoneNumber.Text = "";
            rtbAddress.Text = "";
            dtpContractStartDate.Value = DateTime.Now;
            txtBaseSalary.Text = "0.0";
            cbbContractType.SelectedIndex = -1;

            int totalItem = clbPermission.Items.Count;
            for (int itemIndex = 0; itemIndex < totalItem; itemIndex++)
                clbPermission.SetItemChecked(itemIndex, false);
        }

        private void cmdNewUser_Click(object sender, EventArgs e)
        {
            lsbUser.SelectedIndex = -1;
            lsbUser.Enabled = false;
            cmdNewUser.Enabled = false;
            cmdReset.Enabled = true;
            cmdSave.Enabled = true;
            cmdCancel.Enabled = true;
            _IsModified = true;

            ResetUserInfo();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (_IsModified)
            {
                if (MessageBoxHandler.ConfirmMessage("Operation.Request.Cancel", ""))
                {
                    _IsModified = false;
                    lsbUser.Enabled = true;
                    if (lsbUser.SelectedIndex == -1)
                        lsbUser.SelectedIndex = 0;
                    else
                        lsbUser_SelectedIndexChanged(sender, e);
                }
                else
                    return;
            }
            lsbUser.Enabled = true;
            cmdNewUser.Enabled = true;
            cmdDeleteUser.Enabled = true;
            cmdReset.Enabled = false;
            cmdSave.Enabled = false;
            cmdCancel.Enabled = false;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_IsModified)
                {
                    // Pre save
                    if (txtLogIn.Text.Length == 0)
                    {
                        MessageBox.Show("LogInName");
                        return;
                    }

                    if (txtPassword.Text.Length == 0)
                    {
                        MessageBox.Show("Password");
                        return;
                    }

                    if (txtIDNumber.Text.Length == 0)
                    {
                        MessageBox.Show("ID Number");
                        return;
                    }

                    if (txtUserName.Text.Length == 0)
                    {
                        MessageBox.Show("User name");
                        return;
                    }

                    var userPermissionList = new List<UserPermission>();
                    int permissionNum = ((IList) clbPermission.DataSource).Count;
                    for (int counter = 0; counter < permissionNum; counter++)
                    {
                        if (clbPermission.GetItemChecked(counter))
                        {
                            var userPermission = new UserPermission();
                            userPermission.PermissionID =
                                ((Permission) clbPermission.Items[counter]).PermissionID;
                            userPermissionList.Add(userPermission);
                        }
                    }

                    if (userPermissionList.Count == 0)
                    {
                        MessageBox.Show("Please select at least one permission.");
                        return;
                    }

                    _CurrentUser.IDNumber = txtIDNumber.Text;
                    _CurrentUser.LogInName = txtLogIn.Text;
                    _CurrentUser.Password = txtPassword.Text;
                    _CurrentUser.UserName = txtUserName.Text;
                    _CurrentUser.SexID = cbbSex.SelectedValue == null ? 0 : Int32.Parse(cbbSex.SelectedValue.ToString());
                    _CurrentUser.BirthDate = dtpBirthDate.Value;
                    _CurrentUser.MaritalStatusID = cbbMaritalStatus.SelectedValue == null
                                                       ? 0
                                                       : Int32.Parse(cbbMaritalStatus.SelectedValue.ToString());
                    _CurrentUser.PositionID = cbbPosition.SelectedValue == null
                                                  ? 0
                                                  : Int32.Parse(cbbPosition.SelectedValue.ToString());
                    _CurrentUser.PhoneNumber = txtPhoneNumber.Text;
                    _CurrentUser.Address = rtbAddress.Text;
                    _CurrentUser.ContractStartDate = dtpContractStartDate.Value;
                    _CurrentUser.BaseSalary = float.Parse(txtBaseSalary.Text);
                    _CurrentUser.ContractTypeID = cbbContractType.SelectedValue == null
                                                      ? 0
                                                      : Int32.Parse(cbbContractType.SelectedValue.ToString());

                    SetModifydStatus(false);
                    // Saving
                    if (_CurrentUser.UserID == 0)
                    {
                        _UserService.UserManagement(
                            _CurrentUser,
                            userPermissionList,
                            Resources.OperationRequestInsert);
                        _UserBindingList.Add(_CurrentUser);
                    }
                    else
                    {
                        _UserService.UserManagement(
                            _CurrentUser,
                            userPermissionList,
                            Resources.OperationRequestUpdate);
                        _SkipAllowed = true;
                        _UserBindingList[lsbUser.SelectedIndex] = _CurrentUser;
                    }

                    // Post save                
                    cmdCancel_Click(sender, e);
                }
            }
            catch (Exception exception)
            {
                SetModifydStatus(true);
                MessageBoxHandler.UnknownErrorMessage(Resources.MessageCaptionUnknownError, exception.Message);
            }
        }

        //private void clbUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if((clbUserGroup.ValueMember == "") || (clbUserGroup.DisplayMember == ""))
        //        return;

        //    if(clbUserGroup.SelectedIndex == -1)
        //        return;

        //    _PermmissionByGroup = CommonService.IListToBindingList(_UserService.GetPermissionByGroup(
        //        _GroupPermmissionList, Int32.Parse(clbUserGroup.SelectedValue.ToString())));

        //    clbPermission.DataSource = _PermmissionByGroup;
        //    clbPermission.ValueMember = GroupPermission.CONST_GROUP_PERMISSION_ID;
        //    clbPermission.DisplayMember = GroupPermission.CONST_PERMISSION_LABEL;

        //    if (clbUserGroup.CheckedItems.Count == 0)
        //        return;

        //    if(clbUserGroup.SelectedValue == null)
        //        return;

        //    AutoCheckUserGroupPermission(((Group) clbUserGroup.SelectedItem).GroupID);
        //}	    

        private void SetUserPermission()
        {
            if (_CurrentUser == null)
                return;

            try
            {
                clbPermission.ItemCheck -= clbUserPermission_ItemCheck;
                IList objList = _UserService.GetPermissions(_CurrentUser.UserID);

                for (int counter = 0; counter < clbPermission.Items.Count; counter++)
                    clbPermission.SetItemChecked(counter, false);

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
                clbPermission.ItemCheck += clbUserPermission_ItemCheck;
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        //private void clbUserGroup_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //    if(_CurrentUser == null)
        //        return;

        //    if(e.Index == clbUserGroup.SelectedIndex)
        //    {                
        //        if (!"Checked".Equals(e.NewValue.ToString()))
        //        {
        //            if (e.CurrentValue.ToString().Equals("Checked"))
        //            {
        //                e.NewValue = CheckState.Checked;
        //                MessageBox.Show("At least one group");
        //                return;                        
        //            }                                                            
        //        }
        //        else
        //        {
        //            ManualCheckUserGroup(e.Index);
        //            _UserGroupPermissionList.Clear();

        //            foreach (GroupPermission groupPermission in _PermmissionByGroup)
        //            {
        //                UserGroupPermission userGroupPermission = new UserGroupPermission();
        //                userGroupPermission.GroupID = groupPermission.GroupID;
        //                userGroupPermission.PermissionID = groupPermission.PermissionID;
        //                userGroupPermission.UserID = _CurrentUser.UserID;

        //                _UserGroupPermissionList.Add(userGroupPermission);
        //            }
        //        }
        //        SetModifydStatus(true);
        //    }                        
        //}

        //private void AutoCheckUserGroup(int groupID)
        //{
        //    //int totalItem = clbUserGroup.Items.Count;
        //    //clbUserGroup.ItemCheck -= new ItemCheckEventHandler(clbUserGroup_ItemCheck);
        //    //for (int itemIndex = 0; itemIndex < totalItem; itemIndex++)
        //    //{
        //    //    if (groupID == ((Group)clbUserGroup.Items[itemIndex]).GroupID)
        //    //        clbUserGroup.SetItemChecked(itemIndex, true);
        //    //    else
        //    //        clbUserGroup.SetItemChecked(itemIndex, false);
        //    //}
        //    //clbUserGroup.ItemCheck += new ItemCheckEventHandler(clbUserGroup_ItemCheck);            
        //    //AutoCheckUserGroupPermission(groupID);
        //}

        //private void AutoCheckUserGroupPermission(int groupID)
        //{                     
        //    if(clbPermission.DataSource == null)
        //        return;

        //    int totalItem = clbPermission.Items.Count;
        //    clbPermission.ItemCheck -= new ItemCheckEventHandler(clbUserPermission_ItemCheck);

        //    for (int itemIndex = 0; itemIndex < totalItem; itemIndex++)
        //    {
        //        if (_UserGroupPermissionList.Count == 0)
        //            clbPermission.SetItemChecked(itemIndex, false);
        //        else
        //        {
        //            if (groupID != ((Group)clbUserGroup.CheckedItems[0]).GroupID)
        //                clbPermission.SetItemChecked(itemIndex, false);
        //            else
        //            {
        //                if(groupID != ((GroupPermission)clbPermission.Items[0]).GroupID)
        //                    clbPermission.SetItemChecked(itemIndex, false);
        //                else
        //                {
        //                    int permissionID = ((GroupPermission)clbPermission.Items[itemIndex]).PermissionID;
        //                    foreach (UserGroupPermission userGroupPermission in _UserGroupPermissionList)
        //                    {
        //                        if (permissionID == userGroupPermission.PermissionID)
        //                        {
        //                            clbPermission.SetItemChecked(itemIndex, true);
        //                            break;
        //                        }
        //                        clbPermission.SetItemChecked(itemIndex, false);
        //                    }                                                                        
        //                }
        //            }
        //        }
        //    }

        //    if (((UserGroupPermission)_UserGroupPermissionList[0]).GroupID !=
        //        Int32.Parse(clbUserGroup.SelectedValue.ToString()))
        //        clbPermission.Enabled = false;
        //    else
        //        clbPermission.Enabled = true;

        //    clbPermission.ItemCheck += clbUserPermission_ItemCheck;            
        //}

        //private void ManualCheckUserGroup(int selectedIndex)
        //{
        //    int totalItem = clbUserGroup.Items.Count;
        //    for (int itemIndex = 0; itemIndex < totalItem; itemIndex++)
        //    {
        //        if (itemIndex != selectedIndex)
        //            clbUserGroup.SetItemChecked(itemIndex, false);
        //    }

        //    SetCheckToUserGroupPermission();	        
        //}

        //private void SetCheckToUserGroupPermission()
        //{            
        //    //if(_CurrentUser == null)
        //    //    return;

        //    //if(_UserGroupPermissionList == null)
        //    //    AutoCheckUserGroupPermission(
        //    //        "Checked".Equals(clbUserGroup.GetItemCheckState(clbUserGroup.SelectedIndex).ToString()));
        //    //else if(_UserGroupPermissionList.Count == 0)
        //    //    AutoCheckUserGroupPermission(
        //    //        "Checked".Equals(clbUserGroup.GetItemCheckState(clbUserGroup.SelectedIndex).ToString()));
        //    //else
        //    //{
        //    //    if (((UserGroupPermission)_UserGroupPermissionList[0]).GroupID != ((Group)clbUserGroup.SelectedItem).GroupID)
        //    //        AutoCheckUserGroupPermission(
        //    //            "Checked".Equals(clbUserGroup.GetItemCheckState(clbUserGroup.SelectedIndex).ToString()));
        //    //    else
        //    //        ManualCheckUserGroupPermission();
        //    //}
        //}

        //private void ManualCheckUserGroupPermission()
        //{
        //    //int totalItem = clbPermission.Items.Count;

        //    //for (int itemIndex = 0; itemIndex < totalItem; itemIndex++)
        //    //{
        //    //    int permissionID = ((GroupPermission)clbPermission.Items[itemIndex]).PermissionID;
        //    //    foreach (UserGroupPermission userGroupPermission in _UserGroupPermissionList)
        //    //    {
        //    //        if (permissionID == userGroupPermission.PermissionID)
        //    //        {
        //    //            clbPermission.SetItemChecked(itemIndex, true);
        //    //            break;
        //    //        }
        //    //        clbPermission.SetItemChecked(itemIndex, false);
        //    //    }
        //    //}
        //}

        //private void AutoCheckUserGroupPermission(bool checkState)
        //{
        //    int totalItem = clbPermission.Items.Count;
        //    for (int itemIndex = 0; itemIndex < totalItem; itemIndex++)
        //        clbPermission.SetItemChecked(itemIndex, checkState);
        //}

        private void clbUserPermission_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_CurrentUser == null)
                return;

            //if (e.Index == clbPermission.SelectedIndex)
            //{
            //    if (!"Checked".Equals(e.NewValue.ToString()))
            //    {                    
            //        if (_UserGroupPermissionList.Count == 1)
            //        {
            //            e.NewValue = CheckState.Checked;
            //            MessageBox.Show("At least one permission");
            //            return;
            //        }

            //        foreach (UserGroupPermission userGroupPermission in _UserGroupPermissionList)
            //        {
            //            if (userGroupPermission.PermissionID == ((GroupPermission)clbPermission.SelectedItem).PermissionID)
            //            {
            //                _UserGroupPermissionList.Remove(userGroupPermission);
            //                break;
            //            }
            //        }                    
            //    }
            //    else
            //    {
            //        UserGroupPermission userGroupPermission = new UserGroupPermission();
            //        userGroupPermission.GroupID = ((GroupPermission)clbPermission.SelectedItem).GroupID;
            //        userGroupPermission.PermissionID = ((GroupPermission)clbPermission.SelectedItem).PermissionID;
            //        userGroupPermission.UserID = _CurrentUser.UserID;

            //        _UserGroupPermissionList.Add(userGroupPermission);
            //    }
            //}
            SetModifydStatus(true);
        }

        private void txtLogIn_Enter(object sender, EventArgs e)
        {
            txtLogIn.TextChanged += ModificationHandler;
        }

        private void txtLogIn_Leave(object sender, EventArgs e)
        {
            txtLogIn.TextChanged -= ModificationHandler;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.TextChanged += ModificationHandler;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtPassword.TextChanged -= ModificationHandler;
        }

        private void txtUserSearch_TextChanged(object sender, EventArgs e)
        {
            lsbUser.SelectedIndex = lsbUser.FindString(txtUserSearch.Text);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdSearchUser = new System.Windows.Forms.Button();
            this.cmdDeleteUser = new System.Windows.Forms.Button();
            this.cmdNewUser = new System.Windows.Forms.Button();
            this.txtUserSearch = new System.Windows.Forms.TextBox();
            this.lsbUser = new System.Windows.Forms.ListBox();
            this.grbUserInfo = new System.Windows.Forms.GroupBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblLogIn = new System.Windows.Forms.Label();
            this.txtLogIn = new System.Windows.Forms.TextBox();
            this.cbbContractType = new System.Windows.Forms.ComboBox();
            this.cbbMaritalStatus = new System.Windows.Forms.ComboBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.dtpContractStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.cbbSex = new System.Windows.Forms.ComboBox();
            this.grbLine_2 = new System.Windows.Forms.GroupBox();
            this.grbLine_1 = new System.Windows.Forms.GroupBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.cbbPosition = new System.Windows.Forms.ComboBox();
            this.lblBaseSalary = new System.Windows.Forms.Label();
            this.txtBaseSalary = new System.Windows.Forms.TextBox();
            this.lblContractType = new System.Windows.Forms.Label();
            this.lblMaritalStatus = new System.Windows.Forms.Label();
            this.lblContractStartDate = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.rtbAddress = new System.Windows.Forms.RichTextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblIDNumber = new System.Windows.Forms.Label();
            this.txtIDNumber = new System.Windows.Forms.TextBox();
            this.grbPurchaseHistory = new System.Windows.Forms.GroupBox();
            this.clbPermission = new System.Windows.Forms.CheckedListBox();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.pnlBody.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.grbUserInfo.SuspendLayout();
            this.grbPurchaseHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.cmdReset);
            this.pnlBody.Controls.Add(this.cmdCancel);
            this.pnlBody.Controls.Add(this.cmdSave);
            this.pnlBody.Controls.Add(this.grbPurchaseHistory);
            this.pnlBody.Controls.Add(this.grbUserInfo);
            this.pnlBody.Controls.Add(this.cmdSearchUser);
            this.pnlBody.Controls.Add(this.cmdDeleteUser);
            this.pnlBody.Controls.Add(this.cmdNewUser);
            this.pnlBody.Controls.Add(this.txtUserSearch);
            this.pnlBody.Controls.Add(this.lsbUser);
            this.pnlBody.Size = new System.Drawing.Size(1016, 581);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(1016, 75);
            // 
            // cmdSearchUser
            // 
            this.cmdSearchUser.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                              System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdSearchUser.Image = Resources.Search32;
            this.cmdSearchUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearchUser.Location = new System.Drawing.Point(209, 9);
            this.cmdSearchUser.Name = "cmdSearchUser";
            this.cmdSearchUser.Size = new System.Drawing.Size(89, 28);
            this.cmdSearchUser.TabIndex = 1;
            this.cmdSearchUser.Text = "&Search";
            this.cmdSearchUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSearchUser.UseVisualStyleBackColor = true;
            // 
            // cmdDeleteUser
            // 
            this.cmdDeleteUser.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                              System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdDeleteUser.Image = Resources.Delete32;
            this.cmdDeleteUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDeleteUser.Location = new System.Drawing.Point(209, 582);
            this.cmdDeleteUser.Name = "cmdDeleteUser";
            this.cmdDeleteUser.Size = new System.Drawing.Size(89, 28);
            this.cmdDeleteUser.TabIndex = 4;
            this.cmdDeleteUser.Text = "&Delete";
            this.cmdDeleteUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDeleteUser.UseVisualStyleBackColor = true;
            this.cmdDeleteUser.Click += new System.EventHandler(this.cmdDeleteUser_Click);
            // 
            // cmdNewUser
            // 
            this.cmdNewUser.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                           System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdNewUser.Location = new System.Drawing.Point(118, 582);
            this.cmdNewUser.Name = "cmdNewUser";
            this.cmdNewUser.Size = new System.Drawing.Size(89, 28);
            this.cmdNewUser.TabIndex = 3;
            this.cmdNewUser.Text = "&New";
            this.cmdNewUser.UseVisualStyleBackColor = true;
            this.cmdNewUser.Click += new System.EventHandler(this.cmdNewUser_Click);
            // 
            // txtUserSearch
            // 
            this.txtUserSearch.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                              System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtUserSearch.Location = new System.Drawing.Point(14, 14);
            this.txtUserSearch.Name = "txtUserSearch";
            this.txtUserSearch.Size = new System.Drawing.Size(189, 23);
            this.txtUserSearch.TabIndex = 0;
            this.txtUserSearch.TextChanged += new System.EventHandler(this.txtUserSearch_TextChanged);
            // 
            // lsbUser
            // 
            this.lsbUser.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                                                        System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lsbUser.FormattingEnabled = true;
            this.lsbUser.HorizontalScrollbar = true;
            this.lsbUser.ItemHeight = 22;
            this.lsbUser.Location = new System.Drawing.Point(14, 43);
            this.lsbUser.Name = "lsbUser";
            this.lsbUser.Size = new System.Drawing.Size(284, 532);
            this.lsbUser.TabIndex = 2;
            this.lsbUser.SelectedIndexChanged += new System.EventHandler(this.lsbUser_SelectedIndexChanged);
            // 
            // grbUserInfo
            // 
            this.grbUserInfo.Controls.Add(this.lblPassword);
            this.grbUserInfo.Controls.Add(this.txtPassword);
            this.grbUserInfo.Controls.Add(this.lblLogIn);
            this.grbUserInfo.Controls.Add(this.txtLogIn);
            this.grbUserInfo.Controls.Add(this.cbbContractType);
            this.grbUserInfo.Controls.Add(this.cbbMaritalStatus);
            this.grbUserInfo.Controls.Add(this.dtpBirthDate);
            this.grbUserInfo.Controls.Add(this.dtpContractStartDate);
            this.grbUserInfo.Controls.Add(this.lblBirthDate);
            this.grbUserInfo.Controls.Add(this.lblSex);
            this.grbUserInfo.Controls.Add(this.cbbSex);
            this.grbUserInfo.Controls.Add(this.grbLine_2);
            this.grbUserInfo.Controls.Add(this.grbLine_1);
            this.grbUserInfo.Controls.Add(this.lblPosition);
            this.grbUserInfo.Controls.Add(this.cbbPosition);
            this.grbUserInfo.Controls.Add(this.lblBaseSalary);
            this.grbUserInfo.Controls.Add(this.txtBaseSalary);
            this.grbUserInfo.Controls.Add(this.lblContractType);
            this.grbUserInfo.Controls.Add(this.lblMaritalStatus);
            this.grbUserInfo.Controls.Add(this.lblContractStartDate);
            this.grbUserInfo.Controls.Add(this.lblAddress);
            this.grbUserInfo.Controls.Add(this.rtbAddress);
            this.grbUserInfo.Controls.Add(this.lblPhoneNumber);
            this.grbUserInfo.Controls.Add(this.txtPhoneNumber);
            this.grbUserInfo.Controls.Add(this.lblUserName);
            this.grbUserInfo.Controls.Add(this.txtUserName);
            this.grbUserInfo.Controls.Add(this.lblIDNumber);
            this.grbUserInfo.Controls.Add(this.txtIDNumber);
            this.grbUserInfo.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.grbUserInfo.Location = new System.Drawing.Point(311, 3);
            this.grbUserInfo.Name = "grbUserInfo";
            this.grbUserInfo.Size = new System.Drawing.Size(700, 282);
            this.grbUserInfo.TabIndex = 5;
            this.grbUserInfo.TabStop = false;
            this.grbUserInfo.Text = "ពត៍មានអំពីបុគ្គលិក";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblPassword.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPassword.Location = new System.Drawing.Point(355, 28);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(86, 24);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "ពាក្យសំងាត់";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtPassword.Location = new System.Drawing.Point(481, 27);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(205, 23);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // lblLogIn
            // 
            this.lblLogIn.AutoSize = true;
            this.lblLogIn.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                         System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblLogIn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLogIn.Location = new System.Drawing.Point(10, 28);
            this.lblLogIn.Name = "lblLogIn";
            this.lblLogIn.Size = new System.Drawing.Size(53, 24);
            this.lblLogIn.TabIndex = 0;
            this.lblLogIn.Text = "គណនី";
            // 
            // txtLogIn
            // 
            this.txtLogIn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                         System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtLogIn.Location = new System.Drawing.Point(136, 27);
            this.txtLogIn.Name = "txtLogIn";
            this.txtLogIn.Size = new System.Drawing.Size(205, 23);
            this.txtLogIn.TabIndex = 1;
            this.txtLogIn.Enter += new System.EventHandler(this.txtLogIn_Enter);
            this.txtLogIn.Leave += new System.EventHandler(this.txtLogIn_Leave);
            // 
            // cbbContractType
            // 
            this.cbbContractType.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cbbContractType.FormattingEnabled = true;
            this.cbbContractType.Location = new System.Drawing.Point(136, 241);
            this.cbbContractType.Name = "cbbContractType";
            this.cbbContractType.Size = new System.Drawing.Size(205, 26);
            this.cbbContractType.TabIndex = 27;
            this.cbbContractType.Leave += new System.EventHandler(this.cbbContractType_Leave);
            this.cbbContractType.Enter += new System.EventHandler(this.cbbContractType_Enter);
            // 
            // cbbMaritalStatus
            // 
            this.cbbMaritalStatus.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                 System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cbbMaritalStatus.FormattingEnabled = true;
            this.cbbMaritalStatus.Location = new System.Drawing.Point(136, 119);
            this.cbbMaritalStatus.Name = "cbbMaritalStatus";
            this.cbbMaritalStatus.Size = new System.Drawing.Size(205, 26);
            this.cbbMaritalStatus.TabIndex = 14;
            this.cbbMaritalStatus.Leave += new System.EventHandler(this.cbbMaritalStatus_Leave);
            this.cbbMaritalStatus.Enter += new System.EventHandler(this.cbbMaritalStatus_Enter);
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.CalendarFont = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                                                                     System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.dtpBirthDate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                             System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(481, 90);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(205, 23);
            this.dtpBirthDate.TabIndex = 12;
            this.dtpBirthDate.Enter += new System.EventHandler(this.dtpBirthDate_Enter);
            this.dtpBirthDate.Leave += new System.EventHandler(this.dtpBirthDate_Leave);
            // 
            // dtpContractStartDate
            // 
            this.dtpContractStartDate.CalendarFont = new System.Drawing.Font("Trebuchet MS", 12F,
                                                                             System.Drawing.FontStyle.Bold,
                                                                             System.Drawing.GraphicsUnit.Point,
                                                                             ((byte) (0)));
            this.dtpContractStartDate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F,
                                                                     System.Drawing.FontStyle.Bold,
                                                                     System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.dtpContractStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpContractStartDate.Location = new System.Drawing.Point(136, 215);
            this.dtpContractStartDate.Name = "dtpContractStartDate";
            this.dtpContractStartDate.Size = new System.Drawing.Size(205, 23);
            this.dtpContractStartDate.TabIndex = 23;
            this.dtpContractStartDate.Enter += new System.EventHandler(this.dtpContractStartDate_Enter);
            this.dtpContractStartDate.Leave += new System.EventHandler(this.dtpContractStartDate_Leave);
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                             System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblBirthDate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblBirthDate.Location = new System.Drawing.Point(355, 91);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(119, 24);
            this.lblBirthDate.TabIndex = 11;
            this.lblBirthDate.Text = "ថ្ងៃ ខែ ឆ្នាំកំណើត";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                       System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblSex.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSex.Location = new System.Drawing.Point(10, 91);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(38, 24);
            this.lblSex.TabIndex = 9;
            this.lblSex.Text = "ភេទ";
            // 
            // cbbSex
            // 
            this.cbbSex.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                       System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cbbSex.FormattingEnabled = true;
            this.cbbSex.Location = new System.Drawing.Point(136, 90);
            this.cbbSex.Name = "cbbSex";
            this.cbbSex.Size = new System.Drawing.Size(205, 26);
            this.cbbSex.TabIndex = 10;
            this.cbbSex.Leave += new System.EventHandler(this.cbbSex_Leave);
            this.cbbSex.Enter += new System.EventHandler(this.cbbSex_Enter);
            // 
            // grbLine_2
            // 
            this.grbLine_2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_2.Location = new System.Drawing.Point(13, 207);
            this.grbLine_2.Name = "grbLine_2";
            this.grbLine_2.Size = new System.Drawing.Size(675, 2);
            this.grbLine_2.TabIndex = 21;
            this.grbLine_2.TabStop = false;
            // 
            // grbLine_1
            // 
            this.grbLine_1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_1.Location = new System.Drawing.Point(13, 56);
            this.grbLine_1.Name = "grbLine_1";
            this.grbLine_1.Size = new System.Drawing.Size(675, 2);
            this.grbLine_1.TabIndex = 4;
            this.grbLine_1.TabStop = false;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblPosition.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPosition.Location = new System.Drawing.Point(10, 152);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(43, 24);
            this.lblPosition.TabIndex = 15;
            this.lblPosition.Text = "ឋានៈ";
            // 
            // cbbPosition
            // 
            this.cbbPosition.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cbbPosition.FormattingEnabled = true;
            this.cbbPosition.Location = new System.Drawing.Point(136, 148);
            this.cbbPosition.Name = "cbbPosition";
            this.cbbPosition.Size = new System.Drawing.Size(205, 26);
            this.cbbPosition.TabIndex = 16;
            this.cbbPosition.Leave += new System.EventHandler(this.cbbPosition_Leave);
            this.cbbPosition.Enter += new System.EventHandler(this.cbbPosition_Enter);
            // 
            // lblBaseSalary
            // 
            this.lblBaseSalary.AutoSize = true;
            this.lblBaseSalary.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                              System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblBaseSalary.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblBaseSalary.Location = new System.Drawing.Point(355, 215);
            this.lblBaseSalary.Name = "lblBaseSalary";
            this.lblBaseSalary.Size = new System.Drawing.Size(60, 24);
            this.lblBaseSalary.TabIndex = 24;
            this.lblBaseSalary.Text = "ប្រាក់ខែ";
            // 
            // txtBaseSalary
            // 
            this.txtBaseSalary.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                              System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtBaseSalary.Location = new System.Drawing.Point(481, 214);
            this.txtBaseSalary.Name = "txtBaseSalary";
            this.txtBaseSalary.Size = new System.Drawing.Size(205, 23);
            this.txtBaseSalary.TabIndex = 25;
            this.txtBaseSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBaseSalary.Enter += new System.EventHandler(this.txtBaseSalary_Enter);
            this.txtBaseSalary.Leave += new System.EventHandler(this.txtBaseSalary_Leave);
            // 
            // lblContractType
            // 
            this.lblContractType.AutoSize = true;
            this.lblContractType.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblContractType.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblContractType.Location = new System.Drawing.Point(10, 240);
            this.lblContractType.Name = "lblContractType";
            this.lblContractType.Size = new System.Drawing.Size(115, 24);
            this.lblContractType.TabIndex = 26;
            this.lblContractType.Text = "ប្រភេទកិច្ចសន្យា";
            // 
            // lblMaritalStatus
            // 
            this.lblMaritalStatus.AutoSize = true;
            this.lblMaritalStatus.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                                 System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblMaritalStatus.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblMaritalStatus.Location = new System.Drawing.Point(10, 120);
            this.lblMaritalStatus.Name = "lblMaritalStatus";
            this.lblMaritalStatus.Size = new System.Drawing.Size(81, 24);
            this.lblMaritalStatus.TabIndex = 13;
            this.lblMaritalStatus.Text = "អេតាស៊ីវីល";
            // 
            // lblContractStartDate
            // 
            this.lblContractStartDate.AutoSize = true;
            this.lblContractStartDate.Font = new System.Drawing.Font("Khmer OS System", 9.75F,
                                                                     System.Drawing.FontStyle.Bold,
                                                                     System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblContractStartDate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblContractStartDate.Location = new System.Drawing.Point(10, 216);
            this.lblContractStartDate.Name = "lblContractStartDate";
            this.lblContractStartDate.Size = new System.Drawing.Size(106, 24);
            this.lblContractStartDate.TabIndex = 22;
            this.lblContractStartDate.Text = "ថ្ងៃចុះកិច្ចសន្យា";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                           System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblAddress.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAddress.Location = new System.Drawing.Point(355, 118);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(85, 24);
            this.lblAddress.TabIndex = 19;
            this.lblAddress.Text = "អាស័យដ្ឋាន";
            // 
            // rtbAddress
            // 
            this.rtbAddress.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                           System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.rtbAddress.Location = new System.Drawing.Point(481, 116);
            this.rtbAddress.Name = "rtbAddress";
            this.rtbAddress.Size = new System.Drawing.Size(205, 83);
            this.rtbAddress.TabIndex = 20;
            this.rtbAddress.Text = "";
            this.rtbAddress.Leave += new System.EventHandler(this.rtbAddress_Leave);
            this.rtbAddress.Enter += new System.EventHandler(this.rtbAddress_Enter);
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblPhoneNumber.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPhoneNumber.Location = new System.Drawing.Point(10, 178);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(87, 24);
            this.lblPhoneNumber.TabIndex = 17;
            this.lblPhoneNumber.Text = "លេខទូរស័ព្ទ";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(136, 177);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(205, 23);
            this.txtPhoneNumber.TabIndex = 18;
            this.txtPhoneNumber.Enter += new System.EventHandler(this.txtPhoneNumber_Enter);
            this.txtPhoneNumber.Leave += new System.EventHandler(this.txtPhoneNumber_Leave);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblUserName.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblUserName.Location = new System.Drawing.Point(355, 65);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(99, 24);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "ឈ្មោះបុគ្គលិក";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtUserName.Location = new System.Drawing.Point(481, 64);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(205, 23);
            this.txtUserName.TabIndex = 8;
            this.txtUserName.Enter += new System.EventHandler(this.txtUserName_Enter);
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // lblIDNumber
            // 
            this.lblIDNumber.AutoSize = true;
            this.lblIDNumber.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblIDNumber.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblIDNumber.Location = new System.Drawing.Point(10, 65);
            this.lblIDNumber.Name = "lblIDNumber";
            this.lblIDNumber.Size = new System.Drawing.Size(65, 24);
            this.lblIDNumber.TabIndex = 5;
            this.lblIDNumber.Text = "លេខកូដ";
            // 
            // txtIDNumber
            // 
            this.txtIDNumber.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtIDNumber.Location = new System.Drawing.Point(136, 64);
            this.txtIDNumber.Name = "txtIDNumber";
            this.txtIDNumber.Size = new System.Drawing.Size(205, 23);
            this.txtIDNumber.TabIndex = 6;
            this.txtIDNumber.Enter += new System.EventHandler(this.txtIDNumber_Enter);
            this.txtIDNumber.Leave += new System.EventHandler(this.txtIDNumber_Leave);
            // 
            // grbPurchaseHistory
            // 
            this.grbPurchaseHistory.Controls.Add(this.clbPermission);
            this.grbPurchaseHistory.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold,
                                                                   System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.grbPurchaseHistory.Location = new System.Drawing.Point(311, 285);
            this.grbPurchaseHistory.Name = "grbPurchaseHistory";
            this.grbPurchaseHistory.Size = new System.Drawing.Size(700, 290);
            this.grbPurchaseHistory.TabIndex = 6;
            this.grbPurchaseHistory.TabStop = false;
            this.grbPurchaseHistory.Text = "សិទ្ឋ";
            // 
            // clbPermission
            // 
            this.clbPermission.CheckOnClick = true;
            this.clbPermission.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                              System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.clbPermission.FormattingEnabled = true;
            this.clbPermission.Location = new System.Drawing.Point(14, 35);
            this.clbPermission.Name = "clbPermission";
            this.clbPermission.Size = new System.Drawing.Size(672, 238);
            this.clbPermission.TabIndex = 0;
            this.clbPermission.ItemCheck +=
                new System.Windows.Forms.ItemCheckEventHandler(this.clbUserPermission_ItemCheck);
            // 
            // cmdReset
            // 
            this.cmdReset.Enabled = false;
            this.cmdReset.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                         System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdReset.Location = new System.Drawing.Point(724, 582);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(89, 28);
            this.cmdReset.TabIndex = 7;
            this.cmdReset.Text = "&Reset";
            this.cmdReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Enabled = false;
            this.cmdCancel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                          System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdCancel.Image = Resources.Cancel32;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(908, 582);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(89, 28);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Enabled = false;
            this.cmdSave.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                        System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdSave.Image = Resources.OK32;
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(816, 582);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(89, 28);
            this.cmdSave.TabIndex = 8;
            this.cmdSave.Text = "&Save   ";
            this.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1016, 731);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmUser";
            this.Load += new System.EventHandler(this.FrmUser_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grbUserInfo.ResumeLayout(false);
            this.grbUserInfo.PerformLayout();
            this.grbPurchaseHistory.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}