namespace EzPos.Model.SaleOrder
{
    /// <summary>
    /// Summary description for SalesOrder.
    /// </summary>
    public class SaleOrder
    {
        public const string ConstSaleOrderId = "SaleOrderId";
        public const string ConstSaleOrderDate = "SaleOrderDate";
        public const string ConstSaleOrderNumber = "SaleOrderNumber";

        public int SaleOrderId { get; set; }

        public string SaleOrderNumber { get; set; }

        public object SaleOrderDate { get; set; }

        public int SaleOrderTypeId { get; set; }

        public int CustomerId { get; set; }

        public int CashierId { get; set; }

        public int DelivererId { get; set; }

        public string Description { get; set; }

        public int PaymentTypeId { get; set; }

        public int CurrencyId { get; set; }

        public float ExchangeRate { get; set; }

        public float AmountSoldInt { get; set; }

        public float AmountSoldRiel { get; set; }

        public float AmountPaidInt { get; set; }

        public float AmountPaidRiel { get; set; }

        public float AmountReturnInt { get; set; }

        public float AmountReturnRiel { get; set; }

        public float Discount { get; set; }

        public int DiscountTypeId { get; set; }

        public string CardNumber { get; set; }

        public Customer.Customer FkCustomer { get; set; }

        public string ReferenceNum { get; set; }

        public float DepositAmount { get; set; }
    }
}