using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using SING.Data.DAL.Data;
using SING.Data.Help;
using IMessage = Apache.NMS.IMessage;

namespace SING.Data.BaseTools
{
    public interface IMQManager
    {
        void Dispose();
        void Subscriber();
        void Publish<T>(T t);
    }
    public abstract class MQService : IDisposable, IMQManager
    {
        delegate string AsyCallDelegate();

        public event MessageListener Listener;
        private string _topicName;
        private IMessageConsumer consumer;

        public MQService(string TopicName)
        {
            this._topicName = TopicName;
        }

        public void Subscriber()
        {
            AsyCallDelegate mqDelegate = new AsyCallDelegate(AysnHandle);
            mqDelegate.BeginInvoke(new AsyncCallback(endAsycallMethod), mqDelegate);
        }

        public void Dispose()
        {
            if (consumer != null)
            {
                consumer.Listener -= new MessageListener(OnListerner);
                consumer.Close();
                consumer = null;
            }
        }

        private string AysnHandle()
        {
            ReceiveMQMessage();
            return "结束启动mq连接";
        }

        private void ReceiveMQMessage()
        {
            try
            {
                consumer = MQHelper.Subscriber_Topic(_topicName);

                if (consumer != null)
                {
                    consumer.Listener += new MessageListener(OnListerner);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("接收MQ消息时出错，错误信息为：\r\n" + ex.Message);
            }
        }

        protected abstract void OnListerner(IMessage message);

        private void endAsycallMethod(IAsyncResult ar)
        {
            AsyCallDelegate a = ar.AsyncState as AsyCallDelegate;

            if (a != null)
            {
                string str = a.EndInvoke(ar);

                Logger.Logger.Info(str);
            }
        }

        public void Publish<T>(T t)
        {
            MQHelper.Producer_Topic<T>(_topicName, t);
        }
    }

    public class CapMQService : MQService
    {
        delegate void AsyReceiveDelegate(IMessage message);
        //private FaceCaptureData cap;

        public CapMQService(string TopicName) : base(TopicName)
        {
        }

        protected override void OnListerner(IMessage message)
        {
            #region @hq 20170711 add

            AsyReceiveDelegate callback = new AsyReceiveDelegate(receive);
            callback.BeginInvoke(message, new AsyncCallback(endreceive), (message as IMapMessage).Body.GetString("fcap_id"));
            #endregion

            #region @hq 20170711 modify

            //IMapMessage mapMessage = message as IMapMessage;

            //#region   Old Code
            ////if (mapMessage != null)
            ////{
            ////    if (cap != null)
            ////        cap = null;
            ////    cap = new FaceCaptureData();
            ////    {
            ////        cap.FcapId = mapMessage.Body.GetString("fcap_id");
            ////        cap.FcapDcid = mapMessage.Body.GetString("fcap_dcid");
            ////        cap.FcapTime = mapMessage.Body.GetLong("fcap_time").LToString();
            ////        cap.FcapType = mapMessage.Body.GetInt("fcap_type");
            ////        cap.FcapQuality = mapMessage.Body.GetInt("fcap_quality");
            ////        cap.FcapSex = mapMessage.Body.GetInt("fcap_sex");
            ////        cap.FcapAge = mapMessage.Body.GetInt("fcap_age");
            ////        cap.ChannelLongitude = mapMessage.Body.GetDouble("channel_longitude");
            ////        cap.ChannelLatitude = mapMessage.Body.GetDouble("channel_latitude");
            ////        cap.ChannelDirect = mapMessage.Body.GetInt("channel_direct");
            ////        cap.FcapObjImg = mapMessage.Body.GetBytes("fcap_obj_img");
            ////        cap.FcapSceneImg = mapMessage.Body.GetBytes("fcap_scene_img");
            ////        if (cap.FcapObjImg != null) cap.FcapObjFeat = mapMessage.Body.GetBytes("fcap_obj_feat");
            ////        cap.FcapFaceX = mapMessage.Body.GetInt("fcap_face_x");
            ////        cap.FcapFaceY = mapMessage.Body.GetInt("fcap_face_y");
            ////        cap.FcapFaceCx = mapMessage.Body.GetInt("fcap_face_cx");
            ////        cap.FcapFaceCy = mapMessage.Body.GetInt("fcap_face_cy");

            ////        cap.ChannelName = mapMessage.Body.GetString("channel_name");
            ////        cap.ChannelDescription = mapMessage.Body.GetString("channel_description");
            ////        cap.ChannelAddr = mapMessage.Body.GetString("channel_addr");
            ////        cap.ChannelPort = mapMessage.Body.GetInt("channel_port");
            ////        cap.ChannelType = mapMessage.Body.GetInt("channel_type");
            ////        cap.RegionId = mapMessage.Body.GetInt("region_id");
            ////        cap.ChannelNo = mapMessage.Body.GetString("channel_no");
            ////        cap.ChannelGuid = mapMessage.Body.GetString("channel_guid");
            ////        cap.ChannelArea = mapMessage.Body.GetString("channel_area");
            ////        cap.SdkVer = mapMessage.Body.GetString("sdk_ver");
            ////        cap.MinFaceWidth = mapMessage.Body.GetInt("min_face_width");
            ////        cap.MinImgQuality = mapMessage.Body.GetInt("min_img_quality");
            ////        cap.MinCapDistance = mapMessage.Body.GetInt("min_cap_distance");
            ////        cap.MaxSaveDistance = mapMessage.Body.GetInt("max_save_distance");
            ////        cap.MaxYaw = mapMessage.Body.GetInt("max_yaw");
            ////        cap.MaxPitch = mapMessage.Body.GetInt("max_pitch");
            ////        cap.MaxYoll = mapMessage.Body.GetInt("max_roll");
            ////        cap.ChannelThreshold = mapMessage.Body.GetDouble("channel_threshold");
            ////        cap.CapStat = mapMessage.Body.GetInt("cap_stat");
            ////        cap.Important = mapMessage.Body.GetInt("important");

            ////    }
            ////    IEventAggregator _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            ////    _eventAggregator.GetEvent<RealtimeCapEvent>().Publish(cap);

            ////}
            //#endregion

            //#region   New Code

            //if (mapMessage != null)
            //{
            //    if (cap != null)
            //        cap = null;

            //    if (mapMessage.Body == null)
            //    {
            //        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body为空！");
            //    }

            //    cap = new FaceCaptureData();
            //    {
            //        if (mapMessage.Body.Contains("fcap_id"))
            //        {
            //            if (string.IsNullOrEmpty(mapMessage.Body.GetString("fcap_id")))
            //            {
            //                Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'fcap_id'对应的键值为空！");
            //            }
            //            else
            //                cap.FcapId = mapMessage.Body.GetString("fcap_id");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_id'！");
            //        }

            //        if (mapMessage.Body.Contains("fcap_dcid"))
            //        {
            //            if (string.IsNullOrEmpty(mapMessage.Body.GetString("fcap_dcid")))
            //            {
            //                Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'fcap_dcid'对应的键值为空！");
            //            }
            //            else
            //                cap.FcapDcid = mapMessage.Body.GetString("fcap_dcid");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_dcid'！");
            //        }

            //        if (mapMessage.Body.Contains("fcap_time"))
            //        {
            //            if (string.IsNullOrEmpty(mapMessage.Body.GetLong("fcap_time").LToString()))
            //            {
            //                Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'fcap_time'对应的键值为空！");
            //            }
            //            else
            //                cap.FcapTime = mapMessage.Body.GetLong("fcap_time").LToString();
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_time'！");
            //        }

            //        if (mapMessage.Body.Contains("fcap_type"))
            //        {
            //            cap.FcapType = mapMessage.Body.GetInt("fcap_type");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_type'！");
            //        }

            //        if (mapMessage.Body.Contains("fcap_quality"))
            //        {
            //            cap.FcapQuality = mapMessage.Body.GetInt("fcap_quality");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_quality'！");
            //        }

            //        if (mapMessage.Body.Contains("fcap_sex"))
            //        {
            //            cap.FcapSex = mapMessage.Body.GetInt("fcap_sex");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_sex'！");
            //        }

            //        if (mapMessage.Body.Contains("fcap_age"))
            //        {
            //            cap.FcapAge = mapMessage.Body.GetInt("fcap_age");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_age'！");
            //        }

            //        if (mapMessage.Body.Contains("channel_longitude"))
            //        {
            //            cap.ChannelLongitude = mapMessage.Body.GetDouble("channel_longitude");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_longitude'！");
            //        }

            //        if (mapMessage.Body.Contains("channel_latitude"))
            //        {
            //            cap.ChannelLatitude = mapMessage.Body.GetDouble("channel_latitude");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_latitude'！");
            //        }

            //        if (mapMessage.Body.Contains("channel_direct"))
            //        {
            //            cap.ChannelDirect = mapMessage.Body.GetInt("channel_direct");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_direct'！");
            //        }

            //        if (mapMessage.Body.Contains("fcap_obj_img"))
            //        {
            //            if (mapMessage.Body.GetBytes("fcap_obj_img") == null)
            //            {
            //                Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'fcap_time'对应的键值为空！");
            //            }
            //            else
            //                cap.FcapObjImg = mapMessage.Body.GetBytes("fcap_obj_img");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_obj_img'！");
            //        }

            //        if (mapMessage.Body.Contains("fcap_scene_img"))
            //        {
            //            if (mapMessage.Body.GetBytes("fcap_scene_img") == null)
            //            {
            //                Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'fcap_scene_img'对应的键值为空！");
            //            }
            //            else
            //                cap.FcapSceneImg = mapMessage.Body.GetBytes("fcap_scene_img");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_scene_img'！");
            //        }

            //        if (mapMessage.Body.Contains("fcap_obj_feat"))
            //        {
            //            if (mapMessage.Body.GetBytes("fcap_obj_feat") == null)
            //            {
            //                Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'fcap_obj_feat'对应的键值为空！");
            //            }
            //            else if (cap.FcapObjImg != null)
            //                cap.FcapObjFeat = mapMessage.Body.GetBytes("fcap_obj_feat");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_obj_feat'！");
            //        }

            //        if (mapMessage.Body.Contains("fcap_face_x"))
            //        {
            //            cap.FcapFaceX = mapMessage.Body.GetInt("fcap_face_x");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_face_x'！");
            //        }

            //        if (mapMessage.Body.Contains("fcap_face_y"))
            //        {
            //            cap.FcapFaceY = mapMessage.Body.GetInt("fcap_face_y");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_face_y'！");
            //        }

            //        if (mapMessage.Body.Contains("fcap_face_cx"))
            //        {
            //            cap.FcapFaceCx = mapMessage.Body.GetInt("fcap_face_cx");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_face_cx'！");
            //        }

            //        if (mapMessage.Body.Contains("fcap_face_cy"))
            //        {
            //            cap.FcapFaceCy = mapMessage.Body.GetInt("fcap_face_cy");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_face_cy'！");
            //        }

            //        if (mapMessage.Body.Contains("channel_name"))
            //        {
            //            if (string.IsNullOrEmpty(mapMessage.Body.GetString("channel_name")))
            //            {
            //                Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'channel_name'对应的键值为空！");
            //            }
            //            else
            //                cap.ChannelName = mapMessage.Body.GetString("channel_name");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_name'！");
            //        }

            //        if (mapMessage.Body.Contains("channel_description"))
            //        {
            //            if (string.IsNullOrEmpty(mapMessage.Body.GetString("channel_description")))
            //            {
            //                Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'channel_description'对应的键值为空！");
            //            }
            //            else
            //                cap.ChannelDescription = mapMessage.Body.GetString("channel_description");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_description'！");
            //        }

            //        if (mapMessage.Body.Contains("channel_addr"))
            //        {
            //            if (string.IsNullOrEmpty(mapMessage.Body.GetString("channel_addr")))
            //            {
            //                Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'channel_addr'对应的键值为空！");
            //            }
            //            else
            //                cap.ChannelAddr = mapMessage.Body.GetString("channel_addr");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_addr'！");
            //        }

            //        if (mapMessage.Body.Contains("channel_port"))
            //        {
            //            cap.ChannelPort = mapMessage.Body.GetInt("channel_port");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_port'！");
            //        }

            //        if (mapMessage.Body.Contains("channel_type"))
            //        {
            //            cap.ChannelType = mapMessage.Body.GetInt("channel_type");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_type'！");
            //        }

            //        if (mapMessage.Body.Contains("region_id"))
            //        {
            //            cap.RegionId = mapMessage.Body.GetInt("region_id");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'region_id'！");
            //        }

            //        if (mapMessage.Body.Contains("channel_no"))
            //        {
            //            if (string.IsNullOrEmpty(mapMessage.Body.GetString("channel_no")))
            //            {
            //                Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'channel_no'对应的键值为空！");
            //            }
            //            else
            //                cap.ChannelNo = mapMessage.Body.GetString("channel_no");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_no'！");
            //        }

            //        if (mapMessage.Body.Contains("channel_guid"))
            //        {
            //            if (string.IsNullOrEmpty(mapMessage.Body.GetString("channel_guid")))
            //            {
            //                Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'channel_guid'对应的键值为空！");
            //            }
            //            else
            //                cap.ChannelGuid = mapMessage.Body.GetString("channel_guid");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_guid'！");
            //        }

            //        if (mapMessage.Body.Contains("channel_area"))
            //        {
            //            if (string.IsNullOrEmpty(mapMessage.Body.GetString("channel_area")))
            //            {
            //                Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'channel_area'对应的键值为空！");
            //            }
            //            else
            //                cap.ChannelArea = mapMessage.Body.GetString("channel_area");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_area'！");
            //        }

            //        if (mapMessage.Body.Contains("sdk_ver"))
            //        {
            //            if (string.IsNullOrEmpty(mapMessage.Body.GetString("sdk_ver")))
            //            {
            //                Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'sdk_ver'对应的键值为空！");
            //            }
            //            else
            //                cap.SdkVer = mapMessage.Body.GetString("sdk_ver");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'sdk_ver'！");
            //        }

            //        if (mapMessage.Body.Contains("min_face_width"))
            //        {
            //            cap.MinFaceWidth = mapMessage.Body.GetInt("min_face_width");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'min_face_width'！");
            //        }

            //        if (mapMessage.Body.Contains("min_img_quality"))
            //        {
            //            cap.MinImgQuality = mapMessage.Body.GetInt("min_img_quality");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'min_img_quality'！");
            //        }

            //        if (mapMessage.Body.Contains("min_cap_distance"))
            //        {
            //            cap.MinCapDistance = mapMessage.Body.GetInt("min_cap_distance");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'min_cap_distance'！");
            //        }

            //        if (mapMessage.Body.Contains("max_save_distance"))
            //        {
            //            cap.MaxSaveDistance = mapMessage.Body.GetInt("max_save_distance");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'max_save_distance'！");
            //        }

            //        if (mapMessage.Body.Contains("max_yaw"))
            //        {
            //            cap.MaxYaw = mapMessage.Body.GetInt("max_yaw");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'max_yaw'！");
            //        }

            //        if (mapMessage.Body.Contains("max_pitch"))
            //        {
            //            cap.MaxPitch = mapMessage.Body.GetInt("max_pitch");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'max_pitch'！");
            //        }

            //        if (mapMessage.Body.Contains("max_roll"))
            //        {
            //            cap.MaxYoll = mapMessage.Body.GetInt("max_roll");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'max_roll'！");
            //        }

            //        if (mapMessage.Body.Contains("channel_threshold"))
            //        {
            //            cap.ChannelThreshold = mapMessage.Body.GetDouble("channel_threshold");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_threshold'！");
            //        }

            //        if (mapMessage.Body.Contains("cap_stat"))
            //        {
            //            cap.CapStat = mapMessage.Body.GetInt("cap_stat");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'cap_stat'！");
            //        }

            //        if (mapMessage.Body.Contains("important"))
            //        {
            //            cap.Important = mapMessage.Body.GetInt("important");
            //        }
            //        else
            //        {
            //            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'important'！");
            //        }

            //    }
            //    IEventAggregator _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            //    _eventAggregator.GetEvent<RealtimeCapEvent>().Publish(cap);

            //}
            //else
            //{
            //    Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage为空！");
            //}

            //#endregion

            #endregion
        }

        private void receive(IMessage message)
        {
            IMapMessage mapMessage = message as IMapMessage;

            #region   Old Code
            //if (mapMessage != null)
            //{
            //    if (cap != null)
            //        cap = null;
            //    cap = new FaceCaptureData();
            //    {
            //        cap.FcapId = mapMessage.Body.GetString("fcap_id");
            //        cap.FcapDcid = mapMessage.Body.GetString("fcap_dcid");
            //        cap.FcapTime = mapMessage.Body.GetLong("fcap_time").LToString();
            //        cap.FcapType = mapMessage.Body.GetInt("fcap_type");
            //        cap.FcapQuality = mapMessage.Body.GetInt("fcap_quality");
            //        cap.FcapSex = mapMessage.Body.GetInt("fcap_sex");
            //        cap.FcapAge = mapMessage.Body.GetInt("fcap_age");
            //        cap.ChannelLongitude = mapMessage.Body.GetDouble("channel_longitude");
            //        cap.ChannelLatitude = mapMessage.Body.GetDouble("channel_latitude");
            //        cap.ChannelDirect = mapMessage.Body.GetInt("channel_direct");
            //        cap.FcapObjImg = mapMessage.Body.GetBytes("fcap_obj_img");
            //        cap.FcapSceneImg = mapMessage.Body.GetBytes("fcap_scene_img");
            //        if (cap.FcapObjImg != null) cap.FcapObjFeat = mapMessage.Body.GetBytes("fcap_obj_feat");
            //        cap.FcapFaceX = mapMessage.Body.GetInt("fcap_face_x");
            //        cap.FcapFaceY = mapMessage.Body.GetInt("fcap_face_y");
            //        cap.FcapFaceCx = mapMessage.Body.GetInt("fcap_face_cx");
            //        cap.FcapFaceCy = mapMessage.Body.GetInt("fcap_face_cy");

            //        cap.ChannelName = mapMessage.Body.GetString("channel_name");
            //        cap.ChannelDescription = mapMessage.Body.GetString("channel_description");
            //        cap.ChannelAddr = mapMessage.Body.GetString("channel_addr");
            //        cap.ChannelPort = mapMessage.Body.GetInt("channel_port");
            //        cap.ChannelType = mapMessage.Body.GetInt("channel_type");
            //        cap.RegionId = mapMessage.Body.GetInt("region_id");
            //        cap.ChannelNo = mapMessage.Body.GetString("channel_no");
            //        cap.ChannelGuid = mapMessage.Body.GetString("channel_guid");
            //        cap.ChannelArea = mapMessage.Body.GetString("channel_area");
            //        cap.SdkVer = mapMessage.Body.GetString("sdk_ver");
            //        cap.MinFaceWidth = mapMessage.Body.GetInt("min_face_width");
            //        cap.MinImgQuality = mapMessage.Body.GetInt("min_img_quality");
            //        cap.MinCapDistance = mapMessage.Body.GetInt("min_cap_distance");
            //        cap.MaxSaveDistance = mapMessage.Body.GetInt("max_save_distance");
            //        cap.MaxYaw = mapMessage.Body.GetInt("max_yaw");
            //        cap.MaxPitch = mapMessage.Body.GetInt("max_pitch");
            //        cap.MaxYoll = mapMessage.Body.GetInt("max_roll");
            //        cap.ChannelThreshold = mapMessage.Body.GetDouble("channel_threshold");
            //        cap.CapStat = mapMessage.Body.GetInt("cap_stat");
            //        cap.Important = mapMessage.Body.GetInt("important");

            //    }
            //    IEventAggregator _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            //    _eventAggregator.GetEvent<RealtimeCapEvent>().Publish(cap);

            //}
            #endregion

            #region   New Code

            if (mapMessage != null)
            {
                //if (cap != null)
                //    cap = null;

                if (mapMessage.Body == null)
                {
                    Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body为空！");
                }

                FaceCaptureData cap = new FaceCaptureData();
                {
                    if (mapMessage.Body.Contains("fcap_id"))
                    {
                        if (string.IsNullOrEmpty(mapMessage.Body.GetString("fcap_id")))
                        {
                            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'fcap_id'对应的键值为空！");
                        }
                        else
                            cap.FcapId = mapMessage.Body.GetString("fcap_id");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_id'！");
                    }

                    if (mapMessage.Body.Contains("fcap_dcid"))
                    {
                        if (string.IsNullOrEmpty(mapMessage.Body.GetString("fcap_dcid")))
                        {
                            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'fcap_dcid'对应的键值为空！");
                        }
                        else
                            cap.FcapDcid = mapMessage.Body.GetString("fcap_dcid");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_dcid'！");
                    }

                    if (mapMessage.Body.Contains("fcap_time"))
                    {
                        if (string.IsNullOrEmpty(mapMessage.Body.GetLong("fcap_time").LToString()))
                        {
                            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'fcap_time'对应的键值为空！");
                        }
                        else
                            cap.FcapTime = mapMessage.Body.GetLong("fcap_time").LToString();
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_time'！");
                    }

                    if (mapMessage.Body.Contains("fcap_type"))
                    {
                        cap.FcapType = mapMessage.Body.GetInt("fcap_type");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_type'！");
                    }

                    if (mapMessage.Body.Contains("fcap_quality"))
                    {
                        cap.FcapQuality = mapMessage.Body.GetInt("fcap_quality");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_quality'！");
                    }

                    if (mapMessage.Body.Contains("fcap_sex"))
                    {
                        cap.FcapSex = mapMessage.Body.GetInt("fcap_sex");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_sex'！");
                    }

                    if (mapMessage.Body.Contains("fcap_age"))
                    {
                        cap.FcapAge = mapMessage.Body.GetInt("fcap_age");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_age'！");
                    }

                    if (mapMessage.Body.Contains("channel_longitude"))
                    {
                        cap.ChannelLongitude = mapMessage.Body.GetDouble("channel_longitude");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_longitude'！");
                    }

                    if (mapMessage.Body.Contains("channel_latitude"))
                    {
                        cap.ChannelLatitude = mapMessage.Body.GetDouble("channel_latitude");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_latitude'！");
                    }

                    if (mapMessage.Body.Contains("channel_direct"))
                    {
                        cap.ChannelDirect = mapMessage.Body.GetInt("channel_direct");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_direct'！");
                    }

                    if (mapMessage.Body.Contains("fcap_obj_img"))
                    {
                        if (mapMessage.Body.GetBytes("fcap_obj_img") == null)
                        {
                            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'fcap_time'对应的键值为空！");
                        }
                        else
                            cap.FcapObjImg = mapMessage.Body.GetBytes("fcap_obj_img");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_obj_img'！");
                    }

                    //if (mapMessage.Body.Contains("fcap_scene_img"))
                    //{
                    //    if (mapMessage.Body.GetBytes("fcap_scene_img") == null)
                    //    {
                    //        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'fcap_scene_img'对应的键值为空！");
                    //    }
                    //    else
                    //        cap.FcapSceneImg = mapMessage.Body.GetBytes("fcap_scene_img");
                    //}
                    //else
                    //{
                    //    Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_scene_img'！");
                    //}

                    if (mapMessage.Body.Contains("fcap_obj_feat"))
                    {
                        if (mapMessage.Body.GetBytes("fcap_obj_feat") == null)
                        {
                            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'fcap_obj_feat'对应的键值为空！");
                        }
                        else if (cap.FcapObjImg != null)
                            cap.FcapObjFeat = mapMessage.Body.GetBytes("fcap_obj_feat");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_obj_feat'！");
                    }

                    if (mapMessage.Body.Contains("fcap_face_x"))
                    {
                        cap.FcapFaceX = mapMessage.Body.GetInt("fcap_face_x");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_face_x'！");
                    }

                    if (mapMessage.Body.Contains("fcap_face_y"))
                    {
                        cap.FcapFaceY = mapMessage.Body.GetInt("fcap_face_y");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_face_y'！");
                    }

                    if (mapMessage.Body.Contains("fcap_face_cx"))
                    {
                        cap.FcapFaceCx = mapMessage.Body.GetInt("fcap_face_cx");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_face_cx'！");
                    }

                    if (mapMessage.Body.Contains("fcap_face_cy"))
                    {
                        cap.FcapFaceCy = mapMessage.Body.GetInt("fcap_face_cy");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'fcap_face_cy'！");
                    }

                    if (mapMessage.Body.Contains("channel_name"))
                    {
                        if (string.IsNullOrEmpty(mapMessage.Body.GetString("channel_name")))
                        {
                            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'channel_name'对应的键值为空！");
                        }
                        else
                            cap.ChannelName = mapMessage.Body.GetString("channel_name");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_name'！");
                    }

                    if (mapMessage.Body.Contains("channel_description"))
                    {
                        if (string.IsNullOrEmpty(mapMessage.Body.GetString("channel_description")))
                        {
                            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'channel_description'对应的键值为空！");
                        }
                        else
                            cap.ChannelDescription = mapMessage.Body.GetString("channel_description");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_description'！");
                    }

                    if (mapMessage.Body.Contains("channel_addr"))
                    {
                        if (string.IsNullOrEmpty(mapMessage.Body.GetString("channel_addr")))
                        {
                            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'channel_addr'对应的键值为空！");
                        }
                        else
                            cap.ChannelAddr = mapMessage.Body.GetString("channel_addr");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_addr'！");
                    }

                    if (mapMessage.Body.Contains("channel_port"))
                    {
                        cap.ChannelPort = mapMessage.Body.GetInt("channel_port");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_port'！");
                    }

                    if (mapMessage.Body.Contains("channel_type"))
                    {
                        cap.ChannelType = mapMessage.Body.GetInt("channel_type");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_type'！");
                    }

                    if (mapMessage.Body.Contains("region_id"))
                    {
                        cap.RegionId = mapMessage.Body.GetInt("region_id");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'region_id'！");
                    }

                    if (mapMessage.Body.Contains("channel_no"))
                    {
                        if (string.IsNullOrEmpty(mapMessage.Body.GetString("channel_no")))
                        {
                            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'channel_no'对应的键值为空！");
                        }
                        else
                            cap.ChannelNo = mapMessage.Body.GetString("channel_no");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_no'！");
                    }

                    //if (mapMessage.Body.Contains("channel_guid"))
                    //{
                    //    if (string.IsNullOrEmpty(mapMessage.Body.GetString("channel_guid")))
                    //    {
                    //        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'channel_guid'对应的键值为空！");
                    //    }
                    //    else
                    //        cap.ChannelGuid = mapMessage.Body.GetString("channel_guid");
                    //}
                    //else
                    //{
                    //    Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_guid'！");
                    //}

                    if (mapMessage.Body.Contains("channel_area"))
                    {
                        if (string.IsNullOrEmpty(mapMessage.Body.GetString("channel_area")))
                        {
                            Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'channel_area'对应的键值为空！");
                        }
                        else
                            cap.ChannelArea = mapMessage.Body.GetString("channel_area");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_area'！");
                    }

                    //if (mapMessage.Body.Contains("sdk_ver"))
                    //{
                    //    if (string.IsNullOrEmpty(mapMessage.Body.GetString("sdk_ver")))
                    //    {
                    //        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键'sdk_ver'对应的键值为空！");
                    //    }
                    //    else
                    //        cap.SdkVer = mapMessage.Body.GetString("sdk_ver");
                    //}
                    //else
                    //{
                    //    Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'sdk_ver'！");
                    //}

                    if (mapMessage.Body.Contains("min_face_width"))
                    {
                        cap.MinFaceWidth = mapMessage.Body.GetInt("min_face_width");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'min_face_width'！");
                    }

                    if (mapMessage.Body.Contains("min_img_quality"))
                    {
                        cap.MinImgQuality = mapMessage.Body.GetInt("min_img_quality");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'min_img_quality'！");
                    }

                    if (mapMessage.Body.Contains("min_cap_distance"))
                    {
                        cap.MinCapDistance = mapMessage.Body.GetInt("min_cap_distance");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'min_cap_distance'！");
                    }

                    if (mapMessage.Body.Contains("max_save_distance"))
                    {
                        cap.MaxSaveDistance = mapMessage.Body.GetInt("max_save_distance");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'max_save_distance'！");
                    }

                    if (mapMessage.Body.Contains("max_yaw"))
                    {
                        cap.MaxYaw = mapMessage.Body.GetInt("max_yaw");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'max_yaw'！");
                    }

                    if (mapMessage.Body.Contains("max_pitch"))
                    {
                        cap.MaxPitch = mapMessage.Body.GetInt("max_pitch");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'max_pitch'！");
                    }

                    if (mapMessage.Body.Contains("max_roll"))
                    {
                        cap.MaxYoll = mapMessage.Body.GetInt("max_roll");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'max_roll'！");
                    }

                    if (mapMessage.Body.Contains("channel_threshold"))
                    {
                        cap.ChannelThreshold = mapMessage.Body.GetDouble("channel_threshold");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'channel_threshold'！");
                    }

                    if (mapMessage.Body.Contains("cap_stat"))
                    {
                        cap.CapStat = mapMessage.Body.GetInt("cap_stat");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'cap_stat'！");
                    }

                    if (mapMessage.Body.Contains("important"))
                    {
                        cap.Important = mapMessage.Body.GetInt("important");
                    }
                    else
                    {
                        Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key集合中不包含'important'！");
                    }

                }
                IEventAggregator _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
                _eventAggregator.GetEvent<RealtimeCapEvent>().Publish(cap);

            }
            else
            {
                Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage为空！");
            }

            #endregion
        }

        private void endreceive(IAsyncResult ar)
        {
            //AsyReceiveDelegate a = ar.AsyncState as AsyReceiveDelegate;
            AsyReceiveDelegate a = (AsyReceiveDelegate)((AsyncResult)ar).AsyncDelegate;

            if (a != null)
            {
                a.EndInvoke(ar);

                Logger.Logger.Info($"接收了一条mq抓拍消息,抓拍ID:{ar.AsyncState}！{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}");
            }
        }

        private void CopyFromBody<T>(IMapMessage message) where T : new()
        {
            if (message == null)
            {
                Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：CopyFromBody,mapMessage为空！");
                return;
            }

            if (message.Body == null)
            {
                Logger.Logger.Error("【Error】：推送告警信息！【CapMQService】-->【函数名】：CopyFromBody,message.Body！");
                return;
            }

            T data = new T();
            foreach (var pInfo in typeof(T).GetProperties())
            {
                if (pInfo.PropertyType == typeof(string))
                {
                    if (!message.Body.Contains(pInfo.Name))
                    {
                        Logger.Logger.Error($"【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key中不包含‘{pInfo.Name}’！");
                        break;
                    }
                    if (string.IsNullOrEmpty(message.Body.GetString(pInfo.Name)))
                    {
                        Logger.Logger.Error($"【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键‘{pInfo.Name}’对应的键值为空！");
                        break;
                    }
                    pInfo.SetValue(data, message.Body.GetString(pInfo.Name));
                }
                if (pInfo.PropertyType == typeof(int))
                {
                    if (!message.Body.Contains(pInfo.Name))
                    {
                        Logger.Logger.Error($"【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key中不包含‘{pInfo.Name}’！");
                        break;
                    }
                    if (string.IsNullOrEmpty(message.Body.GetString(pInfo.Name)))
                    {
                        Logger.Logger.Error($"【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键‘{pInfo.Name}’对应的键值为空！");
                        break;
                    }
                    pInfo.SetValue(data, message.Body.GetInt(pInfo.Name));
                }
                if (pInfo.PropertyType == typeof(long))
                {
                    if (!message.Body.Contains(pInfo.Name))
                    {
                        Logger.Logger.Error($"【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key中不包含‘{pInfo.Name}’！");
                        break;
                    }
                    if (string.IsNullOrEmpty(message.Body.GetString(pInfo.Name)))
                    {
                        Logger.Logger.Error($"【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键‘{pInfo.Name}’对应的键值为空！");
                        break;
                    }
                    pInfo.SetValue(data, message.Body.GetLong(pInfo.Name));
                }
                if (pInfo.PropertyType == typeof(byte[]))
                {
                    if (!message.Body.Contains(pInfo.Name))
                    {
                        Logger.Logger.Error($"【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key中不包含‘{pInfo.Name}’！");
                        break;
                    }
                    if (string.IsNullOrEmpty(message.Body.GetString(pInfo.Name)))
                    {
                        Logger.Logger.Error($"【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键‘{pInfo.Name}’对应的键值为空！");
                        break;
                    }
                    pInfo.SetValue(data, message.Body.GetBytes(pInfo.Name));
                }
                if (pInfo.PropertyType == typeof(double))
                {
                    if (!message.Body.Contains(pInfo.Name))
                    {
                        Logger.Logger.Error($"【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key中不包含‘{pInfo.Name}’！");
                        break;
                    }
                    if (string.IsNullOrEmpty(message.Body.GetString(pInfo.Name)))
                    {
                        Logger.Logger.Error($"【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键‘{pInfo.Name}’对应的键值为空！");
                        break;
                    }
                    pInfo.SetValue(data, message.Body.GetDouble(pInfo.Name));
                }
                if (pInfo.PropertyType == typeof(double))
                {
                    if (!message.Body.Contains(pInfo.Name))
                    {
                        Logger.Logger.Error($"【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body的Key中不包含‘{pInfo.Name}’！");
                        break;
                    }
                    if (string.IsNullOrEmpty(message.Body.GetString(pInfo.Name)))
                    {
                        Logger.Logger.Error($"【Error】：推送告警信息！【CapMQService】-->【函数名】：OnListerner,mapMessage.Body中键‘{pInfo.Name}’对应的键值为空！");
                        break;
                    }
                    pInfo.SetValue(data, message.Body.GetDouble(pInfo.Name));
                }
            }
        }
    }

    public class AlertMQService : MQService
    {
        delegate void AsyReceiveDelegate(IMessage message);
        //private AlertData atData;

        public AlertMQService(string TopicName) : base(TopicName)
        {
        }
        protected override void OnListerner(IMessage message)
        {
            #region @hq 20170711 add

            AsyReceiveDelegate callback = new AsyReceiveDelegate(receive);
            callback.BeginInvoke(message, new AsyncCallback(endreceive), (message as IMapMessage).Body.GetString("uuid"));
            #endregion

            #region  @hq 201707112035 modify
            //if (message == null) return;
            //IMapMessage mapMessage = message as IMapMessage;

            //if (atData != null) atData = null;
            //if (mapMessage != null)
            //{
            //    atData = new AlertData();

            //    if (mapMessage.Body.Contains("uuid")) atData.Uuid = mapMessage.Body.GetString("uuid");
            //    if (mapMessage.Body.Contains("fcmp_cap_id")) atData.FcapId = mapMessage.Body.GetString("fcmp_cap_id");
            //    if (mapMessage.Body.Contains("fcmp_fobj_sex")) atData.FobjSex = mapMessage.Body.GetInt("fcmp_fobj_sex");
            //    if (mapMessage.Body.Contains("region_name")) atData.RegionName = mapMessage.Body.GetString("region_name");
            //    if (mapMessage.Body.Contains("fcap_time")) atData.FcapTime = mapMessage.Body.GetLong("fcap_time").LToString();
            //    if (mapMessage.Body.Contains("fcap_obj_img")) atData.FcapImg = mapMessage.Body.GetBytes("fcap_obj_img");
            //    if (mapMessage.Body.Contains("fcmp_cap_channel")) atData.ChannelId = mapMessage.Body.GetString("fcmp_cap_channel");
            //    if (mapMessage.Body.Contains("channel_longitude")) atData.ChannelLongitude = mapMessage.Body.GetDouble("channel_longitude");
            //    if (mapMessage.Body.Contains("channel_latitude")) atData.ChannelLatitude = mapMessage.Body.GetDouble("channel_latitude");
            //    if (mapMessage.Body.Contains("channel_name")) atData.ChannelName = mapMessage.Body.GetString("channel_name");
            //    if (mapMessage.Body.Contains("channel_direct")) atData.ChannelDirect = mapMessage.Body.GetInt("channel_direct");
            //    if (mapMessage.Body.Contains("fcmp_socre")) atData.FcmpSocre = mapMessage.Body.GetDouble("fcmp_socre");
            //    if (mapMessage.Body.Contains("fcmp_fobj_id")) atData.FobjId = mapMessage.Body.GetString("fcmp_fobj_id");
            //    if (mapMessage.Body.Contains("fcmp_fobj_name")) atData.FobjName = mapMessage.Body.GetString("fcmp_fobj_name");
            //    if (mapMessage.Body.Contains("id_type")) atData.IdType = mapMessage.Body.GetInt("id_type");
            //    if (mapMessage.Body.Contains("id_numb")) atData.IdNumb = mapMessage.Body.GetString("id_numb");
            //    if (mapMessage.Body.Contains("ftdb_id")) atData.FtdbId = mapMessage.Body.GetInt("ftdb_id");
            //    if (mapMessage.Body.Contains("template_db_name")) atData.FtdbName = mapMessage.Body.GetString("template_db_name");
            //    if (mapMessage.Body.Contains("fcmp_ft_id")) atData.FtId = mapMessage.Body.GetString("fcmp_ft_id");
            //    if (mapMessage.Body.Contains("ft_image")) atData.FtImg = mapMessage.Body.GetBytes("ft_image");
            //    if (mapMessage.Body.Contains("ft_image_time")) atData.FtImgTime = mapMessage.Body.GetLong("ft_image_time").LToString();
            //    if (mapMessage.Body.Contains("ruler_id")) atData.RulerId = mapMessage.Body.GetLong("ruler_id");
            //    if (mapMessage.Body.Contains("alert_time")) atData.AlertTime = mapMessage.Body.GetLong("alert_time").LToString();
            //    if (mapMessage.Body.Contains("acker")) atData.Acker = mapMessage.Body.GetString("acker");
            //    if (mapMessage.Body.Contains("ack_stat")) atData.AckStat = mapMessage.Body.GetInt("ack_stat");
            //    if (mapMessage.Body.Contains("ack_time")) atData.AckTime = mapMessage.Body.GetLong("ack_time").LToString();
            //    if (mapMessage.Body.Contains("puber")) atData.Puber = mapMessage.Body.GetString("puber");
            //    if (mapMessage.Body.Contains("pub_stat")) atData.PubStat = mapMessage.Body.GetInt("pub_stat");
            //    if (mapMessage.Body.Contains("pub_time")) atData.PubTime = mapMessage.Body.GetLong("pub_time").LToString();
            //    if (mapMessage.Body.Contains("channel_threshold")) atData.ChannelThreshold = mapMessage.Body.GetDouble("channel_threshold");
            //    if (mapMessage.Body.Contains("channel_area")) atData.ChannelArea = mapMessage.Body.GetString("channel_area");

            //    if (mapMessage.Body.Contains("fcap_face_x")) atData.FcapFaceX = mapMessage.Body.GetInt("fcap_face_x");
            //    if (mapMessage.Body.Contains("fcap_face_y")) atData.FcapFaceY = mapMessage.Body.GetInt("fcap_face_y");
            //    if (mapMessage.Body.Contains("fcap_face_cx")) atData.FcapFaceCx = mapMessage.Body.GetInt("fcap_face_cx");
            //    if (mapMessage.Body.Contains("fcap_face_cy")) atData.FcapFaceCy = mapMessage.Body.GetInt("fcap_face_cy");
            //    if (mapMessage.Body.Contains("matched_count")) atData.MatchedCount = mapMessage.Body.GetInt("matched_count");


            //    IEventAggregator _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            //    _eventAggregator.GetEvent<AlertMQEvent>().Publish(atData);
            //}
            #endregion
        }

        private void receive(IMessage message)
        {
            if (message == null) return;
            IMapMessage mapMessage = message as IMapMessage;

            if (mapMessage != null)
            {
                AlertData atData = new AlertData();

                if (mapMessage.Body.Contains("uuid")) atData.Uuid = mapMessage.Body.GetString("uuid");
                if (mapMessage.Body.Contains("fcmp_cap_id")) atData.FcapId = mapMessage.Body.GetString("fcmp_cap_id");
                if (mapMessage.Body.Contains("fcmp_fobj_sex")) atData.FobjSex = mapMessage.Body.GetInt("fcmp_fobj_sex");
                if (mapMessage.Body.Contains("region_name")) atData.RegionName = mapMessage.Body.GetString("region_name");
                if (mapMessage.Body.Contains("fcap_time")) atData.FcapTime = mapMessage.Body.GetLong("fcap_time").LToString();
                if (mapMessage.Body.Contains("fcap_obj_img")) atData.FcapImg = mapMessage.Body.GetBytes("fcap_obj_img");
                if (mapMessage.Body.Contains("fcmp_cap_channel")) atData.ChannelId = mapMessage.Body.GetString("fcmp_cap_channel");
                if (mapMessage.Body.Contains("channel_longitude")) atData.ChannelLongitude = mapMessage.Body.GetDouble("channel_longitude");
                if (mapMessage.Body.Contains("channel_latitude")) atData.ChannelLatitude = mapMessage.Body.GetDouble("channel_latitude");
                if (mapMessage.Body.Contains("channel_name")) atData.ChannelName = mapMessage.Body.GetString("channel_name");
                if (mapMessage.Body.Contains("channel_direct")) atData.ChannelDirect = mapMessage.Body.GetInt("channel_direct");
                if (mapMessage.Body.Contains("fcmp_socre"))
                {
                    atData.FcmpSocre = mapMessage.Body.GetDouble("fcmp_socre");
                    Logger.Logger.Info("=======================Socre Begin==============================");
                    Logger.Logger.Info($"Socre:{atData.FcmpSocre}");
                    Logger.Logger.Info("=======================Socre End==============================");
                }
                if (mapMessage.Body.Contains("fcmp_fobj_id")) atData.FobjId = mapMessage.Body.GetString("fcmp_fobj_id");
                if (mapMessage.Body.Contains("fcmp_fobj_name")) atData.FobjName = mapMessage.Body.GetString("fcmp_fobj_name");
                if (mapMessage.Body.Contains("id_type")) atData.IdType = mapMessage.Body.GetInt("id_type");
                if (mapMessage.Body.Contains("id_numb")) atData.IdNumb = mapMessage.Body.GetString("id_numb");
                if (mapMessage.Body.Contains("ftdb_id")) atData.FtdbId = mapMessage.Body.GetInt("ftdb_id");
                if (mapMessage.Body.Contains("template_db_name")) atData.FtdbName = mapMessage.Body.GetString("template_db_name");
                if (mapMessage.Body.Contains("fcmp_ft_id")) atData.FtId = mapMessage.Body.GetString("fcmp_ft_id");
                if (mapMessage.Body.Contains("ft_image")) atData.FtImg = mapMessage.Body.GetBytes("ft_image");
                if (mapMessage.Body.Contains("ft_image_time")) atData.FtImgTime = mapMessage.Body.GetLong("ft_image_time").LToString();
                if (mapMessage.Body.Contains("ruler_id")) atData.RulerId = mapMessage.Body.GetLong("ruler_id");
                if (mapMessage.Body.Contains("alert_time")) atData.AlertTime = mapMessage.Body.GetLong("alert_time").LToString();
                if (mapMessage.Body.Contains("acker")) atData.Acker = mapMessage.Body.GetString("acker");
                if (mapMessage.Body.Contains("ack_stat")) atData.AckStat = mapMessage.Body.GetInt("ack_stat");
                if (mapMessage.Body.Contains("ack_time")) atData.AckTime = mapMessage.Body.GetLong("ack_time").LToString();
                if (mapMessage.Body.Contains("puber")) atData.Puber = mapMessage.Body.GetString("puber");
                if (mapMessage.Body.Contains("pub_stat")) atData.PubStat = mapMessage.Body.GetInt("pub_stat");
                if (mapMessage.Body.Contains("pub_time")) atData.PubTime = mapMessage.Body.GetLong("pub_time").LToString();
                if (mapMessage.Body.Contains("channel_threshold")) atData.ChannelThreshold = mapMessage.Body.GetDouble("channel_threshold");
                if (mapMessage.Body.Contains("channel_area")) atData.ChannelArea = mapMessage.Body.GetString("channel_area");

                if (mapMessage.Body.Contains("fcap_face_x")) atData.FcapFaceX = mapMessage.Body.GetInt("fcap_face_x");
                if (mapMessage.Body.Contains("fcap_face_y")) atData.FcapFaceY = mapMessage.Body.GetInt("fcap_face_y");
                if (mapMessage.Body.Contains("fcap_face_cx")) atData.FcapFaceCx = mapMessage.Body.GetInt("fcap_face_cx");
                if (mapMessage.Body.Contains("fcap_face_cy")) atData.FcapFaceCy = mapMessage.Body.GetInt("fcap_face_cy");
                if (mapMessage.Body.Contains("matched_count")) atData.MatchedCount = mapMessage.Body.GetInt("matched_count");


                IEventAggregator _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
                _eventAggregator.GetEvent<AlertMQEvent>().Publish(atData);
            }
        }

        private void endreceive(IAsyncResult ar)
        {
            //AsyReceiveDelegate a = ar.AsyncState as AsyReceiveDelegate;
            AsyReceiveDelegate a = (AsyReceiveDelegate)((AsyncResult)ar).AsyncDelegate;

            if (a != null)
            {
                a.EndInvoke(ar);

                Logger.Logger.Info($"接收了一条mq告警消息,告警ID:{ar.AsyncState}！{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}");
            }
        }
    }

    public class AlarmMQService : MQService
    {
        private AlarmData amData;

        public AlarmMQService(string TopicName) : base(TopicName)
        {
        }

        protected override void OnListerner(IMessage message)
        {
            IMapMessage mapMessage = message as IMapMessage;

            if (amData != null) amData = null;
            if (mapMessage != null)
            {
                amData = new AlarmData();
                if (mapMessage.Body.Contains("uuid")) amData.Uuid = mapMessage.Body.GetString("uuid");
                if (mapMessage.Body.Contains("fcmp_cap_id")) amData.FcapId = mapMessage.Body.GetString("fcmp_cap_id");
                if (mapMessage.Body.Contains("fcmp_fobj_sex")) amData.FobjSex = mapMessage.Body.GetInt("fcmp_fobj_sex");
                if (mapMessage.Body.Contains("region_name")) amData.RegionName = mapMessage.Body.GetString("region_name");
                if (mapMessage.Body.Contains("fcap_time")) amData.FcapTime = mapMessage.Body.GetLong("fcap_time").LToString();
                if (mapMessage.Body.Contains("fcap_obj_img")) amData.FcapImg = mapMessage.Body.GetBytes("fcap_obj_img");
                if (mapMessage.Body.Contains("fcmp_cap_channel")) amData.ChannelId = mapMessage.Body.GetString("fcmp_cap_channel");
                if (mapMessage.Body.Contains("channel_longitude")) amData.ChannelLongitude = mapMessage.Body.GetDouble("channel_longitude");
                if (mapMessage.Body.Contains("channel_latitude")) amData.ChannelLatitude = mapMessage.Body.GetDouble("channel_latitude");
                if (mapMessage.Body.Contains("channel_name")) amData.ChannelName = mapMessage.Body.GetString("channel_name");
                if (mapMessage.Body.Contains("channel_direct")) amData.ChannelDirect = mapMessage.Body.GetInt("channel_direct");
                if (mapMessage.Body.Contains("fcmp_socre")) amData.FcmpSocre = mapMessage.Body.GetDouble("fcmp_socre");
                if (mapMessage.Body.Contains("fcmp_fobj_id")) amData.FobjId = mapMessage.Body.GetString("fcmp_fobj_id");
                if (mapMessage.Body.Contains("fcmp_fobj_name")) amData.FobjName = mapMessage.Body.GetString("fcmp_fobj_name");
                if (mapMessage.Body.Contains("id_type")) amData.IdType = mapMessage.Body.GetInt("id_type");
                if (mapMessage.Body.Contains("id_numb")) amData.IdNumb = mapMessage.Body.GetString("id_numb");
                if (mapMessage.Body.Contains("ftdb_id")) amData.FtdbId = mapMessage.Body.GetInt("ftdb_id");
                if (mapMessage.Body.Contains("template_db_name")) amData.FtdbName = mapMessage.Body.GetString("template_db_name");
                if (mapMessage.Body.Contains("fcmp_ft_id")) amData.FtId = mapMessage.Body.GetString("fcmp_ft_id");
                if (mapMessage.Body.Contains("ft_image")) amData.FtImg = mapMessage.Body.GetBytes("ft_image");
                if (mapMessage.Body.Contains("ft_image_time")) amData.FtImgTime = mapMessage.Body.GetLong("ft_image_time").LToString();
                if (mapMessage.Body.Contains("ruler_id")) amData.RulerId = mapMessage.Body.GetLong("ruler_id");
                if (mapMessage.Body.Contains("alert_time")) amData.AlertTime = mapMessage.Body.GetLong("alert_time").LToString();
                if (mapMessage.Body.Contains("acker")) amData.Acker = mapMessage.Body.GetString("acker");
                if (mapMessage.Body.Contains("ack_stat")) amData.AckStat = mapMessage.Body.GetInt("ack_stat");
                if (mapMessage.Body.Contains("ack_time")) amData.AckTime = mapMessage.Body.GetLong("ack_time").LToString();
                if (mapMessage.Body.Contains("puber")) amData.Puber = mapMessage.Body.GetString("puber");
                if (mapMessage.Body.Contains("pub_stat")) amData.PubStat = mapMessage.Body.GetInt("pub_stat");
                if (mapMessage.Body.Contains("pub_time")) amData.PubTime = mapMessage.Body.GetLong("pub_time").LToString();
                if (mapMessage.Body.Contains("channel_threshold")) amData.ChannelThreshold = mapMessage.Body.GetDouble("channel_threshold");
                if (mapMessage.Body.Contains("channel_area")) amData.ChannelArea = mapMessage.Body.GetString("channel_area");

                if (mapMessage.Body.Contains("fcap_face_x")) amData.FcapFaceX = mapMessage.Body.GetInt("fcap_face_x");
                if (mapMessage.Body.Contains("fcap_face_y")) amData.FcapFaceY = mapMessage.Body.GetInt("fcap_face_y");
                if (mapMessage.Body.Contains("fcap_face_cx")) amData.FcapFaceCx = mapMessage.Body.GetInt("fcap_face_cx");
                if (mapMessage.Body.Contains("fcap_face_cy")) amData.FcapFaceCy = mapMessage.Body.GetInt("fcap_face_cy");
                if (mapMessage.Body.Contains("matched_count")) amData.MatchedCount = mapMessage.Body.GetInt("matched_count");

                IEventAggregator _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();

                _eventAggregator.GetEvent<AlarmMQEvent>().Publish(amData);
            }
        }
    }
}
