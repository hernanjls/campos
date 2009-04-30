using EzPos.Component;
using EzPos.Properties;

namespace EzPos.GUI.Forms
{
    partial class FrmBase
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderInfo = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.cmdAdvancedOption = new ExtendedButton(this.components);
            this.cmd5 = new ExtendedButton(this.components);
            this.cmd4 = new ExtendedButton(this.components);
            this.cmdQuit = new ExtendedButton(this.components);
            this.cmd3 = new ExtendedButton(this.components);
            this.cmd2 = new ExtendedButton(this.components);
            this.cmd1 = new ExtendedButton(this.components);
            this.pnlBody = new System.Windows.Forms.Panel();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(209)))), ((int)(((byte)(226)))));
            this.pnlHeader.Controls.Add(this.lblHeaderInfo);
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1024, 75);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblHeaderInfo
            // 
            this.lblHeaderInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblHeaderInfo.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderInfo.Location = new System.Drawing.Point(774, 0);
            this.lblHeaderInfo.Name = "lblHeaderInfo";
            this.lblHeaderInfo.Size = new System.Drawing.Size(250, 75);
            this.lblHeaderInfo.TabIndex = 2;
            this.lblHeaderInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Trebuchet MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(4, 7);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(430, 61);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Module Title Here";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(209)))), ((int)(((byte)(226)))));
            this.pnlFooter.Controls.Add(this.cmdAdvancedOption);
            this.pnlFooter.Controls.Add(this.cmd5);
            this.pnlFooter.Controls.Add(this.cmd4);
            this.pnlFooter.Controls.Add(this.cmdQuit);
            this.pnlFooter.Controls.Add(this.cmd3);
            this.pnlFooter.Controls.Add(this.cmd2);
            this.pnlFooter.Controls.Add(this.cmd1);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 693);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1024, 75);
            this.pnlFooter.TabIndex = 4;
            // 
            // cmdAdvancedOption
            // 
            this.cmdAdvancedOption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdAdvancedOption.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAdvancedOption.Font = new System.Drawing.Font("Candara", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdvancedOption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cmdAdvancedOption.Image = Resources.Config32;
            this.cmdAdvancedOption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdvancedOption.Location = new System.Drawing.Point(553, 19);
            this.cmdAdvancedOption.Name = "cmdAdvancedOption";
            this.cmdAdvancedOption.Size = new System.Drawing.Size(109, 37);
            this.cmdAdvancedOption.TabIndex = 6;
            this.cmdAdvancedOption.TabStop = false;
            this.cmdAdvancedOption.Text = "&Advance";
            this.cmdAdvancedOption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAdvancedOption.UseVisualStyleBackColor = true;
            this.cmdAdvancedOption.Click += new System.EventHandler(this.cmdAdvancedOption_Click);
            // 
            // cmd5
            // 
            this.cmd5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmd5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmd5.Font = new System.Drawing.Font("Candara", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cmd5.Location = new System.Drawing.Point(443, 19);
            this.cmd5.Name = "cmd5";
            this.cmd5.Size = new System.Drawing.Size(109, 37);
            this.cmd5.TabIndex = 5;
            this.cmd5.TabStop = false;
            this.cmd5.Text = "Purcha&se";
            this.cmd5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmd5.UseVisualStyleBackColor = true;
            this.cmd5.Click += new System.EventHandler(this.cmd5_Click);
            // 
            // cmd4
            // 
            this.cmd4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmd4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmd4.Font = new System.Drawing.Font("Candara", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cmd4.Image = Resources.customer32;
            this.cmd4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmd4.Location = new System.Drawing.Point(333, 19);
            this.cmd4.Name = "cmd4";
            this.cmd4.Size = new System.Drawing.Size(109, 37);
            this.cmd4.TabIndex = 4;
            this.cmd4.TabStop = false;
            this.cmd4.Text = "&Customer";
            this.cmd4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmd4.UseVisualStyleBackColor = true;
            this.cmd4.Click += new System.EventHandler(this.cmd4_Click);
            // 
            // cmdQuit
            // 
            this.cmdQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdQuit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdQuit.Font = new System.Drawing.Font("Candara", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdQuit.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cmdQuit.Image = Resources.exit32;
            this.cmdQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdQuit.Location = new System.Drawing.Point(912, 19);
            this.cmdQuit.Name = "cmdQuit";
            this.cmdQuit.Size = new System.Drawing.Size(109, 37);
            this.cmdQuit.TabIndex = 3;
            this.cmdQuit.TabStop = false;
            this.cmdQuit.Text = "&Exit";
            this.cmdQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdQuit.UseVisualStyleBackColor = true;
            this.cmdQuit.Click += new System.EventHandler(this.cmdQuit_Click);
            // 
            // cmd3
            // 
            this.cmd3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmd3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmd3.Font = new System.Drawing.Font("Candara", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cmd3.Image = Resources.User32;
            this.cmd3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmd3.Location = new System.Drawing.Point(223, 19);
            this.cmd3.Name = "cmd3";
            this.cmd3.Size = new System.Drawing.Size(109, 37);
            this.cmd3.TabIndex = 2;
            this.cmd3.TabStop = false;
            this.cmd3.Text = "&User";
            this.cmd3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmd3.UseVisualStyleBackColor = true;
            this.cmd3.Click += new System.EventHandler(this.cmd3_Click);
            // 
            // cmd2
            // 
            this.cmd2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmd2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmd2.Font = new System.Drawing.Font("Candara", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cmd2.Image = Resources.Product32;
            this.cmd2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmd2.Location = new System.Drawing.Point(113, 19);
            this.cmd2.Name = "cmd2";
            this.cmd2.Size = new System.Drawing.Size(109, 37);
            this.cmd2.TabIndex = 1;
            this.cmd2.TabStop = false;
            this.cmd2.Text = "&Product";
            this.cmd2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmd2.UseVisualStyleBackColor = true;
            this.cmd2.Click += new System.EventHandler(this.cmd2_Click);
            // 
            // cmd1
            // 
            this.cmd1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmd1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmd1.Font = new System.Drawing.Font("Candara", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cmd1.Image = Resources.Sale32;
            this.cmd1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmd1.Location = new System.Drawing.Point(3, 19);
            this.cmd1.Name = "cmd1";
            this.cmd1.Size = new System.Drawing.Size(109, 37);
            this.cmd1.TabIndex = 0;
            this.cmd1.TabStop = false;
            this.cmd1.Text = "&Sale";
            this.cmd1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmd1.UseVisualStyleBackColor = true;
            this.cmd1.Click += new System.EventHandler(this.cmd1_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 75);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1024, 618);
            this.pnlBody.TabIndex = 5;
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Interval = 1000;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // FrmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        public System.Windows.Forms.Panel pnlBody;
        private ExtendedButton cmdQuit;
        public System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Label lblHeader;
        public ExtendedButton cmd1;
        public ExtendedButton cmd2;
        public ExtendedButton cmd3;
        public ExtendedButton cmd4;
        public ExtendedButton cmd5;
        public ExtendedButton cmdAdvancedOption;
        private System.Windows.Forms.Label lblHeaderInfo;
        private System.Windows.Forms.Timer tmrRefresh;
    }
}