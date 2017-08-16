using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FACE_MonitorTasks.Views
{
    /// <summary>
    /// TaskView.xaml 的交互逻辑
    /// </summary>
    public partial class TaskView : UserControl
    {
        public TaskView()
        {
            InitializeComponent();
            this.Loaded += TaskView_Loaded;
            this.PreviewKeyDown += TaskView_PreviewKeyDown;
            this.GridView.RowLoaded += GridView_RowLoaded;
        }

        private void TaskView_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as ViewModels.ViewModel;
            if (vm != null)
            {
                vm.UnSelectedAll += Vm_UnSelectedAll;
            }
        }

        private void GridView_RowLoaded(object sender, Telerik.Windows.Controls.GridView.RowLoadedEventArgs e)
        {
            var item = e.DataElement as FACE_MonitorTasks.Models.MonitorTask;
            if (item != null&&item.TaskStatus==0)
            {
               // e.Row.Foreground = Brushes.Red;
               
            }
            e.Row.Background = null;
           
        }

        private void TaskView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var element = e.OriginalSource as FrameworkElement;
            if (e.Key == Key.Enter && element != null && element.Name == "txtKeyWord")
            {
                this.btnSearch.Command.Execute(this.txtKeyWord.Text);
            }
        }
        

        private void Vm_UnSelectedAll(object sender, EventArgs e)
        {
            this.GridView.UnselectAll();
        }

        private void GridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
          var select=  (e.OriginalSource as FrameworkElement).DataContext;
            if (select != null)
            {
                var vm = this.DataContext as ViewModels.ViewModel;
                vm.CommandDetailTask.Execute(((FACE_MonitorTasks.Models.MonitorTask)select).Uuid);
            }
        }
    }
}
