using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using SING.Data.DAL;
using SING.Data.DAL.Data;
using SING.Data.Help;
using FACE_MonitorTasks.Models;

namespace FACE_MonitorTasks.Converter
{
    public class EnabledStatusConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = string.Empty;

            try
            {
                int status = (int)value;
                switch (status)
                {
                    case 1:
                        result = "是";
                        break;
                    case 2:
                        result = "否";
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
                if (value != null)
                {
                    string status = value.ToString();
                    switch (status)
                    {
                        case "是":
                            result = 1;
                            break;
                        case "否":
                            result = 2;
                            break;
                    }
                }
            }
            catch (Exception)
            {

            }

            return result;
        }
    }

    public class IntToVisibilityReverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility result = Visibility.Visible;

            try
            {
                if (value != null)
                {
                    result = (int)value <= 0 ? Visibility.Visible : Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class VisibilityReverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility result = Visibility.Collapsed;

            try
            {
                if (value != null)
                {
                    result = (Visibility)value == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }


    public class CmpMethodStringConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int status = (int)value;
            return CmpStrategy.GetMethodStringName(status);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

    }

    public class CmpMethodTypeStringConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int status = (int)value;
            return CmpStrategy.GetMethodTypeStringName(status);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

    }


    public class TaskTypeConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int status = (int)value;
            return MonitorTask.GetTaskTypeName(status);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

    }
    public class TaskStatusConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int status = (int)value;
            return MonitorTask.GetTaskStatusName(status);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

    }




}
