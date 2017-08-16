﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SING.Data.DAL.NewCode.Data
{
    public class JobFaceObjectData : UIDataBase
    {
        private string uuid;
        private string jobId;
        private string objId;
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
                uuid = value;OnPropertyChanged("Uuid");
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

        public string ObjId
        {
            get
            {
                return objId;
            }

            set
            {
                objId = value;OnPropertyChanged("ObjId");
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
                adder = value;OnPropertyChanged("Adder");
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
                addTime = value;OnPropertyChanged("AddTime");
            }
        }
    }
}
