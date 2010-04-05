using System;
using System.Collections;
using Castle.Services.Transaction;
using EzPos.DataAccess;
using EzPos.Model;
using EzPos.Properties;

namespace EzPos.Service
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

        public virtual void ExpenseManagement(Expense expense, string requestCode)
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

        private void DeleteExpense(Expense Expense)
        {
            if (Expense == null)
                throw new ArgumentNullException("Expense", "Expense");

            _ExpenseDataAccess.DeleteExpense(Expense);
        }

        private void InsertExpense(Expense expense)
        {
            if (expense == null)
                throw new ArgumentNullException("expense", "Expense");

            //Expense
            _ExpenseDataAccess.InsertExpense(expense);
        }

        private void UpdateExpense(Expense Expense)
        {
            if (Expense == null)
                throw new ArgumentNullException("Expense", "Expense");

            _ExpenseDataAccess.UpdateExpense(Expense);
        }

        public virtual IList GetExpenses(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", "Search Criteria");

            return _ExpenseDataAccess.GetExpenses(searchCriteria);
        }
    }
}