using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Infrastructure.Enums
{
    public enum TaskPlanTypeEnum
    {
        [Description("永久布控")]
        Forever = 0,
        [Description("自定义起止日期")]
        Custom = 1
    }
}
