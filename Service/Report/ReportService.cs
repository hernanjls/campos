using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using EzPos.Model;
using EzPos.Model.Expense;
using EzPos.Properties;
using EzPos.Service.Product;
using EzPos.Service.SaleOrder;
using EzPos.Utility;
using Microsoft.Office.Interop.Excel;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;

namespace EzPos.Service.Report
{
    public class ReportService
    {
        public ProductService ProductService { get; set; }
        public SaleOrderService SaleOrderService { get; set; }
        public ExpenseService ExpenseService { get; set; }

        //Stock
        public string StockStatementReport(int markId, string markStr)
        {
            if (ProductService == null)
                return string.Empty;

            //Stock
            var searchCriteria = new List<string> { "QtyInStock > 0" };
            var productList = ProductService.GetObjects(searchCriteria);
            if ((productList == null) || (productList.Count == 0))
                return string.Empty;

            //Write to Excel file
            var templateReportFile =
                System.Windows.Forms.Application.StartupPath + @"\" +
                Resources.ConstStockStatementExcelFile;

            var reportFileInfo = new FileInfo(templateReportFile);
            if (!reportFileInfo.Exists)
                return string.Empty;

            var dateTimeString =
                StringHelper.Right("00" + DateTime.Now.Month, 2) +
                "." +
                StringHelper.Right("0000" + DateTime.Now.Year, 2);

            var reportSubTitle =
                markStr + " សំរាប់ខែ " + dateTimeString;

            //Open workbook                
            var excelApplication = new ExcelApplication();
            var workBook = excelApplication.Workbooks.Open(
                templateReportFile,
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
            var workSheet = (Worksheet)workBook.Worksheets[Resources.ConstSheetStockStatement];

            //Shop name
            var rowIndex = 1;
            var excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = "របាយ​ការណ៏​ស្តុករបស់​ " + AppContext.ShopNameLocal;

            //Period
            rowIndex = 2;
            excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = "បញ្ជីស្តុកគ្រឿងបន្លាស់  " + reportSubTitle;

            //Stock
            rowIndex = 5;

            //var totalUnitPrice = 0f;
            //var grandTotalUnitPrice = 0f;
            var counter = 1;
            var startRowIndex = rowIndex;

            var sortedProductList =
                (from product
                    in productList.Cast<Model.Product>()
                orderby product.MarkStr
                select product).ToList();

            foreach (var product in sortedProductList.Where(product => product != null))
            {
                //Order number
                excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = counter;

                //Product code
                var productCode = !string.IsNullOrEmpty(product.ForeignCode) ? product.ForeignCode : product.ProductCode;
                excelRange = workSheet.get_Range("B" + rowIndex, "B" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = productCode;

                //Product description
                excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = product.Description;

                //Qty in stock
                //var qtyInStock = product.QtyInStock;
                excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = product.QtyInStock;

                //Qty in stock (skip)

                //Unit price
                //var unitPrice = product.UnitPriceIn;
                excelRange = workSheet.get_Range("F" + rowIndex, "F" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = product.UnitPriceIn;

                //Total unit price
                //var totalUnitPrice = qtyInStock * unitPrice;
                //grandTotalUnitPrice += totalUnitPrice;
                excelRange = workSheet.get_Range("G" + rowIndex, "G" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = "=D" + rowIndex + "*F" + rowIndex;

                excelRange = workSheet.get_Range("A" + rowIndex, "G" + rowIndex);
                excelRange.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                excelRange.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                excelRange.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                excelRange.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                counter += 1;
                rowIndex += 1;
                excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                excelRange.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, 1);
            }

            //rowIndex += 2;
            excelRange = workSheet.get_Range("F" + rowIndex, "F" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = "សរុប";
            excelRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
            excelRange = workSheet.get_Range("G" + rowIndex, "G" + rowIndex);
            excelRange.Select();
            excelRange.Formula = "=SUM(G" + startRowIndex + ":G" + (rowIndex - 1) + ")";

            excelRange = workSheet.get_Range("A1", "A1");
            excelRange.Select();

            var reportFileName =
                System.Windows.Forms.Application.StartupPath + @"\" +
                DateTime.Now.Ticks + " - " +
                Resources.ConstStockStatementExcelFile;

            workBook.Close(
                true,
                reportFileName,
                System.Reflection.Missing.Value);

            excelApplication.Quit();

            Marshal.ReleaseComObject(excelApplication);
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            return reportFileName;
        }
        
        //Sale
        public string SaleStatementReport(string startDate, string endDate, int markId, bool showProfit)
        {
            if (string.IsNullOrEmpty(startDate))
                return string.Empty;

            if (string.IsNullOrEmpty(endDate))
                return string.Empty;

            if (SaleOrderService == null)
                return string.Empty;

            //Sales
            var searchCriteria =
                new List<string>
                    {
                        "SaleOrderId IN (SELECT SaleOrderId FROM TSaleOrders WHERE SaleOrderDate BETWEEN CONVERT(DATETIME, '" + startDate + "', 103) AND CONVERT(DATETIME, '" +
                        endDate + " 23:59', 103))"
                    };
            var saleOrderList = SaleOrderService.GetSaleOrders(searchCriteria);
            var saleOrderHistoryList = SaleOrderService.GetSaleHistories(searchCriteria);

            if ((saleOrderList == null) || (saleOrderList.Count == 0))
                return string.Empty;

            //Write to Excel file
            var templateReportFile =
                System.Windows.Forms.Application.StartupPath + @"\" +
                Resources.ConstSaleStatementExcelFile;

            var reportFileInfo = new FileInfo(templateReportFile);
            if (!reportFileInfo.Exists)
                return string.Empty;

            var invoicePeriode =
                startDate + " ដល់ " + endDate;

            //Open workbook                
            var excelApplication = new ExcelApplication();
            var workBook = excelApplication.Workbooks.Open(
                templateReportFile,
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
            var workSheet = (Worksheet)workBook.Worksheets[Resources.ConstSheetSaleStatement];

            //Shop name
            var rowIndex = 1;
            var excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = "របាយ​ការណ៏​លក់​របស់ក្រុមហ៊ុន​ " + AppContext.ShopNameLocal;

            //Period
            rowIndex = 2;
            excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = "សំរាប់រយៈពេល " + invoicePeriode;

            //Sale            
            rowIndex = 5;

            var grandTotalSoldForeign = 0f;
            var grandTotalSoldLocal = 0f;
            var grandTotalPaidForeign = 0f;
            var grandTotalPaidLocal = 0f;
            var grandTotalReturnForeign = 0f;
            var grandTotalReturnLocal = 0f;
            foreach (Model.SaleOrder saleOrder in saleOrderList)
            {
                if (saleOrder == null)
                    continue;

                var localSaleOrder = saleOrder;

                var exchangeRate = saleOrder.ExchangeRate;

                //////var totalPaidForeign = saleOrder.AmountPaidForeign;
                //////var totalPaidLocal = saleOrder.AmountPaidLocal;

                //////var totalReturnForeign = saleOrder.AmountReturnForeign;
                //////var totalReturnLocal = saleOrder.AmountReturnLocal;

                var discountPercentage = saleOrder.Discount;

                var filteredSaleOrderHistoryList =
                    (from saleOrderReport
                         in saleOrderHistoryList.Cast<SaleOrderReport>()
                     where saleOrderReport.SaleOrderId == localSaleOrder.SaleOrderId
                     select saleOrderReport).ToList();

                //Invoice number
                var invoiceNumber = saleOrder.SaleOrderNumber;
                invoiceNumber +=
                    string.IsNullOrEmpty(saleOrder.ReferenceNum) ?
                    string.Empty : "(" + saleOrder.ReferenceNum + ")";
                workSheet.get_Range("A" + rowIndex + ":C" + rowIndex, Type.Missing).Merge(Type.Missing);
                excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = "លេខ​វិក្ក័យ​ប័ត្រ: " + invoiceNumber;

                excelRange = workSheet.get_Range("A" + rowIndex, "G" + rowIndex);
                excelRange.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDot;

                //Customer
                //workSheet.get_Range("C" + rowIndex + ":E" + rowIndex, Type.Missing).Merge(Type.Missing);
                //excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
                //excelRange.Select();
                //excelRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
                //excelRange.Value2 = "កាល​បរិច្ឆេទ​: " + ((DateTime)saleOrder.SaleOrderDate).ToString("dd/MM/yyyy", AppContext.CultureInfo);

                //excelRange = workSheet.get_Range("A" + rowIndex, "E" + rowIndex);
                //excelRange.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //excelRange.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                //excelRange.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //excelRange.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                rowIndex += 1;
                excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                excelRange.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, 1);

                var orderNumber = 0;
                foreach (var saleOrderHistory in filteredSaleOrderHistoryList)
                {
                    if (saleOrderHistory == null)
                        continue;

                    orderNumber += 1;
                    excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = orderNumber;

                    excelRange = workSheet.get_Range("B" + rowIndex, "B" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = saleOrderHistory.ProductCode;

                    excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = saleOrderHistory.ProductName;

                    var quantity = saleOrderHistory.QtySold;
                    excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = quantity;

                    var unitPrice = saleOrderHistory.UnitPriceOut;
                    excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = unitPrice;

                    var subTotal = quantity * unitPrice;
                    excelRange = workSheet.get_Range("F" + rowIndex, "F" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = subTotal;

                    if(showProfit)
                    {
                        excelRange = workSheet.get_Range("G" + rowIndex, "G" + rowIndex);
                        excelRange.Select();
                        excelRange.Value2 = subTotal;  
                    }

                    excelRange = workSheet.get_Range("A" + rowIndex, "G" + rowIndex);
                    excelRange.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDot;

                    rowIndex += 1;
                    excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                    excelRange.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, 1);
                }

                //Total amount
                //Total Amount before discount
                //////var discountableTotalAmount =
                //////    (from saleItem
                //////     in saleItemList.Cast<SaleItem>()
                //////     where
                //////        (saleItem.SaleOrderID == localSaleOrder.SaleOrderId)
                //////        && (saleItem.FKProduct != null)
                //////        && ((from categoryId in AppContext.DiscountProductCategoryList select categoryId).Contains(saleItem.FkProduct.CategoryId))
                //////     select (saleItem.QtySold * saleItem.UnitPriceOut)).Sum();

                //////var nonDiscountableTotalAmount =
                //////    (from saleItem
                //////    in saleItemList.Cast<SaleItem>()
                //////     where
                //////         (saleItem.SaleOrderID == localSaleOrder.SaleOrderId)
                //////         && (saleItem.FKProduct != null)
                //////         && !((from categoryId in AppContext.DiscountProductCategoryList select categoryId).Contains(saleItem.FkProduct.CategoryId))
                //////     select (saleItem.QtySold * saleItem.UnitPriceOut)).Sum();

                //////var totalSoldLocal = discountableTotalAmount + nonDiscountableTotalAmount;
                //////var totalSoldForeign = totalSoldLocal / exchangeRate;

                //Discount
                //////var discountAmountLocal = (discountableTotalAmount * discountPercentage) / 100;
                //////var discountAmountForeign = discountAmountLocal / exchangeRate;

                ////////Total amount after discount
                //////var totalAmountLocal = totalSoldLocal - discountAmountLocal;
                //////var totalAmountForeign = totalSoldForeign - discountAmountForeign;

                //SubTotal
                excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = "សរុប";
                excelRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
                excelRange = workSheet.get_Range("F" + rowIndex, "F" + rowIndex);
                excelRange.Select();
                //////excelRange.Value2 = totalSoldLocal;
                excelRange = workSheet.get_Range("G" + rowIndex, "G" + rowIndex);
                excelRange.Select();
                //////excelRange.Value2 = totalSoldForeign;

                ////////Discount
                //////rowIndex += 1;
                //////excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
                //////excelRange.Select();
                //////excelRange.Value2 = "បញ្ចុះ​តំលៃ " + saleOrder.Discount + " %";
                //////excelRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
                //////excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
                //////excelRange.Select();

                ////////////excelRange.Value2 = discountAmountLocal;
                //////excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
                //////excelRange.Select();
                ////////////excelRange.Value2 = discountAmountForeign;

                ////////Grand Total
                //////rowIndex += 1;
                //////excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
                //////excelRange.Select();
                //////excelRange.Value2 = "ប្រាក់​សរុប";
                //////excelRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
                //////excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
                //////excelRange.Select();
                ////////////excelRange.Value2 = totalAmountLocal;
                //////excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
                //////excelRange.Select();
                ////////////excelRange.Value2 = totalAmountForeign;

                ////////Paid
                //////rowIndex += 1;
                //////excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
                //////excelRange.Select();
                //////excelRange.Value2 = "ប្រាក់​ទទួល";
                //////excelRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
                //////excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
                //////excelRange.Select();
                ////////////excelRange.Value2 = totalPaidLocal;
                //////excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
                //////excelRange.Select();
                ////////////excelRange.Value2 = totalPaidForeign;

                ////////Return
                //////rowIndex += 1;
                //////excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
                //////excelRange.Select();
                //////excelRange.Value2 = "ប្រាក់​អាប់";
                //////excelRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
                //////excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
                //////excelRange.Select();
                ////////////excelRange.Value2 = totalReturnLocal;
                //////excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
                //////excelRange.Select();
                ////////////excelRange.Value2 = totalReturnForeign;

                rowIndex += 1;

                ////////////grandTotalSoldLocal += totalAmountLocal;
                ////////////grandTotalSoldForeign += totalAmountForeign;

                ////////////grandTotalPaidLocal += totalPaidLocal;
                ////////////grandTotalPaidForeign += totalPaidForeign;

                ////////////grandTotalReturnLocal += totalReturnLocal;
                ////////////grandTotalReturnForeign += totalReturnForeign;
            }

            //rowIndex += 2;
            excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = "សរុប​ប្រាក់​លក់";
            excelRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
            excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = grandTotalSoldLocal;
            excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = grandTotalSoldForeign;
            excelRange = workSheet.get_Range("D" + rowIndex, "E" + rowIndex);
            excelRange.Font.Bold = true;
            excelRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(253, 233, 217));

            rowIndex += 1;
            excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = "សរុប​ប្រាក់ទទួល";
            excelRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
            excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = grandTotalPaidLocal;
            excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = grandTotalPaidForeign;
            excelRange = workSheet.get_Range("D" + rowIndex, "E" + rowIndex);
            excelRange.Font.Bold = true;
            excelRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(253, 233, 217));

            rowIndex += 1;
            excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = "សរុប​ប្រាក់អាប់";
            excelRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
            excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = grandTotalReturnLocal;
            excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = grandTotalReturnForeign;
            excelRange = workSheet.get_Range("D" + rowIndex, "E" + rowIndex);
            excelRange.Font.Bold = true;
            excelRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(253, 233, 217));

            excelRange = workSheet.get_Range("A1", "A1");
            excelRange.Select();

            var reportFileName =
                System.Windows.Forms.Application.StartupPath + @"\" +
                DateTime.Now.Ticks + " - " +
                Resources.ConstSaleStatementExcelFile;

            workBook.Close(
                true,
                reportFileName,
                System.Reflection.Missing.Value);

            excelApplication.Quit();

            Marshal.ReleaseComObject(excelApplication);
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            return reportFileName;
        }

        public string ExpenseStatementReport(string startDate, string endDate)
        {
            if (string.IsNullOrEmpty(startDate))
                return string.Empty;

            if (string.IsNullOrEmpty(endDate))
                return string.Empty;

            if (ExpenseService == null)
                return string.Empty;

            //Expenses
            var searchCriteria =
                new List<string>
                    {
                        "CONVERT(DATETIME, ExpenseDate, 103) BETWEEN CONVERT(DATETIME, '" + startDate + "', 103) AND CONVERT(DATETIME, '" + endDate + " 23:59', 103)"
                    };
            var expenseList = ExpenseService.GetExpenses(searchCriteria);

            if ((expenseList == null) || (expenseList.Count == 0))
                return string.Empty;

            //Write to Excel file
            var templateReportFile =
                System.Windows.Forms.Application.StartupPath + @"\" +
                Resources.ConstExpenseStatementExcelFile;

            var reportFileInfo = new FileInfo(templateReportFile);
            if (!reportFileInfo.Exists)
                return string.Empty;

            var expensePeriod =
                startDate + " ដល់ " + endDate;

            //Open workbook                
            var excelApplication = new ExcelApplication();
            var workBook = excelApplication.Workbooks.Open(
                templateReportFile,
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

            //Expense content
            var workSheet = (Worksheet)workBook.Worksheets[Resources.ConstSheetExpenseStatement];

            //Shop name
            var rowIndex = 1;
            var excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = "របាយការណ៏ចំណាយរបស់ក្រុមហ៊ុន " + AppContext.ShopNameLocal;

            //Period
            rowIndex = 2;
            excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = "សំរាប់រយៈពេល " + expensePeriod;

            //Expense            
            rowIndex = 5;
            var grandTotalExpenseForeign = 0f;
            var grandTotalExpenseLocal = 0f;

            var expenseDateList =
                (from expense
                in expenseList.Cast<Expense>()
                 select ((DateTime)expense.ExpenseDate).Date).Distinct().ToList();

            foreach (var expenseDate in expenseDateList)
            {
                var localExpenseDate = expenseDate;
                var filteredExpenseList =
                    (from anExpense
                    in expenseList.Cast<Expense>()
                     where
                         ((DateTime)anExpense.ExpenseDate).Date == localExpenseDate
                     select anExpense).ToList();

                //Expense date
                workSheet.get_Range("A" + rowIndex + ":E" + rowIndex, Type.Missing).Merge(Type.Missing);
                excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = expenseDate.ToString("dd/MM/yyyy", AppContext.CultureInfo);

                excelRange = workSheet.get_Range("A" + rowIndex, "E" + rowIndex);
                excelRange.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                excelRange.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                excelRange.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                excelRange.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                excelRange.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                rowIndex += 1;
                excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                excelRange.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, 1);

                var subTotalExpenseForeign = 0f;
                var subTotalExpenseLocal = 0f;
                var orderNumber = 0;
                foreach (var anExpense in filteredExpenseList)
                {
                    if (anExpense == null)
                        continue;

                    orderNumber += 1;
                    excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = orderNumber;

                    excelRange = workSheet.get_Range("B" + rowIndex, "B" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = anExpense.ExpenseTypeStr;

                    var quantity = anExpense.Description;
                    excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = quantity;

                    var expenseAmountLocal = anExpense.ExpenseAmountRiel;
                    excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = expenseAmountLocal;

                    var expenseAmountForeign = anExpense.ExpenseAmountInt;
                    excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = expenseAmountForeign;

                    subTotalExpenseLocal += expenseAmountLocal;
                    subTotalExpenseForeign += expenseAmountForeign;

                    rowIndex += 1;
                    excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                    excelRange.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, 1);
                }

                //SubTotal
                excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = "សរុប";
                excelRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
                excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = subTotalExpenseLocal;
                excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = subTotalExpenseForeign;

                //Grand Total
                rowIndex += 2;

                grandTotalExpenseLocal += subTotalExpenseLocal;
                grandTotalExpenseForeign += subTotalExpenseForeign;
            }

            //rowIndex += 2;
            excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = "សរុប​ប្រាក់ចំណាយ";
            excelRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
            excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = grandTotalExpenseLocal;
            excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = grandTotalExpenseForeign;
            excelRange = workSheet.get_Range("D" + rowIndex, "E" + rowIndex);
            excelRange.Font.Bold = true;
            excelRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(253, 233, 217));

            excelRange = workSheet.get_Range("A1", "A1");
            excelRange.Select();

            var reportFileName =
                System.Windows.Forms.Application.StartupPath + @"\" +
                DateTime.Now.Ticks + " - " +
                Resources.ConstExpenseStatementExcelFile;

            workBook.Close(
                true,
                reportFileName,
                System.Reflection.Missing.Value);

            excelApplication.Quit();

            Marshal.ReleaseComObject(excelApplication);
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            return reportFileName;
        }
    }
}