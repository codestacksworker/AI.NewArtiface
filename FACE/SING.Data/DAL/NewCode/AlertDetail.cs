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
    public class AlertDetail: DataAcess
    {
        private string fcapImgUuid;// 抓拍图片ID 根据抓拍图片ID，到图片服务器获取抓拍图片
        private string fcapImgUrl;//抓拍图片URL 用于回显抓拍图片

        private string fcmpImgUuid;// 目标人图片ID 根据目标人图片ID，到图片服务器获取目标人图片
        private string fcmpImgUrl;// 目标人图片URL 用于回显目标人图片

        private string fcapUuid;// 抓拍id

        private string channelName;// 通道名称 

        private int sex;// 目标人性别  0 未知 1 男 2 女

        private string sexTag;// 性别标识 String 回显性别中文值
        private string name;// 目标人姓名 
        private int appearNumber; //出现次数 
        private string regionName;// 区域名称 String
        private double threshold;// 质量系数 double  //
        private long ftImgTime; //图片采集时间 long

        [JsonProperty(PropertyName = "fcapImgUuid", NullValueHandling = NullValueHandling.Ignore)]
        public string FcapImgUuid
        {
            get
            {
                return fcapImgUuid;
            }

            set
            {
                fcapImgUuid = value;
            }
        }
        [JsonProperty(PropertyName = "fcapImgUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string FcapImgUrl
        {
            get
            {
                return fcapImgUrl;
            }

            set
            {
                fcapImgUrl = value;
            }
        }
        [JsonProperty(PropertyName = "fcmpImgUuid", NullValueHandling = NullValueHandling.Ignore)]
        public string FcmpImgUuid
        {
            get
            {
                return fcmpImgUuid;
            }

            set
            {
                fcmpImgUuid = value;
            }
        }
        [JsonProperty(PropertyName = "fcmpImgUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string FcmpImgUrl
        {
            get
            {
                return fcmpImgUrl;
            }

            set
            {
                fcmpImgUrl = value;
            }
        }
        [JsonProperty(PropertyName = "fcapUuid", NullValueHandling = NullValueHandling.Ignore)]
        public string FcapUuid
        {
            get
            {
                return fcapUuid;
            }

            set
            {
                fcapUuid = value;
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
        [JsonProperty(PropertyName = "appearNumber", NullValueHandling = NullValueHandling.Ignore)]
        public int AppearNumber
        {
            get
            {
                return appearNumber;
            }

            set
            {
                appearNumber = value;
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
        [JsonProperty(PropertyName = "threshold", NullValueHandling = NullValueHandling.Ignore)]
        public double Threshold
        {
            get
            {
                return threshold;
            }

            set
            {
                threshold = value;
            }
        }
        [JsonProperty(PropertyName = "ftImgTime", NullValueHandling = NullValueHandling.Ignore)]
        public long FtImgTime
        {
            get
            {
                return ftImgTime;
            }

            set
            {
                ftImgTime = value;
            }
        }

        #region  数据接口
        
        #endregion
    }
}
