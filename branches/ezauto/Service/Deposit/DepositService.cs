using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EzPos.DataAccess;
using EzPos.Model;
using EzPos.Properties;

namespace EzPos.Service
{
    public class DepositService
    {
        private readonly DepositDataAccess _depositDataAccess;

        public DepositService(DepositDataAccess depositDataAccess)
        {
            _depositDataAccess = depositDataAccess;
        }

        public virtual IList GetDeposits(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", Resources.ConstSearchCriteria);

            return _depositDataAccess.GetDeposits(searchCriteria);
        }

        public virtual void UpdateDeposit(Deposit deposit)
        {
            _depositDataAccess.UpdateDeposit(deposit);
        }

        public virtual void InsertDeposit(Deposit deposit)
        {
            if (deposit == null)
                throw new ArgumentNullException("deposit", Resources.ConstDeposit);

            deposit.UpdateDate = DateTime.Now;
            _depositDataAccess.InsertDeposit(deposit);
            deposit.DepositNumber = "D-00" + deposit.DepositId;

            _depositDataAccess.UpdateDeposit(deposit);

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
                throw new ArgumentNullException("depositItemList", Resources.ConstDepositItem);

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
                    _depositDataAccess.InsertDepositItem(depositItem);
                }
            }
            return deposit;
        }

        public virtual IList GetDepositItems(int depositId)
        {
            return _depositDataAccess.GetDepositItems(depositId);
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
            var depositList = _depositDataAccess.GetDepositHistories(searchCriteria);
            var depositId = 0;
            foreach (Object[] anObject in depositList)
            {
                if (anObject == null)
                    continue;

                var deposit = anObject[0] as Deposit;                
                var customer = anObject[1] as Customer;
                var user = anObject[2] as User;
                var depositItem = anObject[3] as DepositItem;
                var product = anObject[4] as Model.Product;

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
            return (from DepositReport depositReport in depositReportList
                    where depositReport != null
                    select new SaleOrderReport
                               {
                                   AmountPaidInt = depositReport.AmountPaidInt, 
                                   AmountPaidRiel = depositReport.AmountPaidRiel, 
                                   AmountReturnInt = depositReport.AmountReturnInt, 
                                   AmountReturnRiel = depositReport.AmountReturnRiel, 
                                   AmountSoldInt = depositReport.AmountSoldInt, 
                                   CardNumber = depositReport.CardNumber, 
                                   CashierName = depositReport.CashierName, 
                                   CustomerName = depositReport.CustomerName, 
                                   Discount = depositReport.Discount, 
                                   ExchangeRate = depositReport.ExchangeRate, 
                                   ProductID = depositReport.ProductId, 
                                   ProductName = depositReport.ProductName, 
                                   QtySold = depositReport.QtySold, 
                                   ReferenceNum = depositReport.ReferenceNum, 
                                   SaleItemID = depositReport.DepositItemId, 
                                   SaleOrderDate = (DateTime) depositReport.DepositDate, 
                                   SaleOrderNumber = depositReport.DepositNumber, 
                                   SaleOrderId = depositReport.DepositId, 
                                   SubTotal = depositReport.SubTotal, 
                                   TotalDiscount = depositReport.TotalDiscount, 
                                   UnitPriceIn = depositReport.UnitPriceIn, 
                                   UnitPriceOut = depositReport.UnitPriceOut
                               }).ToList();
        }
    }
}