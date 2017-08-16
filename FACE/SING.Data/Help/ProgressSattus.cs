using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Help
{
    public class ProgressSattus : INotifyPropertyChanged
    {
        private bool _isBusyHanding = false;
        public bool IsBusyHanding
        {
            get { return _isBusyHanding; }
            set
            {
                _isBusyHanding = value;
                OnPropertyChanged("IsBusyHanding");
            }
        }

        private double _progressValue;
        public double ProgressValue
        {
            get { return _progressValue; }
            set
            {
                _progressValue = value;
                OnPropertyChanged("ProgressValue");
            }
        }

        private string _busyContent = "请求处理中，请稍候...";
        public string BusyContent
        {
            get { return _busyContent; }
            set
            {
                _busyContent = value;
                OnPropertyChanged("BusyContent");
            }
        }

        private double _displayAfterShowMain = 0.0;
        public double DisplayAfterShowMain
        {
            get { return _displayAfterShowMain; }
            set
            {
                _displayAfterShowMain = value;
                OnPropertyChanged("DisplayAfterShowMain");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
