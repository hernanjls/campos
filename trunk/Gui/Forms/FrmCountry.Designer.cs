using EzPos.Properties;

namespace EzPos.GUI
{
    partial class FrmCountry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblExchangeRate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgvCountry = new System.Windows.Forms.DataGridView();
            this.CountryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountry)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Image = Resources.Cancel32;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(318, 325);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(89, 28);
            this.cmdCancel.TabIndex = 12;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lblExchangeRate
            // 
            this.lblExchangeRate.AutoSize = true;
            this.lblExchangeRate.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExchangeRate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblExchangeRate.Location = new System.Drawing.Point(62, 19);
            this.lblExchangeRate.Name = "lblExchangeRate";
            this.lblExchangeRate.Size = new System.Drawing.Size(138, 24);
            this.lblExchangeRate.TabIndex = 56;
            this.lblExchangeRate.Text = "តារាងឈ្មោះប្រទេស";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Location = new System.Drawing.Point(57, 317);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 2);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // pnlBody
            // 
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody.Controls.Add(this.dgvCountry);
            this.pnlBody.Controls.Add(this.lblExchangeRate);
            this.pnlBody.Controls.Add(this.groupBox1);
            this.pnlBody.Controls.Add(this.cmdCancel);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(468, 386);
            this.pnlBody.TabIndex = 1;
            // 
            // dgvCountry
            // 
            this.dgvCountry.AllowUserToResizeColumns = false;
            this.dgvCountry.AllowUserToResizeRows = false;
            this.dgvCountry.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCountry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCountry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCountry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCountry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CountryID,
            this.CountryName});
            this.dgvCountry.Location = new System.Drawing.Point(57, 44);
            this.dgvCountry.Name = "dgvCountry";
            this.dgvCountry.RowHeadersVisible = false;
            this.dgvCountry.RowHeadersWidth = 25;
            this.dgvCountry.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCountry.RowTemplate.Height = 35;
            this.dgvCountry.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCountry.ShowCellToolTips = false;
            this.dgvCountry.Size = new System.Drawing.Size(367, 264);
            this.dgvCountry.TabIndex = 57;
            this.dgvCountry.VirtualMode = true;
            this.dgvCountry.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCountry_RowValidating);
            this.dgvCountry.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCountry_RowValidated);
            this.dgvCountry.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCountry_CellValueChanged);
            this.dgvCountry.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvCountry_DataError);
            // 
            // CountryID
            // 
            this.CountryID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CountryID.DataPropertyName = "CountryID";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountryID.DefaultCellStyle = dataGridViewCellStyle2;
            this.CountryID.HeaderText = "លេខរៀង";
            this.CountryID.Name = "CountryID";
            this.CountryID.ReadOnly = true;
            this.CountryID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CountryID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CountryID.Visible = false;
            // 
            // CountryName
            // 
            this.CountryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CountryName.DataPropertyName = "CountryName";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountryName.DefaultCellStyle = dataGridViewCellStyle3;
            this.CountryName.HeaderText = "ឈ្មោះប្រទេស";
            this.CountryName.Name = "CountryName";
            this.CountryName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CountryName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CountryName.Width = 348;
            // 
            // FrmCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(468, 386);
            this.Controls.Add(this.pnlBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCountry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Country";
            this.Load += new System.EventHandler(this.FrmCountry_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lblExchangeRate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.DataGridView dgvCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryName;
    }
}