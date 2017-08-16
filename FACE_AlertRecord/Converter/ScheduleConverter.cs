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

namespace FACE_AlertRecord.Converter
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

    public class DefDbTypeConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = string.Empty;

            try
            {
                int type = (int)value;

                var Dbtype = BasicData.DefDbTypes.SingleOrDefault(p => p.Type.Equals(type));

                if (Dbtype != null)
                {
                    result = Dbtype.Description;
                }
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

    public class EditorHeightConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null)
            {
                return "0";
            }
            else
            {
                bool r = (bool)value;
                if (r)
                {
                    double y = SystemParameters.PrimaryScreenHeight;//得到屏幕整体高度
                    if (y > 1200)
                    {
                        return "30%";
                    }
                    else
                        return "Auto";
                }
                else
                {
                    return "0";
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class ShowVisibilityConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility result = Visibility.Visible;
            if (value != null)
            {
                try
                {
                    if (!(bool)value)
                    {
                        result = Visibility.Collapsed;
                    }
                }
                catch (Exception)
                {
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class FtIndexBinaryImgConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value != null && parameter != null)
                {
                    List<FaceTemplateData> list = value as List<FaceTemplateData>;

                    if (list.Count == 0) return null;

                    int index = int.Parse(parameter.ToString());

                    FaceTemplateData ftd = list.FirstOrDefault(p => p != null && p.FtIndex == index && p.Deed != (int) FtStatus.Deleted);

                    if (ftd != null)
                    {
                        byte[] bytes = ftd.FtImage;

                        BitmapImage image = ImageConvert.ByteArrayToBitmapImage(bytes);
                        return image;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class EditorHeight : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "Auto";
            if (value != null)
            {
                try
                {
                    if ((Visibility)value == Visibility.Collapsed)
                    {
                        result = "1";
                    }
                }
                catch (Exception)
                {
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }


    public class AgeByBirthDateConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = string.Empty;

            try
            {
                DateTime datebrith = (DateTime)value;
                TimeSpan ts = DateTime.Now - datebrith;
                double age = ts.TotalDays / 365.0;
                result = age.ToString();

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


    /// <summary>
    /// 身份证id 类型转换描述
    /// </summary>
    public class FaceObjectIdTypeConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = string.Empty;

            try
            {
                int temp1 = (int)value;
                switch (temp1)
                {
                    case 0:
                        result = "未知";
                        break;
                    case 1:
                        result = "身份证";
                        break;
                    case 2:
                        result = "护照";
                        break;
                    case 3:
                        result = "军官证";
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
            return null;
        }
    }


    /// <summary>
    /// 性别类型转换描述
    /// </summary>
    public class FaceObjectSexTypeConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = string.Empty;

            try
            {
                int temp1 = (int)value;
                switch (temp1)
                {
                    case 0:
                        result = "未知";
                        break;
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
            return null;
        }
    }


    /// <summary>
    /// 人脸对象类型转换描述
    /// </summary>
    public class FaceObjectTypeConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = string.Empty;

            try
            {
                int temp1 = (int)value;
                switch (temp1)
                {
                    case 0:
                        result = "请选择";
                        break;
                    case 1:
                        result = "普通";
                        break;
                    case 2:
                        result = "黑名单";
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
            return null;
        }
    }



    /// <summary>
    /// 人脸对象敏感级别转换描述
    /// </summary>
    public class FaceObjetSensitivelevelConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = string.Empty;

            try
            {
                int temp1 = (int)value;
                switch (temp1)
                {
                    case 0:
                        result = "请选择";
                        break;
                    case 1:
                        result = "一级";
                        break;
                    case 2:
                        result = "二级";
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
            return null;
        }
    }

    /// <summary>
    /// 年龄转换
    /// </summary>
    public class AgeByDateTimeConvert : IValueConverter
    {
        private int GetAgeByBirthdate(DateTime birthdate)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthdate.Year;
            if (now.Month < birthdate.Month || (now.Month == birthdate.Month && now.Day < birthdate.Day))
            {
                age--;
            }
            return age < 0 ? 0 : age;
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = string.Empty;

            try
            {
                if (value == null)
                {
                    return null;
                }
                if (value.ToString().Length > 8)
                {
                    DateTime time = DateTime.ParseExact(value.ToString(), "yyyyMMdd HH:mm:ss", new CultureInfo("en-US"));
                    result = GetAgeByBirthdate(time).ToString();
                }
                else
                {
                    DateTime time = DateTime.ParseExact(value.ToString(), "yyyyMMdd", new CultureInfo("en-US"));
                    result = GetAgeByBirthdate(time).ToString();
                }
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
