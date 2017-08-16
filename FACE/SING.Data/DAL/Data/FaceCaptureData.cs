using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.Help;
using System.Windows.Media;

namespace SING.Data.DAL.Data
{
    [Serializable]
    public class FaceCaptureData : INotifyPropertyChanged
    {
        private string _fcapId;
        private string _fcapDcid;
        private string _fcapTime;
        private int _fcapQuality;
        private int _fcapType;
        private int _fcapFaceX;
        private int _fcapFaceY;
        private int _fcapFaceCx;
        private int _fcapFaceCy;
        private int _fcapSex;
        private int _fcapAge;
        private byte[] _fcapObjImg;
        private byte[] _fcapSceneImg;
        private double _channelLongitude;
        private double _channelLatitude;
        private int _channelDirect;
        private byte[] _fcapObjFeat;
        private string _channelName;

        private string _channelDescription;
        private string _channelAddr;
        private int _channelPort;
        private int _channelType;
        private int _regionId;
        private string _channelNo;
        private string _channelGuid;
        private string _channelArea;
        private string _sdkVer;
        private int _minFaceWidth;
        private int _minImgQuality;
        private int _minCapDistance;
        private int _maxSaveDistance;
        private int _maxYaw;
        private int _maxYoll;
        private int _maxPitch;
        private double _channelThreshold;
        private int _capStat;
        private int _important;

        public virtual string FcapId
        {
            get
            {
                return this._fcapId;
            }
            set
            {
                this._fcapId = value;
                OnPropertyChanged("FcapId");
            }
        }

        public virtual string FcapDcid
        {
            get
            {
                return this._fcapDcid;
            }
            set
            {
                this._fcapDcid = value;
                OnPropertyChanged("FcapDcid");
            }
        }

        public virtual string FcapTime
        {
            get
            {
                return this._fcapTime;
            }
            set
            {
                this._fcapTime = value;
                OnPropertyChanged("FcapTime");
            }
        }

        public virtual int FcapQuality
        {
            get
            {
                return this._fcapQuality;
            }
            set
            {
                this._fcapQuality = value;
                OnPropertyChanged("FcapQuality");
            }
        }

        public virtual int FcapType
        {
            get
            {
                return this._fcapType;
            }
            set
            {
                this._fcapType = value;
                OnPropertyChanged("FcapType");
            }
        }

        public virtual int FcapFaceX
        {
            get
            {
                return this._fcapFaceX;
            }
            set
            {
                this._fcapFaceX = value;
                OnPropertyChanged("FcapFaceX");
            }
        }

        public virtual int FcapFaceY
        {
            get
            {
                return this._fcapFaceY;
            }
            set
            {
                this._fcapFaceY = value;
                OnPropertyChanged("FcapFaceY");
            }
        }

        public virtual int FcapFaceCx
        {
            get
            {
                return this._fcapFaceCx;
            }
            set
            {
                this._fcapFaceCx = value;
                OnPropertyChanged("FcapFaceCx");
            }
        }

        public virtual int FcapFaceCy
        {
            get
            {
                return this._fcapFaceCy;
            }
            set
            {
                this._fcapFaceCy = value;
                OnPropertyChanged("FcapFaceCy");
            }
        }

        public virtual int FcapSex
        {
            get
            {
                return this._fcapSex;
            }
            set
            {
                this._fcapSex = value;
                OnPropertyChanged("FcapSex");
            }
        }

        public virtual int FcapAge
        {
            get
            {
                return this._fcapAge;
            }
            set
            {
                this._fcapAge = value;
                OnPropertyChanged("FcapAge");
            }
        }

        public virtual byte[] FcapObjImg
        {
            get
            {
                return this._fcapObjImg;
            }
            set
            {
                this._fcapObjImg = value;
                OnPropertyChanged("FcapObjImg");
            }
        }

        public virtual byte[] FcapSceneImg
        {
            get
            {
                return this._fcapSceneImg;
            }
            set
            {
                this._fcapSceneImg = value;
                OnPropertyChanged("FcapSceneImg");
            }
        }

        public virtual double ChannelLongitude
        {
            get
            {
                return this._channelLongitude;
            }
            set
            {
                this._channelLongitude = value;
                OnPropertyChanged("ChannelLongitude");
            }
        }

        public virtual double ChannelLatitude
        {
            get
            {
                return this._channelLatitude;
            }
            set
            {
                this._channelLatitude = value;
                OnPropertyChanged("ChannelLatitude");
            }
        }

        public virtual int ChannelDirect
        {
            get
            {
                return this._channelDirect;
            }
            set
            {
                this._channelDirect = value;
                OnPropertyChanged("ChannelDirect");
            }
        }

        public virtual byte[] FcapObjFeat
        {
            get
            {
                return this._fcapObjFeat;
            }
            set
            {
                this._fcapObjFeat = value;
                OnPropertyChanged("FcapObjFeat");
            }
        }

        public virtual string ChannelName
        {
            get
            {
                return this._channelName;
            }
            set
            {
                this._channelName = value;
                OnPropertyChanged("ChannelName");
            }
        }

        public virtual string ChannelDescription
        {
            get
            {
                return this._channelDescription;
            }
            set
            {
                this._channelDescription = value;
                OnPropertyChanged("ChannelDescription");
            }
        }

        public virtual string ChannelAddr
        {
            get
            {
                return this._channelAddr;
            }
            set
            {
                this._channelAddr = value;
                OnPropertyChanged("ChannelAddr");
            }
        }

        public virtual int ChannelPort
        {
            get
            {
                return this._channelPort;
            }
            set
            {
                this._channelPort = value;
                OnPropertyChanged("ChannelPort");
            }
        }

        public virtual int ChannelType
        {
            get
            {
                return this._channelType;
            }
            set
            {
                this._channelType = value;
                OnPropertyChanged("ChannelType");
            }
        }

        public virtual int RegionId
        {
            get
            {
                return this._regionId;
            }
            set
            {
                this._regionId = value;
                OnPropertyChanged("RegionId");
            }
        }

        public virtual string ChannelNo
        {
            get
            {
                return this._channelNo;
            }
            set
            {
                this._channelNo = value;
                OnPropertyChanged("ChannelNo");
            }
        }

        public virtual string ChannelGuid
        {
            get
            {
                return this._channelGuid;
            }
            set
            {
                this._channelGuid = value;
                OnPropertyChanged("ChannelGuid");
            }
        }

        public virtual string ChannelArea
        {
            get
            {
                return this._channelArea;
            }
            set
            {
                this._channelArea = value;
                OnPropertyChanged("ChannelArea");
            }
        }


        public virtual string SdkVer
        {
            get
            {
                return this._sdkVer;
            }
            set
            {
                this._sdkVer = value;
                OnPropertyChanged("SdkVer");
            }
        }

        public virtual int MinFaceWidth
        {
            get
            {
                return this._minFaceWidth;
            }
            set
            {
                this._minFaceWidth = value;
                OnPropertyChanged("MinFaceWidth");
            }
        }

        public virtual int MinImgQuality
        {
            get
            {
                return this._minImgQuality;
            }
            set
            {
                this._minImgQuality = value;
                OnPropertyChanged("MinImgQuality");
            }
        }

        public virtual int MinCapDistance
        {
            get
            {
                return this._minCapDistance;
            }
            set
            {
                this._minCapDistance = value;
                OnPropertyChanged("MinCapDistance");
            }
        }

        public virtual int MaxSaveDistance
        {
            get
            {
                return this._maxSaveDistance;
            }
            set
            {
                this._maxSaveDistance = value;
                OnPropertyChanged("MaxSaveDistance");
            }
        }

        public virtual int MaxYaw
        {
            get
            {
                return this._maxYaw;
            }
            set
            {
                this._maxYaw = value;
                OnPropertyChanged("MaxYaw");
            }
        }

        public virtual int MaxYoll
        {
            get
            {
                return this._maxYoll;
            }
            set
            {
                this._maxYoll = value;
                OnPropertyChanged("MaxYoll");
            }
        }

        public virtual int MaxPitch
        {
            get
            {
                return this._maxPitch;
            }
            set
            {
                this._maxPitch = value;
                OnPropertyChanged("MaxPitch");
            }
        }

        public virtual double ChannelThreshold
        {
            get
            {
                return this._channelThreshold;
            }
            set
            {
                this._channelThreshold = value;
                OnPropertyChanged("ChannelThreshold");
            }
        }

        public virtual int CapStat
        {
            get
            {
                return this._capStat;
            }
            set
            {
                this._capStat = value;
                OnPropertyChanged("CapStat");
            }
        }

        public virtual int Important
        {
            get
            {
                return this._important;
            }
            set
            {
                this._important = value;
                OnPropertyChanged("Important");
            }
        }

        public static FaceCapture Convert(FaceCaptureData oridata)
        {
            FaceCapture target = new FaceCapture();

            #region

            target.FcapId = oridata.FcapId;
            target.FcapDcid = oridata.FcapDcid;
            target.FcapTime = TimeConvert.Convert(oridata.FcapTime);
            target.FcapQuality = oridata.FcapQuality;
            target.FcapType = oridata.FcapType;
            target.FcapFaceX = oridata.FcapFaceX;
            target.FcapFaceY = oridata.FcapFaceY;
            target.FcapFaceCx = oridata.FcapFaceCx;
            target.FcapFaceCy = oridata.FcapFaceCy;
            target.FcapSex = oridata.FcapSex;
            target.FcapAge = oridata.FcapAge;
            target.FcapObjImg = oridata.FcapObjImg;
            target.FcapSceneImg = oridata.FcapSceneImg;
            target.ChannelLongitude = oridata.ChannelLongitude;
            target.ChannelLatitude = oridata.ChannelLatitude;
            target.ChannelDirect = oridata.ChannelDirect;
            target.FcapObjFeat = oridata.FcapObjFeat;
            target.ChannelName = oridata.ChannelName;
            target.ChannelDescription = oridata.ChannelDescription;
            target.ChannelAddr = oridata.ChannelAddr;
            target.ChannelPort = oridata.ChannelPort;
            target.ChannelType = oridata.ChannelType;
            target.RegionId = oridata.RegionId;
            target.ChannelNo = oridata.ChannelNo;
            target.ChannelGuid = oridata.ChannelGuid;
            target.ChannelArea = oridata.ChannelArea;
            target.SdkVer = oridata.SdkVer;
            target.MinFaceWidth = oridata.MinFaceWidth;
            target.MinImgQuality = oridata.MinImgQuality;
            target.MinCapDistance = oridata.MinCapDistance;
            target.MaxSaveDistance = oridata.MaxSaveDistance;
            target.MaxYaw = oridata.MaxYaw;
            target.MaxYoll = oridata.MaxYoll;
            target.MaxPitch = oridata.MaxPitch;
            target.ChannelThreshold = oridata.ChannelThreshold;
            target.CapStat = oridata.CapStat;
            target.Important = oridata.Important;

            #endregion

            return target;
        }

        public static FaceCaptureData ConvertToData(FaceCapture oridata)
        {
            FaceCaptureData target = new FaceCaptureData();

            #region

            target.FcapId = oridata.FcapId;
            target.FcapDcid = oridata.FcapDcid;
            target.FcapTime = TimeConvert.Convert(oridata.FcapTime, "yyyyMMdd HH:mm:ss");
            target.FcapQuality = oridata.FcapQuality;
            target.FcapType = oridata.FcapType;
            target.FcapFaceX = oridata.FcapFaceX;
            target.FcapFaceY = oridata.FcapFaceY;
            target.FcapFaceCx = oridata.FcapFaceCx;
            target.FcapFaceCy = oridata.FcapFaceCy;
            target.FcapSex = oridata.FcapSex;
            target.FcapAge = oridata.FcapAge;
            target.FcapObjImg = oridata.FcapObjImg;
            target.FcapSceneImg = oridata.FcapSceneImg;
            target.ChannelLongitude = oridata.ChannelLongitude;
            target.ChannelLatitude = oridata.ChannelLatitude;
            target.ChannelDirect = oridata.ChannelDirect;
            target.FcapObjFeat = oridata.FcapObjFeat;
            target.ChannelName = oridata.ChannelName;
            target.ChannelDescription = oridata.ChannelDescription;
            target.ChannelAddr = oridata.ChannelAddr;
            target.ChannelPort = oridata.ChannelPort;
            target.ChannelType = oridata.ChannelType;
            target.RegionId = oridata.RegionId;
            target.ChannelNo = oridata.ChannelNo;
            target.ChannelGuid = oridata.ChannelGuid;
            target.ChannelArea = oridata.ChannelArea;
            target.SdkVer = oridata.SdkVer;
            target.MinFaceWidth = oridata.MinFaceWidth;
            target.MinImgQuality = oridata.MinImgQuality;
            target.MinCapDistance = oridata.MinCapDistance;
            target.MaxSaveDistance = oridata.MaxSaveDistance;
            target.MaxYaw = oridata.MaxYaw;
            target.MaxYoll = oridata.MaxYoll;
            target.MaxPitch = oridata.MaxPitch;
            target.ChannelThreshold = oridata.ChannelThreshold;
            target.CapStat = oridata.CapStat;
            target.Important = oridata.Important;

            #endregion

            return target;
        }

        public static void CopyValue(object origin, object target)
        {
            System.Reflection.PropertyInfo[] properties = (target.GetType()).GetProperties();
            System.Reflection.PropertyInfo[] fields = (origin.GetType()).GetProperties();
            for (int i = 0; i < fields.Length; i++)
            {
                for (int j = 0; j < properties.Length; j++)
                {

                    if (fields[i].Name.ToUpper() == properties[j].Name.ToUpper() && properties[j].CanWrite)
                    {
                        properties[j].SetValue(target, fields[i].GetValue(origin, null), null);
                    }
                }
            }
        }

        #region  PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
