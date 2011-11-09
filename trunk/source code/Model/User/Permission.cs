namespace EzPos.Model.User
{
    /// <summary>
    /// Summary description for Permission.
    /// </summary>
    public class Permission
    {
        public const string ConstPermissionId = "PermissionId";
        public const string ConstPermissionLabel = "PermissionLabel";
        public const string ConstSpecialOrder = "SpecialOrderId";

        public int PermissionId { get; set; }

        public string PermissionLabel { get; set; }

        public string PermissionCode { get; set; }

        public int SpecialOrderId { get; set; }
    }
}