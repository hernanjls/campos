using System;
using System.Collections;
using System.Collections.Generic;
using EzPos.Model;
using NHibernate.Expression;

namespace EzPos.DataAccess
{
    public class PurchaseOrderDataAccess : BaseDataAccess
    {
        //Purchase Order
        public virtual IList GetPurchaseOrders()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(PurchaseOrder.CONST_PURCHASE_ORDER_ID));
            orderList.Add(Order.Asc(PurchaseOrder.CONST_PURCHASE_ORDER_NUMBER));

            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Gt("PurchaseOrderID", "0"));

            return SelectObjects(typeof (PurchaseOrder), criterionList, orderList).List();
        }

        public virtual IList GetPurchaseOrders(String poNumber)
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Eq("PurchaseOrderNumber", poNumber));

            var orderList = new List<Order>();
            orderList.Add(Order.Asc(PurchaseOrder.CONST_PURCHASE_ORDER_NUMBER));

            return SelectObjects(typeof (PurchaseOrder), criterionList, orderList).List();
        }

        public virtual void InsertPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            InsertObject(purchaseOrder);
        }

        public virtual void UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            UpdateObject(purchaseOrder);
        }

        public virtual void DeletePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            DeleteObject(purchaseOrder);
        }

        //Purchase Order Status
        public virtual IList GetPurchaseOrderStatus()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(PurchaseOrderStatus.CONST_PURCHASE_ORDER_STATUS_NAME));

            return SelectObjects(typeof (PurchaseOrderStatus), orderList).List();
        }

        //Purchase Item
        public virtual IList GetPurchaseItems(int purchaseOrderID)
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Eq("PurchaseOrderID", purchaseOrderID));
            criterionList.Add(Expression.Gt("PurchaseOrderID", "0"));

            return SelectObjects(
                typeof (PurchaseItem),
                criterionList).List();
        }

        public virtual IList GetPurchaseItemsWithCustomizedBarCode()
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(
                Expression.Sql(
                    "PurchaseItemID IN (SELECT MIN(PurchaseItemID) AS PurchaseItem FROM TPurchaseItems GROUP BY BarCodeValue)"));

            return SelectObjects(
                typeof (PurchaseItem),
                criterionList).List();
        }

        public virtual void InsertPurchaseItem(PurchaseItem purchaseItem)
        {
            InsertObject(purchaseItem);
        }

        public virtual IList GetPurchaseOrdersReporting()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(PurchaseOrderReport.CONST_PO_DATE));
            orderList.Add(Order.Asc(PurchaseOrderReport.CONST_PO_ID));
            orderList.Add(Order.Asc(PurchaseOrderReport.CONST_PRODUCT_NAME));

            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Gt("PurchaseOrderID", "0"));

            return SelectObjects(typeof (PurchaseOrderReport), criterionList, orderList).List();
        }

        public virtual IList GetPaidPurchaseOrdersReporting()
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Eq("PaidStatus", "Paid"));
            criterionList.Add(Expression.Gt("PurchaseOrderID", "0"));

            var orderList = new List<Order>();
            orderList.Add(Order.Asc(PurchaseOrderReport.CONST_PO_DATE));
            orderList.Add(Order.Asc(PurchaseOrderReport.CONST_PO_ID));
            orderList.Add(Order.Asc(PurchaseOrderReport.CONST_PRODUCT_NAME));

            return SelectObjects(typeof (PurchaseOrderReport), criterionList, orderList).List();
        }

        public virtual IList GetUnpaidPurchaseOrdersReporting()
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Eq("PaidStatus", "UnPaid"));
            criterionList.Add(Expression.Gt("PurchaseOrderID", "0"));

            var orderList = new List<Order>();
            orderList.Add(Order.Asc(PurchaseOrderReport.CONST_PO_DATE));
            orderList.Add(Order.Asc(PurchaseOrderReport.CONST_PO_ID));
            orderList.Add(Order.Asc(PurchaseOrderReport.CONST_PRODUCT_NAME));

            return SelectObjects(typeof (PurchaseOrderReport), criterionList, orderList).List();
        }
    }
}