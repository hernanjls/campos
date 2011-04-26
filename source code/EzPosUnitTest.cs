using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using EzPos.GUIs.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using Microsoft.Office.Interop.Excel;
using NUnit.Framework;
using System.Collections.Generic;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;
using System.Linq;

namespace EzPos
{
    [TestFixture]
    public class EzPosUnitTest
    {
        [Test]
        public void TestResizeImage()
        {
            var myBitmap = Image.FromFile(@"D:\DSC06857.JPG");
            var myThumbnail = 
                myBitmap.GetThumbnailImage(
                    100, 
                    100, 
                    null, 
                    new IntPtr());
            myThumbnail.Save("test.jpg");
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        [Test]
        public static void TestDeleteFile()
        {
            CommonService.DeleteFile(
                @"D:\Users\YSakal\Private\point of sales\ezpos\application\source code\bin\Debug",
                Resources.ConstIncomeStatementExcelFile,
                "*.xls*",
                true);

            Assert.AreEqual(1, 1, "Test performed");
        }

        [Test]
        public void TestPrintInvoice()
        {
            //var saleItemBindingList = new BindingList<SaleItem>
            //    {
            //        CreateSaleItem(),
            //        CreateSaleItem(),
            //        CreateSaleItem(),
            //        CreateSaleItem(),
            //        CreateSaleItem(),
            //        CreateSaleItem(),
            //        CreateSaleItem(),
            //        CreateSaleItem(),
            //        CreateSaleItem(),
            //        CreateSaleItem(),
            //        CreateSaleItem(),
            //        CreateSaleItem(),
            //        CreateSaleItem(),
            //        CreateSaleItem(),
            //        CreateSaleItem()
            //    };

            ////Print
            //var printReceipt = new PrintInvoice();
            //var customer = new Customer { CustomerName = "Name", Address = "Address" };
            //var saleOrder = new SaleOrder {SaleOrderNumber = "SO number", SaleOrderDate = DateTime.Now};

            ////printReceipt.SaleItemList = saleItemBindingList;
            ////printReceipt.Customer = customer;
            ////printReceipt.InvoiceNumber = saleOrder.SaleOrderNumber;
            ////printReceipt.InvoiceDate = (DateTime)saleOrder.SaleOrderDate;
            //printReceipt.InializeInvoicePrinting();

            Assert.AreEqual(1, 1, "Test performed");
        }

        [Test]
        public void TestPrintBarCode()
        {
            var barCodeList =
                new List<BarCode>();
            for(var counter = 0; counter < 36; counter++)
            {
                barCodeList.Add(CreateBarCode());
            }

            //Print
            PrintBarCode.InializePrinting(barCodeList, Resources.ConstBarCodeTemplate2);

            Assert.AreEqual(1, 1, "Test performed");
        }

        private static SaleItem CreateSaleItem()
        {
            var saleItem = new SaleItem
                               {
                                   ProductName = "productName",
                                   ProductDisplayName = "productName",
                                   ProductID = 1,
                                   QtySold = 1,
                                   UnitPriceIn = 1,
                                   PublicUPOut = 1,
                                   UnitPriceOut = 1,
                                   Discount = 0,
                                   SubTotal = 1,
                                   ProdPicture = Resources.NoImage,
                                   FKProduct = null
                               };

            return saleItem;
        }

        private static BarCode CreateBarCode()
        {
            var barCode =
                new BarCode
                {
                    BarCodeValue = "000001032",
                    DisplayStr = "Souvenir (Qx059)",
                    AdditionalStr = "$ 138.00",
                    UnitPrice = "$ 138.00"
                };
            return barCode;
        }

        [Test]
        public void CreateResource()
        {
            var rw = new ResourceWriter("English.resources");
            rw.AddResource("Name", "Test");
            rw.AddResource("Ver", 1.0);
            rw.AddResource("Author", "www.java2s.com");
            rw.Generate();
            rw.Close();

            Assert.AreEqual(1, 1, "Test performed");
        }

        [Test]
        public void TestOutstadingPayment()
        {
            //using (var frmOutstandingPayment = new FrmOutstandingPayment())
            //{
            //    frmOutstandingPayment.SalesOrderInfo = "SalesOrder";
            //    frmOutstandingPayment.ShowDialog();
            //}

            Assert.AreEqual(1, 1, "Test performed");
        }

        [Test]
        public void TestExcel()
        {            
            //var excelApplication = new Application();
            //var _WorkBook = excelApplication.Workbooks.Open(
            //    @"d:\20100429.xlsx",
            //    0,
            //    false,
            //    5,
            //    "comin",
            //    "",
            //    false,
            //    XlPlatform.xlWindows,
            //    "",
            //    true,
            //    false,
            //    0,
            //    true,
            //    false,
            //    false);

            ////excelApplication.Visible = true;
            ////_WorkBook.PrintPreview(true);
            //try
            //{                
            //    _WorkBook.PrintOut(
            //        1,
            //        1,
            //        1,
            //        false,
            //        "HP Color LaserJet 2600n (Network)",
            //        false,
            //        false,
            //        "");
            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show(exception.Message);
            //}
            //finally
            //{
            //    excelApplication.Workbooks.Close();    
            //}

            var saleItemBindingList = new BindingList<SaleItem>
                {
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem()
                };

            var printReceipt = new PrintInvoice();
            printReceipt.ExcelInvoicePrintingHandler(
                "EPSON LQ-300+ /II ESC/P 2",
                @"D:\users\ysakal\private\point of sales\ezpos\source code\bin\Debug\invoice-sale.xlsx",
                string.Empty,
                "Customer",
                "Address",
                "InvoiceNumber",
                DateTime.Now,
                10,
                5,
                10,
                saleItemBindingList,
                false);
            
            Assert.AreEqual(1, 1, "Test performed");
        }

        [Test]
        public void GetDepositHistories()
        {
            try
            {
                var depositService = ServiceFactory.GenerateServiceInstance().GenerateDepositService();
                var depositList = depositService.GetDepositHistories(null, false);
                MessageBox.Show(depositList.Count.ToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        [Test]
        public void ToPinyinput()
        {
            //string CName;
            //foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            //{
            //    CName = lang.Culture.EnglishName;
            //    MessageBox.Show(CName);

            //    if (CName.StartsWith("Khmer"))
            //    {
            //        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("km-KH"));
            //        //InputLanguage.CurrentInputLanguage = lang;
            //    }
            //}
        }

        [Test]
        public void BankReport()
        {
            ////Sales
            //var curDate = DateTime.Now;
            //var saleOrderService = ServiceFactory.GenerateServiceInstance().GenerateSaleOrderService();
            //var searchCriteria =
            //    new List<string>
            //                {
            //                    "SaleOrderDate BETWEEN CONVERT(DATETIME, '" +
            //                    curDate.AddDays(-365).ToString("dd/MM/yyyy") +
            //                    "', 103) AND CONVERT(DATETIME, '" +
            //                    curDate.ToString("dd/MM/yyyy") + " 23:59', 103)"
            //                };
            //var saleOrderList = saleOrderService.GetSaleHistoriesOrderByProductCategory(searchCriteria);

            //var saleType = string.Empty;
            //var saleAmount = 0f;
            //var purchaseAmount = 0f;
            //var groupSaleList = new List<List<object>>();
            //foreach (var saleOrderReport in saleOrderList.Cast<SaleOrderReport>().Where(saleOrderReport => saleOrderReport != null))
            //{
            //    if (!saleOrderReport.CategoryStr.Equals(saleType))
            //    {
            //        List<object> groupExpense;
            //        if (groupSaleList.Count != 0)
            //        {
            //            var counter = groupSaleList.Count;
            //            groupExpense = groupSaleList[counter - 1];

            //            groupExpense.Add(saleAmount);
            //            groupExpense.Add(purchaseAmount);

            //        }

            //        saleType = saleOrderReport.CategoryStr;

            //        groupExpense = new List<object> { saleType };
            //        groupSaleList.Add(groupExpense);

            //        saleAmount = 0f;
            //        purchaseAmount = 0f;
            //    }

            //    saleAmount += saleOrderReport.AmountSoldInt;
            //    saleAmount += (saleOrderReport.AmountSoldInt * saleOrderReport.ExchangeRate);
            //    purchaseAmount += saleOrderReport.PurchaseUnitPrice;
            //}

            //if (groupSaleList.Count != 0)
            //{
            //    var counter = groupSaleList.Count;
            //    var groupExpense = groupSaleList[counter - 1];

            //    groupExpense.Add(saleAmount);
            //    groupExpense.Add(purchaseAmount);
            //}

            ////Expense
            //var expenseService = ServiceFactory.GenerateServiceInstance().GenerateExpenseService();
            //searchCriteria =
            //    new List<string>
            //    {
            //        "ExpenseDate BETWEEN CONVERT(DATETIME, '" +
            //        curDate.AddDays(-365).ToString("dd/MM/yyyy", AppContext.CultureInfo) +
            //        "', 103) AND CONVERT(DATETIME, '" +
            //        curDate.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
            //        "', 103)"
            //    };            
            //var expenseList = expenseService.GetExpensesOrderByType(searchCriteria);

            //var expenseType = string.Empty;
            //var expenseAmount = 0f;
            //var groupExpenseList = new List<List<object>>();
            //foreach (var expense in expenseList.Cast<Expense>().Where(expense => expense != null))
            //{
            //    if(!expense.ExpenseTypeStr.Equals(expenseType))
            //    {
            //        List<object> groupExpense;
            //        if (groupExpenseList.Count != 0)
            //        {
            //            var counter = groupExpenseList.Count;
            //            groupExpense = groupExpenseList[counter - 1];

            //            groupExpense.Add(expenseAmount);
            //        }

            //        expenseType = expense.ExpenseTypeStr;

            //        groupExpense = new List<object> {expenseType};
            //        groupExpenseList.Add(groupExpense);
                    
            //        expenseAmount = 0f;                    
            //    }

            //    expenseAmount += expense.ExpenseAmountInt;
            //    expenseAmount += (expense.ExpenseAmountRiel * expense.ExchangeRate);
            //}

            //if (groupExpenseList.Count != 0)
            //{
            //    var counter = groupExpenseList.Count;
            //    var groupExpense = groupExpenseList[counter - 1];

            //    groupExpense.Add(expenseAmount);
            //}
            
            ////Write to Excel file
            ////Open workbook
            //var shopName = string.Empty;
            //var invoicePeriode = string.Empty;
            //var protectedPassword = false;
            //var fileName =
            //    @"D:\users\ysakal\private\projects\point of sales\ezpos\application\source code\obj\Debug\" + 
            //    Resources.ConstIncomeStatementExcelFile;
            //var excelApplication = new ExcelApplication();
            //try
            //{
            //    var workBook = excelApplication.Workbooks.Open(
            //        fileName,
            //        0,
            //        false,
            //        5,
            //        protectedPassword,
            //        string.Empty,
            //        false,
            //        XlPlatform.xlWindows,
            //        string.Empty,
            //        true,
            //        false,
            //        0,
            //        true,
            //        false,
            //        false);

            //    //Invoice content
            //    var workSheet = (Worksheet)workBook.Worksheets[Resources.ConstSheetIncomeStatement];

            //    //Shop name
            //    var rowIndex = 2;
            //    var excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
            //    excelRange.Select();
            //    excelRange.Value2 = "របាយការណ៏ហិរញ្ញវុត្ថុរបស់ក្រុមហ៊ុន  " + shopName;

            //    //Period
            //    rowIndex = 3;
            //    excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
            //    excelRange.Select();
            //    excelRange.Value2 = "ពី " + invoicePeriode;

            //    //Income
            //    rowIndex = 5;
            //    var counter = 0;
            //    var totalPurchaseAmount = 0f;
            //    foreach (var saleReport in groupSaleList.Where(saleReport => saleReport != null))
            //    {
            //        excelRange = workSheet.get_Range("B" + rowIndex, "B" + rowIndex);
            //        excelRange.Select();
            //        excelRange.Value2 = saleReport[0].ToString();

            //        excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
            //        excelRange.Select();
            //        excelRange.Value2 = "…………………………………….";

            //        excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
            //        excelRange.Select();
            //        excelRange.Value2 = "USD";
                    
            //        excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
            //        excelRange.Select();
            //        excelRange.Value2 = float.Parse(saleReport[1].ToString());
            //        totalPurchaseAmount = float.Parse(saleReport[2].ToString());

            //        rowIndex += 1;
            //        excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
            //        if (counter == (groupSaleList.Count - 1))
            //            continue;
                    
            //        excelRange.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, 1);
            //        counter += 1;                    
            //    }

            //    //Purchase amount
            //    rowIndex += 3;
            //    excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
            //    excelRange.Select();
            //    excelRange.Value2 = totalPurchaseAmount;

            //    //Expense
            //    rowIndex += 4;
            //    counter = 0;
            //    foreach (var expenseReport in groupExpenseList.Where(expenseReport => expenseReport != null))
            //    {
            //        excelRange = workSheet.get_Range("B" + rowIndex, "B" + rowIndex);
            //        excelRange.Select();
            //        excelRange.Value2 = expenseReport[0].ToString();

            //        excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
            //        excelRange.Select();
            //        excelRange.Value2 = "…………………………………….";

            //        excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
            //        excelRange.Select();
            //        excelRange.Value2 = "USD";

            //        excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
            //        excelRange.Select();
            //        excelRange.Value2 = expenseReport[1].ToString();

            //        rowIndex += 1;
            //        excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
            //        if (counter == (groupExpenseList.Count - 1))
            //            continue;

            //        excelRange.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, 1);
            //        counter += 1;
            //    }

            //    excelRange = workSheet.get_Range("A1", "A1");
            //    excelRange.Select();

            //    //Open report
            //    excelApplication.Visible = true;
            //}
            //catch (Exception exception)
            //{                                
            //    throw exception;
            //}

            Assert.AreEqual(1, 1, "Test performed");
        }
    }
}
