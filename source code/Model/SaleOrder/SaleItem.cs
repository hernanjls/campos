using System.Drawing;

namespace EzPos.Model.SaleOrder
{
    /// <summary>
    /// Summary description for SalesItem.
    /// </summary>
    public class SaleItem
    {
        public const string ConstProductId = "ProductId";
        public const string ConstSaleOrderId = "SaleOrderId";

        public int SaleItemId { get; set; }

        public int SaleOrderId { get; set; }

        public int ProductId { get; set; }

        public float UnitPriceIn { get; set; }

        public float UnitPriceOut { get; set; }

        public string ProductName { get; set; }

        public float Discount { get; set; }

        public int QtySold { get; set; }

        public float SubTotal { get; set; }

        public float PublicUpOut { get; set; }

        public Image ProdPicture { get; set; }

        public string ProductDisplayName { get; set; }

        public Product.Product FkProduct { get; set; }

        public float QtyBonus { get; set; }
    }
}