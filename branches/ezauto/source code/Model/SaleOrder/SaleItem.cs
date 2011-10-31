using System.Drawing;

namespace EzPos.Model
{
    /// <summary>
    /// Summary description for SalesItem.
    /// </summary>
    public class SaleItem
    {
        public const string ConstProductId = "ProductID";
        public const string ConstSaleOrderId = "SaleOrderId";

        public int SaleItemID { get; set; }

        public int SaleOrderId { get; set; }

        public int ProductID { get; set; }

        public float UnitPriceIn { get; set; }

        public float UnitPriceOut { get; set; }

        public string ProductName { get; set; }

        public float Discount { get; set; }

        public int QtySold { get; set; }

        public float SubTotal { get; set; }

        public float PublicUPOut { get; set; }

        public Image ProdPicture { get; set; }

        public string ProductDisplayName { get; set; }

        public Product FKProduct { get; set; }
    }
}