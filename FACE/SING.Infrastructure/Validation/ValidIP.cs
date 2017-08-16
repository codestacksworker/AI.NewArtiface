using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using SING.Infrastructure.Regexs;
using SING.Data.BaseTools;

namespace SING.Infrastructure.Validation
{
    public class ValidIP 
    {
        public static bool IsIPAddr(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
            {
                MessageBoxHelper.Show("Ip地址为空！");
                return false;
            }
            if (!Regex.IsMatch(ip, RegexString.IP))
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
