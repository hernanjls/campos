using System;
using System.Collections;
using Castle.Services.Transaction;
using EzPos.DataAccess;
using EzPos.DataAccess.Customer;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Utility;

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
            return _CustomerDataAccess.GetCustomers();
        }

        public IList GetCustomers(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", "Search Criteria");

            IList customerList = _CustomerDataAccess.GetCustomers(searchCriteria);
            return customerList;
        }

        public virtual void CustomerManagement(Customer customer, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "requestCode");

            if (customer == null)
                throw new ArgumentNullException("customer", "Customer");

            if (requestCode == Resources.OperationRequestInsert)
                InsertCustomer(customer);
            else if (requestCode == Resources.OperationRequestDuplicate)
            {
                customer.CustomerID = 0;
                InsertCustomer(customer);
            }
            else if (requestCode == Resources.OperationRequestUpdate)
                UpdateCustomer(customer);
            else
                DeleteCustomer(customer);
        }

        private void DeleteCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer", "Customer");

            int customerID = customer.CustomerID;
            _CustomerDataAccess.DeleteCustomer(customer);

            IList dCardList = _CustomerDataAccess.GetDiscountCardsByCustomer(customerID);
            if (dCardList.Count != 0)
            {
                var discountCard = (DiscountCard) dCardList[0];
                discountCard.CustomerID = 0;
                _CustomerDataAccess.UpdateDiscountCard(discountCard);
            }
        }

        public virtual IList GetDiscountCardsByCustomer(int customerID)
        {
            return _CustomerDataAccess.GetDiscountCardsByCustomer(customerID);
        }

        private void InsertCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer", "Customer");

            //Insert customer
            _CustomerDataAccess.InsertCustomer(customer);

            //Updating customer code
            customer.CustomerCode =
                StringHelper.Right("00" + DateTime.Now.Year, 2) + "-" +
                StringHelper.Right("00" + DateTime.Now.Month, 2) + "-" +
                customer.CustomerID;
            UpdateCustomer(customer);
        }

        private void UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer", "Customer");

            _CustomerDataAccess.UpdateCustomer(customer);
        }

        //Discount card
        public IList GetDiscountCards()
        {
            return _CustomerDataAccess.GetDiscountCards();
        }

        public IList GetDiscountCards(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", "Search Criteria");

            return _CustomerDataAccess.GetDiscountCards(searchCriteria);
        }

        public IList GetUsedDiscountCards()
        {
            return _CustomerDataAccess.GetUsedDiscountCards();
        }

        public virtual void DiscountCardManagement(DiscountCard discountCard, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "requestCode");

            if (discountCard == null)
                throw new ArgumentNullException("discountCard", "discountCard");

            if (requestCode == Resources.OperationRequestInsert)
                InsertDiscountCard(discountCard);
            else if (requestCode == Resources.OperationRequestDuplicate)
            {
                discountCard.DiscountCardID = 0;
                InsertDiscountCard(discountCard);
            }
            else if (requestCode == Resources.OperationRequestUpdate)
                UpdateDiscountCard(discountCard);
            else
                DeleteDiscountCard(discountCard);
        }

        private void InsertDiscountCard(DiscountCard discountCard)
        {
            if (discountCard == null)
                throw new ArgumentNullException("discountCard", "DiscountCard");

            //Insert customer
            _CustomerDataAccess.InsertDiscountCard(discountCard);

            //Updating customer code
            discountCard.CardNumber =
                StringHelper.Right("000000000" + discountCard.DiscountCardID, 9);
            UpdateDiscountCard(discountCard);
        }

        private void UpdateDiscountCard(DiscountCard discountCard)
        {
            if (discountCard == null)
                throw new ArgumentNullException("discountCard", "DiscountCard");

            IList objList = _CustomerDataAccess.GetDiscountCardsByCustomer(discountCard.CustomerID);
            if (objList != null)
            {
                if (objList.Count != 0)
                {
                    foreach (DiscountCard dCard in objList)
                    {
                        dCard.CustomerID = 0;
                        _CustomerDataAccess.UpdateDiscountCard(dCard);
                    }
                }
            }

            if (discountCard.DiscountCardID != 0)
                _CustomerDataAccess.UpdateDiscountCard(discountCard);
        }

        private void DeleteDiscountCard(DiscountCard discountCard)
        {
            if (discountCard == null)
                throw new ArgumentNullException("discountCard", "DiscountCard");

            _CustomerDataAccess.DeleteDiscountCard(discountCard);
        }
    }
}