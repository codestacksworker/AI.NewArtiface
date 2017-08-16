using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.DAL;
using SING.Data.DAL.Data;
using SING.Data.DAL.ScheduleConvert;
using SING.Data.Help;
using SING.Data.Logger;
using SING.Data.ScheduleProcess;

namespace FACE_TemplateManagement.Services.HelpService
{
    public class HelpMethod
    {
        public static List<FaceObjTempViewData> GetFots(QueryCondition qc)
        {
            List<FaceObjTempViewData> list = null;
            try
            {
                List<FaceObject> listobj = ScheduleGet.QueryFaceObj(qc);

                if (listobj == null || listobj.Count == 0) return list;

                for (int i = 0; i < listobj.Count; i++)
                {
                    FaceObjectData fod = FaceObjectData.ConvertToData(listobj[i]);

                    List<FaceTemplate> ListFt = FaceTemplate.QueryFaceTByObjID(fod.FTDBID, fod.Uuid);

                    List<FaceTemplateData> FtList = new List<FaceTemplateData>()
                    {
                        null,null,null,null,null
                    };

                    if (ListFt != null && ListFt.Count > 0)
                    {
                        for (int j = 0; j < ListFt.Count; j++)
                        {
                            FaceTemplateData ftd = FaceTemplateData.ConvertToData(ListFt[j]);

                            FtList[ftd.FtIndex] = ftd;
                        }
                    }

                    FaceObjTempViewData fot = DataConvert.ViewDataFromData(fod, FtList);

                    if (list == null) list = new List<FaceObjTempViewData>();

                    list.Add(fot);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("查询人脸模板信息异常：HelpMethod->GetFots", ex);
            }
            return list;
        }
        
    

    }

 

}
