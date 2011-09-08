using EzPos.GUIs.Components;

namespace EzPos.GUIs.Controls
{
    partial class CtrlCustomer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBodyLeft = new System.Windows.Forms.Panel();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.pnlBodyRight = new System.Windows.Forms.Panel();
            this.btnOutstandingInvoice = new System.Windows.Forms.Button();
            this.lblAmount = new System.Windows.Forms.Label();
            this.grbAmount = new System.Windows.Forms.GroupBox();
            this.purchaseAmountLbl = new System.Windows.Forms.Label();
            this.debtAmountLbl = new System.Windows.Forms.Label();
            this.lblDebtAmount = new System.Windows.Forms.Label();
            this.lblPurchaseAmount = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.grbAddress = new System.Windows.Forms.GroupBox();
            this.addressLbl = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.pnlBodySearch = new System.Windows.Forms.Panel();
            this.chbDeposit = new System.Windows.Forms.CheckBox();
            this.lblResultInfo = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCardNum = new System.Windows.Forms.Label();
            this.txtCardNum = new System.Windows.Forms.TextBox();
            this.lblDCountType = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbDCardType = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.cmbDiscountCard = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenderStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Website = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchasedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebtAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountCardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FKDiscountCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountRejected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBodyLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.pnlBodyRight.SuspendLayout();
            this.grbAmount.SuspendLayout();
            this.grbAddress.SuspendLayout();
            this.pnlBodySearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBodyLeft
            // 
            this.pnlBodyLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBodyLeft.Controls.Add(this.dgvCustomer);
            this.pnlBodyLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBodyLeft.Location = new System.Drawing.Point(0, 120);
            this.pnlBodyLeft.Name = "pnlBodyLeft";
            this.pnlBodyLeft.Size = new System.Drawing.Size(824, 471);
            this.pnlBodyLeft.TabIndex = 1;
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowUserToAddRows = false;
            this.dgvCustomer.AllowUserToDeleteRows = false;
            this.dgvCustomer.AllowUserToResizeColumns = false;
            this.dgvCustomer.AllowUserToResizeRows = false;
            this.dgvCustomer.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCustomer.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomer.ColumnHeadersHeight = 40;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerID,
            this.CustomerCode,
            this.CustomerName,
            this.GenderStr,
            this.GenderID,
            this.PhoneNumber,
            this.EmailAddress,
            this.Website,
            this.Address,
            this.PurchasedAmount,
            this.DebtAmount,
            this.DiscountCardNumber,
            this.DiscountCardType,
            this.DiscountPercentage,
            this.FKDiscountCard,
            this.DiscountRejected,
            this.LocalName,
            this.CustomerNameCol});
            this.dgvCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomer.EnableHeadersVisualStyles = false;
            this.dgvCustomer.GridColor = System.Drawing.Color.White;
            this.dgvCustomer.Location = new System.Drawing.Point(0, 0);
            this.dgvCustomer.MultiSelect = false;
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCustomer.RowHeadersVisible = false;
            this.dgvCustomer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCustomer.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Candara", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCustomer.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.dgvCustomer.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dgvCustomer.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvCustomer.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Maroon;
            this.dgvCustomer.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomer.RowTemplate.Height = 50;
            this.dgvCustomer.RowTemplate.ReadOnly = true;
            this.dgvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomer.Size = new System.Drawing.Size(822, 469);
            this.dgvCustomer.TabIndex = 1;
            this.dgvCustomer.VirtualMode = true;
            this.dgvCustomer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCustomerCellDoubleClick);
            this.dgvCustomer.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvCustomerDataError);
            this.dgvCustomer.SelectionChanged += new System.EventHandler(this.DgvCustomerSelectionChanged);
            // 
            // pnlBodyRight
            // 
            this.pnlBodyRight.BackgroundImage = global::EzPos.Properties.Resources.backgroud_12;
            this.pnlBodyRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBodyRight.Controls.Add(this.btnOutstandingInvoice);
            this.pnlBodyRight.Controls.Add(this.cmbDiscountCard);
            this.pnlBodyRight.Controls.Add(this.lblAmount);
            this.pnlBodyRight.Controls.Add(this.grbAmount);
            this.pnlBodyRight.Controls.Add(this.lblAddress);
            this.pnlBodyRight.Controls.Add(this.grbAddress);
            this.pnlBodyRight.Controls.Add(this.btnDelete);
            this.pnlBodyRight.Controls.Add(this.btnNew);
            this.pnlBodyRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBodyRight.Location = new System.Drawing.Point(824, 0);
            this.pnlBodyRight.Name = "pnlBodyRight";
            this.pnlBodyRight.Size = new System.Drawing.Size(200, 591);
            this.pnlBodyRight.TabIndex = 2;
            // 
            // btnOutstandingInvoice
            // 
            this.btnOutstandingInvoice.BackColor = System.Drawing.Color.Transparent;
            this.btnOutstandingInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOutstandingInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOutstandingInvoice.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutstandingInvoice.ForeColor = System.Drawing.Color.White;
            this.btnOutstandingInvoice.Image = global::EzPos.Properties.Resources.Customer32;
            this.btnOutstandingInvoice.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnOutstandingInvoice.Location = new System.Drawing.Point(28, 478);
            this.btnOutstandingInvoice.Name = "btnOutstandingInvoice";
            this.btnOutstandingInvoice.Size = new System.Drawing.Size(144, 40);
            this.btnOutstandingInvoice.TabIndex = 102;
            this.btnOutstandingInvoice.Text = "ប្រាក់កក់";
            this.btnOutstandingInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOutstandingInvoice.UseVisualStyleBackColor = false;
            this.btnOutstandingInvoice.MouseLeave += new System.EventHandler(this.BtnOutstandingInvoiceMouseLeave);
            this.btnOutstandingInvoice.Click += new System.EventHandler(this.BtnOutstandingInvoiceClick);
            this.btnOutstandingInvoice.MouseEnter += new System.EventHandler(this.BtnOutstandingInvoiceMouseEnter);
            // 
            // lblAmount
            // 
            this.lblAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblAmount.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.Yellow;
            this.lblAmount.Location = new System.Drawing.Point(10, 151);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(179, 32);
            this.lblAmount.TabIndex = 100;
            this.lblAmount.Text = "ទឹកប្រាក់";
            // 
            // grbAmount
            // 
            this.grbAmount.BackgroundImage = global::EzPos.Properties.Resources.pnlBodyRight;
            this.grbAmount.Controls.Add(this.purchaseAmountLbl);
            this.grbAmount.Controls.Add(this.debtAmountLbl);
            this.grbAmount.Controls.Add(this.lblDebtAmount);
            this.grbAmount.Controls.Add(this.lblPurchaseAmount);
            this.grbAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbAmount.Location = new System.Drawing.Point(10, 150);
            this.grbAmount.Name = "grbAmount";
            this.grbAmount.Size = new System.Drawing.Size(180, 99);
            this.grbAmount.TabIndex = 99;
            this.grbAmount.TabStop = false;
            // 
            // purchaseAmountLbl
            // 
            this.purchaseAmountLbl.BackColor = System.Drawing.Color.Transparent;
            this.purchaseAmountLbl.Font = new System.Drawing.Font("Candara", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaseAmountLbl.ForeColor = System.Drawing.Color.White;
            this.purchaseAmountLbl.Location = new System.Drawing.Point(68, 33);
            this.purchaseAmountLbl.Name = "purchaseAmountLbl";
            this.purchaseAmountLbl.Size = new System.Drawing.Size(112, 24);
            this.purchaseAmountLbl.TabIndex = 92;
            this.purchaseAmountLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // debtAmountLbl
            // 
            this.debtAmountLbl.BackColor = System.Drawing.Color.Transparent;
            this.debtAmountLbl.Font = new System.Drawing.Font("Candara", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debtAmountLbl.ForeColor = System.Drawing.Color.White;
            this.debtAmountLbl.Location = new System.Drawing.Point(71, 64);
            this.debtAmountLbl.Name = "debtAmountLbl";
            this.debtAmountLbl.Size = new System.Drawing.Size(108, 27);
            this.debtAmountLbl.TabIndex = 94;
            this.debtAmountLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDebtAmount
            // 
            this.lblDebtAmount.AutoSize = true;
            this.lblDebtAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblDebtAmount.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebtAmount.Location = new System.Drawing.Point(3, 66);
            this.lblDebtAmount.Name = "lblDebtAmount";
            this.lblDebtAmount.Size = new System.Drawing.Size(54, 27);
            this.lblDebtAmount.TabIndex = 93;
            this.lblDebtAmount.Text = "ជំពាក់";
            this.lblDebtAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPurchaseAmount
            // 
            this.lblPurchaseAmount.AutoSize = true;
            this.lblPurchaseAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblPurchaseAmount.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchaseAmount.Location = new System.Drawing.Point(3, 34);
            this.lblPurchaseAmount.Name = "lblPurchaseAmount";
            this.lblPurchaseAmount.Size = new System.Drawing.Size(72, 27);
            this.lblPurchaseAmount.TabIndex = 91;
            this.lblPurchaseAmount.Text = "បានទិញ";
            this.lblPurchaseAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAddress
            // 
            this.lblAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblAddress.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.Yellow;
            this.lblAddress.Location = new System.Drawing.Point(10, 1);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(179, 32);
            this.lblAddress.TabIndex = 96;
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
            this.grbAddress.TabIndex = 95;
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
            this.btnDelete.TabIndex = 82;
            this.btnDelete.Text = "លុបចោល";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.MouseLeave += new System.EventHandler(this.BtnDeleteMouseLeave);
            this.btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
            this.btnDelete.MouseEnter += new System.EventHandler(this.BtnDeleteMouseEnter);
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
            this.btnNew.TabIndex = 83;
            this.btnNew.Text = "បង្កើតថ្មី";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.MouseLeave += new System.EventHandler(this.BtnNewMouseLeave);
            this.btnNew.Click += new System.EventHandler(this.BtnNewClick);
            this.btnNew.MouseEnter += new System.EventHandler(this.BtnNewMouseEnter);
            // 
            // pnlBodySearch
            // 
            this.pnlBodySearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBodySearch.Controls.Add(this.chbDeposit);
            this.pnlBodySearch.Controls.Add(this.lblResultInfo);
            this.pnlBodySearch.Controls.Add(this.lblPhoneNumber);
            this.pnlBodySearch.Controls.Add(this.txtPhoneNumber);
            this.pnlBodySearch.Controls.Add(this.lblCustomerName);
            this.pnlBodySearch.Controls.Add(this.txtCustomerName);
            this.pnlBodySearch.Controls.Add(this.lblCardNum);
            this.pnlBodySearch.Controls.Add(this.txtCardNum);
            this.pnlBodySearch.Controls.Add(this.cmbDCardType);
            this.pnlBodySearch.Controls.Add(this.lblDCountType);
            this.pnlBodySearch.Controls.Add(this.btnReset);
            this.pnlBodySearch.Controls.Add(this.btnSearch);
            this.pnlBodySearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBodySearch.Location = new System.Drawing.Point(0, 0);
            this.pnlBodySearch.Name = "pnlBodySearch";
            this.pnlBodySearch.Size = new System.Drawing.Size(824, 120);
            this.pnlBodySearch.TabIndex = 0;
            // 
            // chbDeposit
            // 
            this.chbDeposit.AutoSize = true;
            this.chbDeposit.BackColor = System.Drawing.Color.Transparent;
            this.chbDeposit.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbDeposit.Location = new System.Drawing.Point(625, 10);
            this.chbDeposit.Name = "chbDeposit";
            this.chbDeposit.Size = new System.Drawing.Size(123, 34);
            this.chbDeposit.TabIndex = 15;
            this.chbDeposit.Text = "បានកក់ប្រាក់";
            this.chbDeposit.UseVisualStyleBackColor = false;
            // 
            // lblResultInfo
            // 
            this.lblResultInfo.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultInfo.Location = new System.Drawing.Point(8, 86);
            this.lblResultInfo.Name = "lblResultInfo";
            this.lblResultInfo.Size = new System.Drawing.Size(799, 27);
            this.lblResultInfo.TabIndex = 14;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(320, 12);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(61, 27);
            this.lblPhoneNumber.TabIndex = 12;
            this.lblPhoneNumber.Text = "ទូរស័ព្ទ";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(388, 12);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(184, 27);
            this.txtPhoneNumber.TabIndex = 13;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(8, 12);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(57, 27);
            this.lblCustomerName.TabIndex = 10;
            this.lblCustomerName.Text = "ឈ្មោះ";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(93, 12);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(184, 27);
            this.txtCustomerName.TabIndex = 11;
            // 
            // lblCardNum
            // 
            this.lblCardNum.AutoSize = true;
            this.lblCardNum.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardNum.Location = new System.Drawing.Point(8, 49);
            this.lblCardNum.Name = "lblCardNum";
            this.lblCardNum.Size = new System.Drawing.Size(79, 27);
            this.lblCardNum.TabIndex = 0;
            this.lblCardNum.Text = "លេខកាត";
            // 
            // txtCardNum
            // 
            this.txtCardNum.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNum.Location = new System.Drawing.Point(93, 49);
            this.txtCardNum.Name = "txtCardNum";
            this.txtCardNum.Size = new System.Drawing.Size(184, 27);
            this.txtCardNum.TabIndex = 1;
            // 
            // lblDCountType
            // 
            this.lblDCountType.AutoSize = true;
            this.lblDCountType.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDCountType.Location = new System.Drawing.Point(320, 49);
            this.lblDCountType.Name = "lblDCountType";
            this.lblDCountType.Size = new System.Drawing.Size(62, 27);
            this.lblDCountType.TabIndex = 2;
            this.lblDCountType.Text = "ប្រភេទ";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::EzPos.Properties.Resources.Undo32;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnReset.Location = new System.Drawing.Point(621, 48);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(89, 28);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "&Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::EzPos.Properties.Resources.Search32;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(716, 48);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 28);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "&Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearchClick);
            // 
            // cmbDCardType
            // 
            this.cmbDCardType.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDCardType.FormattingEnabled = true;
            this.cmbDCardType.Location = new System.Drawing.Point(388, 49);
            this.cmbDCardType.Name = "cmbDCardType";
            this.cmbDCardType.Size = new System.Drawing.Size(184, 27);
            this.cmbDCardType.TabIndex = 3;
            // 
            // cmbDiscountCard
            // 
            this.cmbDiscountCard.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDiscountCard.FormattingEnabled = true;
            this.cmbDiscountCard.Location = new System.Drawing.Point(8, 281);
            this.cmbDiscountCard.Name = "cmbDiscountCard";
            this.cmbDiscountCard.Size = new System.Drawing.Size(184, 28);
            this.cmbDiscountCard.TabIndex = 101;
            this.cmbDiscountCard.Visible = false;
            // 
            // CustomerID
            // 
            this.CustomerID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CustomerID.DataPropertyName = "CustomerID";
            this.CustomerID.HeaderText = "CustomerID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CustomerID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CustomerID.Visible = false;
            // 
            // CustomerCode
            // 
            this.CustomerCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CustomerCode.DataPropertyName = "CustomerCode";
            this.CustomerCode.HeaderText = "CustomerCode";
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CustomerCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CustomerCode.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CustomerName.DataPropertyName = "DisplayName";
            this.CustomerName.HeaderText = "ឈ្មោះអតិថិជន";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GenderStr
            // 
            this.GenderStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.GenderStr.DataPropertyName = "GenderStr";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GenderStr.DefaultCellStyle = dataGridViewCellStyle2;
            this.GenderStr.HeaderText = "ភេទ";
            this.GenderStr.Name = "GenderStr";
            this.GenderStr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GenderStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GenderStr.Width = 95;
            // 
            // GenderID
            // 
            this.GenderID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.GenderID.DataPropertyName = "GenderID";
            this.GenderID.HeaderText = "GenderID";
            this.GenderID.Name = "GenderID";
            this.GenderID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GenderID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GenderID.Visible = false;
            this.GenderID.Width = 80;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PhoneNumber.DataPropertyName = "PhoneNumber";
            this.PhoneNumber.HeaderText = "លេខទូរស័ព្ទ";
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PhoneNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PhoneNumber.Width = 130;
            // 
            // EmailAddress
            // 
            this.EmailAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EmailAddress.DataPropertyName = "EmailAddress";
            this.EmailAddress.HeaderText = "សារអេឡិចត្រូនិច";
            this.EmailAddress.Name = "EmailAddress";
            this.EmailAddress.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EmailAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EmailAddress.Visible = false;
            // 
            // Website
            // 
            this.Website.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Website.DataPropertyName = "Website";
            this.Website.HeaderText = "គេហៈទំព័រ";
            this.Website.Name = "Website";
            this.Website.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Website.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Website.Visible = false;
            this.Website.Width = 215;
            // 
            // Address
            // 
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "អាស័យដ្ឋាន";
            this.Address.Name = "Address";
            this.Address.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Address.Visible = false;
            // 
            // PurchasedAmount
            // 
            this.PurchasedAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PurchasedAmount.DataPropertyName = "PurchasedAmount";
            this.PurchasedAmount.HeaderText = "PurchasedAmount";
            this.PurchasedAmount.Name = "PurchasedAmount";
            this.PurchasedAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PurchasedAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PurchasedAmount.Visible = false;
            // 
            // DebtAmount
            // 
            this.DebtAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DebtAmount.DataPropertyName = "DebtAmount";
            this.DebtAmount.HeaderText = "DebtAmount";
            this.DebtAmount.Name = "DebtAmount";
            this.DebtAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DebtAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DebtAmount.Visible = false;
            // 
            // DiscountCardNumber
            // 
            this.DiscountCardNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DiscountCardNumber.DataPropertyName = "DiscountCardNumber";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DiscountCardNumber.DefaultCellStyle = dataGridViewCellStyle3;
            this.DiscountCardNumber.HeaderText = "លេខកាត";
            this.DiscountCardNumber.Name = "DiscountCardNumber";
            this.DiscountCardNumber.ReadOnly = true;
            this.DiscountCardNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DiscountCardNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DiscountCardNumber.Width = 130;
            // 
            // DiscountCardType
            // 
            this.DiscountCardType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DiscountCardType.DataPropertyName = "DiscountCardType";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DiscountCardType.DefaultCellStyle = dataGridViewCellStyle4;
            this.DiscountCardType.HeaderText = "ប្រភេទកាត";
            this.DiscountCardType.Name = "DiscountCardType";
            this.DiscountCardType.ReadOnly = true;
            this.DiscountCardType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DiscountCardType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DiscountCardType.Width = 130;
            // 
            // DiscountPercentage
            // 
            this.DiscountPercentage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DiscountPercentage.DataPropertyName = "DiscountPercentage";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.DiscountPercentage.DefaultCellStyle = dataGridViewCellStyle5;
            this.DiscountPercentage.HeaderText = "%";
            this.DiscountPercentage.Name = "DiscountPercentage";
            this.DiscountPercentage.ReadOnly = true;
            this.DiscountPercentage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DiscountPercentage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DiscountPercentage.Width = 50;
            // 
            // FKDiscountCard
            // 
            this.FKDiscountCard.DataPropertyName = "FKDiscountCard";
            this.FKDiscountCard.HeaderText = "FKDiscountCard";
            this.FKDiscountCard.Name = "FKDiscountCard";
            this.FKDiscountCard.Visible = false;
            // 
            // DiscountRejected
            // 
            this.DiscountRejected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DiscountRejected.DataPropertyName = "DiscountRejected";
            this.DiscountRejected.HeaderText = "DiscountRejected";
            this.DiscountRejected.Name = "DiscountRejected";
            this.DiscountRejected.ReadOnly = true;
            this.DiscountRejected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DiscountRejected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DiscountRejected.Visible = false;
            // 
            // LocalName
            // 
            this.LocalName.DataPropertyName = "LocalName";
            this.LocalName.HeaderText = "LocalName";
            this.LocalName.Name = "LocalName";
            this.LocalName.Visible = false;
            // 
            // CustomerNameCol
            // 
            this.CustomerNameCol.DataPropertyName = "CustomerName";
            this.CustomerNameCol.HeaderText = "CustomerName";
            this.CustomerNameCol.Name = "CustomerNameCol";
            this.CustomerNameCol.Visible = false;
            // 
            // CtrlCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBodyLeft);
            this.Controls.Add(this.pnlBodySearch);
            this.Controls.Add(this.pnlBodyRight);
            this.Name = "CtrlCustomer";
            this.Size = new System.Drawing.Size(1024, 591);
            this.Load += new System.EventHandler(this.CtrlCustomer_Load);
            this.pnlBodyLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.pnlBodyRight.ResumeLayout(false);
            this.grbAmount.ResumeLayout(false);
            this.grbAmount.PerformLayout();
            this.grbAddress.ResumeLayout(false);
            this.pnlBodySearch.ResumeLayout(false);
            this.pnlBodySearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBodyLeft;
        private System.Windows.Forms.Panel pnlBodyRight;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.GroupBox grbAddress;
        private System.Windows.Forms.Label addressLbl;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.GroupBox grbAmount;
        private System.Windows.Forms.Label debtAmountLbl;
        private System.Windows.Forms.Label lblDebtAmount;
        private System.Windows.Forms.Label purchaseAmountLbl;
        private System.Windows.Forms.Label lblPurchaseAmount;
        private System.Windows.Forms.Panel pnlBodySearch;
        private System.Windows.Forms.Label lblCardNum;
        private System.Windows.Forms.TextBox txtCardNum;
        private ExtendedComboBox cmbDCardType;
        private System.Windows.Forms.Label lblDCountType;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblResultInfo;
        private ExtendedComboBox cmbDiscountCard;
        private System.Windows.Forms.Button btnOutstandingInvoice;
        private System.Windows.Forms.CheckBox chbDeposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenderStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Website;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchasedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebtAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountCardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountCardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn FKDiscountCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountRejected;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerNameCol;
    }
}