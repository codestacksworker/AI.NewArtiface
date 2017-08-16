﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.DAL.NewCode.Condition
{
    public class ChannelCondition:DataProcess
    {
        private int regionId;
        private string channelName;

        [JsonProperty(PropertyName = "regionId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int RegionId
        {
            get
            {
                return regionId;
            }

            set
            {
                regionId = value;
            }
        }

        [JsonProperty(PropertyName = "channelName", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelName
        {
            get
            {
                return channelName;
            }

            set
            {
                channelName = value;
            }
        }
    }
}
