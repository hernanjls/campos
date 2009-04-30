namespace EzPos.Model
{
    /// <summary>
    /// Summary description for PurchaseItem.
    /// </summary>
    public class PurchaseOrderReport
    {
        public const string CONST_PO_DATE = "PurchaseOrderDate";
        public const string CONST_PO_ID = "PurchaseOrderID";
        public const string CONST_PO_NUMBER = "PurchaseOrderNumber";
        public const string CONST_PRODUCT_NAME = "ProductName";

        public int RowID { get; set; }

        public int PurchaseOrderID { get; set; }

        public string PurchaseOrderNumber { get; set; }

        public string PurchaseOrderDate { get; set; }

        public string PaymentDate { get; set; }

        public float AmountStandard { get; set; }

        public int SupplierID { get; set; }

        public string SupplierName { get; set; }

        public float AmountPaid { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string BarCodeValue { get; set; }

        public string DateIn { get; set; }

        public string DateExpire { get; set; }

        public float Quantity { get; set; }

        public float UnitPrice { get; set; }

        public int ProductUnitID { get; set; }

        public string ProductUnitName { get; set; }

        public int CellID { get; set; }

        public string CellName { get; set; }

        public string PaidStatus { get; set; }

        public float AmountStandardDuplicate { get; set; }

        public float AmountPaidDuplicate { get; set; }
    }
}