using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.Controls.TreeControl.Models;
using SING.Data.Help;

namespace SING.Data.DAL.Data
{
    [Serializable]
    public class ChannelData : INotifyPropertyChanged
    {
        private string _uuid;
        private string _channelName;
        private string _channelDescription;
        private int _channelType;
        private string _channelAddr;
        private int _channelPort;
        private string _channelUid;
        private string _channelPsw;
        private string _channelNo;
        private string _channelGuid;
        private string _minFaceWidth = "96";
        private string _minImgQuality = "0";
        private string _minCapDistance = "20";
        private string _maxSaveDistance = "0";
        private string _maxYaw = "90";
        private string _maxYoll = "90";
        private string _maxPitch = "90";
        private double _channelLongitude;
        private double _channelLatitude;
        private string _channelArea;
        private int _channelDirect;
        private double _channelThreshold;
        private int _capStat;
        private int _isDel;
        private string _lastTimestamp;
        private int _regionId;
        private int _important;
        private int _reserved;

        public virtual string Uuid
        {
            get
            {
                return this._uuid;
            }
            set
            {
                this._uuid = value;
                OnPropertyChanged("Uuid");
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

        public virtual string ChannelUid
        {
            get
            {
                return this._channelUid;
            }
            set
            {
                this._channelUid = value;
                OnPropertyChanged("ChannelUid");
            }
        }

        public virtual string ChannelPsw
        {
            get
            {
                return this._channelPsw;
            }
            set
            {
                this._channelPsw = value;
                OnPropertyChanged("ChannelPsw");
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

        public virtual string MinFaceWidth
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

        public virtual string MinImgQuality
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

        public virtual string MinCapDistance
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

        public virtual string MaxSaveDistance
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

        public virtual string MaxYaw
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

        public virtual string MaxYoll
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

        public virtual string MaxPitch
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

        public virtual int IsDel
        {
            get
            {
                return this._isDel;
            }
            set
            {
                this._isDel = value;
                OnPropertyChanged("IsDel");
            }
        }

        public virtual string LastTimestamp
        {
            get
            {
                return this._lastTimestamp;
            }
            set
            {
                this._lastTimestamp = value;
                OnPropertyChanged("LastTimestamp");
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

        public virtual int Reserved
        {
            get
            {
                return this._reserved;
            }
            set
            {
                this._reserved = value;
                OnPropertyChanged("Reserved");
            }
        }

        private bool _isConnected = false;
        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                _isConnected = value;
                OnPropertyChanged("IsConnected");
            }
        }

        private bool _isSubscribe;
        public bool IsSubscribe
        {
            get { return _isSubscribe; }
            set
            {
                _isSubscribe = value;
                OnPropertyChanged("IsSubscribe");
            }
        }

        private bool _isVideo;
        public bool IsVideo
        {
            get { return _isVideo; }
            set
            {
                _isVideo = value;
                OnPropertyChanged("IsVideo");
            }
        }

        private bool _IsOpend;
        public bool IsOpened
        {
            get
            {
                return _IsOpend;
            }
            set
            {
                _IsOpend = value;
                OnPropertyChanged("IsOpened");
            }
        }

        public static Channel Convert(ChannelData oridata)
        {
            Channel target = new Channel();

            #region

            target.Uuid = oridata.Uuid;
            target.ChannelName = oridata.ChannelName;
            target.ChannelDescription = oridata.ChannelDescription;
            target.ChannelType = oridata.ChannelType;
            target.ChannelAddr = oridata.ChannelAddr;
            target.ChannelPort = oridata.ChannelPort;
            target.ChannelUid = oridata.ChannelUid;
            target.ChannelPsw = oridata.ChannelPsw;
            target.ChannelNo = oridata.ChannelNo;
            target.ChannelGuid = oridata.ChannelGuid;
            target.MinFaceWidth = int.Parse(oridata.MinFaceWidth);
            target.MinImgQuality = int.Parse(oridata.MinImgQuality);
            target.MinCapDistance = int.Parse(oridata.MinCapDistance);
            target.MaxSaveDistance = int.Parse(oridata.MaxSaveDistance);
            target.MaxYaw = int.Parse(oridata.MaxYaw);
            target.MaxYoll = int.Parse(oridata.MaxYoll);
            target.MaxPitch = int.Parse(oridata.MaxPitch);
            target.ChannelLongitude = oridata.ChannelLongitude;
            target.ChannelLatitude = oridata.ChannelLatitude;
            target.ChannelArea = oridata.ChannelArea;
            target.ChannelDirect = oridata.ChannelDirect;
            target.ChannelThreshold = oridata.ChannelThreshold;
            target.CapStat = oridata.CapStat;
            target.IsDel = oridata.IsDel;
            target.LastTimestamp = TimeConvert.Convert(oridata.LastTimestamp);
            target.RegionId = oridata.RegionId;
            target.Important = oridata.Important;
            target.Reserved = oridata.Reserved;

            #endregion

            return target;
        }

        public static ChannelData ConvertToData(Channel oridata)
        {
            ChannelData target = new ChannelData();

            #region

            target.Uuid = oridata.Uuid;
            target.ChannelName = oridata.ChannelName;
            target.ChannelDescription = oridata.ChannelDescription;
            target.ChannelType = oridata.ChannelType;
            target.ChannelAddr = oridata.ChannelAddr;
            target.ChannelPort = oridata.ChannelPort;
            target.ChannelUid = oridata.ChannelUid;
            target.ChannelPsw = oridata.ChannelPsw;
            target.ChannelNo = oridata.ChannelNo;
            target.ChannelGuid = oridata.ChannelGuid;
            target.MinFaceWidth = oridata.MinFaceWidth.ToString();
            target.MinImgQuality = oridata.MinImgQuality.ToString();
            target.MinCapDistance = oridata.MinCapDistance.ToString();
            target.MaxSaveDistance = oridata.MaxSaveDistance.ToString();
            target.MaxYaw = oridata.MaxYaw.ToString();
            target.MaxYoll = oridata.MaxYoll.ToString();
            target.MaxPitch = oridata.MaxPitch.ToString();
            target.ChannelLongitude = oridata.ChannelLongitude;
            target.ChannelLatitude = oridata.ChannelLatitude;
            target.ChannelArea = oridata.ChannelArea;
            target.ChannelDirect = oridata.ChannelDirect;
            target.ChannelThreshold = oridata.ChannelThreshold;
            target.CapStat = oridata.CapStat;
            target.IsDel = oridata.IsDel;
            target.LastTimestamp = TimeConvert.Convert(oridata.LastTimestamp, "yyyyMMdd HH:mm:ss");
            target.RegionId = oridata.RegionId;
            target.Important = oridata.Important;
            target.Reserved = oridata.Reserved;

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
