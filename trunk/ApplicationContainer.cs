using System;
using Castle.Facilities.AutomaticTransactionManagement;
using Castle.Facilities.NHibernateIntegration;
using Castle.MicroKernel;
using Castle.Windsor;
using EzPos.DataAccess;
using EzPos.DataAccess.Common;
using EzPos.Service;
using EzPos.Service.Common;

// Copyright 2004-2005 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace EzPos
{
    /// <summary>
    /// Summary description for ApplicationContainer.
    /// </summary>
    public class ApplicationContainer : WindsorContainer
    {
        public ApplicationContainer(String appConfig) : base(appConfig)
        {
            Init();
        }

        public ApplicationContainer(IConfigurationStore store) : base(store)
        {
            Init();
        }

        public void Init()
        {
            RegisterFacilities();
            RegisterComponents();
        }

        private void RegisterFacilities()
        {
            AddFacility("nhibernate", new NHibernateFacility());
            AddFacility("transaction", new TransactionFacility());
        }

        protected void RegistredPharmaStockComponent()
        {
            //Product
            AddComponent("Product.Service", typeof (ProductService));
            AddComponent("Product.DataAccess", typeof (ProductDataAccess));

            //Product
            AddComponent("PurchaseOrder.Service", typeof (PurchaseOrderService));
            AddComponent("PurchaseOrder.DataAccess", typeof (PurchaseOrderDataAccess));

            // BarCode
            AddComponent("BarCode.Service", typeof (BarCodeService));
            AddComponent("BarCode.DataAccess", typeof (BarCodeDataAccess));

            // Supplier
            AddComponent("Supplier.Service", typeof (SupplierService));
            AddComponent("Supplier.DataAccess", typeof (SupplierDataAccess));

            // Customer
            AddComponent("Customer.Service", typeof (CustomerService));
            AddComponent("Customer.DataAccess", typeof (CustomerDataAccess));

            // SaleOrder
            AddComponent("SaleOrder.Service", typeof (SaleOrderService));
            AddComponent("SaleOrder.DataAccess", typeof (SaleOrderDataAccess));

            // User
            AddComponent("User.Service", typeof (UserService));
            AddComponent("User.DataAccess", typeof (UserDataAccess));

            // ExchageRate
            AddComponent("ExchageRate.Service", typeof (ExchangeRateService));
            AddComponent("ExchageRate.DataAccess", typeof (ExchangeRateDataAccess));

            // Courtesy
            AddComponent("Courtesy.Service", typeof (CourtesyService));
            AddComponent("Courtesy.DataAccess", typeof (CourtesyDataAccess));

            // Report
            AddComponent("Report.Service", typeof (ReportService));
            AddComponent("Report.DataAccess", typeof (ReportDataAccess));
        }

        protected void RegisterComponents()
        {
            RegistredPharmaStockComponent();
        }

        protected void SubcribeForEvents()
        {
        }
    }
}