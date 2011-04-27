using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EzPos.DataAccess;
using EzPos.GUIs.Components;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Utility;
using DataTable=System.Data.DataTable;

namespace EzPos.Service.Common
{
    public class CommonService
    {
        private readonly CommonDataAccess _commonDataAccess;

        public CommonService(CommonDataAccess commonDataAccess)
        {
            _commonDataAccess = commonDataAccess;
        }

        //Operation log
        public void InsertOperationLog(int userId, int operationId)
        {
            var operationLog = 
                new OperationLog
                {
                    UserID = userId,
                    OperationID = operationId,
                    LogDateTime = DateTime.Now,
                    IPAddress = ClientInfoHelper.GetHostIP()
                };

            _commonDataAccess.InsertOperationLog(operationLog);
        }

        //Application parameters
        public virtual IList GetAppParameterTypes()
        {
            return _commonDataAccess.GetAppParameterTypes();
        }

        public virtual IList GetAppParameters()
        {
            return _commonDataAccess.GetAppParameters();
        }

        public virtual IList GetAppParameters(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", Resources.MsgInvalidSearchCriteria);

            return _commonDataAccess.GetAppParameters(searchCriteria);
        }

        public virtual IList GetAppParametersByType(int parameterTypeId)
        {
            return _commonDataAccess.GetAppParametersByType(parameterTypeId);
        }

        public virtual IList GetAppParametersByTypeSortByValue(int parameterTypeId)
        {
            return _commonDataAccess.GetAppParametersByTypeSortByValue(parameterTypeId);
        }

        public static IList GetAppParametersByTypeStatic(IList appParamList, int parameterTypeId)
        {
            if (appParamList == null)
                throw new ArgumentNullException("appParamList", Resources.MsgInvalidAppParameter);

            return appParamList.Cast<AppParameter>().Where(appParameter => appParameter.ParameterTypeID == parameterTypeId).ToList();
        }

        public virtual IList GetAppParametersByType(IList appParamList, int parameterTypeId)
        {
            if (appParamList == null)
                throw new ArgumentNullException("appParamList", Resources.MsgInvalidAppParameter);

            return appParamList.Cast<AppParameter>().Where(appParameter => appParameter.ParameterTypeID == parameterTypeId).ToList();
        }

        public virtual void AppParameterManagement(AppParameter appParameter, string requestStr)
        {
            if (appParameter == null)
                throw new ArgumentNullException("appParameter", Resources.MsgInvalidAppParameter);

            if (requestStr == null)
                throw new ArgumentNullException("requestStr", Resources.MsgOperationRequestUnknown);

            if (requestStr.Length == 0)
                throw new ArgumentNullException("requestStr", Resources.MsgOperationRequestUnknown);

            if (requestStr == Resources.OperationRequestInsert)
                InsertAppParameter(appParameter);
            else if (requestStr == Resources.OperationRequestUpdate)
                UpdateAppParameter(appParameter);
            else
                DeleteAppParameter(appParameter);
        }

        private void InsertAppParameter(AppParameter appParameter)
        {
            _commonDataAccess.InsertAppParameter(appParameter);
        }

        private void UpdateAppParameter(AppParameter appParameter)
        {
            _commonDataAccess.UpdateAppParameter(appParameter);
        }

        private void DeleteAppParameter(AppParameter appParameter)
        {
            _commonDataAccess.DeleteAppParameter(appParameter);
        }

        public void PopAppParamCombobox(ref ComboBox appParamComboBox, IList appParamList, int appParamType)
        {
            appParamComboBox.DataSource = GetAppParametersByType(
                appParamList, appParamType);
            if (((IList) appParamComboBox.DataSource).Count == 0) 
                return;

            appParamComboBox.DisplayMember = Resources.AppParamDisplay;
            appParamComboBox.ValueMember = Resources.AppParamValue;
        }

        public void PopAppParamExtendedCombobox(
            ref ExtendedComboBox appParamComboBox,
            IList appParamList,
            int appParamType,
            bool defaultSelect)
        {
            appParamComboBox.CustomizedDataBinding(
                GetAppParametersByType(appParamList, appParamType),
                Resources.AppParamDisplay,
                Resources.AppParamValue,
                defaultSelect);
        }

        public void PopAppParamComboboxWithSelect(
            ref ComboBox appParamComboBox,
            IList appParamList,
            int appParamType)
        {
            appParamComboBox.DisplayMember = Resources.AppParamDisplay;
            appParamComboBox.ValueMember = Resources.AppParamValue;
            appParamComboBox.DataSource = GetAppParametersByType(
                appParamList, appParamType);
            appParamComboBox.SelectedIndex = -1;
        }

        public void PopAppParamCheckListBox(
            ref CheckedListBox appParamCheckListBox,
            IList appParamList,
            int appParamType)
        {
            appParamCheckListBox.DataSource = GetAppParametersByType(
                appParamList, appParamType);
            appParamCheckListBox.DisplayMember = Resources.AppParamDisplay;
            appParamCheckListBox.ValueMember = Resources.AppParamValue;
            appParamCheckListBox.SelectedIndex = -1;
        }

        public void InitializeGlobalConfiguration()
        {
            AppContext.ExchangeRate = GetExchangeRate();
            AppContext.IntegratedModuleList = GetIntegratedModules();
            var searchCriteria = 
                new List<string>
                {
                    "ParameterTypeID IN (" +
                    Resources.AppParamServerPhotoPath + ", " +
                    Resources.AppParamShopName + ", " +
                    Resources.AppParamShopAddress + ", " +
                    Resources.AppParamShopContact + ", " +
                    Resources.AppParamBarcodeTemplate + ", " +
                    Resources.AppParamIssueReceipt + ", " +
                    Resources.AppParamReceiptTemplate + ", " +
                    Resources.AppParamReceiptPrinter + ", " +
                    Resources.AppParamReceiptFooter + ")"
                };
            var appParameterList = GetAppParameters(searchCriteria);
            foreach (AppParameter appParameter in appParameterList)
            {
                if (appParameter.ParameterTypeID.ToString().Equals(Resources.AppParamServerPhotoPath))
                    AppContext.ServerPhotoPath = appParameter.ParameterLabel;
                else if (appParameter.ParameterTypeID.ToString().Equals(Resources.AppParamShopName))
                {
                    AppContext.ShopNameLocal = appParameter.ParameterValue;
                    AppContext.ShopName = appParameter.ParameterLabel;
                }
                else if (appParameter.ParameterTypeID.ToString().Equals(Resources.AppParamShopAddress))
                    AppContext.ShopAddress = appParameter.ParameterLabel;
                else if (appParameter.ParameterTypeID.ToString().Equals(Resources.AppParamShopContact))
                    AppContext.ShopContact = appParameter.ParameterLabel;
                else if (appParameter.ParameterTypeID.ToString().Equals(Resources.AppParamReceiptFooter))
                    AppContext.ReceiptFooter = appParameter.ParameterLabel;
                else if (appParameter.ParameterTypeID.ToString().Equals(Resources.AppParamBarcodeTemplate))
                    AppContext.BarCodeTemplate = appParameter.ParameterLabel;
                else if (appParameter.ParameterTypeID.ToString().Equals(Resources.AppParamReceiptTemplate))
                    AppContext.ReceiptTemplate = appParameter.ParameterLabel;
                else if (appParameter.ParameterTypeID.ToString().Equals(Resources.AppParamIssueReceipt))
                    AppContext.IssueReceipt = appParameter.ParameterLabel;
                else if (appParameter.ParameterTypeID.ToString().Equals(Resources.AppParamReceiptPrinter))
                    AppContext.ReceiptPrinter = appParameter.ParameterLabel;
            }
        }

        public void InitializeWorkSpace()
        {
            AppContext.CultureInfo = new CultureInfo(CultureInfo.CurrentCulture.Name);
            AppContext.Counter = GetCounter();
        }

        public void InitializeCustomizedConfiguration(User usrObj)
        {
            AppContext.User = usrObj;
            UserService userService =
                ServiceFactory.GenerateServiceInstance().GenerateUserService();
            IList userPermissionList = userService.GetPermissionsByUser(usrObj.UserID);
            if (userPermissionList == null)
                return;
            AppContext.UserPermissionList = userPermissionList;
        }

        public void StoreApplicationContext(User usrObj, ExchangeRate exchangeRate)
        {
            AppContext.CultureInfo = new CultureInfo(CultureInfo.CurrentCulture.Name);

            AppContext.User = usrObj;

            if (exchangeRate == null)
                exchangeRate = GetExchangeRate();
            if (exchangeRate == null)
                return;
            AppContext.ExchangeRate = exchangeRate;

            var userService =
                ServiceFactory.GenerateServiceInstance().GenerateUserService();
            var userPermissionList = userService.GetPermissionsByUser(usrObj.UserID);
            if (userPermissionList == null)
                return;
            AppContext.UserPermissionList = userPermissionList;
        }

        public virtual Counter GetCounter()
        {
            var ipAddress = ClientInfoHelper.GetHostIP();
            var counterList = _commonDataAccess.GetCounterByIP(ipAddress);
            if (counterList == null)
                return null;

            if (counterList.Count == 0)
            {
                ipAddress = ClientInfoHelper.GetHostName();
                counterList = _commonDataAccess.GetCounterByIP(ipAddress);
            }

            if (counterList.Count == 0)
                return null;

            return counterList[0] as Counter;
        }

        public static DataTable IListToDataTable(Type objType, IList iListToConvert)
        {
            if (iListToConvert == null)
                throw new ArgumentNullException("iListToConvert", Resources.MsgInvalidInput);

            var dataTableResult = new DataTable();
            var propertyInfos = objType.GetProperties();
            foreach (var dataColumn in
                propertyInfos.Select(propertyInfo => new DataColumn(propertyInfo.Name, propertyInfo.PropertyType)))
            {
                dataTableResult.Columns.Add(dataColumn);
            }

            foreach (var objInstance in iListToConvert)
            {
                var dataRow = dataTableResult.NewRow();
                foreach (var propertyInfo in propertyInfos)
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
                dataTableResult.Rows.Add(dataRow);
            }
            return dataTableResult;
        }

        public static BindingList<object> IListToBindingList(IList iListToConvert)
        {
            if (iListToConvert == null)
                throw new ArgumentNullException("iListToConvert", Resources.MsgInvalidInput);

            var bindingList = new BindingList<object>();
            foreach (object objInstance in iListToConvert)
                bindingList.Add(objInstance);
            return bindingList;
        }

        public static void DoSynchronizePhoto(string sourcePath, string destinationPath)
        {
            var directoryInfo = new DirectoryInfo(sourcePath);
            if (directoryInfo.Exists)
            {
                foreach (DirectoryInfo remoteDirectoryInfo in directoryInfo.GetDirectories())
                {
                    var localDirectoryInfo =
                        new DirectoryInfo(destinationPath + @"\" + remoteDirectoryInfo.Name);
                    if (!localDirectoryInfo.Exists)
                        localDirectoryInfo.Create();
                    DoSynchronizePhoto(remoteDirectoryInfo.FullName, localDirectoryInfo.FullName);
                }

                foreach (var remoteFileInfo in directoryInfo.GetFiles())
                {
                    if (!remoteFileInfo.Exists) 
                        continue;

                    var localFileInfo =
                        new FileInfo(destinationPath + @"\" + remoteFileInfo.Name);
                    if (!localFileInfo.Exists)
                        remoteFileInfo.CopyTo(localFileInfo.FullName);
                }
            }
        }

        //Exchange rate
        public ExchangeRate GetExchangeRate()
        {
            var exchangeRateList = _commonDataAccess.GetExchangeRate();
            if (exchangeRateList != null)
                if (exchangeRateList.Count != 0)
                    return (ExchangeRate) exchangeRateList[0];

            return null;
        }

        //Integrated module
        public IList GetIntegratedModules()
        {
            var integratedModuleList = _commonDataAccess.GetIntegratedModules();
            return integratedModuleList;
        }

        public static bool IsIntegratedModule(string moduleName)
        {
            if (AppContext.IntegratedModuleList == null)
                return false;

            return (from IntegratedModule integratedModule in AppContext.IntegratedModuleList
                    where moduleName.Equals(integratedModule.ModuleName)
                    select integratedModule.IsIntegrated).FirstOrDefault();
        }

        public virtual void InsertExchangeRate(ExchangeRate exchangeRate)
        {
            if (exchangeRate == null)
                throw new ArgumentNullException("exchangeRate", Resources.MsgInvalidExchangeRate);

            _commonDataAccess.InsertExchangeRate(exchangeRate);
            StoreApplicationContext(AppContext.User, exchangeRate);
        }

        public static void RecordLog(string logMsg, string startUpPath)
        {
            //var directoryInfo = new DirectoryInfo(Application.StartupPath);
            var directoryInfo = new DirectoryInfo(startUpPath);
            if (!directoryInfo.Exists) 
                return;

            var logFileInfo = new FileInfo("log.txt");
            if (!logFileInfo.Exists)
                logFileInfo.CreateText();

            var streamWriter = File.AppendText(logFileInfo.FullName);
            streamWriter.WriteLine(logMsg);
            streamWriter.Close();
        }

        public static void DeleteFile(string directoryPath, string baseFileName, string fileExtension, bool temporayFileOnly)
        {
            if(string.IsNullOrEmpty(directoryPath) ||
                string.IsNullOrEmpty(baseFileName) ||
                string.IsNullOrEmpty(fileExtension))
                return;
            
            var directoryInfo = new DirectoryInfo(directoryPath);  
            if(!directoryInfo.Exists)
                return;

            var fileInfoList = directoryInfo.GetFiles(fileExtension);
            foreach (var fileInfo in fileInfoList.Where(fileInfo => fileInfo.Exists).Where(fileInfo => fileInfo.Name.Contains(baseFileName)))
            {
                if(!temporayFileOnly)
                    fileInfo.Delete();
                else
                {
                    if(fileInfo.Name.Length > baseFileName.Length)
                        fileInfo.Delete();
                }
            }
        }        
    }
}