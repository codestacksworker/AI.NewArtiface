using SING.Data.BaseTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Dev_SING.Data;
using System.Globalization;
using SING.Infrastructure.Enums;

namespace SING.Infrastructure.Converter
{
    public class PubStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = "未推送";

            try
            {
                var status = (int)value;
                switch (status)
                {
                    case 2:
                        result = "已推送";
                        break;
                    default:
                        result = "未推送";
                        break;
                }
            }
            catch (Exception ex)
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
