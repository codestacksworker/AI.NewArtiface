using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SING.Infrastructure.Converter
{
    public class DateTimeFormattingConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime date = new DateTime();
            try
            {
                if (string.IsNullOrEmpty((string)value))
                    return "空";
                string dateString = value.ToString().Trim();

                date = DateTime.ParseExact(dateString, "yyyyMMdd HH:mm:ss", new CultureInfo("en-US"));
            }
            catch (Exception)
            {

            }

            return date.ToString();

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value != null)
                    return ((DateTime)value).ToString("yyyyMMdd HH:mm:ss");
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }

    public class DateFormattingConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime date = new DateTime();
            try
            {
                if (string.IsNullOrEmpty((string)value))
                    return null;
                string dateString = value.ToString().Trim();

                if (dateString.Length == 8)
                {
                    date = DateTime.ParseExact(dateString, "yyyyMMdd", null);
                }
                else if (dateString.Length > 8)
                {
                    date = DateTime.ParseExact(dateString.Substring(0, 8), "yyyyMMdd", null);
                }
            }
            catch (Exception ex)
            {

            }

            return date;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value != null)
                    return ((DateTime)value).ToString("yyyyMMdd");
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }

    public class ShortDateFormattingConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty((string)value))
                    return null;
                string dateString = value.ToString().Trim();

                DateTime date = new DateTime();

                if (dateString.Length == 8)
                {
                    date = DateTime.ParseExact(dateString, "yyyyMMdd", null);
                }
                else if (dateString.Length > 8)
                {
                    date = DateTime.ParseExact(dateString.Substring(0, 8), "yyyyMMdd", null);
                }

                result = date.ToShortDateString();
            }
            catch (Exception ex)
            {

            }

            return result;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value != null)
                    return ((DateTime)value).ToString("yyyyMMdd");
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }

    public class TimeFormattingConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            string result = string.Empty;

            try
            {

                if (string.IsNullOrEmpty((string)value))
                    return null;
                string dateString = value.ToString().Trim();

                DateTime s = DateTime.ParseExact(dateString, "yyyyMMdd HH:mm:ss", new CultureInfo("en-US"));

                result = $"{s:T}";

            }
            catch (Exception)
            {

            }

            return result;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
        #endregion
    }
}
