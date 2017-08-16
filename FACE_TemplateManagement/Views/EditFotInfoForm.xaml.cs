using FACE_TemplateManagement.ViewModels;
using SING.Infrastructure;
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
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace FACE_TemplateManagement.Views
{
    /// <summary>
    /// EditFotInfoForm.xaml 的交互逻辑
    /// </summary>
    public partial class EditFotInfoForm : RadWindow
    {
        public bool FormIsOpen { get; private set; }
        public EditFotInfoForm()
        {
            InitializeComponent();
        }

        //[Import(AllowRecomposition = false)]
        //public ViewModel viewModel
        //{
        //    get { return this.DataContext as ViewModel; }
        //    set { this.DataContext = value; }
        //}

        #region 事件
        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.IsTopmost = true;
            FormIsOpen = true;
            UIHelper.RefreshPopWindows();
        }

        private void RadWindow_Closed(object sender, WindowClosedEventArgs e)
        {
            FormIsOpen = false;
            UIHelper.RefreshPopWindows();
        }

        private void RadWindow_Activated(object sender, EventArgs e)
        {
            UIHelper.RefreshPopWindows();
        }

        private void RadWindow_Deactivated(object sender, EventArgs e)
        {
            UIHelper.RefreshPopWindows();
        }
        #endregion
    }
}
