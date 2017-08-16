using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace FACE_MonitorTasks.Converter
{
   
    public class TaskStatusForegroundBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string tag = "BrushChancel";
            try
            {
              
                var status = (int)value;
                switch (status)
                {
                    case 1:
                        tag = "BrushOk";
                        break;
                    case 2:
                        tag = "BrushQuestion";
                        break;
                    default:
                        tag = "BrushChancel";
                        break;
                }
         
            }
            catch
            {

            }

            return new DynamicResourceExtension(tag);
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

    }
}
