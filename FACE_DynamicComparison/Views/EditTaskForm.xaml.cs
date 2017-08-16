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
    /// EditTaskForm.xaml 的交互逻辑
    /// </summary>
    public partial class EditTaskForm : RadWindow
    {
        public DataMode CurrentMode { get; private set; }
        public EditTaskForm()
        {
            InitializeComponent();
        }
        public EditTaskForm(ViewModel viewModel,DataMode mode) : this()
        {
            this.DataContext = viewModel;
            this.CurrentMode = mode;

            switch (mode)
            {
                case DataMode.Add:
                    break;
                case DataMode.Edit:
                    break;
                case DataMode.Detail:
                    break;
            }
        }
    }
}
