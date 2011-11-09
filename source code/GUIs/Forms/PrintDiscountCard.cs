using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Model.Common;

namespace EzPos.GUI
{
    public class PrintDiscountCard
    {
        private static readonly PrintDocument printDocument = new PrintDocument();
        private static int _Counter;
        private static List<BarCode> _DiscountCardList;
        private static StringFormat StrFormat;

        public static void InializePrinting(List<BarCode> discountCardList)
        {
            _DiscountCardList = discountCardList;
            PrintPreviewDialog printPreviewDialog;
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.WindowState = FormWindowState.Maximized;
            printPreviewDialog.FormBorderStyle = FormBorderStyle.None;
            printPreviewDialog.UseAntiAlias = true;
            printPreviewDialog.Document = printDocument;
            printDocument.PrinterSettings.PrinterName = AppContext.Counter.ReportPrinter;

            printDocument.BeginPrint += printDoc_BeginPrint;
            printDocument.PrintPage += printDocument_PrintPage;

            printPreviewDialog.ShowDialog();

            printDocument.BeginPrint -= printDoc_BeginPrint;
            printDocument.PrintPage -= printDocument_PrintPage;
        }

        private static void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            //int recHeight, recWidth;
            //int posX = 1, posY = 2;
            //int rowIndex = 0, colIndex = 0;

            //Font fontBarCode = new Font("Free 3 of 9 Extended", 20, FontStyle.Regular);
            //Font fontDisplayName = new Font("Arial", 9, FontStyle.Regular);
            //SolidBrush solidBrush = new SolidBrush(Color.Black); 
            //recWidth = (e.MarginBounds.Left + e.MarginBounds.Right) / 5;
            //recHeight = (e.MarginBounds.Top + e.MarginBounds.Bottom)/18;

            //while(_Counter <= _DiscountCardList.Count - 1)
            //{
            //    if (rowIndex == 18)
            //    {
            //        e.HasMorePages = true;
            //        return;
            //    }

            //    BarCode discountCard = _DiscountCardList[_Counter];
            //    string printStr = "*" + discountCard.BarCodeValue + "*";                
            //    int txtPosX = Int32.Parse(
            //        Math.Round(e.Graphics.MeasureString(printStr, fontBarCode).Width, 0).ToString());
            //    int txtPosY = 5 + Int32.Parse(
            //        Math.Round(e.Graphics.MeasureString(printStr, fontBarCode).Height, 0).ToString()) / 2;

            //    e.Graphics.DrawString(
            //        printStr, 
            //        fontBarCode, 
            //        solidBrush, 
            //        ((2 * posX) + recWidth - txtPosX) / 2, 
            //        posY + txtPosY,
            //        StrFormat);

            //    printStr = discountCard.BarCodeValue;
            //    txtPosX = Int32.Parse(
            //        Math.Round(e.Graphics.MeasureString(printStr, fontDisplayName).Width, 0).ToString());
            //    e.Graphics.DrawString(
            //        printStr,
            //        fontDisplayName,
            //        solidBrush,
            //        ((2 * posX) + recWidth - txtPosX) / 2,
            //        posY + txtPosY + 18,
            //        StrFormat);

            //    _Counter++;                
            //    if (colIndex < 4)
            //    {
            //        colIndex++;
            //        posX += recWidth - 3;
            //    }
            //    else
            //    {
            //        colIndex = 0;
            //        posX = 1;
            //        rowIndex++;
            //        if (rowIndex < 8)
            //            posY += recHeight + 3;
            //        else
            //            posY += recHeight;
            //    }
            //}
            //e.HasMorePages = false;

            int recHeight, recWidth;
            int posX = 10, posY = 3;
            int rowIndex = 0, colIndex = 0;

            var fontBarCode = new Font("Free 3 of 9 Extended", 20, FontStyle.Regular);
            var fontDisplayName = new Font("Arial", 9, FontStyle.Regular);
            var solidBrush = new SolidBrush(Color.Black);
            recWidth = (e.MarginBounds.Left + e.MarginBounds.Right)/4;
            recHeight = (e.MarginBounds.Top + e.MarginBounds.Bottom)/14;

            while (_Counter <= _DiscountCardList.Count - 1)
            {
                if (rowIndex == 14)
                {
                    e.HasMorePages = true;
                    return;
                }

                BarCode discountCard = _DiscountCardList[_Counter];
                string printStr = "*" + discountCard.BarCodeValue + "*";
                int txtPosX = Int32.Parse(
                    Math.Round(e.Graphics.MeasureString(printStr, fontBarCode).Width, 0).ToString());
                int txtPosY = 5 + Int32.Parse(
                                      Math.Round(e.Graphics.MeasureString(printStr, fontBarCode).Height, 0).ToString())/
                                  2;

                e.Graphics.DrawString(
                    printStr,
                    fontBarCode,
                    solidBrush,
                    ((2*posX) + recWidth - txtPosX)/2,
                    posY + txtPosY,
                    StrFormat);

                printStr = discountCard.BarCodeValue;
                txtPosX = Int32.Parse(
                    Math.Round(e.Graphics.MeasureString(printStr, fontDisplayName).Width, 0).ToString());
                e.Graphics.DrawString(
                    printStr,
                    fontDisplayName,
                    solidBrush,
                    ((2*posX) + recWidth - txtPosX)/2,
                    posY + txtPosY + 18,
                    StrFormat);

                _Counter++;
                if (colIndex < 3)
                {
                    colIndex++;
                    if (colIndex == 3)
                        posX -= 10;

                    posX += recWidth - 3;
                }
                else
                {
                    colIndex = 0;
                    posX = 10;
                    rowIndex++;
                    if (rowIndex == 13)
                        posY -= 10;

                    posY += recHeight;
                }
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