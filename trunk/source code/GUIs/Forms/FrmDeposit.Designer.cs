
namespace EzPos.GUIs.Forms
{
    partial class FrmDeposit
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
            this.btnDeliver = new System.Windows.Forms.Button();
            this.btnCancelDeposit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgvDeposit = new System.Windows.Forms.DataGridView();
            this.lblSearchInfo = new System.Windows.Forms.Label();
            this.DepositId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepositNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepositDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExchangeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountSoldInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountPaidInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountPaidRiel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountReturnInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountReturnRiel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepositTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FKCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FKCashier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelivererId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountSoldRiel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeposit)).BeginInit();
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
            this.btnCancel.MouseLeave += new System.EventHandler(this.BtnCancelMouseLeave);
            this.btnCancel.MouseEnter += new System.EventHandler(this.BtnCancelMouseEnter);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackgroundImage = global::EzPos.Properties.Resources.background_5;
            this.pnlFooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFooter.Controls.Add(this.btnDeliver);
            this.pnlFooter.Controls.Add(this.btnCancelDeposit);
            this.pnlFooter.Controls.Add(this.btnPrint);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 523);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(694, 48);
            this.pnlFooter.TabIndex = 107;
            // 
            // btnDeliver
            // 
            this.btnDeliver.BackColor = System.Drawing.Color.Transparent;
            this.btnDeliver.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnDeliver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeliver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeliver.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeliver.ForeColor = System.Drawing.Color.White;
            this.btnDeliver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeliver.Location = new System.Drawing.Point(137, 9);
            this.btnDeliver.Name = "btnDeliver";
            this.btnDeliver.Size = new System.Drawing.Size(116, 36);
            this.btnDeliver.TabIndex = 50;
            this.btnDeliver.Text = "ប្រគល់";
            this.btnDeliver.UseVisualStyleBackColor = false;
            this.btnDeliver.MouseLeave += new System.EventHandler(this.BtnDeliverMouseLeave);
            this.btnDeliver.Click += new System.EventHandler(this.BtnDeliverClick);
            this.btnDeliver.MouseEnter += new System.EventHandler(this.BtnDeliverMouseEnter);
            // 
            // btnCancelDeposit
            // 
            this.btnCancelDeposit.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelDeposit.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnCancelDeposit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelDeposit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelDeposit.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelDeposit.ForeColor = System.Drawing.Color.White;
            this.btnCancelDeposit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelDeposit.Location = new System.Drawing.Point(20, 9);
            this.btnCancelDeposit.Name = "btnCancelDeposit";
            this.btnCancelDeposit.Size = new System.Drawing.Size(116, 36);
            this.btnCancelDeposit.TabIndex = 49;
            this.btnCancelDeposit.Text = "បោះបង់";
            this.btnCancelDeposit.UseVisualStyleBackColor = false;
            this.btnCancelDeposit.MouseLeave += new System.EventHandler(this.BtnDetailDepositMouseLeave);
            this.btnCancelDeposit.Click += new System.EventHandler(this.BtnCancelDepositClick);
            this.btnCancelDeposit.MouseEnter += new System.EventHandler(this.BtnDetailDepositMouseEnter);
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
            this.btnPrint.Location = new System.Drawing.Point(254, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(116, 36);
            this.btnPrint.TabIndex = 48;
            this.btnPrint.Text = "បោះពុម្ភ";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.MouseLeave += new System.EventHandler(this.BtnPrintMouseLeave);
            this.btnPrint.Click += new System.EventHandler(this.BtnPrintClick);
            this.btnPrint.MouseEnter += new System.EventHandler(this.BtnPrintMouseEnter);
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody.Controls.Add(this.dgvDeposit);
            this.pnlBody.Controls.Add(this.lblSearchInfo);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBody.Location = new System.Drawing.Point(0, 89);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(694, 434);
            this.pnlBody.TabIndex = 105;
            // 
            // dgvDeposit
            // 
            this.dgvDeposit.AllowUserToAddRows = false;
            this.dgvDeposit.AllowUserToDeleteRows = false;
            this.dgvDeposit.AllowUserToResizeColumns = false;
            this.dgvDeposit.AllowUserToResizeRows = false;
            this.dgvDeposit.BackgroundColor = System.Drawing.Color.White;
            this.dgvDeposit.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDeposit.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeposit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDeposit.ColumnHeadersHeight = 40;
            this.dgvDeposit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDeposit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DepositId,
            this.DepositNumber,
            this.DepositDate,
            this.CashierName,
            this.ExchangeRate,
            this.AmountSoldInt,
            this.AmountPaidInt,
            this.AmountPaidRiel,
            this.AmountReturnInt,
            this.AmountReturnRiel,
            this.DepositTypeId,
            this.CardNumber,
            this.FKCustomer,
            this.Discount,
            this.FKCashier,
            this.CashierId,
            this.DelivererId,
            this.Description,
            this.PaymentTypeId,
            this.CurrencyId,
            this.AmountSoldRiel,
            this.DiscountTypeId,
            this.ReferenceNum,
            this.UpdateDate,
            this.CustomerName,
            this.ColCustomerId});
            this.dgvDeposit.EnableHeadersVisualStyles = false;
            this.dgvDeposit.GridColor = System.Drawing.Color.White;
            this.dgvDeposit.Location = new System.Drawing.Point(19, 48);
            this.dgvDeposit.MultiSelect = false;
            this.dgvDeposit.Name = "dgvDeposit";
            this.dgvDeposit.ReadOnly = true;
            this.dgvDeposit.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDeposit.RowHeadersVisible = false;
            this.dgvDeposit.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDeposit.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Candara", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDeposit.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.dgvDeposit.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dgvDeposit.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvDeposit.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Maroon;
            this.dgvDeposit.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeposit.RowTemplate.Height = 50;
            this.dgvDeposit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeposit.Size = new System.Drawing.Size(657, 359);
            this.dgvDeposit.TabIndex = 3;
            this.dgvDeposit.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSearchResultCellDoubleClick);
            // 
            // lblSearchInfo
            // 
            this.lblSearchInfo.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchInfo.Location = new System.Drawing.Point(14, 13);
            this.lblSearchInfo.Name = "lblSearchInfo";
            this.lblSearchInfo.Size = new System.Drawing.Size(668, 29);
            this.lblSearchInfo.TabIndex = 4;
            // 
            // DepositId
            // 
            this.DepositId.DataPropertyName = "DepositId";
            this.DepositId.HeaderText = "DepositId";
            this.DepositId.Name = "DepositId";
            this.DepositId.ReadOnly = true;
            this.DepositId.Visible = false;
            // 
            // DepositNumber
            // 
            this.DepositNumber.DataPropertyName = "DepositNumber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DepositNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.DepositNumber.HeaderText = "លេខកក់";
            this.DepositNumber.Name = "DepositNumber";
            this.DepositNumber.ReadOnly = true;
            // 
            // DepositDate
            // 
            this.DepositDate.DataPropertyName = "DepositDate";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.DepositDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.DepositDate.HeaderText = "ថ្ងៃកក់";
            this.DepositDate.Name = "DepositDate";
            this.DepositDate.ReadOnly = true;
            this.DepositDate.Width = 115;
            // 
            // CashierName
            // 
            this.CashierName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CashierName.DataPropertyName = "CashierName";
            this.CashierName.HeaderText = "អ្នកលក់";
            this.CashierName.Name = "CashierName";
            this.CashierName.ReadOnly = true;
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
            this.AmountPaidInt.HeaderText = "កក់($)";
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
            this.AmountReturnInt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AmountReturnInt.DataPropertyName = "AmountReturnInt";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.AmountReturnInt.DefaultCellStyle = dataGridViewCellStyle7;
            this.AmountReturnInt.HeaderText = "ខ្វះ($)";
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
            // DepositTypeId
            // 
            this.DepositTypeId.DataPropertyName = "DepositTypeId";
            this.DepositTypeId.HeaderText = "DiscountTypeId";
            this.DepositTypeId.Name = "DepositTypeId";
            this.DepositTypeId.ReadOnly = true;
            this.DepositTypeId.Visible = false;
            // 
            // CardNumber
            // 
            this.CardNumber.DataPropertyName = "CardNumber";
            this.CardNumber.HeaderText = "CardNumber";
            this.CardNumber.Name = "CardNumber";
            this.CardNumber.ReadOnly = true;
            this.CardNumber.Visible = false;
            // 
            // FKCustomer
            // 
            this.FKCustomer.DataPropertyName = "FkCustomer";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            this.FKCustomer.DefaultCellStyle = dataGridViewCellStyle9;
            this.FKCustomer.HeaderText = "បញ្ចុះ";
            this.FKCustomer.Name = "FKCustomer";
            this.FKCustomer.ReadOnly = true;
            this.FKCustomer.Visible = false;
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "Discount";
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            this.Discount.Visible = false;
            // 
            // FKCashier
            // 
            this.FKCashier.DataPropertyName = "FkCashier";
            this.FKCashier.HeaderText = "FKCashier";
            this.FKCashier.Name = "FKCashier";
            this.FKCashier.ReadOnly = true;
            this.FKCashier.Visible = false;
            // 
            // CashierId
            // 
            this.CashierId.DataPropertyName = "CashierId";
            this.CashierId.HeaderText = "CashierId";
            this.CashierId.Name = "CashierId";
            this.CashierId.ReadOnly = true;
            this.CashierId.Visible = false;
            // 
            // DelivererId
            // 
            this.DelivererId.DataPropertyName = "DelivererId";
            this.DelivererId.HeaderText = "DelivererId";
            this.DelivererId.Name = "DelivererId";
            this.DelivererId.ReadOnly = true;
            this.DelivererId.Visible = false;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Visible = false;
            // 
            // PaymentTypeId
            // 
            this.PaymentTypeId.DataPropertyName = "PaymentTypeId";
            this.PaymentTypeId.HeaderText = "PaymentTypeId";
            this.PaymentTypeId.Name = "PaymentTypeId";
            this.PaymentTypeId.ReadOnly = true;
            this.PaymentTypeId.Visible = false;
            // 
            // CurrencyId
            // 
            this.CurrencyId.DataPropertyName = "CurrencyId";
            this.CurrencyId.HeaderText = "CurrencyId";
            this.CurrencyId.Name = "CurrencyId";
            this.CurrencyId.ReadOnly = true;
            this.CurrencyId.Visible = false;
            // 
            // AmountSoldRiel
            // 
            this.AmountSoldRiel.DataPropertyName = "AmountSoldRiel";
            this.AmountSoldRiel.HeaderText = "AmountSoldRiel";
            this.AmountSoldRiel.Name = "AmountSoldRiel";
            this.AmountSoldRiel.ReadOnly = true;
            this.AmountSoldRiel.Visible = false;
            // 
            // DiscountTypeId
            // 
            this.DiscountTypeId.DataPropertyName = "DiscountTypeId";
            this.DiscountTypeId.HeaderText = "DiscountTypeId";
            this.DiscountTypeId.Name = "DiscountTypeId";
            this.DiscountTypeId.ReadOnly = true;
            this.DiscountTypeId.Visible = false;
            // 
            // ReferenceNum
            // 
            this.ReferenceNum.DataPropertyName = "ReferenceNum";
            this.ReferenceNum.HeaderText = "ReferenceNum";
            this.ReferenceNum.Name = "ReferenceNum";
            this.ReferenceNum.ReadOnly = true;
            this.ReferenceNum.Visible = false;
            // 
            // UpdateDate
            // 
            this.UpdateDate.DataPropertyName = "UpdateDate";
            this.UpdateDate.HeaderText = "UpdateDate";
            this.UpdateDate.Name = "UpdateDate";
            this.UpdateDate.ReadOnly = true;
            this.UpdateDate.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Visible = false;
            // 
            // ColCustomerId
            // 
            this.ColCustomerId.DataPropertyName = "CustomerId";
            this.ColCustomerId.HeaderText = "CustomerId";
            this.ColCustomerId.Name = "ColCustomerId";
            this.ColCustomerId.ReadOnly = true;
            this.ColCustomerId.Visible = false;
            // 
            // FrmDeposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(694, 571);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDeposit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   .: Sale :.";
            this.Load += new System.EventHandler(this.FrmDeposit_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeposit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlBody;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.DataGridView dgvDeposit;
        private System.Windows.Forms.Label lblSearchInfo;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancelDeposit;
        private System.Windows.Forms.Button btnDeliver;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepositId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepositNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepositDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExchangeRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountSoldInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountPaidInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountPaidRiel;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountReturnInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountReturnRiel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepositTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn FKCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn FKCashier;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashierId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelivererId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountSoldRiel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerId;

    }
}