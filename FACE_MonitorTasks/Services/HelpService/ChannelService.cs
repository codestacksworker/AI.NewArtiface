using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_MonitorTasks.Models;
using FACE_MonitorTasks.ViewModels;
using System.ComponentModel;
using SING.Data.Logger;

namespace FACE_MonitorTasks.Services.HelpService
{
    public class ChannelService
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
                Logger.Error("ChannelService:通道查询异常", err);
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void Search(object sender, DoWorkEventArgs e)
        {
            _viewmodel.AreaChannelList.Clear();
            for (int i = 0; i < 5; i++)
            {
                AreaChannelData areaChannel = new AreaChannelData
                {
                    Area = "区域" + i.ToString(),
                    Describe = "描述i" + i.ToString(),
                };
                for (int j = 0; j < 3; j++)
                {
                    AreaChannelData areaChannelChild = new AreaChannelData
                    {
                        ChannelChild = "通道" + i.ToString(),
                        Describe = "描述j" + j.ToString(),
                    };
                    areaChannel.AreaChannelChildList.Add(areaChannelChild);
                }
                _viewmodel.AreaChannelList.Add(areaChannel);
            }
        }
        

    }
}
