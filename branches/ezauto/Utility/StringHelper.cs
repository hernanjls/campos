using System;
using System.Text.RegularExpressions;

namespace EzPos.Utility
{
    /// <summary>
    /// Summary description for StringHelper.
    /// </summary>
    public class StringHelper
    {
        public static bool IsDefined(String str)
        {
            return !(str == null || String.Empty.Equals(str));
        }

        public static String GetNotNullString(String str)
        {
            return str ?? " ";
        }

        public static String GetString(Object obj)
        {
            return obj == null ? String.Empty : obj.ToString();
        }

        public static string Left(string param, int length)
        {
            var result = param.Substring(0, length);
            return result;
        }

        public static string Right(string param, int length)
        {
            var result = param.Substring(param.Length - length, length);
            return result;
        }

        public static int Length(string str)
        {
            return str == null ? 0 : str.Length;
        }

        public static int Length(string str, bool trim)
        {
            if (str == null)
                return 0;

            return trim ? str.Trim().Length : 0;
        }

        public static string Increment(string param, int identityIncrement)
        {
            if (Length(param) == 0)
                throw new ArgumentNullException("param", "Param");

            var result = param;
            result = (Int32.Parse(result) + identityIncrement).ToString();
            return result;
        }

        //public static bool IsValidatedString(string stringToParse, string regularExpression)
        //{
        //    var returnResult = true;

        //    Regex

        //    stringToParse.

        //    return returnResult;
        //}
    }
}