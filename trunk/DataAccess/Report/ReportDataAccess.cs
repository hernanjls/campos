using System.Collections;
using System.Collections.Generic;
using EzPos.Model;
using NHibernate.Expression;

namespace EzPos.DataAccess
{
    public class ReportDataAccess : BaseDataAccess
    {
        public virtual IList GetAssessments()
        {
            return SelectObjects(typeof (Assessment)).List();
        }

        public virtual IList GetAssessments(string startDate, string stopDate)
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Sql("SaleOrderDate BETWEEN CONVERT(DATETIME, '" + startDate + "', 101) " +
                                             " AND CONVERT(DATETIME, '" + stopDate + "', 101)"));
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(Assessment.CONST_ASSESSMENT_DATE_SOLD));
            orderList.Add(Order.Asc(Assessment.CONST_ASSESSMENT_SALE_NUMBER));

            return SelectObjects(typeof (Assessment), criterionList, orderList).List();
        }

        public virtual IList GetAssessmentsStock()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(Product.CONST_PRODUCT_NAME));

            return SelectObjects(typeof (Product), orderList).List();
        }

        public virtual IList GetAssessmentsStockCriticalQty()
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(
                Expression.Sql("ProductID IN (SELECT DISTINCT ProductID FROM TSaleItems) AND QtyInStock <= MinQty"));

            var orderList = new List<Order>();
            orderList.Add(Order.Asc(Product.CONST_PRODUCT_NAME));

            return SelectObjects(typeof (Product), criterionList, orderList).List();
        }

        public virtual IList GetAssessmentsStockCriticalExpire()
        {
            var criterionList = new List<ICriterion>();
            //criterionList.Add(Expression.Sql("(QtyInStock <> 0) AND (ProductID IN (SELECT ProductID FROM TPurchaseItems WHERE DATEADD(mm, 2, DateExpire) <= GETDATE() AND PurchaseItemID IN (SELECT MAX(PurchaseItemID) AS PurchaseItemID FROM TPurchaseItems GROUP BY ProductID)))"));
            criterionList.Add(
                Expression.Sql(
                    "(QtyInStock <> 0) AND (ProductID IN (SELECT ProductID FROM TPurchaseItems WHERE DateExpire <= DATEADD(mm, 3, GETDATE()) AND PurchaseItemID IN (SELECT MAX(PurchaseItemID) AS PurchaseItemID FROM TPurchaseItems GROUP BY ProductID)))"));


            var orderList = new List<Order>();
            orderList.Add(Order.Asc(Product.CONST_PRODUCT_NAME));

            return SelectObjects(typeof (Product), criterionList, orderList).List();
        }
    }
}