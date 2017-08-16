using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dev_SING.Data.BaseTools;
using SING.Data.DAL.NewCode;
using SING.Data.DAL.NewCode.Data;

namespace FACE_TemplateManagement.Services.HelpService
{
    public class TemplateService
    {
        public Pager<FaceTemplateDb,FaceTemplateDb> QueryAll()
        {
            Pager<FaceTemplateDb> pager = new Pager<FaceTemplateDb>
            {
                PageNo=1,
                PageRows=20
            };
            FaceTemplateDb db = new FaceTemplateDb();
            var result= db.QueryAll(pager);
            return result;
        }

        public FaceTemplateDbData Insert()
        {
            FaceTemplateDbData data = new FaceTemplateDbData
            {
               TemplateDbName="目标库1",
               TemplateDbDescription="测试",
               TemplateDbType=1,
               IsUsed=1,
               TemplateDbSize=10,
               TemplateDbCapacity=1000
            };
            FaceTemplateDb obj = data.ToData<FaceTemplateDb>();
            var result = obj.Insert().ToUIData<FaceTemplateDbData>();
            return result;
        }

        public bool Update()
        {
            FaceTemplateDbData data = new FaceTemplateDbData
            {
                TemplateDbName = "目标库1",
                TemplateDbDescription = "测试",
                TemplateDbType = 1,
                IsUsed = 1,
                TemplateDbSize = 10,
                TemplateDbCapacity = 1000
            };
            FaceTemplateDb obj = data.ToData<FaceTemplateDb>();
            var result = obj.Update();
            return result;
        }

        public bool Delete()
        {
            string[] idarr = { "110108196608166316", "120101193010291546" };
            FaceTemplateDb obj = new FaceTemplateDb();
            var result = obj.Delete(idarr);
            return result;
        }

        public List<FaceTemplateDbData> QueryDetail()
        {
            Pager<FaceTemplateDb> pager = new Pager<FaceTemplateDb>
            {
                PageNo=1,
                PageRows=20
            };
            FaceTemplateDb obj = new FaceTemplateDb();
            var list = obj.QueryDetail(pager);
            List<FaceTemplateDbData> result = new List<FaceTemplateDbData>();
            list.ResultList.ForEach(f=>result.Add(f.ToUIData<FaceTemplateDbData>()));
            return result;
        }
    }
}
