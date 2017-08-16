using Newtonsoft.Json;
using SING.Data.DAL.NewCode.Condition;
using System;

namespace SING.Data.DAL.NewCode
{
    public class JobMethod : DataProcess
    {
        private string uuid;
        private int _type;
        private string name;
        private string description;
        private int method;
        private float m1Score;
        private float m2Score;
        private int m2Seconds;
        private int m2Count;
        private string adder;
        private string adderId;
        private DateTime addTime;
        private string addTimeStr;
        private string modifierId;
        private string modifier;
        private DateTime modifyTime;
        private string modifyTimeStr;
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
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "method", NullValueHandling = NullValueHandling.Ignore)]
        public int Method
        {
            get
            {
                return method;
            }

            set
            {
                method = value;
            }
        }
        [JsonProperty(PropertyName = "m1Score", NullValueHandling = NullValueHandling.Ignore)]
        public float M1Score
        {
            get
            {
                return m1Score;
            }

            set
            {
                m1Score = value;
            }
        }
        [JsonProperty(PropertyName = "m2Score", NullValueHandling = NullValueHandling.Ignore)]
        public float M2Score
        {
            get
            {
                return m2Score;
            }

            set
            {
                m2Score = value;
            }
        }
        [JsonProperty(PropertyName = "m2Seconds", NullValueHandling = NullValueHandling.Ignore)]
        public int M2Seconds
        {
            get
            {
                return m2Seconds;
            }

            set
            {
                m2Seconds = value;
            }
        }
        [JsonProperty(PropertyName = "m2Count", NullValueHandling = NullValueHandling.Ignore)]
        public int M2Count
        {
            get
            {
                return m2Count;
            }

            set
            {
                m2Count = value;
            }
        }
        [JsonProperty(PropertyName = "addUid", NullValueHandling = NullValueHandling.Ignore)]
        public string AdderId
        {
            get
            {
                return adderId;
            }

            set
            {
                adderId = value;
            }
        }
        [JsonProperty(PropertyName = "addUidTag", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "addTime", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "modifyUid", NullValueHandling = NullValueHandling.Ignore)]
        public string ModifierId
        {
            get
            {
                return modifierId;
            }

            set
            {
                modifierId = value;
            }
        }

        [JsonProperty(PropertyName = "modifyUidTag", NullValueHandling = NullValueHandling.Ignore)]
        public string Modifier
        {
            get
            {
                return modifier;
            }

            set
            {
                modifier = value;
            }
        }
        [JsonProperty(PropertyName = "modifyTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ModifyTime
        {
            get
            {
                return modifyTime;
            }

            set
            {
                modifyTime = value;
            }
        }
        [JsonProperty(PropertyName = "modifyTimeStr", NullValueHandling = NullValueHandling.Ignore)]
        public string ModifyTimeStr
        {
            get
            {
                return modifyTimeStr;
            }

            set
            {
                modifyTimeStr = value;
            }
        }

        #region  数据操作
        /// <summary>
        /// 查询所有比对策略，返回查询结果LIST和分页信息
        /// CORE_WS_CL_001
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        [Url("/facecore/jobMethod/query")]
        public Pager<JobMethodCondition,JobMethod> Query(Pager<JobMethodCondition> pager)
        {
            return RequestForPager<JobMethodCondition, JobMethod>(pager);
        }
        

        /// <summary>
        /// 新增比对策略信息，返回新增处理结果和新增的任务UUID
        /// CORE_WS_CL_002
        /// </summary>
        /// <returns></returns>
        [Url("/facecore/jobMethod/save")]
        public JobMethod Insert()
        {
            return Request<JobMethod>();
        }

        /// <summary>
        /// 修改比对策略信息，返回修改结果
        /// CORE_WS_CL_003
        /// </summary>
        /// <param name="tactics"></param>
        /// <returns></returns>
        [Url("/facecore/jobMethod/update")]
        public JobMethod Update()
        {
            return Request<JobMethod>();
        }

        /// <summary>
        /// 根据UUID逻辑删除比对策略，并返回处理结果，当有任务引用策略时返回删除失败
        /// CORE_WS_CL_004
        /// </summary>
        /// <returns></returns>
        [Url("/facecore/jobMethod/delete")]
        public JobMethod Delete()
        {
            return Request<JobMethod>();
        }
        #endregion
    }
}
