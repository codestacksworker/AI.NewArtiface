using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.DAL.Data;

namespace SING.Data.DAL.NewCode.Data
{
    public class ChannelData : UIDataBase
    {
        private string uuid;
        private string channelName;
        private string channelDescription;
        private int channelType;
        private string channelAddr;
        private int channelPort;
        private string channelUid;
        private string channelPsw;
        private string channelNo;
        private string channelGuid;
        private int minFaceWidth;
        private int minImgQuality;
        private int minCapDistance;
        private int maxSaveDistance;
        private int maxYaw;
        private int maxRoll;
        private int maxPitch;
        private double channelLongitude;
        private double channelLatitude;
        private string channelArea;
        private int channelDirect;
        private double channelThreshold;
        private int capStat;
        private int isDel;
        private DateTime lastTimestamp;
        private string lastTimestampStr;
        private int regionId;
        private int reserved;
        private string sdkVer;
        private int important;
        private string channelVerid;

        private string capStatTag;  //抓拍状态显示

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

        public string ChannelName
        {
            get
            {
                return channelName;
            }

            set
            {
                channelName = value;
                OnPropertyChanged("ChannelName");
            }
        }

        public string ChannelDescription
        {
            get
            {
                return channelDescription;
            }

            set
            {
                channelDescription = value;
                OnPropertyChanged("ChannelDescription");
            }
        }

        public int ChannelType
        {
            get
            {
                return channelType;
            }

            set
            {
                channelType = value;
                OnPropertyChanged("ChannelType");
            }
        }

        public string ChannelAddr
        {
            get
            {
                return channelAddr;
            }

            set
            {
                channelAddr = value;
                OnPropertyChanged("ChannelAddr");
            }
        }

        public int ChannelPort
        {
            get
            {
                return channelPort;
            }

            set
            {
                channelPort = value;
                OnPropertyChanged("ChannelPort");
            }
        }

        public string ChannelUid
        {
            get
            {
                return channelUid;
            }

            set
            {
                channelUid = value;
                OnPropertyChanged("ChannelUid");
            }
        }

        public string ChannelPsw
        {
            get
            {
                return channelPsw;
            }

            set
            {
                channelPsw = value;
                OnPropertyChanged("ChannelPsw");
            }
        }

        public string ChannelNo
        {
            get
            {
                return channelNo;
            }

            set
            {
                channelNo = value;
                OnPropertyChanged("ChannelNo");
            }
        }

        public string ChannelGuid
        {
            get
            {
                return channelGuid;
            }

            set
            {
                channelGuid = value;
                OnPropertyChanged("ChannelGuid");
            }
        }

        public int MinFaceWidth
        {
            get
            {
                return minFaceWidth;
            }

            set
            {
                minFaceWidth = value;
                OnPropertyChanged("MinFaceWidth");
            }
        }

        public int MinImgQuality
        {
            get
            {
                return minImgQuality;
            }

            set
            {
                minImgQuality = value;
                OnPropertyChanged("MinImgQuality");
            }
        }

        public int MinCapDistance
        {
            get
            {
                return minCapDistance;
            }

            set
            {
                minCapDistance = value;
                OnPropertyChanged("MinCapDistance");
            }
        }

        public int MaxSaveDistance
        {
            get
            {
                return maxSaveDistance;
            }

            set
            {
                maxSaveDistance = value;
                OnPropertyChanged("MaxSaveDistance");
            }
        }

        public int MaxYaw
        {
            get
            {
                return maxYaw;
            }

            set
            {
                maxYaw = value;
                OnPropertyChanged("MaxYaw");
            }
        }

        public int MaxRoll
        {
            get
            {
                return maxRoll;
            }

            set
            {
                maxRoll = value;
                OnPropertyChanged("MaxRoll");
            }
        }

        public int MaxPitch
        {
            get
            {
                return maxPitch;
            }

            set
            {
                maxPitch = value;
                OnPropertyChanged("MaxPitch");
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

        public string ChannelArea
        {
            get
            {
                return channelArea;
            }

            set
            {
                channelArea = value;
                OnPropertyChanged("ChannelArea");
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

        public double ChannelThreshold
        {
            get
            {
                return channelThreshold;
            }

            set
            {
                channelThreshold = value;
                OnPropertyChanged("ChannelThreshold");
            }
        }

        public int CapStat
        {
            get
            {
                return capStat;
            }

            set
            {
                capStat = value;
                OnPropertyChanged("CapStat");
            }
        }

        public int IsDel
        {
            get
            {
                return isDel;
            }

            set
            {
                isDel = value;
                OnPropertyChanged("IsDel");
            }
        }

        public DateTime LastTimestamp
        {
            get
            {
                return lastTimestamp;
            }

            set
            {
                lastTimestamp = value;
                OnPropertyChanged("LastTimestamp");
            }
        }

        public string LastTimestampStr
        {
            get
            {
                return lastTimestampStr;
            }

            set
            {
                lastTimestampStr = value;
                OnPropertyChanged("LastTimestampStr");
            }
        }

        public int RegionId
        {
            get
            {
                return regionId;
            }

            set
            {
                regionId = value;
                OnPropertyChanged("RegionId");
            }
        }

        public int Reserved
        {
            get
            {
                return reserved;
            }

            set
            {
                reserved = value;
                OnPropertyChanged("Reserved");
            }
        }

        public string SdkVer
        {
            get
            {
                return sdkVer;
            }

            set
            {
                sdkVer = value;
                OnPropertyChanged("SdkVer");
            }
        }

        public int Important
        {
            get
            {
                return important;
            }

            set
            {
                important = value;
                OnPropertyChanged("Important");
            }
        }

        public string ChannelVerid
        {
            get
            {
                return channelVerid;
            }

            set
            {
                channelVerid = value;
                OnPropertyChanged("ChannelVerid");
            }
        }

        public string CapStatTag
        {
            get
            {
                return capStatTag;
            }

            set
            {
                capStatTag = value;
                OnPropertyChanged("CapStatTag");
            }
        }
    }
}
