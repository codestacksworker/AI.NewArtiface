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
    public class QueryCondition : INotifyPropertyChanged,IPageCondition
    {
        #region PUBLIC

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
        #endregion

        #region FaceTempDbRelation

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
                RaisePropertyChanged("_templateDbName");
            }
        }

        private int _isUsed;
        public virtual int IsUsed
        {
            get
            {
                return this._isUsed;
            }
            set
            {
                this._isUsed = value;
                RaisePropertyChanged("IsUsed");
            }
        }

        private string _templateDbDescription;
        public virtual string TemplateDbDescription
        {
            get
            {
                return this._templateDbDescription;
            }
            set
            {
                this._templateDbDescription = value;
                RaisePropertyChanged("TemplateDbDescription");
            }
        }
        #endregion

        #region FaceTempRelation

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
                RaisePropertyChanged("StartTime");
            }
        }

        private string _objId;
        public virtual string ObjId
        {
            get
            {
                return this._objId;
            }
            set
            {
                this._objId = value;
                RaisePropertyChanged("ObjId");
            }
        }
        #endregion

        #region FaceObjRelation

        private string _name;
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
                RaisePropertyChanged("Name");
            }
        }

        private int _type;
        public virtual int Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
                RaisePropertyChanged("Type");
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

        private int _sex;
        public virtual int Sex
        {
            get
            {
                return this._sex;
            }
            set
            {
                this._sex = value;
                RaisePropertyChanged("Sex");
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

        private string _startBirthDate;
        public virtual string StartBirthDate
        {
            get
            {
                return this._startBirthDate;
            }
            set
            {
                this._startBirthDate = value;
                RaisePropertyChanged("StartBirthDate");
            }
        }

        private string _endBirthDate;
        public virtual string EndBirthDate
        {
            get
            {
                return this._endBirthDate;
            }
            set
            {
                this._endBirthDate = value;
                RaisePropertyChanged("EndBirthDate");
            }
        }

        private string _addr;
        public virtual string Addr
        {
            get
            {
                return this._addr;
            }
            set
            {
                this._addr = value;
                RaisePropertyChanged("Addr");
            }
        }

        private string _ethnic;
        public virtual string Ethnic
        {
            get
            {
                return this._ethnic;
            }
            set
            {
                this._ethnic = value;
                RaisePropertyChanged("Ethnic");
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

        private string _remarks;
        public virtual string Remarks
        {
            get
            {
                return this._remarks;
            }
            set
            {
                this._remarks = value;
                RaisePropertyChanged("Remarks");
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

        private int _count = 50;
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

        #endregion

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

        public static string FobjJsonConvert(QueryCondition qc)
        {
            FaceObjRelation jsonData = ParameterConvert.FaceObjRelationFromCondition(qc);
            return JsonHelper.SerializeObject(jsonData);
        }
    }
}
