namespace EzPos.Model
{
    /// <summary>
    /// Summary description for PurchaseOrder.
    /// </summary>
    public class PurchaseOrder
    {
        public const string CONST_PURCHASE_ORDER_ID = "PurchaseOrderID";
        public const string CONST_PURCHASE_ORDER_NUMBER = "PurchaseOrderNumber";

        //Foreign keys

        public int PurchaseOrderID { get; set; }

        public string PurchaseOrderNumber { get; set; }

        public object PurchaseOrderDate { get; set; }

        public object DeliveryDate { get; set; }

        public object PaymentDate { get; set; }

        public int CurrencyID { get; set; }

        public float ExchangeRate { get; set; }

        public float AmountCurrency { get; set; }

        public float AmountStandard { get; set; }

        public int StatusID { get; set; }

        public int SupplierID { get; set; }

        public int PaymentTermID { get; set; }

        public string Description { get; set; }

        public float Discount { get; set; }

        public float AmountPaid { get; set; }

        public Currency FKCurrency { get; set; }

        public PurchaseOrderStatus FKPurchaseOrderStatus { get; set; }

        public Supplier FKSupplier { get; set; }

        public PaymentTerm FKPaymentTerm { get; set; }
    }
}