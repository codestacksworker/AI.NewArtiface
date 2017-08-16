using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_ChannelManagement.Models;
using FACE_ChannelManagement.ViewModels;
using SING.Data.DAL.Data;
using SING.Data.Logger;
using FACE_ChannelManagement.Enum;
using SING.Data.Controls.VideoControl;
using System.Windows.Forms.Integration;
using Dev_SING.Data.BaseTools;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Resources;
using System.Windows;
using SING.Data.BaseTools;

namespace FACE_ChannelManagement.Services.HelpService
{
    public class VideoViewService
    {
        private ViewModel _viewmodel;
        private BackgroundWorker _work;

        public void DoWork(ViewModel viewmodel)
        {
            try
            {
                this._viewmodel = viewmodel;
                this._work = new BackgroundWorker();
                _work.WorkerReportsProgress = true;
                _work.WorkerSupportsCancellation = true;
                _work.DoWork += Do;
                _work.RunWorkerCompleted += RunWorkerCompleted;
                _work.ProgressChanged += ProgressChanged;
                _work.RunWorkerAsync();
            }
            catch (Exception err)
            {
                Logger.Error("ChannelService:通道启动查询异常", err);
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Do(object sender, DoWorkEventArgs e)
        {
            Search();
        }

        void Search()
        {

        }

        #region  视频操作
        public void InitializeContainer(ViewModel viewModel)
        {
            viewModel.WfhList = new List<WindowsFormsHost>();
            WindowsFormsHost wfh = new WindowsFormsHost();
            wfh.Tag = null;
            viewModel.WfhList.Add(wfh);
        }
        public void ChangeVideoSource(ViewModel viewModel)
        {
            if (viewModel.Video == null) return;
            try
            {
                string IP = viewModel.Video.Channel.ChannelAddr;
                if (IP == string.Empty)
                {
                   MessageBoxHelper.Show(AboutCameraPlayer.CameraIpIsNull);
                    return;
                }
                
                if (OpenStream(viewModel))
                    SetSingleScreen(viewModel);
            }
            catch (Exception ex)
            {
               MessageBoxHelper.Show(AboutCameraPlayer.CameraOffLink);
                Logger.Error("通道摄像机连接异常，方法名：ChangeVideoSource", ex);
            }
        }

        private void InitializeComponent(ViewModel viewModel)
        {
            VideoParameter paras = new VideoParameter();
            paras.SetParas(viewModel.Video.Channel);

            if (!viewModel.IsLocal)
            {
                viewModel.playerCtrl = new AxDZVideoControl();
                (viewModel.playerCtrl as AxDZVideoControl).Dock = System.Windows.Forms.DockStyle.Fill;
                viewModel.playerCtrl.Initialize(paras,"");
                viewModel.playerCtrl.Login();
            }

            if (paras.PlatFormID <= 0 || paras.DeviceID <= 0 || paras.ChannelID <= 0 || paras.ChannelType <= 0 || paras.StreamType <= 0)
            {
                MessageBoxHelper.Show("通道号为空！");
                return;
            }

            viewModel.playerCtrl.Play(paras.PlatFormID, paras.DeviceID, paras.ChannelID, paras.ChannelType, paras.StreamType);
        }

        bool OpenStream(ViewModel viewModel)
        {
            bool result = false;

            VideoParameter paras = new VideoParameter();
            paras.SetParas(viewModel.Video.Channel);

            if (paras.PlatFormID <= 0 || paras.DeviceID <= 0 || paras.ChannelID <= 0 || paras.ChannelType <= 0 || paras.StreamType <= 0)
            {
               MessageBoxHelper.Show("通道号为空！");
                return false;
            }

            if (!viewModel.IsLocal)
            {
                viewModel.AxVideoControl = new AxVideoControl();

                viewModel.AxVideoControl.InitPara();

                viewModel.AxVideoControl.Login(paras.IP, paras.Port, paras.UserName, paras.Password);

            }

            //viewModel.AxVideoControl.Close();

            viewModel.AxVideoControl.Play(paras.PlatFormID, paras.DeviceID, paras.ChannelID, paras.ChannelType, paras.StreamType);

            //if (!viewModel.IsLocal)
            //{
            //    viewModel.AxVideoOCX  = new AxVideoOCXLib.AxVideoOCX();

            //    viewModel.AxVideoOCX.BeginInit();

            //    WindowsFormsHost host = new WindowsFormsHost();

            //    host.Child = viewModel.AxVideoOCX;

            //    viewModel.VideoPlayerGrid.Children.Add(host);

            //    viewModel.AxVideoOCX.EndInit();

            //    viewModel.AxVideoOCX.InitPara("");

            //    viewModel.AxVideoOCX.Login(paras.IP, paras.Port, paras.UserName, paras.Password);

            //}

            //viewModel.AxVideoOCX.CloseRealVideo();

            //viewModel.AxVideoOCX.PlayRealVideo(paras.PlatFormID, paras.DeviceID, paras.ChannelID, paras.ChannelType, paras.StreamType);
            ////InitializeComponent(viewModel);
            if (viewModel.AxVideoControl != null)
            {
                if (viewModel.WfhList != null && viewModel.WfhList.Count >= 1)
                {
                    WindowsFormsHost wfh = viewModel.WfhList[0];
                    wfh.Child = viewModel.AxVideoControl;
                    wfh.Tag = viewModel.Video.Channel.Uuid;

                    viewModel.Video.Channel.IsOpened = true;
                    result = true;
                }
            }
            return result;
        }

        public bool CloseStream(ViewModel viewModel)
        {
            bool result = false;
            if (viewModel.Video.Channel.IsOpened == true)
            {
                if (viewModel.WfhList is List<WindowsFormsHost> && viewModel.WfhList != null && viewModel.WfhList.Count >= 0)
                {
                    WindowsFormsHost wfh = viewModel.WfhList[0];
                    if (wfh.Tag != null && wfh.Tag.ToString() == viewModel.Video.Channel.Uuid && wfh.Child != null)
                    {
                        (wfh.Child as AxVideoControl).Close();
                        if (!viewModel.IsLocal)
                        {
                            (wfh.Child as AxVideoControl).LogOut();
                            (wfh.Child as AxVideoControl).Dispose();
                            wfh.Child = null;
                            wfh.Tag = null;
                        }
                        viewModel.Video.Channel.IsOpened = false;
                        result = true;
                    }
                }
            }
            return result;
        }

        public void SetSingleScreen(ViewModel viewModel)
        {
            if (viewModel.VideoPlayerGrid == null) viewModel.VideoPlayerGrid = new Grid();
            try
            {
                for (int i = 0; i < viewModel.VideoPlayerGrid.Children.Count; i++)
                {
                    ((Grid)viewModel.VideoPlayerGrid.Children[i]).Children.Clear();
                }

                viewModel.VideoPlayerGrid.Children.Clear();
                viewModel.VideoPlayerGrid.RowDefinitions.Clear();
                viewModel.VideoPlayerGrid.ColumnDefinitions.Clear();

                viewModel.VideoPlayerGrid.RowDefinitions.Add(new RowDefinition());
                viewModel.VideoPlayerGrid.ColumnDefinitions.Add(new ColumnDefinition());

                Grid screenGrid = new Grid();
                ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
                StreamResourceInfo streamResourceInfo;
                string resourceStr = string.Empty;
                resourceStr = @"pack://application:,,,/FACE_ChannelManagement;component/Images/noVideoBackground.png";
                streamResourceInfo = Application.GetResourceStream(new Uri(resourceStr, UriKind.Absolute));
                screenGrid.Background = new ImageBrush((ImageSource)imageSourceConverter.ConvertFrom(streamResourceInfo.Stream));

                screenGrid.Children.Add(viewModel.WfhList[0]);
                viewModel.VideoPlayerGrid.Children.Add(screenGrid);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Show(ex.Message);
            }
        }
        #endregion
    }
}
