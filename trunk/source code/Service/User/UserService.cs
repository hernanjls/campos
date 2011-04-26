using System;
using System.Collections;
using EzPos.DataAccess;
using EzPos.Model;
using EzPos.Properties;

namespace EzPos.Service
{
    public class UserService
    {
        private readonly UserDataAccess _UserDataAccess;

        public UserService(UserDataAccess userDataAccess)
        {
            _UserDataAccess = userDataAccess;
        }

        public virtual IList GetUsers()
        {
            return _UserDataAccess.GetUsers();
        }

        public virtual IList GetUsers(string logIn)
        {
            return _UserDataAccess.GetUsers(logIn);
        }

        public virtual User GetUser(string logIn, string pwd)
        {
            IList userList = _UserDataAccess.GetUsers(logIn, pwd);

            if (userList == null)
                return null;

            if (userList.Count == 0)
                return null;

            return userList[0] as User;
        }

        public virtual IList GetUsers(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", "Search Criteria");

            return _UserDataAccess.GetUsers(searchCriteria);
        }

        public virtual void UserManagement(User user, IList userPermissionList, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentNullException("requestCode", "Request code");

            if (user == null)
                throw new ArgumentNullException("user", "User");

            if (requestCode == Resources.OperationRequestInsert)
                _UserDataAccess.InsertUser(user);
            else if (requestCode == Resources.OperationRequestDuplicate)
            {
                user.UserID = 0;
                _UserDataAccess.InsertUser(user);
            }
            else if (requestCode == Resources.OperationRequestUpdate)
                _UserDataAccess.UpdateUser(user);
            else
            {
                //_UserDataAccess.DeleteUser(user);
                DeleteUser(user);
                return;
            }

            UserPermissionManagement(user, userPermissionList);
        }

        private void DeleteUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user", "User");

            _UserDataAccess.DeleteUserPermission(user.UserID);
            _UserDataAccess.DeleteUser(user);
        }

        private void UserPermissionManagement(User user, IList userPermissionList)
        {
            if (user == null)
                throw new ArgumentNullException("user", "User");

            if (userPermissionList == null)
                throw new ArgumentNullException("userPermissionList", "User Permission List");

            if (userPermissionList.Count == 0)
                throw new ArgumentNullException("userPermissionList", "User Permission List");

            _UserDataAccess.DeleteUserPermission(user.UserID);
            foreach (UserPermission userPermission in userPermissionList)
            {
                userPermission.UserID = user.UserID;
                _UserDataAccess.InsertUserPermission(userPermission);
            }
        }

        public static bool AllowToPerform(string actionStr)
        {
            bool allowFlag = false;

            if (AppContext.UserPermissionList == null)
                allowFlag = false;

            foreach (UserPermission userPermission in AppContext.UserPermissionList)
            {
                if (actionStr.Equals(userPermission.PermissionID.ToString()))
                {
                    allowFlag = true;
                    break;
                }
            }

            return allowFlag;
        }

        public virtual IList GetPermissions()
        {
            return _UserDataAccess.GetPermissions();
        }

        public virtual IList GetPermissionsByUser(int userID)
        {
            return _UserDataAccess.GetPermissionsByUser(userID);
        }
    }
}