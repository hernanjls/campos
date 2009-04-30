using System;
using System.Collections;
using System.Collections.Generic;
using EzPos.Model;
using NHibernate.Expression;

namespace EzPos.DataAccess
{
    public class SaleOrderDataAccess : BaseDataAccess
    {
        public virtual IList GetSaleOrders()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(SaleOrder.CONST_SALE_ORDER_ID));
            orderList.Add(Order.Asc(SaleOrder.CONST_SALE_ORDER_NUMBER));

            return SelectObjects(typeof (SaleOrder), orderList).List();
        }

        public virtual IList GetSaleOrders(String soNumber)
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Eq("SaleOrderNumber", soNumber));

            var orderList = new List<Order>();
            orderList.Add(Order.Asc(SaleOrder.CONST_SALE_ORDER_NUMBER));

            return SelectObjects(typeof (SaleOrder), criterionList, orderList).List();
        }

        public virtual IList GetFirstSaleOrders()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(SaleOrder.CONST_SALE_ORDER_ID));

            return SelectObjects(typeof (SaleOrder), orderList).SetMaxResults(1).List();
        }

        public virtual IList GetPreviousSaleOrders(string saleOrderID)
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Lt("SaleOrderID", saleOrderID));

            var orderList = new List<Order>();
            orderList.Add(Order.Desc(SaleOrder.CONST_SALE_ORDER_ID));

            return SelectObjects(typeof (SaleOrder), criterionList, orderList).SetMaxResults(1).List();
        }

        public virtual IList GetNextSaleOrder(string saleOrderID)
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Gt("SaleOrderID", saleOrderID));

            var orderList = new List<Order>();
            orderList.Add(Order.Asc(SaleOrder.CONST_SALE_ORDER_ID));

            return SelectObjects(typeof (SaleOrder), criterionList, orderList).SetMaxResults(1).List();
        }

        public virtual IList GetLastSaleOrder()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Desc(SaleOrder.CONST_SALE_ORDER_ID));

            return SelectObjects(typeof (SaleOrder), orderList).SetMaxResults(1).List();
        }

        public virtual void UpdateSaleOrder(SaleOrder saleOrder)
        {
            UpdateObject(saleOrder);
        }

        public virtual void InsertSaleOrder(SaleOrder saleOrder)
        {
            InsertObject(saleOrder);
        }

        ///////////////////////// SaleItem
        public virtual IList GetSaleItems()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(SaleItem.CONST_SALE_ORDER_ID));

            return SelectObjects(typeof (SaleItem), orderList).List();
        }

        public virtual IList GetSaleItems(int saleOrderID)
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Eq("SaleOrderID", saleOrderID));

            var orderList = new List<Order>();
            orderList.Add(Order.Asc(SaleItem.CONST_PRODUCT_ID));

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
    }
}