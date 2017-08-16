using FACE_MonitorTasks.Models;
using FACE_MonitorTasks.ViewModels;
using Telerik.Windows.Controls;

namespace FACE_MonitorTasks.Views
{
    /// <summary>
    /// EditStrategyForm.xaml 的交互逻辑
    /// </summary>
    public partial class EditStrategyForm : RadWindow
    {
        public DataMode CurrentMode { get; private set; }
        public EditStrategyForm()
        {
            InitializeComponent();
            
        }

        public EditStrategyForm(ViewModel viewModel,DataMode mode) : this()
        {
            this.DataContext = viewModel;
            this.CurrentMode = mode;
            viewModel.HasValidationError = false;

            switch (mode)
            {
                case DataMode.Add:
                    this.Header = "新建比对策略";
                    viewModel.IsInEditMode = true;
                    break;
                case DataMode.Edit:
                    this.Header = "编辑比对策略";
                    viewModel.IsInEditMode = true;
                    break;
                case DataMode.Detail:
                    this.Header = "查看比对策略";
                    viewModel.IsInEditMode = false;
                    break;
            }


            //if (viewModel.EditedStrategy != null && viewModel.EditedStrategy.TaskList.Count == 0)
            //{
            //    this.borderTaskList.Visibility = Visibility.Collapsed;
            //}

        }

      
    }
}
