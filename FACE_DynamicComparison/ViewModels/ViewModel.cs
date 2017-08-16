using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Data;
using FACE_DynamicComparison.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.ServiceLocation;
using SING.Data.DAL.Data;
using SING.Data.Help;
using Sofa.Commons;
using Sofa.Container;
using SING.Data.DAL.ScheduleConvert;
using SING.Infrastructure.Helper;
using SING.Infrastructure.Events;
using System.Windows;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Win32;
using SING.Data.DAL;
using SING.Data.Logger;
using SING.Data.BaseTools;
using System.Collections.ObjectModel;
using System.IO;
using SING.Data.Controls.TreeControl.Models;
using FACE_DynamicComparison.Models;
using FACE_DynamicComparison.Views;
using SING.Data.DAL.NewCode.Data;

namespace FACE_DynamicComparison.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ViewModel : INotifyPropertyChanged, INavigationAware
    {
        public readonly IDataService _dataService;
        public readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;
        private readonly IServiceLocator _serviceLocator;

        [ImportingConstructor]
        public ViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.VM = this;
            Initialize();
        }

        private void Initialize()
        {
            InitializeCommand();
            _capCmpList = new ObservableCollection<AlertData>();
            _CurrentItem = new AlertData();
            _capList = new ObservableCollection<AlarmPromptData>();
            _treeItems = new ObservableCollection<DataItem>();
            _currentTreeItem = new DataItem();
            _TaskReports = new ObservableCollection<JobsData>();
            _currentReports = new JobsData();
            _Persons = new ObservableCollection<MonitorTaskReportsModel>();
            _Alerts = new ObservableCollection<MonitorTaskReportsModel>();
            _Alarms = new ObservableCollection<MonitorTaskReportsModel>();
            _dataService.GenarateCmpData();
            _dataService.GenarateCapData();
            _dataService.GenarateTaskData();
            _dataService.LoadTree();
         
            try
            {
                var vm = this;

                var resultPublishCount = vm._dataService.GetPublishCount();
                var resultAlertCount = vm._dataService.GetAlertCount();
                var resultUncheckedCount = vm._dataService.GetUncheckedCount();
                var resultStatisticalCount = vm._dataService.FindStatisticalCount();
                var resultCapState = vm._dataService.QueryCapState();
                var resultComState = vm._dataService.QueryComState();
                var resultMethodeState = vm._dataService.QueryMethodeState();

                var resultSubscribeSec = vm._dataService.SubscribeSec();
                var resultUnSubscribeSec = vm._dataService.UnSubscribeSec();
                var resultSubscribeOriginal = vm._dataService.SubscribeOriginal();
                var resultUnSubscribeOriginal = vm._dataService.UnSubscribeOriginal();

                var resultAlertDetail = vm._dataService.GetAlertDetail();
                var resultNewestAlerts = vm._dataService.QueryNewestAlerts();
                var resultCheckAlert = vm._dataService.ReCheckAlert();
              
                var resultJobs = vm._dataService.QueryJobs();
                var resultUser = vm._dataService.Login();
                var resultStatistics = vm._dataService.CheckedStatistics();

            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
            }
          
        }

        private void InitializeCommand()
        {
            CommandShowWindow = new DelegateCommand<object>(ExecuteCommandShowWindow, CanCommandShowWindow);
            CommandTabSwich = new DelegateCommand<object>(ExecuteCommandTabSwich, CanCommandTabSwich);
            CommandTaskMonitor = new DelegateCommand<object>(ExecuteCommandTaskMonitor, CanCommandTaskMonitor);
            CommandStrategy = new DelegateCommand<object>(ExecuteCommandStrategy, CanCommandStrategy);
            CommandRealVidePlay = new DelegateCommand<object>(ExecuteCommandRealVidePlay, CanCommandRealVidePlay);
            CommandPrevious = new DelegateCommand<object>(ExecuteCommandPrevious);
            CommandPush = new DelegateCommand<object>(ExecuteCommandPush);
            CommandIdentifyTar = new DelegateCommand<object>(ExecuteCommandIdentifyTar);
            CommandExcludeAll = new DelegateCommand<object>(ExecuteCommandExcludeAll);
            CommandBehind = new DelegateCommand<object>(ExecuteCommandBehind);
            CommandEditFot = new DelegateCommand<object>(ExecuteCommandEditFot);
            CommandAgainReview = new DelegateCommand(ExecuteCommandAgainReview);
            CommandMouseWheel = new DelegateCommand<object>(ExecuteCommandMouseWheel);
            CommandExportScenario = new DelegateCommand(ExecuteCommandExportScenario);
            CommandExportVideo = new DelegateCommand(ExecuteCommandExportVideo);
        }

        #region  Propertys
        #region  TabControl

        private int _SelectedTabValue;
        public int SelectedTabValue
        {
            get
            {
                return _SelectedTabValue;
            }

            set
            {
                _SelectedTabValue = value;
                OnPropertyChanged("SelectedTabValue");
            }
        }

        private int _SelectedTabIndex;
        public int SelectedTabIndex
        {
            get
            {
                return _SelectedTabIndex;
            }

            set
            {
                _SelectedTabIndex = value;
                OnPropertyChanged("SelectedTabIndex");
            }
        }

        #region  布控任务/区域通道 搜索按钮是否可见
        private Visibility _TaskSearchVisibity = Visibility.Collapsed;
        public Visibility TaskSearchVisibity
        {
            get
            {
                return _TaskSearchVisibity;
            }

            set
            {
                _TaskSearchVisibity = value;
                OnPropertyChanged("TaskSearchVisibity");
            }
        }
        private Visibility _RegionVisibity = Visibility.Collapsed;
        public Visibility RegionVisibity
        {
            get
            {
                return _RegionVisibity;
            }

            set
            {
                _RegionVisibity = value;
                OnPropertyChanged("RegionVisibity");
            }
        }
        #endregion
        #endregion

        #region 目标预警

        private int _UnCheckCount = 1;
        public int UnCheckCount
        {
            get
            {
                return _UnCheckCount;
            }

            set
            {
                _UnCheckCount = value;
                OnPropertyChanged("UnCheckCount");
            }
        }

        private int _PushedCount = 10000;
        public int PushedCount
        {
            get
            {
                return _PushedCount;
            }

            set
            {
                _PushedCount = value;
                OnPropertyChanged("PushedCount");
            }
        }

        private int _AlertedCount = 10092;
        public int AlertedCount
        {
            get
            {
                return _AlertedCount;
            }

            set
            {
                _AlertedCount = value;
                OnPropertyChanged("AlertedCount");
            }
        }

        private int _PersonCount = 10299100;
        public int PersonCount
        {
            get
            {
                return _PersonCount;
            }

            set
            {
                _PersonCount = value;
                OnPropertyChanged("PersonCount");
            }
        }

        private ObservableCollection<AlertData> _capCmpList;
        public ObservableCollection<AlertData> CapCmpList
        {
            get
            {
                return _capCmpList;
            }

            set
            {
                _capCmpList = value;
            }
        }

        private AlertData _CurrentItem;
        public AlertData CurrentItem
        {
            get
            {
                return _CurrentItem;
            }

            set
            {
                if (value != null)
                {
                    _CurrentItem = value;
                    SelectedTabValue = 0;
                    OnPropertyChanged("CurrentItem");

                    var result = _dataService.QueryCapImg();
                    if (result != null)
                    {
                        CurrentItem.FcapSceneImg = result.FcapSceneImg;
                        CurrentItem.FcapFaceCx = result.FcapFaceCx;
                        CurrentItem.FcapFaceCy = result.FcapFaceCy;
                        CurrentItem.FcapFaceX = result.FcapFaceX;
                        CurrentItem.FcapFaceY = result.FcapFaceY;
                    }
                }
            }
        }
        #endregion

        #region  拍摄预览
        private ObservableCollection<AlarmPromptData> _capList;
        public ObservableCollection<AlarmPromptData> CapList
        {
            get
            {
                return _capList;
            }

            set
            {
                _capList = value;
            }
        }
        #endregion

        #region  区域通道树
        private ObservableCollection<DataItem> _treeItems;
        public ObservableCollection<DataItem> TreeItems
        {
            get
            {
                return _treeItems;
            }

            set
            {
                _treeItems = value;
            }
        }
        private DataItem _currentTreeItem;
        public DataItem CurrentTreeItem
        {
            get
            {
                return _currentTreeItem;
            }

            set
            {
                _currentTreeItem = value;
                SelectedTabValue = 2;
                OnPropertyChanged("CurrentTreeItem");
            }
        }
        #endregion

        #region  布控任务统计

        private ObservableCollection<JobsData> _TaskReports;
        public ObservableCollection<JobsData> TaskReports
        {
            get
            {
                return _TaskReports;
            }

            set
            {
                _TaskReports = value;
                OnPropertyChanged("CurrentTreeItem");
            }
        }

        private JobsData _currentReports;
        public JobsData CurrentReports
        {
            get
            {
                return _currentReports;
            }
            set
            {
                _currentReports = value;
                OnPropertyChanged("CurrentReports");
                if (value != null)
                {
                    this.SelectedTabValue = 1;
                    this._dataService.GenarateReportData();
                }
            }
        }

        private ObservableCollection<MonitorTaskReportsModel> _Persons;
        public ObservableCollection<MonitorTaskReportsModel> Persons
        {
            get
            {
                return _Persons;
            }

            set
            {
                _Persons = value;
                OnPropertyChanged("Persons");
            }
        }

        private ObservableCollection<MonitorTaskReportsModel> _Alerts;
        public ObservableCollection<MonitorTaskReportsModel> Alerts
        {
            get
            {
                return _Alerts;
            }

            set
            {
                _Alerts = value;
                OnPropertyChanged("Alerts");
            }
        }

        private ObservableCollection<MonitorTaskReportsModel> _Alarms;
        public ObservableCollection<MonitorTaskReportsModel> Alarms
        {
            get
            {
                return _Alarms;
            }

            set
            {
                _Alarms = value;
                OnPropertyChanged("Alarms");
            }
        }
        #endregion

        #region 视频
        private bool _IsFlowlayer = true;
        public bool IsFlowlayer
        {
            get
            {
                return _IsFlowlayer;
            }

            set
            {
                _IsFlowlayer = value;
                OnPropertyChanged("IsFlowlayer");
            }
        }
        #endregion

        #region 比对图
        private Visibility _defaultVisible = Visibility.Visible;
        public Visibility DefaultVisible
        {
            get
            {
                return _defaultVisible;
            }

            set
            {
                _defaultVisible = value;
                OnPropertyChanged("DefaultVisible");
            }
        }

        private Visibility _confirmExcludVisible = Visibility.Hidden;
        public Visibility ConfirmExcludVisible
        {
            get
            {
                return _confirmExcludVisible;
            }

            set
            {
                _confirmExcludVisible = value;
                OnPropertyChanged("ConfirmExcludVisible");
            }
        }

        private Visibility _pushedVisible = Visibility.Hidden;
        public Visibility PushedVisible
        {
            get
            {
                return _pushedVisible;
            }

            set
            {
                _pushedVisible = value;
                OnPropertyChanged("PushedVisible");
            }
        }

        private Visibility _pushBtnVisible = Visibility.Visible;
        public Visibility PushBtnVisible
        {
            get
            {
                return _pushBtnVisible;
            }

            set
            {
                _pushBtnVisible = value;
                OnPropertyChanged("PushBtnVisible");
            }
        }

        private Visibility _centerBtnVisible = Visibility.Visible;
        public Visibility CenterBtnVisible
        {
            get
            {
                return _centerBtnVisible;
            }

            set
            {
                _centerBtnVisible = value;
                OnPropertyChanged("CenterBtnVisible");
            }
        }

        private Visibility _tagBtnVisible = Visibility.Hidden;
        public Visibility TagBtnVisible
        {
            get
            {
                return _tagBtnVisible;
            }

            set
            {
                _tagBtnVisible = value;
                OnPropertyChanged("TagBtnVisible");
            }
        }

        private AlarmPromptData _faceCapData = new AlarmPromptData();
        public AlarmPromptData FaceCapData
        {
            get
            {
                return _faceCapData;
            }

            set
            {
                _faceCapData = value;
                OnPropertyChanged("FaceCapData");
            }
        }

        private AlarmPromptData _curFaceCapData = new AlarmPromptData();
        public AlarmPromptData CurFaceCapData
        {
            get
            {
                return _curFaceCapData;
            }

            set
            {
                _curFaceCapData = value;
                OnPropertyChanged("CurFaceCapData");
            }
        }

        private string _btnPushContent = "推送";
        public string BtnPushContent
        {
            get
            {
                return _btnPushContent;
            }

            set
            {
                _btnPushContent = value;
                OnPropertyChanged("BtnPushContent");
            }
        }

        private string _tagBtnContent = "✔此目标已确认";
        public string TagBtnContent
        {
            get
            {
                return _tagBtnContent;
            }

            set
            {
                _tagBtnContent = value;
                OnPropertyChanged("TagBtnContent");
            }
        }

        private bool _pushBtnIsEnabled = false;
        public bool PushBtnIsEnabled
        {
            get
            {
                return _pushBtnIsEnabled;
            }

            set
            {
                _pushBtnIsEnabled = value;
                OnPropertyChanged("PushBtnIsEnabled");
            }
        }
        #endregion
        #endregion

        #region   Command
        #region  搜索按钮
        public DelegateCommand<object> CommandTabSwich { get; set; }
        private void ExecuteCommandTabSwich(object commandParameter)
        {
            if (SelectedTabIndex == 0)
            {
                if (TaskSearchVisibity == Visibility.Visible)
                    TaskSearchVisibity = Visibility.Collapsed;
                else
                    TaskSearchVisibity = Visibility.Visible;
            }
            else
            {
                if (RegionVisibity == Visibility.Visible)
                    RegionVisibity = Visibility.Collapsed;
                else
                    RegionVisibity = Visibility.Visible;
            }
        }
        private bool CanCommandTabSwich(object commandParameter)
        {
            return true;
        }
        #endregion

        public DelegateCommand<object> CommandPrevious { get; private set; }
        private void ExecuteCommandPrevious(object para)
        {
            try
            {
                CurFaceCapData = CapList[FaceCapData.FcapId - 1];
                FaceCapData = CapList[FaceCapData.FcapId - 1];
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand<object> CommandPush { get; private set; }
        private void ExecuteCommandPush(object para)
        {
            try
            {
                BtnPushContent = "已推送";
                PushBtnIsEnabled = false;
                DefaultVisible = Visibility.Hidden;
                ConfirmExcludVisible = Visibility.Hidden;
                PushedVisible = Visibility.Visible;
                TagBtnVisible = Visibility.Visible;
                TagBtnContent = "✔目标已确认";
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand<object> CommandIdentifyTar { get; private set; }
        private void ExecuteCommandIdentifyTar(object para)
        {
            try
            {
                PushBtnIsEnabled = true;
                CenterBtnVisible = Visibility.Hidden;
                DefaultVisible = Visibility.Hidden;
                ConfirmExcludVisible = Visibility.Visible;
                PushedVisible = Visibility.Hidden;
                TagBtnVisible = Visibility.Visible;
                TagBtnContent = "✔此目标已确认";
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand<object> CommandExcludeAll { get; private set; }
        private void ExecuteCommandExcludeAll(object para)
        {
            try
            {
                PushBtnVisible = Visibility.Hidden;
                CenterBtnVisible = Visibility.Hidden;
                DefaultVisible = Visibility.Hidden;
                ConfirmExcludVisible = Visibility.Visible;
                PushedVisible = Visibility.Hidden;
                TagBtnVisible = Visibility.Visible;
                TagBtnContent = "✖目标已排除";
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand<object> CommandBehind { get; private set; }

        private void ExecuteCommandBehind(object para)
        {
            try
            {
                CurFaceCapData = CapList[FaceCapData.FcapId + 1];
                FaceCapData = CapList[FaceCapData.FcapId + 1];
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand<object> CommandEditFot { get; private set; }

        private void ExecuteCommandEditFot(object para)
        {
            try
            {
                if (FaceCapData != null)
                {
                    CurFaceCapData = FaceCapData;
                    CurFaceCapData.FcmpSocre = CurFaceCapData.FcmpSocre.Trim('✔');
                }
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand<object> CommandMouseWheel { get; private set; }

        private void ExecuteCommandMouseWheel(object para)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand CommandAgainReview { get; private set; }

        private void ExecuteCommandAgainReview()
        {
            try
            {
                PushBtnIsEnabled = false;
                CenterBtnVisible = Visibility.Visible;
                DefaultVisible = Visibility.Hidden;
                ConfirmExcludVisible = Visibility.Visible;
                PushedVisible = Visibility.Hidden;
                TagBtnVisible = Visibility.Visible;
                TagBtnContent = "✔此目标已确认";
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand CommandExportScenario { get; private set; }
        private void ExecuteCommandExportScenario()
        {
            try
            {
                string imgstr1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"img\u2770.jpg");
                byte[] buffer1 = ImageConvert.PathToBinaryStream(imgstr1);

                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Multiselect = false;
                fileDialog.Title = "保存场景图";
                fileDialog.Filter = "jpg|*.jpg|bmp|*.bmp|png|*.png|gif|*gif|icon|*icon";
                if (fileDialog.ShowDialog() == true)
                {
                    string FilePath = fileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand CommandExportVideo { get; private set; }
        private void ExecuteCommandExportVideo()
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Multiselect = false;
                fileDialog.Title = "保存视频";
                fileDialog.Filter = ".mov|*.avi|bmp|*.bmp|png|*.png|gif|*gif|icon|*icon";
                if (fileDialog.ShowDialog() == true)
                {
                }
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public AlertInfoForm _AlertInfoPusher;
        private EditStrategyForm myEditStrategyForm;
        private EditTaskForm myEditTaskForm;
        #region  告警弹窗
        public DelegateCommand<object> CommandShowWindow { get; set; }

        private void ExecuteCommandShowWindow(object commandParameter)
        {
            #region  告警/报警弹窗
            if (_AlertInfoPusher != null)
            {
                if (!AlertInfoForm.FormIsOpen)
                {
                    _AlertInfoPusher = new AlertInfoForm(this);
                    _AlertInfoPusher.Show();
                }
                else
                {
                    _AlertInfoPusher.Focus();
                }
            }
            else
            {
                _AlertInfoPusher = new AlertInfoForm(this);
                _AlertInfoPusher.Show();
            }

            PushBtnIsEnabled = true;
            CenterBtnVisible = Visibility.Hidden;
            DefaultVisible = Visibility.Hidden;
            ConfirmExcludVisible = Visibility.Visible;
            PushedVisible = Visibility.Hidden;
            TagBtnVisible = Visibility.Visible;
            TagBtnContent = "✔此目标已确认";
            #endregion
        }
        private bool CanCommandShowWindow(object commandParameter)
        {
            return true;
        }
        #endregion

        #region  任务弹窗
        public DelegateCommand<object> CommandTaskMonitor { get; set; }

        private void ExecuteCommandTaskMonitor(object commandParameter)
        {
            #region  告警/报警弹窗
            myEditTaskForm = new EditTaskForm(this, DataMode.Edit);
            myEditTaskForm.Show();
            #endregion
        }
        private bool CanCommandTaskMonitor(object commandParameter)
        {
            return true;
        }
        #endregion

        #region  比对策略弹窗
        public DelegateCommand<object> CommandStrategy { get; set; }

        private void ExecuteCommandStrategy(object commandParameter)
        {
            myEditStrategyForm = new EditStrategyForm(this, DataMode.Edit);
            myEditStrategyForm.Show();
        }
        private bool CanCommandStrategy(object commandParameter)
        {
            return true;
        }
        #endregion

        #region  消息订阅
        #region  告警订阅
        public DelegateCommand<object> CommandAlertSubscribe { get; set; }

        private void ExecuteCommandAlertSubscribe(object commandParameter)
        {
            myEditStrategyForm = new EditStrategyForm(this, DataMode.Edit);
            myEditStrategyForm.Show();
        }
        private bool CanCommandAlertSubscribe(object commandParameter)
        {
            return true;
        }
        #endregion
        #region  报警订阅
        #endregion

        #region  实时视频
        #region  播放

        public DelegateCommand<object> CommandRealVidePlay { get; set; }
        private void ExecuteCommandRealVidePlay(object commandParameter)
        {
            IsFlowlayer = !IsFlowlayer;
        }
        private bool CanCommandRealVidePlay(object commandParameter)
        {
            return true;
        }
        #endregion
        #endregion
        #endregion
        #endregion

        #region Event

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

        #region  PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }

}
