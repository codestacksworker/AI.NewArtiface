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
    public class FaceCapture : DataAcess
    {
        private string uuid;
        private string fcapDcid;
        private long fcapTime;
        private int fcapQuality;
        private int fcapType;
        private int fcapFaceX;
        private int fcapFaceY;
        private int fcapFaceCx;
        private int fcapFaceCy;
        private int fcapSex;
        private int fcapAge;
        private double channelLongitude;
        private double channelLatitude;
        private int channelDirect;
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
        [JsonProperty(PropertyName = "fcapDcid", NullValueHandling = NullValueHandling.Ignore)]
        public string FcapDcid
        {
            get
            {
                return fcapDcid;
            }

            set
            {
                fcapDcid = value;
            }
        }
        [JsonProperty(PropertyName = "fcapTime", NullValueHandling = NullValueHandling.Ignore)]
        public long FcapTime
        {
            get
            {
                return fcapTime;
            }

            set
            {
                fcapTime = value;
            }
        }
        [JsonProperty(PropertyName = "fcapQuality", NullValueHandling = NullValueHandling.Ignore)]
        public int FcapQuality
        {
            get
            {
                return fcapQuality;
            }

            set
            {
                fcapQuality = value;
            }
        }
        [JsonProperty(PropertyName = "fcapType", NullValueHandling = NullValueHandling.Ignore)]
        public int FcapType
        {
            get
            {
                return fcapType;
            }

            set
            {
                fcapType = value;
            }
        }
        [JsonProperty(PropertyName = "fcapFaceX", NullValueHandling = NullValueHandling.Ignore)]
        public int FcapFaceX
        {
            get
            {
                return fcapFaceX;
            }

            set
            {
                fcapFaceX = value;
            }
        }
        [JsonProperty(PropertyName = "fcapFaceY", NullValueHandling = NullValueHandling.Ignore)]
        public int FcapFaceY
        {
            get
            {
                return fcapFaceY;
            }

            set
            {
                fcapFaceY = value;
            }
        }
        [JsonProperty(PropertyName = "fcapFaceCx", NullValueHandling = NullValueHandling.Ignore)]
        public int FcapFaceCx
        {
            get
            {
                return fcapFaceCx;
            }

            set
            {
                fcapFaceCx = value;
            }
        }
        [JsonProperty(PropertyName = "fcapFaceCy", NullValueHandling = NullValueHandling.Ignore)]
        public int FcapFaceCy
        {
            get
            {
                return fcapFaceCy;
            }

            set
            {
                fcapFaceCy = value;
            }
        }
        [JsonProperty(PropertyName = "fcapSex", NullValueHandling = NullValueHandling.Ignore)]
        public int FcapSex
        {
            get
            {
                return fcapSex;
            }

            set
            {
                fcapSex = value;
            }
        }
        [JsonProperty(PropertyName = "fcapAge", NullValueHandling = NullValueHandling.Ignore)]
        public int FcapAge
        {
            get
            {
                return fcapAge;
            }

            set
            {
                fcapAge = value;
            }
        }
        [JsonProperty(PropertyName = "channelLongitude", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "channelLatitude", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "channelDirect", NullValueHandling = NullValueHandling.Ignore)]
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

        #region   数据接口
       
        #endregion
    }
}
