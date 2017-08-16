using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.DAL.Data;

namespace SING.Data.DAL.NewCode.Data
{
    public class FaceObjectData : UIDataBase
    {
        private string uuid;
        private string mainFtid;
        private string name;
        private int type;
        private int sst;
        private int reserved;
        private int sex;
        private long timestamp;
        private string timestampStr;
        private string remarks;
        private string idNumb;
        private int idType;
        private long birthDate;
        private string addr;
        private string ethnic;
        private int ftdbId;
        private string tags;

        private string sexTag;  //性别显示值
        private string sstTag;  //敏感等级
        private string idTypeTag; //证件类型显示

        private string birthDateStr;//生日日期

        public string Uuid
        {
            get
            {
                return uuid;
            }

            set
            {
                uuid = value;
                OnPropertyChanged("Uuid");
            }
        }

        public string MainFtid
        {
            get
            {
                return mainFtid;
            }

            set
            {
                mainFtid = value;
                OnPropertyChanged("MainFtid");
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }

        public int Sst
        {
            get
            {
                return sst;
            }

            set
            {
                sst = value;
                OnPropertyChanged("Sst");
            }
        }

        public int Reserved
        {
            get
            {
                return reserved;
            }

            set
            {
                reserved = value;
                OnPropertyChanged("Reserved");
            }
        }

        public int Sex
        {
            get
            {
                return sex;
            }

            set
            {
                sex = value;
                OnPropertyChanged("Sex");
            }
        }

        public long Timestamp
        {
            get
            {
                return timestamp;
            }

            set
            {
                timestamp = value;
                OnPropertyChanged("Timestamp");
            }
        }

        public string TimestampStr
        {
            get
            {
                return timestampStr;
            }

            set
            {
                timestampStr = value;
                OnPropertyChanged("TimestampStr");
            }
        }

        public string Remarks
        {
            get
            {
                return remarks;
            }

            set
            {
                remarks = value;
                OnPropertyChanged("Remarks");
            }
        }

        public string IdNumb
        {
            get
            {
                return idNumb;
            }

            set
            {
                idNumb = value;
                OnPropertyChanged("IdNumb");
            }
        }

        public int IdType
        {
            get
            {
                return idType;
            }

            set
            {
                idType = value;
                OnPropertyChanged("IdType");
            }
        }

        public long BirthDate
        {
            get
            {
                return birthDate;
            }

            set
            {
                birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        public string Addr
        {
            get
            {
                return addr;
            }

            set
            {
                addr = value;
                OnPropertyChanged("Addr");
            }
        }

        public string Ethnic
        {
            get
            {
                return ethnic;
            }

            set
            {
                ethnic = value;
                OnPropertyChanged("Ethnic");
            }
        }

        public int FtdbId
        {
            get
            {
                return ftdbId;
            }

            set
            {
                ftdbId = value;
                OnPropertyChanged("FtdbId");
            }
        }

        public string Tags
        {
            get
            {
                return tags;
            }

            set
            {
                tags = value;
                OnPropertyChanged("Tags");
            }
        }

        public string SexTag
        {
            get
            {
                return sexTag;
            }

            set
            {
                sexTag = value;
                OnPropertyChanged("SexTag");
            }
        }

        public string SstTag
        {
            get
            {
                return sstTag;
            }

            set
            {
                sstTag = value;
                OnPropertyChanged("SstTag");
            }
        }

        public string IdTypeTag
        {
            get
            {
                return idTypeTag;
            }

            set
            {
                idTypeTag = value;
                OnPropertyChanged("IdTypeTag");
            }
        }

        public string BirthDateStr
        {
            get
            {
                return birthDateStr;
            }

            set
            {
                birthDateStr = value;
                OnPropertyChanged("BirthDateStr");
            }
        }
    }
}
