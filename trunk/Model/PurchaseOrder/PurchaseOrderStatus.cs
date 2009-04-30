namespace EzPos.Model
{
    public class PurchaseOrderStatus
    {
        public const string CONST_PURCHASE_ORDER_STATUS_ID = "PurchaseOrderStatusID";
        public const string CONST_PURCHASE_ORDER_STATUS_NAME = "PurchaseOrderStatusName";

        public int PurchaseOrderStatusID { get; set; }

        public string PurchaseOrderStatusName { get; set; }
    }
}