using System;

namespace EzPos.Model
{
    public class SaleOrderReport
    {
        public const string CONST_SALE_ORDER_DATE = "SaleOrderDate";
        public const string CONST_SALE_ORDER_NUMBER = "SaleOrderNumber";

        //private string _SaleOrderNumber;

        public int ReportID { get; set; }

        public int SalesOrderId { get; set; }

        public string SaleOrderNumber
        {
            get; set;
            //{
            //    var saleOrderNumber = _SaleOrderNumber;
            //    if(!string.IsNullOrEmpty(ReferenceNum))
            //        saleOrderNumber += " (" + ReferenceNum + ")";

            //    return saleOrderNumber;
            //}
            //set
            //{
            //    _SaleOrderNumber = value;
            //}
        }

        public DateTime SaleOrderDate { get; set; }

        public string CustomerName { get; set; }

        public string CashierName { get; set; }

        public float ExchangeRate { get; set; }

        public float AmountSoldInt { get; set; }

        public float AmountPaidInt { get; set; }

        public float AmountPaidRiel { get; set; }

        public float AmountReturnInt { get; set; }

        public float AmountReturnRiel { get; set; }

        public float TotalDiscount { get; set; }

        public string ProductName { get; set; }

        public float UnitPriceIn { get; set; }

        public float UnitPriceOut { get; set; }

        public float Discount { get; set; }

        public float QtySold { get; set; }

        public float SubTotal { get; set; }

        public int CustomerID { get; set; }

        public int SaleItemID { get; set; }

        public int ProductID { get; set; }

        public int DiscountTypeID { get; set; }

        public string CardNumber { get; set; }

        public int ReportHeader { get; set; }

        public string ReferenceNum { get; set; }

        public string ReportTypeStr { get; set; }

        public float DepositAmount { get; set; }

        public string ProductCode { get; set; }
    }
}