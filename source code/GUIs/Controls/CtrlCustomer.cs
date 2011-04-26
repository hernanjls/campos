using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using EzPos.GUIs.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Utility;
using NHibernate;

namespace EzPos.GUIs.Controls
{
    public partial class CtrlCustomer : UserControl
    {
        private CommonService _CommonService;
        private BindingList<Customer> _CustomerList;
        private CustomerService _CustomerService;

        public CtrlCustomer()
        {
            InitializeComponent();
        }

        public CustomerService CustomerService
        {
            set { _CustomerService = value; }
        }

        public CommonService CommonService
        {
            set { _CommonService = value; }
        }

        private void CtrlCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                if (!UserService.AllowToPerform(Resources.PermissionViewCustResultInfo))
                {
                    lblResultInfo.Visible = false;
                }
                if (_CustomerService == null)
                    _CustomerService = ServiceFactory.GenerateServiceInstance().GenerateCustomerService();
                if (_CommonService == null)
                    _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

                InitializeCustomerList();

                ThreadStart threadStart = UpdateControlContent;
                var thread = new Thread(threadStart) {IsBackground = true};
                thread.Start();

                var discountCardList = _CustomerService.GetUsedDiscountCards();
                cmbDiscountCard.CustomizedDataBinding(
                    discountCardList,
                    DiscountCard.CONST_DISCOUNT_CARD_NUMBER,
                    DiscountCard.CONST_CUSTOMER_ID,
                    false);

                IListToBindingList(_CustomerService.GetCustomers());
                dgvCustomer.Refresh();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void InitializeCustomerList()
        {
            if (_CustomerList == null)
                _CustomerList = new BindingList<Customer>();

            dgvCustomer.DataSource = _CustomerList;
            dgvCustomer.Columns["CustomerName"].DisplayIndex = 0;
            dgvCustomer.Columns["GenderID"].DisplayIndex = 1;
            dgvCustomer.Columns["PhoneNumber"].DisplayIndex = 2;
            dgvCustomer.Columns["EmailAddress"].DisplayIndex = 3;
            dgvCustomer.Columns["Website"].DisplayIndex = 4;
        }

        private void IListToBindingList(IList customerList)
        {
            if (customerList == null)
                throw new ArgumentNullException("customerList", "customerList");

            if (_CustomerList == null)
                return;

            _CustomerList.Clear();
            foreach (Customer customer in customerList)
            {
                if (cmbDiscountCard.Items.Count != 0)
                {
                    cmbDiscountCard.SelectedValue = customer.CustomerID;
                    if (cmbDiscountCard.SelectedItem != null)
                    {
                        var discountCard = (DiscountCard) cmbDiscountCard.SelectedItem;
                        customer.DiscountCardNumber = discountCard.CardNumber;
                        customer.DiscountCardType = discountCard.DiscountCardTypeStr;
                        customer.DiscountPercentage = discountCard.DiscountPercentage;
                    }
                }
                _CustomerList.Add(customer);
            }

            UpdateResultInfo();
            EnableActionButton();
        }

        private void dgvCustomer_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            FrmExtendedMessageBox.UnknownErrorMessage(
                Resources.MsgCaptionUnknownError,
                e.Exception.Message);
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionEditCustomer))
            {
                const string briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                var detailMsg = Resources.MsgUserPermissionDeny;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                    return;
                }
            }

            CustomerManagement(Resources.OperationRequestUpdate);
        }

        private void CustomerManagement(IEquatable<string> operationRequest)
        {
            using (var frmCustomer = new FrmCustomer())
            {
                frmCustomer.CommonService = _CommonService;
                frmCustomer.CustomerService = _CustomerService;

                if (operationRequest.Equals(Resources.OperationRequestUpdate))
                    if (dgvCustomer.CurrentRow != null)
                        frmCustomer.Customer = _CustomerList[dgvCustomer.CurrentRow.Index];

                if (frmCustomer.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        ThreadStart threadStart = UpdateControlContent;
                        var thread = new Thread(threadStart);
                        thread.Start();

                        if (operationRequest.Equals(Resources.OperationRequestInsert))
                            _CustomerList.Add(frmCustomer.Customer);

                        dgvCustomer.Refresh();
                        SetCustomerInfo();
                        UpdateResultInfo();
                        EnableActionButton();
                    }
                    catch (Exception exception)
                    {
                        FrmExtendedMessageBox.UnknownErrorMessage(
                            Resources.MsgCaptionUnknownError,
                            exception.Message);
                    }
                }
            }

            SetFocusToCustomerList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionAddCustomer))
            {
                const string briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                var detailMsg = Resources.MsgUserPermissionDeny;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                    return;
                }
            }

            CustomerManagement(Resources.OperationRequestInsert);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string briefMsg, detailMsg;

            if (!UserService.AllowToPerform(Resources.PermissionDeleteCustomer))
            {
                briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                detailMsg = Resources.MsgUserPermissionDeny;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                    return;
                }
            }

            SetFocusToCustomerList();

            //string briefMsg, detailMsg;
            briefMsg = "អំពីការលុប";
            detailMsg = Resources.MsgOperationRequestDelete + "\n" +
                        dgvCustomer.CurrentRow.Cells["CustomerName"].Value + " ?";
            using (var frmMessageBox = new FrmExtendedMessageBox())
            {
                frmMessageBox.BriefMsgStr = briefMsg;
                frmMessageBox.DetailMsgStr = detailMsg;
                if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            try
            {
                _CustomerService.CustomerManagement(
                    _CustomerList[dgvCustomer.CurrentRow.Index],
                    Resources.OperationRequestDelete);

                ThreadStart threadStart = UpdateControlContent;
                var thread = new Thread(threadStart);
                thread.Start();

                _CustomerList.RemoveAt(dgvCustomer.CurrentRow.Index);
                dgvCustomer.Refresh();

                UpdateResultInfo();
                EnableActionButton();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            SetCustomerInfo();
        }

        private void SetCustomerInfo()
        {
            if ((_CustomerList.Count == 0) || (dgvCustomer.CurrentRow == null))
            {
                addressLbl.Text = string.Empty;
                purchaseAmountLbl.Text = "$ 0.00";
                debtAmountLbl.Text = "$ 0.00";
                return;
            }

            var customer = _CustomerList[dgvCustomer.CurrentRow.Index];
            addressLbl.Text = customer.Address;
            purchaseAmountLbl.Text = "$ " + customer.PurchasedAmount.ToString("N", AppContext.CultureInfo);
            debtAmountLbl.Text = "$ " + customer.DebtAmount.ToString("N", AppContext.CultureInfo);
        }

        private void UpdateControlContent()
        {
            SafeCrossCallBackDelegate safeCrossCallBackDelegate = null;
            if ((cmbDCardType.InvokeRequired))
                safeCrossCallBackDelegate = UpdateControlContent;

            if (cmbDCardType.InvokeRequired)
                Invoke(safeCrossCallBackDelegate);
            else
            {
                var searchCriteria = new List<string> {"ParameterTypeID IN (20)"};

                var objList = _CommonService.GetAppParameters(searchCriteria);

                //_CommonService.PopAppParamExtendedCombobox(
                //    ref cmbGender, objList, int.Parse(Resources.AppParamGender, AppContext.CultureInfo), false);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbDCardType, objList, int.Parse(Resources.AppParamDiscountType, AppContext.CultureInfo), false);
            }
        }

        private void SetFocusToCustomerList()
        {
            if (dgvCustomer.CanFocus)
                dgvCustomer.Focus();
        }

        private void EnableActionButton()
        {
            btnDelete.Enabled = _CustomerList.Count != 0;
            SetFocusToCustomerList();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCustomerName.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            chbDeposit.Checked = false;
            txtCardNum.Text = string.Empty;
            cmbDCardType.SelectedIndex = -1;

            btnSearch_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var searchCriteria = new List<string>();
                if (StringHelper.Length(txtCustomerName.Text) != 0)
                    searchCriteria.Add("CustomerName LIKE '%" + txtCustomerName.Text + "%'");

                if (StringHelper.Length(txtPhoneNumber.Text) != 0)
                    searchCriteria.Add("PhoneNumber LIKE '%" + txtPhoneNumber.Text + "%'");

                if (chbDeposit.Checked)
                    searchCriteria.Add(
                        "CustomerID IN (SELECT CustomerId FROM TDeposits WHERE (AmountPaidInt < AmountSoldInt) AND (DepositNumber NOT IN (SELECT ReferenceNum FROM TDeposits WHERE ReferenceNum IS NOT NULL)))");

                if (StringHelper.Length(txtCardNum.Text) != 0)
                    searchCriteria.Add(
                        "CustomerID IN (SELECT CustomerID FROM TDiscountCards WHERE CustomerID <> 0 AND CardNumber LIKE '%" +
                        StringHelper.Right("000000000" + txtCardNum.Text, 9) + "%')");

                if (cmbDCardType.SelectedIndex != -1)
                    searchCriteria.Add(
                        "CustomerID IN (SELECT CustomerID FROM TDiscountCards WHERE CustomerID <> 0 AND DiscountCardTypeID = " +
                        cmbDCardType.SelectedValue + ")");

                IListToBindingList(
                    _CustomerService.GetCustomers(searchCriteria));
                dgvCustomer.Refresh();
            }
            catch (ADOException exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void UpdateResultInfo()
        {
            var resultNum = 0;
            if (_CustomerList != null)
                resultNum = _CustomerList.Count;

            var strResultInfo = string.Format(
                "ការសែ្វងរករបស់អ្នកផ្តល់លទ្ឋផលចំនួន {0}",
                resultNum.ToString("N0", AppContext.CultureInfo));
            lblResultInfo.Text = strResultInfo;
        }

        private void btnNew_MouseEnter(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = Resources.background_9;
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackgroundImage = Resources.background_9;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackgroundImage = null;
        }

        private void btnNew_MouseLeave(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = null;
        }

        #region Nested type: SafeCrossCallBackDelegate

        private delegate void SafeCrossCallBackDelegate();

        #endregion

        private void btnOutstandingInvoice_Click(object sender, EventArgs e)
        {
            Visible = false;
            using (var frmOutstandingInvoice = new FrmDeposit())
            {
                if(dgvCustomer.CurrentRow == null)
                    return;

                frmOutstandingInvoice.CustomerId = _CustomerList[dgvCustomer.CurrentRow.Index].CustomerID;
                if (frmOutstandingInvoice.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
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

        private void btnOutstandingInvoice_MouseEnter(object sender, EventArgs e)
        {
            btnOutstandingInvoice.BackgroundImage = Resources.background_9;
        }

        private void btnOutstandingInvoice_MouseLeave(object sender, EventArgs e)
        {
            btnOutstandingInvoice.BackgroundImage = null;
        }
    }
}