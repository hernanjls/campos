using System;
using System.Collections;
using Castle.Services.Transaction;
using EzPos.DataAccess;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Utility;

namespace EzPos.Service
{
    /// <summary>
    /// Summary description for SupplierService.
    /// </summary>
    [Transactional]
    public class SupplierService
    {
        private readonly SupplierDataAccess _SupplierDataAccess;

        public SupplierService(SupplierDataAccess supplierDataAccess)
        {
            _SupplierDataAccess = supplierDataAccess;
        }

        public IList GetSuppliers()
        {
            return _SupplierDataAccess.GetSuppliers();
        }

        public IList GetSuppliers(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", "Search Criteria");

            var SupplierList = _SupplierDataAccess.GetSuppliers(searchCriteria);
            return SupplierList;
        }

        public virtual void SupplierManagement(Supplier Supplier, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "requestCode");

            if (Supplier == null)
                throw new ArgumentNullException("Supplier", "Supplier");

            if (requestCode == Resources.OperationRequestInsert)
                InsertSupplier(Supplier);
            else if (requestCode == Resources.OperationRequestDuplicate)
            {
                Supplier.SupplierId = 0;
                InsertSupplier(Supplier);
            }
            else if (requestCode == Resources.OperationRequestUpdate)
                UpdateSupplier(Supplier);
            else
                DeleteSupplier(Supplier);
        }

        private void DeleteSupplier(Supplier Supplier)
        {
            if (Supplier == null)
                throw new ArgumentNullException("Supplier", "Supplier");

            //int SupplierID = Supplier.SupplierId;
            _SupplierDataAccess.DeleteSupplier(Supplier);

            //IList dCardList = _SupplierDataAccess.GetDiscountCardsBySupplier(SupplierID);
            //if (dCardList.Count != 0)
            //{
            //    var discountCard = (DiscountCard) dCardList[0];
            //    discountCard.SupplierId = 0;
            //    _SupplierDataAccess.UpdateDiscountCard(discountCard);
            //}
        }

        //public virtual IList GetDiscountCardsBySupplier(int SupplierID)
        //{
        //    return _SupplierDataAccess.GetDiscountCardsBySupplier(SupplierID);
        //}

        private void InsertSupplier(Supplier Supplier)
        {
            if (Supplier == null)
                throw new ArgumentNullException("Supplier", "Supplier");

            //Insert Supplier
            _SupplierDataAccess.InsertSupplier(Supplier);

            //Updating Supplier code
            Supplier.SupplierCode =
                StringHelper.Right("00" + DateTime.Now.Year, 2) + "-" +
                StringHelper.Right("00" + DateTime.Now.Month, 2) + "-" +
                Supplier.SupplierId;
            UpdateSupplier(Supplier);
        }

        private void UpdateSupplier(Supplier Supplier)
        {
            if (Supplier == null)
                throw new ArgumentNullException("Supplier", "Supplier");

            _SupplierDataAccess.UpdateSupplier(Supplier);
        }

        ////Discount card
        //public IList GetDiscountCards()
        //{
        //    return _SupplierDataAccess.GetDiscountCards();
        //}

        //public IList GetDiscountCards(IList searchCriteria)
        //{
        //    if (searchCriteria == null)
        //        throw new ArgumentNullException("searchCriteria", "Search Criteria");

        //    return _SupplierDataAccess.GetDiscountCards(searchCriteria);
        //}

        //public IList GetUsedDiscountCards()
        //{
        //    return _SupplierDataAccess.GetUsedDiscountCards();
        //}

        //public virtual void DiscountCardManagement(DiscountCard discountCard, string requestCode)
        //{
        //    if (requestCode == null)
        //        throw new ArgumentException("Request code", "requestCode");

        //    if (discountCard == null)
        //        throw new ArgumentNullException("discountCard", "discountCard");

        //    if (requestCode == Resources.OperationRequestInsert)
        //        InsertDiscountCard(discountCard);
        //    else if (requestCode == Resources.OperationRequestDuplicate)
        //    {
        //        discountCard.DiscountCardID = 0;
        //        InsertDiscountCard(discountCard);
        //    }
        //    else if (requestCode == Resources.OperationRequestUpdate)
        //        UpdateDiscountCard(discountCard);
        //    else
        //        DeleteDiscountCard(discountCard);
        //}

        //private void InsertDiscountCard(DiscountCard discountCard)
        //{
        //    if (discountCard == null)
        //        throw new ArgumentNullException("discountCard", "DiscountCard");

        //    //Insert Supplier
        //    _SupplierDataAccess.InsertDiscountCard(discountCard);

        //    //Updating Supplier code
        //    discountCard.CardNumber =
        //        StringHelper.Right("000000000" + discountCard.DiscountCardID, 9);
        //    UpdateDiscountCard(discountCard);
        //}

        //private void UpdateDiscountCard(DiscountCard discountCard)
        //{
        //    if (discountCard == null)
        //        throw new ArgumentNullException("discountCard", "DiscountCard");

        //    IList objList = _SupplierDataAccess.GetDiscountCardsBySupplier(discountCard.SupplierID);
        //    if (objList != null)
        //    {
        //        if (objList.Count != 0)
        //        {
        //            foreach (DiscountCard dCard in objList)
        //            {
        //                dCard.SupplierID = 0;
        //                _SupplierDataAccess.UpdateDiscountCard(dCard);
        //            }
        //        }
        //    }

        //    if (discountCard.DiscountCardID != 0)
        //        _SupplierDataAccess.UpdateDiscountCard(discountCard);
        //}

        //private void DeleteDiscountCard(DiscountCard discountCard)
        //{
        //    if (discountCard == null)
        //        throw new ArgumentNullException("discountCard", "DiscountCard");

        //    _SupplierDataAccess.DeleteDiscountCard(discountCard);
        //}
    }
}