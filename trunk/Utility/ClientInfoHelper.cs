using System.Net;

namespace EzPos.Utility
{
    /// <summary>
    /// Summary description for ClientInfoService.
    /// </summary>
    public class ClientInfoHelper
    {
        public static string GetHostName()
        {
            return Dns.GetHostName();
        }

        public static string GetHostIP()
        {
            IPHostEntry ipHostentry = Dns.GetHostEntry(GetHostName());

            // Enumerate IP addresses
            foreach (IPAddress ipaddress in ipHostentry.AddressList)
                return ipaddress.ToString();

            return string.Empty;
        }
    }
}