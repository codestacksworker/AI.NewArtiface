using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL.NewCode.Data
{
    public class JobChannelData : UIDataBase
    {
        private string uuid;
        private string jobId;
        private string channelId;
        private string adder;
        private DateTime addTime;

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

        public string JobId
        {
            get
            {
                return jobId;
            }

            set
            {
                jobId = value;
                OnPropertyChanged("JobId");
            }
        }

        public string ChannelId
        {
            get
            {
                return channelId;
            }

            set
            {
                channelId = value; OnPropertyChanged("ChannelId");
            }
        }

        public string Adder
        {
            get
            {
                return adder;
            }

            set
            {
                adder = value; OnPropertyChanged("Adder");
            }
        }

        public DateTime AddTime
        {
            get
            {
                return addTime;
            }

            set
            {
                addTime = value; OnPropertyChanged("AddTime");
            }
        }
    }
}
