using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Data;
using FACE_TemplateManagement.Services;
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
using FACE_TemplateManagement.Services.HelpService;
using SING.Data.BaseTools;

namespace FACE_TemplateManagement.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ViewModel : NotificationObject, INavigationAware
    {
        public readonly IDataService _dataService;
        public readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;
        private readonly IServiceLocator _serviceLocator;

        [ImportingConstructor]
        public ViewModel(IDataService dataService, IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
            SyncService.Initialize(this);

            QueryConditionFtdb = new QueryCondition();
            QueryConditionFot = new QueryCondition();
            QueryConditionFot.Count = 20;
            _dataService.SearchFtdb(this);

            DefDbTypeDatas = BasicData.DefDbTypes;

            //CommandSearchFtdb = new DelegateCommand<string>(ExecuteCommandSearchFtdb);
            CommandCreateFtdb = new DelegateCommand<string>(ExecuteCommandCreateFtdb);
            CommandSaveFtdb = new DelegateCommand<string>(ExecuteCommandSaveFtdb);
            CommandDeleteFtdb = new DelegateCommand<string>(ExecuteCommandDeleteFtdb);

            CommandSearchFot = new DelegateCommand<string>(ExecuteCommandSearchFot);
            CommandCreateFot = new DelegateCommand<string>(ExecuteCommandCreateFot);
            CommandSaveFot = new DelegateCommand<string>(ExecuteCommandSaveFot);
            CommandDeleteFot = new DelegateCommand<string>(ExecuteCommandDeleteFot);
            CommandCreateFt = new DelegateCommand<string>(ExecuteCommandCreateFt);
            CommandSetMainFt = new DelegateCommand<string>(ExecuteCommandSetMainFt);
            CommandDeleteFt = new DelegateCommand<string>(ExecuteCommandDeleteFt);
            CommandBatchCreateFt = new DelegateCommand<string>(ExecuteCommandBatchCreateFt);
            CommandBatchDeleteFt = new DelegateCommand<string>(ExecuteCommandBatchDeleteFt);
           

            CommandFtdbItemChanged = new DelegateCommand<string>(ExecuteCommandFtdbItemChanged, CanExecuteCommandFtdbItemChanged);
            CommandChangePage = new DelegateCommand<string>(ExecuteCommandChangePage);
            CommandFtdbEditItemChanged = new DelegateCommand<object>(ExecuteCommandFtdbEditItemChanged);
            CommandSetFtDeed = new DelegateCommand<string>(ExecuteCommandSetFtDeed);

            #region  接口测试
            //var result = _dataService.QueryFaceObjects();//通过
            //var model = _dataService.InsertFaceObject();//通过
            //var model = _dataService.UpdateFaceObject();//通过
            //var model = _dataService.DeleteFaceObject();//通过
            //var result = _dataService.QueryAllTemplates();//通过
            //var result = _dataService.Insert();//通过
            //var result = _dataService.Update();//通过
            //var result = _dataService.Delete();//通过
            //var result = _dataService.QueryTemplateDetail();//通过
            #endregion
        }

        #region Properties

        private ProgressSattus _progressSattus;
        public ProgressSattus ProgressSattus
        {
            get
            {
                return _progressSattus;
            }
            set
            {
                _progressSattus = value;
                RaisePropertyChanged("ProgressSattus");
            }
        }


        private QueryCondition _queryConditionFtdb;
        public QueryCondition QueryConditionFtdb
        {
            get { return _queryConditionFtdb; }
            set
            {
                _queryConditionFtdb = value;
                RaisePropertyChanged("QueryCondition");
            }
        }

        private QueryCondition _queryConditionFot;

        public QueryCondition QueryConditionFot
        {
            get { return _queryConditionFot; }
            set
            {
                _queryConditionFot = value;
                RaisePropertyChanged("QueryConditionFot");
            }
        }

        private FaceTemplateDBData _currentFtdb;
        public FaceTemplateDBData CurrentFtdb
        {
            get { return _currentFtdb; }
            set
            {
                _currentFtdb = value;
                RaisePropertyChanged("CurrentFtdb");
            }
        }

        private FaceTemplateDBData _currentFtdbEdit;
        public FaceTemplateDBData CurrentFtdbEdit
        {
            get { return _currentFtdbEdit; }
            set
            {
                _currentFtdbEdit = value;
                RaisePropertyChanged("CurrentFtdbEdit");
            }
        }

        private List<FaceTemplateDBData> _ftdbList;
        public List<FaceTemplateDBData> FtdbList
        {
            get { return _ftdbList; }
            set
            {
                _ftdbList = value;
                RaisePropertyChanged("FtdbList");
            }
        }

        private ICollectionView _ftdbCV;
        public ICollectionView FtdbCV
        {
            get { return _ftdbCV; }
            set
            {
                _ftdbCV = value;
                RaisePropertyChanged("FtdbCV");
            }
        }

        private List<DefDbTypeData> _defDbTypeDatas;
        public List<DefDbTypeData> DefDbTypeDatas
        {
            get { return _defDbTypeDatas; }
            set
            {
                _defDbTypeDatas = value;
                RaisePropertyChanged("DefDbTypeDatas");
            }
        }


        private List<FaceObjTempViewData> _fotList;
        public List<FaceObjTempViewData> FotList
        {
            get { return _fotList; }
            set
            {
                _fotList = value;
                RaisePropertyChanged("FotList");
            }
        }

        private FaceObjTempViewData _currentFot;
        public FaceObjTempViewData CurrentFot
        {
            get { return _currentFot; }
            set
            {
                _currentFot = value;
                RaisePropertyChanged("CurrentFot");
            }
        }

        private FaceObjTempViewData _currentFotEdit;
        public FaceObjTempViewData CurrentFotEdit
        {
            get { return _currentFotEdit; }
            set
            {
                _currentFotEdit = value;
                RaisePropertyChanged("CurrentFotEdit");
            }
        }

        private ICollectionView _fotCV;
        public ICollectionView FotCV
        {
            get { return _fotCV; }
            set
            {
                _fotCV = value;
                RaisePropertyChanged("FotCV");
            }
        }

        private bool _IsEditorShow;
        public bool IsEditorShow
        {
            get
            {
                return _IsEditorShow;
            }
            set
            {
                _IsEditorShow = value;
                RaisePropertyChanged("IsEditorShow");
            }
        }

        private bool _isAddFot;
        public bool IsAddFot
        {
            get
            {
                return _isAddFot;
            }
            set
            {
                _isAddFot = value;
                RaisePropertyChanged("IsAddFot");
            }
        }

        #endregion

        #region Command

        #region CommandSearchFtdb

        public DelegateCommand<string> CommandSearchFtdb { get; private set; }

        private void ExecuteCommandSearchFtdb(string commandParameter)
        {
            if (QueryConditionFtdb == null) return;

            FtdbList = BasicData.FTDBDatas;
            if (FtdbList == null) FtdbList = new List<FaceTemplateDBData>();

            //修改为动态查询
            var andBuilder = PredicateBuilder.True<FaceTemplateDBData>();
            if (!string.IsNullOrEmpty(QueryConditionFtdb.TemplateDbName))
            {
                andBuilder = andBuilder.And(p => p.TemplateDbName.Contains(QueryConditionFtdb.TemplateDbName));
            }
            if (!string.IsNullOrEmpty(QueryConditionFtdb.TemplateDbDescription))
            {
                andBuilder = andBuilder.And(p => p.TemplateDbDescription.Contains(QueryConditionFtdb.TemplateDbDescription));
            }
            if (QueryConditionFtdb.IsUsed != 0)
            {
                andBuilder = andBuilder.And(p => p.IsUsed.Equals(QueryConditionFtdb.IsUsed));
            }
            //截止时间不选
            if (!string.IsNullOrEmpty(QueryConditionFtdb.StartTime) && string.IsNullOrEmpty(QueryConditionFtdb.EndTime))
            {
                DateTime startTime = QueryConditionFtdb.StartTime.SToDateTime();
                DateTime endTime = DateTime.MaxValue;

                andBuilder = andBuilder.And(p => startTime <= p.CreateTime.SToDateTime() && endTime >= p.CreateTime.SToDateTime());
            }
            //开始时间不选
            if (string.IsNullOrEmpty(QueryConditionFtdb.StartTime) && !string.IsNullOrEmpty(QueryConditionFtdb.EndTime))
            {
                DateTime startTime = DateTime.MinValue;
                DateTime endTime = QueryConditionFtdb.EndTime.SToDateTime();

                andBuilder = andBuilder.And(p => startTime <= p.CreateTime.SToDateTime() && endTime >= p.CreateTime.SToDateTime());
            }
            if (!string.IsNullOrEmpty(QueryConditionFtdb.StartTime) && !string.IsNullOrEmpty(QueryConditionFtdb.EndTime))
            {
                DateTime startTime = QueryConditionFtdb.StartTime.SToDateTime();
                DateTime endTime = QueryConditionFtdb.EndTime.SToDateTime();

                andBuilder = andBuilder.And(p => startTime <= p.CreateTime.SToDateTime() && endTime >= p.CreateTime.SToDateTime());
            }

            FtdbList = FtdbList.Where(andBuilder.Compile()).ToList();

            FtdbCV = new ListCollectionView(FtdbList);
            FtdbCV.CurrentChanged += new EventHandler(FtdbSelectedItemChanged);
            GetFtdbCurrentItem();
        }
        #endregion

        #region CommandFtdbItemChanged

        public DelegateCommand<object> CommandFtdbEditItemChanged { get; private set; }
        private void ExecuteCommandFtdbEditItemChanged(object commandParameter)
        {
            if (CurrentFtdb == null) return;
            FtdbCV.MoveCurrentTo(CurrentFtdb);
        }

        public DelegateCommand<string> CommandFtdbItemChanged { get; private set; }

        private void ExecuteCommandFtdbItemChanged(string commandParameter)
        {
            GetFtdbCurrentItem();
        }

        private bool CanExecuteCommandFtdbItemChanged(string commandParameter)
        {
            return FtdbCV.CurrentItem != null;
        }

        public void FtdbSelectedItemChanged(object sender, EventArgs e)
        {
            CommandFtdbItemChanged.RaiseCanExecuteChanged();
            CommandFtdbItemChanged.Execute("");
        }

        public void GetFtdbCurrentItem()
        {
            if (FtdbCV != null && FtdbCV.CurrentItem != null)
            {
                CurrentFtdb = FtdbCV.CurrentItem as FaceTemplateDBData;
                CurrentFtdbEdit = new FaceTemplateDBData();
                FaceTemplateDBData.CopyValue(CurrentFtdb, CurrentFtdbEdit);
            }
            else
            {
                CurrentFtdb = null;
                CurrentFtdbEdit = null;
                CommandCreateFtdb.Execute("");
            }

            QueryConditionFot.StartNum = 0;

            QueryConditionFot.PageNow = 1;

            _dataService.SearchFot(this);
          
            IsEditorShow = false;

            IsAddFot = false;
        }
        #endregion

        #region CommandSaveFtdb

        public DelegateCommand<string> CommandSaveFtdb { get; private set; }

        private void ExecuteCommandSaveFtdb(string commandParameter)
        {
            _dataService.SaveFtdb(this);
        }
        #endregion

        #region CommandCreateFtdb

        public DelegateCommand<string> CommandCreateFtdb { get; private set; }

        private void ExecuteCommandCreateFtdb(string commandParameter)
        {
            //清理人脸对象列表
            FotList = null;
            FotCV = null;
            CurrentFotEdit = null;
            CurrentFot = null;
            IsEditorShow = false;
            IsAddFot = false;

            _dataService.CreateFtdb(this);
        }
        #endregion

        #region CommandDeleteFtdb

        public DelegateCommand<string> CommandDeleteFtdb { get; private set; }

        private void ExecuteCommandDeleteFtdb(string commandParameter)
        {
            _dataService.DeleteFtdb(this);
        }
        #endregion

        #region CommandSearchFot

        public DelegateCommand<string> CommandSearchFot { get; private set; }

        private void ExecuteCommandSearchFot(string commandParameter)
        {
            QueryConditionFot.StartNum = 0;
            QueryConditionFot.PageNow = 1;

            _dataService.SearchFot(this);
        }

        public void FotSelectedItemChanged(object sender, EventArgs e)
        {
            GetFotCurrentItem();
        }

        public void GetFotCurrentItem()
        {
            if (FotCV != null && FotCV.CurrentItem != null)
            {
                CurrentFot = FotCV.CurrentItem as FaceObjTempViewData;
                CurrentFotEdit = DataConvert.CopyViewData(CurrentFot);
            }
            else
            {
                CurrentFot = null;
                CurrentFotEdit = null;
            }
        }
        #endregion

        #region CommandChangePage
        public DelegateCommand<string> CommandChangePage { get; private set; }

        private void ExecuteCommandChangePage(string commandParameter)
        {
            if (commandParameter == "Up")
            {
                if (QueryConditionFot.PageNow > 1)
                {
                    QueryConditionFot.PageNow--;
                    QueryConditionFot.StartNum = (QueryConditionFot.PageNow - 1) * QueryConditionFot.Count;
                    _dataService.SearchFot(this);
                }
            }
            else
            {
                if (this.FotList.Count >= QueryConditionFot.Count)
                {
                    QueryConditionFot.PageNow++;
                    QueryConditionFot.StartNum = (QueryConditionFot.PageNow - 1) * QueryConditionFot.Count;
                    _dataService.SearchFot(this);
                }
            }
        }
        #endregion
        
        #region CommandCreateFot

        public DelegateCommand<string> CommandCreateFot { get; private set; }

        private void ExecuteCommandCreateFot(string commandParameter)
        {
            _dataService.CreateFot(this);
            IsEditorShow = CurrentFtdb != null;
        }
        #endregion

        #region CommandSaveFot

        public DelegateCommand<string> CommandSaveFot { get; private set; }

        private void ExecuteCommandSaveFot(string commandParameter)
        {
            _dataService.SaveFot(this);
        }
        #endregion

        #region CommandDeleteFot

        public DelegateCommand<string> CommandDeleteFot { get; private set; }

        private void ExecuteCommandDeleteFot(string commandParameter)
        {
            _dataService.DeleteFot(this);
        }
        #endregion

        #region CommandCreateFt

        public DelegateCommand<string> CommandCreateFt { get; private set; }

        private void ExecuteCommandCreateFt(string commandParameter)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Multiselect = false;
                fileDialog.Title = "请选择模板照片";
                fileDialog.Filter = "jpg|*.jpg|bmp|*.bmp|png|*.png|gif|*gif|icon|*icon";
                if (fileDialog.ShowDialog() == true)
                {

                    string FilePath = fileDialog.FileName;

                    int index = int.Parse(commandParameter);

                    InsertFotTemps(FilePath, index);

                    RaisePropertyChanged("CurrentFotEdit");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("【Error】：选择模板照片异常：【ViewModel】-->CommandCreateFt", ex);
                MessageBoxHelper.Show("选择模板照片失败！", "提示", MessageBoxImage.Error);
            }
        }

        private void InsertFotTemps(string path, int index)
        {
            if (CurrentFotEdit == null) return;

            if (CurrentFotEdit.Temps == null)
            {
                CurrentFotEdit.Temps = new List<FaceTemplateData>() {null,null,null,null,null};

                FaceTemplateData ft = new FaceTemplateData();

                ft.Uuid = Guid.NewGuid().ToString();
                ft.FTDBID = CurrentFotEdit.FTDBID;
                ft.ObjId = CurrentFotEdit.Uuid;
                ft.Deed = (int)FtStatus.Added;
                ft.FtIndex = index;
                ft.FtImage = ImageHelper.GetPicThumbnail(path, 112, 126);
                ft.FtImgTime = ImageHelper.GetCreateTime(path).DToString();
                //CurrentFotEdit.Temps.Add(ft);
                CurrentFotEdit.Temps[index] = ft;
            }
            else
            {
                FaceTemplateData ft = CurrentFotEdit.Temps[index];

                if (ft == null)
                {
                    ft = new FaceTemplateData();

                    ft.Uuid = Guid.NewGuid().ToString();
                    ft.FTDBID = CurrentFotEdit.FTDBID;
                    ft.ObjId = CurrentFotEdit.Uuid;
                    ft.Deed = (int)FtStatus.Added;
                    ft.FtIndex = index;
                    ft.FtImage = ImageHelper.GetPicThumbnail(path, 112, 126);
                    ft.FtImgTime = ImageHelper.GetCreateTime(path).DToString();
                    ft.FTDBID = CurrentFotEdit.FTDBID;
                    //CurrentFotEdit.Temps.Add(ft);
                    CurrentFotEdit.Temps[index] = ft;
                }
                else
                {
                    ft.FtIndex = index;
                    ft.Deed = 3;
                    ft.FtImage = null;
                    ft.ImgMd = null;
                    ft.FTDBID = CurrentFotEdit.FTDBID;
                    ft.ObjId = CurrentFotEdit.Uuid;
                    ft.FtImage = ImageHelper.GetPicThumbnail(path, 112, 126);
                    //ft.FtImage = ImageConvert.PathToBinaryStream(path);
                    ft.FtImgTime = ImageHelper.GetCreateTime(path).DToString();

                    if (ft.Uuid == CurrentFotEdit.MainFtID)
                    {
                        CommandSetMainFt.Execute(index.ToString());
                    }
                }
            }

            if (string.IsNullOrEmpty(CurrentFotEdit.MainFtID))
            {
                CommandSetMainFt.Execute(index.ToString());
            }
        }
        #endregion

        #region CommandBatchCreateFt

        public DelegateCommand<string> CommandBatchCreateFt { get; private set; }

        private void ExecuteCommandBatchCreateFt(string commandParameter)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Title = "请选择模板照片";
                fileDialog.Filter = "jpg|*.jpg|bmp|*.bmp|png|*.png|gif|*gif|icon|*icon";
                fileDialog.FileName = string.Empty;
                fileDialog.Multiselect = true;
                fileDialog.FilterIndex = 1;
                fileDialog.RestoreDirectory = true;
                if (fileDialog.ShowDialog() == true)
                {

                    string[] FileNames = fileDialog.FileNames;

                    if (FileNames == null) return;

                    int maxNum = 5 - CurrentFotEdit.Temps.Where(p => p != null && p.Deed != (int) FtStatus.Deleted).Count();

                    if (FileNames.Length > maxNum)
                    {
                        MessageBoxHelper.Show("模板选择最大限度：【五张】;剩余可选 " + maxNum + " 张模板!", "提示");
                        return;
                    }
                    for (int i = 0; i < FileNames.Length; i++)
                    {
                        string filePath = FileNames[i];

                        for (int j = 0; j < 5; j++)
                        {
                            int index = CurrentFotEdit.Temps.FindIndex(p => p != null && p.FtIndex == j);

                            if (index == -1)
                            {
                                InsertFotTemps(filePath, j);
                                break;
                            }
                        }
                    }
                    RaisePropertyChanged("CurrentFotEdit");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("【Error】：批量选择模板照片异常：【ViewModel】-->CommandBatchCreateFt", ex);
                MessageBoxHelper.Show("批量选择模板照片异常！", "提示", MessageBoxImage.Error);
            }
        }
        #endregion

        #region CommandBatchDeleteFt

        public DelegateCommand<string> CommandBatchDeleteFt { get; private set; }

        private void ExecuteCommandBatchDeleteFt(string commandParameter)
        {
            _dataService.BatchDeleteFt(this);
            RaisePropertyChanged("CurrentFotEdit");
        }
        #endregion

        #region CommandSetMainFt
        public DelegateCommand<string> CommandSetMainFt { get; private set; }
        private void ExecuteCommandSetMainFt(string commandParameter)
        {
            if (!string.IsNullOrEmpty(commandParameter))
            {
                int ftindex = Convert.ToInt32(commandParameter);

                _dataService.SetMainFt(this, ftindex);
            }
           
            RaisePropertyChanged("CurrentFotEdit");
        }
        #endregion

        #region CommandDeleteFt
        public DelegateCommand<string> CommandDeleteFt { get; private set; }

        private void ExecuteCommandDeleteFt(string commandParameter)
        {
            if (!string.IsNullOrEmpty(commandParameter))
            {
                int ftindex = Convert.ToInt32(commandParameter);

                _dataService.RemoveFt(this, ftindex);
            }

            RaisePropertyChanged("CurrentFotEdit");
        }
        #endregion

        #region CommandDeleteFt
        public DelegateCommand<string> CommandSetFtDeed { get; private set; }

        private void ExecuteCommandSetFtDeed(string commandParameter)
        {
            try
            {
                if (!string.IsNullOrEmpty(commandParameter))
                {
                    int ftindex = Convert.ToInt32(commandParameter);

                    if (CurrentFotEdit != null && CurrentFotEdit.Temps != null)
                    {
                        FaceTemplateData ft = CurrentFotEdit.Temps.Find(p => p!= null && p.FtIndex == ftindex);

                        FaceTemplateData oft = CurrentFot.Temps != null ? CurrentFot.Temps.Find(p => p != null && p.FtIndex == ftindex) : null;

                        if ((ft != null && ft.Deed == (int)FtStatus.Unchanged) && (oft == null || (!string.IsNullOrEmpty(oft.FtImgTime) && !oft.FtImgTime.Equals(ft.FtImgTime))))
                        {
                            ft.Deed = (int)FtStatus.ModifiedOnlyInfo;
                        }
                    }
                }

                RaisePropertyChanged("CurrentFotEdit");
            }
            catch(Exception ex)
            {
                Logger.Error("【Error】：设置模版行为异常！【ViewModel】-->【函数名】：CommandSetFtDeed", ex);
            }
            
        }
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
