using System;
using System.Collections;
using System.Linq;
using EzPos.DataAccess.User;
using EzPos.Model.Common;
using EzPos.Model.User;
using EzPos.Properties;

namespace EzPos.Service.User
{
    public class UserService
    {
        private readonly UserDataAccess _userDataAccess;

        public UserService(UserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public virtual IList GetUsers()
        {
            return _userDataAccess.GetUsers();
        }

        public virtual IList GetUsers(string logIn)
        {
            return _userDataAccess.GetUsers(logIn);
        }

        public virtual Model.User.User GetUser(string logIn, string pwd)
        {
            IList userList = _userDataAccess.GetUsers(logIn, pwd);

            if (userList == null)
                return null;

            if (userList.Count == 0)
                return null;

            return userList[0] as Model.User.User;
        }

        public virtual IList GetUsers(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", "Search Criteria");

            return _userDataAccess.GetUsers(searchCriteria);
        }

        public virtual void UserManagement(Model.User.User user, IList userPermissionList, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentNullException("requestCode", "Request code");

            if (user == null)
                throw new ArgumentNullException("user", "User");

            if (requestCode == Resources.OperationRequestInsert)
                _userDataAccess.InsertUser(user);
            else if (requestCode == Resources.OperationRequestDuplicate)
            {
                user.UserId = 0;
                _userDataAccess.InsertUser(user);
            }
            else if (requestCode == Resources.OperationRequestUpdate)
                _userDataAccess.UpdateUser(user);
            else
            {
                //_UserDataAccess.DeleteUser(user);
                DeleteUser(user);
                return;
            }

            UserPermissionManagement(user, userPermissionList);
        }

        private void DeleteUser(Model.User.User user)
        {
            if (user == null)
                throw new ArgumentNullException("user", "User");

            _userDataAccess.DeleteUserPermission(user.UserId);
            _userDataAccess.DeleteUser(user);
        }

        private void UserPermissionManagement(Model.User.User user, IList userPermissionList)
        {
            if (user == null)
                throw new ArgumentNullException("user", "User");

            if (userPermissionList == null)
                throw new ArgumentNullException("userPermissionList", "User Permission List");

            if (userPermissionList.Count == 0)
                throw new ArgumentNullException("userPermissionList", "User Permission List");

            _userDataAccess.DeleteUserPermission(user.UserId);
            foreach (UserPermission userPermission in userPermissionList)
            {
                userPermission.UserId = user.UserId;
                _userDataAccess.InsertUserPermission(userPermission);
            }
        }

        public static bool AllowToPerform(string actionStr)
        {
            return AppContext.UserPermissionList != null && AppContext.UserPermissionList.Cast<UserPermission>().Any(userPermission => actionStr.Equals(userPermission.PermissionId.ToString()));
        }

        public virtual IList GetPermissions()
        {
            return _userDataAccess.GetPermissions();
        }

        public virtual IList GetPermissionsByUser(int userId)
        {
            return _userDataAccess.GetPermissionsByUser(userId);
        }
    }
}