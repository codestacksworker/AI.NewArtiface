using System;
using System.Windows.Forms;
using SING.Data.Controls.Video.VideoSdkHelper.Enum;
using static SING.Data.Controls.Video.VideoSdkHelper.VideoClient;
using System.Runtime.InteropServices;
using SING.Data.Controls.Video.VideoSdkHelper.Models;
using SING.Data.Help;

namespace SING.Data.Controls.Video.VideoSdkHelper
{
    public partial class ViedeoPlayerWin : UserControl
    {
        public ViedeoPlayerWin()
        {
            InitializeComponent();
            data = new VideoItem();
            data.Duration = new TimeQuantum();
            RecordManager = new RecordManager(this.Handle);
        }

        #region  属性

        public double TotalSeconds
        {
            get { return data.Duration.End.Subtract(data.Duration.Begin).TotalSeconds; }
        }

        private DateTime _currentTime;
        public DateTime CurrentTime
        {
            get
            {
                GetTime();
                return _currentTime;
            }
            set
            {
                _currentTime = value;

                if (_currentTime == DateTime.MinValue)
                    return;

                SetTime();
            }
        }

        public double CurrentPercond
        {
            get
            {
                if (TotalSeconds <= 0) return 0;
                return CurrentTime.Subtract(data.Duration.Begin).TotalSeconds / TotalSeconds;
            }
            set
            {
                CurrentTime = data.Duration.Begin.Add(new TimeSpan(0, 0, (int)(value * TotalSeconds)));
            }
        }

        private void SetTime()
        {
            SetVideoProgress((int)_currentTime.DToLong());
        }

        private void GetTime()
        {
            int timestamp = 0;
            int result = -1;
            result = GetPlayTimeStamp(ref timestamp);

            if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
                _currentTime = ((long)timestamp).LToDateTime();
        }

        private VideoItem data;

        public VideoItem Data
        {
            get { return data; }
            set { data = value; }
        }
        #endregion

        public int Init()
        {
            return RecordManager.Init();
        }

        public int Login(string sIp, int nPort, string sName, string sPassword, int nLoginID = 0)
        {
            data.ServerIp = sIp;
            data.ServerPort = nPort;
            data.ServerUserName = sName;
            data.ServerPwd = sPassword;
            return RecordManager.Login(sIp, nPort, sName, sPassword, nLoginID);
        }

        public int ReLogin()
        {
            return RecordManager.ReLogin();
        }

        public int LogOut()
        {
            return RecordManager.LogOut();
        }

        public int PlayBack(string szNodeID, DateTime szStartTime, DateTime szEndTime, DateTime szCurrentPlayTime, int nPlatID)
        {
            data.Duration.Begin = szStartTime;
            data.Duration.End = szEndTime;
            data.Duration.Current = szCurrentPlayTime;
            data.PlatID = nPlatID;
            return RecordManager.PlayBack(szNodeID, szStartTime, szEndTime, szCurrentPlayTime,
                EnumStorageType.SYS_STORAGE_CSS_SER, EnumRecordType.SYS_RECORD_PLAN, nPlatID);
        }

        public int Play(EnumRecordPlayCtrl operation)
        {
            return RecordManager.Play(operation);
        }

        public int SetVideoProgress(int nTotleSeconds)
        {
            return RecordManager.SetVideoProgress(nTotleSeconds);
        }

        public int GetPlayTimeStamp(ref int nTimeStamp)
        {
            return RecordManager.GetPlayTimeStamp(ref nTimeStamp);
        }

        public int GetVideoProgress(ref int nPos)
        {
            return RecordManager.GetVideoProgerss(ref nPos);
        }

        public int StartLocalRecord(int handle, int hWnd, string szFileName, string szBelongtoDomainID,
            EnumRecordType eRecordType)
        {
            return RecordManager.StartLocalRecord(szFileName, szBelongtoDomainID, eRecordType);
        }

        //录像下载
        //result = Video_SDK_DownloadRecordFileByTime(m_handle, "52_#_51000003_1_101", "2017-05-04-16-42-57","2017-05-04-16-43-49", SYS_STORAGE_CSS_SER,DOWNLOAD_CLIENT, SYS_RECORD_PLAN,\
        //  "52_51000012_#_#_99*52_51000006_#_#_99*52_51000002_#_#_99*52_51000001_#_#_99", "c:\\Client\\LocalRecord\\22.GMF");
        public int LoadFile(string szNodeID, DateTime szStartTime, DateTime szEndTime,
            EnumStorageType eStorageType, EnumDownloadMode eDownloadMode,
            string szBelongDomainID = "", string szFileName = "", int nPlatID = 0)
        {
            return RecordManager.LoadFile(szNodeID, szStartTime, szEndTime,
            eStorageType, eDownloadMode, EnumRecordType.SYS_RECORD_ALL,
            szBelongDomainID, szFileName, nPlatID);
        }

        public int SetProgressNotify(ProgressNotifyCallBack pProgressNotifyCB, IntPtr pUserData)
        {
            return RecordManager.SetProgressNotify(pProgressNotifyCB, pUserData);
        }

        public int SetNetEventNotify([MarshalAs(UnmanagedType.FunctionPtr)] NetEventNotifyCallBack pNetEventNotifyCbFun, IntPtr pUserData)
        {
            return RecordManager.SetNetEventNotify(pNetEventNotifyCbFun, pUserData);
        }

        public void dispose()
        {
            //RecordManager.Dispose();
        }

        public RecordManager RecordManager { get; set; }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, e.Location);
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "打开":
                    PlayBack("52_#_51000004_1_101", DateTime.Now.AddSeconds(-8), DateTime.Now.AddSeconds(7),
                        DateTime.Now, 52);
                    break;
                case "播放":
                    RecordManager.Play(EnumRecordPlayCtrl.RECORD_CTRL_PLAY);
                    break;
                case "暂停":
                    RecordManager.Play(EnumRecordPlayCtrl.RECORD_CTRL_PAUSE);
                    break;
                //case "快进":
                //    RecordManager.Play(EnumRecordPlayCtrl.RECORD_CTRL_FAST);
                //    break;
                //case "慢进":
                //    RecordManager.Play(EnumRecordPlayCtrl.RECORD_CTRL_SLOW);
                //    break;
                case "停止":
                    RecordManager.Play(EnumRecordPlayCtrl.RECORD_CTRL_STOP);
                    break;
            }
        }

        ~ViedeoPlayerWin()
        {
            LogOut();
            Dispose();
        }
    }
}
