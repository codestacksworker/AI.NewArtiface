using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL.NewCode.Data
{
    public class FcmpCaptureAlarmData : UIDataBase
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

        public string FcmpCapChannel
        {
            get
            {
                return fcmpCapChannel;
            }

            set
            {
                fcmpCapChannel = value;
                OnPropertyChanged("FcmpCapChannel");
            }
        }

        public long FcmpTime
        {
            get
            {
                return fcmpTime;
            }

            set
            {
                fcmpTime = value;
                OnPropertyChanged("FcmpTime");
            }
        }

        public int FcmpOrder
        {
            get
            {
                return fcmpOrder;
            }

            set
            {
                fcmpOrder = value;
                OnPropertyChanged("FcmpOrder");
            }
        }

        public double FcmpSocre
        {
            get
            {
                return fcmpSocre;
            }

            set
            {
                fcmpSocre = value;
                OnPropertyChanged("FcmpSocre");
            }
        }

        public string FcmpFobjId
        {
            get
            {
                return fcmpFobjId;
            }

            set
            {
                fcmpFobjId = value;
                OnPropertyChanged("FcmpFobjId");
            }
        }

        public string FcmpFobjName
        {
            get
            {
                return fcmpFobjName;
            }

            set
            {
                fcmpFobjName = value;
                OnPropertyChanged("FcmpFobjName");
            }
        }

        public int FcmpFobjType
        {
            get
            {
                return fcmpFobjType;
            }

            set
            {
                fcmpFobjType = value;
                OnPropertyChanged("FcmpFobjType");
            }
        }

        public int FcmpFobjSex
        {
            get
            {
                return fcmpFobjSex;
            }

            set
            {
                fcmpFobjSex = value;
                OnPropertyChanged("FcmpFobjSex");
            }
        }

        public int FcmpType
        {
            get
            {
                return fcmpType;
            }

            set
            {
                fcmpType = value;
                OnPropertyChanged("FcmpType");
            }
        }

        public float ChannelLongitude
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

        public float ChannelLatitude
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

        public string FcmpFtId
        {
            get
            {
                return fcmpFtId;
            }

            set
            {
                fcmpFtId = value;
                OnPropertyChanged("FcmpFtId");
            }
        }

        public long FtdbId
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
    }
}
