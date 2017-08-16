using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using SING.Data.BaseTools;

namespace SING.Infrastructure.Converter
{
    public class UcBackgroundConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush color = new SolidColorBrush(Colors.Transparent);
            if (AppConfig.Instance == null || AppConfig.Instance.CurrentTheme == null) return color;

            if (AppConfig.Instance.CurrentTheme.ToString() == "Windows7")
            {
                color = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else if (AppConfig.Instance.CurrentTheme.ToString() == "WINDOWS8")
            {
                color = new SolidColorBrush(Color.FromRgb(6, 83, 135));
            }
            else if (AppConfig.Instance.CurrentTheme.ToString() == "Expression_Dark")
            {
                color = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class BlockBackgroundConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush color = new SolidColorBrush(Colors.Transparent);
            if (AppConfig.Instance == null || AppConfig.Instance.CurrentTheme == null) return color;

            if (AppConfig.Instance.CurrentTheme.ToString() == "Windows7")
            {
                color = new SolidColorBrush(Color.FromRgb(6, 83, 135));
            }
            else if (AppConfig.Instance.CurrentTheme.ToString() == "Expression_Dark")
            {
                color = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class BlockForeColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush color = new SolidColorBrush(Colors.LightBlue);
            if (AppConfig.Instance == null || AppConfig.Instance.CurrentTheme == null) return color;

            if (AppConfig.Instance.CurrentTheme.ToString() == "Windows7")
            {
                color = new SolidColorBrush(Colors.White);
            }
            else if (AppConfig.Instance.CurrentTheme.ToString() == "Expression_Dark")
            {
                color = new SolidColorBrush(Colors.White);
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class ForeColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush color = new SolidColorBrush(Colors.LightBlue);
         
            //if (value == null)
            //    return color;
            if (AppConfig.Instance == null || AppConfig.Instance.CurrentTheme == null) return color;

            if (AppConfig.Instance.CurrentTheme.ToString() == "Windows7")
            {
                color = new SolidColorBrush(Colors.White);
            }
            else if (AppConfig.Instance.CurrentTheme.ToString() == "Expression_Dark")
            {
                color = new SolidColorBrush(Colors.White);
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class TextboxBackgroudConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush color = new SolidColorBrush(Colors.LightBlue);
            if (value == null) return color;
            if (AppConfig.Instance == null || AppConfig.Instance.CurrentTheme == null) return color;

            if (AppConfig.Instance.CurrentTheme.ToString() == "Windows7")
            {
                color = new SolidColorBrush(Colors.White);
            }
            else if (AppConfig.Instance.CurrentTheme.ToString() == "Expression_Dark")
            {
                color = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }


    public class GridRowBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush color = new SolidColorBrush(Colors.Transparent);
            if (AppConfig.Instance == null || AppConfig.Instance.CurrentTheme == null) return color;

            if (AppConfig.Instance.CurrentTheme.ToString() == "Windows7")
            {
                //color = new SolidColorBrush(Color.FromRgb(206, 231, 255));
                color = new SolidColorBrush(Colors.LightGray);
            }
            else if (AppConfig.Instance.CurrentTheme.ToString() == "Expression_Dark")
            {
                color = new SolidColorBrush(Color.FromRgb(78, 78, 78));
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
