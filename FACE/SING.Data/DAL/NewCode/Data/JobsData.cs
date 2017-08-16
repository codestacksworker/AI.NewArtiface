using Newtonsoft.Json;
using System;

namespace SING.Data.DAL.NewCode.Data
{
    public class JobsData : UIDataBase
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

        #region UIVar 
        private string uiBeginTime;
        private string uiEndTime;
        private string uiBeginTime2;
        private string uiEndTime2;
        private int taskPlanId;
        private int taskTimeSpanId;
        private int rowNo;

        public int TaskPlanId { get; set; }
        public int TaskTimeSpanId { get; set; }
        public string UiBeginTime { get; set; }
        public string UiEndTime { get; set; }
        public string UiBeginTime2 { get; set; }
        public string UiEndTime2 { get; set; }
        public int RowNo { get; set; }

        #endregion


        public string Uuid
        {
            get
            {
                return uuid;
            }

            set
            {
                uuid = value; OnPropertyChanged("Uuid");
            }
        }

        public int Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value; OnPropertyChanged("Type");
            }
        }

        public int State
        {
            get
            {
                return state;
            }

            set
            {
                state = value; OnPropertyChanged("State");
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value; OnPropertyChanged("Name");
            }
        }

        public DateTime BeginDate
        {
            get
            {
                return beginDate;
            }

            set
            {
                beginDate = value; OnPropertyChanged("BeginDate");
            }
        }

        public int BeginHours
        {
            get
            {
                return beginHours;
            }

            set
            {
                beginHours = value; OnPropertyChanged("BeginHours");
            }
        }

        public int BeginMinutes
        {
            get
            {
                return beginMinutes;
            }

            set
            {
                beginMinutes = value; OnPropertyChanged("BeginMinutes");
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value; OnPropertyChanged("EndDate");
            }
        }

        public string DaySet
        {
            get
            {
                return daySet;
            }

            set
            {
                daySet = value; OnPropertyChanged("DaySet");
            }
        }

        public int EndHours
        {
            get
            {
                return endHours;
            }

            set
            {
                endHours = value; OnPropertyChanged("EndHours");
            }
        }

        public int EndMinutes
        {
            get
            {
                return endMinutes;
            }

            set
            {
                endMinutes = value; OnPropertyChanged("EndMinutes");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value; OnPropertyChanged("Description");
            }
        }

        public string MethodId
        {
            get
            {
                return methodId;
            }

            set
            {
                methodId = value; OnPropertyChanged("MethodId");
            }
        }

        public string Uid
        {
            get
            {
                return uid;
            }

            set
            {
                uid = value; OnPropertyChanged("Uid");
            }
        }

        public DateTime CreateTime
        {
            get
            {
                return createTime;
            }

            set
            {
                createTime = value; OnPropertyChanged("CreateTime");
            }
        }

        public int IsDelete
        {
            get
            {
                return isDelete;
            }

            set
            {
                isDelete = value; OnPropertyChanged("IsDelete");
            }
        }

        public string JobTypeTag
        {
            get
            {
                return jobTypeTag;
            }

            set
            {
                jobTypeTag = value;
                OnPropertyChanged("JobTypeTag");
            }
        }

        public string StateTag
        {
            get
            {
                return stateTag;
            }

            set
            {
                stateTag = value; OnPropertyChanged("StateTag");
            }
        }

        public string BeginDateStr
        {
            get
            {
                return beginDateStr;
            }

            set
            {
                beginDateStr = value; OnPropertyChanged("BeginDateStr");
            }
        }

        public string EndDateStr
        {
            get
            {
                return endDateStr;
            }

            set
            {
                endDateStr = value; OnPropertyChanged("EndDateStr");
            }
        }

        [JsonProperty(PropertyName = "BeginHour2", NullValueHandling = NullValueHandling.Ignore)]
        public int BeginHour2
        {
            get
            {
                return beginHour2;
            }

            set
            {
                beginHour2 = value; OnPropertyChanged("BeginHour2");
            }
        }

        [JsonProperty(PropertyName = "BeginMin2", NullValueHandling = NullValueHandling.Ignore)]
        public int BeginMin2
        {
            get
            {
                return beginMin2;
            }

            set
            {
                beginMin2 = value; OnPropertyChanged("BeginMin2");
            }
        }

        [JsonProperty(PropertyName = "EndHour2", NullValueHandling = NullValueHandling.Ignore)]
        public int EndHour2
        {
            get
            {
                return endHour2;
            }

            set
            {
                endHour2 = value; OnPropertyChanged("EndHour2");
            }
        }

        [JsonProperty(PropertyName = "EndMin2", NullValueHandling = NullValueHandling.Ignore)]
        public int EndMin2
        {
            get
            {
                return endMin2;
            }

            set
            {
                endMin2 = value; OnPropertyChanged("EndMin2");
            }
        }

        public string MethodeName
        {
            get
            {
                return methodeName;
            }

            set
            {
                methodeName = value; OnPropertyChanged("MethodeName");
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value; OnPropertyChanged("UserName");
            }
        }

        public string CreateTimeStr
        {
            get
            {
                return createTimeStr;
            }

            set
            {
                createTimeStr = value; OnPropertyChanged("CreateTimeStr");
            }
        }

        public string JobObjects
        {
            get
            {
                return jobObjects;
            }

            set
            {
                jobObjects = value; OnPropertyChanged("JobObjects");
            }
        }

        public string JobChannels
        {
            get
            {
                return jobChannels;
            }

            set
            {
                jobChannels = value; OnPropertyChanged("JobChannels");
            }
        }

        public string JobTags
        {
            get
            {
                return jobTags;
            }

            set
            {
                jobTags = value; OnPropertyChanged("JobTags");
            }
        }

        public string JobTemplateDbs
        {
            get
            {
                return jobTemplateDbs;
            }

            set
            {
                jobTemplateDbs = value; OnPropertyChanged("JobTemplateDbs");
            }
        }

        public string JobTemplateDbsTag
        {
            get
            {
                return jobTemplateDbsTag;
            }

            set
            {
                jobTemplateDbsTag = value; OnPropertyChanged("JobTemplateDbsTag");
            }
        }

        public int ChannelCount
        {
            get
            {
                return channelCount;
            }

            set
            {
                channelCount = value; OnPropertyChanged("ChannelCount");
            }
        }

        public int AlarmCount
        {
            get
            {
                return alarmCount;
            }

            set
            {
                alarmCount = value; OnPropertyChanged("AlarmCount");
            }
        }

        public int ObjectCount
        {
            get
            {
                return objectCount;
            }

            set
            {
                objectCount = value; OnPropertyChanged("ObjectCount");
            }
        }

        public int SubscribeOriginalState
        {
            get
            {
                return subscribeOriginalState;
            }

            set
            {
                subscribeOriginalState = value; OnPropertyChanged("SubscribeOriginalState");
            }
        }

        public int SubscribeSecState
        {
            get
            {
                return subscribeSecState;
            }

            set
            {
                subscribeSecState = value; OnPropertyChanged("SubscribeSecState");
            }
        }

        public string RegionIds
        {
            get
            {
                return regionIds;
            }

            set
            {
                regionIds = value; OnPropertyChanged("RegionIds");
            }
        }

        public string RegionsTag
        {
            get
            {
                return regionsTag;
            }

            set
            {
                regionsTag = value; OnPropertyChanged("RegionsTag");
            }
        }

        public string RegionCount
        {
            get
            {
                return regionCount;
            }

            set
            {
                regionCount = value; OnPropertyChanged("RegionCount");
            }
        }

        public int TemplateCount
        {
            get
            {
                return templateCount;
            }

            set
            {
                templateCount = value; OnPropertyChanged("TemplateCount");
            }
        }

        public string TimeSectionTag
        {
            get
            {
                return timeSectionTag;
            }

            set
            {
                timeSectionTag = value; OnPropertyChanged("TimeSectionTag");
            }
        }
    }
}
