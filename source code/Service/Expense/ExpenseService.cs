using System;
using System.Collections;
using Castle.Services.Transaction;
using EzPos.DataAccess.Expense;
using EzPos.Properties;

namespace EzPos.Service.Expense
{
    /// <summary>
    /// Summary description for ExpenseService.
    /// </summary>
    [Transactional]
    public class ExpenseService
    {
        private readonly ExpenseDataAccess _expenseDataAccess;

        public ExpenseService(ExpenseDataAccess expenseDataAccess)
        {
            _expenseDataAccess = expenseDataAccess;
        }

        public IList GetExpenses()
        {
            return _expenseDataAccess.GetExpenses();
        }

        public virtual void ExpenseManagement(Model.Expense.Expense expense, string requestCode)
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

        private void DeleteExpense(Model.Expense.Expense expense)
        {
            if (expense == null)
                throw new ArgumentNullException(Resources.MsgInvalidExpense, Resources.MsgInvalidExpense);

            _expenseDataAccess.DeleteExpense(expense);
        }

        private void InsertExpense(Model.Expense.Expense expense)
        {
            if (expense == null)
                throw new ArgumentNullException(Resources.MsgInvalidExpense, Resources.MsgInvalidExpense);

            //Expense
            _expenseDataAccess.InsertExpense(expense);
        }

        private void UpdateExpense(Model.Expense.Expense expense)
        {
            if (expense == null)
                throw new ArgumentNullException(Resources.MsgInvalidExpense, Resources.MsgInvalidExpense);

            _expenseDataAccess.UpdateExpense(expense);
        }

        public virtual IList GetExpenses(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException(Resources.MsgInvalidSearchCriteria, Resources.MsgInvalidSearchCriteria);

            return _expenseDataAccess.GetExpenses(searchCriteria);
        }

        public virtual IList GetExpensesOrderByType(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException(Resources.MsgInvalidSearchCriteria, Resources.MsgInvalidSearchCriteria);

            return _expenseDataAccess.GetExpensesOrderByType(searchCriteria);
        }
    }
}