using ExtendedComboBox = EzPos.GUIs.Components.ExtendedComboBox;

namespace EzPos.GUIs.Forms
{
    partial class FrmCatalog
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
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblMark = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblUPIn = new System.Windows.Forms.Label();
            this.txtUPIn = new System.Windows.Forms.TextBox();
            this.lblUPOut = new System.Windows.Forms.Label();
            this.txtUPOut = new System.Windows.Forms.TextBox();
            this.lblExtraPercentage = new System.Windows.Forms.Label();
            this.txtExtraPercentage = new System.Windows.Forms.TextBox();
            this.lblQtyInStock = new System.Windows.Forms.Label();
            this.txtQtyInStock = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.grbLine_1 = new System.Windows.Forms.GroupBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.txtForeignCode = new System.Windows.Forms.TextBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.cmbSize = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.lblQty = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbColor = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.cmbMark = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.cmbCategory = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblProductName = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnAdjustment = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmsCatalog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmIndividual = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmImport = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPhotoPath = new System.Windows.Forms.TextBox();
            this.ptbProduct = new System.Windows.Forms.PictureBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.pnlBody.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.cmsCatalog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCategory
            // 
            this.lblCategory.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(23, 57);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(122, 38);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "ប្រភេទ";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMark
            // 
            this.lblMark.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMark.Location = new System.Drawing.Point(23, 100);
            this.lblMark.Name = "lblMark";
            this.lblMark.Size = new System.Drawing.Size(122, 28);
            this.lblMark.TabIndex = 4;
            this.lblMark.Text = "ម៉ាក";
            this.lblMark.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblColor
            // 
            this.lblColor.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(24, 138);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(122, 28);
            this.lblColor.TabIndex = 6;
            this.lblColor.Text = "ពណ៍";
            this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUPIn
            // 
            this.lblUPIn.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUPIn.Location = new System.Drawing.Point(23, 224);
            this.lblUPIn.Name = "lblUPIn";
            this.lblUPIn.Size = new System.Drawing.Size(122, 32);
            this.lblUPIn.TabIndex = 12;
            this.lblUPIn.Text = "ទិញចូល";
            this.lblUPIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUPIn
            // 
            this.txtUPIn.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUPIn.Location = new System.Drawing.Point(151, 221);
            this.txtUPIn.Name = "txtUPIn";
            this.txtUPIn.Size = new System.Drawing.Size(230, 36);
            this.txtUPIn.TabIndex = 13;
            this.txtUPIn.Text = "0.00";
            this.txtUPIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUPIn.Leave += new System.EventHandler(this.txtUPIn_Leave);
            this.txtUPIn.Enter += new System.EventHandler(this.txtUPIn_Enter);
            // 
            // lblUPOut
            // 
            this.lblUPOut.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUPOut.Location = new System.Drawing.Point(23, 301);
            this.lblUPOut.Name = "lblUPOut";
            this.lblUPOut.Size = new System.Drawing.Size(122, 31);
            this.lblUPOut.TabIndex = 18;
            this.lblUPOut.Text = "លក់ចេញ";
            this.lblUPOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUPOut
            // 
            this.txtUPOut.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUPOut.Location = new System.Drawing.Point(151, 297);
            this.txtUPOut.Name = "txtUPOut";
            this.txtUPOut.Size = new System.Drawing.Size(230, 36);
            this.txtUPOut.TabIndex = 19;
            this.txtUPOut.Text = "0.00";
            this.txtUPOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUPOut.Leave += new System.EventHandler(this.txtUPOut_Leave);
            this.txtUPOut.Enter += new System.EventHandler(this.txtUPOut_Enter);
            this.txtUPOut.Validating += new System.ComponentModel.CancelEventHandler(this.txtUPOut_Validating);
            // 
            // lblExtraPercentage
            // 
            this.lblExtraPercentage.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtraPercentage.Location = new System.Drawing.Point(24, 264);
            this.lblExtraPercentage.Name = "lblExtraPercentage";
            this.lblExtraPercentage.Size = new System.Drawing.Size(121, 28);
            this.lblExtraPercentage.TabIndex = 14;
            this.lblExtraPercentage.Text = "% បន្ថែម";
            this.lblExtraPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtExtraPercentage
            // 
            this.txtExtraPercentage.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtraPercentage.Location = new System.Drawing.Point(151, 259);
            this.txtExtraPercentage.Name = "txtExtraPercentage";
            this.txtExtraPercentage.Size = new System.Drawing.Size(70, 36);
            this.txtExtraPercentage.TabIndex = 15;
            this.txtExtraPercentage.Text = "0";
            this.txtExtraPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExtraPercentage.Leave += new System.EventHandler(this.txtExtraPercentage_Leave);
            this.txtExtraPercentage.Enter += new System.EventHandler(this.txtExtraPercentage_Enter);
            // 
            // lblQtyInStock
            // 
            this.lblQtyInStock.AutoSize = true;
            this.lblQtyInStock.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyInStock.Location = new System.Drawing.Point(71, 352);
            this.lblQtyInStock.Name = "lblQtyInStock";
            this.lblQtyInStock.Size = new System.Drawing.Size(74, 30);
            this.lblQtyInStock.TabIndex = 22;
            this.lblQtyInStock.Text = "នៅសល់";
            // 
            // txtQtyInStock
            // 
            this.txtQtyInStock.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtyInStock.Location = new System.Drawing.Point(151, 346);
            this.txtQtyInStock.Name = "txtQtyInStock";
            this.txtQtyInStock.Size = new System.Drawing.Size(230, 36);
            this.txtQtyInStock.TabIndex = 23;
            this.txtQtyInStock.Text = "1";
            this.txtQtyInStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyInStock.Leave += new System.EventHandler(this.txtQtyInStock_Leave);
            this.txtQtyInStock.Enter += new System.EventHandler(this.txtQtyInStock_Enter);
            // 
            // lblDiscount
            // 
            this.lblDiscount.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(227, 262);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(78, 33);
            this.lblDiscount.TabIndex = 16;
            this.lblDiscount.Text = "% បញ្ចុះ";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(311, 259);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(70, 36);
            this.txtDiscount.TabIndex = 17;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
            this.txtDiscount.Enter += new System.EventHandler(this.txtDiscount_Enter);
            // 
            // grbLine_1
            // 
            this.grbLine_1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_1.Location = new System.Drawing.Point(29, 214);
            this.grbLine_1.Name = "grbLine_1";
            this.grbLine_1.Size = new System.Drawing.Size(352, 2);
            this.grbLine_1.TabIndex = 11;
            this.grbLine_1.TabStop = false;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody.Controls.Add(this.cmbProduct);
            this.pnlBody.Controls.Add(this.txtForeignCode);
            this.pnlBody.Controls.Add(this.lblProductCode);
            this.pnlBody.Controls.Add(this.lblSize);
            this.pnlBody.Controls.Add(this.cmbSize);
            this.pnlBody.Controls.Add(this.lblQty);
            this.pnlBody.Controls.Add(this.label3);
            this.pnlBody.Controls.Add(this.grbLine_1);
            this.pnlBody.Controls.Add(this.txtDiscount);
            this.pnlBody.Controls.Add(this.lblDiscount);
            this.pnlBody.Controls.Add(this.txtQtyInStock);
            this.pnlBody.Controls.Add(this.lblQtyInStock);
            this.pnlBody.Controls.Add(this.txtExtraPercentage);
            this.pnlBody.Controls.Add(this.lblExtraPercentage);
            this.pnlBody.Controls.Add(this.txtUPOut);
            this.pnlBody.Controls.Add(this.lblUPOut);
            this.pnlBody.Controls.Add(this.txtUPIn);
            this.pnlBody.Controls.Add(this.lblUPIn);
            this.pnlBody.Controls.Add(this.ptbProduct);
            this.pnlBody.Controls.Add(this.txtPhotoPath);
            this.pnlBody.Controls.Add(this.cmbColor);
            this.pnlBody.Controls.Add(this.lblColor);
            this.pnlBody.Controls.Add(this.cmbMark);
            this.pnlBody.Controls.Add(this.lblMark);
            this.pnlBody.Controls.Add(this.cmbCategory);
            this.pnlBody.Controls.Add(this.lblCategory);
            this.pnlBody.Controls.Add(this.groupBox1);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBody.Location = new System.Drawing.Point(0, 89);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(695, 400);
            this.pnlBody.TabIndex = 1;
            // 
            // txtForeignCode
            // 
            this.txtForeignCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtForeignCode.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtForeignCode.Location = new System.Drawing.Point(151, 19);
            this.txtForeignCode.Name = "txtForeignCode";
            this.txtForeignCode.Size = new System.Drawing.Size(230, 36);
            this.txtForeignCode.TabIndex = 1;
            this.txtForeignCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtForeignCode.Leave += new System.EventHandler(this.txtProductCode_Leave);
            this.txtForeignCode.Enter += new System.EventHandler(this.txtProductCode_Enter);
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCode.Location = new System.Drawing.Point(71, 25);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(74, 30);
            this.lblProductCode.TabIndex = 0;
            this.lblProductCode.Text = "លេខកូដ";
            // 
            // lblSize
            // 
            this.lblSize.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(76, 176);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(70, 28);
            this.lblSize.TabIndex = 8;
            this.lblSize.Text = "ទំហំ";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSize
            // 
            this.cmbSize.BackColor = System.Drawing.SystemColors.Info;
            this.cmbSize.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Location = new System.Drawing.Point(151, 171);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(230, 36);
            this.cmbSize.TabIndex = 9;
            this.cmbSize.Leave += new System.EventHandler(this.cmbSize_Leave);
            this.cmbSize.Enter += new System.EventHandler(this.cmbSize_Enter);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(23, 324);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(77, 29);
            this.lblQty.TabIndex = 20;
            this.lblQty.Text = "បរិមាណ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "តំលៃ";
            // 
            // cmbColor
            // 
            this.cmbColor.BackColor = System.Drawing.SystemColors.Info;
            this.cmbColor.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(151, 133);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(230, 36);
            this.cmbColor.TabIndex = 7;
            this.cmbColor.Leave += new System.EventHandler(this.cmbColor_Leave);
            this.cmbColor.Enter += new System.EventHandler(this.cmbColor_Enter);
            // 
            // cmbMark
            // 
            this.cmbMark.BackColor = System.Drawing.SystemColors.Info;
            this.cmbMark.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMark.FormattingEnabled = true;
            this.cmbMark.Location = new System.Drawing.Point(151, 95);
            this.cmbMark.Name = "cmbMark";
            this.cmbMark.Size = new System.Drawing.Size(230, 36);
            this.cmbMark.TabIndex = 5;
            this.cmbMark.Leave += new System.EventHandler(this.cmbMark_Leave);
            this.cmbMark.Enter += new System.EventHandler(this.cmbMark_Enter);
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.SystemColors.Info;
            this.cmbCategory.DropDownWidth = 230;
            this.cmbCategory.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(151, 57);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(230, 36);
            this.cmbCategory.TabIndex = 3;
            this.cmbCategory.Leave += new System.EventHandler(this.cmbCategory_Leave);
            this.cmbCategory.Enter += new System.EventHandler(this.cmbCategory_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Location = new System.Drawing.Point(99, 339);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 2);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
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
            this.pnlHeader.TabIndex = 103;
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
            this.lblProductName.TabIndex = 0;
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackgroundImage = global::EzPos.Properties.Resources.background_5;
            this.pnlFooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFooter.Controls.Add(this.btnAdjustment);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 489);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(695, 48);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnAdjustment
            // 
            this.btnAdjustment.BackColor = System.Drawing.Color.Transparent;
            this.btnAdjustment.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnAdjustment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdjustment.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdjustment.ForeColor = System.Drawing.Color.White;
            this.btnAdjustment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdjustment.Location = new System.Drawing.Point(21, 10);
            this.btnAdjustment.Name = "btnAdjustment";
            this.btnAdjustment.Size = new System.Drawing.Size(116, 35);
            this.btnAdjustment.TabIndex = 0;
            this.btnAdjustment.Text = "ដកពីឃ្លាំង";
            this.btnAdjustment.UseVisualStyleBackColor = false;
            this.btnAdjustment.MouseLeave += new System.EventHandler(this.btnAdjustment_MouseLeave);
            this.btnAdjustment.Click += new System.EventHandler(this.btnAdjustment_Click);
            this.btnAdjustment.MouseEnter += new System.EventHandler(this.btnAdjustment_MouseEnter);
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
            this.btnCancel.Location = new System.Drawing.Point(555, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 35);
            this.btnCancel.TabIndex = 2;
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
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::EzPos.Properties.Resources.OK32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(438, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "យល់ព្រម";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.btnSave_MouseEnter);
            // 
            // cmsCatalog
            // 
            this.cmsCatalog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmIndividual,
            this.tmsGroup,
            this.tsmAll,
            this.tsmImport});
            this.cmsCatalog.Name = "cmsCatalog";
            this.cmsCatalog.ShowItemToolTips = false;
            this.cmsCatalog.Size = new System.Drawing.Size(232, 124);
            // 
            // tsmIndividual
            // 
            this.tsmIndividual.Font = new System.Drawing.Font("Khmer OS System", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmIndividual.Name = "tsmIndividual";
            this.tsmIndividual.Size = new System.Drawing.Size(231, 30);
            this.tsmIndividual.Text = "ជ្រើសរើសម្ដងមួយ";
            this.tsmIndividual.Click += new System.EventHandler(this.tsmIndividual_Click);
            // 
            // tmsGroup
            // 
            this.tmsGroup.Font = new System.Drawing.Font("Khmer OS System", 10F, System.Drawing.FontStyle.Bold);
            this.tmsGroup.Name = "tmsGroup";
            this.tmsGroup.Size = new System.Drawing.Size(231, 30);
            this.tmsGroup.Text = "ជ្រើសរើសមួយចំនួន";
            this.tmsGroup.Click += new System.EventHandler(this.tmsGroup_Click);
            // 
            // tsmAll
            // 
            this.tsmAll.Font = new System.Drawing.Font("Khmer OS System", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmAll.Name = "tsmAll";
            this.tsmAll.Size = new System.Drawing.Size(231, 30);
            this.tsmAll.Text = "ជ្រើសរើសម្ដងទាំងអស់";
            this.tsmAll.Click += new System.EventHandler(this.tsmAll_Click);
            // 
            // tsmImport
            // 
            this.tsmImport.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmImport.Name = "tsmImport";
            this.tsmImport.Size = new System.Drawing.Size(231, 30);
            this.tsmImport.Text = "នាំចូលមកពីឃ្លាំង";
            this.tsmImport.Click += new System.EventHandler(this.tsmImport_Click);
            // 
            // txtPhotoPath
            // 
            this.txtPhotoPath.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhotoPath.Location = new System.Drawing.Point(395, 203);
            this.txtPhotoPath.Name = "txtPhotoPath";
            this.txtPhotoPath.Size = new System.Drawing.Size(230, 26);
            this.txtPhotoPath.TabIndex = 25;
            this.txtPhotoPath.Visible = false;
            // 
            // ptbProduct
            // 
            this.ptbProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbProduct.Location = new System.Drawing.Point(392, 19);
            this.ptbProduct.Name = "ptbProduct";
            this.ptbProduct.Size = new System.Drawing.Size(279, 363);
            this.ptbProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbProduct.TabIndex = 101;
            this.ptbProduct.TabStop = false;
            this.ptbProduct.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptbProduct_MouseClick);
            // 
            // cmbProduct
            // 
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(392, 19);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(279, 30);
            this.cmbProduct.Sorted = true;
            this.cmbProduct.TabIndex = 0;
            this.cmbProduct.Visible = false;
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged);
            // 
            // FrmCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(695, 537);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCatalog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product";
            this.Load += new System.EventHandler(this.FrmProduct_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmProductAdvance_FormClosing);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.cmsCatalog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCategory;
        private ExtendedComboBox cmbCategory;
        private System.Windows.Forms.Label lblMark;
        private ExtendedComboBox cmbMark;
        private System.Windows.Forms.Label lblColor;
        private ExtendedComboBox cmbColor;
        private System.Windows.Forms.Label lblUPIn;
        private System.Windows.Forms.TextBox txtUPIn;
        private System.Windows.Forms.Label lblUPOut;
        private System.Windows.Forms.TextBox txtUPOut;
        private System.Windows.Forms.Label lblExtraPercentage;
        private System.Windows.Forms.TextBox txtExtraPercentage;
        private System.Windows.Forms.Label lblQtyInStock;
        private System.Windows.Forms.TextBox txtQtyInStock;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.GroupBox grbLine_1;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ContextMenuStrip cmsCatalog;
        private System.Windows.Forms.ToolStripMenuItem tsmIndividual;
        private System.Windows.Forms.ToolStripMenuItem tsmAll;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.ToolStripMenuItem tmsGroup;
        private System.Windows.Forms.Button btnAdjustment;
        private System.Windows.Forms.Label lblSize;
        private ExtendedComboBox cmbSize;
        private System.Windows.Forms.ToolStripMenuItem tsmImport;
        private System.Windows.Forms.TextBox txtForeignCode;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.PictureBox ptbProduct;
        private System.Windows.Forms.TextBox txtPhotoPath;
    }
}