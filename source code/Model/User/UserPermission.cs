namespace EzPos.Model.User
{
    public class UserPermission
    {
        public const string ConstPermissionId = "PermissionId";
        public const string ConstUserId = "UserId";

        public int UserPermissionId { get; set; }

        public int UserId { get; set; }

        public int PermissionId { get; set; }
    }
}