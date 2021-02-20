using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Net;

namespace LibraryGenius
{
    public class MachineInfoHelper
    {
        /// <summary>
        /// 获取MAC地址
        /// </summary>
        /// <returns></returns>
        public static string GetMacAddress()
        {
            string mac = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    mac = mo["MacAddress"].ToString();
                    mac = string.Format("{0}-{1}-{2}-{3}-{4}-{5}",
                       mac.Substring(0, 2),
                       mac.Substring(3, 2),
                       mac.Substring(6, 2),
                       mac.Substring(9, 2),
                       mac.Substring(12, 2),
                       mac.Substring(15, 2));
                    break;
                }
            }
            return mac;
        }

        /// <summary>
        /// 获取IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {
            string ip = string.Empty;
            IPAddress[] addressList = Dns.GetHostAddresses(Dns.GetHostName());
            for (int i = 0; i < addressList.Length; i++)
            {
                ip = addressList[i].ToString();
            }
            return ip;
        }

        /// <summary>
        /// 获取操作系统的登录用户名
        /// </summary>
        /// <returns></returns>
        public static string GetUserName()
        {
            return Environment.UserName;
        }

        /// <summary>
        /// 取得域用户名
        /// </summary>
        /// <returns></returns>
        public static string GetDomainUserName()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }

        /// <summary>
        /// 获取计算机名
        /// </summary>
        /// <returns></returns>
        public static string GetComputerName()
        {
            return Environment.MachineName;
        } 
    }
}
