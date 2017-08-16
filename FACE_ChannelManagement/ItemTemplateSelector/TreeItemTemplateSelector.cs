using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SING.Data.Controls.TreeControl.Models;

namespace FACE_ChannelManagement.ItemTemplateSelector
{
    public class TreeItemTemplateSelector : DataTemplateSelector
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
            var lstItem = item as DataItem;
            var win = Application.Current.MainWindow;
            if (lstItem != null)
            {
                switch (lstItem.Status)
                {
                    case "Region":
                        return Gettemplate("RegionTemplate");
                    case "Channel":
                        return Gettemplate("ChannelTemplate"); ;
                    default:
                        return Gettemplate("RootTemplate");

                        //case "Region":
                        //    return RegionTemplate;
                        //case "Channel":
                        //    return ChannelTemplate;
                }
            }
            return base.SelectTemplate(item, container);
        }

        HierarchicalDataTemplate Gettemplate(string keyname)
        {
            ResourceDictionary source = new ResourceDictionary();
            HierarchicalDataTemplate result = null;
            Uri uri = new Uri("pack://application:,,,/FACE_ChannelManagement;component/StyleResources.xaml", UriKind.Absolute);
            source.Source = uri;
            result = source[keyname] as HierarchicalDataTemplate;
            return result;
        }
    }
}
