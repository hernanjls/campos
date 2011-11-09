using System.Collections;
using System.Collections.ObjectModel;
using EzPos.Utility;
using NHibernate.Expression;

namespace EzPos.DataAccess.Supplier
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
                                    Order.Asc(Model.Supplier.Supplier.ConstSupplierName),
                                    Order.Desc(Model.Supplier.Supplier.ConstSupplierId)
                                };

            return SelectObjects(
                typeof (Model.Supplier.Supplier), orderList).List();
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
                                    Order.Asc(Model.Supplier.Supplier.ConstSupplierName),
                                    Order.Desc(Model.Supplier.Supplier.ConstSupplierId)
                                };

            return SelectObjects(
                typeof (Model.Supplier.Supplier), criterionList, orderList).List();
        }

        public virtual void InsertSupplier(Model.Supplier.Supplier supplier)
        {
            InsertObject(supplier);
        }

        public virtual void UpdateSupplier(Model.Supplier.Supplier supplier)
        {
            UpdateObject(supplier);
        }

        public virtual void DeleteSupplier(Model.Supplier.Supplier supplier)
        {
            DeleteObject(supplier);
        }
    }
}