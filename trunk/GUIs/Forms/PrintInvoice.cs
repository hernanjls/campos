using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using EzPos.Model;

namespace EzPos.GUI
{
    public class PrintInvoice
    {
        private readonly PrintDocument printDocument = new PrintDocument();
        private string _AmountPaid, _AmountReturn;
        private string _AmountSold;
        private string _AmountSubTotal;
        private BindingList<SaleItem> _BindingListObj;
        private string _Cashier;
        private string _Counter;
        private string _CustomerInfo;
        private string _Discount;
        private string _InvoiceNumber;
        private string _PrintDate;
        internal PrintPreviewDialog printPreviewDialog;

        public BindingList<SaleItem> BindingListObj
        {
            set { _BindingListObj = value; }
        }

        public string InvoiceNumber
        {
            set { _InvoiceNumber = value; }
        }

        public string Cashier
        {
            set { _Cashier = value; }
        }

        public string PrintDate
        {
            set { _PrintDate = value; }
        }

        public string Counter
        {
            set { _Counter = value; }
        }

        public string AmountSold
        {
            set { _AmountSold = value; }
        }

        public string AmountPaid
        {
            set { _AmountPaid = value; }
        }

        public string AmountReturn
        {
            set { _AmountReturn = value; }
        }

        public string Discount
        {
            set { _Discount = value; }
        }

        public string AmountSubTotal
        {
            set { _AmountSubTotal = value; }
        }

        public string CustomerInfo
        {
            get { return _CustomerInfo; }
            set { _CustomerInfo = value; }
        }

        public void InializeInvoicePrinting()
        {
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.UseAntiAlias = true;
            printDocument.PrinterSettings.PrinterName = AppContext.Counter.ReceiptPrinter;
            printDocument.DocumentName = AppContext.ShopName;
            printDocument.PrintPage += printDocument_PrintPage;

            printPreviewDialog.Document = printDocument;
            printDocument.Print();
            printDocument.PrintPage -= printDocument_PrintPage;
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            int posX = 0, posY = 0;

            string textToPrint;
            Font fontInUsed;
            textToPrint = AppContext.ShopName;
            fontInUsed = new Font("Candara", 15, FontStyle.Bold);

            posY += Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString()) - 10;
            e.Graphics.DrawString(
                textToPrint,
                fontInUsed,
                Brushes.Black,
                (283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width)/2,
                posY);

            posY += 3 + Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            fontInUsed = new Font("Arial", 6, FontStyle.Regular);
            textToPrint = AppContext.ShopAddress;
            e.Graphics.DrawString(
                textToPrint,
                fontInUsed,
                Brushes.Black,
                (283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width)/2,
                posY);

            posY += 3 + Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            textToPrint = AppContext.ShopContact;
            e.Graphics.DrawString(
                textToPrint,
                fontInUsed,
                Brushes.Black,
                (283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width)/2,
                posY);

            fontInUsed = new Font("Arial", 8, FontStyle.Bold);
            posY += 15 + Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            textToPrint = "Customer: " + _CustomerInfo;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black, posX, posY);

            posY += 5 + Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            textToPrint = "Invoice nº: " + _InvoiceNumber;
            fontInUsed = new Font("Arial", 6, FontStyle.Regular);
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black, posX, posY);
            textToPrint = "Cashier: " + _Cashier;
            e.Graphics.DrawString(
                textToPrint,
                fontInUsed,
                Brushes.Black,
                283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width,
                posY);

            posY += Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            textToPrint = "Date: " + _PrintDate;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black, posX, posY);
            textToPrint = "Counter: " + _Counter;
            e.Graphics.DrawString(
                textToPrint,
                fontInUsed,
                Brushes.Black,
                283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width,
                posY);

            posY += Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());

            var pen = new Pen(Color.Black, 0.1f);
            var rectangle = new Rectangle(0, posY, 283, 30);
            e.Graphics.DrawRectangle(pen, rectangle);

            fontInUsed = new Font("Arial", 8, FontStyle.Bold);
            posY += 3;
            textToPrint = "U.P.  Amount";
            e.Graphics.DrawString(
                textToPrint,
                fontInUsed,
                Brushes.Black,
                283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width - 1,
                posY);

            posY += Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            textToPrint = "USD     USD";
            e.Graphics.DrawString(
                textToPrint,
                fontInUsed,
                Brushes.Black,
                283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width - 10, posY);

            posY -= (Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString()))/2;
            textToPrint = "                         Item                     Qty.";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black, 0, posY);

            posY = 165;
            int posYProductName = posY + 107;
            fontInUsed = new Font("Arial", 8, FontStyle.Regular);
            foreach (SaleItem saleItem in _BindingListObj)
            {
                if (saleItem.ProductID == 0)
                    continue;
                //Name
                textToPrint = saleItem.ProductName;
                e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black, 0, posY);
                //Qty
                textToPrint = saleItem.QtySold.ToString("N2", AppContext.CultureInfo);
                e.Graphics.DrawString(
                    textToPrint,
                    fontInUsed,
                    Brushes.Black,
                    190 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width,
                    posY);
                //UnitPrice
                textToPrint = Math.Round(saleItem.UnitPriceOut, 2).ToString("N2", AppContext.CultureInfo);
                e.Graphics.DrawString(
                    textToPrint,
                    fontInUsed,
                    Brushes.Black,
                    232 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width,
                    posY);
                //SubTotal
                textToPrint = Math.Round((saleItem.QtySold*saleItem.UnitPriceOut), 2).ToString("N2",
                                                                                               AppContext.CultureInfo);
                e.Graphics.DrawString(
                    textToPrint,
                    fontInUsed,
                    Brushes.Black,
                    283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width,
                    posY);
                e.Graphics.DrawLine(
                    pen,
                    0,
                    posY + e.Graphics.MeasureString(textToPrint, fontInUsed).Height,
                    283,
                    posY + e.Graphics.MeasureString(textToPrint, fontInUsed).Height);

                posY += Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString()) + 2;
                posYProductName += 44;
            }

            posY += 11 + Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            fontInUsed = new Font("Arial", 8, FontStyle.Regular);
            textToPrint = "SubTotal: ";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  235 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY);
            textToPrint = _AmountSubTotal;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY);
            textToPrint = "Discount: ";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  235 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 15);
            textToPrint = _Discount;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 15);
            textToPrint = "Total: ";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  235 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 30);
            textToPrint = _AmountSold;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 30);
            textToPrint = "Cash: ";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  235 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 45);
            textToPrint = _AmountPaid;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 45);
            textToPrint = "Change: ";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  235 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 60);
            textToPrint = _AmountReturn;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 60);

            fontInUsed = new Font("Arial", 6, FontStyle.Regular);
            posY += 75 + Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            textToPrint = AppContext.ReceiptFooter;
            e.Graphics.DrawString(
                textToPrint,
                fontInUsed,
                Brushes.Black,
                (283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width)/2,
                posY);
            posY += Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            textToPrint = "Goods sold are not returnable.";
            e.Graphics.DrawString(
                textToPrint,
                fontInUsed,
                Brushes.Black,
                (283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width)/2,
                posY);
        }
    }
}