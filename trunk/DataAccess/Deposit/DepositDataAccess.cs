using System;
using System.Collections;
using System.Collections.ObjectModel;
using EzPos.Model;
using EzPos.Utility;
using NHibernate.Expression;

namespace EzPos.DataAccess
{
    public class DepositDataAccess : BaseDataAccess
    {
        public virtual IList GetDeposits(IList searchCriteria)
        {
            var criterionList = new Collection<ICriterion>();
            if (searchCriteria != null)
            {
                foreach (string strCriteria in searchCriteria)
                {
                    var delimiterIndex = strCriteria.IndexOf("|");
                    if (delimiterIndex >= 0)
                        criterionList.Add(
                            Expression.Eq(
                                StringHelper.Left(strCriteria, delimiterIndex),
                                StringHelper.Right(strCriteria, strCriteria.Length - delimiterIndex - 1)));
                    else
                        criterionList.Add(Expression.Sql(strCriteria));
                }
            }

            var orderList = 
                new Collection<Order>
                    {
                        Order.Asc(Deposit.CONST_DEPOSIT_DATE),
                        Order.Asc(Deposit.CONST_DEPOSIT_NUMBER)
                    };

            return SelectObjects(typeof(Deposit), criterionList, orderList).List();
        }

        public virtual void UpdateDeposit(Deposit deposit)
        {
            UpdateObject(deposit);
        }

        public virtual void InsertDeposit(Deposit deposit)
        {
            InsertObject(deposit);
        }

        //DepositItem
        public virtual IList GetDepositItems(int depositId)
        {
            var criterionList = 
                new Collection<ICriterion>
                {
                    Expression.Eq("DepositId", depositId)
                };

            var orderList = 
                new Collection<Order>
                {
                    Order.Asc(DepositItem.CONST_PRODUCT_ID)
                };

            return SelectObjects(typeof (DepositItem), criterionList, orderList).List();
        }

        public virtual void UpdateDepositItem(DepositItem depositItem)
        {
            UpdateObject(depositItem);
        }

        public virtual void InsertDepositItem(DepositItem depositItem)
        {
            InsertObject(depositItem);
        }

        //Report
        public virtual IList GetDepositHistories(IList searchCriteria)
        {
            var qryStr =
                "SELECT " +
                "    {a.*}, " +
                "    {b.*}, " +
                "    {c.*}, " +
                "    {d.*}, " +
                "    {e.*} " +
                "FROM " +
                "    TDeposits a " +
                "    INNER JOIN TCustomers b on a.CustomerId = b.CustomerId " +  
                "    INNER JOIN TUsers c on a.CashierId = c.UserId " + 
                "    LEFT JOIN TDepositItems d on a.DepositId = d.DepositId " + 
                "    LEFT JOIN TProducts e on d.ProductId = e.ProductId ";

            var whereClause = string.Empty;
            foreach (string strCriteria in searchCriteria)
            {
                if (!string.IsNullOrEmpty(whereClause))
                    whereClause += " AND ";
                whereClause += strCriteria;
            }

            if (!string.IsNullOrEmpty(whereClause))
                whereClause = " WHERE " + whereClause;

            qryStr += whereClause;
            var aliasList = new string[5];
            aliasList[0] = "a";
            aliasList[1] = "b";
            aliasList[2] = "c";
            aliasList[3] = "d";
            aliasList[4] = "e";

            var typeList = new Type[5];
            typeList[0] = typeof(Deposit);
            typeList[1] = typeof(Customer);
            typeList[2] = typeof(User);
            typeList[3] = typeof(DepositItem);
            typeList[4] = typeof(Product);

            return SelectObjects(qryStr, aliasList, typeList);
        }
    }
}