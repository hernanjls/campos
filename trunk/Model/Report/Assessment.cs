namespace EzPos.Model
{
    public class Assessment
    {
        public const string CONST_ASSESSMENT_DATE_SOLD = "SaleOrderDate";
        public const string CONST_ASSESSMENT_SALE_NUMBER = "SaleOrderNumber";

        //private string _CounterID;

        public int AssessmentID { get; set; }

        public string SaleOrderNumber { get; set; }

        public string SaleOrderDate { get; set; }

        public string CustomerName { get; set; }

        public string ProductName { get; set; }

        public string QtySoldStr { get; set; }

        public string UnitName { get; set; }

        public float PriceIn { get; set; }

        public float PriceOut { get; set; }

        public float SubTotalIn { get; set; }

        public float SubTotalOut { get; set; }

        public float Benefit { get; set; }

        public float AmountSold { get; set; }

        public float AmountPaid { get; set; }

        public float AmountReturn { get; set; }

        public float Discount { get; set; }

        public string Cashier { get; set; }

        public string Deliverer { get; set; }

        //public string CounterID
        //{
        //    get { return _CounterID; }
        //    set { _CounterID = value; }
        //}
    }
}