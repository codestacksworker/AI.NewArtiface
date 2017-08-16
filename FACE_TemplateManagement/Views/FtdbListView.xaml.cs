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
using FACE_TemplateManagement.ViewModels;
using SING.Data.DAL.Data;
using SING.Data.Logger;

namespace FACE_TemplateManagement.Views
{
    [Export]
    public partial class FtdbListView : UserControl
    {
        public FtdbListView()
        {
            InitializeComponent();
        }

       

        [Import(AllowRecomposition = false)]
        public ViewModel viewModel
        {
            get { return this.DataContext as ViewModel; }
            set { this.DataContext = value; }
        }
        private void chbox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                bool? ischecked = (sender as CheckBox).IsChecked;
                if (ischecked != null && ischecked == true)
                {
                    if (viewModel != null && viewModel.FtdbList != null && viewModel.FtdbCV != null)
                    {
                        viewModel.CurrentFtdb = viewModel.FtdbList.FindLast(p => p.ISSELECTED);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Logger.Error("TemplateListView.cs文件中chbox_Checked事件错误", ex);
            }
        }
        //private void ckbSelectedAll_Checked(object sender, RoutedEventArgs e)
        //{
        //    rgvFtdbList.SelectAll();
        //    viewModel.FaceTemplateDBSelectItems = rgvFtdbList.SelectedItems;
        //}

        //private void ckbSelectedAll_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    rgvFtdbList.UnselectAll();
        //    viewModel.FaceTemplateDBSelectItems = rgvFtdbList.SelectedItems;
        //}
    }
}
