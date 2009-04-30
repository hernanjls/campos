namespace EzPos.Model
{
    /// <summary>
    /// Summary description for ProductUnit.
    /// </summary>
    public class ProductUnit
    {
        public const string CONST_UNIT_ID = "UnitID";
        public const string CONST_UNIT_NAME = "UnitName";

        public int UnitID { get; set; }

        public string UnitName { get; set; }

        public string Description { get; set; }
    }
}