using ExtendedComboBox=EzPos.GUIs.Components.ExtendedComboBox;

namespace EzPos.GUIs.Controls
{
    partial class CtrlExpense
    {

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBodyLeft = new System.Windows.Forms.Panel();
            this.dgvExpense = new System.Windows.Forms.DataGridView();
            this.pnlBodySearch = new System.Windows.Forms.Panel();
            this.dtpStopDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblResultInfo = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.cmdSearchProduct = new System.Windows.Forms.Button();
            this.lblExpenseType = new System.Windows.Forms.Label();
            this.lblStopDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlBodyRight = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.cmbExpenseType = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.ExpenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpenseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpenseTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpenseTypeStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpenseAmountInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpenseAmountRiel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExchangeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBodyLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).BeginInit();
            this.pnlBodySearch.SuspendLayout();
            this.pnlBodyRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBodyLeft
            // 
            this.pnlBodyLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBodyLeft.Controls.Add(this.dgvExpense);
            this.pnlBodyLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBodyLeft.Location = new System.Drawing.Point(0, 120);
            this.pnlBodyLeft.Name = "pnlBodyLeft";
            this.pnlBodyLeft.Size = new System.Drawing.Size(824, 471);
            this.pnlBodyLeft.TabIndex = 5;
            // 
            // dgvExpense
            // 
            this.dgvExpense.AllowUserToAddRows = false;
            this.dgvExpense.AllowUserToDeleteRows = false;
            this.dgvExpense.AllowUserToResizeColumns = false;
            this.dgvExpense.AllowUserToResizeRows = false;
            this.dgvExpense.BackgroundColor = System.Drawing.Color.White;
            this.dgvExpense.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvExpense.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExpense.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExpense.ColumnHeadersHeight = 40;
            this.dgvExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvExpense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExpenseID,
            this.ExpenseDate,
            this.ExpenseTypeID,
            this.ExpenseTypeStr,
            this.Description,
            this.ExpenseAmountInt,
            this.ExpenseAmountRiel,
            this.CurrencyID,
            this.ExchangeRate});
            this.dgvExpense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExpense.EnableHeadersVisualStyles = false;
            this.dgvExpense.GridColor = System.Drawing.Color.White;
            this.dgvExpense.Location = new System.Drawing.Point(0, 0);
            this.dgvExpense.MultiSelect = false;
            this.dgvExpense.Name = "dgvExpense";
            this.dgvExpense.ReadOnly = true;
            this.dgvExpense.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvExpense.RowHeadersVisible = false;
            this.dgvExpense.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvExpense.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Candara", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvExpense.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.dgvExpense.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dgvExpense.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvExpense.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Maroon;
            this.dgvExpense.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExpense.RowTemplate.Height = 50;
            this.dgvExpense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpense.Size = new System.Drawing.Size(822, 469);
            this.dgvExpense.TabIndex = 1;
            this.dgvExpense.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvExpenseCellDoubleClick);
            this.dgvExpense.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvExpenseDataError);
            // 
            // pnlBodySearch
            // 
            this.pnlBodySearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBodySearch.Controls.Add(this.dtpStopDate);
            this.pnlBodySearch.Controls.Add(this.dtpStartDate);
            this.pnlBodySearch.Controls.Add(this.lblResultInfo);
            this.pnlBodySearch.Controls.Add(this.btnReset);
            this.pnlBodySearch.Controls.Add(this.cmdSearchProduct);
            this.pnlBodySearch.Controls.Add(this.lblExpenseType);
            this.pnlBodySearch.Controls.Add(this.lblStopDate);
            this.pnlBodySearch.Controls.Add(this.lblStartDate);
            this.pnlBodySearch.Controls.Add(this.cmbExpenseType);
            this.pnlBodySearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBodySearch.Location = new System.Drawing.Point(0, 0);
            this.pnlBodySearch.Name = "pnlBodySearch";
            this.pnlBodySearch.Size = new System.Drawing.Size(824, 120);
            this.pnlBodySearch.TabIndex = 4;
            // 
            // dtpStopDate
            // 
            this.dtpStopDate.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStopDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStopDate.Location = new System.Drawing.Point(370, 12);
            this.dtpStopDate.Name = "dtpStopDate";
            this.dtpStopDate.Size = new System.Drawing.Size(181, 27);
            this.dtpStopDate.TabIndex = 18;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(106, 12);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(181, 27);
            this.dtpStartDate.TabIndex = 17;
            // 
            // lblResultInfo
            // 
            this.lblResultInfo.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultInfo.Location = new System.Drawing.Point(8, 86);
            this.lblResultInfo.Name = "lblResultInfo";
            this.lblResultInfo.Size = new System.Drawing.Size(794, 27);
            this.lblResultInfo.TabIndex = 16;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::EzPos.Properties.Resources.Undo32;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnReset.Location = new System.Drawing.Point(625, 45);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(89, 28);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "&Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // cmdSearchProduct
            // 
            this.cmdSearchProduct.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearchProduct.Image = global::EzPos.Properties.Resources.Search32;
            this.cmdSearchProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearchProduct.Location = new System.Drawing.Point(717, 45);
            this.cmdSearchProduct.Name = "cmdSearchProduct";
            this.cmdSearchProduct.Size = new System.Drawing.Size(89, 28);
            this.cmdSearchProduct.TabIndex = 13;
            this.cmdSearchProduct.Text = "&Search";
            this.cmdSearchProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSearchProduct.UseVisualStyleBackColor = true;
            this.cmdSearchProduct.Click += new System.EventHandler(this.CmdSearchProductClick);
            // 
            // lblExpenseType
            // 
            this.lblExpenseType.AutoSize = true;
            this.lblExpenseType.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpenseType.Location = new System.Drawing.Point(557, 13);
            this.lblExpenseType.Name = "lblExpenseType";
            this.lblExpenseType.Size = new System.Drawing.Size(62, 27);
            this.lblExpenseType.TabIndex = 9;
            this.lblExpenseType.Text = "ប្រភេទ";
            // 
            // lblStopDate
            // 
            this.lblStopDate.AutoSize = true;
            this.lblStopDate.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStopDate.Location = new System.Drawing.Point(292, 13);
            this.lblStopDate.Name = "lblStopDate";
            this.lblStopDate.Size = new System.Drawing.Size(73, 27);
            this.lblStopDate.TabIndex = 8;
            this.lblStopDate.Text = "ថ្ងៃបញ្ចប់";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Khmer OS System", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(8, 13);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(92, 27);
            this.lblStartDate.TabIndex = 7;
            this.lblStartDate.Text = "ថ្ងៃចាប់ផ្តើម";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::EzPos.Properties.Resources.Delete32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(28, 560);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(144, 40);
            this.btnDelete.TabIndex = 100;
            this.btnDelete.Text = "លុបចោល";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.MouseLeave += new System.EventHandler(this.BtnDeleteMouseLeave);
            this.btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
            this.btnDelete.MouseEnter += new System.EventHandler(this.BtnDeleteMouseEnter);
            // 
            // pnlBodyRight
            // 
            this.pnlBodyRight.BackgroundImage = global::EzPos.Properties.Resources.backgroud_12;
            this.pnlBodyRight.Controls.Add(this.btnDelete);
            this.pnlBodyRight.Controls.Add(this.btnNew);
            this.pnlBodyRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBodyRight.Location = new System.Drawing.Point(824, 0);
            this.pnlBodyRight.Name = "pnlBodyRight";
            this.pnlBodyRight.Size = new System.Drawing.Size(200, 591);
            this.pnlBodyRight.TabIndex = 3;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNew.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Image = global::EzPos.Properties.Resources.add32;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNew.Location = new System.Drawing.Point(28, 519);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(144, 40);
            this.btnNew.TabIndex = 99;
            this.btnNew.Text = "បង្កើតថ្មី";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.MouseLeave += new System.EventHandler(this.BtnNewMouseLeave);
            this.btnNew.Click += new System.EventHandler(this.BtnNewClick);
            this.btnNew.MouseEnter += new System.EventHandler(this.BtnNewMouseEnter);
            // 
            // cmbExpenseType
            // 
            this.cmbExpenseType.BackColor = System.Drawing.SystemColors.Window;
            this.cmbExpenseType.DropDownWidth = 230;
            this.cmbExpenseType.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExpenseType.FormattingEnabled = true;
            this.cmbExpenseType.Location = new System.Drawing.Point(625, 12);
            this.cmbExpenseType.Name = "cmbExpenseType";
            this.cmbExpenseType.Size = new System.Drawing.Size(181, 27);
            this.cmbExpenseType.TabIndex = 4;
            // 
            // ExpenseID
            // 
            this.ExpenseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ExpenseID.DataPropertyName = "ExpenseID";
            this.ExpenseID.HeaderText = "ExpenseID";
            this.ExpenseID.Name = "ExpenseID";
            this.ExpenseID.ReadOnly = true;
            this.ExpenseID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExpenseID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExpenseID.Visible = false;
            this.ExpenseID.Width = 150;
            // 
            // ExpenseDate
            // 
            this.ExpenseDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ExpenseDate.DataPropertyName = "ExpenseDate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            dataGridViewCellStyle2.NullValue = null;
            this.ExpenseDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.ExpenseDate.HeaderText = "កាលបរិច្ឆេទ";
            this.ExpenseDate.Name = "ExpenseDate";
            this.ExpenseDate.ReadOnly = true;
            this.ExpenseDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExpenseDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExpenseDate.Width = 125;
            // 
            // ExpenseTypeID
            // 
            this.ExpenseTypeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ExpenseTypeID.DataPropertyName = "ExpenseTypeID";
            this.ExpenseTypeID.HeaderText = "ExpenseTypeID";
            this.ExpenseTypeID.Name = "ExpenseTypeID";
            this.ExpenseTypeID.ReadOnly = true;
            this.ExpenseTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExpenseTypeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExpenseTypeID.Visible = false;
            this.ExpenseTypeID.Width = 140;
            // 
            // ExpenseTypeStr
            // 
            this.ExpenseTypeStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ExpenseTypeStr.DataPropertyName = "ExpenseTypeStr";
            this.ExpenseTypeStr.HeaderText = "ប្រភេទ";
            this.ExpenseTypeStr.Name = "ExpenseTypeStr";
            this.ExpenseTypeStr.ReadOnly = true;
            this.ExpenseTypeStr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExpenseTypeStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExpenseTypeStr.Width = 150;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "បរិយាយ";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExpenseAmountInt
            // 
            this.ExpenseAmountInt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ExpenseAmountInt.DataPropertyName = "ExpenseAmountInt";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.ExpenseAmountInt.DefaultCellStyle = dataGridViewCellStyle3;
            this.ExpenseAmountInt.HeaderText = "ទឹកប្រាក់ ($)";
            this.ExpenseAmountInt.Name = "ExpenseAmountInt";
            this.ExpenseAmountInt.ReadOnly = true;
            this.ExpenseAmountInt.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExpenseAmountInt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExpenseAmountInt.Width = 120;
            // 
            // ExpenseAmountRiel
            // 
            this.ExpenseAmountRiel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ExpenseAmountRiel.DataPropertyName = "ExpenseAmountRiel";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.ExpenseAmountRiel.DefaultCellStyle = dataGridViewCellStyle4;
            this.ExpenseAmountRiel.HeaderText = "ទឹកប្រាក់ (៛)";
            this.ExpenseAmountRiel.Name = "ExpenseAmountRiel";
            this.ExpenseAmountRiel.ReadOnly = true;
            this.ExpenseAmountRiel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExpenseAmountRiel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExpenseAmountRiel.Width = 120;
            // 
            // CurrencyID
            // 
            this.CurrencyID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CurrencyID.DataPropertyName = "CurrencyID";
            this.CurrencyID.HeaderText = "CurrencyID";
            this.CurrencyID.Name = "CurrencyID";
            this.CurrencyID.ReadOnly = true;
            this.CurrencyID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CurrencyID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CurrencyID.Visible = false;
            // 
            // ExchangeRate
            // 
            this.ExchangeRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ExchangeRate.DataPropertyName = "ExchangeRate";
            this.ExchangeRate.HeaderText = "ExchangeRate";
            this.ExchangeRate.Name = "ExchangeRate";
            this.ExchangeRate.ReadOnly = true;
            this.ExchangeRate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExchangeRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExchangeRate.Visible = false;
            // 
            // CtrlExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBodyLeft);
            this.Controls.Add(this.pnlBodySearch);
            this.Controls.Add(this.pnlBodyRight);
            this.Name = "CtrlExpense";
            this.Size = new System.Drawing.Size(1024, 591);
            this.Load += new System.EventHandler(this.CtrlExpense_Load);
            this.pnlBodyLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).EndInit();
            this.pnlBodySearch.ResumeLayout(false);
            this.pnlBodySearch.PerformLayout();
            this.pnlBodyRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBodyLeft;
        private System.Windows.Forms.DataGridView dgvExpense;
        private System.Windows.Forms.Panel pnlBodySearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel pnlBodyRight;
        private System.Windows.Forms.Button btnNew;
        private ExtendedComboBox cmbExpenseType;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label lblExpenseType;
        private System.Windows.Forms.Label lblStopDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button cmdSearchProduct;
        private System.Windows.Forms.Label lblResultInfo;
        private System.Windows.Forms.DateTimePicker dtpStopDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseTypeStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseAmountInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseAmountRiel;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExchangeRate;
    }
}