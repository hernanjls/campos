using ExtendedComboBox=EzPos.GUIs.Components.ExtendedComboBox;

namespace EzPos.GUIs.Controls
{
    partial class CtrlDiscountCard
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
            this.pnlBodyLeft = new System.Windows.Forms.Panel();
            this.dgvDiscountCard = new System.Windows.Forms.DataGridView();
            this.pnlBodyRight = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReturnCard = new System.Windows.Forms.Button();
            this.cmbCustomerHidden = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.lblPrintCard = new System.Windows.Forms.Label();
            this.grbPrintCard = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.rdbPrintSelected = new System.Windows.Forms.RadioButton();
            this.rdbPrintAll = new System.Windows.Forms.RadioButton();
            this.lblDelCard = new System.Windows.Forms.Label();
            this.grbDeleteCard = new System.Windows.Forms.GroupBox();
            this.lblCardSelect = new System.Windows.Forms.Label();
            this.lblNewCard = new System.Windows.Forms.Label();
            this.grbNewCard = new System.Windows.Forms.GroupBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtNumCard = new System.Windows.Forms.TextBox();
            this.cmbDiscountType = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.lblNumCard = new System.Windows.Forms.Label();
            this.lblCardType = new System.Windows.Forms.Label();
            this.pnlBodySearch = new System.Windows.Forms.Panel();
            this.lblResultInfo = new System.Windows.Forms.Label();
            this.chbNonUsed = new System.Windows.Forms.CheckBox();
            this.chbUsed = new System.Windows.Forms.CheckBox();
            this.lblCardNum = new System.Windows.Forms.Label();
            this.txtCardNum = new System.Windows.Forms.TextBox();
            this.cmbCustomer = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbDCardType = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.lblDCountType = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.PrintCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountCardTypeStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountCardTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountCardID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FKCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllowDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBodyLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscountCard)).BeginInit();
            this.pnlBodyRight.SuspendLayout();
            this.grbPrintCard.SuspendLayout();
            this.grbDeleteCard.SuspendLayout();
            this.grbNewCard.SuspendLayout();
            this.pnlBodySearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBodyLeft
            // 
            this.pnlBodyLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBodyLeft.Controls.Add(this.dgvDiscountCard);
            this.pnlBodyLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBodyLeft.Location = new System.Drawing.Point(0, 120);
            this.pnlBodyLeft.Name = "pnlBodyLeft";
            this.pnlBodyLeft.Size = new System.Drawing.Size(826, 475);
            this.pnlBodyLeft.TabIndex = 1;
            // 
            // dgvDiscountCard
            // 
            this.dgvDiscountCard.AllowUserToAddRows = false;
            this.dgvDiscountCard.AllowUserToDeleteRows = false;
            this.dgvDiscountCard.AllowUserToResizeColumns = false;
            this.dgvDiscountCard.AllowUserToResizeRows = false;
            this.dgvDiscountCard.BackgroundColor = System.Drawing.Color.White;
            this.dgvDiscountCard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDiscountCard.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDiscountCard.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiscountCard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDiscountCard.ColumnHeadersHeight = 40;
            this.dgvDiscountCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDiscountCard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PrintCheck,
            this.CardNumber,
            this.DiscountCardTypeStr,
            this.DiscountCardTypeID,
            this.DiscountPercentage,
            this.CustomerID,
            this.CustomerStr,
            this.DiscountCardID,
            this.ExpireDate,
            this.FKCustomer,
            this.AllowDiscount});
            this.dgvDiscountCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiscountCard.EnableHeadersVisualStyles = false;
            this.dgvDiscountCard.GridColor = System.Drawing.Color.White;
            this.dgvDiscountCard.Location = new System.Drawing.Point(0, 0);
            this.dgvDiscountCard.MultiSelect = false;
            this.dgvDiscountCard.Name = "dgvDiscountCard";
            this.dgvDiscountCard.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDiscountCard.RowHeadersVisible = false;
            this.dgvDiscountCard.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDiscountCard.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Candara", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDiscountCard.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.dgvDiscountCard.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dgvDiscountCard.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvDiscountCard.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Maroon;
            this.dgvDiscountCard.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiscountCard.RowTemplate.Height = 50;
            this.dgvDiscountCard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiscountCard.Size = new System.Drawing.Size(824, 473);
            this.dgvDiscountCard.TabIndex = 1;
            this.dgvDiscountCard.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDiscountCard_DataError);
            this.dgvDiscountCard.SelectionChanged += new System.EventHandler(this.dgvDiscountCard_SelectionChanged);
            // 
            // pnlBodyRight
            // 
            this.pnlBodyRight.BackgroundImage = global::EzPos.Properties.Resources.backgroud_12;
            this.pnlBodyRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBodyRight.Controls.Add(this.btnDelete);
            this.pnlBodyRight.Controls.Add(this.btnReturnCard);
            this.pnlBodyRight.Controls.Add(this.cmbCustomerHidden);
            this.pnlBodyRight.Controls.Add(this.lblPrintCard);
            this.pnlBodyRight.Controls.Add(this.grbPrintCard);
            this.pnlBodyRight.Controls.Add(this.lblDelCard);
            this.pnlBodyRight.Controls.Add(this.grbDeleteCard);
            this.pnlBodyRight.Controls.Add(this.lblNewCard);
            this.pnlBodyRight.Controls.Add(this.grbNewCard);
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
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "លុបកាត";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.MouseLeave += new System.EventHandler(this.btnDelete_MouseLeave);
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            this.btnDelete.MouseEnter += new System.EventHandler(this.btnDelete_MouseEnter);
            // 
            // btnReturnCard
            // 
            this.btnReturnCard.BackColor = System.Drawing.Color.Transparent;
            this.btnReturnCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReturnCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReturnCard.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnCard.ForeColor = System.Drawing.Color.White;
            this.btnReturnCard.Image = global::EzPos.Properties.Resources.Cancel32;
            this.btnReturnCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturnCard.Location = new System.Drawing.Point(28, 519);
            this.btnReturnCard.Name = "btnReturnCard";
            this.btnReturnCard.Size = new System.Drawing.Size(144, 40);
            this.btnReturnCard.TabIndex = 7;
            this.btnReturnCard.Text = "ដកហូតកាត";
            this.btnReturnCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReturnCard.UseVisualStyleBackColor = false;
            this.btnReturnCard.MouseLeave += new System.EventHandler(this.btnReturnCard_MouseLeave);
            this.btnReturnCard.Click += new System.EventHandler(this.btnReturnCard_Click);
            this.btnReturnCard.MouseEnter += new System.EventHandler(this.btnReturnCard_MouseEnter);
            // 
            // cmbCustomerHidden
            // 
            this.cmbCustomerHidden.DropDownWidth = 180;
            this.cmbCustomerHidden.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomerHidden.FormattingEnabled = true;
            this.cmbCustomerHidden.Location = new System.Drawing.Point(10, 368);
            this.cmbCustomerHidden.Name = "cmbCustomerHidden";
            this.cmbCustomerHidden.Size = new System.Drawing.Size(184, 28);
            this.cmbCustomerHidden.TabIndex = 6;
            this.cmbCustomerHidden.Visible = false;
            // 
            // lblPrintCard
            // 
            this.lblPrintCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblPrintCard.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrintCard.ForeColor = System.Drawing.Color.Yellow;
            this.lblPrintCard.Location = new System.Drawing.Point(10, 214);
            this.lblPrintCard.Name = "lblPrintCard";
            this.lblPrintCard.Size = new System.Drawing.Size(179, 31);
            this.lblPrintCard.TabIndex = 5;
            this.lblPrintCard.Text = "បោះពុម្ពកាត";
            // 
            // grbPrintCard
            // 
            this.grbPrintCard.BackgroundImage = global::EzPos.Properties.Resources.pnlBodyRight;
            this.grbPrintCard.Controls.Add(this.btnPrint);
            this.grbPrintCard.Controls.Add(this.rdbPrintSelected);
            this.grbPrintCard.Controls.Add(this.rdbPrintAll);
            this.grbPrintCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbPrintCard.Location = new System.Drawing.Point(10, 213);
            this.grbPrintCard.Name = "grbPrintCard";
            this.grbPrintCard.Size = new System.Drawing.Size(180, 149);
            this.grbPrintCard.TabIndex = 4;
            this.grbPrintCard.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Image = global::EzPos.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(18, 102);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(144, 40);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "បោះពុម្ភ";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.MouseLeave += new System.EventHandler(this.btnPrint_MouseLeave);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.btnPrint.MouseEnter += new System.EventHandler(this.btnPrint_MouseEnter);
            // 
            // rdbPrintSelected
            // 
            this.rdbPrintSelected.AutoSize = true;
            this.rdbPrintSelected.BackColor = System.Drawing.Color.Transparent;
            this.rdbPrintSelected.Checked = true;
            this.rdbPrintSelected.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPrintSelected.Location = new System.Drawing.Point(9, 33);
            this.rdbPrintSelected.Name = "rdbPrintSelected";
            this.rdbPrintSelected.Size = new System.Drawing.Size(106, 31);
            this.rdbPrintSelected.TabIndex = 1;
            this.rdbPrintSelected.TabStop = true;
            this.rdbPrintSelected.Text = "ជ្រើសរើស";
            this.rdbPrintSelected.UseVisualStyleBackColor = false;
            // 
            // rdbPrintAll
            // 
            this.rdbPrintAll.AutoSize = true;
            this.rdbPrintAll.BackColor = System.Drawing.Color.Transparent;
            this.rdbPrintAll.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPrintAll.Location = new System.Drawing.Point(9, 69);
            this.rdbPrintAll.Name = "rdbPrintAll";
            this.rdbPrintAll.Size = new System.Drawing.Size(90, 31);
            this.rdbPrintAll.TabIndex = 0;
            this.rdbPrintAll.Text = "ទាំងអស់";
            this.rdbPrintAll.UseVisualStyleBackColor = false;
            // 
            // lblDelCard
            // 
            this.lblDelCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblDelCard.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelCard.ForeColor = System.Drawing.Color.Yellow;
            this.lblDelCard.Location = new System.Drawing.Point(10, 400);
            this.lblDelCard.Name = "lblDelCard";
            this.lblDelCard.Size = new System.Drawing.Size(180, 31);
            this.lblDelCard.TabIndex = 3;
            this.lblDelCard.Text = "លុបកាត";
            this.lblDelCard.Visible = false;
            // 
            // grbDeleteCard
            // 
            this.grbDeleteCard.BackgroundImage = global::EzPos.Properties.Resources.pnlBodyRight;
            this.grbDeleteCard.Controls.Add(this.lblCardSelect);
            this.grbDeleteCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbDeleteCard.Location = new System.Drawing.Point(10, 399);
            this.grbDeleteCard.Name = "grbDeleteCard";
            this.grbDeleteCard.Size = new System.Drawing.Size(180, 62);
            this.grbDeleteCard.TabIndex = 2;
            this.grbDeleteCard.TabStop = false;
            this.grbDeleteCard.Visible = false;
            // 
            // lblCardSelect
            // 
            this.lblCardSelect.BackColor = System.Drawing.Color.Transparent;
            this.lblCardSelect.Font = new System.Drawing.Font("Candara", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardSelect.Location = new System.Drawing.Point(0, 32);
            this.lblCardSelect.Name = "lblCardSelect";
            this.lblCardSelect.Size = new System.Drawing.Size(180, 24);
            this.lblCardSelect.TabIndex = 0;
            this.lblCardSelect.Text = "CardNumber";
            this.lblCardSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNewCard
            // 
            this.lblNewCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblNewCard.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCard.ForeColor = System.Drawing.Color.Yellow;
            this.lblNewCard.Location = new System.Drawing.Point(10, 1);
            this.lblNewCard.Name = "lblNewCard";
            this.lblNewCard.Size = new System.Drawing.Size(179, 31);
            this.lblNewCard.TabIndex = 1;
            this.lblNewCard.Text = "បង្កើតកាតថ្មី";
            // 
            // grbNewCard
            // 
            this.grbNewCard.BackgroundImage = global::EzPos.Properties.Resources.pnlBodyRight;
            this.grbNewCard.Controls.Add(this.btnNew);
            this.grbNewCard.Controls.Add(this.txtNumCard);
            this.grbNewCard.Controls.Add(this.cmbDiscountType);
            this.grbNewCard.Controls.Add(this.lblNumCard);
            this.grbNewCard.Controls.Add(this.lblCardType);
            this.grbNewCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbNewCard.Location = new System.Drawing.Point(10, 0);
            this.grbNewCard.Name = "grbNewCard";
            this.grbNewCard.Size = new System.Drawing.Size(180, 207);
            this.grbNewCard.TabIndex = 0;
            this.grbNewCard.TabStop = false;
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
            this.btnNew.Location = new System.Drawing.Point(18, 160);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(144, 40);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "បង្កើតថ្មី";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.MouseLeave += new System.EventHandler(this.btnNew_MouseLeave);
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            this.btnNew.MouseEnter += new System.EventHandler(this.btnNew_MouseEnter);
            // 
            // txtNumCard
            // 
            this.txtNumCard.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumCard.Location = new System.Drawing.Point(11, 126);
            this.txtNumCard.Name = "txtNumCard";
            this.txtNumCard.Size = new System.Drawing.Size(160, 27);
            this.txtNumCard.TabIndex = 3;
            // 
            // cmbDiscountType
            // 
            this.cmbDiscountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiscountType.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDiscountType.FormattingEnabled = true;
            this.cmbDiscountType.Location = new System.Drawing.Point(8, 65);
            this.cmbDiscountType.Name = "cmbDiscountType";
            this.cmbDiscountType.Size = new System.Drawing.Size(163, 27);
            this.cmbDiscountType.TabIndex = 1;
            // 
            // lblNumCard
            // 
            this.lblNumCard.AutoSize = true;
            this.lblNumCard.BackColor = System.Drawing.Color.Transparent;
            this.lblNumCard.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumCard.ForeColor = System.Drawing.Color.White;
            this.lblNumCard.Location = new System.Drawing.Point(2, 94);
            this.lblNumCard.Name = "lblNumCard";
            this.lblNumCard.Size = new System.Drawing.Size(49, 30);
            this.lblNumCard.TabIndex = 2;
            this.lblNumCard.Text = "ចំនួន";
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.BackColor = System.Drawing.Color.Transparent;
            this.lblCardType.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardType.ForeColor = System.Drawing.Color.White;
            this.lblCardType.Location = new System.Drawing.Point(2, 33);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(63, 30);
            this.lblCardType.TabIndex = 0;
            this.lblCardType.Text = "ប្រភេទ";
            // 
            // pnlBodySearch
            // 
            this.pnlBodySearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBodySearch.Controls.Add(this.lblResultInfo);
            this.pnlBodySearch.Controls.Add(this.chbNonUsed);
            this.pnlBodySearch.Controls.Add(this.chbUsed);
            this.pnlBodySearch.Controls.Add(this.lblCardNum);
            this.pnlBodySearch.Controls.Add(this.txtCardNum);
            this.pnlBodySearch.Controls.Add(this.cmbCustomer);
            this.pnlBodySearch.Controls.Add(this.lblCustomer);
            this.pnlBodySearch.Controls.Add(this.cmbDCardType);
            this.pnlBodySearch.Controls.Add(this.lblDCountType);
            this.pnlBodySearch.Controls.Add(this.btnReset);
            this.pnlBodySearch.Controls.Add(this.btnSearch);
            this.pnlBodySearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBodySearch.Location = new System.Drawing.Point(0, 0);
            this.pnlBodySearch.Name = "pnlBodySearch";
            this.pnlBodySearch.Size = new System.Drawing.Size(826, 120);
            this.pnlBodySearch.TabIndex = 0;
            // 
            // lblResultInfo
            // 
            this.lblResultInfo.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultInfo.Location = new System.Drawing.Point(7, 86);
            this.lblResultInfo.Name = "lblResultInfo";
            this.lblResultInfo.Size = new System.Drawing.Size(803, 32);
            this.lblResultInfo.TabIndex = 15;
            // 
            // chbNonUsed
            // 
            this.chbNonUsed.AutoSize = true;
            this.chbNonUsed.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbNonUsed.Location = new System.Drawing.Point(174, 49);
            this.chbNonUsed.Name = "chbNonUsed";
            this.chbNonUsed.Size = new System.Drawing.Size(111, 31);
            this.chbNonUsed.TabIndex = 7;
            this.chbNonUsed.Text = "មិនទាន់ប្រើ";
            this.chbNonUsed.UseVisualStyleBackColor = true;
            this.chbNonUsed.CheckedChanged += new System.EventHandler(this.chbNonUsed_CheckedChanged);
            // 
            // chbUsed
            // 
            this.chbUsed.AutoSize = true;
            this.chbUsed.Checked = true;
            this.chbUsed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbUsed.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbUsed.Location = new System.Drawing.Point(87, 49);
            this.chbUsed.Name = "chbUsed";
            this.chbUsed.Size = new System.Drawing.Size(76, 31);
            this.chbUsed.TabIndex = 6;
            this.chbUsed.Text = "ប្រើរូច";
            this.chbUsed.UseVisualStyleBackColor = true;
            this.chbUsed.CheckedChanged += new System.EventHandler(this.chbUsed_CheckedChanged);
            // 
            // lblCardNum
            // 
            this.lblCardNum.AutoSize = true;
            this.lblCardNum.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardNum.Location = new System.Drawing.Point(8, 12);
            this.lblCardNum.Name = "lblCardNum";
            this.lblCardNum.Size = new System.Drawing.Size(73, 27);
            this.lblCardNum.TabIndex = 0;
            this.lblCardNum.Text = "លេខកូដ";
            // 
            // txtCardNum
            // 
            this.txtCardNum.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNum.Location = new System.Drawing.Point(87, 12);
            this.txtCardNum.Name = "txtCardNum";
            this.txtCardNum.Size = new System.Drawing.Size(184, 27);
            this.txtCardNum.TabIndex = 1;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownWidth = 180;
            this.cmbCustomer.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(626, 12);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(184, 27);
            this.cmbCustomer.TabIndex = 5;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(548, 12);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(72, 27);
            this.lblCustomer.TabIndex = 4;
            this.lblCustomer.Text = "អតិថិជន";
            // 
            // cmbDCardType
            // 
            this.cmbDCardType.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDCardType.FormattingEnabled = true;
            this.cmbDCardType.Location = new System.Drawing.Point(351, 12);
            this.cmbDCardType.Name = "cmbDCardType";
            this.cmbDCardType.Size = new System.Drawing.Size(184, 27);
            this.cmbDCardType.TabIndex = 3;
            // 
            // lblDCountType
            // 
            this.lblDCountType.AutoSize = true;
            this.lblDCountType.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDCountType.Location = new System.Drawing.Point(283, 12);
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
            this.btnReset.Location = new System.Drawing.Point(626, 49);
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
            this.btnSearch.Location = new System.Drawing.Point(721, 49);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 28);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "&Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // PrintCheck
            // 
            this.PrintCheck.HeaderText = "បោះពុម្ភ";
            this.PrintCheck.Name = "PrintCheck";
            this.PrintCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PrintCheck.Width = 84;
            // 
            // CardNumber
            // 
            this.CardNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CardNumber.DataPropertyName = "CardNumber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CardNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.CardNumber.HeaderText = "លេខកាត";
            this.CardNumber.Name = "CardNumber";
            this.CardNumber.ReadOnly = true;
            this.CardNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CardNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CardNumber.Width = 150;
            // 
            // DiscountCardTypeStr
            // 
            this.DiscountCardTypeStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DiscountCardTypeStr.DataPropertyName = "DiscountCardTypeStr";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DiscountCardTypeStr.DefaultCellStyle = dataGridViewCellStyle3;
            this.DiscountCardTypeStr.HeaderText = "ប្រភេទកាត";
            this.DiscountCardTypeStr.Name = "DiscountCardTypeStr";
            this.DiscountCardTypeStr.ReadOnly = true;
            this.DiscountCardTypeStr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DiscountCardTypeStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DiscountCardTypeStr.Width = 140;
            // 
            // DiscountCardTypeID
            // 
            this.DiscountCardTypeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DiscountCardTypeID.DataPropertyName = "DiscountCardTypeID";
            this.DiscountCardTypeID.HeaderText = "ប្រភេទកាត";
            this.DiscountCardTypeID.Name = "DiscountCardTypeID";
            this.DiscountCardTypeID.ReadOnly = true;
            this.DiscountCardTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DiscountCardTypeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DiscountCardTypeID.Visible = false;
            this.DiscountCardTypeID.Width = 140;
            // 
            // DiscountPercentage
            // 
            this.DiscountPercentage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DiscountPercentage.DataPropertyName = "DiscountPercentage";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.DiscountPercentage.DefaultCellStyle = dataGridViewCellStyle4;
            this.DiscountPercentage.HeaderText = "% បញ្ចុះតំលៃ";
            this.DiscountPercentage.Name = "DiscountPercentage";
            this.DiscountPercentage.ReadOnly = true;
            this.DiscountPercentage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DiscountPercentage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DiscountPercentage.Width = 130;
            // 
            // CustomerID
            // 
            this.CustomerID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CustomerID.DataPropertyName = "CustomerID";
            this.CustomerID.HeaderText = "CustomerID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            this.CustomerID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CustomerID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CustomerID.Visible = false;
            // 
            // CustomerStr
            // 
            this.CustomerStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CustomerStr.DataPropertyName = "CustomerStr";
            this.CustomerStr.HeaderText = "អតិថិជន";
            this.CustomerStr.Name = "CustomerStr";
            this.CustomerStr.ReadOnly = true;
            this.CustomerStr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CustomerStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DiscountCardID
            // 
            this.DiscountCardID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DiscountCardID.DataPropertyName = "DiscountCardID";
            this.DiscountCardID.HeaderText = "DiscountCardID";
            this.DiscountCardID.Name = "DiscountCardID";
            this.DiscountCardID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DiscountCardID.Visible = false;
            // 
            // ExpireDate
            // 
            this.ExpireDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ExpireDate.DataPropertyName = "ExpireDate";
            this.ExpireDate.HeaderText = "ExpireDate";
            this.ExpireDate.Name = "ExpireDate";
            this.ExpireDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExpireDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExpireDate.Visible = false;
            // 
            // FKCustomer
            // 
            this.FKCustomer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FKCustomer.DataPropertyName = "FKCustomer";
            this.FKCustomer.HeaderText = "FKCustomer";
            this.FKCustomer.Name = "FKCustomer";
            this.FKCustomer.ReadOnly = true;
            this.FKCustomer.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FKCustomer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FKCustomer.Visible = false;
            // 
            // AllowDiscount
            // 
            this.AllowDiscount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AllowDiscount.DataPropertyName = "AllowDiscount";
            this.AllowDiscount.HeaderText = "AllowDiscount";
            this.AllowDiscount.Name = "AllowDiscount";
            this.AllowDiscount.ReadOnly = true;
            this.AllowDiscount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AllowDiscount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AllowDiscount.Visible = false;
            // 
            // CtrlDiscountCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBodyLeft);
            this.Controls.Add(this.pnlBodySearch);
            this.Controls.Add(this.pnlBodyRight);
            this.Name = "CtrlDiscountCard";
            this.Size = new System.Drawing.Size(1026, 595);
            this.Load += new System.EventHandler(this.CtrlDiscountCard_Load);
            this.pnlBodyLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscountCard)).EndInit();
            this.pnlBodyRight.ResumeLayout(false);
            this.grbPrintCard.ResumeLayout(false);
            this.grbPrintCard.PerformLayout();
            this.grbDeleteCard.ResumeLayout(false);
            this.grbNewCard.ResumeLayout(false);
            this.grbNewCard.PerformLayout();
            this.pnlBodySearch.ResumeLayout(false);
            this.pnlBodySearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBodyLeft;
        private System.Windows.Forms.Panel pnlBodyRight;
        private System.Windows.Forms.DataGridView dgvDiscountCard;
        private System.Windows.Forms.GroupBox grbNewCard;
        private System.Windows.Forms.Label lblNewCard;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.TextBox txtNumCard;
        private ExtendedComboBox cmbDiscountType;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblNumCard;
        private System.Windows.Forms.Label lblPrintCard;
        private System.Windows.Forms.GroupBox grbPrintCard;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblDelCard;
        private System.Windows.Forms.GroupBox grbDeleteCard;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblCardSelect;
        private System.Windows.Forms.RadioButton rdbPrintAll;
        private System.Windows.Forms.RadioButton rdbPrintSelected;
        private System.Windows.Forms.Panel pnlBodySearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private ExtendedComboBox cmbCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private ExtendedComboBox cmbDCardType;
        private System.Windows.Forms.Label lblDCountType;
        private System.Windows.Forms.Label lblCardNum;
        private System.Windows.Forms.TextBox txtCardNum;
        private System.Windows.Forms.CheckBox chbNonUsed;
        private System.Windows.Forms.CheckBox chbUsed;
        private ExtendedComboBox cmbCustomerHidden;
        private System.Windows.Forms.Label lblResultInfo;
        private System.Windows.Forms.Button btnReturnCard;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PrintCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountCardTypeStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountCardTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountCardID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpireDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn FKCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllowDiscount;

    }
}