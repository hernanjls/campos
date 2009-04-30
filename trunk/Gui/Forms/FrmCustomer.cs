using System;
using System.Collections;
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
    /// Summary description for FrmCustomer.
    /// </summary>
    public class FrmCustomer : FrmBase
    {
        private IList _ContactList;
        private Customer _CurrentCustomer;
        private CustomerService _CustomerService;
        private bool _IsContactModified;
        private bool _IsModified, _SkipAllowed;
        private DataGridViewTextBoxColumn Address;
        private Button cmdCancel;

        private Button cmdDeleteCustomer;
        private Button cmdNewCustomer;
        private Button cmdReset;
        private Button cmdSave;
        private Button cmdSearchCustomer;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components;

        private DataGridViewTextBoxColumn ContactID;
        private DataGridViewTextBoxColumn ContactName;
        private DataGridViewComboBoxColumn CourtesyID;
        private DataGridViewTextBoxColumn CustomerID;
        private DataGridView dgvCustomerContact;
        private DataGridViewTextBoxColumn Email;
        private GroupBox grbContactInfo;

        private GroupBox grbCustomerInfo;
        private GroupBox grbLine_1;
        private GroupBox grbLine_2;
        private Label lblAddress;
        private Label lblCustomerCode;
        private Label lblCustomerName;
        private Label lblDebt;
        private Label lblDisplayName;
        private Label lblEmail;
        private Label lblTelephone;
        private Label lblWebsite;
        private ListBox lsbCustomer;
        private RichTextBox rtbAddress;
        private DataGridViewTextBoxColumn Telephone;
        private TextBox txtAmountDebt;
        private TextBox txtCustomerCode;
        private TextBox txtCustomerName;
        private TextBox txtCustomerSearch;
        private TextBox txtDisplayName;
        private TextBox txtEmail;
        private TextBox txtTelephone;
        private TextBox txtWebSite;

        public FrmCustomer()
        {
            //
            // Required for Windows Form Designer support
            //
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

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                //if (!UserService.AllowToPerform(global::PharmaStock.Properties.Resources.PermissionCUSMNG))
                //    Application.Exit();

                _CustomerService = ServiceFactory.GenerateServiceInstance().GenerateCustomerService();
                PopulateCustomerList();
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
            lblHeader.Text = "Customer management";
            cmd4.Enabled = false;
        }

        private void lsbCustomer_SelectedIndexChanged(object sender, EventArgs e)
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
                    lsbCustomer.SelectedValue = _CurrentCustomer.CustomerID;
                    return;
                }
            }

            if ((lsbCustomer.DisplayMember == "") || (lsbCustomer.ValueMember == ""))
                return;

            if (lsbCustomer.SelectedIndex == -1)
            {
                _CurrentCustomer = new Customer();
                cmdDeleteCustomer.Enabled = false;
                return;
            }

            SetCustomerInfo(true);
        }

        private void SetCustomerInfo(bool refreshContact)
        {
            _CurrentCustomer = (Customer) lsbCustomer.SelectedItem;
            txtCustomerName.Text = _CurrentCustomer.CustomerName;
            txtCustomerCode.Text = _CurrentCustomer.CustomerCode;
            txtDisplayName.Text = _CurrentCustomer.DisplayName;
            rtbAddress.Text = _CurrentCustomer.Address;
            txtTelephone.Text = _CurrentCustomer.Telephone;
            txtEmail.Text = _CurrentCustomer.Email;
            txtWebSite.Text = _CurrentCustomer.Website;
            txtAmountDebt.Text = _CurrentCustomer.AmountDebt.ToString();

            _IsModified = false;
            cmdDeleteCustomer.Enabled = true;
            cmdSave.Enabled = false;
            cmdCancel.Enabled = false;
            cmdReset.Enabled = false;

            if (refreshContact)
                SetContactInfo();
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomerSearch.Text.Length != 0)
            {
                lsbCustomer.SelectedIndex = lsbCustomer.FindString(txtCustomerSearch.Text);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_IsModified)
                {
                    if (txtCustomerName.Text.Length == 0)
                    {
                        MessageBox.Show("Customer name");
                        return;
                    }
                    _CurrentCustomer.CustomerName = txtCustomerName.Text;
                    _CurrentCustomer.CustomerCode = txtCustomerCode.Text;
                    _CurrentCustomer.DisplayName = txtDisplayName.Text;
                    _CurrentCustomer.Address = rtbAddress.Text;
                    _CurrentCustomer.Telephone = txtTelephone.Text;
                    _CurrentCustomer.Email = txtEmail.Text;
                    _CurrentCustomer.Website = txtWebSite.Text;
                    _CurrentCustomer.AmountDebt = float.Parse(txtAmountDebt.Text);
                    if (_CurrentCustomer.CustomerID == 0)
                        _CustomerService.CustomerManagement(_CurrentCustomer,
                                                            Resources.OperationRequestInsert);
                    else
                        _CustomerService.CustomerManagement(_CurrentCustomer,
                                                            Resources.OperationRequestUpdate);
                    _IsModified = false;
                    cmdCancel_Click(sender, e);
                    PopulateCustomerList();
                }
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage(
                    Resources.MessageCaptionUnknownError,
                    exception.Message);
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            ResetCustomerInfo();
        }

        private void CmdNewCustomer_Click(object sender, EventArgs e)
        {
            lsbCustomer.SelectedIndex = -1;
            lsbCustomer.Enabled = false;
            cmdNewCustomer.Enabled = false;
            cmdReset.Enabled = true;
            cmdSave.Enabled = true;
            cmdCancel.Enabled = true;
            _IsModified = true;

            ResetCustomerInfo();
        }

        private void CmdDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (lsbCustomer.SelectedIndex == -1)
                return;

            if (!MessageBoxHandler.ConfirmMessage("Operation.Request.Delete",
                                                  _CurrentCustomer.CustomerName))
                return;
            object objResult =
                _CustomerService.CustomerManagement(
                    _CurrentCustomer,
                    Resources.OperationRequestDelete);

            if (objResult != null)
            {
                MessageBoxHandler.UnknownErrorMessage(
                    Resources.MessageCaptionUnknownError,
                    objResult.ToString());
                return;
            }
            PopulateCustomerList();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (_IsModified)
            {
                if (MessageBoxHandler.ConfirmMessage("Operation.Request.Cancel", ""))
                {
                    _IsModified = false;
                    lsbCustomer.Enabled = true;
                    if (lsbCustomer.SelectedIndex == -1)
                        lsbCustomer.SelectedIndex = 0;
                    else
                        lsbCustomer_SelectedIndexChanged(sender, e);
                }
                else
                    return;
            }
            lsbCustomer.Enabled = true;
            cmdNewCustomer.Enabled = true;
            cmdReset.Enabled = false;
            cmdSave.Enabled = false;
            cmdCancel.Enabled = false;
        }

        private void SetModifydStatus(bool modifyStatus)
        {
            _IsModified = modifyStatus;
            cmdSave.Enabled = _IsModified;
            cmdCancel.Enabled = _IsModified;
            if (!cmdNewCustomer.Enabled)
                cmdNewCustomer.Enabled = !_IsModified;
            if (!cmdDeleteCustomer.Enabled)
                cmdDeleteCustomer.Enabled = !_IsModified;
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            SetModifydStatus(true);
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            SetModifydStatus(true);
        }

        private void txtDisplayName_TextChanged(object sender, EventArgs e)
        {
            SetModifydStatus(true);
        }

        private void rtbAddress_TextChanged(object sender, EventArgs e)
        {
            SetModifydStatus(true);
        }

        private void txtWebSite_TextChanged(object sender, EventArgs e)
        {
            SetModifydStatus(true);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            SetModifydStatus(true);
        }

        private void ResetCustomerInfo()
        {
            txtCustomerCode.Text = "";
            txtCustomerName.Text = "";
            txtDisplayName.Text = "";
            rtbAddress.Text = "";
            txtWebSite.Text = "";
            txtTelephone.Text = "";
            txtEmail.Text = "";
            txtAmountDebt.Text = "0.0";
        }

        private void txtCustomerName_Enter(object sender, EventArgs e)
        {
            txtCustomerName.TextChanged += txtCustomerName_TextChanged;
        }

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
            txtCustomerName.TextChanged -= txtCustomerName_TextChanged;
        }

        private void txtCustomerCode_Enter(object sender, EventArgs e)
        {
            txtCustomerCode.TextChanged += txtCustomerCode_TextChanged;
        }

        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            txtCustomerCode.TextChanged -= txtCustomerCode_TextChanged;
        }

        private void txtDisplayName_Enter(object sender, EventArgs e)
        {
            txtDisplayName.TextChanged += txtDisplayName_TextChanged;
        }

        private void txtDisplayName_Leave(object sender, EventArgs e)
        {
            txtDisplayName.TextChanged -= txtDisplayName_TextChanged;
        }

        private void rtbAddress_Enter(object sender, EventArgs e)
        {
            rtbAddress.TextChanged += rtbAddress_TextChanged;
        }

        private void rtbAddress_Leave(object sender, EventArgs e)
        {
            rtbAddress.TextChanged -= rtbAddress_TextChanged;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            txtEmail.TextChanged += txtEmail_TextChanged;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            txtEmail.TextChanged -= txtEmail_TextChanged;
        }

        private void txtWebSite_Enter(object sender, EventArgs e)
        {
            txtWebSite.TextChanged += txtWebSite_TextChanged;
        }

        private void txtWebSite_Leave(object sender, EventArgs e)
        {
            txtWebSite.TextChanged -= txtWebSite_TextChanged;
        }

        private void PopulateCustomerList()
        {
            IList customerList = _CustomerService.GetCustomers();
            lsbCustomer.ValueMember = Customer.CONST_CUSTOMER_ID;
            lsbCustomer.DisplayMember = Customer.CONST_CUSTOMER_NAME;
            lsbCustomer.DataSource = customerList;
        }

        private void dgvCustomerContact_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SetContactModifyStatus(true);
        }

        private void SetContactModifyStatus(bool modifiedStatus)
        {
            _IsContactModified = modifiedStatus;
        }

        private void dgvCustomerContact_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", e.Exception.Message);
        }

        private void dgvCustomerContact_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SetContactModifyStatus(false);
        }

        private void dgvCustomerContact_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!_IsContactModified)
                return;

            if (dgvCustomerContact.Rows[e.RowIndex].Cells["CourtesyID"].Value is DBNull)
                e.Cancel = true;

            if (dgvCustomerContact.Rows[e.RowIndex].Cells["ContactName"].Value is DBNull)
                e.Cancel = true;

            if (e.Cancel)
                return;

            try
            {
                CustomerContact customerContact;
                string requestCode;
                if (dgvCustomerContact.Rows[e.RowIndex].Cells["ContactID"].Value is DBNull)
                {
                    customerContact = new CustomerContact();
                    requestCode = Resources.OperationRequestInsert;
                }
                else
                {
                    customerContact = (CustomerContact) _ContactList[e.RowIndex];
                    requestCode = Resources.OperationRequestUpdate;
                }
                customerContact.CustomerID = _CurrentCustomer.CustomerID;
                customerContact.ContactName = dgvCustomerContact.Rows[e.RowIndex].Cells["ContactName"].Value.ToString();
                customerContact.CourtesyID =
                    Int32.Parse(dgvCustomerContact.Rows[e.RowIndex].Cells["CourtesyID"].Value.ToString());
                customerContact.Address = dgvCustomerContact.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                customerContact.Telephone = dgvCustomerContact.Rows[e.RowIndex].Cells["Telephone"].Value.ToString();
                customerContact.Email = dgvCustomerContact.Rows[e.RowIndex].Cells["Email"].Value.ToString();

                _CustomerService.ContactManagement(customerContact, requestCode);
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        private void SetContactInfo()
        {
            if (_CurrentCustomer == null)
                return;


            if (CourtesyID.DataSource == null)
            {
                CourtesyService courtesyService = ServiceFactory.GenerateServiceInstance().GenerateCourtesyService();
                CourtesyID.DataSource = courtesyService.GetCourtesies();
                CourtesyID.DisplayMember = Courtesy.CONST_COURTESEY_NAME;
                CourtesyID.ValueMember = Courtesy.CONST_COURTESY_ID;
            }

            _ContactList = _CustomerService.GetContacts(_CurrentCustomer.CustomerID);
            dgvCustomerContact.DataSource = CommonService.IListToDataTable(typeof (CustomerContact), _ContactList);
            SetContactModifyStatus(false);
        }

        private void dgvCustomerContact_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdSearchCustomer = new System.Windows.Forms.Button();
            this.cmdDeleteCustomer = new System.Windows.Forms.Button();
            this.cmdNewCustomer = new System.Windows.Forms.Button();
            this.txtCustomerSearch = new System.Windows.Forms.TextBox();
            this.lsbCustomer = new System.Windows.Forms.ListBox();
            this.grbCustomerInfo = new System.Windows.Forms.GroupBox();
            this.grbLine_2 = new System.Windows.Forms.GroupBox();
            this.grbLine_1 = new System.Windows.Forms.GroupBox();
            this.lblDebt = new System.Windows.Forms.Label();
            this.txtAmountDebt = new System.Windows.Forms.TextBox();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtWebSite = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.rtbAddress = new System.Windows.Forms.RichTextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerCode = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.grbContactInfo = new System.Windows.Forms.GroupBox();
            this.dgvCustomerContact = new System.Windows.Forms.DataGridView();
            this.ContactID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourtesyID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ContactName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBody.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.grbCustomerInfo.SuspendLayout();
            this.grbContactInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgvCustomerContact)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.grbContactInfo);
            this.pnlBody.Controls.Add(this.grbCustomerInfo);
            this.pnlBody.Controls.Add(this.cmdSearchCustomer);
            this.pnlBody.Controls.Add(this.cmdDeleteCustomer);
            this.pnlBody.Controls.Add(this.cmdNewCustomer);
            this.pnlBody.Controls.Add(this.txtCustomerSearch);
            this.pnlBody.Controls.Add(this.lsbCustomer);
            this.pnlBody.Size = new System.Drawing.Size(1016, 584);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(1016, 75);
            // 
            // cmdSearchCustomer
            // 
            this.cmdSearchCustomer.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdSearchCustomer.Image = Resources.Search32;
            this.cmdSearchCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearchCustomer.Location = new System.Drawing.Point(209, 9);
            this.cmdSearchCustomer.Name = "cmdSearchCustomer";
            this.cmdSearchCustomer.Size = new System.Drawing.Size(89, 28);
            this.cmdSearchCustomer.TabIndex = 58;
            this.cmdSearchCustomer.Text = "&Search";
            this.cmdSearchCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSearchCustomer.UseVisualStyleBackColor = true;
            // 
            // cmdDeleteCustomer
            // 
            this.cmdDeleteCustomer.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdDeleteCustomer.Image = Resources.Delete32;
            this.cmdDeleteCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDeleteCustomer.Location = new System.Drawing.Point(209, 582);
            this.cmdDeleteCustomer.Name = "cmdDeleteCustomer";
            this.cmdDeleteCustomer.Size = new System.Drawing.Size(89, 28);
            this.cmdDeleteCustomer.TabIndex = 57;
            this.cmdDeleteCustomer.Text = "&Delete";
            this.cmdDeleteCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDeleteCustomer.UseVisualStyleBackColor = true;
            this.cmdDeleteCustomer.Click += new System.EventHandler(this.CmdDeleteCustomer_Click);
            // 
            // cmdNewCustomer
            // 
            this.cmdNewCustomer.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdNewCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNewCustomer.Location = new System.Drawing.Point(118, 582);
            this.cmdNewCustomer.Name = "cmdNewCustomer";
            this.cmdNewCustomer.Size = new System.Drawing.Size(89, 28);
            this.cmdNewCustomer.TabIndex = 56;
            this.cmdNewCustomer.Text = "&New";
            this.cmdNewCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdNewCustomer.UseVisualStyleBackColor = true;
            this.cmdNewCustomer.Click += new System.EventHandler(this.CmdNewCustomer_Click);
            // 
            // txtCustomerSearch
            // 
            this.txtCustomerSearch.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtCustomerSearch.Location = new System.Drawing.Point(14, 14);
            this.txtCustomerSearch.Name = "txtCustomerSearch";
            this.txtCustomerSearch.Size = new System.Drawing.Size(189, 23);
            this.txtCustomerSearch.TabIndex = 30;
            this.txtCustomerSearch.TextChanged += new System.EventHandler(this.txtCustomerSearch_TextChanged);
            // 
            // lsbCustomer
            // 
            this.lsbCustomer.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lsbCustomer.FormattingEnabled = true;
            this.lsbCustomer.HorizontalScrollbar = true;
            this.lsbCustomer.ItemHeight = 22;
            this.lsbCustomer.Location = new System.Drawing.Point(14, 43);
            this.lsbCustomer.Name = "lsbCustomer";
            this.lsbCustomer.Size = new System.Drawing.Size(284, 532);
            this.lsbCustomer.TabIndex = 29;
            this.lsbCustomer.SelectedIndexChanged += new System.EventHandler(this.lsbCustomer_SelectedIndexChanged);
            // 
            // grbCustomerInfo
            // 
            this.grbCustomerInfo.Controls.Add(this.grbLine_2);
            this.grbCustomerInfo.Controls.Add(this.grbLine_1);
            this.grbCustomerInfo.Controls.Add(this.lblDebt);
            this.grbCustomerInfo.Controls.Add(this.txtAmountDebt);
            this.grbCustomerInfo.Controls.Add(this.lblWebsite);
            this.grbCustomerInfo.Controls.Add(this.txtEmail);
            this.grbCustomerInfo.Controls.Add(this.lblTelephone);
            this.grbCustomerInfo.Controls.Add(this.txtTelephone);
            this.grbCustomerInfo.Controls.Add(this.lblEmail);
            this.grbCustomerInfo.Controls.Add(this.txtWebSite);
            this.grbCustomerInfo.Controls.Add(this.lblAddress);
            this.grbCustomerInfo.Controls.Add(this.rtbAddress);
            this.grbCustomerInfo.Controls.Add(this.lblDisplayName);
            this.grbCustomerInfo.Controls.Add(this.txtDisplayName);
            this.grbCustomerInfo.Controls.Add(this.cmdReset);
            this.grbCustomerInfo.Controls.Add(this.cmdCancel);
            this.grbCustomerInfo.Controls.Add(this.cmdSave);
            this.grbCustomerInfo.Controls.Add(this.lblCustomerName);
            this.grbCustomerInfo.Controls.Add(this.txtCustomerName);
            this.grbCustomerInfo.Controls.Add(this.lblCustomerCode);
            this.grbCustomerInfo.Controls.Add(this.txtCustomerCode);
            this.grbCustomerInfo.Font = new System.Drawing.Font("Khmer OS", 12F, System.Drawing.FontStyle.Bold,
                                                                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.grbCustomerInfo.Location = new System.Drawing.Point(311, 3);
            this.grbCustomerInfo.Name = "grbCustomerInfo";
            this.grbCustomerInfo.Size = new System.Drawing.Size(700, 224);
            this.grbCustomerInfo.TabIndex = 59;
            this.grbCustomerInfo.TabStop = false;
            this.grbCustomerInfo.Text = "ពត៍មានអំពីអតិថិជន";
            // 
            // grbLine_2
            // 
            this.grbLine_2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_2.Location = new System.Drawing.Point(13, 176);
            this.grbLine_2.Name = "grbLine_2";
            this.grbLine_2.Size = new System.Drawing.Size(675, 2);
            this.grbLine_2.TabIndex = 82;
            this.grbLine_2.TabStop = false;
            // 
            // grbLine_1
            // 
            this.grbLine_1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_1.Location = new System.Drawing.Point(13, 111);
            this.grbLine_1.Name = "grbLine_1";
            this.grbLine_1.Size = new System.Drawing.Size(675, 2);
            this.grbLine_1.TabIndex = 81;
            this.grbLine_1.TabStop = false;
            // 
            // lblDebt
            // 
            this.lblDebt.AutoSize = true;
            this.lblDebt.Font = new System.Drawing.Font("Khmer OS", 9.75F, System.Drawing.FontStyle.Bold,
                                                        System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblDebt.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblDebt.Location = new System.Drawing.Point(360, 148);
            this.lblDebt.Name = "lblDebt";
            this.lblDebt.Size = new System.Drawing.Size(60, 27);
            this.lblDebt.TabIndex = 74;
            this.lblDebt.Text = "បំណុល";
            // 
            // txtAmountDebt
            // 
            this.txtAmountDebt.Enabled = false;
            this.txtAmountDebt.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                              System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtAmountDebt.Location = new System.Drawing.Point(483, 147);
            this.txtAmountDebt.Name = "txtAmountDebt";
            this.txtAmountDebt.Size = new System.Drawing.Size(205, 23);
            this.txtAmountDebt.TabIndex = 73;
            this.txtAmountDebt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Font = new System.Drawing.Font("Khmer OS", 9.75F, System.Drawing.FontStyle.Bold,
                                                           System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblWebsite.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblWebsite.Location = new System.Drawing.Point(10, 148);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(72, 27);
            this.lblWebsite.TabIndex = 72;
            this.lblWebsite.Text = "វែបសាយ";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                         System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtEmail.Location = new System.Drawing.Point(136, 147);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(205, 23);
            this.txtEmail.TabIndex = 71;
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Font = new System.Drawing.Font("Khmer OS", 9.75F, System.Drawing.FontStyle.Bold,
                                                             System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblTelephone.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTelephone.Location = new System.Drawing.Point(10, 119);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(89, 27);
            this.lblTelephone.TabIndex = 70;
            this.lblTelephone.Text = "លេខទូរស័ព្ទ";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                             System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtTelephone.Location = new System.Drawing.Point(136, 118);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(205, 23);
            this.txtTelephone.TabIndex = 69;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Khmer OS", 9.75F, System.Drawing.FontStyle.Bold,
                                                         System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblEmail.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblEmail.Location = new System.Drawing.Point(360, 119);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(122, 27);
            this.lblEmail.TabIndex = 68;
            this.lblEmail.Text = "សារអេឡិចត្រូនិច";
            // 
            // txtWebSite
            // 
            this.txtWebSite.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                           System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtWebSite.Location = new System.Drawing.Point(483, 118);
            this.txtWebSite.Name = "txtWebSite";
            this.txtWebSite.Size = new System.Drawing.Size(205, 23);
            this.txtWebSite.TabIndex = 67;
            this.txtWebSite.Leave += new System.EventHandler(this.txtWebSite_Leave);
            this.txtWebSite.Enter += new System.EventHandler(this.txtWebSite_Enter);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Khmer OS", 9.75F, System.Drawing.FontStyle.Bold,
                                                           System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblAddress.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAddress.Location = new System.Drawing.Point(360, 56);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(87, 27);
            this.lblAddress.TabIndex = 66;
            this.lblAddress.Text = "អាស័យដ្ឋាន";
            // 
            // rtbAddress
            // 
            this.rtbAddress.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                           System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.rtbAddress.Location = new System.Drawing.Point(483, 53);
            this.rtbAddress.Name = "rtbAddress";
            this.rtbAddress.Size = new System.Drawing.Size(205, 52);
            this.rtbAddress.TabIndex = 65;
            this.rtbAddress.Text = "";
            this.rtbAddress.Enter += new System.EventHandler(this.rtbAddress_Enter);
            this.rtbAddress.Leave += new System.EventHandler(this.rtbAddress_Leave);
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Font = new System.Drawing.Font("Khmer OS", 9.75F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblDisplayName.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblDisplayName.Location = new System.Drawing.Point(10, 85);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(79, 27);
            this.lblDisplayName.TabIndex = 64;
            this.lblDisplayName.Text = "ឈ្មោះកាត់";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtDisplayName.Location = new System.Drawing.Point(136, 82);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(205, 23);
            this.txtDisplayName.TabIndex = 63;
            this.txtDisplayName.Leave += new System.EventHandler(this.txtDisplayName_Leave);
            this.txtDisplayName.Enter += new System.EventHandler(this.txtDisplayName_Enter);
            // 
            // cmdReset
            // 
            this.cmdReset.Enabled = false;
            this.cmdReset.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                         System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdReset.Location = new System.Drawing.Point(416, 183);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(89, 28);
            this.cmdReset.TabIndex = 62;
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
            this.cmdCancel.Location = new System.Drawing.Point(600, 183);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(89, 28);
            this.cmdCancel.TabIndex = 61;
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
            this.cmdSave.Location = new System.Drawing.Point(508, 183);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(89, 28);
            this.cmdSave.TabIndex = 60;
            this.cmdSave.Text = "&Save   ";
            this.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Khmer OS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblCustomerName.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCustomerName.Location = new System.Drawing.Point(10, 27);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(107, 27);
            this.lblCustomerName.TabIndex = 59;
            this.lblCustomerName.Text = "ឈ្មោះអតិថិជន";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtCustomerName.Location = new System.Drawing.Point(136, 24);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(552, 23);
            this.txtCustomerName.TabIndex = 58;
            this.txtCustomerName.Leave += new System.EventHandler(this.txtCustomerName_Leave);
            this.txtCustomerName.Enter += new System.EventHandler(this.txtCustomerName_Enter);
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AutoSize = true;
            this.lblCustomerCode.Font = new System.Drawing.Font("Khmer OS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblCustomerCode.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCustomerCode.Location = new System.Drawing.Point(10, 56);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(122, 27);
            this.lblCustomerCode.TabIndex = 57;
            this.lblCustomerCode.Text = "លេខកូដអតិថិជន";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtCustomerCode.Location = new System.Drawing.Point(136, 53);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(205, 23);
            this.txtCustomerCode.TabIndex = 56;
            this.txtCustomerCode.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
            this.txtCustomerCode.Enter += new System.EventHandler(this.txtCustomerCode_Enter);
            // 
            // grbContactInfo
            // 
            this.grbContactInfo.Controls.Add(this.dgvCustomerContact);
            this.grbContactInfo.Font = new System.Drawing.Font("Khmer OS", 12F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.grbContactInfo.Location = new System.Drawing.Point(311, 233);
            this.grbContactInfo.Name = "grbContactInfo";
            this.grbContactInfo.Size = new System.Drawing.Size(700, 341);
            this.grbContactInfo.TabIndex = 60;
            this.grbContactInfo.TabStop = false;
            this.grbContactInfo.Text = "ពត៍មានអំពីទំនាក់ទំនងនឹងអតិថិជន";
            // 
            // dgvCustomerContact
            // 
            this.dgvCustomerContact.AllowUserToResizeColumns = false;
            this.dgvCustomerContact.AllowUserToResizeRows = false;
            this.dgvCustomerContact.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCustomerContact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS", 12F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomerContact.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomerContact.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerContact.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
                                                         {
                                                             this.ContactID,
                                                             this.CustomerID,
                                                             this.CourtesyID,
                                                             this.ContactName,
                                                             this.Address,
                                                             this.Telephone,
                                                             this.Email
                                                         });
            this.dgvCustomerContact.Location = new System.Drawing.Point(13, 28);
            this.dgvCustomerContact.Name = "dgvCustomerContact";
            this.dgvCustomerContact.RowHeadersWidth = 30;
            this.dgvCustomerContact.RowHeadersWidthSizeMode =
                System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCustomerContact.RowTemplate.Height = 35;
            this.dgvCustomerContact.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomerContact.ShowCellToolTips = false;
            this.dgvCustomerContact.Size = new System.Drawing.Size(675, 300);
            this.dgvCustomerContact.TabIndex = 39;
            this.dgvCustomerContact.VirtualMode = true;
            this.dgvCustomerContact.CellValueChanged +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerContact_CellValueChanged);
            this.dgvCustomerContact.RowValidating +=
                new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCustomerContact_RowValidating);
            this.dgvCustomerContact.RowValidated +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerContact_RowValidated);
            this.dgvCustomerContact.DataError +=
                new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvCustomerContact_DataError);
            this.dgvCustomerContact.RowsRemoved +=
                new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvCustomerContact_RowsRemoved);
            // 
            // ContactID
            // 
            this.ContactID.DataPropertyName = "ContactID";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ContactID.DefaultCellStyle = dataGridViewCellStyle2;
            this.ContactID.HeaderText = "ContactID";
            this.ContactID.Name = "ContactID";
            this.ContactID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ContactID.Visible = false;
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "CustomerID";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.CustomerID.DefaultCellStyle = dataGridViewCellStyle3;
            this.CustomerID.HeaderText = "CustomerID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CustomerID.Visible = false;
            // 
            // CourtesyID
            // 
            this.CourtesyID.DataPropertyName = "CourtesyID";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.CourtesyID.DefaultCellStyle = dataGridViewCellStyle4;
            this.CourtesyID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.CourtesyID.HeaderText = "ឋានៈ";
            this.CourtesyID.Name = "CourtesyID";
            this.CourtesyID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CourtesyID.Visible = false;
            // 
            // ContactName
            // 
            this.ContactName.DataPropertyName = "ContactName";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ContactName.DefaultCellStyle = dataGridViewCellStyle5;
            this.ContactName.HeaderText = "ឈ្មោះ";
            this.ContactName.Name = "ContactName";
            this.ContactName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ContactName.Width = 300;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Address.DefaultCellStyle = dataGridViewCellStyle6;
            this.Address.HeaderText = "អាស័យដ្ឋាន";
            this.Address.Name = "Address";
            this.Address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Address.Width = 350;
            // 
            // Telephone
            // 
            this.Telephone.DataPropertyName = "Telephone";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Telephone.DefaultCellStyle = dataGridViewCellStyle7;
            this.Telephone.HeaderText = "ទូរស័ព្ទ";
            this.Telephone.Name = "Telephone";
            this.Telephone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Telephone.Width = 150;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Email.DefaultCellStyle = dataGridViewCellStyle8;
            this.Email.HeaderText = "សារអេឡិចត្រូនិច";
            this.Email.Name = "Email";
            this.Email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Email.Width = 150;
            // 
            // FrmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmCustomer";
            this.Text = ".: Customer :.";
            this.Load += new System.EventHandler(this.FrmCustomer_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grbCustomerInfo.ResumeLayout(false);
            this.grbCustomerInfo.PerformLayout();
            this.grbContactInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.dgvCustomerContact)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}