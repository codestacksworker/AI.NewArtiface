using SING.Data.Help;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SING.Data.DAL.Data
{
    [Serializable]
    public class FcmpRecordViewData : INotifyPropertyChanged
    {
        private bool _isTopFiled = false;
        private string _uuid;
        private string _fcmpCapId;
        private string _fcmpCapChannel;
        private double _channelLongitude;
        private double _channelLatitude;
        private int _channelDirect;
        private string _fcapTime;
        private int _ftdbId;
        private string _templateDbName;
        private string _channelName;
        private string _channelArea;
        private byte[] _fcapObjImg;
        private ImageSource _fcapObjImgSource;
        private byte[] _fcapSceneImg;
        private List<FaceObjTempViewData> _FaceObjs;
        private ImageSource _fcapSceneImgSource;

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

        public virtual string FcmpCapId
        {
            get
            {
                return this._fcmpCapId;
            }
            set
            {
                this._fcmpCapId = value;
                OnPropertyChanged("FcmpCapId");
            }
        }

        public virtual string FcmpCapChannel
        {
            get
            {
                return this._fcmpCapChannel;
            }
            set
            {
                this._fcmpCapChannel = value;
                OnPropertyChanged("FcmpCapChannel");
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

        public virtual int FTDBID
        {
            get
            {
                return this._ftdbId;
            }
            set
            {
                this._ftdbId = value;
                OnPropertyChanged("FTDBID");
            }
        }

        public virtual string TemplateDbName
        {
            get
            {
                return this._templateDbName;
            }
            set
            {
                this._templateDbName = value;
                OnPropertyChanged("TemplateDbName");
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

        //public virtual ImageSource FcapObjImgSource
        //{
        //    get
        //    {
        //        return this._fcapObjImgSource;
        //    }
        //    set
        //    {
        //        this._fcapObjImgSource = value;
        //        OnPropertyChanged("FcapObjImgSource");
        //    }
        //}

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

        public virtual ImageSource FcapSceneImgSource
        {
            get
            {
                return this._fcapSceneImgSource;
            }
            set
            {
                this._fcapSceneImgSource = value;
                OnPropertyChanged("FcapSceneImgSource");
            }
        }

        public List<FaceObjTempViewData> FaceObjs
        {
            get
            {
                return _FaceObjs;
            }

            set
            {
                _FaceObjs = value;
                OnPropertyChanged("FaceObjs");
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
