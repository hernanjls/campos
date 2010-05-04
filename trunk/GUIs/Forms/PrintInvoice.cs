using System;
using System.Collections;
//using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using EzPos.Model;
//using EzPos.Properties;
using Microsoft.Office.Interop.Excel;
//using Font=System.Drawing.Font;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;

namespace EzPos.GUIs.Forms
{
    public class PrintInvoice
    {
        private static readonly PrintDocument _PrintDocument = new PrintDocument();
        //private IList _SaleItemList;
        //private static int _Counter;
        //private static StringFormat _StrFormat;
        //private Customer _Customer;
        //private string _InvoiceNumber;
        //private DateTime _InvoiceDate;
        //private float _TotalAmount;
        //private float _DepositAmount;
        //private float _DiscountPercentage;

        //private SaleOrder _SaleOrder;

        //public IList SaleItemList
        //{
        //    set { _SaleItemList = value; }
        //}

        //public Customer Customer
        //{
        //    set { _Customer = value; }
        //}

        //public SaleOrder SaleOrder
        //{
        //    set { _SaleOrder = value; }
        //}

        //public string InvoiceNumber
        //{
        //    set { _InvoiceNumber = value; }
        //}

        //public DateTime InvoiceDate
        //{
        //    set { _InvoiceDate = value; }
        //}

        //public float TotalAmount
        //{
        //    set { _TotalAmount = value; }
        //}

        //public float DepositAmount
        //{
        //    set { _DepositAmount = value; }
        //}

        //public float DiscountPercentage
        //{
        //    set { _DiscountPercentage = value; }
        //}

        public void InializeInvoicePrinting()
        {
            var printPreviewDialog = 
                new PrintPreviewDialog
                {
                    WindowState = FormWindowState.Maximized,
                    FormBorderStyle = FormBorderStyle.None,
                    UseAntiAlias = true,
                    Document = _PrintDocument
                };

            if (AppContext.Counter != null)
                _PrintDocument.PrinterSettings.PrinterName = AppContext.Counter.BarCodePrinter;
            _PrintDocument.BeginPrint += printDoc_BeginPrint;
            _PrintDocument.PrintPage += printDocument_PrintPage;

            printPreviewDialog.ShowDialog();            

            _PrintDocument.BeginPrint -= printDoc_BeginPrint;
            _PrintDocument.PrintPage -= printDocument_PrintPage;
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            //int posX = 25;
            //int posY = 30;
            //int rowIndex = 0, colIndex = 0;
            //int incrementValue = 0;
            //var txtPosX = 0;

            //var latinFont = new Font("Arial", 11, FontStyle.Regular);
            //var khmerFont = new Font("Limon S1", 24, FontStyle.Regular);
            ////var pen = new Pen(Color.Black, 0.1f);

            //var solidBrush = new SolidBrush(Color.Black);
            //var marginLeft = e.MarginBounds.Left;
            //var marginRight = e.MarginBounds.Right;
            //var marginTop = e.MarginBounds.Top;
            //var marginBottom = e.MarginBounds.Bottom;            
            //var paperWidth = e.PageSettings.PaperSize.Width;

            ////Logo
            ////var logoCompany = Image.FromFile(Application.StartupPath + @"\logo.jpg");
            //var logoCompany = Resources.logo;
            //e.Graphics.DrawImage(logoCompany, posX, posY);

            ////Header
            //posY = 0;
            //khmerFont = new Font("Limon R1", 40, FontStyle.Regular);
            //var textToPrint = "lk;eRKÓgGKÁisnI";
            //txtPosX =
            //    Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, khmerFont).Width).ToString());
            //txtPosX = (paperWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint, 
            //    khmerFont, 
            //    Brushes.Black,
            //    txtPosX, 
            //    posY);

            //posY += 
            //    Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, khmerFont).Height).ToString()) - 10;
            //latinFont = new Font("Arial", 15, FontStyle.Bold);
            //textToPrint = "Electric Eco Cambodia Co., Ltd.";
            //txtPosX =
            //    Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Width).ToString());
            //txtPosX = (paperWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint,
            //    latinFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);

            ////Invoice
            ////Header
            //posY = 100;
            //khmerFont = new Font("Limon R1", 35, FontStyle.Regular);
            //textToPrint = "viká½yb½Rt";
            //txtPosX =
            //    Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Width).ToString());
            //txtPosX = (paperWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint, 
            //    khmerFont, 
            //    Brushes.Black, 
            //    txtPosX, 
            //    posY);

            //posY +=
            //    Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, khmerFont).Height).ToString()) - 10;
            //latinFont = new Font("Arial", 18, FontStyle.Bold);
            //textToPrint = "INVOICE";
            //txtPosX =
            //    Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Width).ToString());
            //txtPosX = (paperWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint,
            //    latinFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);

            ////Number
            //posY = 160;
            //latinFont = new Font("Arial", 11, FontStyle.Regular);
            //textToPrint = "No: " + _InvoiceNumber;
            //txtPosX =
            //    paperWidth -
            //    Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Width).ToString()) -
            //    52;
            //e.Graphics.DrawString(
            //    textToPrint, 
            //    latinFont, 
            //    Brushes.Black,
            //    txtPosX, 
            //    posY);

            ////Date
            //textToPrint = "Date: " + _InvoiceDate.ToShortDateString();
            //txtPosX =
            //    paperWidth -
            //    Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Width).ToString()) -
            //    52;
            //e.Graphics.DrawString(
            //    textToPrint, 
            //    latinFont, 
            //    Brushes.Black, 
            //    txtPosX, 
            //    posY + 20);

            ////Customer
            ////Name
            //textToPrint = "Customer name: " + _Customer.CustomerName;
            //e.Graphics.DrawString(textToPrint, latinFont, Brushes.Black, posX, posY);

            ////Address
            //posY += 20;
            //textToPrint = "Address: " + _Customer.Address;
            //e.Graphics.DrawString(textToPrint, latinFont, Brushes.Black, posX, posY);

            ////Purchased items
            ////Item header
            //posY = 200;
            //khmerFont = new Font("Limon S2", 26, FontStyle.Bold);
            //textToPrint = "l>r                        briyay                          cMnYn      tMélray     tMélsrub";
            //e.Graphics.DrawString(
            //    textToPrint, 
            //    khmerFont, 
            //    Brushes.Black, 
            //    posX + 10, 
            //    posY);

            //incrementValue = 
            //    Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, khmerFont).Height).ToString()) - 
            //    10;
            //latinFont = new Font("Arial", 12, FontStyle.Bold);
            //textToPrint = "No.                                    Description                                 Quantity       Unit Price         A. Price";
            //e.Graphics.DrawString(
            //    textToPrint, 
            //    latinFont, 
            //    Brushes.Black, 
            //    posX + 20, 
            //    posY + incrementValue);

            //var pen = new Pen(Color.Black, 0.1f);
            //incrementValue = 65;
            //posX = 25;
            //e.Graphics.DrawLine(pen, posX, posY, paperWidth - 52, posY);
            //e.Graphics.DrawLine(pen, posX, posY + incrementValue, paperWidth - 52, posY + incrementValue);
            //e.Graphics.DrawLine(pen, posX, posY, posX, posY + incrementValue);
            //posX = 94;
            //e.Graphics.DrawLine(pen, posX, posY, posX, posY + incrementValue);
            //posX = 480;
            //e.Graphics.DrawLine(pen, posX, posY, posX, posY + incrementValue);
            //posX = 570;
            //e.Graphics.DrawLine(pen, posX, posY, posX, posY + incrementValue);
            //posX = 685;
            //e.Graphics.DrawLine(pen, posX, posY, posX, posY + incrementValue);
            //posX = paperWidth - 52;
            //e.Graphics.DrawLine(pen, posX, posY, posX, posY + incrementValue);

            ////Items
            //posY += 70;
            //posX = 25;
            //e.Graphics.DrawLine(
            //    pen,
            //    posX,
            //    posY,
            //    paperWidth - 52,
            //    posY);

            //latinFont = new Font("Arial", 11, FontStyle.Regular);
            //var totalPrice = 0f;
            //for (var counter = 0; counter < 15; counter++)
            //{
            //    //foreach (SaleItem saleItem in _SaleItemList)
            //    //{
            //    SaleItem saleItem = null;
            //    if (counter < _SaleItemList.Count)
            //        saleItem = _SaleItemList[counter] as SaleItem;

            //    if(saleItem == null)
            //    {
            //        break;
            //    }

            //    if (saleItem.ProductID == 0)
            //        continue;

            //    //Counter
            //    posX = 30;
            //    _Counter += 1;
            //    textToPrint = _Counter.ToString();
            //    incrementValue =
            //        Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Width).ToString());
            //    incrementValue /= 2;
            //    incrementValue = 34 - incrementValue;
            //    e.Graphics.DrawString(
            //        textToPrint,
            //        latinFont,
            //        Brushes.Black,
            //        posX + incrementValue,
            //        posY + 8);

            //    //Product name
            //    posX = 100;
            //    textToPrint = saleItem.ProductName;
            //    e.Graphics.DrawString(
            //        textToPrint,
            //        latinFont,
            //        Brushes.Black,
            //        posX,
            //        posY + 8);

            //    //Qty
            //    posX = 560;
            //    textToPrint = saleItem.QtySold.ToString("N2", AppContext.CultureInfo);
            //    e.Graphics.DrawString(
            //        textToPrint,
            //        latinFont,
            //        Brushes.Black,
            //        posX - e.Graphics.MeasureString(textToPrint, latinFont).Width,
            //        posY + 8);

            //    //UnitPrice
            //    posX = 675;
            //    textToPrint = Math.Round(saleItem.UnitPriceOut, 2).ToString("N2", AppContext.CultureInfo);
            //    e.Graphics.DrawString(
            //        textToPrint,
            //        latinFont,
            //        Brushes.Black,
            //        posX - e.Graphics.MeasureString(textToPrint, latinFont).Width,
            //        posY + 8);

            //    //SubTotal
            //    posX = 790;
            //    var subTotal = saleItem.QtySold * saleItem.UnitPriceOut;
            //    totalPrice += subTotal;
            //    textToPrint = Math.Round(subTotal, 2).ToString("N2", AppContext.CultureInfo);
            //    e.Graphics.DrawString(
            //        textToPrint,
            //        latinFont,
            //        Brushes.Black,
            //        posX - e.Graphics.MeasureString(textToPrint, latinFont).Width,
            //        posY + 8);

            //    //Separator
            //    //Line counter
            //    incrementValue +=
            //        Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Height).ToString()) -
            //        8;
            //    posX = 25;
            //    e.Graphics.DrawLine(
            //        pen,
            //        posX,
            //        posY,
            //        posX,
            //        posY + incrementValue);
            //    //Line product
            //    posX = 94;
            //    e.Graphics.DrawLine(
            //        pen,
            //        posX,
            //        posY,
            //        posX,
            //        posY + incrementValue);
            //    //Line quantity
            //    posX = 480;
            //    e.Graphics.DrawLine(
            //        pen,
            //        posX,
            //        posY,
            //        posX,
            //        posY + incrementValue);
            //    //Line unit price
            //    posX = 570;
            //    e.Graphics.DrawLine(
            //        pen,
            //        posX,
            //        posY,
            //        posX,
            //        posY + incrementValue);
            //    //Line sub total
            //    posX = 685;
            //    e.Graphics.DrawLine(
            //        pen,
            //        posX,
            //        posY,
            //        posX,
            //        posY + incrementValue);
            //    //Line right margin
            //    posX = paperWidth - 52;
            //    e.Graphics.DrawLine(
            //        pen,
            //        posX,
            //        posY,
            //        posX,
            //        posY + incrementValue);

            //    posX = 25;
            //    posY +=
            //        Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Height).ToString()) +
            //        15;

            //    e.Graphics.DrawLine(
            //        pen,
            //        posX,
            //        posY,
            //        paperWidth - 52,
            //        posY);
            //    //}                
            //}
                
            //////Footer
            //////Remark

            ////Total amount
            //khmerFont = new Font("Limon R1", 23, FontStyle.Underline);
            //posY = marginBottom - 220;
            //textToPrint = "sMKal;";
            //e.Graphics.DrawString(
            //    textToPrint,
            //    khmerFont,
            //    Brushes.Black,
            //    posX,
            //    posY);

            //posY +=
            //    Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, khmerFont).Height).ToString()) - 10;
            //khmerFont = new Font("Limon S2", 22, FontStyle.Regular);
            //textToPrint = "TMnijTijrYcehIyminGacdUr)aneT .";
            //e.Graphics.DrawString(
            //    textToPrint,
            //    khmerFont,
            //    Brushes.Black,
            //    posX,
            //    posY);

            //posY +=
            //    Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, khmerFont).Height).ToString()) - 10;
            //latinFont = new Font("Arial", 11, FontStyle.Regular);
            //textToPrint = "Goods sold are not returnable.";
            //e.Graphics.DrawString(
            //    textToPrint,
            //    latinFont,
            //    Brushes.Black,
            //    posX + 5,
            //    posY);

            //posY +=
            //    Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Height).ToString());
            //textToPrint = "ral;plitplTaMgGs; nwgrkSasiT§Ca®TBüsm,tþi";
            //e.Graphics.DrawString(
            //    textToPrint,
            //    khmerFont,
            //    Brushes.Black,
            //    posX,
            //    posY);

            //posY +=
            //    Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, khmerFont).Height).ToString()) - 10;
            ////textToPrint = "rbs;RkumhunrhUtdl;bg;R)ak;RKb;cMnYn";
            //textToPrint = "rbs;Rkumh‘unrhUtdl;bg;R)ak;RKb;cMnYn";
            //e.Graphics.DrawString(
            //    textToPrint,
            //    khmerFont,
            //    Brushes.Black,
            //    posX,
            //    posY);

            //khmerFont = new Font("Limon R1", 26, FontStyle.Regular);
            //posY = marginBottom - 220;
            //textToPrint = "R)ak;srub";
            //e.Graphics.DrawString(
            //    textToPrint,
            //    khmerFont,
            //    Brushes.Black,
            //    posX + 350,
            //    posY);

            //latinFont = new Font("Arial", 11, FontStyle.Regular);
            //posY = marginBottom - 207;
            //txtPosX = 480;
            //textToPrint = "TOTAL";
            //e.Graphics.DrawString(
            //    textToPrint,
            //    latinFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);

            //posY = marginBottom - 185;
            //textToPrint = "R)ak;kk;";
            //e.Graphics.DrawString(
            //    textToPrint,
            //    khmerFont,
            //    Brushes.Black,
            //    posX + 350,
            //    posY);

            //posY = marginBottom - 172;
            //txtPosX = 480;
            //textToPrint = "DEPOSIT";
            //e.Graphics.DrawString(
            //    textToPrint,
            //    latinFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);

            //posY = marginBottom - 150;
            //textToPrint = "R)ak;enAxVH";
            //e.Graphics.DrawString(
            //    textToPrint,
            //    khmerFont,
            //    Brushes.Black,
            //    posX + 350,
            //    posY);

            //posY = marginBottom - 137;
            //txtPosX = 480;
            //textToPrint = "BALANCE";
            //e.Graphics.DrawString(
            //    textToPrint,
            //    latinFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);

            //e.Graphics.DrawLine(
            //    pen, paperWidth - 52, marginBottom - 220, paperWidth - 52, marginBottom - 110);
            //e.Graphics.DrawLine(
            //    pen, 570, marginBottom - 220, 570, marginBottom - 110);
            //e.Graphics.DrawLine(
            //    pen, 570, marginBottom - 183, paperWidth - 52, marginBottom - 183);
            //e.Graphics.DrawLine(
            //    pen, 570, marginBottom - 145, paperWidth - 52, marginBottom - 145);
            //e.Graphics.DrawLine(
            //    pen, 570, marginBottom - 110, paperWidth - 52, marginBottom - 110);
            
            ////Signature
            //var recWidth = (e.MarginBounds.Left + e.MarginBounds.Right) / 5;
            //posY = marginBottom - 80;
            //posX = 10;
            //textToPrint = "Gñk®Kb;®Kg";
            //txtPosX = Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, khmerFont).Width).ToString());
            //txtPosX = posX + (recWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint,
            //    khmerFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);

            //posX += recWidth - 10;
            //textToPrint = "Gñk®bKl;";
            //txtPosX = Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, khmerFont).Width).ToString());
            //txtPosX = posX + (recWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint,
            //    khmerFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);

            //posX += recWidth - 10;
            //textToPrint = "GñkXøaMg";
            //txtPosX = Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, khmerFont).Width).ToString());
            //txtPosX = posX + (recWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint,
            //    khmerFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);

            //posX += recWidth - 5;
            //textToPrint = "GñkebIkbr";
            //txtPosX = Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, khmerFont).Width).ToString());
            //txtPosX = posX + (recWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint,
            //    khmerFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);

            //posX += recWidth;
            //textToPrint = "GñkTTYl";
            //txtPosX = Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, khmerFont).Width).ToString());
            //txtPosX = posX + (recWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint,
            //    khmerFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);

            //posY += 
            //    Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, khmerFont).Height).ToString()) - 5;
            //posX = 10;
            //textToPrint = "Manager";
            //txtPosX = Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Width).ToString());
            //txtPosX = posX + (recWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint,
            //    latinFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);

            //posX += recWidth - 10;
            //textToPrint = "Delivered by";
            //txtPosX = Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Width).ToString());
            //txtPosX = posX + (recWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint,
            //    latinFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);
            
            //posX += recWidth - 10;
            //textToPrint = "Warehouse";
            //txtPosX = Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Width).ToString());
            //txtPosX = posX + (recWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint,
            //    latinFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);
            
            //posX += recWidth;
            //textToPrint = "Driver";
            //txtPosX = Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Width).ToString());
            //txtPosX = posX + (recWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint,
            //    latinFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);
            
            //posX += recWidth - 5;
            //textToPrint = "Received by";
            //txtPosX = Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Width).ToString());
            //txtPosX = posX + (recWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint,
            //    latinFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);

            //posY = marginBottom + 50;
            //posX = 10;
            //textToPrint = "..............................";
            //txtPosX = Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Width).ToString());
            //txtPosX = posX + (recWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint,
            //    latinFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);

            //posX += recWidth - 10;
            //textToPrint = "..............................";
            //txtPosX = Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Width).ToString());
            //txtPosX = posX + (recWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint,
            //    latinFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);

            //posX += recWidth - 10;
            //textToPrint = "..............................";
            //txtPosX = Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Width).ToString());
            //txtPosX = posX + (recWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint,
            //    latinFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);

            //posX += recWidth;
            //textToPrint = "..............................";
            //txtPosX = Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Width).ToString());
            //txtPosX = posX + (recWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint,
            //    latinFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY);

            //posX += recWidth - 5;
            //textToPrint = "..............................";
            //txtPosX = Int32.Parse(Math.Round(e.Graphics.MeasureString(textToPrint, latinFont).Width).ToString());
            //txtPosX = posX + (recWidth - txtPosX) / 2;
            //e.Graphics.DrawString(
            //    textToPrint,
            //    latinFont,
            //    Brushes.Black,
            //    txtPosX,
            //    posY); 
            //e.HasMorePages = false;
        }

        private static void printDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            try
            {
                //_StrFormat = 
                //    new StringFormat
                //    {
                //        Alignment = StringAlignment.Near,
                //        LineAlignment = StringAlignment.Center,
                //        Trimming = StringTrimming.EllipsisCharacter
                //    };

                //_Counter = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExcelInvoicePrintingHandler(
            string printerName, 
            string fileName, 
            string protectedPassword,
            string customerName,
            string customerAddress,
            string invoiceNumber,
            DateTime invoiceDate,
            float discountPercentage,
            float depositAmount,
            float paidAmount,
            IList invoiceItemList,
            bool isDeposit)
        {
            if (string.IsNullOrEmpty(printerName))
                throw new ArgumentNullException("printerName", string.Empty);

            var excelApplication = new ExcelApplication();
            try
            {
                //Open workbook
                var workBook = excelApplication.Workbooks.Open(
                    fileName,
                    0,
                    false,
                    5,
                    protectedPassword,
                    string.Empty,
                    false,
                    XlPlatform.xlWindows,
                    string.Empty,
                    true,
                    false,
                    0,
                    true,
                    false,
                    false);

                //Invoice content
                var workSheet = (Worksheet)workBook.Worksheets["Invoice"];

                //Customer name
                var rowIndex = 8;
                var excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = "Customer name: " + customerName;

                //Invoice number
                excelRange = workSheet.get_Range("L" + rowIndex, "L" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = invoiceNumber;

                //Customer address
                rowIndex += 1;
                excelRange = workSheet.get_Range("A" + rowIndex, "A" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = "Address: " + customerAddress;

                //Invoice date
                excelRange = workSheet.get_Range("L" + rowIndex, "L" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = invoiceDate;

                //Invoice item
                rowIndex += 4;
                var totalAmount = 0f;
                foreach (SaleItem saleItem in invoiceItemList)
                {
                    if(saleItem == null)    
                        continue;

                    if(saleItem.ProductID == 0)
                        continue;

                    //Product
                    var productName = saleItem.ProductName;
                    if (saleItem.FKProduct != null)
                        productName += " (" + saleItem.FKProduct.ForeignCode + ")";
                    excelRange = workSheet.get_Range("B" + rowIndex, "B" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = productName;

                    //Quantity
                    excelRange = workSheet.get_Range("I" + rowIndex, "I" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = saleItem.QtySold;

                    //Unit price out
                    excelRange = workSheet.get_Range("J" + rowIndex, "J" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = saleItem.UnitPriceOut;

                    //Discount
                    excelRange = workSheet.get_Range("K" + rowIndex, "K" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = saleItem.Discount;

                    //Sub total
                    var subTotal = 
                        saleItem.UnitPriceOut -
                        ((saleItem.UnitPriceOut * saleItem.Discount) / 100);
                    subTotal *= saleItem.QtySold;
                    excelRange = workSheet.get_Range("L" + rowIndex, "L" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = subTotal;

                    totalAmount += subTotal;
                    rowIndex += 1;
                }
                
                //Total amount
                rowIndex = 28;
                excelRange = workSheet.get_Range("J" + rowIndex, "J" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = totalAmount;

                //Overall discount
                rowIndex += 1;
                excelRange = workSheet.get_Range("J" + rowIndex, "J" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = discountPercentage / 100;

                //Deposit amount
                rowIndex += 1;
                excelRange = workSheet.get_Range("J" + rowIndex, "J" + rowIndex);
                excelRange.Select();
                excelRange.Value2 = depositAmount;

                //Balance amount
                rowIndex += 1;
                totalAmount -= (totalAmount * discountPercentage) / 100;
                if (isDeposit)
                {
                    var balanceAmount = totalAmount;
                    balanceAmount -= depositAmount;
                    excelRange = workSheet.get_Range("J" + rowIndex, "J" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = balanceAmount;
                }
                else
                {
                    excelRange = workSheet.get_Range("J" + rowIndex, "J" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = paidAmount;                    

                    rowIndex += 1;
                    excelRange = workSheet.get_Range("J" + rowIndex, "J" + rowIndex);
                    excelRange.Select();
                    excelRange.Value2 = (depositAmount + paidAmount) - totalAmount;
                }

                //Print workbook
                workBook.PrintOut(
                    1,
                    1,
                    1,
                    false,
                    printerName,
                    false,
                    false,
                    string.Empty);
                //excelApplication.Visible = true;
                //workBook.PrintPreview(true);

                //Close workbook
                workBook.Close(
                    false,
                    fileName,
                    0);
            }
            finally
            {
                excelApplication.Workbooks.Close();
            }
        }
    }
}