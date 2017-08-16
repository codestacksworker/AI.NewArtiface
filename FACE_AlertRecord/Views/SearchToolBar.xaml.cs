using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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
using FACE_AlertRecord.ViewModels;
using SING.Infrastructure;
using Telerik.Windows.Controls;

namespace FACE_AlertRecord.Views
{
    [Export]
    public partial class SearchToolBar : UserControl
    {
        public SearchToolBar()
        {
            InitializeComponent();
        }

        [Import(AllowRecomposition = false)]
        public ViewModel viewModel
        {
            get { return this.DataContext as ViewModel; }
            set { this.DataContext = value; }
        }
    }
}
