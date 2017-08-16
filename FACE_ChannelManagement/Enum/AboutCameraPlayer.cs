using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_ChannelManagement.Enum
{
    /// <summary>
    /// Channel
    /// </summary>
    public struct AboutCameraPlayer
    {
        /// <summary>
        /// 摄像机IP为空！
        /// </summary>
        public const string CameraIpIsNull = "摄像机IP为空！";

        /// <summary>
        /// 摄像机无法连接！
        /// </summary>
        public const string CameraOffLink = "摄像机无法连接！";

        /// <summary>
        /// 删除通道成功！
        /// </summary>
        public const string CameraDeletedSuccess = "删除通道成功！";

        /// <summary>
        /// 删除通道失败！
        /// </summary>
        public const string CameraDeletedFail = "删除通道失败！";

        /// <summary>
        /// 窗口Title
        /// 添加通道数据 Camera = Channel
        /// </summary>
        public const string TitleAddCamera = "添加通道数据";

        /// <summary>
        /// 窗口Title
        /// 添加通道数据 Camera = Channel
        /// </summary>
        public const string TitleModifyCamera = "编辑通道数据";

    }
}
