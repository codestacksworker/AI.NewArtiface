using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;

namespace FACE_AlertRecord.Models
{
    public class AreaChannelData : INotifyPropertyChanged
    {
        private string _area;
        private string _channel;
        private string _describe;
        private string _areaChild;
        private string _channelChild;
        private bool _isChecked;

        public string Area
        {
            get
            {
                return _area;
            }

            set
            {
                _area = value;
                OnPropertyChanged("Area");
            }
        }

        public string Channel
        {
            get
            {
                return _channel;
            }

            set
            {
                _channel = value;
                OnPropertyChanged("Channel");
            }
        }

        public string Describe
        {
            get
            {
                return _describe;
            }

            set
            {
                _describe = value;
                OnPropertyChanged("Describe");
            }
        }

        public string AreaChild
        {
            get
            {
                return _areaChild;
            }

            set
            {
                _areaChild = value;
                OnPropertyChanged("AreaChild");
            }
        }

        public string ChannelChild
        {
            get
            {
                return _channelChild;
            }

            set
            {
                _channelChild = value;
                OnPropertyChanged("ChannelChild");
            }
        }

        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }

            set
            {
                _isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }


        private ObservableCollection<AreaChannelData> _areaChannelChildList =
            new ObservableCollection<AreaChannelData>();
        public ObservableCollection<AreaChannelData> AreaChannelChildList
        {
            get
            {
                return _areaChannelChildList;
            }

            set
            {
                _areaChannelChildList = value;
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
