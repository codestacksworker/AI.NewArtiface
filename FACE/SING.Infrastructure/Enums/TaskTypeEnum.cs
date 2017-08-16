using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Infrastructure.Enums
{
    public enum TaskTypeEnum
    {
        [Description("目标监视")]
        TargetAnalyze = 0,
        [Description("区域设防")]
        RegionAnalyze = 1
    }
}

