using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.DAL.Data;

namespace SING.Data.DAL.NewCode.Data
{
    public class SysSubscribeData : UIDataBase
    {
        private string uuid;
        private string uid;
        private string jobId;
        private int state;
        private DateTime subTime;
        private string subTimeStr;

        public string Uuid
        {
            get
            {
                return uuid;
            }

            set
            {
                uuid = value;OnPropertyChanged("Uuid");
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
                uid = value;OnPropertyChanged("Uid");
            }
        }

        public string JobId
        {
            get
            {
                return jobId;
            }

            set
            {
                jobId = value;OnPropertyChanged("JobId");
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
                state = value;OnPropertyChanged("State");
            }
        }

        public DateTime SubTime
        {
            get
            {
                return subTime;
            }

            set
            {
                subTime = value;OnPropertyChanged("SubTime");
            }
        }

        public string SubTimeStr
        {
            get
            {
                return subTimeStr;
            }

            set
            {
                subTimeStr = value;OnPropertyChanged("SubTimeStr");
            }
        }
    }
}
