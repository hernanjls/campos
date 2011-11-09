using EzPos.GUIs.Components;

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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.txtForeignCode = new System.Windows.Forms.TextBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.cmbSize = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.lblQty = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ptbProduct = new System.Windows.Forms.PictureBox();
            this.txtPhotoPath = new System.Windows.Forms.TextBox();
            this.cmbColor = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.cmbMark = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.cmbCategory = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblProductName = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnAdjustment = new EzPos.GUIs.Components.ExtendedButton(this.components);
            this.btnCancel = new EzPos.GUIs.Components.ExtendedButton(this.components);
            this.btnSave = new EzPos.GUIs.Components.ExtendedButton(this.components);
            this.cmsCatalog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmIndividual = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmImport = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPromotion = new System.Windows.Forms.Label();
            this.txtQtyPromotion = new System.Windows.Forms.TextBox();
            this.lblQtyPromotion = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblQtyBonus = new System.Windows.Forms.Label();
            this.txtQtyBonus = new System.Windows.Forms.TextBox();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbProduct)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.cmsCatalog.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCategory
            // 
            this.lblCategory.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(25, 58);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(122, 38);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "ប្រភេទ";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMark
            // 
            this.lblMark.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMark.Location = new System.Drawing.Point(25, 101);
            this.lblMark.Name = "lblMark";
            this.lblMark.Size = new System.Drawing.Size(122, 28);
            this.lblMark.TabIndex = 4;
            this.lblMark.Text = "ម៉ាក";
            this.lblMark.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblColor
            // 
            this.lblColor.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(26, 139);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(122, 28);
            this.lblColor.TabIndex = 6;
            this.lblColor.Text = "ពណ៍";
            this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUPIn
            // 
            this.lblUPIn.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUPIn.Location = new System.Drawing.Point(25, 312);
            this.lblUPIn.Name = "lblUPIn";
            this.lblUPIn.Size = new System.Drawing.Size(122, 32);
            this.lblUPIn.TabIndex = 14;
            this.lblUPIn.Text = "ទិញចូល";
            this.lblUPIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUPIn
            // 
            this.txtUPIn.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUPIn.Location = new System.Drawing.Point(153, 309);
            this.txtUPIn.Name = "txtUPIn";
            this.txtUPIn.Size = new System.Drawing.Size(266, 36);
            this.txtUPIn.TabIndex = 15;
            this.txtUPIn.Text = "0.00";
            this.txtUPIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUPIn.Leave += new System.EventHandler(this.TxtUpInLeave);
            this.txtUPIn.Enter += new System.EventHandler(this.TxtUpInEnter);
            // 
            // lblUPOut
            // 
            this.lblUPOut.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUPOut.Location = new System.Drawing.Point(25, 389);
            this.lblUPOut.Name = "lblUPOut";
            this.lblUPOut.Size = new System.Drawing.Size(122, 31);
            this.lblUPOut.TabIndex = 20;
            this.lblUPOut.Text = "លក់ចេញ";
            this.lblUPOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUPOut
            // 
            this.txtUPOut.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUPOut.Location = new System.Drawing.Point(153, 385);
            this.txtUPOut.Name = "txtUPOut";
            this.txtUPOut.Size = new System.Drawing.Size(266, 36);
            this.txtUPOut.TabIndex = 21;
            this.txtUPOut.Text = "0.00";
            this.txtUPOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUPOut.Leave += new System.EventHandler(this.TxtUpOutLeave);
            this.txtUPOut.Enter += new System.EventHandler(this.TxtUpOutEnter);
            this.txtUPOut.Validating += new System.ComponentModel.CancelEventHandler(this.TxtUpOutValidating);
            // 
            // lblExtraPercentage
            // 
            this.lblExtraPercentage.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtraPercentage.Location = new System.Drawing.Point(26, 352);
            this.lblExtraPercentage.Name = "lblExtraPercentage";
            this.lblExtraPercentage.Size = new System.Drawing.Size(121, 28);
            this.lblExtraPercentage.TabIndex = 16;
            this.lblExtraPercentage.Text = "% បន្ថែម";
            this.lblExtraPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtExtraPercentage
            // 
            this.txtExtraPercentage.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtraPercentage.Location = new System.Drawing.Point(153, 347);
            this.txtExtraPercentage.Name = "txtExtraPercentage";
            this.txtExtraPercentage.Size = new System.Drawing.Size(85, 36);
            this.txtExtraPercentage.TabIndex = 17;
            this.txtExtraPercentage.Text = "0";
            this.txtExtraPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExtraPercentage.Leave += new System.EventHandler(this.TxtExtraPercentageLeave);
            this.txtExtraPercentage.Enter += new System.EventHandler(this.TxtExtraPercentageEnter);
            // 
            // lblQtyInStock
            // 
            this.lblQtyInStock.AutoSize = true;
            this.lblQtyInStock.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyInStock.Location = new System.Drawing.Point(73, 440);
            this.lblQtyInStock.Name = "lblQtyInStock";
            this.lblQtyInStock.Size = new System.Drawing.Size(74, 30);
            this.lblQtyInStock.TabIndex = 24;
            this.lblQtyInStock.Text = "នៅសល់";
            // 
            // txtQtyInStock
            // 
            this.txtQtyInStock.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtyInStock.Location = new System.Drawing.Point(153, 434);
            this.txtQtyInStock.Name = "txtQtyInStock";
            this.txtQtyInStock.Size = new System.Drawing.Size(266, 36);
            this.txtQtyInStock.TabIndex = 25;
            this.txtQtyInStock.Text = "1";
            this.txtQtyInStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyInStock.Leave += new System.EventHandler(this.TxtQtyInStockLeave);
            this.txtQtyInStock.Enter += new System.EventHandler(this.TxtQtyInStockEnter);
            // 
            // lblDiscount
            // 
            this.lblDiscount.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(244, 350);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(78, 33);
            this.lblDiscount.TabIndex = 18;
            this.lblDiscount.Text = "% បញ្ចុះ";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(330, 347);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(89, 36);
            this.txtDiscount.TabIndex = 19;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.Leave += new System.EventHandler(this.TxtDiscountLeave);
            this.txtDiscount.Enter += new System.EventHandler(this.TxtDiscountEnter);
            // 
            // grbLine_1
            // 
            this.grbLine_1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_1.Location = new System.Drawing.Point(31, 302);
            this.grbLine_1.Name = "grbLine_1";
            this.grbLine_1.Size = new System.Drawing.Size(388, 2);
            this.grbLine_1.TabIndex = 13;
            this.grbLine_1.TabStop = false;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody.Controls.Add(this.txtQtyBonus);
            this.pnlBody.Controls.Add(this.lblQtyBonus);
            this.pnlBody.Controls.Add(this.lblPromotion);
            this.pnlBody.Controls.Add(this.txtQtyPromotion);
            this.pnlBody.Controls.Add(this.lblQtyPromotion);
            this.pnlBody.Controls.Add(this.groupBox2);
            this.pnlBody.Controls.Add(this.txtDescription);
            this.pnlBody.Controls.Add(this.label1);
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
            this.pnlBody.Size = new System.Drawing.Size(831, 543);
            this.pnlBody.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.Info;
            this.txtDescription.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(153, 210);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(266, 86);
            this.txtDescription.TabIndex = 11;
            this.txtDescription.Leave += new System.EventHandler(this.TxtDescriptionLeave);
            this.txtDescription.Enter += new System.EventHandler(this.TxtDescriptionEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 30);
            this.label1.TabIndex = 10;
            this.label1.Text = "បរិយាយ";
            // 
            // cmbProduct
            // 
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(429, 20);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(279, 30);
            this.cmbProduct.Sorted = true;
            this.cmbProduct.TabIndex = 26;
            this.cmbProduct.Visible = false;
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.CmbProductSelectedIndexChanged);
            // 
            // txtForeignCode
            // 
            this.txtForeignCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtForeignCode.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtForeignCode.Location = new System.Drawing.Point(153, 20);
            this.txtForeignCode.Name = "txtForeignCode";
            this.txtForeignCode.Size = new System.Drawing.Size(266, 36);
            this.txtForeignCode.TabIndex = 1;
            this.txtForeignCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtForeignCode.Leave += new System.EventHandler(this.TxtProductCodeLeave);
            this.txtForeignCode.Enter += new System.EventHandler(this.TxtProductCodeEnter);
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCode.Location = new System.Drawing.Point(73, 26);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(74, 30);
            this.lblProductCode.TabIndex = 0;
            this.lblProductCode.Text = "លេខកូដ";
            // 
            // lblSize
            // 
            this.lblSize.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(78, 177);
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
            this.cmbSize.Location = new System.Drawing.Point(153, 172);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(266, 36);
            this.cmbSize.TabIndex = 9;
            this.cmbSize.Leave += new System.EventHandler(this.CmbSizeLeave);
            this.cmbSize.Enter += new System.EventHandler(this.CmbSizeEnter);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(25, 412);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(77, 29);
            this.lblQty.TabIndex = 22;
            this.lblQty.Text = "បរិមាណ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 29);
            this.label3.TabIndex = 12;
            this.label3.Text = "តំលៃ";
            // 
            // ptbProduct
            // 
            this.ptbProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbProduct.Location = new System.Drawing.Point(427, 20);
            this.ptbProduct.Name = "ptbProduct";
            this.ptbProduct.Size = new System.Drawing.Size(377, 501);
            this.ptbProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbProduct.TabIndex = 101;
            this.ptbProduct.TabStop = false;
            this.ptbProduct.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PtbProductMouseClick);
            // 
            // txtPhotoPath
            // 
            this.txtPhotoPath.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhotoPath.Location = new System.Drawing.Point(427, 204);
            this.txtPhotoPath.Name = "txtPhotoPath";
            this.txtPhotoPath.Size = new System.Drawing.Size(230, 26);
            this.txtPhotoPath.TabIndex = 27;
            this.txtPhotoPath.Visible = false;
            // 
            // cmbColor
            // 
            this.cmbColor.BackColor = System.Drawing.SystemColors.Info;
            this.cmbColor.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(153, 134);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(266, 36);
            this.cmbColor.TabIndex = 7;
            this.cmbColor.Leave += new System.EventHandler(this.CmbColorLeave);
            this.cmbColor.Enter += new System.EventHandler(this.CmbColorEnter);
            // 
            // cmbMark
            // 
            this.cmbMark.BackColor = System.Drawing.SystemColors.Info;
            this.cmbMark.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMark.FormattingEnabled = true;
            this.cmbMark.Location = new System.Drawing.Point(153, 96);
            this.cmbMark.Name = "cmbMark";
            this.cmbMark.Size = new System.Drawing.Size(266, 36);
            this.cmbMark.TabIndex = 5;
            this.cmbMark.Leave += new System.EventHandler(this.CmbMarkLeave);
            this.cmbMark.Enter += new System.EventHandler(this.CmbMarkEnter);
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.SystemColors.Info;
            this.cmbCategory.DropDownWidth = 230;
            this.cmbCategory.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(153, 58);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(266, 36);
            this.cmbCategory.TabIndex = 3;
            this.cmbCategory.Leave += new System.EventHandler(this.CmbCategoryLeave);
            this.cmbCategory.Enter += new System.EventHandler(this.CmbCategoryEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Location = new System.Drawing.Point(101, 427);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 2);
            this.groupBox1.TabIndex = 23;
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
            this.pnlHeader.Size = new System.Drawing.Size(831, 89);
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
            this.lblProductName.Size = new System.Drawing.Size(831, 89);
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
            this.pnlFooter.Location = new System.Drawing.Point(0, 632);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(831, 48);
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
            this.btnAdjustment.Click += new System.EventHandler(this.BtnAdjustmentClick);
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
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
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
            this.tsmIndividual.Click += new System.EventHandler(this.TsmIndividualClick);
            // 
            // tmsGroup
            // 
            this.tmsGroup.Font = new System.Drawing.Font("Khmer OS System", 10F, System.Drawing.FontStyle.Bold);
            this.tmsGroup.Name = "tmsGroup";
            this.tmsGroup.Size = new System.Drawing.Size(231, 30);
            this.tmsGroup.Text = "ជ្រើសរើសមួយចំនួន";
            this.tmsGroup.Click += new System.EventHandler(this.TmsGroupClick);
            // 
            // tsmAll
            // 
            this.tsmAll.Font = new System.Drawing.Font("Khmer OS System", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmAll.Name = "tsmAll";
            this.tsmAll.Size = new System.Drawing.Size(231, 30);
            this.tsmAll.Text = "ជ្រើសរើសម្ដងទាំងអស់";
            this.tsmAll.Click += new System.EventHandler(this.TsmAllClick);
            // 
            // tsmImport
            // 
            this.tsmImport.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmImport.Name = "tsmImport";
            this.tsmImport.Size = new System.Drawing.Size(231, 30);
            this.tsmImport.Text = "នាំចូលមកពីឃ្លាំង";
            this.tsmImport.Click += new System.EventHandler(this.TsmImportClick);
            // 
            // lblPromotion
            // 
            this.lblPromotion.AutoSize = true;
            this.lblPromotion.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromotion.Location = new System.Drawing.Point(25, 463);
            this.lblPromotion.Name = "lblPromotion";
            this.lblPromotion.Size = new System.Drawing.Size(117, 29);
            this.lblPromotion.TabIndex = 102;
            this.lblPromotion.Text = "កម្មវិធីពិសេស";
            // 
            // txtQtyPromotion
            // 
            this.txtQtyPromotion.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtyPromotion.Location = new System.Drawing.Point(153, 485);
            this.txtQtyPromotion.Name = "txtQtyPromotion";
            this.txtQtyPromotion.Size = new System.Drawing.Size(110, 36);
            this.txtQtyPromotion.TabIndex = 105;
            this.txtQtyPromotion.Text = "0";
            this.txtQtyPromotion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyPromotion.Leave += new System.EventHandler(this.TxtQtyPromotionLeave);
            this.txtQtyPromotion.Enter += new System.EventHandler(this.TxtQtyPromotionEnter);
            // 
            // lblQtyPromotion
            // 
            this.lblQtyPromotion.AutoSize = true;
            this.lblQtyPromotion.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyPromotion.Location = new System.Drawing.Point(73, 491);
            this.lblQtyPromotion.Name = "lblQtyPromotion";
            this.lblQtyPromotion.Size = new System.Drawing.Size(73, 30);
            this.lblQtyPromotion.TabIndex = 104;
            this.lblQtyPromotion.Text = "ទិញអស់";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox2.Location = new System.Drawing.Point(101, 478);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 2);
            this.groupBox2.TabIndex = 103;
            this.groupBox2.TabStop = false;
            // 
            // lblQtyBonus
            // 
            this.lblQtyBonus.AutoSize = true;
            this.lblQtyBonus.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyBonus.Location = new System.Drawing.Point(269, 491);
            this.lblQtyBonus.Name = "lblQtyBonus";
            this.lblQtyBonus.Size = new System.Drawing.Size(44, 30);
            this.lblQtyBonus.TabIndex = 106;
            this.lblQtyBonus.Text = "ថែម";
            // 
            // txtQtyBonus
            // 
            this.txtQtyBonus.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtyBonus.Location = new System.Drawing.Point(309, 485);
            this.txtQtyBonus.Name = "txtQtyBonus";
            this.txtQtyBonus.Size = new System.Drawing.Size(110, 36);
            this.txtQtyBonus.TabIndex = 107;
            this.txtQtyBonus.Text = "0";
            this.txtQtyBonus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyBonus.Leave += new System.EventHandler(this.TxtQtyBonusLeave);
            this.txtQtyBonus.Enter += new System.EventHandler(this.TxtQtyBonusEnter);
            // 
            // FrmCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(831, 680);
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
            ((System.ComponentModel.ISupportInitialize)(this.ptbProduct)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.cmsCatalog.ResumeLayout(false);
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
        private ExtendedButton btnCancel;
        private ExtendedButton btnSave;
        private System.Windows.Forms.ContextMenuStrip cmsCatalog;
        private System.Windows.Forms.ToolStripMenuItem tsmIndividual;
        private System.Windows.Forms.ToolStripMenuItem tsmAll;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.ToolStripMenuItem tmsGroup;
        private ExtendedButton btnAdjustment;
        private System.Windows.Forms.Label lblSize;
        private ExtendedComboBox cmbSize;
        private System.Windows.Forms.ToolStripMenuItem tsmImport;
        private System.Windows.Forms.TextBox txtForeignCode;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.PictureBox ptbProduct;
        private System.Windows.Forms.TextBox txtPhotoPath;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQtyBonus;
        private System.Windows.Forms.Label lblQtyBonus;
        private System.Windows.Forms.Label lblPromotion;
        private System.Windows.Forms.TextBox txtQtyPromotion;
        private System.Windows.Forms.Label lblQtyPromotion;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}