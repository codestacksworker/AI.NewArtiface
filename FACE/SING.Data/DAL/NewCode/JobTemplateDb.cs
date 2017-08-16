using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL.NewCode
{
    public class JobTemplateDb: DataAcess
    {
        private string uuid;
        private string jobId;
        private string ftDbId;
        private string adder;
        private DateTime addTime;
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
        [JsonProperty(PropertyName = "jobId", NullValueHandling = NullValueHandling.Ignore)]
        public string JobId
        {
            get
            {
                return jobId;
            }

            set
            {
                jobId = value;
            }
        }
        [JsonProperty(PropertyName = "ftDbId", NullValueHandling = NullValueHandling.Ignore)]
        public string FtDbId
        {
            get
            {
                return ftDbId;
            }

            set
            {
                ftDbId = value;
            }
        }
        [JsonProperty(PropertyName = "uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Adder
        {
            get
            {
                return adder;
            }

            set
            {
                adder = value;
            }
        }
        [JsonProperty(PropertyName = "addTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime AddTime
        {
            get
            {
                return addTime;
            }

            set
            {
                addTime = value;
            }
        }
    }
}
