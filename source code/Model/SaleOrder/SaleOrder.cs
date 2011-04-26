namespace EzPos.Model
{
    /// <summary>
    /// Summary description for SalesOrder.
    /// </summary>
    public class SaleOrder
    {
        public const string CONST_SALE_ORDER_ID = "SaleOrderId";
        public const string CONST_SALE_ORDER_DATE = "SaleOrderDate";
        public const string CONST_SALE_ORDER_NUMBER = "SaleOrderNumber";

        public int SaleOrderId { get; set; }

        public string SaleOrderNumber { get; set; }

        public object SaleOrderDate { get; set; }

        public int SaleOrderTypeID { get; set; }

        public int CustomerID { get; set; }

        public int CashierId { get; set; }

        public int DelivererID { get; set; }

        public string Description { get; set; }

        public int PaymentTypeID { get; set; }

        public int CurrencyID { get; set; }

        public float ExchangeRate { get; set; }

        public float AmountSoldInt { get; set; }

        public float AmountSoldRiel { get; set; }

        public float AmountPaidInt { get; set; }

        public float AmountPaidRiel { get; set; }

        public float AmountReturnInt { get; set; }

        public float AmountReturnRiel { get; set; }

        public float Discount { get; set; }

        public int DiscountTypeID { get; set; }

        public string CardNumber { get; set; }

        public Customer FKCustomer { get; set; }

        public string ReferenceNum { get; set; }

        public float DepositAmount { get; set; }
    }
}