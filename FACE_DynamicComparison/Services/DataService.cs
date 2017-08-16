using System.Collections.Generic;
using System.ComponentModel.Composition;
using FACE_DynamicComparison.ViewModels;
using FACE_DynamicComparison.Services.HelpService;
using SING.Data.DAL.NewCode;
using SING.Data.DAL.NewCode.Data;
using FaceCapture = SING.Data.DAL.FaceCapture;
using System;

namespace FACE_DynamicComparison.Services
{
    [Export(typeof(IDataService))]
    public class DataService : IDataService
    {
        [Import]
        private Lazy<ISysUserService> SysUserSvc=null;
        [Import]
        private Lazy<IRegionService> RegionSvc = null;
        [Import]
        private Lazy<ITargetAlertService> TargetAlertSvc = null;
        [Import]
        private Lazy<ICapPreviewService> CapPreviewSvc = null;
        [Import]
        private Lazy<IAlertService> AlertSvc = null;
        [Import]
        private Lazy<IAlarmService> AlarmSvc = null;
        [Import]
        private Lazy<ITaskService> TaskSvc = null;
        [Import]
        private Lazy<IStatisticsService> StatisticsSvc = null;
        [Import]
        private Lazy<ISysSubscribeService> SysSubscribeSvc = null;

        public ViewModel VM { get; set; }

        public void GenarateCmpData()
        {
            TargetAlertSvc.Value.DoSearch(VM); 
        }

        public void GenarateCapData()
        {
            CapPreviewSvc.Value.DoSearch(VM); 
        }

        public FaceCapture QueryCapImg()
        {
          return  AlertSvc.Value.QueryCapImg(); 
        }

        public void LoadTree()
        {
            RegionSvc.Value.DoSearch(VM);
        }

        public void GenarateTaskData()
        {
            TaskSvc.Value.DoSearch(VM);
        }

        public void GenarateReportData()
        {
            TaskSvc.Value.GenarateReportData();
        }

        public List<AlertInfoData> QueryNewestAlerts()
        {
            return AlertSvc.Value.QueryNewestAlerts();
        }

        public AlertInfoData ReCheckAlert()
        {
            return AlertSvc.Value.ReCheckAlert();
        }

        public List<AlertInfoData> GetAlertDetail()
        {
            return AlertSvc.Value.GetAlertDetail();
        }

        public List<JobsData> QueryJobs()
        {
            return AlarmSvc.Value.QueryJobs();
        }

        public SysUser Login()
        {
            return SysUserSvc.Value.Login();
        }


        public int GetPublishCount()
        {
            return StatisticsSvc.Value.GetPublishCount();
        }

        public int GetAlertCount()
        {
            return StatisticsSvc.Value.GetAlertCount();
        }

        public int GetUncheckedCount()
        {
            return StatisticsSvc.Value.GetUncheckedCount();
        }

        public List<StatisticsData> CheckedStatistics()
        {
            return StatisticsSvc.Value.CheckedStatistics();
        }

        public string QueryCapState()
        {
            return StatisticsSvc.Value.QueryCapState();
        }

        public string QueryComState()
        {
            return StatisticsSvc.Value.QueryComState();
        }

        public string QueryMethodeState()
        {
            return StatisticsSvc.Value.QueryMethodeState();
        }
        
        public int FindStatisticalCount()
        {
            return StatisticsSvc.Value.FindStatisticalCount();
        }


        public bool SubscribeSec()
        {
            return SysSubscribeSvc.Value.SubscribeSec();
        }

        public bool UnSubscribeSec()
        {
            return SysSubscribeSvc.Value.UnSubscribeSec();
        }

        public bool SubscribeOriginal()
        {
            return SysSubscribeSvc.Value.SubscribeOriginal();
        }

        public bool UnSubscribeOriginal()
        {
            return SysSubscribeSvc.Value.UnSubscribeOriginal();
        }

    }
}