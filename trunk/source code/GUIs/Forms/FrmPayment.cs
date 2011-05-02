using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Utility;

namespace EzPos.GUIs.Forms
{
    public partial class FrmPayment : Form
    {
        private BindingList<Customer> _customerList;
        private BindingList<DiscountCard> _discountCardList;
        private IList _discountTypeList;
        private float _exchangeRate;

        public FrmPayment()
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

        public float TotalAmountInt
        {
            get { return _TotalAmountInt; }
            set { _TotalAmountInt = value; }
        }

        public float AmountPaidInt { get; private set; }

        public float AmountPaidRiel { get; private set; }

        public Customer Customer { get; private set; }

        public bool IsDeposit { get; set; }

        private void FrmPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (DialogResult != DialogResult.OK)
                    return;

                if (Customer == null)
                {
                    const string briefMsg = "អំពីអតិថិជន";
                    const string detailMsg = "ការ​គិត​លុយ​ពុំ​អាច​ប្រព្រឹត្ត​ទៅ​ដោយ​គ្មាន​អតិថិជន​ឡើយ ។";
                    using (var frmMessageBox = new FrmExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                    }

                    e.Cancel = true;
                    return;
                }

                PaymentManagement();
                var amountReturnRiel = float.Parse(txtAmountReturnRiel.Text);
                if (amountReturnRiel < 0)
                {
                    //if (!CommonService.IsIntegratedModule(Resources.ModCustomerDebt))
                    //{
                    //    if (((-1)*amountReturnRiel) >= 0)
                    //    {
                    //        const string briefMsg = "អំពីការប្រគល់ប្រាក់";
                    //        const string detailMsg = "ទឹក​ប្រាក់​ដែល​អ្នក​បាន​បញ្ចូល​ពុំ​ទាន់​គ្រប់​គ្រាន់​ទេ ។";
                    //        using (var frmMessageBox = new ExtendedMessageBox())
                    //        {
                    //            frmMessageBox.BriefMsgStr = briefMsg;
                    //            frmMessageBox.DetailMsgStr = detailMsg;
                    //            frmMessageBox.IsCanceledOnly = true;
                    //            frmMessageBox.ShowDialog(this);
                    //        }

                    //        e.Cancel = true;
                    //        return;
                    //    }
                    //}
                    //else
                    //{
                        if(!IsDeposit)
                        {
                            if (((-1) * amountReturnRiel) >= 0)
                            {
                                const string briefMsg = "អំពីការប្រគល់ប្រាក់";
                                const string detailMsg = "ទឹក​ប្រាក់​ដែល​អ្នក​បាន​បញ្ចូល​ពុំ​ទាន់​គ្រប់​គ្រាន់​ទេ ។";
                                using (var frmMessageBox = new FrmExtendedMessageBox())
                                {
                                    frmMessageBox.BriefMsgStr = briefMsg;
                                    frmMessageBox.DetailMsgStr = detailMsg;
                                    frmMessageBox.IsCanceledOnly = true;
                                    frmMessageBox.ShowDialog(this);
                                }

                                e.Cancel = true;
                                return;
                            }
                        }
                        else
                        {
                            const string briefMsg = "អំពីការប្រគល់ប្រាក់";
                            var detailMsg = Resources.MsgConfirmCreditPayment;
                            using (var frmMessageBox = new FrmExtendedMessageBox())
                            {
                                frmMessageBox.BriefMsgStr = briefMsg;
                                frmMessageBox.DetailMsgStr = detailMsg;
                                frmMessageBox.IsCanceledOnly = false;
                                if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                                {
                                    e.Cancel = true;
                                    return;
                                }
                            }
                        }
                    //}
                }
                else if (IsDeposit)
                {
                    const string briefMsg = "អំពីការប្រគល់ប្រាក់";
                    var detailMsg = Resources.MsgInvalidDepositPayment;
                    using (var frmMessageBox = new FrmExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }                    
                }

                if (CommonService.IsIntegratedModule(Resources.ModDiscountCard))
                    DiscountCardManagement();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void FrmPayment_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
                case Keys.Enter:
                    if (txtAmountPaidUsd.Text.Length == 0)
                        txtAmountPaidUsd.Focus();

                    if (txtAmountPaidRiel.Text.Length == 0)
                        txtAmountPaidRiel.Focus();

                    DialogResult = DialogResult.OK;
                    break;
                default:
                    break;
            }
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            try
            {
                if (_CustomerService == null)
                    _CustomerService = ServiceFactory.GenerateServiceInstance().GenerateCustomerService();
                if (_CommonService == null)
                    _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

                ThreadStart threadStart = UpdateControlContent;
                var thread = new Thread(threadStart) {IsBackground = true};
                thread.Start();

                if (AppContext.ExchangeRate != null)
                    _exchangeRate = AppContext.ExchangeRate.ExchangeValue;

                _discountCardList = new BindingList<DiscountCard>();
                cmbDiscountCard.DataSource = _discountCardList;
                cmbDiscountCard.DisplayMember = DiscountCard.CONST_DISCOUNT_CARD_NUMBER;
                cmbDiscountCard.ValueMember = DiscountCard.CONST_DISCOUNT_CARD_ID;

                _customerList = new BindingList<Customer>();
                lsbCustomer.DataSource = _customerList;
                lsbCustomer.DisplayMember = Customer.CONST_CUSTOMER_DISPLAY_NAME;
                lsbCustomer.ValueMember = Customer.CONST_CUSTOMER_ID;

                txtExchangeRate.Text = _exchangeRate.ToString("N", AppContext.CultureInfo);
                txtCurrentSaleAmount.Text = _TotalAmountInt.ToString("N", AppContext.CultureInfo);
                CalculateDiscount();

                if (UserService.AllowToPerform(Resources.PermissionSpecialDiscount))
                    cmbDCountType.Enabled = true;

                if (CommonService.IsIntegratedModule(Resources.ModCustomer))
                {
                    IList searchCriteria = new List<string> {"CustomerName|Retail customer"};
                    var customerList = _CustomerService.GetCustomers(searchCriteria);
                    foreach (Customer customer in customerList)
                        _customerList.Add(customer);
                    //txtSearch.Enabled = false;
                    //lsbCustomer.Enabled = false;
                    //btnNew.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void TxtAmountPaidUsdLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmountPaidUsd.Text))
                txtAmountPaidUsd.Text = "0.00";

            PaymentManagement();
        }

        private void TxtAmountPaidRiel_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmountPaidRiel.Text))
                txtAmountPaidRiel.Text = "0.00";

            PaymentManagement();
        }

        private void PaymentManagement()
        {
            try
            {
                if (string.IsNullOrEmpty(txtAmountPaidUsd.Text))
                    txtAmountPaidUsd.Text = "0.00";
                if (string.IsNullOrEmpty(txtAmountPaidRiel.Text))
                    txtAmountPaidRiel.Text = "0.00";
                if (string.IsNullOrEmpty(txtTotalAmountUsd.Text))
                    txtTotalAmountUsd.Text = "0.00";

                var amountToPay = float.Parse(txtTotalAmountUsd.Text);
                AmountPaidInt = float.Parse(txtAmountPaidUsd.Text);
                AmountPaidRiel = float.Parse(txtAmountPaidRiel.Text);

                AmountPaidInt += float.Parse(txtAmountPaidRiel.Text)/_exchangeRate;
                txtAmountReturnUsd.Text = (AmountPaidInt - amountToPay).ToString("N", AppContext.CultureInfo);
                txtAmountReturnRiel.Text = ((AmountPaidInt - amountToPay)*_exchangeRate).ToString("N",
                                                                                                   AppContext.
                                                                                                       CultureInfo);
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void LsbCustomerSelectedIndexChanged(object sender, EventArgs e)
        {
            if ((lsbCustomer.SelectedIndex == -1) || (lsbCustomer.DisplayMember == "") ||
                (lsbCustomer.ValueMember == ""))
                ResetCustomerInfo();
            else
            {
                Customer = lsbCustomer.SelectedItem as Customer;
                SetCustomerInfo();
            }
            CalculateDiscount();
        }

        private void SetCustomerInfo()
        {
            if (Customer == null)
                return;

            cmbDiscountCard.SelectedIndex = -1;
            var strCustomerInfo =
                "អតិថិជន: " + Customer.CustomerName + "\n" +
                "លេខទូរស័ព្ទ: " + Customer.PhoneNumber + "\n" +
                "ទឹកប្រាក់បានទិញ: $" + Customer.PurchasedAmount.ToString("N", AppContext.CultureInfo) + "\n";
            lblCustomerInfo.Text = strCustomerInfo;

            if (_discountCardList == null)
                return;
            for (var counter = 0; counter < _discountCardList.Count; counter++)
            {
                if (Customer.CustomerID != (_discountCardList[counter]).CustomerID) 
                    continue;

                cmbDiscountCard.SelectedIndex = counter;
                break;
            }

            if (cmbDiscountCard.SelectedItem != null)
            {
                Customer.FKDiscountCard = (DiscountCard) cmbDiscountCard.SelectedItem;

                txtSearch.Text = Customer.FKDiscountCard.CardNumber;
                txtDiscount.Text = Customer.FKDiscountCard.DiscountPercentage + " %";
                strCustomerInfo =
                    Customer.FKDiscountCard.CardNumber + " :ប័ណ្ណបញ្ចុះតំលៃ" + "\n " +
                    Customer.FKDiscountCard.DiscountCardTypeStr + " :ប្រភេទប័ណ្ណ" + "\n" +
                    Customer.FKDiscountCard.DiscountPercentage + "% :%បញ្ចុះតំលៃ";

                Customer.DiscountCardNumber = Customer.FKDiscountCard.CardNumber;
                Customer.DiscountCardType = Customer.FKDiscountCard.DiscountCardTypeStr;
                Customer.DiscountPercentage = Customer.FKDiscountCard.DiscountPercentage;

                cmbDiscountCard.SelectedIndex = -1;
            }
            else
            {
                txtSearch.Text = string.Empty;
                txtDiscount.Text = "0 %";
                strCustomerInfo =
                    "N/A :ប័ណ្ណបញ្ចុះតំលៃ" + "\n " +
                    "N/A :ប្រភេទប័ណ្ណ" + "\n" +
                    "N/A :%បញ្ចុះតំលៃ";
            }
            lblDCardInfo.Text = strCustomerInfo;
        }

        private void ResetCustomerInfo()
        {
            lblCustomerInfo.Text = string.Empty;
        }

        private void CalculateDiscount()
        {
            float totalAmountPurchase;
            if (Customer == null)
                totalAmountPurchase = _TotalAmountInt;
            else
                totalAmountPurchase = Customer.PurchasedAmount + _TotalAmountInt;

            if (_discountTypeList == null)
            {
                CalculateSale("0 %", 0);
                return;
            }

            if (_discountTypeList.Count == 0)
            {
                CalculateSale("0 %", 0);
                return;
            }

            float discountPercentage = 0;
            foreach (AppParameter appParameter in _discountTypeList)
            {
                if (appParameter == null) 
                    continue;

                if (String.IsNullOrEmpty(appParameter.ParameterCode))
                    appParameter.ParameterCode = "0";

                var purchasedAmount = float.Parse(appParameter.ParameterCode, AppContext.CultureInfo);
                if (totalAmountPurchase < purchasedAmount) 
                    continue;

                if (String.IsNullOrEmpty(appParameter.ParameterValue))
                    appParameter.ParameterValue = "0";

                discountPercentage = float.Parse(appParameter.ParameterValue, AppContext.CultureInfo);
            }

            CalculateSale(discountPercentage.ToString("N0") + " %", discountPercentage);
            PaymentManagement();
        }

        private void BtnNewClick(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionAddCustomer))
            {
                const string briefMsg = "អំពីសិទ្ឋប្រើប្រាស់";
                const string detailMsg = "អ្នក​ពុំ​មាន​សិទ្ឋ​គ្រប់​គ្រាន់​សំរាប់​ការ​ស្នើរ​សុំ​នេះ​ឡើយ ។";
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                }
                return;
            }

            Visible = false;
            using (var frmCustomer = new FrmCustomer())
            {
                if (frmCustomer.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        _customerList.Add(frmCustomer.Customer);
                        if (frmCustomer.Customer.FKDiscountCard != null)
                            _discountCardList.Add(frmCustomer.Customer.FKDiscountCard);

                        lsbCustomer.SelectedIndex = -1;
                        lsbCustomer.SelectedIndex = lsbCustomer.FindStringExact(frmCustomer.Customer.CustomerName);
                    }
                    catch (Exception exception)
                    {
                        FrmExtendedMessageBox.UnknownErrorMessage(
                            Resources.MsgCaptionUnknownError,
                            exception.Message);
                    }
                }
                Visible = true;
            }
        }

        private void TxtSearchKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Return:
                        if (StringHelper.Length(txtSearch.Text) == 0)
                            return;

                        DoCustomerFetching(txtSearch.Text, true);
                        break;
                }
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void TxtAmountPaidUsdTextChanged(object sender, EventArgs e)
        {
            PaymentManagement();
        }

        private void TxtAmountPaidRielTextChanged(object sender, EventArgs e)
        {
            PaymentManagement();
        }

        private void TxtDCardNumEnter(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            KeyDown -= FrmPayment_KeyDown;
        }

        private void TxtDCardNumLeave(object sender, EventArgs e)
        {
            KeyDown += FrmPayment_KeyDown;
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

        private void BtnNewMouseEnter(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = Resources.background_9;
        }

        private void BtnNewMouseLeave(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = Resources.background_2;
        }

        private void DoCustomerFetching(string givenParam, bool isAllowed)
        {
            if (String.IsNullOrEmpty(givenParam))
                return;

            cmbDiscountCard.SelectedIndex = -1;
            lsbCustomer.SelectedIndex = -1;

            var selectedIndex = cmbDiscountCard.FindStringExact(
                StringHelper.Right("000000000" + givenParam, 9));
            if (selectedIndex == -1)
            {
                selectedIndex = lsbCustomer.FindString(givenParam);
                if (selectedIndex == -1)
                {
                    foreach (var customer in _customerList)
                    {
                        if ((customer.CustomerName.ToUpper() != givenParam.ToUpper()) &&
                            (customer.PhoneNumber != givenParam) &&
                            (customer.LocalName != givenParam)) 
                            continue;

                        lsbCustomer.SelectedIndex = _customerList.IndexOf(customer);
                        break;
                    }
                }
                else
                    lsbCustomer.SelectedIndex = selectedIndex;
            }
            else
            {
                cmbDiscountCard.SelectedIndex = selectedIndex;
                lsbCustomer.SelectedValue = ((DiscountCard) cmbDiscountCard.SelectedItem).CustomerID;
            }

            if ((lsbCustomer.SelectedIndex == -1) && (isAllowed))
            {
                var searchCriteria = 
                    new List<string>
                    {
                        "(CustomerName LIKE N'%" + givenParam + "%')" +
                        " OR (LocalName LIKE N'%" + givenParam + "%')" +
                        " OR (PhoneNumber LIKE '%" + givenParam + "%')" +
                        " OR (CustomerID IN (SELECT CustomerID FROM TDiscountCards WHERE CustomerID <> 0 AND CardNumber LIKE '%" +
                        givenParam + "%'))"
                    };
                var customerList = _CustomerService.GetCustomers(searchCriteria);
                if (customerList.Count != 0)
                {
                    foreach (Customer customer in customerList)
                    {
                        _customerList.Add(customer);

                        var discountCardList =
                            _CustomerService.GetDiscountCardsByCustomer(customer.CustomerID);
                        foreach (DiscountCard discountCard in discountCardList)
                            _discountCardList.Add(discountCard);
                    }

                    DoCustomerFetching(givenParam, false);
                }
                else
                {
                    if (txtSearch.CanFocus)
                        txtSearch.Focus();

                    const string briefMsg = "អំពីអតិថិជន";
                    var detailMsg = Resources.MsgOperationRequestCustomerNotFound;
                    using (var frmMessageBox = new FrmExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }
            }

            if (lsbCustomer.CanFocus)
                lsbCustomer.Focus();
        }

        private void DiscountCardManagement()
        {
            if (Customer == null)
                return;

            var dCardTypeList =
                _CommonService.GetAppParametersByType(
                    Int32.Parse(Resources.AppParamDiscountType, AppContext.CultureInfo));

            float purchaseAmount;
            if (!IsDeposit)
                purchaseAmount = _TotalAmountInt;
            else
                float.TryParse(txtAmountPaidUsd.Text, out purchaseAmount);

            Customer.PurchasedAmount += purchaseAmount;
            if (!IsDeposit)
            {
                if (Customer.FKDiscountCard != null)
                    Customer.PurchasedAmount -= ((purchaseAmount*Customer.FKDiscountCard.DiscountPercentage)/100);
            }

            var counter = -1;
            foreach (var appParameter in
                dCardTypeList.Cast<AppParameter>().Where(appParameter => (!string.IsNullOrEmpty(appParameter.ParameterCode)) && (Customer.PurchasedAmount >= float.Parse(appParameter.ParameterCode, AppContext.CultureInfo))))
            {
                if (counter == -1)
                    counter = dCardTypeList.IndexOf(appParameter);
                else if (
                    float.Parse(((AppParameter) dCardTypeList[counter]).ParameterCode, AppContext.CultureInfo) <=
                    float.Parse(appParameter.ParameterCode, AppContext.CultureInfo))
                    counter = dCardTypeList.IndexOf(appParameter);
            }

            if (counter == -1)
                return;

            if (Customer.FKDiscountCard == null)
            {
                DiscountCardDistribution(
                    Customer,
                    string.Empty,
                    ((AppParameter) dCardTypeList[counter]).ParameterLabel);
            }
            else
            {
                if (Customer.FKDiscountCard.DiscountCardTypeID !=
                    ((AppParameter) dCardTypeList[counter]).ParameterID)
                {
                    DiscountCardDistribution(
                        Customer,
                        Customer.FKDiscountCard.DiscountCardTypeStr,
                        ((AppParameter) dCardTypeList[counter]).ParameterLabel);
                }
            }
        }

        private void DiscountCardDistribution(
            Customer customer,
            string currentCardType,
            string nextCardType)
        {
            if (customer == null)
                return;

            if (customer.DiscountRejected == 1)
                return;

            string briefMsgStr, detailMsgStr;
            if (String.IsNullOrEmpty(currentCardType))
            {
                briefMsgStr = "ការប្រគល់ប័ណ្ណបញ្ចុះតំលៃ";
                detailMsgStr = String.Format(
                    "សូម​មេត្តា​ផ្ដល់​ប័ណ្ណ​កាត​បញ្ចុះ​តំលៃ​ប្រភេទ​​ {0} ជូន​ទៅ​អតិថិជន {1}",
                    nextCardType,
                    customer.CustomerName);
            }
            else
            {
                briefMsgStr = "កាផ្លាស់ប្ដូរប័ណ្ណបញ្ចុះតំលៃ";
                detailMsgStr = string.Format(
                    "សូមមេត្តាប្ដូរប័ណ្ណបញ្ចុះតំលៃពីប្រភេទ {0} ទៅប្រភេទ {1} ជូនអតិថិជន {2}",
                    currentCardType,
                    nextCardType,
                    customer.CustomerName);
            }

            using (var frmMessageBox = new FrmExtendedMessageBox())
            {
                frmMessageBox.BriefMsgStr = briefMsgStr;
                frmMessageBox.DetailMsgStr = detailMsgStr;

                if (frmMessageBox.ShowDialog(this) != DialogResult.OK) 
                    return;

                Visible = false;
                using (var frmCustomer = new FrmCustomer())
                {
                    frmCustomer.Customer = customer;
                    if (frmCustomer.ShowDialog(this) == DialogResult.OK)
                        Customer = frmCustomer.Customer;
                    Visible = true;
                }
            }
        }

        private void CalculateSale(string dPercentageStr, float dPercentage)
        {
            var customer = lsbCustomer.SelectedItem as Customer;
            if (customer == null)
                return;

            if (customer.DiscountRejected == 1)
            {
                dPercentage = 0;
                dPercentageStr = "0 %";
            }

            txtDiscount.Text = dPercentageStr;

            var currentAmount = _TotalAmountInt - ((_TotalAmountInt*dPercentage)/100);

            txtTotalAmountUsd.Text = currentAmount.ToString("N", AppContext.CultureInfo);
            txtTotalAmountRiel.Text =
                (_exchangeRate*currentAmount).ToString("N", AppContext.CultureInfo);
            if (Customer == null) 
                return;

            if (Customer.FKDiscountCard == null)
                Customer.FKDiscountCard = new DiscountCard();
            Customer.FKDiscountCard.DiscountPercentage = dPercentage;
            Customer.DiscountPercentage = dPercentage;
        }

        private void UpdateControlContent()
        {
            SafeCrossCallBackDelegate safeCrossCallBackDelegate = null;

            if (cmbDCountType.InvokeRequired)
                safeCrossCallBackDelegate = UpdateControlContent;

            if (cmbDCountType.InvokeRequired)
                Invoke(safeCrossCallBackDelegate);
            else
            {
                _discountTypeList = _CommonService.GetAppParametersByTypeSortByValue(
                    Int32.Parse(Resources.AppParamDiscountType, AppContext.CultureInfo));

                if (_discountTypeList.Count != 0)
                {
                    cmbDCountType.DataSource = _discountTypeList;
                    cmbDCountType.DisplayMember = AppParameter.CONST_PARAMETER_VALUE;
                    cmbDCountType.ValueMember = AppParameter.CONST_PARAMETER_VALUE;

                    if (lsbCustomer.Items.Count != 0)
                    {
                        int selectedIndex = lsbCustomer.SelectedIndex;
                        lsbCustomer.SelectedIndex = -1;
                        lsbCustomer.SelectedIndex = selectedIndex;
                    }
                }
            }
        }

        private void CmbDCountTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbDCountType.DataSource == null) ||
                String.IsNullOrEmpty(cmbDCountType.ValueMember) ||
                String.IsNullOrEmpty(cmbDCountType.DisplayMember))
                return;

            if (cmbDCountType.SelectedIndex == -1)
                return;

            CalculateSale(cmbDCountType.SelectedValue + " %",
                          Int32.Parse(cmbDCountType.SelectedValue.ToString(), AppContext.CultureInfo));

            cmbDCountType.SelectedIndex = -1;
        }

        private void LsbCustomerMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((String.IsNullOrEmpty(lsbCustomer.DisplayMember)) ||
                (String.IsNullOrEmpty(lsbCustomer.ValueMember)) ||
                (lsbCustomer.SelectedIndex == -1))
                return;

            ManageCustomer(
                lsbCustomer.SelectedItem as Customer,
                Resources.OperationRequestUpdate);
        }

        private void ManageCustomer(Customer customer, string operationStr)
        {
            if (String.IsNullOrEmpty(operationStr))
                return;

            Visible = false;
            using (var frmCustomer = new FrmCustomer())
            {
                DiscountCard discountCard = null;
                if (customer != null)
                {
                    frmCustomer.Customer = customer;
                    discountCard = customer.FKDiscountCard;
                }

                if (frmCustomer.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        //Remove existing discount card of selected customer
                        if (discountCard != null)
                            _discountCardList.Remove(discountCard);
                        //Add new discount card of selected customer
                        if (frmCustomer.Customer.FKDiscountCard != null)
                            _discountCardList.Add(frmCustomer.Customer.FKDiscountCard);

                        //Customer
                        if (operationStr.Equals(Resources.OperationRequestInsert))
                            _customerList.Add(frmCustomer.Customer);
                        else
                            _customerList[_customerList.IndexOf(lsbCustomer.SelectedItem as Customer)] =
                                frmCustomer.Customer;

                        lsbCustomer.SelectedIndex = -1;
                        lsbCustomer.SelectedIndex = lsbCustomer.FindStringExact(frmCustomer.Customer.CustomerName);
                    }
                    catch (Exception exception)
                    {
                        FrmExtendedMessageBox.UnknownErrorMessage(
                            Resources.MsgCaptionUnknownError,
                            exception.Message);
                    }
                }
                Visible = true;
            }
        }

        #region Nested type: SafeCrossCallBackDelegate

        private delegate void SafeCrossCallBackDelegate();

        #endregion
    }
}