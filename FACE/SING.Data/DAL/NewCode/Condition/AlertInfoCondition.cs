using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.DAL.NewCode.Condition
{
    public class AlertInfoCondition:DataProcess
    {
        private int[] nameids;
        private string[] dbIds;//DBID
        private string[] channelIds;//channelIDs
        private int idType;
        private string idNumber;
        private string startTime;
        private string endTime;
        private string userId;
        private int topCount;

        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int[] NameIds
        {
            get
            {
                return nameids;
            }

            set
            {
                nameids = value;
            }
        }

        [JsonProperty(PropertyName = "DBID", NullValueHandling = NullValueHandling.Ignore)]
        public string[] DbIds
        {
            get
            {
                return dbIds;
            }

            set
            {
                dbIds = value;
            }
        }

        [JsonProperty(PropertyName = "channelIDs", NullValueHandling = NullValueHandling.Ignore)]
        public string[] ChannelIds
        {
            get
            {
                return channelIds;
            }

            set
            {
                channelIds = value;
            }
        }

        [JsonProperty(PropertyName = "idType", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "idNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string IdNumber
        {
            get
            {
                return idNumber;
            }

            set
            {
                idNumber = value;
            }
        }
        [JsonProperty(PropertyName = "startTime", NullValueHandling = NullValueHandling.Ignore)]
        public string StartTime
        {
            get
            {
                return startTime;
            }

            set
            {
                startTime = value;
            }
        }
        [JsonProperty(PropertyName = "endTime", NullValueHandling = NullValueHandling.Ignore)]
        public string EndTime
        {
            get
            {
                return endTime;
            }

            set
            {
                endTime = value;
            }
        }
        [JsonProperty(PropertyName = "userId", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId
        {
            get
            {
                return userId;
            }

            set
            {
                userId = value;
            }
        }
        [JsonProperty(PropertyName = "topCount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TopCount
        {
            get
            {
                return topCount;
            }

            set
            {
                topCount = value;
            }
        }
    }
}
