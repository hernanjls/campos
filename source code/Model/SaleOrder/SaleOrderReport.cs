using System;

namespace EzPos.Model.SaleOrder
{
    public class SaleOrderReport
    {
        public const string ConstSaleOrderDate = "SaleOrderDate";
        public const string ConstSaleOrderNumber = "SaleOrderNumber";
        public const string ConstSaleOrderProductCategory = "CategoryStr";

        //private string _SaleOrderNumber;

        public int ReportId { get; set; }

        public int SaleOrderId { get; set; }

        public string SaleOrderNumber
        {
            get; set;
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

        public int CustomerId { get; set; }

        public int SaleItemId { get; set; }

        public int ProductId { get; set; }

        public int DiscountTypeId { get; set; }

        public string CardNumber { get; set; }

        public int ReportHeader { get; set; }

        public string ReferenceNum { get; set; }

        public string ReportTypeStr { get; set; }

        public float DepositAmount { get; set; }

        public string ProductCode { get; set; }

        public string CategoryStr { get; set; }

        public float PurchaseUnitPrice { get; set; }
    
        public float QtyBonus { get; set; }
    }
}