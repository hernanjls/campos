using EzPos.GUIs.Components;

namespace EzPos.GUIs.Controls
{
    partial class CtrlUser
    {

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBodyRight = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblAddress = new System.Windows.Forms.Label();
            this.grbAddress = new System.Windows.Forms.GroupBox();
            this.addressLbl = new System.Windows.Forms.Label();
            this.pnlBodySearch = new System.Windows.Forms.Panel();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblResultInfo = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.cmbPosition = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.lblPosition = new System.Windows.Forms.Label();
            this.cmbGender = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.lblGender = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlBodyLeft = new System.Windows.Forms.Panel();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenderStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PositionStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogInName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CivilityStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaritalStatusStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CivilityId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaritalStatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PositionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhotoPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefaultModule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBodyRight.SuspendLayout();
            this.grbAddress.SuspendLayout();
            this.pnlBodySearch.SuspendLayout();
            this.pnlBodyLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBodyRight
            // 
            this.pnlBodyRight.BackgroundImage = global::EzPos.Properties.Resources.backgroud_12;
            this.pnlBodyRight.Controls.Add(this.btnDelete);
            this.pnlBodyRight.Controls.Add(this.btnNew);
            this.pnlBodyRight.Controls.Add(this.lblAddress);
            this.pnlBodyRight.Controls.Add(this.grbAddress);
            this.pnlBodyRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBodyRight.Location = new System.Drawing.Point(824, 0);
            this.pnlBodyRight.Name = "pnlBodyRight";
            this.pnlBodyRight.Size = new System.Drawing.Size(200, 591);
            this.pnlBodyRight.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::EzPos.Properties.Resources.Delete32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(28, 560);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(144, 40);
            this.btnDelete.TabIndex = 100;
            this.btnDelete.Text = "លុបចោល";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.MouseLeave += new System.EventHandler(this.btnDelete_MouseLeave);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.MouseEnter += new System.EventHandler(this.btnDelete_MouseEnter);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNew.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Image = global::EzPos.Properties.Resources.add32;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNew.Location = new System.Drawing.Point(28, 519);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(144, 40);
            this.btnNew.TabIndex = 99;
            this.btnNew.Text = "បង្កើតថ្មី";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.MouseLeave += new System.EventHandler(this.btnNew_MouseLeave);
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            this.btnNew.MouseEnter += new System.EventHandler(this.btnNew_MouseEnter);
            // 
            // lblAddress
            // 
            this.lblAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblAddress.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.Yellow;
            this.lblAddress.Location = new System.Drawing.Point(10, 1);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(179, 32);
            this.lblAddress.TabIndex = 98;
            this.lblAddress.Text = "អាស័យដ្ឋាន";
            // 
            // grbAddress
            // 
            this.grbAddress.BackgroundImage = global::EzPos.Properties.Resources.pnlBodyRight;
            this.grbAddress.Controls.Add(this.addressLbl);
            this.grbAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbAddress.Location = new System.Drawing.Point(10, -7);
            this.grbAddress.Name = "grbAddress";
            this.grbAddress.Size = new System.Drawing.Size(180, 175);
            this.grbAddress.TabIndex = 97;
            this.grbAddress.TabStop = false;
            // 
            // addressLbl
            // 
            this.addressLbl.BackColor = System.Drawing.Color.Transparent;
            this.addressLbl.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressLbl.ForeColor = System.Drawing.Color.White;
            this.addressLbl.Location = new System.Drawing.Point(1, 39);
            this.addressLbl.Name = "addressLbl";
            this.addressLbl.Size = new System.Drawing.Size(177, 134);
            this.addressLbl.TabIndex = 91;
            // 
            // pnlBodySearch
            // 
            this.pnlBodySearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBodySearch.Controls.Add(this.lblPhoneNumber);
            this.pnlBodySearch.Controls.Add(this.txtPhoneNumber);
            this.pnlBodySearch.Controls.Add(this.lblResultInfo);
            this.pnlBodySearch.Controls.Add(this.lblUserName);
            this.pnlBodySearch.Controls.Add(this.txtUserName);
            this.pnlBodySearch.Controls.Add(this.cmbPosition);
            this.pnlBodySearch.Controls.Add(this.lblPosition);
            this.pnlBodySearch.Controls.Add(this.cmbGender);
            this.pnlBodySearch.Controls.Add(this.lblGender);
            this.pnlBodySearch.Controls.Add(this.btnReset);
            this.pnlBodySearch.Controls.Add(this.btnSearch);
            this.pnlBodySearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBodySearch.Location = new System.Drawing.Point(0, 0);
            this.pnlBodySearch.Name = "pnlBodySearch";
            this.pnlBodySearch.Size = new System.Drawing.Size(824, 120);
            this.pnlBodySearch.TabIndex = 1;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(22, 49);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(61, 27);
            this.lblPhoneNumber.TabIndex = 21;
            this.lblPhoneNumber.Text = "ទូរស័ព្ទ";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(89, 49);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(184, 27);
            this.txtPhoneNumber.TabIndex = 22;
            // 
            // lblResultInfo
            // 
            this.lblResultInfo.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultInfo.Location = new System.Drawing.Point(22, 86);
            this.lblResultInfo.Name = "lblResultInfo";
            this.lblResultInfo.Size = new System.Drawing.Size(776, 27);
            this.lblResultInfo.TabIndex = 20;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(22, 12);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(57, 27);
            this.lblUserName.TabIndex = 10;
            this.lblUserName.Text = "ឈ្មោះ";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(89, 12);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(184, 27);
            this.txtUserName.TabIndex = 11;
            // 
            // cmbPosition
            // 
            this.cmbPosition.DropDownWidth = 180;
            this.cmbPosition.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(610, 12);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(184, 27);
            this.cmbPosition.TabIndex = 15;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(555, 12);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(49, 27);
            this.lblPosition.TabIndex = 14;
            this.lblPosition.Text = "ឋានៈ";
            // 
            // cmbGender
            // 
            this.cmbGender.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(348, 12);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(184, 27);
            this.cmbGender.TabIndex = 13;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(299, 12);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(43, 27);
            this.lblGender.TabIndex = 12;
            this.lblGender.Text = "ភេទ";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::EzPos.Properties.Resources.Undo32;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnReset.Location = new System.Drawing.Point(610, 48);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(89, 28);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "&Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::EzPos.Properties.Resources.Search32;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(705, 48);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 28);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "&Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlBodyLeft
            // 
            this.pnlBodyLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBodyLeft.Controls.Add(this.dgvUser);
            this.pnlBodyLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBodyLeft.Location = new System.Drawing.Point(0, 120);
            this.pnlBodyLeft.Name = "pnlBodyLeft";
            this.pnlBodyLeft.Size = new System.Drawing.Size(824, 471);
            this.pnlBodyLeft.TabIndex = 2;
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AllowUserToResizeColumns = false;
            this.dgvUser.AllowUserToResizeRows = false;
            this.dgvUser.BackgroundColor = System.Drawing.Color.White;
            this.dgvUser.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvUser.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUser.ColumnHeadersHeight = 40;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.PhoneNumber,
            this.GenderStr,
            this.PositionStr,
            this.LogInName,
            this.Salary,
            this.BirthDate,
            this.CivilityStr,
            this.MaritalStatusStr,
            this.ContractStr,
            this.StartingDate,
            this.Address,
            this.Password,
            this.GenderId,
            this.CivilityId,
            this.MaritalStatusId,
            this.PositionId,
            this.ContractId,
            this.UserId,
            this.UserNumber,
            this.PhotoPath,
            this.DefaultModule});
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.EnableHeadersVisualStyles = false;
            this.dgvUser.GridColor = System.Drawing.Color.White;
            this.dgvUser.Location = new System.Drawing.Point(0, 0);
            this.dgvUser.MultiSelect = false;
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            this.dgvUser.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUser.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Candara", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUser.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.dgvUser.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dgvUser.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvUser.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Maroon;
            this.dgvUser.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.RowTemplate.Height = 50;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(822, 469);
            this.dgvUser.TabIndex = 1;
            this.dgvUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellDoubleClick);
            this.dgvUser.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvUser_DataError);
            // 
            // UserName
            // 
            this.UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "ឈ្មោះបុគ្គលិក";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PhoneNumber.DataPropertyName = "PhoneNumber";
            this.PhoneNumber.HeaderText = "លេខទូរស័ព្ទ";
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.ReadOnly = true;
            this.PhoneNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PhoneNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PhoneNumber.Width = 155;
            // 
            // GenderStr
            // 
            this.GenderStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.GenderStr.DataPropertyName = "GenderStr";
            this.GenderStr.HeaderText = "ភេទ";
            this.GenderStr.Name = "GenderStr";
            this.GenderStr.ReadOnly = true;
            this.GenderStr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GenderStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PositionStr
            // 
            this.PositionStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PositionStr.DataPropertyName = "PositionStr";
            this.PositionStr.HeaderText = "ឋានៈ";
            this.PositionStr.Name = "PositionStr";
            this.PositionStr.ReadOnly = true;
            this.PositionStr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PositionStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PositionStr.Width = 150;
            // 
            // LogInName
            // 
            this.LogInName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LogInName.DataPropertyName = "LogInName";
            this.LogInName.HeaderText = "គណនីយ";
            this.LogInName.Name = "LogInName";
            this.LogInName.ReadOnly = true;
            this.LogInName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LogInName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LogInName.Width = 150;
            // 
            // Salary
            // 
            this.Salary.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Salary.DataPropertyName = "Salary";
            this.Salary.HeaderText = "បៀរវត្ស";
            this.Salary.Name = "Salary";
            this.Salary.ReadOnly = true;
            this.Salary.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Salary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Salary.Visible = false;
            // 
            // BirthDate
            // 
            this.BirthDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BirthDate.DataPropertyName = "BirthDate";
            this.BirthDate.HeaderText = "ថ្ងៃ ខែ ឆ្នាំកំណើត";
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.ReadOnly = true;
            this.BirthDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BirthDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BirthDate.Visible = false;
            // 
            // CivilityStr
            // 
            this.CivilityStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CivilityStr.DataPropertyName = "CivilityStr";
            this.CivilityStr.HeaderText = "CivilityStr";
            this.CivilityStr.Name = "CivilityStr";
            this.CivilityStr.ReadOnly = true;
            this.CivilityStr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CivilityStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CivilityStr.Visible = false;
            // 
            // MaritalStatusStr
            // 
            this.MaritalStatusStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MaritalStatusStr.DataPropertyName = "MaritalStatusStr";
            this.MaritalStatusStr.HeaderText = "MaritalStatusStr";
            this.MaritalStatusStr.Name = "MaritalStatusStr";
            this.MaritalStatusStr.ReadOnly = true;
            this.MaritalStatusStr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MaritalStatusStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MaritalStatusStr.Visible = false;
            // 
            // ContractStr
            // 
            this.ContractStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ContractStr.DataPropertyName = "ContractStr";
            this.ContractStr.HeaderText = "ContractStr";
            this.ContractStr.Name = "ContractStr";
            this.ContractStr.ReadOnly = true;
            this.ContractStr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ContractStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ContractStr.Visible = false;
            // 
            // StartingDate
            // 
            this.StartingDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StartingDate.DataPropertyName = "StartingDate";
            this.StartingDate.HeaderText = "StartingDate";
            this.StartingDate.Name = "StartingDate";
            this.StartingDate.ReadOnly = true;
            this.StartingDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StartingDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StartingDate.Visible = false;
            // 
            // Address
            // 
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Address.Visible = false;
            // 
            // Password
            // 
            this.Password.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Password.DataPropertyName = "Password";
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Password.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Password.Visible = false;
            // 
            // GenderId
            // 
            this.GenderId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.GenderId.DataPropertyName = "GenderId";
            this.GenderId.HeaderText = "GenderId";
            this.GenderId.Name = "GenderId";
            this.GenderId.ReadOnly = true;
            this.GenderId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GenderId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GenderId.Visible = false;
            // 
            // CivilityId
            // 
            this.CivilityId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CivilityId.DataPropertyName = "CivilityId";
            this.CivilityId.HeaderText = "CivilityId";
            this.CivilityId.Name = "CivilityId";
            this.CivilityId.ReadOnly = true;
            this.CivilityId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CivilityId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CivilityId.Visible = false;
            // 
            // MaritalStatusId
            // 
            this.MaritalStatusId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MaritalStatusId.DataPropertyName = "MaritalStatusId";
            this.MaritalStatusId.HeaderText = "MaritalStatusId";
            this.MaritalStatusId.Name = "MaritalStatusId";
            this.MaritalStatusId.ReadOnly = true;
            this.MaritalStatusId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MaritalStatusId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MaritalStatusId.Visible = false;
            // 
            // PositionId
            // 
            this.PositionId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PositionId.DataPropertyName = "PositionId";
            this.PositionId.HeaderText = "PositionId";
            this.PositionId.Name = "PositionId";
            this.PositionId.ReadOnly = true;
            this.PositionId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PositionId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PositionId.Visible = false;
            // 
            // ContractId
            // 
            this.ContractId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ContractId.DataPropertyName = "ContractId";
            this.ContractId.HeaderText = "ContractId";
            this.ContractId.Name = "ContractId";
            this.ContractId.ReadOnly = true;
            this.ContractId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ContractId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ContractId.Visible = false;
            // 
            // UserId
            // 
            this.UserId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UserId.DataPropertyName = "UserId";
            this.UserId.HeaderText = "UserId";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            this.UserId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UserId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UserId.Visible = false;
            // 
            // UserNumber
            // 
            this.UserNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UserNumber.DataPropertyName = "UserNumber";
            this.UserNumber.HeaderText = "UserNumber";
            this.UserNumber.Name = "UserNumber";
            this.UserNumber.ReadOnly = true;
            this.UserNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UserNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UserNumber.Visible = false;
            // 
            // PhotoPath
            // 
            this.PhotoPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PhotoPath.DataPropertyName = "PhotoPath";
            this.PhotoPath.HeaderText = "PhotoPath";
            this.PhotoPath.Name = "PhotoPath";
            this.PhotoPath.ReadOnly = true;
            this.PhotoPath.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PhotoPath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PhotoPath.Visible = false;
            // 
            // DefaultModule
            // 
            this.DefaultModule.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DefaultModule.DataPropertyName = "DefaultModule";
            this.DefaultModule.HeaderText = "DefaultModule";
            this.DefaultModule.Name = "DefaultModule";
            this.DefaultModule.ReadOnly = true;
            this.DefaultModule.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DefaultModule.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DefaultModule.Visible = false;
            // 
            // CtrlUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBodyLeft);
            this.Controls.Add(this.pnlBodySearch);
            this.Controls.Add(this.pnlBodyRight);
            this.Name = "CtrlUser";
            this.Size = new System.Drawing.Size(1024, 591);
            this.Load += new System.EventHandler(this.CtrlUser_Load);
            this.pnlBodyRight.ResumeLayout(false);
            this.grbAddress.ResumeLayout(false);
            this.pnlBodySearch.ResumeLayout(false);
            this.pnlBodySearch.PerformLayout();
            this.pnlBodyLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBodyRight;
        private System.Windows.Forms.Panel pnlBodySearch;
        private System.Windows.Forms.Panel pnlBodyLeft;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.GroupBox grbAddress;
        private System.Windows.Forms.Label addressLbl;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private ExtendedComboBox cmbPosition;
        private System.Windows.Forms.Label lblPosition;
        private ExtendedComboBox cmbGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label lblResultInfo;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenderStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogInName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CivilityStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaritalStatusStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CivilityId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaritalStatusId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhotoPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefaultModule;




    }
}