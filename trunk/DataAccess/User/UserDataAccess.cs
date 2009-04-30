using System.Collections;
using System.Collections.ObjectModel;
using EzPos.Model;
using EzPos.Utility;
using NHibernate.Expression;

namespace EzPos.DataAccess
{
    public class UserDataAccess : BaseDataAccess
    {
        public virtual IList GetUsers(IList searchCriteria)
        {
            var criterionList = new Collection<ICriterion>();
            if (searchCriteria != null)
            {
                foreach (string strCriteria in searchCriteria)
                {
                    var delimiterIndex = strCriteria.IndexOf("|");
                    if (delimiterIndex >= 0)
                        criterionList.Add(
                            Expression.Eq(
                                StringHelper.Left(strCriteria, delimiterIndex),
                                StringHelper.Right(strCriteria, strCriteria.Length - delimiterIndex - 1)));
                    else
                        criterionList.Add(Expression.Sql(strCriteria));
                }
            }

            var orderList = new Collection<Order> {Order.Asc(User.CONST_USER_LOG_IN_NAME)};

            return SelectObjects(
                typeof(User), criterionList, orderList).List();
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

        //Sex
        public virtual IList GetSex()
        {
            var orderList = new Collection<Order> { Order.Asc(Sex.CONST_SEX_LABEL) };

            return SelectObjects(typeof (Sex), orderList).List();
        }

        //MaritalStatus
        public virtual IList GetMaritalStatus()
        {
            var orderList = new Collection<Order> { Order.Asc(MaritalStatus.CONST_MARITALSTATUS_LABEL) };

            return SelectObjects(typeof (MaritalStatus), orderList).List();
        }

        //Position
        public virtual IList GetPositions()
        {
            var orderList = new Collection<Order> { Order.Asc(Position.CONST_POSITION_LABEL) };

            return SelectObjects(typeof (Position), orderList).List();
        }

        //ContractType
        public virtual IList GetContractTypes()
        {
            var orderList = new Collection<Order> { Order.Asc(ContractType.CONST_CONCTRACT_TYPE_LABEL) };

            return SelectObjects(typeof (ContractType), orderList).List();
        }

        public virtual void DeleteUserGroup(int userId)
        {
            var qryStr = "FROM UserGroup WHERE UserID = " + userId;
            DeleteObject(qryStr);
        }

        //UserGroupPermission
        public virtual void InsertUserGroupPermission(UserPermission userGroupPermission)
        {
            InsertObject(userGroupPermission);
        }

        public virtual void DeleteUserPermission(int userId)
        {
            var qryStr = "FROM UserPermission WHERE UserID = " + userId;
            DeleteObject(qryStr);
        }

        public virtual IList GetCounterByIP(string iPString)
        {
            var criterionList = new Collection<ICriterion> { Expression.Eq("CounterIP", iPString) };

            var orderList = new Collection<Order> { Order.Asc(Counter.CONST_COUNTER_NAME) };

            return SelectObjects(typeof (Counter), criterionList, orderList).List();
        }

        public virtual IList GetPermissions()
        {
            var orderList = new Collection<Order> { Order.Asc(Permission.CONST_PERMISSION_LABEL) };

            return SelectObjects(typeof (Permission), orderList).List();
        }

        public virtual IList GetPermissions(int userId)
        {
            var criterionList = new Collection<ICriterion> { Expression.Eq("UserID", userId) };

            return SelectObjects(typeof (UserPermission), criterionList).List();
        }
    }
}