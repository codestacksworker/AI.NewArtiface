using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL.NewCode
{
    public class Tags : DataAcess
    {
        private string id;
        private int tagName;

        private int objCount;   //目标人数
        private int templateCount;  //模板数
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        [JsonProperty(PropertyName = "tagName", NullValueHandling = NullValueHandling.Ignore)]
        public int TagName
        {
            get
            {
                return tagName;
            }

            set
            {
                tagName = value;
            }
        }
        [JsonProperty(PropertyName = "objCount", NullValueHandling = NullValueHandling.Ignore)]
        public int ObjCount
        {
            get
            {
                return objCount;
            }

            set
            {
                objCount = value;
            }
        }
        [JsonProperty(PropertyName = "templateCount", NullValueHandling = NullValueHandling.Ignore)]
        public int TemplateCount
        {
            get
            {
                return templateCount;
            }

            set
            {
                templateCount = value;
            }
        }
    }
}
