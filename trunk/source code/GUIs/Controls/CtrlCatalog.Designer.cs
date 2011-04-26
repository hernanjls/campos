using ExtendedComboBox = EzPos.GUIs.Components.ExtendedComboBox;

namespace EzPos.GUIs.Controls
{
    partial class CtrlCatalog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBodyRight = new System.Windows.Forms.Panel();
            this.lblPrice = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.extraPercentageLbl = new System.Windows.Forms.Label();
            this.UPOutLbl = new System.Windows.Forms.Label();
            this.lblUPOut = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblExtraPercentage = new System.Windows.Forms.Label();
            this.UPInLbl = new System.Windows.Forms.Label();
            this.lblUPIn = new System.Windows.Forms.Label();
            this.discountLbl = new System.Windows.Forms.Label();
            this.lblPrintProduct = new System.Windows.Forms.Label();
            this.grbPrintProduct = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.rdbPrintSelected = new System.Windows.Forms.RadioButton();
            this.rdbPrintAll = new System.Windows.Forms.RadioButton();
            this.rdbProduct = new System.Windows.Forms.RadioButton();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.ptbProduct = new System.Windows.Forms.PictureBox();
            this.pnlBodySearch = new System.Windows.Forms.Panel();
            this.lblResultInfo = new System.Windows.Forms.Label();
            this.chbInstockOnly = new System.Windows.Forms.CheckBox();
            this.chbDisplayPicture = new System.Windows.Forms.CheckBox();
            this.lblBarCode = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.cmbColor = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.lblColor = new System.Windows.Forms.Label();
            this.cmbMark = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.lblMark = new System.Windows.Forms.Label();
            this.cmbCategory = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmdSearchProduct = new System.Windows.Forms.Button();
            this.pnlBodyLeft = new System.Windows.Forms.Panel();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.PrintCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PublicQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductPic = new System.Windows.Forms.DataGridViewImageColumn();
            this.DisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPriceOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhotoPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPriceIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarkID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarkStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SkinID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SkinStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtySold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtraPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForeignCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBodyRight.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbPrintProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbProduct)).BeginInit();
            this.pnlBodySearch.SuspendLayout();
            this.pnlBodyLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBodyRight
            // 
            this.pnlBodyRight.BackgroundImage = global::EzPos.Properties.Resources.backgroud_12;
            this.pnlBodyRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBodyRight.Controls.Add(this.lblPrice);
            this.pnlBodyRight.Controls.Add(this.groupBox1);
            this.pnlBodyRight.Controls.Add(this.lblPrintProduct);
            this.pnlBodyRight.Controls.Add(this.grbPrintProduct);
            this.pnlBodyRight.Controls.Add(this.btnDelete);
            this.pnlBodyRight.Controls.Add(this.btnNew);
            this.pnlBodyRight.Controls.Add(this.ptbProduct);
            this.pnlBodyRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBodyRight.Location = new System.Drawing.Point(824, 0);
            this.pnlBodyRight.Name = "pnlBodyRight";
            this.pnlBodyRight.Size = new System.Drawing.Size(200, 591);
            this.pnlBodyRight.TabIndex = 0;
            // 
            // lblPrice
            // 
            this.lblPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblPrice.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.Yellow;
            this.lblPrice.Location = new System.Drawing.Point(10, 158);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(179, 35);
            this.lblPrice.TabIndex = 1;
            this.lblPrice.Text = "តំលៃ";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::EzPos.Properties.Resources.pnlBodyRight;
            this.groupBox1.Controls.Add(this.extraPercentageLbl);
            this.groupBox1.Controls.Add(this.UPOutLbl);
            this.groupBox1.Controls.Add(this.lblUPOut);
            this.groupBox1.Controls.Add(this.lblDiscount);
            this.groupBox1.Controls.Add(this.lblExtraPercentage);
            this.groupBox1.Controls.Add(this.UPInLbl);
            this.groupBox1.Controls.Add(this.lblUPIn);
            this.groupBox1.Controls.Add(this.discountLbl);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(10, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // extraPercentageLbl
            // 
            this.extraPercentageLbl.BackColor = System.Drawing.Color.Transparent;
            this.extraPercentageLbl.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extraPercentageLbl.ForeColor = System.Drawing.Color.White;
            this.extraPercentageLbl.Location = new System.Drawing.Point(8, 89);
            this.extraPercentageLbl.Name = "extraPercentageLbl";
            this.extraPercentageLbl.Size = new System.Drawing.Size(76, 27);
            this.extraPercentageLbl.TabIndex = 4;
            this.extraPercentageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UPOutLbl
            // 
            this.UPOutLbl.BackColor = System.Drawing.Color.Transparent;
            this.UPOutLbl.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UPOutLbl.ForeColor = System.Drawing.Color.White;
            this.UPOutLbl.Location = new System.Drawing.Point(82, 113);
            this.UPOutLbl.Name = "UPOutLbl";
            this.UPOutLbl.Size = new System.Drawing.Size(91, 27);
            this.UPOutLbl.TabIndex = 7;
            this.UPOutLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUPOut
            // 
            this.lblUPOut.AutoSize = true;
            this.lblUPOut.BackColor = System.Drawing.Color.Transparent;
            this.lblUPOut.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUPOut.ForeColor = System.Drawing.Color.Black;
            this.lblUPOut.Location = new System.Drawing.Point(6, 113);
            this.lblUPOut.Name = "lblUPOut";
            this.lblUPOut.Size = new System.Drawing.Size(79, 27);
            this.lblUPOut.TabIndex = 6;
            this.lblUPOut.Text = "លក់ចេញ";
            this.lblUPOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscount.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.Color.Black;
            this.lblDiscount.Location = new System.Drawing.Point(107, 63);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(65, 27);
            this.lblDiscount.TabIndex = 3;
            this.lblDiscount.Text = "%បញ្ចុះ";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblExtraPercentage
            // 
            this.lblExtraPercentage.AutoSize = true;
            this.lblExtraPercentage.BackColor = System.Drawing.Color.Transparent;
            this.lblExtraPercentage.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtraPercentage.ForeColor = System.Drawing.Color.Black;
            this.lblExtraPercentage.Location = new System.Drawing.Point(6, 63);
            this.lblExtraPercentage.Name = "lblExtraPercentage";
            this.lblExtraPercentage.Size = new System.Drawing.Size(69, 27);
            this.lblExtraPercentage.TabIndex = 2;
            this.lblExtraPercentage.Text = "%បន្ថែម";
            this.lblExtraPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UPInLbl
            // 
            this.UPInLbl.BackColor = System.Drawing.Color.Transparent;
            this.UPInLbl.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UPInLbl.ForeColor = System.Drawing.Color.White;
            this.UPInLbl.Location = new System.Drawing.Point(74, 37);
            this.UPInLbl.Name = "UPInLbl";
            this.UPInLbl.Size = new System.Drawing.Size(99, 27);
            this.UPInLbl.TabIndex = 1;
            this.UPInLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUPIn
            // 
            this.lblUPIn.AutoSize = true;
            this.lblUPIn.BackColor = System.Drawing.Color.Transparent;
            this.lblUPIn.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUPIn.ForeColor = System.Drawing.Color.Black;
            this.lblUPIn.Location = new System.Drawing.Point(6, 37);
            this.lblUPIn.Name = "lblUPIn";
            this.lblUPIn.Size = new System.Drawing.Size(72, 27);
            this.lblUPIn.TabIndex = 0;
            this.lblUPIn.Text = "ទិញចូល";
            this.lblUPIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // discountLbl
            // 
            this.discountLbl.BackColor = System.Drawing.Color.Transparent;
            this.discountLbl.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discountLbl.ForeColor = System.Drawing.Color.White;
            this.discountLbl.Location = new System.Drawing.Point(103, 89);
            this.discountLbl.Name = "discountLbl";
            this.discountLbl.Size = new System.Drawing.Size(70, 27);
            this.discountLbl.TabIndex = 5;
            this.discountLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrintProduct
            // 
            this.lblPrintProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblPrintProduct.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrintProduct.ForeColor = System.Drawing.Color.Yellow;
            this.lblPrintProduct.Location = new System.Drawing.Point(10, 303);
            this.lblPrintProduct.Name = "lblPrintProduct";
            this.lblPrintProduct.Size = new System.Drawing.Size(179, 35);
            this.lblPrintProduct.TabIndex = 3;
            this.lblPrintProduct.Text = "បោះពុម្ភ";
            // 
            // grbPrintProduct
            // 
            this.grbPrintProduct.BackgroundImage = global::EzPos.Properties.Resources.pnlBodyRight;
            this.grbPrintProduct.Controls.Add(this.btnPrint);
            this.grbPrintProduct.Controls.Add(this.rdbPrintSelected);
            this.grbPrintProduct.Controls.Add(this.rdbPrintAll);
            this.grbPrintProduct.Controls.Add(this.rdbProduct);
            this.grbPrintProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbPrintProduct.Location = new System.Drawing.Point(10, 302);
            this.grbPrintProduct.Name = "grbPrintProduct";
            this.grbPrintProduct.Size = new System.Drawing.Size(180, 166);
            this.grbPrintProduct.TabIndex = 2;
            this.grbPrintProduct.TabStop = false;
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
            this.btnPrint.Location = new System.Drawing.Point(18, 118);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(144, 40);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "បោះពុម្ភ";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.MouseLeave += new System.EventHandler(this.BtnPrintMouseLeave);
            this.btnPrint.Click += new System.EventHandler(this.BtnPrintClick);
            this.btnPrint.MouseEnter += new System.EventHandler(this.BtnPrintMouseEnter);
            // 
            // rdbPrintSelected
            // 
            this.rdbPrintSelected.AutoSize = true;
            this.rdbPrintSelected.BackColor = System.Drawing.Color.Transparent;
            this.rdbPrintSelected.Checked = true;
            this.rdbPrintSelected.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPrintSelected.ForeColor = System.Drawing.Color.Black;
            this.rdbPrintSelected.Location = new System.Drawing.Point(11, 37);
            this.rdbPrintSelected.Name = "rdbPrintSelected";
            this.rdbPrintSelected.Size = new System.Drawing.Size(130, 31);
            this.rdbPrintSelected.TabIndex = 1;
            this.rdbPrintSelected.TabStop = true;
            this.rdbPrintSelected.Text = "កូដជ្រើសរើស";
            this.rdbPrintSelected.UseVisualStyleBackColor = false;
            // 
            // rdbPrintAll
            // 
            this.rdbPrintAll.AutoSize = true;
            this.rdbPrintAll.BackColor = System.Drawing.Color.Transparent;
            this.rdbPrintAll.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPrintAll.ForeColor = System.Drawing.Color.Black;
            this.rdbPrintAll.Location = new System.Drawing.Point(11, 63);
            this.rdbPrintAll.Name = "rdbPrintAll";
            this.rdbPrintAll.Size = new System.Drawing.Size(114, 31);
            this.rdbPrintAll.TabIndex = 0;
            this.rdbPrintAll.Text = "កូដទាំងអស់";
            this.rdbPrintAll.UseVisualStyleBackColor = false;
            // 
            // rdbProduct
            // 
            this.rdbProduct.AutoSize = true;
            this.rdbProduct.BackColor = System.Drawing.Color.Transparent;
            this.rdbProduct.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbProduct.ForeColor = System.Drawing.Color.Black;
            this.rdbProduct.Location = new System.Drawing.Point(11, 89);
            this.rdbProduct.Name = "rdbProduct";
            this.rdbProduct.Size = new System.Drawing.Size(102, 31);
            this.rdbProduct.TabIndex = 3;
            this.rdbProduct.Text = "ផលិតផល";
            this.rdbProduct.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::EzPos.Properties.Resources.Delete32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(28, 560);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(144, 40);
            this.btnDelete.TabIndex = 5;
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
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "បង្កើតថ្មី";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.MouseLeave += new System.EventHandler(this.BtnNewMouseLeave);
            this.btnNew.Click += new System.EventHandler(this.BtnNewProductClick);
            this.btnNew.MouseEnter += new System.EventHandler(this.BtnNewMouseEnter);
            // 
            // ptbProduct
            // 
            this.ptbProduct.BackColor = System.Drawing.Color.Transparent;
            this.ptbProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbProduct.Cursor = System.Windows.Forms.Cursors.Default;
            this.ptbProduct.ImageLocation = "";
            this.ptbProduct.Location = new System.Drawing.Point(10, 0);
            this.ptbProduct.Name = "ptbProduct";
            this.ptbProduct.Size = new System.Drawing.Size(180, 156);
            this.ptbProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbProduct.TabIndex = 77;
            this.ptbProduct.TabStop = false;
            // 
            // pnlBodySearch
            // 
            this.pnlBodySearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBodySearch.Controls.Add(this.lblResultInfo);
            this.pnlBodySearch.Controls.Add(this.chbInstockOnly);
            this.pnlBodySearch.Controls.Add(this.chbDisplayPicture);
            this.pnlBodySearch.Controls.Add(this.lblBarCode);
            this.pnlBodySearch.Controls.Add(this.txtProductCode);
            this.pnlBodySearch.Controls.Add(this.btnReset);
            this.pnlBodySearch.Controls.Add(this.cmbColor);
            this.pnlBodySearch.Controls.Add(this.lblColor);
            this.pnlBodySearch.Controls.Add(this.cmbMark);
            this.pnlBodySearch.Controls.Add(this.lblMark);
            this.pnlBodySearch.Controls.Add(this.cmbCategory);
            this.pnlBodySearch.Controls.Add(this.lblCategory);
            this.pnlBodySearch.Controls.Add(this.cmdSearchProduct);
            this.pnlBodySearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBodySearch.Location = new System.Drawing.Point(0, 0);
            this.pnlBodySearch.Name = "pnlBodySearch";
            this.pnlBodySearch.Size = new System.Drawing.Size(824, 120);
            this.pnlBodySearch.TabIndex = 1;
            // 
            // lblResultInfo
            // 
            this.lblResultInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblResultInfo.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultInfo.Location = new System.Drawing.Point(23, 86);
            this.lblResultInfo.Name = "lblResultInfo";
            this.lblResultInfo.Size = new System.Drawing.Size(768, 30);
            this.lblResultInfo.TabIndex = 12;
            this.lblResultInfo.Click += new System.EventHandler(this.lblResultInfo_Click);
            // 
            // chbInstockOnly
            // 
            this.chbInstockOnly.AutoSize = true;
            this.chbInstockOnly.BackColor = System.Drawing.Color.Transparent;
            this.chbInstockOnly.Checked = true;
            this.chbInstockOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbInstockOnly.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbInstockOnly.Location = new System.Drawing.Point(456, 51);
            this.chbInstockOnly.Name = "chbInstockOnly";
            this.chbInstockOnly.Size = new System.Drawing.Size(86, 34);
            this.chbInstockOnly.TabIndex = 9;
            this.chbInstockOnly.Text = "ក្នុងស្តុក";
            this.chbInstockOnly.UseVisualStyleBackColor = false;
            this.chbInstockOnly.CheckedChanged += new System.EventHandler(this.ChbInstockOnlyCheckedChanged);
            // 
            // chbDisplayPicture
            // 
            this.chbDisplayPicture.AutoSize = true;
            this.chbDisplayPicture.BackColor = System.Drawing.Color.Transparent;
            this.chbDisplayPicture.Checked = true;
            this.chbDisplayPicture.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDisplayPicture.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbDisplayPicture.Location = new System.Drawing.Point(352, 50);
            this.chbDisplayPicture.Name = "chbDisplayPicture";
            this.chbDisplayPicture.Size = new System.Drawing.Size(81, 34);
            this.chbDisplayPicture.TabIndex = 8;
            this.chbDisplayPicture.Text = "រូបភាព";
            this.chbDisplayPicture.UseVisualStyleBackColor = false;
            this.chbDisplayPicture.CheckedChanged += new System.EventHandler(this.ChbDisplayPictureCheckedChanged);
            // 
            // lblBarCode
            // 
            this.lblBarCode.AutoSize = true;
            this.lblBarCode.BackColor = System.Drawing.Color.Transparent;
            this.lblBarCode.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarCode.Location = new System.Drawing.Point(23, 49);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(74, 30);
            this.lblBarCode.TabIndex = 6;
            this.lblBarCode.Text = "លេខកូដ";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(100, 49);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(184, 27);
            this.txtProductCode.TabIndex = 7;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::EzPos.Properties.Resources.Undo32;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnReset.Location = new System.Drawing.Point(607, 49);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(89, 28);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "&Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
            // 
            // cmbColor
            // 
            this.cmbColor.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(607, 13);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(184, 27);
            this.cmbColor.TabIndex = 5;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.BackColor = System.Drawing.Color.Transparent;
            this.lblColor.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(555, 12);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(49, 30);
            this.lblColor.TabIndex = 4;
            this.lblColor.Text = "ពណ៍";
            // 
            // cmbMark
            // 
            this.cmbMark.DropDownWidth = 180;
            this.cmbMark.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMark.FormattingEnabled = true;
            this.cmbMark.Location = new System.Drawing.Point(352, 13);
            this.cmbMark.Name = "cmbMark";
            this.cmbMark.Size = new System.Drawing.Size(184, 27);
            this.cmbMark.TabIndex = 3;
            // 
            // lblMark
            // 
            this.lblMark.AutoSize = true;
            this.lblMark.BackColor = System.Drawing.Color.Transparent;
            this.lblMark.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMark.Location = new System.Drawing.Point(305, 12);
            this.lblMark.Name = "lblMark";
            this.lblMark.Size = new System.Drawing.Size(43, 30);
            this.lblMark.TabIndex = 2;
            this.lblMark.Text = "ម៉ាក";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(100, 13);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(184, 27);
            this.cmbCategory.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.BackColor = System.Drawing.Color.Transparent;
            this.lblCategory.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(23, 12);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 30);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "ប្រភេទ";
            // 
            // cmdSearchProduct
            // 
            this.cmdSearchProduct.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearchProduct.Image = global::EzPos.Properties.Resources.Search32;
            this.cmdSearchProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearchProduct.Location = new System.Drawing.Point(702, 49);
            this.cmdSearchProduct.Name = "cmdSearchProduct";
            this.cmdSearchProduct.Size = new System.Drawing.Size(89, 28);
            this.cmdSearchProduct.TabIndex = 11;
            this.cmdSearchProduct.Text = "&Search";
            this.cmdSearchProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSearchProduct.UseVisualStyleBackColor = true;
            this.cmdSearchProduct.Click += new System.EventHandler(this.CmdSearchProductClick);
            // 
            // pnlBodyLeft
            // 
            this.pnlBodyLeft.Controls.Add(this.dgvProduct);
            this.pnlBodyLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBodyLeft.Location = new System.Drawing.Point(0, 120);
            this.pnlBodyLeft.Name = "pnlBodyLeft";
            this.pnlBodyLeft.Size = new System.Drawing.Size(824, 471);
            this.pnlBodyLeft.TabIndex = 2;
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            this.dgvProduct.AllowUserToResizeColumns = false;
            this.dgvProduct.AllowUserToResizeRows = false;
            this.dgvProduct.BackgroundColor = System.Drawing.Color.White;
            this.dgvProduct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvProduct.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProduct.ColumnHeadersHeight = 40;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PrintCheck,
            this.PublicQty,
            this.ProductPic,
            this.DisplayName,
            this.Description,
            this.QtyInStock,
            this.UnitPriceOut,
            this.DiscountPercentage,
            this.ProductID,
            this.PhotoPath,
            this.UnitPriceIn,
            this.CategoryID,
            this.CategoryStr,
            this.MarkID,
            this.MarkStr,
            this.ColorID,
            this.ColorStr,
            this.SkinID,
            this.SkinStr,
            this.SizeID,
            this.SizeStr,
            this.ProductNameCol,
            this.ProductCode,
            this.QtySold,
            this.ExtraPercentage,
            this.LastUpdate,
            this.ForeignCode});
            this.dgvProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduct.EnableHeadersVisualStyles = false;
            this.dgvProduct.GridColor = System.Drawing.Color.White;
            this.dgvProduct.Location = new System.Drawing.Point(0, 0);
            this.dgvProduct.MultiSelect = false;
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProduct.RowHeadersVisible = false;
            this.dgvProduct.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProduct.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Candara", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProduct.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.dgvProduct.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dgvProduct.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvProduct.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Maroon;
            this.dgvProduct.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduct.RowTemplate.Height = 100;
            this.dgvProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduct.Size = new System.Drawing.Size(824, 471);
            this.dgvProduct.TabIndex = 0;
            this.dgvProduct.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DgvProductScroll);
            this.dgvProduct.DoubleClick += new System.EventHandler(this.DgvProductDoubleClick);
            this.dgvProduct.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvProductDataError);
            this.dgvProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvProductKeyDown);
            this.dgvProduct.SelectionChanged += new System.EventHandler(this.DgvProductSelectionChanged);
            this.dgvProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProductCellContentClick);
            // 
            // PrintCheck
            // 
            this.PrintCheck.DataPropertyName = "PrintCheck";
            this.PrintCheck.HeaderText = "";
            this.PrintCheck.Name = "PrintCheck";
            this.PrintCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PrintCheck.Width = 25;
            // 
            // PublicQty
            // 
            this.PublicQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PublicQty.DataPropertyName = "PublicQty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PublicQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.PublicQty.HeaderText = "បោះពុម្ភ";
            this.PublicQty.Name = "PublicQty";
            this.PublicQty.ReadOnly = true;
            this.PublicQty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PublicQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PublicQty.Width = 85;
            // 
            // ProductPic
            // 
            this.ProductPic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductPic.DataPropertyName = "ProductPic";
            this.ProductPic.HeaderText = "រូបភាព";
            this.ProductPic.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ProductPic.Name = "ProductPic";
            this.ProductPic.ReadOnly = true;
            this.ProductPic.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductPic.Width = 102;
            // 
            // DisplayName
            // 
            this.DisplayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DisplayName.DataPropertyName = "DisplayName";
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DisplayName.DefaultCellStyle = dataGridViewCellStyle3;
            this.DisplayName.HeaderText = "បរិយាយ";
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.ReadOnly = true;
            this.DisplayName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DisplayName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Description.DataPropertyName = "Description";
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Description.DefaultCellStyle = dataGridViewCellStyle4;
            this.Description.HeaderText = "លក្ខណៈពិសេស";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Description.Visible = false;
            this.Description.Width = 300;
            // 
            // QtyInStock
            // 
            this.QtyInStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.QtyInStock.DataPropertyName = "QtyInStock";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.QtyInStock.DefaultCellStyle = dataGridViewCellStyle5;
            this.QtyInStock.HeaderText = "បរិមាណ";
            this.QtyInStock.Name = "QtyInStock";
            this.QtyInStock.ReadOnly = true;
            this.QtyInStock.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.QtyInStock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QtyInStock.Width = 85;
            // 
            // UnitPriceOut
            // 
            this.UnitPriceOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnitPriceOut.DataPropertyName = "UnitPriceOut";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.UnitPriceOut.DefaultCellStyle = dataGridViewCellStyle6;
            this.UnitPriceOut.HeaderText = "តំលៃលក់";
            this.UnitPriceOut.Name = "UnitPriceOut";
            this.UnitPriceOut.ReadOnly = true;
            this.UnitPriceOut.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UnitPriceOut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitPriceOut.Visible = false;
            // 
            // DiscountPercentage
            // 
            this.DiscountPercentage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DiscountPercentage.DataPropertyName = "DiscountPercentage";
            this.DiscountPercentage.HeaderText = "% បញ្ចុះ";
            this.DiscountPercentage.Name = "DiscountPercentage";
            this.DiscountPercentage.ReadOnly = true;
            this.DiscountPercentage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DiscountPercentage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DiscountPercentage.Visible = false;
            this.DiscountPercentage.Width = 120;
            // 
            // ProductID
            // 
            this.ProductID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductID.Visible = false;
            // 
            // PhotoPath
            // 
            this.PhotoPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PhotoPath.DataPropertyName = "PhotoPath";
            this.PhotoPath.HeaderText = "PhotoPath";
            this.PhotoPath.Name = "PhotoPath";
            this.PhotoPath.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PhotoPath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PhotoPath.Visible = false;
            // 
            // UnitPriceIn
            // 
            this.UnitPriceIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnitPriceIn.DataPropertyName = "UnitPriceIn";
            this.UnitPriceIn.HeaderText = "UnitPriceIn";
            this.UnitPriceIn.Name = "UnitPriceIn";
            this.UnitPriceIn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UnitPriceIn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitPriceIn.Visible = false;
            // 
            // CategoryID
            // 
            this.CategoryID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CategoryID.DataPropertyName = "CategoryID";
            this.CategoryID.HeaderText = "CategoryID";
            this.CategoryID.Name = "CategoryID";
            this.CategoryID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CategoryID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CategoryID.Visible = false;
            // 
            // CategoryStr
            // 
            this.CategoryStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CategoryStr.DataPropertyName = "CategoryStr";
            this.CategoryStr.HeaderText = "CategoryStr";
            this.CategoryStr.Name = "CategoryStr";
            this.CategoryStr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CategoryStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CategoryStr.Visible = false;
            // 
            // MarkID
            // 
            this.MarkID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MarkID.DataPropertyName = "MarkID";
            this.MarkID.HeaderText = "MarkID";
            this.MarkID.Name = "MarkID";
            this.MarkID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MarkID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MarkID.Visible = false;
            // 
            // MarkStr
            // 
            this.MarkStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MarkStr.DataPropertyName = "MarkStr";
            this.MarkStr.HeaderText = "MarkStr";
            this.MarkStr.Name = "MarkStr";
            this.MarkStr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MarkStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MarkStr.Visible = false;
            // 
            // ColorID
            // 
            this.ColorID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColorID.DataPropertyName = "ColorID";
            this.ColorID.HeaderText = "ColorID";
            this.ColorID.Name = "ColorID";
            this.ColorID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColorID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColorID.Visible = false;
            // 
            // ColorStr
            // 
            this.ColorStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColorStr.DataPropertyName = "ColorStr";
            this.ColorStr.HeaderText = "ColorStr";
            this.ColorStr.Name = "ColorStr";
            this.ColorStr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColorStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColorStr.Visible = false;
            // 
            // SkinID
            // 
            this.SkinID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SkinID.DataPropertyName = "SkinID";
            this.SkinID.HeaderText = "SkinID";
            this.SkinID.Name = "SkinID";
            this.SkinID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SkinID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SkinID.Visible = false;
            // 
            // SkinStr
            // 
            this.SkinStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SkinStr.DataPropertyName = "SkinStr";
            this.SkinStr.HeaderText = "SkinStr";
            this.SkinStr.Name = "SkinStr";
            this.SkinStr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SkinStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SkinStr.Visible = false;
            // 
            // SizeID
            // 
            this.SizeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SizeID.DataPropertyName = "SizeID";
            this.SizeID.HeaderText = "SizeID";
            this.SizeID.Name = "SizeID";
            this.SizeID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SizeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SizeID.Visible = false;
            // 
            // SizeStr
            // 
            this.SizeStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SizeStr.DataPropertyName = "SizeStr";
            this.SizeStr.HeaderText = "SizeStr";
            this.SizeStr.Name = "SizeStr";
            this.SizeStr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SizeStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SizeStr.Visible = false;
            // 
            // ProductNameCol
            // 
            this.ProductNameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductNameCol.DataPropertyName = "ProductName";
            this.ProductNameCol.HeaderText = "ProductName";
            this.ProductNameCol.Name = "ProductNameCol";
            this.ProductNameCol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductNameCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductNameCol.Visible = false;
            // 
            // ProductCode
            // 
            this.ProductCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductCode.DataPropertyName = "ProductCode";
            this.ProductCode.HeaderText = "ProductCode";
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductCode.Visible = false;
            // 
            // QtySold
            // 
            this.QtySold.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.QtySold.DataPropertyName = "QtySold";
            this.QtySold.HeaderText = "QtySold";
            this.QtySold.Name = "QtySold";
            this.QtySold.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.QtySold.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QtySold.Visible = false;
            // 
            // ExtraPercentage
            // 
            this.ExtraPercentage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ExtraPercentage.DataPropertyName = "ExtraPercentage";
            this.ExtraPercentage.HeaderText = "ExtraPercentage";
            this.ExtraPercentage.Name = "ExtraPercentage";
            this.ExtraPercentage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExtraPercentage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExtraPercentage.Visible = false;
            // 
            // LastUpdate
            // 
            this.LastUpdate.DataPropertyName = "LastUpdate";
            this.LastUpdate.HeaderText = "LastUpdate";
            this.LastUpdate.Name = "LastUpdate";
            this.LastUpdate.Visible = false;
            // 
            // ForeignCode
            // 
            this.ForeignCode.DataPropertyName = "ForeignCode";
            this.ForeignCode.HeaderText = "ForeignCode";
            this.ForeignCode.Name = "ForeignCode";
            this.ForeignCode.Visible = false;
            // 
            // CtrlCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBodyLeft);
            this.Controls.Add(this.pnlBodySearch);
            this.Controls.Add(this.pnlBodyRight);
            this.Name = "CtrlCatalog";
            this.Size = new System.Drawing.Size(1024, 591);
            this.Load += new System.EventHandler(this.CtrlCatalog_Load);
            this.pnlBodyRight.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbPrintProduct.ResumeLayout(false);
            this.grbPrintProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbProduct)).EndInit();
            this.pnlBodySearch.ResumeLayout(false);
            this.pnlBodySearch.PerformLayout();
            this.pnlBodyLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBodyRight;
        private System.Windows.Forms.Panel pnlBodySearch;
        private System.Windows.Forms.Panel pnlBodyLeft;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.PictureBox ptbProduct;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblBarCode;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Button btnReset;
        private ExtendedComboBox cmbColor;
        private System.Windows.Forms.Label lblColor;
        private ExtendedComboBox cmbMark;
        private System.Windows.Forms.Label lblMark;
        private ExtendedComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button cmdSearchProduct;
        private System.Windows.Forms.CheckBox chbDisplayPicture;
        private System.Windows.Forms.Label lblPrintProduct;
        private System.Windows.Forms.GroupBox grbPrintProduct;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RadioButton rdbPrintSelected;
        private System.Windows.Forms.RadioButton rdbPrintAll;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblUPIn;
        private System.Windows.Forms.Label lblExtraPercentage;
        private System.Windows.Forms.Label UPInLbl;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label discountLbl;
        private System.Windows.Forms.Label UPOutLbl;
        private System.Windows.Forms.Label lblUPOut;
        private System.Windows.Forms.Label extraPercentageLbl;
        private System.Windows.Forms.CheckBox chbInstockOnly;
        private System.Windows.Forms.Label lblResultInfo;
        private System.Windows.Forms.RadioButton rdbProduct;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PrintCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublicQty;
        private System.Windows.Forms.DataGridViewImageColumn ProductPic;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyInStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPriceOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhotoPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPriceIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarkID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarkStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn SkinID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SkinStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtySold;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtraPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForeignCode;
    }
}