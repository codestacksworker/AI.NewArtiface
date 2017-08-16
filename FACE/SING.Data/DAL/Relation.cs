using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;

namespace SING.Data.DAL
{
    public class FaceTempDbRelation : ParamBase
    {
        private string _templateDbName;
        [JsonProperty(PropertyName = "template_db_name", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string TemplateDbName
        {
            get
            {
                return this._templateDbName;
            }
            set
            {
                this._templateDbName = value;
            }
        }

        private int _isUsed;
        [JsonProperty(PropertyName = "is_used", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int IsUsed
        {
            get
            {
                return this._isUsed;
            }
            set
            {
                this._isUsed = value;
            }
        }

        private string _templateDbDescription;
        [JsonProperty(PropertyName = "template_db_description", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string TemplateDbDescription
        {
            get
            {
                return this._templateDbDescription;
            }
            set
            {
                this._templateDbDescription = value;
            }
        }
    }

    public class FaceTempRelation : ParamBase
    {
        private int _ftdbid;

        [JsonProperty(PropertyName = "ftdb_id")]
        public virtual int FTDBID
        {
            get { return this._ftdbid; }
            set { this._ftdbid = value; }
        }

        private string _uuid;
        [JsonProperty(PropertyName = "uuid", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Uuid
        {
            get { return this._uuid; }
            set { this._uuid = value; }
        }

        private string _objId;

        [JsonProperty(PropertyName = "obj_id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ObjId
        {
            get { return this._objId; }
            set { this._objId = value; }
        }

        #region

        private FaceTemplate _ft;

        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public virtual FaceTemplate FT
        {
            get { return this._ft; }
            set { this._ft = value; }
        }

        #endregion
    }

    public class FaceObjRelation : ParamBase
    {
        private int _ftdbid;

        [JsonProperty(PropertyName = "ftdb_id")]
        public virtual int FTDBID
        {
            get { return this._ftdbid; }
            set { this._ftdbid = value; }
        }


        private string _uuid;
        [JsonProperty(PropertyName = "uuid", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Uuid
        {
            get { return this._uuid; }
            set { this._uuid = value; }
        }

        private string _mainFtID;

        [JsonProperty(PropertyName = "main_ftID", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string MainFtID
        {
            get { return this._mainFtID; }
            set { this._mainFtID = value; }
        }

        private string _name;

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        private int _type;

        [JsonProperty(PropertyName = "type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        private int _sst;

        [JsonProperty(PropertyName = "sst", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int Sst
        {
            get { return this._sst; }
            set { this._sst = value; }
        }

        private int _sex;

        [JsonProperty(PropertyName = "sex", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        private long _timeStamp;

        [JsonProperty(PropertyName = "timestamp", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long TimeStamp
        {
            get { return this._timeStamp; }
            set { this._timeStamp = value; }
        }

        private int _idType;

        [JsonProperty(PropertyName = "id_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int IdType
        {
            get { return this._idType; }
            set { this._idType = value; }
        }

        private string _idNumb;

        [JsonProperty(PropertyName = "id_numb", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string IdNumb
        {
            get { return this._idNumb; }
            set { this._idNumb = value; }
        }

        private long _birthDate;

        [JsonProperty(PropertyName = "birth_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long BirthDate
        {
            get { return this._birthDate; }
            set { this._birthDate = value; }
        }

        private long _startBirthDate;

        [JsonProperty(PropertyName = "start_birth_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long StartBirthDate
        {
            get { return this._startBirthDate; }
            set { this._startBirthDate = value; }
        }

        private long _endBirthDate;

        [JsonProperty(PropertyName = "end_birth_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long EndBirthDate
        {
            get { return this._endBirthDate; }
            set { this._endBirthDate = value; }
        }

        private string _addr;

        [JsonProperty(PropertyName = "addr", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Addr
        {
            get { return this._addr; }
            set { this._addr = value; }
        }

        private string _ethnic;

        [JsonProperty(PropertyName = "ethnic", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Ethnic
        {
            get { return this._ethnic; }
            set { this._ethnic = value; }
        }

        private string _remarks;

        [JsonProperty(PropertyName = "remarks", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Remarks
        {
            get { return this._remarks; }
            set { this._remarks = value; }
        }
    }
}
