using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.DAL.Data;

namespace SING.Data.DAL.NewCode.Data
{
    public class FaceCapture : UIDataBase
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

        public string FcapDcid
        {
            get
            {
                return fcapDcid;
            }

            set
            {
                fcapDcid = value;
                OnPropertyChanged("FcapDcid");
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

        public int FcapQuality
        {
            get
            {
                return fcapQuality;
            }

            set
            {
                fcapQuality = value;
                OnPropertyChanged("FcapQuality");
            }
        }

        public int FcapType
        {
            get
            {
                return fcapType;
            }

            set
            {
                fcapType = value;
                OnPropertyChanged("FcapType");
            }
        }

        public int FcapFaceX
        {
            get
            {
                return fcapFaceX;
            }

            set
            {
                fcapFaceX = value;
                OnPropertyChanged("FcapFaceX");
            }
        }

        public int FcapFaceY
        {
            get
            {
                return fcapFaceY;
            }

            set
            {
                fcapFaceY = value;
                OnPropertyChanged("FcapFaceY");
            }
        }

        public int FcapFaceCx
        {
            get
            {
                return fcapFaceCx;
            }

            set
            {
                fcapFaceCx = value;
                OnPropertyChanged("FcapFaceCx");
            }
        }

        public int FcapFaceCy
        {
            get
            {
                return fcapFaceCy;
            }

            set
            {
                fcapFaceCy = value;
                OnPropertyChanged("FcapFaceCy");
            }
        }

        public int FcapSex
        {
            get
            {
                return fcapSex;
            }

            set
            {
                fcapSex = value;
                OnPropertyChanged("FcapSex");
            }
        }

        public int FcapAge
        {
            get
            {
                return fcapAge;
            }

            set
            {
                fcapAge = value;
                OnPropertyChanged("FcapAge");
            }
        }

        public double ChannelLongitude
        {
            get
            {
                return channelLongitude;
            }

            set
            {
                channelLongitude = value;
                OnPropertyChanged("ChannelLongitude");
            }
        }

        public double ChannelLatitude
        {
            get
            {
                return channelLatitude;
            }

            set
            {
                channelLatitude = value;
                OnPropertyChanged("ChannelLatitude");
            }
        }

        public int ChannelDirect
        {
            get
            {
                return channelDirect;
            }

            set
            {
                channelDirect = value;
                OnPropertyChanged("ChannelDirect");
            }
        }
    }
}
