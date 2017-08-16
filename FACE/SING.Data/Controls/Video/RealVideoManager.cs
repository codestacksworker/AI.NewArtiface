using SING.Data.Controls.Video;
using SING.Data.Controls.Video.VideoSdkHelper;
using SING.Data.Controls.Video.VideoSdkHelper.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SING.Data.Controls.Video.VideoSdkHelper.VideoClient;

namespace SING.Data.Controls.Video
{
    public class RealVideoManager: BaseManager
    {
        public RealVideoManager(IntPtr Hwdn) : base(Hwdn)
        {
        }

        #region  方法
        public int Play(string szNodeID, int WaitOutTime = 2000)
        {
            int result = -1;
            try
            {
                result = VideoClient.Video_SDK_PlayRealVideo(handle, HWND, szNodeID, WaitOutTime, PLAY_STREAM_TYPE.STREAM__FIRST);
                if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
                    Logger.Logger.Info($"【Error】：视频打开失败！【RealVideoManager】-->【函数名】: Play:{Catch(result)}");
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"【Error】：视频关闭失败！【RealVideoManager】-->【函数名】: Stop;", ex);
            }
            return result;
        }
        public int Stop()
        {
            int result = -1;
            try
            {
                result = VideoClient.Video_SDK_CloseVideo(handle, HWND);
                if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
                    Logger.Logger.Info($"【Error】：视频关闭失败！【RealVideoManager】-->【函数名】: Stop:{Catch(result)}");
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"【Error】：视频关闭失败！【RealVideoManager】-->【函数名】: Stop;", ex);
            }
            return result;
        }

        public int StopAllVideo()
        {
            int result = -1;
            try
            {
                result = VideoClient.Video_SDK_CloseAllVideo(handle);
                if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
                    Logger.Logger.Info($"【Error】：关闭所有视频失败！【RealVideoManager】-->【函数名】: StopAllVideo:{Catch(result)}");
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"【Error】：视频关闭失败！【RealVideoManager】-->【函数名】: StopAllVideo;", ex);
            }
            return result;
        }
        #endregion

        #region 资源释放
        //~RealVideoManager()
        //{
        //    Console.WriteLine("{0}被销毁", this);
        //    Dispose(false);
        //}

        //public new void Dispose()
        //{
        //    Console.WriteLine("{0}被手动销毁", this);
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //protected void Dispose(bool disposing)
        //{
        //    Console.WriteLine("{0}被自动销毁", this);
        //    if (!disposed)
        //    {
        //        if (disposing)
        //        {
        //            //托管资源释放
        //            try
        //            {
        //                VideoClient.Video_SDK_Cleanup();
        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //        }
        //        //非托管资源释放
        //        {

        //        }
        //    }
        //    disposed = true;
        //}
        #endregion
    }
}
