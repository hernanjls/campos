using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EzPos.DataAccess.SaleOrder;
using EzPos.Model.Common;
using EzPos.Model.Deposit;
using EzPos.Model.SaleOrder;
using EzPos.Properties;

namespace EzPos.Service.SaleOrder
{
    public class SaleOrderService
    {
        private readonly SaleOrderDataAccess _saleOrderDataAccess;

        public SaleOrderService(SaleOrderDataAccess saleOrderDataAccess)
        {
            _saleOrderDataAccess = saleOrderDataAccess;
        }

        public virtual IList GetSaleOrders()
        {
            return _saleOrderDataAccess.GetSaleOrders();
        }

        public virtual IList GetSaleOrders(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", Resources.MsgInvalidSearchCriteria);

            return _saleOrderDataAccess.GetSaleOrders(searchCriteria);
        }

        public virtual Model.SaleOrder.SaleOrder GetSaleOrder(Model.Deposit.Deposit deposit)
        {
            if (deposit == null)
                throw new ArgumentNullException("deposit", Resources.MsgInvalidDeposit);

            var saleOrder = 
                new Model.SaleOrder.SaleOrder
                {
                    AmountPaidInt = deposit.AmountPaidInt,
                    AmountPaidRiel = deposit.AmountPaidRiel,
                    AmountReturnInt = deposit.AmountReturnInt,
                    AmountReturnRiel = deposit.AmountReturnRiel,
                    AmountSoldInt = deposit.AmountSoldInt,
                    AmountSoldRiel = deposit.AmountSoldRiel,
                    CardNumber = deposit.CardNumber,
                    CashierId = deposit.CashierId,
                    CurrencyId = deposit.CurrencyId,
                    CustomerId = deposit.CustomerId,
                    DelivererId = deposit.DelivererId,
                    Description = deposit.Description,
                    Discount = deposit.Discount,
                    DiscountTypeId = deposit.DiscountTypeId,
                    ExchangeRate = deposit.ExchangeRate,
                    FkCustomer = deposit.FkCustomer,
                    PaymentTypeId = deposit.PaymentTypeId,
                    ReferenceNum = deposit.ReferenceNum,
                    SaleOrderDate = deposit.DepositDate,
                    SaleOrderTypeId = deposit.DepositTypeId
                };
            return saleOrder;
        }

        public virtual void UpdateSaleOrder(Model.SaleOrder.SaleOrder saleOrder)
        {
            _saleOrderDataAccess.UpdateSaleOrder(saleOrder);
        }

        public virtual void InsertSaleOrder(Model.SaleOrder.SaleOrder saleOrder)
        {
            if (saleOrder == null)
                throw new ArgumentNullException("saleOrder", Resources.MsgInvalidSaleOrder);

            _saleOrderDataAccess.InsertSaleOrder(saleOrder);
            saleOrder.SaleOrderNumber = "S-00" + saleOrder.SaleOrderId;

            _saleOrderDataAccess.UpdateSaleOrder(saleOrder);
        }

        public virtual Model.SaleOrder.SaleOrder RecordSaleOrder(
            IList saleItemList,
            float totalAmountInt,
            float totalAmountPaidInt,
            float totalAmountPaidRiel,
            float totalAmountReturnInt,
            Model.Customer.Customer customer,
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
                new Model.SaleOrder.SaleOrder
                {
                    SaleOrderDate = DateTime.Now,
                    SaleOrderTypeId = (isReturned ? 1 : 0),
                    CustomerId = customer.CustomerId,
                    CashierId = AppContext.User.UserId,
                    DelivererId = 0,
                    Description = string.Empty,
                    PaymentTypeId = 0,
                    CurrencyId = 0,
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
            if (customer.FkDiscountCard != null)
            {
                saleOrder.DiscountTypeId = customer.FkDiscountCard.DiscountCardTypeId;
                saleOrder.CardNumber = customer.FkDiscountCard.CardNumber;
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
            saleOrder.FkCustomer = customer;
            
            //Sale item      
            var productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();
            var isAllowed = true;
            foreach (var saleItem in saleItemList.Cast<SaleItem>().Where(saleItem => saleItem.ProductId != 0))
            {
                if (isReturned)
                    saleItem.QtySold *= factor;

                //Product                                    
                productService.UpdateProduct(saleItem);

                //SaleItem
                saleItem.SaleOrderId = saleOrder.SaleOrderId;
                _saleOrderDataAccess.InsertSaleItem(saleItem);

                var saleOrderReport = 
                    new SaleOrderReport
                        {
                            SaleOrderId = saleOrder.SaleOrderId,
                            SaleOrderNumber = saleOrder.SaleOrderNumber,
                            SaleOrderDate = ((DateTime) saleOrder.SaleOrderDate),
                            CustomerId = customer.CustomerId,
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
                    saleOrderReport.DiscountTypeId = saleOrder.DiscountTypeId;
                    saleOrderReport.TotalDiscount = saleOrder.Discount;
                    saleOrderReport.CardNumber = saleOrder.CardNumber;
                    saleOrderReport.ReportHeader = 1;
                    saleOrderReport.DepositAmount = depositAmount;
                }
                saleOrderReport.SaleItemId = saleItem.SaleItemId;
                saleOrderReport.ProductId = saleItem.ProductId;
                saleOrderReport.ReferenceNum = referenceNum;                

                if (saleItem.FkProduct != null)
                {
                    saleOrderReport.CategoryStr = saleItem.FkProduct.CategoryStr;
                    saleOrderReport.PurchaseUnitPrice = saleItem.FkProduct.UnitPriceIn;

                    if (!string.IsNullOrEmpty(saleItem.FkProduct.ProductCode))
                    {
                        var productCode = 
                            !string.IsNullOrEmpty(saleItem.FkProduct.ForeignCode) ?
                                                                                      saleItem.FkProduct.ForeignCode :
                                                                                                                         string.Empty;
                        productCode = productCode.Replace(",", string.Empty);
                        productCode = productCode.Replace(" ", string.Empty);
                        saleOrderReport.ProductCode =
                            productCode + 
                            " (" + 
                            (!string.IsNullOrEmpty(saleItem.FkProduct.ProductCode) ? 
                                                                                       saleItem.FkProduct.ProductCode : 
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
                saleOrderReport.QtyBonus = saleItem.QtyBonus;
                //Public Unit Price Out : Unit price after discount
                saleOrderReport.UnitPriceOut = saleItem.PublicUpOut;
                saleOrderReport.SubTotal = saleItem.PublicUpOut * saleItem.QtySold;

                _saleOrderDataAccess.InsertSaleOrderReport(saleOrderReport);
                isAllowed = false;
            }

            return saleOrder;
        }

        public virtual IList GetSaleItems(int saleOrderId)
        {
            return _saleOrderDataAccess.GetSaleItems(saleOrderId);
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
                        SaleOrderId = depositItem.DepositId,
                        ProductId = depositItem.ProductId,
                        ProductName = depositItem.ProductName,
                        FkProduct = depositItem.FkProduct,
                        UnitPriceIn = depositItem.UnitPriceIn,
                        UnitPriceOut = depositItem.UnitPriceOut,
                        Discount = depositItem.Discount,
                        QtySold = depositItem.QtySold
                    };

                if (saleItem.FkProduct != null)
                {
                    saleItem.ProductName = saleItem.FkProduct.ProductName;

                    var extraPercentage = saleItem.FkProduct.ExtraPercentage;
                    var discountPercentage = depositItem.Discount;
                    var publicUnitPriceOut = 
                        saleItem.UnitPriceIn + ((saleItem.UnitPriceIn * extraPercentage) / 100);
                    publicUnitPriceOut = 
                        publicUnitPriceOut - ((publicUnitPriceOut * discountPercentage) / 100);
                    saleItem.PublicUpOut = publicUnitPriceOut;
                }

                saleItemList.Add(saleItem);
            }
            return saleItemList;
        }

        public virtual IList GetSaleItems()
        {
            return _saleOrderDataAccess.GetSaleItems();
        }

        public virtual IList GetSaleHistories(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", Resources.MsgInvalidSearchCriteria);

            var saleOrderReportList = _saleOrderDataAccess.GetSaleHistories(searchCriteria);
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

            var saleOrderReportList = _saleOrderDataAccess.GetSaleHistoriesOrderByProductCategory(searchCriteria);
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