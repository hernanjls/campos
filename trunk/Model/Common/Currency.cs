namespace EzPos.Model
{
    public class Currency
    {
        public const string CONST_CURRENCY_ID = "CurrencyID";
        public const string CONST_CURRENCY_NAME = "CurrencyName";

        public int CurrencyID { get; set; }

        public string CurrencyCode { get; set; }

        public string CurrencyName { get; set; }

        public string CurrencySymbol { get; set; }
    }
}