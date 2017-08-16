using FACE_MonitorTasks.ViewModels;
using SING.Data.DAL.NewCode;
using SING.Data.DAL.NewCode.Condition;
using SING.Data.DAL.NewCode.Data;
using SING.Data.Logger;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace FACE_MonitorTasks.Services.HelpService
{
    public class MonitorTaskService
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
                Logger.Error("MonitorTaskService:布控任务查询异常", err);
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
            try
            {
                ObservableCollection<JobsData> data = new ObservableCollection<JobsData>();
                Pager<JobsCondition, Jobs> result = new Jobs().Query(new Pager<JobsCondition>
                {
                    PageNo = 0,
                    PageRows = 20,
                    Condition = new JobsCondition()
                    {

                    }
                });

                Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background, new Action(() =>
                {
                    this._viewmodel.MonitorTaskList.Clear();
                    result.ResultList.ForEach(x => this._viewmodel.MonitorTaskList.Add(x.ToUIData<JobsData>()));

                    for (int i = 0; i < _viewmodel.MonitorTaskList.Count; i++)
                        _viewmodel.MonitorTaskList[i].RowNo = i + 1;
                }));
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }


    }
}
