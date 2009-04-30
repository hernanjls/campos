namespace EzPos.Model
{
    /// <summary>
    /// Summary description for ProductCategory.
    /// </summary>
    public class ProductCategory
    {
        public const string CONST_CATEGORY_ID = "CategoryID";
        public const string CONST_CATEGORY_NAME = "CategoryName";

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
    }
}