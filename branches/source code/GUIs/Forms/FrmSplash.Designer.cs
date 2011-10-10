
namespace EzPos.GUIs.Forms
{
    partial class FrmSplash
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBody_Left = new System.Windows.Forms.Panel();
            this.lblInfoLeft = new System.Windows.Forms.Label();
            this.pnlBody_Right = new System.Windows.Forms.Panel();
            this.lblInitialization = new System.Windows.Forms.Label();
            this.pgbCustomizedConfig = new System.Windows.Forms.ProgressBar();
            this.lblCustomizedConfig = new System.Windows.Forms.Label();
            this.pgbInitialization = new System.Windows.Forms.ProgressBar();
            this.lblGlobalConfig = new System.Windows.Forms.Label();
            this.pgbGlobalConfig = new System.Windows.Forms.ProgressBar();
            this.lblService = new System.Windows.Forms.Label();
            this.pgbService = new System.Windows.Forms.ProgressBar();
            this.pnlBody_Left.SuspendLayout();
            this.pnlBody_Right.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody_Left
            // 
            this.pnlBody_Left.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody_Left.BackgroundImage = global::EzPos.Properties.Resources.backgroud_11;
            this.pnlBody_Left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBody_Left.Controls.Add(this.lblInfoLeft);
            this.pnlBody_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBody_Left.Location = new System.Drawing.Point(0, 0);
            this.pnlBody_Left.Name = "pnlBody_Left";
            this.pnlBody_Left.Size = new System.Drawing.Size(80, 312);
            this.pnlBody_Left.TabIndex = 0;
            // 
            // lblInfoLeft
            // 
            this.lblInfoLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfoLeft.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoLeft.ForeColor = System.Drawing.Color.Yellow;
            this.lblInfoLeft.Location = new System.Drawing.Point(0, 0);
            this.lblInfoLeft.Name = "lblInfoLeft";
            this.lblInfoLeft.Size = new System.Drawing.Size(80, 312);
            this.lblInfoLeft.TabIndex = 0;
            this.lblInfoLeft.Text = "E\n\nZ\n\nP\n\nO\n\nS";
            this.lblInfoLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBody_Right
            // 
            this.pnlBody_Right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlBody_Right.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody_Right.Controls.Add(this.lblInitialization);
            this.pnlBody_Right.Controls.Add(this.pgbCustomizedConfig);
            this.pnlBody_Right.Controls.Add(this.lblCustomizedConfig);
            this.pnlBody_Right.Controls.Add(this.pgbInitialization);
            this.pnlBody_Right.Controls.Add(this.lblGlobalConfig);
            this.pnlBody_Right.Controls.Add(this.pgbGlobalConfig);
            this.pnlBody_Right.Controls.Add(this.lblService);
            this.pnlBody_Right.Controls.Add(this.pgbService);
            this.pnlBody_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody_Right.Location = new System.Drawing.Point(80, 0);
            this.pnlBody_Right.Name = "pnlBody_Right";
            this.pnlBody_Right.Size = new System.Drawing.Size(422, 312);
            this.pnlBody_Right.TabIndex = 1;
            // 
            // lblInitialization
            // 
            this.lblInitialization.AutoSize = true;
            this.lblInitialization.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitialization.Location = new System.Drawing.Point(55, 159);
            this.lblInitialization.Name = "lblInitialization";
            this.lblInitialization.Size = new System.Drawing.Size(169, 19);
            this.lblInitialization.TabIndex = 4;
            this.lblInitialization.Text = "Initializing worksapce ...";
            // 
            // pgbCustomizedConfig
            // 
            this.pgbCustomizedConfig.ForeColor = System.Drawing.Color.Transparent;
            this.pgbCustomizedConfig.Location = new System.Drawing.Point(59, 231);
            this.pgbCustomizedConfig.Name = "pgbCustomizedConfig";
            this.pgbCustomizedConfig.Size = new System.Drawing.Size(307, 10);
            this.pgbCustomizedConfig.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbCustomizedConfig.TabIndex = 7;
            // 
            // lblCustomizedConfig
            // 
            this.lblCustomizedConfig.AutoSize = true;
            this.lblCustomizedConfig.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomizedConfig.Location = new System.Drawing.Point(55, 204);
            this.lblCustomizedConfig.Name = "lblCustomizedConfig";
            this.lblCustomizedConfig.Size = new System.Drawing.Size(256, 19);
            this.lblCustomizedConfig.TabIndex = 6;
            this.lblCustomizedConfig.Text = "Loading customized configuration ...";
            // 
            // pgbInitialization
            // 
            this.pgbInitialization.ForeColor = System.Drawing.Color.Transparent;
            this.pgbInitialization.Location = new System.Drawing.Point(59, 186);
            this.pgbInitialization.Name = "pgbInitialization";
            this.pgbInitialization.Size = new System.Drawing.Size(307, 10);
            this.pgbInitialization.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbInitialization.TabIndex = 5;
            // 
            // lblGlobalConfig
            // 
            this.lblGlobalConfig.AutoSize = true;
            this.lblGlobalConfig.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlobalConfig.Location = new System.Drawing.Point(55, 114);
            this.lblGlobalConfig.Name = "lblGlobalConfig";
            this.lblGlobalConfig.Size = new System.Drawing.Size(221, 19);
            this.lblGlobalConfig.TabIndex = 2;
            this.lblGlobalConfig.Text = "Loading global configuration ...";
            // 
            // pgbGlobalConfig
            // 
            this.pgbGlobalConfig.ForeColor = System.Drawing.Color.Transparent;
            this.pgbGlobalConfig.Location = new System.Drawing.Point(59, 141);
            this.pgbGlobalConfig.Name = "pgbGlobalConfig";
            this.pgbGlobalConfig.Size = new System.Drawing.Size(307, 10);
            this.pgbGlobalConfig.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbGlobalConfig.TabIndex = 3;
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblService.Location = new System.Drawing.Point(55, 69);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(129, 19);
            this.lblService.TabIndex = 0;
            this.lblService.Text = "Loading service ...";
            // 
            // pgbService
            // 
            this.pgbService.ForeColor = System.Drawing.Color.Transparent;
            this.pgbService.Location = new System.Drawing.Point(59, 96);
            this.pgbService.Name = "pgbService";
            this.pgbService.Size = new System.Drawing.Size(307, 10);
            this.pgbService.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbService.TabIndex = 1;
            // 
            // FrmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(502, 312);
            this.Controls.Add(this.pnlBody_Right);
            this.Controls.Add(this.pnlBody_Left);
            this.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmSplash_Load);
            this.pnlBody_Left.ResumeLayout(false);
            this.pnlBody_Right.ResumeLayout(false);
            this.pnlBody_Right.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody_Left;
        private System.Windows.Forms.Label lblInfoLeft;
        private System.Windows.Forms.Panel pnlBody_Right;
        private System.Windows.Forms.Label lblInitialization;
        private System.Windows.Forms.ProgressBar pgbCustomizedConfig;
        private System.Windows.Forms.Label lblCustomizedConfig;
        private System.Windows.Forms.ProgressBar pgbInitialization;
        private System.Windows.Forms.Label lblGlobalConfig;
        private System.Windows.Forms.ProgressBar pgbGlobalConfig;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.ProgressBar pgbService;
    }
}