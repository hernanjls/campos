using System;
using System.Collections;
using System.Collections.ObjectModel;
using Castle.Facilities.NHibernateExtension;
using NHibernate;
using NHibernate.Expression;

namespace EzPos.DataAccess
{
    [UsesAutomaticSessionCreation]
    public class BaseDataAccess
    {
        private ISession _Session;

        private void CreateSession()
        {
            if (_Session == null)
                _Session = SessionManager.CurrentSession;

            if (!_Session.IsConnected)
                _Session = SessionManager.CurrentSession;
        }

        protected ICriteria SelectObjects(Type persistenClass)
        {
            return SelectObjects(persistenClass, null, null);
        }

        protected ICriteria SelectObjects(Type persistenClass, Collection<ICriterion> expression)
        {
            return SelectObjects(persistenClass, expression, null);
        }

        protected ICriteria SelectObjects(Type persistenClass, Collection<Order> orders)
        {
            return SelectObjects(persistenClass, null, orders);
        }

        protected ICriteria SelectObjects(
            Type persistentClass,
            Collection<ICriterion> expressions,
            Collection<Order> orders)
        {
            if (persistentClass == null)
                throw new ArgumentNullException("persistentClass", "PersistentClass");

            CreateSession();

            var criteria = _Session.CreateCriteria(persistentClass);
            if (orders != null)
            {
                foreach (var order in orders)
                    criteria.AddOrder(order);
            }

            if (expressions != null)
            {
                foreach (var expression in expressions)
                    criteria.Add(expression);
            }
            return criteria;
        }

        protected IList SelectObjects(string qryStr)
        {
            if (string.IsNullOrEmpty(qryStr))
                throw new ArgumentNullException("qryStr", "Query");

            CreateSession();
            return _Session.CreateQuery(qryStr).List();
        }

        protected IList SelectObjects(string qryStr, string[] aliasList, Type[] typeList)
        {
            if (string.IsNullOrEmpty(qryStr))
                throw new ArgumentNullException("qryStr", "Query");

            if (aliasList == null)
                throw new ArgumentNullException("aliasList", "aliasList");

            if (aliasList.Length == 0)
                throw new ArgumentNullException("aliasList", "aliasList");

            if (typeList == null)
                throw new ArgumentNullException("typeList", "typeList");

            if (typeList.Length == 0)
                throw new ArgumentNullException("typeList", "typeList");

            CreateSession();
            return _Session.CreateSQLQuery(
                qryStr,
                aliasList,
                typeList).List();
        }

        protected void UpdateObject(object instantObj)
        {
            if (instantObj == null)
                throw new ArgumentNullException("instantObj", "InstantObject");

            CreateSession();
            _Session.BeginTransaction();
            _Session.Update(instantObj);
            _Session.Transaction.Commit();
        }

        protected void DeleteObject(object instantObj)
        {
            if (instantObj == null)
                throw new ArgumentNullException("instantObj", "InstantObject");

            CreateSession();
            try
            {
                _Session.BeginTransaction();
                _Session.Delete(instantObj);
                _Session.Transaction.Commit();
            }
            catch (Exception)
            {
                _Session.Transaction.Rollback();
                throw;
            }
        }

        protected void DeleteObject(string qryStr)
        {
            if (qryStr == null)
                throw new ArgumentNullException("qryStr", "Query");

            if (qryStr.Length == 0)
                throw new ArgumentNullException("qryStr", "Query");

            CreateSession();
            try
            {
                _Session.BeginTransaction();
                _Session.Delete(qryStr);
                _Session.Transaction.Commit();
            }
            catch (Exception)
            {
                _Session.Transaction.Rollback();
                throw;
            }
        }

        protected void InsertObject(object instantObj)
        {
            if (instantObj == null)
                throw new ArgumentNullException("instantObj", "InstantObject");

            CreateSession();
            try
            {
                _Session.BeginTransaction();
                _Session.SaveOrUpdate(instantObj);
                _Session.Transaction.Commit();
            }
            catch (Exception)
            {
                _Session.Transaction.Rollback();
                throw;
            }
        }
    }
}