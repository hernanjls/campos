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

        public virtual IList GetUsers(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", "Search Criteria");

            return _UserDataAccess.GetUsers(searchCriteria);
        }

        public virtual object UserManagement(User user, IList userPermissionList, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "requestCode");

            if (user == null)
                throw new ArgumentNullException("user", "Product");

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
                _UserDataAccess.DeleteUser(user);

            UserPermissionManagement(user.UserID, userPermissionList);
            return null;
        }

        public virtual void UpdateUser(User user)
        {
            _UserDataAccess.UpdateUser(user);
        }

        public virtual void InsertUser(User user)
        {
            _UserDataAccess.InsertUser(user);
        }

        //Sex
        public virtual IList GetSex()
        {
            return _UserDataAccess.GetSex();
        }

        //MaritalStatus
        public virtual IList GetMaritalStatus()
        {
            return _UserDataAccess.GetMaritalStatus();
        }

        //Position
        public virtual IList GetPositions()
        {
            return _UserDataAccess.GetPositions();
        }

        //ContractType
        public virtual IList GetContractTypes()
        {
            return _UserDataAccess.GetContractTypes();
        }

        public virtual void UserPermissionManagement(int userId, IList userPermissionList)
        {
            _UserDataAccess.DeleteUserPermission(userId);

            if (userPermissionList == null)
                return;

            if (userPermissionList.Count == 0)
                return;

            foreach (UserPermission userPermission in userPermissionList)
            {
                userPermission.UserID = userId;
                _UserDataAccess.InsertUserGroupPermission(userPermission);
            }
        }

        public static bool AllowToPerform(string actionStr)
        {
            bool allowFlag = false;

            if (UserContext._UserPermissions == null)
                return false;

            foreach (UserPermission userPermission in UserContext._UserPermissions)
            {
                if (!actionStr.Equals(userPermission.FKPermission.PermissionCode))
                    continue;

                allowFlag = true;
                break;
            }

            return allowFlag;
        }

        //Counter
        public virtual IList GetCounterByIP(string iPString)
        {
            return _UserDataAccess.GetCounterByIP(iPString);
        }

        //Permission
        public virtual IList GetPermissions()
        {
            return _UserDataAccess.GetPermissions();
        }

        public virtual IList GetPermissions(int userId)
        {
            return _UserDataAccess.GetPermissions(userId);
        }
    }
}