using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;

namespace EzPos.GUIs.Forms
{
    public partial class FrmSaleSearch : Form
    {
        private CommonService _CommonService;
        private BindingList<SaleOrderReport> _SaleOrderReportList;
        private string _SONumber = string.Empty;

        public FrmSaleSearch()
        {
            InitializeComponent();
        }

        public string SONumber
        {
            get { return _SONumber; }
        }

        private void FrmSaleOrderSearch_Load(object sender, EventArgs e)
        {
            try
            {
                if (_CommonService == null)
                    _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

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
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text == "ម្ដង​ទៀត")
                SetVisibleControls(true);
            else
            {
                try
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
                            "CustomerID = " + Int32.Parse(cmbCustomer.SelectedValue.ToString()));

                    if (!String.IsNullOrEmpty(txtPhoneNumber.Text))
                        searchCriteria.Add(
                            "CustomerID IN (SELECT CustomerID FROM TCustomers WHERE PhoneNumber LIKE '%" +
                            txtPhoneNumber.Text + "%')");

                    if (!String.IsNullOrEmpty(txtCardNumber.Text))
                        searchCriteria.Add(
                            "CardNumber LIKE '%" + txtCardNumber.Text + "%'");

                    if (cmbDiscountType.SelectedItem != null)
                        searchCriteria.Add(
                            "DiscountTypeID = " +
                            Int32.Parse(cmbDiscountType.SelectedValue.ToString()));

                    if (cmbCategory.SelectedItem != null)
                        searchCriteria.Add(
                            "ProductID IN (SELECT ProductID FROM TProducts WHERE CategoryID =  " +
                            Int32.Parse(cmbCategory.SelectedValue.ToString()) + ")");

                    if (cmbBrand.SelectedItem != null)
                        searchCriteria.Add(
                            "ProductID IN (SELECT ProductID FROM TProducts WHERE MarkID =  " +
                            Int32.Parse(cmbBrand.SelectedValue.ToString()) + ")");

                    if (cmbColor.SelectedItem != null)
                        searchCriteria.Add(
                            "ProductID IN (SELECT ProductID FROM TProducts WHERE ColorID =  " +
                            Int32.Parse(cmbColor.SelectedValue.ToString()) + ")");

                    if (!String.IsNullOrEmpty(txtProductCode.Text))
                        searchCriteria.Add(
                            "ProductID IN (SELECT ProductID FROM TProducts WHERE ProductCode LIKE '%" +
                            txtProductCode.Text + "%')");

                    SaleOrderService saleOrderService =
                        ServiceFactory.GenerateServiceInstance().GenerateSaleOrderService();
                    IListToBindingList(
                        saleOrderService.GetSaleOrders(searchCriteria));

                    string searchInfo = String.Format(
                        "ការ​ស្វែងរក​របស់​អ្នក​ផ្ដល់​លទ្ឋផល​ចំនួន {0}",
                        _SaleOrderReportList.Count);
                    lblSearchInfo.Text = searchInfo;
                    SetVisibleControls(false);
                }
                catch (Exception exception)
                {
                    ExtendedMessageBox.UnknownErrorMessage(
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
                var searchCriteria = new List<string> {"ParameterTypeID IN (1, 4, 3, 20)"};

                var objList =
                    _CommonService.GetAppParameters(searchCriteria);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbDiscountType,
                    objList,
                    int.Parse(Resources.AppParamDiscountType, AppContext.CultureInfo),
                    false);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbCategory,
                    objList,
                    int.Parse(Resources.AppParamCategory, AppContext.CultureInfo),
                    false);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbBrand,
                    objList,
                    int.Parse(Resources.AppParamMark, AppContext.CultureInfo),
                    false);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbColor,
                    objList,
                    int.Parse(Resources.AppParamColor, AppContext.CultureInfo),
                    false);

                searchCriteria.Clear();
                searchCriteria.Add(
                    "CustomerID IN (SELECT DISTINCT CustomerID FROM TSaleOrders WHERE CustomerID IS NOT NULL)");
                objList =
                    ServiceFactory.GenerateServiceInstance().GenerateCustomerService().GetCustomers(searchCriteria);
                cmbCustomer.CustomizedDataBinding(
                    objList,
                    Customer.CONST_CUSTOMER_NAME,
                    Customer.CONST_CUSTOMER_ID,
                    false);
            }
        }

        private void FrmSaleOrderSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            btnSearch.BackgroundImage = Resources.background_9;
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            btnSearch.BackgroundImage = Resources.background_2;
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_9;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
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
        }

        private void InitializeSaleOrderReportList()
        {
            try
            {
                if (_SaleOrderReportList == null)
                    _SaleOrderReportList = new BindingList<SaleOrderReport>();

                dgvSearchResult.DataSource = _SaleOrderReportList;
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
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void IListToBindingList(IList saleOrderReportList)
        {
            if (saleOrderReportList == null)
                throw new ArgumentNullException("saleOrderReportList", "Sale Order List");

            try
            {
                _SaleOrderReportList.Clear();
                foreach (SaleOrderReport saleOrderReport in saleOrderReportList)
                    _SaleOrderReportList.Add(saleOrderReport);
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void dgvSearchResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e == null)
                return;

            if (_SaleOrderReportList.Count == 0)
                return;

            _SONumber = (_SaleOrderReportList[e.RowIndex]).SaleOrderNumber;
            DialogResult = DialogResult.OK;
        }

        #region Nested type: SafeCrossCallBackDelegate

        private delegate void SafeCrossCallBackDelegate();

        #endregion
    }
}