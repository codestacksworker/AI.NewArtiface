using FACE_DynamicComparison.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_DynamicComparison.Services
{
   public interface ISearchServiceBase
    {
        ViewModel VM { get; set; }
        void DoSearch(ViewModel viewModel);

    }
}
