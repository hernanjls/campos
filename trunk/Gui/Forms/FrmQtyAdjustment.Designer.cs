using EzPos.Properties;

namespace EzPos.GUI
{
    partial class FrmQtyAdjustment
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblQtyAdjusted = new System.Windows.Forms.Label();
            this.txtQtyAdjusted = new System.Windows.Forms.TextBox();
            this.lblCurrentQty = new System.Windows.Forms.Label();
            this.txtCurrentQty = new System.Windows.Forms.TextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Image = Resources.Cancel32;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(227, 194);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(89, 28);
            this.cmdCancel.TabIndex = 6;
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
            this.cmdSave.Location = new System.Drawing.Point(135, 194);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(89, 28);
            this.cmdSave.TabIndex = 5;
            this.cmdSave.Text = "&Save   ";
            this.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSave.UseVisualStyleBackColor = true;
            // 
            // lblQtyAdjusted
            // 
            this.lblQtyAdjusted.AutoSize = true;
            this.lblQtyAdjusted.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyAdjusted.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblQtyAdjusted.Location = new System.Drawing.Point(82, 126);
            this.lblQtyAdjusted.Name = "lblQtyAdjusted";
            this.lblQtyAdjusted.Size = new System.Drawing.Size(75, 24);
            this.lblQtyAdjusted.TabIndex = 3;
            this.lblQtyAdjusted.Text = "បរិមាណថ្មី";
            // 
            // txtQtyAdjusted
            // 
            this.txtQtyAdjusted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtyAdjusted.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtyAdjusted.Location = new System.Drawing.Point(163, 125);
            this.txtQtyAdjusted.Name = "txtQtyAdjusted";
            this.txtQtyAdjusted.Size = new System.Drawing.Size(205, 23);
            this.txtQtyAdjusted.TabIndex = 4;
            this.txtQtyAdjusted.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyAdjusted.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQtyAdjusted_KeyDown);
            // 
            // lblCurrentQty
            // 
            this.lblCurrentQty.AutoSize = true;
            this.lblCurrentQty.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentQty.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCurrentQty.Location = new System.Drawing.Point(43, 101);
            this.lblCurrentQty.Name = "lblCurrentQty";
            this.lblCurrentQty.Size = new System.Drawing.Size(114, 24);
            this.lblCurrentQty.TabIndex = 1;
            this.lblCurrentQty.Text = "បរិមាណបច្ចុប្បន្ន";
            // 
            // txtCurrentQty
            // 
            this.txtCurrentQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentQty.Enabled = false;
            this.txtCurrentQty.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentQty.Location = new System.Drawing.Point(163, 100);
            this.txtCurrentQty.Name = "txtCurrentQty";
            this.txtCurrentQty.ReadOnly = true;
            this.txtCurrentQty.Size = new System.Drawing.Size(205, 23);
            this.txtCurrentQty.TabIndex = 2;
            this.txtCurrentQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(450, 66);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "ការផ្លាស់ប្ដូរបរិមាណលក់";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmQtyAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 250);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblCurrentQty);
            this.Controls.Add(this.txtCurrentQty);
            this.Controls.Add(this.lblQtyAdjusted);
            this.Controls.Add(this.txtQtyAdjusted);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQtyAdjustment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmQtyAdjustment_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmQtyAdjustment_KeyDown);
            this.Load += new System.EventHandler(this.FrmQtyAdjustment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label lblQtyAdjusted;
        private System.Windows.Forms.TextBox txtQtyAdjusted;
        private System.Windows.Forms.Label lblCurrentQty;
        private System.Windows.Forms.TextBox txtCurrentQty;
        private System.Windows.Forms.Label lblHeader;
    }
}