using FACE_MonitorTasks.Services.HelpService;
using FACE_MonitorTasks.ViewModels;
using SING.Data.DAL.NewCode.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;

namespace FACE_MonitorTasks.Services
{
    [Export(typeof(IDataService))]
    public class DataService : IDataService
    {
        public void SearchFtdb(ViewModel viewModel)
        {
            new HelpService.FtdbService().DoSearch(viewModel);
        }

        public void SearchChannel(ViewModel viewModel)
        {
            new HelpService.ChannelService().DoSearch(viewModel);
        }

        public void SearchMonitorTask(ViewModel viewModel)
        {
            new HelpService.MonitorTaskService().DoSearch(viewModel);

        }

        public void SearchCmpStrategy(ViewModel viewModel)
        {
            new JobMethodService().Query(viewModel);
        }

        public void CreateMonitorTask(ViewModel viewModel)
        {
            throw new NotImplementedException();
        }
        public void DeleteMonitorTask(ViewModel viewModel)
        {
            new JobsService().Delete(viewModel);
        }
        public void SaveMonitorTask(ViewModel viewModel)
        {
            throw new NotImplementedException();
        }


        public void CreateCmpStrategy(ViewModel viewModel)
        {
            throw new NotImplementedException();
        }
        public void DeleteCmpStrategy(ViewModel viewModel)
        {
            throw new NotImplementedException();
        }
        public void SaveCmpStrategy(ViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        #region 基础类型Basic Data Source

        /// <summary>
        /// Get Job Type DataSource
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public void GetJobType(ViewModel viewModel)
        {
            new BasicDataSource().GetJobType(viewModel);
        }

        /// <summary>
        /// Get FaceObject DataSource
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public void GetFaceObjectData(ViewModel viewModel)
        {
            new BasicDataSource().GetFaceObjectData(viewModel);
        }

        /// <summary>
        /// Get JobMethod DataSource
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public void GetJobMethodName(ViewModel viewModel)
        {
            new BasicDataSource().GetStrategyName(viewModel);
        }
        #endregion

        #region  接口测试      
        public List<JobsData> QueryJobsStatistics(ViewModel viewModel)
        {
            JobsService service = new JobsService();
            return service.QueryStatistics(viewModel);
        }

        public List<JobsData> QueryJobs(ViewModel viewModel)
        {
            JobsService service = new JobsService();
            return service.Query(viewModel);
        }

        public List<JobsData> QueryJobsDetail(ViewModel viewModel)
        {
            JobsService service = new JobsService();
            return service.QueryDetail(viewModel);
        }

        public JobsData InsertJobs(ViewModel viewModel)
        {
            JobsService service = new JobsService();
            return service.Insert(viewModel);
        }

        public bool UpdateJobs(ViewModel viewModel)
        {
            JobsService service = new JobsService();
            return service.Update(viewModel);
        }

        public bool DeleteJobs(ViewModel viewModel)
        {
            JobsService service = new JobsService();
            return service.Delete(viewModel);
        }

        public ObservableCollection<JobMethodData> Query(ViewModel viewModel)
        {
            JobMethodService service = new JobMethodService();
            return service.Query(viewModel);
        }

        public JobMethodData InsertJobMethod()
        {
            JobMethodService service = new JobMethodService();
            return service.InsertJobMethod();
        }

        public JobMethodData UpdataJobMethod()
        {
            JobMethodService service = new JobMethodService();
            return service.UpdataJobMethod();
        }

        public JobMethodData DeleteJobMethod()
        {
            JobMethodService service = new JobMethodService();
            return service.DeleteJobMethod();
        }



        #endregion

    }
}