using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.DAL.Data;

namespace SING.Data.DAL.NewCode.Data
{
    public class OriginalAlertsData : UIDataBase
    {
        private string uuid;
        private string fcmpCapChannel;
        private long fcapTime;
        private long alertTime;
        private string fcmpFobjId;
        private double fcmpSocre;
        private string jobId;
        private string rulerId;
        private int ackStat;
        private long ackTime;
        private string acker;
        private int pubStat;
        private long pubTime;
        private string puber;
        private int ftdbId;
        private string fcmpFobjName;
        private string idNumb;
        private int matchedCount;

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

        public string FcmpCapChannel
        {
            get
            {
                return fcmpCapChannel;
            }

            set
            {
                fcmpCapChannel = value;OnPropertyChanged("FcmpCapChannel");
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

        public long AlertTime
        {
            get
            {
                return alertTime;
            }

            set
            {
                alertTime = value;OnPropertyChanged("AlertTime");
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
                fcmpFobjId = value;OnPropertyChanged("FcmpFobjId");
            }
        }

        public double FcmpSocre
        {
            get
            {
                return fcmpSocre;
            }

            set
            {
                fcmpSocre = value;OnPropertyChanged("FcmpSocre");
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

        public string RulerId
        {
            get
            {
                return rulerId;
            }

            set
            {
                rulerId = value;OnPropertyChanged("RulerId");
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

        public long AckTime
        {
            get
            {
                return ackTime;
            }

            set
            {
                ackTime = value;OnPropertyChanged("AckTime");
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

        public int FtdbId
        {
            get
            {
                return ftdbId;
            }

            set
            {
                ftdbId = value;OnPropertyChanged("FtdbId");
            }
        }

        public string FcmpFobjName
        {
            get
            {
                return fcmpFobjName;
            }

            set
            {
                fcmpFobjName = value;OnPropertyChanged("FcmpFobjName");
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
                idNumb = value;OnPropertyChanged("IdNumb");
            }
        }

        public int MatchedCount
        {
            get
            {
                return matchedCount;
            }

            set
            {
                matchedCount = value;OnPropertyChanged("MatchedCount");
            }
        }
    }
}
