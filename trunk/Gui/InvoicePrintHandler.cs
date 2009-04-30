using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using EzPos.Model;

namespace EzPos.GUI
{
    public class InvoicePrintHandler
    {
        private readonly PrintDocument printDocument = new PrintDocument();
        private string _AmountPaid, _AmountReturn;
        private string _AmountSold;
        private BindingList<SaleItem> _BindingListObj;
        private string _Cashier;
        private string _Counter;
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

        public void InializeRetailInvoicePrinting()
        {
            printPreviewDialog = new PrintPreviewDialog {UseAntiAlias = true};

            printDocument.PrintPage += printDocument_PrintPage;

            printPreviewDialog.Document = printDocument;
            //printDocument.Print();
            printPreviewDialog.ShowDialog();
            printDocument.PrintPage -= printDocument_PrintPage;
        }

        public void InializeEmptyInvoicePrinting()
        {
            printPreviewDialog = new PrintPreviewDialog {UseAntiAlias = true, Document = printDocument};
            printDocument.Print();
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            const int posX = 0;
            int posY = 0;

            string textToPrint = "¬saxapSaredb:U¦";
            var fontInUsed = new Font("Limon R1", 15, FontStyle.Bold);
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black, 283 - 110, posY + 8);

            textToPrint = "»sfsßan rsµIsYK’";
            fontInUsed = new Font("Limon R1", 23, FontStyle.Bold);
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  (283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width)/2 - 55, posY);

            posY += Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString()) - 10;
            textToPrint = "Rasmey Suor Pharmacy";
            fontInUsed = new Font("Arial", 10, FontStyle.Regular);
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  (283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width)/2, posY);

            posY += 3 + Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            fontInUsed = new Font("Arial", 8, FontStyle.Regular);
            textToPrint = "Nº 79 St. 215 Sangkat PHSADEPO II";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  (283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width)/2, posY);

            posY += 10 + Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            textToPrint = "Invoice nº: " + _InvoiceNumber;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black, posX, posY);
            textToPrint = "Cashier: " + _Cashier;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY);

            posY += Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            textToPrint = "Date: " + _PrintDate;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black, posX, posY);
            textToPrint = "Counter: " + _Counter;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY);

            posY += Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());

            var pen = new Pen(Color.Black, 0.1f);
            var rectangle = new Rectangle(0, posY, 283, 30);
            e.Graphics.DrawRectangle(pen, rectangle);

            fontInUsed = new Font("Arial", 8, FontStyle.Bold);
            posY += 3;
            textToPrint = "U.P.  Amount";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width - 1, posY);

            posY += Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            textToPrint = "USD     USD";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width - 10, posY);

            posY -= (Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString()))/2;
            textToPrint = "                         Item                      Qty.";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black, 0, posY);

            posY = 142;
            //var posYProductName = posY + 107;
            fontInUsed = new Font("Arial", 8, FontStyle.Regular);
            foreach (SaleItem saleItem in _BindingListObj)
            {
                if (saleItem.ProductID == 0)
                    continue;

                textToPrint = saleItem.FKProduct.DisplayName;
                e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black, 0, posY);
                textToPrint = saleItem.QtyOutStr;
                e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                      200 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY);
                textToPrint = Math.Round(saleItem.UnitPriceOut, 2).ToString();
                e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                      232 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY);
                textToPrint = Math.Round((saleItem.QtyOut*saleItem.UnitPriceOut), 2).ToString();
                e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                      283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY);
                e.Graphics.DrawLine(pen, 0, posY + e.Graphics.MeasureString(textToPrint, fontInUsed).Height, 283,
                                    posY + e.Graphics.MeasureString(textToPrint, fontInUsed).Height);

                posY += Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString()) + 2;
                //posYProductName += 44;
            }

            posY += 5 + Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            fontInUsed = new Font("Limon S1", 15, FontStyle.Bold);
            textToPrint = "srub ";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  180 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY);
            textToPrint = "R)ak;TTYl ";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  180 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 15);
            textToPrint = "R)ak;Gab; ";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  180 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 30);

            posY += 6;
            fontInUsed = new Font("Arial", 8, FontStyle.Regular);
            textToPrint = "(Total): ";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  235 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY);
            textToPrint = _AmountSold;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY);
            fontInUsed = new Font("Arial", 8, FontStyle.Regular);
            textToPrint = "(Cash): ";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  235 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 15);
            textToPrint = _AmountPaid;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 15);
            textToPrint = "(Change): ";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  235 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 30);
            textToPrint = _AmountReturn;
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width, posY + 30);

            fontInUsed = new Font("Arial", 6, FontStyle.Regular);
            posY += 45 + Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            textToPrint = "Thank you for purchasing drugs at Rasmey Suor Pharmacy.";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  (283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width)/2, posY);
            posY += Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, fontInUsed).Height).ToString());
            textToPrint = "Goods sold are not returnable.";
            e.Graphics.DrawString(textToPrint, fontInUsed, Brushes.Black,
                                  (283 - e.Graphics.MeasureString(textToPrint, fontInUsed).Width)/2, posY);
        }
    }
}