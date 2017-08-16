using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_DynamicComparison.ViewModels;
using SING.Data.DAL.NewCode;
using SING.Data.Help;
using SING.Data.DAL.NewCode.Data;
using FaceCapture = SING.Data.DAL.FaceCapture;

namespace FACE_DynamicComparison.Services
{
    public interface IDataService
    {
        ViewModel VM { get; set; }
        void GenarateCmpData( );
        void GenarateCapData( );
        void LoadTree( );
        void GenarateTaskData( );
        void GenarateReportData( );
        FaceCapture QueryCapImg();

        List<AlertInfoData> QueryNewestAlerts();
        AlertInfoData ReCheckAlert();
        List<AlertInfoData> GetAlertDetail();
        List<StatisticsData> CheckedStatistics();
        List<JobsData> QueryJobs();
        SysUser Login();

        int GetPublishCount();
        int GetAlertCount();
        int GetUncheckedCount();
        int FindStatisticalCount();

        string QueryCapState();
        string QueryComState();
        string QueryMethodeState();
        bool SubscribeSec();
        bool UnSubscribeSec();
        bool SubscribeOriginal();
        bool UnSubscribeOriginal();
       
    }
}