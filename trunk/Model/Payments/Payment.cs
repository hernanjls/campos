
namespace EzPos.Model.Payments
{
    /// <summary>
    /// Summary description for Payment.
    /// </summary>
    public class Payment
    {
        public const string CONST_PAYMENT_ID = "PaymentId";
        public const string CONST_PAYMENT_DATE = "PaymentDate";
        public const string CONST_SALE_ORDER_ID = "SalesOrderId";

        public int PaymentId { get; set; }

        public object PaymentDate { get; set; }

        public float PaymentAmount { get; set; }

        public int SalesOrderId { get; set; }

        public int CashierId { get; set; }
        
        public string CashierName
        {
            get
            {
                return FKCashier != null ? FKCashier.LogInName : string.Empty;
            }
        }

        public string Remark { get; set; }

        public SaleOrder FKSaleOrder { get; set; }

        public User FKCashier { get; set; }
    }
}