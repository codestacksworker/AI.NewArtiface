using Newtonsoft.Json;
using SING.Data.DAL.NewCode.Condition;

namespace SING.Data.DAL.NewCode
{
    public class SysTypecode : DataProcess
    {
        private string uuid;
        private string typeCode;
        private int itemId;
        private string itemCode;
        private string itemValue;
        private string parentId;
        private string searchCode;
        private string memo;
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
        [JsonProperty(PropertyName = "typeCode", NullValueHandling = NullValueHandling.Ignore)]
        public string TypeCode
        {
            get
            {
                return typeCode;
            }

            set
            {
                typeCode = value;
            }
        }

        [JsonProperty(PropertyName = "itemId", NullValueHandling = NullValueHandling.Ignore)]
        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        [JsonProperty(PropertyName = "itemCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemCode
        {
            get
            {
                return itemCode;
            }

            set
            {
                itemCode = value;
            }
        }
        [JsonProperty(PropertyName = "itemValue", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemValue
        {
            get
            {
                return itemValue;
            }

            set
            {
                itemValue = value;
            }
        }
        [JsonProperty(PropertyName = "parentId", NullValueHandling = NullValueHandling.Ignore)]
        public string ParentId
        {
            get
            {
                return parentId;
            }

            set
            {
                parentId = value;
            }
        }
        [JsonProperty(PropertyName = "searchCode", NullValueHandling = NullValueHandling.Ignore)]
        public string SearchCode
        {
            get
            {
                return searchCode;
            }

            set
            {
                searchCode = value;
            }
        }
        [JsonProperty(PropertyName = "memo", NullValueHandling = NullValueHandling.Ignore)]
        public string Memo
        {
            get
            {
                return memo;
            }

            set
            {
                memo = value;
            }
        }

        #region  数据接口
        /// <summary>
        /// 根据字典类型，查询返回字典列表
        /// CORE_WS_XT_009
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        [Url("/facecore/sysTypecode/query")]
        public Pager<SysTypecodeDataCondition, SysTypecode> Query(Pager<SysTypecodeDataCondition> pager)
        {
            return RequestForPager<SysTypecodeDataCondition, SysTypecode>(pager);
        }
        #endregion
    }
}
