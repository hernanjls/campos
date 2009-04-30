namespace EzPos.Model
{
    /// <summary>
    /// Summary description for UserGroupPermissions.
    /// </summary>
    public class UserPermission
    {
        public const string CONST_PERMISSION = "Permission";
        public const string CONST_PERMISSION_ID = "PermissionID";

        public Permission FKPermission { get; set; }

        public int UserPermissionID { get; set; }

        public int UserID { get; set; }

        public int PermissionID { get; set; }
    }
}