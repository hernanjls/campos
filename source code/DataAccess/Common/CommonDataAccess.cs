using System.Collections;
using System.Collections.ObjectModel;
using EzPos.Model;
using EzPos.Utility;
using NHibernate.Expression;

namespace EzPos.DataAccess
{
    public class CommonDataAccess : BaseDataAccess
    {
        //Operation log
        public virtual void InsertOperationLog(OperationLog operationLog)
        {
            InsertObject(operationLog);
        }

        //Application parameters
        public virtual IList GetAppParameterTypes()
        {
            var criterionList = new Collection<ICriterion> {Expression.Eq("IsActive", 1)};

            var orderList = new Collection<Order> {Order.Asc("ParameterType")};

            return SelectObjects(typeof (AppParameterType), criterionList, orderList).List();
        }

        public virtual IList GetAppParameters()
        {
            var criterionList = new Collection<ICriterion>
                                    {
                                        Expression.Sql(
                                            "ParameterTypeID IN (SELECT ParameterTypeID FROM TAppParameterTypes WHERE IsActive = 1)")
                                    };

            var orderList = new Collection<Order> {Order.Asc("ParameterTypeID"), Order.Asc("ParameterLabel")};

            return SelectObjects(typeof (AppParameter),
                                 criterionList,
                                 orderList).List();
        }

        public virtual IList GetAppParameters(IList searchCriteria)
        {
            var criterionList = new Collection<ICriterion>();
            if (searchCriteria != null)
            {
                foreach (string strCriteria in searchCriteria)
                {
                    var delimiterIndex = strCriteria.IndexOf("|");
                    if (delimiterIndex >= 0)
                        criterionList.Add(Expression.Eq(
                                              StringHelper.Left(strCriteria, delimiterIndex),
                                              StringHelper.Right(strCriteria, strCriteria.Length - delimiterIndex - 1)));
                    else
                        criterionList.Add(Expression.Sql(strCriteria));
                }
            }
            criterionList.Add(
                Expression.Sql("ParameterTypeID IN (SELECT ParameterTypeID FROM TAppParameterTypes WHERE IsActive = 1)"));

            var orderList = new Collection<Order> {Order.Asc("ParameterTypeID"), Order.Asc("ParameterLabel")};

            return SelectObjects(typeof (AppParameter),
                                 criterionList,
                                 orderList).List();
        }

        public virtual IList GetAppParametersByType(int parameterTypeId)
        {
            var criterionList = new Collection<ICriterion> {Expression.Eq("ParameterTypeID", parameterTypeId)};

            var orderList = new Collection<Order> {Order.Asc("ParameterTypeID"), Order.Asc("ParameterLabel")};

            return SelectObjects(typeof (AppParameter), criterionList,
                                 orderList).List();
        }

        public virtual IList GetAppParametersByTypeSortByValue(int parameterTypeId)
        {
            var criterionList = new Collection<ICriterion> {Expression.Eq("ParameterTypeID", parameterTypeId)};

            var orderList = new Collection<Order> {Order.Asc("ParameterValue")};

            return SelectObjects(
                typeof (AppParameter),
                criterionList,
                orderList).List();
        }

        public virtual void InsertAppParameter(AppParameter appParameter)
        {
            InsertObject(appParameter);
        }

        public virtual void UpdateAppParameter(AppParameter appParameter)
        {
            UpdateObject(appParameter);
        }

        public virtual void DeleteAppParameter(AppParameter appParameter)
        {
            DeleteObject(appParameter);
        }

        //Integrated module
        public virtual IList GetIntegratedModules()
        {
            var orderList = new Collection<Order> {Order.Desc("ModuleName")};

            return SelectObjects(typeof (IntegratedModule), orderList).List();
        }

        //Exchange rate
        public virtual IList GetExchangeRate()
        {
            var orderList = new Collection<Order> {Order.Desc("ExchangeRateID")};

            return SelectObjects(typeof (ExchangeRate), orderList).List();
        }

        public virtual void InsertExchangeRate(ExchangeRate exchangeRate)
        {
            InsertObject(exchangeRate);
        }

        public virtual IList GetCounterByIP(string iPString)
        {
            var criterionList = new Collection<ICriterion> {Expression.Eq("CounterIP", iPString)};

            var orderList = new Collection<Order> {Order.Asc(Counter.CONST_COUNTER_NAME)};

            return SelectObjects(typeof (Counter), criterionList, orderList).List();
        }
    }
}