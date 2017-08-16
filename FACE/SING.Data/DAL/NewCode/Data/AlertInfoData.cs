using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL.NewCode.Data
{
    public class AlertInfoData : UIDataBase
    {
        private string alertUuid;
        private string fcapImgUuid;
        private string fcapImgUrl;
        private string fcmpImgUuid;
        private string fcmpImgUrl;
        private string fcapUuid;
        private string fcmpFobjId;
        private string dBID;
        private string name;
        private string sex;
        private string sexTag;
        private string iDNumber;
        private string label;
        private string regionName;
        private string channelName;
        private string addr;
        private string appearNumber;
        private string score;
        private string taskName;
        private string alertTime;
        private string pubState;
        private string actTime;
        private string uncheckedCount;
        private string userId;
        private string acker;
        
        public string AlertUuid
        {
            get
            {
                return alertUuid;
            }

            set
            {
                alertUuid = value;
                OnPropertyChanged("AlertUuid");
            }
        }

        public string FcapImgUuid
        {
            get
            {
                return fcapImgUuid;
            }

            set
            {
                fcapImgUuid = value;
                OnPropertyChanged("FcapImgUuid");
            }
        }

        public string FcapImgUrl
        {
            get
            {
                return fcapImgUrl;
            }

            set
            {
                fcapImgUrl = value;
                OnPropertyChanged("FcapImgUrl");
            }
        }

        public string FcmpImgUuid
        {
            get
            {
                return fcmpImgUuid;
            }

            set
            {
                fcmpImgUuid = value;
                OnPropertyChanged("FcmpImgUuid");
            }
        }

        public string FcmpImgUrl
        {
            get
            {
                return fcmpImgUrl;
            }

            set
            {
                fcmpImgUrl = value;
                OnPropertyChanged("FcmpImgUrl");
            }
        }

        public string FcapUuid
        {
            get
            {
                return fcapUuid;
            }

            set
            {
                fcapUuid = value;
                OnPropertyChanged("FcapUuid");
            }
        }

        public string FcmpFobjId
        {
            get
            {
                return fcmpFobjId;
            }

            set
            {
                fcmpFobjId = value;
                OnPropertyChanged("FcmpFobjId");
            }
        }

        public string DBID
        {
            get
            {
                return dBID;
            }

            set
            {
                dBID = value;
                OnPropertyChanged("DBID");
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

        public string Sex
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

        public string IDNumber
        {
            get
            {
                return iDNumber;
            }

            set
            {
                iDNumber = value;
                OnPropertyChanged("IDNumber");
            }
        }

        public string Label
        {
            get
            {
                return label;
            }

            set
            {
                label = value;
                OnPropertyChanged("Label");
            }
        }

        public string RegionName
        {
            get
            {
                return regionName;
            }

            set
            {
                regionName = value;
                OnPropertyChanged("RegionName");
            }
        }

        public string ChannelName
        {
            get
            {
                return channelName;
            }

            set
            {
                channelName = value;
                OnPropertyChanged("ChannelName");
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

        public string AppearNumber
        {
            get
            {
                return appearNumber;
            }

            set
            {
                appearNumber = value;
                OnPropertyChanged("AppearNumber");
            }
        }

        public string Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
                OnPropertyChanged("Score");
            }
        }

        public string TaskName
        {
            get
            {
                return taskName;
            }

            set
            {
                taskName = value;
                OnPropertyChanged("TaskName");
            }
        }

        public string AlertTime
        {
            get
            {
                return alertTime;
            }

            set
            {
                alertTime = value;
                OnPropertyChanged("AlertTime");
            }
        }

        public string PubState
        {
            get
            {
                return pubState;
            }

            set
            {
                pubState = value;
                OnPropertyChanged("PubState");
            }
        }

        public string ActTime
        {
            get
            {
                return actTime;
            }

            set
            {
                actTime = value;
                OnPropertyChanged("ActTime");
            }
        }

        public string UncheckedCount
        {
            get
            {
                return uncheckedCount;
            }

            set
            {
                uncheckedCount = value;
                OnPropertyChanged("UncheckedCount");
            }
        }

        public string UserId
        {
            get
            {
                return userId;
            }

            set
            {
                userId = value;
                OnPropertyChanged("UserId");
            }
        }

        public string Acker
        {
            get
            {
                return acker;
            }

            set
            {
                acker = value;
                OnPropertyChanged("Acker");
            }
        }
    }
}
