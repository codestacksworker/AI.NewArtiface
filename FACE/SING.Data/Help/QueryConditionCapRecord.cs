using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using SING.Data.DAL;
using SING.Data.DAL.ScheduleConvert;
using SING.Data.Help.Json;
using SING.Data.Controls.PageControl;

namespace SING.Data.Help
{
    public class QueryConditionCapRecord : INotifyPropertyChanged,IPageCondition
    {
        private string _fcapId;
        public virtual string FcapId
        {
            get
            {
                return this._fcapId;
            }
            set
            {
                this._fcapId = value;
                RaisePropertyChanged("FcapId");
            }
        }

        private string _channelId;
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

        private string _startTime;
        public virtual string StartTime
        {
            get
            {
                return this._startTime;
            }
            set
            {
                this._startTime = value;
                RaisePropertyChanged("StartTime");
            }
        }

        private string _endTime;
        public virtual string EndTime
        {
            get
            {
                return this._endTime;
            }
            set
            {
                this._endTime = value;
                RaisePropertyChanged("EndTime");
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
                RaisePropertyChanged("FcapType");
            }
        }

        private int _startNum;
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

        private int _count = 48;
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

        private int _PageNow = 1;
        public int PageNow
        {
            get
            {
                return _PageNow;
            }
            set
            {
                _PageNow = value;
                this.RaisePropertyChanged("PageNow");
            }
        }

        private int _regionId;
        public virtual int RegionId
        {
            get
            {
                return this._regionId;
            }
            set
            {
                this._regionId = value;
                RaisePropertyChanged("RegionId");
            }
        }

        private int _isOrder;
        public virtual int IsOrder
        {
            get
            {
                return this._isOrder;
            }
            set
            {
                this._isOrder = value;
                RaisePropertyChanged("IsOrder");
            }
        }

        private string _orderCol;
        public virtual string OrderCol
        {
            get
            {
                return this._orderCol;
            }
            set
            {
                this._orderCol = value;
                RaisePropertyChanged("OrderCol");
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
        

        #region
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public static string JsonConvert(QueryConditionCapRecord qc)
        {
            CapRecordParameter jsonData = ParameterConvert.CapRecordParaFromCondition(qc);

            return JsonHelper.SerializeObject(jsonData);
        }
    }
}
