using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Controls.PageControl
{
    public interface IPageCondition
    {
        int StartNum { get; set; }
        int Count { get; set; }
        int PageNow { get; set; }

        bool PreviousPageIsEnable { get; set; }
        bool NextPageIsEnable { get; set; }

   
    }
}
