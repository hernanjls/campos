using System;
using System.Collections;
using Castle.Services.Transaction;
using EzPos.DataAccess;
using EzPos.Model;
using EzPos.Model.Expense;
using EzPos.Properties;

namespace EzPos.Service
{
    /// <summary>
    /// Summary description for ExpenseService.
    /// </summary>
    [Transactional]
    public class ExpenseService
    {
        private readonly ExpenseDataAccess ExpenseDataAccess;

        public ExpenseService(ExpenseDataAccess expenseDataAccess)
        {
            ExpenseDataAccess = expenseDataAccess;
        }

        public IList GetExpenses()
        {
            return ExpenseDataAccess.GetExpenses();
        }

        public virtual void ExpenseManagement(Expense expense, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException(Resources.MsgUnknownRequestCode, Resources.MsgUnknownRequestCode);

            if (expense == null)
                throw new ArgumentNullException(Resources.MsgInvalidExpense, Resources.MsgInvalidExpense);

            if (requestCode == Resources.OperationRequestInsert)
                InsertExpense(expense);
            else if (requestCode == Resources.OperationRequestDuplicate)
            {
                expense.ExpenseId = 0;
                InsertExpense(expense);
            }
            else if (requestCode == Resources.OperationRequestUpdate)
                UpdateExpense(expense);
            else
                DeleteExpense(expense);
        }

        private void DeleteExpense(Expense expense)
        {
            if (expense == null)
                throw new ArgumentNullException(Resources.MsgInvalidExpense, Resources.MsgInvalidExpense);

            ExpenseDataAccess.DeleteExpense(expense);
        }

        private void InsertExpense(Expense expense)
        {
            if (expense == null)
                throw new ArgumentNullException(Resources.MsgInvalidExpense, Resources.MsgInvalidExpense);

            //Expense
            ExpenseDataAccess.InsertExpense(expense);
        }

        private void UpdateExpense(Expense expense)
        {
            if (expense == null)
                throw new ArgumentNullException(Resources.MsgInvalidExpense, Resources.MsgInvalidExpense);

            ExpenseDataAccess.UpdateExpense(expense);
        }

        public virtual IList GetExpenses(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException(Resources.MsgInvalidSearchCriteria, Resources.MsgInvalidSearchCriteria);

            return ExpenseDataAccess.GetExpenses(searchCriteria);
        }

        public virtual IList GetExpensesOrderByType(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException(Resources.MsgInvalidSearchCriteria, Resources.MsgInvalidSearchCriteria);

            return ExpenseDataAccess.GetExpensesOrderByType(searchCriteria);
        }
    }
}