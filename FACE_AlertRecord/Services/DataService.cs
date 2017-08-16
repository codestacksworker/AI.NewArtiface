using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_AlertRecord.Services.HelpService;
using FACE_AlertRecord.ViewModels;
using SING.Data.Help;
using SING.Data.DAL.ScheduleConvert;
using SING.Data.DAL.Data;
using SING.Data.DAL.NewCode.Data;

namespace FACE_AlertRecord.Services
{
    [Export(typeof(IDataService))]
    public class DataService : IDataService
    {
        public void AlarmPromptData(ViewModel viewModel)
        {
            AlarmPromptService service = new AlarmPromptService();
            service.AlarmPromptData(viewModel);
        }

        public void MonTaskData(ViewModel viewModel)
        {
            MonTaskService service = new MonTaskService();
            service.MonTaskData(viewModel);
        }

        public void TarLibraryData(ViewModel viewModel)
        {
            TarLibraryService service = new TarLibraryService();
            service.TarLibraryData(viewModel);
        }

        public void AreaChannelData(ViewModel viewModel)
        {
            AreaChannelService service = new AreaChannelService();
            service.AreaChannelData(viewModel);
        }

        public void AlarmInfoData(ViewModel viewModel)
        {
            AlarmInfoService service = new AlarmInfoService();
            service.FaceCapData(viewModel);
        }

        #region  接口测试

        public List<AlertInfoData> GetAlertList(ViewModel viewModel)
        {
            AlarmPromptService service = new AlarmPromptService();
            return service.GetAlertList(viewModel);
        }

        public List<AlertInfoData> QueryTargetPersonList()
        {
            AlarmPromptService service = new AlarmPromptService();
            return service.QueryTargetPersonList();
        }

        public AlertInfoData QueryTargetPersonByID()
        {
            AlarmPromptService service = new AlarmPromptService();
            return service.QueryTargetPersonByID();
        }

        public AlertInfoData Previous()
        {
            AlarmPromptService service = new AlarmPromptService();
            return service.Previous();
        }

        public AlertInfoData Next()
        {
            AlarmPromptService service = new AlarmPromptService();
            return service.Next();
        }

        public bool Confirm()
        {
            AlarmPromptService service = new AlarmPromptService();
            return service.Confirm();
        }

        public bool Eliminate()
        {
            AlarmPromptService service = new AlarmPromptService();
            return service.Eliminate();
        }

        #endregion
    }
}