namespace EzPos.Model
{
    /// <summary>
    /// Summary description for SupplierContact.
    /// </summary>
    public class SupplierContact
    {
        public const string CONST_CONTACT_ID = "ContactID";
        public const string CONST_CONTACT_NAME = "ContactName";

        public int ContactID { get; set; }

        public string ContactName { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public int SupplierID { get; set; }
    }
}