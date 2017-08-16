using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Controls.VideoControl
{
    public interface IVideoBase
    {
        /// <summary>
        /// 传入参数stOcxPara为json形式的字符串。具体传输那些参数值，两边要定义一致。
        ///“{
        ///	“OcxID”: “1111111111111”,
        ///	“其它参数1”: “”,
        ///	“其它参数2”: “”
        /// }”
        /// </summary>
        /// <param name="paras"></param>
        void Initialize(VideoParameter paras, string controlName="");

        /// <summary>
        /// "192.168.1.146", 10002, "admin", "123@456"
        /// </summary>
        /// <param name="sIP"></param>
        /// <param name="nPort"></param>
        /// <param name="sUserName"></param>
        /// <param name="sPassword"></param>
        byte Login();

        /// <summary>
        /// 打开视频
        /// "52_#_51000008_1_101" 视频平台参数字符串  nPlatFormID_#_nDeviceID_nChannelID_nChannelType
        /// 流的类型（1实时流,2  平台录像流,3  DVR前端设备录像流）
        /// </summary>
        byte Play(int PlatFormID, int DeviceID, int ChannelID, int ChannelType, int StreamType);

        /// <summary>
        /// 关闭视频
        /// </summary>
        byte Stop();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        byte LogOut();
        byte Delete();
        void DisPose();
    }
}
