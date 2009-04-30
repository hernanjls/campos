using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using EzPos.DataAccess.Common;
using EzPos.Model;
using EzPos.Model.Common;
using EzPos.Properties;
using EzPos.Utility;

namespace EzPos.Service.Common
{
    public class CommonService
    {
        private readonly CommonDataAccess _CommonDataAccess;

        public CommonService(CommonDataAccess commonDataAccess)
        {
            _CommonDataAccess = commonDataAccess;
        }

        public static void StoreUserContext(User usrObj)
        {
            var _UserService = ServiceFactory.GenerateServiceInstance().GenerateUserService();

            UserContext.User = usrObj;
            UserContext.UserPermissions = _UserService.GetPermissions(usrObj.UserID);

            var counterList = _UserService.GetCounterByIP(ClientInfoHelper.GetHostIP());
            if (counterList.Count == 0)
                return;

            UserContext.Counter = (Counter) counterList[0];
        }

        public static void StoreApplicationContext()
        {
            var _ExchangeRateService =
                ServiceFactory.GenerateServiceInstance().GenerateExchangeRateService();
            AppContext.ExchangeRate = _ExchangeRateService.GetLastExchangeRate(1);
        }

        public static DataTable IListToDataTable(Type objType, IList iListToConvert)
        {
            if (iListToConvert == null)
                throw new ArgumentNullException("iListToConvert", "IListToConvert");

            var dataTableResult = new DataTable();
            var PropertyInfos = objType.GetProperties();
            foreach (var propertyInfo in PropertyInfos)
            {
                var dataColumn = new DataColumn(propertyInfo.Name, propertyInfo.PropertyType);
                dataTableResult.Columns.Add(dataColumn);
            }

            foreach (var objInstance in iListToConvert)
            {
                var dataRow = dataTableResult.NewRow();
                foreach (var propertyInfo in PropertyInfos)
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
                dataTableResult.Rows.Add(dataRow);
            }
            return dataTableResult;
        }

        public static BindingList<object> IListToBindingList(IList iListToConvert)
        {
            if (iListToConvert == null)
                throw new ArgumentNullException("iListToConvert", "IListToConvert");

            var bindingList = new BindingList<object>();
            foreach (var objInstance in iListToConvert)
                bindingList.Add(objInstance);
            return bindingList;
        }

        public void InitializeGlobalConfiguration()
        {
            AppContext.ExchangeRate = GetExchangeRate();
            AppContext.IntegratedModuleList = GetIntegratedModules();
            var searchCriteria = new List<string>
                                     {
                                         "ParameterTypeID IN (" +
                                         Resources.AppParamServerPhotoPath + ", " +
                                         Resources.AppParamShopName + ", " +
                                         Resources.AppParamShopAddress + ", " +
                                         Resources.AppParamShopContact + ", " +
                                         Resources.AppParamReceiptFooter + ")"
                                     };
            var appParameterList = GetAppParameters(searchCriteria);
            foreach (AppParameter appParameter in appParameterList)
            {
                if (appParameter.ParameterTypeID.ToString().Equals(Resources.AppParamServerPhotoPath))
                    AppContext.ServerPhotoPath = appParameter.ParameterLabel;
                else if (appParameter.ParameterTypeID.ToString().Equals(Resources.AppParamShopName))
                    AppContext.ShopName = appParameter.ParameterLabel;
                else if (appParameter.ParameterTypeID.ToString().Equals(Resources.AppParamShopAddress))
                    AppContext.ShopAddress = appParameter.ParameterLabel;
                else if (appParameter.ParameterTypeID.ToString().Equals(Resources.AppParamShopContact))
                    AppContext.ShopContact = appParameter.ParameterLabel;
                else if (appParameter.ParameterTypeID.ToString().Equals(Resources.AppParamReceiptFooter))
                    AppContext.ReceiptFooter = appParameter.ParameterLabel;
            }
        }

        //Exchange rate
        public ExchangeRate GetExchangeRate()
        {
            var exchangeRateList = _CommonDataAccess.GetExchangeRate();
            if (exchangeRateList != null)
                if (exchangeRateList.Count != 0)
                    return (ExchangeRate)exchangeRateList[0];

            return null;
        }

        //Integrated module
        public IList GetIntegratedModules()
        {
            var integratedModuleList = _CommonDataAccess.GetIntegratedModules();
            return integratedModuleList;
        }

        public static bool IsIntegratedModule(string moduleName)
        {
            if (AppContext.IntegratedModuleList == null)
                return false;

            var integratedFlag = false;
            if (AppContext.IntegratedModuleList != null)
            {
                foreach (IntegratedModule integratedModule in AppContext.IntegratedModuleList)
                {
                    if (!moduleName.Equals(integratedModule.ModuleName))
                        continue;

                    integratedFlag = integratedModule.IsIntegrated;
                    break;
                }
            }

            return integratedFlag;
        }

        //Application parameters
        public virtual IList GetAppParameterTypes()
        {
            return _CommonDataAccess.GetAppParameterTypes();
        }

        public virtual IList GetAppParameters(IList searchCriteria)
        {
            return _CommonDataAccess.GetAppParameters(searchCriteria);
        }

        public void InitializeWorkSpace()
        {
            AppContext.CultureInfo = new CultureInfo(CultureInfo.CurrentCulture.Name);
            AppContext.Counter = GetCounter();
        }

        public virtual Counter GetCounter()
        {
            var ipAddress = ClientInfoHelper.GetHostIP();
            var counterList = _CommonDataAccess.GetCounterByIP(ipAddress);
            if (counterList == null)
                return null;

            if (counterList.Count == 0)
            {
                ipAddress = ClientInfoHelper.GetHostName();
                counterList = _CommonDataAccess.GetCounterByIP(ipAddress);
            }

            if (counterList.Count == 0)
                return null;

            return counterList[0] as Counter;
        }

        public void InitializeCustomizedConfiguration(User usrObj)
        {
            AppContext.User = usrObj;
            var userService =
                ServiceFactory.GenerateServiceInstance().GenerateUserService();
            var userPermissionList = userService.GetPermissions(usrObj.UserID);
            if (userPermissionList == null)
                return;
            AppContext.UserPermissionList = userPermissionList;
        }
    }
}