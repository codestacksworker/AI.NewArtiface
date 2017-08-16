using FACE_MonitorTasks.Services;
using FACE_MonitorTasks.ViewModels;
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

namespace FACE_MonitorTasks.Views
{
    /// <summary>
    /// SelectFtdbForm.xaml 的交互逻辑
    /// </summary>
    public partial class SelectFtdbForm : RadWindow
    {
        public SelectFtdbForm()
        {
            InitializeComponent();
            this.btnSelectedAll.Click += (s, e) => this.gvFtdb.SelectAll();
            this.btnUnSelectedAll.Click += (s, e) => this.gvFtdb.UnselectAll();
        }

        public SelectFtdbForm(ViewModel viewModel) : this()
        {
            new DataService().GetFaceObjectData(viewModel);
            this.DataContext = viewModel;

            //if (viewModel.FtdbList.Count == 0)
            //{
            //    var newItem = new SING.Data.DAL.Data.FaceTemplateDBData();
            //    newItem.ISSELECTED = false;
            //    newItem.IsUsed = 0;
            //    newItem.TemplateDbName = "模板库1";
            //    newItem.TemplateDbSize = 1000;
            //    newItem.TemplateDbCapacity = 10000;
            //    newItem.TemplateDbDescription = "模板库1模板库1";
            //    viewModel.FtdbList.Add(newItem);
            //}
        }
    }
}
