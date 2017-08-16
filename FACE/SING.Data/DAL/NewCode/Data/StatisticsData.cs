using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.DAL.Data;

namespace SING.Data.DAL.NewCode.Data
{
    public class StatisticsData:UIDataBase
    {
        private string startTime;
        private string endTime;
        private string jobId;

        private int hour;
        private int alertCount;
        private int alarmCount;
        private int personCoount;

        #region  查询条件
        public string JobId
        {
            get
            {
                return jobId;
            }

            set
            {
                this.jobId = value; OnPropertyChanged("JobId");
            }
        }

        public string StartTime
        {
            get
            {
                return startTime;
            }

            set
            {
                startTime = value;
                OnPropertyChanged("StartTime");
            }
        }
        public string EndTime
        {
            get
            {
                return endTime;
            }

            set
            {
                endTime = value;
                OnPropertyChanged("EndTime");
            }
        }
        #endregion

        public int Hour
        {
            get
            {
                return hour;
            }

            set
            {
                hour = value;OnPropertyChanged("Hour");
            }
        }

        public int AlertCount
        {
            get
            {
                return alertCount;
            }

            set
            {
                alertCount = value;OnPropertyChanged("AlertCount");
            }
        }

        public int AlarmCount
        {
            get
            {
                return alarmCount;
            }

            set
            {
                alarmCount = value;OnPropertyChanged("AlarmCount");
            }
        }

        public int PersonCoount
        {
            get
            {
                return personCoount;
            }

            set
            {
                personCoount = value;OnPropertyChanged("PersonCoount");
            }
        }

     
    }
}
