using SING.Data.DAL.NewCode;
using SING.Data.DAL.NewCode.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_DynamicComparison.Services.HelpServiceImpl
{
    [Export(typeof(HelpService.IStatisticsService))]
    public  class StatisticsService:HelpService.IStatisticsService
    {
        public int GetPublishCount()
        {
            StatisticsData condition = new StatisticsData();
            condition.StartTime = "";
            condition.EndTime = "";
            Statistics model = condition.ToData<Statistics>();
            return model.GetPublishCount();
        }

        public int GetAlertCount()
        {
            StatisticsData condition = new StatisticsData();
            condition.StartTime = "2017-08-01 00:59:26";
            condition.EndTime = "2017-8-1 0:59:27";
            Statistics model = condition.ToData<Statistics>();
            return model.GetAlertCount();
        }

        public int GetUncheckedCount()
        {
            StatisticsData condition = new StatisticsData();
            condition.StartTime = "2017-08-01 00:59:26";
            condition.EndTime = "2017-08-11 0:59:27";
            Statistics model = condition.ToData<Statistics>();
            return model.UncheckedCount();
        }

        public List<StatisticsData> CheckedStatistics()
        {
            StatisticsData condition = new StatisticsData();
            condition.StartTime = "2017-08-01 00:59:26";
            condition.EndTime = "2017-08-11 0:59:27";
            condition.JobId = "1ce62ab7a2624acfba8e63c8318982d6";
            Statistics model = condition.ToData<Statistics>();
            var list = model.CheckedStatistics();
            return list!=null? list.Cast<StatisticsData>().ToList():null;
        }

        public string QueryCapState()
        {
            Statistics statis = new Statistics();
            return statis.QueryCapState();
        }

        public string QueryComState()
        {
            Statistics statis = new Statistics();
            return statis.QueryComState();
        }

        public string QueryMethodeState()
        {
            Statistics statis = new Statistics();
            return statis.QueryMethodeState();
        }

        public int FindStatisticalCount()
        {
            Statistics statis = new Statistics
            {
                StartTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                EndTime = DateTime.Now.Subtract(new TimeSpan(1, 0, 0)).ToString("yyyy-MM-dd hh:mm:ss"),
            };
            return statis.FindStatisticalCount();
        }

    }
}
