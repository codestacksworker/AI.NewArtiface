using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.DAL.Data;

namespace SING.Data.DAL.NewCode.Data
{
    public class FaceTemplateDbData : UIDataBase
    {
        private int id;
        private string templateDbName;
        private string templateDbDescription;
        private int templateDbType;
        private int isUsed;
        private int templateDbSize;
        private long createTime;
        private int isDeleted;
        private int templateDbCapacity;

        private int objectCount;// 目标人数量
        private string createTimeStr;// 创建时间
        private string templateDbTypeTag;//模板类型

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string TemplateDbName
        {
            get
            {
                return templateDbName;
            }

            set
            {
                templateDbName = value;
                OnPropertyChanged("TemplateDbName");
            }
        }

        public string TemplateDbDescription
        {
            get
            {
                return templateDbDescription;
            }

            set
            {
                templateDbDescription = value;
                OnPropertyChanged("TemplateDbDescription");
            }
        }

        public int TemplateDbType
        {
            get
            {
                return templateDbType;
            }

            set
            {
                templateDbType = value;
                OnPropertyChanged("TemplateDbType");
            }
        }

        public int IsUsed
        {
            get
            {
                return isUsed;
            }

            set
            {
                isUsed = value;
                OnPropertyChanged("IsUsed");
            }
        }

        public int TemplateDbSize
        {
            get
            {
                return templateDbSize;
            }

            set
            {
                templateDbSize = value;
                OnPropertyChanged("TemplateDbSize");
            }
        }

        public long CreateTime
        {
            get
            {
                return createTime;
            }

            set
            {
                createTime = value;
                OnPropertyChanged("CreateTime");
            }
        }

        public int IsDeleted
        {
            get
            {
                return isDeleted;
            }

            set
            {
                isDeleted = value;
                OnPropertyChanged("IsDeleted");
            }
        }

        public int TemplateDbCapacity
        {
            get
            {
                return templateDbCapacity;
            }

            set
            {
                templateDbCapacity = value;
                OnPropertyChanged("TemplateDbCapacity");
            }
        }

        public int ObjectCount
        {
            get
            {
                return objectCount;
            }

            set
            {
                objectCount = value;
                OnPropertyChanged("ObjectCount");
            }
        }

        public string CreateTimeStr
        {
            get
            {
                return createTimeStr;
            }

            set
            {
                createTimeStr = value;
                OnPropertyChanged("CreateTimeStr");
            }
        }

        public string TemplateDbTypeTag
        {
            get
            {
                return templateDbTypeTag;
            }

            set
            {
                templateDbTypeTag = value;
                OnPropertyChanged("TemplateDbTypeTag");
            }
        }
    }
}
