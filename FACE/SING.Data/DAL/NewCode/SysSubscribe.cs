using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.DAL.Data;

namespace SING.Data.DAL.NewCode
{
    public class SysSubscribe : DataProcess
    {
        private string uuid;
        private string uid;
        private string jobId;
        private int state;
        private DateTime subTime;
        private string subTimeStr;
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
        [JsonProperty(PropertyName = "uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid
        {
            get
            {
                return uid;
            }

            set
            {
                uid = value;
            }
        }
        [JsonProperty(PropertyName = "jobId", NullValueHandling = NullValueHandling.Ignore)]
        public string JobId
        {
            get
            {
                return jobId;
            }

            set
            {
                jobId = value;
            }
        }
        [JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "subTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime SubTime
        {
            get
            {
                return subTime;
            }

            set
            {
                subTime = value;
            }
        }
        [JsonProperty(PropertyName = "subTimeStr", NullValueHandling = NullValueHandling.Ignore)]
        public string SubTimeStr
        {
            get
            {
                return subTimeStr;
            }

            set
            {
                subTimeStr = value;
            }
        }

        #region   数据接口
        /// <summary>
        /// 根据布控任务ID进行告警信息订阅，返回订阅操作结果
        /// CORE_WS_XT_005
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        [Url("/facecore/sysSubscribe/saveSec")]
        public bool SaveSec()
        {
            return Request();
        }

        /// <summary>
        /// 根据布控任务ID取消告警信息订阅，返回取消操作结果
        /// CORE_WS_XT_006
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        [Url("/facecore/sysSubscribe/cancelAlarmSub")]
        public bool CancelAlarmSub()
        {
            return Request();
        }

        /// <summary>
        /// 根据布控任务ID进行报警信息订阅，返回订阅操作结果
        /// CORE_WS_XT_007
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        [Url("/facecore/sysSubscribe/saveOriginal")]
        public bool SaveOriginal()
        {
            return Request();
        }

        /// <summary>
        /// 根据布控任务ID取消报警信息订阅，返回取消操作结果
        /// CORE_WS_XT_008
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        [Url("/facecore/sysSubscribe/cancleWarningSub")]
        public bool CancleWarningSub()
        {
            return Request();
        }
        #endregion
    }
}
