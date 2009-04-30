using System;
using System.Collections;
using System.Collections.Generic;
using EzPos.DataAccess;
using EzPos.Model;
using EzPos.Utility;

namespace EzPos.Service
{
    public class SaleOrderService
    {
        private readonly SaleOrderDataAccess _SaleOrderDataAccess;

        public SaleOrderService(SaleOrderDataAccess saleOrderDataAccess)
        {
            _SaleOrderDataAccess = saleOrderDataAccess;
        }

        public virtual IList GetSaleOrders()
        {
            return _SaleOrderDataAccess.GetSaleOrders();
        }

        public virtual IList GetSaleOrders(string soNumber)
        {
            return _SaleOrderDataAccess.GetSaleOrders(soNumber);
        }

        public virtual SaleOrder GetSaleOrder(int saleOrderID, string criteria)
        {
            if (criteria == null)
                criteria = string.Empty;

            SaleOrder _SaleOrderResult = null;
            IList saleOrderList = new List<SaleOrder>();
            switch (criteria)
            {
                case "+":
                    saleOrderList = _SaleOrderDataAccess.GetNextSaleOrder(saleOrderID.ToString());
                    if (saleOrderList.Count == 0)
                        saleOrderList = _SaleOrderDataAccess.GetFirstSaleOrders();
                    break;
                case "-":
                    saleOrderList = _SaleOrderDataAccess.GetPreviousSaleOrders(saleOrderID.ToString());
                    if (saleOrderList.Count == 0)
                        saleOrderList = _SaleOrderDataAccess.GetLastSaleOrder();
                    break;
                default:
                    break;
            }

            if (saleOrderList.Count != 0)
                _SaleOrderResult = (SaleOrder) saleOrderList[0];

            return _SaleOrderResult;
        }

        public virtual void UpdateSaleOrder(SaleOrder saleOrder)
        {
            _SaleOrderDataAccess.UpdateSaleOrder(saleOrder);
        }

        public virtual void InsertSaleOrder(SaleOrder saleOrder)
        {
            if (saleOrder == null)
                throw new ArgumentNullException("saleOrder", "SaleOrder");

            IList soList = _SaleOrderDataAccess.GetSaleOrders();
            string soNumber;
            if (soList.Count == 0)
            {
                soNumber = "SO-" +
                           StringHelper.Right(DateTime.Today.Year.ToString(), 2) + "-" +
                           StringHelper.Right("00" + DateTime.Today.Month, 2) + "-1";
            }
            else
            {
                soNumber = ((SaleOrder) soList[soList.Count - 1]).SaleOrderNumber;
                soNumber = StringHelper.Increment(soNumber.Split('-')[3], 1);
                soNumber = "SO-" +
                           StringHelper.Right(DateTime.Today.Year.ToString(), 2) + "-" +
                           StringHelper.Right("00" + DateTime.Today.Month, 2) + "-" + soNumber;
            }
            saleOrder.SaleOrderNumber = soNumber;
            saleOrder.RecorderID = UserContext._User.UserID;

            saleOrder.DateOut = DateTime.Today;
            _SaleOrderDataAccess.InsertSaleOrder(saleOrder);
        }

        public SaleOrder RecordSaleOrder(IList saleItemList, float _TotalAmountInUsd, float _TotalAmountPaid)
        {
            if (saleItemList == null)
                throw new ArgumentNullException("saleItemList", "SaleItem");

            SaleOrder saleOrder;
            //SaleOrder
            saleOrder = new SaleOrder();
            saleOrder.CustomerID = 80;
            if (UserContext.Counter == null)
                saleOrder.CounterID = 0;
            else
                saleOrder.CounterID = UserContext.Counter.CounterID;
            saleOrder.DelivererID = 0;
            saleOrder.WholeRetail = 0;
            saleOrder.AmountSold = _TotalAmountInUsd;
            saleOrder.AmountPaid = _TotalAmountPaid;
            saleOrder.AmountReturn = _TotalAmountPaid - _TotalAmountInUsd;
            InsertSaleOrder(saleOrder);

            ProductService productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();
            foreach (SaleItem saleItem in saleItemList)
            {
                if (saleItem.ProductID == 0)
                    continue;

                //Product                    
                productService.UpdateProduct(saleItem);

                //SaleItem
                saleItem.SaleOrderID = saleOrder.SaleOrderID;
                saleItem.FKSaleOrder = saleOrder;
                _SaleOrderDataAccess.InsertSaleItem(saleItem);
            }

            return saleOrder;
        }

        public virtual void UpdateProduct(SaleItem saleItem)
        {
            if (saleItem == null)
                throw new ArgumentNullException("saleItem", "saleItem");

            //if (saleItem.FKProduct == null)
            //    return;

            //Product product = saleItem.FKProduct;
            //product.QtyInStock -= saleItem.QtyOut;
            //product.LastUpdate = DateTime.Today;

            ////_SaleOrderDataAccess.UpdateProduct(product);
            ////_ProductDataAccess.UpdatePurchaseItem(purchaseItem);
        }

        public virtual IList GetSaleItems(int saleOrderID)
        {
            return _SaleOrderDataAccess.GetSaleItems(saleOrderID);
        }
    }
}