namespace EzPos.Model
{
    /// <summary>
    /// Summary description for ProductLocation.
    /// </summary>
    public class ProductLocation
    {
        public const string CONST_CELL_ID = "CellID";
        public const string CONST_CELL_NAME = "CellName";

        public int CellID { get; set; }

        public string CellName { get; set; }

        public int CabinetID { get; set; }
    }
}