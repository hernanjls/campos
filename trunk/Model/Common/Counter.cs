namespace EzPos.Model
{
    public class Counter
    {
        public const string CONST_COUNTER_ID = "CounterID";
        public const string CONST_COUNTER_NAME = "CounterName";

        public int CounterID { get; set; }

        public string CounterName { get; set; }

        public string CounterIP { get; set; }

        public string CounterMac { get; set; }
    }
}