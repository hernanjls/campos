namespace EzPos.Model
{
    public class PaymentTerm
    {
        public const string CONST_PAYMENT_TERM_ID = "PaymentTermID";
        public const string CONST_PAYMENT_TERM_NAME = "PaymentTermName";

        public int PaymentTermID { get; set; }

        public string PaymentTermName { get; set; }
    }
}