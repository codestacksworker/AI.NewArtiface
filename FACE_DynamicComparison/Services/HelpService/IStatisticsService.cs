using SING.Data.DAL.NewCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_DynamicComparison.Services.HelpService
{
   public interface IStatisticsService
    {
        int GetPublishCount();

        int GetAlertCount();

        int GetUncheckedCount();

        List<StatisticsData> CheckedStatistics();

        string QueryCapState();

        string QueryComState();

        string QueryMethodeState();

        int FindStatisticalCount();

    }
}
