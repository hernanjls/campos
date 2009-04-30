using System;

namespace EzPos.Model
{
    /// <summary>
    /// Summary description for Product.
    /// </summary>
    public class Product
    {
        public const string CONST_PRODUCT_DISPLAY_NAME = "DisplayName";
        public const string CONST_PRODUCT_ID = "ProductID";
        public const string CONST_PRODUCT_NAME = "ProductName";

        public string ProductCode { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string DisplayName { get; set; }

        public string Remark { get; set; }

        public float MinQty { get; set; }

        public float UnitPriceIn { get; set; }

        public float UnitPriceOut { get; set; }

        public float QtyInStock { get; set; }

        public float QtySold { get; set; }

        public float ExtraPercentage { get; set; }

        public int CategoryID { get; set; }

        public int LaboratoryID { get; set; }

        public int CountryID { get; set; }

        public object LastUpdate { get; set; }

        public int LatestUnitID { get; set; }

        public int LatestLocationID { get; set; }

        public DateTime LastExpire { get; set; }

        public int StoreID { get; set; }
    }
}