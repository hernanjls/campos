using System;
using Castle.Facilities.AutomaticTransactionManagement;
using Castle.Facilities.NHibernateIntegration;
using Castle.MicroKernel;
using Castle.Windsor;
using EzPos.DataAccess;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Service.Payment;
using EzPos.DataAccess.Payments;
using EzPos.Service.Product;

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

        protected void RegistredEzPosComponent()
        {
            //Product
            AddComponent("Product.Service", typeof (ProductService));
            AddComponent("Product.DataAccess", typeof (ProductDataAccess));

            // Customer
            AddComponent("Customer.Service", typeof (CustomerService));
            AddComponent("Customer.DataAccess", typeof (CustomerDataAccess));

            // Supplier
            AddComponent("Supplier.Service", typeof(SupplierService));
            AddComponent("Supplier.DataAccess", typeof(SupplierDataAccess));

            // SaleOrder
            AddComponent("SaleOrder.Service", typeof (SaleOrderService));
            AddComponent("SaleOrder.DataAccess", typeof (SaleOrderDataAccess));

            // Deposit
            AddComponent("Deposit.Service", typeof(DepositService));
            AddComponent("Deposit.DataAccess", typeof(DepositDataAccess));

            // Payment
            AddComponent("Payment.Service", typeof(PaymentService));
            AddComponent("Payment.DataAccess", typeof(PaymentDataAccess));

            // User
            AddComponent("User.Service", typeof (UserService));
            AddComponent("User.DataAccess", typeof (UserDataAccess));

            //// ExchageRate
            //AddComponent("ExchageRate.Service", typeof (ExchangeRateService));
            //AddComponent("ExchageRate.DataAccess", typeof (ExchangeRateDataAccess));

            //Common
            AddComponent("Common.Service", typeof (CommonService));
            AddComponent("Common.DataAccess", typeof (CommonDataAccess));

            //Expense
            AddComponent("Expense.Service", typeof (ExpenseService));
            AddComponent("Expense.DataAccess", typeof (ExpenseDataAccess));
        }

        protected void RegisterComponents()
        {
            RegistredEzPosComponent();
        }
    }
}