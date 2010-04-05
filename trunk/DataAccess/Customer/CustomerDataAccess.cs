using System.Collections;
using System.Collections.ObjectModel;
using EzPos.Model;
using EzPos.Utility;
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
            var orderList = new Collection<Order>();
            orderList.Add(Order.Asc(Customer.CONST_CUSTOMER_NAME));
            orderList.Add(Order.Desc(Customer.CONST_CUSTOMER_ID));

            return SelectObjects(
                typeof (Customer), orderList).List();
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

            var orderList = new Collection<Order>();
            orderList.Add(Order.Asc(Customer.CONST_CUSTOMER_NAME));
            orderList.Add(Order.Desc(Customer.CONST_CUSTOMER_ID));

            return SelectObjects(
                typeof (Customer), criterionList, orderList).List();
        }

        public virtual void InsertCustomer(Customer customer)
        {
            InsertObject(customer);
        }

        public virtual void UpdateCustomer(Customer customer)
        {
            UpdateObject(customer);
        }

        public virtual void DeleteCustomer(Customer customer)
        {
            DeleteObject(customer);
        }

        public virtual SaleOrder GetASaleOrder(int customerId)
        {
            var criterionList = new Collection<ICriterion>();
            criterionList.Add(Expression.Eq("CustomerId", customerId));

            return (SaleOrder) SelectObjects(
                                   typeof (SaleOrder),
                                   criterionList).UniqueResult();
        }

        //Discount card
        public virtual IList GetDiscountCardsByCustomer(int customerId)
        {
            var orderList = new Collection<Order>();
            orderList.Add(Order.Asc(DiscountCard.CONST_CUSTOMER_ID));
            orderList.Add(Order.Asc(DiscountCard.CONST_DISCOUNT_CARD_ID));

            var criterionList = new Collection<ICriterion>();
            criterionList.Add(Expression.Eq("CustomerID", customerId));

            return SelectObjects(
                typeof (DiscountCard),
                criterionList, orderList).List();
        }

        public virtual IList GetDiscountCards()
        {
            var orderList = new Collection<Order>();
            orderList.Add(Order.Asc(DiscountCard.CONST_DISCOUNT_CARD_NUMBER));
            orderList.Add(Order.Desc(DiscountCard.CONST_DISCOUNT_CARD_ID));

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

            var orderList = new Collection<Order>();
            orderList.Add(Order.Asc(DiscountCard.CONST_DISCOUNT_CARD_NUMBER));
            orderList.Add(Order.Asc(DiscountCard.CONST_DISCOUNT_CARD_ID));

            return SelectObjects(typeof (DiscountCard), criterionList, orderList).List();
        }

        public virtual IList GetUsedDiscountCards()
        {
            var orderList = new Collection<Order>();
            orderList.Add(Order.Asc(DiscountCard.CONST_DISCOUNT_CARD_NUMBER));
            orderList.Add(Order.Desc(DiscountCard.CONST_DISCOUNT_CARD_ID));

            var criterionList = new Collection<ICriterion>();
            criterionList.Add(Expression.Gt("CustomerID", "0"));

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