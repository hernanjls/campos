namespace EzPos.Model.Customer
{
    /// <summary>
    /// Summary description for Customer.
    /// </summary>
    public class Customer
    {
        public const string ConstCustomerId = "CustomerId";
        public const string ConstCustomerName = "CustomerName";
        public const string ConstCustomerDisplayName = "DisplayName";

        public int CustomerId { get; set; }

        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }

        public string LocalName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string Website { get; set; }

        public int GenderId { get; set; }

        public string GenderStr { get; set; }

        public float PurchasedAmount { get; set; }

        public float DebtAmount { get; set; }

        public string DiscountCardNumber { get; set; }

        public float DiscountPercentage { get; set; }

        public string DiscountCardType { get; set; }

        public DiscountCard FkDiscountCard { get; set; }

        public int DiscountRejected { get; set; }

        public string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(LocalName))
                    return string.IsNullOrEmpty(CustomerName) ? string.Empty : CustomerName;
                
                return
                    (string.IsNullOrEmpty(CustomerName) ? string.Empty : CustomerName) + 
                    " (" +
                    (string.IsNullOrEmpty(LocalName) ? string.Empty : LocalName) + 
                    ")";
            }
        }
    }
}