using ExtendedComboBox=EzPos.GUIs.Components.ExtendedComboBox;

namespace EzPos.GUIs.Controls
{
    partial class CtrlSupplier
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBodyLeft = new System.Windows.Forms.Panel();
            this.dgvSupplier = new System.Windows.Forms.DataGridView();
            this.pnlBodyRight = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblAddress = new System.Windows.Forms.Label();
            this.grbAddress = new System.Windows.Forms.GroupBox();
            this.addressLbl = new System.Windows.Forms.Label();
            this.lblBankInfo = new System.Windows.Forms.Label();
            this.grbPrintCard = new System.Windows.Forms.GroupBox();
            this.bankInfoLbl = new System.Windows.Forms.Label();
            this.pnlBodySearch = new System.Windows.Forms.Panel();
            this.lblResultInfo = new System.Windows.Forms.Label();
            this.lblCardNum = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.cmbCountry = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.lblCountry = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaxNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Website = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankInformation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBodyLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).BeginInit();
            this.pnlBodyRight.SuspendLayout();
            this.grbAddress.SuspendLayout();
            this.grbPrintCard.SuspendLayout();
            this.pnlBodySearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBodyLeft
            // 
            this.pnlBodyLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBodyLeft.Controls.Add(this.dgvSupplier);
            this.pnlBodyLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBodyLeft.Location = new System.Drawing.Point(0, 90);
            this.pnlBodyLeft.Name = "pnlBodyLeft";
            this.pnlBodyLeft.Size = new System.Drawing.Size(826, 505);
            this.pnlBodyLeft.TabIndex = 1;
            // 
            // dgvSupplier
            // 
            this.dgvSupplier.AllowUserToAddRows = false;
            this.dgvSupplier.AllowUserToDeleteRows = false;
            this.dgvSupplier.AllowUserToResizeColumns = false;
            this.dgvSupplier.AllowUserToResizeRows = false;
            this.dgvSupplier.BackgroundColor = System.Drawing.Color.White;
            this.dgvSupplier.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSupplier.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSupplier.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupplier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSupplier.ColumnHeadersHeight = 40;
            this.dgvSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSupplier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SupplierName,
            this.PhoneNumber,
            this.FaxNumber,
            this.CountryStr,
            this.SupplierId,
            this.SupplierCode,
            this.Address,
            this.EmailAddress,
            this.Website,
            this.CountryId,
            this.BankInformation});
            this.dgvSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSupplier.EnableHeadersVisualStyles = false;
            this.dgvSupplier.GridColor = System.Drawing.Color.White;
            this.dgvSupplier.Location = new System.Drawing.Point(0, 0);
            this.dgvSupplier.MultiSelect = false;
            this.dgvSupplier.Name = "dgvSupplier";
            this.dgvSupplier.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSupplier.RowHeadersVisible = false;
            this.dgvSupplier.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSupplier.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Candara", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSupplier.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.dgvSupplier.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dgvSupplier.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvSupplier.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Maroon;
            this.dgvSupplier.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupplier.RowTemplate.Height = 50;
            this.dgvSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupplier.Size = new System.Drawing.Size(824, 503);
            this.dgvSupplier.TabIndex = 1;
            this.dgvSupplier.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupplier_CellDoubleClick);
            this.dgvSupplier.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDiscountCard_DataError);
            this.dgvSupplier.SelectionChanged += new System.EventHandler(this.dgvDiscountCard_SelectionChanged);
            // 
            // pnlBodyRight
            // 
            this.pnlBodyRight.BackgroundImage = global::EzPos.Properties.Resources.backgroud_12;
            this.pnlBodyRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBodyRight.Controls.Add(this.btnDelete);
            this.pnlBodyRight.Controls.Add(this.btnNew);
            this.pnlBodyRight.Controls.Add(this.lblAddress);
            this.pnlBodyRight.Controls.Add(this.grbAddress);
            this.pnlBodyRight.Controls.Add(this.lblBankInfo);
            this.pnlBodyRight.Controls.Add(this.grbPrintCard);
            this.pnlBodyRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBodyRight.Location = new System.Drawing.Point(826, 0);
            this.pnlBodyRight.Name = "pnlBodyRight";
            this.pnlBodyRight.Size = new System.Drawing.Size(200, 595);
            this.pnlBodyRight.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::EzPos.Properties.Resources.Delete32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(28, 560);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(144, 40);
            this.btnDelete.TabIndex = 99;
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
            this.btnNew.TabIndex = 100;
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
            this.grbAddress.Location = new System.Drawing.Point(10, -6);
            this.grbAddress.Name = "grbAddress";
            this.grbAddress.Size = new System.Drawing.Size(180, 150);
            this.grbAddress.TabIndex = 97;
            this.grbAddress.TabStop = false;
            // 
            // addressLbl
            // 
            this.addressLbl.BackColor = System.Drawing.Color.Transparent;
            this.addressLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressLbl.ForeColor = System.Drawing.Color.White;
            this.addressLbl.Location = new System.Drawing.Point(1, 39);
            this.addressLbl.Name = "addressLbl";
            this.addressLbl.Size = new System.Drawing.Size(177, 110);
            this.addressLbl.TabIndex = 91;
            // 
            // lblBankInfo
            // 
            this.lblBankInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblBankInfo.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankInfo.ForeColor = System.Drawing.Color.Yellow;
            this.lblBankInfo.Location = new System.Drawing.Point(10, 151);
            this.lblBankInfo.Name = "lblBankInfo";
            this.lblBankInfo.Size = new System.Drawing.Size(179, 31);
            this.lblBankInfo.TabIndex = 5;
            this.lblBankInfo.Text = "ធានាគារ";
            // 
            // grbPrintCard
            // 
            this.grbPrintCard.BackgroundImage = global::EzPos.Properties.Resources.pnlBodyRight;
            this.grbPrintCard.Controls.Add(this.bankInfoLbl);
            this.grbPrintCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbPrintCard.Location = new System.Drawing.Point(10, 150);
            this.grbPrintCard.Name = "grbPrintCard";
            this.grbPrintCard.Size = new System.Drawing.Size(180, 149);
            this.grbPrintCard.TabIndex = 4;
            this.grbPrintCard.TabStop = false;
            // 
            // bankInfoLbl
            // 
            this.bankInfoLbl.BackColor = System.Drawing.Color.Transparent;
            this.bankInfoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bankInfoLbl.ForeColor = System.Drawing.Color.White;
            this.bankInfoLbl.Location = new System.Drawing.Point(1, 34);
            this.bankInfoLbl.Name = "bankInfoLbl";
            this.bankInfoLbl.Size = new System.Drawing.Size(177, 113);
            this.bankInfoLbl.TabIndex = 93;
            // 
            // pnlBodySearch
            // 
            this.pnlBodySearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBodySearch.Controls.Add(this.lblResultInfo);
            this.pnlBodySearch.Controls.Add(this.lblCardNum);
            this.pnlBodySearch.Controls.Add(this.txtSupplierName);
            this.pnlBodySearch.Controls.Add(this.cmbCountry);
            this.pnlBodySearch.Controls.Add(this.lblCountry);
            this.pnlBodySearch.Controls.Add(this.btnReset);
            this.pnlBodySearch.Controls.Add(this.btnSearch);
            this.pnlBodySearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBodySearch.Location = new System.Drawing.Point(0, 0);
            this.pnlBodySearch.Name = "pnlBodySearch";
            this.pnlBodySearch.Size = new System.Drawing.Size(826, 90);
            this.pnlBodySearch.TabIndex = 0;
            // 
            // lblResultInfo
            // 
            this.lblResultInfo.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultInfo.Location = new System.Drawing.Point(7, 51);
            this.lblResultInfo.Name = "lblResultInfo";
            this.lblResultInfo.Size = new System.Drawing.Size(803, 32);
            this.lblResultInfo.TabIndex = 15;
            // 
            // lblCardNum
            // 
            this.lblCardNum.AutoSize = true;
            this.lblCardNum.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardNum.Location = new System.Drawing.Point(8, 12);
            this.lblCardNum.Name = "lblCardNum";
            this.lblCardNum.Size = new System.Drawing.Size(57, 27);
            this.lblCardNum.TabIndex = 0;
            this.lblCardNum.Text = "ឈ្មោះ";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierName.Location = new System.Drawing.Point(71, 12);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(184, 27);
            this.txtSupplierName.TabIndex = 1;
            // 
            // cmbCountry
            // 
            this.cmbCountry.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(351, 12);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(184, 27);
            this.cmbCountry.TabIndex = 3;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(277, 12);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(68, 27);
            this.lblCountry.TabIndex = 2;
            this.lblCountry.Text = "ប្រទេស";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::EzPos.Properties.Resources.Undo32;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnReset.Location = new System.Drawing.Point(626, 11);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(89, 28);
            this.btnReset.TabIndex = 8;
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
            this.btnSearch.Location = new System.Drawing.Point(721, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 28);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "&Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // SupplierName
            // 
            this.SupplierName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SupplierName.DataPropertyName = "SupplierName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.SupplierName.DefaultCellStyle = dataGridViewCellStyle2;
            this.SupplierName.HeaderText = "ឈ្មោះ";
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.ReadOnly = true;
            this.SupplierName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SupplierName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PhoneNumber.DataPropertyName = "PhoneNumber";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PhoneNumber.DefaultCellStyle = dataGridViewCellStyle3;
            this.PhoneNumber.HeaderText = "ទូរស័ព្ទ";
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.ReadOnly = true;
            this.PhoneNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PhoneNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PhoneNumber.Width = 170;
            // 
            // FaxNumber
            // 
            this.FaxNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FaxNumber.DataPropertyName = "FaxNumber";
            this.FaxNumber.HeaderText = "ទូរសារ";
            this.FaxNumber.Name = "FaxNumber";
            this.FaxNumber.ReadOnly = true;
            this.FaxNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FaxNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FaxNumber.Width = 170;
            // 
            // CountryStr
            // 
            this.CountryStr.DataPropertyName = "CountryStr";
            this.CountryStr.HeaderText = "ប្រទេស";
            this.CountryStr.Name = "CountryStr";
            this.CountryStr.Width = 170;
            // 
            // SupplierId
            // 
            this.SupplierId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SupplierId.DataPropertyName = "SupplierId";
            this.SupplierId.HeaderText = "SupplierId";
            this.SupplierId.Name = "SupplierId";
            this.SupplierId.ReadOnly = true;
            this.SupplierId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SupplierId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SupplierId.Visible = false;
            // 
            // SupplierCode
            // 
            this.SupplierCode.DataPropertyName = "SupplierCode";
            this.SupplierCode.HeaderText = "SupplierCode";
            this.SupplierCode.Name = "SupplierCode";
            this.SupplierCode.Visible = false;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.Visible = false;
            // 
            // EmailAddress
            // 
            this.EmailAddress.DataPropertyName = "EmailAddress";
            this.EmailAddress.HeaderText = "EmailAddress";
            this.EmailAddress.Name = "EmailAddress";
            this.EmailAddress.Visible = false;
            // 
            // Website
            // 
            this.Website.DataPropertyName = "Website";
            this.Website.HeaderText = "Website";
            this.Website.Name = "Website";
            this.Website.Visible = false;
            // 
            // CountryId
            // 
            this.CountryId.DataPropertyName = "CountryId";
            this.CountryId.HeaderText = "CountryId";
            this.CountryId.Name = "CountryId";
            this.CountryId.Visible = false;
            // 
            // BankInformation
            // 
            this.BankInformation.DataPropertyName = "BankInformation";
            this.BankInformation.HeaderText = "BankInformation";
            this.BankInformation.Name = "BankInformation";
            this.BankInformation.Visible = false;
            // 
            // CtrlSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBodyLeft);
            this.Controls.Add(this.pnlBodySearch);
            this.Controls.Add(this.pnlBodyRight);
            this.Name = "CtrlSupplier";
            this.Size = new System.Drawing.Size(1026, 595);
            this.Load += new System.EventHandler(this.CtrlSupplier_Load);
            this.pnlBodyLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).EndInit();
            this.pnlBodyRight.ResumeLayout(false);
            this.grbAddress.ResumeLayout(false);
            this.grbPrintCard.ResumeLayout(false);
            this.pnlBodySearch.ResumeLayout(false);
            this.pnlBodySearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBodyLeft;
        private System.Windows.Forms.Panel pnlBodyRight;
        private System.Windows.Forms.DataGridView dgvSupplier;
        private System.Windows.Forms.Label lblBankInfo;
        private System.Windows.Forms.GroupBox grbPrintCard;
        private System.Windows.Forms.Panel pnlBodySearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private ExtendedComboBox cmbCountry;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblCardNum;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Label lblResultInfo;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.GroupBox grbAddress;
        private System.Windows.Forms.Label addressLbl;
        private System.Windows.Forms.Label bankInfoLbl;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaxNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Website;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankInformation;

    }
}