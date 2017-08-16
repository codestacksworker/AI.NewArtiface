using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.DAL;
using SING.Data.Help;

namespace SING.Data.ScheduleProcess
{
    public class ScheduleGet
    {
        public static bool Login(string userName, string passWord)
        {
            return true;
        }

        public static List<FaceObject> QueryFaceObj(QueryCondition qc)
        {
            List<FaceObject> list = null;
            try
            {
                if (qc == null) return list;

                string json = QueryCondition.FobjJsonConvert(qc);

                list = FaceObject.QueryFaceObj(json);
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询人脸对象信息异常！【ScheduleGet】-->【函数名】：QueryAlerts", ex);
            }

            return list;
        }

        public static List<FaceCapture> QueryFaceCap(QueryConditionCapRecord qc)
        {
            List<FaceCapture> list = null;
            try
            {
                if (qc == null) return list;

                string json = QueryConditionCapRecord.JsonConvert(qc);

                list = FaceCapture.QueryFaceCap(json);
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询抓拍记录信息异常！【ScheduleGet】-->【函数名】：QueryFaceCap", ex);
            }

            return list;
        }

        public static List<FaceCapture> QueryCapLog(QueryConditionCapRecord qc)
        {
            List<FaceCapture> list = null;
            try
            {
                if (qc == null) return list;

                string json = QueryConditionCapRecord.JsonConvert(qc);

                list = FaceCapture.QueryCapLog(json);
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询抓拍记录信息异常！【ScheduleGet】-->【函数名】：QueryCapLog", ex);
            }

            return list;
        }

        public static List<FcmpCaptureAlarm> QueryCmpLog(QueryConditionCmpRecord qc)
        {
            List<FcmpCaptureAlarm> list = null;
            try
            {
                if (qc == null) return list;

                string json = QueryConditionCmpRecord.JsonConvert(qc);

                list = FcmpCaptureAlarm.QueryCmpLog(json);
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询比对记录信息异常！【ScheduleGet】-->【函数名】：QueryCmpLog", ex);
            }

            return list;
        }

        public static List<FcmpCaptureAlarm> QueryCmpLogWithImg(QueryConditionCmpRecord qc)
        {
            List<FcmpCaptureAlarm> list = null;
            try
            {
                if (qc == null) return list;

                string json = QueryConditionCmpRecord.JsonConvert(qc);

                Console.WriteLine($"第{qc.PageNow}页Json:{json}");

                list = FcmpCaptureAlarm.QueryCmpLogWithImg(json);
                Console.WriteLine($"第{qc.PageNow}页行数:{list.Count}");

            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询比对记录信息异常！【ScheduleGet】-->【函数名】：QueryCmpLogWithImg", ex);
            }

            return list;
        }

        public static List<Alert> QueryAlerts(QueryConditionAlertRecord qc)
        {
            List<Alert> list = null;
            try
            {
                if (qc == null) return list;

                string json = QueryConditionAlertRecord.JsonConvert(qc);

                list = Alert.QueryAlerts(json);
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询告警记录异常！【ScheduleGet】-->【函数名】：QueryAlerts", ex);
            }

            return list;
        }

        public static List<Alarm> QueryAlarms(QueryConditionAlertRecord qc)
        {
            List<Alarm> list = null;
            try
            {
                if (qc == null) return list;

                string json = QueryConditionAlertRecord.JsonConvert(qc);

                list = Alarm.QueryAlarms(json);
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询告警记录异常！【ScheduleGet】-->【函数名】：QueryAlarms", ex);
            }

            return list;
        }
    }
}
