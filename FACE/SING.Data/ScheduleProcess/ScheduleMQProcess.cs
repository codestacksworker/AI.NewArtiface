using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using SING.Data.BaseTools;
using SING.Data.DAL;
using SING.Data.DAL.Data;
using SING.Data.DAL.ScheduleConvert;
using SING.Data.Help;

namespace SING.Data.ScheduleProcess
{
    public class ScheduleMQProcess
    {
        private string _type = string.Empty;
        private MQService service = null;
        private static ScheduleMQProcess process = null;
        protected static ConcurrentDictionary<string, object> Cache = new ConcurrentDictionary<string, object>();
        private MQSubMessageParameters _paramsConvert = null;

        public static ScheduleMQProcess Process
        {
            get
            {
                if (process == null)
                    process = new ScheduleMQProcess();

                return process;
            }
        }

        private ScheduleMQProcess()
        { }

        public MQService CreateService(params string[] parameters)
        {
            _type = parameters[0];
            string topicName = string.Empty;


            switch (_type)
            {
                case "cap":
                    _paramsConvert = new MQSubMessageParameters(parameters[0], parameters[1], parameters[2]);
                    topicName = _paramsConvert.ToString();
                    service = new CapMQService(topicName);
                    break;
                case "alert":
                    _paramsConvert = new MQSubMessageParameters(parameters[0], parameters[1], parameters[2], parameters[3]);
                    topicName = _paramsConvert.ToString();
                    service = new AlertMQService(topicName);
                    break;
                case "alarm":
                    _paramsConvert = new MQSubMessageParameters(parameters[0], AppConfig.Instance.LoginName);
                    topicName = _paramsConvert.ToString();
                    service = new AlarmMQService(topicName);
                    break;
            }
            return service;
        }

        public IMQManager GetOrAdd(params string[] parameters)
        {
            string key = string.Join("-", parameters);
            return (IMQManager)Cache.GetOrAdd(key, s => CreateService(parameters));
        }
    }

    //public class ScheduleMQProcess
    //{

    //    private static IEventAggregator _eventAggregator;

    //    private static AlertData atData;

    //    private static AlarmData amData;

    //    private static FaceCaptureData cap;

    //    private static FaceCmpViewData cmp;

    //    public static void SubsriberCapMQ(string region, string channel)
    //    {
    //        MQEventAggregator.GetEventAggregator().GetEvent<MQCapMessageEvent>().Publish(new MQSubMessageParameters("cap", region, channel));
    //        MQMapService.ListenerCap += MQMapService_ListenerCap;
    //    }

    //    public static void SubsriberCmpMQ(string topicName)
    //    {
    //        MQEventAggregator.GetEventAggregator().GetEvent<MQCmpMessageEvent>().Publish(new MQSubMessageParameters("cmp", topicName));
    //        MQMapService.ListenerCmp += MQMapService_ListenerCmp;
    //    }

    //    public static void SubsriberAlertMQ(string region, string channel, string ftdbId)
    //    {
    //        MQEventAggregator.GetEventAggregator().GetEvent<MQAlertMessageEvent>().Publish(new MQSubMessageParameters("alert", region, channel, ftdbId));
    //        MQAlertService.ListenerAlert += MQAlertService_Listener;
    //    }

    //    public static void SubsriberAlarmMQ(string topic)
    //    {
    //        MQEventAggregator.GetEventAggregator().GetEvent<MQAlarmMessageEvent>().Publish(new MQSubMessageParameters("alert", AppConfig.Instance.LoginName));
    //        MQAlertService.ListenerAlarm += MQAlarmService_Listener;
    //    }

    //    public static void PublishAlertMQ(AlertData data)
    //    {
    //        string topic = new MQSubMessageParameters("alert", AppConfig.Instance.LoginName).ToString();

    //        Alert alert = AlertData.Convert(data);
    //        MQHelper.Producer_Topic<Alert>(topic, alert);
    //    }

    //    public static void CancleCapMQ(string region, string channel)
    //    {
    //        MQMapService.ListenerCap -= MQMapService_ListenerCap;
    //        MQSubMessageParameters para = new MQSubMessageParameters("cap", region, channel);
    //        MQMapService.CloseCapMQ(para.ToString());
    //    }

    //    public static void CancleCmpMQ()
    //    {
    //        MQMapService.ListenerCmp -= MQMapService_ListenerCmp;
    //        MQMapService.CloseCmpMQ();
    //    }

    //    public static void CancleAlertMQ(string region, string channel, string ftdbId)
    //    {
    //        MQAlertService.ListenerAlert -= MQAlertService_Listener;
    //        MQSubMessageParameters para = new MQSubMessageParameters("alert", region, channel, ftdbId);
    //        MQAlertService.CloseAlertMQ(para.ToString());
    //    }

    //    public static void CancleAlarmMQ()
    //    {
    //        MQAlertService.ListenerAlarm -= MQAlarmService_Listener;
    //        string topic = new MQSubMessageParameters("alert", AppConfig.Instance.LoginName).ToString();
    //        MQAlertService.CloseAlarmMQ(topic);
    //    }

    //    private static void MQMapService_ListenerCap(IMessage message)
    //    {
    //        IMapMessage mapMessage = message as IMapMessage;
    //        //FaceCaptureData cap = null;
    //        if (mapMessage != null)
    //        {
    //            if (cap != null)
    //                cap = null;
    //            cap = new FaceCaptureData();
    //            {
    //                cap.FcapId = mapMessage.Body.GetString("fcap_id");
    //                cap.FcapDcid = mapMessage.Body.GetString("fcap_dcid");
    //                cap.FcapTime = mapMessage.Body.GetLong("fcap_time").LToString();
    //                cap.FcapType = mapMessage.Body.GetInt("fcap_type");
    //                cap.FcapQuality = mapMessage.Body.GetInt("fcap_quality");
    //                cap.FcapSex = mapMessage.Body.GetInt("fcap_sex");
    //                cap.FcapAge = mapMessage.Body.GetInt("fcap_age");
    //                cap.ChannelLongitude = mapMessage.Body.GetDouble("channel_longitude");
    //                cap.ChannelLatitude = mapMessage.Body.GetDouble("channel_latitude");
    //                cap.ChannelDirect = mapMessage.Body.GetInt("channel_direct");
    //                cap.FcapObjImg = mapMessage.Body.GetBytes("fcap_obj_img");
    //                cap.FcapSceneImg = mapMessage.Body.GetBytes("fcap_scene_img");
    //                if(cap.FcapObjImg != null) cap.FcapObjFeat = mapMessage.Body.GetBytes("fcap_obj_feat");
    //                cap.FcapFaceX = mapMessage.Body.GetInt("fcap_face_x");
    //                cap.FcapFaceY = mapMessage.Body.GetInt("fcap_face_y");
    //                cap.FcapFaceCx = mapMessage.Body.GetInt("fcap_face_cx");
    //                cap.FcapFaceCy = mapMessage.Body.GetInt("fcap_face_cy");

    //                cap.ChannelName = mapMessage.Body.GetString("channel_name");
    //                cap.ChannelDescription = mapMessage.Body.GetString("channel_description");
    //                cap.ChannelAddr = mapMessage.Body.GetString("channel_addr");
    //                cap.ChannelPort = mapMessage.Body.GetInt("channel_port");
    //                cap.ChannelType = mapMessage.Body.GetInt("channel_type");
    //                cap.RegionId = mapMessage.Body.GetInt("region_id");
    //                cap.ChannelNo = mapMessage.Body.GetString("channel_no");
    //                cap.ChannelGuid = mapMessage.Body.GetString("channel_guid");
    //                cap.ChannelArea = mapMessage.Body.GetString("channel_area");
    //                cap.SdkVer = mapMessage.Body.GetString("sdk_ver");
    //                cap.MinFaceWidth = mapMessage.Body.GetInt("min_face_width");
    //                cap.MinImgQuality = mapMessage.Body.GetInt("min_img_quality");
    //                cap.MinCapDistance = mapMessage.Body.GetInt("min_cap_distance");
    //                cap.MaxSaveDistance = mapMessage.Body.GetInt("max_save_distance");
    //                cap.MaxYaw = mapMessage.Body.GetInt("max_yaw");
    //                cap.MaxPitch = mapMessage.Body.GetInt("max_pitch");
    //                cap.MaxYoll = mapMessage.Body.GetInt("max_roll");
    //                cap.ChannelThreshold = mapMessage.Body.GetDouble("channel_threshold");
    //                cap.CapStat = mapMessage.Body.GetInt("cap_stat");
    //                cap.Important = mapMessage.Body.GetInt("important");

    //            }
    //            _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
    //            _eventAggregator.GetEvent<RealtimeCapEvent>().Publish(cap);
    //        }
    //    }

    //    private static void MQMapService_ListenerCmp(IMessage message)
    //    {
    //        IMapMessage mapMessage = message as IMapMessage;
    //        //FaceCmpViewData cmp = null;
    //        if (mapMessage != null)
    //        {
    //            if (cmp != null)
    //                cmp = null;
    //            cmp = new FaceCmpViewData();
    //            {
    //                cmp.Uuid = mapMessage.Body.GetString("uuid");
    //                cmp.FcmpCapId = mapMessage.Body.GetString("fcmp_cap_id");
    //                cmp.FcapDcid = mapMessage.Body.GetString("fcap_dcid");
    //                cmp.ChannelName = mapMessage.Body.GetString("channel_name");
    //                //cmp.FcapTime = TimeConvert.Convert(mapMessage.Body.GetLong("fcap_time"), "yyyyMMdd HH:mm:ss");
    //                cmp.FcapType = mapMessage.Body.GetInt("fcap_type");
    //                cmp.FcapSex = mapMessage.Body.GetInt("fcap_sex");
    //                cmp.FcapAge = mapMessage.Body.GetInt("fcap_age");

    //                cmp.FcapObjImg = mapMessage.Body.GetBytes("fcap_obj_img");
    //                //if (cmp.FcapObjImg != null)
    //                //    cmp.FcapObjImgSource = ImageHelper.ByteArrayToBitmapImage(cmp.FcapObjImg);

    //                cmp.FcapSceneImg = mapMessage.Body.GetBytes("fcap_scene_img");
    //                //if (cmp.FcapSceneImg != null)
    //                //    cmp.FcapSceneImgSource = ImageHelper.ByteArrayToBitmapImage(cmp.FcapSceneImg);

    //                cmp.FcmpFobjImg = mapMessage.Body.GetBytes("fcmp_fobj_img");
    //                //if (cmp.FcmpFobjImg != null)
    //                //    cmp.FcmpFobjImgSource = ImageHelper.ByteArrayToBitmapImage(cmp.FcmpFobjImg);

    //                cmp.FcmpFobjId = mapMessage.Body.GetString("fcmp_fobj_id");
    //                cmp.FcmpFobjName = mapMessage.Body.GetString("fcmp_fobj_name");
    //                cmp.FcmpFobjType = mapMessage.Body.GetInt("fcmp_fobj_type");
    //                //cmp.FcmpTime = TimeConvert.Convert(mapMessage.Body.GetLong("fcmp_time"), "yyyyMMdd HH:mm:ss");
    //                //cmp.FcmpOrder = mapMessage.Body.GetInt("fcmp_order");
    //                cmp.FcmpSocre = mapMessage.Body.GetDouble("fcmp_socre");
    //                cmp.ChannelLongitude = mapMessage.Body.GetDouble("channel_longitude");
    //                cmp.ChannelLatitude = mapMessage.Body.GetDouble("channel_latitude");
    //                cmp.ChannelDirect = mapMessage.Body.GetInt("channel_direct");
    //                cmp.FTDBID = mapMessage.Body.GetInt("ftdb_id");
    //                cmp.TemplateDbName = mapMessage.Body.GetString("template_db_name");
    //            }
    //            _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
    //            _eventAggregator.GetEvent<RealtimeCmpEvent>().Publish(cmp);
    //        }
    //    }

    //    private static void MQAlertService_Listener(IMessage message)
    //    {
    //        if (message == null) return;
    //        IMapMessage mapMessage = message as IMapMessage;

    //        if (atData != null) atData = null;
    //        if (mapMessage != null)
    //        {
    //            atData = new AlertData();

    //            if (mapMessage.Body.Contains("uuid")) atData.Uuid = mapMessage.Body.GetString("uuid");
    //            if (mapMessage.Body.Contains("fcmp_cap_id")) atData.FcapId = mapMessage.Body.GetString("fcmp_cap_id");
    //            if (mapMessage.Body.Contains("fcmp_fobj_sex")) atData.FobjSex = mapMessage.Body.GetInt("fcmp_fobj_sex");
    //            if (mapMessage.Body.Contains("region_name")) atData.RegionName = mapMessage.Body.GetString("region_name");
    //            if (mapMessage.Body.Contains("fcap_time")) atData.FcapTime = mapMessage.Body.GetLong("fcap_time").LToString();
    //            if (mapMessage.Body.Contains("fcap_obj_img")) atData.FcapImg = mapMessage.Body.GetBytes("fcap_obj_img");
    //            if (mapMessage.Body.Contains("fcmp_cap_channel")) atData.ChannelId = mapMessage.Body.GetString("fcmp_cap_channel");
    //            if (mapMessage.Body.Contains("channel_longitude")) atData.ChannelLongitude = mapMessage.Body.GetDouble("channel_longitude");
    //            if (mapMessage.Body.Contains("channel_latitude")) atData.ChannelLatitude = mapMessage.Body.GetDouble("channel_latitude");
    //            if (mapMessage.Body.Contains("channel_name")) atData.ChannelName = mapMessage.Body.GetString("channel_name");
    //            if (mapMessage.Body.Contains("channel_direct")) atData.ChannelDirect = mapMessage.Body.GetInt("channel_direct");
    //            if (mapMessage.Body.Contains("fcmp_socre")) atData.FcmpSocre = mapMessage.Body.GetDouble("fcmp_socre");
    //            if (mapMessage.Body.Contains("fcmp_fobj_id")) atData.FobjId = mapMessage.Body.GetString("fcmp_fobj_id");
    //            if (mapMessage.Body.Contains("fcmp_fobj_name")) atData.FobjName = mapMessage.Body.GetString("fcmp_fobj_name");
    //            if (mapMessage.Body.Contains("id_type")) atData.IdType = mapMessage.Body.GetInt("id_type");
    //            if (mapMessage.Body.Contains("id_numb")) atData.IdNumb = mapMessage.Body.GetString("id_numb");
    //            if (mapMessage.Body.Contains("ftdb_id")) atData.FtdbId = mapMessage.Body.GetInt("ftdb_id");
    //            if (mapMessage.Body.Contains("template_db_name")) atData.FtdbName = mapMessage.Body.GetString("template_db_name");
    //            if (mapMessage.Body.Contains("fcmp_ft_id")) atData.FtId = mapMessage.Body.GetString("fcmp_ft_id");
    //            if (mapMessage.Body.Contains("ft_image")) atData.FtImg = mapMessage.Body.GetBytes("ft_image");
    //            if (mapMessage.Body.Contains("ft_image_time")) atData.FtImgTime = mapMessage.Body.GetLong("ft_image_time").LToString();
    //            if (mapMessage.Body.Contains("ruler_id")) atData.RulerId = mapMessage.Body.GetLong("ruler_id");
    //            if (mapMessage.Body.Contains("alert_time")) atData.AlertTime = mapMessage.Body.GetLong("alert_time").LToString();
    //            if (mapMessage.Body.Contains("acker")) atData.Acker = mapMessage.Body.GetString("acker");
    //            if (mapMessage.Body.Contains("ack_stat")) atData.AckStat = mapMessage.Body.GetInt("ack_stat");
    //            if (mapMessage.Body.Contains("ack_time")) atData.AckTime = mapMessage.Body.GetLong("ack_time").LToString();
    //            if (mapMessage.Body.Contains("puber")) atData.Puber = mapMessage.Body.GetString("puber");
    //            if (mapMessage.Body.Contains("pub_stat")) atData.PubStat = mapMessage.Body.GetInt("pub_stat");
    //            if (mapMessage.Body.Contains("pub_time")) atData.PubTime = mapMessage.Body.GetLong("pub_time").LToString();
    //            if (mapMessage.Body.Contains("channel_threshold")) atData.ChannelThreshold = mapMessage.Body.GetDouble("channel_threshold");
    //            if (mapMessage.Body.Contains("channel_area")) atData.ChannelArea = mapMessage.Body.GetString("channel_area");

    //            if (mapMessage.Body.Contains("fcap_face_x")) atData.FcapFaceX = mapMessage.Body.GetInt("fcap_face_x");
    //            if (mapMessage.Body.Contains("fcap_face_y")) atData.FcapFaceY = mapMessage.Body.GetInt("fcap_face_y");
    //            if (mapMessage.Body.Contains("fcap_face_cx")) atData.FcapFaceCx = mapMessage.Body.GetInt("fcap_face_cx");
    //            if (mapMessage.Body.Contains("fcap_face_cy")) atData.FcapFaceCy = mapMessage.Body.GetInt("fcap_face_cy");
    //            if (mapMessage.Body.Contains("matched_count")) atData.MatchedCount = mapMessage.Body.GetInt("matched_count");


    //            _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
    //            _eventAggregator.GetEvent<AlertMQEvent>().Publish(atData);
    //        }
    //    }

    //    private static void MQAlarmService_Listener(IMessage message)
    //    {

    //        IMapMessage mapMessage = message as IMapMessage;

    //        if (amData != null) amData = null;
    //        if (mapMessage != null)
    //        {
    //            amData = new AlarmData();
    //            if (mapMessage.Body.Contains("uuid")) amData.Uuid = mapMessage.Body.GetString("uuid");
    //            if (mapMessage.Body.Contains("fcmp_cap_id")) amData.FcapId = mapMessage.Body.GetString("fcmp_cap_id");
    //            if (mapMessage.Body.Contains("fcmp_fobj_sex")) amData.FobjSex = mapMessage.Body.GetInt("fcmp_fobj_sex");
    //            if (mapMessage.Body.Contains("region_name")) amData.RegionName = mapMessage.Body.GetString("region_name");
    //            if (mapMessage.Body.Contains("fcap_time")) amData.FcapTime = mapMessage.Body.GetLong("fcap_time").LToString();
    //            if (mapMessage.Body.Contains("fcap_obj_img")) amData.FcapImg = mapMessage.Body.GetBytes("fcap_obj_img");
    //            if (mapMessage.Body.Contains("fcmp_cap_channel")) amData.ChannelId = mapMessage.Body.GetString("fcmp_cap_channel");
    //            if (mapMessage.Body.Contains("channel_longitude")) amData.ChannelLongitude = mapMessage.Body.GetDouble("channel_longitude");
    //            if (mapMessage.Body.Contains("channel_latitude")) amData.ChannelLatitude = mapMessage.Body.GetDouble("channel_latitude");
    //            if (mapMessage.Body.Contains("channel_name")) amData.ChannelName = mapMessage.Body.GetString("channel_name");
    //            if (mapMessage.Body.Contains("channel_direct")) amData.ChannelDirect = mapMessage.Body.GetInt("channel_direct");
    //            if (mapMessage.Body.Contains("fcmp_socre")) amData.FcmpSocre = mapMessage.Body.GetDouble("fcmp_socre");
    //            if (mapMessage.Body.Contains("fcmp_fobj_id")) amData.FobjId = mapMessage.Body.GetString("fcmp_fobj_id");
    //            if (mapMessage.Body.Contains("fcmp_fobj_name")) amData.FobjName = mapMessage.Body.GetString("fcmp_fobj_name");
    //            if (mapMessage.Body.Contains("id_type")) amData.IdType = mapMessage.Body.GetInt("id_type");
    //            if (mapMessage.Body.Contains("id_numb")) amData.IdNumb = mapMessage.Body.GetString("id_numb");
    //            if (mapMessage.Body.Contains("ftdb_id")) amData.FtdbId = mapMessage.Body.GetInt("ftdb_id");
    //            if (mapMessage.Body.Contains("template_db_name")) amData.FtdbName = mapMessage.Body.GetString("template_db_name");
    //            if (mapMessage.Body.Contains("fcmp_ft_id")) amData.FtId = mapMessage.Body.GetString("fcmp_ft_id");
    //            if (mapMessage.Body.Contains("ft_image")) amData.FtImg = mapMessage.Body.GetBytes("ft_image");
    //            if (mapMessage.Body.Contains("ft_image_time")) amData.FtImgTime = mapMessage.Body.GetLong("ft_image_time").LToString();
    //            if (mapMessage.Body.Contains("ruler_id")) amData.RulerId = mapMessage.Body.GetLong("ruler_id");
    //            if (mapMessage.Body.Contains("alert_time")) amData.AlertTime = mapMessage.Body.GetLong("alert_time").LToString();
    //            if (mapMessage.Body.Contains("acker")) amData.Acker = mapMessage.Body.GetString("acker");
    //            if (mapMessage.Body.Contains("ack_stat")) amData.AckStat = mapMessage.Body.GetInt("ack_stat");
    //            if (mapMessage.Body.Contains("ack_time")) amData.AckTime = mapMessage.Body.GetLong("ack_time").LToString();
    //            if (mapMessage.Body.Contains("puber")) amData.Puber = mapMessage.Body.GetString("puber");
    //            if (mapMessage.Body.Contains("pub_stat")) amData.PubStat = mapMessage.Body.GetInt("pub_stat");
    //            if (mapMessage.Body.Contains("pub_time")) amData.PubTime = mapMessage.Body.GetLong("pub_time").LToString();
    //            if (mapMessage.Body.Contains("channel_threshold")) amData.ChannelThreshold = mapMessage.Body.GetDouble("channel_threshold");
    //            if (mapMessage.Body.Contains("channel_area")) amData.ChannelArea = mapMessage.Body.GetString("channel_area");

    //            if (mapMessage.Body.Contains("fcap_face_x")) amData.FcapFaceX = mapMessage.Body.GetInt("fcap_face_x");
    //            if (mapMessage.Body.Contains("fcap_face_y")) amData.FcapFaceY = mapMessage.Body.GetInt("fcap_face_y");
    //            if (mapMessage.Body.Contains("fcap_face_cx")) amData.FcapFaceCx = mapMessage.Body.GetInt("fcap_face_cx");
    //            if (mapMessage.Body.Contains("fcap_face_cy")) amData.FcapFaceCy = mapMessage.Body.GetInt("fcap_face_cy");
    //            if (mapMessage.Body.Contains("matched_count")) amData.MatchedCount = mapMessage.Body.GetInt("matched_count");

    //            _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();

    //            _eventAggregator.GetEvent<AlarmMQEvent>().Publish(amData);
    //        }
    //    }
    //}
}
