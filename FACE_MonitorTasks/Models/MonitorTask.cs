using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SING.Data.DAL.Data;
using SING.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace FACE_MonitorTasks.Models
{
    public class MonitorTask : ModelBase, ICloneable
    {
        private Guid _uuid;
        private string _taskName;
        private int _taskType;
        private int _taskStatus;
        private string _createUser;
        private DateTime _createDate;
        private string _description;
        private int _targetCount;
        private int _channelCount;
        private string _taskSpan;
        private Guid _strategyId;
        private int _taskPlanId;
        private DateTime _customStartDate;
        private DateTime _customEndDate;
        private int _taskTimeSpanId;
        private string _spanStartTime;
        private string _spanEndTime;

        public ObservableCollection<FaceTemplateDBData> SelectedFtdbList { get; private set; }
        public ObservableCollection<AreaChannelData> SelectedAreaChannelList { get; private set; }

        public MonitorTask()
        {
            this.SelectedFtdbList = new ObservableCollection<FaceTemplateDBData>();
            this.SelectedAreaChannelList = new ObservableCollection<AreaChannelData>();

            this.Uuid = Guid.NewGuid();
            this.CreateDate = DateTime.Now;
            this.CreateUser = "admin";
            this.Index = 0;
            this.TargetCount = 0;
            this.ChannelCount = 0;
            this.CustomStartDate = DateTime.Now;
            this.CustomEndDate = DateTime.Now;
            this.TaskType = 0;
            this.TaskStatus = 1;
            this.SpanStartTime = "00:00";
            this.SpanEndTime = "24:00";
        }

        public Guid Uuid
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

        [StringLength(5, ErrorMessage = "布控名称最大长度为64个字符")]
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

        public Guid StrategyId
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

        public int TaskPlanId
        {
            get
            {
                return _taskPlanId;
            }

            set
            {
                this._taskPlanId = value;
                this.RaisePropertyChanged(() => this.TaskPlanId);
            }
        }

        public DateTime CustomStartDate
        {
            get
            {
                return _customStartDate;
            }

            set
            {
                this._customStartDate = value;
                this.RaisePropertyChanged(() => this.CustomStartDate);
            }
        }

        public DateTime CustomEndDate
        {
            get
            {
                return _customEndDate;
            }

            set
            {
                this._customEndDate = value;
                this.RaisePropertyChanged(() => this.CustomEndDate);
            }
        }

        public int TaskTimeSpanId
        {
            get
            {
                return _taskTimeSpanId;
            }

            set
            {
                this._taskTimeSpanId = value;
                this.RaisePropertyChanged(() => this.TaskTimeSpanId);
            }
        }

        public string SpanStartTime
        {
            get
            {
                return _spanStartTime;
            }

            set
            {
                this._spanStartTime = value;
                this.RaisePropertyChanged(() => this.SpanStartTime);
            }
        }

        public string SpanEndTime
        {
            get
            {
                return _spanEndTime;
            }

            set
            {
                this._spanEndTime = value;
                this.RaisePropertyChanged(() => this.SpanEndTime);
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


        private static Random Ram = new Random();
        public static void RefreshDatas(int count)
        {
            _monitorTaskDatas = new List<MonitorTask>();
            for (int i = 0; i < count; i++)
            {
                MonitorTask item = new MonitorTask();
                item.Uuid = Guid.NewGuid();
                item.Index = i + 1;
                item.TaskName = "###-#####" + item.Index;
                item.TaskType = 0;
                item.TaskStatus = Ram.Next(0, 3);
                item.TaskSpan = "每天 0:00-24:00";
                item.CreateUser = item.Index % 3 == 0 ? "测试人" : "admin";
                item.CreateDate = DateTime.Now.AddDays(-1 * item.Index);
                item.Description = "##########";
                item.StrategyId = CmpStrategy.DefaultUuid;

                _monitorTaskDatas.Add(item);
            }
        }


        public static string GetTaskTypeName(int taskyType)
        {
            string result = "";
            switch (taskyType)
            {
                case 0:
                    result = "目标监视";
                    break;
                case 1:
                    result = "区域设防";
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
            MonitorTask target = new MonitorTask();
            System.Reflection.PropertyInfo[] properties = (target.GetType()).GetProperties();
            System.Reflection.PropertyInfo[] fields = (this.GetType()).GetProperties();
            for (int i = 0; i < fields.Length; i++)
            {
                for (int j = 0; j < properties.Length; j++)
                {

                    if (fields[i].Name.ToUpper() == properties[j].Name.ToUpper() && properties[j].CanWrite)
                    {
                        properties[j].SetValue(target, fields[i].GetValue(this, null), null);
                    }
                }
            }

            return target;
        }

        public void CopyValue(object obj)
        {
            object target = this;
            object source = obj;

            System.Reflection.PropertyInfo[] properties = (target.GetType()).GetProperties();
            System.Reflection.PropertyInfo[] fields = (source.GetType()).GetProperties();
            for (int i = 0; i < fields.Length; i++)
            {
                for (int j = 0; j < properties.Length; j++)
                {

                    if (fields[i].Name.ToUpper() == properties[j].Name.ToUpper() && properties[j].CanWrite)
                    {
                        properties[j].SetValue(target, fields[i].GetValue(source, null), null);
                    }
                }
            }
        }
    }
}
