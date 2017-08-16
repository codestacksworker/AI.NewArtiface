using Dev_SING.Data.BaseTools;
using SING.Infrastructure.Video.VideoSdkHelper.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
using VideoSdkHelper.Enum;
using VideoSDKTest.Controls;

namespace SING.Infrastructure.Video
{
    /// <summary>
    /// VideoPlayer.xaml 的交互逻辑
    /// </summary>
    public partial class VideoPlayer : UserControl, IDisposable
    {
        public RecordManager RecordManager { get; set; }
        public VideoPlayer()
        {
            InitializeComponent();
            //Login();
        }

        #region  控制
        public int Login()
        {
            //return RecordManager.Login(ItemSource.ServerIp, ItemSource.ServerPort, ItemSource.ServerUserName, ItemSource.ServerPwd, ItemSource.PlatID);
            //return RecordManager.Login("192.168.1.216", 10002, "admin", "123@456", 2);
            return WinPlayer.Login("192.168.1.216", 10002, "admin", "123@456", 2);
        }

        public int LogOut()
        {
            //return RecordManager.LogOut();
            return WinPlayer.LogOut();
        }

        public int PlayBack()
        {
            //return RecordManager.PlayBack(ItemSource.ChannelNo, ItemSource.TimeQuantum.Begin,
            //    ItemSource.TimeQuantum.End, ItemSource.TimeQuantum.Current, EnumStorageType.SYS_STORAGE_CSS_SER,
            //    EnumRecordType.SYS_RECORD_PLAN, ItemSource.PlatID);

            //return RecordManager.PlayBack("52_#_51000004_1_101",DateTime.Parse("2017-06-15 16:42:53"), DateTime.Parse("2017-06-15 16:43:20"), DateTime.Parse("2017-06-15 16:42:53"), EnumStorageType.SYS_STORAGE_CSS_SER, EnumRecordType.SYS_RECORD_PLAN, 52);
            return WinPlayer.PlayBack("52_#_51000004_1_101", DateTime.Parse("2017-06-15 16:42:53"), DateTime.Parse("2017-06-15 16:43:20"), DateTime.Parse("2017-06-15 16:42:53"), EnumStorageType.SYS_STORAGE_CSS_SER, EnumRecordType.SYS_RECORD_PLAN, 52);
        }

        public int Play(EnumRecordPlayCtrl operation)
        {
            //return RecordManager.Play(operation);
            return WinPlayer.Play(operation);
        }

        public int SetVideoProgress(int progress)
        {
            //return RecordManager.SetVideoProgress(progress);
            return WinPlayer.SetVideoProgress(progress);
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
        #endregion

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            PlayBack();
        }

        public void Dispose()
        {
            LogOut();
        }

        ~VideoPlayer()
        {
           // Dispose();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Play(EnumRecordPlayCtrl.RECORD_CTRL_PLAY);
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            Play(EnumRecordPlayCtrl.RECORD_CTRL_PAUSE);
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            Play(EnumRecordPlayCtrl.RECORD_CTRL_STOP);
        }

        private void sliderPosition_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (e.NewValue > 1)
                SetVideoProgress((int)e.NewValue);
        }
    }
}
