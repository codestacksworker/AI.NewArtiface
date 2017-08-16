using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SING.Data.DAL.Data
{
    [Serializable]
    public class FaceCmpViewData : INotifyPropertyChanged
    {
        #region Properties

        private int _ftdbId;
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

        private string _templateDbName;
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

        private string _uuid;
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

        private string _fcmpCapId;
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

        private string _fcapDcid;
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

        private string _channelName;
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

        private string _fcapTime;
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

        private int _fcapType;
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

        private int _fcapSex;
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

        private int _fcapAge;
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

        private byte[] _fcapObjImg;
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

        private byte[] _fcapSceneImg;
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

        private string _fcmpFobjId;
        public virtual string FcmpFobjId
        {
            get
            {
                return this._fcmpFobjId;
            }
            set
            {
                this._fcmpFobjId = value;
                OnPropertyChanged("FcmpFobjId");
            }
        }

        private string _fcmpFobjName;
        public virtual string FcmpFobjName
        {
            get
            {
                return this._fcmpFobjName;
            }
            set
            {
                this._fcmpFobjName = value;
                OnPropertyChanged("FcmpFobjName");
            }
        }

        private int _fcmpFobjType;
        public virtual int FcmpFobjType
        {
            get
            {
                return this._fcmpFobjType;
            }
            set
            {
                this._fcmpFobjType = value;
                OnPropertyChanged("FcmpFobjType");
            }
        }

        private byte[] _fcmpFobjImg;
        public virtual byte[] FcmpFobjImg
        {
            get
            {
                return this._fcmpFobjImg;
            }
            set
            {
                this._fcmpFobjImg = value;
                OnPropertyChanged("FcmpFobjImg");
            }
        }

        private string _fcmpTime;
        public virtual string FcmpTime
        {
            get
            {
                return this._fcmpTime;
            }
            set
            {
                this._fcmpTime = value;
                OnPropertyChanged("FcmpTime");
            }
        }

        private int _fcmpOrder;
        public virtual int FcmpOrder
        {
            get
            {
                return this._fcmpOrder;
            }
            set
            {
                this._fcmpOrder = value;
                OnPropertyChanged("FcmpOrder");
            }
        }

        private double _fcmpSocre;
        public virtual double FcmpSocre
        {
            get
            {
                return this._fcmpSocre;
            }
            set
            {
                this._fcmpSocre = value;
                OnPropertyChanged("FcmpSocre");
            }
        }

        private double _channelLongitude;
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

        private double _channelLatitude;
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

        private int _channelDirect;
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

        #region  Image
        private ImageSource _fcapObjImgSource;
        public virtual ImageSource FcapObjImgSource
        {
            get
            {
                return this._fcapObjImgSource;
            }
            set
            {
                this._fcapObjImgSource = value;
               // this._fcapObjImgSource.Freeze(); // 冻结后就可以跨线程用作绑定源
                OnPropertyChanged("FcapObjImgSource");
            }
        }
        private ImageSource _fcmpFobjImgSource;
        public virtual ImageSource FcmpFobjImgSource
        {
            get
            {
                return this._fcmpFobjImgSource;
            }
            set
            {
                this._fcmpFobjImgSource = value;
               // this._fcmpFobjImgSource.Freeze(); // 冻结后就可以跨线程用作绑定源
                OnPropertyChanged("FcmpFobjImgSource");
            }
        }

        private ImageSource _fcapSceneImgSource;
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
        #endregion
        #endregion

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
