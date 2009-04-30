namespace EzPos.Model
{
    /// <summary>
    /// Summary description for SalesOrder.
    /// </summary>
    public class SaleOrder
    {
        public const string CONST_SALE_ORDER_ID = "SaleOrderID";
        public const string CONST_SALE_ORDER_NUMBER = "SaleOrderNumber";

        public int SaleOrderID { get; set; }

        public string SaleOrderNumber { get; set; }

        public int CustomerID { get; set; }

        public int RecorderID { get; set; }

        public object DateOut { get; set; }

        public int DelivererID { get; set; }

        public float AmountSold { get; set; }

        public float AmountPaid { get; set; }

        public float AmountReturn { get; set; }

        public float Discount { get; set; }

        public int WholeRetail { get; set; }

        public int CounterID { get; set; }
    }
}