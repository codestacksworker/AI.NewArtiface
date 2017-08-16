using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_AlertRecord.Models;
using FACE_AlertRecord.ViewModels;
using SING.Data.Help;

namespace FACE_AlertRecord.Services.HelpService
{
    public class AlarmInfoService
    {
        public void FaceCapData(ViewModel viewModel)
        {
            //string imgstr1 = @"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\aa.jpeg";//@"/FACE_DynamicComparison;component/Images/back.png";//"pack://application:,,,/Images/1asdasd.jpeg.jpeg";//相对路径
            //string imgstr2 = @"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\bb.jpeg";//@"/FACE_DynamicComparison;component/Images/dasdsa.jpg.jpeg";//"pack://application:,,,/Images/dasdsa.jpg.jpeg";
            string imgstr1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"img\aa.jpeg");
            string imgstr2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"img\bb.jpeg");
            byte[] buffer1 = ImageConvert.PathToBinaryStream(imgstr1);//ImageConvert.PathToBinaryStream(new Uri(imgstr1, UriKind.Relative).AbsolutePath);
            byte[] buffer2 = ImageConvert.PathToBinaryStream(imgstr2);//ImageConvert.PathToBinaryStream(new Uri(imgstr2, UriKind.Relative).AbsolutePath);
            Random ran = new Random();

            for (int i = 0; i < 9; i++)
            {
                AlarmPromptData alarm = new AlarmPromptData
                {
                    FcapId = i,
                    FcapImg = buffer1,
                    TargetImg = buffer2,
                    FcmpSocre = Math.Round((double)ran.Next(1,100), 3).ToString() + "%"
                };
                viewModel.FaceCapList.Add(alarm);
            }
        }
    }
}
