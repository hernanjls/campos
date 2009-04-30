namespace EzPos.Model
{
    /// <summary>
    /// Summary description for Courtesy.
    /// </summary>
    public class Courtesy
    {
        public const string CONST_COURTESEY_NAME = "CourtesyName";
        public const string CONST_COURTESY_ID = "CourtesyID";

        public int CourtesyID { get; set; }

        public string CourtesyName { get; set; }
    }
}