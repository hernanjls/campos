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
    /// Summary description for PurchaseOrderService.
    /// </summary>
    [Transactional]
    public class PurchaseOrderService
    {
        private readonly PurchaseOrderDataAccess _PurchaseOrderDataAccess;
        private ProductService _ProductService;

        public PurchaseOrderService(PurchaseOrderDataAccess purchaseOrderDataAccess)
        {
            _PurchaseOrderDataAccess = purchaseOrderDataAccess;
        }

        //Purchase Order
        public virtual IList GetPurchaseOrders()
        {
            return _PurchaseOrderDataAccess.GetPurchaseOrders();
        }

        public virtual IList GetPurchaseOrders(string poNumber)
        {
            return _PurchaseOrderDataAccess.GetPurchaseOrders(poNumber);
        }

        public virtual object PurchaseOrderManagement(PurchaseOrder purchaseOrder, IList purchaseItemList,
                                                      string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "requestCode");

            if (purchaseOrder == null)
                throw new ArgumentNullException("purchaseOrder", "Purchase Order");

            if (requestCode == Resources.OperationRequestInsert)
            {
                InsertPurchaseOrder(purchaseOrder);
            }
            else if (requestCode == Resources.OperationRequestDuplicate)
            {
                purchaseOrder.PurchaseOrderID = 0;
                InsertPurchaseOrder(purchaseOrder);
            }
            else if (requestCode == Resources.OperationRequestUpdate)
            {
                _PurchaseOrderDataAccess.UpdatePurchaseOrder(purchaseOrder);
            }
            else
            {
                DeletePurchaseOrder(purchaseOrder);
            }

            //Purchase Item Management
            PurchaseItemManagement(purchaseOrder.PurchaseOrderID, purchaseItemList);
            return null;
        }

        public virtual void InsertPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            IList poList = _PurchaseOrderDataAccess.GetPurchaseOrders();
            string poNumber;
            if (poList.Count == 0)
            {
                poNumber = "PO-" +
                           StringHelper.Right(DateTime.Today.Year.ToString(), 2) + "-" +
                           StringHelper.Right("00" + DateTime.Today.Month, 2) + "-1";
            }
            else
            {
                poNumber = ((PurchaseOrder) poList[poList.Count - 1]).PurchaseOrderNumber;
                poNumber = StringHelper.Increment(poNumber.Split('-')[3], 1);
                poNumber = "PO-" +
                           StringHelper.Right(DateTime.Today.Year.ToString(), 2) + "-" +
                           StringHelper.Right("00" + DateTime.Today.Month, 2) + "-" + poNumber;
            }
            purchaseOrder.PurchaseOrderNumber = poNumber;
            _PurchaseOrderDataAccess.InsertPurchaseOrder(purchaseOrder);
        }

        private void DeletePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder == null)
                throw new ArgumentNullException("purchaseOrder", "Purchase Order");

            IList purchaseItemList = _PurchaseOrderDataAccess.GetPurchaseItems(purchaseOrder.PurchaseOrderID);
            if (purchaseItemList != null)
            {
                if (_ProductService == null)
                    _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                foreach (PurchaseItem purchaseItem in purchaseItemList)
                {
                    purchaseItem.Quantity = (-1)*purchaseItem.Quantity;
                    _ProductService.UpdateProduct(purchaseItem);
                }
            }

            _PurchaseOrderDataAccess.DeletePurchaseOrder(purchaseOrder);
            return;
        }

        //Purchase Order
        public virtual IList GetPurchaseOrderStatus()
        {
            return _PurchaseOrderDataAccess.GetPurchaseOrderStatus();
        }

        //Purchase Item
        public IList GetPurchaseItems(int purchaseOrderID)
        {
            IList purchaseItemList = _PurchaseOrderDataAccess.GetPurchaseItems(purchaseOrderID);
            if (purchaseItemList != null)
            {
                foreach (PurchaseItem purchaseItem in purchaseItemList)
                    purchaseItem.SubTotal =
                        float.Parse(Math.Round(purchaseItem.Quantity*purchaseItem.UnitPrice, 2).ToString());
            }
            return purchaseItemList;
        }

        public IList GetPurchaseItemsWithCustomizedBarCode()
        {
            IList purchaseItemList = _PurchaseOrderDataAccess.GetPurchaseItemsWithCustomizedBarCode();
            return purchaseItemList;
        }

        ///////////////PurchaseItem
        public virtual object PurchaseItemManagement(int purchaseOrderID, IList purchaseItemList)
        {
            //if(purchaseOrderID == 0)
            //    throw new ArgumentNullException("purchaseOrderID", "Purchase Order");

            if (purchaseItemList == null)
                return null;

            _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();
            foreach (PurchaseItem purchaseItem in purchaseItemList)
            {
                //PurchaseItem
                if (purchaseItem.PurchaseItemID != 0)
                    continue;

                purchaseItem.PurchaseOrderID = purchaseOrderID;
                InsertPurchaseItem(purchaseItem);
            }
            return null;
        }

        public virtual void InsertPurchaseItem(PurchaseItem purchaseItem)
        {
            if (purchaseItem == null)
                throw new ArgumentNullException("purchaseItem", "PurchaseItem");

            //Insert purchase item
            _PurchaseOrderDataAccess.InsertPurchaseItem(purchaseItem);

            //Update product
            _ProductService.UpdateProduct(purchaseItem);
        }

        public virtual IList GetPurchaseOrdersReporting()
        {
            IList poReports = _PurchaseOrderDataAccess.GetPurchaseOrdersReporting();
            foreach (PurchaseOrderReport purchaseOrderReport in poReports)
            {
                purchaseOrderReport.AmountStandardDuplicate = purchaseOrderReport.AmountStandard;
                purchaseOrderReport.AmountPaidDuplicate = purchaseOrderReport.AmountPaid;
            }
            return poReports;
        }

        public virtual IList GetPaidPurchaseOrdersReporting()
        {
            IList poReports = _PurchaseOrderDataAccess.GetPaidPurchaseOrdersReporting();
            foreach (PurchaseOrderReport purchaseOrderReport in poReports)
            {
                purchaseOrderReport.AmountStandardDuplicate = purchaseOrderReport.AmountStandard;
                purchaseOrderReport.AmountPaidDuplicate = purchaseOrderReport.AmountPaid;
            }
            return poReports;
        }

        public virtual IList GetUnpaidPurchaseOrdersReporting()
        {
            IList poReports = _PurchaseOrderDataAccess.GetUnpaidPurchaseOrdersReporting();
            foreach (PurchaseOrderReport purchaseOrderReport in poReports)
            {
                purchaseOrderReport.AmountStandardDuplicate = purchaseOrderReport.AmountStandard;
                purchaseOrderReport.AmountPaidDuplicate = purchaseOrderReport.AmountPaid;
            }
            return poReports;
        }
    }
}