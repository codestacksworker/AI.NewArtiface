using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL
{

    public class CapParameter 
    {
        private string _fcapid;

        [JsonProperty(PropertyName = "fcap_id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Fcapid
        {
            get
            {
                return this._fcapid;
            }
            set
            {
                this._fcapid = value;
            }
        }

        private long _fcaptime;

        [JsonProperty(PropertyName = "fcap_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long Fcaptime
        {
            get
            {
                return this._fcaptime;
            }
            set
            {
                this._fcaptime = value;
            }
        }
    }
    public class CapRecordParameter : ParamBase
    {
        #region

        private string _fcapId;
        [JsonProperty(PropertyName = "fcap_id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string FcapId
        {
            get
            {
                return this._fcapId;
            }
            set
            {
                this._fcapId = value;
            }
        }

        private string _channelId;
        [JsonProperty(PropertyName = "fcap_dcid", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ChannelId
        {
            get
            {
                return this._channelId;
            }
            set
            {
                this._channelId = value;
            }
        }

        private int _fcapType;
        [JsonProperty(PropertyName = "fcap_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FcapType
        {
            get
            {
                return this._fcapType;
            }
            set
            {
                this._fcapType = value;
            }
        }

        private int _regionId;
        [JsonProperty(PropertyName = "region_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int RegionId
        {
            get
            {
                return this._regionId;
            }
            set
            {
                this._regionId = value;
            }
        }

        #endregion
    }

    public class CmpRecordParameter : ParamBase
    {
        #region

        private int _tdbid;
        [JsonProperty(PropertyName = "ftdb_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int TDBID
        {
            get
            {
                return this._tdbid;
            }
            set
            {
                this._tdbid = value;
            }
        }

        private string _uuid;
        [JsonProperty(PropertyName = "uid", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Uuid
        {
            get
            {
                return this._uuid;
            }
            set
            {
                this._uuid = value;
            }
        }

        private string _channelId;
        [JsonProperty(PropertyName = "fcmp_cap_channel", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ChannelId
        {
            get
            {
                return this._channelId;
            }
            set
            {
                this._channelId = value;
            }
        }

        private string _fcmpFobjName;
        [JsonProperty(PropertyName = "fcmp_fobj_name", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string FcmpFobjName
        {
            get
            {
                return this._fcmpFobjName;
            }
            set
            {
                this._fcmpFobjName = value;
            }
        }

        private int _fcmpFobjType;
        [JsonProperty(PropertyName = "fcmp_fobj_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FcmpFobjType
        {
            get
            {
                return this._fcmpFobjType;
            }
            set
            {
                this._fcmpFobjType = value;
            }
        }

        private int _fcmpType;
        [JsonProperty(PropertyName = "fcmp_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FcmpType
        {
            get
            {
                return this._fcmpType;
            }
            set
            {
                this._fcmpType = value;
            }
        }

        private int _fcmpFobjSex;
        [JsonProperty(PropertyName = "nSex", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FcmpFobjSex
        {
            get
            {
                return this._fcmpFobjSex;
            }
            set
            {
                this._fcmpFobjSex = value;
            }
        }

        private int _sst;
        [JsonProperty(PropertyName = "sst", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int Sst
        {
            get
            {
                return this._sst;
            }
            set
            {
                this._sst = value;
            }
        }

        [JsonIgnore]
        private int _top;
        [JsonProperty(PropertyName = "top", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int Top
        {
            get
            {
                return this._top;
            }
            set
            {
                this._top = value;
            }
        }

        private double _fcmpSocre;
        [JsonProperty(PropertyName = "fcmp_min_socre", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual double FcmpSocre
        {
            get
            {
                return this._fcmpSocre;
            }
            set
            {
                this._fcmpSocre = value;
            }
        }

        private long _startTime;
        [JsonProperty(PropertyName = "fcap_start_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long StartTime
        {
            get
            {
                return this._startTime;
            }
            set
            {
                this._startTime = value;
            }
        }


        private long _endTime;
        [JsonProperty(PropertyName = "fcap_end_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long EndTime
        {
            get
            {
                return this._endTime;
            }
            set
            {
                this._endTime = value;
            }
        }

        [JsonIgnore]
        private int _regionId;
        [JsonProperty(PropertyName = "region_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int RegionId
        {
            get
            {
                return this._regionId;
            }
            set
            {
                this._regionId = value;
            }
        }

        private string _idNumb;
        [JsonProperty(PropertyName = "fobj_id_numb", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string IdNumb
        {
            get
            {
                return this._idNumb;
            }
            set
            {
                this._idNumb = value;
            }
        }

        private int _idType;
        [JsonProperty(PropertyName = "fobj_id_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int IdType
        {
            get
            {
                return this._idType;
            }
            set
            {
                this._idType = value;
            }
        }

        #endregion
    }

    public class ChannelParameter : ParamBase
    {
        #region

        private int _regionId;

        [JsonProperty(PropertyName = "regionid", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int RegionId
        {
            get { return this._regionId; }
            set { this._regionId = value; }
        }

        #endregion
    }

    public class RegionsParameter
    {
        #region 
        private int _id;
        [JsonProperty(PropertyName = "id")]
        public virtual int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        private bool _delChannel;
        [JsonProperty(PropertyName = "delChannel")]
        public virtual bool delChannel
        {
            get
            {
                return this._delChannel;
            }
            set
            {
                this._delChannel = value;
            }
        }
        #endregion
    }

    public class FaceTagsParameter
    {
        #region 
        private int _tagId;
        [JsonProperty(PropertyName = "tag_id")]
        public virtual int TagId
        {
            get
            {
                return this._tagId;
            }
            set
            {
                this._tagId = value;
            }
        }

        private string _objId;
        [JsonProperty(PropertyName = "obj_id")]
        public virtual string ObjId
        {
            get
            {
                return this._objId;
            }
            set
            {
                this._objId = value;
            }
        }
        #endregion
    }

    public class AlertParameter : ParamBase
    {
        #region
        private string _uuid;
        private string _channelId;
        private int _ftdbId;
        private long _fcapStartTime;
        private long _fcapEndTime;
        private int _ackStat;
        private int _pubStat;
        private string _keyWords;


        [JsonProperty(PropertyName = "uuid", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Uuid
        {
            get
            {
                return this._uuid;
            }
            set
            {
                this._uuid = value;
            }
        }

        [JsonProperty(PropertyName = "fcmp_cap_channel", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ChannelId
        {
            get
            {
                return this._channelId;
            }
            set
            {
                this._channelId = value;
            }
        }

        [JsonProperty(PropertyName = "ftdb_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FtdbId
        {
            get
            {
                return this._ftdbId;
            }
            set
            {
                this._ftdbId = value;
            }
        }

        [JsonProperty(PropertyName = "fcap_start_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long FcapStartTime
        {
            get
            {
                return this._fcapStartTime;
            }
            set
            {
                this._fcapStartTime = value;
            }
        }

        [JsonProperty(PropertyName = "fcap_end_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long FcapEndTime
        {
            get
            {
                return this._fcapEndTime;
            }
            set
            {
                this._fcapEndTime = value;
            }
        }

        [JsonProperty(PropertyName = "ack_stat", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int AckStat
        {
            get
            {
                return this._ackStat;
            }
            set
            {
                this._ackStat = value;
            }
        }

        [JsonProperty(PropertyName = "pub_stat", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int PubStat
        {
            get
            {
                return this._pubStat;
            }
            set
            {
                this._pubStat = value;
            }
        }

        [JsonProperty(PropertyName = "key_words", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string KeyWords
        {
            get
            {
                return this._keyWords;
            }
            set
            {
                this._keyWords = value;
            }
        }

        #endregion
    }

    public class AlertOpParameter
    {
        #region

        private string _uuid;

        [JsonProperty(PropertyName = "uuid")]
        public virtual string Uuid
        {
            get { return this._uuid; }
            set { this._uuid = value; }
        }

        private string _oper;

        [JsonProperty(PropertyName = "oper", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Oper
        {
            get { return this._oper; }
            set { this._oper = value; }
        }

        private int _stat;

        [JsonProperty(PropertyName = "stat", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int Stat
        {
            get { return this._stat; }
            set { this._stat = value; }
        }

        private long _timeStamp;

        [JsonProperty(PropertyName = "timestamp", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long TimeStamp
        {
            get { return this._timeStamp; }
            set { this._timeStamp = value; }
        }

        private bool _force;

        [JsonProperty(PropertyName = "force", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual bool Force
        {
            get { return this._force; }
            set { this._force = value; }
        }

        #endregion
    }
}
