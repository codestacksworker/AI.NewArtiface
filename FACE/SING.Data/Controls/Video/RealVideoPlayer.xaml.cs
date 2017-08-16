using SING.Data.Controls.Video.VideoSdkHelper;
using SING.Data.Controls.Video.VideoSdkHelper.Enum;
using SING.Data.Controls.Video.VideoSdkHelper.Models;
using SING.Data.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static SING.Data.Controls.Video.VideoSdkHelper.VideoClient;

namespace SING.Data.Controls.Video
{
    /// <summary>
    /// RealVideoPlayer.xaml 的交互逻辑
    /// </summary>
    public partial class RealVideoPlayer : UserControl, IDisposable
    {
        private NetEventNotifyCallBack onNetConnected = null;
        public RealVideoPlayer()
        {
            InitializeComponent();
            onNetConnected = new NetEventNotifyCallBack(OnNetEventNotifyCallBack);
        }

        #region  依赖属性
        public VideoItem ItemSource
        {
            get { return (VideoItem)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(VideoItem), typeof(RealVideoPlayer), new PropertyMetadata(null));

        public bool IsPlaying
        {
            get { return (bool)GetValue(IsPlayingProperty); }
            set { SetValue(IsPlayingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsConnected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPlayingProperty =
            DependencyProperty.Register("IsPlaying", typeof(bool), typeof(RealVideoPlayer), new PropertyMetadata(false));

        public bool IsConnected
        {
            get { return (bool)GetValue(IsConnectedProperty); }
            set { SetValue(IsConnectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsConnected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsConnectedProperty =
            DependencyProperty.Register("IsConnected", typeof(bool), typeof(RealVideoPlayer), new PropertyMetadata(false));

        public bool IsStarted
        {
            get { return (bool)GetValue(IsStartedProperty); }
            set { SetValue(IsStartedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsConnected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsStartedProperty =
            DependencyProperty.Register("IsStarted", typeof(bool), typeof(RealVideoPlayer), new PropertyMetadata(false, onIsStartedChanged));

        private static void onIsStartedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            int result = -1;
            RealVideoPlayer player = d as RealVideoPlayer;
            if (e.NewValue != null && player != null)
            {
                bool isStarted = (bool)e.NewValue;
                if (isStarted)
                {
                    result = player.Login();
                    if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
                    {
                        result = player.Play();
                    }
                }
                else
                    result = player.LogOut();
            }
        }
        #endregion

        #region   方法

        public int Login()
        {
            int result = -1;

            if (!IsValidSource())
            {
                PlayerWnd.ShowError("视频源参数无效！");
                IsConnected = false;
                return result;
            }

            result = PlayerWnd.Login(ItemSource.ServerIp, ItemSource.ServerPort, ItemSource.ServerUserName, ItemSource.ServerPwd, ItemSource.PlatID);
            if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
            {
                IsConnected = true;
                result = PlayerWnd.SetNetEventNotify(onNetConnected, IntPtr.Zero);
            }
            else
            {
                IsConnected = false;
                PlayerWnd.ShowError(PlayerWnd.HandleError(result));
            }

            return result;
        }

        public int LogOut()
        {
            int result = -1;

            if (onNetConnected != null)
                onNetConnected = null;

            IsConnected = false;

            result = PlayerWnd.LogOut();

            if (result != (int)SysParameter.VIDEO_SDK_NOERROR)
                PlayerWnd.ShowError(PlayerWnd.HandleError(result));
            else
            {
                if (IsPlaying)
                    PlayerWnd.Refresh();
            }

            return result;
        }
        public void Dispose()
        {
            PlayerWnd.dispose();
            onNetConnected = null;
        }

        public int Play(int WaitOutTime = 2000)
        {
            int result = -1;

            result = PlayerWnd.Play(ItemSource.ChannelNo, WaitOutTime);
            if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
            {
                IsPlaying = true;
            }
            else
            {
                IsPlaying = false;
                PlayerWnd.ShowError(PlayerWnd.HandleError(result));
            }

            return result;
        }
        public int Stop()
        {
            int result = -1;

            result = PlayerWnd.Stop();
            if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
            {
                IsPlaying = false;
            }
            else
                PlayerWnd.ShowError(PlayerWnd.HandleError(result));

            return result;
        }

        //public int StopAllVideo()
        //{
        //    int result = -1;
        //    IsConnected = false;
        //    result = PlayerWnd.StopAllVideo();
        //    if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
        //    {
        //        IsPlaying = false;
        //    }
        //    else
        //        PlayerWnd.ShowError(PlayerWnd.HandleError(result));

        //    return result;
        //}

        private void OnNetEventNotifyCallBack(int handle, NET_EVENT_TYPE eNetEventType, IntPtr pUserData)
        {
            int result = -1;
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (eNetEventType == NET_EVENT_TYPE.NET_EVENT_TYPE_CLOSE)
                {
                    PlayerWnd.ShowError("断开连接！重连中。。。");
                    IsConnected = false;
                    IsPlaying = false;
                }
                if (eNetEventType == NET_EVENT_TYPE.NET_EVENT_TYPE_RECONNECT)
                {
                    if (ItemSource != null)
                    {
                        result = LogOut();
                        if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
                        {
                            if (ItemSource != null && IsValidSource())
                            {
                                result = PlayerWnd.Login(ItemSource.ServerIp, ItemSource.ServerPort, ItemSource.ServerUserName, ItemSource.ServerPwd, ItemSource.PlatID);
                                if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
                                {
                                    IsConnected = true;
                                    result = Play();
                                    if (result == (int)SysParameter.VIDEO_SDK_NOERROR)
                                    {
                                        IsPlaying = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }));
        }

        private bool IsValidSource()
        {
            if (ItemSource == null)
                return false;
            if (string.IsNullOrEmpty(ItemSource.ServerIp) || !ValidIP.IsIPAddr(ItemSource.ServerIp))
                return false;

            if (ItemSource.ServerPort <= 0 || ItemSource.ServerPort > 65535)
                return false;

            if (string.IsNullOrEmpty(ItemSource.ServerUserName) || string.IsNullOrEmpty(ItemSource.ServerPwd))
                return false;

            return true;
        }
        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Pause_Click(object sender, RoutedEventArgs e)
        {
            //if (IsPlaying)
            //{
            //    IsStarted = false;
            FlowLayer_play.Visibility = Visibility.Visible;
            FlowLayer_pause.Visibility = Visibility.Collapsed;
            //}
        }

        private void Btn_Play_Click(object sender, RoutedEventArgs e)
        {
            //if (IsPlaying)
            //{
            //    IsStarted = false;
            FlowLayer_play.Visibility = Visibility.Collapsed;
            FlowLayer_pause.Visibility = Visibility.Visible;
            //}
        }
    }
}
