using System.Collections;
using System.Collections.ObjectModel;
using EzPos.Model;
using EzPos.Utility;
using NHibernate.Expression;

namespace EzPos.DataAccess
{
    public class UserDataAccess : BaseDataAccess
    {
        public virtual IList GetUsers()
        {
            var orderList = new Collection<Order>();
            orderList.Add(Order.Asc(User.CONST_USER_LOG_IN_NAME));

            return SelectObjects(typeof (User), orderList).List();
        }

        public virtual IList GetUsers(string logIn)
        {
            var criterionList = new Collection<ICriterion>();
            criterionList.Add(Expression.Eq("LogIn", logIn));

            var orderList = new Collection<Order>();
            orderList.Add(Order.Asc(User.CONST_USER_LOG_IN_NAME));

            return SelectObjects(typeof (User), criterionList, orderList).List();
        }

        public virtual IList GetUsers(string logIn, string pwd)
        {
            var criterionList = new Collection<ICriterion>();
            criterionList.Add(Expression.Eq("LogInName", logIn));
            criterionList.Add(Expression.Eq("Password", pwd));

            var orderList = new Collection<Order>();
            orderList.Add(Order.Asc(User.CONST_USER_LOG_IN_NAME));

            return SelectObjects(typeof (User), criterionList, orderList).List();
        }

        public virtual IList GetUsers(IList searchCriteria)
        {
            var criterionList = new Collection<ICriterion>();
            if (searchCriteria != null)
            {
                foreach (string strCriteria in searchCriteria)
                {
                    int delimiterIndex = strCriteria.IndexOf("|");
                    if (delimiterIndex >= 0)
                        criterionList.Add(
                            Expression.Eq(
                                StringHelper.Left(strCriteria, delimiterIndex),
                                StringHelper.Right(strCriteria, strCriteria.Length - delimiterIndex - 1)));
                    else
                        criterionList.Add(Expression.Sql(strCriteria));
                }
            }

            var orderList = new Collection<Order>();
            orderList.Add(Order.Asc(User.CONST_USER_LOG_IN_NAME));

            return SelectObjects(
                typeof (User), criterionList, orderList).List();
        }

        public virtual void UpdateUser(User user)
        {
            UpdateObject(user);
        }

        public virtual void InsertUser(User user)
        {
            InsertObject(user);
        }

        public virtual void DeleteUser(User user)
        {
            DeleteObject(user);
        }

        public virtual void DeleteUserPermission(int userId)
        {
            string qryStr = "FROM UserPermission WHERE UserID = " + userId;
            DeleteObject(qryStr);
        }

        public virtual void InsertUserPermission(UserPermission userPermission)
        {
            InsertObject(userPermission);
        }

        public virtual IList GetPermissions()
        {
            var orderList = new Collection<Order>();
            orderList.Add(Order.Asc(Permission.CONST_SPECIAL_ORDER));

            return SelectObjects(typeof (Permission), orderList).List();
        }

        public virtual IList GetPermissionsByUser(int userId)
        {
            var orderList = new Collection<Order>();
            orderList.Add(Order.Asc(UserPermission.CONST_PERMISSION_ID));

            var criterionList = new Collection<ICriterion>();
            criterionList.Add(Expression.Eq("UserID", userId));

            return SelectObjects(typeof (UserPermission), criterionList, orderList).List();
        }
    }
}