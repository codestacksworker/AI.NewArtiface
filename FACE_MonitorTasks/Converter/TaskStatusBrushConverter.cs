using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FACE_MonitorTasks.Converter
{

    public class TaskStatusBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ImageBrush result = null;

            try
            {
                string tag = "black";
                var status = (int)value;
                switch (status)
                {
                    case 1://已推送
                        tag = "blue";
                        break;
                    case 2://已推送
                        tag = "orange";
                        break;
                    default://未推送
                        tag = "black";
                        break;
                }
                string path = string.Format(@"pack://application:,,,/FACE_MonitorTasks;Component/Images/icon/bullet_{0}.png", tag);
                result = new ImageBrush();
                result.ImageSource = new BitmapImage(new Uri(path));
            }
            catch
            {

            }

            return result;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

    }
}
