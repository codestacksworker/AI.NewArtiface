using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.DAL.NewCode.Condition
{
    public class SysTypecodeDataCondition:DataProcess
    {
        private string typeCode;
        [JsonProperty(PropertyName = "typeCode", NullValueHandling = NullValueHandling.Ignore)]
        public string TypeCode
        {
            get
            {
                return typeCode;
            }

            set
            {
                typeCode = value;
            }
        }
    }
}
