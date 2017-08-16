using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL.NewCode.Data
{
    public class AlertsCmplogsData :UIDataBase
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

        public string FcmpUuid
        {
            get
            {
                return fcmpUuid;
            }

            set
            {
                fcmpUuid = value;
                OnPropertyChanged("FcmpUuid");
            }
        }
        public long FcapTime
        {
            get
            {
                return fcapTime;
            }

            set
            {
                fcapTime = value;
                OnPropertyChanged("FcapTime");
            }
        }

        public string FcmpCapId
        {
            get
            {
                return fcmpCapId;
            }

            set
            {
                fcmpCapId = value;
                OnPropertyChanged("FcmpCapId");
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

        public string Imgmd5
        {
            get
            {
                return imgmd5;
            }

            set
            {
                imgmd5 = value;
                OnPropertyChanged("Imgmd5");
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
    }
}
