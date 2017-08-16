using Dev_SING.Data.BaseTools;
using SING.Data.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Controls.VideoControl
{
    public class VideoParameter
    {
        //public string controlName { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PlatFormID { get; set; }
        public int DeviceID { get; set; }
        public int ChannelID { get; set; }
        public int ChannelType { get; set; }
        public int StreamType { get; set; }

        public void SetParas(ChannelData Channel)
        {
            if (Channel != null)
            {
                IP = Channel.ChannelAddr;
                Port = Channel.ChannelPort;
                UserName = Channel.ChannelUid;
                Password = Channel.ChannelPsw;
                var NoInfo = AssistTools.AnalyChannelNo(Channel.ChannelNo);
                if (NoInfo != null && NoInfo.Length >= 5)
                {
                    PlatFormID = int.Parse(NoInfo[0]);
                    DeviceID = int.Parse(NoInfo[1]);
                    ChannelID = int.Parse(NoInfo[2]);
                    ChannelType = int.Parse(NoInfo[3]);
                    StreamType = int.Parse(NoInfo[4]);
                }
            }
        }
    }
}
