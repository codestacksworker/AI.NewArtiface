using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.DAL.Data;

namespace SING.Data.DAL.NewCode
{
    public class SysUser : DataProcess
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

        private int state;	//用户状态 0启用 1停用
        [JsonProperty(PropertyName = "uuid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uuid
        {
            get
            {
                return uuid;
            }

            set
            {
                uuid = value;
            }
        }
        [JsonProperty(PropertyName = "username", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }
        [JsonProperty(PropertyName = "password", NullValueHandling = NullValueHandling.Ignore)]
        public string PassWord
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
        [JsonProperty(PropertyName = "realname", NullValueHandling = NullValueHandling.Ignore)]
        public string RealName
        {
            get
            {
                return realname;
            }

            set
            {
                realname = value;
            }
        }
        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
        [JsonProperty(PropertyName = "addUid", NullValueHandling = NullValueHandling.Ignore)]
        public string Adder
        {
            get
            {
                return adder;
            }

            set
            {
                adder = value;
            }
        }
        [JsonProperty(PropertyName = "addTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime AddTime
        {
            get
            {
                return addTime;
            }

            set
            {
                addTime = value;
            }
        }
        [JsonProperty(PropertyName = "lastLoginTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime LastLoginTime
        {
            get
            {
                return lastLoginTime;
            }

            set
            {
                lastLoginTime = value;
            }
        }
        [JsonProperty(PropertyName = "loginCount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int LoginCount
        {
            get
            {
                return loginCount;
            }

            set
            {
                loginCount = value;
            }
        }
        [JsonProperty(PropertyName = "ip", NullValueHandling = NullValueHandling.Ignore)]
        public string Ip
        {
            get
            {
                return ip;
            }

            set
            {
                ip = value;
            }
        }
        [JsonProperty(PropertyName = "mobile", NullValueHandling = NullValueHandling.Ignore)]
        public string Mobile
        {
            get
            {
                return mobile;
            }

            set
            {
                mobile = value;
            }
        }
        [JsonProperty(PropertyName = "addTimeStr", NullValueHandling = NullValueHandling.Ignore)]
        public string AddTimeStr
        {
            get
            {
                return addTimeStr;
            }

            set
            {
                addTimeStr = value;
            }
        }
        [JsonProperty(PropertyName = "lastLoginTimeStr", NullValueHandling = NullValueHandling.Ignore)]
        public string LastLoginTimeStr
        {
            get
            {
                return lastLoginTimeStr;
            }

            set
            {
                lastLoginTimeStr = value;
            }
        }
        [JsonProperty(PropertyName = "state", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }
        [JsonProperty(PropertyName = "port", NullValueHandling = NullValueHandling.Ignore)]
        public string Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }

        #region  数据接口
        /// <summary>
        /// 根据用户名、密码认证用户登录信息，返回认证结果：成功、用户名或密码错误、用户账号不存在，若登录成功同时返回用户信息，如姓名等
        /// CORE_WS_XT_001
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Url("/facecore/sysUser/login")]
        public SysUser Login()
        {
            return Request<SysUser>();
        }

        /// <summary>
        /// 按条件分页查询用户列表，返回用户列表
        /// CORE_WS_XT_011
        /// </summary>
        /// <returns></returns>
        [Url("/facecore/sysUser/query")]
        public Pager<SysUser, SysUser> Query(Pager<SysUser> pager)
        {
            return RequestForPager<SysUser, SysUser>(pager);
        }

        /// <summary>
        /// 按用户ID，查询返回用户详细信息
        /// CORE_WS_XT_012
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        [Url("/facecore/sysUser/detail")]
        public Pager<SysUser, SysUser> Detail(Pager<SysUser> pager)
        {
            return RequestForPager<SysUser, SysUser>(pager);
        }

        /// <summary>
        /// 新增用户账号信息，返回新增结果
        /// CORE_WS_XT_013
        /// </summary>
        /// <returns></returns>
        [Url("/facecore/sysUser/save")]
        public SysUser Insert()
        {
            return Request<SysUser>();
        }

        /// <summary>
        /// 修改用户账号信息，返回修改结果
        /// CORE_WS_XT_014
        /// </summary>
        /// <returns></returns>
        [Url("/facecore/sysUser/update")]
        public SysUser Update()
        {
            return Request<SysUser>();
        }

        /// <summary>
        /// 根据用户ID，逻辑删除用户账号信息，返回删除结果
        /// CORE_WS_XT_015
        /// </summary>
        /// <returns></returns>
        [Url("/facecore/sysUser/delete")]
        public bool Delete(string[] idarr)
        {
            return Request(idarr);
        }

        /// <summary>
        /// 根据用户ID，修改用户状态为禁用，返回结果
        /// CORE_WS_XT_016
        /// </summary>
        /// <returns></returns>
        [Url("/facecore/sysUser/closeUser")]
        public SysUser CloseUser()
        {
            return Request<SysUser>();
        }

        /// <summary>
        /// 根据用户ID，修改用户状态为启用，返回结果
        /// CORE_WS_XT_017
        /// </summary>
        /// <returns></returns>
        [Url("/facecore/sysUser/openUser")]
        public SysUser OpenUser()
        {
            return Request<SysUser>();
        }
        #endregion
    }
}
