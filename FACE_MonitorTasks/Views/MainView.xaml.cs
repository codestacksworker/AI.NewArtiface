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
using FACE_MonitorTasks.ViewModels;
using SING.Data.BaseTools;
using Sofa.Commons;
using Sofa.Container;

namespace FACE_MonitorTasks.Views
{
    [Export("FACE.MainRegion.ViewContract", typeof(UserControl))]
    [ExportMetadata("ProductPrimaryName", "FACE_MonitorTasks")]
    [ExportMetadata("ProductSecondaryName", "")]
    [ExportMetadata("AuthoizedWord", "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF")]
    [ExportMetadata("AvalonContentType", "DocumentContent")]
    [ExportMetadata("AvalonPaneGroup", "WorkPad")]
    [ExportMetadata("IfExists_DefaultValue", "UseIt")]
    [ExportMetadata("ImageURI", "")]
    [ExportMetadata("Label", "布控任务")]
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        [Import(AllowRecomposition = false)]
        public ViewModel ViewModel
        {
            get { return this.DataContext as ViewModel; }
            set { this.DataContext = value; }
        }
    }
}
