using Dev_SING.Data.BaseTools;
using FACE_MonitorTasks.ViewModels;
using SING.Data.DAL.NewCode;
using SING.Data.DAL.NewCode.Data;
using SING.Data.DAL.NewCode.Condition;
using System.Collections.Generic;
using System;

namespace FACE_MonitorTasks.Services.HelpService
{
    /// <summary>
    /// 布控任务的增删该查接口
    /// </summary>
    public class JobsService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public List<JobsData> QueryStatistics(ViewModel viewModel)
        {
            Pager<JobsCondition> pager = new Pager<JobsCondition>
            {
                PageNo = 1,
                PageRows = 20,
                Condition = new JobsCondition
                {
                    LoginUuid = "admin",
                    Name = "任务名称"
                }
                //Condition = new System.Collections.Hashtable()
            };
            //pager.Condition.Add("loginUid", "admin");
            //pager.Condition.Add("name", "任务名称1");
            Jobs job = new Jobs();
            Pager<JobsCondition, Jobs> p = job.QueryStatistics(pager);
            List<JobsData> result = new List<JobsData>();
            p.ResultList.ForEach(j => { result.Add(j.ToUIData<JobsData>()); });
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public List<JobsData> Query(ViewModel viewModel)
        {
            Pager<JobsCondition> pager = new Pager<JobsCondition>
            {
                PageNo = 1,
                PageRows = 20,
                //Condition = new System.Collections.Hashtable()
            };
            //pager.Condition.Add("name", "任务名称1");
            Jobs job = new Jobs();
            Pager<JobsCondition, Jobs> p = job.Query(pager);
            List<JobsData> result = new List<JobsData>();
            p.ResultList.ForEach(j => { result.Add(j.ToUIData<JobsData>()); });
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public List<JobsData> QueryDetail(ViewModel viewModel)
        {
            JobsData data = new JobsData { Uuid = AssistTools.GuidN, Uid = "admin'" };
            Jobs job = data.ToData<Jobs>();
            List<Jobs> list = job.QueryDetail();
            List<JobsData> result = new List<JobsData>();
            list.ForEach(j =>
            {
                result.Add(j.ToUIData<JobsData>());
            });
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public JobsData Insert(ViewModel viewModel)
        {
            try
            {
                viewModel.EditedTask.Uuid = AssistTools.GuidN;
                viewModel.EditedTask.Uid = "codestacks";
                viewModel.EditedTask.Type += 1;
                viewModel.EditedTask.BeginHours = Convert.ToInt32(viewModel.EditedTask.UiBeginTime.Substring(0, 2));
                viewModel.EditedTask.BeginMinutes = Convert.ToInt32(viewModel.EditedTask.UiBeginTime.Substring(3, 2));
                viewModel.EditedTask.EndHours = Convert.ToInt32(viewModel.EditedTask.UiEndTime.Substring(0, 2)); viewModel.EditedTask.EndMinutes = Convert.ToInt32(viewModel.EditedTask.UiEndTime.Substring(3, 2));

                string begin = Convert.ToDateTime(viewModel.EditedTask.BeginDateStr).ToString("yyyy-MM-dd");
                string end = Convert.ToDateTime(viewModel.EditedTask.EndDateStr).ToString("yyyy-MM-dd");

                viewModel.EditedTask.BeginDateStr = begin + " " + viewModel.EditedTask.UiBeginTime + "00";
                viewModel.EditedTask.EndDateStr = end + " " + viewModel.EditedTask.UiEndTime + "00";

                if (viewModel.EditedTask.State != 1)
                    viewModel.EditedTask.State = 0;

                Jobs obj = viewModel.EditedTask.ToData<Jobs>();
                var result = obj.Insert().ToUIData<JobsData>();
                return result;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return new JobsData();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public bool Update(ViewModel viewModel)
        {
            JobsData data = new JobsData
            {
                Uuid = AssistTools.GuidN,
                Type = 1,
                State = 1,
                Name = "布控任务1",
                BeginDateStr = "2017-08-01 00:59:26",
                EndDateStr = "2017-08-01 00:59:26",
                DaySet = "1,2,3,4,5",
                BeginHours = 12,
                BeginMinutes = 30,
                EndHours = 23,
                EndMinutes = 60,
                BeginHour2 = 12,
                BeginMin2 = 30,
                EndHour2 = 23,
                EndMin2 = 60,
                Description = "哈哈",
                MethodId = "10",
                Uid = "admin"
            };
            Jobs obj = data.ToData<Jobs>();
            return obj.Update();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public bool Delete(ViewModel viewModel)
        {
            var result = new Jobs().Delete(viewModel.WhereData.UuidArray);
            return result;
        }



    }
}
