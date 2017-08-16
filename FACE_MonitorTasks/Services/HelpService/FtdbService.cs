using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FACE_MonitorTasks.ViewModels;

namespace FACE_MonitorTasks.Services.HelpService
{
    public class FtdbService
    {
        private ViewModel _viewmodel;
        private BackgroundWorker _work;

        public void DoSearch(ViewModel viewmodel)
        {
            try
            {
                this._viewmodel = viewmodel;
                this._work = new BackgroundWorker();
                _work.WorkerReportsProgress = true;
                _work.WorkerSupportsCancellation = true;
                _work.DoWork += Search;
                _work.RunWorkerCompleted += RunWorkerCompleted;
                _work.ProgressChanged += ProgressChanged;
                _work.RunWorkerAsync();
            }
            catch (Exception err)
            {
                SING.Data.Logger.Logger.Error("ChannelService:通道查询异常", err);
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void Search(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            List<SING.Data.DAL.Data.FaceTemplateDBData> list = SING.Data.Help.BasicData.FTDBDatas;
            if (list != null)
            {
                foreach (var item in list)
                {
                    //_viewmodel.FtdbList.Add(item);
                }
            }



        }


    }
}
