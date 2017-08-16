using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SING.Data.BaseTools;
using SING.Data.DAL.Data;
using SING.Infrastructure.Enums;

namespace SING.Infrastructure.Converter
{
    public class DirectConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = string.Empty;

            try
            {
                int num = System.Convert.ToInt32(value);
                result = EnumUtils.Parse<VideoDirectEnum>(num);
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

    //public class RegionNameConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        string regionName = string.Empty;

    //        try
    //        {
    //            if (value == null) return regionName;

    //            ChannelData channel = value as ChannelData;

    //            if (channel.RegionId > 0&&channel)
    //            {
    //                point = new PointLatLng(channel.ChannelLatitude, channel.ChannelLongitude);
    //            }
    //        }
    //        catch (Exception)
    //        {

    //        }

    //        return point;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return targetType.Assembly;
    //    }
    //}
}
