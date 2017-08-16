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
    public class Channel : DataProcess
    {
        private string uuid;
        private string channelName;
        private string channelDescription;
        private int channelType;
        private string channelAddr;
        private int channelPort;
        private string channelUid;
        private string channelPsw;
        private string channelNo;
        private string channelGuid;
        private int minFaceWidth;
        private int minImgQuality;
        private int minCapDistance;
        private int maxSaveDistance;
        private int maxYaw;
        private int maxRoll;
        private int maxPitch;
        private double channelLongitude;
        private double channelLatitude;
        private string channelArea;
        private int channelDirect;
        private double channelThreshold;
        private int capStat;
        private int isDel;
        private DateTime lastTimestamp;
        private string lastTimestampStr;
        private int regionId;
        private int reserved;
        private string sdkVer;
        private int important;
        private string channelVerid;

        private string capStatTag;  //抓拍状态显示
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
        [JsonProperty(PropertyName = "channelDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelDescription
        {
            get
            {
                return channelDescription;
            }

            set
            {
                channelDescription = value;
            }
        }
        [JsonProperty(PropertyName = "channelType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int ChannelType
        {
            get
            {
                return channelType;
            }

            set
            {
                channelType = value;
            }
        }
        [JsonProperty(PropertyName = "channelAddr", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelAddr
        {
            get
            {
                return channelAddr;
            }

            set
            {
                channelAddr = value;
            }
        }
        [JsonProperty(PropertyName = "channelPort", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int ChannelPort
        {
            get
            {
                return channelPort;
            }

            set
            {
                channelPort = value;
            }
        }
        [JsonProperty(PropertyName = "channelUid", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelUid
        {
            get
            {
                return channelUid;
            }

            set
            {
                channelUid = value;
            }
        }
        [JsonProperty(PropertyName = "channelPsw", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelPsw
        {
            get
            {
                return channelPsw;
            }

            set
            {
                channelPsw = value;
            }
        }
        [JsonProperty(PropertyName = "channelNo", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelNo
        {
            get
            {
                return channelNo;
            }

            set
            {
                channelNo = value;
            }
        }
        [JsonProperty(PropertyName = "channelGuid", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelGuid
        {
            get
            {
                return channelGuid;
            }

            set
            {
                channelGuid = value;
            }
        }
        [JsonProperty(PropertyName = "minFaceWidth", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MinFaceWidth
        {
            get
            {
                return minFaceWidth;
            }

            set
            {
                minFaceWidth = value;
            }
        }
        [JsonProperty(PropertyName = "minImgQuality", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MinImgQuality
        {
            get
            {
                return minImgQuality;
            }

            set
            {
                minImgQuality = value;
            }
        }
        [JsonProperty(PropertyName = "minCapDistance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MinCapDistance
        {
            get
            {
                return minCapDistance;
            }

            set
            {
                minCapDistance = value;
            }
        }
        [JsonProperty(PropertyName = "maxSaveDistance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MaxSaveDistance
        {
            get
            {
                return maxSaveDistance;
            }

            set
            {
                maxSaveDistance = value;
            }
        }
        [JsonProperty(PropertyName = "maxYaw", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MaxYaw
        {
            get
            {
                return maxYaw;
            }

            set
            {
                maxYaw = value;
            }
        }
        [JsonProperty(PropertyName = "maxRoll", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MaxRoll
        {
            get
            {
                return maxRoll;
            }

            set
            {
                maxRoll = value;
            }
        }
        [JsonProperty(PropertyName = "maxPitch", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MaxPitch
        {
            get
            {
                return maxPitch;
            }

            set
            {
                maxPitch = value;
            }
        }
        [JsonProperty(PropertyName = "channelLongitude", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double ChannelLongitude
        {
            get
            {
                return channelLongitude;
            }

            set
            {
                channelLongitude = value;
            }
        }
        [JsonProperty(PropertyName = "channelLatitude", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double ChannelLatitude
        {
            get
            {
                return channelLatitude;
            }

            set
            {
                channelLatitude = value;
            }
        }
        [JsonProperty(PropertyName = "channelArea", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelArea
        {
            get
            {
                return channelArea;
            }

            set
            {
                channelArea = value;
            }
        }
        [JsonProperty(PropertyName = "channelDirect", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int ChannelDirect
        {
            get
            {
                return channelDirect;
            }

            set
            {
                channelDirect = value;
            }
        }
        [JsonProperty(PropertyName = "channelThreshold", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double ChannelThreshold
        {
            get
            {
                return channelThreshold;
            }

            set
            {
                channelThreshold = value;
            }
        }
        [JsonProperty(PropertyName = "capStat", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int CapStat
        {
            get
            {
                return capStat;
            }

            set
            {
                capStat = value;
            }
        }
        [JsonProperty(PropertyName = "isDel", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int IsDel
        {
            get
            {
                return isDel;
            }

            set
            {
                isDel = value;
            }
        }
        [JsonProperty(PropertyName = "lastTimestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime LastTimestamp
        {
            get
            {
                return lastTimestamp;
            }

            set
            {
                lastTimestamp = value;
            }
        }
        [JsonProperty(PropertyName = "lastTimestampStr", NullValueHandling = NullValueHandling.Ignore)]
        public string LastTimestampStr
        {
            get
            {
                return lastTimestampStr;
            }

            set
            {
                lastTimestampStr = value;
            }
        }
        [JsonProperty(PropertyName = "regionId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int RegionId
        {
            get
            {
                return regionId;
            }

            set
            {
                regionId = value;
            }
        }
        [JsonProperty(PropertyName = "reserved", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "sdkVer", NullValueHandling = NullValueHandling.Ignore)]
        public string SdkVer
        {
            get
            {
                return sdkVer;
            }

            set
            {
                sdkVer = value;
            }
        }
        [JsonProperty(PropertyName = "Important", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Important
        {
            get
            {
                return important;
            }

            set
            {
                important = value;
            }
        }
        [JsonProperty(PropertyName = "ChannelVerid", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelVerid
        {
            get
            {
                return channelVerid;
            }

            set
            {
                channelVerid = value;
            }
        }

        [JsonProperty(PropertyName = "CapStatTag", NullValueHandling = NullValueHandling.Ignore)]
        public string CapStatTag
        {
            get
            {
                return capStatTag;
            }

            set
            {
                capStatTag = value;
            }
        }

        #region  数据接口
        /// <summary>
        /// 根据输入的信息模糊查询通道信息
        /// CORE_WS_TD_001				
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        [Url("/facecore/channel/query")]
        public Pager<ChannelCondition,Channel> Query(Pager<ChannelCondition> pager)
        {
            return base.RequestForPager<ChannelCondition,Channel>(pager);
        }

        /// <summary>
        /// 新增通道配置信息，保存数据库，返回处理结果
        /// CORE_WS_TD_002				
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        [Url("/facecore/channel/save")]
        public Channel Insert()
        {
            return Request<Channel>();
        }

        /// <summary>
        /// 修改通道配置信息，保存数据库，返回处理结果
        /// CORE_WS_TD_003
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        [Url("/facecore/channel/update")]
        public Channel Update()
        {
            return Request<Channel>();
        }

        /// <summary>
        /// 按照指定通道信息，删除数据库中通道信息，返回处理结果
        /// CORE_WS_TD_004				
        /// </summary>
        /// <param name="idarr"></param>
        /// <returns></returns>
        [Url("/facecore/channel/delete")]
        public bool Delete(string[] idarr)
        {
            return Request(idarr);
        }
        #endregion
    }
}
