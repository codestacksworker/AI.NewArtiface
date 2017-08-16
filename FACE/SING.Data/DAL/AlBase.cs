using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL
{
    public partial class AlBase
    {
        private string _uuid;
        private string _fcapId;
        private string _channelId;
        private long _fcapTime;
        private long _alertTime;
        private string _fobjId;
        private double _fcmpSocre;
        private long _rulerId;
        private int _ackStat;
        private long _ackTime;
        private string _acker;
        private int _pubStat;
        private long _pubTime;
        private string _puber;

        [JsonProperty(PropertyName = "uuid")]
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

        [JsonProperty(PropertyName = "fcmp_cap_id", NullValueHandling = NullValueHandling.Ignore)]
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

        [JsonProperty(PropertyName = "fcap_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long FcapTime
        {
            get
            {
                return this._fcapTime;
            }
            set
            {
                this._fcapTime = value;
            }
        }

        [JsonProperty(PropertyName = "alert_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long AlertTime
        {
            get
            {
                return this._alertTime;
            }
            set
            {
                this._alertTime = value;
            }
        }

        [JsonProperty(PropertyName = "fcmp_fobj_id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string FobjId
        {
            get
            {
                return this._fobjId;
            }
            set
            {
                this._fobjId = value;
            }
        }

        [JsonProperty(PropertyName = "fcmp_socre", DefaultValueHandling = DefaultValueHandling.Ignore)]
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

        [JsonProperty(PropertyName = "ruler_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long RulerId
        {
            get
            {
                return this._rulerId;
            }
            set
            {
                this._rulerId = value;
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

        [JsonProperty(PropertyName = "ack_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long AckTime
        {
            get
            {
                return this._ackTime;
            }
            set
            {
                this._ackTime = value;
            }
        }

        [JsonProperty(PropertyName = "acker", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Acker
        {
            get
            {
                return this._acker;
            }
            set
            {
                this._acker = value;
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

        [JsonProperty(PropertyName = "pub_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long PubTime
        {
            get
            {
                return this._pubTime;
            }
            set
            {
                this._pubTime = value;
            }
        }

        [JsonProperty(PropertyName = "puber", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Puber
        {
            get
            {
                return this._puber;
            }
            set
            {
                this._puber = value;
            }
        }
    }
}
