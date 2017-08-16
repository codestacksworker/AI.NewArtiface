using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace FACE_AlertRecord.Models
{
  public  class MonitorTaskData : INotifyPropertyChanged, ICloneable
    {

        private int _uuid;
        private string _taskName;
        private  int _taskType;
        private int _taskStatus;
        private string _createUser;
        private DateTime _createDate;
        private string _description;
        private int _targetCount;
        private int _channelCount;
        private string _taskSpan;
        private int _strategyId;
        private bool _isChecked;

        public int Uuid
        {
            get
            {
                return _uuid;
            }

            set
            {
                this._uuid = value;
                OnPropertyChanged("Uuid");
            }
        }

        public string TaskName
        {
            get
            {
                return _taskName;
            }

            set
            {
                this._taskName = value;
                OnPropertyChanged("TaskName");
            }
        }

        public int TaskType
        {
            get
            {
                return _taskType;
            }

            set
            {
                this._taskType = value;
                OnPropertyChanged("TaskType");
            }
        }

        public int TaskStatus
        {
            get
            {
                return _taskStatus;
            }

            set
            {
                this._taskStatus = value;
                OnPropertyChanged("TaskStatus");
            }
        }

        public string CreateUser
        {
            get
            {
                return _createUser;
            }

            set
            {
                this._createUser = value;
                OnPropertyChanged("CreateUser");
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }

            set
            {
                this._createDate = value;
                OnPropertyChanged("CreateDate");
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                this._description = value;
                OnPropertyChanged("Description");
            }
        }

        public int TargetCount
        {
            get
            {
                return _targetCount;
            }

            set
            {
                this._targetCount = value;
                OnPropertyChanged("TargetCount");
            }
        }

        public int ChannelCount
        {
            get
            {
                return _channelCount;
            }

            set
            {
                this._channelCount = value;
                OnPropertyChanged("ChannelCount");
            }
        }

        public string TaskSpan
        {
            get
            {
                return _taskSpan;
            }

            set
            {
                this._taskSpan = value;
                OnPropertyChanged("TaskSpan");
            }
        }

        public int StrategyId
        {
            get
            {
                return _strategyId;
            }

            set
            {
                this._strategyId = value;
                OnPropertyChanged("StrategyId");
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
                this._isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }


        private static List<MonitorTaskData> _monitorTaskDatas;
        public static List<MonitorTaskData> MonitorTaskDatas
        {
            get
            {
                if (_monitorTaskDatas == null)
                {
                    int count = 10000;

                    _monitorTaskDatas = new List<MonitorTaskData>();
                    for (int i = 0; i < count; i++)
                    {
                        MonitorTaskData item = new MonitorTaskData();
                        item.Uuid = i + 1;
                        item.TaskName = "###-#####";
                        item.TaskSpan = "每周1、2、3、4、5 8:00-24:00";
                        item.CreateUser = "测试人";
                        item.CreateDate = DateTime.Now;
                        item.Description = "##########";
                        item.StrategyId = new Random().Next(0, count - 1);

                        _monitorTaskDatas.Add(item);
                    }
                }
                return _monitorTaskDatas;
            }
        }
        
        public static string GetTaskTypeName(int taskyType)
        {
            string result = "";
            switch (taskyType)
            {
                case 0:
                    result = "区域设防";
                    break;
                case 1:
                    result = "目标监视";
                    break;
            }

            return result;
        }

        public static string GetTaskStatusName(int taskStatus)
        {
            string result = "";
            switch (taskStatus)
            {
                case 0:
                    result = "关闭";
                    break;
                case 1:
                    result = "布控中";
                    break;
                case 2:
                    result = "不在运行时段";
                    break;
                case 3:
                    result = "暂停";
                    break;
            }

            return result;
        }


        public object Clone()
        {
            return null;
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
