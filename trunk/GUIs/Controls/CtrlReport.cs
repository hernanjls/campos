using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EzPos.GUIs.DataSets;
using EzPos.GUIs.Forms;
using EzPos.GUIs.Reports;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;

namespace EzPos.GUIs.Controls
{
    public partial class CtrlReport : UserControl
    {
        private ExpenseService _ExpenseService;
        private ProductService _ProductService;
        private SaleOrderService _SaleOrderService;
        private DepositService _DepositService;

        public CtrlReport()
        {
            InitializeComponent();
        }

        public SaleOrderService SaleOrderService
        {
            set { _SaleOrderService = value; }
        }

        public ProductService ProductService
        {
            set { _ProductService = value; }
        }

        public ExpenseService ExpenseService
        {
            set { _ExpenseService = value; }
        }

        private void RefreshReportSale(bool showBenefit)
        {
            if (chbShowBenefit.Checked)
            {
                if (!UserService.AllowToPerform(Resources.PermissionViewSaleDetailReport))
                {
                    const string briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                    var detailMsg = Resources.MsgUserPermissionDeny;
                    using (var frmMessageBox = new ExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }
            }
            else
            {
                if (!UserService.AllowToPerform(Resources.PermissionViewSaleReport))
                {
                    const string briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                    var detailMsg = Resources.MsgUserPermissionDeny;
                    using (var frmMessageBox = new ExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }
            }

            var searchCriteria = 
                new List<string>
                {
                    "SaleOrderNumber IN (SELECT SaleOrderNumber FROM TSaleOrders WHERE SaleOrderTypeID = 0)",
                    "SaleOrderDate BETWEEN CONVERT(DATETIME, '" +
                    dtpStartAdmin.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
                    "', 103) AND CONVERT(DATETIME, '" +
                    dtpStopAdmin.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
                    " 23:59', 103)"
                };
            var saleList = _SaleOrderService.GetSaleHistories(searchCriteria);

            DataSet dtsModel = new DtsModels();
            var PropertyInfos = typeof (SaleOrderReport).GetProperties();
            foreach (var objInstance in saleList)
            {
                var dataRow = dtsModel.Tables[1].NewRow();
                foreach (var propertyInfo in PropertyInfos)
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
                dtsModel.Tables[1].Rows.Add(dataRow);
            }

            if (!showBenefit)
            {
                var rptSaleOrder = new CsrSaleOrder();
                rptSaleOrder.SetDataSource(dtsModel);
                crvReport.ReportSource = rptSaleOrder;
            }
            else
            {
                var rptSaleBenefit = new CsrSaleBenefit();
                rptSaleBenefit.SetDataSource(dtsModel);
                crvReport.ReportSource = rptSaleBenefit;
            }
        }

        private void RefreshReportReturn()
        {
            if (!UserService.AllowToPerform(Resources.PermissionViewReturnProductReport))
            {
                const string briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                var detailMsg = Resources.MsgUserPermissionDeny;
                using (var frmMessageBox = new ExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                    return;
                }
            }

            var searchCriteria = 
                new List<string>
                {
                    "SaleOrderNumber IN (SELECT SaleOrderNumber FROM TSaleOrders WHERE SaleOrderTypeID = 1)",
                    "SaleOrderDate BETWEEN CONVERT(DATETIME, '" +
                    dtpStartAdmin.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
                    "', 103) AND CONVERT(DATETIME, '" +
                    dtpStopAdmin.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
                    " 23:59', 103)"
                };

            var assessmentList = _SaleOrderService.GetSaleHistories(searchCriteria);

            DataSet dtsModel = new DtsModels();
            var PropertyInfos = typeof (SaleOrderReport).GetProperties();
            foreach (var objInstance in assessmentList)
            {
                var dataRow = dtsModel.Tables[1].NewRow();
                foreach (var propertyInfo in PropertyInfos)
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
                dtsModel.Tables[1].Rows.Add(dataRow);
            }

            var rptSaleReturn = new CsrSaleReturn();
            rptSaleReturn.SetDataSource(dtsModel);
            crvReport.ReportSource = rptSaleReturn;
        }

        private void RefreshReportStock()
        {
            try
            {
                if (rdbStockDetail.Checked)
                {
                    if (!UserService.AllowToPerform(Resources.PermissionViewDetailStockReport))
                    {
                        const string briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                        var detailMsg = Resources.MsgUserPermissionDeny;
                        using (var frmMessageBox = new ExtendedMessageBox())
                        {
                            frmMessageBox.BriefMsgStr = briefMsg;
                            frmMessageBox.DetailMsgStr = detailMsg;
                            frmMessageBox.IsCanceledOnly = true;
                            frmMessageBox.ShowDialog(this);
                            return;
                        }
                    }
                }
                else if (rdbStockShort.Checked)
                {
                    if (!UserService.AllowToPerform(Resources.PermissionViewStockReport))
                    {
                        const string briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                        var detailMsg = Resources.MsgUserPermissionDeny;
                        using (var frmMessageBox = new ExtendedMessageBox())
                        {
                            frmMessageBox.BriefMsgStr = briefMsg;
                            frmMessageBox.DetailMsgStr = detailMsg;
                            frmMessageBox.IsCanceledOnly = true;
                            frmMessageBox.ShowDialog(this);
                            return;
                        }
                    }
                }
                else
                {
                    if (!UserService.AllowToPerform(Resources.PermissionViewExpiredProductReport))
                    {
                        const string briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                        var detailMsg = Resources.MsgUserPermissionDeny;
                        using (var frmMessageBox = new ExtendedMessageBox())
                        {
                            frmMessageBox.BriefMsgStr = briefMsg;
                            frmMessageBox.DetailMsgStr = detailMsg;
                            frmMessageBox.IsCanceledOnly = true;
                            frmMessageBox.ShowDialog(this);
                            return;
                        }
                    }
                }

                var searchCriteria = new List<string> {"QtyInStock > 0"};
                if (rdbProductExpired.Checked)
                    searchCriteria.Add(
                        "LastUpdate <= CONVERT(DATETIME, '" +
                        DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy") +
                        "', 103)");

                var productList = _ProductService.GetObjects(searchCriteria);

                DataSet dtsProduct = new DtsModels();
                var PropertyInfos = typeof (Product).GetProperties();
                foreach (var objInstance in productList)
                {
                    var dataRow = dtsProduct.Tables[0].NewRow();
                    foreach (var propertyInfo in PropertyInfos)
                        dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
                    dtsProduct.Tables[0].Rows.Add(dataRow);
                }

                if ((rdbStockDetail.Checked) || (rdbProductExpired.Checked))
                {
                    var csrCatalog = new CsrCatalog();
                    csrCatalog.SetDataSource(dtsProduct);
                    crvReport.ReportSource = csrCatalog;
                }
                else
                {
                    var csrCatalogShorten = new CsrCatalogShorten();
                    csrCatalogShorten.SetDataSource(dtsProduct);
                    crvReport.ReportSource = csrCatalogShorten;
                }
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void btnSearchStock_Click(object sender, EventArgs e)
        {
            RefreshReportStock();
        }

        private void btnSearchSale_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbSale.Checked)
                    RefreshReportSale(chbShowBenefit.Checked);
                else if (rdbDeposit.Checked)
                {
                    RefreshReportDeposit();
                }
                else
                    RefreshReportReturn();
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
                throw;
            }
        }

        private void btnSearchStock_MouseEnter(object sender, EventArgs e)
        {
            btnSearchStock.BackgroundImage = Resources.background_9;
        }

        private void btnSearchStock_MouseLeave(object sender, EventArgs e)
        {
            btnSearchStock.BackgroundImage = null;
        }

        private void btnSearchSale_MouseEnter(object sender, EventArgs e)
        {
            btnSearchSale.BackgroundImage = Resources.background_9;
        }

        private void btnSearchSale_MouseLeave(object sender, EventArgs e)
        {
            btnSearchSale.BackgroundImage = null;
        }

        private void btnDailyReport_Click(object sender, EventArgs e)
        {
            refreshDailyExpenseReport();
        }

        private void refreshDailyExpenseReport()
        {
            if (!UserService.AllowToPerform(Resources.PermissionViewExpenseReport))
            {
                const string briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                var detailMsg = Resources.MsgUserPermissionDeny;
                using (var frmMessageBox = new ExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                    return;
                }
            }

            var searchCriteria = 
                new List<string>
                {
                    "CONVERT(DATETIME, ExpenseDate, 103) BETWEEN CONVERT(DATETIME, '" +
                    dtpExpenseStart.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
                    "', 103) AND CONVERT(DATETIME, '" +
                    dtpExpenseStop.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
                    " 23:59', 103)"
                };
            var expenseList = _ExpenseService.GetExpenses(searchCriteria);

            DataSet dtsProduct = new DtsModels();
            var PropertyInfos = typeof (Expense).GetProperties();
            foreach (var objInstance in expenseList)
            {
                var dataRow = dtsProduct.Tables["DtbExpenses"].NewRow();
                foreach (var propertyInfo in PropertyInfos)
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
                dtsProduct.Tables["DtbExpenses"].Rows.Add(dataRow);
            }

            var csrExpense = new CsrExpense();
            csrExpense.SetDataSource(dtsProduct);
            crvReport.ReportSource = csrExpense;
        }

        private void btnDailyReport_MouseEnter(object sender, EventArgs e)
        {
            btnDailyReport.BackgroundImage = Resources.background_9;
        }

        private void btnDailyReport_MouseLeave(object sender, EventArgs e)
        {
            btnDailyReport.BackgroundImage = null;
        }

        private void CtrlReport_Load(object sender, EventArgs e)
        {
            if (_SaleOrderService == null)
                _SaleOrderService = ServiceFactory.GenerateServiceInstance().GenerateSaleOrderService();
            if (_DepositService == null)
                _DepositService = ServiceFactory.GenerateServiceInstance().GenerateDepositService();
            if (_ProductService == null)
                _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();
            if (_ExpenseService == null)
                _ExpenseService = ServiceFactory.GenerateServiceInstance().GenerateExpenseService();
        }               

        private void RefreshReportDeposit()
        {
            if (!UserService.AllowToPerform(Resources.PermissionViewDepositReport))
            {
                const string briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                var detailMsg = Resources.MsgUserPermissionDeny;
                using (var frmMessageBox = new ExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                    return;
                }
            }

            var searchCriteria =
                new List<string>
                {
                    "(DepositDate BETWEEN CONVERT(DATETIME, '" +
                    dtpStartAdmin.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
                    "', 103) AND CONVERT(DATETIME, '" +
                    dtpStopAdmin.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
                    " 23:59', 103)) "
                    //,
                    //"and (AmountPaidInt < AmountSoldInt) "
                };

            var assessmentList = _DepositService.GetDepositHistories(searchCriteria);

            DataSet dtsModel = new DtsModels();
            var PropertyInfos = typeof(DepositReport).GetProperties();
            foreach (var objInstance in assessmentList)
            {
                var dataRow = dtsModel.Tables[3].NewRow();
                foreach (var propertyInfo in PropertyInfos)
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
                dtsModel.Tables[3].Rows.Add(dataRow);
            }

            var rptDeposit = new CsrDeposit();
            rptDeposit.SetDataSource(dtsModel);
            crvReport.ReportSource = rptDeposit;           
        }
    }
}