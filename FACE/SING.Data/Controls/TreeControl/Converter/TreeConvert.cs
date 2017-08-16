using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SING.Data.Controls.TreeControl.Converter
{
    public class TreeViewItemWithConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double result = 200;

            try
            {
                int num =System.Convert.ToInt32(value);
                result = num * 0.75;
            }
            catch (Exception)
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
