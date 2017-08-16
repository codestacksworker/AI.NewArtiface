using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SING.Infrastructure.Converter
{
    public class SstConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = string.Empty;

            try
            {
                int temp1 = (int)value;
                switch (temp1)
                {
                    case 1:
                        result = "高";
                        break;
                    case 2:
                        result = "中";
                        break;
                    case 3:
                        result = "低";
                        break;
                }
            }
            catch (Exception)
            {

            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int result = 0;

            try
            {
                if (value == null) return result;
                string sst = value.ToString();
                switch (sst)
                {
                    case "高":
                        result = 1;
                        break;
                    case "中":
                        result = 2;
                        break;
                    case "低":
                        result = 3;
                        break;
                }
            }
            catch (Exception)
            {

            }

            return result;
        }
    }
}
