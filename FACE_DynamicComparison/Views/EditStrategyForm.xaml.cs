using FACE_DynamicComparison.Models;
using FACE_DynamicComparison.ViewModels;
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

namespace FACE_DynamicComparison.Views
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
        }

    }
}
