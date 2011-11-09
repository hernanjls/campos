using System;

namespace EzPos.Model.Product
{
    /// <summary>
    /// Summary description for Product.
    /// </summary>
    public class Product
    {
        public const string ConstProductCode = "ProductCode";
        public const string ConstForeignCode = "ForeignCode";
        public const string ConstProductId = "ProductId";
        public const string ConstProductName = "ProductName";

        public int ProductId { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string Description
        {
            get;
            set;
        }

        public int CategoryId { get; set; }

        public string CategoryStr { get; set; }

        public int MarkId { get; set; }

        public string MarkStr { get; set; }

        public int SizeId { get; set; }

        public string SizeStr { get; set; }

        public int ColorId { get; set; }

        public string ColorStr { get; set; }

        public int SkinId { get; set; }

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
        
        public float QtyPromotion { get; set; }

        public float QtyBonus { get; set; }
    }
}