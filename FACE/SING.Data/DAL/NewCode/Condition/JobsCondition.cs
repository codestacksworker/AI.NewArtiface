using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.DAL.NewCode.Condition
{
    public class JobsCondition:DataProcess
    {
        private string loginUuid;
        private string name;
        [JsonProperty(PropertyName = "loginUuid", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LoginUuid
        {
            get
            {
                return loginUuid;
            }

            set
            {
                loginUuid = value;
            }
        }
        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }
}
