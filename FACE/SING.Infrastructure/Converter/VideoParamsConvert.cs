using SING.Data.Controls.TreeControl.Models;
using SING.Data.Controls.Video.VideoSdkHelper.Models;
using SING.Data.Logger;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SING.Infrastructure.Converter
{
    public class VideoParamsConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            VideoItem item = null;

            try
            {
                if (value == null) return null;
                DataItem data = (DataItem)value;
                item = new VideoItem
                {
                    ServerIp = data.Channel.ChannelAddr,
                    ServerPort = data.Channel.ChannelPort,
                    ServerUserName = data.Channel.ChannelUid,
                    ServerPwd = data.Channel.ChannelPsw,
                    ChannelNo = data.Channel.ChannelNo,
                    PlatID = 52
                };
            }
            catch (Exception ex)
            {
                Logger.Error($"【Error】：视频参数获取失败！【SING.Infrastructure.Converter.VideoParamsConvert】-->【函数名】: Convert", ex);
            }

            return item;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
