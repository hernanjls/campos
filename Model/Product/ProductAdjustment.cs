namespace EzPos.Model
{
    /// <summary>
    /// Summary description for Product.
    /// </summary>
    public class ProductAdjustment
    {
        public int AdjustmentID { get; set; }

        public int ProductID { get; set; }

        public float QtyInStock { get; set; }

        public float QtyAdjusted { get; set; }

        public string Description { get; set; }

        public Product FKProduct { get; set; }
    }
}