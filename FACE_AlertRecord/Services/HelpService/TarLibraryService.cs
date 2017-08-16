using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using FACE_AlertRecord.Models;
using FACE_AlertRecord.ViewModels;

namespace FACE_AlertRecord.Services.HelpService
{
    public class TarLibraryService
    {
        public void TarLibraryData(ViewModel viewModel)
        {
            for (int i = 0; i < 5; i++)
            {
                TarLibraryData tarLib = new TarLibraryData
                {
                    TarLibName = "目标库i" + i.ToString(),
                    Describe = "描述i" + i.ToString(),
                    LibStatus = "启用i" + i.ToString(),
                    TarPeopleNum = "i" + i.ToString(),
                    TemplateNum = "i" + i.ToString()
                };
                for (int j = 0; j < 3; j++)
                {
                    TarLibraryData tarLibChild = new TarLibraryData
                    {
                        TarPeople = "目标人j" + j.ToString(),
                        Describe = "描述j" + j.ToString(),
                        LibStatus = "启用j" + j.ToString(),
                        TarPeopleNum = "j" + j.ToString(),
                        TemplateNum = "j" + j.ToString()
                    };
                    tarLib.TarLibChildList.Add(tarLibChild);
                }
                viewModel.TarLibraryList.Add(tarLib);
            }
        }
    }
}
