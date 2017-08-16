using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FACE_ChannelManagement.ItemTemplateSelector
{
    public class TreeItemContextMenuTemplateSelector: DataTemplateSelector
    {
        /// <summary>
        /// 垂直排版
        /// </summary>
        public DataTemplate VerticalTemplate { get; set; }

        /// <summary>
        /// 水平排版
        /// </summary>
        public DataTemplate HorizontalTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //var lstItem = item as LstModel;
            //if (lstItem != null)
            //{
            //    switch (lstItem.Status)
            //    {
            //        case "V":
            //            return VerticalTemplate;
            //        case "H":
            //            return HorizontalTemplate;
            //    }
            //}
            return base.SelectTemplate(item, container);
        }
    }
}
