using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL.NewCode.Data
{
    public class FaceTemplateData : UIDataBase
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

        public string Uuid
        {
            get
            {
                return uuid;
            }

            set
            {
                uuid = value;
                OnPropertyChanged("Uuid");
            }
        }

        public string ObjId
        {
            get
            {
                return objId;
            }

            set
            {
                objId = value;
                OnPropertyChanged("ObjId");
            }
        }

        public string FtDkey
        {
            get
            {
                return ftDkey;
            }

            set
            {
                ftDkey = value;
                OnPropertyChanged("FtDkey");
            }
        }

        public int FtType
        {
            get
            {
                return ftType;
            }

            set
            {
                ftType = value;
                OnPropertyChanged("FtType");
            }
        }

        public int FtIndex
        {
            get
            {
                return ftIndex;
            }

            set
            {
                ftIndex = value;
                OnPropertyChanged("FtIndex");
            }
        }

        public long FtImageTime
        {
            get
            {
                return ftImageTime;
            }

            set
            {
                ftImageTime = value;
                OnPropertyChanged("FtImageTime");
            }
        }

        public long FtTime
        {
            get
            {
                return ftTime;
            }

            set
            {
                ftTime = value;
                OnPropertyChanged("FtTime");
            }
        }

        public int FtQuality
        {
            get
            {
                return ftQuality;
            }

            set
            {
                ftQuality = value;
                OnPropertyChanged("FtQuality");
            }
        }

        public int FaceX
        {
            get
            {
                return faceX;
            }

            set
            {
                faceX = value;
                OnPropertyChanged("FaceX");
            }
        }

        public int FaceY
        {
            get
            {
                return faceY;
            }

            set
            {
                faceY = value;
                OnPropertyChanged("FaceY");
            }
        }

        public int FaceCx
        {
            get
            {
                return faceCx;
            }

            set
            {
                faceCx = value;
                OnPropertyChanged("FaceCx");
            }
        }

        public int FaceCy
        {
            get
            {
                return faceCy;
            }

            set
            {
                faceCy = value;
                OnPropertyChanged("FaceCy");
            }
        }

        public string FtRemarks
        {
            get
            {
                return ftRemarks;
            }

            set
            {
                ftRemarks = value;
                OnPropertyChanged("FtRemarks");
            }
        }

        public string Imgmd
        {
            get
            {
                return imgmd;
            }

            set
            {
                imgmd = value;
                OnPropertyChanged("Imgmd");
            }
        }

        public int FtdbId
        {
            get
            {
                return ftdbId;
            }

            set
            {
                ftdbId = value;
                OnPropertyChanged("FtdbId");
            }
        }

        public byte[] FtImage
        {
            get
            {
                return ftImage;
            }

            set
            {
                ftImage = value;
                OnPropertyChanged("FtImage");
            }
        }

        public byte[] FtFea
        {
            get
            {
                return ftFea;
            }

            set
            {
                ftFea = value;
                OnPropertyChanged("FtFea");
            }
        }
    }
}
