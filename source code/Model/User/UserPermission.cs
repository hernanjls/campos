namespace EzPos.Model
{
    public class UserPermission
    {
        public const string CONST_PERMISSION_ID = "PermissionID";
        public const string CONST_USER_ID = "UserID";

        public int UserPermissionID { get; set; }

        public int UserID { get; set; }

        public int PermissionID { get; set; }
    }
}