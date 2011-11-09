
namespace EzPos.Model.Payments
{
    /// <summary>
    /// Summary description for Payment.
    /// </summary>
    public class Payment
    {
        public const string ConstPaymentId = "PaymentId";
        public const string ConstPaymentDate = "PaymentDate";
        public const string ConstSaleOrderId = "SaleOrderId";

        public int PaymentId { get; set; }

        public object PaymentDate { get; set; }

        public float PaymentAmount { get; set; }

        public int SalesOrderId { get; set; }

        public int CashierId { get; set; }
        
        public string CashierName
        {
            get
            {
                return FkCashier != null ? FkCashier.LogInName : string.Empty;
            }
        }

        public string Remark { get; set; }

        public SaleOrder.SaleOrder FkSaleOrder { get; set; }

        public User.User FkCashier { get; set; }
    }
}