using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.DAL.Data;

namespace SING.Data.DAL.NewCode.Data
{
    public class SysUserData : UIDataBase
    {
        private string uuid;
        private string username;
        private string password;
        private string realname;
        private string email;
        private string mobile;
        private string adder;
        private DateTime addTime;
        private string addTimeStr;
        private DateTime lastLoginTime;
        private string lastLoginTimeStr;
        private int loginCount;
        private string ip;
        private string port; //端口号

        public string Uuid
        {
            get
            {
                return uuid;
            }

            set
            {
                uuid = value;OnPropertyChanged("Uuid");
            }
        }

        public string UserName
        {
            get
            {
                return username;
            }

            set
            {
                username = value;OnPropertyChanged("UserName");
            }
        }

        public string PassWord
        {
            get
            {
                return password;
            }

            set
            {
                password = value;OnPropertyChanged("PassWord");
            }
        }

        public string RealName
        {
            get
            {
                return realname;
            }

            set
            {
                realname = value;OnPropertyChanged("RealName");
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;OnPropertyChanged("Email");
            }
        }

        public string Adder
        {
            get
            {
                return adder;
            }

            set
            {
                adder = value;OnPropertyChanged("Adder");
            }
        }

        public DateTime AddTime
        {
            get
            {
                return addTime;
            }

            set
            {
                addTime = value;OnPropertyChanged("AddTime");
            }
        }

        public DateTime LastLoginTime
        {
            get
            {
                return lastLoginTime;
            }

            set
            {
                lastLoginTime = value;OnPropertyChanged("LastLoginTime");
            }
        }

        public int LoginCount
        {
            get
            {
                return loginCount;
            }

            set
            {
                loginCount = value;OnPropertyChanged("LoginCount");
            }
        }

        public string Mobile
        {
            get
            {
                return mobile;
            }

            set
            {
                mobile = value;
                OnPropertyChanged("Mobile");
            }
        }

        public string AddTimeStr
        {
            get
            {
                return addTimeStr;
            }

            set
            {
                addTimeStr = value;
                OnPropertyChanged("AddTimeStr");
            }
        }

        public string LastLoginTimeStr
        {
            get
            {
                return lastLoginTimeStr;
            }

            set
            {
                lastLoginTimeStr = value;
                OnPropertyChanged("LastLoginTimeStr");
            }
        }

        public string Ip
        {
            get
            {
                return ip;
            }

            set
            {
                ip = value;
                OnPropertyChanged("Ip");
            }
        }

        public string Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
                OnPropertyChanged("Port");
            }
        }
    }
}
