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

        public static string GetHostIp()
        {
            var ipHostentry = Dns.GetHostEntry(GetHostName());

            // Enumerate IP addresses
            foreach (var ipaddress in ipHostentry.AddressList)
                return ipaddress.ToString();

            return string.Empty;
        }
    }
}