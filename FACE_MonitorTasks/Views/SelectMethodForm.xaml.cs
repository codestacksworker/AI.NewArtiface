using FACE_MonitorTasks.ViewModels;
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
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace FACE_MonitorTasks.Views
{
    /// <summary>
    /// SelectMethodForm.xaml 的交互逻辑
    /// </summary>
    public partial class SelectMethodForm : RadWindow
    {
        public SelectMethodForm()
        {
            InitializeComponent();
            this.btnSelectedAll.Click += (s, e) => this.gvMethod.SelectAll();
            this.btnUnSelectedAll.Click += (s, e) => this.gvMethod.UnselectAll();
        }

        public SelectMethodForm(ViewModel viewModel) : this()
        {
            gvMethod.SelectionChanged += viewModel.SelectedJobMethod;
            this.DataContext = viewModel;
        }
    }
}
