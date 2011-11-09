using System;

namespace EzPos.Model.Common
{
    /// <summary>
    /// Summary description for BarCode.
    /// </summary>
    public class BarCode
    {
        public const String ConstBarcodeValues = "BarCodeValue";

        public string BarCodeValue { get; set; }
        public string DisplayStr { get; set; }
        public string AdditionalStr { get; set; }
        public string UnitPrice { get; set; }
        public string Description { get; set; }
    }
}