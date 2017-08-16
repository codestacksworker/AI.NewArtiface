using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SING.Data.Controls.VideoControl
{
    public delegate void CallBack(object para);

    public partial class AxDZVideoControl : UserControl,IVideoBase
    {
        public event CallBack OnNetStateChanged;
        public CallBack callback;

        private VideoParameter _para=null;
        public VideoParameter Para
        {
            get
            {
                return _para;
            }

            set
            {
                _para = value;
            }
        }

        public AxDZVideoControl()
        {
            InitializeComponent();
            axVideoOCX1.Dock = DockStyle.Fill;
        }

        #region  IVideoManager实现
        public void Initialize(VideoParameter paras,string controlName)
        {
            _para = paras;
            axVideoOCX1.InitPara(controlName);
        }        
        public byte Login()
        {
            return axVideoOCX1.Login(_para.IP, _para.Port, _para.UserName, _para.Password);
        }       
        public byte Play(int PlatFormID,int DeviceID,int ChannelID,int ChannelType,int StreamType)
        {
            return axVideoOCX1.PlayRealVideo(_para.PlatFormID, _para.DeviceID, _para.ChannelID, _para.ChannelType, _para.StreamType);
        }
        public byte Stop()
        {
            return axVideoOCX1.CloseRealVideo();
        }
        void NetStateChanged(object para)
        {
            OnNetStateChanged?.Invoke(para);
        }

        public byte LogOut()
        {
            return axVideoOCX1.LogOut();
        }

        public byte Delete()
        {
            return axVideoOCX1.Delete();
        }

        public void DisPose()
        {
            axVideoOCX1.Dispose();
            axVideoOCX1.Delete();           
            axVideoOCX1 = null;
            Dispose(true);         
        }
        #endregion
    }
}
