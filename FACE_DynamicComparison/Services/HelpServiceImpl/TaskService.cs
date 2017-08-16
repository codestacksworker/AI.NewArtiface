using FACE_DynamicComparison.Models;
using SING.Data.DAL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.DAL.NewCode;
using SING.Data.DAL.NewCode.Condition;
using SING.Data.DAL.NewCode.Data;

namespace FACE_DynamicComparison.Services.HelpServiceImpl
{
    [Export(typeof(HelpService.ITaskService))]
    public class TaskService:SearchServiceBase,HelpService.ITaskService
    {
        public override void Search()
        {
            Pager<JobsCondition> pager = new Pager<JobsCondition>
            {
                PageNo = 1,
                PageRows = 20,
                Condition = new JobsCondition
                {
                    LoginUuid = "227159349775419893c9ad3a95dfaf40"
                }
            };

            VM.TaskReports.Clear();
            Jobs job = new Jobs();
            var p = job.QueryStatistics(pager);
            if (p != null&& p.ResultList!=null)
            {
                p.ResultList.ForEach(j => VM.TaskReports.Add(j.ToUIData<JobsData>()));
            }
        }


        public void GenarateReportData()
        {
            VM.Persons.Clear();
            VM.Alerts.Clear();
            VM.Alarms.Clear();

            StatisticsData condition = new StatisticsData();
            condition.StartTime = "2017-08-01 00:59:26";
            condition.EndTime = "2017-08-11 0:59:27";
            condition.JobId = VM.CurrentReports.Uuid;
            Statistics model = condition.ToData<Statistics>();
            var list = model.CheckedStatistics();
            if (list != null)
            {
                foreach(var item in list)
                {
                    VM.Persons.Add(new MonitorTaskReportsModel
                    {
                        Hour = item.Hour,
                        Count = item.PersonCoount
                    });
                    VM.Alerts.Add(new MonitorTaskReportsModel
                    {
                        Hour = item.Hour,
                        Count = item.AlertCount
                    });
                    VM.Alarms.Add(new MonitorTaskReportsModel
                    {
                        Hour = item.Hour,
                        Count = item.AlarmCount
                    });
                }
            }
        }

        private List<int> GetHours()
        {
            List<int> hours = new List<int>();
            Random ran = new Random();
            for (int i = 0; i < 10; i++)
            {
                hours.Add(i + 1);
            }
            return hours;
        }
    }
}
