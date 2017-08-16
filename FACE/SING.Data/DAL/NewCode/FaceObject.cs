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
    public class FaceObject : DataProcess
    {
        private string uuid;
        private string mainFtid;
        private string name;
        private int type;
        private int sst;
        private int reserved;
        private int sex;
        private long timestamp;
        private string timestampStr;
        private string remarks;
        private string idNumb;
        private int idType;
        private long birthDate;
        private string addr;
        private string ethnic;
        private int ftdbId;
        private string tags;

        private string sexTag;  //性别显示值
        private string sstTag;  //敏感等级
        private string idTypeTag; //证件类型显示

        private string birthDateStr;//生日日期
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
        [JsonProperty(PropertyName = "mainFtid", NullValueHandling = NullValueHandling.Ignore)]
        public string MainFtid
        {
            get
            {
                return mainFtid;
            }

            set
            {
                mainFtid = value;
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
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
        [JsonProperty(PropertyName = "sst", NullValueHandling = NullValueHandling.Ignore)]
        public int Sst
        {
            get
            {
                return sst;
            }

            set
            {
                sst = value;
            }
        }
        [JsonProperty(PropertyName = "reserved", NullValueHandling = NullValueHandling.Ignore)]
        public int Reserved
        {
            get
            {
                return reserved;
            }

            set
            {
                reserved = value;
            }
        }
        [JsonProperty(PropertyName = "sex", NullValueHandling = NullValueHandling.Ignore)]
        public int Sex
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
        [JsonProperty(PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public long Timestamp
        {
            get
            {
                return timestamp;
            }

            set
            {
                timestamp = value;
            }
        }
        [JsonProperty(PropertyName = "timestampStr", NullValueHandling = NullValueHandling.Ignore)]
        public string TimestampStr
        {
            get
            {
                return timestampStr;
            }

            set
            {
                timestampStr = value;
            }
        }
        [JsonProperty(PropertyName = "remarks", NullValueHandling = NullValueHandling.Ignore)]
        public string Remarks
        {
            get
            {
                return remarks;
            }

            set
            {
                remarks = value;
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
        [JsonProperty(PropertyName = "idType", NullValueHandling = NullValueHandling.Ignore)]
        public int IdType
        {
            get
            {
                return idType;
            }

            set
            {
                idType = value;
            }
        }
        [JsonProperty(PropertyName = "birthDate", NullValueHandling = NullValueHandling.Ignore)]
        public long BirthDate
        {
            get
            {
                return birthDate;
            }

            set
            {
                birthDate = value;
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
        [JsonProperty(PropertyName = "ethnic", NullValueHandling = NullValueHandling.Ignore)]
        public string Ethnic
        {
            get
            {
                return ethnic;
            }

            set
            {
                ethnic = value;
            }
        }
        [JsonProperty(PropertyName = "ftdbId", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "tags", NullValueHandling = NullValueHandling.Ignore)]
        public string Tags
        {
            get
            {
                return tags;
            }

            set
            {
                tags = value;
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
        [JsonProperty(PropertyName = "sstTag", NullValueHandling = NullValueHandling.Ignore)]
        public string SstTag
        {
            get
            {
                return sstTag;
            }

            set
            {
                sstTag = value;
            }
        }
        [JsonProperty(PropertyName = "idTypeTag", NullValueHandling = NullValueHandling.Ignore)]
        public string IdTypeTag
        {
            get
            {
                return idTypeTag;
            }

            set
            {
                idTypeTag = value;
            }
        }
        [JsonProperty(PropertyName = "birthDateStr", NullValueHandling = NullValueHandling.Ignore)]
        public string BirthDateStr
        {
            get
            {
                return birthDateStr;
            }

            set
            {
                birthDateStr = value;
            }
        }

        #region  数据接口
        /// <summary>
        /// 查询目标人，返回目标人列表
        /// CORE_WS_MB_001				
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        [Url("/facecore/faceObject/query")]
        public Pager<FaceObjectCondition,FaceObject> Query(Pager<FaceObjectCondition> pager)
        {
            return RequestForPager<FaceObjectCondition, FaceObject>(pager);
        }

        /// <summary>
        /// 新增目标人信息，保存到数据库，返回处理结果
        /// CORE_WS_MB_002				
        /// </summary>
        /// <param name="fobj"></param>
        /// <returns></returns>
        [Url("/facecore/faceObject/save")]
        public FaceObject Insert()
        {
            return Request<FaceObject>();
        }

        /// <summary>
        /// 修改目标人信息，保存到数据库，返回处理结果				
        /// CORE_WS_MB_003				
        /// </summary>
        /// <param name="fobj"></param>
        /// <returns></returns>
        [Url("/facecore/faceObject/update")]
        public FaceObject Update()
        {
            return Request<FaceObject>();
        }

        /// <summary>
        /// 删除目标人信息，返回处理结果				
        /// CORE_WS_MB_004				
        /// </summary>
        /// <param name="fobj"></param>
        /// <returns></returns>
        [Url("/facecore/faceObject/delete")]
        public bool Delete(string [] idarr)
        {
            return Request(idarr);
        }
        #endregion
    }
}
