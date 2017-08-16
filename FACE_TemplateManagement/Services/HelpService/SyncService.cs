using FACE_TemplateManagement.ViewModels;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using SING.Data.DAL.Data;
using SING.Infrastructure.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FACE_TemplateManagement.Services.HelpService
{
    public class SyncService
    {
        private static ViewModel viewModel;
        private static IEventAggregator eventAggregator;
        public const string FACE_TemplateManagement = "FACE_TemplateManagement";
        public static void Initialize(ViewModel _viewModel)
        {
            viewModel = _viewModel;
            eventAggregator = _viewModel._eventAggregator;
            viewModel._eventAggregator.GetEvent<FtDbModuleSyncEvent>().Subscribe(OnFtDbSyncEvent);
            viewModel._eventAggregator.GetEvent<FtDbUpdateModuleSyncEvent>().Subscribe(OnFtDbUpdateSyncEvent);
        }

        public static  void PublishModuleSync(List<FaceTemplateDBData> newValue)
        {
            FtDbSyncParameters parameters = new FtDbSyncParameters();
            parameters.ProductPrimaryName = FACE_TemplateManagement;
            parameters.newValue = newValue;

            eventAggregator.GetEvent<FtDbModuleSyncEvent>().Publish(parameters);
        }
        public static void PublishModuleSync(FaceTemplateDBData newValue)
        {
            FtDbUpdateSyncParameters parameters = new FtDbUpdateSyncParameters();
            parameters.ProductPrimaryName = FACE_TemplateManagement;
            parameters.newValue = newValue;

            eventAggregator.GetEvent<FtDbUpdateModuleSyncEvent>().Publish(parameters);
        }



        private static void OnFtDbSyncEvent(FtDbSyncParameters parameters)
        {
            if (parameters != null && parameters.ProductPrimaryName != FACE_TemplateManagement)
            {
                //viewModel.FtdbList = parameters.newValue;
                viewModel._dataService.SearchFtdb(viewModel);
            }
        }

        private static void OnFtDbUpdateSyncEvent(FtDbUpdateSyncParameters parameters)
        {
            if (parameters != null && parameters.ProductPrimaryName != FACE_TemplateManagement)
            {
                var item = viewModel.FtdbList.FirstOrDefault(p => p.ID == parameters.newValue.ID);

                if (item != null)
                {
                    FaceTemplateDBData.CopyValue(parameters.newValue, item);
                }
            }
        }


    }
}
