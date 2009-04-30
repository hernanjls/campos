using System.Collections;

namespace EzPos.Model
{
    public class UserContext
    {
        public static Counter _Counter;
        public static User _User;
        public static IList _UserPermissions;

        public static User User
        {
            get { return _User; }
            set { _User = value; }
        }

        public static IList UserPermissions
        {
            get { return _UserPermissions; }
            set { _UserPermissions = value; }
        }

        public static Counter Counter
        {
            get { return _Counter; }
            set { _Counter = value; }
        }
    }
}