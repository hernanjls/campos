using System;
using System.Collections;
using System.Collections.Generic;
using EzPos.Model;
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
            try
            {
                var orderList = new List<Order>();
                orderList.Add(Order.Asc(Supplier.CONST_SUPPLIER_NAME));

                return SelectObjects(typeof (Supplier), orderList).List();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void InsertSupplier(Supplier supplier)
        {
            try
            {
                InsertObject(supplier);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void UpdateSupplier(Supplier supplier)
        {
            try
            {
                UpdateObject(supplier);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void DeleteSupplier(Supplier supplier)
        {
            try
            {
                DeleteObject(supplier);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}