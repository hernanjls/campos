namespace EzPos.Model
{
    /// <summary>
    /// Summary description for Country.
    /// </summary>
    public class Country
    {
        public const string CONST_COUNTRY_ID = "CountryID";
        public const string CONST_COUNTRY_NAME = "CountryName";

        public int CountryID { get; set; }

        public string CountryName { get; set; }
    }
}