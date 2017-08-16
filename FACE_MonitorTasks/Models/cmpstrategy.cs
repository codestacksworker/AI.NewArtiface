using Microsoft.Practices.Prism.ViewModel;
using SING.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Data;

namespace FACE_MonitorTasks.Models
{
  public  class CmpStrategy: ModelBase
    {
        private Guid _uuid;
        private string _strategyName;
        private int _taskType;
        private string _createUser;
        private DateTime _createDate;
        private string _description;
        private int _cmpMethodString;
        private int _taskCount;


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

        public string StrategyName
        {
            get
            {
                return _strategyName;
            }

            set
            {
                this._strategyName = value;
                this.RaisePropertyChanged(() => this.StrategyName);
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
        
        public int CmpMethodString
        {
            get
            {
                return _cmpMethodString;
            }

            set
            {
                this._cmpMethodString = value;
                this.RaisePropertyChanged(() => this.CmpMethodString);
            }
        }


        public int TaskCount
        {
            get
            {
                return _taskCount;
            }

            set
            {
                this._taskCount = value;
                this.RaisePropertyChanged(() => this.TaskCount);
            }
        }



        public object Clone()
        {
            CmpStrategy target = new CmpStrategy();
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

        public ObservableItemCollection<CmpMethodType> CmpMethodTypeList { get; private set; }
        public ObservableItemCollection<CmpMethod> CmpMethodList { get; private set; }
        public ObservableItemCollection<MonitorTask> TaskList { get; private set; }
        public CmpStrategy()
        {
            this.Uuid = DefaultUuid;
            this.CreateDate = DateTime.Now;
            this.TaskList = new ObservableItemCollection<MonitorTask>();

            this.CmpMethodTypeList = new ObservableItemCollection<CmpMethodType>();
            foreach(var item in CmpMethodType.MethodTypeList)
            {
                this.CmpMethodTypeList.Add(item);
            }
            
            this.CmpMethodList = new ObservableItemCollection<CmpMethod>();
           foreach(var item in CmpMethod.AllCmpMethod)
            {
                this.CmpMethodList.Add(item);
            }
        }
     


        private static List<CmpStrategy> _cmpStrategyDatas;
        public static List<CmpStrategy> CmpStrategyDatas
        {
            get
            {
                return _cmpStrategyDatas;
            }
        }

        public static Guid DefaultUuid = Guid.NewGuid();
        
        public static void RefreshDatas()
        {
            _cmpStrategyDatas = new List<CmpStrategy>();
            //添加系统默认策略
            CmpStrategy first = new CmpStrategy();
            first.Uuid = DefaultUuid;
            first.Index =1;
            first.StrategyName = "默认策略";
            first.CreateUser = "测试人";
            first.CreateDate = DateTime.Now.AddHours(-1);
            first.Description = "##########";
            first.CmpMethodString = 2;

            var list = CmpStrategy.GetTasks(first.Uuid);
            first.TaskList.Clear();
            foreach (var item in list)
            {
                first.TaskList.Add(item);
            }
            first.TaskCount = first.TaskList.Count;

            _cmpStrategyDatas.Add(first);
            
        }


        public static List<MonitorTask> GetTasks(Guid strategyID)
        {
            return MonitorTask.MonitorTaskDatas.Where(p=>p.StrategyId==strategyID).ToList();
        }

       

        public static string GetMethodStringName(int cmpMethodString)
        {
            string name= "";
            switch (cmpMethodString)
            {
                case 0:
                    name= "阈值法";
                    break;
                case 1:
                    name = "计数法";
                    break;
                case 2:
                    name = "阈值法,计数法";
                    break;
            }
            return name;
        }

        public  int GetMethodString()
        {
            int result = -1;
            var list = CmpMethodList.Where(p=>p.IsChecked);
            var m0 = list.FirstOrDefault(p => p.MethodType == 0);
            var m1 = list.FirstOrDefault(p => p.MethodType == 1);

            if (m0 != null)
            {
                if (m1 != null)
                {
                    result = 2;
                }
                else
                {
                    result = 0;
                }
            }
            else
            {
                if (m1 != null)
                {
                    result = 1;
                }
            }

            return result;
        }

        public static string GetMethodTypeStringName(int typeID)
        {
            if (typeID == 0)
            {
                return "阈值法";
            }
            else
            {
                return "计数法";
            }
            
        }

       


    }
}
