using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Infrastructure.Enums
{
    public enum PubStatusEnum
    {
        [Description("未推送")]
        UnPushed = 1,
        [Description("已推送")]
        Pushed = 2
    }
}
