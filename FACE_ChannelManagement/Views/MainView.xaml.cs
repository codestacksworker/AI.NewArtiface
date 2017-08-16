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
using FACE_ChannelManagement.ViewModels;
using SING.Data.BaseTools;

namespace FACE_ChannelManagement.Views
{
    [Export("FACE.MainRegion.ViewContract", typeof(UserControl))]
    [ExportMetadata("ProductPrimaryName", "FACE_ChannelManagement")]
    [ExportMetadata("ProductSecondaryName", "")]
    [ExportMetadata("AuthoizedWord", "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF")]
    [ExportMetadata("AvalonContentType", "DocumentContent")]
    [ExportMetadata("AvalonPaneGroup", "WorkPad")]
    [ExportMetadata("IfExists_DefaultValue", "UseIt")]
    [ExportMetadata("ImageURI", "")]
    [ExportMetadata("Label", "通道管理")]
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
