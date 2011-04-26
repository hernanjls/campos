namespace EzPos.Model
{
    /// <summary>
    /// Summary description for Permission.
    /// </summary>
    public class Permission
    {
        public const string CONST_PERMISSION_ID = "PermissionID";
        public const string CONST_PERMISSION_LABEL = "PermissionLabel";
        public const string CONST_SPECIAL_ORDER = "SpecialOrderID";

        public int PermissionID { get; set; }

        public string PermissionLabel { get; set; }

        public string PermissionCode { get; set; }

        public int SpecialOrderID { get; set; }
    }
}