using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.Help;

namespace SING.Data.DAL.ScheduleConvert
{
    public class ParameterConvert
    {
        public static FaceTempDbRelation TDBRelationFromCondition(QueryCondition oradata)
        {
            FaceTempDbRelation data = new FaceTempDbRelation();

            #region

            data.StartTime = TimeConvert.Convert(oradata.StartTime);
            data.EndTime = TimeConvert.Convert(oradata.EndTime);
            data.TemplateDbName = oradata.TemplateDbName;
            data.IsUsed = oradata.IsUsed;
            data.TemplateDbDescription = oradata.TemplateDbDescription;

            #endregion

            return data;
        }

        public static FaceTempRelation FaceTRelationFromPara(int ftdbid, int startNum, int count)
        {
            FaceTempRelation data = new FaceTempRelation();

            #region

            data.FTDBID = ftdbid;
            data.StartNum = startNum;
            data.Count = count;

            #endregion

            return data;
        }

        public static CapParameter CapParaFromPara(string fcapid, long fcaptime)
        {
            CapParameter data = new CapParameter();

            #region

            data.Fcapid = fcapid;
            data.Fcaptime = fcaptime;

            #endregion

            return data;
        }

        public static FaceTempRelation FaceTRelationFromPara(int ftdbid, string uuid = null, string objId = null)
        {
            FaceTempRelation data = new FaceTempRelation();

            #region

            data.FTDBID = ftdbid;
            data.Uuid = uuid;
            data.ObjId = objId;

            #endregion

            return data;
        }

        public static FaceObjRelation FaceObjRelationFromPara(int ftdbid, string uuid = null, int startNum = 0, int count = 0)
        {
            FaceObjRelation data = new FaceObjRelation();

            #region

            data.FTDBID = ftdbid;
            data.Uuid = uuid;
            data.StartNum = startNum;
            data.Count = count;

            #endregion

            return data;
        }

        public static FaceObjRelation FaceObjRelationFromCondition(QueryCondition oradata)
        {
            FaceObjRelation data = new FaceObjRelation();

            #region

            data.FTDBID = oradata.TDBID;
            data.Name = oradata.Name;
            data.Type = oradata.Type;
            data.Sst = oradata.Sst;
            data.Sex = oradata.Sex;
            data.IdType = oradata.IdType;
            data.IdNumb = oradata.IdNumb;
            data.StartBirthDate = oradata.StartBirthDate.SToShortDateLong();
            data.EndBirthDate = oradata.EndBirthDate.SToShortDateLong();
            data.Addr = oradata.Addr;
            data.Ethnic = oradata.Ethnic;
            data.StartTime = oradata.StartTime.SToLong();
            data.EndTime = oradata.EndTime.SToLong();
            data.Tag = oradata.Tag;
            data.Remarks = oradata.Remarks;
            data.StartNum = oradata.StartNum;
            data.Count = oradata.Count;
            data.IsOrder = oradata.IsOrder;
            data.OrderCol = oradata.OrderCol;

            #endregion

            return data;
        }

        public static CapRecordParameter CapRecordParaFromCondition(QueryConditionCapRecord oradata)
        {
            CapRecordParameter data = new CapRecordParameter();

            #region

            data.ChannelId = oradata.ChannelId;
            data.StartTime = TimeConvert.Convert(oradata.StartTime);
            data.EndTime = TimeConvert.Convert(oradata.EndTime);
            data.FcapType = oradata.FcapType;
            data.StartNum = oradata.StartNum;
            data.Count = oradata.Count;
            data.RegionId = oradata.RegionId;
            data.FcapId = oradata.FcapId;
            data.IsOrder = oradata.IsOrder;
            data.OrderCol = oradata.OrderCol;

            #endregion

            return data;
        }

        public static CmpRecordParameter CmpRecordParaFromCondition(QueryConditionCmpRecord oradata)
        {
            CmpRecordParameter data = new CmpRecordParameter();

            #region

            data.TDBID = oradata.TDBID;
            data.Uuid = oradata.Uuid;
            data.ChannelId = oradata.ChannelId;
            data.FcmpFobjName = oradata.FcmpFobjName;
            data.FcmpFobjType = oradata.FcmpFobjType;
            data.FcmpType = oradata.FcmpType;
            data.FcmpFobjSex = oradata.FcmpFobjSex;
            data.Sst = oradata.Sst;
            data.StartTime = TimeConvert.Convert(oradata.StartTime);
            data.EndTime = TimeConvert.Convert(oradata.EndTime);
            //data.Top = oradata.Top;
            data.IsRepeat = oradata.IsRepeat;
            data.FcmpSocre = oradata.FcmpSocre;
            data.Tag = oradata.Tag;
            data.StartNum = oradata.StartNum;
            data.Count = oradata.Count;
            data.IsOrder = oradata.IsOrder;
            data.OrderCol = oradata.OrderCol;
            //data.RegionId = oradata.RegionId;
            data.IdNumb = oradata.IdNumb;
            data.IdType = oradata.IdType;

            #endregion

            return data;
        }

        public static ChannelParameter ChannelParameterFromPara(int regionId, int startNum = 0, int count = 0)
        {
            ChannelParameter data = new ChannelParameter();

            #region
            data.RegionId = regionId;
            data.StartNum = startNum;
            data.Count = count;

            #endregion

            return data;
        }

        public static RegionsParameter RegionsParameterFromPara(int id = 0, bool delChannel = true)
        {
            RegionsParameter data = new RegionsParameter();

            #region

            data.id = id;
            data.delChannel = delChannel;

            #endregion

            return data;
        }

        public static FaceTagsParameter FaceTagsParameterFromPara(int tagId, string objId)
        {
            FaceTagsParameter data = new FaceTagsParameter();

            #region

            data.TagId = tagId;
            data.ObjId = objId;

            #endregion

            return data;
        }

        public static AlertParameter AlertParameterFromQc(QueryConditionAlertRecord qc)
        {
            AlertParameter data = new AlertParameter();

            #region

            data.Uuid = qc.Uuid;
            data.ChannelId = qc.ChannelId;
            data.FtdbId = qc.FtdbId;
            data.FcapStartTime = qc.FcapStartTime.SToLong();
            data.FcapEndTime = qc.FcapEndTime.SToLong();
            data.AckStat = qc.AckStat;
            data.PubStat = qc.PubStat;
            data.KeyWords = qc.KeyWords;
            data.StartNum = qc.StartNum;
            data.Count = qc.Count;

            #endregion

            return data;
        }

        public static AlertOpParameter AlertOpParameterFromPara(string uuid, string oper, int stat, long timeStamp, bool force)
        {
            AlertOpParameter data = new AlertOpParameter();

            #region

            data.Uuid = uuid;
            data.Oper = oper;
            data.Stat = stat;
            data.TimeStamp = timeStamp;
            data.Force = force;

            #endregion

            return data;
        }
    }
}
