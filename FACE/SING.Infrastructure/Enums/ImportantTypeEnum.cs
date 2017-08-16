using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Infrastructure.Enum
{
    public enum ImportantType
    {
        [Description("高")]
        High = 0,
        [Description("中")]
        Normal = 1,
        [Description("低")]
        Low = 2

    }
}
