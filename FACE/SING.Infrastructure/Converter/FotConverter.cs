using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SING.Infrastructure.Converter
{
    public class SexConverter : IValueConverter
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
                        result = "男";
                        break;
                    case 2:
                        result = "女";
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
                string sex = value.ToString();
                switch (sex)
                {
                    case "男":
                        result = 1;
                        break;
                    case "女":
                        result = 2;
                        break;
                }
            }
            catch (Exception)
            {

            }

            return result;
        }
    }

    public class IdTypeConverter : IValueConverter
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
                        result = "身份证";
                        break;
                    case 2:
                        result = "护照";
                        break;
                    case 3:
                        result = "签证";
                        break;
                    case 4:
                        result = "港澳通行证";
                        break;
                    case 5:
                        result = "军人证";
                        break;
                    case 6:
                        result = "户口本";
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
                string IdType = value.ToString();
                switch (IdType)
                {
                    case "身份证":
                        result = 1;
                        break;
                    case "护照":
                        result = 2;
                        break;
                    case "签证":
                        result = 3;
                        break;
                    case "港澳通行证":
                        result = 4;
                        break;
                    case "军人证":
                        result = 5;
                        break;
                    case "户口本":
                        result = 6;
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
