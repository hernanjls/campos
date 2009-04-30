using EzPos.Properties;

namespace EzPos.GUI
{
    partial class FrmLogIn_
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogIn_));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pcbLogIn = new System.Windows.Forms.PictureBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.cmdQuit = new System.Windows.Forms.Button();
            this.cmdLogIn = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtLogIn = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblLogIn = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogIn)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(209)))), ((int)(((byte)(226)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Controls.Add(this.pcbLogIn);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(382, 57);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(71, 12);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(240, 32);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "Authentication";
            // 
            // pcbLogIn
            // 
            this.pcbLogIn.Image = ((System.Drawing.Image)(resources.GetObject("pcbLogIn.Image")));
            this.pcbLogIn.Location = new System.Drawing.Point(12, 5);
            this.pcbLogIn.Name = "pcbLogIn";
            this.pcbLogIn.Size = new System.Drawing.Size(49, 49);
            this.pcbLogIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pcbLogIn.TabIndex = 1;
            this.pcbLogIn.TabStop = false;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBody.Controls.Add(this.cmdQuit);
            this.pnlBody.Controls.Add(this.cmdLogIn);
            this.pnlBody.Controls.Add(this.txtPwd);
            this.pnlBody.Controls.Add(this.txtLogIn);
            this.pnlBody.Controls.Add(this.lblPassword);
            this.pnlBody.Controls.Add(this.lblLogIn);
            this.pnlBody.Controls.Add(this.lblInfo);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 57);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(382, 147);
            this.pnlBody.TabIndex = 1;
            // 
            // cmdQuit
            // 
            this.cmdQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdQuit.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdQuit.Image = Resources.Cancel32;
            this.cmdQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdQuit.Location = new System.Drawing.Point(235, 107);
            this.cmdQuit.Name = "cmdQuit";
            this.cmdQuit.Size = new System.Drawing.Size(89, 28);
            this.cmdQuit.TabIndex = 6;
            this.cmdQuit.Text = "&Quit";
            this.cmdQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdQuit.UseVisualStyleBackColor = true;
            this.cmdQuit.Click += new System.EventHandler(this.cmdQuit_Click);
            // 
            // cmdLogIn
            // 
            this.cmdLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdLogIn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLogIn.Image = Resources.OK32;
            this.cmdLogIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLogIn.Location = new System.Drawing.Point(140, 107);
            this.cmdLogIn.Name = "cmdLogIn";
            this.cmdLogIn.Size = new System.Drawing.Size(89, 28);
            this.cmdLogIn.TabIndex = 5;
            this.cmdLogIn.Text = "&Login";
            this.cmdLogIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdLogIn.UseVisualStyleBackColor = true;
            this.cmdLogIn.Click += new System.EventHandler(this.cmdLogIn_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPwd.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPwd.Location = new System.Drawing.Point(140, 82);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = 'º';
            this.txtPwd.Size = new System.Drawing.Size(184, 21);
            this.txtPwd.TabIndex = 4;
            this.txtPwd.Leave += new System.EventHandler(this.txtPwd_Leave);
            this.txtPwd.Enter += new System.EventHandler(this.txtPwd_Enter);
            // 
            // txtLogIn
            // 
            this.txtLogIn.AcceptsTab = true;
            this.txtLogIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogIn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogIn.Location = new System.Drawing.Point(140, 57);
            this.txtLogIn.Name = "txtLogIn";
            this.txtLogIn.Size = new System.Drawing.Size(184, 21);
            this.txtLogIn.TabIndex = 3;
            this.txtLogIn.Tag = "";
            this.txtLogIn.Leave += new System.EventHandler(this.txtLogIn_Leave);
            this.txtLogIn.Enter += new System.EventHandler(this.txtLogIn_Enter);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPassword.Location = new System.Drawing.Point(49, 85);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 15);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password :";
            // 
            // lblLogIn
            // 
            this.lblLogIn.AutoSize = true;
            this.lblLogIn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogIn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLogIn.Location = new System.Drawing.Point(49, 59);
            this.lblLogIn.Name = "lblLogIn";
            this.lblLogIn.Size = new System.Drawing.Size(47, 15);
            this.lblLogIn.TabIndex = 1;
            this.lblLogIn.Text = "Log in :";
            // 
            // lblInfo
            // 
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblInfo.Location = new System.Drawing.Point(0, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(382, 48);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Please enter User name and Password provided by PharmaStock administrator to star" +
                "t the session.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmLogIn_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdQuit;
            this.ClientSize = new System.Drawing.Size(382, 204);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogIn_";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   .: PharmaStock :.";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogIn)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblLogIn;
        private System.Windows.Forms.TextBox txtLogIn;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button cmdQuit;
        private System.Windows.Forms.Button cmdLogIn;
        private System.Windows.Forms.PictureBox pcbLogIn;
        private System.Windows.Forms.Label lblHeader;
    }
}