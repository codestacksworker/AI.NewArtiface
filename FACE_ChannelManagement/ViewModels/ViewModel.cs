using Dev_SING.Data.BaseTools;
using FACE_ChannelManagement.Services;
using GMap.NET;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using SING.Data;
using SING.Data.BaseTools;
using SING.Data.Controls.TreeControl.Models;
using SING.Data.Controls.VideoControl;
using SING.Data.DAL;
using SING.Data.DAL.Data;
using SING.Data.Help;
using SING.Data.Logger;
using SING.Infrastructure.Enum;
using SING.Infrastructure.Enums;
using SING.Infrastructure.Events;
using SING.Infrastructure.Models;
using Sofa.Commons;
using Sofa.Container;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace FACE_ChannelManagement.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ViewModel : NotificationObject, INavigationAware
    {
        public readonly IDataService _dataService;
        public readonly IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public ViewModel(IDataService dataService, IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;

            InitializeVarables();
            _dataService.InitialRegions(this);
            _dataService.InitializeContainer(this);
            _dataService.SetSingleScreen(this);
            this.SetTreeMenuShowMode();

            AddRootNodeCommand = new DelegateCommand<object>(ExecuteAddRootNode);
            AddChildNodeCommand = new DelegateCommand<object>(ExecuteAddChildNode);
            AddPeerNodeCommand = new DelegateCommand<object>(ExecuteAddPeerNode);
            AddChannelCommand = new DelegateCommand<object>(ExecuteAddChannel);
            EditNodeCommand = new DelegateCommand<object>(ExecuteEditNode);
            DeleteNodeCommand = new DelegateCommand<object>(ExecuteDeleteNode);
            SelectedNodeCommand = new DelegateCommand<RoutedEventArgs>(ExecuteSelectedNode);
            VideoViewExitCommand = new DelegateCommand<object>(ExecuteVideoViewExit);
            UpdateConnectedCommand = new DelegateCommand<object>(ExecuteUpdateConnected);
            SearchCommand = new DelegateCommand<object>(ExecuteSearch);
            SaveDetailsCommand = new DelegateCommand<object>(ExecuteSaveDetails);
            EnterKeyCommand = new DelegateCommand<object>(ExecuteEnterKey);
        }

        #region Properties

        private PointLatLng _currentMapPosition;
        public PointLatLng CurrentMapPosition
        {
            get
            {
                return _currentMapPosition;
            }

            set
            {
                _currentMapPosition = value;

                if (_currentMapPosition != null && EditItem != null)
                {
                    EditItem.ChannelLongitude = _currentMapPosition.Lng;
                    EditItem.ChannelLatitude = _currentMapPosition.Lat;
                }

                RaisePropertyChanged("CurrentMapPosition");
            }
        }

        #region  树控件源数据
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
                ResetPageMode();//重置界面的模式
                OperationStr = string.Empty;

                //if (value != null && value.Items != null && value.Items.Count > 0)
                //    value.IsExpanded = !value.IsExpanded;

                _currentTreeItem = value;
                RaisePropertyChanged("CurrentTreeItem");

                if (value != null)
                {
                    ReBindDetailInfo(value);//重新绑定通道详细信息的数据源  

                    if (_currentTreeItem.Channel != null)
                    {
                        CurrentMapPosition = new PointLatLng(_currentTreeItem.Channel.ChannelLatitude, _currentTreeItem.Channel.ChannelLongitude);
                    }
                }
                SetTreeMenuShowMode();
            }
        }
        private string searchText;
        public string SearchText
        {
            get
            {
                return searchText;
            }

            set
            {
                searchText = value;
                RaisePropertyChanged("SearchText");
            }
        }

        #region  动态设置右键菜单内容
        private Visibility _regionVisibility = Visibility.Collapsed;
        public Visibility RegionVisibility
        {
            get
            {
                return _regionVisibility;
            }

            set
            {
                _regionVisibility = value;
                RaisePropertyChanged("RegionVisibility");
            }
        }
        private Visibility _channelVisibility = Visibility.Collapsed;
        public Visibility ChannelVisibility
        {
            get
            {
                return _channelVisibility;
            }

            set
            {
                _channelVisibility = value;
                RaisePropertyChanged("ChannelVisibility");
            }
        }
        private Visibility _rootVisibility = Visibility.Collapsed;
        public Visibility RootVisibility
        {
            get
            {
                return _rootVisibility;
            }

            set
            {
                _rootVisibility = value;
                RaisePropertyChanged("RootVisibility");
            }
        }
        private Visibility _maintainVisibility = Visibility.Collapsed;
        public Visibility MaintainVisibility
        {
            get
            {
                return _maintainVisibility;
            }

            set
            {
                _maintainVisibility = value;
                RaisePropertyChanged("MaintainVisibility");
            }
        }
        //private Visibility _menuVisibility = Visibility.Collapsed;
        //public Visibility MenuVisibility
        //{
        //    get
        //    {
        //        return _menuVisibility;
        //    }

        //    set
        //    {
        //        _menuVisibility = value;
        //        RaisePropertyChanged("MenuVisibility");
        //    }
        //}
        #endregion

        #endregion

        #region  列表控件源数据
        private ObservableCollection<DataItem> _videoList;
        public ObservableCollection<DataItem> VideoList
        {
            get
            {
                return _videoList;
            }

            set
            {
                _videoList = value;
            }
        }

        private DataItem _video;
        public DataItem Video
        {
            get
            {
                return _video;
            }

            set
            {
                if (IsPlaying)
                    IsStarted = false;

                _video = value;
                if (value != null && _video != null)
                {
                    if (_video.Channel != null)
                    {
                        CurrentMapPosition = new PointLatLng(_video.Channel.ChannelLatitude, _video.Channel.ChannelLongitude);
                    }
                }

                RaisePropertyChanged("Video");

                if (_video != null)
                {
                    IsStarted = true;
                    if (!IsPlaying)
                        IsStarted = false;
                }
            }
        }
        #endregion

        #region  通道视频源数据
        #region  视频控件操作
        private IVideoBase _VideoView;
        public IVideoBase VideoView
        {
            get
            {
                return _VideoView;
            }
            set
            {
                _VideoView = value;
            }
        }

        private Grid _videoPlayerGrid;
        public Grid VideoPlayerGrid
        {
            get
            {
                return _videoPlayerGrid;
            }
            set
            {
                _videoPlayerGrid = value;
                RaisePropertyChanged("VideoPartGrid");
            }
        }
        private List<WindowsFormsHost> _wfhList;
        public List<WindowsFormsHost> WfhList
        {
            get
            {
                return _wfhList;
            }
            set
            {
                _wfhList = value;
                RaisePropertyChanged("WfhList");
            }
        }
        public bool IsLocal { get; set; }

        public AxDZVideoControl playerCtrl { get; set; }
        public List<IVideoManager> VideoManager { get; set; }

        public AxVideoControl AxVideoControl { get; set; }

        private bool _IsPlaying = false;
        public bool IsPlaying
        {
            get
            {
                return _IsPlaying;
            }
            set
            {
                _IsPlaying = value;
                RaisePropertyChanged("IsPlaying");
            }
        }

        private bool _IsStarted = false;
        public bool IsStarted
        {
            get
            {
                return _IsStarted;
            }
            set
            {
                _IsStarted = value;
                RaisePropertyChanged("IsStarted");
            }
        }
        #endregion
        #endregion

        #region  通道详细
        #endregion

        #region  通道数据维护源数据

        private ChannelData _editItem;
        public ChannelData EditItem
        {
            get
            {
                return _editItem;
            }

            set
            {
                _editItem = value;
                RaisePropertyChanged("EditItem");
            }
        }
        /// <summary>
        /// 通道编辑页面状态值
        /// </summary>
        private bool _inEdit = false;
        public bool InEdit
        {
            get
            {
                return _inEdit;
            }

            set
            {
                _inEdit = value;
                RaisePropertyChanged("InEdit");
            }
        }

        private ObservableCollection<EnumData> _directs = EnumUtils.GetEnumDataObservableList<VideoDirectEnum>();
        public ObservableCollection<EnumData> Directs
        {
            get
            {
                return _directs;
            }

            set
            {
                _directs = value;
                RaisePropertyChanged("Directs");
            }
        }
        private ObservableCollection<EnumData> _Importants = EnumUtils.GetEnumDataObservableList<ImportantType>();
        public ObservableCollection<EnumData> Importants
        {
            get
            {
                return _Importants;
            }

            set
            {
                _Importants = value;
                RaisePropertyChanged("Importants");
            }
        }

        private bool _isEditMap;
        public bool IsEditMap
        {
            get
            {
                return this._isEditMap;
            }
            set
            {
                this._isEditMap = value;
                RaisePropertyChanged("IsEditMap");
            }
        }
        #endregion

        #region  通道列表与编辑页面切换
        private bool _IsEdited = false;
        public bool IsEdited
        {
            get { return _IsEdited; }
            set
            {
                _IsEdited = value;
                VideoListVisibility = _IsEdited ? Visibility.Collapsed : Visibility.Visible;
                EditInfoVisibility = _IsEdited ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        private Visibility _videoListVisibility = Visibility.Visible;
        private Visibility _editInfoVisibility = Visibility.Collapsed;
        public Visibility VideoListVisibility
        {
            get { return _videoListVisibility; }
            set
            {
                _videoListVisibility = value;
                RaisePropertyChanged("VideoListVisibility");
            }
        }

        public Visibility EditInfoVisibility
        {
            get
            {
                return _editInfoVisibility;
            }

            set
            {
                _editInfoVisibility = value;
                RaisePropertyChanged("EditInfoVisibility");
            }
        }
        #endregion

        #endregion

        #region  Commands

        #region  树控件
        //添加根区域
        public DelegateCommand<object> AddRootNodeCommand { get; set; }
        void ExecuteAddRootNode(object obj)
        {
            DataItem item = new DataItem()
            {
                Region = new RegionsData()
                { ParentId = 0, RegionLevel = 0 },
                Text = "区域"
            };
            #region 提交操作
            var result = _dataService.AddRegion(item);
            #endregion
            if (result.ErrorCode == StatusCode.Success)
            {
                item.Id = result.ID.ToString();
                item.Region.ID = result.ID;
                TreeItems.Add(item);

                if (!string.IsNullOrEmpty(obj?.ToString()))
                    _dataService.Notice(this, obj.ToString(), item?.Region?.ID.ToString(), item);
            }
            else
            {
                Logger.Error("数据提交失败！");
                MessageBoxHelper.Show("数据提交失败！", "提示");
                return;
            }
        }
        //添加子区域
        public DelegateCommand<object> AddChildNodeCommand { get; set; }
        private void ExecuteAddChildNode(object obj)
        {
            if (CurrentTreeItem == null) return;
            DataItem item = new DataItem()
            {
                Region = new RegionsData()
                {
                    ParentId = CurrentTreeItem.Region.ID,
                    RegionLevel = ++CurrentTreeItem.Region.RegionLevel
                },
                Text = "区域",
                Parent = CurrentTreeItem
            };
            #region  提交操作
            var result = _dataService.AddRegion(item);
            #endregion
            if (result.ErrorCode != StatusCode.Success)
            {
                Logger.Error("数据提交失败！");
                MessageBoxHelper.Show("数据提交失败！",
                    "提示");
                return;
            }
            item.Id = result.ID.ToString();
            item.Region.ID = result.ID;

            CurrentTreeItem.Items.Add(item);
            CurrentTreeItem.IsExpanded = true;

            if (!string.IsNullOrEmpty(obj?.ToString()))
                _dataService.Notice(this, obj.ToString(), CurrentTreeItem?.Region?.ID.ToString(), item);
        }
        //添加同级区域
        public DelegateCommand<object> AddPeerNodeCommand { get; set; }
        void ExecuteAddPeerNode(object obj)
        {
            DataItem parent = CurrentTreeItem.Parent;
            DataItem item = new DataItem { Region = new RegionsData() };
            item.Text = "区域";
            if (parent != null)
            {
                item.Region.ParentId = parent.Region.ID;
                item.Region.RegionLevel = ++parent.Region.RegionLevel;
            }

            #region 提交操作
            var result = _dataService.AddRegion(item);
            #endregion
            if (result.ErrorCode != StatusCode.Success)
            {
                Logger.Error("数据提交失败！");
                MessageBoxHelper.Show("数据提交失败！",
                    "提示");
                return;
            }
            item.Id = result.ID.ToString();
            item.Region.ID = result.ID;

            if (parent != null)
            {
                item.Parent = parent;
                parent.Items.Add(item);
            }
            else
            {
                TreeItems.Add(item);
            }

            if (!string.IsNullOrEmpty(obj?.ToString()))
                _dataService.Notice(this, obj.ToString(), item?.Region.ID.ToString(), item);
        }
        //添加通道
        public DelegateCommand<object> AddChannelCommand { get; set; }
        void ExecuteAddChannel(object obj)
        {
            OperationStr = obj?.ToString();

            if (EditItem == null)
                EditItem = new ChannelData();

            EditItem.ChannelThreshold = 1;
            IsEdited = true;
            InEdit = true;
        }

        public string OperationStr { get; set; }

        private ChannelData ChannelInstance = new ChannelData();
        //编辑
        public DelegateCommand<object> EditNodeCommand { get; set; }
        void ExecuteEditNode(object obj)
        {
            OperationStr = obj?.ToString();

            if (CurrentTreeItem.Status == "Channel")
            {
                EditItem = CurrentTreeItem.Channel;

                //维护通道数据本地副本
                EditItem.Cast(ChannelInstance);

                IsEdited = true;
                InEdit = true;
            }
            else if (CurrentTreeItem.Status == "Region")
            {
                CurrentTreeItem.IsInEdit = true;
            }
        }
        //删除
        public DelegateCommand<object> DeleteNodeCommand { get; set; }

        private void ExecuteDeleteNode(object obj)
        {
            Result result = null;
            if (CurrentTreeItem.Status == "Region")
            {
                if (MessageBoxHelper.confirm("删除当前区域将删除区域内所有子区域和通道，是否删除当前区域？", "提示") == MessageBoxResult.Yes)
                {

                    //递归删除通道
                    List<RegionsData> list = GetRegions(CurrentTreeItem);

                    if (list != null && list.Count > 0)
                    {
                        foreach (RegionsData t in list)
                        {
                            result = _dataService.DeleteChannel(t.ID);
                        }
                    }

                    if (result?.ErrorCode == StatusCode.Success)
                        result = _dataService.DeleteRegion(CurrentTreeItem);

                    if (!IsFailture(result))
                        return;

                    VideoList.Clear();

                    if (!string.IsNullOrEmpty(obj?.ToString()))
                    {
                        _dataService.Notice(this, obj.ToString(), CurrentTreeItem?.Region?.ID.ToString(), CurrentTreeItem);
                    }
                }
                else
                {
                    return;
                }
            }
            else if (CurrentTreeItem.Status == "Channel")
            {
                if (MessageBoxHelper.confirm("是否删除通道？", "提示") == MessageBoxResult.Yes)
                {

                    result = _dataService.DeleteChannel(CurrentTreeItem);

                    if (!IsFailture(result))
                        return;

                    VideoList.Remove(CurrentTreeItem);

                    if (!string.IsNullOrEmpty(obj?.ToString()))
                    {
                        _dataService.Notice(this, obj.ToString(), CurrentTreeItem?.Channel?.Uuid, CurrentTreeItem);
                    }
                }
                else
                {
                    return;
                }
            }

            if (result.ErrorCode == StatusCode.Success)
            {
                var alternativeItem = GetAlternativeItem();

                RemoveItem(CurrentTreeItem, TreeItems);
                CurrentTreeItem = alternativeItem;
                IsEdited = false;
            }
        }

        private DataItem GetAlternativeItem()
        {
            DataItem result = null;

            var list = GetItems();
            if (list != null)
            {
                var currentIndex = list.IndexOf(CurrentTreeItem);
                result = list.Count == 1
                    ? CurrentTreeItem.Parent
                    : currentIndex == list.Count - 1
                    ? list[--currentIndex]
                        : list[++currentIndex];
            }

            return result;
        }

        private ObservableCollection<DataItem> GetItems()
        {
            return CurrentTreeItem != null && CurrentTreeItem.Parent != null ? CurrentTreeItem.Parent.Items : TreeItems;
        }

        //选中
        public DelegateCommand<RoutedEventArgs> SelectedNodeCommand { get; set; }
        private void ExecuteSelectedNode(RoutedEventArgs e)
        {
            if (e == null) return;
            var treeViewItem = VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;

            if (treeViewItem == null) return;
            treeViewItem.Focus();
            e.Handled = true;
        }
        public DelegateCommand<object> SearchCommand { get; set; }
        private void ExecuteSearch(object obj)
        {
            LocalNodes(SearchText, TreeItems, true);
            SetTreeMenuShowMode();
        }

        public DelegateCommand<object> EnterKeyCommand { get; set; }
        private void ExecuteEnterKey(object obj)
        {
            //foreach (var pro in BindingOperations.GetSourceUpdatingBindings(CurrentTreeItem))
            //    pro.UpdateSource();

            //CurrentTreeItem.OnPropertyChanged("Text");
            //RaisePropertyChanged("CurrentTreeItem");
            ResetPageMode();
            //if (CurrentTreeItem != null && CurrentTreeItem.IsInEdit)
            //{
            //    var result = _dataService.EditRegion(CurrentTreeItem);
            //    if (result.ErrorCode == StatusCode.Success)
            //        CurrentTreeItem.IsInEdit = false;

            //    if (!string.IsNullOrEmpty(OperationStr))
            //        _dataService.Notice(this, OperationStr, CurrentTreeItem?.Region?.ID.ToString(), CurrentTreeItem);
            //}

            //if (InEdit)
            //    InEdit = false;
        }
        #endregion

        #region  列表控件源数据
        public DelegateCommand<object> VideoViewExitCommand { get; set; }
        void ExecuteVideoViewExit(object obj)
        {
            if (MessageBoxHelper.confirm("是否删除通道？", "提示") == MessageBoxResult.Yes)
            {
                if (string.IsNullOrWhiteSpace(obj?.ToString())) return;

                string uuid = obj.ToString();

                var item = VideoList.FirstOrDefault(v => v.Channel.Uuid == uuid);

                if (item == null) return;

                var result = _dataService.DeleteChannel(item);

                if (!IsFailture(result)) return;

                VideoList.Remove(item);

                RemoveItem(item, TreeItems);

                _dataService.Notice(this, "删除", uuid, item);
            }
        }
        public DelegateCommand<object> UpdateConnectedCommand { get; set; }
        private void ExecuteUpdateConnected(object obj)
        {
            if (string.IsNullOrWhiteSpace(obj?.ToString()))
                return;
            string uuid = obj.ToString();
            var item = VideoList.FirstOrDefault(v => v.Channel.Uuid == uuid);
            if (item != null && string.IsNullOrWhiteSpace(item.Channel?.ChannelAddr))
                return;
            Task.Factory.StartNew(new Action(() =>
            {
                if (item == null) return;
                var channelData = item.Channel;
                var connected = channelData != null
                            && ValidIP.Ping(channelData.ChannelAddr);
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (item.Channel != null)
                        item.Channel.IsConnected = connected;
                }));
            }));
        }
        #endregion

        #region  通道视频源数据
        #endregion

        #region  通道详细
        #endregion

        #region  通道数据维护源数据
        /// <summary>
        /// 通道编辑页面数据保存操作
        /// </summary>
        public DelegateCommand<object> SaveDetailsCommand { get; set; }
        private void ExecuteSaveDetails(object obj)
        {
            #region  子节点

            if (CurrentTreeItem == null || EditItem == null) return;

            string flat = string.Empty;
            string isEmpty = string.Empty;

            if (string.IsNullOrWhiteSpace(EditItem.ChannelName))
            {
                flat += "通道名称、";
            }
            if (string.IsNullOrWhiteSpace(EditItem.ChannelNo))
            {
                flat += "通道号、";
            }
            if (string.IsNullOrWhiteSpace(EditItem.ChannelAddr))
            {
                flat += "视频地址、";
            }
            if (EditItem.ChannelPort == 0)
            {
                flat += "视频端口、";
            }
            if (string.IsNullOrWhiteSpace(EditItem.ChannelUid))
            {
                flat += "视频帐号、";
            }
            if (string.IsNullOrWhiteSpace(EditItem.ChannelPsw))
            {
                flat += "视频密码、";
            }
            if (string.IsNullOrWhiteSpace(EditItem.MinFaceWidth))
            {
                isEmpty += "人脸最小检测尺寸、";
            }
            if (string.IsNullOrWhiteSpace(EditItem.MinImgQuality))
            {
                isEmpty += "最小有效图像质量、";
            }
            if (string.IsNullOrWhiteSpace(EditItem.MinCapDistance))
            {
                isEmpty += "最小采集帧间距、";
            }
            if (string.IsNullOrWhiteSpace(EditItem.MaxSaveDistance))
            {
                isEmpty += "最大人脸存储间隔、";
            }
            if (string.IsNullOrWhiteSpace(EditItem.MaxYaw))
            {
                isEmpty += "绕X轴旋转-俯仰角、";
            }
            if (string.IsNullOrWhiteSpace(EditItem.MaxPitch))
            {
                isEmpty += "绕Y轴旋转—偏航角、";
            }
            if (string.IsNullOrWhiteSpace(EditItem.MaxYoll))
            {
                isEmpty += "绕Z轴旋转-翻滚角、";
            }

            if (!string.IsNullOrWhiteSpace(flat))
            {
                MessageBoxHelper.Show("请填写必填项：【" + flat.TrimEnd('、') + "】", "提示");
                return;
            }
            if (!string.IsNullOrWhiteSpace(isEmpty))
            {
                MessageBoxHelper.Show("保存失败，【" + isEmpty.TrimEnd('、') + "】不能为空", "提示");
                return;
            }

            if (!Regex.IsMatch(EditItem.MinFaceWidth.Trim(), @"^[0-9]+$"))
            {
                MessageBoxHelper.Show("请正确填写【人脸最小检测尺寸】，应为正整数", "提示");
                return;
            }
            if (!Regex.IsMatch(EditItem.MinImgQuality.Trim(), @"^[0-9]+$"))
            {
                MessageBoxHelper.Show("请正确填写【最小有效图像质量】，应为正整数", "提示");
                return;
            }
            if (!Regex.IsMatch(EditItem.MaxSaveDistance.Trim(), @"^[0-9]+$"))
            {
                MessageBoxHelper.Show("请正确填写【最小采集帧间距】，应为正整数", "提示");
                return;
            }
            if (!Regex.IsMatch(EditItem.MaxYaw.Trim(), @"^[0-9]+$"))
            {
                MessageBoxHelper.Show("请正确填写【绕X轴旋转-俯仰角】，应为正整数", "提示");
                return;
            }
            if (!Regex.IsMatch(EditItem.MaxPitch.Trim(), @"^[0-9]+$"))
            {
                MessageBoxHelper.Show("请正确填写【绕Y轴旋转—偏航角】，应为正整数", "提示");
                return;
            }
            if (!Regex.IsMatch(EditItem.MaxYoll.Trim(), @"^[0-9]+$"))
            {
                MessageBoxHelper.Show("请正确填写【绕Z轴旋转-翻滚角】，应为正整数", "提示");
                return;
            }

            if (EditItem.ChannelThreshold < 0 || EditItem.ChannelThreshold > 2)
            {
                MessageBoxHelper.Show("请正确填写通道系数：【范围：0-2，默认值：1】", "提示");
                return;
            }
            if (int.Parse(EditItem.MinFaceWidth) < 40)
            {
                MessageBoxHelper.Show("请正确填写人脸最小检测尺寸：【范围：>= 40，默认值：96】", "提示");
                return;
            }
            if (int.Parse(EditItem.MinImgQuality) < 0 || int.Parse(EditItem.MinImgQuality) > 100)
            {
                MessageBoxHelper.Show("请正确填写最小有效图像质量：【范围：0-100，默认值：0】", "提示");
                return;
            }
            if (int.Parse(EditItem.MinCapDistance) < 1 || int.Parse(EditItem.MinCapDistance) > 20)
            {
                MessageBoxHelper.Show("请正确填写最小采集帧间距： 【范围：1 - 20，默认值：20】", "提示");
                return;
            }

            if (CurrentTreeItem.Status == "Region")//新增子节点通道
            {
                var channel = new DataItem()
                {
                    Id = AssistTools.GuidN,
                    Channel = EditItem,
                    Text = EditItem.ChannelName,
                    Parent = CurrentTreeItem
                };
                channel.Channel.RegionId = CurrentTreeItem.Region.ID;
                channel.Channel.Uuid = channel.Id;

                if (!_dataService.ChannelIsExist(channel.Channel.ChannelNo))
                {
                    var result = _dataService.AddChannel(channel);

                    if (!IsFailture(result)) return;

                    CurrentTreeItem.Items.Add(channel);

                    VideoList.Add(channel);

                    if (!string.IsNullOrEmpty(OperationStr))
                    {
                        _dataService.Notice(this, OperationStr, CurrentTreeItem?.Region?.ID.ToString(), channel);
                    }
                }
                else
                {
                    return;
                }
            }
            else if (CurrentTreeItem.Status == "Channel")//编辑通道
            {
                Result result = null;
                #region  坐标操作 只允许新增 不允许修改
                ChannelData data = _dataService.QueryChannel(CurrentTreeItem.Channel.Uuid);

                if (data == null) return;

                if (CurrentTreeItem.Channel.ChannelNo != data.ChannelNo)
                {
                    if (_dataService.ChannelIsExist(CurrentTreeItem.Channel.ChannelNo))
                    {
                        return;
                    }
                }

                result = _dataService.EditChannel(CurrentTreeItem);
                #endregion
                if (result.ErrorCode != StatusCode.Success)
                {
                    Logger.Error("数据提交失败！");
                    MessageBoxHelper.Show("数据提交失败！", "提示");
                    return;
                }
                CurrentTreeItem.Text = EditItem.ChannelName;

                if (!string.IsNullOrEmpty(OperationStr))
                {
                    _dataService.Notice(this, OperationStr, CurrentTreeItem?.Channel?.Uuid, CurrentTreeItem);
                }
            }
            #endregion
            #region  //新增根节点通道
            //else
            //{
            //    var channel = new DataItem()
            //    {
            //        Id = AssistTools.GuidN,
            //        Channel = EditItem,
            //        Text = EditItem.ChannelName,
            //        Parent = CurrentTreeItem
            //    };
            //    channel.Channel.Uuid = channel.Id;

            //    var result = _dataService.AddChannel(channel);
            //    if (!IsFailture(result))
            //        return;

            //    TreeItems.Add(channel);
            //    VideoList.Add(channel);

            //    if (!string.IsNullOrEmpty(obj?.ToString()))
            //        _dataService.Notice(this, obj.ToString(), channel?.Channel?.Uuid, channel);
            //}
            #endregion
            //IsEdited = false;
            InEdit = false;
            //if (CurrentTreeItem?.Parent != null)
            //    CurrentTreeItem = CurrentTreeItem.Parent;

            SetParentExpand(CurrentTreeItem, true);

            //EditItem = new ChannelData();
        }
        #endregion

        #endregion

        #region  Private Methods

        public void RaiseEvent(OperationInfo data)
        {
            _eventAggregator.GetEvent<ModuleInteractionEvent<OperationInfo>>().Publish(data);
        }

        void InitializeVarables()
        {
            TreeItems = new ObservableCollection<DataItem>();
            VideoList = new ObservableCollection<DataItem>();
            EditItem = new ChannelData();
            VideoManager = new List<IVideoManager>();

            #region  接口测试
            //var result = _dataService.QueryChannels();//通过
            //var result = _dataService.InsertChannel();
            //var result = _dataService.UpdateChannel();
            //var result = _dataService.DeleteChannel();//通过
            //var result = _dataService.QueryRegionAndChannel();//通过
            //var result = _dataService.InsertRegions();//通过
            //var result = _dataService.UpdateRegions();//通过
            //var result = _dataService.DeleteRegions();//通过
            #endregion
        }
        private List<RegionsData> GetRegions(DataItem item)
        {
            List<RegionsData> list = new List<RegionsData>();

            GetChildRegions(item, list);

            return list;
        }

        private void GetChildRegions(DataItem item, List<RegionsData> list)
        {
            if (item?.Region != null)
            {
                list.Add(item.Region);

                foreach (var cItem in item.Items)
                {
                    GetChildRegions(cItem, list);
                }
            }
        }
        private void SetVideoListMode()
        {
            IsEdited = _currentTreeItem.Status == "Channel";
        }
        public void SetTreeMenuShowMode()
        {
            if (CurrentTreeItem != null && CurrentTreeItem.Status == "Channel")
            {
                //MenuVisibility = Visibility.Visible;
                RegionVisibility = Visibility.Collapsed;
                ChannelVisibility = Visibility.Visible;
                RootVisibility = Visibility.Collapsed;
                MaintainVisibility = Visibility.Visible;
            }
            else if (CurrentTreeItem != null && CurrentTreeItem.Status == "Region")
            {
                //MenuVisibility = Visibility.Visible;
                RegionVisibility = Visibility.Visible;
                ChannelVisibility = Visibility.Collapsed;
                RootVisibility = Visibility.Collapsed;
                MaintainVisibility = Visibility.Visible;
            }
            else
            {
                //MenuVisibility = Visibility.Visible;
                RegionVisibility = Visibility.Collapsed;
                ChannelVisibility = Visibility.Collapsed;
                RootVisibility = Visibility.Visible;
                MaintainVisibility = Visibility.Collapsed;
            }
        }
        private void SetVideoListSource(DataItem value)
        {
            Video = null;
            VideoList.Clear();
            QueryItemsByRegion(CurrentTreeItem).ForEach((c) =>
            {
                if (c != null)
                {
                    if (c.Channel != null && !string.IsNullOrEmpty(c.Channel.ChannelAddr))
                        c.Channel.IsConnected = ValidIP.Ping(c.Channel.ChannelAddr);

                    VideoList.Add(c);
                }
            });
        }
        private void SetEditPageSource(DataItem value)
        {
            EditItem = value.Channel;
        }
        private void ReBindDetailInfo(DataItem value)
        {
            SetEditPageSource(value);
            SetVideoListSource(value);
            SetVideoListMode();
        }
        private void ResetPageMode()
        {
            if (_currentTreeItem != null && _currentTreeItem.IsInEdit)
            {
                var result = _dataService.EditRegion(_currentTreeItem);
                if (result.ErrorCode == StatusCode.Success)
                    _currentTreeItem.IsInEdit = false;

                if (!string.IsNullOrEmpty(OperationStr))
                    _dataService.Notice(this, OperationStr, _currentTreeItem?.Region?.ID.ToString(), _currentTreeItem);
            }

            if (InEdit)
            {
                //if (MessageBoxHelper.Show("是否退出当前客户端程序？", "系统退出确认",  MessageBoxImage.Question)==MessageBoxResult.Yes)
                ChannelInstance.Cast(EditItem);
                InEdit = false;
            }

            if (!string.IsNullOrEmpty(OperationStr))
                OperationStr = string.Empty;
        }
        /// <summary>
        /// 定位指定节点
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <param name="isexpand"></param>
        private void LocalNodes(string Name, IEnumerable<DataItem> items, bool isexpand)
        {
            ExpandAllNodes(items, false);
            var result = QueryItemsByName(Name, TreeItems);

            if (result != null)
            {
                for (int i = result.Count - 1; i >= 0; i--)
                {
                    var item = result[i];
                    SetParentExpand(item, true);
                    CurrentTreeItem = item;
                }
            }
        }
        private List<DataItem> QueryItemsByName(string Name, IEnumerable<DataItem> items)
        {
            List<DataItem> result = new List<DataItem>();
            QueryItemsByName(Name, items, result);
            return result;
        }
        IEnumerable<ChannelData> QueryChannelsByRegion(DataItem item)
        {
            IEnumerable<DataItem> result = QueryItemsByRegion(item);
            var channels = from m in result
                           select m.Channel;

            return channels;
        }
        IEnumerable<DataItem> QueryItemsByRegion(DataItem item)
        {
            List<DataItem> result = new List<DataItem>();
            GetChildRen(item, result);
            return result;
        }

        #region 递归

        void GetChildRen(DataItem item, List<DataItem> result)
        {
            if (result == null)
                result = new List<DataItem>();
            if (item?.Items == null || item.Items.Count <= 0) return;
            foreach (var it in item.Items)
            {
                if (it != null && it.Status == "Channel")
                    result.Add(it);

                if (it?.Items != null && it.Items.Count > 0)
                    GetChildRen(it, result);
            }
        }

        void RemoveItem(DataItem item, ObservableCollection<DataItem> Items)
        {
            if (item == null) return;
            foreach (var it in Items)
            {
                if (it.Id == item.Id)
                {
                    Items.Remove(it);
                    return;
                }

                if (it.Items != null && it.Items.Count > 0)
                    RemoveItem(item, it.Items);
            }
        }

        void QueryItemsByName(string Name, IEnumerable<DataItem> Items, List<DataItem> result)
        {
            if (result == null)
                result = new List<DataItem>();
            if (string.IsNullOrWhiteSpace(Name)) return;
            foreach (var it in Items)
            {
                if (it.Text.Contains(Name))
                {
                    result.Add(it);
                }

                if (it.Items != null && it.Items.Count > 0)
                    QueryItemsByName(Name, it.Items, result);
            }
        }

        void QueryItemsByID(string Id, IEnumerable<DataItem> Items, List<DataItem> result)
        {
            if (result == null)
                result = new List<DataItem>();
            if (string.IsNullOrWhiteSpace(Id)) return;
            foreach (var it in Items)
            {
                if (it.Id == Id)
                {
                    result.Add(it);
                }

                if (it.Items != null && it.Items.Count > 0)
                    QueryItemsByName(Id, it.Items, result);
            }
        }

        void SetParentExpand(DataItem item, bool isexpand)
        {
            if (item == null) return;
            item.IsExpanded = isexpand;
            if (item.Parent == null) return;
            SetParentExpand(item.Parent, isexpand);
        }

        /// <summary>
        /// 展开/关闭所有子节点
        /// </summary>
        /// <param name="items"></param>
        /// <param name="isexpand"></param>
        void ExpandAllNodes(IEnumerable<DataItem> items, bool isexpand)
        {
            if (items == null) return;
            foreach (var it in items)
            {
                if (it.IsExpanded == !isexpand)
                    it.IsExpanded = isexpand;

                if (it.Items != null && it.Items.Count > 0)
                {
                    ExpandAllNodes(it.Items, isexpand);
                }
            }
        }
        #endregion

        private static DependencyObject VisualUpwardSearch<M>(DependencyObject source)
        {
            while (source != null && source.GetType() != typeof(M))
            {
                if (source is Visual || source is Visual3D)
                    source = VisualTreeHelper.GetParent(source);
                else
                    source = LogicalTreeHelper.GetParent(source);
            }
            return source;
        }

        private bool IsFailture(Result result)
        {
            if (result.ErrorCode != StatusCode.Success)
            {
                Logger.Error("数据提交失败！");
                MessageBoxHelper.Show("数据提交失败！",
                    "提示");
                return false;
            }
            return true;
        }
        #endregion

        #region CommandChannelVideoSearch
        public DelegateCommand<string> CommandChannelVideoSearch { get; private set; }
        private void ExecuteCommandChannelVideoSearch(string commandParameter)
        {
        }

        private bool CanCommandChannelVideoSearch(string commandParameter)
        {
            return true;
        }
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

        #region CommonEvent


        public SofaComponent ThisSofaComponent;
        public IBaseContainer Container;

        public void SofaCommonEventHandler(object sender, SofaEventArgs e)
        {
            if (e.TargetGUID == ThisSofaComponent.GUID)
            {

                if (e.EventType == "Closed")
                {
                    if (IsPlaying)
                        IsStarted = false;
                }
            }
        }
        #endregion
    }
}
