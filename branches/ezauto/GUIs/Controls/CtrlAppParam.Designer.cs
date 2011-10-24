namespace EzPos.GUIs.Controls
{
    partial class CtrlAppParam
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAppParameter = new System.Windows.Forms.DataGridView();
            this.ParameterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParameterLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParameterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParameterValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsbAppParam = new System.Windows.Forms.ListBox();
            this.cmbAppParamValue = new System.Windows.Forms.ComboBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppParameter)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAppParameter
            // 
            this.dgvAppParameter.AllowUserToResizeColumns = false;
            this.dgvAppParameter.AllowUserToResizeRows = false;
            this.dgvAppParameter.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppParameter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAppParameter.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvAppParameter.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppParameter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAppParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppParameter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParameterID,
            this.ParameterLabel,
            this.ParameterCode,
            this.ParameterValue});
            this.dgvAppParameter.EnableHeadersVisualStyles = false;
            this.dgvAppParameter.GridColor = System.Drawing.Color.Silver;
            this.dgvAppParameter.Location = new System.Drawing.Point(303, 8);
            this.dgvAppParameter.MultiSelect = false;
            this.dgvAppParameter.Name = "dgvAppParameter";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppParameter.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAppParameter.RowHeadersWidth = 28;
            this.dgvAppParameter.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAppParameter.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAppParameter.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Candara", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAppParameter.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.dgvAppParameter.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dgvAppParameter.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvAppParameter.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Maroon;
            this.dgvAppParameter.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppParameter.RowTemplate.Height = 35;
            this.dgvAppParameter.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAppParameter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppParameter.ShowCellToolTips = false;
            this.dgvAppParameter.Size = new System.Drawing.Size(708, 592);
            this.dgvAppParameter.TabIndex = 2;
            this.dgvAppParameter.VirtualMode = true;
            this.dgvAppParameter.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppParameter_CellValueChanged);
            this.dgvAppParameter.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvAppParameter_UserDeletingRow);
            this.dgvAppParameter.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvAppParameter_RowValidating);
            this.dgvAppParameter.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.dgvAppParameter_CancelRowEdit);
            this.dgvAppParameter.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppParameter_RowValidated);
            this.dgvAppParameter.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvAppParameter_DataError);
            // 
            // ParameterID
            // 
            this.ParameterID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ParameterID.DataPropertyName = "ParameterID";
            this.ParameterID.HeaderText = "ParameterID";
            this.ParameterID.Name = "ParameterID";
            this.ParameterID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ParameterID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ParameterID.Visible = false;
            // 
            // ParameterLabel
            // 
            this.ParameterLabel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ParameterLabel.DataPropertyName = "ParameterLabel";
            this.ParameterLabel.HeaderText = "បរិយាយ";
            this.ParameterLabel.Name = "ParameterLabel";
            this.ParameterLabel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ParameterLabel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ParameterLabel.Width = 330;
            // 
            // ParameterCode
            // 
            this.ParameterCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ParameterCode.DataPropertyName = "ParameterCode";
            this.ParameterCode.HeaderText = "លេខកូដ";
            this.ParameterCode.Name = "ParameterCode";
            this.ParameterCode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ParameterCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ParameterCode.Width = 165;
            // 
            // ParameterValue
            // 
            this.ParameterValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ParameterValue.DataPropertyName = "ParameterValue";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Khmer OS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterValue.DefaultCellStyle = dataGridViewCellStyle2;
            this.ParameterValue.HeaderText = "តំលៃ";
            this.ParameterValue.Name = "ParameterValue";
            this.ParameterValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ParameterValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ParameterValue.Width = 165;
            // 
            // lsbAppParam
            // 
            this.lsbAppParam.Font = new System.Drawing.Font("Candara", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbAppParam.FormattingEnabled = true;
            this.lsbAppParam.HorizontalScrollbar = true;
            this.lsbAppParam.ItemHeight = 28;
            this.lsbAppParam.Location = new System.Drawing.Point(13, 8);
            this.lsbAppParam.Name = "lsbAppParam";
            this.lsbAppParam.Size = new System.Drawing.Size(282, 592);
            this.lsbAppParam.TabIndex = 0;
            this.lsbAppParam.SelectedIndexChanged += new System.EventHandler(this.lsbProduct_SelectedIndexChanged);
            // 
            // cmbAppParamValue
            // 
            this.cmbAppParamValue.FormattingEnabled = true;
            this.cmbAppParamValue.Location = new System.Drawing.Point(13, -3);
            this.cmbAppParamValue.Name = "cmbAppParamValue";
            this.cmbAppParamValue.Size = new System.Drawing.Size(282, 21);
            this.cmbAppParamValue.Sorted = true;
            this.cmbAppParamValue.TabIndex = 2;
            this.cmbAppParamValue.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ParameterID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ParameterID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ParameterLabel";
            this.dataGridViewTextBoxColumn2.HeaderText = "Label";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ParameterCode";
            this.dataGridViewTextBoxColumn3.HeaderText = "Code";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 175;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ParameterValue";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Khmer OS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn4.HeaderText = "Value";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 290;
            // 
            // CtrlAppParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lsbAppParam);
            this.Controls.Add(this.dgvAppParameter);
            this.Controls.Add(this.cmbAppParamValue);
            this.Name = "CtrlAppParam";
            this.Size = new System.Drawing.Size(1014, 603);
            this.Load += new System.EventHandler(this.CtrBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppParameter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lsbAppParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView dgvAppParameter;
        private System.Windows.Forms.ComboBox cmbAppParamValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterValue;



    }
}