using System;

namespace EzPos.Model.Common
{
    public class ExchangeRate
    {
        public int ExchangeRateId { get; set; }

        public int FromCurrencyId { get; set; }

        public int ToCurrencyId { get; set; }

        public float ExchangeValue { get; set; }

        public DateTime ExchangeDateTime { get; set; }
    }
}