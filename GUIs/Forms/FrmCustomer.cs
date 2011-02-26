using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;

namespace EzPos.GUIs.Forms
{
    public partial class FrmCustomer : Form
    {
        private bool IsModified;

        public FrmCustomer()
        {
            InitializeComponent();
        }

        public CommonService CommonService
        {
            set { _CommonService = value; }
        }

        public CustomerService CustomerService
        {
            set { _CustomerService = value; }
        }

        public Customer Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }

        public IList ContactList { get; set; }

        private void SetModifydStatus(bool modifyStatus)
        {
            IsModified = modifyStatus;
            btnSave.Enabled = modifyStatus;
        }

        private void FrmCustomerAdvance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((DialogResult == DialogResult.Cancel) && (IsModified))
            {
                const string briefMsg = "អំពីការបោះបង់";
                var detailMsg = Resources.MsgOperationRequestCancel;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            if (!IsModified)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            try
            {
                if ((cmbGender.SelectedIndex == -1) || (String.IsNullOrEmpty(txtCustomerName.Text)))
                {
                    const string briefMsg = "អំពីពត៌មាន";
                    var detailMsg = Resources.MsgInvalidData;
                    using (var frmMessageBox = new FrmExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }

                if (_Customer == null)
                    _Customer = new Customer();

                _Customer.LocalName = txtLocalName.Text;
                _Customer.CustomerName = txtCustomerName.Text;
                _Customer.Address = txtAddress.Text;
                _Customer.PhoneNumber = txtPhoneNumber.Text;
                _Customer.EmailAddress = txtEmailAddress.Text;
                _Customer.Website = txtWebsite.Text;
                _Customer.GenderID = Int32.Parse(cmbGender.SelectedValue.ToString());
                _Customer.GenderStr = cmbGender.Text;
                _Customer.DiscountRejected = chbDiscountRejected.Checked ? 1 : 0;

                var isAllowed = false;
                if (lsbDiscountCard.SelectedItem != null)
                {
                    var discountCard = (DiscountCard) lsbDiscountCard.SelectedItem;
                    //if (discountCard != null)
                    //{
                        if ((discountCard.CustomerID != _Customer.CustomerID) ||
                            _Customer.CustomerID == 0)
                        {
                            isAllowed = true;

                            _Customer.FKDiscountCard = discountCard;
                            _Customer.DiscountCardNumber = discountCard.CardNumber;
                            _Customer.DiscountCardType = discountCard.DiscountCardTypeStr;
                            _Customer.DiscountPercentage = discountCard.DiscountPercentage;

                            if (cmbDCardType.SelectedValue != null)
                            {
                                float discountAmount =
                                    float.Parse(((AppParameter) cmbDCardType.SelectedItem).ParameterCode);
                                if (_Customer.PurchasedAmount < discountAmount)
                                    _Customer.PurchasedAmount = discountAmount;
                            }
                        }
                    //}
                }

                if (_CustomerService == null)
                    _CustomerService = ServiceFactory.GenerateServiceInstance().GenerateCustomerService();

                _CustomerService.CustomerManagement(_Customer,
                                                    _Customer.CustomerID != 0
                                                        ? Resources.OperationRequestUpdate
                                                        : Resources.OperationRequestInsert);

                if (isAllowed)
                {
                    var discountCard = (DiscountCard) lsbDiscountCard.SelectedItem;
                    discountCard.CustomerID = _Customer.CustomerID;
                    _CustomerService.DiscountCardManagement(
                        discountCard,
                        Resources.OperationRequestUpdate);
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void TxtCustomerNameEnter(object sender, EventArgs e)
        {
            txtCustomerName.TextChanged += ModificationHandler;
        }

        private void TxtCustomerNameLeave(object sender, EventArgs e)
        {
            txtCustomerName.TextChanged -= ModificationHandler;
        }

        private void TxtPhoneNumberEnter(object sender, EventArgs e)
        {
            txtPhoneNumber.TextChanged += ModificationHandler;
        }

        private void TxtPhoneNumberLeave(object sender, EventArgs e)
        {
            txtPhoneNumber.TextChanged -= ModificationHandler;
        }

        private void TxtEmailAddressEnter(object sender, EventArgs e)
        {
            txtEmailAddress.TextChanged += ModificationHandler;
        }

        private void TxtEmailAddressLeave(object sender, EventArgs e)
        {
            txtEmailAddress.TextChanged -= ModificationHandler;
        }

        private void TxtWebsiteEnter(object sender, EventArgs e)
        {
            txtWebsite.TextChanged += ModificationHandler;
        }

        private void TxtWebsiteLeave(object sender, EventArgs e)
        {
            txtWebsite.TextChanged -= ModificationHandler;
        }

        private void TxtAddressEnter(object sender, EventArgs e)
        {
            txtAddress.TextChanged += ModificationHandler;
        }

        private void TxtAddressLeave(object sender, EventArgs e)
        {
            txtAddress.TextChanged -= ModificationHandler;
        }

        private void ModificationHandler(object sender, EventArgs e)
        {
            SetModifydStatus(true);
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                if (_CustomerService == null)
                    _CustomerService = ServiceFactory.GenerateServiceInstance().GenerateCustomerService();
                if (_CommonService == null)
                    _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

                var objList = _CommonService.GetAppParametersByType(
                    int.Parse(Resources.AppParamGender));

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbGender, objList, int.Parse(Resources.AppParamGender), true);

                objList = _CommonService.GetAppParametersByType(
                    int.Parse(Resources.AppParamDiscountType));

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbDCardType, objList, int.Parse(Resources.AppParamDiscountType), true);
                cmbDCardType.SelectedIndex = 0;
                lblDisPercentage.Text = ((AppParameter) cmbDCardType.SelectedItem).ParameterValue;

                var criteriaList = new List<string> {"CustomerID|0"};
                if (cmbDCardType.SelectedItem != null)
                    criteriaList.Add("DiscountCardTypeID|" + ((AppParameter) cmbDCardType.SelectedItem).ParameterID);

                objList = _CustomerService.GetDiscountCards(criteriaList);
                lsbDiscountCard.DataSource = objList;
                if (objList.Count != 0)
                {
                    lsbDiscountCard.DisplayMember = DiscountCard.CONST_DISCOUNT_CARD_NUMBER;
                    lsbDiscountCard.ValueMember = DiscountCard.CONST_DISCOUNT_CARD_ID;
                    lsbDiscountCard.SelectedIndex = -1;
                }

                SetCustomerInfo();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.InnerException.Message);
            }
        }

        private void SetCustomerInfo()
        {
            DiscountCard discountCard;

            if (_CustomerService == null)
                _CustomerService = ServiceFactory.GenerateServiceInstance().GenerateCustomerService();

            if (_Customer == null)
                return;

            var objList = _CustomerService.GetDiscountCardsByCustomer(_Customer.CustomerID);
            if (objList.Count != 0)
            {
                discountCard = (DiscountCard) objList[0];
                if (discountCard != null)
                    currentCardLbl.Text = discountCard.CardNumber + " (" + discountCard.DiscountCardTypeStr + ")";
            }

            txtLocalName.Text = _Customer.LocalName;
            txtCustomerName.Text = _Customer.CustomerName;
            cmbGender.SelectedValue = _Customer.GenderID;
            txtAddress.Text = _Customer.Address;
            txtPhoneNumber.Text = _Customer.PhoneNumber;
            txtEmailAddress.Text = _Customer.EmailAddress;
            txtWebsite.Text = _Customer.Website;
        }

        private void CmbGenderEnter(object sender, EventArgs e)
        {
            cmbGender.SelectedIndexChanged += ModificationHandler;
        }

        private void CmbGenderLeave(object sender, EventArgs e)
        {
            cmbGender.SelectedIndexChanged += ModificationHandler;
        }

        private void CmbDCardTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            var criteriaList = new List<string>
                                   {
                                       "CustomerID|0",
                                       "DiscountCardTypeID|" + ((AppParameter) cmbDCardType.SelectedItem).ParameterID
                                   };
            lblDisPercentage.Text = ((AppParameter) cmbDCardType.SelectedItem).ParameterValue;

            var objList = _CustomerService.GetDiscountCards(criteriaList);
            lsbDiscountCard.DataSource = objList;
            if (objList.Count == 0) 
                return;

            lsbDiscountCard.DisplayMember = DiscountCard.CONST_DISCOUNT_CARD_NUMBER;
            lsbDiscountCard.ValueMember = DiscountCard.CONST_DISCOUNT_CARD_ID;
            lsbDiscountCard.SelectedIndex = -1;
        }

        private void LsbDiscountCardEnter(object sender, EventArgs e)
        {
            lsbDiscountCard.SelectedIndexChanged += ModificationHandler;
        }

        private void LsbDiscountCardLeave(object sender, EventArgs e)
        {
            lsbDiscountCard.SelectedIndexChanged -= ModificationHandler;
        }

        private void CmbDCardTypeEnter(object sender, EventArgs e)
        {
            cmbDCardType.SelectedIndexChanged += CmbDCardTypeSelectedIndexChanged;
        }

        private void BtnSaveMouseEnter(object sender, EventArgs e)
        {
            btnSave.BackgroundImage = Resources.background_9;
        }

        private void BtnSaveMouseLeave(object sender, EventArgs e)
        {
            btnSave.BackgroundImage = Resources.background_2;
        }

        private void BtnCancelMouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_9;
        }

        private void BtnCancelMouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_2;
        }

        private void TxtLocalNameMouseEnter(object sender, EventArgs e)
        {
            txtLocalName.TextChanged += ModificationHandler;
        }

        private void TxtLocalNameMouseLeave(object sender, EventArgs e)
        {
            txtLocalName.TextChanged -= ModificationHandler;
        }
    }
}