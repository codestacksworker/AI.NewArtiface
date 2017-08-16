using FACE_MonitorTasks.ViewModels;
using SING.Data.DAL.NewCode.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FACE_MonitorTasks.Services
{
    public interface IDataService
    {
        void SearchFtdb(ViewModel viewModel);
        void SearchChannel(ViewModel viewModel);
        void SearchMonitorTask(ViewModel viewModel);
        void SearchCmpStrategy(ViewModel viewModel);

        void CreateMonitorTask(ViewModel viewModel);
        void DeleteMonitorTask(ViewModel viewModel);
        void SaveMonitorTask(ViewModel viewModel);
        void CreateCmpStrategy(ViewModel viewModel);
        void DeleteCmpStrategy(ViewModel viewModel);
        void SaveCmpStrategy(ViewModel viewModel);

        #region BasicDataSource 所需的基础数据源

        void GetJobType(ViewModel viewModel);
        void GetJobMethodName(ViewModel viewModel);
        void GetFaceObjectData(ViewModel viewModel);

        #endregion

        #region  接口测试       
        List<JobsData> QueryJobsStatistics(ViewModel viewModel);
        List<JobsData> QueryJobs(ViewModel viewModel);
        List<JobsData> QueryJobsDetail(ViewModel viewModel);
        JobsData InsertJobs(ViewModel viewModel);
        bool UpdateJobs(ViewModel viewModel);
        bool DeleteJobs(ViewModel viewModel);
        ObservableCollection<JobMethodData> Query(ViewModel viewModel);
        JobMethodData InsertJobMethod();
        JobMethodData UpdataJobMethod();
        JobMethodData DeleteJobMethod();
        #endregion

    }
}