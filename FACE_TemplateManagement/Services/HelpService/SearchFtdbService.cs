using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using FACE_TemplateManagement.ViewModels;
using SING.Data.DAL;
using SING.Data.DAL.Data;
using SING.Data.Help;
using SING.Data.Logger;
using SING.Infrastructure.Events;

namespace FACE_TemplateManagement.Services.HelpService
{
    public class SearchFtdbService
    {
        private ViewModel viewModel;

        private BackgroundWorker Worker;

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            viewModel.ProgressSattus.IsBusyHanding = false;
            SyncService.PublishModuleSync(viewModel.FtdbList);
        }

        public void DoWork(ViewModel viewModel)
        {
            try
            {
                this.viewModel = viewModel;

                viewModel.ProgressSattus = new ProgressSattus();
                viewModel.ProgressSattus.IsBusyHanding = true;

                Worker = new BackgroundWorker();

                Worker.WorkerReportsProgress = true;
                Worker.WorkerSupportsCancellation = true;

                Worker.DoWork += Do;
                Worker.ProgressChanged += ProgressChanged;
                Worker.RunWorkerCompleted += RunWorkerCompleted;
                Worker.RunWorkerAsync(viewModel.ProgressSattus);
            }
            catch (Exception err)
            {
                Logger.Error("SearchFtdbService:启动查询模板库表异常", err);
            }
        }

        private void Do(object sender, DoWorkEventArgs e)
        {
            Search();
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            viewModel.ProgressSattus.ProgressValue = e.ProgressPercentage;
        }

        private void Search()
        {
            try
            {
                List<FaceTemplateDBData> list = BasicData.FTDBDatas;

                if (list == null)
                {
                    list = new List<FaceTemplateDBData>();
                }

                viewModel.FtdbList = list;
                viewModel.FtdbCV = new ListCollectionView(viewModel.FtdbList);
                viewModel.FtdbCV.CurrentChanged += new EventHandler(viewModel.FtdbSelectedItemChanged);
                viewModel.GetFtdbCurrentItem();
            }
            catch (Exception ex)
            {
                Logger.Error("查询模板库表异常", ex);
            }
        }
    }
}
