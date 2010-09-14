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
        private readonly SaleOrderDataAccess SaleOrderDataAccess;

        public SaleOrderService(SaleOrderDataAccess saleOrderDataAccess)
        {
            SaleOrderDataAccess = saleOrderDataAccess;
        }

        public virtual IList GetSaleOrders()
        {
            return SaleOrderDataAccess.GetSaleOrders();
        }

        public virtual IList GetSaleOrders(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", Resources.MsgInvalidSearchCriteria);

            return SaleOrderDataAccess.GetSaleOrders(searchCriteria);
        }

        public virtual SaleOrder GetSaleOrder(Deposit deposit)
        {
            if (deposit == null)
                throw new ArgumentNullException("deposit", Resources.MsgInvalidDeposit);

            var saleOrder = 
                new SaleOrder
                {
                    AmountPaidInt = deposit.AmountPaidInt,
                    AmountPaidRiel = deposit.AmountPaidRiel,
                    AmountReturnInt = deposit.AmountReturnInt,
                    AmountReturnRiel = deposit.AmountReturnRiel,
                    AmountSoldInt = deposit.AmountSoldInt,
                    AmountSoldRiel = deposit.AmountSoldRiel,
                    CardNumber = deposit.CardNumber,
                    CashierId = deposit.CashierId,
                    CurrencyID = deposit.CurrencyId,
                    CustomerID = deposit.CustomerId,
                    DelivererID = deposit.DelivererId,
                    Description = deposit.Description,
                    Discount = deposit.Discount,
                    DiscountTypeID = deposit.DiscountTypeId,
                    ExchangeRate = deposit.ExchangeRate,
                    FKCustomer = deposit.FKCustomer,
                    PaymentTypeID = deposit.PaymentTypeId,
                    ReferenceNum = deposit.ReferenceNum,
                    SaleOrderDate = deposit.DepositDate,
                    SaleOrderTypeID = deposit.DepositTypeId
                };
            return saleOrder;
        }

        public virtual void UpdateSaleOrder(SaleOrder saleOrder)
        {
            SaleOrderDataAccess.UpdateSaleOrder(saleOrder);
        }

        public virtual void InsertSaleOrder(SaleOrder saleOrder)
        {
            if (saleOrder == null)
                throw new ArgumentNullException("saleOrder", Resources.MsgInvalidSaleOrder);

            SaleOrderDataAccess.InsertSaleOrder(saleOrder);
            saleOrder.SaleOrderNumber = "S-00" + saleOrder.SaleOrderId;

            SaleOrderDataAccess.UpdateSaleOrder(saleOrder);

            //var paymentService = ServiceFactory.GenerateServiceInstance().GeneratePaymentService();
            //var payment = 
            //    new Model.Payments.Payment
            //    {
            //        PaymentDate = saleOrder.SaleOrderDate,
            //        PaymentAmount = saleOrder.AmountPaidInt,
            //        SalesOrderId = saleOrder.SaleOrderId,
            //        CashierId = saleOrder.CashierId
            //    };
            //paymentService.ManagePayment(Resources.OperationRequestInsert, payment);
        }

        public virtual SaleOrder RecordSaleOrder(
            IList saleItemList,
            float totalAmountInt,
            float totalAmountPaidInt,
            float totalAmountPaidRiel,
            float totalAmountReturnInt,
            Customer customer,
            bool isReturned,
            string referenceNum,
            float discount,
            float depositAmount,
            bool fromDeposit)
        {
            if (saleItemList == null)
                throw new ArgumentNullException("saleItemList", Resources.MsgInvalidSaleItem);

            var factor = 1;
            if (isReturned)
                factor = -1;

            //SaleOrder
            var saleOrder = 
                new SaleOrder
                {
                    SaleOrderDate = DateTime.Now,
                    SaleOrderTypeID = (isReturned ? 1 : 0),
                    CustomerID = customer.CustomerID,
                    CashierId = AppContext.User.UserID,
                    DelivererID = 0,
                    Description = "",
                    PaymentTypeID = 0,
                    CurrencyID = 0,
                    ExchangeRate = (AppContext.ExchangeRate == null ? 0 : AppContext.ExchangeRate.ExchangeValue),
                    AmountSoldInt = fromDeposit ? totalAmountInt : (totalAmountInt - ((totalAmountInt * discount) / 100)),
                    DepositAmount = depositAmount
                };

            saleOrder.AmountSoldInt *= factor;
            saleOrder.AmountSoldRiel = saleOrder.AmountSoldInt * saleOrder.ExchangeRate;
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
            //saleOrder.AmountReturnInt = saleOrder.AmountPaidInt - saleOrder.AmountSoldInt;
            saleOrder.AmountReturnInt = totalAmountReturnInt;
            saleOrder.AmountReturnRiel = saleOrder.AmountReturnInt * saleOrder.ExchangeRate;
            saleOrder.Discount = discount;
            if (customer.FKDiscountCard != null)
            {
                saleOrder.DiscountTypeID = customer.FKDiscountCard.DiscountCardTypeID;
                saleOrder.CardNumber = customer.FKDiscountCard.CardNumber;
            }
            saleOrder.ReferenceNum = referenceNum;

            //saleOrder.
            InsertSaleOrder(saleOrder);

            //Customer
            var customerService = ServiceFactory.GenerateServiceInstance().GenerateCustomerService();
            if(fromDeposit)
            {
                customer.PurchasedAmount += saleOrder.AmountPaidInt;
                customer.DebtAmount += saleOrder.AmountPaidInt;
            }
            else
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
                saleItem.SaleOrderID = saleOrder.SaleOrderId;
                SaleOrderDataAccess.InsertSaleItem(saleItem);

                var saleOrderReport = 
                    new SaleOrderReport
                    {
                        SalesOrderId = saleOrder.SaleOrderId,
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
                    saleOrderReport.DepositAmount = depositAmount;
                }
                saleOrderReport.SaleItemID = saleItem.SaleItemID;
                saleOrderReport.ProductID = saleItem.ProductID;
                saleOrderReport.ReferenceNum = referenceNum;                

                if (saleItem.FKProduct != null)
                {
                    saleOrderReport.CategoryStr = saleItem.FKProduct.CategoryStr;
                    saleOrderReport.PurchaseUnitPrice = saleItem.FKProduct.UnitPriceIn;

                    if (!string.IsNullOrEmpty(saleItem.FKProduct.ProductCode))
                    {
                        var productCode = 
                            !string.IsNullOrEmpty(saleItem.FKProduct.ForeignCode) ?
                            saleItem.FKProduct.ForeignCode :
                            string.Empty;
                        productCode = productCode.Replace(",", string.Empty);
                        productCode = productCode.Replace(" ", string.Empty);
                        saleOrderReport.ProductCode =
                            productCode + 
                            " (" + 
                            (!string.IsNullOrEmpty(saleItem.FKProduct.ProductCode) ? 
                            saleItem.FKProduct.ProductCode : 
                            string.Empty) + 
                            ")";
                        saleOrderReport.ProductName = saleItem.ProductName + " (" + productCode + ")";                        
                    }
                }

                if (string.IsNullOrEmpty(saleOrderReport.ProductName))
                    saleOrderReport.ProductName = saleItem.ProductName;
                saleOrderReport.UnitPriceIn = saleItem.UnitPriceIn;
                saleOrderReport.Discount = saleItem.Discount;
                saleOrderReport.QtySold = saleItem.QtySold;
                //Public Unit Price Out : Unit price after discount
                saleOrderReport.UnitPriceOut = saleItem.PublicUPOut;
                saleOrderReport.SubTotal = saleItem.PublicUPOut * saleItem.QtySold;

                SaleOrderDataAccess.InsertSaleOrderReport(saleOrderReport);
                isAllowed = false;
            }
            return saleOrder;
        }

        public virtual IList GetSaleItems(int saleOrderId)
        {
            return SaleOrderDataAccess.GetSaleItems(saleOrderId);
        }

        public virtual IList GetSaleItems(IList depositItemList)
        {
            var saleItemList = new List<SaleItem>();
            foreach (DepositItem depositItem in depositItemList)
            {
                if (depositItem == null)
                    continue;

                var saleItem = 
                    new SaleItem
                    {
                        SaleOrderID = depositItem.DepositId,
                        ProductID = depositItem.ProductId,
                        ProductName = depositItem.ProductName,
                        FKProduct = depositItem.FKProduct,
                        UnitPriceIn = depositItem.UnitPriceIn,
                        UnitPriceOut = depositItem.UnitPriceOut,
                        Discount = depositItem.Discount,
                        QtySold = depositItem.QtySold
                    };

                if (saleItem.FKProduct != null)
                {
                    saleItem.ProductName = saleItem.FKProduct.ProductName;

                    var extraPercentage = saleItem.FKProduct.ExtraPercentage;
                    var discountPercentage = depositItem.Discount;
                    var publicUnitPriceOut = 
                        saleItem.UnitPriceIn + ((saleItem.UnitPriceIn * extraPercentage) / 100);
                    publicUnitPriceOut = 
                        publicUnitPriceOut - ((publicUnitPriceOut * discountPercentage) / 100);
                    saleItem.PublicUPOut = publicUnitPriceOut;
                }

                saleItemList.Add(saleItem);
            }
            return saleItemList;
        }

        public virtual IList GetSaleItems()
        {
            return SaleOrderDataAccess.GetSaleItems();
        }

        public virtual IList GetSaleHistories(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", Resources.MsgInvalidSearchCriteria);

            var saleOrderReportList = SaleOrderDataAccess.GetSaleHistories(searchCriteria);
            foreach (SaleOrderReport saleOrderReport in saleOrderReportList)
            {
                if (!string.IsNullOrEmpty(saleOrderReport.ReferenceNum))
                    saleOrderReport.SaleOrderNumber += " (" + saleOrderReport.ReferenceNum + ")";

                if (!string.IsNullOrEmpty(saleOrderReport.CardNumber))
                    saleOrderReport.CustomerName += " (" + saleOrderReport.CardNumber + ")";
            }

            return saleOrderReportList;
        }

        public virtual IList GetSaleHistoriesOrderByProductCategory(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", Resources.MsgInvalidSearchCriteria);

            var saleOrderReportList = SaleOrderDataAccess.GetSaleHistoriesOrderByProductCategory(searchCriteria);
            foreach (SaleOrderReport saleOrderReport in saleOrderReportList)
            {
                if (!string.IsNullOrEmpty(saleOrderReport.ReferenceNum))
                    saleOrderReport.SaleOrderNumber += " (" + saleOrderReport.ReferenceNum + ")";

                if (!string.IsNullOrEmpty(saleOrderReport.CardNumber))
                    saleOrderReport.CustomerName += " (" + saleOrderReport.CardNumber + ")";
            }

            return saleOrderReportList;
        }
    }
}