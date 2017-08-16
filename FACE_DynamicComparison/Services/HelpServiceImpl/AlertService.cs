using Dev_SING.Data.BaseTools;
using SING.Data.BaseTools;
using SING.Data.DAL;
using SING.Data.DAL.Data;
using SING.Data.DAL.NewCode;
using SING.Data.DAL.NewCode.Condition;
using SING.Data.DAL.NewCode.Data;
using SING.Data.Help;
using SING.Data.Logger;
using SING.Data.ScheduleProcess;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FaceCapture = SING.Data.DAL.FaceCapture;


namespace FACE_DynamicComparison.Services.HelpServiceImpl
{
    [Export(typeof(HelpService.IAlertService))]
    public  class AlertService:SearchServiceBase,HelpService.IAlertService
    {
        public void ModAlertAck(int ackStat)
        {
            if (!string.IsNullOrEmpty(VM.CurrentItem.Uuid))
            {
                bool isSuccess = false;
                try
                {
                    var acker = AppConfig.Instance.LoginName;
                    var time = DateTime.Now.DToString();

                    Result result = Alert.ModAlertAck(VM.CurrentItem.Uuid, acker, ackStat, time.SToLong(), true);
                    if (StatusCode.Success == result.ErrorCode)
                    {
                        VM.CurrentItem.Acker = acker;
                        VM.CurrentItem.AckTime = time;
                        VM.CurrentItem.AckStat = ackStat;
                        isSuccess = true;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("【Error】：修改告警记录异常！【AlertInfoService】-->【函数名】：ModAlertAck", ex);
                }

                //提示用户
                var actionName = ackStat == 2 ? "确认" : "否决";
                if (isSuccess)
                {
                    MessageBoxHelper.Show(actionName + "成功！", "提示", MessageBoxImage.Information);
                }
                else
                {
                    MessageBoxHelper.Show(actionName + "失败！", "提示", MessageBoxImage.Warning);
                }

            }
        }

        public void ModAlertPub()
        {
            Result result = null;

            if (VM.CurrentItem.AckStat == 1 || VM.CurrentItem.AckStat == 3)
            {
                MessageBoxHelper.Show("推送失败，【仅能推送已确认的告警】", "提示", MessageBoxImage.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(VM.CurrentItem.Uuid))
            {
                VM.CurrentItem.PubStat = 2;
                VM.CurrentItem.Puber = AppConfig.Instance.LoginName;
                VM.CurrentItem.PubTime = DateTime.Now.DToString();
                long time = VM.CurrentItem.PubTime.SToLong();
                try
                {
                    result = Alert.ModAlertPub(VM.CurrentItem.Uuid, VM.CurrentItem.Puber,
                    VM.CurrentItem.PubStat, time, true);

                    if (result != null && result.ErrorCode == StatusCode.Success)
                    {
                        result = AddAlarmInfo();
                        if (result != null && result.ErrorCode == StatusCode.Success)
                        {
                            Task.Factory.StartNew(() =>
                            {
                                TaskAsyncHelper.RunAsync(Send, CallBack);
                            });
                        }
                        else
                        {
                            Logger.Info("【Info】：添加报警信息失败！【AlertInfoService】-->【函数名】：ModAlertPub");
                        }
                    }
                    else
                    {
                        Logger.Info("【Info】：修改推送状态失败！【AlertInfoService】-->【函数名】：ModAlertPub");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("【Error】：修改告警记录异常！【AlertInfoService】-->【函数名】：ModAlertPub", ex);
                }
            }
        }

        private void Send()
        {
            Alert alert = AlertData.Convert(VM.CurrentItem);
            ScheduleMQProcess.Process.GetOrAdd("alarm", AppConfig.Instance.LoginName).Publish(alert);
        }

        private void CallBack()
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                VM.CapCmpList.Remove(VM.CurrentItem);
                VM.CurrentItem = null;

                //viewmodel.CommandAlertPopup.Execute("CloseAction");
            }));
        }

        private Result AddAlarmInfo()
        {
            Result result = null;
            try
            {
                var alarm = new Alarm
                {
                    Uuid = VM.CurrentItem.Uuid,
                    PubStat = 1,
                    AckStat = 1,
                    FcapTime = VM.CurrentItem.FcapTime.SToLong()
                };

                result = Alarm.AddAlarms(new List<Alarm>() { alarm });
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Fail;
                result.Message = ex.ToString();
                Logger.Error("【Error】：修改告警记录异常！【AlertInfoService】-->【函数名】：ModAlertAck", ex);
            }
            return result;
        }

        public FaceCapture QueryCapImg()
        {
            try
            {
                if (!string.IsNullOrEmpty(VM.CurrentItem.FcapId) && !string.IsNullOrEmpty(VM.CurrentItem.FcapTime))
                {
                    return FaceCapture.QueryCapImg(VM.CurrentItem.FcapId, VM.CurrentItem.FcapTime.SToLong());

                }
            }
            catch (Exception ex)
            {
                Logger.Error("【Error】：查询抓拍背景图片异常！【AlertInfoService】-->【函数名】：QueryCapImg", ex);
            }

            return null;
        }



        public List<AlertInfoData> GetAlertDetail()
        {
            AlertInfo table = new AlertInfo();
            table.AlertUuid = "10";
            table.FcmpFobjId = "10";

            var list = table.QueryAlertDetail();
            List<AlertInfoData> result = new List<AlertInfoData>();
            list.ForEach(r => { result.Add(r.ToUIData<AlertInfoData>()); });

            return result;
        }

        public List<AlertInfoData> QueryNewestAlerts()
        {
            AlertInfoCondition condition = new AlertInfoCondition()
            {
                UserId = "admin",
                TopCount = 10
            };

            AlertInfo alertinfo = new AlertInfo();

            var list = alertinfo.QueryNewestAlerts(condition);
            List<AlertInfoData> result = new List<AlertInfoData>();
            if (list != null)
            {
                list.ForEach(r => { result.Add(r.ToUIData<AlertInfoData>()); });
            }
           

            return result;
        }

        public AlertInfoData ReCheckAlert()
        {
            AlertInfo condition = new AlertInfo
            {
                AlertUuid = AssistTools.GuidN
            };
            AlertInfo alert = condition.ReCheckAlert();
            if (alert != null)
                return alert.ToUIData<AlertInfoData>();
            else
                return null;
        }


    }
}
