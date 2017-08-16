using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_DynamicComparison.Models
{
    [Serializable]
    public class AlarmPromptData : INotifyPropertyChanged
    {
        private int _fcapId;
        private byte[] _fcapImg;
        private byte[] _targetImg;
        private string _tarLibrary;
        private string _tarName;
        private string _tarSex;
        private string _serialNum;
        private string _lables;
        private string _region;
        private string _channel;
        private string _position;
        private int _timesNum;
        private string _fcmpSocre;
        private int _monTasksNum;
        private string _alertTime;
        private string _status;

        public int FcapId
        {
            get
            {
                return _fcapId;
            }

            set
            {
                _fcapId = value;
                OnPropertyChanged("FcapId");
            }
        }

        public virtual byte[] FcapImg
        {
            get { return _fcapImg; }
            set
            {
                _fcapImg = value;
                OnPropertyChanged("FcapImg");
            }
        }

        public virtual byte[] TargetImg
        {
            get { return _targetImg; }
            set
            {
                _targetImg = value;
                OnPropertyChanged("TargetImg");
            }
        }

        public virtual string TarLibrary
        {
            get { return _tarLibrary; }
            set
            {
                _tarLibrary = value;
                OnPropertyChanged("TarLibrary");
            }
        }

        public virtual string TarName
        {
            get { return _tarName; }
            set
            {
                _tarName = value;
                OnPropertyChanged("TarName");
            }
        }

        public virtual string TarSex
        {
            get { return _tarSex; }
            set
            {
                _tarSex = value;
                OnPropertyChanged("TarSex");
            }
        }

        public virtual string SerialNum
        {
            get { return _serialNum; }
            set
            {
                _serialNum = value;
                OnPropertyChanged("SerialNum");
            }
        }

        public virtual string Lables
        {
            get { return _lables; }
            set
            {
                _lables = value;
                OnPropertyChanged("Lables");
            }
        }

        public virtual string Region
        {
            get { return _region; }
            set
            {
                _region = value;
                OnPropertyChanged("Region");
            }
        }

        public virtual string Channel
        {
            get { return _channel; }
            set
            {
                _channel = value;
                OnPropertyChanged("Channel");
            }
        }

        public virtual string Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged("Position");
            }
        }

        public virtual int TimesNum
        {
            get { return _timesNum; }
            set
            {
                _timesNum = value;
                OnPropertyChanged("TimesNum");
            }
        }

        public virtual string FcmpSocre
        {
            get { return _fcmpSocre; }
            set
            {
                _fcmpSocre = value;
                OnPropertyChanged("FcmpSocre");
            }
        }

        public virtual int MonTasksNum
        {
            get { return _monTasksNum; }
            set
            {
                _monTasksNum = value;
                OnPropertyChanged("MonTasksNum");
            }
        }

        public virtual string AlertTime
        {
            get { return _alertTime; }
            set
            {
                _alertTime = value;
                OnPropertyChanged("AlertTime");
            }
        }

        public virtual string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("State");
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
