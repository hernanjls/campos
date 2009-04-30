using EzPos.Properties;

namespace EzPos.GUI
{
    partial class FrmLaboratory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblExchangeRate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgvLaboratory = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LaboratoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LaboratoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Website = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaboratory)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Image = Resources.Cancel32;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(553, 324);
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
            this.lblExchangeRate.Size = new System.Drawing.Size(136, 24);
            this.lblExchangeRate.TabIndex = 56;
            this.lblExchangeRate.Text = "តារាងមន្ទីរពិសោធន៏";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Location = new System.Drawing.Point(57, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 2);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // pnlBody
            // 
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody.Controls.Add(this.dgvLaboratory);
            this.pnlBody.Controls.Add(this.lblExchangeRate);
            this.pnlBody.Controls.Add(this.groupBox1);
            this.pnlBody.Controls.Add(this.cmdCancel);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(702, 386);
            this.pnlBody.TabIndex = 1;
            // 
            // dgvLaboratory
            // 
            this.dgvLaboratory.AllowUserToResizeColumns = false;
            this.dgvLaboratory.AllowUserToResizeRows = false;
            this.dgvLaboratory.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLaboratory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLaboratory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLaboratory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaboratory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LaboratoryID,
            this.LaboratoryName,
            this.CountryID,
            this.Address,
            this.Telephone,
            this.Email,
            this.Website});
            this.dgvLaboratory.Location = new System.Drawing.Point(57, 44);
            this.dgvLaboratory.Name = "dgvLaboratory";
            this.dgvLaboratory.RowHeadersVisible = false;
            this.dgvLaboratory.RowHeadersWidth = 25;
            this.dgvLaboratory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLaboratory.RowTemplate.Height = 35;
            this.dgvLaboratory.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLaboratory.ShowCellToolTips = false;
            this.dgvLaboratory.Size = new System.Drawing.Size(585, 263);
            this.dgvLaboratory.TabIndex = 57;
            this.dgvLaboratory.VirtualMode = true;
            this.dgvLaboratory.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvLaboratory_RowValidating);
            this.dgvLaboratory.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLaboratory_RowValidated);
            this.dgvLaboratory.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLaboratory_CellValueChanged);
            this.dgvLaboratory.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvLaboratory_DataError);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Address";
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn3.HeaderText = "អាស័យដ្ឋាន";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 350;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Telephone";
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn4.HeaderText = "លេខទូរស័ព្ទ";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Email";
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn5.HeaderText = "សារអេឡិចត្រូនិច";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Website";
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn6.HeaderText = "គេហទំព័រ";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // LaboratoryID
            // 
            this.LaboratoryID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LaboratoryID.DataPropertyName = "LaboratoryID";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LaboratoryID.DefaultCellStyle = dataGridViewCellStyle2;
            this.LaboratoryID.HeaderText = "លេខរៀង";
            this.LaboratoryID.Name = "LaboratoryID";
            this.LaboratoryID.ReadOnly = true;
            this.LaboratoryID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LaboratoryID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LaboratoryID.Visible = false;
            // 
            // LaboratoryName
            // 
            this.LaboratoryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LaboratoryName.DataPropertyName = "LaboratoryName";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LaboratoryName.DefaultCellStyle = dataGridViewCellStyle3;
            this.LaboratoryName.HeaderText = "ឈ្មោះមន្ទីពិសោធន៏";
            this.LaboratoryName.Name = "LaboratoryName";
            this.LaboratoryName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LaboratoryName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LaboratoryName.Width = 350;
            // 
            // CountryID
            // 
            this.CountryID.DataPropertyName = "CountryID";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.CountryID.DefaultCellStyle = dataGridViewCellStyle4;
            this.CountryID.HeaderText = "ប្រទេស";
            this.CountryID.Name = "CountryID";
            this.CountryID.Width = 150;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.Address.DefaultCellStyle = dataGridViewCellStyle5;
            this.Address.HeaderText = "អាស័យដ្ឋាន";
            this.Address.Name = "Address";
            this.Address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Address.Width = 350;
            // 
            // Telephone
            // 
            this.Telephone.DataPropertyName = "Telephone";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.Telephone.DefaultCellStyle = dataGridViewCellStyle6;
            this.Telephone.HeaderText = "លេខទូរស័ព្ទ";
            this.Telephone.Name = "Telephone";
            this.Telephone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Telephone.Width = 150;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.Email.DefaultCellStyle = dataGridViewCellStyle7;
            this.Email.HeaderText = "សារអេឡិចត្រូនិច";
            this.Email.Name = "Email";
            this.Email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Email.Width = 150;
            // 
            // Website
            // 
            this.Website.DataPropertyName = "Website";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.Website.DefaultCellStyle = dataGridViewCellStyle8;
            this.Website.HeaderText = "គេហទំព័រ";
            this.Website.Name = "Website";
            this.Website.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Website.Width = 150;
            // 
            // FrmLaboratory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(702, 386);
            this.Controls.Add(this.pnlBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLaboratory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laboratory";
            this.Load += new System.EventHandler(this.FrmLaboratory_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaboratory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lblExchangeRate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.DataGridView dgvLaboratory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn LaboratoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LaboratoryName;
        private System.Windows.Forms.DataGridViewComboBoxColumn CountryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Website;
    }
}