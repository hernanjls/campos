using ExtendedComboBox=EzPos.GUIs.Components.ExtendedComboBox;

namespace EzPos.GUIs.Forms
{
    partial class FrmUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblMaritalStatus = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtPhotoPath = new System.Windows.Forms.TextBox();
            this.ptbUser = new System.Windows.Forms.PictureBox();
            this.lblSalary = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.grbLine_1 = new System.Windows.Forms.GroupBox();
            this.clbPermission = new System.Windows.Forms.CheckedListBox();
            this.lblPermission = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblAccount = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLogInName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblStartingDate = new System.Windows.Forms.Label();
            this.dtpStartingDate = new System.Windows.Forms.DateTimePicker();
            this.cmbContractType = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.lblContractType = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.grbLine_2 = new System.Windows.Forms.GroupBox();
            this.cmbPosition = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.cmbMaritalStatus = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.cmbGender = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblProductName = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbUser)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGender
            // 
            this.lblGender.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold);
            this.lblGender.Location = new System.Drawing.Point(38, 60);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(122, 22);
            this.lblGender.TabIndex = 2;
            this.lblGender.Text = "ភេទ";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaritalStatus
            // 
            this.lblMaritalStatus.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold);
            this.lblMaritalStatus.Location = new System.Drawing.Point(38, 95);
            this.lblMaritalStatus.Name = "lblMaritalStatus";
            this.lblMaritalStatus.Size = new System.Drawing.Size(122, 28);
            this.lblMaritalStatus.TabIndex = 4;
            this.lblMaritalStatus.Text = "អេតាស៊ីវីល";
            this.lblMaritalStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPosition
            // 
            this.lblPosition.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold);
            this.lblPosition.Location = new System.Drawing.Point(41, 266);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(122, 30);
            this.lblPosition.TabIndex = 13;
            this.lblPosition.Text = "មុខងារ";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhotoPath
            // 
            this.txtPhotoPath.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhotoPath.Location = new System.Drawing.Point(410, 146);
            this.txtPhotoPath.Name = "txtPhotoPath";
            this.txtPhotoPath.Size = new System.Drawing.Size(230, 26);
            this.txtPhotoPath.TabIndex = 100;
            this.txtPhotoPath.Visible = false;
            // 
            // ptbUser
            // 
            this.ptbUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbUser.Location = new System.Drawing.Point(410, 14);
            this.ptbUser.Name = "ptbUser";
            this.ptbUser.Size = new System.Drawing.Size(250, 233);
            this.ptbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbUser.TabIndex = 101;
            this.ptbUser.TabStop = false;
            this.ptbUser.Click += new System.EventHandler(this.PtbProductClick);
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold);
            this.lblSalary.Location = new System.Drawing.Point(87, 381);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(74, 29);
            this.lblSalary.TabIndex = 21;
            this.lblSalary.Text = "បៀរវត្ស";
            // 
            // txtSalary
            // 
            this.txtSalary.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalary.Location = new System.Drawing.Point(166, 376);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(230, 36);
            this.txtSalary.TabIndex = 22;
            this.txtSalary.Text = "0.00";
            this.txtSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSalary.Leave += new System.EventHandler(this.TxtSalaryLeave);
            this.txtSalary.Enter += new System.EventHandler(this.TxtSalaryEnter);
            // 
            // grbLine_1
            // 
            this.grbLine_1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_1.Location = new System.Drawing.Point(44, 254);
            this.grbLine_1.Name = "grbLine_1";
            this.grbLine_1.Size = new System.Drawing.Size(352, 2);
            this.grbLine_1.TabIndex = 12;
            this.grbLine_1.TabStop = false;
            // 
            // clbPermission
            // 
            this.clbPermission.BackColor = System.Drawing.SystemColors.Info;
            this.clbPermission.Font = new System.Drawing.Font("Khmer OS System", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbPermission.FormattingEnabled = true;
            this.clbPermission.HorizontalScrollbar = true;
            this.clbPermission.Location = new System.Drawing.Point(410, 280);
            this.clbPermission.Name = "clbPermission";
            this.clbPermission.Size = new System.Drawing.Size(250, 199);
            this.clbPermission.TabIndex = 29;
            this.clbPermission.ThreeDCheckBoxes = true;
            this.clbPermission.Leave += new System.EventHandler(this.ClbPermissionLeave);
            this.clbPermission.Enter += new System.EventHandler(this.ClbPermissionEnter);
            // 
            // lblPermission
            // 
            this.lblPermission.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold);
            this.lblPermission.Location = new System.Drawing.Point(405, 250);
            this.lblPermission.Name = "lblPermission";
            this.lblPermission.Size = new System.Drawing.Size(47, 27);
            this.lblPermission.TabIndex = 28;
            this.lblPermission.Text = "សិទ្ឋ";
            this.lblPermission.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(100, 19);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 29);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "ឈ្មោះ";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody.Controls.Add(this.lblAccount);
            this.pnlBody.Controls.Add(this.txtPassword);
            this.pnlBody.Controls.Add(this.txtLogInName);
            this.pnlBody.Controls.Add(this.lblPassword);
            this.pnlBody.Controls.Add(this.lblAddress);
            this.pnlBody.Controls.Add(this.txtPhoneNumber);
            this.pnlBody.Controls.Add(this.lblPhoneNumber);
            this.pnlBody.Controls.Add(this.txtAddress);
            this.pnlBody.Controls.Add(this.lblStartingDate);
            this.pnlBody.Controls.Add(this.dtpStartingDate);
            this.pnlBody.Controls.Add(this.cmbContractType);
            this.pnlBody.Controls.Add(this.lblContractType);
            this.pnlBody.Controls.Add(this.lblBirthDate);
            this.pnlBody.Controls.Add(this.dtpBirthDate);
            this.pnlBody.Controls.Add(this.txtUserName);
            this.pnlBody.Controls.Add(this.grbLine_2);
            this.pnlBody.Controls.Add(this.lblUserName);
            this.pnlBody.Controls.Add(this.lblPermission);
            this.pnlBody.Controls.Add(this.clbPermission);
            this.pnlBody.Controls.Add(this.grbLine_1);
            this.pnlBody.Controls.Add(this.txtSalary);
            this.pnlBody.Controls.Add(this.lblSalary);
            this.pnlBody.Controls.Add(this.ptbUser);
            this.pnlBody.Controls.Add(this.txtPhotoPath);
            this.pnlBody.Controls.Add(this.cmbPosition);
            this.pnlBody.Controls.Add(this.lblPosition);
            this.pnlBody.Controls.Add(this.cmbMaritalStatus);
            this.pnlBody.Controls.Add(this.lblMaritalStatus);
            this.pnlBody.Controls.Add(this.cmbGender);
            this.pnlBody.Controls.Add(this.lblGender);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBody.Location = new System.Drawing.Point(0, 89);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(695, 515);
            this.pnlBody.TabIndex = 1;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold);
            this.lblAccount.Location = new System.Drawing.Point(78, 432);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(83, 29);
            this.lblAccount.TabIndex = 24;
            this.lblAccount.Text = "គណនីយ";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Info;
            this.txtPassword.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(166, 465);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(230, 36);
            this.txtPassword.TabIndex = 27;
            this.txtPassword.Leave += new System.EventHandler(this.TxtPasswordLeave);
            this.txtPassword.Enter += new System.EventHandler(this.TxtPasswordEnter);
            // 
            // txtLogInName
            // 
            this.txtLogInName.BackColor = System.Drawing.SystemColors.Info;
            this.txtLogInName.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogInName.Location = new System.Drawing.Point(166, 427);
            this.txtLogInName.Name = "txtLogInName";
            this.txtLogInName.Size = new System.Drawing.Size(230, 36);
            this.txtLogInName.TabIndex = 25;
            this.txtLogInName.Leave += new System.EventHandler(this.TxtLogInNameLeave);
            this.txtLogInName.Enter += new System.EventHandler(this.TxtLogInNameEnter);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(58, 470);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(103, 29);
            this.lblPassword.TabIndex = 26;
            this.lblPassword.Text = "ពាក្យសំងាត់";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold);
            this.lblAddress.Location = new System.Drawing.Point(61, 209);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(102, 29);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = "អាស័យដ្ឋាន";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(166, 166);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(230, 36);
            this.txtPhoneNumber.TabIndex = 9;
            this.txtPhoneNumber.Leave += new System.EventHandler(this.TxtPhoneNumberLeave);
            this.txtPhoneNumber.Enter += new System.EventHandler(this.TxtPhoneNumberEnter);
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold);
            this.lblPhoneNumber.Location = new System.Drawing.Point(57, 171);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(104, 29);
            this.lblPhoneNumber.TabIndex = 8;
            this.lblPhoneNumber.Text = "លេខទូរស័ព្ទ";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(166, 204);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(230, 43);
            this.txtAddress.TabIndex = 11;
            this.txtAddress.Leave += new System.EventHandler(this.TxtAddressLeave);
            this.txtAddress.Enter += new System.EventHandler(this.TxtAddressEnter);
            // 
            // lblStartingDate
            // 
            this.lblStartingDate.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold);
            this.lblStartingDate.Location = new System.Drawing.Point(6, 340);
            this.lblStartingDate.Name = "lblStartingDate";
            this.lblStartingDate.Size = new System.Drawing.Size(155, 36);
            this.lblStartingDate.TabIndex = 17;
            this.lblStartingDate.Text = "ថ្ងៃចាប់ផ្តើម";
            this.lblStartingDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpStartingDate
            // 
            this.dtpStartingDate.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartingDate.Location = new System.Drawing.Point(166, 338);
            this.dtpStartingDate.Name = "dtpStartingDate";
            this.dtpStartingDate.Size = new System.Drawing.Size(230, 36);
            this.dtpStartingDate.TabIndex = 18;
            this.dtpStartingDate.Value = new System.DateTime(2007, 10, 21, 0, 0, 0, 0);
            this.dtpStartingDate.Leave += new System.EventHandler(this.DtpStartingDateLeave);
            this.dtpStartingDate.Enter += new System.EventHandler(this.DtpStartingDateEnter);
            // 
            // cmbContractType
            // 
            this.cmbContractType.BackColor = System.Drawing.SystemColors.Info;
            this.cmbContractType.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbContractType.FormattingEnabled = true;
            this.cmbContractType.Location = new System.Drawing.Point(166, 300);
            this.cmbContractType.Name = "cmbContractType";
            this.cmbContractType.Size = new System.Drawing.Size(230, 36);
            this.cmbContractType.TabIndex = 16;
            this.cmbContractType.Leave += new System.EventHandler(this.CmbContractTypeLeave);
            this.cmbContractType.Enter += new System.EventHandler(this.CmbContractTypeEnter);
            // 
            // lblContractType
            // 
            this.lblContractType.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold);
            this.lblContractType.Location = new System.Drawing.Point(41, 306);
            this.lblContractType.Name = "lblContractType";
            this.lblContractType.Size = new System.Drawing.Size(122, 30);
            this.lblContractType.TabIndex = 15;
            this.lblContractType.Text = "កិច្ចសន្យា";
            this.lblContractType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold);
            this.lblBirthDate.Location = new System.Drawing.Point(12, 134);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(149, 28);
            this.lblBirthDate.TabIndex = 6;
            this.lblBirthDate.Text = "ថ្ងៃ ខែ ឆ្នាំកំណើត";
            this.lblBirthDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.CustomFormat = "";
            this.dtpBirthDate.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(166, 128);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(230, 36);
            this.dtpBirthDate.TabIndex = 7;
            this.dtpBirthDate.Value = new System.DateTime(2007, 10, 21, 0, 0, 0, 0);
            this.dtpBirthDate.Leave += new System.EventHandler(this.DtpBirthDateLeave);
            this.dtpBirthDate.Enter += new System.EventHandler(this.DtpBirthDateEnter);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Info;
            this.txtUserName.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(166, 14);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(230, 36);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Leave += new System.EventHandler(this.TxtUserNameLeave);
            this.txtUserName.Enter += new System.EventHandler(this.TxtUserNameEnter);
            // 
            // grbLine_2
            // 
            this.grbLine_2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_2.Location = new System.Drawing.Point(44, 419);
            this.grbLine_2.Name = "grbLine_2";
            this.grbLine_2.Size = new System.Drawing.Size(352, 2);
            this.grbLine_2.TabIndex = 23;
            this.grbLine_2.TabStop = false;
            // 
            // cmbPosition
            // 
            this.cmbPosition.BackColor = System.Drawing.SystemColors.Info;
            this.cmbPosition.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(166, 262);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(230, 36);
            this.cmbPosition.TabIndex = 14;
            this.cmbPosition.Leave += new System.EventHandler(this.CmbPositionLeave);
            this.cmbPosition.Enter += new System.EventHandler(this.CmbPositionEnter);
            // 
            // cmbMaritalStatus
            // 
            this.cmbMaritalStatus.BackColor = System.Drawing.SystemColors.Info;
            this.cmbMaritalStatus.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaritalStatus.FormattingEnabled = true;
            this.cmbMaritalStatus.Location = new System.Drawing.Point(166, 90);
            this.cmbMaritalStatus.Name = "cmbMaritalStatus";
            this.cmbMaritalStatus.Size = new System.Drawing.Size(230, 36);
            this.cmbMaritalStatus.TabIndex = 5;
            this.cmbMaritalStatus.Leave += new System.EventHandler(this.CmbMaritalStatusLeave);
            this.cmbMaritalStatus.Enter += new System.EventHandler(this.CmbMaritalStatus_Enter);
            // 
            // cmbGender
            // 
            this.cmbGender.BackColor = System.Drawing.SystemColors.Info;
            this.cmbGender.DropDownWidth = 230;
            this.cmbGender.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(166, 52);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(230, 36);
            this.cmbGender.TabIndex = 3;
            this.cmbGender.Leave += new System.EventHandler(this.CmbCategoryLeave);
            this.cmbGender.Enter += new System.EventHandler(this.CmbCategoryEnter);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackgroundImage = global::EzPos.Properties.Resources.backgroud_11;
            this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHeader.Controls.Add(this.lblProductName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(695, 89);
            this.pnlHeader.TabIndex = 104;
            // 
            // lblProductName
            // 
            this.lblProductName.BackColor = System.Drawing.Color.Transparent;
            this.lblProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductName.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.Yellow;
            this.lblProductName.Location = new System.Drawing.Point(0, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(695, 89);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackgroundImage = global::EzPos.Properties.Resources.background_5;
            this.pnlFooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 604);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(695, 48);
            this.pnlFooter.TabIndex = 105;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = global::EzPos.Properties.Resources.Cancel32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(544, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 35);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "បោះបង់";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.MouseLeave += new System.EventHandler(this.BtnCancelMouseLeave);
            this.btnCancel.MouseEnter += new System.EventHandler(this.BtnCancelMouseEnter);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::EzPos.Properties.Resources.OK32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(427, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 35);
            this.btnSave.TabIndex = 46;
            this.btnSave.Text = "យល់ព្រម";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.MouseLeave += new System.EventHandler(this.BtnSaveMouseLeave);
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            this.btnSave.MouseEnter += new System.EventHandler(this.BtnSaveMouseEnter);
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(695, 652);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   .: User :.";
            this.Load += new System.EventHandler(this.FrmUser_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUser_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ptbUser)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGender;
        private ExtendedComboBox cmbGender;
        private System.Windows.Forms.Label lblMaritalStatus;
        private ExtendedComboBox cmbMaritalStatus;
        private System.Windows.Forms.Label lblPosition;
        private ExtendedComboBox cmbPosition;
        private System.Windows.Forms.TextBox txtPhotoPath;
        private System.Windows.Forms.PictureBox ptbUser;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.GroupBox grbLine_1;
        private System.Windows.Forms.CheckedListBox clbPermission;
        private System.Windows.Forms.Label lblPermission;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.GroupBox grbLine_2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label lblStartingDate;
        private System.Windows.Forms.DateTimePicker dtpStartingDate;
        private ExtendedComboBox cmbContractType;
        private System.Windows.Forms.Label lblContractType;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLogInName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}