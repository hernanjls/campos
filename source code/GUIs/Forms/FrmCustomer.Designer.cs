using EzPos.Model;
using EzPos.Model.Customer;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Service.Customer;
using ExtendedComboBox=EzPos.GUIs.Components.ExtendedComboBox;

namespace EzPos.GUIs.Forms
{
    partial class FrmCustomer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblLocalName = new System.Windows.Forms.Label();
            this.txtLocalName = new System.Windows.Forms.TextBox();
            this.chbDiscountRejected = new System.Windows.Forms.CheckBox();
            this.lblNewCard = new System.Windows.Forms.Label();
            this.currentCardLbl = new System.Windows.Forms.Label();
            this.lblCurrentCard = new System.Windows.Forms.Label();
            this.lsbDiscountCard = new System.Windows.Forms.ListBox();
            this.lblDisPercentage = new System.Windows.Forms.Label();
            this.lblDPercentage = new System.Windows.Forms.Label();
            this.lblDCardType = new System.Windows.Forms.Label();
            this.cmbDCardType = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.cmbGender = new EzPos.GUIs.Components.ExtendedComboBox(this.components);
            this.lblSize = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.grbLine_1 = new System.Windows.Forms.GroupBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.lblDiscountCard = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblProductName = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlBody.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody.Controls.Add(this.lblLocalName);
            this.pnlBody.Controls.Add(this.txtLocalName);
            this.pnlBody.Controls.Add(this.chbDiscountRejected);
            this.pnlBody.Controls.Add(this.lblNewCard);
            this.pnlBody.Controls.Add(this.currentCardLbl);
            this.pnlBody.Controls.Add(this.lblCurrentCard);
            this.pnlBody.Controls.Add(this.lsbDiscountCard);
            this.pnlBody.Controls.Add(this.lblDisPercentage);
            this.pnlBody.Controls.Add(this.lblDPercentage);
            this.pnlBody.Controls.Add(this.lblDCardType);
            this.pnlBody.Controls.Add(this.cmbDCardType);
            this.pnlBody.Controls.Add(this.cmbGender);
            this.pnlBody.Controls.Add(this.lblSize);
            this.pnlBody.Controls.Add(this.txtWebsite);
            this.pnlBody.Controls.Add(this.lblEmail);
            this.pnlBody.Controls.Add(this.txtEmailAddress);
            this.pnlBody.Controls.Add(this.lblTelephone);
            this.pnlBody.Controls.Add(this.txtPhoneNumber);
            this.pnlBody.Controls.Add(this.txtAddress);
            this.pnlBody.Controls.Add(this.lblCustomerName);
            this.pnlBody.Controls.Add(this.txtCustomerName);
            this.pnlBody.Controls.Add(this.grbLine_1);
            this.pnlBody.Controls.Add(this.lblAddress);
            this.pnlBody.Controls.Add(this.lblWebsite);
            this.pnlBody.Controls.Add(this.lblDiscountCard);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBody.Location = new System.Drawing.Point(0, 89);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(695, 362);
            this.pnlBody.TabIndex = 1;
            // 
            // lblLocalName
            // 
            this.lblLocalName.AutoSize = true;
            this.lblLocalName.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalName.Location = new System.Drawing.Point(26, 19);
            this.lblLocalName.Name = "lblLocalName";
            this.lblLocalName.Size = new System.Drawing.Size(110, 29);
            this.lblLocalName.TabIndex = 0;
            this.lblLocalName.Text = "ឈ្មោះ (ជាតិ)";
            // 
            // txtLocalName
            // 
            this.txtLocalName.BackColor = System.Drawing.SystemColors.Info;
            this.txtLocalName.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalName.Location = new System.Drawing.Point(142, 14);
            this.txtLocalName.Name = "txtLocalName";
            this.txtLocalName.Size = new System.Drawing.Size(250, 36);
            this.txtLocalName.TabIndex = 1;
            this.txtLocalName.MouseLeave += new System.EventHandler(this.TxtLocalNameMouseLeave);
            this.txtLocalName.MouseEnter += new System.EventHandler(this.TxtLocalNameMouseEnter);
            // 
            // chbDiscountRejected
            // 
            this.chbDiscountRejected.AutoSize = true;
            this.chbDiscountRejected.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbDiscountRejected.Location = new System.Drawing.Point(142, 167);
            this.chbDiscountRejected.Name = "chbDiscountRejected";
            this.chbDiscountRejected.Size = new System.Drawing.Size(170, 33);
            this.chbDiscountRejected.TabIndex = 8;
            this.chbDiscountRejected.Text = "មិនអាចបញ្ចុះតំលៃ";
            this.chbDiscountRejected.UseVisualStyleBackColor = true;
            // 
            // lblNewCard
            // 
            this.lblNewCard.BackColor = System.Drawing.Color.Gainsboro;
            this.lblNewCard.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCard.Location = new System.Drawing.Point(411, 53);
            this.lblNewCard.Name = "lblNewCard";
            this.lblNewCard.Size = new System.Drawing.Size(249, 36);
            this.lblNewCard.TabIndex = 18;
            this.lblNewCard.Text = "កាតថ្មី";
            this.lblNewCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentCardLbl
            // 
            this.currentCardLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentCardLbl.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentCardLbl.Location = new System.Drawing.Point(457, 13);
            this.currentCardLbl.Name = "currentCardLbl";
            this.currentCardLbl.Size = new System.Drawing.Size(203, 36);
            this.currentCardLbl.TabIndex = 17;
            this.currentCardLbl.Text = "N/A";
            this.currentCardLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentCard
            // 
            this.lblCurrentCard.AutoSize = true;
            this.lblCurrentCard.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentCard.Location = new System.Drawing.Point(406, 19);
            this.lblCurrentCard.Name = "lblCurrentCard";
            this.lblCurrentCard.Size = new System.Drawing.Size(45, 29);
            this.lblCurrentCard.TabIndex = 16;
            this.lblCurrentCard.Text = "កាត";
            // 
            // lsbDiscountCard
            // 
            this.lsbDiscountCard.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbDiscountCard.FormattingEnabled = true;
            this.lsbDiscountCard.ItemHeight = 28;
            this.lsbDiscountCard.Location = new System.Drawing.Point(410, 204);
            this.lsbDiscountCard.Name = "lsbDiscountCard";
            this.lsbDiscountCard.Size = new System.Drawing.Size(250, 144);
            this.lsbDiscountCard.TabIndex = 24;
            this.lsbDiscountCard.Leave += new System.EventHandler(this.LsbDiscountCardLeave);
            this.lsbDiscountCard.Enter += new System.EventHandler(this.LsbDiscountCardEnter);
            // 
            // lblDisPercentage
            // 
            this.lblDisPercentage.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisPercentage.Location = new System.Drawing.Point(564, 127);
            this.lblDisPercentage.Name = "lblDisPercentage";
            this.lblDisPercentage.Size = new System.Drawing.Size(102, 36);
            this.lblDisPercentage.TabIndex = 22;
            this.lblDisPercentage.Text = "0";
            this.lblDisPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDPercentage
            // 
            this.lblDPercentage.AutoSize = true;
            this.lblDPercentage.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDPercentage.Location = new System.Drawing.Point(558, 95);
            this.lblDPercentage.Name = "lblDPercentage";
            this.lblDPercentage.Size = new System.Drawing.Size(108, 29);
            this.lblDPercentage.TabIndex = 20;
            this.lblDPercentage.Text = "%​បញ្ចុះតំលៃ";
            // 
            // lblDCardType
            // 
            this.lblDCardType.AutoSize = true;
            this.lblDCardType.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDCardType.Location = new System.Drawing.Point(408, 95);
            this.lblDCardType.Name = "lblDCardType";
            this.lblDCardType.Size = new System.Drawing.Size(98, 29);
            this.lblDCardType.TabIndex = 19;
            this.lblDCardType.Text = "ប្រភេទកាត";
            // 
            // cmbDCardType
            // 
            this.cmbDCardType.BackColor = System.Drawing.SystemColors.Window;
            this.cmbDCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDCardType.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDCardType.FormattingEnabled = true;
            this.cmbDCardType.Location = new System.Drawing.Point(411, 128);
            this.cmbDCardType.Name = "cmbDCardType";
            this.cmbDCardType.Size = new System.Drawing.Size(142, 36);
            this.cmbDCardType.TabIndex = 21;
            this.cmbDCardType.Enter += new System.EventHandler(this.CmbDCardTypeEnter);
            // 
            // cmbGender
            // 
            this.cmbGender.BackColor = System.Drawing.SystemColors.Info;
            this.cmbGender.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(142, 90);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(250, 36);
            this.cmbGender.TabIndex = 5;
            this.cmbGender.Leave += new System.EventHandler(this.CmbGenderLeave);
            this.cmbGender.Enter += new System.EventHandler(this.CmbGenderEnter);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(90, 95);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(46, 29);
            this.lblSize.TabIndex = 4;
            this.lblSize.Text = "ភេទ";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWebsite.Location = new System.Drawing.Point(142, 241);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(250, 36);
            this.txtWebsite.TabIndex = 12;
            this.txtWebsite.Leave += new System.EventHandler(this.TxtWebsiteLeave);
            this.txtWebsite.Enter += new System.EventHandler(this.TxtWebsiteEnter);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(71, 208);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(65, 29);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "អ៊ីមែល";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailAddress.Location = new System.Drawing.Point(142, 203);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(250, 36);
            this.txtEmailAddress.TabIndex = 10;
            this.txtEmailAddress.Leave += new System.EventHandler(this.TxtEmailAddressLeave);
            this.txtEmailAddress.Enter += new System.EventHandler(this.TxtEmailAddressEnter);
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelephone.Location = new System.Drawing.Point(71, 133);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(65, 29);
            this.lblTelephone.TabIndex = 6;
            this.lblTelephone.Text = "ទូរស័ព្ទ";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(142, 128);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(250, 36);
            this.txtPhoneNumber.TabIndex = 7;
            this.txtPhoneNumber.Leave += new System.EventHandler(this.TxtPhoneNumberLeave);
            this.txtPhoneNumber.Enter += new System.EventHandler(this.TxtPhoneNumberEnter);
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(142, 279);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(250, 69);
            this.txtAddress.TabIndex = 14;
            this.txtAddress.Leave += new System.EventHandler(this.TxtAddressLeave);
            this.txtAddress.Enter += new System.EventHandler(this.TxtAddressEnter);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(76, 57);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(60, 29);
            this.lblCustomerName.TabIndex = 2;
            this.lblCustomerName.Text = "ឈ្មោះ";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.SystemColors.Info;
            this.txtCustomerName.Font = new System.Drawing.Font("Candara", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(142, 52);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(250, 36);
            this.txtCustomerName.TabIndex = 3;
            this.txtCustomerName.Leave += new System.EventHandler(this.TxtCustomerNameLeave);
            this.txtCustomerName.Enter += new System.EventHandler(this.TxtCustomerNameEnter);
            // 
            // grbLine_1
            // 
            this.grbLine_1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_1.Location = new System.Drawing.Point(400, 14);
            this.grbLine_1.Name = "grbLine_1";
            this.grbLine_1.Size = new System.Drawing.Size(2, 334);
            this.grbLine_1.TabIndex = 15;
            this.grbLine_1.TabStop = false;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(35, 285);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(102, 29);
            this.lblAddress.TabIndex = 13;
            this.lblAddress.Text = "អាស័យដ្ឋាន";
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebsite.Location = new System.Drawing.Point(52, 246);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(85, 29);
            this.lblWebsite.TabIndex = 11;
            this.lblWebsite.Text = "គេហទំព័រ";
            // 
            // lblDiscountCard
            // 
            this.lblDiscountCard.AutoSize = true;
            this.lblDiscountCard.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountCard.Location = new System.Drawing.Point(405, 171);
            this.lblDiscountCard.Name = "lblDiscountCard";
            this.lblDiscountCard.Size = new System.Drawing.Size(125, 29);
            this.lblDiscountCard.TabIndex = 23;
            this.lblDiscountCard.Text = "កាតបញ្ចុះតំលៃ";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ContactId";
            this.dataGridViewTextBoxColumn1.HeaderText = "ContactId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CustomerId";
            this.dataGridViewTextBoxColumn2.HeaderText = "CustomerId";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ContactName";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn3.HeaderText = "ឈ្មោះ";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 290;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PhoneNumber";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Khmer OS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn4.HeaderText = "ទូរស័ព្ទ";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 160;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "EmailAddress";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Khmer OS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.Format = "N2";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn5.HeaderText = "អ៊ីមែល";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 200;
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
            this.pnlHeader.TabIndex = 105;
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
            // pnlFooter
            // 
            this.pnlFooter.BackgroundImage = global::EzPos.Properties.Resources.background_5;
            this.pnlFooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 451);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(695, 48);
            this.pnlFooter.TabIndex = 106;
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
            this.btnCancel.TabIndex = 47;
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
            this.btnSave.TabIndex = 46;
            this.btnSave.Text = "យល់ព្រម";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.MouseLeave += new System.EventHandler(this.BtnSaveMouseLeave);
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            this.btnSave.MouseEnter += new System.EventHandler(this.BtnSaveMouseEnter);
            // 
            // FrmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(695, 499);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.FrmCustomer_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCustomerAdvance_FormClosing);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.GroupBox grbLine_1;
        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private ExtendedComboBox cmbGender;
        private System.Windows.Forms.Label lblSize;
        private ExtendedComboBox cmbDCardType;
        private System.Windows.Forms.Label lblDPercentage;
        private System.Windows.Forms.Label lblDCardType;
        private System.Windows.Forms.Label lblDiscountCard;
        private System.Windows.Forms.ListBox lsbDiscountCard;
        private System.Windows.Forms.Label lblDisPercentage;
        private System.Windows.Forms.Label lblCurrentCard;
        private System.Windows.Forms.Label currentCardLbl;
        private System.Windows.Forms.Label lblNewCard;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chbDiscountRejected;
        private System.Windows.Forms.Label lblLocalName;
        private System.Windows.Forms.TextBox txtLocalName;
        private CommonService _CommonService;
        private Customer _Customer;
        private CustomerService _CustomerService;
    }
}