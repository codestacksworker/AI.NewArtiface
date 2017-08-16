using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SING.Infrastructure.Enums
{
    public enum CmpMethodTypeEnum
    {
        [Description("阈值法")]
        Threshold=0,
        [Description("计数法")]
        Calculate =1
    }
}

