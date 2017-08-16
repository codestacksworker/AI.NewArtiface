using Newtonsoft.Json;
using SING.Data.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.Help.Http;
using SING.Data.Help.Json;
using SING.Data.DAL.NewCode.Condition;

namespace SING.Data.DAL.NewCode
{
    public class Jobs:DataProcess
    {
        private string uuid;
        private int _type;
        private int state;
        private string name;
        private DateTime beginDate;
        private int beginHours;
        private int beginMinutes;
        private DateTime endDate;
        private string daySet;
        private int endHours;
        private int endMinutes;
        private string description;
        private string methodId;
        private string uid;
        private DateTime createTime;
        private int isDelete;

        private string jobTypeTag;// 任务类型名称
        private string stateTag;// 状态名称
        private string beginDateStr;
        private string endDateStr;
        private int beginHour2;
        private int beginMin2;
        private int endHour2;
        private int endMin2;
        private string methodeName;// 比对策略名称
        private string userName;//布控人姓名
        private string createTimeStr;
        private string jobObjects;//目标人id集
        private string jobChannels;//通道id集
        private string jobTags;//标签id集
        private string jobTemplateDbs;//模板库id集
        private string jobTemplateDbsTag;//模板库id集名称

        private int channelCount;//任务关联的通道数
        private int alarmCount;//任务告警数
        private int objectCount;//任务下的目标人人数
        private int subscribeOriginalState;//登录用户订阅告警状态
        private int subscribeSecState;//登录用户订阅报警状态

        private string regionIds;//布控区域id集
        private string regionsTag;//布控区域显示名称
        private string regionCount;//布控区域个数
        private int templateCount;//模板库数量

        private string timeSectionTag;//布控时段显示值

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
        [JsonProperty(PropertyName = "jobType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }
        //[JsonProperty(PropertyName = "state", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "beginDate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime BeginDate
        {
            get
            {
                return beginDate;
            }

            set
            {
                beginDate = value;
            }
        }
        [JsonProperty(PropertyName = "beginHour", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int BeginHours
        {
            get
            {
                return beginHours;
            }

            set
            {
                beginHours = value;
            }
        }
        [JsonProperty(PropertyName = "beginMin", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int BeginMinutes
        {
            get
            {
                return beginMinutes;
            }

            set
            {
                beginMinutes = value;
            }
        }
        [JsonProperty(PropertyName = "endDate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
            }
        }
        [JsonProperty(PropertyName = "daySet", NullValueHandling = NullValueHandling.Ignore)]
        public string DaySet
        {
            get
            {
                return daySet;
            }

            set
            {
                daySet = value;
            }
        }
        [JsonProperty(PropertyName = "endHour", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int EndHours
        {
            get
            {
                return endHours;
            }

            set
            {
                endHours = value;
            }
        }
        [JsonProperty(PropertyName = "endMin", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int EndMinutes
        {
            get
            {
                return endMinutes;
            }

            set
            {
                endMinutes = value;
            }
        }
        [JsonProperty(PropertyName = "memo", NullValueHandling = NullValueHandling.Ignore)]
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }
        [JsonProperty(PropertyName = "methodId", NullValueHandling = NullValueHandling.Ignore)]
        public string MethodId
        {
            get
            {
                return methodId;
            }

            set
            {
                methodId = value;
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

        [JsonProperty(PropertyName = "createTime", DefaultValueHandling = DefaultValueHandling.Ignore,NullValueHandling =NullValueHandling.Ignore)]
        public DateTime CreateTime
        {
            get
            {
                return createTime;
            }

            set
            {
                createTime = value;
            }
        }

        [JsonProperty(PropertyName = "isDeleted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int IsDelete
        {
            get
            {
                return isDelete;
            }

            set
            {
                isDelete = value;
            }
        }
        [JsonProperty(PropertyName = "jobTypeTag", NullValueHandling = NullValueHandling.Ignore)]
        public string JobTypeTag
        {
            get
            {
                return jobTypeTag;
            }

            set
            {
                jobTypeTag = value;
            }
        }
        [JsonProperty(PropertyName = "StateTag", NullValueHandling = NullValueHandling.Ignore)]
        public string StateTag
        {
            get
            {
                return stateTag;
            }

            set
            {
                stateTag = value;
            }
        }
        [JsonProperty(PropertyName = "BeginDateStr", NullValueHandling = NullValueHandling.Ignore)]
        public string BeginDateStr
        {
            get
            {
                return beginDateStr;
            }

            set
            {
                beginDateStr = value;
            }
        }
        [JsonProperty(PropertyName = "EndDateStr", NullValueHandling = NullValueHandling.Ignore)]
        public string EndDateStr
        {
            get
            {
                return endDateStr;
            }

            set
            {
                endDateStr = value;
            }
        }
        [JsonProperty(PropertyName = "BeginHour2", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int BeginHour2
        {
            get
            {
                return beginHour2;
            }

            set
            {
                beginHour2 = value;
            }
        }
        [JsonProperty(PropertyName = "BeginMin2", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int BeginMin2
        {
            get
            {
                return beginMin2;
            }

            set
            {
                beginMin2 = value;
            }
        }
        [JsonProperty(PropertyName = "EndHour2", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int EndHour2
        {
            get
            {
                return endHour2;
            }

            set
            {
                endHour2 = value;
            }
        }
        [JsonProperty(PropertyName = "EndMin2", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int EndMin2
        {
            get
            {
                return endMin2;
            }

            set
            {
                endMin2 = value;
            }
        }
        [JsonProperty(PropertyName = "MethodeName", NullValueHandling = NullValueHandling.Ignore)]
        public string MethodeName
        {
            get
            {
                return methodeName;
            }

            set
            {
                methodeName = value;
            }
        }
        [JsonProperty(PropertyName = "UserName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }
        [JsonProperty(PropertyName = "CreateTimeStr", NullValueHandling = NullValueHandling.Ignore)]
        public string CreateTimeStr
        {
            get
            {
                return createTimeStr;
            }

            set
            {
                createTimeStr = value;
            }
        }
        [JsonProperty(PropertyName = "JobObjects", NullValueHandling = NullValueHandling.Ignore)]
        public string JobObjects
        {
            get
            {
                return jobObjects;
            }

            set
            {
                jobObjects = value;
            }
        }
        [JsonProperty(PropertyName = "JobChannels", NullValueHandling = NullValueHandling.Ignore)]
        public string JobChannels
        {
            get
            {
                return jobChannels;
            }

            set
            {
                jobChannels = value;
            }
        }
        [JsonProperty(PropertyName = "JobTags", NullValueHandling = NullValueHandling.Ignore)]
        public string JobTags
        {
            get
            {
                return jobTags;
            }

            set
            {
                jobTags = value;
            }
        }
        [JsonProperty(PropertyName = "JobTemplateDbs", NullValueHandling = NullValueHandling.Ignore)]
        public string JobTemplateDbs
        {
            get
            {
                return jobTemplateDbs;
            }

            set
            {
                jobTemplateDbs = value;
            }
        }
        [JsonProperty(PropertyName = "JobTemplateDbsTag", NullValueHandling = NullValueHandling.Ignore)]
        public string JobTemplateDbsTag
        {
            get
            {
                return jobTemplateDbsTag;
            }

            set
            {
                jobTemplateDbsTag = value;
            }
        }
        [JsonProperty(PropertyName = "ChannelCount", NullValueHandling = NullValueHandling.Ignore)]
        public int ChannelCount
        {
            get
            {
                return channelCount;
            }

            set
            {
                channelCount = value;
            }
        }
        [JsonProperty(PropertyName = "AlarmCount", NullValueHandling = NullValueHandling.Ignore)]
        public int AlarmCount
        {
            get
            {
                return alarmCount;
            }

            set
            {
                alarmCount = value;
            }
        }
        [JsonProperty(PropertyName = "ObjectCount", NullValueHandling = NullValueHandling.Ignore)]
        public int ObjectCount
        {
            get
            {
                return objectCount;
            }

            set
            {
                objectCount = value;
            }
        }
        [JsonProperty(PropertyName = "SubscribeOriginalState", NullValueHandling = NullValueHandling.Ignore)]
        public int SubscribeOriginalState
        {
            get
            {
                return subscribeOriginalState;
            }

            set
            {
                subscribeOriginalState = value;
            }
        }
        [JsonProperty(PropertyName = "SubscribeSecState", NullValueHandling = NullValueHandling.Ignore)]
        public int SubscribeSecState
        {
            get
            {
                return subscribeSecState;
            }

            set
            {
                subscribeSecState = value;
            }
        }
        [JsonProperty(PropertyName = "RegionIds", NullValueHandling = NullValueHandling.Ignore)]
        public string RegionIds
        {
            get
            {
                return regionIds;
            }

            set
            {
                regionIds = value;
            }
        }
        [JsonProperty(PropertyName = "RegionsTag", NullValueHandling = NullValueHandling.Ignore)]
        public string RegionsTag
        {
            get
            {
                return regionsTag;
            }

            set
            {
                regionsTag = value;
            }
        }
        [JsonProperty(PropertyName = "RegionCount", NullValueHandling = NullValueHandling.Ignore)]
        public string RegionCount
        {
            get
            {
                return regionCount;
            }

            set
            {
                regionCount = value;
            }
        }
        [JsonProperty(PropertyName = "TemplateCount", NullValueHandling = NullValueHandling.Ignore)]
        public int TemplateCount
        {
            get
            {
                return templateCount;
            }

            set
            {
                templateCount = value;
            }
        }
        [JsonProperty(PropertyName = "TimeSectionTag", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeSectionTag
        {
            get
            {
                return timeSectionTag;
            }

            set
            {
                timeSectionTag = value;
            }
        }

        #region  数据接口
        /// <summary>
        /// 查询全部布控任务，返回查询结果列表				
        /// CORE_WS_RW_001				
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>\
        [Url("/facecore/jobs/queryJobs")]
        public Pager<JobsCondition,Jobs> QueryJobs(Pager<JobsCondition> pager)
        {
            return base.RequestForPager<JobsCondition, Jobs>(pager);
        }

        /// <summary>
        /// 查询全部布控任务，返回查询结果并统计目标人数、布控通道数
        /// CORE_WS_RW_007
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        [Url("/facecore/jobs/query")]
        public Pager<JobsCondition, Jobs> Query(Pager<JobsCondition> pager)
        {
            return RequestForPager<JobsCondition, Jobs>(pager);
        }

        /// <summary>
        /// 根据布控任务ID，查询返回布控任务详情信息(任务类型、布控计划、布控人、描述、布控区域、布控目标、目标库、比对策略、创建时间)
        /// CORE_WS_RW_006
        /// </summary>
        /// <returns></returns>
        [Url("/facecore/jobs/detail")]
        public List<Jobs> QueryDetail()
        {
            return RequestForList<Jobs>();
        }

        /// <summary>
        /// 查询所有布控任务列表，返回列表（布控通道数、目标人数、告警次数、当前用户订阅状态、任务状态）
        /// CORE_WS_RW_005
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        [Url("/facecore/jobs/queryStatistics")]
        public Pager<JobsCondition,Jobs> QueryStatistics(Pager<JobsCondition> pager)
        {
            return RequestForPager<JobsCondition, Jobs>(pager);
        }

        /// <summary>
        /// 新增任务信息，返回新增结果和新增处理结果的任务UUID
        /// CORE_WS_RW_002
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        [Url("/facecore/jobs/save")]
        public Jobs Insert()
        {
            return Request<Jobs>();
        }

        /// <summary>
        /// 修改任务信息，返回修改结果
        /// CORE_WS_RW_003
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        [Url("/facecore/jobs/update")]
        public bool Update()
        {
            return Request();
        }

        /// <summary>
        /// 根据UUID逻辑删除布控任务
        /// CORE_WS_RW_004
        /// </summary>
        /// <param name="idarr"></param>
        /// <returns></returns>
        [Url("/facecore/jobs/delete")]
        public bool Delete(string[] idarr)
        {
            return Request(idarr);
        }
        #endregion
    }
}
