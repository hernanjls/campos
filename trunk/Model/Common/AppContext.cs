using System.Collections;
using System.Globalization;

namespace EzPos.Model
{
    public class AppContext
    {
        private static Counter _Counter;
        private static CultureInfo _CultureInfo;
        private static ExchangeRate _ExchangeRate;
        private static IList _IntegratedModuleList;
        private static string _ReceiptFooter;
        private static string _ServerPhotoPath;
        private static string _ShopAddress;
        private static string _ShopContact;
        private static string _ShopName;
        private static string _ReceiptHeader;
        private static User _User;
        private static IList _UserPermissionList;
        private static string _BarCodeTemplate;
        private static string _ReceiptTemplate;
        private static string _IssueReceipt;
        private static string _ReceiptPrinter;

        public static User User
        {
            get { return _User; }
            set { _User = value; }
        }

        public static ExchangeRate ExchangeRate
        {
            get { return _ExchangeRate; }
            set { _ExchangeRate = value; }
        }

        public static IList UserPermissionList
        {
            get { return _UserPermissionList; }
            set { _UserPermissionList = value; }
        }

        public static CultureInfo CultureInfo
        {
            get { return _CultureInfo; }
            set { _CultureInfo = value; }
        }

        public static Counter Counter
        {
            get { return _Counter; }
            set { _Counter = value; }
        }

        public static string ServerPhotoPath
        {
            get { return _ServerPhotoPath; }
            set { _ServerPhotoPath = value; }
        }

        public static string ShopName
        {
            get { return _ShopName; }
            set { _ShopName = value; }
        }

        public static string ShopAddress
        {
            get { return _ShopAddress; }
            set { _ShopAddress = value; }
        }

        public static string ShopContact
        {
            get { return _ShopContact; }
            set { _ShopContact = value; }
        }

        public static string ReceiptFooter
        {
            get { return _ReceiptFooter; }
            set { _ReceiptFooter = value; }
        }

        public static string ReceiptHeader
        {
            get { return _ReceiptHeader; }
            set { _ReceiptHeader = value; }
        }

        public static IList IntegratedModuleList
        {
            get { return _IntegratedModuleList; }
            set { _IntegratedModuleList = value; }
        }

        public static string BarCodeTemplate
        {
            get { return _BarCodeTemplate; }
            set { _BarCodeTemplate = value; }
        }

        public static string ReceiptTemplate
        {
            get { return _ReceiptTemplate; }
            set { _ReceiptTemplate = value; }
        }

        public static string IssueReceipt
        {
            get { return _IssueReceipt; }
            set { _IssueReceipt = value; }
        }

        public static string ReceiptPrinter
        {
            get { return _ReceiptPrinter; }
            set { _ReceiptPrinter = value; }
        }
    }
}