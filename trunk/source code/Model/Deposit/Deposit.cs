
namespace EzPos.Model.Deposit
{
    /// <summary>
    /// Summary description for SalesOrder.
    /// </summary>
    public class Deposit
    {
        public const string ConstDepositId = "DepositId";
        public const string ConstDepositNumber = "DepositNumber";
        public const string ConstDepositDate = "DepositDate";

        public int DepositId { get; set; }

        public string DepositNumber { get; set; }

        public object DepositDate { get; set; }

        public int DepositTypeId { get; set; }

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

        public string ReferenceNum { get; set; }

        public object UpdateDate { get; set; }

        public Customer.Customer FkCustomer { get; set; }

        public User.User FkCashier { get; set; }

        public string CashierName
        {
            get
            {
                return FkCashier != null ? FkCashier.LogInName : string.Empty;
            }
        }

        public string CustomerName
        {
            get
            {
                return FkCustomer != null ? FkCustomer.CustomerName : string.Empty;
            }
        }
    }
}