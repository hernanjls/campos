using System.Collections;
using System.Collections.ObjectModel;
using EzPos.Model;
using EzPos.Utility;
using NHibernate.Expression;

namespace EzPos.DataAccess
{
    public class SaleOrderDataAccess : BaseDataAccess
    {
        public virtual IList GetSaleOrders()
        {
            var orderList = 
                new Collection<Order>
                {
                    Order.Asc(SaleOrder.CONST_SALE_ORDER_ID),
                    Order.Asc(SaleOrder.CONST_SALE_ORDER_NUMBER)
                };

            return SelectObjects(typeof (SaleOrder), orderList).List();
        }

        public virtual IList GetSaleOrders(IList searchCriteria)
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

            var orderList = 
                new Collection<Order>
                {
                    Order.Asc(SaleOrder.CONST_SALE_ORDER_DATE),
                    Order.Asc(SaleOrder.CONST_SALE_ORDER_NUMBER)
                };

            return SelectObjects(typeof (SaleOrder), criterionList, orderList).List();
        }

        //public virtual IList GetDeposits(String soNumber)
        //{
        //    var criterionList = new Collection<ICriterion> {Expression.Eq("SaleOrderNumber", soNumber)};

        //    var orderList = new Collection<Order> {Order.Asc(SaleOrder.CONST_SALE_ORDER_NUMBER)};

        //    return SelectObjects(typeof (SaleOrder), criterionList, orderList).List();
        //}

        //public virtual IList GetPreviousSaleOrders(string saleOrderId)
        //{
        //    var criterionList = new Collection<ICriterion> {Expression.Lt("SaleOrderId", saleOrderId)};

        //    var orderList = new Collection<Order> {Order.Desc(SaleOrder.CONST_SALE_ORDER_ID)};

        //    return SelectObjects(typeof (SaleOrder), criterionList, orderList).List();
        //}

        //public virtual IList GetNextSaleOrder(string saleOrderId)
        //{
        //    var criterionList = new Collection<ICriterion> {Expression.Gt("SaleOrderId", saleOrderId)};

        //    var orderList = new Collection<Order> {Order.Asc(SaleOrder.CONST_SALE_ORDER_ID)};

        //    return SelectObjects(typeof (SaleOrder), criterionList, orderList).List();
        //}

        public virtual void UpdateSaleOrder(SaleOrder saleOrder)
        {
            UpdateObject(saleOrder);
        }

        public virtual void InsertSaleOrder(SaleOrder saleOrder)
        {
            InsertObject(saleOrder);
        }

        //SaleItem
        public virtual IList GetSaleItems()
        {
            var orderList = new Collection<Order> {Order.Asc(SaleItem.CONST_SALE_ORDER_ID)};

            return SelectObjects(typeof (SaleItem), orderList).List();
        }

        public virtual IList GetSaleItems(int saleOrderId)
        {
            var criterionList = new Collection<ICriterion> {Expression.Eq("SaleOrderID", saleOrderId)};

            var orderList = new Collection<Order> {Order.Asc(SaleItem.CONST_PRODUCT_ID)};

            return SelectObjects(typeof (SaleItem), criterionList, orderList).List();
        }

        public virtual void UpdateSaleItem(SaleItem saleItem)
        {
            UpdateObject(saleItem);
        }

        public virtual void InsertSaleItem(SaleItem saleItem)
        {
            InsertObject(saleItem);
        }

        public virtual IList GetSaleHistories(IList searchCriteria)
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

            var orderList = 
                new Collection<Order>
                {
                    Order.Asc(SaleOrderReport.CONST_SALE_ORDER_DATE),
                    Order.Asc(SaleOrderReport.CONST_SALE_ORDER_NUMBER)
                };

            return SelectObjects(typeof (SaleOrderReport), criterionList, orderList).List();
        }

        public virtual void InsertSaleOrderReport(SaleOrderReport saleOrderReport)
        {
            InsertObject(saleOrderReport);
        }
    }
}