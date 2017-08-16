using System;
using SING.Data.Controls.Video.VideoSdkHelper;
using SING.Data.BaseTools;
using System.Runtime.InteropServices;
using static SING.Data.Controls.Video.VideoSdkHelper.VideoClient;

namespace SING.Data.Controls.Video
{
    public class BaseManager//:IDisposable
    {
        protected IntPtr HWND = IntPtr.Zero;
        protected int _result = -1;
        protected int handle;

        public BaseManager(IntPtr Hwdn)
        {
            HWND = Hwdn;
        }

        public virtual int Init()
        {
            int result = -1;
            try
            {
                result = VideoClient.Video_SDK_Init(0);
                if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
                    Logger.Logger.Info($"【Error】：重新登陆失败！【BaseManager】-->【函数名】: ReLogin:{Catch(result)}");
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"【Error】：重新登陆失败！【BaseManager】-->【函数名】: ReLogin;", ex);
            }
            return result;
        }

        public virtual int Login(string sIp, int nPort, string sName, string sPassword, int nLoginID = 0)
        {
            int result = -1;
            try
            {
                result = VideoClient.Video_SDK_Login(out handle, sIp, nPort, sName, sPassword, 2);
                if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
                    Logger.Logger.Info($"【Error】：用户登陆失败！【BaseManager】-->【函数名】: Login:{Catch(result)}");
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"【Error】：用户登陆失败！【BaseManager】-->【函数名】: Login;", ex);
            }
            return result;
        }

        public virtual int ReLogin()
        {
            int result = -1;
            try
            {
                result = VideoClient.Video_SDK_Relogin(handle);
                if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
                    Logger.Logger.Info($"【Error】：重新登陆失败！【BaseManager】-->【函数名】: ReLogin:{Catch(result)}");
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"【Error】：重新登陆失败！【BaseManager】-->【函数名】: ReLogin;", ex);
            }
            return result;
        }

        public virtual int LogOut()
        {
            int result = -1;
            try
            {
                result = VideoClient.Video_SDK_Logout(handle);
                if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
                    Logger.Logger.Info($"【Error】：登出操作失败！【BaseManager】-->【函数名】: LogOut:{Catch(result)}");
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"【Error】：登出操作失败！【BaseManager】-->【函数名】: LogOut;", ex);
            }
            return result;
        }

        public int SetNetEventNotify([MarshalAs(UnmanagedType.FunctionPtr)] NetEventNotifyCallBack pNetEventNotifyCbFun, IntPtr pUserData)
        {
            int result = -1;
            try
            {
                result = Video_SDK_SetNetEventNotify(pNetEventNotifyCbFun, pUserData);

                if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
                    Logger.Logger.Info($"【Error】：网络监控异常！【RecordManager】-->【函数名】: SetNetEventNotify:{Catch(result)}");
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"【Error】：网络监控异常！【RecordManager】-->【函数名】: SetNetEventNotify;", ex);
            }
            return result;
        }

        //public void Dispose()
        //{
        //    int result = -1;
        //    try
        //    {
        //        result = VideoClient.Video_SDK_Cleanup();

        //        if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
        //            Logger.Logger.Info($"【Error】：资源释放失败！【BaseManager】-->【函数名】: Dispose:{Catch(result)}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Logger.Error($"【Error】：资源释放失败！【BaseManager】-->【函数名】: Dispose;", ex);
        //    }
        //}

        public string Catch(int code)
        {
            return EnumUtils.Parse<SysParameter>(code);
        }
    }
}
