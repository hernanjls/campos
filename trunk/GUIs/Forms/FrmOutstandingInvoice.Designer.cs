
namespace EzPos.GUIs.Forms
{
    partial class FrmOutstandingInvoice
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgvInvoiceOutstanding = new System.Windows.Forms.DataGridView();
            this.ReportID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExchangeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountSoldInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountPaidInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountPaidRiel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountReturnInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountReturnRiel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPriceIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPriceOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtySold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportTypeStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsOutstandingInvoice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmPaymentOutStanding = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSearchInfo = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceOutstanding)).BeginInit();
            this.cmsOutstandingInvoice.SuspendLayout();
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
            this.lblProductName.TabIndex = 1;
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
            this.pnlHeader.TabIndex = 106;
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
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btnCancel_MouseEnter);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackgroundImage = global::EzPos.Properties.Resources.background_5;
            this.pnlFooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFooter.Controls.Add(this.btnPrint);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 523);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(694, 48);
            this.pnlFooter.TabIndex = 107;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Image = global::EzPos.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(443, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(116, 36);
            this.btnPrint.TabIndex = 48;
            this.btnPrint.Text = "បោះពុម្ភ";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBody.Controls.Add(this.dgvInvoiceOutstanding);
            this.pnlBody.Controls.Add(this.lblSearchInfo);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBody.Location = new System.Drawing.Point(0, 89);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(694, 434);
            this.pnlBody.TabIndex = 105;
            // 
            // dgvInvoiceOutstanding
            // 
            this.dgvInvoiceOutstanding.AllowUserToAddRows = false;
            this.dgvInvoiceOutstanding.AllowUserToDeleteRows = false;
            this.dgvInvoiceOutstanding.AllowUserToResizeColumns = false;
            this.dgvInvoiceOutstanding.AllowUserToResizeRows = false;
            this.dgvInvoiceOutstanding.BackgroundColor = System.Drawing.Color.White;
            this.dgvInvoiceOutstanding.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvInvoiceOutstanding.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceOutstanding.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvoiceOutstanding.ColumnHeadersHeight = 40;
            this.dgvInvoiceOutstanding.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInvoiceOutstanding.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReportID,
            this.SaleOrderNumber,
            this.SaleOrderDate,
            this.CustomerID,
            this.CustomerName,
            this.CashierName,
            this.ExchangeRate,
            this.AmountSoldInt,
            this.AmountPaidInt,
            this.AmountPaidRiel,
            this.AmountReturnInt,
            this.AmountReturnRiel,
            this.DiscountTypeID,
            this.CardNumber,
            this.TotalDiscount,
            this.SaleItemID,
            this.ProductID,
            this.ProductNameCol,
            this.UnitPriceIn,
            this.UnitPriceOut,
            this.Discount,
            this.QtySold,
            this.SubTotal,
            this.ReportHeader,
            this.ReferenceNum,
            this.ReportTypeStr});
            this.dgvInvoiceOutstanding.EnableHeadersVisualStyles = false;
            this.dgvInvoiceOutstanding.GridColor = System.Drawing.Color.White;
            this.dgvInvoiceOutstanding.Location = new System.Drawing.Point(19, 48);
            this.dgvInvoiceOutstanding.MultiSelect = false;
            this.dgvInvoiceOutstanding.Name = "dgvInvoiceOutstanding";
            this.dgvInvoiceOutstanding.ReadOnly = true;
            this.dgvInvoiceOutstanding.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInvoiceOutstanding.RowHeadersVisible = false;
            this.dgvInvoiceOutstanding.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvInvoiceOutstanding.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Candara", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvInvoiceOutstanding.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.dgvInvoiceOutstanding.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dgvInvoiceOutstanding.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvInvoiceOutstanding.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Maroon;
            this.dgvInvoiceOutstanding.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceOutstanding.RowTemplate.Height = 50;
            this.dgvInvoiceOutstanding.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoiceOutstanding.Size = new System.Drawing.Size(657, 359);
            this.dgvInvoiceOutstanding.TabIndex = 3;
            this.dgvInvoiceOutstanding.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchResult_CellDoubleClick);
            this.dgvInvoiceOutstanding.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvSearchResult_MouseClick);
            // 
            // ReportID
            // 
            this.ReportID.DataPropertyName = "ReportID";
            this.ReportID.HeaderText = "ReportID";
            this.ReportID.Name = "ReportID";
            this.ReportID.ReadOnly = true;
            this.ReportID.Visible = false;
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
            this.SaleOrderDate.Width = 115;
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "CustomerID";
            this.CustomerID.HeaderText = "CustomerID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            this.CustomerID.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "អតិថិជន";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Visible = false;
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
            this.AmountReturnInt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
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
            // DiscountTypeID
            // 
            this.DiscountTypeID.DataPropertyName = "DiscountTypeID";
            this.DiscountTypeID.HeaderText = "DiscountTypeID";
            this.DiscountTypeID.Name = "DiscountTypeID";
            this.DiscountTypeID.ReadOnly = true;
            this.DiscountTypeID.Visible = false;
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
            // SaleItemID
            // 
            this.SaleItemID.DataPropertyName = "SaleItemID";
            this.SaleItemID.HeaderText = "SaleItemID";
            this.SaleItemID.Name = "SaleItemID";
            this.SaleItemID.ReadOnly = true;
            this.SaleItemID.Visible = false;
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Visible = false;
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
            // cmsOutstandingInvoice
            // 
            this.cmsOutstandingInvoice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPaymentOutStanding});
            this.cmsOutstandingInvoice.Name = "cmsCatalog";
            this.cmsOutstandingInvoice.ShowItemToolTips = false;
            this.cmsOutstandingInvoice.Size = new System.Drawing.Size(162, 34);
            // 
            // tsmPaymentOutStanding
            // 
            this.tsmPaymentOutStanding.Font = new System.Drawing.Font("Khmer OS System", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmPaymentOutStanding.Name = "tsmPaymentOutStanding";
            this.tsmPaymentOutStanding.Size = new System.Drawing.Size(161, 30);
            this.tsmPaymentOutStanding.Text = "ប្រគលប្រាក​";
            this.tsmPaymentOutStanding.Click += new System.EventHandler(this.tsmIndividual_Click);
            // 
            // lblSearchInfo
            // 
            this.lblSearchInfo.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchInfo.Location = new System.Drawing.Point(14, 13);
            this.lblSearchInfo.Name = "lblSearchInfo";
            this.lblSearchInfo.Size = new System.Drawing.Size(668, 29);
            this.lblSearchInfo.TabIndex = 4;
            // 
            // FrmOutstandingInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 571);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmOutstandingInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   .: Sale :.";
            this.Load += new System.EventHandler(this.FrmSaleOrderSearch_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceOutstanding)).EndInit();
            this.cmsOutstandingInvoice.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlBody;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.DataGridView dgvInvoiceOutstanding;
        private System.Windows.Forms.Label lblSearchInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExchangeRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountSoldInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountPaidInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountPaidRiel;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountReturnInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountReturnRiel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPriceIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPriceOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtySold;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportTypeStr;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ContextMenuStrip cmsOutstandingInvoice;
        private System.Windows.Forms.ToolStripMenuItem tsmPaymentOutStanding;

    }
}