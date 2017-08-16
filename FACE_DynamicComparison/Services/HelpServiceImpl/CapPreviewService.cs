using FACE_DynamicComparison.Models;
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
    [Export(typeof(HelpService.ICapPreviewService))]
    public class CapPreviewService:SearchServiceBase,HelpService.ICapPreviewService
    {
        public override void Search()
        {
           
            string imgstr1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"img\1asdasd.jpeg");
            string imgstr2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"img\dasdsa.jpg.jpeg");
            byte[] buffer1 = ImageConvert.PathToBinaryStream(imgstr1);
            byte[] buffer2 = ImageConvert.PathToBinaryStream(imgstr2);
            Random ran = new Random();

            for (int i = 0; i < 8; i++)
            {
                AlarmPromptData alarm = new AlarmPromptData
                {
                    FcapId = i,
                    FcapImg = buffer1,
                    TargetImg = buffer2,
                    FcmpSocre = Math.Round((double)ran.Next(1, 100), 3).ToString() + "%"
                };
                VM.CapList.Add(alarm);
            }
        }
     

        private byte[] FileContent(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            try
            {
                byte[] buffur = new byte[fs.Length];
                fs.Read(buffur, 0, (int)fs.Length);

                return buffur;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (fs != null)
                {

                    //关闭资源  
                    fs.Close();
                }
            }
        }
    }
}
