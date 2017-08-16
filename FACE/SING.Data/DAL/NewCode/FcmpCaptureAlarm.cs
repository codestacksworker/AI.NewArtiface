using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL.NewCode
{
    public class FcmpCaptureAlarm : DataAcess
    {
        private string uuid;
        private string fcmpCapId;
        private string fcmpCapChannel;
        private long fcmpTime;
        private int fcmpOrder;
        private double fcmpSocre;
        private string fcmpFobjId;
        private string fcmpFobjName;
        private int fcmpFobjType;
        private int fcmpFobjSex;
        private int fcmpType;
        private float channelLongitude;
        private float channelLatitude;
        private int channelDirect;
        private long fcapTime;
        private string fcmpFtId;
        private long ftdbId;
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
        [JsonProperty(PropertyName = "fcmpCapId", NullValueHandling = NullValueHandling.Ignore)]
        public string FcmpCapId
        {
            get
            {
                return fcmpCapId;
            }

            set
            {
                fcmpCapId = value;
            }
        }
        [JsonProperty(PropertyName = "fcmpCapChannel", NullValueHandling = NullValueHandling.Ignore)]
        public string FcmpCapChannel
        {
            get
            {
                return fcmpCapChannel;
            }

            set
            {
                fcmpCapChannel = value;
            }
        }
        [JsonProperty(PropertyName = "fcmpTime", NullValueHandling = NullValueHandling.Ignore)]
        public long FcmpTime
        {
            get
            {
                return fcmpTime;
            }

            set
            {
                fcmpTime = value;
            }
        }
        [JsonProperty(PropertyName = "fcmpOrder", NullValueHandling = NullValueHandling.Ignore)]
        public int FcmpOrder
        {
            get
            {
                return fcmpOrder;
            }

            set
            {
                fcmpOrder = value;
            }
        }
        [JsonProperty(PropertyName = "fcmpSocre", NullValueHandling = NullValueHandling.Ignore)]
        public double FcmpSocre
        {
            get
            {
                return fcmpSocre;
            }

            set
            {
                fcmpSocre = value;
            }
        }
        [JsonProperty(PropertyName = "fcmpFobjId", NullValueHandling = NullValueHandling.Ignore)]
        public string FcmpFobjId
        {
            get
            {
                return fcmpFobjId;
            }

            set
            {
                fcmpFobjId = value;
            }
        }
        [JsonProperty(PropertyName = "fcmpFobjName", NullValueHandling = NullValueHandling.Ignore)]
        public string FcmpFobjName
        {
            get
            {
                return fcmpFobjName;
            }

            set
            {
                fcmpFobjName = value;
            }
        }
        [JsonProperty(PropertyName = "fcmpFobjType", NullValueHandling = NullValueHandling.Ignore)]
        public int FcmpFobjType
        {
            get
            {
                return fcmpFobjType;
            }

            set
            {
                fcmpFobjType = value;
            }
        }
        [JsonProperty(PropertyName = "fcmpFobjSex", NullValueHandling = NullValueHandling.Ignore)]
        public int FcmpFobjSex
        {
            get
            {
                return fcmpFobjSex;
            }

            set
            {
                fcmpFobjSex = value;
            }
        }
        [JsonProperty(PropertyName = "fcmpType", NullValueHandling = NullValueHandling.Ignore)]
        public int FcmpType
        {
            get
            {
                return fcmpType;
            }

            set
            {
                fcmpType = value;
            }
        }
        [JsonProperty(PropertyName = "channelLongitude", NullValueHandling = NullValueHandling.Ignore)]
        public float ChannelLongitude
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
        public float ChannelLatitude
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
        [JsonProperty(PropertyName = "fcmpFtId", NullValueHandling = NullValueHandling.Ignore)]
        public string FcmpFtId
        {
            get
            {
                return fcmpFtId;
            }

            set
            {
                fcmpFtId = value;
            }
        }
        [JsonProperty(PropertyName = "ftdbId", NullValueHandling = NullValueHandling.Ignore)]
        public long FtdbId
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
    }
}
