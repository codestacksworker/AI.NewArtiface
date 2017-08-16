using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using FACE_AlertRecord.Models;
using FACE_AlertRecord.ViewModels;
using SING.Data.DAL.Data;
using SING.Data.DAL.NewCode;
using SING.Data.DAL.NewCode.Data;
using SING.Data.Help;
using SING.Data.DAL.NewCode.Condition;

namespace FACE_AlertRecord.Services.HelpService
{
    public class AlarmPromptService
    {
        //private ViewModel viewModel;
        public void AlarmPromptData(ViewModel viewModel)
        {
            //string imgstr1 = @"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\YangYang1.jpg";//@"/FACE_DynamicComparison;component/Images/back.png";//"pack://application:,,,/Images/1asdasd.jpeg.jpeg";//相对路径
            //string imgstr2 = @"E:\RLSB-CS\RLSB\trunk\Client\UI\FaceSystem\FACE_AlertRecord\Images\YangYang2.jpg";//@"/FACE_DynamicComparison;component/Images/dasdsa.jpg.jpeg";//"pack://application:,,,/Images/dasdsa.jpg.jpeg";
            string imgstr1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"img\YangYang1.jpg");
            string imgstr2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"img\YangYang2.jpg");
            byte[] buffer1 = ImageConvert.PathToBinaryStream(imgstr1);//ImageConvert.PathToBinaryStream(new Uri(imgstr1, UriKind.Relative).AbsolutePath);
            byte[] buffer2 = ImageConvert.PathToBinaryStream(imgstr2);//ImageConvert.PathToBinaryStream(new Uri(imgstr2, UriKind.Relative).AbsolutePath);
            Random ran = new Random();

            for (int i = 0; i < 8; i++)
            {
                AlarmPromptData alarm = new AlarmPromptData
                {
                    FcapId = i,
                    FcapImg = buffer1,
                    TargetImg = buffer2,
                    TarLibrary = "研发部" + i.ToString(),
                    TarName = "姓名" + i.ToString(),
                    TarSex = "男",
                    SerialNum = i.ToString(),
                    Lables = "白名单    不吸毒    无偷盗    无抢劫    无犯罪前科    没有犯罪    有指纹    无法使用",
                    Region = "北京市 - 海淀区 - 大钟寺" + i.ToString(),
                    Channel = "通道" + i.ToString(),
                    Position = "科技大厦" + i.ToString(),
                    TimesNum = i,
                    FcmpSocre = Math.Round((double)ran.Next(1, 100), 3).ToString() + "%" ,
                    MonTasksNum = i,
                    AlertTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm"),
                    Status = "未复核",
                    StatusDate = "2017-05-18 16:26",
                    StatusUser = "usera",
                    StatusColors = new SolidColorBrush(Color.FromArgb(255, 111, 203, 217))
                };
                viewModel.AlarmPromptList.Add(alarm);
            }
        }

        #region  接口测试

        public List<AlertInfoData> GetAlertList(ViewModel viewModel)
        {
            Pager<AlertInfoCondition> pager = new Pager<AlertInfoCondition>();
            pager.PageNo = 1;
            pager.PageRows = 20;
            //pager.Condition = new Hashtable();
            //pager.Condition.Add("name", "");
            //pager.Condition.Add("DBID", "");
            //pager.Condition.Add("channelIDs", "");
            //pager.Condition.Add("idType", "");
            //pager.Condition.Add("idNumber", "");
            //pager.Condition.Add("startTime", "");
            //pager.Condition.Add("endTime", "");
            //int[] nameIds = viewModel.MonTaskTxt.Split(',');
            //string [] dbIds = viewModel.TarLibTxt.Split(',');
            pager.Condition = new AlertInfoCondition {
                /*NameIds = new int[] { },
                DbIds = new string[] { },
                ChannelIds = new string[] { },*/
                IdType = 1,
                IdNumber = viewModel.IDNumTxt,
                StartTime = viewModel.StartDateTxt + viewModel.StartTimeTxt,
                EndTime = viewModel.EndDateTxt + viewModel.EndTimeTxt
            };
             

            AlertInfo alert = new AlertInfo();
            var p = alert.Query(pager);
            List<AlertInfoData> result = new List<AlertInfoData>();
            p.ResultList.ForEach(a => { result.Add(a.ToUIData<AlertInfoData>()); });
            return result;
        }

        public List<AlertInfoData> QueryTargetPersonList()
        {
            AlertInfo table = new AlertInfo();
            table.AlertUuid = "10";

            var list = table.QueryTargetPersonList();
            List<AlertInfoData> result = new List<AlertInfoData>();
            list.ForEach(a => { result.Add(a.ToUIData<AlertInfoData>()); });
            return result;
        }

        public AlertInfoData QueryTargetPersonByID()
        {
            AlertInfo table = new AlertInfo();
            table.FcmpFobjId = "10";
            table.FcapUuid = "10";
            table.AlertUuid = "10";

            var result = table.QueryTargetPersonByID();
            return result.ToUIData<AlertInfoData>();
        }

        public AlertInfoData Previous()
        {
            AlertInfo table = new AlertInfo();
            table.FcmpFobjId = "10";
            table.FcapUuid = "10";
            table.AlertUuid = "10";

            var result = table.Previous();
            return result.ToUIData<AlertInfoData>();
        }

        public AlertInfoData Next()
        {
            AlertInfo table = new AlertInfo();
            table.UserId = "admin";

            var result = table.Next();
            return result.ToUIData<AlertInfoData>();
        }

        public bool Confirm()
        {
            OriginalAlerts table = new OriginalAlerts();
            table.Acker = "admin";
            table.Uuid = "10";
            table.FcmpFobjId = "10";

            var result = table.Confirm();
            return result;
        }

        public bool Eliminate()
        {
            OriginalAlerts table = new OriginalAlerts();
            table.Acker = "admin";
            table.Uuid = "10";
            var result = table.Eliminate();
            return result;
        }

        public bool Publish()
        {
            OriginalAlerts table = new OriginalAlerts();
            table.Acker = "admin";
            table.Uuid = "10";

            var result = table.Publish();
            return result;
        }
        #endregion
    }
}
