using System;
using System.Collections;
using Castle.Services.Transaction;
using EzPos.DataAccess;
using EzPos.Model;
using EzPos.Properties;

namespace EzPos.Service
{
    /// <summary>
    /// Summary description for SupplierService.
    /// </summary>
    [Transactional]
    public class SupplierService : BaseDataAccess
    {
        private readonly SupplierDataAccess _SupplierDataAccess;

        public SupplierService(SupplierDataAccess supplierDataAccess)
        {
            _SupplierDataAccess = supplierDataAccess;
        }

        public virtual IList GetSuppliers()
        {
            return _SupplierDataAccess.GetSuppliers();
        }

        public virtual object SupplierManagement(Supplier supplier, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "Request code");

            if (supplier == null)
                throw new ArgumentNullException("Supplier", "Supplier");

            try
            {
                if (requestCode == Resources.OperationRequestInsert)
                {
                    _SupplierDataAccess.InsertSupplier(supplier);
                    return null;
                }
                else if (requestCode == Resources.OperationRequestDuplicate)
                {
                    supplier.SupplierID = 0;
                    _SupplierDataAccess.InsertSupplier(supplier);
                    return null;
                }
                else if (requestCode == Resources.OperationRequestUpdate)
                {
                    _SupplierDataAccess.UpdateSupplier(supplier);
                    return null;
                }
                else
                {
                    return DeleteSupplier(supplier);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private object DeleteSupplier(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException("Supplier", "Supplier");

            _SupplierDataAccess.DeleteSupplier(supplier);
            return null;
        }
    }
}