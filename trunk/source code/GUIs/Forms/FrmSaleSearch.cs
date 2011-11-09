using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using EzPos.Model.Common;
using EzPos.Model.Customer;
using EzPos.Model.Deposit;
using EzPos.Model.SaleOrder;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Service.User;

namespace EzPos.GUIs.Forms
{
    public partial class FrmSaleSearch : Form
    {
        private CommonService _commonService;
        private BindingList<SaleOrderReport> _saleOrderReportList;
        private IList _depositReportList;
        private string _soNumber = string.Empty;

        public FrmSaleSearch()
        {
            InitializeComponent();
        }

        public string SearchSoNumber
        {
            get { return _soNumber; }
        }

        private void FrmSaleOrderSearch_Load(object sender, EventArgs e)
        {
            try
            {
                if (_commonService == null)
                    _commonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

                dtpStartDate.Value = DateTime.Now.AddMonths(-1);
                InitializeSaleOrderReportList();

                ThreadStart threadStart = UpdateControlContent;
                var thread = 
                    new Thread(threadStart)
                    {
                        Priority = ThreadPriority.Lowest
                    };
                thread.Start();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void BtnSearchClick(object sender, EventArgs e)
        {
            if (btnSearch.Text == Resources.ConstRepeatSearch)
                SetVisibleControls(true);
            else
            {
                try
                {
                    if (rbtSale.Checked)
                    {
                        var searchCriteria =
                            new List<string>
                            {
                                "(ReportHeader = 1) AND (QtySold >= 0)",
                                "SaleOrderDate BETWEEN CONVERT(DATETIME, '" +
                                dtpStartDate.Value.ToString("dd/MM/yyyy") +
                                "', 103) AND CONVERT(DATETIME, '" +
                                dtpStopDate.Value.ToString("dd/MM/yyyy") + " 23:59', 103)"
                            };

                        if (!String.IsNullOrEmpty(txtInvoiceNumber.Text))
                            searchCriteria.Add(
                                "SaleOrderNumber LIKE '%" + txtInvoiceNumber.Text + "%'");

                        if (cmbCustomer.SelectedItem != null)
                            searchCriteria.Add(
                                "CustomerId = " + Int32.Parse(cmbCustomer.SelectedValue.ToString()));

                        if (!String.IsNullOrEmpty(txtPhoneNumber.Text))
                            searchCriteria.Add(
                                "CustomerId IN (SELECT CustomerId FROM TCustomers WHERE PhoneNumber LIKE '%" +
                                txtPhoneNumber.Text + "%')");

                        if (!String.IsNullOrEmpty(txtCardNumber.Text))
                            searchCriteria.Add(
                                "CardNumber LIKE '%" + txtCardNumber.Text + "%'");

                        if (cmbDiscountType.SelectedItem != null)
                            searchCriteria.Add(
                                "DiscountTypeId = " +
                                Int32.Parse(cmbDiscountType.SelectedValue.ToString()));

                        if (cmbCategory.SelectedItem != null)
                            searchCriteria.Add(
                                "ProductId IN (SELECT ProductId FROM TProducts WHERE CategoryId =  " +
                                Int32.Parse(cmbCategory.SelectedValue.ToString()) + ")");

                        if (cmbBrand.SelectedItem != null)
                            searchCriteria.Add(
                                "ProductId IN (SELECT ProductId FROM TProducts WHERE MarkId =  " +
                                Int32.Parse(cmbBrand.SelectedValue.ToString()) + ")");

                        if (cmbColor.SelectedItem != null)
                            searchCriteria.Add(
                                "ProductId IN (SELECT ProductId FROM TProducts WHERE ColorId =  " +
                                Int32.Parse(cmbColor.SelectedValue.ToString()) + ")");

                        if (!String.IsNullOrEmpty(txtProductCode.Text))
                            searchCriteria.Add(
                                "ProductId IN (SELECT ProductId FROM TProducts WHERE (ProductCode LIKE '%" +
                                txtProductCode.Text + "%') OR (ForeignCode LIKE '%" + txtProductCode.Text + "%'))");

                        var saleOrderService =
                            ServiceFactory.GenerateServiceInstance().GenerateSaleOrderService();
                        IListToBindingList(
                            saleOrderService.GetSaleHistories(searchCriteria));

                        var searchInfo = String.Format(
                            "ការ​ស្វែងរក​របស់​អ្នក​ផ្ដល់​លទ្ឋផល​ចំនួន {0}",
                            _saleOrderReportList.Count);
                        lblSearchInfo.Text = searchInfo;
                    }
                    else
                    {
                        var searchCriteria =
                            new List<string>
                        {
                            "(a.DepositDate BETWEEN CONVERT(DATETIME, '" +
                            dtpStartDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
                            "', 103) AND CONVERT(DATETIME, '" +
                            dtpStopDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
                            " 23:59', 103)) ",
                            "(a.AmountPaidInt < a.AmountSoldInt) ",
                            "DepositNumber NOT IN (SELECT ReferenceNum FROM TDeposits WHERE ReferenceNum IS NOT NULL) "
                        };

                        if (!String.IsNullOrEmpty(txtInvoiceNumber.Text))
                            searchCriteria.Add(
                                "a.DepositNumber LIKE '%" + txtInvoiceNumber.Text + "%'");

                        if (cmbCustomer.SelectedItem != null)
                            searchCriteria.Add(
                                "a.CustomerId = " + Int32.Parse(cmbCustomer.SelectedValue.ToString()));

                        if (!String.IsNullOrEmpty(txtPhoneNumber.Text))
                            searchCriteria.Add(
                                "a.CustomerId IN (SELECT CustomerId FROM TCustomers WHERE PhoneNumber LIKE '%" +
                                txtPhoneNumber.Text + "%')");

                        if (!String.IsNullOrEmpty(txtCardNumber.Text))
                            searchCriteria.Add(
                                "a.CardNumber LIKE '%" + txtCardNumber.Text + "%'");

                        if (cmbDiscountType.SelectedItem != null)
                            searchCriteria.Add(
                                "a.DiscountTypeId = " +
                                Int32.Parse(cmbDiscountType.SelectedValue.ToString()));

                        if (cmbCategory.SelectedItem != null)
                            searchCriteria.Add(
                                "e.ProductId IN (SELECT ProductId FROM TProducts WHERE CategoryId =  " +
                                Int32.Parse(cmbCategory.SelectedValue.ToString()) + ")");

                        if (cmbBrand.SelectedItem != null)
                            searchCriteria.Add(
                                "e.ProductId IN (SELECT ProductId FROM TProducts WHERE MarkId =  " +
                                Int32.Parse(cmbBrand.SelectedValue.ToString()) + ")");

                        if (cmbColor.SelectedItem != null)
                            searchCriteria.Add(
                                "e.ProductId IN (SELECT ProductId FROM TProducts WHERE ColorId =  " +
                                Int32.Parse(cmbColor.SelectedValue.ToString()) + ")");

                        if (!String.IsNullOrEmpty(txtProductCode.Text))
                            searchCriteria.Add(
                                "e.ProductId IN (SELECT ProductId FROM TProducts WHERE ProductCode LIKE '%" +
                                txtProductCode.Text + "%')");

                        var depositService =
                            ServiceFactory.GenerateServiceInstance().GenerateDepositService();
                        _depositReportList = depositService.GetDepositHistories(searchCriteria, true);
                        IListToBindingList(
                            depositService.GetSaleHistories(_depositReportList));
                        var searchInfo = String.Format(
                            "ការ​ស្វែងរក​របស់​អ្នក​ផ្ដល់​លទ្ឋផល​ចំនួន {0}",
                            _depositReportList.Count);
                        lblSearchInfo.Text = searchInfo;
                    }
                    SetVisibleControls(false);
                }
                catch (Exception exception)
                {
                    FrmExtendedMessageBox.UnknownErrorMessage(
                        Resources.MsgCaptionUnknownError,
                        exception.Message);
                }
            }
        }


        private void UpdateControlContent()
        {
            SafeCrossCallBackDelegate safeCrossCallBackDelegate = null;
            if ((cmbCustomer.InvokeRequired) || (cmbDiscountType.InvokeRequired) ||
                (cmbCategory.InvokeRequired) || (cmbBrand.InvokeRequired) ||
                (cmbColor.InvokeRequired))
                safeCrossCallBackDelegate = UpdateControlContent;

            if (cmbCustomer.InvokeRequired)
                Invoke(safeCrossCallBackDelegate);
            else
            {
                var searchCriteria = new List<string> {"ParameterTypeId IN (1, 4, 3, 20)"};

                var objList =
                    _commonService.GetAppParameters(searchCriteria);

                _commonService.PopAppParamExtendedCombobox(
                    ref cmbDiscountType,
                    objList,
                    int.Parse(Resources.AppParamDiscountType, AppContext.CultureInfo),
                    false);

                _commonService.PopAppParamExtendedCombobox(
                    ref cmbCategory,
                    objList,
                    int.Parse(Resources.AppParamCategory, AppContext.CultureInfo),
                    false);

                _commonService.PopAppParamExtendedCombobox(
                    ref cmbBrand,
                    objList,
                    int.Parse(Resources.AppParamMark, AppContext.CultureInfo),
                    false);

                _commonService.PopAppParamExtendedCombobox(
                    ref cmbColor,
                    objList,
                    int.Parse(Resources.AppParamColor, AppContext.CultureInfo),
                    false);

                searchCriteria.Clear();
                searchCriteria.Add(
                    "CustomerId IN (SELECT DISTINCT CustomerId FROM TSaleOrders WHERE CustomerId IS NOT NULL)");
                objList =
                    ServiceFactory.GenerateServiceInstance().GenerateCustomerService().GetCustomers(searchCriteria);
                cmbCustomer.CustomizedDataBinding(
                    objList,
                    Customer.ConstCustomerName,
                    Customer.ConstCustomerId,
                    false);
            }
        }

        private void FrmSaleOrderSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void BtnSearchMouseEnter(object sender, EventArgs e)
        {
            btnSearch.BackgroundImage = Resources.background_9;
        }

        private void BtnSearchMouseLeave(object sender, EventArgs e)
        {
            btnSearch.BackgroundImage = Resources.background_2;
        }

        private void BtnCancelMouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_9;
        }

        private void BtnCancelMouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_2;
        }

        private void SetVisibleControls(bool isVisible)
        {
            grbSaleInfo.Visible = isVisible;
            grbCustomerInfo.Visible = isVisible;
            grbProductInfo.Visible = isVisible;

            lblSearchInfo.Visible = !isVisible;
            dgvSearchResult.Visible = !isVisible;

            btnSearch.Text = isVisible ? "​ស្វែងរក" : "ម្ដង​ទៀត";
            btnDeleteDeposit.Visible = ((!isVisible) && rbtDeposit.Checked);
        }

        private void InitializeSaleOrderReportList()
        {
            try
            {
                if (_saleOrderReportList == null)
                    _saleOrderReportList = new BindingList<SaleOrderReport>();

                dgvSearchResult.DataSource = _saleOrderReportList;
                dgvSearchResult.Columns["SaleOrderNumber"].DisplayIndex = 0;
                dgvSearchResult.Columns["SaleOrderDate"].DisplayIndex = 1;
                dgvSearchResult.Columns["CustomerName"].DisplayIndex = 2;
                dgvSearchResult.Columns["CashierName"].DisplayIndex = 3;
                dgvSearchResult.Columns["AmountSoldInt"].DisplayIndex = 4;
                dgvSearchResult.Columns["AmountPaidInt"].DisplayIndex = 5;
                dgvSearchResult.Columns["AmountReturnInt"].DisplayIndex = 6;
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void IListToBindingList(IList saleOrderReportList)
        {
            if (saleOrderReportList == null)
                throw new ArgumentNullException("saleOrderReportList", Resources.MsgInvalidSaleOrder);

            try
            {
                _saleOrderReportList.Clear();
                foreach (SaleOrderReport saleOrderReport in saleOrderReportList)
                    _saleOrderReportList.Add(saleOrderReport);
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void DgvSearchResultCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(rbtDeposit.Checked)
                return;

            if (e == null)
                return;

            if (_saleOrderReportList.Count == 0)
                return;

            _soNumber = (_saleOrderReportList[e.RowIndex]).SaleOrderNumber;
            DialogResult = DialogResult.OK;
        }

        #region Nested type: SafeCrossCallBackDelegate

        private delegate void SafeCrossCallBackDelegate();

        #endregion

        private void BtnDeleteDepositMouseEnter(object sender, EventArgs e)
        {
            btnDeleteDeposit.BackgroundImage = Resources.background_9;
        }

        private void BtnDeleteDepositMouseLeave(object sender, EventArgs e)
        {
            btnDeleteDeposit.BackgroundImage = Resources.background_2;
        }

        private void BtnDeleteDepositClick(object sender, EventArgs e)
        {
            var briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
            var detailMsg = Resources.MsgUserPermissionDeny;
            if (!UserService.AllowToPerform(Resources.PermissionCancelDeposit))
            {
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                    return;
                }
            }

            if (_depositReportList == null)
                return;

            if (_depositReportList.Count == 0)
                return;

            if (dgvSearchResult.CurrentRow == null)
                return;

            var depositReport = _depositReportList[dgvSearchResult.CurrentRow.Index] as DepositReport;
            if(depositReport == null)
                return;

            var depositService = ServiceFactory.GenerateServiceInstance().GenerateDepositService();
            var searchCriteria = new List<string> {"DepositId|" + depositReport.DepositId};
            var depositList = depositService.GetDeposits(searchCriteria);
            if (depositList.Count == 0)
                return;

            var deposit = depositList[0] as Deposit;
            if (deposit == null)
                return;

            briefMsg = "អំពីការបោះបង់";
            detailMsg = "សូម​មេត្តា​ចុច​លើ​ប៊ូតុង យល់​ព្រម ដើម្បី​បញ្ជាក់​ពី​ការ​ប្រគល់​សង​។";
            using (var frmMessageBox = new FrmExtendedMessageBox())
            {
                frmMessageBox.BriefMsgStr = briefMsg;
                frmMessageBox.DetailMsgStr = detailMsg;
                if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            deposit.DepositDate = DateTime.Now;
            deposit = depositService.RecordDeposit(
                new List<DepositItem>(),
                deposit.AmountSoldInt,
                deposit.AmountPaidInt,
                0,
                deposit.FkCustomer,
                deposit.DepositNumber,
                deposit.Discount,
                true);

            var paymentService = ServiceFactory.GenerateServiceInstance().GeneratePaymentService();
            var payment =
                new Model.Payments.Payment
                {
                    PaymentDate = deposit.DepositDate,
                    PaymentAmount = deposit.AmountPaidInt,
                    SalesOrderId = deposit.DepositId,
                    CashierId = deposit.CashierId
                };
            paymentService.ManagePayment(Resources.OperationRequestInsert, payment);
            BtnSearchClick(null, null);
        }
    }
}