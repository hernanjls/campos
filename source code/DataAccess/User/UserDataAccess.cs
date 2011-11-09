using System.Collections;
using System.Collections.ObjectModel;
using EzPos.Model.User;
using EzPos.Utility;
using NHibernate.Expression;

namespace EzPos.DataAccess.User
{
    public class UserDataAccess : BaseDataAccess
    {
        public virtual IList GetUsers()
        {
            var orderList = new Collection<Order> {Order.Asc(Model.User.User.ConstUserLogInName)};

            return SelectObjects(typeof (Model.User.User), orderList).List();
        }

        public virtual IList GetUsers(string logIn)
        {
            var criterionList = new Collection<ICriterion> {Expression.Eq("LogIn", logIn)};

            var orderList = new Collection<Order> {Order.Asc(Model.User.User.ConstUserLogInName)};

            return SelectObjects(typeof (Model.User.User), criterionList, orderList).List();
        }

        public virtual IList GetUsers(string logIn, string pwd)
        {
            var criterionList = new Collection<ICriterion>
                                    {
                                        Expression.Eq("LogInName", logIn),
                                        Expression.Eq("Password", pwd)
                                    };

            var orderList = new Collection<Order> {Order.Asc(Model.User.User.ConstUserLogInName)};

            return SelectObjects(typeof (Model.User.User), criterionList, orderList).List();
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

            var orderList = new Collection<Order> {Order.Asc(Model.User.User.ConstUserLogInName)};

            return SelectObjects(
                typeof (Model.User.User), criterionList, orderList).List();
        }

        public virtual void UpdateUser(Model.User.User user)
        {
            UpdateObject(user);
        }

        public virtual void InsertUser(Model.User.User user)
        {
            InsertObject(user);
        }

        public virtual void DeleteUser(Model.User.User user)
        {
            DeleteObject(user);
        }

        public virtual void DeleteUserPermission(int userId)
        {
            var qryStr = "FROM UserPermission WHERE UserId = " + userId;
            DeleteObject(qryStr);
        }

        public virtual void InsertUserPermission(UserPermission userPermission)
        {
            InsertObject(userPermission);
        }

        public virtual IList GetPermissions()
        {
            var orderList = new Collection<Order> {Order.Asc(Permission.ConstSpecialOrder)};

            return SelectObjects(typeof (Permission), orderList).List();
        }

        public virtual IList GetPermissionsByUser(int userId)
        {
            var orderList = new Collection<Order> {Order.Asc(UserPermission.ConstPermissionId)};

            var criterionList = new Collection<ICriterion> {Expression.Eq("UserId", userId)};

            return SelectObjects(typeof (UserPermission), criterionList, orderList).List();
        }
    }
}