using SING.Data.Controls.Video.VideoSdkHelper.Models;
using SING.Data.DAL;
using SING.Data.DAL.Data;
using SING.Data.DAL.ScheduleConvert;
using SING.Data.Help;
using SING.Data.Logger;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FACE_DynamicComparison.Converter
{
    public class VideoInfoConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            VideoItem result = null;

            try
            {
                AlertData s = (AlertData)value;
                if (s == null) return null;
                var item = Channel.QueryChannel(s.ChannelId);
                if (item == null) return null;
                result = DataConvert.VideoFromData(item);
                result.Duration = new TimeQuantum();
                result.Duration.Current = s.FcapTime.SToDateTime();
                result.Duration.Begin = result.Duration.Current.Subtract(TimeSpan.FromSeconds(8));
                result.Duration.End = result.Duration.Current.Subtract(TimeSpan.FromSeconds(-7));
            }
            catch (Exception ex)
            {
                Logger.Error($"【Error】：HTTP连接失败！【FACE_AlertInfo.Converter.VideoInfoConvert】-->【函数名】: Convert", ex);
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
