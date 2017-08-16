using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.DAL.Data
{
    public class JobData : INotifyPropertyChanged
    {
        private string uuid;
        private int _type;
        private int state;
        private string name;
        private DateTime beginDate;
        private int beginHours;
        private int beginMinutes;
        private DateTime endDate;
        private string daySet;
        private int endHours;
        private int endMinutes;
        private string description;
        private string methodId;
        private string uid;
        private DateTime createTime;
        private int isDelete;
        
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

        public int Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        public int State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                OnPropertyChanged("State");
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

        public DateTime BeginDate
        {
            get
            {
                return beginDate;
            }

            set
            {
                beginDate = value;
                OnPropertyChanged("BeginDate");
            }
        }

        public int BeginHours
        {
            get
            {
                return beginHours;
            }

            set
            {
                beginHours = value;
                OnPropertyChanged("BeginHours");
            }
        }

        public int BeginMinutes
        {
            get
            {
                return beginMinutes;
            }

            set
            {
                beginMinutes = value;
                OnPropertyChanged("BeginMinutes");
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        public string DaySet
        {
            get
            {
                return daySet;
            }

            set
            {
                daySet = value;
                OnPropertyChanged("DaySet");
            }
        }

        public int EndHours
        {
            get
            {
                return endHours;
            }

            set
            {
                endHours = value;
                OnPropertyChanged("EndHours");
            }
        }

        public int EndMinutes
        {
            get
            {
                return endMinutes;
            }

            set
            {
                endMinutes = value;
                OnPropertyChanged("EndMinutes");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public string MethodId
        {
            get
            {
                return methodId;
            }

            set
            {
                methodId = value;
                OnPropertyChanged("MethodId");
            }
        }

        public string Uid
        {
            get
            {
                return uid;
            }

            set
            {
                uid = value;
                OnPropertyChanged("Uid");
            }
        }

        public DateTime CreateTime
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

        public int IsDelete
        {
            get
            {
                return isDelete;
            }

            set
            {
                isDelete = value;
                OnPropertyChanged("IsDelete");
            }
        }

        #region  PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
