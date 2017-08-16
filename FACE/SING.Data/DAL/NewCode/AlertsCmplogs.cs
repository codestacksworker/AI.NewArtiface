using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL.NewCode
{
    public class AlertsCmplogs : DataAcess
    {
        private string uuid;
        private string fcmpUuid;
        private long fcapTime;
        private string fcmpCapId;
        private int faceX;
        private int faceY;
        private int faceCx;
        private string imgmd5;
        private int faceCy;
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
        [JsonProperty(PropertyName = "fcmpUuid", NullValueHandling = NullValueHandling.Ignore)]
        public string FcmpUuid
        {
            get
            {
                return fcmpUuid;
            }

            set
            {
                fcmpUuid = value;
            }
        }
        [JsonProperty(PropertyName = "fcapTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "faceX", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int FaceX
        {
            get
            {
                return faceX;
            }

            set
            {
                faceX = value;
            }
        }
        [JsonProperty(PropertyName = "faceY", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int FaceY
        {
            get
            {
                return faceY;
            }

            set
            {
                faceY = value;
            }
        }
        [JsonProperty(PropertyName = "faceCx", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int FaceCx
        {
            get
            {
                return faceCx;
            }

            set
            {
                faceCx = value;
            }
        }
        [JsonProperty(PropertyName = "imgmd5", NullValueHandling = NullValueHandling.Ignore)]
        public string Imgmd5
        {
            get
            {
                return imgmd5;
            }

            set
            {
                imgmd5 = value;
            }
        }
        [JsonProperty(PropertyName = "faceCy", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int FaceCy
        {
            get
            {
                return faceCy;
            }

            set
            {
                faceCy = value;
            }
        }
    }
}
