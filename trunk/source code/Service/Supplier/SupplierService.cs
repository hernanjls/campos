using System;
using System.Collections;
using Castle.Services.Transaction;
using EzPos.DataAccess.Supplier;
using EzPos.Properties;
using EzPos.Utility;

namespace EzPos.Service.Supplier
{
    /// <summary>
    /// Summary description for SupplierService.
    /// </summary>
    [Transactional]
    public class SupplierService
    {
        private readonly SupplierDataAccess _supplierDataAccess;

        public SupplierService(SupplierDataAccess supplierDataAccess)
        {
            _supplierDataAccess = supplierDataAccess;
        }

        public IList GetSuppliers()
        {
            return _supplierDataAccess.GetSuppliers();
        }

        public IList GetSuppliers(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", "Search Criteria");

            var supplierList = _supplierDataAccess.GetSuppliers(searchCriteria);
            return supplierList;
        }

        public virtual void SupplierManagement(Model.Supplier.Supplier supplier, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "requestCode");

            if (supplier == null)
                throw new ArgumentNullException("supplier", "Supplier");

            if (requestCode == Resources.OperationRequestInsert)
                InsertSupplier(supplier);
            else if (requestCode == Resources.OperationRequestDuplicate)
            {
                supplier.SupplierId = 0;
                InsertSupplier(supplier);
            }
            else if (requestCode == Resources.OperationRequestUpdate)
                UpdateSupplier(supplier);
            else
                DeleteSupplier(supplier);
        }

        private void DeleteSupplier(Model.Supplier.Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException("supplier", "Supplier");

            _supplierDataAccess.DeleteSupplier(supplier);
        }

        private void InsertSupplier(Model.Supplier.Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException("supplier", "Supplier");

            //Insert Supplier
            _supplierDataAccess.InsertSupplier(supplier);

            //Updating Supplier code
            supplier.SupplierCode =
                StringHelper.Right("00" + DateTime.Now.Year, 2) + "-" +
                StringHelper.Right("00" + DateTime.Now.Month, 2) + "-" +
                supplier.SupplierId;
            UpdateSupplier(supplier);
        }

        private void UpdateSupplier(Model.Supplier.Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException("supplier", "Supplier");

            _supplierDataAccess.UpdateSupplier(supplier);
        }
    }
}