
namespace EzPos.GUIs.Forms
{
    partial class FrmOutstandingPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblSalesOrderInfo = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblPaymentInfo = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnPaymentDetail = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlPaymentInfo = new System.Windows.Forms.Panel();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblPaymentAmount = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.lblCashier = new System.Windows.Forms.Label();
            this.txtPaymentAmount = new System.Windows.Forms.TextBox();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.txtPaymentDate = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPaymentOutstanding = new System.Windows.Forms.DataGridView();
            this.PaymentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FKSaleOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FKCashier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSearchInfo = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlPaymentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentOutstanding)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSalesOrderInfo
            // 
            this.lblSalesOrderInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblSalesOrderInfo.Font = new System.Drawing.Font("Khmer OS System", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesOrderInfo.ForeColor = System.Drawing.Color.Yellow;
            this.lblSalesOrderInfo.Location = new System.Drawing.Point(13, 0);
            this.lblSalesOrderInfo.Name = "lblSalesOrderInfo";
            this.lblSalesOrderInfo.Size = new System.Drawing.Size(284, 89);
            this.lblSalesOrderInfo.TabIndex = 1;
            this.lblSalesOrderInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackgroundImage = global::EzPos.Properties.Resources.backgroud_11;
            this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHeader.Controls.Add(this.lblPaymentInfo);
            this.pnlHeader.Controls.Add(this.lblSalesOrderInfo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(694, 89);
            this.pnlHeader.TabIndex = 106;
            // 
            // lblPaymentInfo
            // 
            this.lblPaymentInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPaymentInfo.Font = new System.Drawing.Font("Khmer OS System", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentInfo.ForeColor = System.Drawing.Color.Yellow;
            this.lblPaymentInfo.Location = new System.Drawing.Point(431, 0);
            this.lblPaymentInfo.Name = "lblPaymentInfo";
            this.lblPaymentInfo.Size = new System.Drawing.Size(252, 89);
            this.lblPaymentInfo.TabIndex = 2;
            this.lblPaymentInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackgroundImage = global::EzPos.Properties.Resources.background_5;
            this.pnlFooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFooter.Controls.Add(this.btnPaymentDetail);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 418);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(694, 48);
            this.pnlFooter.TabIndex = 107;
            // 
            // btnPaymentDetail
            // 
            this.btnPaymentDetail.BackColor = System.Drawing.Color.Transparent;
            this.btnPaymentDetail.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnPaymentDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPaymentDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPaymentDetail.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaymentDetail.ForeColor = System.Drawing.Color.White;
            this.btnPaymentDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaymentDetail.Location = new System.Drawing.Point(19, 9);
            this.btnPaymentDetail.Name = "btnPaymentDetail";
            this.btnPaymentDetail.Size = new System.Drawing.Size(116, 36);
            this.btnPaymentDetail.TabIndex = 49;
            this.btnPaymentDetail.Text = "លំអិត";
            this.btnPaymentDetail.UseVisualStyleBackColor = false;
            this.btnPaymentDetail.MouseLeave += new System.EventHandler(this.btnPaymentDetail_MouseLeave);
            this.btnPaymentDetail.Click += new System.EventHandler(this.btnPaymentDetail_Click);
            this.btnPaymentDetail.MouseEnter += new System.EventHandler(this.btnPaymentDetail_MouseEnter);
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
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Text = "បោះបង់";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btnCancel_MouseEnter);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::EzPos.Properties.Resources.OK32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(443, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 36);
            this.btnSave.TabIndex = 44;
            this.btnSave.Text = "យល់ព្រម";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.btnSave_MouseEnter);
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBody.Controls.Add(this.pnlPaymentInfo);
            this.pnlBody.Controls.Add(this.dgvPaymentOutstanding);
            this.pnlBody.Controls.Add(this.lblSearchInfo);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBody.Location = new System.Drawing.Point(0, 89);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(694, 329);
            this.pnlBody.TabIndex = 105;
            // 
            // pnlPaymentInfo
            // 
            this.pnlPaymentInfo.Controls.Add(this.lblRemark);
            this.pnlPaymentInfo.Controls.Add(this.txtRemark);
            this.pnlPaymentInfo.Controls.Add(this.lblPaymentAmount);
            this.pnlPaymentInfo.Controls.Add(this.cmbUser);
            this.pnlPaymentInfo.Controls.Add(this.lblCashier);
            this.pnlPaymentInfo.Controls.Add(this.txtPaymentAmount);
            this.pnlPaymentInfo.Controls.Add(this.lblPaymentDate);
            this.pnlPaymentInfo.Controls.Add(this.txtPaymentDate);
            this.pnlPaymentInfo.Controls.Add(this.groupBox2);
            this.pnlPaymentInfo.Location = new System.Drawing.Point(19, 48);
            this.pnlPaymentInfo.Name = "pnlPaymentInfo";
            this.pnlPaymentInfo.Size = new System.Drawing.Size(657, 265);
            this.pnlPaymentInfo.TabIndex = 0;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblRemark.Location = new System.Drawing.Point(347, 31);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(66, 29);
            this.lblRemark.TabIndex = 7;
            this.lblRemark.Text = "ផេ្សងៗ";
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.SystemColors.Window;
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(352, 73);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(305, 171);
            this.txtRemark.TabIndex = 8;
            // 
            // lblPaymentAmount
            // 
            this.lblPaymentAmount.AutoSize = true;
            this.lblPaymentAmount.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblPaymentAmount.Location = new System.Drawing.Point(3, 123);
            this.lblPaymentAmount.Name = "lblPaymentAmount";
            this.lblPaymentAmount.Size = new System.Drawing.Size(78, 29);
            this.lblPaymentAmount.TabIndex = 4;
            this.lblPaymentAmount.Text = "ទឺកប្រាក់";
            // 
            // cmbUser
            // 
            this.cmbUser.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(93, 73);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(220, 36);
            this.cmbUser.TabIndex = 3;
            // 
            // lblCashier
            // 
            this.lblCashier.AutoSize = true;
            this.lblCashier.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblCashier.Location = new System.Drawing.Point(3, 78);
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.Size = new System.Drawing.Size(84, 29);
            this.lblCashier.TabIndex = 2;
            this.lblCashier.Text = "អ្នកទទួល";
            // 
            // txtPaymentAmount
            // 
            this.txtPaymentAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtPaymentAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaymentAmount.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentAmount.Location = new System.Drawing.Point(93, 119);
            this.txtPaymentAmount.Name = "txtPaymentAmount";
            this.txtPaymentAmount.Size = new System.Drawing.Size(220, 36);
            this.txtPaymentAmount.TabIndex = 5;
            this.txtPaymentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.AutoSize = true;
            this.lblPaymentDate.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblPaymentDate.Location = new System.Drawing.Point(3, 31);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(78, 29);
            this.lblPaymentDate.TabIndex = 0;
            this.lblPaymentDate.Text = "ថ្ងៃទទួល";
            // 
            // txtPaymentDate
            // 
            this.txtPaymentDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtPaymentDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaymentDate.Enabled = false;
            this.txtPaymentDate.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentDate.Location = new System.Drawing.Point(93, 27);
            this.txtPaymentDate.Name = "txtPaymentDate";
            this.txtPaymentDate.ReadOnly = true;
            this.txtPaymentDate.Size = new System.Drawing.Size(220, 36);
            this.txtPaymentDate.TabIndex = 1;
            this.txtPaymentDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox2.Location = new System.Drawing.Point(327, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(2, 217);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // dgvPaymentOutstanding
            // 
            this.dgvPaymentOutstanding.AllowUserToAddRows = false;
            this.dgvPaymentOutstanding.AllowUserToDeleteRows = false;
            this.dgvPaymentOutstanding.AllowUserToResizeColumns = false;
            this.dgvPaymentOutstanding.AllowUserToResizeRows = false;
            this.dgvPaymentOutstanding.BackgroundColor = System.Drawing.Color.White;
            this.dgvPaymentOutstanding.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPaymentOutstanding.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentOutstanding.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvPaymentOutstanding.ColumnHeadersHeight = 40;
            this.dgvPaymentOutstanding.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPaymentOutstanding.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PaymentId,
            this.PaymentDate,
            this.CashierName,
            this.PaymentAmount,
            this.SalesOrderId,
            this.Remark,
            this.CashierId,
            this.FKSaleOrder,
            this.FKCashier});
            this.dgvPaymentOutstanding.EnableHeadersVisualStyles = false;
            this.dgvPaymentOutstanding.GridColor = System.Drawing.Color.White;
            this.dgvPaymentOutstanding.Location = new System.Drawing.Point(19, 48);
            this.dgvPaymentOutstanding.MultiSelect = false;
            this.dgvPaymentOutstanding.Name = "dgvPaymentOutstanding";
            this.dgvPaymentOutstanding.ReadOnly = true;
            this.dgvPaymentOutstanding.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPaymentOutstanding.RowHeadersVisible = false;
            this.dgvPaymentOutstanding.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPaymentOutstanding.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Candara", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPaymentOutstanding.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.dgvPaymentOutstanding.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dgvPaymentOutstanding.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvPaymentOutstanding.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Maroon;
            this.dgvPaymentOutstanding.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentOutstanding.RowTemplate.Height = 50;
            this.dgvPaymentOutstanding.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaymentOutstanding.Size = new System.Drawing.Size(657, 265);
            this.dgvPaymentOutstanding.TabIndex = 6;
            // 
            // PaymentId
            // 
            this.PaymentId.DataPropertyName = "PaymentId";
            this.PaymentId.HeaderText = "PaymentId";
            this.PaymentId.Name = "PaymentId";
            this.PaymentId.ReadOnly = true;
            this.PaymentId.Visible = false;
            // 
            // PaymentDate
            // 
            this.PaymentDate.DataPropertyName = "PaymentDate";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Format = "dd/MM/yyyy";
            this.PaymentDate.DefaultCellStyle = dataGridViewCellStyle14;
            this.PaymentDate.HeaderText = "ថ្ងៃទទួល";
            this.PaymentDate.Name = "PaymentDate";
            this.PaymentDate.ReadOnly = true;
            this.PaymentDate.Width = 120;
            // 
            // CashierName
            // 
            this.CashierName.DataPropertyName = "CashierName";
            this.CashierName.HeaderText = "អ្នកលក់";
            this.CashierName.Name = "CashierName";
            this.CashierName.ReadOnly = true;
            this.CashierName.Width = 200;
            // 
            // PaymentAmount
            // 
            this.PaymentAmount.DataPropertyName = "PaymentAmount";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N2";
            this.PaymentAmount.DefaultCellStyle = dataGridViewCellStyle15;
            this.PaymentAmount.HeaderText = "ទទួលបាន";
            this.PaymentAmount.Name = "PaymentAmount";
            this.PaymentAmount.ReadOnly = true;
            this.PaymentAmount.Width = 120;
            // 
            // SalesOrderId
            // 
            this.SalesOrderId.DataPropertyName = "SalesOrderId";
            this.SalesOrderId.HeaderText = "SalesOrderId";
            this.SalesOrderId.Name = "SalesOrderId";
            this.SalesOrderId.ReadOnly = true;
            this.SalesOrderId.Visible = false;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.DataPropertyName = "Remark";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N2";
            dataGridViewCellStyle16.NullValue = null;
            this.Remark.DefaultCellStyle = dataGridViewCellStyle16;
            this.Remark.HeaderText = "ផេ្សងៗ";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // CashierId
            // 
            this.CashierId.DataPropertyName = "CashierId";
            this.CashierId.HeaderText = "CashierId";
            this.CashierId.Name = "CashierId";
            this.CashierId.ReadOnly = true;
            this.CashierId.Visible = false;
            // 
            // FKSaleOrder
            // 
            this.FKSaleOrder.DataPropertyName = "FKSaleOrder";
            this.FKSaleOrder.HeaderText = "FKSaleOrder";
            this.FKSaleOrder.Name = "FKSaleOrder";
            this.FKSaleOrder.ReadOnly = true;
            this.FKSaleOrder.Visible = false;
            // 
            // FKCashier
            // 
            this.FKCashier.DataPropertyName = "FKCashier";
            this.FKCashier.HeaderText = "FKCashier";
            this.FKCashier.Name = "FKCashier";
            this.FKCashier.ReadOnly = true;
            this.FKCashier.Visible = false;
            // 
            // lblSearchInfo
            // 
            this.lblSearchInfo.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchInfo.Location = new System.Drawing.Point(14, 14);
            this.lblSearchInfo.Name = "lblSearchInfo";
            this.lblSearchInfo.Size = new System.Drawing.Size(668, 29);
            this.lblSearchInfo.TabIndex = 5;
            // 
            // FrmOutstandingPayment
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(694, 466);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmOutstandingPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   .: Sale :.";
            this.Load += new System.EventHandler(this.FrmSaleOrderSearch_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlPaymentInfo.ResumeLayout(false);
            this.pnlPaymentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentOutstanding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSalesOrderInfo;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlBody;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPaymentInfo;
        private System.Windows.Forms.Label lblSearchInfo;
        private System.Windows.Forms.DataGridView dgvPaymentOutstanding;
        private System.Windows.Forms.Button btnPaymentDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentAmont;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashierId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FKSaleOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn FKCashier;
        private System.Windows.Forms.Panel pnlPaymentInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.TextBox txtPaymentDate;
        private System.Windows.Forms.Label lblCashier;
        private System.Windows.Forms.TextBox txtPaymentAmount;
        private System.Windows.Forms.Label lblPaymentAmount;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtRemark;

    }
}