namespace EzPos.Model
{
    /// <summary>
    /// Summary description for Customer.
    /// </summary>
    public class Customer
    {
        public const string CONST_CUSTOMER_ID = "CustomerID";
        public const string CONST_CUSTOMER_NAME = "CustomerName";

        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerCode { get; set; }

        public string DisplayName { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public float AmountDebt { get; set; }
    }
}