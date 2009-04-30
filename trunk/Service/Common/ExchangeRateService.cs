using System;
using System.Collections;
using EzPos.DataAccess.Common;
using EzPos.Model;

namespace EzPos.Service.Common
{
    public class ExchangeRateService
    {
        private readonly ExchangeRateDataAccess _ExchangeRateDataAccess;

        public ExchangeRateService(ExchangeRateDataAccess exchangeRateDataAccess)
        {
            _ExchangeRateDataAccess = exchangeRateDataAccess;
        }

        public virtual IList GetCurrencies()
        {
            return _ExchangeRateDataAccess.GetCurrencies();
        }

        public virtual IList GetExchangeRates()
        {
            return _ExchangeRateDataAccess.GetExchangeRates();
        }

        public virtual IList GetExchangeRates(string currencyCode)
        {
            return _ExchangeRateDataAccess.GetExchangeRates(currencyCode);
        }

        public virtual ExchangeRate GetLastExchangeRate()
        {
            return _ExchangeRateDataAccess.GetLastExchangeRate();
        }

        public virtual ExchangeRate GetLastExchangeRate(int currencyID)
        {
            IList exchangeRateList = _ExchangeRateDataAccess.GetLastExchangeRate(currencyID);
            if (exchangeRateList != null)
                return (ExchangeRate) exchangeRateList[0];

            return null;
        }

        public virtual void InsertExchangeRate(ExchangeRate exchangeRate)
        {
            if (exchangeRate == null)
                throw new ArgumentNullException("exchangeRate", "ExchangeRate");

            _ExchangeRateDataAccess.InsertExchangeRate(exchangeRate);
        }

        public virtual IList GetPaymentTerms()
        {
            return _ExchangeRateDataAccess.GetPaymentTerms();
        }
    }
}