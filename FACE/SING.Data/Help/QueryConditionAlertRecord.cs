using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.DAL;
using SING.Data.DAL.ScheduleConvert;
using SING.Data.Help.Json;
using SING.Data.Controls.PageControl;

namespace SING.Data.Help
{
    public class QueryConditionAlertRecord : INotifyPropertyChanged,IPageCondition
    {
        private string _uuid;
        private string _channelId;
        private int _ftdbId;
        private string _fcapStartTime;
        private string _fcapEndTime;
        private int _ackStat;
        private int _pubStat;
        private string _keyWords;
        private int _startNum;
        private int _count = 50;
        private int _PageNow = 1;

        public virtual string Uuid
        {
            get
            {
                return this._uuid;
            }
            set
            {
                this._uuid = value;
                RaisePropertyChanged("Uuid");
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
                RaisePropertyChanged("ChannelId");
            }
        }

        public virtual int FtdbId
        {
            get
            {
                return this._ftdbId;
            }
            set
            {
                this._ftdbId = value;
                RaisePropertyChanged("FtdbId");
            }
        }

        public virtual string FcapStartTime
        {
            get
            {
                return this._fcapStartTime;
            }
            set
            {
                this._fcapStartTime = value;
                RaisePropertyChanged("FcapStartTime");
            }
        }

        public virtual string FcapEndTime
        {
            get
            {
                return this._fcapEndTime;
            }
            set
            {
                this._fcapEndTime = value;
                RaisePropertyChanged("FcapEndTime");
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
                RaisePropertyChanged("AckStat");
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
                RaisePropertyChanged("PubStat");
            }
        }

        public virtual string KeyWords
        {
            get
            {
                return this._keyWords;
            }
            set
            {
                this._keyWords = value;
                RaisePropertyChanged("KeyWords");
            }
        }

        public virtual int StartNum
        {
            get
            {
                return this._startNum;
            }
            set
            {
                this._startNum = value;
                RaisePropertyChanged("StartNum");
            }
        }

     
        public virtual int Count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
                RaisePropertyChanged("Count");
            }
        }

       
        public int PageNow
        {
            get
            {
                return _PageNow;
            }
            set
            {
                _PageNow = value;
                RaisePropertyChanged("PageNow");
            }
        }

        private bool _PreviousPageIsEnable;
        public bool PreviousPageIsEnable
        {
            get
            {
                return this._PreviousPageIsEnable;
            }
            set
            {
                this._PreviousPageIsEnable = value;
                RaisePropertyChanged("PreviousPageIsEnable");
            }
        }

        private bool _NextPageIsEnable;
        public bool NextPageIsEnable
        {
            get
            {
                return this._NextPageIsEnable;
            }
            set
            {
                this._NextPageIsEnable = value;
                RaisePropertyChanged("NextPageIsEnable");
            }
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


        public static string JsonConvert(QueryConditionAlertRecord qc)
        {
            AlertParameter jsonData = ParameterConvert.AlertParameterFromQc(qc);
            return JsonHelper.SerializeObject(jsonData);
        }
    }
}
