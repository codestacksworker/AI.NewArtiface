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
using FACE_DynamicComparison.ViewModels;
using SING.Data.BaseTools;
using Sofa.Commons;
using Sofa.Container;
using Telerik.Windows.Controls;

namespace FACE_DynamicComparison.Views
{
    [Export("FACE.MainRegion.ViewContract", typeof(UserControl))]
    [ExportMetadata("ProductPrimaryName", "FACE_DynamicComparison")]
    [ExportMetadata("ProductSecondaryName", "")]
    [ExportMetadata("AuthoizedWord", "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF")]
    [ExportMetadata("AvalonContentType", "DocumentContent")]
    [ExportMetadata("AvalonPaneGroup", "WorkPad")]
    [ExportMetadata("IfExists_DefaultValue", "UseIt")]
    [ExportMetadata("ImageURI", "")]
    [ExportMetadata("Label", "首页")]
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

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            RadButton button = sender as RadButton;
            if (button == null) return;
            if (button.Content.ToString() == "订阅报警")
                button.Content = "取消" + button.Content;
            else
                button.Content = "订阅报警";
        }

        private void RadButton_Click_1(object sender, RoutedEventArgs e)
        {
            RadButton button = sender as RadButton;
            if (button == null) return;
            if (button.Content.ToString() == "告警订阅")
                button.Content = "取消" + button.Content;
            else
                button.Content = "告警订阅";
        }

        private void RealVideoPlayer_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
