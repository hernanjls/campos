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
        private readonly ExpenseDataAccess _ExpenseDataAccess;

        public ExpenseService(ExpenseDataAccess ExpenseDataAccess)
        {
            _ExpenseDataAccess = ExpenseDataAccess;
        }

        public IList GetExpenses()
        {
            return _ExpenseDataAccess.GetExpenses();
        }

        public virtual void ExpenseManagement(Model.Expense expense, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "requestCode");

            if (expense == null)
                throw new ArgumentNullException("expense", "Expense");

            if (requestCode == Resources.OperationRequestInsert)
                InsertExpense(expense);
            else if (requestCode == Resources.OperationRequestDuplicate)
            {
                expense.ExpenseID = 0;
                InsertExpense(expense);
            }
            else if (requestCode == Resources.OperationRequestUpdate)
                UpdateExpense(expense);
            else
                DeleteExpense(expense);
        }

        private void DeleteExpense(Model.Expense expense)
        {
            if (expense == null)
                throw new ArgumentNullException("expense", "Expense");

            _ExpenseDataAccess.DeleteExpense(expense);
        }

        private void InsertExpense(Model.Expense expense)
        {
            if (expense == null)
                throw new ArgumentNullException("expense", "Expense");

            //Expense
            _ExpenseDataAccess.InsertExpense(expense);
        }

        private void UpdateExpense(Model.Expense expense)
        {
            if (expense == null)
                throw new ArgumentNullException("expense", "Expense");

            _ExpenseDataAccess.UpdateExpense(expense);
        }

        public virtual IList GetExpenses(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", "Search Criteria");

            return _ExpenseDataAccess.GetExpenses(searchCriteria);
        }
    }
}