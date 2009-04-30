using System;
using System.Configuration;
using EzPos.Service.Common;
using EzPos.Service.Expense;

namespace EzPos.Service
{
    public class ServiceFactory
    {
        private static readonly String APP_XML_CONFIG = ConfigurationManager.AppSettings["ServiceHibernatePath"];
        private static ApplicationContainer _ApplicationContainer;
        private static ServiceFactory _ServiceInstance;
        // Constructor
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

        public CommonService GenerateCommonService()
        {
            return (CommonService)_ApplicationContainer[typeof(CommonService)];
        }

        public ProductService GenerateProductService()
        {
            return (ProductService) _ApplicationContainer[typeof (ProductService)];
        }

        public PurchaseOrderService GeneratePurchaseOrderService()
        {
            return (PurchaseOrderService) _ApplicationContainer[typeof (PurchaseOrderService)];
        }

        public ExpenseService GenerateExpenseService()
        {
            return (ExpenseService)_ApplicationContainer[typeof(ExpenseService)];
        }

        //////////public ProductUnitService GenerateProductUnitService()
        //////////{
        //////////    return (ProductUnitService)_ApplicationContainer[typeof(ProductUnitService)];
        //////////}

        //////////public ProductCategoryService GenerateProductCategoryService()
        //////////{
        //////////    return (ProductCategoryService)_ApplicationContainer[typeof(ProductCategoryService)];
        //////////}

        //////////public CabinetService GenerateCabinetService() 
        //////////{
        //////////    return (CabinetService) _ApplicationContainer[typeof(CabinetService)];
        //////////}		

        //////////public CellService GenerateCellService() 
        //////////{
        //////////    return (CellService) _ApplicationContainer[typeof(CellService)];
        //////////}		

        public BarCodeService GenerateBarCodeService()
        {
            return (BarCodeService) _ApplicationContainer[typeof (BarCodeService)];
        }

        public SupplierService GenerateSupplierService()
        {
            return (SupplierService) _ApplicationContainer[typeof (SupplierService)];
        }

        public CustomerService GenerateCustomerService()
        {
            return (CustomerService) _ApplicationContainer[typeof (CustomerService)];
        }

        //public CustomerContactService GenerateCustomerContactService() 
        //{
        //    return (CustomerContactService) _ApplicationContainer[typeof(CustomerContactService)];
        //}						

        //public PurchaseOrderService GeneratePurchaseOrderService() 
        //{
        //    return (PurchaseOrderService) _ApplicationContainer[typeof(PurchaseOrderService)];
        //}						

        //public PurchaseItemService GeneratePurchaseItemService() 
        //{
        //    return (PurchaseItemService) _ApplicationContainer[typeof(PurchaseItemService)];
        //}

        public SaleOrderService GenerateSaleOrderService()
        {
            return (SaleOrderService) _ApplicationContainer[typeof (SaleOrderService)];
        }

        //public SaleItemService GenerateSaleItemService()
        //{
        //    return (SaleItemService)_ApplicationContainer[typeof(SaleItemService)];
        //}

        public UserService GenerateUserService()
        {
            return (UserService) _ApplicationContainer[typeof (UserService)];
        }

        public ExchangeRateService GenerateExchangeRateService()
        {
            return (ExchangeRateService) _ApplicationContainer[typeof (ExchangeRateService)];
        }

        public CourtesyService GenerateCourtesyService()
        {
            return (CourtesyService) _ApplicationContainer[typeof (CourtesyService)];
        }

        public ReportService GenerateReportService()
        {
            return (ReportService) _ApplicationContainer[typeof (ReportService)];
        }
    }
}