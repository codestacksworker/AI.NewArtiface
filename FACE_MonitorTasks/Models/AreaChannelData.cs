
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;
using SING.Infrastructure.Models;

namespace FACE_MonitorTasks.Models
{
    public class AreaChannelData : ModelBase
    {
        private string _area;
        private string _channel;
        private string _describe;
        private string _areaChild;
        private string _channelChild;

        public string Area
        {
            get
            {
                return _area;
            }

            set
            {
                _area = value;
                RaisePropertyChanged("Area");
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
                RaisePropertyChanged("Channel");
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
                RaisePropertyChanged("Describe");
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
                RaisePropertyChanged("AreaChild");
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
                RaisePropertyChanged("ChannelChild");
            }
        }

 


        private ObservableCollection<AreaChannelData> _areaChannelChildList =new ObservableCollection<AreaChannelData>();
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

    }
}
