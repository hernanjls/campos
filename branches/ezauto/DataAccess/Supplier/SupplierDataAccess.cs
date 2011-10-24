using System.Collections;
using System.Collections.ObjectModel;
using EzPos.Model;
using EzPos.Utility;
using NHibernate.Expression;

namespace EzPos.DataAccess
{
    /// <summary>
    /// Summary description for SupplierDataAccess.
    /// </summary>
    public class SupplierDataAccess : BaseDataAccess
    {
        public virtual IList GetSuppliers()
        {
            var orderList = new Collection<Order>
                                {
                                    Order.Asc(Supplier.CONST_SUPPLIER_NAME),
                                    Order.Desc(Supplier.CONST_SUPPLIER_ID)
                                };

            return SelectObjects(
                typeof (Supplier), orderList).List();
        }

        public virtual IList GetSuppliers(IList searchCriteria)
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

            var orderList = new Collection<Order>
                                {
                                    Order.Asc(Supplier.CONST_SUPPLIER_NAME),
                                    Order.Desc(Supplier.CONST_SUPPLIER_ID)
                                };

            return SelectObjects(
                typeof (Supplier), criterionList, orderList).List();
        }

        public virtual void InsertSupplier(Supplier Supplier)
        {
            InsertObject(Supplier);
        }

        public virtual void UpdateSupplier(Supplier Supplier)
        {
            UpdateObject(Supplier);
        }

        public virtual void DeleteSupplier(Supplier Supplier)
        {
            DeleteObject(Supplier);
        }

        //public virtual SaleOrder GetASaleOrder(int SupplierId)
        //{
        //    var criterionList = new Collection<ICriterion>
        //                            {
        //                                Expression.Eq("SupplierId", SupplierId)
        //                            };

        //    return (SaleOrder) SelectObjects(
        //                           typeof (SaleOrder),
        //                           criterionList).UniqueResult();
        //}

        ////Discount card
        //public virtual IList GetDiscountCardsBySupplier(int SupplierId)
        //{
        //    var orderList = new Collection<Order>();
        //    orderList.Add(Order.Asc(DiscountCard.CONST_Supplier_ID));
        //    orderList.Add(Order.Asc(DiscountCard.CONST_DISCOUNT_CARD_ID));

        //    var criterionList = new Collection<ICriterion>();
        //    criterionList.Add(Expression.Eq("SupplierID", SupplierId));

        //    return SelectObjects(
        //        typeof (DiscountCard),
        //        criterionList, orderList).List();
        //}

        //public virtual IList GetDiscountCards()
        //{
        //    var orderList = new Collection<Order>();
        //    orderList.Add(Order.Asc(DiscountCard.CONST_DISCOUNT_CARD_NUMBER));
        //    orderList.Add(Order.Desc(DiscountCard.CONST_DISCOUNT_CARD_ID));

        //    return SelectObjects(
        //        typeof (DiscountCard), orderList).List();
        //}

        //public virtual IList GetDiscountCards(IList searchCriteria)
        //{
        //    var criterionList = new Collection<ICriterion>();
        //    if (searchCriteria != null)
        //    {
        //        foreach (string strCriteria in searchCriteria)
        //        {
        //            int delimiterIndex = strCriteria.IndexOf("|");
        //            if (delimiterIndex >= 0)
        //                criterionList.Add(Expression.Eq(
        //                                      StringHelper.Left(strCriteria, delimiterIndex),
        //                                      StringHelper.Right(strCriteria, strCriteria.Length - delimiterIndex - 1)));
        //            else
        //                criterionList.Add(Expression.Sql(strCriteria));
        //        }
        //    }

        //    var orderList = new Collection<Order>();
        //    orderList.Add(Order.Asc(DiscountCard.CONST_DISCOUNT_CARD_NUMBER));
        //    orderList.Add(Order.Asc(DiscountCard.CONST_DISCOUNT_CARD_ID));

        //    return SelectObjects(typeof (DiscountCard), criterionList, orderList).List();
        //}

        //public virtual IList GetUsedDiscountCards()
        //{
        //    var orderList = new Collection<Order>();
        //    orderList.Add(Order.Asc(DiscountCard.CONST_DISCOUNT_CARD_NUMBER));
        //    orderList.Add(Order.Desc(DiscountCard.CONST_DISCOUNT_CARD_ID));

        //    var criterionList = new Collection<ICriterion>();
        //    criterionList.Add(Expression.Gt("SupplierID", "0"));

        //    return SelectObjects(
        //        typeof (DiscountCard), criterionList, orderList).List();
        //}

        ////Discount card
        //public virtual void InsertDiscountCard(DiscountCard discountCard)
        //{
        //    InsertObject(discountCard);
        //}

        //public virtual void UpdateDiscountCard(DiscountCard discountCard)
        //{
        //    UpdateObject(discountCard);
        //}

        //public virtual void DeleteDiscountCard(DiscountCard discountCard)
        //{
        //    DeleteObject(discountCard);
        //}
    }
}