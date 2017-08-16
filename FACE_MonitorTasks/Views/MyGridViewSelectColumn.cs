using SING.Data.DAL.Data;
using SING.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace FACE_MonitorTasks.Views
{
    public class MyGridViewSelectColumn : GridViewSelectColumn
    {
        public override FrameworkElement CreateCellElement(GridViewCell cell, object dataItem)
        {
            var element = base.CreateCellElement(cell, dataItem);

            var checkBox = element as CheckBox;
            if (checkBox != null)
            {
                var item = dataItem as IChecked;
                if (item != null)
                {
                    checkBox.IsChecked = item.IsChecked;
                    checkBox.Checked += (s, e) => item.IsChecked = true;
                    checkBox.Unchecked += (s, e) => item.IsChecked = false;

                    checkBox.SetBinding(CheckBox.IsCheckedProperty, new Binding("IsSelected") { Source = cell, Mode = BindingMode.TwoWay });
                }
                else
                {
                    var ftdb = dataItem as FaceTemplateDBData;
                    if (ftdb != null)
                    {
                        checkBox.IsChecked = ftdb.ISSELECTED;
                        checkBox.Checked += (s, e) => ftdb.ISSELECTED = true;
                        checkBox.Unchecked += (s, e) => ftdb.ISSELECTED = false;

                        checkBox.SetBinding(CheckBox.IsCheckedProperty, new Binding("IsSelected") { Source = cell, Mode = BindingMode.TwoWay });
                    }
                }
               
            }


            return element;
        }
    }
}