using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.DAL.Data;

namespace SING.Data.DAL.NewCode
{
    public class OriginalAlerts : DataProcess
    {
        private string uuid;
        private string fcmpCapChannel;
        private long fcapTime;
        private long alertTime;
        private string fcmpFobjId;
        private double fcmpSocre;
        private string jobId;
        private string rulerId;
        private int ackStat;
        private long ackTime;
        private string acker;
        private int pubStat;
        private long pubTime;
        private string puber;
        private int ftdbId;
        private string fcmpFobjName;
        private string idNumb;
        private int matchedCount;
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
        [JsonProperty(PropertyName = "fcmpCapChannel", NullValueHandling = NullValueHandling.Ignore)]
        public string FcmpCapChannel
        {
            get
            {
                return fcmpCapChannel;
            }

            set
            {
                fcmpCapChannel = value;
            }
        }
        [JsonProperty(PropertyName = "fcapTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long FcapTime
        {
            get
            {
                return fcapTime;
            }

            set
            {
                fcapTime = value;
            }
        }
        [JsonProperty(PropertyName = "alertTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long AlertTime
        {
            get
            {
                return alertTime;
            }

            set
            {
                alertTime = value;
            }
        }
        [JsonProperty(PropertyName = "fcmpFobjId", NullValueHandling = NullValueHandling.Ignore)]
        public string FcmpFobjId
        {
            get
            {
                return fcmpFobjId;
            }

            set
            {
                fcmpFobjId = value;
            }
        }
        [JsonProperty(PropertyName = "fcmpSocre", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double FcmpSocre
        {
            get
            {
                return fcmpSocre;
            }

            set
            {
                fcmpSocre = value;
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
        [JsonProperty(PropertyName = "rulerId", NullValueHandling = NullValueHandling.Ignore)]
        public string RulerId
        {
            get
            {
                return rulerId;
            }

            set
            {
                rulerId = value;
            }
        }
        [JsonProperty(PropertyName = "ackStat", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int AckStat
        {
            get
            {
                return ackStat;
            }

            set
            {
                ackStat = value;
            }
        }
        [JsonProperty(PropertyName = "ackTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long AckTime
        {
            get
            {
                return ackTime;
            }

            set
            {
                ackTime = value;
            }
        }
        [JsonProperty(PropertyName = "acker", NullValueHandling = NullValueHandling.Ignore)]
        public string Acker
        {
            get
            {
                return acker;
            }

            set
            {
                acker = value;
            }
        }
        [JsonProperty(PropertyName = "pubStat", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int PubStat
        {
            get
            {
                return pubStat;
            }

            set
            {
                pubStat = value;
            }
        }
        [JsonProperty(PropertyName = "pubTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long PubTime
        {
            get
            {
                return pubTime;
            }

            set
            {
                pubTime = value;
            }
        }
        [JsonProperty(PropertyName = "puber", NullValueHandling = NullValueHandling.Ignore)]
        public string Puber
        {
            get
            {
                return puber;
            }

            set
            {
                puber = value;
            }
        }
        [JsonProperty(PropertyName = "ftdbId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int FtdbId
        {
            get
            {
                return ftdbId;
            }

            set
            {
                ftdbId = value;
            }
        }
        [JsonProperty(PropertyName = "fcmpFobjName", NullValueHandling = NullValueHandling.Ignore)]
        public string FcmpFobjName
        {
            get
            {
                return fcmpFobjName;
            }

            set
            {
                fcmpFobjName = value;
            }
        }
        [JsonProperty(PropertyName = "idNumb", NullValueHandling = NullValueHandling.Ignore)]
        public string IdNumb
        {
            get
            {
                return idNumb;
            }

            set
            {
                idNumb = value;
            }
        }
        [JsonProperty(PropertyName = "matchedCount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MatchedCount
        {
            get
            {
                return matchedCount;
            }

            set
            {
                matchedCount = value;
            }
        }

        #region  数据接口
        /// <summary>
        /// 修改告警状态为“已确认”，并标记已确定的目标人，返回处理结果
        /// CORE_WS_GJ_009
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        [Url("/facecore/originalAlerts/confirm")]
        public bool Confirm()
        {
            return Request();
        }

        /// <summary>
        /// 修改告警状态为“已排除”，返回处理结果
        /// CORE_WS_GJ_010
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        [Url("/facecore/originalAlerts/eliminate")]
        public bool Eliminate()
        {
            return Request();
        }

        /// <summary>
        /// 修改告警状态为“已推送”，返回处理结果
        /// CORE_WS_GJ_011
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        [Url("/facecore/originalAlerts/publish")]
        public bool Publish()
        {
            return Request();
        }
        #endregion
    }
}
