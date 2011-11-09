namespace EzPos.Model.Supplier
{
    /// <summary>
    /// Summary description for Customer.
    /// </summary>
    public class Supplier
    {
        public const string ConstSupplierId = "SupplierId";
        public const string ConstSupplierName = "SupplierName";

        public int SupplierId { get; set; }

        public string SupplierCode { get; set; }

        public string SupplierName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public string EmailAddress { get; set; }

        public string Website { get; set; }

        public int CountryId { get; set; }

        public string CountryStr { get; set; }

        public string BankInformation { get; set; }
    }
}