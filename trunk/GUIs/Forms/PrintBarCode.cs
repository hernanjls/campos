using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Utility;

namespace EzPos.GUI
{
    public class PrintBarCode
    {
        private static readonly PrintDocument printDocument = new PrintDocument();
        private static List<BarCode> _BarCodeList = new List<BarCode>();
        private static int _Counter;
        private static StringFormat StrFormat;

        public static void InializePrinting(List<BarCode> barCodeList)
        {
            _BarCodeList = barCodeList;
            PrintPreviewDialog printPreviewDialog;
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.WindowState = FormWindowState.Maximized;
            printPreviewDialog.FormBorderStyle = FormBorderStyle.None;
            printPreviewDialog.UseAntiAlias = true;
            printPreviewDialog.Document = printDocument;

            printDocument.PrinterSettings.PrinterName = AppContext.Counter.BarCodePrinter;
            printDocument.BeginPrint += printDoc_BeginPrint;
            printDocument.PrintPage += printDocument_PrintPage;

            printPreviewDialog.ShowDialog();

            printDocument.BeginPrint -= printDoc_BeginPrint;
            printDocument.PrintPage -= printDocument_PrintPage;
        }

        private static void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            int recHeight, recWidth;
            int posX = 12, posY = 30;
            int rowIndex = 0, colIndex = 0;

            var fontBarCode = new Font("Free 3 of 9 Extended", 24, FontStyle.Regular);
            var solidBrush = new SolidBrush(Color.Black);
            recWidth = (e.MarginBounds.Left + e.MarginBounds.Right)/5;
            recHeight = (e.MarginBounds.Top + e.MarginBounds.Bottom)/8;

            while (_Counter <= _BarCodeList.Count - 1)
            {
                var fontDisplayName = new Font("Arial", 8, FontStyle.Bold);
                if (rowIndex == 8)
                {
                    e.HasMorePages = true;
                    return;
                }

                BarCode barCode = _BarCodeList[_Counter];
                string printStr = "*" + barCode.BarCodeValue + "*";
                int widthBarCode = Int32.Parse(
                    Math.Round(e.Graphics.MeasureString(printStr, fontBarCode).Width, 0).ToString());
                int txtPosY = 5 + Int32.Parse(
                                      Math.Round(e.Graphics.MeasureString(printStr, fontBarCode).Height, 0).ToString())/
                                  2;

                printStr =
                    StringHelper.Right("000" + DateTime.Today.Day, 3) +
                    StringHelper.Right("000" + DateTime.Today.Month, 3) +
                    StringHelper.Right("000" + DateTime.Today.Year, 3);

                e.Graphics.DrawString(
                    printStr,
                    fontDisplayName,
                    solidBrush,
                    ((2*posX) + recWidth - widthBarCode)/2 + 2,
                    posY,
                    StrFormat);

                printStr = "*" + barCode.BarCodeValue + "*";
                e.Graphics.DrawString(
                    printStr,
                    fontBarCode,
                    solidBrush,
                    ((2*posX) + recWidth - widthBarCode)/2,
                    5 + posY + txtPosY,
                    StrFormat);

                fontDisplayName = new Font("Arial", 10, FontStyle.Bold);
                printStr = barCode.BarCodeValue;
                e.Graphics.DrawString(
                    printStr,
                    fontDisplayName,
                    solidBrush,
                    ((2*posX) + recWidth - widthBarCode)/2 + 5,
                    posY + txtPosY + 30,
                    StrFormat);

                fontDisplayName = new Font("Arial", 13, FontStyle.Bold);
                widthBarCode = ((2*posX) + recWidth - widthBarCode)/2 + widthBarCode;
                printStr = "$" + barCode.DisplayStr;
                int widthTxt = Int32.Parse(
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

                _Counter++;
            }
            e.HasMorePages = false;
        }

        private static void printDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            try
            {
                StrFormat = new StringFormat();
                StrFormat.Alignment = StringAlignment.Near;
                StrFormat.LineAlignment = StringAlignment.Center;
                StrFormat.Trimming = StringTrimming.EllipsisCharacter;

                _Counter = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}