using System.Collections;
using System.Collections.ObjectModel;
using EzPos.Model;
using EzPos.Utility;
using NHibernate.Expression;

namespace EzPos.DataAccess
{
    /// <summary>
    /// Summary description for ExpenseDataAccess.
    /// </summary>
    public class ExpenseDataAccess : BaseDataAccess
    {
        public virtual IList GetExpenses()
        {
            var orderList = new Collection<Order> {Order.Desc(Expense.CONST_EXPENSE_ID)};

            return SelectObjects(
                typeof (Expense), orderList).List();
        }

        public virtual void InsertExpense(Expense expense)
        {
            InsertObject(expense);
        }

        public virtual void UpdateExpense(Expense expense)
        {
            UpdateObject(expense);
        }

        public virtual void DeleteExpense(Expense expense)
        {
            DeleteObject(expense);
        }

        public virtual IList GetExpenses(IList searchCriteria)
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
                    Order.Desc(Expense.CONST_EXPENSE_DATE),
                    Order.Asc(Expense.CONST_EXPENSE_TYPE_STR)
                };

            return SelectObjects(typeof (Expense), criterionList, orderList).List();
        }

        public virtual IList GetExpensesOrderByType(IList searchCriteria)
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
                    Order.Asc(Expense.CONST_EXPENSE_TYPE_STR)
                };            

            return SelectObjects(typeof (Expense), criterionList, orderList).List();
        }
    }
}