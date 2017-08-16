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
    public class Regions : DataProcess
    {
        private int id;
        private string regionName;
        private string regionDescription;
        private int parentId;
        private int regionLevel;
        private int regionSort;

        private List<Channel> channelList; //通道列表
        private List<int> childRegionIdList;    //子区域id列表
        private List<string> childRegionNameList;   //子区域名称列表
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
        [JsonProperty(PropertyName = "regionDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string RegionDescription
        {
            get
            {
                return regionDescription;
            }

            set
            {
                regionDescription = value;
            }
        }
        [JsonProperty(PropertyName = "parentId", NullValueHandling = NullValueHandling.Ignore)]
        public int ParentId
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
        [JsonProperty(PropertyName = "regionLevel", NullValueHandling = NullValueHandling.Ignore)]
        public int RegionLevel
        {
            get
            {
                return regionLevel;
            }

            set
            {
                regionLevel = value;
            }
        }
        [JsonProperty(PropertyName = "regionSort", NullValueHandling = NullValueHandling.Ignore)]
        public int RegionSort
        {
            get
            {
                return regionSort;
            }

            set
            {
                regionSort = value;
            }
        }
        [JsonProperty(PropertyName = "channelList", NullValueHandling = NullValueHandling.Ignore)]
        public List<Channel> ChannelList
        {
            get
            {
                return channelList;
            }

            set
            {
                channelList = value;
            }
        }
        [JsonProperty(PropertyName = "childRegionIdList", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> ChildRegionIdList
        {
            get
            {
                return childRegionIdList;
            }

            set
            {
                childRegionIdList = value;
            }
        }
        [JsonProperty(PropertyName = "childRegionNameList", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ChildRegionNameList
        {
            get
            {
                return childRegionNameList;
            }

            set
            {
                childRegionNameList = value;
            }
        }

        #region   数据接口
        /// <summary>
        /// 按区域等级展示区域通道信息(按照通道模糊查询)
        /// CORE_WS_TD_005
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        [Url("/facecore/regions/queryRegionAndChannel")]
        public Pager<RegionsCondition, Regions> QueryRegionAndChannel(Pager<RegionsCondition> pager)
        {
            return base.RequestForPager<RegionsCondition,Regions>(pager);
        }

        /// <summary>
        /// 添加区域信息，保存数据库，返回处理结果
        /// CORE_WS_TD_102		
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        [Url("/facecore/regions/save")]
        public Regions Insert()
        {
            return Request<Regions>();
        }

        /// <summary>
        /// 修改区域信息，保存数据库，返回处理结果
        /// CORE_WS_TD_103
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        [Url("/facecore/regions/update")]
        public Regions Update()
        {
            return Request<Regions>();
        }

        /// <summary>
        /// 按照指定区域，删除数据库区域信息，返回处理结果
        /// CORE_WS_TD_104				
        /// </summary>
        /// <param name="idarr"></param>
        /// <returns></returns>
        [Url("/facecore/regions/delete")]
        public bool Delete(string[] idarr)
        {
            return Request(idarr);
        }
        #endregion
    }
}
