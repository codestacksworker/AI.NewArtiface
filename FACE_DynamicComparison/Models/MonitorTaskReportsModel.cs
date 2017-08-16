using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_DynamicComparison.Models
{
    public class MonitorTaskReportsModel : INotifyPropertyChanged
    {
        private int count;
        private int hour;
        private DateTime time;

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }

        public int Hour
        {
            get
            {
                return hour;
            }

            set
            {
                this.hour = value;
                OnPropertyChanged("Hour");
            }
        }

        public DateTime Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
                OnPropertyChanged("Time");
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

    public class SalesRevenue : INotifyPropertyChanged
    {
        public SalesRevenue(string month, double revenue)
        {
            this._month = month;
            this._revenue = revenue;
        }

        private string _month;
        private double _revenue;

        public string Month
        {
            get
            {
                return this._month;
            }
            set
            {
                _month = value;
                OnPropertyChanged("Month");
            }
        }

        public double Revenue
        {
            get
            {
                return this._revenue;
            }
            set
            {
                _revenue = value;
                OnPropertyChanged("Revenue");
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
