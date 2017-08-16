using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.DAL.Data;

namespace SING.Data.DAL.NewCode
{
    public class FaceTemplateDb : DataProcess
    {
        private int id;
        private string templateDbName;
        private string templateDbDescription;
        private int templateDbType;
        private int isUsed;
        private int templateDbSize;
        private long createTime;
        private int isDeleted;
        private int templateDbCapacity;

        private int objectCount;// 目标人数量
        private string createTimeStr;// 创建时间
        private string templateDbTypeTag;//模板类型
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        [JsonProperty(PropertyName = "templateDbName", NullValueHandling = NullValueHandling.Ignore)]
        public string TemplateDbName
        {
            get
            {
                return templateDbName;
            }

            set
            {
                templateDbName = value;
            }
        }
        [JsonProperty(PropertyName = "templateDbDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string TemplateDbDescription
        {
            get
            {
                return templateDbDescription;
            }

            set
            {
                templateDbDescription = value;
            }
        }
        [JsonProperty(PropertyName = "templateDbType", NullValueHandling = NullValueHandling.Ignore)]
        public int TemplateDbType
        {
            get
            {
                return templateDbType;
            }

            set
            {
                templateDbType = value;
            }
        }
        [JsonProperty(PropertyName = "isUsed", NullValueHandling = NullValueHandling.Ignore)]
        public int IsUsed
        {
            get
            {
                return isUsed;
            }

            set
            {
                isUsed = value;
            }
        }
        [JsonProperty(PropertyName = "templateDbSize", NullValueHandling = NullValueHandling.Ignore)]
        public int TemplateDbSize
        {
            get
            {
                return templateDbSize;
            }

            set
            {
                templateDbSize = value;
            }
        }
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public long CreateTime
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
        [JsonProperty(PropertyName = "isDeleted", NullValueHandling = NullValueHandling.Ignore)]
        public int IsDeleted
        {
            get
            {
                return isDeleted;
            }

            set
            {
                isDeleted = value;
            }
        }
        [JsonProperty(PropertyName = "templateDbCapacity", NullValueHandling = NullValueHandling.Ignore)]
        public int TemplateDbCapacity
        {
            get
            {
                return templateDbCapacity;
            }

            set
            {
                templateDbCapacity = value;
            }
        }
        [JsonProperty(PropertyName = "objectCount", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "createTimeStr", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "templateDbTypeTag", NullValueHandling = NullValueHandling.Ignore)]
        public string TemplateDbTypeTag
        {
            get
            {
                return templateDbTypeTag;
            }

            set
            {
                templateDbTypeTag = value;
            }
        }

        #region  数据接口
        /// <summary>
        /// 查询全部模板库，返回查询结果列表
        /// CORE_WS_MB_101				
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        [Url("/facecore/faceTemplateDb/queryAll")]
        public Pager<FaceTemplateDb, FaceTemplateDb> QueryAll(Pager<FaceTemplateDb> pager)
        {
            return RequestForPager<FaceTemplateDb, FaceTemplateDb>(pager);
        }


        /// <summary>
        /// 查询目标库，返回目标库信息（以及目标人数、模板数）列表				
        /// CORE_WS_MB_105				
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        [Url("/facecore/faceTemplateDb/queryDetail")]
        public Pager<FaceTemplateDb,FaceTemplateDb> QueryDetail(Pager<FaceTemplateDb> pager)
        {
            return RequestForPager<FaceTemplateDb, FaceTemplateDb>(pager);
        }

        /// <summary>
        /// 添加目标库信息，保存数据库，返回处理结果
        /// CORE_WS_MB_102				
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        [Url("/facecore/faceTemplateDb/save")]
        public FaceTemplateDb Insert()
        {
            return Request<FaceTemplateDb>();
        }

        /// <summary>
        /// 修改目标库信息，保存到数据库，返回处理结果				
        /// CORE_WS_MB_103				
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        [Url("/facecore/faceTemplateDb/update")]
        public bool Update()
        {
            return Request();
        }

        /// <summary>
        /// 按照指定的库，删除数据库中目标库数据，返回处理结果				
        /// CORE_WS_MB_104				
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        [Url("/facecore/faceTemplateDb/delete")]
        public bool Delete(string[] idarr)
        {
            return Request(idarr);
        }
        #endregion
    }
}
