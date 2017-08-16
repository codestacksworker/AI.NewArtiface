using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.DAL.Data
{
    [Serializable]
    public class AlDataBase : INotifyPropertyChanged
    {
        private string _uuid;
        private string _fcapId;
        private string _channelId;
        private string _fcapTime;
        private string _alertTime;
        private string _fobjId;
        private double _fcmpSocre;
        private long _rulerId;
        private int _ackStat;
        private string _ackTime;
        private string _acker;
        private int _pubStat;
        private string _pubTime;
        private string _puber;

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

        public virtual string ChannelId
        {
            get
            {
                return this._channelId;
            }
            set
            {
                this._channelId = value;
                OnPropertyChanged("ChannelId");
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

        public virtual string AlertTime
        {
            get
            {
                return this._alertTime;
            }
            set
            {
                this._alertTime = value;
                OnPropertyChanged("AlertTime");
            }
        }

        public virtual string FobjId
        {
            get
            {
                return this._fobjId;
            }
            set
            {
                this._fobjId = value;
                OnPropertyChanged("FobjId");
            }
        }

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

        public virtual long RulerId
        {
            get
            {
                return this._rulerId;
            }
            set
            {
                this._rulerId = value;
                OnPropertyChanged("RulerId");
            }
        }

        public virtual int AckStat
        {
            get
            {
                return this._ackStat;
            }
            set
            {
                this._ackStat = value;
                OnPropertyChanged("AckStat");
            }
        }

        public virtual string AckTime
        {
            get
            {
                return this._ackTime;
            }
            set
            {
                this._ackTime = value;
                OnPropertyChanged("AckTime");
            }
        }

        public virtual string Acker
        {
            get
            {
                return this._acker;
            }
            set
            {
                this._acker = value;
                OnPropertyChanged("Acker");
            }
        }

        public virtual int PubStat
        {
            get
            {
                return this._pubStat;
            }
            set
            {
                this._pubStat = value;
                OnPropertyChanged("PubStat");
            }
        }

        public virtual string PubTime
        {
            get
            {
                return this._pubTime;
            }
            set
            {
                this._pubTime = value;
                OnPropertyChanged("PubTime");
            }
        }

        public virtual string Puber
        {
            get
            {
                return this._puber;
            }
            set
            {
                this._puber = value;
                OnPropertyChanged("Puber");
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
