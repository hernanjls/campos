namespace EzPos.Model.Product
{
    /// <summary>
    /// Summary description for Product.
    /// </summary>
    public class ProductAdjustment
    {
        public int AdjustmentId { get; set; }

        public int ProductId { get; set; }

        public float QtyInStock { get; set; }

        public float QtyAdjusted { get; set; }

        public string Description { get; set; }

        public Product FkProduct { get; set; }
    }
}