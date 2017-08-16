using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL.NewCode.Data
{
    public class SecAlertsData : UIDataBase
    {
        private string uuid;
        private int ackStat;
        private long actTime;
        private string acker;
        private int pubStat;
        private long pubTime;
        private string puber;
        private long fcapTime;

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

        public int AckStat
        {
            get
            {
                return ackStat;
            }

            set
            {
                ackStat = value;OnPropertyChanged("AckStat");
            }
        }

        public long ActTime
        {
            get
            {
                return actTime;
            }

            set
            {
                actTime = value;OnPropertyChanged("ActTime");
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
                acker = value;OnPropertyChanged("Acker");
            }
        }

        public int PubStat
        {
            get
            {
                return pubStat;
            }

            set
            {
                pubStat = value;OnPropertyChanged("PubStat");
            }
        }

        public long PubTime
        {
            get
            {
                return pubTime;
            }

            set
            {
                pubTime = value;OnPropertyChanged("PubTime");
            }
        }

        public string Puber
        {
            get
            {
                return puber;
            }

            set
            {
                puber = value;OnPropertyChanged("Puber");
            }
        }

        public long FcapTime
        {
            get
            {
                return fcapTime;
            }

            set
            {
                fcapTime = value;OnPropertyChanged("FcapTime");
            }
        }
    }
}
