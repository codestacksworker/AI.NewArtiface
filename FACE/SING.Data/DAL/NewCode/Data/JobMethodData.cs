using System;

namespace SING.Data.DAL.NewCode.Data
{
    public class JobMethodData : UIDataBase
    {
        private string uuid;
        private int _type;
        private string name;
        private string description;
        private int method;
        private float m1Score;
        private float m2Score;
        private int m2Seconds;
        private int m2Count;
        private string adder;
        private DateTime addTime;
        private string modifier;
        private DateTime modifyTime;

        #region MyRegion
        private int index;
        public int Index
        {
            get { return index; }
            set { index = value; OnPropertyChanged("Index"); }
        }
        #endregion

        public string Uuid
        {
            get
            {
                return uuid;
            }

            set
            {
                uuid = value; OnPropertyChanged("Uuid");
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
                _type = value; OnPropertyChanged("Type");
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
                name = value; OnPropertyChanged("Name");
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
                description = value; OnPropertyChanged("Description");
            }
        }

        public int Method
        {
            get
            {
                return method;
            }

            set
            {
                method = value; OnPropertyChanged("Method");
            }
        }

        public float M1Score
        {
            get
            {
                return m1Score;
            }

            set
            {
                m1Score = value; OnPropertyChanged("M1Score");
            }
        }

        public float M2Score
        {
            get
            {
                return m2Score;
            }

            set
            {
                m2Score = value; OnPropertyChanged("M2Score");
            }
        }

        public int M2Seconds
        {
            get
            {
                return m2Seconds;
            }

            set
            {
                m2Seconds = value; OnPropertyChanged("M2Seconds");
            }
        }

        public int M2Count
        {
            get
            {
                return m2Count;
            }

            set
            {
                m2Count = value; OnPropertyChanged("M2Count");
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

        public string Modifier
        {
            get
            {
                return modifier;
            }

            set
            {
                modifier = value; OnPropertyChanged("Modifier");
            }
        }

        public DateTime ModifyTime
        {
            get
            {
                return modifyTime;
            }

            set
            {
                modifyTime = value; OnPropertyChanged("ModifyTime");
            }
        }
    }
}
