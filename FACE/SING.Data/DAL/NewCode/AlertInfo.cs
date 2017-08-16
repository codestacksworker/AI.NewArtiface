using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.DAL.Data;
using SING.Data.DAL.NewCode.Condition;

namespace SING.Data.DAL.NewCode
{
    public class AlertInfo : DataProcess
    {
        private string alertUuid;
        private string fcapImgUuid;
        private string fcapImgUrl;
        private string fcmpImgUuid;
        private string fcmpImgUrl;
        private string fcapUuid;
        private string fcmpFobjId;
        private string dBID;
        private string name;
        private string sex;
        private string sexTag;
        private string iDNumber;
        private string label;
        private string regionName;
        private string channelName;
        private string addr;
        private string appearNumber;
        private string score;
        private string taskName;
        private string alertTime;
        private string pubState;
        private string actTime;
        private string uncheckedCount;
        private string userId;
        private string acker;

        [JsonProperty(PropertyName = "alertUuid", NullValueHandling = NullValueHandling.Ignore)]
        public string AlertUuid
        {
            get
            {
                return alertUuid;
            }

            set
            {
                alertUuid = value;
            }
        }
        [JsonProperty(PropertyName = "fcapImgUuid", NullValueHandling = NullValueHandling.Ignore)]
        public string FcapImgUuid
        {
            get
            {
                return fcapImgUuid;
            }

            set
            {
                fcapImgUuid = value;
            }
        }
        [JsonProperty(PropertyName = "fcapImgUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string FcapImgUrl
        {
            get
            {
                return fcapImgUrl;
            }

            set
            {
                fcapImgUrl = value;
            }
        }
        [JsonProperty(PropertyName = "fcmpImgUuid", NullValueHandling = NullValueHandling.Ignore)]
        public string FcmpImgUuid
        {
            get
            {
                return fcmpImgUuid;
            }

            set
            {
                fcmpImgUuid = value;
            }
        }
        [JsonProperty(PropertyName = "fcmpImgUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string FcmpImgUrl
        {
            get
            {
                return fcmpImgUrl;
            }

            set
            {
                fcmpImgUrl = value;
            }
        }
        [JsonProperty(PropertyName = "fcapUuid", NullValueHandling = NullValueHandling.Ignore)]
        public string FcapUuid
        {
            get
            {
                return fcapUuid;
            }

            set
            {
                fcapUuid = value;
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
        [JsonProperty(PropertyName = "DBID", NullValueHandling = NullValueHandling.Ignore)]
        public string DBID
        {
            get
            {
                return dBID;
            }

            set
            {
                dBID = value;
            }
        }
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        [JsonProperty(PropertyName = "sex", NullValueHandling = NullValueHandling.Ignore)]
        public string Sex
        {
            get
            {
                return sex;
            }

            set
            {
                sex = value;
            }
        }
        [JsonProperty(PropertyName = "sexTag", NullValueHandling = NullValueHandling.Ignore)]
        public string SexTag
        {
            get
            {
                return sexTag;
            }

            set
            {
                sexTag = value;
            }
        }
        [JsonProperty(PropertyName = "iDNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string IDNumber
        {
            get
            {
                return iDNumber;
            }

            set
            {
                iDNumber = value;
            }
        }
        [JsonProperty(PropertyName = "label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label
        {
            get
            {
                return label;
            }

            set
            {
                label = value;
            }
        }
        [JsonProperty(PropertyName = "regionName", NullValueHandling = NullValueHandling.Ignore)]
        public string RegionName
        {
            get
            {
                return regionName;
            }

            set
            {
                regionName = value;
            }
        }
        [JsonProperty(PropertyName = "channelName", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelName
        {
            get
            {
                return channelName;
            }

            set
            {
                channelName = value;
            }
        }
        [JsonProperty(PropertyName = "addr", NullValueHandling = NullValueHandling.Ignore)]
        public string Addr
        {
            get
            {
                return addr;
            }

            set
            {
                addr = value;
            }
        }
        [JsonProperty(PropertyName = "appearNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string AppearNumber
        {
            get
            {
                return appearNumber;
            }

            set
            {
                appearNumber = value;
            }
        }
        [JsonProperty(PropertyName = "score", NullValueHandling = NullValueHandling.Ignore)]
        public string Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }
        [JsonProperty(PropertyName = "taskName", NullValueHandling = NullValueHandling.Ignore)]
        public string TaskName
        {
            get
            {
                return taskName;
            }

            set
            {
                taskName = value;
            }
        }
        [JsonProperty(PropertyName = "alertTime", NullValueHandling = NullValueHandling.Ignore)]
        public string AlertTime
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
        [JsonProperty(PropertyName = "pubState", NullValueHandling = NullValueHandling.Ignore)]
        public string PubState
        {
            get
            {
                return pubState;
            }

            set
            {
                pubState = value;
            }
        }
        [JsonProperty(PropertyName = "ActTime", NullValueHandling = NullValueHandling.Ignore)]
        public string ActTime
        {
            get
            {
                return actTime;
            }

            set
            {
                actTime = value;
            }
        }
        [JsonProperty(PropertyName = "uncheckedCount", NullValueHandling = NullValueHandling.Ignore)]
        public string UncheckedCount
        {
            get
            {
                return uncheckedCount;
            }

            set
            {
                uncheckedCount = value;
            }
        }
        [JsonProperty(PropertyName = "userId", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId
        {
            get
            {
                return userId;
            }

            set
            {
                userId = value;
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

        #region   数据接口
        /// <summary>
        /// 根据条件（布控任务、目标库、通道、证件类型、证件编号、时间区间等），查询返回告警信息列表和分页信息
        /// CORE_WS_GJ_003
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        [Url("/facecore/originalAlerts/query")]
        public Pager<AlertInfoCondition,AlertInfo> Query(Pager<AlertInfoCondition> pager)
        {
            return base.RequestForPager<AlertInfoCondition,AlertInfo>(pager);
        }

        /// <summary>
        /// 查询告警命中的目标人列表，根据分数倒排序，返回目标人信息列表、分数等
        /// CORE_WS_GJ_005
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        [Url("/facecore/originalAlerts/queryTargetPersonList")]
        public List<AlertInfo> QueryTargetPersonList()
        {
            return base.RequestForList<AlertInfo>();
        }

        /// <summary>
        /// 按用户ID，查询所订阅布控任务的最新告警信息（TOP50？），返回告警信息列表
        /// CORE_WS_GJ_001
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Url("/facecore/originalAlerts/queryNewestAlerts")]
        public List<AlertInfo> QueryNewestAlerts(AlertInfoCondition condition)
        {
            return RequestForList<AlertInfoCondition, AlertInfo>(condition);
        }

        /// <summary>
        /// 切换当前告警的目标人
        /// CORE_WS_GJ_006
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        [Url("/facecore/originalAlerts/queryTargetPersonByID")]
        public AlertInfo QueryTargetPersonByID()
        {
            //Response response = Request(this, "/facecore/originalAlerts/queryTargetPersonByID");

            //if (response == null)
            //    return null;

            //AlertInfo result = null;

            //foreach (var m in response.Map.Values)
            //{
            //    if (m != null && !string.IsNullOrEmpty(m.ToString()))
            //        result = JsonToModel<AlertInfo>(m.ToString());
            //}

            //return result;
            return base.Request<AlertInfo>();
        }

        /// <summary>
        /// 根据时间顺序，返回前一组告警ID
        /// CORE_WS_GJ_007
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        [Url("/facecore/originalAlerts/previous")]
        public AlertInfo Previous()
        {
            return base.Request<AlertInfo>();
        }

        /// <summary>
        /// 根据时间顺序，返回后一组告警ID
        /// CORE_WS_GJ_008				
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        [Url("/facecore/originalAlerts/queryAlertsByTime")]
        public AlertInfo Next()
        {
            return base.Request<AlertInfo>();
        }

        //根据告警ID、目标人获得比对拍场景图列表  CORE_WS_GJ_013

        

        /// <summary>
        /// 修改告警状态为初始状态，返回处理结果
        /// CORE_WS_GJ_012
        /// </summary>
        /// <returns></returns>
        [Url("/facecore/originalAlerts/recheckAlert")]
        public AlertInfo ReCheckAlert()
        {
            return Request<AlertInfo>();
        }

        /// <summary>
        /// 根据告警ID，查询返回告警详情信息、抓拍信息、目标人信息
        /// CORE_WS_GJ_002
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        [Url("/facecore/originalAlerts/queryAlertDetail")]
        public List<AlertInfo> QueryAlertDetail()
        {
            return base.RequestForList<AlertInfo>();
        }
        #endregion
    }
}
