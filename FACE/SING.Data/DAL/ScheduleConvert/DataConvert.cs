using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dev_SING.Data.BaseTools;
using SING.Data.Controls.Video.VideoSdkHelper.Models;
using SING.Data.DAL.Data;
using SING.Data.Help;

namespace SING.Data.DAL.ScheduleConvert
{
    public class DataConvert
    {
        public static FaceObjTempViewData ViewDataFromData(FaceObjectData oradata, List<FaceTemplateData> temps)
        {
            FaceObjTempViewData data = new FaceObjTempViewData();

            #region

            data.FTDBID = oradata.FTDBID;
            data.Uuid = oradata.Uuid;
            data.MainFtID = oradata.MainFtID;
            data.Name = oradata.Name;
            data.Type = oradata.Type;
            data.Sst = oradata.Sst;
            data.Sex = oradata.Sex;
            data.TimeStamp = oradata.TimeStamp;
            data.Remarks = oradata.Remarks;
            data.IdNumb = oradata.IdNumb;
            data.IdType = oradata.IdType;
            data.BirthDate = oradata.BirthDate;
            data.Addr = oradata.Addr;
            data.Ethnic = oradata.Ethnic;
            data.Tag = oradata.Tag;
            if (temps != null && temps.Count > 0)
            {
                data.Temps = temps;
                data.Temp = temps.SingleOrDefault(p => p != null && p.Uuid == oradata.MainFtID);
            }

            #endregion

            return data;
        }

        public static FaceObjTempViewData CopyViewData(FaceObjTempViewData oradata)
        {
            FaceObjTempViewData data = new FaceObjTempViewData();

            #region

            data.FTDBID = oradata.FTDBID;
            data.Uuid = oradata.Uuid;
            data.MainFtID = oradata.MainFtID;
            data.Name = oradata.Name;
            data.Type = oradata.Type;
            data.Sst = oradata.Sst;
            data.Sex = oradata.Sex;
            data.TimeStamp = oradata.TimeStamp;
            data.Remarks = oradata.Remarks;
            data.IdNumb = oradata.IdNumb;
            data.IdType = oradata.IdType;
            data.BirthDate = oradata.BirthDate;
            data.Addr = oradata.Addr;
            data.Ethnic = oradata.Ethnic;
            data.Tag = oradata.Tag;
            if (oradata.Temps != null && oradata.Temps.Count > 0)
            {
                data.Temps = new List<FaceTemplateData>();
                for (int i = 0; i < oradata.Temps.Count; i++)
                {
                    if (oradata.Temps[i] != null)
                    {
                        data.Temps.Add(FaceTemplateData.CopyData(oradata.Temps[i]));
                    }
                    else
                    {
                        data.Temps.Add(oradata.Temps[i]);
                    }
                }
            }

            if (oradata.Temp != null)
            {
                data.Temp = FaceTemplateData.CopyData(oradata.Temp);
            }

            #endregion

            return data;
        }

        public static FaceObjTempViewData ViewDataFromBase(FaceObject oradata, List<FaceTemplateData> temps)
        {
            FaceObjTempViewData data = new FaceObjTempViewData();
            #region

            data.FTDBID = oradata.FTDBID;
            data.Uuid = oradata.Uuid;
            data.MainFtID = oradata.MainFtID;
            data.Name = oradata.Name;
            data.Type = oradata.Type;
            data.Sst = oradata.Sst;
            data.Sex = oradata.Sex;
            data.TimeStamp = oradata.TimeStamp.LToString();
            data.Remarks = oradata.Remarks;
            data.IdNumb = oradata.IdNumb;
            data.IdType = oradata.IdType;
            data.BirthDate = oradata.BirthDate.LToShortDateString();
            data.Addr = oradata.Addr;
            data.Ethnic = oradata.Ethnic;
            data.Tag = oradata.Tag;
            data.Temps = temps;
            #endregion
            return data;
        }

        public static FaceObject BaseFromViewData(FaceObjTempViewData oradata)
        {
            FaceObject data = new FaceObject();
            #region

            data.FTDBID = oradata.FTDBID;
            data.Uuid = oradata.Uuid;
            data.MainFtID = oradata.MainFtID;
            data.Name = oradata.Name;
            data.Type = oradata.Type;
            data.Sst = oradata.Sst;
            data.Sex = oradata.Sex;
            data.TimeStamp = oradata.TimeStamp.SToLong();
            data.Remarks = oradata.Remarks;
            data.IdNumb = oradata.IdNumb;
            data.IdType = oradata.IdType;
            data.BirthDate = oradata.BirthDate.SToShortDateLong();
            data.Addr = oradata.Addr;
            data.Ethnic = oradata.Ethnic;
            data.Tag = oradata.Tag;
            #endregion
            return data;
        }

        public static FaceTemplateDBData CopyData(FaceTemplateDBData oridata)
        {
            FaceTemplateDBData target = new FaceTemplateDBData();

            #region
            target.ID = oridata.ID;
            target.TemplateDbName = oridata.TemplateDbName;
            target.TemplateDbDescription = oridata.TemplateDbDescription;
            target.TemplateDbType = oridata.TemplateDbType;
            target.IsUsed = oridata.IsUsed;
            target.TemplateDbSize = oridata.TemplateDbSize;
            target.CreateTime = oridata.CreateTime;
            target.IsDeleted = oridata.IsDeleted;
            target.TemplateDbCapacity = oridata.TemplateDbCapacity;
            #endregion

            return target;
        }
        public static FcmpRecordViewData ViewDataFromBase(FcmpCaptureAlarm oridata)
        {
            FcmpRecordViewData target = new FcmpRecordViewData();

            #region

            target.Uuid = oridata.Uuid;
            target.FcmpCapId = oridata.FcmpCapId;
            target.FcmpCapChannel = oridata.FcmpCapChannel;
            target.ChannelLongitude = oridata.ChannelLongitude;
            target.ChannelLatitude = oridata.ChannelLatitude;
            target.ChannelDirect = oridata.ChannelDirect;
            target.FcapTime = TimeConvert.Convert(oridata.FcapTime, "yyyyMMdd HH:mm:ss");
            target.FTDBID = oridata.FTDBID;
            target.ChannelName = oridata.ChannelName;
            target.FcapObjImg = oridata.FcapObjImg;
            //target.FcapObjImgSource = ImageHelper.ByteArrayToBitmapImage(oridata.FcapObjImg);
            target.TemplateDbName = oridata.TemplateDbName;
            target.ChannelArea = oridata.ChannelArea;

            #endregion

            return target;
        }

        public static FcmpCaptureAlarm BaseFromViewData(FcmpRecordViewData oridata)
        {
            FcmpCaptureAlarm target = new FcmpCaptureAlarm();

            #region

            target.Uuid = oridata.Uuid;
            target.FcmpCapId = oridata.FcmpCapId;
            target.FcmpCapChannel = oridata.FcmpCapChannel;
            target.ChannelLongitude = oridata.ChannelLongitude;
            target.ChannelLatitude = oridata.ChannelLatitude;
            target.ChannelDirect = oridata.ChannelDirect;
            target.FcapTime = TimeConvert.Convert(oridata.FcapTime);
            target.FTDBID = oridata.FTDBID;
            target.ChannelName = oridata.ChannelName;
            target.FcapObjImg = oridata.FcapObjImg;
            target.TemplateDbName = oridata.TemplateDbName;
            target.ChannelArea = oridata.ChannelArea;

            #endregion

            return target;
        }

        public static FaceObjTempViewData BaseFromViewData(FcmpCaptureAlarm oridata)
        {
            FaceObjTempViewData target = new FaceObjTempViewData();

            #region

            target.FTDBID = oridata.FTDBID;
            target.Uuid = oridata.Uuid;
            target.TimeStamp = TimeConvert.Convert(oridata.FcmpTime, "yyyyMMdd HH:mm:ss");
            target.FcmpOrder = oridata.FcmpOrder;
            target.FcmpSocre = oridata.FcmpSocre;
            target.Uuid = oridata.FcmpFobjId;
            target.Name = oridata.FcmpFobjName;
            target.Type = oridata.FcmpFobjType;
            target.Sex = oridata.FcmpFobjSex;
            target.IdNumb = oridata.IdNumb;
            target.IdType = oridata.IdType;
            target.TemplateDbName = oridata.TemplateDbName;
            target.Temp = new FaceTemplateData
            {
                Uuid = oridata.FcmpFtId,
                FTDBID = oridata.FTDBID,
                FtImage = oridata.FtImage,
            };

            #endregion

            return target;
        }

        public static FcmpCaptureAlarm ViewDataFromBase(FaceObjTempViewData oridata)
        {
            FcmpCaptureAlarm target = new FcmpCaptureAlarm();

            #region

            target.Uuid = oridata.Uuid;
            target.FcmpTime = TimeConvert.Convert(oridata.TimeStamp);
            target.FcmpOrder = oridata.FcmpOrder;
            target.FcmpSocre = oridata.FcmpSocre;
            target.FcmpFobjId = oridata.Uuid;
            target.FcmpFobjName = oridata.Name;
            target.FcmpFobjType = oridata.Type;
            target.FcmpFobjSex = oridata.Sex;
            target.IdNumb = oridata.IdNumb;
            target.IdType = oridata.IdType;
            target.TemplateDbName = oridata.TemplateDbName;
            target.FTDBID = oridata.FTDBID;
            if (oridata.Temp != null)
            {
                target.FcmpFtId = oridata.Temp.Uuid;
                target.FtImage = oridata.Temp.FtImage;
            }

            #endregion

            return target;
        }

        public static AlarmData DataFromData(AlertData oridata)
        {
            AlarmData target = new AlarmData();

            #region

            target.Uuid = oridata.Uuid;
            target.ChannelDirect = oridata.ChannelDirect;
            target.ChannelId = oridata.ChannelId;
            target.ChannelLatitude = oridata.ChannelLatitude;
            target.ChannelLongitude = oridata.ChannelLongitude;
            target.ChannelName = oridata.ChannelName;
            target.ChannelArea = oridata.ChannelArea;
            target.ChannelThreshold = oridata.ChannelThreshold;
            target.FcapId = oridata.FcapId;
            target.FcapImg = oridata.FcapImg;
            target.FcapTime = oridata.FcapTime;
            target.FcmpSocre = oridata.FcmpSocre;
            target.FobjId = oridata.FobjId;
            target.FobjName = oridata.FobjName;
            target.FobjSex = oridata.FobjSex;
            target.FtdbId = oridata.FtdbId;
            target.FtdbName = oridata.FtdbName;
            target.FtId = oridata.FtId;
            target.FtImg = oridata.FtImg;
            target.FtImgTime = oridata.FtImgTime;
            target.IdType = oridata.IdType;
            target.IdNumb = oridata.IdNumb;
            target.RulerId = oridata.RulerId;
            target.RegionName = oridata.RegionName;
            target.RegionId = oridata.RegionId;
            target.MatchedCount = oridata.MatchedCount;
            target.RulerName = oridata.RulerName;
            target.AlertTime = oridata.AlertTime;
            target.Acker = oridata.Acker;
            target.AckStat = oridata.AckStat;
            target.AckTime = oridata.AckTime;
            target.Puber = oridata.Puber;
            target.PubStat = oridata.PubStat;
            target.PubTime = oridata.PubTime;

            #endregion

            return target;
        }

        public static AlarmData DataFromBase(Alert oridata)
        {
            AlarmData target = new AlarmData();

            #region

            target.Uuid = oridata.Uuid;
            target.ChannelDirect = oridata.ChannelDirect;
            target.ChannelId = oridata.ChannelId;
            target.ChannelLatitude = oridata.ChannelLatitude;
            target.ChannelLongitude = oridata.ChannelLongitude;
            target.ChannelName = oridata.ChannelName;
            target.ChannelArea = oridata.ChannelArea;
            target.ChannelThreshold = oridata.ChannelThreshold;
            target.FcapId = oridata.FcapId;
            target.FcapImg = oridata.FcapImg;
            target.FcapTime = oridata.FcapTime.LToString();
            target.FcmpSocre = oridata.FcmpSocre;
            target.FobjId = oridata.FobjId;
            target.FobjName = oridata.FobjName;
            target.FobjSex = oridata.FobjSex;
            target.FtdbId = oridata.FtdbId;
            target.FtdbName = oridata.FtdbName;
            target.FtId = oridata.FtId;
            target.FtImg = oridata.FtImg;
            target.FtImgTime = oridata.FtImgTime.LToString();
            target.IdType = oridata.IdType;
            target.IdNumb = oridata.IdNumb;
            target.RulerId = oridata.RulerId;
            target.RegionName = oridata.RegionName;
            target.MatchedCount = oridata.MatchedCount;
            target.RulerName = oridata.RulerName;
            //target.RegionId = oridata.RegionId;// 预留字段
            target.AlertTime = oridata.AlertTime.LToString();
            target.Acker = oridata.Acker;
            target.AckStat = oridata.AckStat;
            target.AckTime = oridata.AckTime.LToString();
            target.Puber = oridata.Puber;
            target.PubStat = oridata.PubStat;
            target.PubTime = oridata.PubTime.LToString();

            #endregion

            return target;
        }

        public static VideoItem VideoFromData(Channel oridata)
        {
            VideoItem target = new VideoItem();

            target.ServerIp = oridata.ChannelAddr;
            target.ServerPort = oridata.ChannelPort;
            target.ServerUserName = oridata.ChannelUid;
            target.ServerPwd = oridata.ChannelPsw;
            target.ChannelNo = oridata.ChannelNo;
            string platid = AssistTools.AnalyChannelNo(oridata.ChannelNo)?.FirstOrDefault();
            target.PlatID= !string.IsNullOrEmpty(platid)?int.Parse(platid):0;

            return target;
        }
    }
}
