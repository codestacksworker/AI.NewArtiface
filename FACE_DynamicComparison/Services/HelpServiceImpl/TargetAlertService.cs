using SING.Data.DAL.Data;
using SING.Data.Help;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_DynamicComparison.Services.HelpServiceImpl
{
    [Export(typeof(HelpService.ITargetAlertService))]
    public class TargetAlertService : SearchServiceBase,HelpService.ITargetAlertService
    {
        public override void Search()
        {
           
            string imgstr1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"img\1asdasd.jpeg");
            string imgstr2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"img\dasdsa.jpg.jpeg");
            byte[] buffer1 = ImageConvert.PathToBinaryStream(imgstr1);
            byte[] buffer2 = ImageConvert.PathToBinaryStream(imgstr2);
            Random ran = new Random();

            string resourceStr = @"/FACE_CapCmpManagement;component/Images/BlueCamera.png";

            for (int i = 0; i < 10; i++)
            {
                AlertData alert = new AlertData
                {
                    FcapImg = buffer1,
                    FtImg = buffer2,
                    FobjName = "测试" + i.ToString(),
                    ChannelName = "通道" + i.ToString(),
                    FcmpSocre = Math.Round((double)ran.Next(1, 100) / 100, 3),
                    MatchedCount = i
                };
                VM.CapCmpList.Add(alert);
            }
        }
    }
}
