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

        public string Description { get; set; }

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

        public string DisplayName { get; set; }

        public object ProductPic { get; set; }

        public bool PrintCheck { get; set; }

        public string PublicQty { get; set; }

        public DateTime LastUpdate { get; set; }

        public string ForeignCode { get; set; }
    }
}