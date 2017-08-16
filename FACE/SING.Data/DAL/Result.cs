using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.Help;

namespace SING.Data.DAL
{
    public class Result
    {
        private StatusCode _errorCode;

        [JsonIgnore]
        public StatusCode ErrorCode
        {
            get
            {
                return this._errorCode;
            }
            set
            {
                this._errorCode = value;
            }
        }

        private int _error;

        [JsonProperty(PropertyName = "error")]
        public int Error
        {
            get
            {
                return this._error;
            }
            set
            {
                this._error = value;
                this.ErrorCode = (StatusCode) _error;
            }
        }

        private string _message;

        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message
        {
            get
            {
                return this._message;
            }
            set
            {
                this._message = value;
            }
        }

        private object _data;
        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public object Data
        {
            get
            {
                return this._data;
            }
            set
            {
                this._data = value;
            }
        }

        private int _id;
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int ID
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

        private string _oper;
        [JsonProperty(PropertyName = "oper", NullValueHandling = NullValueHandling.Ignore)]
        public string Oper
        {
            get
            {
                return this._oper;
            }
            set
            {
                this._oper = value;
            }
        }

        private int _stat;
        [JsonProperty(PropertyName = "stat", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Stat
        {
            get
            {
                return this._stat;
            }
            set
            {
                this._stat = value;
            }
        }

        private long _timeStamp;
        [JsonProperty(PropertyName = "timestamp", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long TimeStamp
        {
            get
            {
                return this._timeStamp;
            }
            set
            {
                this._timeStamp = value;
            }
        }

        private long _force;
        [JsonProperty(PropertyName = "force", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long Force
        {
            get
            {
                return this._force;
            }
            set
            {
                this._force = value;
            }
        }
    }
}
