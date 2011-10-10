
using EzPos.GUIs.Components;

namespace EzPos.GUIs.Forms
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblDateInfo = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.pnlSepartorTop = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSupplier = new ExtendedButton();
            this.btnExpense = new ExtendedButton();
            this.btnReport = new ExtendedButton();
            this.btnConfiguration = new ExtendedButton();
            this.btnDiscountCard = new ExtendedButton();
            this.btnCustomer = new ExtendedButton();
            this.btnQuit = new ExtendedButton();
            this.btnUser = new ExtendedButton();
            this.btnProduct = new ExtendedButton();
            this.btnSaleOrder = new ExtendedButton();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.BackgroundImage = global::EzPos.Properties.Resources.backgroud_11;
            this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHeader.Controls.Add(this.lblDateInfo);
            this.pnlHeader.Controls.Add(this.lblProductName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1024, 113);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblDateInfo
            // 
            this.lblDateInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblDateInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDateInfo.Font = new System.Drawing.Font("Candara", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateInfo.ForeColor = System.Drawing.Color.FloralWhite;
            this.lblDateInfo.Location = new System.Drawing.Point(824, 0);
            this.lblDateInfo.Name = "lblDateInfo";
            this.lblDateInfo.Size = new System.Drawing.Size(200, 113);
            this.lblDateInfo.TabIndex = 1;
            this.lblDateInfo.Text = "lblDateInfo";
            this.lblDateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Trebuchet MS", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.Yellow;
            this.lblProductName.Location = new System.Drawing.Point(3, 17);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(508, 81);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "EzPos";
            // 
            // pnlSepartorTop
            // 
            this.pnlSepartorTop.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.pnlSepartorTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlSepartorTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSepartorTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSepartorTop.ForeColor = System.Drawing.Color.Gold;
            this.pnlSepartorTop.Location = new System.Drawing.Point(0, 113);
            this.pnlSepartorTop.Name = "pnlSepartorTop";
            this.pnlSepartorTop.Size = new System.Drawing.Size(1024, 0);
            this.pnlSepartorTop.TabIndex = 1;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackgroundImage = global::EzPos.Properties.Resources.background_5;
            this.pnlFooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFooter.Controls.Add(this.btnSupplier);
            this.pnlFooter.Controls.Add(this.btnExpense);
            this.pnlFooter.Controls.Add(this.btnReport);
            this.pnlFooter.Controls.Add(this.btnConfiguration);
            this.pnlFooter.Controls.Add(this.btnDiscountCard);
            this.pnlFooter.Controls.Add(this.btnCustomer);
            this.pnlFooter.Controls.Add(this.btnQuit);
            this.pnlFooter.Controls.Add(this.btnUser);
            this.pnlFooter.Controls.Add(this.btnProduct);
            this.pnlFooter.Controls.Add(this.btnSaleOrder);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 618);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1024, 48);
            this.pnlFooter.TabIndex = 3;
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSupplier.Font = new System.Drawing.Font("Candara", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.ForeColor = System.Drawing.Color.White;
            this.btnSupplier.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSupplier.Location = new System.Drawing.Point(402, 10);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(95, 35);
            this.btnSupplier.TabIndex = 5;
            this.btnSupplier.TabStop = false;
            this.btnSupplier.Text = "Supplier";
            this.btnSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.BtnSupplierClick);
            // 
            // btnExpense
            // 
            this.btnExpense.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnExpense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExpense.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExpense.Font = new System.Drawing.Font("Candara", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpense.ForeColor = System.Drawing.Color.White;
            this.btnExpense.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExpense.Location = new System.Drawing.Point(498, 10);
            this.btnExpense.Name = "btnExpense";
            this.btnExpense.Size = new System.Drawing.Size(95, 35);
            this.btnExpense.TabIndex = 4;
            this.btnExpense.TabStop = false;
            this.btnExpense.Text = "Expense";
            this.btnExpense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExpense.UseVisualStyleBackColor = true;
            this.btnExpense.Click += new System.EventHandler(this.BtnExpenseClick);
            // 
            // btnReport
            // 
            this.btnReport.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.Font = new System.Drawing.Font("Candara", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnReport.Location = new System.Drawing.Point(594, 10);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(95, 35);
            this.btnReport.TabIndex = 6;
            this.btnReport.TabStop = false;
            this.btnReport.Text = "Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.BtnReportClick);
            // 
            // btnConfiguration
            // 
            this.btnConfiguration.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnConfiguration.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfiguration.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfiguration.Font = new System.Drawing.Font("Candara", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguration.ForeColor = System.Drawing.Color.White;
            this.btnConfiguration.Image = global::EzPos.Properties.Resources.Config32;
            this.btnConfiguration.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnConfiguration.Location = new System.Drawing.Point(786, 10);
            this.btnConfiguration.Name = "btnConfiguration";
            this.btnConfiguration.Size = new System.Drawing.Size(95, 35);
            this.btnConfiguration.TabIndex = 8;
            this.btnConfiguration.TabStop = false;
            this.btnConfiguration.Text = "Config";
            this.btnConfiguration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfiguration.UseVisualStyleBackColor = true;
            this.btnConfiguration.Click += new System.EventHandler(this.BtnConfigurationClick);
            // 
            // btnDiscountCard
            // 
            this.btnDiscountCard.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnDiscountCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDiscountCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDiscountCard.Font = new System.Drawing.Font("Candara", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscountCard.ForeColor = System.Drawing.Color.White;
            this.btnDiscountCard.Image = global::EzPos.Properties.Resources.Buy32;
            this.btnDiscountCard.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDiscountCard.Location = new System.Drawing.Point(306, 10);
            this.btnDiscountCard.Name = "btnDiscountCard";
            this.btnDiscountCard.Size = new System.Drawing.Size(95, 35);
            this.btnDiscountCard.TabIndex = 3;
            this.btnDiscountCard.TabStop = false;
            this.btnDiscountCard.Text = "Card";
            this.btnDiscountCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDiscountCard.UseVisualStyleBackColor = true;
            this.btnDiscountCard.Click += new System.EventHandler(this.BtnDiscountCardClick);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomer.Font = new System.Drawing.Font("Candara", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Image = global::EzPos.Properties.Resources.Customer32;
            this.btnCustomer.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCustomer.Location = new System.Drawing.Point(210, 10);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(95, 35);
            this.btnCustomer.TabIndex = 2;
            this.btnCustomer.TabStop = false;
            this.btnCustomer.Text = "Cust.";
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.BtnCustomerClick);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuit.BackgroundImage")));
            this.btnQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuit.Font = new System.Drawing.Font("Candara", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.ForeColor = System.Drawing.Color.White;
            this.btnQuit.Image = global::EzPos.Properties.Resources.exit32;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.Location = new System.Drawing.Point(911, 10);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(100, 35);
            this.btnQuit.TabIndex = 9;
            this.btnQuit.TabStop = false;
            this.btnQuit.Text = "Quit";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.BtnQuitClick);
            // 
            // btnUser
            // 
            this.btnUser.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUser.Font = new System.Drawing.Font("Candara", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Image = global::EzPos.Properties.Resources.User32;
            this.btnUser.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnUser.Location = new System.Drawing.Point(690, 10);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(95, 35);
            this.btnUser.TabIndex = 7;
            this.btnUser.TabStop = false;
            this.btnUser.Text = "User";
            this.btnUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.BtnUserClick);
            // 
            // btnProduct
            // 
            this.btnProduct.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProduct.Font = new System.Drawing.Font("Candara", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Image = global::EzPos.Properties.Resources.Product32;
            this.btnProduct.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnProduct.Location = new System.Drawing.Point(114, 10);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(95, 35);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.TabStop = false;
            this.btnProduct.Text = "Prod.";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.BtnProductClick);
            // 
            // btnSaleOrder
            // 
            this.btnSaleOrder.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnSaleOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaleOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaleOrder.Font = new System.Drawing.Font("Candara", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaleOrder.ForeColor = System.Drawing.Color.White;
            this.btnSaleOrder.Image = global::EzPos.Properties.Resources.Sale32;
            this.btnSaleOrder.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSaleOrder.Location = new System.Drawing.Point(18, 10);
            this.btnSaleOrder.Name = "btnSaleOrder";
            this.btnSaleOrder.Size = new System.Drawing.Size(95, 35);
            this.btnSaleOrder.TabIndex = 0;
            this.btnSaleOrder.TabStop = false;
            this.btnSaleOrder.Text = "Sale";
            this.btnSaleOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaleOrder.UseVisualStyleBackColor = true;
            this.btnSaleOrder.Click += new System.EventHandler(this.BtnSaleOrderClick);
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 113);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1024, 505);
            this.pnlBody.TabIndex = 4;
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Interval = 1000;
            this.tmrRefresh.Tick += new System.EventHandler(this.TmrRefreshTick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "SaleItemID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "SaleOrderId";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "ProductID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "UnitPriceIn";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn5.HeaderText = "ProductName";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 300;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn6.HeaderText = "QtySold";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn7.HeaderText = "UnitPriceOut";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn8.HeaderText = "Discount";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn9.HeaderText = "SubTotal";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 120;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 666);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlSepartorTop);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: EzPos :.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlSepartorTop;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlBody;
        public ExtendedButton btnConfiguration;
        public ExtendedButton btnDiscountCard;
        public ExtendedButton btnCustomer;
        private ExtendedButton btnQuit;
        public ExtendedButton btnUser;
        public ExtendedButton btnProduct;
        public ExtendedButton btnSaleOrder;
        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        public ExtendedButton btnReport;
        public ExtendedButton btnExpense;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblDateInfo;
        public ExtendedButton btnSupplier;
    }
}