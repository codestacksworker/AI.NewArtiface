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
using SING.Data.DAL.ScheduleConvert;
using SING.Data.BaseTools;

namespace FACE_TemplateManagement.Views
{
    [Export]
    public partial class FotListView : UserControl
    {
        public FotListView()
        {
            InitializeComponent();
        }

        [Import(AllowRecomposition = false)]
        public ViewModel viewModel
        {
            get { return this.DataContext as ViewModel; }
            set { this.DataContext = value; }
        }

        private void pager_PageIndexChanged(object sender, Telerik.Windows.Controls.PageIndexChangedEventArgs e)
        {

        }

        private void FotList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (viewModel.CurrentFot == null) return;

            viewModel.IsEditorShow = true;

            viewModel.IsAddFot = false;

            viewModel.CurrentFotEdit = DataConvert.CopyViewData(viewModel.CurrentFot);
        }

        private void RadMenuItem_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            
            if (viewModel.CurrentFtdb == null)
            {
                MessageBoxHelper.Show("请您先选择模板库，【编辑】", "提示");
                return;
            }
            if (viewModel.CurrentFot == null)
            {
                MessageBoxHelper.Show("请您选择要编辑的人脸对象，【编辑】", "提示");
                return;
            }

            viewModel.IsEditorShow = true;

            viewModel.IsAddFot = false;

            viewModel.CurrentFotEdit = DataConvert.CopyViewData(viewModel.CurrentFot);
        }
    }
}
