using Dev_SING.Data.BaseTools;
using SING.Data.BaseTools;
using SING.Data.Controls.Video.VideoSdkHelper;
using SING.Data.Controls.Video.VideoSdkHelper.Enum;
using SING.Data.Controls.Video.VideoSdkHelper.Models;
using SING.Data.Help;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static SING.Data.Controls.Video.VideoSdkHelper.VideoClient;


namespace SING.Data.Controls.Video
{
    /// <summary>
    /// VideoPlayer.xaml 的交互逻辑
    /// </summary>
    public partial class VideoPlayer : UserControl, IDisposable
    {
        private DispatcherTimer timer = null;
        private NetEventNotifyCallBack onNetConnected = null;
        private ProgressNotifyCallBack onPlayedComplete = null;
        public VideoPlayer()
        {
            InitializeComponent();

            onNetConnected = new NetEventNotifyCallBack(OnNetEventNotifyCallBack);
            onPlayedComplete = new ProgressNotifyCallBack(OnPlayCompleteCallBack);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            sliderPosition.Value = PlayerWnd.CurrentPercond * sliderPosition.Maximum;
            var usedSeconds = (int)(PlayerWnd.CurrentPercond * PlayerWnd.TotalSeconds);
            if (usedSeconds <= 0) usedSeconds = 0;
            TimeSpan time = new TimeSpan(0, 0, usedSeconds);
            TimeSpan duration = new TimeSpan(0, 0, (int)PlayerWnd.TotalSeconds);
            tblTime.Text = string.Format("{0:00}:{1:00}:{2:00}/{3:00}:{4:00}:{5:00}", time.Hours, time.Minutes,
                time.Seconds, duration.Hours, duration.Minutes, duration.Seconds);//显示媒体时间属性 
        }

        #region  属性
        private bool _IsPlayCompleted = true;
        public bool IsPlayCompleted
        {
            get
            {
                return _IsPlayCompleted;
            }
            set
            {
                _IsPlayCompleted = value;
            }
        }
        #endregion

        #region  控制
        public int Init()
        {
            return PlayerWnd.Init();
        }

        public int Login()
        {
            return PlayerWnd.Login(ItemSource.ServerIp, ItemSource.ServerPort, ItemSource.ServerUserName, ItemSource.ServerPwd, ItemSource.PlatID);
        }

        //接口有问题，Error：提示密码错误
        public int ReLogin()
        {
            return PlayerWnd.ReLogin();
        }

        public int LogOut()
        {
            return PlayerWnd.LogOut();
        }

        public void dispose()
        {
            PlayerWnd.dispose();
        }

        public int PlayBack()
        {
            return PlayerWnd.PlayBack(ItemSource.ChannelNo, ItemSource.Duration.Begin,
                ItemSource.Duration.End, ItemSource.Duration.Current, ItemSource.PlatID);
        }

        public int Play(EnumRecordPlayCtrl operation)
        {
            return PlayerWnd.Play(operation);
        }

        //录像下载
        //result = Video_SDK_DownloadRecordFileByTime(m_handle, "52_#_51000003_1_101", "2017-05-04-16-42-57","2017-05-04-16-43-49", SYS_STORAGE_CSS_SER,DOWNLOAD_CLIENT, SYS_RECORD_PLAN,\
        //  "52_51000012_#_#_99*52_51000006_#_#_99*52_51000002_#_#_99*52_51000001_#_#_99", "c:\\Client\\LocalRecord\\22.GMF");
        public int SaveVideoRecord(string szNodeID, DateTime szStartTime, DateTime szEndTime, string szBelongDomainID = "", string szFileName = "", int nPlatID = 0)
        {
            return PlayerWnd.LoadFile(szNodeID, szStartTime, szEndTime,
            EnumStorageType.SYS_STORAGE_CSS_SER, EnumDownloadMode.DOWNLOAD_CLIENT,
            szBelongDomainID, szFileName, nPlatID);
        }

        public int SetProgressNotify(ProgressNotifyCallBack pProgressNotifyCB, IntPtr pUserData)
        {
            return PlayerWnd.SetProgressNotify(pProgressNotifyCB, pUserData);
        }

        public int SetNetEventNotify(NetEventNotifyCallBack pNetEventNotifyCbFun, IntPtr pUserData)
        {
            return PlayerWnd.SetNetEventNotify(pNetEventNotifyCbFun, pUserData);
        }
        #endregion

        #region  依赖属性
        public VideoItem ItemSource
        {
            get { return (VideoItem)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(VideoItem), typeof(VideoPlayer), new PropertyMetadata(null));

        public int MediaPosition
        {
            get { return (int)GetValue(MediaPositionProperty); }
            set { SetValue(MediaPositionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MediaPosition.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MediaPositionProperty =
            DependencyProperty.Register("MediaPosition", typeof(int), typeof(VideoPlayer), new PropertyMetadata(0));



        public bool IsConnected
        {
            get { return (bool)GetValue(IsConnectedProperty); }
            set { SetValue(IsConnectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsConnected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsConnectedProperty =
            DependencyProperty.Register("IsConnected", typeof(bool), typeof(VideoPlayer), new PropertyMetadata(false));

        public bool IsPaused
        {
            get { return (bool)GetValue(IsPausedProperty); }
            set { SetValue(IsPausedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPaused.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPausedProperty =
            DependencyProperty.Register("IsPaused", typeof(bool), typeof(VideoPlayer), new PropertyMetadata(true));
        #endregion

        #region   事件
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            int result = -1;
            if (!_IsPlayCompleted)
            {
                if (IsPaused)
                {
                    result = Play(EnumRecordPlayCtrl.RECORD_CTRL_PLAY);
                    if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
                    {
                        timer.Start();
                        IsPaused = false;
                    }
                }
                else
                {
                    result = Play(EnumRecordPlayCtrl.RECORD_CTRL_PAUSE);
                    if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
                    {
                        timer.Stop();
                        IsPaused = true;
                    }
                }
            }
            else
            {
                result = PlayBack();
                if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
                {
                    _IsPlayCompleted = false;
                    IsPaused = false;
                    timer.Start();
                }
            }

            if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
            {
                MessageBoxHelper.Show("播放失败,【错误码:" + result + "】", "提示", MessageBoxImage.Warning);
            }

        }

        private void sliderPosition_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sliderPosition.Value = (float)e.NewValue;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            int result = -1;
            if (ItemSource != null)
            {
                //result = Init();
                //if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
                result = Login();

                if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
                {
                    IsConnected = true;
                    result = SetNetEventNotify(onNetConnected, IntPtr.Zero);
                }
                else
                    IsConnected = false;


                if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
                    result = SetProgressNotify(onPlayedComplete, IntPtr.Zero);
            }
        }

        private void OnPlayCompleteCallBack(int handle, EnumTransferType eTransType, int nPos, IntPtr pData, IntPtr pUserData)
        {
            IsPlayCompleted = true;
            timer.Stop();
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                IsPaused = true;
                TimeSpan duration = new TimeSpan(0, 0, (int)PlayerWnd.TotalSeconds);
                tblTime.Text = string.Format("{0:00}:{1:00}:{2:00}/{3:00}:{4:00}:{5:00}", duration.Hours, duration.Minutes,
                    duration.Seconds, duration.Hours, duration.Minutes, duration.Seconds);//显示媒体时间属性 
                sliderPosition.Value = sliderPosition.Maximum;
            }));
        }

        private void OnNetEventNotifyCallBack(int handle, NET_EVENT_TYPE eNetEventType, IntPtr pUserData)
        {
            int result = -1;
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (eNetEventType == NET_EVENT_TYPE.NET_EVENT_TYPE_CLOSE)
                    {
                        IsConnected = false;
                    }
                    if (eNetEventType == NET_EVENT_TYPE.NET_EVENT_TYPE_RECONNECT)
                    {
                        if (ItemSource != null)
                        {
                            result = LogOut();
                            if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
                            {
                                result = Login();
                                if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
                                    IsConnected = true;
                            }
                        }
                    }
                }));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string fileName = string.Empty;
                Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();

                sfd.Title = "请保存视频记录";
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                sfd.Filter = "GMF|*.GMF";
                sfd.FilterIndex = 1;
                sfd.RestoreDirectory = true;
                sfd.ValidateNames = true;
                sfd.AddExtension = true;
                sfd.FileName = !string.IsNullOrEmpty(fileName) ? fileName : string.Format(@"{0}", DateTime.Now.ToString("yyyyMMddhhmmss"));
                sfd.DefaultExt = "gmf";
                sfd.CheckPathExists = true;

                if (sfd.ShowDialog() == true)
                {
                    fileName = sfd.FileName;

                    int isSave = -1;

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        if (ItemSource != null && ItemSource.PlatID > 0)
                        {
                            var szBelongDomainID = ItemSource.PlatID + "_#_#_#_99";
                            isSave = SaveVideoRecord(ItemSource.ChannelNo, ItemSource.Duration.Begin, ItemSource.Duration.End, szBelongDomainID, fileName, ItemSource.PlatID);
                        }

                        if (isSave == 0)
                            MessageBoxHelper.Show("保存成功！", "提示", MessageBoxImage.Information);
                        else
                            MessageBoxHelper.Show("保存失败！", "提示", MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Show("保存失败！", "提示", MessageBoxImage.Warning);
                Logger.Logger.Error("【Error】：保存图片异常！【SaveImage】-->【函数名】：Action", ex);
            }
        }
        #endregion

        public void Dispose()
        {
            if (timer != null)
            {
                timer.Stop();
                timer = null;
            }
            LogOut();
            dispose();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            Dispose();
        }

        private void sliderPosition_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (PlayerWnd.TotalSeconds > 0)
            {
                PlayerWnd.Play(EnumRecordPlayCtrl.RECORD_CTRL_PAUSE);
                timer.Stop();
            }
        }

        private void sliderPosition_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (PlayerWnd.TotalSeconds > 0)
            {
                double newpercond = sliderPosition.Value / sliderPosition.Maximum;
                PlayerWnd.Play(EnumRecordPlayCtrl.RECORD_CTRL_PLAY);
                timer.Start();
                PlayerWnd.CurrentPercond = newpercond;
            }
        }
    }
}
