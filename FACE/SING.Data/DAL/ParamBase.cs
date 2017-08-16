using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL
{
    public partial class ParamBase
    {
        private long _startTime;
        [JsonProperty(PropertyName = "start_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "end_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
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

        private string _tag;
        [JsonProperty(PropertyName = "Tag", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                this._tag = value;
            }
        }

        private int _startNum;
        [JsonProperty(PropertyName = "start_num", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int StartNum
        {
            get
            {
                return this._startNum;
            }
            set
            {
                this._startNum = value;
            }
        }

        private int _count;
        [JsonProperty(PropertyName = "count", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int Count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }

        private int _isOrder;
        [JsonProperty(PropertyName = "is_order", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int IsOrder
        {
            get
            {
                return this._isOrder;
            }
            set
            {
                this._isOrder = value;
            }
        }

        private string _orderCol;
        [JsonProperty(PropertyName = "order_col", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string OrderCol
        {
            get
            {
                return this._orderCol;
            }
            set
            {
                this._orderCol = value;
            }
        }

        private bool _isRepeat;
        [JsonProperty(PropertyName = "is_repeat", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual bool IsRepeat
        {
            get
            {
                return this._isRepeat;
            }
            set
            {
                this._isRepeat = value;
            }
        }
    }
}
