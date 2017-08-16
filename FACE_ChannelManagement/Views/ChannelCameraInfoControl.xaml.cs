using System.ComponentModel.Composition;
using System.Windows.Controls;
using FACE_ChannelManagement.ViewModels;

namespace FACE_ChannelManagement.UserControls
{
    [Export]
    public partial class ChannelCameraInfoControl : UserControl
    {
        public ChannelCameraInfoControl()
        {
            InitializeComponent();
        }

        [Import(AllowRecomposition = false)]
        public ViewModel ViewModel
        {
            get { return this.DataContext as ViewModel; }
            set { this.DataContext = value; }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //ViewModel.IsEditMap = true;
        }
    }
}
