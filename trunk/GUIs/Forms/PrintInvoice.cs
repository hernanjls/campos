using System;
using System.Collections;
using System.Drawing.Printing;
using System.Windows.Forms;
using EzPos.Model;
using Microsoft.Office.Interop.Excel;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;

namespace EzPos.GUIs.Forms
{
    public class PrintInvoice
    {
        private static readonly PrintDocument PrintDocument = new PrintDocument();
        public void InializeInvoicePrinting()
        {
            var printPreviewDialog = 
                new PrintPreviewDialog
                {
                    WindowState = FormWindowState.Maximized,
                    FormBorderStyle = FormBorderStyle.None,
                    UseAntiAlias = true,
                    Document = PrintDocument
                };

            if (AppContext.Counter != null)
                PrintDocument.PrinterSettings.PrinterName = AppContext.Counter.BarCodePrinter;
            //PrintDocument.BeginPrint += PrintDocBeginPrint;
            //PrintDocument.PrintPage += PrintDocumentPrintPage;

            printPreviewDialog.ShowDialog();            

            //PrintDocument.BeginPrint -= PrintDocBeginPrint;
            //PrintDocument.PrintPage -= PrintDocumentPrintPage;
        }

        //private static void PrintDocumentPrintPage(object sender, PrintPageEventArgs e)
        //{
        //}

        //private static void PrintDocBeginPrint(object sender, PrintEventArgs e)
        //{
        //    try
        //    {
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public void ExcelInvoicePrintingHandler(
            string printerName, 
            string fileName, 
            string protectedPassword,
            string customerName,
            string customerAddress,
            string invoiceNumber,
            DateTime invoiceDate,
            float discountPercentage,
            float depositAmount,
            float paidAmount,
            IList invoiceItemList,
            bool isDeposit)
        {
            if (string.IsNullOrEmpty(printerName))
                throw new ArgumentNullException("printerName", string.Empty);

            var excelApplication = new ExcelApplication();
            try
            {
                //Open workbook
                var workBook = excelApplication.Workbooks.Open(
                    fileName,
                    0,
                    false,
                    5,
                    protectedPassword,
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
                var workSheet = (Worksheet)workBook.Worksheets["Invoice"];

                //Customer name
                var rowIndex = 8;
                var excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = "Customer name: " + customerName;

                //Invoice number
                excelRange = workSheet.get_Range("L" + rowIndex, "L" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = invoiceNumber;

                //Customer address
                rowIndex += 1;
                excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = "Address: " + customerAddress;

                //Invoice date
                excelRange = workSheet.get_Range("L" + rowIndex, "L" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = invoiceDate;

                //Invoice item
                rowIndex += 4;
                var totalAmount = 0f;
                foreach (SaleItem saleItem in invoiceItemList)
                {
                    if(saleItem == null)    
                        continue;

                    if(saleItem.ProductID == 0)
                        continue;

                    //Product
                    var productName = saleItem.ProductName;
                    if (saleItem.FKProduct != null)
                        productName += " (" + saleItem.FKProduct.ForeignCode + ")";
                    excelRange = workSheet.get_Range("B" + rowIndex, "B" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = productName;

                    //Quantity
                    excelRange = workSheet.get_Range("I" + rowIndex, "I" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = saleItem.QtySold;

                    //Unit price out
                    excelRange = workSheet.get_Range("J" + rowIndex, "J" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = saleItem.UnitPriceOut;

                    //Discount                    
                    excelRange = workSheet.get_Range("K" + rowIndex, "K" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = saleItem.Discount / 100;

                    //Sub total
                    var unitPriceOut =
                        float.Parse(Math.Round(saleItem.UnitPriceOut, 2).ToString("N3", AppContext.CultureInfo),
                                    AppContext.CultureInfo);

                    var subTotal =
                        unitPriceOut -
                        ((unitPriceOut * saleItem.Discount) / 100);
                    subTotal *= saleItem.QtySold;
                    excelRange = workSheet.get_Range("L" + rowIndex, "L" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = subTotal;

                    totalAmount += subTotal;
                    rowIndex += 1;
                }
                
                //Total amount
                rowIndex = 28;
                excelRange = workSheet.get_Range("J" + rowIndex, "J" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = totalAmount;

                //Overall discount
                rowIndex += 1;
                excelRange = workSheet.get_Range("J" + rowIndex, "J" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = discountPercentage / 100;

                //Deposit and balance amount 
                rowIndex += 1;
                totalAmount -= (totalAmount * discountPercentage) / 100;
                if (isDeposit)
                {
                    excelRange = workSheet.get_Range("J" + rowIndex, "J" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = depositAmount;

                    rowIndex += 1;
                    var balanceAmount = totalAmount;
                    balanceAmount -= depositAmount;
                    excelRange = workSheet.get_Range("J" + rowIndex, "J" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = balanceAmount;
                }
                else
                {
                    excelRange = workSheet.get_Range("J" + rowIndex, "J" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = totalAmount;

                    rowIndex += 1; 
                    excelRange = workSheet.get_Range("J" + rowIndex, "J" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = depositAmount;

                    rowIndex += 1;
                    excelRange = workSheet.get_Range("J" + rowIndex, "J" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = paidAmount;

                    rowIndex += 1;
                    excelRange = workSheet.get_Range("J" + rowIndex, "J" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = (depositAmount + paidAmount) - totalAmount;
                }

                //Print workbook
                workBook.PrintOut(
                    1,
                    1,
                    1,
                    false,
                    printerName,
                    false,
                    false,
                    string.Empty);
                //excelApplication.Visible = true;
                //workBook.PrintPreview(true);

                //Close workbook
                workBook.Close(
                    false,
                    fileName,
                    0);
            }
            finally
            {
                excelApplication.Workbooks.Close();
            }
        }
    }
}