using System;

namespace EzPos.Model
{
    /// <summary>
    /// Summary description for Product.
    /// </summary>
    public class Product
    {
        public const string CONST_PRODUCT_CODE = "ProductCode";
        public const string CONST_FOREIGN_CODE = "ForeignCode";
        public const string CONST_PRODUCT_ID = "ProductID";
        public const string CONST_PRODUCT_NAME = "ProductName";

        public int ProductID { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        //private string _description;

        public string Description
        {
            get;
            set;
            //get
            //{
            //    if(string.IsNullOrEmpty(_description))
            //    {
            //        var displayName =
            //            ProductName + "\r" +
            //            "Size: " + SizeStr + "\r" +
            //            "Code: " + ProductCode;

            //        if (!string.IsNullOrEmpty(ForeignCode))
            //            displayName += " (" + ForeignCode + ")";

            //        return displayName;
            //    }

            //    return _description; 
            //}
            //set
            //{
            //    _description = value;
            //}
        }

        public int CategoryID { get; set; }

        public string CategoryStr { get; set; }

        public int MarkID { get; set; }

        public string MarkStr { get; set; }

        public int SizeID { get; set; }

        public string SizeStr { get; set; }

        public int ColorID { get; set; }

        public string ColorStr { get; set; }

        public int SkinID { get; set; }

        public string SkinStr { get; set; }

        public string PhotoPath { get; set; }

        public float UnitPriceIn { get; set; }

        public float ExtraPercentage { get; set; }

        public float UnitPriceOut { get; set; }

        public float DiscountPercentage { get; set; }

        public float QtyInStock { get; set; }

        public float QtySold { get; set; }

        private string _displayName;
        public string DisplayName
        {
            get
            {
                _displayName = string.IsNullOrEmpty(Description) ? ProductName : Description;
                _displayName =
                    _displayName + "\r" +
                    "Size: " + SizeStr + "\r" +
                    "Code: " + ProductCode;

                if (!string.IsNullOrEmpty(ForeignCode))
                    _displayName += " (" + ForeignCode + ")";

                return _displayName;
            }
            set
            {
                _displayName = value;
            }
        }

        public object ProductPic { get; set; }

        public bool PrintCheck { get; set; }

        public string PublicQty { get; set; }

        public DateTime LastUpdate { get; set; }

        public string ForeignCode { get; set; }
    }
}