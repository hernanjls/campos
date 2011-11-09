using System.Collections;
using System.Collections.ObjectModel;
using EzPos.Model.Customer;
using EzPos.Utility;
using NHibernate.Expression;

namespace EzPos.DataAccess.Customer
{
    /// <summary>
    /// Summary description for CustomerDataAccess.
    /// </summary>
    public class CustomerDataAccess : BaseDataAccess
    {
        public virtual IList GetCustomers()
        {
            var orderList = new Collection<Order>
                                {
                                    Order.Asc(Model.Customer.Customer.ConstCustomerName),
                                    Order.Desc(Model.Customer.Customer.ConstCustomerId)
                                };

            return SelectObjects(
                typeof (Model.Customer.Customer), orderList).List();
        }

        public virtual IList GetCustomers(IList searchCriteria)
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

            var orderList = new Collection<Order>
                                {
                                    Order.Asc(Model.Customer.Customer.ConstCustomerName),
                                    Order.Desc(Model.Customer.Customer.ConstCustomerId)
                                };

            return SelectObjects(
                typeof (Model.Customer.Customer), criterionList, orderList).List();
        }

        public virtual void InsertCustomer(Model.Customer.Customer customer)
        {
            InsertObject(customer);
        }

        public virtual void UpdateCustomer(Model.Customer.Customer customer)
        {
            UpdateObject(customer);
        }

        public virtual void DeleteCustomer(Model.Customer.Customer customer)
        {
            DeleteObject(customer);
        }

        public virtual Model.SaleOrder.SaleOrder GetASaleOrder(int customerId)
        {
            var criterionList = new Collection<ICriterion> {Expression.Eq("CustomerId", customerId)};

            return (Model.SaleOrder.SaleOrder)SelectObjects(
                                   typeof(Model.SaleOrder.SaleOrder),
                                   criterionList).UniqueResult();
        }

        //Discount card
        public virtual IList GetDiscountCardsByCustomer(int customerId)
        {
            var orderList = new Collection<Order>
                                {
                                    Order.Asc(DiscountCard.ConstCustomerId),
                                    Order.Asc(DiscountCard.ConstDiscountCardId)
                                };

            var criterionList = new Collection<ICriterion> {Expression.Eq("CustomerId", customerId)};

            return SelectObjects(
                typeof (DiscountCard),
                criterionList, orderList).List();
        }

        public virtual IList GetDiscountCards()
        {
            var orderList = new Collection<Order>
                                {
                                    Order.Asc(DiscountCard.ConstDiscountCardNumber),
                                    Order.Desc(DiscountCard.ConstDiscountCardId)
                                };

            return SelectObjects(
                typeof (DiscountCard), orderList).List();
        }

        public virtual IList GetDiscountCards(IList searchCriteria)
        {
            var criterionList = new Collection<ICriterion>();
            if (searchCriteria != null)
            {
                foreach (string strCriteria in searchCriteria)
                {
                    int delimiterIndex = strCriteria.IndexOf("|");
                    if (delimiterIndex >= 0)
                        criterionList.Add(Expression.Eq(
                                              StringHelper.Left(strCriteria, delimiterIndex),
                                              StringHelper.Right(strCriteria, strCriteria.Length - delimiterIndex - 1)));
                    else
                        criterionList.Add(Expression.Sql(strCriteria));
                }
            }

            var orderList = new Collection<Order>
                                {
                                    Order.Asc(DiscountCard.ConstDiscountCardNumber),
                                    Order.Asc(DiscountCard.ConstDiscountCardId)
                                };

            return SelectObjects(typeof (DiscountCard), criterionList, orderList).List();
        }

        public virtual IList GetUsedDiscountCards()
        {
            var orderList = new Collection<Order>
                                {
                                    Order.Asc(DiscountCard.ConstDiscountCardNumber),
                                    Order.Desc(DiscountCard.ConstDiscountCardId)
                                };

            var criterionList = new Collection<ICriterion> {Expression.Gt("CustomerId", "0")};

            return SelectObjects(
                typeof (DiscountCard), criterionList, orderList).List();
        }

        //Discount card
        public virtual void InsertDiscountCard(DiscountCard discountCard)
        {
            InsertObject(discountCard);
        }

        public virtual void UpdateDiscountCard(DiscountCard discountCard)
        {
            UpdateObject(discountCard);
        }

        public virtual void DeleteDiscountCard(DiscountCard discountCard)
        {
            DeleteObject(discountCard);
        }
    }
}