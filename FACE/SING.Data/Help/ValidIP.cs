using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using SING.Data.BaseTools;

namespace SING.Data.Help
{
    public class ValidIP 
    {
        public static readonly string IP = @"^((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))$";
        public static bool IsIPAddr(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
            {
                MessageBoxHelper.Show("Ip地址为空！");
                return false;
            }
            if (!Regex.IsMatch(ip, IP))
            {
                MessageBoxHelper.Show("当前Ip地址不满足ip地址正则匹配！");
                return false;
            }
            return true;
        }

        public static bool Ping(string ip)
        {
            if (!IsIPAddr(ip))
                return false;

            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(ip, 120);//第一个参数为ip地址，第二个参数为ping的时间
            if (reply != null && reply.Status == IPStatus.Success)
            {
                //ping的通
                return true;
            }
            else
            {
                //ping不通
                return false;
            }
        }
    }
}
