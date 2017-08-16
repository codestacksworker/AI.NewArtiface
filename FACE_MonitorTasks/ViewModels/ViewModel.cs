using FACE_MonitorTasks.Models;
using FACE_MonitorTasks.Services;
using FACE_MonitorTasks.Services.HelpService;
using FACE_MonitorTasks.Views;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using SING.Data.BaseTools;
using SING.Data.DAL.NewCode.Data;
using SING.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Linq;
using Telerik.Windows.Controls;

namespace FACE_MonitorTasks.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ViewModel : ModelBase, INavigationAware
    {
        public IDataService DataService { get; private set; }
        public IEventAggregator EventAggregator { get; private set; }
        public IRegionManager RegionManager { get; private set; }
        public IServiceLocator ServiceLocator { get; private set; }

        public event EventHandler UnSelectedAll;
        private Views.EditTaskForm myEditTaskForm;
        private Views.EditStrategyForm myEditStrategyForm;
        private Views.SelectFtdbForm mySelectFtdbForm;
        private Views.AreaChannelForm _areaChannelForm;
        private Views.SelectMethodForm mySelectMethodForm;
        public ViewModel() { }
        [ImportingConstructor]
        public ViewModel(IDataService dataService, IEventAggregator eventAggregator, IRegionManager regionManager, IServiceLocator serviceLocator)
        {
            this.DataService = dataService;
            this.EventAggregator = eventAggregator;
            this.RegionManager = regionManager;
            this.ServiceLocator = serviceLocator;

            this.InitializeCommands();
            this.InitializeProperties();
        }

        #region Properties
        private string _title;
        private bool _isInEditMode;
        private bool _hasSelectedItems;
        private string _keywordTask;
        private string _keywordStrategy;
        private bool _hasValidationError;
        private bool _hasHttpError;
        private bool _hasStrategyHttpError;

        private JobsData _editedTask;
        private JobMethodData _editedStrategy;
        private JobsData _selectedTask;
        private JobMethodData _selectedStrategy;

        public string[] TaskType { get; set; }
        public string[] TaskPlan { get; private set; }
        public string[] TaskTimeSpan { get; private set; }
        public string[] TaskAction { get; private set; }
        public ObservableCollection<FaceObjectData> FtdbList { get; private set; }
        public ObservableCollection<AreaChannelData> AreaChannelList { get; private set; }
        public ObservableCollection<JobsData> MonitorTaskList { get; private set; }
        public ObservableCollection<JobMethodData> CmpStrategyList { get; private set; }

        public PageCondition TaskPageCondition { get; private set; }


        /*-----------*/
        //public Dictionary<int, SysTypecodeData> CmpMethodTypeList { get; private set; }
        //public Dictionary<int, SysSubscribeData> CmpMethodTypeSelecteItems { get; private set; }

        public ObservableCollection<SysTypecodeData> CmpMethodTypeItemsSource { get; private set; }
        public ObservableCollection<SysTypecodeData> CmpMethodTypeSelectedItems { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<JobMethodData> CmpMethodList { get; set; }

        public QueryCondition WhereData { get; private set; }


        public void SelectedJobMethod(object sender, SelectionChangeEventArgs e)
        {
            RadGridView rgv = sender as RadGridView;
            var items = rgv.SelectedItems.Cast<SysTypecodeData>();
            CmpMethodTypeSelectedItems.Clear();
            foreach (var item in items)
            {
                CmpMethodTypeSelectedItems.Add(item);
            }
        }

        #region New DataStructure


        #endregion

        private void InitializeProperties()
        {
            new DataService().GetJobType(this);
            CmpMethodTypeSelectedItems = new ObservableCollection<SysTypecodeData>();
            CmpMethodList = new ObservableCollection<JobMethodData>();

            //CmpMethodTypeList = new Dictionary<int, SysTypecodeData>();
            //CmpMethodTypeList.Add(1, new SysTypecodeData { ItemValue = "计数法" });
            //CmpMethodTypeList.Add(2, new SysTypecodeData { ItemValue = "阈值法" });



            #region 页面效果，非数据源数据，固定数据源
            TaskPlan = new string[] { "永久布控", "自定义起止日期" };
            TaskTimeSpan = new string[] { "每天" };
            TaskAction = new string[] { "告警" };
            #endregion

            MonitorTaskList = new ObservableCollection<JobsData>();
            CmpStrategyList = new ObservableCollection<JobMethodData>();
            FtdbList = new ObservableCollection<FaceObjectData>();
            AreaChannelList = new ObservableCollection<AreaChannelData>();

            this.IsInEditMode = false;
            this.DataService.SearchChannel(this);
            this.DataService.SearchFtdb(this);

            this.CommandRefreshTask.Execute(null);
            this.CommandRefreshStrategy.Execute(null);

            this.MonitorTaskList.CollectionChanged += MonitorTaskList_CollectionChanged;
            this.CmpStrategyList.CollectionChanged += CmpStrategyList_CollectionChanged;

            this.TaskPageCondition = new PageCondition();

            #region  接口测试        
            //var result = DataService.QueryJobsStatistics();//通过
            //var result = DataService.QueryJobs();//通过
            //var result = DataService.QueryJobsDetail();//通过
            //var model = DataService.InsertJobs();//通过
            //var result = DataService.UpdateJobs();//通过
            //var result = DataService.DeleteJobs();//通过
            #endregion



        }

        private void CmpStrategyList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove)
            {
                int i = 1;
                foreach (var item in this.CmpStrategyList)
                {
                    item.Index = i++;
                }
            }
        }

        private void MonitorTaskList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove)
            {
                int i = 1;
                foreach (var item in this.MonitorTaskList)
                {
                    //item.Index = i++;
                }
            }
        }

        public bool HasStrategyHttpError
        {
            get
            {
                return _hasStrategyHttpError;
            }

            set
            {
                this._hasStrategyHttpError = value;
                this.RaisePropertyChanged(() => this.HasStrategyHttpError);
            }
        }

        public bool HasHttpError
        {
            get
            {
                return _hasHttpError;
            }

            set
            {
                this._hasHttpError = value;
                this.RaisePropertyChanged(() => this.HasHttpError);
            }
        }

        public bool HasValidationError
        {
            get
            {
                return _hasValidationError;
            }

            set
            {
                this._hasValidationError = value;
                this.RaisePropertyChanged(() => this.HasValidationError);
            }
        }
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                this._title = value;
                this.RaisePropertyChanged(() => this.Title);
            }
        }

        public bool IsInEditMode
        {
            get
            {
                return _isInEditMode;
            }

            set
            {
                this._isInEditMode = value;
                this.RaisePropertyChanged(() => this.IsInEditMode);
            }
        }

        public JobsData EditedTask
        {
            get
            {
                return _editedTask;
            }

            set
            {
                this._editedTask = value;
                this.RaisePropertyChanged(() => this.EditedTask);
            }
        }

        /**old CmpStrategy**/
        public JobMethodData EditedStrategy
        {
            get
            {
                return _editedStrategy;
            }

            set
            {
                this._editedStrategy = value;
                this.RaisePropertyChanged(() => this.EditedStrategy);
            }
        }

        public JobsData SelectedTask
        {
            get
            {
                return _selectedTask;
            }

            set
            {
                this._selectedTask = value;
                this.RaisePropertyChanged(() => this.SelectedTask);
            }
        }

        public JobMethodData SelectedStrategy
        {
            get
            {
                return _selectedStrategy;
            }

            set
            {
                this._selectedStrategy = value;
                this.RaisePropertyChanged(() => this.SelectedStrategy);
            }
        }


        public bool HasSelectedItems
        {
            get
            {
                return _hasSelectedItems;
            }

            set
            {
                this._hasSelectedItems = value;
                this.RaisePropertyChanged(() => this.HasSelectedItems);
            }
        }

        public string KeywordTask
        {
            get
            {
                return _keywordTask;
            }

            set
            {
                this._keywordTask = value;
                this.RaisePropertyChanged(() => this.KeywordTask);
            }
        }

        public string KeywordStrategy
        {
            get
            {
                return _keywordStrategy;
            }

            set
            {
                this._keywordStrategy = value;
                this.RaisePropertyChanged(() => this.KeywordStrategy);
            }
        }

        #endregion

        #region Commands
        public DelegateCommand<object> CommandSelectedChanged { get; private set; }

        public DelegateCommand<object> CommandAddTask { get; private set; }
        public DelegateCommand<object> CommandEditTask { get; private set; }
        public DelegateCommand<object> CommandDeleteTask { get; private set; }
        public DelegateCommand<object> CommandDetailTask { get; private set; }
        public DelegateCommand<object> CommandRefreshTask { get; private set; }
        public DelegateCommand<object> CommandOpenItemsTask { get; private set; }
        public DelegateCommand<object> CommandCloseItemsTask { get; private set; }
        public DelegateCommand<object> CommandToggleTask { get; private set; }
        public DelegateCommand<object> CommandSaveTask { get; private set; }
        public DelegateCommand<object> CommandOpenFtdbForm { get; private set; }
        public DelegateCommand<object> CommandOpenChannelForm { get; private set; }
        public DelegateCommand<object> CommandSelectedChannelForm { get; private set; }
        public DelegateCommand<object> CommandSelectedFtdbForm { get; private set; }


        public DelegateCommand<object> CommandQueryTask { get; private set; }
        public DelegateCommand<object> CommandQueryStrategy { get; private set; }
        public DelegateCommand<object> CommandAddStrategy { get; private set; }
        public DelegateCommand<object> CommandEditStrategy { get; private set; }
        public DelegateCommand<object> CommandDeleteStrategy { get; private set; }
        public DelegateCommand<object> CommandDetailStrategy { get; private set; }
        public DelegateCommand<object> CommandRefreshStrategy { get; private set; }
        public DelegateCommand<object> CommandSaveStrategy { get; private set; }
        public DelegateCommand<object> CommandOpenMethodForm { get; private set; }
        public DelegateCommand<object> CommandSelectedMethodForm { get; private set; }

        public DelegateCommand<object> CommandRemoveMethod { get; private set; }


        private void InitializeCommands()
        {
            this.CommandSelectedChanged = new DelegateCommand<object>(this.OnSelectedChangedExecuted);
            this.CommandAddTask = new DelegateCommand<object>(this.OnAddTaskExecuted);
            this.CommandEditTask = new DelegateCommand<object>(this.OnEditTaskExecuted);
            this.CommandDeleteTask = new DelegateCommand<object>(this.OnDeleteTaskExecuted);
            this.CommandDetailTask = new DelegateCommand<object>(this.OnDetailTaskExecuted);
            this.CommandRefreshTask = new DelegateCommand<object>(this.OnRefreshTaskExecuted);
            this.CommandOpenItemsTask = new DelegateCommand<object>(this.OnOpenItemsTaskExecuted);
            this.CommandCloseItemsTask = new DelegateCommand<object>(this.OnCloseItemsTaskExecuted);
            this.CommandToggleTask = new DelegateCommand<object>(this.OnToggleTaskExecuted);
            this.CommandSaveTask = new DelegateCommand<object>(this.OnSaveTaskExecuted);
            this.CommandOpenFtdbForm = new DelegateCommand<object>(this.OnOpenFtdbFormExecuted);
            this.CommandOpenChannelForm = new DelegateCommand<object>(this.OnOpenChannelFormExecuted);
            this.CommandSelectedFtdbForm = new DelegateCommand<object>(this.OnSelectedFtdbExecuted);
            this.CommandSelectedChannelForm = new DelegateCommand<object>(this.OnSelectedChannelExecuted);

            this.CommandQueryTask = new DelegateCommand<object>(this.OnQueryTaskExecuted);
            this.CommandQueryStrategy = new DelegateCommand<object>(this.OnQueryStrategyExecuted);
            this.CommandAddStrategy = new DelegateCommand<object>(this.OnAddStrategyExecuted);
            this.CommandEditStrategy = new DelegateCommand<object>(this.OnEditStrategyExecuted);
            this.CommandDeleteStrategy = new DelegateCommand<object>(this.OnDeleteStrategyExecuted);
            this.CommandDetailStrategy = new DelegateCommand<object>(this.OnDetailStrategyExecuted);
            this.CommandRefreshStrategy = new DelegateCommand<object>(this.OnRefreshStrategyExecuted);
            this.CommandSaveStrategy = new DelegateCommand<object>(this.OnSaveStrategyExecuted);
            this.CommandOpenMethodForm = new DelegateCommand<object>(this.OnOpenMethodFormExecuted);
            this.CommandSelectedMethodForm = new DelegateCommand<object>(this.OnSelectedMethodExecuted);

            this.CommandRemoveMethod = new DelegateCommand<object>(this.OnRemoveMethodExecuted);

            CommandCheckAll = new DelegateCommand<string>(ExecuteCommandCheckAll);
            CommandCancelAll = new DelegateCommand<string>(ExecuteCommandCancelAll);
            CommandChecked = new DelegateCommand<string>(ExecuteCommandChecked);
            CommandUnChecked = new DelegateCommand<string>(ExecuteCommandUnChecked);
            CommandChildChecked = new DelegateCommand<string>(ExecuteCommandChildChecked);
            CommandChildUnChecked = new DelegateCommand<string>(ExecuteCommandChildUnChecked);
        }

        private void OnRemoveMethodExecuted(object obj)
        {
            if (obj == null || this.EditedStrategy == null)
                return;

            //var select = this.EditedStrategy.CmpMethodList.FirstOrDefault(p => p.Uuid == (Guid)obj);
            //this.EditedStrategy.CmpMethodList.Remove(select);
            //int i = 1;
            //foreach (var item in this.EditedStrategy.CmpMethodList)
            //{
            //    item.Index = i;
            //    i++;
            //}
        }

        private void OnQueryTaskExecuted(object obj)
        {
            if (obj == null)
                this.KeywordTask = null;
            else
                this.KeywordTask = obj.ToString();

            this.HasHttpError = this.KeywordTask.Contains("null");

            if (!string.IsNullOrEmpty(KeywordTask))
            {
                new DataService().SearchMonitorTask(this);

                //var list = MonitorTask.MonitorTaskDatas.Where(p => p.TaskName.Contains(this.KeywordTask));
                //this.MonitorTaskList.Clear();

                //foreach (var item in list)
                //{
                //    this.MonitorTaskList.Add(item);
                //}
            }
            else
            {
                this.CommandRefreshTask.Execute(null);
            }
        }


        private void OnQueryStrategyExecuted(object obj)
        {
            if (obj == null)
                this.KeywordStrategy = null;
            else
                this.KeywordStrategy = obj.ToString();

            this.HasStrategyHttpError = this.KeywordStrategy.Contains("null");

            if (!string.IsNullOrEmpty(KeywordStrategy))
            {
                this.WhereData = new QueryCondition();
                new DataService().SearchCmpStrategy(this);
            }
            else
            {
                this.CommandRefreshStrategy.Execute(null);
            }
        }

        private void OnSelectedChangedExecuted(object obj)
        {
            bool hasSelected = false;
            if (obj != null)
            {
                var list = obj as IEnumerable<object>;
                if (list != null)
                {
                    hasSelected = list.Count() > 0;
                    var last = list.LastOrDefault();
                    if (last != null)
                    {
                        MonitorTask item = last as MonitorTask;
                        if (item != null)
                        {
                            //this.SelectedStrategy = this.CmpStrategyList.FirstOrDefault(p => p.Uuid == item.StrategyId);
                        }
                    }
                }
            }

            this.HasSelectedItems = hasSelected;
        }

        private void OnAddTaskExecuted(object obj)
        {
            try
            {
                this.EditedTask = new JobsData();
                myEditTaskForm = new Views.EditTaskForm(this, DataMode.Add);
                myEditTaskForm.ShowDialog();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void OnEditTaskExecuted(object obj)
        {
            this.EditedTask = this.MonitorTaskList.FirstOrDefault(x => x.Uuid == obj.ToString());

            myEditTaskForm = new Views.EditTaskForm(this, DataMode.Edit);
            myEditTaskForm.ShowDialog();
        }

        /// <summary>
        /// Delete Task
        /// </summary>
        /// <param name="obj"></param>
        private void OnDeleteTaskExecuted(object obj)
        {
            if (obj != null)
            {
                var item = this.MonitorTaskList.FirstOrDefault(x => x.Uuid == obj.ToString());
                if (item != null)
                {
                    if (item.State != 0)
                    {
                        MessageBoxHelper.Show("该布控任务没有关闭，无法删除");
                        return;
                    }
                    if (MessageBoxHelper.ConfirmMessage(string.Format("确定删除布控任务【{0}】？", item.Name)))
                    {
                        //删除任务
                        this.WhereData = new QueryCondition();
                        this.WhereData.UuidArray = new string[] { obj.ToString() };
                        new DataService().DeleteMonitorTask(this);
                        this.MonitorTaskList.Remove(item);

                        //跟新策略关联布控任务数量
                        //var oldStrategy = this.CmpStrategyList.FirstOrDefault(p => p.Uuid == item.StrategyId);
                        //this.UpdateTaskListByStrategy(oldStrategy, this.MonitorTaskList);
                        //}
                        this.CommandRefreshStrategy.Execute(null);//刷新策略列表，更新关联任务数量
                    }
                }
                //this.CommandRefreshTask.Execute(null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void OnDetailTaskExecuted(object obj)
        {
            //if (obj == null)
            //    return;
            //this.SelectedTask = this.MonitorTaskList.FirstOrDefault(p => p.Uuid == (Guid)obj);
            //this.EditedTask = this.SelectedTask.Clone() as MonitorTask;
            //myEditTaskForm = new Views.EditTaskForm(this, DataMode.Edit);
            //myEditTaskForm.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void OnRefreshTaskExecuted(object obj)
        {
            //布控任务列表
            DataService ds = new Services.DataService();
            ds.SearchMonitorTask(this);
            this.KeywordTask = "";
            this.HasHttpError = false;
            this.HasStrategyHttpError = false;
        }
        private void OnOpenItemsTaskExecuted(object obj)
        {
            if (obj == null) return;

            var list = obj as IEnumerable<object>;
            if (MessageBoxHelper.ConfirmMessage(string.Format("您是否确认启动选择的任务?")))
            {
                foreach (MonitorTask item in list)
                {
                    item.TaskStatus = 1;
                    item.IsChecked = false;
                }
                this.FireUnSelectedAll();
            }
        }
        private void OnCloseItemsTaskExecuted(object obj)
        {
            if (obj == null) return;

            var list = obj as IEnumerable<object>;
            if (MessageBoxHelper.ConfirmMessage(string.Format("您是否确认关闭选择的任务?")))
            {
                foreach (MonitorTask item in list)
                {
                    item.TaskStatus = 0;
                    item.IsChecked = false;
                }
                this.FireUnSelectedAll();
            }
        }
        private void OnToggleTaskExecuted(object obj)
        {
            //if (obj == null) return;
            //var task = this.MonitorTaskList.FirstOrDefault(p => p.Uuid == (Guid)obj);
            //if (task != null)
            //{
            //    if (task.TaskStatus == 1 || task.TaskStatus == 2)
            //    {
            //        if (MessageBoxHelper.ConfirmMessage(string.Format("您是否确认关闭【{0}】任务?", task.TaskName)))
            //        {
            //            task.TaskStatus = 0;
            //        }
            //    }
            //    else
            //    {
            //        if (MessageBoxHelper.ConfirmMessage(string.Format("您是否确认启动【{0}】任务?", task.TaskName)))
            //        {
            //            task.TaskStatus = 1;
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Insert New Task Data
        /// </summary>
        /// <param name="obj"></param>
        private void OnSaveTaskExecuted(object obj)
        {
            new JobsService().Insert(this);

            //if (string.IsNullOrEmpty(this.EditedTask.TaskName) || this.SelectedStrategy == null || this.EditedTask.SelectedFtdbList.Count == 0 || this.EditedTask.SelectedAreaChannelList.Count == 0)
            //{
            //    this.HasValidationError = true;
            //    return;
            //}

            //// 目标人数 布控通道数 布控时段( 2017 - 6 - 15~2017 - 6 - 16 每天8: 00 - 18:30)
            //this.EditedTask.TargetCount = this.EditedTask.SelectedFtdbList.Count * 1000;
            //this.EditedTask.ChannelCount = this.EditedTask.SelectedAreaChannelList.Count * 1000;
            //var dateStr = this.EditedTask.TaskPlanId == 0 ? "" : this.EditedTask.CustomStartDate.ToString("yyyy-MM-dd") + "~" + this.EditedTask.CustomEndDate.ToString("yyyy-MM-dd");
            //var spanType = this.EditedTask.TaskTimeSpanId == 0 ? "每天" : "";
            //var timeSpan = this.EditedTask.SpanStartTime + "-" + this.EditedTask.SpanEndTime;
            //this.EditedTask.TaskSpan = dateStr + spanType + timeSpan;

            //if (myEditTaskForm.CurrentMode == DataMode.Add)
            //{
            //    this.CommandRefreshTask.Execute(null);
            //    this.SelectedTask = (MonitorTask)this.EditedTask.Clone();
            //    this.MonitorTaskList.Insert(0, this.SelectedTask);
            //}
            //else
            //{
            //    this.SelectedTask.CopyValue(this.EditedTask);
            //}

            ////策略关联布控任务
            //var oldStrategy = this.CmpStrategyList.FirstOrDefault(p => p.Uuid == this.EditedTask.StrategyId);
            //var newStrategy = this.SelectedStrategy;
            //this.SelectedTask.StrategyId = this.SelectedStrategy.Uuid;
            //this.UpdateTaskListByStrategy(oldStrategy, this.MonitorTaskList);
            //this.UpdateTaskListByStrategy(newStrategy, this.MonitorTaskList);

            myEditTaskForm.Close();
            this.CommandRefreshTask.Execute(null);
        }

        #region --Obsolete
        //private void UpdateTaskListByStrategy(CmpStrategy entity, IList<MonitorTask> datas)
        //{
        //    if (entity == null) return;

        //    var withTask = datas.Where(p => p.StrategyId == entity.Uuid);
        //    entity.TaskList.Clear();
        //    foreach (var item in withTask)
        //    {
        //        entity.TaskList.Add(item);
        //    }
        //    entity.TaskCount = entity.TaskList.Count;
        //}
        #endregion

        private void OnOpenFtdbFormExecuted(object obj)
        {
            mySelectFtdbForm = new Views.SelectFtdbForm(this);
            mySelectFtdbForm.ShowDialog();
        }
        private void OnOpenChannelFormExecuted(object obj)
        {
            //mySelectChannelForm = new Views.SelectChannelForm(this);
            //mySelectChannelForm.ShowDialog();

            _areaChannelForm = new AreaChannelForm(this);
            _areaChannelForm.Show();
        }
        private void OnSelectedFtdbExecuted(object obj)
        {
            //var list = obj as IList<object>;
            //this.EditedTask.SelectedFtdbList.Clear();
            //foreach (FaceTemplateDBData item in list)
            //{
            //    this.EditedTask.SelectedFtdbList.Add(item);
            //}
            //this.mySelectFtdbForm.Close();
            //this.HasValidationError = false;
        }
        private void OnSelectedChannelExecuted(object obj)
        {
            //var list = this.AreaChannelList.Where(p => p.IsChecked);
            //this.EditedTask.SelectedAreaChannelList.Clear();
            //foreach (var item in list)
            //{
            //    this.EditedTask.SelectedAreaChannelList.Add(item);
            //}
            //this._areaChannelForm.Close();
            //this.HasValidationError = false;
        }

        private void OnAddStrategyExecuted(object obj)
        {
            try
            {
                this.EditedStrategy = new JobMethodData();
                //this.EditedStrategy.Index = CmpStrategy.CmpStrategyDatas.Max(p => p.Index) + 1;
                this.EditedStrategy.Uuid = Guid.NewGuid().ToString();

                myEditStrategyForm = new Views.EditStrategyForm(this, DataMode.Add);
                myEditStrategyForm.ShowDialog();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }
        private void OnEditStrategyExecuted(object obj)
        {
            //this.SelectedStrategy = this.CmpStrategyList.FirstOrDefault(p => p.Uuid == obj.ToString());
            //this.EditedStrategy = this.SelectedStrategy.Clone() as JobMethodData;
            this.EditedStrategy = this.CmpStrategyList.FirstOrDefault(p => p.Uuid == obj.ToString());

            myEditStrategyForm = new Views.EditStrategyForm(this, DataMode.Edit);
            myEditStrategyForm.ShowDialog();
        }
        private void OnDeleteStrategyExecuted(object obj)
        {
            if (obj != null)
            {
                var item = this.CmpStrategyList.FirstOrDefault(p => p.Uuid == obj.ToString());
                if (item != null)
                {
                    //if (item.Uuid == 1)
                    //{
                    //    MessageBoxHelper.Show("系统初始比对策略不允许删除");
                    //    return;
                    //}

                    //if (item.TaskList.Count > 0)
                    //{
                    //    MessageBoxHelper.Show("该比对策略正在被使用，无法删除");
                    //    return;
                    //}

                    //if (MessageBoxHelper.ConfirmMessage(string.Format("您是否确认删除【{0}】策略?", item.StrategyName)))
                    //{
                    //    this.CmpStrategyList.Remove(item);
                    //}
                }
            }
        }
        private void OnDetailStrategyExecuted(object obj)
        {
            //this.SelectedStrategy = this.CmpStrategyList.FirstOrDefault(p => p.Uuid == obj.ToString());
            //this.EditedStrategy = this.SelectedStrategy.Clone() as JobMethodData;

            this.EditedStrategy = this.CmpStrategyList.FirstOrDefault(p => p.Uuid == obj.ToString());

            myEditStrategyForm = new Views.EditStrategyForm(this, DataMode.Edit);
            myEditStrategyForm.ShowDialog();
        }
        private void OnRefreshStrategyExecuted(object obj)
        {
            new DataService().SearchCmpStrategy(this);
            //CmpStrategy.RefreshDatas();
            //this.CmpStrategyList.Clear();
            //foreach (var item in CmpStrategy.CmpStrategyDatas)
            //{
            //    this.CmpStrategyList.Add(item);
            //}
            this.KeywordStrategy = "";
            this.HasStrategyHttpError = false;
            this.HasHttpError = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void OnSaveStrategyExecuted(object obj)
        {
            //if (string.IsNullOrEmpty(this.EditedStrategy.Name) || this.EditedStrategy.CmpMethodList.Count == 0)
            //{
            //    this.HasValidationError = true;
            //    return;
            //}

            //this.EditedStrategy.CmpMethodString = this.EditedStrategy.GetMethodString();
            //if (myEditStrategyForm.CurrentMode == DataMode.Add)
            //{
            //    this.CommandRefreshStrategy.Execute(null);
            //    this.SelectedStrategy = (CmpStrategy)this.EditedStrategy.Clone();
            //    this.CmpStrategyList.Insert(0, this.SelectedStrategy);

            //}
            //else
            //{
            //    this.SelectedStrategy.CopyValue(this.EditedStrategy);
            //}

            //myEditStrategyForm.Close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void OnOpenMethodFormExecuted(object obj)
        {
            new DataService().GetJobMethodName(this);

            //this.EditedStrategy.CmpMethodTypeList.Clear();
            //foreach (var item in CmpMethodType.MethodTypeList)
            //{
            //    var exist = this.EditedStrategy.CmpMethodList.FirstOrDefault(p => p.MethodType == item.TypeId);
            //    if (exist == null)
            //    {
            //        this.EditedStrategy.CmpMethodTypeList.Add(item);
            //    }
            //}

            mySelectMethodForm = new Views.SelectMethodForm(this);
            mySelectMethodForm.ShowDialog();
        }

        private void OnSelectedMethodExecuted(object obj)
        {
            this.HasValidationError = false;
            this.mySelectMethodForm.Close();
            if (this.EditedStrategy == null) return;

            CmpMethodList.Clear();
            foreach (var item in CmpMethodTypeSelectedItems)
            {
                CmpMethodList.Add(new JobMethodData()
                {

                });
            }
            CmpMethodList.Clear();
            CmpMethodList.Add(new JobMethodData()
            {

            });

            this.CmpMethodTypeItemsSource.Clear();

            //this.EditedStrategy.CmpMethodList.Clear();
            //var list = this.EditedStrategy.CmpMethodTypeList;
            //foreach (CmpMethodType item in list)
            //{
            //    if (item.IsChecked)
            //    {
            //        this.EditedStrategy.CmpMethodList.Add(CmpMethod.GetMethod(this.EditedStrategy.Uuid, item.TypeId, 0));
            //    }
            //}
            //int i = 1;
            //foreach (var item in this.EditedStrategy.CmpMethodList)
            //{
            //    item.Index = i;
            //    i++;
            //}

            //this.EditedStrategy.CmpMethodString = this.EditedStrategy.GetMethodString();
        }

        #region 通道选择
        public DelegateCommand<string> CommandCheckAll { get; private set; }

        private void ExecuteCommandCheckAll(string para)
        {
            try
            {
                if (para == "0")
                {
                    foreach (var item in this.MonitorTaskList)
                    {
                        // item.IsChecked = true; //codestacks
                    }
                }
                else if (para == "1")
                {
                    //foreach (var item in this.TarLibraryList)
                    //{
                    //    item.IsChecked = true;
                    //    foreach (var itemChild in item.TarLibChildList)
                    //    {
                    //        itemChild.IsChecked = true;
                    //    }
                    //}
                }
                else if (para == "2")
                {
                    foreach (var item in this.AreaChannelList)
                    {
                        item.IsChecked = true;
                        foreach (var itemChild in item.AreaChannelChildList)
                        {
                            itemChild.IsChecked = true;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        public DelegateCommand<string> CommandCancelAll { get; private set; }

        private void ExecuteCommandCancelAll(string para)
        {
            try
            {
                if (para == "0")
                {
                    foreach (var item in this.MonitorTaskList)
                    {
                        //item.IsChecked = false;//codestacks
                    }
                }
                else if (para == "1")
                {
                    //foreach (var item in this.TarLibraryList)
                    //{
                    //    item.IsChecked = false;
                    //    foreach (var itemChild in item.TarLibChildList)
                    //    {
                    //        itemChild.IsChecked = false;
                    //    }
                    //}
                }
                else if (para == "2")
                {
                    foreach (var item in this.AreaChannelList)
                    {
                        item.IsChecked = false;
                        foreach (var itemChild in item.AreaChannelChildList)
                        {
                            itemChild.IsChecked = false;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        public DelegateCommand<string> CommandChecked { get; private set; }

        private void ExecuteCommandChecked(string para)
        {
            try
            {
                if (para == "1")
                {
                    //foreach (var item in this.TarLibraryList)
                    //{
                    //    if (item.IsChecked == true)
                    //    {
                    //        foreach (var itemChild in item.TarLibChildList)
                    //        {
                    //            itemChild.IsChecked = true;
                    //        }
                    //    }
                    //}
                }
                else if (para == "2")
                {
                    foreach (var item in this.AreaChannelList)
                    {
                        if (item.IsChecked == true)
                        {
                            foreach (var itemChild in item.AreaChannelChildList)
                            {
                                itemChild.IsChecked = true;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        public DelegateCommand<string> CommandUnChecked { get; private set; }

        private void ExecuteCommandUnChecked(string para)
        {
            try
            {
                if (para == "1")
                {
                    //foreach (var item in this.TarLibraryList)
                    //{
                    //    if (item.IsChecked == false)
                    //    {
                    //        foreach (var itemChild in item.TarLibChildList)
                    //        {
                    //            itemChild.IsChecked = false;
                    //        }
                    //    }
                    //}
                }
                else if (para == "2")
                {
                    foreach (var item in this.AreaChannelList)
                    {
                        if (item.IsChecked == false)
                        {
                            foreach (var itemChild in item.AreaChannelChildList)
                            {
                                itemChild.IsChecked = false;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        public DelegateCommand<string> CommandChildChecked { get; private set; }

        private void ExecuteCommandChildChecked(string para)
        {
            try
            {
                if (para == "1")
                {
                    //foreach (var item in this.TarLibraryList)
                    //{
                    //    if (item.TarLibChildList.ToList().FindAll(p => p.IsChecked == true).Count() == item.TarLibChildList.Count())
                    //    {
                    //        item.IsChecked = true;
                    //    }
                    //}
                }
                else if (para == "2")
                {
                    foreach (var item in this.AreaChannelList)
                    {
                        if (item.AreaChannelChildList.ToList().FindAll(p => p.IsChecked == true).Count() == item.AreaChannelChildList.Count())
                        {
                            item.IsChecked = true;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        public DelegateCommand<string> CommandChildUnChecked { get; private set; }



        private void ExecuteCommandChildUnChecked(string para)
        {
            try
            {
                if (para == "1")
                {
                    //foreach (var item in this.TarLibraryList)
                    //{
                    //    if (item.TarLibChildList.ToList().FindAll(p => p.IsChecked == false).Any())
                    //    {
                    //        item.IsChecked = false;
                    //    }
                    //}
                }
                else if (para == "2")
                {
                    foreach (var item in this.AreaChannelList)
                    {
                        if (item.AreaChannelChildList.ToList().FindAll(p => p.IsChecked == false).Any())
                        {
                            item.IsChecked = false;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        #endregion
        private void FireUnSelectedAll()
        {
            if (this.UnSelectedAll != null)
                this.UnSelectedAll(this, null);
        }

        #endregion

        #region INavigationAware Members
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            // Called to see if this view can handle the navigation request.
            // If it can, this view is activated.
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // Called when this view is deactivated as a result of navigation to another view.
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // Called to initialize this view during navigation.

            // Retrieve any required paramaters from the navigation Uri.
            string id = navigationContext.Parameters["ID"];

        }
        #endregion

    }

}
