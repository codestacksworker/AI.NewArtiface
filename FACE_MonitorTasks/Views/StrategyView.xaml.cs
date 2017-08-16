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
    /// StrategyView.xaml 的交互逻辑
    /// </summary>
    public partial class StrategyView : UserControl
    {
        public StrategyView()
        {
            InitializeComponent();
            
            this.Loaded += StrategyView_Loaded;
        }

        private void StrategyView_Loaded(object sender, RoutedEventArgs e)
        {
            this.PreviewKeyDown += StrategyView_PreviewKeyDown;
        }

        private void StrategyView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.btnSearch.Command.Execute(this.txtKeyWord.Text);
            }
        }

        private void GridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var select = (e.OriginalSource as FrameworkElement).DataContext;
            if (select != null)
            {
                var vm = this.DataContext as ViewModels.ViewModel;
                vm.CommandDetailStrategy.Execute(((FACE_MonitorTasks.Models.CmpStrategy)select).Uuid);
            }
        }
    }
}
