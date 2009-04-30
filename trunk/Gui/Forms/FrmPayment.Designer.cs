using EzPos.Properties;

namespace EzPos.GUI
{
    partial class FrmPayment
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
            this.pnlBody = new System.Windows.Forms.Panel();
            this.grbLine_0 = new System.Windows.Forms.GroupBox();
            this.lblExchangeRate = new System.Windows.Forms.Label();
            this.txtExchangeRate = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAmountReturnRiel = new System.Windows.Forms.TextBox();
            this.lblAmountReturnRiel = new System.Windows.Forms.Label();
            this.lblAmountReturnUsd = new System.Windows.Forms.Label();
            this.txtAmountReturnUsd = new System.Windows.Forms.TextBox();
            this.grbLine_2 = new System.Windows.Forms.GroupBox();
            this.txtAmountPaidRiel = new System.Windows.Forms.TextBox();
            this.lblAmoutPaidRiel = new System.Windows.Forms.Label();
            this.lblAmountPaidUsd = new System.Windows.Forms.Label();
            this.txtAmountPaidUsd = new System.Windows.Forms.TextBox();
            this.grbLine_1 = new System.Windows.Forms.GroupBox();
            this.txtTotalAmountRiel = new System.Windows.Forms.TextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.txtTotalAmountUsd = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody.Controls.Add(this.grbLine_0);
            this.pnlBody.Controls.Add(this.lblExchangeRate);
            this.pnlBody.Controls.Add(this.txtExchangeRate);
            this.pnlBody.Controls.Add(this.groupBox1);
            this.pnlBody.Controls.Add(this.txtAmountReturnRiel);
            this.pnlBody.Controls.Add(this.lblAmountReturnRiel);
            this.pnlBody.Controls.Add(this.lblAmountReturnUsd);
            this.pnlBody.Controls.Add(this.txtAmountReturnUsd);
            this.pnlBody.Controls.Add(this.grbLine_2);
            this.pnlBody.Controls.Add(this.txtAmountPaidRiel);
            this.pnlBody.Controls.Add(this.lblAmoutPaidRiel);
            this.pnlBody.Controls.Add(this.lblAmountPaidUsd);
            this.pnlBody.Controls.Add(this.txtAmountPaidUsd);
            this.pnlBody.Controls.Add(this.grbLine_1);
            this.pnlBody.Controls.Add(this.txtTotalAmountRiel);
            this.pnlBody.Controls.Add(this.lblDisplayName);
            this.pnlBody.Controls.Add(this.lblProductCode);
            this.pnlBody.Controls.Add(this.txtTotalAmountUsd);
            this.pnlBody.Controls.Add(this.cmdCancel);
            this.pnlBody.Controls.Add(this.cmdSave);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(468, 299);
            this.pnlBody.TabIndex = 0;
            // 
            // grbLine_0
            // 
            this.grbLine_0.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_0.Location = new System.Drawing.Point(56, 49);
            this.grbLine_0.Name = "grbLine_0";
            this.grbLine_0.Size = new System.Drawing.Size(350, 2);
            this.grbLine_0.TabIndex = 1;
            this.grbLine_0.TabStop = false;
            // 
            // lblExchangeRate
            // 
            this.lblExchangeRate.AutoSize = true;
            this.lblExchangeRate.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExchangeRate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblExchangeRate.Location = new System.Drawing.Point(62, 19);
            this.lblExchangeRate.Name = "lblExchangeRate";
            this.lblExchangeRate.Size = new System.Drawing.Size(149, 24);
            this.lblExchangeRate.TabIndex = 56;
            this.lblExchangeRate.Text = "អាត្រាប្តូរប្រាក់ $ ទៅ ៛";
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.Enabled = false;
            this.txtExchangeRate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExchangeRate.Location = new System.Drawing.Point(217, 18);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.ReadOnly = true;
            this.txtExchangeRate.Size = new System.Drawing.Size(176, 23);
            this.txtExchangeRate.TabIndex = 0;
            this.txtExchangeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Location = new System.Drawing.Point(57, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 2);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // txtAmountReturnRiel
            // 
            this.txtAmountReturnRiel.Enabled = false;
            this.txtAmountReturnRiel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountReturnRiel.Location = new System.Drawing.Point(217, 217);
            this.txtAmountReturnRiel.Name = "txtAmountReturnRiel";
            this.txtAmountReturnRiel.ReadOnly = true;
            this.txtAmountReturnRiel.Size = new System.Drawing.Size(176, 23);
            this.txtAmountReturnRiel.TabIndex = 9;
            this.txtAmountReturnRiel.Text = "0";
            this.txtAmountReturnRiel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAmountReturnRiel
            // 
            this.lblAmountReturnRiel.AutoSize = true;
            this.lblAmountReturnRiel.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountReturnRiel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAmountReturnRiel.Location = new System.Drawing.Point(62, 218);
            this.lblAmountReturnRiel.Name = "lblAmountReturnRiel";
            this.lblAmountReturnRiel.Size = new System.Drawing.Size(136, 24);
            this.lblAmountReturnRiel.TabIndex = 53;
            this.lblAmountReturnRiel.Text = "ទឹកប្រាក់ត្រូវអាប់ (៛)";
            // 
            // lblAmountReturnUsd
            // 
            this.lblAmountReturnUsd.AutoSize = true;
            this.lblAmountReturnUsd.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountReturnUsd.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAmountReturnUsd.Location = new System.Drawing.Point(62, 193);
            this.lblAmountReturnUsd.Name = "lblAmountReturnUsd";
            this.lblAmountReturnUsd.Size = new System.Drawing.Size(138, 24);
            this.lblAmountReturnUsd.TabIndex = 51;
            this.lblAmountReturnUsd.Text = "ទឹកប្រាក់ត្រូវអាប់ ($)";
            // 
            // txtAmountReturnUsd
            // 
            this.txtAmountReturnUsd.Enabled = false;
            this.txtAmountReturnUsd.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountReturnUsd.Location = new System.Drawing.Point(217, 192);
            this.txtAmountReturnUsd.Name = "txtAmountReturnUsd";
            this.txtAmountReturnUsd.ReadOnly = true;
            this.txtAmountReturnUsd.Size = new System.Drawing.Size(176, 23);
            this.txtAmountReturnUsd.TabIndex = 8;
            this.txtAmountReturnUsd.Text = "0";
            this.txtAmountReturnUsd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grbLine_2
            // 
            this.grbLine_2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_2.Location = new System.Drawing.Point(57, 182);
            this.grbLine_2.Name = "grbLine_2";
            this.grbLine_2.Size = new System.Drawing.Size(350, 2);
            this.grbLine_2.TabIndex = 7;
            this.grbLine_2.TabStop = false;
            // 
            // txtAmountPaidRiel
            // 
            this.txtAmountPaidRiel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountPaidRiel.Location = new System.Drawing.Point(217, 150);
            this.txtAmountPaidRiel.Name = "txtAmountPaidRiel";
            this.txtAmountPaidRiel.Size = new System.Drawing.Size(176, 23);
            this.txtAmountPaidRiel.TabIndex = 6;
            this.txtAmountPaidRiel.Text = "0";
            this.txtAmountPaidRiel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmountPaidRiel.Leave += new System.EventHandler(this.TxtAmountPaidRiel_Leave);
            this.txtAmountPaidRiel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPayment_KeyDown);
            // 
            // lblAmoutPaidRiel
            // 
            this.lblAmoutPaidRiel.AutoSize = true;
            this.lblAmoutPaidRiel.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmoutPaidRiel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAmoutPaidRiel.Location = new System.Drawing.Point(62, 151);
            this.lblAmoutPaidRiel.Name = "lblAmoutPaidRiel";
            this.lblAmoutPaidRiel.Size = new System.Drawing.Size(151, 24);
            this.lblAmoutPaidRiel.TabIndex = 48;
            this.lblAmoutPaidRiel.Text = "ទឹកប្រាក់បានទទួល (៛)";
            // 
            // lblAmountPaidUsd
            // 
            this.lblAmountPaidUsd.AutoSize = true;
            this.lblAmountPaidUsd.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountPaidUsd.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAmountPaidUsd.Location = new System.Drawing.Point(62, 126);
            this.lblAmountPaidUsd.Name = "lblAmountPaidUsd";
            this.lblAmountPaidUsd.Size = new System.Drawing.Size(153, 24);
            this.lblAmountPaidUsd.TabIndex = 46;
            this.lblAmountPaidUsd.Text = "ទឹកប្រាក់បានទទួល ($)";
            // 
            // txtAmountPaidUsd
            // 
            this.txtAmountPaidUsd.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountPaidUsd.Location = new System.Drawing.Point(217, 125);
            this.txtAmountPaidUsd.Name = "txtAmountPaidUsd";
            this.txtAmountPaidUsd.Size = new System.Drawing.Size(176, 23);
            this.txtAmountPaidUsd.TabIndex = 5;
            this.txtAmountPaidUsd.Text = "0";
            this.txtAmountPaidUsd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmountPaidUsd.Leave += new System.EventHandler(this.txtAmountPaidUsd_Leave);
            this.txtAmountPaidUsd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPayment_KeyDown);
            // 
            // grbLine_1
            // 
            this.grbLine_1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_1.Location = new System.Drawing.Point(56, 115);
            this.grbLine_1.Name = "grbLine_1";
            this.grbLine_1.Size = new System.Drawing.Size(350, 2);
            this.grbLine_1.TabIndex = 4;
            this.grbLine_1.TabStop = false;
            // 
            // txtTotalAmountRiel
            // 
            this.txtTotalAmountRiel.Enabled = false;
            this.txtTotalAmountRiel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmountRiel.Location = new System.Drawing.Point(217, 84);
            this.txtTotalAmountRiel.Name = "txtTotalAmountRiel";
            this.txtTotalAmountRiel.ReadOnly = true;
            this.txtTotalAmountRiel.Size = new System.Drawing.Size(176, 23);
            this.txtTotalAmountRiel.TabIndex = 3;
            this.txtTotalAmountRiel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayName.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblDisplayName.Location = new System.Drawing.Point(62, 85);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(119, 24);
            this.lblDisplayName.TabIndex = 43;
            this.lblDisplayName.Text = "ទឹកប្រាក់សរុប (៛)";
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCode.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblProductCode.Location = new System.Drawing.Point(62, 60);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(121, 24);
            this.lblProductCode.TabIndex = 41;
            this.lblProductCode.Text = "ទឹកប្រាក់សរុប ($)";
            // 
            // txtTotalAmountUsd
            // 
            this.txtTotalAmountUsd.Enabled = false;
            this.txtTotalAmountUsd.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmountUsd.Location = new System.Drawing.Point(217, 59);
            this.txtTotalAmountUsd.Name = "txtTotalAmountUsd";
            this.txtTotalAmountUsd.ReadOnly = true;
            this.txtTotalAmountUsd.Size = new System.Drawing.Size(176, 23);
            this.txtTotalAmountUsd.TabIndex = 2;
            this.txtTotalAmountUsd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Image = Resources.Cancel32;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(236, 256);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(89, 28);
            this.cmdCancel.TabIndex = 12;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdSave.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Image = Resources.OK32;
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(144, 256);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(89, 28);
            this.cmdSave.TabIndex = 11;
            this.cmdSave.Text = "&Save   ";
            this.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSave.UseVisualStyleBackColor = true;
            // 
            // FrmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(468, 299);
            this.Controls.Add(this.pnlBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmPayment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPayment";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPayment_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPayment_KeyDown);
            this.Load += new System.EventHandler(this.FrmPayment_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.TextBox txtTotalAmountRiel;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.TextBox txtTotalAmountUsd;
        private System.Windows.Forms.GroupBox grbLine_1;
        private System.Windows.Forms.TextBox txtAmountPaidRiel;
        private System.Windows.Forms.Label lblAmoutPaidRiel;
        private System.Windows.Forms.Label lblAmountPaidUsd;
        private System.Windows.Forms.TextBox txtAmountPaidUsd;
        private System.Windows.Forms.TextBox txtAmountReturnRiel;
        private System.Windows.Forms.Label lblAmountReturnRiel;
        private System.Windows.Forms.Label lblAmountReturnUsd;
        private System.Windows.Forms.TextBox txtAmountReturnUsd;
        private System.Windows.Forms.GroupBox grbLine_2;
        private System.Windows.Forms.Label lblExchangeRate;
        private System.Windows.Forms.TextBox txtExchangeRate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grbLine_0;


    }
}