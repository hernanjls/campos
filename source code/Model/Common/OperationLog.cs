using System;

namespace EzPos.Model.Common
{
    public class OperationLog
    {
        public Int32 OperationLogId { get; set; }

        public DateTime LogDateTime { get; set; }

        public Int32 OperationId { get; set; }

        public Int32 UserId { get; set; }

        public string IpAddress { get; set; }
    }
}