using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Model.Common;
using EzPos.Model.Product;
using EzPos.Properties;

namespace EzPos.GUI
{
    public class PrintProduct
    {
        private static readonly PrintDocument printDocument = new PrintDocument();
        private static int _Counter;
        private static BindingList<Product> _ProductListt = new BindingList<Product>();
        private static StringFormat StrFormat;

        public static void InializePrinting(BindingList<Product> productList)
        {
            _ProductListt = productList;
            var printPreviewDialog = new PrintPreviewDialog
                                         {
                                             WindowState = FormWindowState.Maximized,
                                             FormBorderStyle = FormBorderStyle.None,
                                             UseAntiAlias = true,
                                             Document = printDocument
                                         };
            printDocument.PrinterSettings.PrinterName = AppContext.Counter.ReportPrinter;

            printDocument.BeginPrint += printDoc_BeginPrint;
            printDocument.PrintPage += printDocument_PrintPage;

            printPreviewDialog.ShowDialog();

            printDocument.BeginPrint -= printDoc_BeginPrint;
            printDocument.PrintPage -= printDocument_PrintPage;
        }

        private static void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            var posY = 30;
            var rowIndex = 0;
            var recHeight = 130;
            var recWidth = 150;

            var fontDisplayName = new Font("Arial", 12, FontStyle.Regular);
            var fontBarCode = new Font("Free 3 of 9 Extended", 40, FontStyle.Regular);
            var solidBrush = new SolidBrush(Color.Black);

            while (_Counter <= _ProductListt.Count - 1)
            {
                var posX = e.MarginBounds.Left;
                if (rowIndex == 8)
                {
                    e.HasMorePages = true;
                    return;
                }

                var product = _ProductListt[_Counter];
                Bitmap bitmapImage;
                if (string.IsNullOrEmpty(product.PhotoPath))
                    bitmapImage = Resources.NoImage;
                else
                {
                    var fileInfo = new FileInfo(product.PhotoPath);
                    bitmapImage = !fileInfo.Exists ? Resources.NoImage : new Bitmap(product.PhotoPath);
                }
                e.Graphics.DrawImage(
                    bitmapImage,
                    new Rectangle(posX, posY, 150, recHeight));

                posX += 50 + recWidth;
                var printStr =
                    product.ProductName + "\n" +
                    "Size: " + product.SizeStr + "\n" +
                    "Code: " + product.ProductCode;
                e.Graphics.DrawString(
                    printStr,
                    fontDisplayName,
                    solidBrush,
                    posX,
                    posY + 35,
                    StrFormat);

                printStr = "*" + product.ProductCode + "*";
                e.Graphics.DrawString(
                    printStr,
                    fontBarCode,
                    solidBrush,
                    posX,
                    posY + 90,
                    StrFormat);

                printStr = product.QtyInStock.ToString("N0", AppContext.CultureInfo);
                //printStr = string.Empty;
                posX =
                    e.MarginBounds.Right -
                    Int32.Parse(Math.Round(e.Graphics.MeasureString(printStr, fontDisplayName).Width, 0).ToString());
                e.Graphics.DrawString(
                    printStr,
                    fontDisplayName,
                    solidBrush,
                    posX,
                    posY + 15,
                    StrFormat);

                _Counter++;
                posY += recHeight;
                rowIndex += 1;
            }
            e.HasMorePages = false;
        }

        private static void printDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            try
            {
                StrFormat = new StringFormat
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