using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using EzPos.Utility;

namespace EzPos.GUI
{
    public class BarCodePrintHandler
    {
        private static StringFormat StrFormat;
        private readonly PrintDocument printDocument = new PrintDocument();
        private string _BarCodeValue;
        private string _ProductDisplayName;

        public string ProductDisplayName
        {
            set { _ProductDisplayName = value; }
        }

        public string BarCodeValue
        {
            set { _BarCodeValue = value; }
        }

        public void InializePrinting()
        {
            PrintPreviewDialog printPreviewDialog;
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.UseAntiAlias = true;
            printPreviewDialog.Document = printDocument;

            printDocument.BeginPrint += printDoc_BeginPrint;
            printDocument.PrintPage += printDocument_PrintPage;

            printPreviewDialog.ShowDialog();

            printDocument.BeginPrint -= printDoc_BeginPrint;
            printDocument.PrintPage -= printDocument_PrintPage;
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            int recHeight, recWidth;
            int posX = 0, posY = 0;

            var fontBarCode = new Font("Free 3 of 9 Extended", 20, FontStyle.Regular);
            var fontDisplayName = new Font("Arial", 9, FontStyle.Regular);
            var solidBrush = new SolidBrush(Color.Black);
            recWidth = (e.MarginBounds.Left + e.MarginBounds.Right)/4;
            recHeight = (e.MarginBounds.Top + e.MarginBounds.Bottom)/14;

            for (int rowIndex = 0; rowIndex <= 13; rowIndex++)
            {
                for (int colIndex = 0; colIndex <= 3; colIndex++)
                {
                    string printStr = "*" + _BarCodeValue + "*";
                    int widthBarCode = Int32.Parse(
                        Math.Round(e.Graphics.MeasureString(printStr, fontBarCode).Width, 0).ToString());
                    int txtPosY = 5 + Int32.Parse(
                                          Math.Round(e.Graphics.MeasureString(printStr, fontBarCode).Height, 0).ToString
                                              ())/2;

                    e.Graphics.DrawString(
                        printStr,
                        fontBarCode,
                        solidBrush,
                        ((2*posX) + recWidth - widthBarCode)/2,
                        posY + txtPosY,
                        StrFormat);

                    if (_ProductDisplayName.Length > 17)
                        printStr = StringHelper.Left(_ProductDisplayName, 17) + "...";
                    else
                        printStr = _ProductDisplayName;
                    e.Graphics.DrawString(
                        printStr,
                        fontDisplayName,
                        solidBrush,
                        ((2*posX) + recWidth - widthBarCode)/2 + 2,
                        posY + txtPosY + 18,
                        StrFormat);

                    if (colIndex < 3)
                    {
                        if (colIndex == 2)
                            posX -= 8;

                        posX += recWidth - 3;
                    }
                    else
                    {
                        posX = 0;
                        if (rowIndex == 4)
                            posY -= 10;

                        if (rowIndex == 11)
                            posY -= 10;

                        posY += recHeight;
                    }
                }
            }
        }

        private static void printDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            try
            {
                StrFormat = new StringFormat();
                StrFormat.Alignment = StringAlignment.Near;
                StrFormat.LineAlignment = StringAlignment.Center;
                StrFormat.Trimming = StringTrimming.EllipsisCharacter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}