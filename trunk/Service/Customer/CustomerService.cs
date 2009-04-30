using System;
using System.Collections;
using Castle.Services.Transaction;
using EzPos.DataAccess;
using EzPos.Model;
using EzPos.Properties;

namespace EzPos.Service
{
    /// <summary>
    /// Summary description for CustomerService.
    /// </summary>
    [Transactional]
    public class CustomerService
    {
        private readonly CustomerDataAccess _CustomerDataAccess;

        public CustomerService(CustomerDataAccess customerDataAccess)
        {
            _CustomerDataAccess = customerDataAccess;
        }

        public IList GetCustomers()
        {
            try
            {
                return _CustomerDataAccess.GetCustomers();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual object CustomerManagement(Customer customer, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "Request code");

            if (customer == null)
                throw new ArgumentNullException("Customer", "Customer");

            try
            {
                if (requestCode == Resources.OperationRequestInsert)
                {
                    _CustomerDataAccess.InsertCustomer(customer);
                    return null;
                    //////////////////////////////
                }
                else if (requestCode == Resources.OperationRequestDuplicate)
                {
                    customer.CustomerID = 0;
                    _CustomerDataAccess.InsertCustomer(customer);
                    return null;
                    //////////////////////////////
                }
                else if (requestCode == Resources.OperationRequestUpdate)
                {
                    _CustomerDataAccess.UpdateCustomer(customer);
                    return null;
                    //////////////////////////////
                }
                else
                {
                    return DeleteCustomer(customer);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private object DeleteCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Customer", "Customer");

            try
            {
                if (!IsDeletable(customer))
                    return "Customer can not be deleted";
                _CustomerDataAccess.DeleteCustomer(customer);
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private bool IsDeletable(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Customer", "Customer");

            try
            {
                SaleOrder saleOrder = _CustomerDataAccess.GetASaleOrder(customer.CustomerID);
                if (saleOrder == null)
                    return true;
                else
                    return false;
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
                return _CustomerDataAccess.GetContacts();
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
                return _CustomerDataAccess.GetContacts(customerID);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual object ContactManagement(CustomerContact customerContact, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "Request code");

            if (customerContact == null)
                throw new ArgumentNullException("Customer Contact", "Customer Contact");

            try
            {
                if (requestCode == Resources.OperationRequestInsert)
                {
                    _CustomerDataAccess.InsertContact(customerContact);
                    return null;
                    //////////////////////////////
                }
                else if (requestCode == Resources.OperationRequestDuplicate)
                {
                    customerContact.CustomerID = 0;
                    _CustomerDataAccess.InsertContact(customerContact);
                    return null;
                    //////////////////////////////
                }
                else if (requestCode == Resources.OperationRequestUpdate)
                {
                    _CustomerDataAccess.UpdateContact(customerContact);
                    return null;
                    //////////////////////////////
                }
                else
                {
                    return DeleteContact(customerContact);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private object DeleteContact(CustomerContact customerContact)
        {
            if (customerContact == null)
                throw new ArgumentNullException("Customer Contact", "Customer Contact");

            try
            {
                _CustomerDataAccess.DeleteContact(customerContact);
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}