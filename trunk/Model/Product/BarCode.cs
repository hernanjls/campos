using System;

namespace EzPos.Model
{
    /// <summary>
    /// Summary description for BarCode.
    /// </summary>
    public class BarCode
    {
        public const string CONST_BARCODE_ID = "BarCodeValue";
        public const String CONST_BARCODE_VALUES = "BarCodeValue";

        public int BarCodeID { get; set; }

        public string BarCodeValue { get; set; }

        public DateTime BarCodeDate { get; set; }
    }
}