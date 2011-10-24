namespace EzPos.Model.Expense
{
    /// <summary>
    /// Summary description for Customer.
    /// </summary>
    public class Expense
    {
        public const string ConstExpenseDate = "ExpenseDate";
        public const string ConstExpenseId = "ExpenseId";
        public const string ConstExpenseTypeId = "ExpenseTypeId";
        public const string ConstExpenseTypeStr = "ExpenseTypeStr";

        public int ExpenseId { get; set; }

        public int ExpenseTypeId { get; set; }

        public string ExpenseTypeStr { get; set; }

        public object ExpenseDate { get; set; }

        public string Description { get; set; }

        public float ExpenseAmountInt { get; set; }

        public float ExpenseAmountRiel { get; set; }

        public int CurrencyId { get; set; }

        public float ExchangeRate { get; set; }
    }
}