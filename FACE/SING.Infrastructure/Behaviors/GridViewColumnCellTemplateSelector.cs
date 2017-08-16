using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SING.Infrastructure.Behaviors
{
    public class GridViewColumnCellTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// 垂直排版
        /// </summary>
        public DataTemplate RegionTemplate { get; set; }

        /// <summary>
        /// 水平排版
        /// </summary>
        public DataTemplate ChannelTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //var lstItem = item as DataItem;
            //RegionTemplate = Gettemplate("RegionTemplate");
            //ChannelTemplate = Gettemplate("ChannelTemplate");
            //var win = Application.Current.MainWindow;
            //if (lstItem != null)
            //{
            //    if(lstItem.Region!=null)
            //        return RegionTemplate;
            //    if (lstItem.Channel != null)
            //        return ChannelTemplate;
            //}
            //return base.SelectTemplate(item, container);

            return Gettemplate("GridViewExtensionColumnTemplate");
        }

        HierarchicalDataTemplate Gettemplate(string keyname)
        {
            ResourceDictionary source = new ResourceDictionary();
            HierarchicalDataTemplate result = null;
            Uri uri = new Uri("pack://application:,,,/FACE_CmpRecordManagement;component/StyleResources.xaml", UriKind.Absolute);
            source.Source = uri;
            result = source[keyname] as HierarchicalDataTemplate;
            return result;
        }
    }
}
