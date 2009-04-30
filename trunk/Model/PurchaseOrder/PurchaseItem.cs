namespace EzPos.Model
{
    /// <summary>
    /// Summary description for PurchaseItem.
    /// </summary>
    public class PurchaseItem
    {
        public const string CONST_BAR_CODE_VALUE = "BarCodeValue";
        public const string CONST_PRODUCT_ID = "ProductID";
        public const string CONST_PURCHASE_ITEM_ID = "PurchaseItemID";
        public const string CONST_PURCHASE_ORDER_ID = "PurchaseOrderID";

        //private float _DbQuantity;
        //Foreign keys

        public int PurchaseItemID { get; set; }

        public int PurchaseOrderID { get; set; }

        public int ProductID { get; set; }

        public string BarCodeValue { get; set; }

        public object DateIn { get; set; }

        public object DateExpire { get; set; }

        public float Quantity { get; set; }

        public float UnitPrice { get; set; }

        public int ProductUnitID { get; set; }

        public int CellID { get; set; }

        public float QtyOut { get; set; }

        public float SubTotal { get; set; }

        public int SupplierID { get; set; }

        public PurchaseOrder FKPurchaseOrder { get; set; }
    }
}