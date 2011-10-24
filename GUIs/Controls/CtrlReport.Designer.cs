
using EzPos.Service;
using EzPos.Service.Product;
using EzPos.Service.SaleOrder;

namespace EzPos.GUIs.Controls
{
    partial class CtrlReport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlBodyRight = new System.Windows.Forms.Panel();
            this.lblStock = new System.Windows.Forms.Label();
            this.grbStock = new System.Windows.Forms.GroupBox();
            this.btnSearchStock = new System.Windows.Forms.Button();
            this.lblSale = new System.Windows.Forms.Label();
            this.grbSale = new System.Windows.Forms.GroupBox();
            this.rdbIncomeStatement = new System.Windows.Forms.RadioButton();
            this.chbShowQuantity = new System.Windows.Forms.CheckBox();
            this.chbAllDeposit = new System.Windows.Forms.CheckBox();
            this.rdbExpense = new System.Windows.Forms.RadioButton();
            this.rdbDeposit = new System.Windows.Forms.RadioButton();
            this.rdbReturn = new System.Windows.Forms.RadioButton();
            this.rdbSale = new System.Windows.Forms.RadioButton();
            this.chbShowBenefit = new System.Windows.Forms.CheckBox();
            this.btnSearchSale = new System.Windows.Forms.Button();
            this.lblStop = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStopDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.pnlBodySearch = new System.Windows.Forms.Panel();
            this.pnlBodyLeft = new System.Windows.Forms.Panel();
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.wbsReport = new System.Windows.Forms.WebBrowser();
            this.cmbMark = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.pnlBodyRight.SuspendLayout();
            this.grbStock.SuspendLayout();
            this.grbSale.SuspendLayout();
            this.pnlBodyLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBodyRight
            // 
            this.pnlBodyRight.BackgroundImage = global::EzPos.Properties.Resources.backgroud_12;
            this.pnlBodyRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
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
            this.grbStock.Controls.Add(this.cmbMark);
            this.grbStock.Controls.Add(this.btnSearchStock);
            this.grbStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbStock.Location = new System.Drawing.Point(10, 0);
            this.grbStock.Name = "grbStock";
            this.grbStock.Size = new System.Drawing.Size(180, 130);
            this.grbStock.TabIndex = 101;
            this.grbStock.TabStop = false;
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
            this.btnSearchStock.Location = new System.Drawing.Point(18, 80);
            this.btnSearchStock.Name = "btnSearchStock";
            this.btnSearchStock.Size = new System.Drawing.Size(144, 40);
            this.btnSearchStock.TabIndex = 11;
            this.btnSearchStock.Text = "ស្វែងរក";
            this.btnSearchStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchStock.UseVisualStyleBackColor = false;
            this.btnSearchStock.MouseLeave += new System.EventHandler(this.BtnSearchStockMouseLeave);
            this.btnSearchStock.Click += new System.EventHandler(this.BtnSearchStockClick);
            this.btnSearchStock.MouseEnter += new System.EventHandler(this.BtnSearchStockMouseEnter);
            // 
            // lblSale
            // 
            this.lblSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblSale.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSale.ForeColor = System.Drawing.Color.Yellow;
            this.lblSale.Location = new System.Drawing.Point(10, 136);
            this.lblSale.Name = "lblSale";
            this.lblSale.Size = new System.Drawing.Size(179, 32);
            this.lblSale.TabIndex = 100;
            this.lblSale.Text = "លក់ សង ចំណាយ";
            // 
            // grbSale
            // 
            this.grbSale.BackgroundImage = global::EzPos.Properties.Resources.pnlBodyRight;
            this.grbSale.Controls.Add(this.rdbIncomeStatement);
            this.grbSale.Controls.Add(this.chbShowQuantity);
            this.grbSale.Controls.Add(this.chbAllDeposit);
            this.grbSale.Controls.Add(this.rdbExpense);
            this.grbSale.Controls.Add(this.rdbDeposit);
            this.grbSale.Controls.Add(this.rdbReturn);
            this.grbSale.Controls.Add(this.rdbSale);
            this.grbSale.Controls.Add(this.chbShowBenefit);
            this.grbSale.Controls.Add(this.btnSearchSale);
            this.grbSale.Controls.Add(this.lblStop);
            this.grbSale.Controls.Add(this.lblStart);
            this.grbSale.Controls.Add(this.dtpStopDate);
            this.grbSale.Controls.Add(this.dtpStartDate);
            this.grbSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbSale.Location = new System.Drawing.Point(10, 135);
            this.grbSale.Name = "grbSale";
            this.grbSale.Size = new System.Drawing.Size(180, 380);
            this.grbSale.TabIndex = 99;
            this.grbSale.TabStop = false;
            // 
            // rdbIncomeStatement
            // 
            this.rdbIncomeStatement.AutoSize = true;
            this.rdbIncomeStatement.BackColor = System.Drawing.Color.Transparent;
            this.rdbIncomeStatement.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbIncomeStatement.Location = new System.Drawing.Point(6, 295);
            this.rdbIncomeStatement.Name = "rdbIncomeStatement";
            this.rdbIncomeStatement.Size = new System.Drawing.Size(92, 31);
            this.rdbIncomeStatement.TabIndex = 20;
            this.rdbIncomeStatement.Text = "ហិរញ្ញវត្ថុ";
            this.rdbIncomeStatement.UseVisualStyleBackColor = false;
            // 
            // chbShowQuantity
            // 
            this.chbShowQuantity.AutoSize = true;
            this.chbShowQuantity.BackColor = System.Drawing.Color.Transparent;
            this.chbShowQuantity.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbShowQuantity.Location = new System.Drawing.Point(29, 153);
            this.chbShowQuantity.Name = "chbShowQuantity";
            this.chbShowQuantity.Size = new System.Drawing.Size(89, 34);
            this.chbShowQuantity.TabIndex = 19;
            this.chbShowQuantity.Text = "បរិមាណ";
            this.chbShowQuantity.UseVisualStyleBackColor = false;
            this.chbShowQuantity.Leave += new System.EventHandler(this.ChbShowQuantityLeave);
            this.chbShowQuantity.Enter += new System.EventHandler(this.ChbShowQuantityEnter);
            // 
            // chbAllDeposit
            // 
            this.chbAllDeposit.AutoSize = true;
            this.chbAllDeposit.BackColor = System.Drawing.Color.Transparent;
            this.chbAllDeposit.Font = new System.Drawing.Font("Khmer OS", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAllDeposit.Location = new System.Drawing.Point(28, 209);
            this.chbAllDeposit.Name = "chbAllDeposit";
            this.chbAllDeposit.Size = new System.Drawing.Size(133, 34);
            this.chbAllDeposit.TabIndex = 18;
            this.chbAllDeposit.Text = "បង្ហាញទាំងអស់";
            this.chbAllDeposit.UseVisualStyleBackColor = false;
            this.chbAllDeposit.Leave += new System.EventHandler(this.ChbAllDepositLeave);
            this.chbAllDeposit.Enter += new System.EventHandler(this.ChbAllDepositEnter);
            // 
            // rdbExpense
            // 
            this.rdbExpense.AutoSize = true;
            this.rdbExpense.BackColor = System.Drawing.Color.Transparent;
            this.rdbExpense.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbExpense.Location = new System.Drawing.Point(6, 267);
            this.rdbExpense.Name = "rdbExpense";
            this.rdbExpense.Size = new System.Drawing.Size(145, 31);
            this.rdbExpense.TabIndex = 17;
            this.rdbExpense.Text = "ចំណាយប្រចាំថ្ងៃ";
            this.rdbExpense.UseVisualStyleBackColor = false;
            // 
            // rdbDeposit
            // 
            this.rdbDeposit.AutoSize = true;
            this.rdbDeposit.BackColor = System.Drawing.Color.Transparent;
            this.rdbDeposit.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDeposit.Location = new System.Drawing.Point(6, 182);
            this.rdbDeposit.Name = "rdbDeposit";
            this.rdbDeposit.Size = new System.Drawing.Size(146, 31);
            this.rdbDeposit.TabIndex = 16;
            this.rdbDeposit.Text = "របាយការណ៏កក់";
            this.rdbDeposit.UseVisualStyleBackColor = false;
            // 
            // rdbReturn
            // 
            this.rdbReturn.AutoSize = true;
            this.rdbReturn.BackColor = System.Drawing.Color.Transparent;
            this.rdbReturn.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbReturn.Location = new System.Drawing.Point(6, 239);
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
            this.rdbSale.Location = new System.Drawing.Point(6, 99);
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
            this.chbShowBenefit.Location = new System.Drawing.Point(28, 126);
            this.chbShowBenefit.Name = "chbShowBenefit";
            this.chbShowBenefit.Size = new System.Drawing.Size(123, 34);
            this.chbShowBenefit.TabIndex = 13;
            this.chbShowBenefit.Text = "ប្រាក់ចំណេញ";
            this.chbShowBenefit.UseVisualStyleBackColor = false;
            this.chbShowBenefit.Leave += new System.EventHandler(this.ChbShowBenefitLeave);
            this.chbShowBenefit.Enter += new System.EventHandler(this.ChbShowBenefitEnter);
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
            this.btnSearchSale.Location = new System.Drawing.Point(18, 332);
            this.btnSearchSale.Name = "btnSearchSale";
            this.btnSearchSale.Size = new System.Drawing.Size(144, 40);
            this.btnSearchSale.TabIndex = 12;
            this.btnSearchSale.Text = "ស្វែងរក";
            this.btnSearchSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchSale.UseVisualStyleBackColor = false;
            this.btnSearchSale.MouseLeave += new System.EventHandler(this.BtnSearchSaleMouseLeave);
            this.btnSearchSale.Click += new System.EventHandler(this.BtnSearchSaleClick);
            this.btnSearchSale.MouseEnter += new System.EventHandler(this.BtnSearchSaleMouseEnter);
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.BackColor = System.Drawing.Color.Transparent;
            this.lblStop.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStop.Location = new System.Drawing.Point(1, 73);
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
            this.lblStart.Location = new System.Drawing.Point(1, 43);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(73, 27);
            this.lblStart.TabIndex = 8;
            this.lblStart.Text = "ចាប់ផ្ដើម";
            // 
            // dtpStopDate
            // 
            this.dtpStopDate.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStopDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStopDate.Location = new System.Drawing.Point(77, 70);
            this.dtpStopDate.Name = "dtpStopDate";
            this.dtpStopDate.Size = new System.Drawing.Size(97, 27);
            this.dtpStopDate.TabIndex = 11;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(77, 40);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(97, 27);
            this.dtpStartDate.TabIndex = 9;
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
            this.pnlBodyLeft.Controls.Add(this.wbsReport);
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
            // wbsReport
            // 
            this.wbsReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbsReport.Location = new System.Drawing.Point(0, 0);
            this.wbsReport.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbsReport.Name = "wbsReport";
            this.wbsReport.Size = new System.Drawing.Size(826, 596);
            this.wbsReport.TabIndex = 1;
            // 
            // cmbMark
            // 
            this.cmbMark.DropDownWidth = 180;
            this.cmbMark.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMark.FormattingEnabled = true;
            this.cmbMark.Location = new System.Drawing.Point(7, 39);
            this.cmbMark.Name = "cmbMark";
            this.cmbMark.Size = new System.Drawing.Size(167, 27);
            this.cmbMark.TabIndex = 13;
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
            this.grbStock.ResumeLayout(false);
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
        private System.Windows.Forms.DateTimePicker dtpStopDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnSearchStock;
        private System.Windows.Forms.Button btnSearchSale;
        private System.Windows.Forms.CheckBox chbShowBenefit;
        private System.Windows.Forms.RadioButton rdbReturn;
        private System.Windows.Forms.RadioButton rdbSale;
        private System.Windows.Forms.RadioButton rdbDeposit;
        private System.Windows.Forms.RadioButton rdbExpense;
        private System.Windows.Forms.CheckBox chbAllDeposit;
        private ExpenseService _ExpenseService;
        private ProductService _ProductService;
        private SaleOrderService _SaleOrderService;
        private System.Windows.Forms.CheckBox chbShowQuantity;
        private System.Windows.Forms.RadioButton rdbIncomeStatement;
        private System.Windows.Forms.WebBrowser wbsReport;
        private EzPos.GUIs.Components.ExtendedComboBox cmbMark;
        private System.ComponentModel.IContainer components;
    }
}