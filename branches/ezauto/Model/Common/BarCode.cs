using System;

namespace EzPos.Model
{
    /// <summary>
    /// Summary description for BarCode.
    /// </summary>
    public class BarCode
    {
        public const String CONST_BARCODE_VALUES = "BarCodeValue";

        public string BarCodeValue { get; set; }
        public string DisplayStr { get; set; }
        public string AdditionalStr { get; set; }
        public string UnitPrice { get; set; }
        public string Description { get; set; }
    }
}