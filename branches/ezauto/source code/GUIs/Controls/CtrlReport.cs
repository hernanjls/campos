using System;
using System.IO;
using System.Linq;
using System.Threading;
using EzPos.Model;
using EzPos.Model.Expense;
using EzPos.Service;
using EzPos.GUIs.Forms;
using EzPos.Properties;
using System.Windows.Forms;
using System.Collections.Generic;
using EzPos.Service.Common;
using EzPos.Service.Product;
using EzPos.Service.Report;
using EzPos.Service.SaleOrder;
using Microsoft.Office.Interop.Excel;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;
using System.Runtime.InteropServices;

namespace EzPos.GUIs.Controls
{
    public partial class CtrlReport : UserControl
    {
        private ExpenseService _expenseService;
        private ProductService _productService;
        private SaleOrderService _saleOrderService;

        private delegate void SafeCrossCallBackDelegate();

        private ReportService _reportService;
        private DepositService _depositService;
        private CommonService _commonService;

        public CtrlReport()
        {
            InitializeComponent();
        }

        public SaleOrderService SaleOrderService
        {
            set { _saleOrderService = value; }
        }

        public ProductService ProductService { get; set; }

        public ExpenseService ExpenseService
        {
            set { _expenseService = value; }
        }

        private void RefreshReportSale()
        {
            if (chbShowBenefit.Checked)
            {
                if (!UserService.AllowToPerform(Resources.PermissionViewSaleDetailReport))
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
            }
            else
            {
                if (!UserService.AllowToPerform(Resources.PermissionViewSaleReport))
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
            }

            //var searchCriteria = 
            //    new List<string>
            //    {
            //        "SaleOrderNumber IN (SELECT SaleOrderNumber FROM TSaleOrders WHERE SaleOrderTypeID = 0)",
            //        "SaleOrderDate BETWEEN CONVERT(DATETIME, '" +
            //        dtpStartDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
            //        "', 103) AND CONVERT(DATETIME, '" +
            //        dtpStopDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
            //        " 23:59', 103)"
            //    };
            //var saleList = _saleOrderService.GetSaleHistories(searchCriteria);

            //DataSet dtsModel = new DtsModels();
            //var propertyInfos = typeof (SaleOrderReport).GetProperties();
            //foreach (var objInstance in saleList)
            //{
            //    var dataRow = dtsModel.Tables[1].NewRow();
            //    foreach (var propertyInfo in propertyInfos)
            //        dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
            //    dtsModel.Tables[1].Rows.Add(dataRow);
            //}

            //if (chbShowQuantity.Checked)
            //{
            //    var rptSaleOrderQuantity = new CsrSaleOrderQuantity();
            //    rptSaleOrderQuantity.SetDataSource(dtsModel);
            //    crvReport.ReportSource = rptSaleOrderQuantity;
            //}
            //else if(chbShowBenefit.Checked)
            //{
            //    var rptSaleBenefit = new CsrSaleBenefit();
            //    rptSaleBenefit.SetDataSource(dtsModel);
            //    crvReport.ReportSource = rptSaleBenefit;
            //}
            //else
            //{
            //    var rptSaleOrder = new CsrSaleOrder();
            //    rptSaleOrder.SetDataSource(dtsModel);
            //    crvReport.ReportSource = rptSaleOrder;
            //}

            var selectedMarkId = -1;
            if (cmbMark.SelectedItem != null)
            {
                Int32.TryParse(cmbMark.SelectedValue.ToString(), out selectedMarkId);
            }

            _reportService.SaleOrderService = _saleOrderService;
            var reportFileName = _reportService.SaleStatementReport(
                dtpStartDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo),
                dtpStopDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo),
                selectedMarkId,
                chbShowBenefit.Checked);

            OpenReport(reportFileName);
        }

        //private void RefreshReportReturn()
        //{
        //    if (!UserService.AllowToPerform(Resources.PermissionViewReturnProductReport))
        //    {
        //        const string briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
        //        var detailMsg = Resources.MsgUserPermissionDeny;
        //        using (var frmMessageBox = new FrmExtendedMessageBox())
        //        {
        //            frmMessageBox.BriefMsgStr = briefMsg;
        //            frmMessageBox.DetailMsgStr = detailMsg;
        //            frmMessageBox.IsCanceledOnly = true;
        //            frmMessageBox.ShowDialog(this);
        //            return;
        //        }
        //    }

        //    var searchCriteria = 
        //        new List<string>
        //        {
        //            "SaleOrderNumber IN (SELECT SaleOrderNumber FROM TSaleOrders WHERE SaleOrderTypeID = 1)",
        //            "SaleOrderDate BETWEEN CONVERT(DATETIME, '" +
        //            dtpStartDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
        //            "', 103) AND CONVERT(DATETIME, '" +
        //            dtpStopDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
        //            " 23:59', 103)"
        //        };

        //    var assessmentList = _saleOrderService.GetSaleHistories(searchCriteria);

        //    DataSet dtsModel = new DtsModels();
        //    var propertyInfos = typeof (SaleOrderReport).GetProperties();
        //    foreach (var objInstance in assessmentList)
        //    {
        //        var dataRow = dtsModel.Tables[1].NewRow();
        //        foreach (var propertyInfo in propertyInfos)
        //            dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
        //        dtsModel.Tables[1].Rows.Add(dataRow);
        //    }

        //    var rptSaleReturn = new CsrSaleReturn();
        //    rptSaleReturn.SetDataSource(dtsModel);
        //    crvReport.ReportSource = rptSaleReturn;
        //}

        private void RefreshReportStock()
        {
            try
            {
                //if (rdbStockDetail.Checked)
                //{
                    if (!UserService.AllowToPerform(Resources.PermissionViewDetailStockReport))
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
                //}
                //else if (rdbStockShort.Checked)
                //{
                //    if (!UserService.AllowToPerform(Resources.PermissionViewStockReport))
                //    {
                //        const string briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                //        var detailMsg = Resources.MsgUserPermissionDeny;
                //        using (var frmMessageBox = new FrmExtendedMessageBox())
                //        {
                //            frmMessageBox.BriefMsgStr = briefMsg;
                //            frmMessageBox.DetailMsgStr = detailMsg;
                //            frmMessageBox.IsCanceledOnly = true;
                //            frmMessageBox.ShowDialog(this);
                //            return;
                //        }
                //    }
                //}
                //else
                //{
                //    if (!UserService.AllowToPerform(Resources.PermissionViewExpiredProductReport))
                //    {
                //        const string briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                //        var detailMsg = Resources.MsgUserPermissionDeny;
                //        using (var frmMessageBox = new FrmExtendedMessageBox())
                //        {
                //            frmMessageBox.BriefMsgStr = briefMsg;
                //            frmMessageBox.DetailMsgStr = detailMsg;
                //            frmMessageBox.IsCanceledOnly = true;
                //            frmMessageBox.ShowDialog(this);
                //            return;
                //        }
                //    }
                //}

                var selectedMarkId = -1;
                var selctedMarkStr = string.Empty;
                if(cmbMark.SelectedItem != null)
                {
                    Int32.TryParse(cmbMark.SelectedValue.ToString(), out selectedMarkId);
                    selctedMarkStr = cmbMark.Text;
                }

                _reportService.ProductService = _productService;
                var reportFileName = _reportService.StockStatementReport(
                    selectedMarkId,
                    selctedMarkStr);

                OpenReport(reportFileName);
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void BtnSearchStockClick(object sender, EventArgs e)
        {
            RefreshReportStock();
        }

        private void BtnSearchSaleClick(object sender, EventArgs e)
        {
            try
            {
                if (!UserService.AllowToPerform(Resources.PermissionByDatesReport))
                {
                    if ((!dtpStartDate.Value.Date.Equals(DateTime.Today)) || (!dtpStopDate.Value.Date.Equals(DateTime.Today)))
                    {
                        const string briefMsg = "សិទ្ធមើល របាយការណ៏តាមថ្ងៃ";
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
                }

                crvReport.BringToFront();
                if (rdbSale.Checked)
                    RefreshReportSale();
                //else if (rdbDeposit.Checked)
                //    RefreshReportDeposit(chbAllDeposit.Checked);
                //else if (rdbReturn.Checked)
                //    RefreshReportReturn();
                else if (rdbExpense.Checked)
                    RefreshDailyExpenseReport();
                else
                    RefreshIncomeStatementReport();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
                throw;
            }
        }

        private void BtnSearchStockMouseEnter(object sender, EventArgs e)
        {
            btnSearchStock.BackgroundImage = Resources.background_9;
        }

        private void BtnSearchStockMouseLeave(object sender, EventArgs e)
        {
            btnSearchStock.BackgroundImage = null;
        }

        private void BtnSearchSaleMouseEnter(object sender, EventArgs e)
        {
            btnSearchSale.BackgroundImage = Resources.background_9;
        }

        private void BtnSearchSaleMouseLeave(object sender, EventArgs e)
        {
            btnSearchSale.BackgroundImage = null;
        }

        private void RefreshDailyExpenseReport()
        {
            if (!UserService.AllowToPerform(Resources.PermissionViewExpenseReport))
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

            _reportService.ExpenseService = _expenseService;
            var reportFileName = _reportService.ExpenseStatementReport(
                dtpStartDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo),
                dtpStopDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo));

            OpenReport(reportFileName);

            //var searchCriteria = 
            //    new List<string>
            //    {
            //        "CONVERT(DATETIME, ExpenseDate, 103) BETWEEN CONVERT(DATETIME, '" +
            //        dtpStartDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
            //        "', 103) AND CONVERT(DATETIME, '" +
            //        dtpStopDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
            //        " 23:59', 103)"
            //    };
            //var expenseList = _ExpenseService.GetExpenses(searchCriteria);

            //DataSet dtsProduct = new DtsModels();
            //var propertyInfos = typeof (Expense).GetProperties();
            //foreach (var objInstance in expenseList)
            //{
            //    var dataRow = dtsProduct.Tables["DtbExpenses"].NewRow();
            //    foreach (var propertyInfo in propertyInfos)
            //        dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
            //    dtsProduct.Tables["DtbExpenses"].Rows.Add(dataRow);
            //}

            //var csrExpense = new CsrExpense();
            //csrExpense.SetDataSource(dtsProduct);
            //crvReport.ReportSource = csrExpense;
        }

        private void CtrlReport_Load(object sender, EventArgs e)
        {
            if (_commonService == null)
                _commonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();
            if (_saleOrderService == null)
                _saleOrderService = ServiceFactory.GenerateServiceInstance().GenerateSaleOrderService();
            if (_depositService == null)
                _depositService = ServiceFactory.GenerateServiceInstance().GenerateDepositService();
            if (_productService == null)
                _productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();
            if (_expenseService == null)
                _expenseService = ServiceFactory.GenerateServiceInstance().GenerateExpenseService();
            if (_reportService == null)
                _reportService = new ReportService();

            try
            {
                ThreadStart updateControlContent = UpdateControlContent;
                var thread = new Thread(updateControlContent) { IsBackground = true };
                thread.Start();

                ThreadStart threadStart = RemoveTemporaryFiles;
                thread = new Thread(threadStart) { IsBackground = true };
                thread.Start();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void UpdateControlContent()
        {
            SafeCrossCallBackDelegate safeCrossCallBackDelegate = null;

            if (cmbMark.InvokeRequired)
                safeCrossCallBackDelegate = UpdateControlContent;

            if (cmbMark.InvokeRequired)
                Invoke(safeCrossCallBackDelegate);
            else
            {
                var searchCriteria =
                    new List<string>
                        {
                            "ParameterTypeID IN (" + Resources.AppParamMark + ")"
                        };
                var objectList = _commonService.GetAppParameters(searchCriteria);
                _commonService.PopAppParamExtendedCombobox(
                    ref cmbMark,
                    objectList,
                    Int32.Parse(Resources.AppParamMark, AppContext.CultureInfo),
                    false);

                _commonService.PopAppParamExtendedCombobox(
                    ref cmbMarkSale,
                    objectList,
                    Int32.Parse(Resources.AppParamMark, AppContext.CultureInfo),
                    false);
            }
        }

        private static void RemoveTemporaryFiles()
        {
            CommonService.DeleteFile(
                System.Windows.Forms.Application.StartupPath,
                Resources.ConstStockStatementExcelFile,
                "*.xls*",
                true);

            CommonService.DeleteFile(
                System.Windows.Forms.Application.StartupPath,
                Resources.ConstSaleStatementExcelFile,
                "*.xls*",
                true);

            CommonService.DeleteFile(
                System.Windows.Forms.Application.StartupPath,
                Resources.ConstExpenseStatementExcelFile,
                "*.xls*",
                true);

            CommonService.DeleteFile(
                System.Windows.Forms.Application.StartupPath,
                Resources.ConstIncomeStatementExcelFile,
                "*.xls*",
                true);
        }

        //private void RefreshReportDeposit(bool allDeposit)
        //{
        //    if (!UserService.AllowToPerform(Resources.PermissionViewDepositReport))
        //    {
        //        const string briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
        //        var detailMsg = Resources.MsgUserPermissionDeny;
        //        using (var frmMessageBox = new FrmExtendedMessageBox())
        //        {
        //            frmMessageBox.BriefMsgStr = briefMsg;
        //            frmMessageBox.DetailMsgStr = detailMsg;
        //            frmMessageBox.IsCanceledOnly = true;
        //            frmMessageBox.ShowDialog(this);
        //            return;
        //        }
        //    }

        //    var searchCriteria = 
        //        !allDeposit ? 
        //        new List<string>
        //        {
        //            "(DepositDate BETWEEN CONVERT(DATETIME, '" +
        //            dtpStartDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) + 
        //            "', 103) AND CONVERT(DATETIME, '" +
        //            dtpStopDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
        //            " 23:59', 103)) ",
        //            "(AmountPaidInt < AmountSoldInt) ",
        //            "DepositNumber NOT IN (SELECT ReferenceNum FROM TDeposits WHERE ReferenceNum IS NOT NULL) "
        //        } : 
        //        new List<string>
        //        {
        //            "(DepositDate BETWEEN CONVERT(DATETIME, '" +
        //            dtpStartDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
        //            "', 103) AND CONVERT(DATETIME, '" +
        //            dtpStopDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
        //            " 23:59', 103)) "
        //        };
        //    var assessmentList = _depositService.GetDepositHistories(searchCriteria, false);

        //    DataSet dtsModel = new DtsModels();
        //    var propertyInfos = typeof(DepositReport).GetProperties();
        //    foreach (var objInstance in assessmentList)
        //    {
        //        var dataRow = dtsModel.Tables[3].NewRow();
        //        foreach (var propertyInfo in propertyInfos)
        //            dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
        //        dtsModel.Tables[3].Rows.Add(dataRow);
        //    }

        //    var rptDeposit = new CsrDeposit();
        //    rptDeposit.SetDataSource(dtsModel);
        //    crvReport.ReportSource = rptDeposit;           
        //}

        private void ChbShowBenefitEnter(object sender, EventArgs e)
        {
            chbShowBenefit.CheckedChanged += ChbShowBenefitCheckedChanged;
        }

        private void ChbShowBenefitLeave(object sender, EventArgs e)
        {
            chbShowBenefit.CheckedChanged -= ChbShowBenefitCheckedChanged;
        }

        //private void ChbAllDepositEnter(object sender, EventArgs e)
        //{
        //    chbAllDeposit.CheckedChanged += ChbAllDepositCheckedChanged;
        //}

        //private void ChbAllDepositLeave(object sender, EventArgs e)
        //{
        //    chbAllDeposit.CheckedChanged -= ChbAllDepositCheckedChanged;
        //}

        private void ChbShowBenefitCheckedChanged(object sender, EventArgs e)
        {
            rdbSale.Checked = true;
            //chbAllDeposit.Checked = false;
            if (chbShowBenefit.Checked)
                chbShowQuantity.Checked = false;
        }

        //private void ChbAllDepositCheckedChanged(object sender, EventArgs e)
        //{
        //    rdbDeposit.Checked = true;
        //    chbShowBenefit.Checked = false;
        //    chbShowQuantity.Checked = false;
        //}

        private void ChbShowQuantityEnter(object sender, EventArgs e)
        {
            chbShowQuantity.CheckedChanged += ChbShowQuantityCheckedChanged;
        }

        private void ChbShowQuantityLeave(object sender, EventArgs e)
        {
            chbShowQuantity.CheckedChanged -= ChbShowQuantityCheckedChanged;
        }

        private void ChbShowQuantityCheckedChanged(object sender, EventArgs e)
        {
            rdbSale.Checked = true;
            //chbAllDeposit.Checked = false;
            if (chbShowQuantity.Checked)
                chbShowBenefit.Checked = false;
        }

        private void RefreshIncomeStatementReport()
        {
            try
            {
                wbsReport.Navigate("about:blank");

                if (!UserService.AllowToPerform(Resources.PermissionViewIncomeStatementReport))
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

                int counter;
                var startDate = dtpStartDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo);
                var endDate = dtpStopDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo);

                //Sales
                var saleOrderService = ServiceFactory.GenerateServiceInstance().GenerateSaleOrderService();
                var searchCriteria =
                    new List<string>
                        {
                            "SaleOrderDate BETWEEN CONVERT(DATETIME, '" +
                            startDate +
                            "', 103) AND CONVERT(DATETIME, '" +
                            endDate + " 23:59', 103)"
                        };

                var saleOrderList = saleOrderService.GetSaleHistoriesOrderByProductCategory(searchCriteria);

                var saleType = string.Empty;
                var saleAmount = 0f;
                var purchaseAmount = 0f;
                var groupSaleList = new List<List<object>>();
                foreach (var saleOrderReport in saleOrderList.Cast<SaleOrderReport>().Where(saleOrderReport => saleOrderReport != null))
                {
                    if (!saleOrderReport.CategoryStr.Equals(saleType))
                    {
                        List<object> groupSale;
                        if (groupSaleList.Count != 0)
                        {
                            counter = groupSaleList.Count;
                            groupSale = groupSaleList[counter - 1];

                            groupSale.Add(saleAmount);
                            groupSale.Add(purchaseAmount);

                        }

                        saleType = saleOrderReport.CategoryStr;

                        groupSale = new List<object> { saleType };
                        groupSaleList.Add(groupSale);

                        saleAmount = 0f;
                        purchaseAmount = 0f;
                    }

                    saleAmount += saleOrderReport.AmountSoldInt;
                    //saleAmount += (saleOrderReport.AmountSoldInt * saleOrderReport.ExchangeRate);
                    saleAmount += (saleOrderReport.DepositAmount);
                    //purchaseAmount += saleOrderReport.PurchaseUnitPrice;
                    purchaseAmount += (saleOrderReport.QtySold * saleOrderReport.UnitPriceIn);
                }

                if (groupSaleList.Count != 0)
                {
                    counter = groupSaleList.Count;
                    var groupExpense = groupSaleList[counter - 1];

                    groupExpense.Add(saleAmount);
                    groupExpense.Add(purchaseAmount);
                }

                //Expense
                var expenseService = ServiceFactory.GenerateServiceInstance().GenerateExpenseService();
                searchCriteria =
                    new List<string>
                    {
                        "ExpenseDate BETWEEN CONVERT(DATETIME, '" +
                        startDate +
                        "', 103) AND CONVERT(DATETIME, '" +
                        endDate +
                        "', 103)"
                    };
                var expenseList = expenseService.GetExpensesOrderByType(searchCriteria);

                var expenseType = string.Empty;
                var expenseAmount = 0f;
                var groupExpenseList = new List<List<object>>();
                foreach (var expense in expenseList.Cast<Expense>().Where(expense => expense != null))
                {
                    if (!expense.ExpenseTypeStr.Equals(expenseType))
                    {
                        List<object> groupExpense;
                        if (groupExpenseList.Count != 0)
                        {
                            counter = groupExpenseList.Count;
                            groupExpense = groupExpenseList[counter - 1];

                            groupExpense.Add(expenseAmount);
                        }

                        expenseType = expense.ExpenseTypeStr;

                        groupExpense = new List<object> { expenseType };
                        groupExpenseList.Add(groupExpense);

                        expenseAmount = 0f;
                    }

                    expenseAmount += expense.ExpenseAmountInt;
                    expenseAmount += (expense.ExpenseAmountRiel / expense.ExchangeRate);
                }

                if (groupExpenseList.Count != 0)
                {
                    counter = groupExpenseList.Count;
                    var groupExpense = groupExpenseList[counter - 1];

                    groupExpense.Add(expenseAmount);
                }

                //Write to Excel file
                var templateIncomeStatementFileName =
                    System.Windows.Forms.Application.StartupPath + @"\" +
                    Resources.ConstIncomeStatementExcelFile;

                var templateIncomeStatementFileInfo = new FileInfo(templateIncomeStatementFileName);
                if (!templateIncomeStatementFileInfo.Exists)
                {
                    const string briefMsg = "អំពីប្រព័ន្ឋ";
                    var detailMsg = Resources.MsgMissingIncomeStatement;
                    using (var frmMessageBox = new FrmExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }

                var temporaryIncomeStatementFileName =
                    System.Windows.Forms.Application.StartupPath + @"\" +
                    DateTime.Now.Ticks +
                    Resources.ConstIncomeStatementExcelFile;

                var invoicePeriode =
                    startDate + " ដល់ " + endDate;

                //Open workbook                
                var excelApplication = new ExcelApplication();
                var workBook = excelApplication.Workbooks.Open(
                    templateIncomeStatementFileName,
                    0,
                    false,
                    5,
                    false,
                    string.Empty,
                    false,
                    XlPlatform.xlWindows,
                    string.Empty,
                    true,
                    false,
                    0,
                    true,
                    false,
                    false);
                
                //Invoice content
                var workSheet = (Worksheet)workBook.Worksheets[Resources.ConstSheetIncomeStatement];

                //Shop name
                var rowIndex = 1;
                var excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = "របាយការណ៏ហិរញ្ញវុត្ថុរបស់ក្រុមហ៊ុន  " + AppContext.ShopNameLocal;
                
                rowIndex = 2;
                excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = "Financial Statement of " + AppContext.ShopName;

                //Period
                rowIndex = 3;
                excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = "ពី " + invoicePeriode;

                //Income
                rowIndex = 5;
                counter = 0;
                var totalPurchaseAmount = 0f;
                foreach (var saleReport in groupSaleList.Where(saleReport => saleReport != null))
                {
                    excelRange = workSheet.get_Range("B" + rowIndex, "B" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = saleReport[0].ToString();

                    excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = "…………………………………….";

                    excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = "USD";

                    excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = float.Parse(saleReport[1].ToString());
                    totalPurchaseAmount += float.Parse(saleReport[2].ToString());

                    rowIndex += 1;
                    excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                    if (counter == (groupSaleList.Count - 1))
                        continue;

                    excelRange.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, 1);
                    counter += 1;
                }

                //Purchase amount
                rowIndex += 3;
                excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = totalPurchaseAmount;

                //Expense
                rowIndex += 4;
                counter = 0;
                foreach (var expenseReport in groupExpenseList.Where(expenseReport => expenseReport != null))
                {
                    excelRange = workSheet.get_Range("B" + rowIndex, "B" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = expenseReport[0].ToString();

                    excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = "…………………………………….";

                    excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = "USD";

                    excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = expenseReport[1].ToString();

                    rowIndex += 1;
                    excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                    if (counter == (groupExpenseList.Count - 1))
                        continue;

                    excelRange.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, 1);
                    counter += 1;
                }

                excelRange = workSheet.get_Range("A1", "A1");
                excelRange.Select();
                
                workBook.Close(
                    true,
                    temporaryIncomeStatementFileName,
                    System.Reflection.Missing.Value);

                excelApplication.Quit();

                Marshal.ReleaseComObject(excelApplication);
                GC.Collect(0, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
                
                //Open report
                wbsReport.BringToFront();
                wbsReport.Navigate(temporaryIncomeStatementFileName);
            } 
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }            
        }

        private void OpenReport(string reportFileName)
        {
            try
            {
                if (string.IsNullOrEmpty(reportFileName))
                {
                    var briefMsg = Resources.MsgExtendedCaptionFind;
                    var detailMsg = Resources.MsgSearchResultEmpty;
                    using (var frmMessageBox = new FrmExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }

                //Open report
                wbsReport.Navigate("about:blank");
                wbsReport.BringToFront();
                wbsReport.Navigate(reportFileName);
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }
    }
}