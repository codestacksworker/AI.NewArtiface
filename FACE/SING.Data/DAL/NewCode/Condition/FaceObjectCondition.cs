using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.DAL.NewCode.Condition
{
    public class FaceObjectCondition:DataProcess
    {
        private string name;
        private int idType;
        private string idNumb;
        private int sex;

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
        [JsonProperty(PropertyName = "idType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int IdType
        {
            get
            {
                return idType;
            }

            set
            {
                idType = value;
            }
        }
        [JsonProperty(PropertyName = "idNumb", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string IdNumb
        {
            get
            {
                return idNumb;
            }

            set
            {
                idNumb = value;
            }
        }
        [JsonProperty(PropertyName = "sex", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Sex
        {
            get
            {
                return sex;
            }

            set
            {
                sex = value;
            }
        }
    }
}
