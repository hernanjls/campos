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
            var searchCriteria = new List<string>();
            if (markId != -1)
            {
                searchCriteria.Add("MarkID|" + markId);
            }

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

            if(markId != -1)
                searchCriteria.Add("SaleOrderId IN (SELECT SaleOrderId FROM TSaleItems WHERE ProductId IN (SELECT ProductID FROM TProducts WHERE MarkID = " + markId + "))");

            var saleOrderList = SaleOrderService.GetSaleOrders(searchCriteria);
            var saleOrderHistoryList = SaleOrderService.GetSaleHistories(searchCriteria);
            var saleItemList = SaleOrderService.GetSaleItems(searchCriteria);

            if ((saleOrderList == null) || (saleOrderList.Count == 0))
                return string.Empty;

            //Write to Excel file
            var templateReportFile =
                System.Windows.Forms.Application.StartupPath + @"\" +
                Resources.ConstSaleStatementExcelFile;
            //var templateReportFile =
            //    @"D:\projects\yim sakal\point of sales\ezpos\application\branches\ezauto\source code\bin\Debug\" +
            //    Resources.ConstSaleStatementExcelFile;

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
            foreach (Model.SaleOrder saleOrder in saleOrderList)
            {
                if (saleOrder == null)
                    continue;

                var localSaleOrder = saleOrder;
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

                //Customer
                workSheet.get_Range("D" + rowIndex + ":G" + rowIndex, Type.Missing).Merge(Type.Missing);
                excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
                excelRange.Select();
                excelRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
                excelRange.Value2 = "កាល​បរិច្ឆេទ​: " + ((DateTime)saleOrder.SaleOrderDate).ToString("dd/MM/yyyy", AppContext.CultureInfo);

                excelRange = workSheet.get_Range("A" + rowIndex, "G" + rowIndex);
                excelRange.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                excelRange.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                excelRange.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                excelRange.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                rowIndex += 1;
                excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                excelRange.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, 1);

                var orderNumber = 0;
                foreach (
                    var saleOrderHistory in
                    filteredSaleOrderHistoryList.Where(saleOrderHistory => saleOrderHistory != null))
                {
                    orderNumber += 1;
                    excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = orderNumber;

                    excelRange = workSheet.get_Range("B" + rowIndex, "B" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = saleOrderHistory.ProductCode;

                    var localSaleOrderHistory = saleOrderHistory;
                    var productDescription =
                        (from saleItem
                             in saleItemList.Cast<SaleItem>()
                         where
                             (saleItem.SaleItemID == localSaleOrderHistory.SaleItemID)
                             && (saleItem.FKProduct != null)
                         select
                             saleItem.FKProduct.Description).FirstOrDefault();
                    excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = productDescription;

                    var quantity = saleOrderHistory.QtySold;
                    excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = quantity;

                    var unitPrice = saleOrderHistory.UnitPriceOut;
                    excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = unitPrice;

                    var subTotalSold = quantity * unitPrice;
                    excelRange = workSheet.get_Range("F" + rowIndex, "F" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = subTotalSold;

                    if(showProfit)
                    {
                        var subTotalProfit = 
                            subTotalSold - 
                            (quantity * saleOrderHistory.UnitPriceIn);

                        excelRange = workSheet.get_Range("G" + rowIndex, "G" + rowIndex);
                        excelRange.Select();
                        excelRange.Value2 = subTotalProfit;  
                    }

                    excelRange = workSheet.get_Range("A" + rowIndex, "G" + rowIndex);
                    excelRange.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDot;

                    rowIndex += 1;
                    excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                    excelRange.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, 1);
                }

                //Total amount
                var totalSold =
                    (from saleOrderHistory
                     in filteredSaleOrderHistoryList
                     select (saleOrderHistory.QtySold * saleOrderHistory.UnitPriceOut)).Sum();
                
                //SubTotal
                excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = "សរុប";
                excelRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
                excelRange = workSheet.get_Range("F" + rowIndex, "F" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = totalSold;
                excelRange = workSheet.get_Range("G" + rowIndex, "G" + rowIndex);
                excelRange.Select();

                excelRange = workSheet.get_Range("F" + rowIndex, "G" + rowIndex);
                excelRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(253, 233, 217));

                rowIndex += 1;
            }

            excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = "សរុបទាំងអស់";

            var grandTotalSold =
                (from saleOrderHistory
                 in saleOrderHistoryList.Cast<SaleOrderReport>()
                 select (saleOrderHistory.QtySold * saleOrderHistory.UnitPriceOut)).Sum();

            excelRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
            excelRange = workSheet.get_Range("F" + rowIndex, "F" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = grandTotalSold;

            if(showProfit)
            {
                var grandTotalProfit =
                    (from saleOrderHistory
                    in saleOrderHistoryList.Cast<SaleOrderReport>()
                    select 
                        (saleOrderHistory.QtySold * saleOrderHistory.UnitPriceOut) -
                        (saleOrderHistory.QtySold * saleOrderHistory.UnitPriceIn)).Sum();

                excelRange = workSheet.get_Range("G" + rowIndex, "G" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = grandTotalProfit;
            }

            excelRange = workSheet.get_Range("F" + rowIndex, "G" + rowIndex);
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

        //Sale
        public string SaleStatementQuantityOnlyReport(string startDate, string endDate, int markId)
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

            if (markId != -1)
                searchCriteria.Add("SaleOrderId IN (SELECT SaleOrderId FROM TSaleItems WHERE ProductId IN (SELECT ProductID FROM TProducts WHERE MarkID = " + markId + "))");

            var saleOrderList = SaleOrderService.GetSaleOrders(searchCriteria);
            var saleOrderHistoryList = SaleOrderService.GetSaleHistories(searchCriteria);
            var saleItemList = SaleOrderService.GetSaleItems(searchCriteria);

            //List of mark
            var markList =
                (from saleItem
                in saleItemList.Cast<SaleItem>()
                where saleItem.FKProduct != null
                orderby saleItem.FKProduct.MarkID
                select saleItem.FKProduct.MarkID).Distinct().ToList();

            if ((saleOrderList == null) || (saleOrderList.Count == 0))
                return string.Empty;

            //Write to Excel file
            var templateReportFile =
                System.Windows.Forms.Application.StartupPath + @"\" +
                Resources.ConstSaleStatementQuantityOnlyExcelFile;
            //var templateReportFile =
            //    @"D:\projects\yim sakal\point of sales\ezpos\application\branches\ezauto\source code\bin\Debug\" +
            //    Resources.ConstSaleStatementQuantityOnlyExcelFile;

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
            //foreach (var soldDate in soldDateList)
            foreach(var productMark in markList)
            {
                var localProductMark = productMark;
                var filterdSaleItemList =
                    (from saleItem
                    in saleItemList.Cast<SaleItem>()
                     where
                         ((saleItem.FKProduct != null)
                          && (saleItem.FKProduct.MarkID == localProductMark))
                     select saleItem).ToList();

                if(filterdSaleItemList.Count == 0)
                    continue;

                //var filteredSaleOrderHistoryList =
                //    (from saleOrderReport
                //         in saleOrderHistoryList.Cast<SaleOrderReport>()
                //     where
                //         (from saleItem in filterdSaleItemList select saleItem.SaleItemID).Contains(
                //             saleOrderReport.SaleItemID)
                //     select saleOrderReport).ToList();

                var filteredSaleOrderHistoryList =
                    (from saleOrderReport in saleOrderHistoryList.Cast<SaleOrderReport>()
                     where
                        (from saleItem in filterdSaleItemList select saleItem.SaleItemID).Contains(saleOrderReport.SaleItemID)
                    group saleOrderReport by saleOrderReport.ProductID into groupSaleOrderReport
                    select new SaleOrderReport{
                        ProductID = groupSaleOrderReport.Key,
                        QtySold = groupSaleOrderReport.Sum(saleOrderReport => saleOrderReport.QtySold),
                        UnitPriceOut = groupSaleOrderReport.Max(saleOrderReport => saleOrderReport.UnitPriceOut)}).ToList();

                //Mark                
                var markStr = filterdSaleItemList[0].FKProduct.MarkStr;
                workSheet.get_Range("A" + rowIndex + ":F" + rowIndex, Type.Missing).Merge(Type.Missing);
                excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = markStr;

                excelRange = workSheet.get_Range("A" + rowIndex, "F" + rowIndex);
                excelRange.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                excelRange.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                excelRange.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                excelRange.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                rowIndex += 1;
                excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                excelRange.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, 1);

                var counter = 1;
                foreach (
                    var saleOrderHistory in
                    filteredSaleOrderHistoryList.Where(saleOrderHistory => saleOrderHistory != null))
                {
                    //Order number
                    excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = counter;

                    //Product code & description
                    var localSaleOrderHistory = saleOrderHistory;
                    var product =
                        (from saleItem
                             in saleItemList.Cast<SaleItem>()
                         where
                             //(saleItem.SaleItemID == localSaleOrderHistory.SaleItemID)
                             (saleItem.FKProduct != null)
                             && (saleItem.FKProduct.ProductID == localSaleOrderHistory.ProductID)
                         select
                             saleItem.FKProduct).FirstOrDefault();

                    if (product != null)
                    {
                        //Product code
                        excelRange = workSheet.get_Range("B" + rowIndex, "B" + rowIndex);
                        excelRange.Select();
                        var productCode =
                            !string.IsNullOrEmpty(product.ForeignCode)
                                ? product.ForeignCode + "(" + product.ProductCode + ")"
                                : "'" + product.ProductCode;
                        excelRange.Value2 = productCode;

                        //Product Description
                        excelRange = workSheet.get_Range("C" + rowIndex, "C" + rowIndex);
                        excelRange.Select();
                        excelRange.Value2 = product.Description;                        
                    }

                    //Qty
                    var quantity = saleOrderHistory.QtySold;
                    excelRange = workSheet.get_Range("D" + rowIndex, "D" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = quantity;

                    //Unit price
                    var unitPrice = saleOrderHistory.UnitPriceOut;
                    excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = saleOrderHistory.UnitPriceOut;

                    //Total
                    var subTotal = quantity*unitPrice;
                    excelRange = workSheet.get_Range("F" + rowIndex, "F" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = subTotal;

                    counter += 1;

                    excelRange = workSheet.get_Range("A" + rowIndex, "F" + rowIndex);
                    excelRange.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDot;

                    rowIndex += 1;
                    excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                    excelRange.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, 1);
                }

                //Total amount
                var totalSold =
                    (from saleOrderHistory
                     in filteredSaleOrderHistoryList
                     select (saleOrderHistory.QtySold * saleOrderHistory.UnitPriceOut)).Sum();

                //SubTotal
                excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = "សរុប";
                excelRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
                excelRange = workSheet.get_Range("F" + rowIndex, "F" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = totalSold;

                excelRange = workSheet.get_Range("F" + rowIndex, "F" + rowIndex);
                excelRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(253, 233, 217));

                rowIndex += 1;
            }

            //Grand Total
            var grandTotalSold =
                (from saleOrderHistory
                 in saleOrderHistoryList.Cast<SaleOrderReport>()
                 select (saleOrderHistory.QtySold * saleOrderHistory.UnitPriceOut)).Sum();

            excelRange = workSheet.get_Range("E" + rowIndex, "E" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = "សរុបទាំងអស់";
            excelRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
            excelRange = workSheet.get_Range("F" + rowIndex, "F" + rowIndex);
            excelRange.Select();
            excelRange.Value2 = grandTotalSold;

            excelRange = workSheet.get_Range("F" + rowIndex, "F" + rowIndex);
            excelRange.Font.Bold = true;
            excelRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(253, 233, 217));

            excelRange = workSheet.get_Range("A1", "A1");
            excelRange.Select();

            var reportFileName =
                System.Windows.Forms.Application.StartupPath + @"\" +
                DateTime.Now.Ticks + " - " +
                Resources.ConstSaleStatementQuantityOnlyExcelFile;

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

        //Expense
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