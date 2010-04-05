using System;

namespace EzPos.Model
{
    public class ExchangeRate
    {
        public int ExchangeRateID { get; set; }

        public int FromCurrencyID { get; set; }

        public int ToCurrencyID { get; set; }

        public float ExchangeValue { get; set; }

        public DateTime ExchangeDateTime { get; set; }
    }
}