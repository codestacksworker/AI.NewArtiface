using SING.Data.DAL.NewCode;
using SING.Data.DAL.NewCode.Condition;
using SING.Data.DAL.NewCode.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_DynamicComparison.Services.HelpServiceImpl
{
    [Export(typeof(HelpService.IAlarmService))]
    public class AlarmService:HelpService.IAlarmService
    {
        public List<JobsData> QueryJobs()
        {
            Pager<JobsCondition> pager = new Pager<JobsCondition>
            {
                PageNo = 1,
                PageRows = 20,
                Condition = new JobsCondition
                {
                    LoginUuid = "admin"
                }
            };

            Jobs job = new Jobs();
            var p = job.QueryStatistics(pager);
            if (p != null)
            {
                List<JobsData> result = new List<JobsData>();
                p.ResultList.ForEach(j => result.Add(j.ToUIData<JobsData>()));
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
