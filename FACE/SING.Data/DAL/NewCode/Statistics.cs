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
    public class Statistics:DataProcess
    {
        private string startTime;
        private string endTime;
        private string jobId;

        private int hour;
        private int alertCount;
        private int alarmCount;
        private int personCoount;

        #region  查询条件
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

        [JsonProperty(PropertyName = "startTime", NullValueHandling = NullValueHandling.Ignore)]
        public string StartTime
        {
            get
            {
                return startTime;
            }

            set
            {
                startTime = value;
            }
        }
        [JsonProperty(PropertyName = "endTime", NullValueHandling = NullValueHandling.Ignore)]
        public string EndTime
        {
            get
            {
                return endTime;
            }

            set
            {
                endTime = value;
            }
        }
        #endregion

        [JsonProperty(PropertyName = "hour", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Hour
        {
            get
            {
                return hour;
            }

            set
            {
                hour = value;
            }
        }
        [JsonProperty(PropertyName = "alertCount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int AlertCount
        {
            get
            {
                return alertCount;
            }

            set
            {
                alertCount = value;
            }
        }
        [JsonProperty(PropertyName = "alarmCount", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "personCoount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int PersonCoount
        {
            get
            {
                return personCoount;
            }

            set
            {
                personCoount = value;
            }
        }

        #region 数据操作
        /// <summary>
        /// 按开始、截至日期统计告警推送次数，返回统计结果
        /// CORE_WS_GJ_018
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        [Url("/facecore/statistics/publishCount")]
        public int GetPublishCount()
        {
            return RequestForValue<int>();
        }

        /// <summary>
        /// 按开始、截至日期统计告警次数，返回统计结果
        /// CORE_WS_GJ_019
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        [Url("/facecore/statistics/alertCount")]
        public int GetAlertCount()
        {
            return RequestForValue<int>();
        }

        /// <summary>
        /// 按开始、截至日期统计未复合的告警次数，返回统计结果
        /// CORE_WS_GJ_020
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        [Url("/facecore/statistics/uncheckedCount")]
        public int UncheckedCount()
        {
            return RequestForValue<int>();
        }

        /// <summary>
        /// 按开始、截至时间，统计每小时的告警、报警、人次数据，返回统计数据列表
        /// 最近24小时统计
        /// CORE_WS_GJ_021
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        [Url("/facecore/statistics/checkedStatistics")]
        public List<Statistics> CheckedStatistics()
        {
            return RequestForList<Statistics>();
        }

        /// <summary>
        /// 查询抓拍服务状态（暂不实现，前期和直接返回正常）
        /// CORE_WS_XT_002
        /// </summary>
        /// <returns></returns>
        [Url("/facecore/state/queryCapState")]
        public string QueryCapState()
        {
            return RequestForValue<string>();
        }

        /// <summary>
        /// 查询比对服务状态（暂不实现，前期和直接返回正常）
        /// CORE_WS_XT_003
        /// </summary>
        /// <returns></returns>
        [Url("/facecore/state/queryComState")]
        public string QueryComState()
        {
            return RequestForValue<string>();
        }

        /// <summary>
        /// 查询策略服务状态（暂不实现，前期和直接返回正常）
        /// CORE_WS_XT_004
        /// </summary>
        /// <returns></returns>
        [Url("/facecore/state/queryMethodeState")]
        public string QueryMethodeState()
        {
            return RequestForValue<string>();
        }

        /// <summary>
        /// 按开始、截至日期统计抓拍次数，返回统计结果
        /// CORE_WS_ZP_001
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        [Url("/facecore/faceCapture/findStatisticalCount")]
        public int FindStatisticalCount()
        {
            return RequestForValue<int>();
        }
        #endregion
    }
}
