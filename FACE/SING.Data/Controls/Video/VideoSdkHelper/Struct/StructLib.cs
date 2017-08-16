using System.Runtime.InteropServices;

namespace SING.Data.Controls.Video.VideoSdkHelper.Struct
{

    [StructLayout(LayoutKind.Sequential)]
    public struct DevParaCmd
    {

        /// INT32->int
        public int iCmdLen;

        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string CmdContent;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct SDK_FRAME_INFO
    {

        /// int
        public int nWidth;//画面宽，单位像素。如果是音频数据则为； 

        /// int
        public int nHeight; //画面高。如果是音频数据则为；

        /// int
        public int nStamp;//时标信息，单位毫秒。 

        /// int
        public int nType; //数据类型，T_AUDIO16，T_RGB32，T_YV12详见宏定义说明。 

        /// int
        public int nFrameRate; //编码时产生的图像帧率。 
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDK_StruDateTime
    {

        /// int
        public int iYear;

        /// int
        public int iMonth;

        /// int
        public int iDay;

        /// int
        public int iHour;

        /// int
        public int iMinute;

        /// int
        public int iSecond;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HMODULE
    {

        /// int
        public int unused;
    }
}
