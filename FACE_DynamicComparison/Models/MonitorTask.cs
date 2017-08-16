using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_DynamicComparison.Models
{
  public  class MonitorTask: NotificationObject, ICloneable
    {
        private bool _checked;
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

        public int Index { get; private set; }
        public bool Checked
        {
            get
            {
                return _checked;
            }

            set
            {
                this._checked = value;
                this.RaisePropertyChanged(() => this.Checked);
            }
        }

 

        public int Uuid
        {
            get
            {
                return _uuid;
            }

            set
            {
                this._uuid = value;
                this.RaisePropertyChanged(() => this.Uuid);
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
                this.RaisePropertyChanged(() => this.TaskName);
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
                this.RaisePropertyChanged(() => this.TaskType);
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
                this.RaisePropertyChanged(() => this.TaskStatus);
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
                this.RaisePropertyChanged(() => this.CreateUser);
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
                this.RaisePropertyChanged(() => this.CreateDate);
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
                this.RaisePropertyChanged(() => this.Description);
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
                this.RaisePropertyChanged(() => this.TargetCount);
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
                this.RaisePropertyChanged(() => this.ChannelCount);
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
                this.RaisePropertyChanged(() => this.TaskSpan);
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
                this.RaisePropertyChanged(() => this.StrategyId);
            }
        }


        private static List<MonitorTask> _monitorTaskDatas;
        public static List<MonitorTask> MonitorTaskDatas
        {
            get
            {
                return _monitorTaskDatas;
            }
        }

        public static void RefreshDatas(int count)
        {
             _monitorTaskDatas = new List<MonitorTask>();
            for (int i = 0; i < count; i++)
            {
                MonitorTask item = new MonitorTask();
                item.Uuid = i + 1;
                item.Index = i + 1;
                item.TaskName = "###-#####";
                item.TaskSpan = "每周1、2、3、4、5 8:00-24:00";
                item.CreateUser = "测试人";
                item.CreateDate = DateTime.Now;
                item.Description = "##########";
                item.StrategyId = new Random().Next(0, count - 1);

                _monitorTaskDatas.Add(item);
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
    }
}
