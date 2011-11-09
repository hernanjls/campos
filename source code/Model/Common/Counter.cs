namespace EzPos.Model.Common
{
    public class Counter
    {
        public const string ConstCounterId = "CounterId";
        public const string ConstCounterIp = "CounterIp";
        public const string ConstCounterName = "CounterName";

        public int CounterId { get; set; }

        public string CounterName { get; set; }

        public string CounterIp { get; set; }

        public string CounterMac { get; set; }

        public string ProductPhotoNetworkPath { get; set; }

        public string ProductPhotoLocalPath { get; set; }

        public string EmployeePhotoPath { get; set; }

        public string ReceiptPrinter { get; set; }

        public string ReportPrinter { get; set; }

        public string BarCodePrinter { get; set; }
    }
}