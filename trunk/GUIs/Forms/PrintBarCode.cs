using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using EzPos.Model;

namespace EzPos.GUIs.Forms
{
    public class PrintBarCode
    {
        private static readonly PrintDocument PrintDocument = new PrintDocument();
        private static List<BarCode> BarCodeList = new List<BarCode>();
        private static int Counter;
        private static StringFormat StrFormat;

        public static void InializePrinting(List<BarCode> barCodeList)
        {
            BarCodeList = barCodeList;
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
            PrintDocument.BeginPrint += PrintDocBeginPrint;
            PrintDocument.PrintPage += PrintDocumentPrintPage;

            printPreviewDialog.ShowDialog();

            PrintDocument.BeginPrint -= PrintDocBeginPrint;
            PrintDocument.PrintPage -= PrintDocumentPrintPage;
        }

        private static void PrintDocumentPrintPage(object sender, PrintPageEventArgs e)
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}