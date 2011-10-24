using System;

namespace EzPos.Model
{
    public class OperationLog
    {
        public Int32 OperationLogID { get; set; }

        public DateTime LogDateTime { get; set; }

        public Int32 OperationID { get; set; }

        public Int32 UserID { get; set; }

        public string IPAddress { get; set; }
    }
}