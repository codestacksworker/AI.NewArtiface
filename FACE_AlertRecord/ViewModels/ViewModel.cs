using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Windows.Data;
using FACE_AlertRecord.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.ServiceLocation;
using SING.Data.Help;
using Sofa.Commons;
using Sofa.Container;
using SING.Data.DAL.ScheduleConvert;
using SING.Infrastructure.Helper;
using SING.Infrastructure.Events;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FACE_AlertRecord.Models;
using FACE_AlertRecord.Views;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Win32;
using SING.Data.DAL;
using SING.Data.Logger;
using SING.Data.BaseTools;
using SING.Data.DAL.Data;

namespace FACE_AlertRecord.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ViewModel : INotifyPropertyChanged, INavigationAware
    {
        public readonly IDataService _dataService;
        public readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;
        private readonly IServiceLocator _serviceLocator;

        private MonitorTasksForm _monitorTasksForm;
        private TarLibraryForm   _tarLibraryForm;
        private AreaChannelForm  _areaChannelForm;
        private AlarmInfoForm    _alertInfoForm;

        [ImportingConstructor]
        public ViewModel(IDataService dataService, IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
            Initialize();
        }

        private void Initialize()
        {
            CommandSelectMonTasks = new DelegateCommand<object>(ExecuteCommandSelectMonTasks);
            CommandSelectTarLibrary = new DelegateCommand<object>(ExecuteCommandSelectTarLibrary);
            CommandSelectArea = new DelegateCommand<object>(ExecuteCommandSelectArea);
            CommandClearCondition = new DelegateCommand<object>(ExecuteCommandClearCondition);
            CommandCheckAll = new DelegateCommand<string>(ExecuteCommandCheckAll);
            CommandCancelAll = new DelegateCommand<string>(ExecuteCommandCancelAll);
            CommandChecked = new DelegateCommand<string>(ExecuteCommandChecked);
            CommandUnChecked = new DelegateCommand<string>(ExecuteCommandUnChecked);
            CommandChildChecked = new DelegateCommand<string>(ExecuteCommandChildChecked);
            CommandChildUnChecked = new DelegateCommand<string>(ExecuteCommandChildUnChecked);
            CommandOK = new DelegateCommand<string>(ExecuteCommandOK);
            CommandReview = new DelegateCommand<object>(ExecuteCommandReview);
            CommandDetailInfo = new DelegateCommand<object>(ExecuteCommandDetailInfo);
            CommandSearchAll = new DelegateCommand<object>(ExecuteCommandSearchAll);
            CommandSearchNoCheck = new DelegateCommand<object>(ExecuteCommandSearchNoCheck);
            CommandSearchExcluded = new DelegateCommand<object>(ExecuteCommandSearchExcluded);
            CommandSearchConfirmed = new DelegateCommand<object>(ExecuteCommandSearchConfirmed);
            CommandSearchNoPush = new DelegateCommand<object>(ExecuteCommandSearchNoPush);
            CommandSearchPush = new DelegateCommand<object>(ExecuteCommandSearchPush);
            CommandSeniorSelect = new DelegateCommand(ExecuteCommandSeniorSelect);
            CommandSearchToday = new DelegateCommand<object>(ExecuteCommandSearchToday);
            CommandSearchYesterday = new DelegateCommand<object>(ExecuteCommandSearchYesterday);
            CommandSearchSevenDays = new DelegateCommand<object>(ExecuteCommandSearchSevenDays);
            CommandCustom = new DelegateCommand<object>(ExecuteCommandCustom);
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
            CommandCustomOk = new DelegateCommand<object>(ExecuteCommandCustomOk);
            CommandCustomCancel = new DelegateCommand<object>(ExecuteCommandCustomCancel);
            StartDateChange = new DelegateCommand(ExecuteStartDateChange);
            EndDateChange = new DelegateCommand(ExecuteEndDateChange);
            StartTimeChange = new DelegateCommand(ExecuteStartTimeChange);
            EndTimeChange = new DelegateCommand(ExecuteEndTimeChange);
            _dataService.AlarmPromptData(this);
            _dataService.MonTaskData(this);
            _dataService.TarLibraryData(this);
            _dataService.AreaChannelData(this);
            _dataService.AlarmInfoData(this);
            if (FaceCapList != null && FaceCapList.Count > 0)
            {
                CurFaceCapData = FaceCapList[0];
                CurFaceCapData.FcmpSocre = FaceCapList[0].FcmpSocre.Trim('✔');
                CurFaceCapData.FcmpSocre = FaceCapList[0].FcmpSocre.Trim('✖');
            }

            foreach (var item in AlarmPromptList)
            {
                if (item.FcapId == 0)
                {
                    item.Status = "未复核";
                    item.StatusColors = new SolidColorBrush(Color.FromArgb(255, 111, 203, 217));
                }
                if (item.FcapId == 1)
                {
                    item.Status = "已确认";
                    item.StatusDate = "2017-05-18 16:26";
                    item.StatusUser = "usera";
                    item.StatusColors = new SolidColorBrush(Color.FromArgb(255, 245, 185, 124));
                }
                if (item.FcapId == 2)
                {
                    item.Status = "已推送";
                    item.StatusDate = "2017-05-18 16:26";
                    item.StatusUser = "usera";
                    item.StatusColors = new SolidColorBrush(Color.FromArgb(255, 226, 42, 59));
                }
                if (item.FcapId == 3)
                {
                    item.Status = "已排除";
                    item.StatusDate = "2017-05-18 16:26";
                    item.StatusUser = "usera";
                    item.StatusColors = new SolidColorBrush(Colors.White);
                }
            }

            #region  接口测试

            var list = _dataService.GetAlertList(this);  //成功
            //var list1 = _dataService.QueryTargetPersonList();//成功
            //var model = _dataService.QueryTargetPersonByID();//成功
            //var model = _dataService.Previous();//成功
            //var model = _dataService.Next();//成功
            //var result = _dataService.Confirm();// 成功
            //var result = _dataService.Eliminate();//成功
            #endregion
        }

        #region Propertys

        private Visibility _searchToolVisible = Visibility.Hidden;
        public Visibility SearchToolVisible
        {
            get
            {
                return _searchToolVisible;
            }

            set
            {
                _searchToolVisible = value;
                OnPropertyChanged("SearchToolVisible");
            }
        }

        private Visibility _noSearchToolVisible =  Visibility.Visible;
        public Visibility NoSearchToolVisible
        {
            get
            {
                return _noSearchToolVisible;
            }

            set
            {
                _noSearchToolVisible = value;
                OnPropertyChanged("NoSearchToolVisible");
            }
        }

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

        private AlarmPromptData _alarmPromptData = new AlarmPromptData();

        public AlarmPromptData AlarmPromptData
        {
            get { return _alarmPromptData; }
            set
            {
                _alarmPromptData = value;
                OnPropertyChanged("AlarmPromptData");
            }
        }

        private ObservableCollection<AlarmPromptData> _alarmPromptList = new ObservableCollection<AlarmPromptData>();
        public ObservableCollection<AlarmPromptData> AlarmPromptList
        {
            get { return _alarmPromptList; }
            set
            {
                _alarmPromptList = value;
                OnPropertyChanged("AlarmPromptList");
            }
        }

        private MonitorTaskData _monitorTaskData = new MonitorTaskData();
        public MonitorTaskData MonitorTaskData
        {
            get { return _monitorTaskData; }
            set
            {
                _monitorTaskData = value;
                OnPropertyChanged("MonitorTaskData");
            }
        }

        private ObservableCollection<MonitorTaskData> _monitorTaskList = new ObservableCollection<MonitorTaskData>();
        public ObservableCollection<MonitorTaskData> MonitorTaskList
        {
            get { return _monitorTaskList; }
            set
            {
                _monitorTaskList = value;
            }
        }

        private TarLibraryData _tarLibraryData = new TarLibraryData();
        public TarLibraryData TarLibraryData
        {
            get
            {
                return _tarLibraryData;
            }

            set
            {
                _tarLibraryData = value;
                OnPropertyChanged("TarLibraryData");
            }
        }

        private ObservableCollection<TarLibraryData> _tarLibraryList = new ObservableCollection<TarLibraryData>();
        public ObservableCollection<TarLibraryData> TarLibraryList
        {
            get
            {
                return _tarLibraryList;
            }

            set
            {
                _tarLibraryList = value;
            }
        }

        private TarLibraryData _tarLibChildData = new TarLibraryData();
        public TarLibraryData TarLibChildData
        {
            get
            {
                return _tarLibChildData;
            }

            set
            {
                _tarLibChildData = value;
                OnPropertyChanged("TarLibChildData");
            }
        }

        private ObservableCollection<TarLibraryData> _tarLibChildList = new ObservableCollection<TarLibraryData>();

        public ObservableCollection<TarLibraryData> TarLibChildList
        {
            get
            {
                return _tarLibChildList;
            }

            set
            {
                _tarLibChildList = value;
            }
        }

        private AreaChannelData _areaChannelData = new AreaChannelData();
        public AreaChannelData AreaChannelData
        {
            get
            {
                return _areaChannelData;
            }

            set
            {
                _areaChannelData = value;
                OnPropertyChanged("AreaChannelData");
            }
        }

        private ObservableCollection<AreaChannelData> _areaChannelList = new ObservableCollection<AreaChannelData>();
        public ObservableCollection<AreaChannelData> AreaChannelList
        {
            get
            {
                return _areaChannelList;
            }

            set
            {
                _areaChannelList = value;
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

        private ObservableCollection<AlarmPromptData> _faceCapList = new ObservableCollection<AlarmPromptData>();
        public ObservableCollection<AlarmPromptData> FaceCapList
        {
            get
            {
                return _faceCapList;
            }

            set
            {
                _faceCapList = value;
            }
        }

        private string _monTaskTxt;
        public string MonTaskTxt
        {
            get
            {
                return _monTaskTxt;
            }

            set
            {
                _monTaskTxt = value;
                OnPropertyChanged("MonTaskTxt");
            }
        }
        
        private string _tarLibTxt;
        public string TarLibTxt
        {
            get
            {
                return _tarLibTxt;
            }

            set
            {
                _tarLibTxt = value;
                OnPropertyChanged("TarLibTxt");
            }
        }
        
        private string _areaChannelTxt;
        public string AreaChannelTxt
        {
            get
            {
                return _areaChannelTxt;
            }

            set
            {
                _areaChannelTxt = value;
                OnPropertyChanged("AreaChannelTxt");
            }
        }

        private string _IDNumTxt;
        public string IDNumTxt
        {
            get
            {
                return _IDNumTxt;
            }

            set
            {
                _IDNumTxt = value;
                OnPropertyChanged("IDNumTxt");
            }
        }

        private int _monTaskNumTxt;
        public int MonTaskNumTxt
        {
            get
            {
                return _monTaskNumTxt;
            }

            set
            {
                _monTaskNumTxt = value;
                OnPropertyChanged("MonTaskNumTxt");
            }
        }

        private int _tarLibNumTxt;
        public int TarLibNumTxt
        {
            get
            {
                return _tarLibNumTxt;
            }

            set
            {
                _tarLibNumTxt = value;
                OnPropertyChanged("TarLibNumTxt");
            }
        }
        
        private int _areaNumTxt;
        public int AreaNumTxt
        {
            get
            {
                return _areaNumTxt;
            }

            set
            {
                _areaNumTxt = value;
                OnPropertyChanged("AreaNumTxt");
            }
        }

        private int _channelNumTxt;
        public int ChannelNumTxt
        {
            get
            {
                return _channelNumTxt;
            }

            set
            {
                _channelNumTxt = value;
                OnPropertyChanged("ChannelNumTxt");
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

        private bool _customIsOpen = false;

        public bool CustomIsOpen
        {
            get
            {
                return _customIsOpen;
            }

            set
            {
                _customIsOpen = value;
                OnPropertyChanged("CustomIsOpen");
            }
        }
        
        private string _startTime = "00:00";
        public string StartTime
        {
            get
            {
                return _startTime;
            }

            set
            {
                _startTime = value;
                OnPropertyChanged("StartTime");
            }
        }

        private string _endTime = "24:00";
        public string EndTime
        {
            get
            {
                return _endTime;
            }

            set
            {
                _endTime = value;
                OnPropertyChanged("EndTime");
            }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }

            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }

            set
            {
                _endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        private string _startTimeTxt = "00:00";
        public string StartTimeTxt
        {
            get
            {
                return _startTimeTxt;
            }

            set
            {
                _startTimeTxt = value;
                OnPropertyChanged("StartTimeTxt");
            }
        }

        private string _endTimeTxt = "24:00";
        public string EndTimeTxt
        {
            get
            {
                return _endTimeTxt;
            }

            set
            {
                _endTimeTxt = value;
                OnPropertyChanged("EndTimeTxt");
            }
        }
        
        private string _startDateTxt = DateTime.Now.ToString("yyyy-MM-dd");
        public string StartDateTxt
        {
            get
            {
                return _startDateTxt;
            }

            set
            {
                _startDateTxt = value;
                OnPropertyChanged("StartDateTxt");
            }
        }

        private string _endDateTxt = DateTime.Now.ToString("yyyy-MM-dd");
        public string EndDateTxt
        {
            get
            {
                return _endDateTxt;
            }

            set
            {
                _endDateTxt = value;
                OnPropertyChanged("EndDateTxt");
            }
        }

        private bool _allIsChecked = true;
        public bool AllIsChecked
        {
            get
            {
                return _allIsChecked;
            }

            set
            {
                _allIsChecked = value;
                OnPropertyChanged("AllIsChecked");
            }
        }

        private bool _noCheckIsChecked = false;
        public bool NoCheckIsChecked
        {
            get
            {
                return _noCheckIsChecked;
            }

            set
            {
                _noCheckIsChecked = value;
                OnPropertyChanged("NoCheckIsChecked");
            }
        }
        
        private bool _excludedIsChecked = false;
        public bool ExcludedIsChecked
        {
            get
            {
                return _excludedIsChecked;
            }

            set
            {
                _excludedIsChecked = value;
                OnPropertyChanged("ExcludedIsChecked");
            }
        }
        
        private bool _confirmedIsChecked = false;
        public bool ConfirmedIsChecked
        {
            get
            {
                return _confirmedIsChecked;
            }

            set
            {
                _confirmedIsChecked = value;
                OnPropertyChanged("ConfirmedIsChecked");
            }
        }
        
        private bool _noPushIsChecked = false;
        public bool NoPushIsChecked
        {
            get
            {
                return _noPushIsChecked;
            }

            set
            {
                _noPushIsChecked = value;
                OnPropertyChanged("NoPushIsChecked");
            }
        }
        
        private bool _pushIsChecked = false;
        public bool PushIsChecked
        {
            get
            {
                return _pushIsChecked;
            }

            set
            {
                _pushIsChecked = value;
                OnPropertyChanged("PushIsChecked");
            }
        }
        
        private bool _todayIsChecked = false;
        public bool TodayIsChecked
        {
            get
            {
                return _todayIsChecked;
            }

            set
            {
                _todayIsChecked = value;
                OnPropertyChanged("TodayIsChecked");
            }
        }
        
        private bool _yesterdayIsChecked = false;
        public bool YesterdayIsChecked
        {
            get
            {
                return _yesterdayIsChecked;
            }

            set
            {
                _yesterdayIsChecked = value;
                OnPropertyChanged("YesterdayIsChecked");
            }
        }
        
        private bool _sevenDaysIsChecked = false;
        public bool SevenDaysIsChecked
        {
            get
            {
                return _sevenDaysIsChecked;
            }

            set
            {
                _sevenDaysIsChecked = value;
                OnPropertyChanged("SevenDaysIsChecked");
            }
        }
        
        private bool _customIsChecked = false;
        public bool CustomIsChecked
        {
            get
            {
                return _customIsChecked;
            }

            set
            {
                _customIsChecked = value;
                OnPropertyChanged("CustomIsChecked");
            }
        }

        private bool _resetIsChecked = false;
        public bool ResetIsChecked
        {
            get
            {
                return _resetIsChecked;
            }

            set
            {
                _resetIsChecked = value;
                OnPropertyChanged("ResetIsChecked");
            }
        }
        #endregion

        #region Event
        public DelegateCommand<object> CommandSelectMonTasks { get; private set; }
        private void ExecuteCommandSelectMonTasks(object para)
        {
            try
            {
                if (_monitorTasksForm != null)
                {
                    if (!MonitorTasksForm.FormIsOpen)
                    {
                        _monitorTasksForm = new MonitorTasksForm(this);
                        _monitorTasksForm.Show();
                    }
                    else
                    {
                        _monitorTasksForm.Focus();
                    }
                }
                else
                {
                    _monitorTasksForm = new MonitorTasksForm(this);
                    _monitorTasksForm.Show();
                }
            }
            catch
            {
                
            }
        }

        public DelegateCommand<object> CommandSelectTarLibrary { get; private set; }
        private void ExecuteCommandSelectTarLibrary(object para)
        {
            try
            {
                if (_tarLibraryForm != null)
                {
                    if (!TarLibraryForm.FormIsOpen)
                    {
                        _tarLibraryForm = new TarLibraryForm(this);
                        _tarLibraryForm.Show();
                    }
                    else
                    {
                        _tarLibraryForm.Focus();
                    }
                }
                else
                {
                    _tarLibraryForm = new TarLibraryForm(this);
                    _tarLibraryForm.Show();
                }
            }
            catch
            {
                
            }
        }

        public DelegateCommand<object> CommandSelectArea { get; private set; }
        private void ExecuteCommandSelectArea(object para)
        {
            try
            {
                if (_areaChannelForm != null)
                {
                    if (!AreaChannelForm.FormIsOpen)
                    {
                        _areaChannelForm = new AreaChannelForm(this);
                        _areaChannelForm.Show();
                    }
                    else
                    {
                        _areaChannelForm.Focus();
                    }
                }
                else
                {
                    _areaChannelForm = new AreaChannelForm(this);
                    _areaChannelForm.Show();
                }
            }
            catch
            {
                
            }
        }

        public DelegateCommand<object> CommandClearCondition { get; private set; }
        private void ExecuteCommandClearCondition(object para)
        {
            try
            {
                MonTaskTxt = string.Empty;
                TarLibTxt = string.Empty;
                AreaChannelTxt = string.Empty;
                IDNumTxt = string.Empty;
            }
            catch
            {
                
            }
        }

        public DelegateCommand<string> CommandCheckAll { get; private set; }
        private void ExecuteCommandCheckAll(string para)
        {
            try
            {
                if (para == "0")
                {
                    foreach (var item in MonitorTaskList)
                    {
                        item.IsChecked = true;
                    }
                }
                else if (para == "1")
                {
                    foreach (var item in TarLibraryList)
                    {
                        item.IsChecked = true;
                        foreach (var itemChild in item.TarLibChildList)
                        {
                            itemChild.IsChecked = true;
                        }
                    }
                }
                else if (para == "2")
                {
                    foreach (var item in AreaChannelList)
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
                    foreach (var item in MonitorTaskList)
                    {
                        item.IsChecked = false;
                    }
                }
                else if (para == "1")
                {
                    foreach (var item in TarLibraryList)
                    {
                        item.IsChecked = false;
                        /*foreach (var itemChild in item.TarLibChildList)
                        {
                            itemChild.IsChecked = false;
                        }*/
                    }
                }
                else if (para == "2")
                {
                    foreach (var item in AreaChannelList)
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
                if (para == "0")
                {
                    MonTaskNumTxt = MonitorTaskList.ToList().FindAll(p => p.IsChecked == true).Count();
                }
                if (para == "1")
                {
                    /*foreach (var item in TarLibraryList)
                    {
                        if (item.IsChecked == true)
                        {
                            foreach (var itemChild in item.TarLibChildList)
                            {
                                itemChild.IsChecked = true;
                            }
                        }
                    }*/
                    TarLibNumTxt = TarLibraryList.ToList().FindAll(p => p.IsChecked == true).Count();
                }
                else if (para == "2")
                {
                    foreach (var item in AreaChannelList)
                    {
                        if (item.IsChecked == true)
                        {
                            foreach (var itemChild in item.AreaChannelChildList)
                            {
                                itemChild.IsChecked = true;
                            }
                        }
                    }
                    AreaNumTxt = AreaChannelList.ToList().FindAll(p => p.IsChecked == true).Count();
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
                if (para == "0")
                {
                    MonTaskNumTxt = MonitorTaskList.ToList().FindAll(p => p.IsChecked == true).Count();
                }
                if (para == "1")
                {
                    /*foreach (var item in TarLibraryList)
                    {
                        if (item.IsChecked == false)
                        {
                            foreach (var itemChild in item.TarLibChildList)
                            {
                                itemChild.IsChecked = false;
                            }
                        }
                    }*/
                    TarLibNumTxt = TarLibraryList.ToList().FindAll(p => p.IsChecked == true).Count();
                }
                else if (para == "2")
                {
                    foreach (var item in AreaChannelList)
                    {
                        if (item.IsChecked == false)
                        {
                            foreach (var itemChild in item.AreaChannelChildList)
                            {
                                itemChild.IsChecked = false;
                            }
                        }
                    }
                    AreaNumTxt = AreaChannelList.ToList().FindAll(p => p.IsChecked == true).Count();
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
                    /*foreach (var item in TarLibraryList)
                    {
                        if (item.TarLibChildList.ToList().FindAll(p => p.IsChecked == true).Count() == item.TarLibChildList.Count())
                        {
                            item.IsChecked = true;
                        }
                    }*/
                }
                else if (para == "2")
                {
                    int i = 0;
                    foreach (var item in AreaChannelList)
                    {
                        if (item.AreaChannelChildList.ToList().FindAll(p => p.IsChecked == true).Count() == item.AreaChannelChildList.Count())
                        {
                            item.IsChecked = true;
                        }
                        i += item.AreaChannelChildList.ToList().FindAll(p => p.IsChecked == true).Count();
                    }
                    ChannelNumTxt = i;
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
                    /*foreach (var item in TarLibraryList)
                    {
                        if (item.TarLibChildList.ToList().FindAll(p => p.IsChecked == false).Any())
                        {
                            item.IsChecked = false;
                        }
                    }*/
                }
                else if (para == "2")
                {
                    int i = 0;
                    foreach (var item in AreaChannelList)
                    {
                        if (item.AreaChannelChildList.ToList().FindAll(p => p.IsChecked == false).Any())
                        {
                            item.IsChecked = false;
                        }
                        i += item.AreaChannelChildList.ToList().FindAll(p => p.IsChecked == true).Count();
                    }
                    ChannelNumTxt = i;
                }
            }
            catch
            {
                
            }
        }

        public DelegateCommand<string> CommandOK { get; private set; }
        private void ExecuteCommandOK(string para)
        {
            try
            {
                MonTaskTxt = string.Empty;
                TarLibTxt = string.Empty;
                AreaChannelTxt = string.Empty;
                if (para == "0")
                {
                    foreach (var item in MonitorTaskList)
                    {
                        if (item.IsChecked == true)
                        {
                            MonTaskTxt += item.TaskName + ",";
                        }
                    }
                    if (MonTaskTxt.EndsWith(",")) MonTaskTxt = MonTaskTxt.TrimEnd(',');
                    _monitorTasksForm.Close();
                }
                else if (para == "1")
                {
                    foreach (var item in TarLibraryList)
                    {
                        if (item.IsChecked == true)
                        {
                            TarLibTxt += item.TarLibName + ",";
                        }
                        /*foreach (var itemChild in item.TarLibChildList)
                        {
                            if (itemChild.IsChecked == true)
                            {
                                TarLibTxt += itemChild.TarPeople + ",";
                            }
                        }*/
                    }
                    if (TarLibTxt.EndsWith(",")) TarLibTxt = TarLibTxt.TrimEnd(',');
                    _tarLibraryForm.Close();
                }
                else if (para == "2")
                {
                    foreach (var item in AreaChannelList)
                    {
                        foreach (var itemChild in item.AreaChannelChildList)
                        {
                            if (itemChild.IsChecked == true)
                            {
                                AreaChannelTxt += itemChild.ChannelChild + ",";
                            }
                        }
                    }
                    if (AreaChannelTxt.EndsWith(",")) AreaChannelTxt = AreaChannelTxt.TrimEnd(',');
                    _areaChannelForm.Close();
                }
            }
            catch
            {
                
            }
        }

        public DelegateCommand<object> CommandReview { get; private set; }
        private void ExecuteCommandReview(object para)
        {
            try
            {
                if (_alertInfoForm != null)
                {
                    if (!AlarmInfoForm.FormIsOpen)
                    {
                        _alertInfoForm = new AlarmInfoForm(this);
                        _alertInfoForm.Show();
                    }
                    else
                    {
                        _alertInfoForm.Focus();
                    }
                }
                else
                {
                    _alertInfoForm = new AlarmInfoForm(this);
                    _alertInfoForm.Show();
                }

                PushBtnIsEnabled = false;
                CenterBtnVisible = Visibility.Visible;
                DefaultVisible = Visibility.Visible;
                ConfirmExcludVisible = Visibility.Hidden;
                PushedVisible = Visibility.Hidden;
                TagBtnVisible = Visibility.Hidden;
            }
            catch
            {
                
            }
        }

        public DelegateCommand<object> CommandDetailInfo { get; private set; }
        private void ExecuteCommandDetailInfo(object para)
        {
            try
            {
                if (_alertInfoForm != null)
                {
                    if (!AlarmInfoForm.FormIsOpen)
                    {
                        _alertInfoForm = new AlarmInfoForm(this);
                        _alertInfoForm.Show();
                    }
                    else
                    {
                        _alertInfoForm.Focus();
                    }
                }
                else
                {
                    _alertInfoForm = new AlarmInfoForm(this);
                    _alertInfoForm.Show();
                }

                PushBtnIsEnabled = false;
                CenterBtnVisible = Visibility.Hidden;
                DefaultVisible = Visibility.Hidden;
                ConfirmExcludVisible = Visibility.Visible;
                PushedVisible = Visibility.Hidden;
                TagBtnVisible = Visibility.Visible;
                TagBtnContent = "✔目标已确认";
            }
            catch
            {
                
            }
        }
        
        public DelegateCommand<object> CommandSearchAll { get; private set; }
        private void ExecuteCommandSearchAll(object para)
        {
            try
            {
                if (AllIsChecked == true)
                {
                    AllIsChecked = false;
                }
                else
                {
                    AllIsChecked = true;
                }
                AlarmPromptList.Clear();
                _dataService.AlarmPromptData(this);
               
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand<object> CommandSearchNoCheck { get; private set; }
        private void ExecuteCommandSearchNoCheck(object para)
        {
            try
            {
                string imgstr1 = @"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\bing4.jpg";
                string imgstr2 = @"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\feng5.jpg";
                byte[] buffer1 = ImageConvert.PathToBinaryStream(imgstr1);
                byte[] buffer2 = ImageConvert.PathToBinaryStream(imgstr2);
                foreach (var item in AlarmPromptList)
                {
                    item.FcapImg = buffer1;
                    item.TargetImg = buffer2;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand<object> CommandSearchExcluded { get; private set; }
        private void ExecuteCommandSearchExcluded(object para)
        {
            try
            {
                byte[] buffer1 = ImageConvert.PathToBinaryStream(@"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\shishi11.jpg");
                byte[] buffer2 = ImageConvert.PathToBinaryStream(@"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\yang7.jpg");
                foreach (var item in AlarmPromptList)
                {
                    item.FcapImg = buffer1;
                    item.TargetImg = buffer2;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand<object> CommandSearchConfirmed { get; private set; }
        private void ExecuteCommandSearchConfirmed(object para)
        {
            try
            {
                byte[] buffer1 = ImageConvert.PathToBinaryStream(@"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\ying2.jpg");
                byte[] buffer2 = ImageConvert.PathToBinaryStream(@"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\ting1.jpg");
                foreach (var item in AlarmPromptList)
                {
                    item.FcapImg = buffer1;
                    item.TargetImg = buffer2;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand<object> CommandSearchNoPush { get; private set; }
        private void ExecuteCommandSearchNoPush(object para)
        {
            try
            {
                byte[] buffer1 = ImageConvert.PathToBinaryStream(@"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\yang5.jpg");
                byte[] buffer2 = ImageConvert.PathToBinaryStream(@"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\ying6.jpg");
                foreach (var item in AlarmPromptList)
                {
                    item.FcapImg = buffer1;
                    item.TargetImg = buffer2;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand<object> CommandSearchPush { get; private set; }
        private void ExecuteCommandSearchPush(object para)
        {
            try
            {
                byte[] buffer1 = ImageConvert.PathToBinaryStream(@"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\shishi11.jpg");
                byte[] buffer2 = ImageConvert.PathToBinaryStream(@"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\yang7.jpg");
                foreach (var item in AlarmPromptList)
                {
                    item.FcapImg = buffer1;
                    item.TargetImg = buffer2;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand CommandSeniorSelect { get; private set; }
        private void ExecuteCommandSeniorSelect()
        {
            try
            {
                if (SearchToolVisible == Visibility.Hidden)
                {
                    SearchToolVisible = Visibility.Visible;
                    NoSearchToolVisible = Visibility.Hidden;
                }
                else
                {
                    SearchToolVisible = Visibility.Hidden;
                    NoSearchToolVisible = Visibility.Visible;
                }
            }
            catch
            {

            }
        }

        public DelegateCommand<object> CommandSearchToday { get; private set; }
        private void ExecuteCommandSearchToday(object para)
        {
            try
            {
                byte[] buffer1 = ImageConvert.PathToBinaryStream(@"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\feng5.jpg");
                byte[] buffer2 = ImageConvert.PathToBinaryStream(@"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\yangmi1.jpg");
                foreach (var item in AlarmPromptList)
                {
                    item.FcapImg = buffer1;
                    item.TargetImg = buffer2;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand<object> CommandSearchYesterday { get; private set; }
        private void ExecuteCommandSearchYesterday(object para)
        {
            try
            {
                byte[] buffer1 = ImageConvert.PathToBinaryStream(@"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\shishi4.jpg");
                byte[] buffer2 = ImageConvert.PathToBinaryStream(@"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\ting1.jpg");
                foreach (var item in AlarmPromptList)
                {
                    item.FcapImg = buffer1;
                    item.TargetImg = buffer2;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand<object> CommandSearchSevenDays { get; private set; }
        private void ExecuteCommandSearchSevenDays(object para)
        {
            try
            {
                byte[] buffer1 = ImageConvert.PathToBinaryStream(@"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\YangYang2.jpg");
                byte[] buffer2 = ImageConvert.PathToBinaryStream(@"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\ying6.jpg");
                foreach (var item in AlarmPromptList)
                {
                    item.FcapImg = buffer1;
                    item.TargetImg = buffer2;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand<object> CommandCustom { get; private set; }
        private void ExecuteCommandCustom(object para)
        {
            try
            {
                if (CustomIsOpen == false)
                {
                    CustomIsOpen = true;
                }
                else
                {
                    CustomIsOpen = false;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand<object> CommandPrevious { get; private set; }
        private void ExecuteCommandPrevious(object para)
        {
            try
            {
                CurFaceCapData = FaceCapList[FaceCapData.FcapId - 1];
                FaceCapData = FaceCapList[FaceCapData.FcapId - 1];
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
                FaceCapData.FcmpSocre = "✔" + FaceCapData.FcmpSocre;
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
                FaceCapData.FcmpSocre = "✖" + FaceCapData.FcmpSocre;
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
                CurFaceCapData = FaceCapList[FaceCapData.FcapId+1];
                FaceCapData = FaceCapList[FaceCapData.FcapId + 1];
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
            catch(Exception ex)
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
                TagBtnVisible = Visibility.Hidden;
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
                    /*byte[] by = new byte[0];//内存byte流
                    System.IO.Stream s = new System.IO.MemoryStream(by);
                    Image image = Image.(s);
                    image.Save("c:\\TEST.jpg");*/
                }

                /*BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(imgstr1));

                using (var fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                {
                    encoder.Save(fileStream);
                }*/
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

        public DelegateCommand<object> CommandCustomOk { get; private set; }
        private void ExecuteCommandCustomOk(object para)
        {
            try
            {
                CustomIsOpen = false;
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand<Object> CommandSeniorQuery { get; private set; }
        private void ExiuteCommandSeniorQuery(object para)
        {
            try
            {
                //var list = _dataService.GetAlertList();  //成功
            }
            catch(Exception ex)
            {
                Logger.Error("错误提示", ex);   
            }
        }

        public DelegateCommand<object> CommandCustomCancel { get; private set; }
        private void ExecuteCommandCustomCancel(object para)
        {
            try
            {
                CustomIsOpen = false;
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand StartDateChange { get; private set; }

        private void ExecuteStartDateChange()
        {
            try
            {
                StartDateTxt = StartDate.ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand EndDateChange { get; private set; }

        private void ExecuteEndDateChange()
        {
            try
            {
                EndDateTxt = EndDate.ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }
        public DelegateCommand StartTimeChange { get; private set; }

        private void ExecuteStartTimeChange()
        {
            try
            {
                StartTimeTxt = StartTime;
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
        }

        public DelegateCommand EndTimeChange { get; private set; }

        private void ExecuteEndTimeChange()
        {
            try
            {
                EndTimeTxt = EndTime;
            }
            catch (Exception ex)
            {
                Logger.Error("错误提示", ex);
            }
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
