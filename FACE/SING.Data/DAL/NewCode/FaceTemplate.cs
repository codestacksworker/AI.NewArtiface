using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL.NewCode
{
    public class FaceTemplate : DataAcess
    {
        private string uuid;
        private string objId;
        private string ftDkey;
        private int ftType;
        private int ftIndex;
        private long ftImageTime;
        private long ftTime;
        private int ftQuality;
        private int faceX;
        private int faceY;
        private int faceCx;
        private int faceCy;
        private string ftRemarks;
        private string imgmd;
        private int ftdbId;
        private byte[] ftImage;
        private byte[] ftFea;
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
        [JsonProperty(PropertyName = "objId", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjId
        {
            get
            {
                return objId;
            }

            set
            {
                objId = value;
            }
        }
        [JsonProperty(PropertyName = "ftDkey", NullValueHandling = NullValueHandling.Ignore)]
        public string FtDkey
        {
            get
            {
                return ftDkey;
            }

            set
            {
                ftDkey = value;
            }
        }
        [JsonProperty(PropertyName = "ftType", NullValueHandling = NullValueHandling.Ignore)]
        public int FtType
        {
            get
            {
                return ftType;
            }

            set
            {
                ftType = value;
            }
        }
        [JsonProperty(PropertyName = "ftIndex", NullValueHandling = NullValueHandling.Ignore)]
        public int FtIndex
        {
            get
            {
                return ftIndex;
            }

            set
            {
                ftIndex = value;
            }
        }
        [JsonProperty(PropertyName = "ftImageTime", NullValueHandling = NullValueHandling.Ignore)]
        public long FtImageTime
        {
            get
            {
                return ftImageTime;
            }

            set
            {
                ftImageTime = value;
            }
        }
        [JsonProperty(PropertyName = "ftTime", NullValueHandling = NullValueHandling.Ignore)]
        public long FtTime
        {
            get
            {
                return ftTime;
            }

            set
            {
                ftTime = value;
            }
        }
        [JsonProperty(PropertyName = "ftQuality", NullValueHandling = NullValueHandling.Ignore)]
        public int FtQuality
        {
            get
            {
                return ftQuality;
            }

            set
            {
                ftQuality = value;
            }
        }
        [JsonProperty(PropertyName = "faceX", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "faceY", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "faceCx", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "faceCy", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "ftRemarks", NullValueHandling = NullValueHandling.Ignore)]
        public string FtRemarks
        {
            get
            {
                return ftRemarks;
            }

            set
            {
                ftRemarks = value;
            }
        }
        [JsonProperty(PropertyName = "Imgmd", NullValueHandling = NullValueHandling.Ignore)]
        public string Imgmd
        {
            get
            {
                return imgmd;
            }

            set
            {
                imgmd = value;
            }
        }
        [JsonProperty(PropertyName = "ftdbId", NullValueHandling = NullValueHandling.Ignore)]
        public int FtdbId
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
        [JsonProperty(PropertyName = "ftImage", NullValueHandling = NullValueHandling.Ignore)]
        public byte[] FtImage
        {
            get
            {
                return ftImage;
            }

            set
            {
                ftImage = value;
            }
        }
        [JsonProperty(PropertyName = "ftFea", NullValueHandling = NullValueHandling.Ignore)]
        public byte[] FtFea
        {
            get
            {
                return ftFea;
            }

            set
            {
                ftFea = value;
            }
        }
    }
}
