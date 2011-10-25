using EzPos.Model;
using EzPos.Model.Expense;
using ExtendedComboBox=EzPos.GUIs.Components.ExtendedComboBox;

namespace EzPos.GUIs.Forms
{
    partial class FrmExpense
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblExpenseType = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dtpExpenseDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpenseAmountRiel = new System.Windows.Forms.Label();
            this.txtExpenseAmountInt = new System.Windows.Forms.TextBox();
            this.txtExpenseAmountRiel = new System.Windows.Forms.TextBox();
            this.lblExpenseAmountInt = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblExpenseDate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbExpenseType = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblKeyboardLayout = new System.Windows.Forms.Label();
            this.pnlBody.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblExpenseType
            // 
            this.lblExpenseType.AutoSize = true;
            this.lblExpenseType.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpenseType.Location = new System.Drawing.Point(165, 35);
            this.lblExpenseType.Name = "lblExpenseType";
            this.lblExpenseType.Size = new System.Drawing.Size(129, 29);
            this.lblExpenseType.TabIndex = 0;
            this.lblExpenseType.Text = "ប្រភេទចំណាយ";
            this.lblExpenseType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlBody
            // 
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody.Controls.Add(this.lblKeyboardLayout);
            this.pnlBody.Controls.Add(this.dtpExpenseDate);
            this.pnlBody.Controls.Add(this.lblExpenseAmountRiel);
            this.pnlBody.Controls.Add(this.txtExpenseAmountInt);
            this.pnlBody.Controls.Add(this.txtExpenseAmountRiel);
            this.pnlBody.Controls.Add(this.lblExpenseAmountInt);
            this.pnlBody.Controls.Add(this.lblDescription);
            this.pnlBody.Controls.Add(this.txtDescription);
            this.pnlBody.Controls.Add(this.lblExpenseDate);
            this.pnlBody.Controls.Add(this.groupBox1);
            this.pnlBody.Controls.Add(this.cmbExpenseType);
            this.pnlBody.Controls.Add(this.lblExpenseType);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBody.Location = new System.Drawing.Point(0, 89);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(695, 289);
            this.pnlBody.TabIndex = 1;
            // 
            // dtpExpenseDate
            // 
            this.dtpExpenseDate.CalendarFont = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpenseDate.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpenseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpenseDate.Location = new System.Drawing.Point(300, 68);
            this.dtpExpenseDate.Name = "dtpExpenseDate";
            this.dtpExpenseDate.Size = new System.Drawing.Size(230, 36);
            this.dtpExpenseDate.TabIndex = 3;
            this.dtpExpenseDate.Leave += new System.EventHandler(this.DtpExpenseDateLeave);
            this.dtpExpenseDate.Enter += new System.EventHandler(this.DtpExpenseDateEnter);
            // 
            // lblExpenseAmountRiel
            // 
            this.lblExpenseAmountRiel.AutoSize = true;
            this.lblExpenseAmountRiel.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpenseAmountRiel.Location = new System.Drawing.Point(191, 189);
            this.lblExpenseAmountRiel.Name = "lblExpenseAmountRiel";
            this.lblExpenseAmountRiel.Size = new System.Drawing.Size(103, 29);
            this.lblExpenseAmountRiel.TabIndex = 7;
            this.lblExpenseAmountRiel.Text = "ទឹកប្រាក់ (៛)";
            // 
            // txtExpenseAmountInt
            // 
            this.txtExpenseAmountInt.BackColor = System.Drawing.SystemColors.Window;
            this.txtExpenseAmountInt.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpenseAmountInt.Location = new System.Drawing.Point(300, 222);
            this.txtExpenseAmountInt.Name = "txtExpenseAmountInt";
            this.txtExpenseAmountInt.Size = new System.Drawing.Size(230, 36);
            this.txtExpenseAmountInt.TabIndex = 10;
            this.txtExpenseAmountInt.Text = "0.00";
            this.txtExpenseAmountInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExpenseAmountInt.Leave += new System.EventHandler(this.TxtExpenseAmountIntLeave);
            this.txtExpenseAmountInt.Enter += new System.EventHandler(this.TxtExpenseAmountIntEnter);
            // 
            // txtExpenseAmountRiel
            // 
            this.txtExpenseAmountRiel.BackColor = System.Drawing.SystemColors.Window;
            this.txtExpenseAmountRiel.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpenseAmountRiel.Location = new System.Drawing.Point(300, 184);
            this.txtExpenseAmountRiel.Name = "txtExpenseAmountRiel";
            this.txtExpenseAmountRiel.Size = new System.Drawing.Size(230, 36);
            this.txtExpenseAmountRiel.TabIndex = 8;
            this.txtExpenseAmountRiel.Text = "0.00";
            this.txtExpenseAmountRiel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExpenseAmountRiel.Leave += new System.EventHandler(this.TxtExpenseAmountRielLeave);
            this.txtExpenseAmountRiel.Enter += new System.EventHandler(this.TxtExpenseAmountRielEnter);
            // 
            // lblExpenseAmountInt
            // 
            this.lblExpenseAmountInt.AutoSize = true;
            this.lblExpenseAmountInt.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpenseAmountInt.Location = new System.Drawing.Point(188, 227);
            this.lblExpenseAmountInt.Name = "lblExpenseAmountInt";
            this.lblExpenseAmountInt.Size = new System.Drawing.Size(106, 29);
            this.lblExpenseAmountInt.TabIndex = 9;
            this.lblExpenseAmountInt.Text = "ទឹកប្រាក់ ($)";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(217, 111);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(77, 29);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "បរិយាយ";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(300, 106);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(230, 65);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.Leave += new System.EventHandler(this.TxtDescriptionLeave);
            this.txtDescription.Enter += new System.EventHandler(this.TxtDescriptionEnter);
            // 
            // lblExpenseDate
            // 
            this.lblExpenseDate.AutoSize = true;
            this.lblExpenseDate.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpenseDate.Location = new System.Drawing.Point(190, 74);
            this.lblExpenseDate.Name = "lblExpenseDate";
            this.lblExpenseDate.Size = new System.Drawing.Size(104, 29);
            this.lblExpenseDate.TabIndex = 2;
            this.lblExpenseDate.Text = "កាលបរិច្ឆេទ";
            this.lblExpenseDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Location = new System.Drawing.Point(170, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 2);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // cmbExpenseType
            // 
            this.cmbExpenseType.BackColor = System.Drawing.SystemColors.Info;
            this.cmbExpenseType.DropDownWidth = 230;
            this.cmbExpenseType.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExpenseType.FormattingEnabled = true;
            this.cmbExpenseType.Location = new System.Drawing.Point(300, 30);
            this.cmbExpenseType.Name = "cmbExpenseType";
            this.cmbExpenseType.Size = new System.Drawing.Size(230, 36);
            this.cmbExpenseType.TabIndex = 1;
            this.cmbExpenseType.Leave += new System.EventHandler(this.CmbCategoryLeave);
            this.cmbExpenseType.Enter += new System.EventHandler(this.CmbCategoryEnter);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackgroundImage = global::EzPos.Properties.Resources.background_5;
            this.pnlFooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 378);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(695, 48);
            this.pnlFooter.TabIndex = 107;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = global::EzPos.Properties.Resources.Cancel32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(537, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "បោះបង់";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.MouseLeave += new System.EventHandler(this.BtnCancelMouseLeave);
            this.btnCancel.MouseEnter += new System.EventHandler(this.BtnCancelMouseEnter);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = global::EzPos.Properties.Resources.background_2;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Khmer OS Freehand", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::EzPos.Properties.Resources.OK32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(419, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "យល់ព្រម";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.MouseLeave += new System.EventHandler(this.BtnSaveMouseLeave);
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            this.btnSave.MouseEnter += new System.EventHandler(this.BtnSaveMouseEnter);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackgroundImage = global::EzPos.Properties.Resources.backgroud_11;
            this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHeader.Controls.Add(this.lblProductName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(695, 89);
            this.pnlHeader.TabIndex = 108;
            // 
            // lblProductName
            // 
            this.lblProductName.BackColor = System.Drawing.Color.Transparent;
            this.lblProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductName.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.Yellow;
            this.lblProductName.Location = new System.Drawing.Point(0, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(695, 89);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKeyboardLayout
            // 
            this.lblKeyboardLayout.AutoSize = true;
            this.lblKeyboardLayout.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyboardLayout.Location = new System.Drawing.Point(536, 111);
            this.lblKeyboardLayout.Name = "lblKeyboardLayout";
            this.lblKeyboardLayout.Size = new System.Drawing.Size(0, 29);
            this.lblKeyboardLayout.TabIndex = 11;
            // 
            // FrmExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(695, 426);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmExpense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   .: Expense :.";
            this.Load += new System.EventHandler(this.FrmExpense_Load);
            this.InputLanguageChanged += new System.Windows.Forms.InputLanguageChangedEventHandler(this.FrmExpense_InputLanguageChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmExpense_FormClosing);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblExpenseType;
        private ExtendedComboBox cmbExpenseType;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblExpenseDate;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtExpenseAmountInt;
        private System.Windows.Forms.TextBox txtExpenseAmountRiel;
        private System.Windows.Forms.Label lblExpenseAmountInt;
        private System.Windows.Forms.Label lblExpenseAmountRiel;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.DateTimePicker dtpExpenseDate;
        private Expense _Expense;
        private System.Windows.Forms.Label lblKeyboardLayout;
    }
}