
namespace EzPos.GUIs.Forms
{
    partial class FrmProductSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.grbLine_1 = new System.Windows.Forms.GroupBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblProductName = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.PrintCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PublicQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductPic = new System.Windows.Forms.DataGridViewImageColumn();
            this.DisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPriceOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhotoPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPriceIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarkStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SkinId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SkinStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtySold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtraPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForeignCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyPromotion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyBonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody.Controls.Add(this.dgvProduct);
            this.pnlBody.Controls.Add(this.txtProductCode);
            this.pnlBody.Controls.Add(this.lblProductCode);
            this.pnlBody.Controls.Add(this.grbLine_1);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBody.Location = new System.Drawing.Point(0, 89);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(695, 400);
            this.pnlBody.TabIndex = 1;
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.ProductId,
            this.PhotoPath,
            this.UnitPriceIn,
            this.CategoryId,
            this.CategoryStr,
            this.MarkId,
            this.MarkStr,
            this.ColorId,
            this.ColorStr,
            this.SkinId,
            this.SkinStr,
            this.SizeId,
            this.SizeStr,
            this.ProductNameCol,
            this.ProductCode,
            this.QtySold,
            this.ExtraPercentage,
            this.LastUpdate,
            this.ForeignCode,
            this.QtyPromotion,
            this.QtyBonus});
            this.dgvProduct.EnableHeadersVisualStyles = false;
            this.dgvProduct.GridColor = System.Drawing.Color.White;
            this.dgvProduct.Location = new System.Drawing.Point(24, 70);
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
            this.dgvProduct.Size = new System.Drawing.Size(647, 321);
            this.dgvProduct.TabIndex = 12;
            this.dgvProduct.SelectionChanged += new System.EventHandler(this.DgvProductSelectionChanged);
            // 
            // txtProductCode
            // 
            this.txtProductCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductCode.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(99, 19);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(230, 36);
            this.txtProductCode.TabIndex = 1;
            this.txtProductCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductCodeKeyDown);
            this.txtProductCode.Leave += new System.EventHandler(this.TxtProductCodeLeave);
            this.txtProductCode.Enter += new System.EventHandler(this.TxtProductCodeEnter);
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCode.Location = new System.Drawing.Point(19, 24);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(74, 30);
            this.lblProductCode.TabIndex = 0;
            this.lblProductCode.Text = "លេខកូដ";
            // 
            // grbLine_1
            // 
            this.grbLine_1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_1.Location = new System.Drawing.Point(24, 62);
            this.grbLine_1.Name = "grbLine_1";
            this.grbLine_1.Size = new System.Drawing.Size(647, 2);
            this.grbLine_1.TabIndex = 11;
            this.grbLine_1.TabStop = false;
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
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnValidate);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 489);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(695, 48);
            this.pnlFooter.TabIndex = 2;
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
            this.btnCancel.MouseLeave += new System.EventHandler(this.BtnCancelMouseLeave);
            this.btnCancel.MouseEnter += new System.EventHandler(this.BtnCancelMouseEnter);
            // 
            // btnValidate
            // 
            this.btnValidate.BackColor = System.Drawing.Color.Transparent;
            this.btnValidate.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnValidate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnValidate.Enabled = false;
            this.btnValidate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnValidate.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidate.ForeColor = System.Drawing.Color.White;
            this.btnValidate.Image = global::EzPos.Properties.Resources.OK32;
            this.btnValidate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnValidate.Location = new System.Drawing.Point(438, 10);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(116, 35);
            this.btnValidate.TabIndex = 1;
            this.btnValidate.Text = "យល់ព្រម";
            this.btnValidate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnValidate.UseVisualStyleBackColor = false;
            this.btnValidate.MouseLeave += new System.EventHandler(this.BtnSaveMouseLeave);
            this.btnValidate.MouseEnter += new System.EventHandler(this.BtnSaveMouseEnter);
            // 
            // PrintCheck
            // 
            this.PrintCheck.DataPropertyName = "PrintCheck";
            this.PrintCheck.HeaderText = global::EzPos.Properties.Resources.ConstBarCodeTemplate6;
            this.PrintCheck.Name = "PrintCheck";
            this.PrintCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PrintCheck.Visible = false;
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
            this.PublicQty.Visible = false;
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
            // ProductId
            // 
            this.ProductId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductId.DataPropertyName = "ProductId";
            this.ProductId.HeaderText = "ProductId";
            this.ProductId.Name = "ProductId";
            this.ProductId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductId.Visible = false;
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
            // CategoryId
            // 
            this.CategoryId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CategoryId.DataPropertyName = "CategoryId";
            this.CategoryId.HeaderText = "CategoryId";
            this.CategoryId.Name = "CategoryId";
            this.CategoryId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CategoryId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CategoryId.Visible = false;
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
            // MarkId
            // 
            this.MarkId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MarkId.DataPropertyName = "MarkId";
            this.MarkId.HeaderText = "MarkId";
            this.MarkId.Name = "MarkId";
            this.MarkId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MarkId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MarkId.Visible = false;
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
            // ColorId
            // 
            this.ColorId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColorId.DataPropertyName = "ColorId";
            this.ColorId.HeaderText = "ColorId";
            this.ColorId.Name = "ColorId";
            this.ColorId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColorId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColorId.Visible = false;
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
            // SkinId
            // 
            this.SkinId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SkinId.DataPropertyName = "SkinId";
            this.SkinId.HeaderText = "SkinId";
            this.SkinId.Name = "SkinId";
            this.SkinId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SkinId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SkinId.Visible = false;
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
            // SizeId
            // 
            this.SizeId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SizeId.DataPropertyName = "SizeId";
            this.SizeId.HeaderText = "SizeId";
            this.SizeId.Name = "SizeId";
            this.SizeId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SizeId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SizeId.Visible = false;
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
            // QtyPromotion
            // 
            this.QtyPromotion.DataPropertyName = "QtyPromotion";
            this.QtyPromotion.HeaderText = "QtyPromotion";
            this.QtyPromotion.Name = "QtyPromotion";
            this.QtyPromotion.Visible = false;
            // 
            // QtyBonus
            // 
            this.QtyBonus.DataPropertyName = "QtyBonus";
            this.QtyBonus.HeaderText = "QtyBonus";
            this.QtyBonus.Name = "QtyBonus";
            this.QtyBonus.Visible = false;
            // 
            // FrmProductSearch
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
            this.Name = "FrmProductSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product";
            this.Load += new System.EventHandler(this.FrmProduct_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.GroupBox grbLine_1;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PrintCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublicQty;
        private System.Windows.Forms.DataGridViewImageColumn ProductPic;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyInStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPriceOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhotoPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPriceIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarkId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarkStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn SkinId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SkinStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtySold;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtraPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForeignCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyPromotion;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyBonus;
    }
}