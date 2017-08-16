using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FACE_TemplateManagement.ViewModels;
using SING.Data.DAL;
using SING.Data.DAL.Data;
using SING.Data.DAL.ScheduleConvert;
using SING.Data.Help;
using SING.Data.Logger;

namespace FACE_TemplateManagement.Services.HelpService
{
    public class SearchFotService
    {
        private ViewModel viewModel;

        private BackgroundWorker Worker;

        private QueryCondition qc;

        public List<FaceObjTempViewData> list;

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            viewModel.ProgressSattus.IsBusyHanding = false;
            viewModel.QueryConditionFot.PreviousPageIsEnable = viewModel.QueryConditionFot.PageNow > 1;
            viewModel.QueryConditionFot.NextPageIsEnable = viewModel.FotList.Count >= viewModel.QueryConditionFot.Count;
        }

        public void DoWork(ViewModel viewModel)
        {
            try
            {
                this.viewModel = viewModel;
                this.qc = viewModel.QueryConditionFot;

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
                Logger.Error("QueryFotService:启动查询模板异常", err);
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
                if (viewModel.CurrentFtdb != null)
                {
                    qc.TDBID = viewModel.CurrentFtdb.ID;
                    list = HelpMethod.GetFots(qc);
                }
                

                if (list == null)
                {
                    list = new List<FaceObjTempViewData>();
                }

                viewModel.FotList = list;
                viewModel.FotCV = new ListCollectionView(viewModel.FotList);
                viewModel.FotCV.CurrentChanged += new EventHandler(viewModel.FotSelectedItemChanged);
                viewModel.GetFotCurrentItem();
            }
            catch (Exception ex)
            {
                Logger.Error("查询模板库异常", ex);
            }
        }
    }
}
