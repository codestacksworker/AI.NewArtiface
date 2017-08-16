using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SING.Infrastructure.Enums
{
    public enum AskStatusEnum
    {
        [Description("未处理")]
        UnHandle = 1,
        [Description("已确认")]
        Confirmed = 2,
        [Description("已否决")]
        Vetoed = 3
    }
}

