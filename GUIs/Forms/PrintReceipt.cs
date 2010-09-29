using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using EzPos.Model;

namespace EzPos.GUIs.Forms
{
    public class PrintReceipt
    {
        private readonly PrintDocument _printDocument = new PrintDocument();
        private string _amountPaid, _amountReturn;
        private string _amountSold;
        private string _amountSubTotal;
        private BindingList<SaleItem> _bindingListObj;
        private string _cashier;
        private string _counter;
        private string _customerInfo;
        private string _discount;
        private string _invoiceNumber;
        private string _printDate;
        internal PrintPreviewDialog PrintPreviewDialog;

        public BindingList<SaleItem> BindingListObj
        {
            set { _bindingListObj = value; }
        }

        public string InvoiceNumber
        {
            set { _invoiceNumber = value; }
        }

        public string Cashier
        {
            set { _cashier = value; }
        }

        public string PrintDate
        {
            set { _printDate = value; }
        }

        public string Counter
        {
            set { _counter = value; }
        }

        public string AmountSold
        {
            set { _amountSold = value; }
        }

        public string AmountPaid
        {
            set { _amountPaid = value; }
        }

        public string AmountReturn
        {
            set { _amountReturn = value; }
        }

        public string Discount
        {
            set { _discount = value; }
        }

        public string AmountSubTotal
        {
            set { _amountSubTotal = value; }
        }

        public string CustomerInfo
        {
            get { return _customerInfo; }
            set { _customerInfo = value; }
        }

        public void InializeReceiptPrinting()
        {
            PrintPreviewDialog = 
                new PrintPreviewDialog
                {
                    UseAntiAlias = true
                };

            _printDocument.PrinterSettings.PrinterName = AppContext.ReceiptPrinter;
            _printDocument.DocumentName = AppContext.ShopName;
            _printDocument.PrintPage += PrintDocumentPrintPage;
            PrintPreviewDialog.Document = _printDocument;
            //PrintPreviewDialog.ShowDialog();
            _printDocument.Print();
            _printDocument.PrintPage -= PrintDocumentPrintPage;
        }

        private void PrintDocumentPrintPage(object sender, PrintPageEventArgs e)
        {
            const int posX = 0;
            var posY = 0;

            var textToPrint = AppContext.ShopName;
            var fontInUsed = new Font("Candara", 15, FontStyle.Bold);

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
            textToPrint = "Customer: " + _customerInfo;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black, posX, posY);

            posY += 5 + Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            textToPrint = "Invoice nº: " + _invoiceNumber;
            fontInUsed = new Font("Arial", 6, FontStyle.Regular);
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black, posX, posY);
            textToPrint = "Cashier: " + _cashier;
            e.Graphics.DrawString(
                textToPrint,
                fontInUsed,
                Brushes.Black,
                283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width,
                posY);

            posY += Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            textToPrint = "Date: " + _printDate;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black, posX, posY);
            textToPrint = "Counter: " + _counter;
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
            textToPrint = "U.P. Amount";
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
            fontInUsed = new Font("Arial", 8, FontStyle.Regular);
            foreach (var saleItem in _bindingListObj)
            {
                if (saleItem.ProductID == 0)
                    continue;
                //Name
                textToPrint = saleItem.ProductName;
                e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black, 0, posY);
                //Qty
                //textToPrint = saleItem.QtySold.ToString("N2", AppContext.CultureInfo);
                textToPrint = saleItem.QtySold.ToString("N0", AppContext.CultureInfo);
                e.Graphics.DrawString(
                    textToPrint,
                    fontInUsed,
                    Brushes.Black,
                    190 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width,
                    posY);
                //UnitPrice
                //textToPrint = Math.Round(saleItem.UnitPriceOut, 2).ToString("N2", AppContext.CultureInfo);
                textToPrint = Math.Round(saleItem.PublicUPOut, 2).ToString("N2", AppContext.CultureInfo);
                e.Graphics.DrawString(
                    textToPrint,
                    fontInUsed,
                    Brushes.Black,
                    232 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width,
                    posY);
                //SubTotal
                //textToPrint = Math.Round((saleItem.QtySold*saleItem.UnitPriceOut), 2).ToString("N2",
                //                                                                               AppContext.CultureInfo);
                textToPrint = Math.Round((saleItem.QtySold*saleItem.PublicUPOut), 2).ToString("N2",
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
            }

            posY += 11 + Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            fontInUsed = new Font("Arial", 8, FontStyle.Regular);
            textToPrint = "SubTotal: ";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  235 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY);
            textToPrint = _amountSubTotal;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY);
            textToPrint = "Discount: ";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  235 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 15);
            textToPrint = _discount;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 15);
            textToPrint = "Total: ";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  235 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 30);
            textToPrint = _amountSold;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 30);
            textToPrint = "Cash: ";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  235 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 45);
            textToPrint = _amountPaid;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 45);
            textToPrint = "Change: ";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  235 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 60);
            textToPrint = _amountReturn;
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