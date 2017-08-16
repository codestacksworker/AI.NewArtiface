using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dev_SING.Data.BaseTools;
using SING.Data.DAL.NewCode;
using SING.Data.DAL.NewCode.Data;
using SING.Data.DAL.NewCode.Condition;

namespace FACE_TemplateManagement.Services.HelpService
{
    public class FaceObjectService
    {
        public List<FaceObjectData> Query()
        {
            try
            {
                Pager<FaceObjectCondition> pager = new Pager<FaceObjectCondition>();
                pager.PageNo = 1;
                pager.PageRows = 20;
                pager.Condition = new FaceObjectCondition {
                    Name="",
                    IdType=1,
                    IdNumb="",
                    Sex=1
                };

                FaceObject obj = new FaceObject();
                Pager<FaceObjectCondition, FaceObject> p = obj.Query(pager);
                if (p == null && p.ResultList == null)
                    return null;

                List<FaceObjectData> result = new List<FaceObjectData>();
                p.ResultList.ForEach(f => { result.Add(f.ToUIData<FaceObjectData>()); });
                return result;
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public FaceObjectData Insert()
        {
            FaceObjectData data = new FaceObjectData
            {
                Name = "测试",
                Sex = 1,
                Ethnic = "汉",
                IdType = 1,
                IdNumb = "3123123131321",
                Sst = 1,
                Remarks = "备注",
                BirthDateStr = "1984-12-31",
                Addr = "dsfsdfds",
                Tags = "工程师",
                FtdbId = 10,
                MainFtid = "rw4234345dsfs463"
            };
            FaceObject obj = data.ToData<FaceObject>();
            var result = obj.Insert().ToUIData<FaceObjectData>();
            return result;
        }

        public FaceObjectData Update()
        {
            FaceObjectData data = new FaceObjectData
            {
                Uuid = AssistTools.GuidN,
                Name = "测试",
                Sex = 1,
                Ethnic = "汉",
                IdType = 1,
                IdNumb = "3123123131321",
                Sst = 1,
                Remarks = "备注",
                BirthDateStr = "1984-12-31",
                Addr = "dsfsdfds",
                Tags = "工程师",
                FtdbId = 10,
                MainFtid = AssistTools.GuidN,
            };
            FaceObject obj = data.ToData<FaceObject>();
            var result = obj.Update().ToUIData<FaceObjectData>();
            return result;
        }

        public bool Delete()
        {
            string[] idarr = { "110108196608166316", "120101193010291546" };
            FaceObject obj = new FaceObject();
            var result = obj.Delete(idarr);
            return result;
        }
    }
}
