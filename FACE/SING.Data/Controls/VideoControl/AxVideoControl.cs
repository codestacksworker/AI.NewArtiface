using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxVideoOCXLib;

namespace SING.Data.Controls.VideoControl
{
    public partial class AxVideoControl : UserControl
    {
        public AxVideoOCX axVideoOCX;

        public AxVideoControl()
        {
            InitializeComponent();

            axVideoOCX = new AxVideoOCX();

            axVideoOCX.BeginInit();

            axVideoOCX.Dock = DockStyle.Fill;

            this.Controls.Add(axVideoOCX);

            axVideoOCX.EndInit();
        }

        public void InitPara()
        {
            axVideoOCX.InitPara("");
        }

        public void InitPara(string stOcxPara)
        {
            axVideoOCX.InitPara(stOcxPara);
        }
        public byte Login(string sIP, int nPort, string sUserName, string sPassword)
        {
            return axVideoOCX.Login(sIP, nPort, sUserName, sPassword);
        }
        public byte Play(int nPlatFormID, int nDeviceID, int nChannelID, int nChannelType, int nStreamType)
        {
            return axVideoOCX.PlayRealVideo( nPlatFormID,  nDeviceID,  nChannelID,  nChannelType,  nStreamType);
        }
        public byte Close()
        {
            return axVideoOCX.CloseRealVideo();
        }

        public byte LogOut()
        {
            return axVideoOCX.LogOut();
        }
    }
}
