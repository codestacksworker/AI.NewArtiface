using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoSdkHelper.Enum;
using VideoSDKTest.Controls;

namespace SING.Infrastructure.Video.VideoSdkHelper
{
    public partial class ViedeoPlayerWin : UserControl
    {
        public ViedeoPlayerWin()
        {
            InitializeComponent();
            RecordManager = new RecordManager(this.Handle);
            Login("192.168.1.216", 10002, "admin", "123@456", 2);
            PlayBack("52_#_51000004_1_101", DateTime.Parse("2017-06-15 16:42:53"), DateTime.Parse("2017-06-15 16:43:20"), DateTime.Parse("2017-06-15 16:42:53"), EnumStorageType.SYS_STORAGE_CSS_SER, EnumRecordType.SYS_RECORD_PLAN, 52);
        }

        public int Login(string sIp, int nPort, string sName, string sPassword, int nLoginID = 0)
        {
            return RecordManager.Login(sIp, nPort, sName, sPassword, nLoginID);
        }

        public int LogOut()
        {
            return RecordManager.LogOut();
        }

        public int PlayBack(string szNodeID, DateTime szStartTime, DateTime szEndTime, DateTime szCurrentPlayTime, EnumStorageType eStorage, EnumRecordType eRecordType, int nPlatID)
        {
            return RecordManager.PlayBack(szNodeID, szStartTime, szEndTime, szCurrentPlayTime, eStorage, eRecordType, nPlatID);
        }

        public int Play(EnumRecordPlayCtrl operation)
        {
            return RecordManager.Play(operation);
        }

        public int SetVideoProgress(int progress)
        {
            return RecordManager.SetVideoProgress(progress);
        }

        public RecordManager RecordManager { get; set; }

        //protected override void OnMouseUp(MouseEventArgs e)
        //{
        //    base.OnMouseUp(e);
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        contextMenuStrip1.Show(this, e.Location);
        //    }
        //}

        //private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{
        //    switch (e.ClickedItem.Text)
        //    {
        //        case "开始回放":
        //            PlayBack("52_#_51000004_1_101", DateTime.Now.AddSeconds(-8), DateTime.Now.AddSeconds(7),
        //                DateTime.Now, EnumStorageType.SYS_STORAGE_CSS_SER, EnumRecordType.SYS_RECORD_PLAN, 52);
        //            break;
        //        case "播放":
        //            RecordManager.Play(EnumRecordPlayCtrl.RECORD_CTRL_PLAY);
        //            break;
        //        case "暂停":
        //            RecordManager.Play(EnumRecordPlayCtrl.RECORD_CTRL_PAUSE);
        //            break;
        //        case "快进":
        //            RecordManager.Play(EnumRecordPlayCtrl.RECORD_CTRL_FAST);
        //            break;
        //        case "慢进":
        //            RecordManager.Play(EnumRecordPlayCtrl.RECORD_CTRL_SLOW);
        //            break;
        //        case "停止":
        //            RecordManager.Play(EnumRecordPlayCtrl.RECORD_CTRL_STOP);
        //            break;
        //    }
        //}

        ~ViedeoPlayerWin()
        {
            LogOut();
        }
    }
}
