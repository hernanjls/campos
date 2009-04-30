namespace EzPos.Model
{
    /// <summary>
    /// Summary description for Supplier.
    /// </summary>
    public class Supplier
    {
        public const string CONST_SUPPLIER_ID = "SupplierID";
        public const string CONST_SUPPLIER_NAME = "SupplierName";

        public int SupplierID { get; set; }

        public string SupplierName { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }
    }
}