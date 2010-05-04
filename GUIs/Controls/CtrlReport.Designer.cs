
namespace EzPos.GUIs.Controls
{
    partial class CtrlReport
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private readonly System.ComponentModel.IContainer components = null;

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
            this.pnlBodyRight = new System.Windows.Forms.Panel();
            this.lblExpense = new System.Windows.Forms.Label();
            this.grbExpense = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpExpenseStop = new System.Windows.Forms.DateTimePicker();
            this.dtpExpenseStart = new System.Windows.Forms.DateTimePicker();
            this.btnDailyReport = new System.Windows.Forms.Button();
            this.lblStock = new System.Windows.Forms.Label();
            this.grbStock = new System.Windows.Forms.GroupBox();
            this.rdbProductExpired = new System.Windows.Forms.RadioButton();
            this.btnSearchStock = new System.Windows.Forms.Button();
            this.rdbStockShort = new System.Windows.Forms.RadioButton();
            this.rdbStockDetail = new System.Windows.Forms.RadioButton();
            this.lblSale = new System.Windows.Forms.Label();
            this.grbSale = new System.Windows.Forms.GroupBox();
            this.rdbReturn = new System.Windows.Forms.RadioButton();
            this.rdbSale = new System.Windows.Forms.RadioButton();
            this.chbShowBenefit = new System.Windows.Forms.CheckBox();
            this.btnSearchSale = new System.Windows.Forms.Button();
            this.lblStop = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStopAdmin = new System.Windows.Forms.DateTimePicker();
            this.dtpStartAdmin = new System.Windows.Forms.DateTimePicker();
            this.pnlBodySearch = new System.Windows.Forms.Panel();
            this.pnlBodyLeft = new System.Windows.Forms.Panel();
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rdbDeposit = new System.Windows.Forms.RadioButton();
            this.pnlBodyRight.SuspendLayout();
            this.grbExpense.SuspendLayout();
            this.grbStock.SuspendLayout();
            this.grbSale.SuspendLayout();
            this.pnlBodyLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBodyRight
            // 
            this.pnlBodyRight.BackgroundImage = global::EzPos.Properties.Resources.backgroud_12;
            this.pnlBodyRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBodyRight.Controls.Add(this.lblExpense);
            this.pnlBodyRight.Controls.Add(this.grbExpense);
            this.pnlBodyRight.Controls.Add(this.lblStock);
            this.pnlBodyRight.Controls.Add(this.grbStock);
            this.pnlBodyRight.Controls.Add(this.lblSale);
            this.pnlBodyRight.Controls.Add(this.grbSale);
            this.pnlBodyRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBodyRight.Location = new System.Drawing.Point(826, 0);
            this.pnlBodyRight.Name = "pnlBodyRight";
            this.pnlBodyRight.Size = new System.Drawing.Size(200, 596);
            this.pnlBodyRight.TabIndex = 1;
            // 
            // lblExpense
            // 
            this.lblExpense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblExpense.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpense.ForeColor = System.Drawing.Color.Yellow;
            this.lblExpense.Location = new System.Drawing.Point(10, 435);
            this.lblExpense.Name = "lblExpense";
            this.lblExpense.Size = new System.Drawing.Size(179, 32);
            this.lblExpense.TabIndex = 107;
            this.lblExpense.Text = "ចំណាយ";
            // 
            // grbExpense
            // 
            this.grbExpense.BackgroundImage = global::EzPos.Properties.Resources.pnlBodyRight;
            this.grbExpense.Controls.Add(this.label1);
            this.grbExpense.Controls.Add(this.label2);
            this.grbExpense.Controls.Add(this.dtpExpenseStop);
            this.grbExpense.Controls.Add(this.dtpExpenseStart);
            this.grbExpense.Controls.Add(this.btnDailyReport);
            this.grbExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbExpense.Location = new System.Drawing.Point(10, 434);
            this.grbExpense.Name = "grbExpense";
            this.grbExpense.Size = new System.Drawing.Size(180, 148);
            this.grbExpense.TabIndex = 106;
            this.grbExpense.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 27);
            this.label1.TabIndex = 109;
            this.label1.Text = "បញ្ចប់";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 27);
            this.label2.TabIndex = 107;
            this.label2.Text = "ចាប់ផ្ដើម";
            // 
            // dtpExpenseStop
            // 
            this.dtpExpenseStop.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpenseStop.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpenseStop.Location = new System.Drawing.Point(77, 67);
            this.dtpExpenseStop.Name = "dtpExpenseStop";
            this.dtpExpenseStop.Size = new System.Drawing.Size(97, 27);
            this.dtpExpenseStop.TabIndex = 110;
            // 
            // dtpExpenseStart
            // 
            this.dtpExpenseStart.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpenseStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpenseStart.Location = new System.Drawing.Point(77, 37);
            this.dtpExpenseStart.Name = "dtpExpenseStart";
            this.dtpExpenseStart.Size = new System.Drawing.Size(97, 27);
            this.dtpExpenseStart.TabIndex = 108;
            // 
            // btnDailyReport
            // 
            this.btnDailyReport.BackColor = System.Drawing.Color.Transparent;
            this.btnDailyReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDailyReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDailyReport.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDailyReport.ForeColor = System.Drawing.Color.White;
            this.btnDailyReport.Image = global::EzPos.Properties.Resources.Search32;
            this.btnDailyReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDailyReport.Location = new System.Drawing.Point(18, 100);
            this.btnDailyReport.Name = "btnDailyReport";
            this.btnDailyReport.Size = new System.Drawing.Size(144, 40);
            this.btnDailyReport.TabIndex = 106;
            this.btnDailyReport.Text = "ស្វែងរក";
            this.btnDailyReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDailyReport.UseVisualStyleBackColor = false;
            this.btnDailyReport.MouseLeave += new System.EventHandler(this.btnDailyReport_MouseLeave);
            this.btnDailyReport.Click += new System.EventHandler(this.btnDailyReport_Click);
            this.btnDailyReport.MouseEnter += new System.EventHandler(this.btnDailyReport_MouseEnter);
            // 
            // lblStock
            // 
            this.lblStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblStock.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.ForeColor = System.Drawing.Color.Yellow;
            this.lblStock.Location = new System.Drawing.Point(10, 1);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(179, 32);
            this.lblStock.TabIndex = 102;
            this.lblStock.Text = "របាយការណ៏ឃ្លាំង";
            // 
            // grbStock
            // 
            this.grbStock.BackgroundImage = global::EzPos.Properties.Resources.pnlBodyRight;
            this.grbStock.Controls.Add(this.rdbProductExpired);
            this.grbStock.Controls.Add(this.btnSearchStock);
            this.grbStock.Controls.Add(this.rdbStockShort);
            this.grbStock.Controls.Add(this.rdbStockDetail);
            this.grbStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbStock.Location = new System.Drawing.Point(10, 0);
            this.grbStock.Name = "grbStock";
            this.grbStock.Size = new System.Drawing.Size(180, 174);
            this.grbStock.TabIndex = 101;
            this.grbStock.TabStop = false;
            // 
            // rdbProductExpired
            // 
            this.rdbProductExpired.AutoSize = true;
            this.rdbProductExpired.BackColor = System.Drawing.Color.Transparent;
            this.rdbProductExpired.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbProductExpired.Location = new System.Drawing.Point(7, 96);
            this.rdbProductExpired.Name = "rdbProductExpired";
            this.rdbProductExpired.Size = new System.Drawing.Size(114, 31);
            this.rdbProductExpired.TabIndex = 12;
            this.rdbProductExpired.Text = "ហួសកំណត់";
            this.rdbProductExpired.UseVisualStyleBackColor = false;
            // 
            // btnSearchStock
            // 
            this.btnSearchStock.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchStock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchStock.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchStock.ForeColor = System.Drawing.Color.White;
            this.btnSearchStock.Image = global::EzPos.Properties.Resources.Search32;
            this.btnSearchStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchStock.Location = new System.Drawing.Point(18, 127);
            this.btnSearchStock.Name = "btnSearchStock";
            this.btnSearchStock.Size = new System.Drawing.Size(144, 40);
            this.btnSearchStock.TabIndex = 11;
            this.btnSearchStock.Text = "ស្វែងរក";
            this.btnSearchStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchStock.UseVisualStyleBackColor = false;
            this.btnSearchStock.MouseLeave += new System.EventHandler(this.btnSearchStock_MouseLeave);
            this.btnSearchStock.Click += new System.EventHandler(this.btnSearchStock_Click);
            this.btnSearchStock.MouseEnter += new System.EventHandler(this.btnSearchStock_MouseEnter);
            // 
            // rdbStockShort
            // 
            this.rdbStockShort.AutoSize = true;
            this.rdbStockShort.BackColor = System.Drawing.Color.Transparent;
            this.rdbStockShort.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbStockShort.Location = new System.Drawing.Point(7, 64);
            this.rdbStockShort.Name = "rdbStockShort";
            this.rdbStockShort.Size = new System.Drawing.Size(79, 31);
            this.rdbStockShort.TabIndex = 3;
            this.rdbStockShort.Text = "សង្ខេប";
            this.rdbStockShort.UseVisualStyleBackColor = false;
            // 
            // rdbStockDetail
            // 
            this.rdbStockDetail.AutoSize = true;
            this.rdbStockDetail.BackColor = System.Drawing.Color.Transparent;
            this.rdbStockDetail.Checked = true;
            this.rdbStockDetail.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbStockDetail.Location = new System.Drawing.Point(6, 32);
            this.rdbStockDetail.Name = "rdbStockDetail";
            this.rdbStockDetail.Size = new System.Drawing.Size(72, 31);
            this.rdbStockDetail.TabIndex = 2;
            this.rdbStockDetail.TabStop = true;
            this.rdbStockDetail.Text = "លំអិត";
            this.rdbStockDetail.UseVisualStyleBackColor = false;
            // 
            // lblSale
            // 
            this.lblSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblSale.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSale.ForeColor = System.Drawing.Color.Yellow;
            this.lblSale.Location = new System.Drawing.Point(10, 177);
            this.lblSale.Name = "lblSale";
            this.lblSale.Size = new System.Drawing.Size(179, 32);
            this.lblSale.TabIndex = 100;
            this.lblSale.Text = "លក់ កក់ និង សង";
            // 
            // grbSale
            // 
            this.grbSale.BackgroundImage = global::EzPos.Properties.Resources.pnlBodyRight;
            this.grbSale.Controls.Add(this.rdbDeposit);
            this.grbSale.Controls.Add(this.rdbReturn);
            this.grbSale.Controls.Add(this.rdbSale);
            this.grbSale.Controls.Add(this.chbShowBenefit);
            this.grbSale.Controls.Add(this.btnSearchSale);
            this.grbSale.Controls.Add(this.lblStop);
            this.grbSale.Controls.Add(this.lblStart);
            this.grbSale.Controls.Add(this.dtpStopAdmin);
            this.grbSale.Controls.Add(this.dtpStartAdmin);
            this.grbSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbSale.Location = new System.Drawing.Point(10, 176);
            this.grbSale.Name = "grbSale";
            this.grbSale.Size = new System.Drawing.Size(180, 256);
            this.grbSale.TabIndex = 99;
            this.grbSale.TabStop = false;
            // 
            // rdbReturn
            // 
            this.rdbReturn.AutoSize = true;
            this.rdbReturn.BackColor = System.Drawing.Color.Transparent;
            this.rdbReturn.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbReturn.Location = new System.Drawing.Point(6, 113);
            this.rdbReturn.Name = "rdbReturn";
            this.rdbReturn.Size = new System.Drawing.Size(152, 31);
            this.rdbReturn.TabIndex = 15;
            this.rdbReturn.Text = "របាយការណ៏សង";
            this.rdbReturn.UseVisualStyleBackColor = false;
            // 
            // rdbSale
            // 
            this.rdbSale.AutoSize = true;
            this.rdbSale.BackColor = System.Drawing.Color.Transparent;
            this.rdbSale.Checked = true;
            this.rdbSale.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSale.Location = new System.Drawing.Point(6, 32);
            this.rdbSale.Name = "rdbSale";
            this.rdbSale.Size = new System.Drawing.Size(152, 31);
            this.rdbSale.TabIndex = 14;
            this.rdbSale.TabStop = true;
            this.rdbSale.Text = "របាយការណ៏លក់";
            this.rdbSale.UseVisualStyleBackColor = false;
            // 
            // chbShowBenefit
            // 
            this.chbShowBenefit.AutoSize = true;
            this.chbShowBenefit.BackColor = System.Drawing.Color.Transparent;
            this.chbShowBenefit.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbShowBenefit.Location = new System.Drawing.Point(28, 57);
            this.chbShowBenefit.Name = "chbShowBenefit";
            this.chbShowBenefit.Size = new System.Drawing.Size(123, 34);
            this.chbShowBenefit.TabIndex = 13;
            this.chbShowBenefit.Text = "ប្រាក់ចំណេញ";
            this.chbShowBenefit.UseVisualStyleBackColor = false;
            // 
            // btnSearchSale
            // 
            this.btnSearchSale.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchSale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchSale.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchSale.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSale.ForeColor = System.Drawing.Color.White;
            this.btnSearchSale.Image = global::EzPos.Properties.Resources.Search32;
            this.btnSearchSale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchSale.Location = new System.Drawing.Point(18, 208);
            this.btnSearchSale.Name = "btnSearchSale";
            this.btnSearchSale.Size = new System.Drawing.Size(144, 40);
            this.btnSearchSale.TabIndex = 12;
            this.btnSearchSale.Text = "ស្វែងរក";
            this.btnSearchSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchSale.UseVisualStyleBackColor = false;
            this.btnSearchSale.MouseLeave += new System.EventHandler(this.btnSearchSale_MouseLeave);
            this.btnSearchSale.Click += new System.EventHandler(this.btnSearchSale_Click);
            this.btnSearchSale.MouseEnter += new System.EventHandler(this.btnSearchSale_MouseEnter);
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.BackColor = System.Drawing.Color.Transparent;
            this.lblStop.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStop.Location = new System.Drawing.Point(1, 177);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(54, 27);
            this.lblStop.TabIndex = 10;
            this.lblStop.Text = "បញ្ចប់";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.BackColor = System.Drawing.Color.Transparent;
            this.lblStart.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(1, 147);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(73, 27);
            this.lblStart.TabIndex = 8;
            this.lblStart.Text = "ចាប់ផ្ដើម";
            // 
            // dtpStopAdmin
            // 
            this.dtpStopAdmin.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStopAdmin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStopAdmin.Location = new System.Drawing.Point(77, 174);
            this.dtpStopAdmin.Name = "dtpStopAdmin";
            this.dtpStopAdmin.Size = new System.Drawing.Size(97, 27);
            this.dtpStopAdmin.TabIndex = 11;
            // 
            // dtpStartAdmin
            // 
            this.dtpStartAdmin.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartAdmin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartAdmin.Location = new System.Drawing.Point(77, 144);
            this.dtpStartAdmin.Name = "dtpStartAdmin";
            this.dtpStartAdmin.Size = new System.Drawing.Size(97, 27);
            this.dtpStartAdmin.TabIndex = 9;
            // 
            // pnlBodySearch
            // 
            this.pnlBodySearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBodySearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBodySearch.Location = new System.Drawing.Point(0, 0);
            this.pnlBodySearch.Name = "pnlBodySearch";
            this.pnlBodySearch.Size = new System.Drawing.Size(826, 0);
            this.pnlBodySearch.TabIndex = 2;
            // 
            // pnlBodyLeft
            // 
            this.pnlBodyLeft.Controls.Add(this.crvReport);
            this.pnlBodyLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBodyLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlBodyLeft.Name = "pnlBodyLeft";
            this.pnlBodyLeft.Size = new System.Drawing.Size(826, 596);
            this.pnlBodyLeft.TabIndex = 3;
            // 
            // crvReport
            // 
            this.crvReport.ActiveViewIndex = -1;
            this.crvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport.DisplayGroupTree = false;
            this.crvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReport.Location = new System.Drawing.Point(0, 0);
            this.crvReport.Name = "crvReport";
            this.crvReport.SelectionFormula = "";
            this.crvReport.Size = new System.Drawing.Size(826, 596);
            this.crvReport.TabIndex = 0;
            this.crvReport.ViewTimeSelectionFormula = "";
            // 
            // rdbDeposit
            // 
            this.rdbDeposit.AutoSize = true;
            this.rdbDeposit.BackColor = System.Drawing.Color.Transparent;
            this.rdbDeposit.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDeposit.Location = new System.Drawing.Point(6, 85);
            this.rdbDeposit.Name = "rdbDeposit";
            this.rdbDeposit.Size = new System.Drawing.Size(146, 31);
            this.rdbDeposit.TabIndex = 16;
            this.rdbDeposit.Text = "របាយការណ៏កក់";
            this.rdbDeposit.UseVisualStyleBackColor = false;
            // 
            // CtrlReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBodyLeft);
            this.Controls.Add(this.pnlBodySearch);
            this.Controls.Add(this.pnlBodyRight);
            this.Name = "CtrlReport";
            this.Size = new System.Drawing.Size(1026, 596);
            this.Load += new System.EventHandler(this.CtrlReport_Load);
            this.pnlBodyRight.ResumeLayout(false);
            this.grbExpense.ResumeLayout(false);
            this.grbExpense.PerformLayout();
            this.grbStock.ResumeLayout(false);
            this.grbStock.PerformLayout();
            this.grbSale.ResumeLayout(false);
            this.grbSale.PerformLayout();
            this.pnlBodyLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBodyRight;
        private System.Windows.Forms.Panel pnlBodySearch;
        private System.Windows.Forms.Panel pnlBodyLeft;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
        private System.Windows.Forms.Label lblSale;
        private System.Windows.Forms.GroupBox grbSale;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.GroupBox grbStock;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStopAdmin;
        private System.Windows.Forms.DateTimePicker dtpStartAdmin;
        private System.Windows.Forms.RadioButton rdbStockShort;
        private System.Windows.Forms.RadioButton rdbStockDetail;
        private System.Windows.Forms.Button btnSearchStock;
        private System.Windows.Forms.Button btnSearchSale;
        private System.Windows.Forms.CheckBox chbShowBenefit;
        private System.Windows.Forms.Label lblExpense;
        private System.Windows.Forms.GroupBox grbExpense;
        private System.Windows.Forms.Button btnDailyReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpExpenseStop;
        private System.Windows.Forms.DateTimePicker dtpExpenseStart;
        private System.Windows.Forms.RadioButton rdbReturn;
        private System.Windows.Forms.RadioButton rdbSale;
        private System.Windows.Forms.RadioButton rdbProductExpired;
        private System.Windows.Forms.RadioButton rdbDeposit;




    }
}