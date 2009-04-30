namespace EzPos.GUI.Forms
{
    partial class FrmAvancedOption
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
            this.cmdProductUnit = new System.Windows.Forms.Button();
            this.cmdAvailableProduct = new System.Windows.Forms.Button();
            this.cmdLocation = new System.Windows.Forms.Button();
            this.cmdExchangeRate = new System.Windows.Forms.Button();
            this.cmdLaboratory = new System.Windows.Forms.Button();
            this.cmdOrigin = new System.Windows.Forms.Button();
            this.cmdSupplier = new System.Windows.Forms.Button();
            this.cmdProductCategory = new System.Windows.Forms.Button();
            this.cmdBarCode = new System.Windows.Forms.Button();
            this.cmdReport = new System.Windows.Forms.Button();
            this.pnlBody.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.cmdReport);
            this.pnlBody.Controls.Add(this.cmdBarCode);
            this.pnlBody.Controls.Add(this.cmdProductUnit);
            this.pnlBody.Controls.Add(this.cmdAvailableProduct);
            this.pnlBody.Controls.Add(this.cmdLocation);
            this.pnlBody.Controls.Add(this.cmdExchangeRate);
            this.pnlBody.Controls.Add(this.cmdLaboratory);
            this.pnlBody.Controls.Add(this.cmdOrigin);
            this.pnlBody.Controls.Add(this.cmdSupplier);
            this.pnlBody.Controls.Add(this.cmdProductCategory);
            // 
            // cmdProductUnit
            // 
            this.cmdProductUnit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProductUnit.Location = new System.Drawing.Point(410, 193);
            this.cmdProductUnit.Name = "cmdProductUnit";
            this.cmdProductUnit.Size = new System.Drawing.Size(130, 37);
            this.cmdProductUnit.TabIndex = 7;
            this.cmdProductUnit.TabStop = false;
            this.cmdProductUnit.Text = "Unit";
            this.cmdProductUnit.UseVisualStyleBackColor = true;
            this.cmdProductUnit.Click += new System.EventHandler(this.cmdProductUnit_Click);
            // 
            // cmdAvailableProduct
            // 
            this.cmdAvailableProduct.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAvailableProduct.Location = new System.Drawing.Point(277, 193);
            this.cmdAvailableProduct.Name = "cmdAvailableProduct";
            this.cmdAvailableProduct.Size = new System.Drawing.Size(130, 37);
            this.cmdAvailableProduct.TabIndex = 6;
            this.cmdAvailableProduct.TabStop = false;
            this.cmdAvailableProduct.Text = "Available product";
            this.cmdAvailableProduct.UseVisualStyleBackColor = true;
            this.cmdAvailableProduct.Click += new System.EventHandler(this.cmdAvailableProduct_Click);
            // 
            // cmdLocation
            // 
            this.cmdLocation.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLocation.Location = new System.Drawing.Point(144, 271);
            this.cmdLocation.Name = "cmdLocation";
            this.cmdLocation.Size = new System.Drawing.Size(130, 37);
            this.cmdLocation.TabIndex = 5;
            this.cmdLocation.TabStop = false;
            this.cmdLocation.Text = "Stock";
            this.cmdLocation.UseVisualStyleBackColor = true;
            this.cmdLocation.Click += new System.EventHandler(this.cmdLocation_Click);
            // 
            // cmdExchangeRate
            // 
            this.cmdExchangeRate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExchangeRate.Location = new System.Drawing.Point(144, 193);
            this.cmdExchangeRate.Name = "cmdExchangeRate";
            this.cmdExchangeRate.Size = new System.Drawing.Size(130, 37);
            this.cmdExchangeRate.TabIndex = 4;
            this.cmdExchangeRate.TabStop = false;
            this.cmdExchangeRate.Text = "Exchange rate";
            this.cmdExchangeRate.UseVisualStyleBackColor = true;
            this.cmdExchangeRate.Click += new System.EventHandler(this.cmdExchangeRate_Click);
            // 
            // cmdLaboratory
            // 
            this.cmdLaboratory.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLaboratory.Location = new System.Drawing.Point(543, 117);
            this.cmdLaboratory.Name = "cmdLaboratory";
            this.cmdLaboratory.Size = new System.Drawing.Size(130, 37);
            this.cmdLaboratory.TabIndex = 3;
            this.cmdLaboratory.TabStop = false;
            this.cmdLaboratory.Text = "Laboratory";
            this.cmdLaboratory.UseVisualStyleBackColor = true;
            this.cmdLaboratory.Click += new System.EventHandler(this.cmdLaboratory_Click);
            // 
            // cmdOrigin
            // 
            this.cmdOrigin.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOrigin.Location = new System.Drawing.Point(410, 117);
            this.cmdOrigin.Name = "cmdOrigin";
            this.cmdOrigin.Size = new System.Drawing.Size(130, 37);
            this.cmdOrigin.TabIndex = 2;
            this.cmdOrigin.TabStop = false;
            this.cmdOrigin.Text = "Origin";
            this.cmdOrigin.UseVisualStyleBackColor = true;
            this.cmdOrigin.Click += new System.EventHandler(this.cmdOrigin_Click);
            // 
            // cmdSupplier
            // 
            this.cmdSupplier.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSupplier.Location = new System.Drawing.Point(277, 117);
            this.cmdSupplier.Name = "cmdSupplier";
            this.cmdSupplier.Size = new System.Drawing.Size(130, 37);
            this.cmdSupplier.TabIndex = 1;
            this.cmdSupplier.TabStop = false;
            this.cmdSupplier.Text = "Supplier";
            this.cmdSupplier.UseVisualStyleBackColor = true;
            this.cmdSupplier.Click += new System.EventHandler(this.cmdSupplier_Click);
            // 
            // cmdProductCategory
            // 
            this.cmdProductCategory.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProductCategory.Location = new System.Drawing.Point(144, 117);
            this.cmdProductCategory.Name = "cmdProductCategory";
            this.cmdProductCategory.Size = new System.Drawing.Size(130, 37);
            this.cmdProductCategory.TabIndex = 0;
            this.cmdProductCategory.TabStop = false;
            this.cmdProductCategory.Text = "Category";
            this.cmdProductCategory.UseVisualStyleBackColor = true;
            this.cmdProductCategory.Click += new System.EventHandler(this.cmdProductCategory_Click);
            // 
            // cmdBarCode
            // 
            this.cmdBarCode.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBarCode.Location = new System.Drawing.Point(543, 193);
            this.cmdBarCode.Name = "cmdBarCode";
            this.cmdBarCode.Size = new System.Drawing.Size(130, 37);
            this.cmdBarCode.TabIndex = 8;
            this.cmdBarCode.TabStop = false;
            this.cmdBarCode.Text = "Barcode";
            this.cmdBarCode.UseVisualStyleBackColor = true;
            this.cmdBarCode.Click += new System.EventHandler(this.cmdBarCode_Click);
            // 
            // cmdReport
            // 
            this.cmdReport.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReport.Location = new System.Drawing.Point(543, 271);
            this.cmdReport.Name = "cmdReport";
            this.cmdReport.Size = new System.Drawing.Size(130, 37);
            this.cmdReport.TabIndex = 9;
            this.cmdReport.TabStop = false;
            this.cmdReport.Text = "Report";
            this.cmdReport.UseVisualStyleBackColor = true;
            this.cmdReport.Click += new System.EventHandler(this.cmdReport_Click);
            // 
            // FrmAvancedOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmAvancedOption";
            this.Text = "FrmAvancedOption";
            this.Load += new System.EventHandler(this.FrmAvancedOption_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button cmdProductCategory;
        public System.Windows.Forms.Button cmdSupplier;
        public System.Windows.Forms.Button cmdLaboratory;
        public System.Windows.Forms.Button cmdOrigin;
        public System.Windows.Forms.Button cmdProductUnit;
        public System.Windows.Forms.Button cmdAvailableProduct;
        public System.Windows.Forms.Button cmdLocation;
        public System.Windows.Forms.Button cmdExchangeRate;
        public System.Windows.Forms.Button cmdBarCode;
        public System.Windows.Forms.Button cmdReport;
    }
}