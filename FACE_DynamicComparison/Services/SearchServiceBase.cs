using FACE_DynamicComparison.ViewModels;
using SING.Data.DAL.NewCode;
using SING.Data.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FACE_DynamicComparison.Services
{
    [Export(typeof(ISearchServiceBase))]
    public class SearchServiceBase
    {
        public ViewModel VM { get; set; }
        private BackgroundWorker _work;
   
        public SearchServiceBase()
        {
            _work = new BackgroundWorker();
            _work.WorkerReportsProgress = true;
            _work.WorkerSupportsCancellation = true;
            _work.DoWork += SearchAction;
            _work.RunWorkerCompleted += OnRunWorkerCompleted;
            _work.ProgressChanged += OnProgressChanged;
        }

        public void DoSearch(ViewModel viewModel)
        {
            try
            {
                this.VM = viewModel;
                _work.RunWorkerAsync();
            }
            catch (Exception err)
            {
                Logger.Error(":查询异常", err);
            }
        }


        private void OnProgressChanged(object sender, ProgressChangedEventArgs e) { }

        private void OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) { }

        private void SearchAction(object sender, DoWorkEventArgs e)
        {
            Search();
        }

        public virtual void Search()
        {

        }


    }
}
