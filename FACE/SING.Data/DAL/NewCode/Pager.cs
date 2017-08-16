using Newtonsoft.Json;
using SING.Data.BaseTools;
using SING.Data.DAL.ScheduleConvert;
using SING.Data.Help.Http;
using SING.Data.Help.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.DAL.NewCode
{
    public class Pager
    {
        private string pageFlag = "pageFlag";

        private int pageNo = 1;//起始页
        private int pageRows = 10;//每页条数
        private int totalCount = -1;//总条数
        private int totalPages;//总页数
        private int realPageNo;
        private ArrayList paramList = new ArrayList();

        [JsonProperty(PropertyName = "pageFlag", NullValueHandling = NullValueHandling.Ignore)]
        public string PageFlag
        {
            get
            {
                return pageFlag;
            }

            set
            {
                pageFlag = value;
            }
        }
        [JsonProperty(PropertyName = "pageNo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int PageNo
        {
            get
            {
                return pageNo;
            }

            set
            {
                pageNo = value;
            }
        }
        [JsonProperty(PropertyName = "pageRows", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int PageRows
        {
            get
            {
                return pageRows;
            }

            set
            {
                pageRows = value;
            }
        }
        [JsonProperty(PropertyName = "totalCount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalCount
        {
            get
            {
                return totalCount;
            }

            set
            {
                totalCount = value;
            }
        }
        [JsonProperty(PropertyName = "totalPages", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalPages
        {
            get
            {
                return totalPages;
            }

            set
            {
                totalPages = value;
            }
        }
        [JsonProperty(PropertyName = "realPageNo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int RealPageNo
        {
            get
            {
                return realPageNo;
            }

            set
            {
                realPageNo = value;
            }
        }
        [JsonProperty(PropertyName = "paramList", NullValueHandling = NullValueHandling.Ignore)]
        public ArrayList ParamList
        {
            get
            {
                return paramList;
            }

            set
            {
                paramList = value;
            }
        }
    }

    public class Pager<TCondition> : Pager 
        where TCondition : new()
    {
        private TCondition _Condition;//存储查询条件

        [JsonProperty(PropertyName = "f", NullValueHandling = NullValueHandling.Ignore)]
        public TCondition Condition
        {
            get
            {
                return _Condition;
            }

            set
            {
                _Condition = value;
            }
        }
    }

    public class Pager<TCondition, TResult>
        where TCondition : new() 
        where TResult : new()
    {
        private List<TResult> resultList; //存储查询返回值
        private Hashtable map;
        private TCondition _Condition;//存储查询条件
        private string pageFlag = "pageFlag";

        private int pageNo = 1;//起始页
        private int pageRows = 10;//每页条数
        private int totalCount = -1;//总条数
        private int totalPages;//总页数
        private int realPageNo;
        private ArrayList paramList = new ArrayList();

        [JsonProperty(PropertyName = "pageFlag", NullValueHandling = NullValueHandling.Ignore)]
        public string PageFlag
        {
            get
            {
                return pageFlag;
            }

            set
            {
                pageFlag = value;
            }
        }
        [JsonProperty(PropertyName = "pageNo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int PageNo
        {
            get
            {
                return pageNo;
            }

            set
            {
                pageNo = value;
            }
        }
        [JsonProperty(PropertyName = "pageRows", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int PageRows
        {
            get
            {
                return pageRows;
            }

            set
            {
                pageRows = value;
            }
        }
        [JsonProperty(PropertyName = "totalCount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalCount
        {
            get
            {
                return totalCount;
            }

            set
            {
                totalCount = value;
            }
        }
        [JsonProperty(PropertyName = "totalPages", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalPages
        {
            get
            {
                return totalPages;
            }

            set
            {
                totalPages = value;
            }
        }
        [JsonProperty(PropertyName = "realPageNo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int RealPageNo
        {
            get
            {
                return realPageNo;
            }

            set
            {
                realPageNo = value;
            }
        }
        [JsonProperty(PropertyName = "paramList", NullValueHandling = NullValueHandling.Ignore)]
        public ArrayList ParamList
        {
            get
            {
                return paramList;
            }

            set
            {
                paramList = value;
            }
        }

        [JsonProperty(PropertyName = "f", NullValueHandling = NullValueHandling.Ignore)]
        public TCondition Condition
        {
            get
            {
                return _Condition;
            }

            set
            {
                _Condition = value;
            }
        }

        [JsonProperty(PropertyName = "resultList", NullValueHandling = NullValueHandling.Ignore)]
        public List<TResult> ResultList
        {
            get
            {
                return resultList;
            }

            set
            {
                resultList = value;
            }
        }
        [JsonProperty(PropertyName = "map", NullValueHandling = NullValueHandling.Ignore)]
        public Hashtable Map
        {
            get
            {
                return map;
            }

            set
            {
                map = value;
            }
        }
    }

    public class Response
    {
        private long error;
        private Hashtable map;
        private string message;

        [JsonProperty(PropertyName = "error", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long Error
        {
            get
            {
                return error;
            }

            set
            {
                error = value;
            }
        }

        [JsonProperty(PropertyName = "map", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Hashtable Map
        {
            get
            {
                return map;
            }

            set
            {
                map = value;
            }
        }

        [JsonProperty(PropertyName = "message", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }
    }
}
