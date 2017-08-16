using SING.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SING.Infrastructure.Converter
{
    public class DefaultValueConverter : IValueConverter
    {
       
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0;

            return value;
        }
    }

    public class DefaultTargetNullValueConverter : IValueConverter
    {
       // public const string TARGETNULLVALUE = "Null";
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Tools.IsNullOrEmpty(value)?"空":value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

}
