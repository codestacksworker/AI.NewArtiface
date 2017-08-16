using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Infrastructure.Enums
{
    public enum OperationTypeEnum
    {
        [Description("添加区域")]
        AddRegion =0,
        [Description("添加子区域")]
        AddChildRegion =1,
        [Description("添加通道")]
        AddChannel =2,
        [Description("编辑")]
        Edit =3,
        [Description("删除")]
        Delete =4
    }
}
