using System;
using System.Collections;
using System.Collections.Generic;
using EzPos.DataAccess;
using EzPos.Model;
using EzPos.Properties;

namespace EzPos.Service
{
    public class DepositService
    {
        private readonly DepositDataAccess _DepositDataAccess;

        public DepositService(DepositDataAccess depositDataAccess)
        {
            _DepositDataAccess = depositDataAccess;
        }

        public virtual IList GetDeposits(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", "Search Criteria");

            return _DepositDataAccess.GetDeposits(searchCriteria);
        }

        public virtual void UpdateDeposit(Deposit deposit)
        {
            _DepositDataAccess.UpdateDeposit(deposit);
        }

        public virtual void InsertDeposit(Deposit deposit)
        {
            if (deposit == null)
                throw new ArgumentNullException("deposit", "Deposit");

            deposit.UpdateDate = DateTime.Now;
            _DepositDataAccess.InsertDeposit(deposit);
            deposit.DepositNumber = "D-00" + deposit.DepositId;

            _DepositDataAccess.UpdateDeposit(deposit);

            var paymentService = ServiceFactory.GenerateServiceInstance().GeneratePaymentService();
            var payment = 
                new Model.Payments.Payment
                {
                    PaymentDate = deposit.DepositDate,
                    PaymentAmount = deposit.AmountPaidInt,
                    SalesOrderId = deposit.DepositId,
                    CashierId = deposit.CashierId
                };
            paymentService.ManagePayment(Resources.OperationRequestInsert, payment);
        }

        public virtual Deposit RecordDeposit(
            IList depositItemList,
            float totalAmountInt,
            float totalAmountPaidInt,
            float totalAmountPaidRiel,
            Customer customer,
            string referenceNum,
            float discount,
            bool isReturned)
        {
            if (depositItemList == null)
                throw new ArgumentNullException("depositItemList", "Deposit item");

            var factor = 1;
            if (isReturned)
                factor = -1;

            //Deposit
            var deposit = 
                new Deposit
                {
                    DepositDate = DateTime.Now,
                    DepositTypeId = isReturned ? 1 : 0,
                    CustomerId = customer.CustomerID,
                    CashierId = AppContext.User.UserID,
                    DelivererId = 0,
                    Description = string.Empty,
                    PaymentTypeId = 0,
                    CurrencyId = 0,
                    ExchangeRate = 
                        (AppContext.ExchangeRate == null ? 0 : AppContext.ExchangeRate.ExchangeValue),
                    AmountSoldInt = 
                        isReturned ? totalAmountInt : (totalAmountInt - ((totalAmountInt * discount) / 100)),
                    AmountPaidInt = totalAmountPaidInt,
                    AmountPaidRiel = totalAmountPaidRiel,
                    Discount = discount
                };
           
            deposit.AmountReturnInt = totalAmountPaidInt - deposit.AmountSoldInt;
            deposit.AmountSoldInt *= factor;
            deposit.AmountPaidInt *= factor;
            deposit.AmountReturnInt *= factor;
            deposit.AmountSoldRiel = deposit.AmountSoldInt * deposit.ExchangeRate;
            deposit.AmountReturnRiel = deposit.AmountReturnInt * deposit.ExchangeRate;
            if (customer.FKDiscountCard != null)
            {
                deposit.DiscountTypeId = customer.FKDiscountCard.DiscountCardTypeID;
                deposit.CardNumber = customer.FKDiscountCard.CardNumber;
            }
            deposit.ReferenceNum = referenceNum;

            //Deposit
            InsertDeposit(deposit);

            //Customer
            var customerService = ServiceFactory.GenerateServiceInstance().GenerateCustomerService();
            customer.DebtAmount += deposit.AmountReturnInt;
            if (isReturned)
                customer.PurchasedAmount += deposit.AmountPaidInt;

            customerService.CustomerManagement(
                customer,
                Resources.OperationRequestUpdate);

            //localy update SaleOrder
            deposit.FKCustomer = customer;

            //Deposit item      
            if (!isReturned)
            {
                foreach (DepositItem depositItem in depositItemList)
                {
                    if (depositItem.ProductId == 0)
                        continue;

                    depositItem.DepositId = deposit.DepositId;
                    _DepositDataAccess.InsertDepositItem(depositItem);
                }
            }
            return deposit;
        }

        public virtual IList GetDepositItems(int depositId)
        {
            return _DepositDataAccess.GetDepositItems(depositId);
        }

        public IList GetDepositItems(IList saleItemList)
        {
            var depositItemList = new List<DepositItem>();
            foreach (SaleItem saleItem in saleItemList)
            {
                if(saleItem == null)
                    continue;

                var depositItem = 
                    new DepositItem
                    {
                        DepositId = saleItem.SaleOrderID,
                        ProductId = saleItem.ProductID,
                        FKProduct = saleItem.FKProduct,
                        UnitPriceIn = saleItem.UnitPriceIn,
                        UnitPriceOut = saleItem.UnitPriceOut,
                        Discount = saleItem.Discount,
                        QtySold = saleItem.QtySold                        
                    };

                if (saleItem.FKProduct != null)
                    depositItem.ProductName = saleItem.FKProduct.ProductName;

                depositItemList.Add(depositItem);
            }
            return depositItemList;
        }

        //Report
        public IList GetDepositHistories(IList searchCriteria, bool headerOnly)
        {
            var depositReportList = new List<DepositReport>();
            var depositList = _DepositDataAccess.GetDepositHistories(searchCriteria);
            var depositId = 0;
            foreach (Object[] anObject in depositList)
            {
                if (anObject == null)
                    continue;

                var deposit = anObject[0] as Deposit;                
                var customer = anObject[1] as Customer;
                var user = anObject[2] as User;
                var depositItem = anObject[3] as DepositItem;
                var product = anObject[4] as Product;

                if ((deposit == null) || (customer == null) || (user == null))
                    continue;

                var unitPriceOut = 0f;
                if (depositItem != null)
                {
                    unitPriceOut = depositItem.UnitPriceOut -
                        ((depositItem.UnitPriceOut*depositItem.Discount)/100);
                }

                var depositReport = 
                    new DepositReport
                    {
                        DepositId = deposit.DepositId,
                        DepositNumber = deposit.DepositNumber,
                        DepositDate = deposit.DepositDate,
                        CustomerName = deposit.CustomerName,
                        CashierName = deposit.CashierName,
                        ExchangeRate = deposit.ExchangeRate,
                        CardNumber = deposit.CardNumber,
                        ReferenceNum = deposit.ReferenceNum,
                        UpdateDate = deposit.UpdateDate,
                        ProductId = depositItem != null ? depositItem.ProductId : 0,
                        ProductName = product != null ? (product.ProductName + " (" + product.ForeignCode + ")") : string.Empty,
                        UnitPriceIn = depositItem != null ? depositItem.UnitPriceIn : 0,
                        UnitPriceOut = unitPriceOut,
                        Discount = depositItem != null ? depositItem.Discount : 0,
                        QtySold = depositItem != null ? depositItem.QtySold : 0,
                        SubTotal = depositItem != null ? (depositItem.QtySold * unitPriceOut) : 0,
                        DepositItemId = depositItem != null ? depositItem.DepositItemId : 0
                    };

                if (!string.IsNullOrEmpty(deposit.ReferenceNum))
                    depositReport.DepositNumber += " (" + deposit.ReferenceNum + ")";
 
                if(depositId != deposit.DepositId)
                {
                    depositId = deposit.DepositId;

                    depositReport.ReportHeader = 1;
                    depositReport.AmountSoldInt = deposit.AmountSoldInt;
                    depositReport.AmountPaidInt = deposit.AmountPaidInt;
                    depositReport.AmountPaidRiel = deposit.AmountPaidRiel;
                    depositReport.AmountReturnInt = (-1) * deposit.AmountReturnInt;
                    depositReport.AmountReturnRiel = (-1) * deposit.AmountReturnRiel;
                    depositReport.TotalDiscount = deposit.Discount;
                }
                if (headerOnly)
                {
                    if(depositReport.ReportHeader == 1)
                        depositReportList.Add(depositReport);
                }
                else
                    depositReportList.Add(depositReport);
            }

            return depositReportList;
        }

        public IList GetSaleHistories(IList depositReportList)
        {
            var saleOrderReportList = new List<SaleOrderReport>();
            foreach (DepositReport depositReport in depositReportList)
            {
                if(depositReport == null)
                    continue;

                var saleOrderReport = new SaleOrderReport();
                saleOrderReport.AmountPaidInt = depositReport.AmountPaidInt;
                saleOrderReport.AmountPaidRiel = depositReport.AmountPaidRiel;
                saleOrderReport.AmountReturnInt = depositReport.AmountReturnInt;
                saleOrderReport.AmountReturnRiel = depositReport.AmountReturnRiel;
                saleOrderReport.AmountSoldInt = depositReport.AmountSoldInt;
                saleOrderReport.CardNumber = depositReport.CardNumber;
                saleOrderReport.CashierName = depositReport.CashierName;
                //saleOrderReport.CustomerID = depositReport.C
                saleOrderReport.CustomerName = depositReport.CustomerName;
                //saleOrderReport.DepositAmount = 0;
                saleOrderReport.Discount = depositReport.Discount;
                //saleOrderReport.DiscountTypeID = depositReport.D
                saleOrderReport.ExchangeRate = depositReport.ExchangeRate;
                saleOrderReport.ProductID = depositReport.ProductId;
                saleOrderReport.ProductName = depositReport.ProductName;
                saleOrderReport.QtySold = depositReport.QtySold;
                saleOrderReport.ReferenceNum = depositReport.ReferenceNum;
                //saleOrderReport.ReportHeader = 
                //saleOrderReport.ReportID = depositReport.
                //saleOrderReport.ReportTypeStr = 
                saleOrderReport.SaleItemID = depositReport.DepositItemId;
                saleOrderReport.SaleOrderDate = (DateTime)depositReport.DepositDate;
                saleOrderReport.SaleOrderNumber = depositReport.DepositNumber;
                saleOrderReport.SalesOrderId = depositReport.DepositId;
                saleOrderReport.SubTotal = depositReport.SubTotal;
                saleOrderReport.TotalDiscount = depositReport.TotalDiscount;
                saleOrderReport.UnitPriceIn = depositReport.UnitPriceIn;
                saleOrderReport.UnitPriceOut = depositReport.UnitPriceOut;

                //if (saleItem.FKProduct != null)
                //{
                //    if (!string.IsNullOrEmpty(saleItem.FKProduct.ProductCode))
                //    {
                //        var productCode =
                //            !string.IsNullOrEmpty(depositReport..ForeignCode) ?
                //            saleItem.FKProduct.ForeignCode :
                //            string.Empty;
                //        productCode = productCode.Replace(",", string.Empty);
                //        productCode = productCode.Replace(" ", string.Empty);
                //        saleOrderReport.ProductCode =
                //            productCode +
                //            " (" +
                //            (string.IsNullOrEmpty(saleItem.FKProduct.ProductCode) ?
                //            saleItem.FKProduct.ProductCode :
                //            string.Empty) +
                //            ")";
                //        saleOrderReport.ProductName = depositReport.ProductName + " (" + productCode + ")";
                //    }
                //}

                saleOrderReportList.Add(saleOrderReport);
            }

            return saleOrderReportList;
        }
    }
}