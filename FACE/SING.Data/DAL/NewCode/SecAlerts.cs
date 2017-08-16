using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL.NewCode
{
    public class SecAlerts : DataAcess
    {
        private string uuid;
        private int ackStat;
        private long actTime;
        private string acker;
        private int pubStat;
        private long pubTime;
        private string puber;
        private long fcapTime;
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
        [JsonProperty(PropertyName = "ackStat", NullValueHandling = NullValueHandling.Ignore)]
        public int AckStat
        {
            get
            {
                return ackStat;
            }

            set
            {
                ackStat = value;
            }
        }
        [JsonProperty(PropertyName = "actTime", NullValueHandling = NullValueHandling.Ignore)]
        public long ActTime
        {
            get
            {
                return actTime;
            }

            set
            {
                actTime = value;
            }
        }
        [JsonProperty(PropertyName = "acker", NullValueHandling = NullValueHandling.Ignore)]
        public string Acker
        {
            get
            {
                return acker;
            }

            set
            {
                acker = value;
            }
        }
        [JsonProperty(PropertyName = "pubStat", NullValueHandling = NullValueHandling.Ignore)]
        public int PubStat
        {
            get
            {
                return pubStat;
            }

            set
            {
                pubStat = value;
            }
        }
        [JsonProperty(PropertyName = "pubTime", NullValueHandling = NullValueHandling.Ignore)]
        public long PubTime
        {
            get
            {
                return pubTime;
            }

            set
            {
                pubTime = value;
            }
        }
        [JsonProperty(PropertyName = "puber", NullValueHandling = NullValueHandling.Ignore)]
        public string Puber
        {
            get
            {
                return puber;
            }

            set
            {
                puber = value;
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
    }
}
