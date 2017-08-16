using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoSdkHelper;
using VideoSdkHelper.Enum;

namespace VideoSDKTest.Controls
{
    public class BaseManager:IDisposable
    {
        protected IntPtr HWND = IntPtr.Zero;
        protected int _result = -1;
        protected int handle;

        public BaseManager(IntPtr Hwdn)
        {
            HWND = Hwdn;
        }

        public virtual int Login(string sIp, int nPort, string sName, string sPassword, int nLoginID = 0)
        {
            int result = -1;
            try
            {
                result = VideoClient.Video_SDK_Init(0);
                result = VideoClient.Video_SDK_Login(out handle, sIp, nPort, sName, sPassword, 2);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public virtual int LogOut()
        {
            int result = -1;
            try
            {
                result = VideoClient.Video_SDK_Logout(handle);
                result = VideoClient.Video_SDK_Cleanup();
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public void Dispose()
        {
            try
            {
                VideoClient.Video_SDK_Cleanup();
            }
            catch (Exception ex)
            {

            }
        }
    }

    public class RecordManager : BaseManager
    {
        public RecordManager(IntPtr Hwdn) : base(Hwdn)
        {
        }

        public int PlayBack(string szNodeID, DateTime szStartTime, DateTime szEndTime, DateTime szCurrentPlayTime, EnumStorageType eStorage, EnumRecordType eRecordType, int nPlatID)
        {
            int result = -1;
            try
            {
                result = VideoClient.Video_SDK_PlayRecordVideoByTime(handle, szNodeID,
                    "2017-06-15-16-42-53", "2017-06-15-16-43-20", "2017-06-15-16-42-53", eStorage,eRecordType, HWND, nPlatID);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        #region  控制

        public int Play(EnumRecordPlayCtrl operation)
        {
            int result = -1;
            try
            {
                result = VideoClient.Video_SDK_RecordPlayCtrl(handle, HWND, operation, 0, 0);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public int GetVideoProgerss(ref int progress)
        {
            int result = -1;
            try
            {
                result = VideoClient.Video_SDK_GetPlayProgress(handle, HWND, ref progress);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public int SetVideoProgress(int progress)
        {
            int result = -1;
            try
            {
                result = VideoClient.Video_SDK_SetRecordPlayProgressByTime(handle, HWND, progress);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        #endregion
    }
}
