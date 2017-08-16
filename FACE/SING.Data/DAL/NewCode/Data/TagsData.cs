using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL.NewCode.Data
{
    public class TagsData : UIDataBase
    {
        private string id;
        private int tagName;

        private int objCount;   //目标人数
        private int templateCount;  //模板数

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;OnPropertyChanged("Id");
            }
        }

        public int TagName
        {
            get
            {
                return tagName;
            }

            set
            {
                tagName = value;OnPropertyChanged("TagName");
            }
        }

        public int ObjCount
        {
            get
            {
                return objCount;
            }

            set
            {
                objCount = value;OnPropertyChanged("ObjCount");
            }
        }

        public int TemplateCount
        {
            get
            {
                return templateCount;
            }

            set
            {
                templateCount = value;OnPropertyChanged("TemplateCount");
            }
        }
    }
}
