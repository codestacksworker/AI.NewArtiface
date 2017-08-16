using FACE_MonitorTasks.ViewModels;
using SING.Data.DAL.NewCode;
using SING.Data.DAL.NewCode.Condition;
using SING.Data.DAL.NewCode.Data;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace FACE_MonitorTasks.Services.HelpService
{
    public class JobMethodService
    {
        public ObservableCollection<JobMethodData> Query(ViewModel viewModel)
        {
            JobMethod method = new JobMethod();
            Pager<JobMethodCondition, JobMethod> p = method.Query(new Pager<JobMethodCondition>
            {
                PageNo = 1,
                PageRows = 20,
                Condition = new JobMethodCondition
                {
                    Name = ""
                }
            });

            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background, new Action(() =>
            {
                viewModel.CmpStrategyList.Clear();
                p.ResultList.ForEach(x => viewModel.CmpStrategyList.Add(x.ToUIData<JobMethodData>()));

                for (int i = 0; i < viewModel.CmpStrategyList.Count; i++)
                {
                    viewModel.CmpStrategyList[i].Index = i + 1;
                }
            }));

            return viewModel.CmpStrategyList;
        }

        public JobMethodData InsertJobMethod()
        {
            JobMethod method = new JobMethod { };
            JobMethod jm = method.Insert();
            return jm.ToUIData<JobMethodData>();
        }

        public JobMethodData UpdataJobMethod()
        {
            JobMethod method = new JobMethod { };
            JobMethod jm = method.Update();
            return jm.ToUIData<JobMethodData>();
        }

        public JobMethodData DeleteJobMethod()
        {
            JobMethod method = new JobMethod { };
            JobMethod jm = method.Delete();
            return jm.ToUIData<JobMethodData>();
        }
    }
}
