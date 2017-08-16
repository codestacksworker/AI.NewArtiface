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
    public class AskStatusConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = "未处理";

            try
            {
                var status = (int)value;
                switch (status)
                {
                    case 2://已确认
                        result = "已确认";
                        break;
                    case 3://已否决
                        result = "已否决";
                        break;
                    default://未处理
                        result = "未处理";
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
