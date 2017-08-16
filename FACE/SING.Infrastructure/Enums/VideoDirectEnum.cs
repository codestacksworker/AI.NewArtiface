using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;
using System.ComponentModel;

namespace SING.Infrastructure.Enums
{
    public enum VideoDirectEnum
    {
        [Description("None")]
        None = 0,
        [Description("东")]
        East = 1,
        [Description("南")]
        South = 2,
        [Description("西")]
        West = 3,
        [Description("北")]
        North = 4,
        [Description("东南")]
        EastSouth = 5,
        [Description("东北")]
        EastNorth = 6,
        [Description("西南")]
        WestSouth = 7,
        [Description("西北")]
        WestNorth = 8


    }
}
