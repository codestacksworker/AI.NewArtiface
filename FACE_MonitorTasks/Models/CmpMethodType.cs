using Microsoft.Practices.Prism.ViewModel;
using SING.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Data;

namespace FACE_MonitorTasks.Models
{
  public  class CmpMethodType : ModelBase
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        

        public static ObservableItemCollection<CmpMethodType> MethodTypeList { get; private set; }
        static CmpMethodType()
        {
            MethodTypeList = new ObservableItemCollection<CmpMethodType>();
            MethodTypeList.Add(new CmpMethodType() { TypeId = 0, Index = 1, IsChecked = true, TypeName = "阈值法" });
            MethodTypeList.Add(new CmpMethodType() { TypeId = 1, Index = 2, IsChecked = true, TypeName = "计数法" });
        }


    }
}
