using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_AlertRecord.ViewModels;
using SING.Data.DAL.NewCode.Data;
using SING.Data.Help;

namespace FACE_AlertRecord.Services
{
    public interface IDataService
    {
        void AlarmPromptData(ViewModel viewModel);

        void MonTaskData(ViewModel viewModel);

        void TarLibraryData(ViewModel viewModel);

        void AreaChannelData(ViewModel viewModel);

        void AlarmInfoData(ViewModel viewModel);

        #region  接口测试

        List<AlertInfoData> GetAlertList(ViewModel viewModel);
        List<AlertInfoData> QueryTargetPersonList();
        AlertInfoData QueryTargetPersonByID();
        AlertInfoData Previous();
        AlertInfoData Next();
        bool Confirm();
        bool Eliminate();

        #endregion
    }
}