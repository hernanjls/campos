using ExtendedComboBox=EzPos.GUIs.Components.ExtendedComboBox;
using Resources=EzPos.Properties.Resources;

namespace EzPos.GUIs.Forms
{
    partial class FrmExchangeRate
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
            this.grbLine_1 = new System.Windows.Forms.GroupBox();
            this.grbLine_0 = new System.Windows.Forms.GroupBox();
            this.lblToCurrency = new System.Windows.Forms.Label();
            this.lblFromCurrency = new System.Windows.Forms.Label();
            this.cbbToCurrency = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.cbbFromCurrency = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.lblExchangeDate = new System.Windows.Forms.Label();
            this.dtpExchangeDate = new System.Windows.Forms.DateTimePicker();
            this.lblExchangeRate = new System.Windows.Forms.Label();
            this.txtExchangeRate = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody.Controls.Add(this.grbLine_1);
            this.pnlBody.Controls.Add(this.grbLine_0);
            this.pnlBody.Controls.Add(this.lblToCurrency);
            this.pnlBody.Controls.Add(this.lblFromCurrency);
            this.pnlBody.Controls.Add(this.cbbToCurrency);
            this.pnlBody.Controls.Add(this.cbbFromCurrency);
            this.pnlBody.Controls.Add(this.lblExchangeDate);
            this.pnlBody.Controls.Add(this.dtpExchangeDate);
            this.pnlBody.Controls.Add(this.lblExchangeRate);
            this.pnlBody.Controls.Add(this.txtExchangeRate);
            this.pnlBody.Controls.Add(this.cmdCancel);
            this.pnlBody.Controls.Add(this.cmdSave);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(468, 302);
            this.pnlBody.TabIndex = 1;
            // 
            // grbLine_1
            // 
            this.grbLine_1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_1.Location = new System.Drawing.Point(58, 198);
            this.grbLine_1.Name = "grbLine_1";
            this.grbLine_1.Size = new System.Drawing.Size(350, 2);
            this.grbLine_1.TabIndex = 9;
            this.grbLine_1.TabStop = false;
            // 
            // grbLine_0
            // 
            this.grbLine_0.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_0.Location = new System.Drawing.Point(58, 132);
            this.grbLine_0.Name = "grbLine_0";
            this.grbLine_0.Size = new System.Drawing.Size(350, 2);
            this.grbLine_0.TabIndex = 4;
            this.grbLine_0.TabStop = false;
            // 
            // lblToCurrency
            // 
            this.lblToCurrency.AutoSize = true;
            this.lblToCurrency.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToCurrency.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblToCurrency.Location = new System.Drawing.Point(75, 95);
            this.lblToCurrency.Name = "lblToCurrency";
            this.lblToCurrency.Size = new System.Drawing.Size(126, 24);
            this.lblToCurrency.TabIndex = 2;
            this.lblToCurrency.Text = "រូបិយវត្ថុចុងក្រោយ";
            // 
            // lblFromCurrency
            // 
            this.lblFromCurrency.AutoSize = true;
            this.lblFromCurrency.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromCurrency.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblFromCurrency.Location = new System.Drawing.Point(75, 67);
            this.lblFromCurrency.Name = "lblFromCurrency";
            this.lblFromCurrency.Size = new System.Drawing.Size(88, 24);
            this.lblFromCurrency.TabIndex = 0;
            this.lblFromCurrency.Text = "រូបិយវត្ថុដើម";
            // 
            // cbbToCurrency
            // 
            this.cbbToCurrency.BackColor = System.Drawing.SystemColors.Info;
            this.cbbToCurrency.Enabled = false;
            this.cbbToCurrency.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbToCurrency.FormattingEnabled = true;
            this.cbbToCurrency.Location = new System.Drawing.Point(207, 97);
            this.cbbToCurrency.Name = "cbbToCurrency";
            this.cbbToCurrency.Size = new System.Drawing.Size(181, 26);
            this.cbbToCurrency.TabIndex = 3;
            // 
            // cbbFromCurrency
            // 
            this.cbbFromCurrency.BackColor = System.Drawing.SystemColors.Info;
            this.cbbFromCurrency.Enabled = false;
            this.cbbFromCurrency.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbFromCurrency.FormattingEnabled = true;
            this.cbbFromCurrency.Location = new System.Drawing.Point(207, 69);
            this.cbbFromCurrency.Name = "cbbFromCurrency";
            this.cbbFromCurrency.Size = new System.Drawing.Size(181, 26);
            this.cbbFromCurrency.TabIndex = 1;
            // 
            // lblExchangeDate
            // 
            this.lblExchangeDate.AutoSize = true;
            this.lblExchangeDate.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExchangeDate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblExchangeDate.Location = new System.Drawing.Point(75, 142);
            this.lblExchangeDate.Name = "lblExchangeDate";
            this.lblExchangeDate.Size = new System.Drawing.Size(87, 24);
            this.lblExchangeDate.TabIndex = 5;
            this.lblExchangeDate.Text = "កាលបរិច្ឆេទ";
            // 
            // dtpExchangeDate
            // 
            this.dtpExchangeDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpExchangeDate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExchangeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExchangeDate.Location = new System.Drawing.Point(207, 142);
            this.dtpExchangeDate.Name = "dtpExchangeDate";
            this.dtpExchangeDate.Size = new System.Drawing.Size(181, 23);
            this.dtpExchangeDate.TabIndex = 8;
            // 
            // lblExchangeRate
            // 
            this.lblExchangeRate.AutoSize = true;
            this.lblExchangeRate.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExchangeRate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblExchangeRate.Location = new System.Drawing.Point(75, 168);
            this.lblExchangeRate.Name = "lblExchangeRate";
            this.lblExchangeRate.Size = new System.Drawing.Size(98, 24);
            this.lblExchangeRate.TabIndex = 7;
            this.lblExchangeRate.Text = "អាត្រាប្តូរប្រាក់";
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExchangeRate.Location = new System.Drawing.Point(207, 167);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Size = new System.Drawing.Size(181, 23);
            this.txtExchangeRate.TabIndex = 6;
            this.txtExchangeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Image = global::EzPos.Properties.Resources.Cancel32;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(299, 206);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(89, 28);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdSave.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Image = global::EzPos.Properties.Resources.OK32;
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(207, 206);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(89, 28);
            this.cmdSave.TabIndex = 10;
            this.cmdSave.Text = "&Save   ";
            this.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // FrmExchangeRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(468, 302);
            this.Controls.Add(this.pnlBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmExchangeRate";
            this.Text = "FrmExchangeRate";
            this.Load += new System.EventHandler(this.FrmExchangeRate_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblExchangeRate;
        private System.Windows.Forms.TextBox txtExchangeRate;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.DateTimePicker dtpExchangeDate;
        private System.Windows.Forms.Label lblExchangeDate;
        private ExtendedComboBox cbbFromCurrency;
        private System.Windows.Forms.Label lblToCurrency;
        private System.Windows.Forms.Label lblFromCurrency;
        private ExtendedComboBox cbbToCurrency;
        private System.Windows.Forms.GroupBox grbLine_0;
        private System.Windows.Forms.GroupBox grbLine_1;
    }
}