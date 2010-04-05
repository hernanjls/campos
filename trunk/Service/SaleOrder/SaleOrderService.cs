using System;
using System.Collections;
using System.Collections.Generic;
using EzPos.DataAccess;
using EzPos.Model;
using EzPos.Properties;

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

        public virtual IList GetSaleOrders(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", "Search Criteria");

            return _SaleOrderDataAccess.GetSaleOrders(searchCriteria);
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
                    break;
                case "-":
                    saleOrderList = _SaleOrderDataAccess.GetPreviousSaleOrders(saleOrderID.ToString());
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

            _SaleOrderDataAccess.InsertSaleOrder(saleOrder);
            saleOrder.SaleOrderNumber = "00" + saleOrder.SaleOrderID;

            _SaleOrderDataAccess.UpdateSaleOrder(saleOrder);
        }

        public virtual SaleOrder RecordSaleOrder(
            IList saleItemList,
            float totalAmountInt,
            float totalAmountPaidInt,
            float totalAmountPaidRiel,
            Customer customer,
            bool isReturned,
            string referenceNum,
            float discount)
        {
            if (saleItemList == null)
                throw new ArgumentNullException("saleItemList", "SaleItem");

            float factor = 1;
            if (isReturned)
                factor = -1;

            //SaleOrder
            var saleOrder = 
                new SaleOrder
                    {
                        SaleOrderDate = DateTime.Now,
                        SaleOrderTypeID = (isReturned ? 1 : 0),
                        CustomerID = customer.CustomerID,
                        CashierID = AppContext.User.UserID,
                        DelivererID = 0,
                        Description = "",
                        PaymentTypeID = 0,
                        CurrencyID = 0,
                        ExchangeRate = (AppContext.ExchangeRate == null ? 0 : AppContext.ExchangeRate.ExchangeValue),
                        AmountSoldInt = (totalAmountInt -
                                         ((totalAmountInt*discount)/100))
                    };

            saleOrder.AmountSoldInt *= factor;
            saleOrder.AmountSoldRiel = saleOrder.AmountSoldInt*saleOrder.ExchangeRate;
            if (isReturned)
            {
                saleOrder.AmountPaidInt = saleOrder.AmountSoldInt;
                saleOrder.AmountPaidRiel = 0;
            }
            else
            {
                saleOrder.AmountPaidInt = totalAmountPaidInt;
                saleOrder.AmountPaidRiel = totalAmountPaidRiel;
            }
            saleOrder.AmountReturnInt = saleOrder.AmountPaidInt - saleOrder.AmountSoldInt;
            saleOrder.AmountReturnRiel = saleOrder.AmountReturnInt*saleOrder.ExchangeRate;
            saleOrder.Discount = discount;
            saleOrder.DiscountTypeID = customer.FKDiscountCard.DiscountCardTypeID;
            saleOrder.CardNumber = customer.FKDiscountCard.CardNumber;
            saleOrder.ReferenceNum = referenceNum;

            //saleOrder.
            InsertSaleOrder(saleOrder);

            //Customer
            var customerService = ServiceFactory.GenerateServiceInstance().GenerateCustomerService();
            customer.DebtAmount += saleOrder.AmountReturnInt;
            customerService.CustomerManagement(
                customer,
                Resources.OperationRequestUpdate);

            //localy update SaleOrder
            saleOrder.FKCustomer = customer;
            
            //Sale item      
            var productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();
            var isAllowed = true;
            foreach (SaleItem saleItem in saleItemList)
            {
                if (saleItem.ProductID == 0)
                    continue;
                if (isReturned)
                    saleItem.QtySold *= factor;

                //Product                    
                //productService.UpdateProduct(saleItem, isReturned);
                productService.UpdateProduct(saleItem);

                //SaleItem
                saleItem.SaleOrderID = saleOrder.SaleOrderID;
                _SaleOrderDataAccess.InsertSaleItem(saleItem);

                var saleOrderReport = 
                    new SaleOrderReport
                    {
                        SaleOrderNumber = saleOrder.SaleOrderNumber,
                        SaleOrderDate = ((DateTime) saleOrder.SaleOrderDate),
                        CustomerID = customer.CustomerID,
                        CustomerName = customer.CustomerName,
                        CashierName = AppContext.User.LogInName,
                        ExchangeRate = saleOrder.ExchangeRate
                    };

                if (isAllowed)
                {
                    saleOrderReport.AmountSoldInt = saleOrder.AmountSoldInt;
                    saleOrderReport.AmountPaidInt = saleOrder.AmountPaidInt;
                    saleOrderReport.AmountPaidRiel = saleOrder.AmountPaidRiel;
                    saleOrderReport.AmountReturnInt = saleOrder.AmountReturnInt;
                    saleOrderReport.AmountReturnRiel = saleOrder.AmountReturnRiel;
                    saleOrderReport.DiscountTypeID = saleOrder.DiscountTypeID;
                    saleOrderReport.TotalDiscount = saleOrder.Discount;
                    saleOrderReport.CardNumber = saleOrder.CardNumber;
                    saleOrderReport.ReportHeader = 1;
                    saleOrderReport.ReferenceNum = referenceNum;
                }
                saleOrderReport.SaleItemID = saleItem.SaleItemID;
                saleOrderReport.ProductID = saleItem.ProductID;
                if (saleItem.FKProduct != null)
                {
                    if (!string.IsNullOrEmpty(saleItem.FKProduct.ProductCode))
                        saleOrderReport.ProductName =
                            saleItem.ProductName +
                            " (" +
                            float.Parse(saleItem.FKProduct.ProductCode).ToString("N0", AppContext.CultureInfo) +
                            ")";
                }
                if (string.IsNullOrEmpty(saleOrderReport.ProductName))
                    saleOrderReport.ProductName = saleItem.ProductName;
                saleOrderReport.UnitPriceIn = saleItem.UnitPriceIn;
                saleOrderReport.UnitPriceOut = saleItem.UnitPriceOut;
                saleOrderReport.Discount = saleItem.Discount;
                saleOrderReport.QtySold = saleItem.QtySold;
                saleOrderReport.SubTotal = saleItem.UnitPriceOut*saleItem.QtySold;

                _SaleOrderDataAccess.InsertSaleOrderReport(saleOrderReport);
                isAllowed = false;
            }
            return saleOrder;
        }

        public virtual IList GetSaleItems(int saleOrderID)
        {
            return _SaleOrderDataAccess.GetSaleItems(saleOrderID);
        }

        public virtual IList GetSaleItems()
        {
            return _SaleOrderDataAccess.GetSaleItems();
        }

        public virtual IList GetSaleHistories(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", "Search Criteria");

            var saleOrderReportList = _SaleOrderDataAccess.GetSaleHistories(searchCriteria);
            foreach (SaleOrderReport saleOrderReport in saleOrderReportList)
            {
                if (!string.IsNullOrEmpty(saleOrderReport.CardNumber))
                    saleOrderReport.CustomerName += " (" + saleOrderReport.CardNumber + ")";

                //////if(!string.IsNullOrEmpty(saleOrderReport.ProductName))
                //////    saleOrderReport.ProductName += " (" + saleOrderReport.ProductID + ")";
            }

            return saleOrderReportList;
        }
    }
}