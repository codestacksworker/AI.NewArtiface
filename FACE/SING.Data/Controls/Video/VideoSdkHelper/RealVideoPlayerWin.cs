using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SING.Data.Controls.Video.VideoSdkHelper.Enum;
using static SING.Data.Controls.Video.VideoSdkHelper.VideoClient;
using SING.Data.Controls.Video.VideoSdkHelper.Models;

namespace SING.Data.Controls.Video.VideoSdkHelper
{
    public delegate void ReconnectOnLoss(int handle, NET_EVENT_TYPE eNetEventType, IntPtr pUserData);
    public partial class RealVideoPlayerWin : UserControl
    {
        public RealVideoPlayerWin()
        {
            InitializeComponent();
            data = new VideoItem();
            data.Duration = new TimeQuantum();
            realVideoManager = new RealVideoManager(this.Handle);
        }

        #region  属性
        public RealVideoManager realVideoManager { get; set; }
        private VideoItem data;
        public VideoItem Data
        {
            get { return data; }
            set { data = value; }
        }
        #endregion

        //// 防止闪屏
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}

        #region  方法
        public int Init()
        {
            return realVideoManager.Init();
        }

        public int Login(string sIp, int nPort, string sName, string sPassword, int nLoginID = 0)
        {
            data.ServerIp = sIp;
            data.ServerPort = nPort;
            data.ServerUserName = sName;
            data.ServerPwd = sPassword;
            return realVideoManager.Login(sIp, nPort, sName, sPassword, nLoginID);
        }

        public int LogOut()
        {
            return realVideoManager.LogOut();
        }
        public void dispose()
        {
            //realVideoManager.Dispose();
        }
        public int Play(string szNodeID, int WaitOutTime = 2000)
        {
            return realVideoManager.Play(szNodeID, WaitOutTime);
        }
        public int Stop()
        {
            return realVideoManager.Stop();
        }

        public int StopAllVideo()
        {
            return realVideoManager.StopAllVideo();
        }

        public int SetNetEventNotify(NetEventNotifyCallBack pNetEventNotifyCbFun, IntPtr pUserData)
        {
            return realVideoManager.SetNetEventNotify(pNetEventNotifyCbFun, pUserData);
        }

        public void ShowError(string msg)
        {
            this.Refresh();
            Graphics g = this.CreateGraphics();
            using (Brush brush=new SolidBrush(SystemColors.Control))
            using (Pen pen = new Pen(Color.Red))
            {
                g.DrawString(msg, this.Font,brush,new Point(0,0));
            }
        }

        public string HandleError(int error)
        {
            return realVideoManager.Catch(error);
        }
        #endregion
    }
}
