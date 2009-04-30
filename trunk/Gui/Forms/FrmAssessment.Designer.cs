//using PharmaStock.GUI.Reports;

using EzPos.Properties;

namespace EzPos.GUI
{
    partial class FrmAssessment
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.tbcAssessment = new System.Windows.Forms.TabControl();
            this.tbpAdministrator = new System.Windows.Forms.TabPage();
            this.lblStopAdmin = new System.Windows.Forms.Label();
            this.lblStartAdmin = new System.Windows.Forms.Label();
            this.dtpStopAdmin = new System.Windows.Forms.DateTimePicker();
            this.dtpStartAdmin = new System.Windows.Forms.DateTimePicker();
            this.tbpCashier = new System.Windows.Forms.TabPage();
            this.lblStopCashier = new System.Windows.Forms.Label();
            this.lblStartCashier = new System.Windows.Forms.Label();
            this.dtpStopCashier = new System.Windows.Forms.DateTimePicker();
            this.dtpStartCashier = new System.Windows.Forms.DateTimePicker();
            this.tbpStock = new System.Windows.Forms.TabPage();
            this.rdbExpire = new System.Windows.Forms.RadioButton();
            this.rdbOutOfStock = new System.Windows.Forms.RadioButton();
            this.rdbStock = new System.Windows.Forms.RadioButton();
            this.cmdBack = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.crvAssessment = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tbpPurchaseOrder = new System.Windows.Forms.TabPage();
            this.rdbUnPaidPO = new System.Windows.Forms.RadioButton();
            this.rdbPaidPO = new System.Windows.Forms.RadioButton();
            this.rdbAllPO = new System.Windows.Forms.RadioButton();
            this.pnlTop.SuspendLayout();
            this.tbcAssessment.SuspendLayout();
            this.tbpAdministrator.SuspendLayout();
            this.tbpCashier.SuspendLayout();
            this.tbpStock.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.tbpPurchaseOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cmdRefresh);
            this.pnlTop.Controls.Add(this.tbcAssessment);
            this.pnlTop.Controls.Add(this.cmdBack);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(918, 180);
            this.pnlTop.TabIndex = 0;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefresh.Image = Resources.Binoc32;
            this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRefresh.Location = new System.Drawing.Point(98, 141);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(101, 28);
            this.cmdRefresh.TabIndex = 2;
            this.cmdRefresh.TabStop = false;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // tbcAssessment
            // 
            this.tbcAssessment.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbcAssessment.Controls.Add(this.tbpAdministrator);
            this.tbcAssessment.Controls.Add(this.tbpCashier);
            this.tbcAssessment.Controls.Add(this.tbpStock);
            this.tbcAssessment.Controls.Add(this.tbpPurchaseOrder);
            this.tbcAssessment.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcAssessment.Location = new System.Drawing.Point(17, 16);
            this.tbcAssessment.Name = "tbcAssessment";
            this.tbcAssessment.SelectedIndex = 0;
            this.tbcAssessment.Size = new System.Drawing.Size(371, 119);
            this.tbcAssessment.TabIndex = 0;
            // 
            // tbpAdministrator
            // 
            this.tbpAdministrator.Controls.Add(this.lblStopAdmin);
            this.tbpAdministrator.Controls.Add(this.lblStartAdmin);
            this.tbpAdministrator.Controls.Add(this.dtpStopAdmin);
            this.tbpAdministrator.Controls.Add(this.dtpStartAdmin);
            this.tbpAdministrator.Location = new System.Drawing.Point(4, 30);
            this.tbpAdministrator.Name = "tbpAdministrator";
            this.tbpAdministrator.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAdministrator.Size = new System.Drawing.Size(363, 85);
            this.tbpAdministrator.TabIndex = 0;
            this.tbpAdministrator.Text = "Administrator";
            this.tbpAdministrator.UseVisualStyleBackColor = true;
            // 
            // lblStopAdmin
            // 
            this.lblStopAdmin.AutoSize = true;
            this.lblStopAdmin.Location = new System.Drawing.Point(18, 60);
            this.lblStopAdmin.Name = "lblStopAdmin";
            this.lblStopAdmin.Size = new System.Drawing.Size(35, 18);
            this.lblStopAdmin.TabIndex = 6;
            this.lblStopAdmin.Text = "Stop";
            // 
            // lblStartAdmin
            // 
            this.lblStartAdmin.AutoSize = true;
            this.lblStartAdmin.Location = new System.Drawing.Point(18, 25);
            this.lblStartAdmin.Name = "lblStartAdmin";
            this.lblStartAdmin.Size = new System.Drawing.Size(38, 18);
            this.lblStartAdmin.TabIndex = 4;
            this.lblStartAdmin.Text = "Start";
            // 
            // dtpStopAdmin
            // 
            this.dtpStopAdmin.Location = new System.Drawing.Point(77, 55);
            this.dtpStopAdmin.Name = "dtpStopAdmin";
            this.dtpStopAdmin.Size = new System.Drawing.Size(255, 23);
            this.dtpStopAdmin.TabIndex = 7;
            // 
            // dtpStartAdmin
            // 
            this.dtpStartAdmin.Location = new System.Drawing.Point(77, 20);
            this.dtpStartAdmin.Name = "dtpStartAdmin";
            this.dtpStartAdmin.Size = new System.Drawing.Size(255, 23);
            this.dtpStartAdmin.TabIndex = 5;
            // 
            // tbpCashier
            // 
            this.tbpCashier.Controls.Add(this.lblStopCashier);
            this.tbpCashier.Controls.Add(this.lblStartCashier);
            this.tbpCashier.Controls.Add(this.dtpStopCashier);
            this.tbpCashier.Controls.Add(this.dtpStartCashier);
            this.tbpCashier.Location = new System.Drawing.Point(4, 30);
            this.tbpCashier.Name = "tbpCashier";
            this.tbpCashier.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCashier.Size = new System.Drawing.Size(363, 85);
            this.tbpCashier.TabIndex = 1;
            this.tbpCashier.Text = "Cashier";
            this.tbpCashier.UseVisualStyleBackColor = true;
            // 
            // lblStopCashier
            // 
            this.lblStopCashier.AutoSize = true;
            this.lblStopCashier.Location = new System.Drawing.Point(18, 60);
            this.lblStopCashier.Name = "lblStopCashier";
            this.lblStopCashier.Size = new System.Drawing.Size(35, 18);
            this.lblStopCashier.TabIndex = 10;
            this.lblStopCashier.Text = "Stop";
            // 
            // lblStartCashier
            // 
            this.lblStartCashier.AutoSize = true;
            this.lblStartCashier.Location = new System.Drawing.Point(18, 25);
            this.lblStartCashier.Name = "lblStartCashier";
            this.lblStartCashier.Size = new System.Drawing.Size(38, 18);
            this.lblStartCashier.TabIndex = 8;
            this.lblStartCashier.Text = "Start";
            // 
            // dtpStopCashier
            // 
            this.dtpStopCashier.Location = new System.Drawing.Point(77, 55);
            this.dtpStopCashier.Name = "dtpStopCashier";
            this.dtpStopCashier.Size = new System.Drawing.Size(255, 23);
            this.dtpStopCashier.TabIndex = 11;
            // 
            // dtpStartCashier
            // 
            this.dtpStartCashier.Location = new System.Drawing.Point(77, 20);
            this.dtpStartCashier.Name = "dtpStartCashier";
            this.dtpStartCashier.Size = new System.Drawing.Size(255, 23);
            this.dtpStartCashier.TabIndex = 9;
            // 
            // tbpStock
            // 
            this.tbpStock.Controls.Add(this.rdbExpire);
            this.tbpStock.Controls.Add(this.rdbOutOfStock);
            this.tbpStock.Controls.Add(this.rdbStock);
            this.tbpStock.Location = new System.Drawing.Point(4, 30);
            this.tbpStock.Name = "tbpStock";
            this.tbpStock.Size = new System.Drawing.Size(363, 85);
            this.tbpStock.TabIndex = 2;
            this.tbpStock.Text = "Stock";
            this.tbpStock.UseVisualStyleBackColor = true;
            // 
            // rdbExpire
            // 
            this.rdbExpire.AutoSize = true;
            this.rdbExpire.Location = new System.Drawing.Point(235, 25);
            this.rdbExpire.Name = "rdbExpire";
            this.rdbExpire.Size = new System.Drawing.Size(106, 22);
            this.rdbExpire.TabIndex = 2;
            this.rdbExpire.Text = "Drug expired";
            this.rdbExpire.UseVisualStyleBackColor = true;
            // 
            // rdbOutOfStock
            // 
            this.rdbOutOfStock.AutoSize = true;
            this.rdbOutOfStock.Location = new System.Drawing.Point(119, 25);
            this.rdbOutOfStock.Name = "rdbOutOfStock";
            this.rdbOutOfStock.Size = new System.Drawing.Size(100, 22);
            this.rdbOutOfStock.TabIndex = 1;
            this.rdbOutOfStock.Text = "Out of stock";
            this.rdbOutOfStock.UseVisualStyleBackColor = true;
            // 
            // rdbStock
            // 
            this.rdbStock.AutoSize = true;
            this.rdbStock.Checked = true;
            this.rdbStock.Location = new System.Drawing.Point(18, 25);
            this.rdbStock.Name = "rdbStock";
            this.rdbStock.Size = new System.Drawing.Size(59, 22);
            this.rdbStock.TabIndex = 0;
            this.rdbStock.TabStop = true;
            this.rdbStock.Text = "Stock";
            this.rdbStock.UseVisualStyleBackColor = true;
            // 
            // cmdBack
            // 
            this.cmdBack.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBack.Image = Resources.Delete32;
            this.cmdBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBack.Location = new System.Drawing.Point(205, 141);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(101, 28);
            this.cmdBack.TabIndex = 1;
            this.cmdBack.TabStop = false;
            this.cmdBack.Text = "Back";
            this.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdBack.UseVisualStyleBackColor = true;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.crvAssessment);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 180);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(918, 297);
            this.pnlBody.TabIndex = 1;
            // 
            // crvAssessment
            // 
            this.crvAssessment.ActiveViewIndex = -1;
            this.crvAssessment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvAssessment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvAssessment.Location = new System.Drawing.Point(0, 0);
            this.crvAssessment.Name = "crvAssessment";
            this.crvAssessment.SelectionFormula = "";
            this.crvAssessment.Size = new System.Drawing.Size(918, 297);
            this.crvAssessment.TabIndex = 1;
            this.crvAssessment.ViewTimeSelectionFormula = "";
            // 
            // tbpPurchaseOrder
            // 
            this.tbpPurchaseOrder.Controls.Add(this.rdbAllPO);
            this.tbpPurchaseOrder.Controls.Add(this.rdbUnPaidPO);
            this.tbpPurchaseOrder.Controls.Add(this.rdbPaidPO);
            this.tbpPurchaseOrder.Location = new System.Drawing.Point(4, 30);
            this.tbpPurchaseOrder.Name = "tbpPurchaseOrder";
            this.tbpPurchaseOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPurchaseOrder.Size = new System.Drawing.Size(363, 85);
            this.tbpPurchaseOrder.TabIndex = 3;
            this.tbpPurchaseOrder.Text = "Purchase Order";
            this.tbpPurchaseOrder.UseVisualStyleBackColor = true;
            // 
            // rdbUnPaidPO
            // 
            this.rdbUnPaidPO.AutoSize = true;
            this.rdbUnPaidPO.Location = new System.Drawing.Point(265, 31);
            this.rdbUnPaidPO.Name = "rdbUnPaidPO";
            this.rdbUnPaidPO.Size = new System.Drawing.Size(70, 22);
            this.rdbUnPaidPO.TabIndex = 2;
            this.rdbUnPaidPO.Text = "Unpaid";
            this.rdbUnPaidPO.UseVisualStyleBackColor = true;
            // 
            // rdbPaidPO
            // 
            this.rdbPaidPO.AutoSize = true;
            this.rdbPaidPO.Location = new System.Drawing.Point(149, 31);
            this.rdbPaidPO.Name = "rdbPaidPO";
            this.rdbPaidPO.Size = new System.Drawing.Size(53, 22);
            this.rdbPaidPO.TabIndex = 1;
            this.rdbPaidPO.Text = "Paid";
            this.rdbPaidPO.UseVisualStyleBackColor = true;
            // 
            // rdbAllPO
            // 
            this.rdbAllPO.AutoSize = true;
            this.rdbAllPO.Checked = true;
            this.rdbAllPO.Location = new System.Drawing.Point(35, 31);
            this.rdbAllPO.Name = "rdbAllPO";
            this.rdbAllPO.Size = new System.Drawing.Size(42, 22);
            this.rdbAllPO.TabIndex = 0;
            this.rdbAllPO.TabStop = true;
            this.rdbAllPO.Text = "All";
            this.rdbAllPO.UseVisualStyleBackColor = true;
            // 
            // FrmAssessment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 477);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAssessment";
            this.Text = "FrmAssessment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTop.ResumeLayout(false);
            this.tbcAssessment.ResumeLayout(false);
            this.tbpAdministrator.ResumeLayout(false);
            this.tbpAdministrator.PerformLayout();
            this.tbpCashier.ResumeLayout(false);
            this.tbpCashier.PerformLayout();
            this.tbpStock.ResumeLayout(false);
            this.tbpStock.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.tbpPurchaseOrder.ResumeLayout(false);
            this.tbpPurchaseOrder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        //private RptAssessmentCashier rptAssessment;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBody;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvAssessment;
        public System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.TabControl tbcAssessment;
        private System.Windows.Forms.TabPage tbpAdministrator;
        private System.Windows.Forms.TabPage tbpCashier;
        private System.Windows.Forms.TabPage tbpStock;
        private System.Windows.Forms.Label lblStopAdmin;
        private System.Windows.Forms.Label lblStartAdmin;
        private System.Windows.Forms.DateTimePicker dtpStopAdmin;
        private System.Windows.Forms.DateTimePicker dtpStartAdmin;
        private System.Windows.Forms.Label lblStopCashier;
        private System.Windows.Forms.Label lblStartCashier;
        private System.Windows.Forms.DateTimePicker dtpStopCashier;
        private System.Windows.Forms.DateTimePicker dtpStartCashier;
        public System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.RadioButton rdbStock;
        private System.Windows.Forms.RadioButton rdbExpire;
        private System.Windows.Forms.RadioButton rdbOutOfStock;
        private System.Windows.Forms.TabPage tbpPurchaseOrder;
        private System.Windows.Forms.RadioButton rdbAllPO;
        private System.Windows.Forms.RadioButton rdbUnPaidPO;
        private System.Windows.Forms.RadioButton rdbPaidPO;

    }
}