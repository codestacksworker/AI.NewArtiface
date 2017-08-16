using SING.Data.Controls.Video.VideoSdkHelper;
using System;
using SING.Data.BaseTools;
using SING.Data.Controls.Video.VideoSdkHelper.Enum;
using static SING.Data.Controls.Video.VideoSdkHelper.VideoClient;
using SING.Data.Help;
using System.Runtime.InteropServices;

namespace SING.Data.Controls.Video
{
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
                result = Video_SDK_PlayRecordVideoByTime(handle, szNodeID,
                    szStartTime.DToVideoTime(), szEndTime.DToVideoTime(),
                    szStartTime.DToVideoTime(), eStorage, eRecordType, HWND, nPlatID);
                if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
                    Logger.Logger.Info($"【Error】：视频打开失败！【RecordManager】-->【函数名】: PlayBack:{Catch(result)}");
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"【Error】：视频打开失败！【RecordManager】-->【函数名】: PlayBack;", ex);
            }
            return result;
        }

        #region  控制

        public int Play(EnumRecordPlayCtrl operation)
        {
            int result = -1;
            try
            {
                result = Video_SDK_RecordPlayCtrl(handle, HWND, operation, 0, 0);
                if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
                    Logger.Logger.Info($"【Error】：视频打开失败！【RecordManager】-->【函数名】: Play:{Catch(result)}");
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"【Error】：视频打开失败！【RecordManager】-->【函数名】: Play;", ex);
            }
            return result;
        }

        public int GetVideoProgerss(ref int nPos)
        {
            int result = -1;
            try
            {
                result = Video_SDK_GetPlayProgress(handle, HWND, ref nPos);
                if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
                    Logger.Logger.Info($"【Error】：视频打开失败！【RecordManager】-->【函数名】: GetVideoProgerss:{Catch(result)}");
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"【Error】：视频打开失败！【RecordManager】-->【函数名】: GetVideoProgerss;", ex);
            }
            return result;
        }

        #region 播放进度
        public int SetVideoProgress(int nTotleSeconds)
        {
            int result = -1;
            try
            {
                result = Video_SDK_SetRecordPlayProgressByTime(handle, HWND, nTotleSeconds);
                if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
                    Logger.Logger.Info($"【Error】：视频打开失败！【RecordManager】-->【函数名】: SetVideoProgress:{Catch(result)}");
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"【Error】：视频打开失败！【RecordManager】-->【函数名】: SetVideoProgress;", ex);
            }
            return result;
        }

        public int GetPlayTimeStamp(ref int nTimeStamp)
        {
            int result = -1;
            try
            {
                result = Video_SDK_GetPlayTimeStamp(handle, HWND, ref nTimeStamp);
                if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
                    Logger.Logger.Info($"【Error】：视频打开失败！【RecordManager】-->【函数名】: GetPlayTimeStamp:{Catch(result)}");
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"【Error】：视频打开失败！【RecordManager】-->【函数名】: GetPlayTimeStamp;", ex);
            }
            return result;
        }
        #endregion

        //result = Video_SDK_StartLocalRecord(m_handle, m_static[0].m_hWnd, "c:\\Client\\LocalRecord\\11.GMF", \
        //  "52_51000012_#_#_99*52_51000006_#_#_99*52_51000002_#_#_99*52_51000001_#_#_99", SYS_RECORD_MANUAL);
        public int StartLocalRecord(string szFileName, string szBelongtoDomainID, EnumRecordType eRecordType)
        {
            int result = -1;
            try
            {
                result = Video_SDK_StartLocalRecord(handle, HWND, szFileName, szBelongtoDomainID, eRecordType);

                if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
                    Logger.Logger.Info($"【Error】：视频打开失败！【RecordManager】-->【函数名】: StartLocalRecord:{Catch(result)}");
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"【Error】：视频打开失败！【RecordManager】-->【函数名】: StartLocalRecord;", ex);
            }
            return result;
        }

        public int LoadFile(string szNodeID, DateTime szStartTime, DateTime szEndTime,
            EnumStorageType eStorageType, EnumDownloadMode eDownloadMode, EnumRecordType eRecordType = EnumRecordType.SYS_RECORD_ALL,
            string szBelongDomainID = "", string szFileName = "", int nPlatID = 0)
        {
            int result = -1;
            try
            {
                result = Video_SDK_DownloadRecordFileByTime(handle, szNodeID, szStartTime.DToVideoTime(), szEndTime.DToVideoTime(), eStorageType, eDownloadMode, eRecordType, szBelongDomainID, szFileName, nPlatID);
                if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
                    result = Video_SDK_StopDownloadByTime(handle, szNodeID, szStartTime.DToVideoTime(), szEndTime.DToVideoTime());

                if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
                    Logger.Logger.Info($"【Error】：视频打开失败！【RecordManager】-->【函数名】: LoadFile:{Catch(result)}");
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"【Error】：视频打开失败！【RecordManager】-->【函数名】: LoadFile;", ex);
            }
            return result;
        }

        public int SetProgressNotify(ProgressNotifyCallBack pProgressNotifyCB, IntPtr pUserData)
        {
            int result = -1;
            try
            {
                result = Video_SDK_SetProgressNotify(pProgressNotifyCB, pUserData);

                if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
                    Logger.Logger.Info($"【Error】：视频打开失败！【RecordManager】-->【函数名】: Video_SDK_SetProgressNotify:{Catch(result)}");
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"【Error】：视频打开失败！【RecordManager】-->【函数名】: Video_SDK_SetProgressNotify;", ex);
            }
            return result;
        }       
        #endregion
    }
}