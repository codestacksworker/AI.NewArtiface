using Newtonsoft.Json;
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
    public class QueryConditionCmpRecord : INotifyPropertyChanged,IPageCondition
    {
        private int _tdbid;
        public virtual int TDBID
        {
            get
            {
                return this._tdbid;
            }
            set
            {
                this._tdbid = value;
                RaisePropertyChanged("TDBID");
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
                RaisePropertyChanged("Uuid");
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
                RaisePropertyChanged("FcmpFobjName");
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
                RaisePropertyChanged("FcmpFobjType");
            }
        }

        private int _fcmpType;
        public virtual int FcmpType
        {
            get
            {
                return this._fcmpType;
            }
            set
            {
                this._fcmpType = value;
                RaisePropertyChanged("FcmpType");
            }
        }

        private int _fcmpFobjSex;
        public virtual int FcmpFobjSex
        {
            get
            {
                return this._fcmpFobjSex;
            }
            set
            {
                this._fcmpFobjSex = value;
                RaisePropertyChanged("FcmpFobjSex");
            }
        }

        private int _sst;
        public virtual int Sst
        {
            get
            {
                return this._sst;
            }
            set
            {
                this._sst = value;
                RaisePropertyChanged("Sst");
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

        private int _top = 3;
        public virtual int Top
        {
            get
            {
                return this._top;
            }
            set
            {
                this._top = value;
                RaisePropertyChanged("Top");
            }
        }

        private bool _isRepeat;
        public virtual bool IsRepeat
        {
            get
            {
                return this._isRepeat;
            }
            set
            {
                this._isRepeat = value;
                RaisePropertyChanged("IsRepeat");
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
                RaisePropertyChanged("FcmpSocre");
            }
        }

        private string _tag;
        public virtual string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                this._tag = value;
                RaisePropertyChanged("Tag");
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

        private int _count = 100;
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

        private string _idNumb;
        public virtual string IdNumb
        {
            get
            {
                return this._idNumb;
            }
            set
            {
                this._idNumb = value;
                RaisePropertyChanged("IdNumb");
            }
        }

        private int _idType;
        public virtual int IdType
        {
            get
            {
                return this._idType;
            }
            set
            {
                this._idType = value;
                RaisePropertyChanged("IdType");
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

        public static string JsonConvert(QueryConditionCmpRecord qc)
        {
            CmpRecordParameter jsonData = ParameterConvert.CmpRecordParaFromCondition(qc);

            return JsonHelper.SerializeObject(jsonData);
        }
    }
}
