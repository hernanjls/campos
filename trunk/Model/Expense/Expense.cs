namespace EzPos.Model
{
    /// <summary>
    /// Summary description for Customer.
    /// </summary>
    public class Expense
    {
        public const string CONST_EXPENSE_DATE = "ExpenseDate";
        public const string CONST_EXPENSE_ID = "ExpenseID";
        public const string CONST_EXPENSE_TYPE_ID = "ExpenseTypeID";
        public const string CONST_EXPENSE_TYPE_STR = "ExpenseTypeStr";

        public int ExpenseID { get; set; }

        public int ExpenseTypeID { get; set; }

        public string ExpenseTypeStr { get; set; }

        public object ExpenseDate { get; set; }

        public string Description { get; set; }

        public float ExpenseAmountInt { get; set; }

        public float ExpenseAmountRiel { get; set; }

        public int CurrencyID { get; set; }

        public float ExchangeRate { get; set; }
    }
}