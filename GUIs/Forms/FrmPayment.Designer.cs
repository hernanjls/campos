using EzPos.GUIs.Components;
using EzPos.Service;
using EzPos.Service.Common;

namespace EzPos.GUIs.Forms
{
    partial class FrmPayment
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.cmbDCountType = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbDiscountCard = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurrentSaleAmount = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lsbCustomer = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblExchangeRate = new System.Windows.Forms.Label();
            this.txtExchangeRate = new System.Windows.Forms.TextBox();
            this.txtAmountReturnRiel = new System.Windows.Forms.TextBox();
            this.lblAmountReturnRiel = new System.Windows.Forms.Label();
            this.lblAmountReturnUsd = new System.Windows.Forms.Label();
            this.txtAmountReturnUsd = new System.Windows.Forms.TextBox();
            this.txtAmountPaidRiel = new System.Windows.Forms.TextBox();
            this.lblAmoutPaidRiel = new System.Windows.Forms.Label();
            this.lblAmountPaidUsd = new System.Windows.Forms.Label();
            this.txtAmountPaidUsd = new System.Windows.Forms.TextBox();
            this.txtTotalAmountRiel = new System.Windows.Forms.TextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.txtTotalAmountUsd = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblDCardInfo = new System.Windows.Forms.Label();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlBody.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody.Controls.Add(this.cmbDCountType);
            this.pnlBody.Controls.Add(this.txtSearch);
            this.pnlBody.Controls.Add(this.cmbDiscountCard);
            this.pnlBody.Controls.Add(this.label2);
            this.pnlBody.Controls.Add(this.txtCurrentSaleAmount);
            this.pnlBody.Controls.Add(this.groupBox2);
            this.pnlBody.Controls.Add(this.lsbCustomer);
            this.pnlBody.Controls.Add(this.label1);
            this.pnlBody.Controls.Add(this.txtDiscount);
            this.pnlBody.Controls.Add(this.lblExchangeRate);
            this.pnlBody.Controls.Add(this.txtExchangeRate);
            this.pnlBody.Controls.Add(this.txtAmountReturnRiel);
            this.pnlBody.Controls.Add(this.lblAmountReturnRiel);
            this.pnlBody.Controls.Add(this.lblAmountReturnUsd);
            this.pnlBody.Controls.Add(this.txtAmountReturnUsd);
            this.pnlBody.Controls.Add(this.txtAmountPaidRiel);
            this.pnlBody.Controls.Add(this.lblAmoutPaidRiel);
            this.pnlBody.Controls.Add(this.lblAmountPaidUsd);
            this.pnlBody.Controls.Add(this.txtAmountPaidUsd);
            this.pnlBody.Controls.Add(this.txtTotalAmountRiel);
            this.pnlBody.Controls.Add(this.lblDisplayName);
            this.pnlBody.Controls.Add(this.lblProductCode);
            this.pnlBody.Controls.Add(this.txtTotalAmountUsd);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 89);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(695, 437);
            this.pnlBody.TabIndex = 1;
            // 
            // cmbDCountType
            // 
            this.cmbDCountType.DropDownWidth = 100;
            this.cmbDCountType.Enabled = false;
            this.cmbDCountType.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDCountType.FormattingEnabled = true;
            this.cmbDCountType.Location = new System.Drawing.Point(643, 103);
            this.cmbDCountType.Name = "cmbDCountType";
            this.cmbDCountType.Size = new System.Drawing.Size(19, 36);
            this.cmbDCountType.TabIndex = 43;
            this.cmbDCountType.SelectedIndexChanged += new System.EventHandler(this.CmbDCountTypeSelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(30, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(242, 36);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearchKeyDown);
            this.txtSearch.Leave += new System.EventHandler(this.TxtDCardNumLeave);
            this.txtSearch.Enter += new System.EventHandler(this.TxtDCardNumEnter);
            // 
            // cmbDiscountCard
            // 
            this.cmbDiscountCard.FormattingEnabled = true;
            this.cmbDiscountCard.Location = new System.Drawing.Point(30, 421);
            this.cmbDiscountCard.Name = "cmbDiscountCard";
            this.cmbDiscountCard.Size = new System.Drawing.Size(242, 21);
            this.cmbDiscountCard.TabIndex = 42;
            this.cmbDiscountCard.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.label2.Location = new System.Drawing.Point(286, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 29);
            this.label2.TabIndex = 21;
            this.label2.Text = "សរុប ($)";
            // 
            // txtCurrentSaleAmount
            // 
            this.txtCurrentSaleAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtCurrentSaleAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentSaleAmount.Enabled = false;
            this.txtCurrentSaleAmount.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentSaleAmount.Location = new System.Drawing.Point(422, 61);
            this.txtCurrentSaleAmount.Name = "txtCurrentSaleAmount";
            this.txtCurrentSaleAmount.ReadOnly = true;
            this.txtCurrentSaleAmount.Size = new System.Drawing.Size(240, 36);
            this.txtCurrentSaleAmount.TabIndex = 22;
            this.txtCurrentSaleAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox2.Location = new System.Drawing.Point(281, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(2, 412);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // lsbCustomer
            // 
            this.lsbCustomer.Font = new System.Drawing.Font("Candara", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbCustomer.FormattingEnabled = true;
            this.lsbCustomer.ItemHeight = 24;
            this.lsbCustomer.Location = new System.Drawing.Point(30, 53);
            this.lsbCustomer.Name = "lsbCustomer";
            this.lsbCustomer.Size = new System.Drawing.Size(242, 364);
            this.lsbCustomer.TabIndex = 1;
            this.lsbCustomer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LsbCustomerMouseDoubleClick);
            this.lsbCustomer.SelectedIndexChanged += new System.EventHandler(this.LsbCustomerSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.label1.Location = new System.Drawing.Point(286, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 29);
            this.label1.TabIndex = 23;
            this.label1.Text = "បញ្ចុះតំលៃ";
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackColor = System.Drawing.SystemColors.Window;
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(422, 103);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(221, 36);
            this.txtDiscount.TabIndex = 24;
            this.txtDiscount.Text = "0 %";
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblExchangeRate
            // 
            this.lblExchangeRate.AutoSize = true;
            this.lblExchangeRate.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExchangeRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblExchangeRate.Location = new System.Drawing.Point(286, 16);
            this.lblExchangeRate.Name = "lblExchangeRate";
            this.lblExchangeRate.Size = new System.Drawing.Size(68, 29);
            this.lblExchangeRate.TabIndex = 18;
            this.lblExchangeRate.Text = "$ ទៅ ៛";
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.BackColor = System.Drawing.SystemColors.Window;
            this.txtExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExchangeRate.Enabled = false;
            this.txtExchangeRate.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExchangeRate.Location = new System.Drawing.Point(422, 12);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.ReadOnly = true;
            this.txtExchangeRate.Size = new System.Drawing.Size(240, 36);
            this.txtExchangeRate.TabIndex = 19;
            this.txtExchangeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAmountReturnRiel
            // 
            this.txtAmountReturnRiel.BackColor = System.Drawing.SystemColors.Window;
            this.txtAmountReturnRiel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountReturnRiel.Enabled = false;
            this.txtAmountReturnRiel.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountReturnRiel.Location = new System.Drawing.Point(422, 385);
            this.txtAmountReturnRiel.Name = "txtAmountReturnRiel";
            this.txtAmountReturnRiel.ReadOnly = true;
            this.txtAmountReturnRiel.Size = new System.Drawing.Size(240, 36);
            this.txtAmountReturnRiel.TabIndex = 40;
            this.txtAmountReturnRiel.Text = "0.00";
            this.txtAmountReturnRiel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAmountReturnRiel
            // 
            this.lblAmountReturnRiel.AutoSize = true;
            this.lblAmountReturnRiel.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountReturnRiel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblAmountReturnRiel.Location = new System.Drawing.Point(286, 392);
            this.lblAmountReturnRiel.Name = "lblAmountReturnRiel";
            this.lblAmountReturnRiel.Size = new System.Drawing.Size(89, 29);
            this.lblAmountReturnRiel.TabIndex = 39;
            this.lblAmountReturnRiel.Text = "អាប់ជា (៛)";
            // 
            // lblAmountReturnUsd
            // 
            this.lblAmountReturnUsd.AutoSize = true;
            this.lblAmountReturnUsd.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountReturnUsd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblAmountReturnUsd.Location = new System.Drawing.Point(286, 347);
            this.lblAmountReturnUsd.Name = "lblAmountReturnUsd";
            this.lblAmountReturnUsd.Size = new System.Drawing.Size(92, 29);
            this.lblAmountReturnUsd.TabIndex = 37;
            this.lblAmountReturnUsd.Text = "អាប់ជា ($)";
            // 
            // txtAmountReturnUsd
            // 
            this.txtAmountReturnUsd.BackColor = System.Drawing.SystemColors.Window;
            this.txtAmountReturnUsd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountReturnUsd.Enabled = false;
            this.txtAmountReturnUsd.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountReturnUsd.Location = new System.Drawing.Point(422, 343);
            this.txtAmountReturnUsd.Name = "txtAmountReturnUsd";
            this.txtAmountReturnUsd.ReadOnly = true;
            this.txtAmountReturnUsd.Size = new System.Drawing.Size(240, 36);
            this.txtAmountReturnUsd.TabIndex = 38;
            this.txtAmountReturnUsd.Text = "0.00";
            this.txtAmountReturnUsd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAmountPaidRiel
            // 
            this.txtAmountPaidRiel.BackColor = System.Drawing.SystemColors.Info;
            this.txtAmountPaidRiel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountPaidRiel.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountPaidRiel.Location = new System.Drawing.Point(422, 291);
            this.txtAmountPaidRiel.Name = "txtAmountPaidRiel";
            this.txtAmountPaidRiel.Size = new System.Drawing.Size(240, 36);
            this.txtAmountPaidRiel.TabIndex = 35;
            this.txtAmountPaidRiel.Text = "0.00";
            this.txtAmountPaidRiel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmountPaidRiel.TextChanged += new System.EventHandler(this.TxtAmountPaidRielTextChanged);
            this.txtAmountPaidRiel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPayment_KeyDown);
            this.txtAmountPaidRiel.Leave += new System.EventHandler(this.TxtAmountPaidRiel_Leave);
            // 
            // lblAmoutPaidRiel
            // 
            this.lblAmoutPaidRiel.AutoSize = true;
            this.lblAmoutPaidRiel.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmoutPaidRiel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblAmoutPaidRiel.Location = new System.Drawing.Point(286, 295);
            this.lblAmoutPaidRiel.Name = "lblAmoutPaidRiel";
            this.lblAmoutPaidRiel.Size = new System.Drawing.Size(121, 29);
            this.lblAmoutPaidRiel.TabIndex = 34;
            this.lblAmoutPaidRiel.Text = "ទទួលលុយ (៛)";
            // 
            // lblAmountPaidUsd
            // 
            this.lblAmountPaidUsd.AutoSize = true;
            this.lblAmountPaidUsd.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountPaidUsd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblAmountPaidUsd.Location = new System.Drawing.Point(286, 253);
            this.lblAmountPaidUsd.Name = "lblAmountPaidUsd";
            this.lblAmountPaidUsd.Size = new System.Drawing.Size(124, 29);
            this.lblAmountPaidUsd.TabIndex = 32;
            this.lblAmountPaidUsd.Text = "ទទួលលុយ ($)";
            // 
            // txtAmountPaidUsd
            // 
            this.txtAmountPaidUsd.BackColor = System.Drawing.SystemColors.Info;
            this.txtAmountPaidUsd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountPaidUsd.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountPaidUsd.Location = new System.Drawing.Point(422, 249);
            this.txtAmountPaidUsd.Name = "txtAmountPaidUsd";
            this.txtAmountPaidUsd.Size = new System.Drawing.Size(240, 36);
            this.txtAmountPaidUsd.TabIndex = 33;
            this.txtAmountPaidUsd.Text = "0.00";
            this.txtAmountPaidUsd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmountPaidUsd.TextChanged += new System.EventHandler(this.TxtAmountPaidUsdTextChanged);
            this.txtAmountPaidUsd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPayment_KeyDown);
            this.txtAmountPaidUsd.Leave += new System.EventHandler(this.TxtAmountPaidUsdLeave);
            // 
            // txtTotalAmountRiel
            // 
            this.txtTotalAmountRiel.BackColor = System.Drawing.SystemColors.Window;
            this.txtTotalAmountRiel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAmountRiel.Enabled = false;
            this.txtTotalAmountRiel.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmountRiel.Location = new System.Drawing.Point(422, 198);
            this.txtTotalAmountRiel.Name = "txtTotalAmountRiel";
            this.txtTotalAmountRiel.ReadOnly = true;
            this.txtTotalAmountRiel.Size = new System.Drawing.Size(240, 36);
            this.txtTotalAmountRiel.TabIndex = 30;
            this.txtTotalAmountRiel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblDisplayName.Location = new System.Drawing.Point(286, 202);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(110, 29);
            this.lblDisplayName.TabIndex = 29;
            this.lblDisplayName.Text = "ត្រូវបង់ជា (៛)";
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblProductCode.Location = new System.Drawing.Point(286, 160);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(113, 29);
            this.lblProductCode.TabIndex = 27;
            this.lblProductCode.Text = "ត្រូវបង់ជា ($)";
            // 
            // txtTotalAmountUsd
            // 
            this.txtTotalAmountUsd.BackColor = System.Drawing.SystemColors.Window;
            this.txtTotalAmountUsd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAmountUsd.Enabled = false;
            this.txtTotalAmountUsd.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmountUsd.Location = new System.Drawing.Point(422, 156);
            this.txtTotalAmountUsd.Name = "txtTotalAmountUsd";
            this.txtTotalAmountUsd.ReadOnly = true;
            this.txtTotalAmountUsd.Size = new System.Drawing.Size(240, 36);
            this.txtTotalAmountUsd.TabIndex = 28;
            this.txtTotalAmountUsd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNew.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNew.Location = new System.Drawing.Point(31, 9);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(116, 36);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "អតិថិជន​ថ្មី";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.MouseLeave += new System.EventHandler(this.BtnNewMouseLeave);
            this.btnNew.Click += new System.EventHandler(this.BtnNewClick);
            this.btnNew.MouseEnter += new System.EventHandler(this.BtnNewMouseEnter);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::EzPos.Properties.Resources.Cancel32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(547, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 36);
            this.btnCancel.TabIndex = 43;
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
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::EzPos.Properties.Resources.OK32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(430, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 36);
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "យល់ព្រម";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.MouseLeave += new System.EventHandler(this.BtnSaveMouseLeave);
            this.btnSave.MouseEnter += new System.EventHandler(this.BtnSaveMouseEnter);
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = global::EzPos.Properties.Resources.backgroud_11;
            this.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTop.Controls.Add(this.lblDCardInfo);
            this.pnlTop.Controls.Add(this.lblCustomerInfo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(695, 89);
            this.pnlTop.TabIndex = 1;
            // 
            // lblDCardInfo
            // 
            this.lblDCardInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblDCardInfo.Font = new System.Drawing.Font("Khmer OS System", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDCardInfo.ForeColor = System.Drawing.Color.Yellow;
            this.lblDCardInfo.Location = new System.Drawing.Point(418, 0);
            this.lblDCardInfo.Name = "lblDCardInfo";
            this.lblDCardInfo.Size = new System.Drawing.Size(252, 89);
            this.lblDCardInfo.TabIndex = 1;
            this.lblDCardInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerInfo.Font = new System.Drawing.Font("Khmer OS System", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerInfo.ForeColor = System.Drawing.Color.Yellow;
            this.lblCustomerInfo.Location = new System.Drawing.Point(26, 0);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(284, 89);
            this.lblCustomerInfo.TabIndex = 0;
            this.lblCustomerInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackgroundImage = global::EzPos.Properties.Resources.background_5;
            this.pnlBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnNew);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Font = new System.Drawing.Font("Candara", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBottom.ForeColor = System.Drawing.Color.White;
            this.pnlBottom.Location = new System.Drawing.Point(0, 526);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(695, 48);
            this.pnlBottom.TabIndex = 2;
            // 
            // FrmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(695, 574);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmPayment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPayment";
            this.Load += new System.EventHandler(this.FrmPayment_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPayment_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPayment_KeyDown);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTotalAmountRiel;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.TextBox txtTotalAmountUsd;
        private System.Windows.Forms.TextBox txtAmountPaidRiel;
        private System.Windows.Forms.Label lblAmoutPaidRiel;
        private System.Windows.Forms.Label lblAmountPaidUsd;
        private System.Windows.Forms.TextBox txtAmountPaidUsd;
        private System.Windows.Forms.TextBox txtAmountReturnRiel;
        private System.Windows.Forms.Label lblAmountReturnRiel;
        private System.Windows.Forms.Label lblAmountReturnUsd;
        private System.Windows.Forms.TextBox txtAmountReturnUsd;
        private System.Windows.Forms.Label lblExchangeRate;
        private System.Windows.Forms.TextBox txtExchangeRate;
        private System.Windows.Forms.ListBox lsbCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurrentSaleAmount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ComboBox cmbDiscountCard;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblDCardInfo;
        private ExtendedComboBox cmbDCountType;
        private float _TotalAmountInt;
        private CommonService _CommonService;
        private CustomerService _CustomerService;
    }
}