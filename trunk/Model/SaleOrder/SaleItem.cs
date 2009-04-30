using System;

namespace EzPos.Model
{
    /// <summary>
    /// Summary description for SalesItem.
    /// </summary>
    public class SaleItem
    {
        public const string CONST_PRODUCT_ID = "ProductID";
        public const string CONST_SALE_ORDER_ID = "SaleOrderID";

        //Foreign keys

        public int SaleItemID { get; set; }

        public int SaleOrderID { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string BarCodeValue { get; set; }

        public string QtyOutStr { get; set; }

        public float QtyOut { get; set; }

        public int UnitID { get; set; }

        public float UnitPriceIn { get; set; }

        public float UnitPriceOut { get; set; }

        public float SubTotal { get; set; }

        public int OrderID { get; set; }

        public DateTime DateOut { get; set; }

        public Product FKProduct { get; set; }

        public SaleOrder FKSaleOrder { get; set; }

        public string SaleOrderNumber { get; set; }
    }
}