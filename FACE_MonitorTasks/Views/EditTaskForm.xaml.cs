using FACE_MonitorTasks.Models;
using FACE_MonitorTasks.ViewModels;
using SING.Data.DAL.NewCode.Data;
using System.Windows;
using Telerik.Windows.Controls;

namespace FACE_MonitorTasks.Views
{
    /// <summary>
    /// EditTaskForm.xaml 的交互逻辑
    /// </summary>
    public partial class EditTaskForm : RadWindow
    {
        public DataMode CurrentMode { get; private set; }
        public EditTaskForm()
        {
            InitializeComponent();
            this.Loaded += EditTaskForm_Loaded;
        }

        private void EditTaskForm_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public EditTaskForm(ViewModel viewModel, DataMode mode) : this()
        {
            this.DataContext = viewModel;
            this.CurrentMode = mode;
            viewModel.HasValidationError = false;

            switch (mode)
            {
                case DataMode.Add:
                    this.Header = "新建布控任务";
                    viewModel.IsInEditMode = true;
                    //viewModel.SelectedStrategy = viewModel.CmpStrategyList.LastOrDefault();
                    viewModel.EditedTask = new JobsData();
                    viewModel.EditedTask.UiBeginTime = "00:00";
                    viewModel.EditedTask.UiEndTime = "24:00";
                    viewModel.EditedTask.Type = 0;
                    //viewModel.EditedTask.UiBeginTime2 =
                    //    viewModel.EditedTask.UiEndTime2 = "24:00";

                    if (viewModel.MonitorTaskList.Count > 0)
                    {
                        //viewModel.EditedTask.Index = viewModel.MonitorTaskList.Max(p => p.Index) + 1;
                        //viewModel.EditedTask.Index = new Random().Next(100);
                    }
                    else
                    {
                        //viewModel.EditedTask.Index = 1;
                    }
                    break;
                case DataMode.Edit:
                    this.Header = "编辑布控任务";
                    viewModel.IsInEditMode = true;



                    break;
                case DataMode.Detail:
                    this.Header = "查看布控任务";
                    viewModel.IsInEditMode = false;



                    break;
            }

            //初始化
            if (viewModel.EditedTask.State == 1 || viewModel.EditedTask.State == 2)
            {
                this.btnOpenTask.IsChecked = true;
                this.btnCloseTask.IsChecked = false;
            }
            else
            {
                this.btnOpenTask.IsChecked = false;
                this.btnCloseTask.IsChecked = true;
            }

            //状态
            this.btnOpenTask.Checked += (s, e) => viewModel.EditedTask.State = 1;
            this.btnCloseTask.Checked += (s, e) => viewModel.EditedTask.State = 0;
        }

    }
}
