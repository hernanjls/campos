using System;
using System.Configuration;
using EzPos.Service.Common;
using EzPos.Service.Payment;
using EzPos.Service.Product;

namespace EzPos.Service
{
    public class ServiceFactory
    {
        private static readonly String APP_XML_CONFIG = ConfigurationManager.AppSettings["ServiceHibernatePath"];
        private static ApplicationContainer _ApplicationContainer;
        private static ServiceFactory _ServiceInstance;

        private ServiceFactory()
        {
            if (_ApplicationContainer == null)
                _ApplicationContainer = new ApplicationContainer(APP_XML_CONFIG);
        }

        public static ServiceFactory GenerateServiceInstance()
        {
            if (_ServiceInstance == null)
                _ServiceInstance = new ServiceFactory();
            return _ServiceInstance;
        }

        public ProductService GenerateProductService()
        {
            return (ProductService) _ApplicationContainer[typeof (ProductService)];
        }

        public CustomerService GenerateCustomerService()
        {
            return (CustomerService) _ApplicationContainer[typeof (CustomerService)];
        }

        public SaleOrderService GenerateSaleOrderService()
        {
            return (SaleOrderService) _ApplicationContainer[typeof (SaleOrderService)];
        }

        public DepositService GenerateDepositService()
        {
            return (DepositService)_ApplicationContainer[typeof(DepositService)];
        }

        public PaymentService GeneratePaymentService()
        {
            return (PaymentService)_ApplicationContainer[typeof(PaymentService)];
        }

        public UserService GenerateUserService()
        {
            return (UserService) _ApplicationContainer[typeof (UserService)];
        }

        public SupplierService GenerateSupplierService()
        {
            return (SupplierService) _ApplicationContainer[typeof(SupplierService)];
        }

        public CommonService GenerateCommonService()
        {
            return (CommonService) _ApplicationContainer[typeof (CommonService)];
        }

        public ExpenseService GenerateExpenseService()
        {
            return (ExpenseService) _ApplicationContainer[typeof (ExpenseService)];
        }
    }
}