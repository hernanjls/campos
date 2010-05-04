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
        private static readonly PrintDocument printDocument = new PrintDocument();
        private static List<BarCode> _BarCodeList = new List<BarCode>();
        private static int _Counter;
        private static StringFormat StrFormat;

        public static void InializePrinting(List<BarCode> barCodeList)
        {
            _BarCodeList = barCodeList;
            var printPreviewDialog = new PrintPreviewDialog
                                         {
                                             WindowState = FormWindowState.Maximized,
                                             FormBorderStyle = FormBorderStyle.None,
                                             UseAntiAlias = true,
                                             Document = printDocument
                                         };

            if (AppContext.Counter != null)
                printDocument.PrinterSettings.PrinterName = AppContext.Counter.BarCodePrinter;
            printDocument.BeginPrint += printDoc_BeginPrint;
            printDocument.PrintPage += printDocument_PrintPage;

            printPreviewDialog.ShowDialog();

            printDocument.BeginPrint -= printDoc_BeginPrint;
            printDocument.PrintPage -= printDocument_PrintPage;
        }

        private static void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            int posX = 10, posY = 30;
            int rowIndex = 0, colIndex = 0;

            var fontBarCode = new Font("Free 3 of 9 Extended", 30, FontStyle.Regular);
            var solidBrush = new SolidBrush(Color.Black);
            var recWidth = (e.MarginBounds.Left + e.MarginBounds.Right) / 3;
            var recHeight = (e.MarginBounds.Top + e.MarginBounds.Bottom) / 8;

            while (_Counter <= _BarCodeList.Count - 1)
            {
                if (rowIndex == 8)
                {
                    e.HasMorePages = true;
                    return;
                }

                var barCode = _BarCodeList[_Counter];
                var printStr = "*" + barCode.BarCodeValue + "*";
                var txtWidth = Int32.Parse(
                    Math.Round(e.Graphics.MeasureString(printStr, fontBarCode).Width, 0).ToString());
                var txtPosY = 
                    5 + Int32.Parse(Math.Round(e.Graphics.MeasureString(printStr, fontBarCode).Height, 0).ToString()) / 2;

                var txtPosX = (posX + recWidth - txtWidth) / 2;
                var recPosx = txtPosX;
                e.Graphics.DrawString(
                    printStr,
                    fontBarCode,
                    solidBrush,
                    txtPosX + 10,
                    5 + posY + txtPosY,
                    StrFormat);

                var fontDisplayName = new Font("Arial", 10, FontStyle.Bold);
                printStr = barCode.BarCodeValue;
                txtWidth = Int32.Parse(
                    Math.Round(e.Graphics.MeasureString(printStr, fontDisplayName).Width, 0).ToString());
                txtPosX = (posX + recWidth - txtWidth) / 2;
                e.Graphics.DrawString(
                    printStr,
                    fontDisplayName,
                    solidBrush,
                    txtPosX + 10,
                    posY + txtPosY + 30,
                    StrFormat);

                fontDisplayName = new Font("Arial", 13, FontStyle.Bold);
                printStr = barCode.DisplayStr;
                txtWidth = Int32.Parse(
                    Math.Round(e.Graphics.MeasureString(printStr, fontDisplayName).Width, 0).ToString());
                txtPosX = (posX + recWidth - txtWidth) / 2;
                e.Graphics.DrawString(
                    printStr,
                    fontDisplayName,
                    solidBrush,
                    txtPosX + 10,
                    posY + txtPosY + 55,
                    StrFormat);

                printStr = barCode.AdditionalStr;
                txtWidth = Int32.Parse(
                    Math.Round(e.Graphics.MeasureString(printStr, fontDisplayName).Width, 0).ToString());
                txtPosX = (posX + recWidth - txtWidth) / 2;
                e.Graphics.DrawString(
                    printStr,
                    fontDisplayName,
                    solidBrush,
                    txtPosX + 10,
                    posY + txtPosY + 75,
                    StrFormat);

                var rectangle =
                    new Rectangle(
                        recPosx - 20,
                        posY,
                        recWidth - 20,
                        recHeight - 20);
                var pen = new Pen(solidBrush, 0.1f);
                e.Graphics.DrawRectangle(pen, rectangle);

                if (colIndex < 2)
                {
                    colIndex++;
                    posX += recWidth + 250;
                }
                else
                {
                    colIndex = 0;
                    posX = 12;
                    rowIndex++;
                    posY += (recHeight - 10);
                }

                _Counter++;
            }
            e.HasMorePages = false;
        }

        private static void printDoc_BeginPrint(object sender, PrintEventArgs e)
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

                _Counter = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}