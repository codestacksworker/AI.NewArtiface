using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using SING.Data.Help;

namespace SING.Infrastructure.Converter
{
    public class BinaryImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is byte[])
            {
                BitmapImage image = null;
                byte[] bytes = value as byte[];
                if (bytes.Length > 0)
                    image = ImageConvert.ByteArrayToBitmapImage(bytes);
                //BitmapSource image = ImageHelper.BinaryToBitmapSource(bytes);
                bytes = null;
                return image;
            }

            return null;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
