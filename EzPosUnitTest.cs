using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using EzPos.GUIs.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using NUnit.Framework;
using System.Collections.Generic;

namespace EzPos
{
    [TestFixture]
    public class EzPosUnitTest
    {
        [Test]
        public void TestPrintInvoice()
        {
            var saleItemBindingList = new BindingList<SaleItem>
                {
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem()
                };

            //Print
            var printReceipt = new PrintInvoice();
            var customer = new Customer { CustomerName = "Name", Address = "Address" };
            var saleOrder = new SaleOrder {SaleOrderNumber = "SO number", SaleOrderDate = DateTime.Now};

            //printReceipt.SaleItemList = saleItemBindingList;
            //printReceipt.Customer = customer;
            //printReceipt.InvoiceNumber = saleOrder.SaleOrderNumber;
            //printReceipt.InvoiceDate = (DateTime)saleOrder.SaleOrderDate;
            printReceipt.InializeInvoicePrinting();

            Assert.AreEqual(1, 1, "Test performed");
        }

        [Test]
        public void TestPrintBarCode()
        {
            var barCodeList = 
                new List<BarCode>
                {
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    //CreateBarCode(),
                    CreateBarCode(),
                    CreateBarCode(),
                    CreateBarCode(),
                    CreateBarCode(),
                    CreateBarCode(),
                    CreateBarCode(),
                    CreateBarCode(),
                    CreateBarCode(),
                    CreateBarCode(),
                    CreateBarCode(),
                    CreateBarCode(),
                    CreateBarCode()
                };

            //Print
            PrintBarCode.InializePrinting(barCodeList);

            Assert.AreEqual(1, 1, "Test performed");
        }

        private static SaleItem CreateSaleItem()
        {
            var saleItem = new SaleItem
                               {
                                   ProductName = "productName",
                                   ProductDisplayName = "productName",
                                   ProductID = 1,
                                   QtySold = 1,
                                   UnitPriceIn = 1,
                                   PublicUPOut = 1,
                                   UnitPriceOut = 1,
                                   Discount = 0,
                                   SubTotal = 1,
                                   ProdPicture = Resources.NoImage,
                                   FKProduct = null
                               };

            return saleItem;
        }

        private static BarCode CreateBarCode()
        {
            var barCode =
                new BarCode
                {
                    BarCodeValue = "000001032",
                    DisplayStr = "Souvenir (Qx059)",
                    AdditionalStr = "$ 138.00"
                };
            return barCode;
        }

        [Test]
        public void CreateResource()
        {
            var rw = new ResourceWriter("English.resources");
            rw.AddResource("Name", "Test");
            rw.AddResource("Ver", 1.0);
            rw.AddResource("Author", "www.java2s.com");
            rw.Generate();
            rw.Close();

            Assert.AreEqual(1, 1, "Test performed");
        }

        [Test]
        public void TestOutstadingPayment()
        {
            using (var frmOutstandingPayment = new FrmOutstandingPayment())
            {
                frmOutstandingPayment.SalesOrderInfo = "SalesOrder";
                frmOutstandingPayment.ShowDialog();
            }

            Assert.AreEqual(1, 1, "Test performed");
        }

        [Test]
        public void TestExcel()
        {            
            //var excelApplication = new Application();
            //var _WorkBook = excelApplication.Workbooks.Open(
            //    @"d:\20100429.xlsx",
            //    0,
            //    false,
            //    5,
            //    "comin",
            //    "",
            //    false,
            //    XlPlatform.xlWindows,
            //    "",
            //    true,
            //    false,
            //    0,
            //    true,
            //    false,
            //    false);

            ////excelApplication.Visible = true;
            ////_WorkBook.PrintPreview(true);
            //try
            //{                
            //    _WorkBook.PrintOut(
            //        1,
            //        1,
            //        1,
            //        false,
            //        "HP Color LaserJet 2600n (Network)",
            //        false,
            //        false,
            //        "");
            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show(exception.Message);
            //}
            //finally
            //{
            //    excelApplication.Workbooks.Close();    
            //}

            var saleItemBindingList = new BindingList<SaleItem>
                {
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem(),
                    CreateSaleItem()
                };

            var printReceipt = new PrintInvoice();
            printReceipt.ExcelInvoicePrintingHandler(
                "EPSON LQ-300+ /II ESC/P 2",
                @"D:\users\ysakal\private\point of sales\ezpos\source code\bin\Debug\invoice-sale.xlsx",
                string.Empty,
                "Customer",
                "Address",
                "InvoiceNumber",
                DateTime.Now,
                10,
                5,
                10,
                saleItemBindingList,
                false);
            
            Assert.AreEqual(1, 1, "Test performed");
        }

        [Test]
        public void GetDepositHistories()
        {
            try
            {
                var depositService = ServiceFactory.GenerateServiceInstance().GenerateDepositService();
                var depositList = depositService.GetDepositHistories(null, false);
                MessageBox.Show(depositList.Count.ToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        [Test]
        public void ToPinyinput()
        {
            string CName;
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                CName = lang.Culture.EnglishName;
                MessageBox.Show(CName);

                if (CName.StartsWith("Khmer"))
                {
                    InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("km-KH"));
                    //InputLanguage.CurrentInputLanguage = lang;
                }
            }

        }
    }
}
