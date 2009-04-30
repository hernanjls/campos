using System;
using System.Collections;
using System.Collections.Generic;
using EzPos.Model;
using NHibernate.Expression;

namespace EzPos.DataAccess
{
    /// <summary>
    /// Summary description for CustomerDataAccess.
    /// </summary>
    public class CustomerDataAccess : BaseDataAccess
    {
        public virtual IList GetCustomers()
        {
            try
            {
                var orderList = new List<Order>();
                orderList.Add(Order.Asc(Customer.CONST_CUSTOMER_NAME));

                return SelectObjects(
                    typeof (Customer), orderList).List();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void InsertCustomer(Customer customer)
        {
            try
            {
                InsertObject(customer);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void UpdateCustomer(Customer customer)
        {
            try
            {
                UpdateObject(customer);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void DeleteCustomer(Customer customer)
        {
            try
            {
                DeleteObject(customer);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual IList GetContacts()
        {
            try
            {
                var orderList = new List<Order>();
                orderList.Add(Order.Asc(CustomerContact.CONST_CONTACT_NAME));

                return SelectObjects(
                    typeof (CustomerContact), orderList).List();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual IList GetContacts(int customerID)
        {
            try
            {
                var criterionList = new List<ICriterion>();
                criterionList.Add(Expression.Eq("CustomerID", customerID));

                var orderList = new List<Order>();
                orderList.Add(Order.Asc(CustomerContact.CONST_CONTACT_NAME));

                return SelectObjects(typeof (CustomerContact), criterionList, orderList).List();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void InsertContact(CustomerContact customerContact)
        {
            try
            {
                InsertObject(customerContact);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void UpdateContact(CustomerContact customerContact)
        {
            try
            {
                UpdateObject(customerContact);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void DeleteContact(CustomerContact customerContact)
        {
            try
            {
                DeleteObject(customerContact);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public virtual SaleOrder GetASaleOrder(int customerID)
        {
            try
            {
                var criterionList = new List<ICriterion>();
                criterionList.Add(Expression.Eq("CustomerID", customerID));

                return (SaleOrder) SelectObjects(
                                       typeof (SaleOrder),
                                       criterionList).UniqueResult();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}