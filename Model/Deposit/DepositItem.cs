using System.Drawing;

namespace EzPos.Model
{
    /// <summary>
    /// Summary description for SalesItem.
    /// </summary>
    public class DepositItem
    {
        public const string CONST_PRODUCT_ID = "ProductId";
        public const string CONST_DEPOSIT_ID = "DepositId";

        public int DepositItemId { get; set; }

        public int DepositId { get; set; }

        public int ProductId { get; set; }

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