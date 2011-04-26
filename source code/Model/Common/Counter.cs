namespace EzPos.Model
{
    public class Counter
    {
        public const string CONST_COUNTER_ID = "CounterID";
        public const string CONST_COUNTER_IP = "CounterIP";
        public const string CONST_COUNTER_NAME = "CounterName";

        public int CounterID { get; set; }

        public string CounterName { get; set; }

        public string CounterIP { get; set; }

        public string CounterMAC { get; set; }

        public string ProductPhotoNetworkPath { get; set; }

        public string ProductPhotoLocalPath { get; set; }

        public string EmployeePhotoPath { get; set; }

        public string ReceiptPrinter { get; set; }

        public string ReportPrinter { get; set; }

        public string BarCodePrinter { get; set; }
    }
}