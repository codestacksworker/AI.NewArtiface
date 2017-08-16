using SING.Data.DAL.NewCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceCapture = SING.Data.DAL.FaceCapture;


namespace FACE_DynamicComparison.Services.HelpService
{
   public interface IAlertService:ISearchServiceBase
    {
        void ModAlertAck(int ackStat);
        void ModAlertPub();
        FaceCapture QueryCapImg();
        List<AlertInfoData> GetAlertDetail();
        List<AlertInfoData> QueryNewestAlerts();
        AlertInfoData ReCheckAlert();

    }
}
