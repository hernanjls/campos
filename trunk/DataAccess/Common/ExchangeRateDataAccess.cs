using System.Collections;
using System.Collections.ObjectModel;
using EzPos.Model;
using NHibernate.Expression;

namespace EzPos.DataAccess.Common
{
    public class ExchangeRateDataAccess : BaseDataAccess
    {
        public virtual IList GetCurrencies()
        {
            var orderCollection = new Collection<Order> {Order.Asc(Currency.CONST_CURRENCY_NAME)};

            return SelectObjects(typeof (Currency), orderCollection).List();
        }

        public virtual IList GetExchangeRates()
        {
            var orderCollection = new Collection<Order> {Order.Asc("ExchangeRateID")};

            return SelectObjects(typeof (ExchangeRate),
                                 orderCollection).List();
        }

        public virtual IList GetExchangeRates(string currencyCode)
        {
            var criterionCollection = new Collection<ICriterion>
                                          {
                                              Expression.Sql(
                                                  "FromCurrencyID IN (SELECT CurrencyID  FROM TCurrencies WHERE CurrencyCode = '" +
                                                  currencyCode + "')")
                                          };

            var orderCollection = new Collection<Order> {Order.Asc("ExchangeRateID")};

            return SelectObjects(typeof(ExchangeRate), criterionCollection, orderCollection).List();
        }

        public virtual ExchangeRate GetLastExchangeRate()
        {
            var orderCollection = new Collection<Order> {Order.Desc("ExchangeRateID")};

            return (ExchangeRate) SelectObjects(
                                      typeof (ExchangeRate),
                                      orderCollection).UniqueResult();
        }

        public virtual IList GetLastExchangeRate(int currencyID)
        {
            var criterionCollection = new Collection<ICriterion> {Expression.Eq("FromCurrencyID", currencyID)};

            var orderCollection = new Collection<Order> {Order.Desc("ExchangeRateID")};

            return SelectObjects(typeof(ExchangeRate), criterionCollection, orderCollection).List();
        }

        public virtual void InsertExchangeRate(ExchangeRate exchangeRate)
        {
            InsertObject(exchangeRate);
        }

        //Payment term
        public virtual IList GetPaymentTerms()
        {
            var orderCollection = new Collection<Order> {Order.Asc(PaymentTerm.CONST_PAYMENT_TERM_NAME)};

            return SelectObjects(typeof(PaymentTerm), orderCollection).List();
        }
    }
}