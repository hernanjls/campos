using ExtendedComboBox = EzPos.GUIs.Components.ExtendedComboBox;

namespace EzPos.GUIs.Forms
{
    partial class FrmSaleSearch
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

        #region Windows Form Designer generated code

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblProductName = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnDeleteDeposit = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgvSearchResult = new System.Windows.Forms.DataGridView();
            this.lblSearchInfo = new System.Windows.Forms.Label();
            this.grbProductInfo = new System.Windows.Forms.GroupBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbColor = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.cmbBrand = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.cmbCategory = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.grbCustomerInfo = new System.Windows.Forms.GroupBox();
            this.lblDiscountType = new System.Windows.Forms.Label();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.cmbDiscountType = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.cmbCustomer = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.grbSaleInfo = new System.Windows.Forms.GroupBox();
            this.rbtDeposit = new System.Windows.Forms.RadioButton();
            this.rbtSale = new System.Windows.Forms.RadioButton();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.lblStopDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.dtpStopDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.ReportId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExchangeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountSoldInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountPaidInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountPaidRiel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountReturnInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountReturnRiel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPriceIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPriceOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtySold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportTypeStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepositAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResult)).BeginInit();
            this.grbProductInfo.SuspendLayout();
            this.grbCustomerInfo.SuspendLayout();
            this.grbSaleInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.BackColor = System.Drawing.Color.Transparent;
            this.lblProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductName.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.Yellow;
            this.lblProductName.Location = new System.Drawing.Point(0, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(694, 89);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackgroundImage = global::EzPos.Properties.Resources.backgroud_11;
            this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHeader.Controls.Add(this.lblProductName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(694, 89);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::EzPos.Properties.Resources.OK32;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(443, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(116, 36);
            this.btnSearch.TabIndex = 46;
            this.btnSearch.Text = "​ស្វែងរក";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.MouseLeave += new System.EventHandler(this.BtnSearchMouseLeave);
            this.btnSearch.Click += new System.EventHandler(this.BtnSearchClick);
            this.btnSearch.MouseEnter += new System.EventHandler(this.BtnSearchMouseEnter);
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
            this.btnCancel.Location = new System.Drawing.Point(560, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 36);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "បិទ";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.MouseLeave += new System.EventHandler(this.BtnCancelMouseLeave);
            this.btnCancel.MouseEnter += new System.EventHandler(this.BtnCancelMouseEnter);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackgroundImage = global::EzPos.Properties.Resources.background_5;
            this.pnlFooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFooter.Controls.Add(this.btnDeleteDeposit);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSearch);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 507);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(694, 48);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnDeleteDeposit
            // 
            this.btnDeleteDeposit.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteDeposit.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnDeleteDeposit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteDeposit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteDeposit.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDeposit.ForeColor = System.Drawing.Color.White;
            this.btnDeleteDeposit.Image = global::EzPos.Properties.Resources.Delete32;
            this.btnDeleteDeposit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteDeposit.Location = new System.Drawing.Point(20, 9);
            this.btnDeleteDeposit.Name = "btnDeleteDeposit";
            this.btnDeleteDeposit.Size = new System.Drawing.Size(116, 36);
            this.btnDeleteDeposit.TabIndex = 48;
            this.btnDeleteDeposit.Text = "បោះបង់";
            this.btnDeleteDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteDeposit.UseVisualStyleBackColor = false;
            this.btnDeleteDeposit.Visible = false;
            this.btnDeleteDeposit.MouseLeave += new System.EventHandler(this.BtnDeleteDepositMouseLeave);
            this.btnDeleteDeposit.Click += new System.EventHandler(this.BtnDeleteDepositClick);
            this.btnDeleteDeposit.MouseEnter += new System.EventHandler(this.BtnDeleteDepositMouseEnter);
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody.Controls.Add(this.dgvSearchResult);
            this.pnlBody.Controls.Add(this.lblSearchInfo);
            this.pnlBody.Controls.Add(this.grbProductInfo);
            this.pnlBody.Controls.Add(this.grbCustomerInfo);
            this.pnlBody.Controls.Add(this.grbSaleInfo);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBody.Location = new System.Drawing.Point(0, 89);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(694, 418);
            this.pnlBody.TabIndex = 1;
            // 
            // dgvSearchResult
            // 
            this.dgvSearchResult.AllowUserToAddRows = false;
            this.dgvSearchResult.AllowUserToDeleteRows = false;
            this.dgvSearchResult.AllowUserToResizeColumns = false;
            this.dgvSearchResult.AllowUserToResizeRows = false;
            this.dgvSearchResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvSearchResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSearchResult.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSearchResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSearchResult.ColumnHeadersHeight = 40;
            this.dgvSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSearchResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReportId,
            this.SaleOrderNumber,
            this.SaleOrderDate,
            this.CustomerId,
            this.CustomerName,
            this.CashierName,
            this.ExchangeRate,
            this.AmountSoldInt,
            this.AmountPaidInt,
            this.AmountPaidRiel,
            this.AmountReturnInt,
            this.AmountReturnRiel,
            this.DiscountTypeId,
            this.CardNumber,
            this.TotalDiscount,
            this.SaleItemId,
            this.ProductId,
            this.ProductNameCol,
            this.UnitPriceIn,
            this.UnitPriceOut,
            this.Discount,
            this.QtySold,
            this.SubTotal,
            this.ReportHeader,
            this.ReferenceNum,
            this.ReportTypeStr,
            this.SalesOrderId,
            this.DepositAmount,
            this.ProductCode,
            this.CategoryStr,
            this.PurchaseUnitPrice});
            this.dgvSearchResult.EnableHeadersVisualStyles = false;
            this.dgvSearchResult.GridColor = System.Drawing.Color.White;
            this.dgvSearchResult.Location = new System.Drawing.Point(19, 48);
            this.dgvSearchResult.MultiSelect = false;
            this.dgvSearchResult.Name = "dgvSearchResult";
            this.dgvSearchResult.ReadOnly = true;
            this.dgvSearchResult.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSearchResult.RowHeadersVisible = false;
            this.dgvSearchResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSearchResult.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Candara", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSearchResult.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.dgvSearchResult.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dgvSearchResult.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvSearchResult.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Maroon;
            this.dgvSearchResult.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSearchResult.RowTemplate.Height = 50;
            this.dgvSearchResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearchResult.Size = new System.Drawing.Size(657, 349);
            this.dgvSearchResult.TabIndex = 4;
            this.dgvSearchResult.Visible = false;
            this.dgvSearchResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSearchResultCellDoubleClick);
            // 
            // lblSearchInfo
            // 
            this.lblSearchInfo.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchInfo.Location = new System.Drawing.Point(14, 13);
            this.lblSearchInfo.Name = "lblSearchInfo";
            this.lblSearchInfo.Size = new System.Drawing.Size(668, 29);
            this.lblSearchInfo.TabIndex = 3;
            this.lblSearchInfo.Visible = false;
            // 
            // grbProductInfo
            // 
            this.grbProductInfo.Controls.Add(this.lblProductCode);
            this.grbProductInfo.Controls.Add(this.lblColor);
            this.grbProductInfo.Controls.Add(this.lblBrand);
            this.grbProductInfo.Controls.Add(this.lblCategory);
            this.grbProductInfo.Controls.Add(this.cmbColor);
            this.grbProductInfo.Controls.Add(this.cmbBrand);
            this.grbProductInfo.Controls.Add(this.txtProductCode);
            this.grbProductInfo.Controls.Add(this.cmbCategory);
            this.grbProductInfo.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbProductInfo.Location = new System.Drawing.Point(19, 277);
            this.grbProductInfo.Name = "grbProductInfo";
            this.grbProductInfo.Size = new System.Drawing.Size(657, 120);
            this.grbProductInfo.TabIndex = 2;
            this.grbProductInfo.TabStop = false;
            this.grbProductInfo.Text = "ពត៌មានអំពីផលិតផល";
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Location = new System.Drawing.Point(367, 73);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(78, 29);
            this.lblProductCode.TabIndex = 6;
            this.lblProductCode.Text = "លេខកូដ";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(43, 73);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(51, 29);
            this.lblColor.TabIndex = 2;
            this.lblColor.Text = "ពណ៌";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(400, 35);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(45, 29);
            this.lblBrand.TabIndex = 4;
            this.lblBrand.Text = "ម៉ាក";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(28, 35);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(66, 29);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "ប្រភេទ";
            // 
            // cmbColor
            // 
            this.cmbColor.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(100, 68);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(190, 36);
            this.cmbColor.TabIndex = 3;
            // 
            // cmbBrand
            // 
            this.cmbBrand.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(451, 30);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(190, 36);
            this.cmbBrand.TabIndex = 5;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(451, 68);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(190, 36);
            this.txtProductCode.TabIndex = 7;
            // 
            // cmbCategory
            // 
            this.cmbCategory.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(100, 30);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(190, 36);
            this.cmbCategory.TabIndex = 1;
            // 
            // grbCustomerInfo
            // 
            this.grbCustomerInfo.Controls.Add(this.lblDiscountType);
            this.grbCustomerInfo.Controls.Add(this.lblCardNumber);
            this.grbCustomerInfo.Controls.Add(this.lblPhoneNumber);
            this.grbCustomerInfo.Controls.Add(this.lblCustomerName);
            this.grbCustomerInfo.Controls.Add(this.cmbDiscountType);
            this.grbCustomerInfo.Controls.Add(this.txtCardNumber);
            this.grbCustomerInfo.Controls.Add(this.txtPhoneNumber);
            this.grbCustomerInfo.Controls.Add(this.cmbCustomer);
            this.grbCustomerInfo.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCustomerInfo.Location = new System.Drawing.Point(19, 152);
            this.grbCustomerInfo.Name = "grbCustomerInfo";
            this.grbCustomerInfo.Size = new System.Drawing.Size(657, 120);
            this.grbCustomerInfo.TabIndex = 1;
            this.grbCustomerInfo.TabStop = false;
            this.grbCustomerInfo.Text = "ពត៌មានអំពីអតិថិជន";
            // 
            // lblDiscountType
            // 
            this.lblDiscountType.AutoSize = true;
            this.lblDiscountType.Location = new System.Drawing.Point(347, 73);
            this.lblDiscountType.Name = "lblDiscountType";
            this.lblDiscountType.Size = new System.Drawing.Size(98, 29);
            this.lblDiscountType.TabIndex = 6;
            this.lblDiscountType.Text = "ប្រភេទកាត";
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.Location = new System.Drawing.Point(10, 73);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(84, 29);
            this.lblCardNumber.TabIndex = 2;
            this.lblCardNumber.Text = "លេខកាត";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(341, 35);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(104, 29);
            this.lblPhoneNumber.TabIndex = 4;
            this.lblPhoneNumber.Text = "លេខទូរស័ព្ទ";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(10, 35);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(60, 29);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "ឈ្មោះ";
            // 
            // cmbDiscountType
            // 
            this.cmbDiscountType.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDiscountType.FormattingEnabled = true;
            this.cmbDiscountType.Location = new System.Drawing.Point(451, 68);
            this.cmbDiscountType.Name = "cmbDiscountType";
            this.cmbDiscountType.Size = new System.Drawing.Size(190, 36);
            this.cmbDiscountType.TabIndex = 7;
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNumber.Location = new System.Drawing.Point(100, 68);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(190, 36);
            this.txtCardNumber.TabIndex = 3;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(451, 30);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(190, 36);
            this.txtPhoneNumber.TabIndex = 5;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(100, 30);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(190, 36);
            this.cmbCustomer.TabIndex = 1;
            // 
            // grbSaleInfo
            // 
            this.grbSaleInfo.Controls.Add(this.rbtDeposit);
            this.grbSaleInfo.Controls.Add(this.rbtSale);
            this.grbSaleInfo.Controls.Add(this.lblInvoiceNumber);
            this.grbSaleInfo.Controls.Add(this.lblStopDate);
            this.grbSaleInfo.Controls.Add(this.lblStartDate);
            this.grbSaleInfo.Controls.Add(this.txtInvoiceNumber);
            this.grbSaleInfo.Controls.Add(this.dtpStopDate);
            this.grbSaleInfo.Controls.Add(this.dtpStartDate);
            this.grbSaleInfo.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSaleInfo.Location = new System.Drawing.Point(19, 13);
            this.grbSaleInfo.Name = "grbSaleInfo";
            this.grbSaleInfo.Size = new System.Drawing.Size(657, 134);
            this.grbSaleInfo.TabIndex = 0;
            this.grbSaleInfo.TabStop = false;
            this.grbSaleInfo.Text = "ពត៌មានអំពីការលក់";
            // 
            // rbtDeposit
            // 
            this.rbtDeposit.AutoSize = true;
            this.rbtDeposit.Location = new System.Drawing.Point(119, 23);
            this.rbtDeposit.Name = "rbtDeposit";
            this.rbtDeposit.Size = new System.Drawing.Size(96, 33);
            this.rbtDeposit.TabIndex = 1;
            this.rbtDeposit.TabStop = true;
            this.rbtDeposit.Text = "កក់ប្រាក់";
            this.rbtDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtDeposit.UseVisualStyleBackColor = true;
            // 
            // rbtSale
            // 
            this.rbtSale.AutoSize = true;
            this.rbtSale.Location = new System.Drawing.Point(15, 23);
            this.rbtSale.Name = "rbtSale";
            this.rbtSale.Size = new System.Drawing.Size(63, 33);
            this.rbtSale.TabIndex = 0;
            this.rbtSale.TabStop = true;
            this.rbtSale.Text = "លក់";
            this.rbtSale.UseVisualStyleBackColor = true;
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Location = new System.Drawing.Point(446, 51);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(124, 29);
            this.lblInvoiceNumber.TabIndex = 6;
            this.lblInvoiceNumber.Text = "លេខវិក័យប័ត្រ";
            // 
            // lblStopDate
            // 
            this.lblStopDate.AutoSize = true;
            this.lblStopDate.Location = new System.Drawing.Point(228, 51);
            this.lblStopDate.Name = "lblStopDate";
            this.lblStopDate.Size = new System.Drawing.Size(78, 29);
            this.lblStopDate.TabIndex = 4;
            this.lblStopDate.Text = "ថ្ងៃបញ្ចប់";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(10, 51);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(98, 29);
            this.lblStartDate.TabIndex = 2;
            this.lblStartDate.Text = "ថ្ងៃចាប់ផ្ដើម";
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNumber.Location = new System.Drawing.Point(451, 83);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(190, 36);
            this.txtInvoiceNumber.TabIndex = 7;
            // 
            // dtpStopDate
            // 
            this.dtpStopDate.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStopDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStopDate.Location = new System.Drawing.Point(233, 83);
            this.dtpStopDate.Name = "dtpStopDate";
            this.dtpStopDate.Size = new System.Drawing.Size(190, 36);
            this.dtpStopDate.TabIndex = 5;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(15, 83);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(190, 36);
            this.dtpStartDate.TabIndex = 3;
            // 
            // ReportId
            // 
            this.ReportId.DataPropertyName = "ReportId";
            this.ReportId.HeaderText = "ReportId";
            this.ReportId.Name = "ReportId";
            this.ReportId.ReadOnly = true;
            this.ReportId.Visible = false;
            // 
            // SaleOrderNumber
            // 
            this.SaleOrderNumber.DataPropertyName = "SaleOrderNumber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SaleOrderNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.SaleOrderNumber.HeaderText = "វិក័យប័ត្រ";
            this.SaleOrderNumber.Name = "SaleOrderNumber";
            this.SaleOrderNumber.ReadOnly = true;
            // 
            // SaleOrderDate
            // 
            this.SaleOrderDate.DataPropertyName = "SaleOrderDate";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.SaleOrderDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.SaleOrderDate.HeaderText = "ថ្ងៃលក់";
            this.SaleOrderDate.Name = "SaleOrderDate";
            this.SaleOrderDate.ReadOnly = true;
            this.SaleOrderDate.Width = 110;
            // 
            // CustomerId
            // 
            this.CustomerId.DataPropertyName = "CustomerId";
            this.CustomerId.HeaderText = "CustomerId";
            this.CustomerId.Name = "CustomerId";
            this.CustomerId.ReadOnly = true;
            this.CustomerId.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "អតិថិជន";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 180;
            // 
            // CashierName
            // 
            this.CashierName.DataPropertyName = "CashierName";
            this.CashierName.HeaderText = "អ្នកលក់";
            this.CashierName.Name = "CashierName";
            this.CashierName.ReadOnly = true;
            this.CashierName.Width = 150;
            // 
            // ExchangeRate
            // 
            this.ExchangeRate.DataPropertyName = "ExchangeRate";
            this.ExchangeRate.HeaderText = "ExchangeRate";
            this.ExchangeRate.Name = "ExchangeRate";
            this.ExchangeRate.ReadOnly = true;
            this.ExchangeRate.Visible = false;
            // 
            // AmountSoldInt
            // 
            this.AmountSoldInt.DataPropertyName = "AmountSoldInt";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.AmountSoldInt.DefaultCellStyle = dataGridViewCellStyle4;
            this.AmountSoldInt.HeaderText = "សរុប($)";
            this.AmountSoldInt.Name = "AmountSoldInt";
            this.AmountSoldInt.ReadOnly = true;
            // 
            // AmountPaidInt
            // 
            this.AmountPaidInt.DataPropertyName = "AmountPaidInt";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.AmountPaidInt.DefaultCellStyle = dataGridViewCellStyle5;
            this.AmountPaidInt.HeaderText = "ទទួល($)";
            this.AmountPaidInt.Name = "AmountPaidInt";
            this.AmountPaidInt.ReadOnly = true;
            // 
            // AmountPaidRiel
            // 
            this.AmountPaidRiel.DataPropertyName = "AmountPaidRiel";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.AmountPaidRiel.DefaultCellStyle = dataGridViewCellStyle6;
            this.AmountPaidRiel.HeaderText = "ទទួល(៛)";
            this.AmountPaidRiel.Name = "AmountPaidRiel";
            this.AmountPaidRiel.ReadOnly = true;
            this.AmountPaidRiel.Visible = false;
            // 
            // AmountReturnInt
            // 
            this.AmountReturnInt.DataPropertyName = "AmountReturnInt";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.AmountReturnInt.DefaultCellStyle = dataGridViewCellStyle7;
            this.AmountReturnInt.HeaderText = "អាប់($)";
            this.AmountReturnInt.Name = "AmountReturnInt";
            this.AmountReturnInt.ReadOnly = true;
            // 
            // AmountReturnRiel
            // 
            this.AmountReturnRiel.DataPropertyName = "AmountReturnRiel";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.AmountReturnRiel.DefaultCellStyle = dataGridViewCellStyle8;
            this.AmountReturnRiel.HeaderText = "អាប់(៛)";
            this.AmountReturnRiel.Name = "AmountReturnRiel";
            this.AmountReturnRiel.ReadOnly = true;
            this.AmountReturnRiel.Visible = false;
            // 
            // DiscountTypeId
            // 
            this.DiscountTypeId.DataPropertyName = "DiscountTypeId";
            this.DiscountTypeId.HeaderText = "DiscountTypeId";
            this.DiscountTypeId.Name = "DiscountTypeId";
            this.DiscountTypeId.ReadOnly = true;
            this.DiscountTypeId.Visible = false;
            // 
            // CardNumber
            // 
            this.CardNumber.DataPropertyName = "CardNumber";
            this.CardNumber.HeaderText = "CardNumber";
            this.CardNumber.Name = "CardNumber";
            this.CardNumber.ReadOnly = true;
            this.CardNumber.Visible = false;
            // 
            // TotalDiscount
            // 
            this.TotalDiscount.DataPropertyName = "TotalDiscount";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            this.TotalDiscount.DefaultCellStyle = dataGridViewCellStyle9;
            this.TotalDiscount.HeaderText = "បញ្ចុះ";
            this.TotalDiscount.Name = "TotalDiscount";
            this.TotalDiscount.ReadOnly = true;
            this.TotalDiscount.Visible = false;
            // 
            // SaleItemId
            // 
            this.SaleItemId.DataPropertyName = "SaleItemId";
            this.SaleItemId.HeaderText = "SaleItemId";
            this.SaleItemId.Name = "SaleItemId";
            this.SaleItemId.ReadOnly = true;
            this.SaleItemId.Visible = false;
            // 
            // ProductId
            // 
            this.ProductId.DataPropertyName = "ProductId";
            this.ProductId.HeaderText = "ProductId";
            this.ProductId.Name = "ProductId";
            this.ProductId.ReadOnly = true;
            this.ProductId.Visible = false;
            // 
            // ProductNameCol
            // 
            this.ProductNameCol.DataPropertyName = "ProductName";
            this.ProductNameCol.HeaderText = "ProductName";
            this.ProductNameCol.Name = "ProductNameCol";
            this.ProductNameCol.ReadOnly = true;
            this.ProductNameCol.Visible = false;
            // 
            // UnitPriceIn
            // 
            this.UnitPriceIn.DataPropertyName = "UnitPriceIn";
            this.UnitPriceIn.HeaderText = "UnitPriceIn";
            this.UnitPriceIn.Name = "UnitPriceIn";
            this.UnitPriceIn.ReadOnly = true;
            this.UnitPriceIn.Visible = false;
            // 
            // UnitPriceOut
            // 
            this.UnitPriceOut.DataPropertyName = "UnitPriceOut";
            this.UnitPriceOut.HeaderText = "UnitPriceOut";
            this.UnitPriceOut.Name = "UnitPriceOut";
            this.UnitPriceOut.ReadOnly = true;
            this.UnitPriceOut.Visible = false;
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "Discount";
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            this.Discount.Visible = false;
            // 
            // QtySold
            // 
            this.QtySold.DataPropertyName = "QtySold";
            this.QtySold.HeaderText = "QtySold";
            this.QtySold.Name = "QtySold";
            this.QtySold.ReadOnly = true;
            this.QtySold.Visible = false;
            // 
            // SubTotal
            // 
            this.SubTotal.DataPropertyName = "SubTotal";
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            this.SubTotal.Visible = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.DataPropertyName = "ReportHeader";
            this.ReportHeader.HeaderText = "ReportHeader";
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ReadOnly = true;
            this.ReportHeader.Visible = false;
            // 
            // ReferenceNum
            // 
            this.ReferenceNum.DataPropertyName = "ReferenceNum";
            this.ReferenceNum.HeaderText = "ReferenceNum";
            this.ReferenceNum.Name = "ReferenceNum";
            this.ReferenceNum.ReadOnly = true;
            this.ReferenceNum.Visible = false;
            // 
            // ReportTypeStr
            // 
            this.ReportTypeStr.DataPropertyName = "ReportTypeStr";
            this.ReportTypeStr.HeaderText = "ReportTypeStr";
            this.ReportTypeStr.Name = "ReportTypeStr";
            this.ReportTypeStr.ReadOnly = true;
            this.ReportTypeStr.Visible = false;
            // 
            // SaleOrderId
            // 
            this.SalesOrderId.DataPropertyName = "SaleOrderId";
            this.SalesOrderId.HeaderText = "SaleOrderId";
            this.SalesOrderId.Name = "SalesOrderId";
            this.SalesOrderId.ReadOnly = true;
            this.SalesOrderId.Visible = false;
            // 
            // DepositAmount
            // 
            this.DepositAmount.DataPropertyName = "DepositAmount";
            this.DepositAmount.HeaderText = "DepositAmount";
            this.DepositAmount.Name = "DepositAmount";
            this.DepositAmount.ReadOnly = true;
            this.DepositAmount.Visible = false;
            // 
            // ProductCode
            // 
            this.ProductCode.DataPropertyName = "ProductCode";
            this.ProductCode.HeaderText = "ProductCode";
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.ReadOnly = true;
            this.ProductCode.Visible = false;
            // 
            // CategoryStr
            // 
            this.CategoryStr.DataPropertyName = "CategoryStr";
            this.CategoryStr.HeaderText = "CategoryStr";
            this.CategoryStr.Name = "CategoryStr";
            this.CategoryStr.ReadOnly = true;
            this.CategoryStr.Visible = false;
            // 
            // PurchaseUnitPrice
            // 
            this.PurchaseUnitPrice.DataPropertyName = "PurchaseUnitPrice";
            this.PurchaseUnitPrice.HeaderText = "PurchaseUnitPrice";
            this.PurchaseUnitPrice.Name = "PurchaseUnitPrice";
            this.PurchaseUnitPrice.ReadOnly = true;
            this.PurchaseUnitPrice.Visible = false;
            // 
            // FrmSaleSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(694, 555);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSaleSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   .: Sale :.";
            this.Load += new System.EventHandler(this.FrmSaleOrderSearch_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSaleOrderSearch_FormClosing);
            this.pnlHeader.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResult)).EndInit();
            this.grbProductInfo.ResumeLayout(false);
            this.grbProductInfo.PerformLayout();
            this.grbCustomerInfo.ResumeLayout(false);
            this.grbCustomerInfo.PerformLayout();
            this.grbSaleInfo.ResumeLayout(false);
            this.grbSaleInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.GroupBox grbSaleInfo;
        private System.Windows.Forms.DateTimePicker dtpStopDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.GroupBox grbCustomerInfo;
        private ExtendedComboBox cmbDiscountType;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private ExtendedComboBox cmbCustomer;
        private System.Windows.Forms.GroupBox grbProductInfo;
        private ExtendedComboBox cmbBrand;
        private System.Windows.Forms.TextBox txtProductCode;
        private ExtendedComboBox cmbCategory;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.Label lblStopDate;
        private System.Windows.Forms.Label lblDiscountType;
        private System.Windows.Forms.Label lblCardNumber;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblCustomerName;
        private ExtendedComboBox cmbColor;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblCategory;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.DataGridView dgvSearchResult;
        private System.Windows.Forms.Label lblSearchInfo;
        private System.Windows.Forms.RadioButton rbtDeposit;
        private System.Windows.Forms.RadioButton rbtSale;
        private System.Windows.Forms.Button btnDeleteDeposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExchangeRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountSoldInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountPaidInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountPaidRiel;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountReturnInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountReturnRiel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPriceIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPriceOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtySold;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportTypeStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepositAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseUnitPrice;

    }
}