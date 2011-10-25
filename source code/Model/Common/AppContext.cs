using System.Collections;
using System.Globalization;

namespace EzPos.Model
{
    public class AppContext
    {
        public static User User { get; set; }

        public static ExchangeRate ExchangeRate { get; set; }

        public static IList UserPermissionList { get; set; }

        public static CultureInfo CultureInfo { get; set; }

        public static Counter Counter { get; set; }

        public static string ServerPhotoPath { get; set; }

        public static string ShopNameLocal { get; set; }

        public static string ShopName { get; set; }

        public static string ShopAddress { get; set; }

        public static string ShopContact { get; set; }

        public static string ReceiptFooter { get; set; }

        public static string ReceiptHeader { get; set; }

        public static IList IntegratedModuleList { get; set; }

        public static string BarCodeTemplate { get; set; }

        public static string ReceiptTemplate { get; set; }

        public static string IssueReceipt { get; set; }

        public static string ReceiptPrinter { get; set; }

        public static string BarcodePrinter { get; set; }

        public static string ApplicationType { get; set; }
    }
}