namespace EzPos.Model
{
    /// <summary>
    /// Summary description for Laboratory.
    /// </summary>
    public class Laboratory
    {
        public const string CONST_LABORATORY_ID = "LaboratoryID";
        public const string CONST_LABORATORY_NAME = "LaboratoryName";

        public int LaboratoryID { get; set; }

        public string LaboratoryName { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public int CountryID { get; set; }
    }
}