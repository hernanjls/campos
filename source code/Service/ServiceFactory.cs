using System;
using System.Configuration;
using EzPos.Service.Common;
using EzPos.Service.Customer;
using EzPos.Service.Deposit;
using EzPos.Service.Expense;
using EzPos.Service.Payment;
using EzPos.Service.Product;
using EzPos.Service.SaleOrder;
using EzPos.Service.Supplier;
using EzPos.Service.User;

namespace EzPos.Service
{
    public class ServiceFactory
    {
        private static readonly String AppXmlConfig = ConfigurationManager.AppSettings["ServiceHibernatePath"];
        private static ApplicationContainer _applicationContainer;
        private static ServiceFactory _serviceInstance;

        private ServiceFactory()
        {
            if (_applicationContainer == null)
                _applicationContainer = new ApplicationContainer(AppXmlConfig);
        }

        public static ServiceFactory GenerateServiceInstance()
        {
            return _serviceInstance ?? (_serviceInstance = new ServiceFactory());
        }

        public ProductService GenerateProductService()
        {
            return (ProductService) _applicationContainer[typeof (ProductService)];
        }

        public CustomerService GenerateCustomerService()
        {
            return (CustomerService) _applicationContainer[typeof (CustomerService)];
        }

        public SaleOrderService GenerateSaleOrderService()
        {
            return (SaleOrderService) _applicationContainer[typeof (SaleOrderService)];
        }

        public DepositService GenerateDepositService()
        {
            return (DepositService)_applicationContainer[typeof(DepositService)];
        }

        public PaymentService GeneratePaymentService()
        {
            return (PaymentService)_applicationContainer[typeof(PaymentService)];
        }

        public UserService GenerateUserService()
        {
            return (UserService) _applicationContainer[typeof (UserService)];
        }

        public SupplierService GenerateSupplierService()
        {
            return (SupplierService) _applicationContainer[typeof(SupplierService)];
        }

        public CommonService GenerateCommonService()
        {
            return (CommonService) _applicationContainer[typeof (CommonService)];
        }

        public ExpenseService GenerateExpenseService()
        {
            return (ExpenseService) _applicationContainer[typeof (ExpenseService)];
        }
    }
}