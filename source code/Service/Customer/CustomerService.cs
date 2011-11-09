using System;
using System.Collections;
using Castle.Services.Transaction;
using EzPos.DataAccess.Customer;
using EzPos.Model.Customer;
using EzPos.Properties;
using EzPos.Utility;

namespace EzPos.Service.Customer
{
    /// <summary>
    /// Summary description for CustomerService.
    /// </summary>
    [Transactional]
    public class CustomerService
    {
        private readonly CustomerDataAccess _customerDataAccess;

        public CustomerService(CustomerDataAccess customerDataAccess)
        {
            _customerDataAccess = customerDataAccess;
        }

        public IList GetCustomers()
        {
            return _customerDataAccess.GetCustomers();
        }

        public IList GetCustomers(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", "Search Criteria");

            IList customerList = _customerDataAccess.GetCustomers(searchCriteria);
            return customerList;
        }

        public virtual void CustomerManagement(Model.Customer.Customer customer, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "requestCode");

            if (customer == null)
                throw new ArgumentNullException("customer", "Customer");

            if (requestCode == Resources.OperationRequestInsert)
                InsertCustomer(customer);
            else if (requestCode == Resources.OperationRequestDuplicate)
            {
                customer.CustomerId = 0;
                InsertCustomer(customer);
            }
            else if (requestCode == Resources.OperationRequestUpdate)
                UpdateCustomer(customer);
            else
                DeleteCustomer(customer);
        }

        private void DeleteCustomer(Model.Customer.Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer", "Customer");

            int customerId = customer.CustomerId;
            _customerDataAccess.DeleteCustomer(customer);

            IList dCardList = _customerDataAccess.GetDiscountCardsByCustomer(customerId);
            if (dCardList.Count != 0)
            {
                var discountCard = (DiscountCard) dCardList[0];
                discountCard.CustomerId = 0;
                _customerDataAccess.UpdateDiscountCard(discountCard);
            }
        }

        public virtual IList GetDiscountCardsByCustomer(int customerId)
        {
            return _customerDataAccess.GetDiscountCardsByCustomer(customerId);
        }

        private void InsertCustomer(Model.Customer.Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer", "Customer");

            //Insert customer
            _customerDataAccess.InsertCustomer(customer);

            //Updating customer code
            customer.CustomerCode =
                StringHelper.Right("00" + DateTime.Now.Year, 2) + "-" +
                StringHelper.Right("00" + DateTime.Now.Month, 2) + "-" +
                customer.CustomerId;
            UpdateCustomer(customer);
        }

        private void UpdateCustomer(Model.Customer.Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer", "Customer");

            _customerDataAccess.UpdateCustomer(customer);
        }

        //Discount card
        public IList GetDiscountCards()
        {
            return _customerDataAccess.GetDiscountCards();
        }

        public IList GetDiscountCards(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", "Search Criteria");

            return _customerDataAccess.GetDiscountCards(searchCriteria);
        }

        public IList GetUsedDiscountCards()
        {
            return _customerDataAccess.GetUsedDiscountCards();
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
                discountCard.DiscountCardId = 0;
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
            _customerDataAccess.InsertDiscountCard(discountCard);

            //Updating customer code
            discountCard.CardNumber =
                StringHelper.Right("000000000" + discountCard.DiscountCardId, 9);
            UpdateDiscountCard(discountCard);
        }

        private void UpdateDiscountCard(DiscountCard discountCard)
        {
            if (discountCard == null)
                throw new ArgumentNullException("discountCard", "DiscountCard");

            var objList = _customerDataAccess.GetDiscountCardsByCustomer(discountCard.CustomerId);
            if (objList != null)
            {
                if (objList.Count != 0)
                {
                    foreach (DiscountCard dCard in objList)
                    {
                        dCard.CustomerId = 0;
                        _customerDataAccess.UpdateDiscountCard(dCard);
                    }
                }
            }

            if (discountCard.DiscountCardId != 0)
                _customerDataAccess.UpdateDiscountCard(discountCard);
        }

        private void DeleteDiscountCard(DiscountCard discountCard)
        {
            if (discountCard == null)
                throw new ArgumentNullException("discountCard", "DiscountCard");

            _customerDataAccess.DeleteDiscountCard(discountCard);
        }
    }
}