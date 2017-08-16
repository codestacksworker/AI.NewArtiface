using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SING.Infrastructure.Video.VideoSdkHelper.Models
{
    public class BaseItem: DependencyObject, INotifyPropertyChanged
    {
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

    public class VideoItem : BaseItem
    {
        private string _serverIp;
        private int _serverPort;
        private string _serverUserName;
        private string _serverPwd;
        private int _platID;
        private TimeQuantum _timeQuantum;
        private string _channelNo;

        public string ServerIp
        {
            get
            {
                return _serverIp;
            }

            set
            {
                _serverIp = value;
                OnPropertyChanged("ServerIp");
            }
        }

        public int ServerPort
        {
            get
            {
                return _serverPort;
            }

            set
            {
                _serverPort = value;
                OnPropertyChanged("ServerPort");
            }
        }

        public string ServerUserName
        {
            get
            {
                return _serverUserName;
            }

            set
            {
                _serverUserName = value;
                OnPropertyChanged("ServerUserName");
            }
        }

        public string ServerPwd
        {
            get
            {
                return _serverPwd;
            }

            set
            {
                _serverPwd = value;
                OnPropertyChanged("ServerPwd");
            }
        }

        public int PlatID
        {
            get
            {
                return _platID;
            }

            set
            {
                _platID = value;
                OnPropertyChanged("PlatID");
            }
        }

        public TimeQuantum TimeQuantum
        {
            get
            {
                return _timeQuantum;
            }

            set
            {
                _timeQuantum = value;
                OnPropertyChanged("TimeQuantum");
            }
        }

        public string ChannelNo
        {
            get
            {
                return _channelNo;
            }

            set
            {
                _channelNo = value;
                OnPropertyChanged("ChannelNo");
            }
        }
    }

    public class TimeQuantum: BaseItem
    {
        private DateTime _begin;
        private DateTime _end;
        private DateTime _current;

        public DateTime Begin
        {
            get
            {
                return _begin;
            }

            set
            {
                _begin = value;
                OnPropertyChanged("Begin");
            }
        }

        public DateTime End
        {
            get
            {
                return _end;
            }

            set
            {
                _end = value;
                OnPropertyChanged("End");
            }
        }

        public DateTime Current
        {
            get
            {
                return _current;
            }

            set
            {
                _current = value;
                OnPropertyChanged("Current");
            }
        }
    }
}
