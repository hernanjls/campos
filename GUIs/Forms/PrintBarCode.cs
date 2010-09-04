using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Utility;

namespace EzPos.GUIs.Forms
{
    public class PrintBarCode
    {
        private static readonly PrintDocument PrintDocument = new PrintDocument();
        private static List<BarCode> BarCodeList = new List<BarCode>();
        private static int Counter;
        private static StringFormat StrFormat;
        private static string PrintType;

        public static void InializePrinting(List<BarCode> barCodeList, string printType)
        {
            BarCodeList = barCodeList;
            PrintType = printType;
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
            
            if (Resources.ConstPrintTypeLabel.Equals(PrintType))
            {
                PrintDocument.BeginPrint += PrintDocBeginPrint;
                PrintDocument.PrintPage += PrintLabelDocumentPrintPage;
                printPreviewDialog.ShowDialog();
                PrintDocument.BeginPrint -= PrintDocBeginPrint;
                PrintDocument.PrintPage -= PrintLabelDocumentPrintPage;
            }
            else if (Resources.ConstPrintTypeA4.Equals(PrintType))
            {
                PrintDocument.BeginPrint += PrintDocBeginPrint;
                PrintDocument.PrintPage += PrintA4DocumentPrintPage;
                printPreviewDialog.ShowDialog();
                PrintDocument.BeginPrint -= PrintDocBeginPrint;
                PrintDocument.PrintPage -= PrintA4DocumentPrintPage;
            }            
        }

        private static void PrintA4DocumentPrintPage(object sender, PrintPageEventArgs e)
        {
            var posY = 25;
            int rowIndex = 0, colIndex = 0;

            var fontBarCode = new Font("Free 3 of 9 Extended", 35, FontStyle.Regular);
            var solidBrush = new SolidBrush(Color.Black);
            var recHeight = (e.MarginBounds.Top + e.MarginBounds.Bottom) / 6;

            var leftMargin = e.MarginBounds.Left;
            var rightMargin = e.MarginBounds.Right;
            var medianPaper = e.MarginBounds.Width / 2;

            var posX = leftMargin - 50;
            while (Counter <= BarCodeList.Count - 1)
            {
                if (rowIndex == 6)
                {
                    e.HasMorePages = true;
                    return;
                }

                var barCode = BarCodeList[Counter];
                var printStr = "*" + barCode.BarCodeValue + "*";
                var txtWidth = Int32.Parse(
                    Math.Round(e.Graphics.MeasureString(printStr, fontBarCode).Width, 0).ToString());
                var txtPosY = 
                    5 + Int32.Parse(Math.Round(e.Graphics.MeasureString(printStr, fontBarCode).Height, 0).ToString()) / 2;

                posX += medianPaper * colIndex;

                var pen = new Pen(solidBrush, 0.1f);
                var rectangle = 
                    colIndex < 1 ? 
                    new Rectangle(
                        posX,
                        posY,
                        medianPaper + 50,
                        recHeight - 20) : 
                    new Rectangle(
                        medianPaper + 100,
                        posY,
                        rightMargin - medianPaper - 50,
                        recHeight - 20);

                pen.Color = Color.White;
                e.Graphics.DrawRectangle(pen, rectangle);

                e.Graphics.DrawString(
                    printStr,
                    fontBarCode,
                    solidBrush,
                    rectangle.Left + ((rectangle.Width - txtWidth) / 2),
                    20 + posY + txtPosY,
                    StrFormat);

                var fontDisplayName = new Font("Arial", 12, FontStyle.Bold);
                printStr = barCode.BarCodeValue;
                txtWidth = Int32.Parse(
                    Math.Round(e.Graphics.MeasureString(printStr, fontDisplayName).Width, 0).ToString());
                e.Graphics.DrawString(
                    printStr,
                    fontDisplayName,
                    solidBrush,
                    rectangle.Left + ((rectangle.Width - txtWidth) / 2),
                    posY + txtPosY + 60,
                    StrFormat);

                fontDisplayName = new Font("Arial", 15, FontStyle.Bold);
                printStr = barCode.DisplayStr;
                txtWidth = Int32.Parse(
                    Math.Round(e.Graphics.MeasureString(printStr, fontDisplayName).Width, 0).ToString());
                e.Graphics.DrawString(
                    printStr,
                    fontDisplayName,
                    solidBrush,
                    rectangle.Left + ((rectangle.Width - txtWidth) / 2),
                    posY + txtPosY + 95,
                    StrFormat);

                printStr = barCode.UnitPrice;
                txtWidth = Int32.Parse(
                    Math.Round(e.Graphics.MeasureString(printStr, fontDisplayName).Width, 0).ToString());
                e.Graphics.DrawString(
                    printStr,
                    fontDisplayName,
                    solidBrush,
                    rectangle.Left + ((rectangle.Width - txtWidth) / 2),
                    posY + txtPosY + 120,
                    StrFormat);

                if (colIndex < 1)
                    colIndex++;
                else
                {
                    colIndex = 0;
                    posX = leftMargin - 50;
                    rowIndex++;
                    posY += (recHeight - 20);
                }

                Counter++;
            }
            e.HasMorePages = false;
        }

        private static void PrintLabelDocumentPrintPage(object sender, PrintPageEventArgs e)
        {
            int posX = 12, posY = 30;
            int rowIndex = 0, colIndex = 0;

            var fontBarCode = new Font("Free 3 of 9 Extended", 24, FontStyle.Regular);
            var solidBrush = new SolidBrush(Color.Black);
            var recWidth = (e.MarginBounds.Left + e.MarginBounds.Right) / 5;
            var recHeight = (e.MarginBounds.Top + e.MarginBounds.Bottom) / 8;

            while (Counter <= BarCodeList.Count - 1)
            {
                var fontDisplayName = new Font("Arial", 8, FontStyle.Bold);
                if (rowIndex == 8)
                {
                    e.HasMorePages = true;
                    return;
                }

                var barCode = BarCodeList[Counter];
                var printStr = "*" + barCode.BarCodeValue + "*";
                var widthBarCode = Int32.Parse(
                    Math.Round(e.Graphics.MeasureString(printStr, fontBarCode).Width, 0).ToString());
                var txtPosY = 5 + Int32.Parse(
                                      Math.Round(e.Graphics.MeasureString(printStr, fontBarCode).Height, 0).ToString()) /
                                  2;

                printStr =
                    StringHelper.Right("000" + DateTime.Today.Day, 3) +
                    StringHelper.Right("000" + DateTime.Today.Month, 3) +
                    StringHelper.Right("000" + DateTime.Today.Year, 3);

                e.Graphics.DrawString(
                    printStr,
                    fontDisplayName,
                    solidBrush,
                    ((2 * posX) + recWidth - widthBarCode) / 2 + 2,
                    posY,
                    StrFormat);

                float xValue = ((2 * posX) + recWidth - widthBarCode) / 2 + 0;
                printStr = "*" + barCode.BarCodeValue + "*";
                e.Graphics.DrawString(
                    printStr,
                    fontBarCode,
                    solidBrush,
                    xValue,
                    5 + posY + txtPosY,
                    StrFormat);

                fontDisplayName = new Font("Arial", 10, FontStyle.Bold);
                printStr = barCode.BarCodeValue;
                e.Graphics.DrawString(
                    printStr,
                    fontDisplayName,
                    solidBrush,
                    ((2 * posX) + recWidth - widthBarCode) / 2 + 5,
                    posY + txtPosY + 30,
                    StrFormat);

                fontDisplayName = new Font("Arial", 13, FontStyle.Bold);
                widthBarCode = ((2 * posX) + recWidth - widthBarCode) / 2 + widthBarCode;
                printStr = "$" + barCode.DisplayStr;
                var widthTxt = Int32.Parse(
                    Math.Round(e.Graphics.MeasureString(printStr, fontDisplayName).Width, 0).ToString());
                e.Graphics.DrawString(
                    printStr,
                    fontDisplayName,
                    solidBrush,
                    widthBarCode - widthTxt - 5,
                    posY + txtPosY + 30,
                    StrFormat);

                if (colIndex < 4)
                {
                    colIndex++;
                    posX += recWidth - 4;
                }
                else
                {
                    colIndex = 0;
                    posX = 12;
                    rowIndex++;
                    if (rowIndex == 2)
                        posY -= 10;
                    if (rowIndex == 5)
                        posY -= 10;

                    posY += recHeight;
                }

                Counter++;
            }
            e.HasMorePages = false;
        }

        private static void PrintDocBeginPrint(object sender, PrintEventArgs e)
        {
            try
            {
                StrFormat = 
                    new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center,
                        Trimming = StringTrimming.EllipsisCharacter
                    };

                Counter = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, 
                    Resources.MsgCaptionError, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }
    }
}