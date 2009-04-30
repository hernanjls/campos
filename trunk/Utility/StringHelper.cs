using System;

namespace EzPos.Utility
{
    /// <summary>
    /// Summary description for StringHelper.
    /// </summary>
    public class StringHelper
    {
        public static bool IsDefined(String s)
        {
            return !(s == null || String.Empty.Equals(s));
        }

        public static String GetNotNullString(String s)
        {
            return s == null ? " " : s;
        }

        public static String GetString(Object o)
        {
            return o == null ? String.Empty : o.ToString();
        }

        public static string Left(string param, int length)
        {
            string result = param.Substring(0, length);
            return result;
        }

        public static string Right(string param, int length)
        {
            string result = param.Substring(param.Length - length, length);
            return result;
        }

        public static string Increment(string param, int identityIncrement)
        {
            if (param == null)
                throw new ArgumentNullException("Param", "Param");
            if (param.Length == 0)
                throw new ArgumentOutOfRangeException("Param", "Param");
            string result = param;
            result = (Int32.Parse(result) + identityIncrement).ToString();
            return result;
        }
    }
}