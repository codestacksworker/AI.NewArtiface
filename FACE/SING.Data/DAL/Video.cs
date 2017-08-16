using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL
{
    public partial class Video
    {
        private string _ocxId;

        [JsonProperty(PropertyName = "OcxID", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string OcxID
        {
            get
            {
                return this._ocxId;
            }
            set
            {
                this._ocxId = value;
            }
        }

        private string _operMethod;

        [JsonProperty(PropertyName = "OperMethod", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string OperMethod
        {
            get
            {
                return this._operMethod;
            }
            set
            {
                this._operMethod = value;
            }
        }

        private bool _operResult;

        [JsonProperty(PropertyName = "OperResult", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual bool OperResult
        {
            get
            {
                return this._operResult;
            }
            set
            {
                this._operResult = value;
            }
        }

        private string _errID;

        [JsonProperty(PropertyName = "ErrID", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ErrID
        {
            get
            {
                return this._errID;
            }
            set
            {
                this._errID = value;
            }
        }

        private string _errDescription;

        [JsonProperty(PropertyName = "ErrDescription", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ErrDescription
        {
            get
            {
                return this._errDescription;
            }
            set
            {
                this._errDescription = value;
            }
        }


        private ErrPara _errPara;

        [JsonProperty(PropertyName = "ErrPara", NullValueHandling = NullValueHandling.Ignore)]
        public virtual ErrPara ErrPara
        {
            get
            {
                return this._errPara;
            }
            set
            {
                this._errPara = value;
            }
        }
    }

    public partial class ErrPara
    {
        private string _para1;

        [JsonProperty(PropertyName = "Para1", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Para1
        {
            get
            {
                return this._para1;
            }
            set
            {
                this._para1 = value;
            }
        }

        private string _para2;

        [JsonProperty(PropertyName = "Para2", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Para2
        {
            get
            {
                return this._para2;
            }
            set
            {
                this._para2 = value;
            }
        }

        private string _para3;

        [JsonProperty(PropertyName = "Para3", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Para3
        {
            get
            {
                return this._para3;
            }
            set
            {
                this._para3 = value;
            }
        }

        private string _para4;

        [JsonProperty(PropertyName = "Para4", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Para4
        {
            get
            {
                return this._para4;
            }
            set
            {
                this._para4 = value;
            }
        }

        private string _para5;

        [JsonProperty(PropertyName = "Para5", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Para5
        {
            get
            {
                return this._para5;
            }
            set
            {
                this._para5 = value;
            }
        }
    }
}
