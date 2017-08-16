using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_TemplateManagement.ViewModels;
using FACE_TemplateManagement.Services.HelpService;
using SING.Data.Help;
using SING.Data.DAL.ScheduleConvert;
using SING.Data.DAL.Data;
using newcode = SING.Data.DAL.NewCode;
using newcodedata = SING.Data.DAL.NewCode.Data;

namespace FACE_TemplateManagement.Services
{
    [Export(typeof(IDataService))]
    public class DataService : IDataService
    {
        public void SearchFtdb(ViewModel viewModel)
        {
            SearchFtdbService service = new SearchFtdbService();
            service.DoWork(viewModel);
        }
        public void CreateFtdb(ViewModel viewModel)
        {
            FtdbService.Create(viewModel);
        }
        public void DeleteFtdb(ViewModel viewModel)
        {
            FtdbService.Delete(viewModel);
        }
        public void SaveFtdb(ViewModel viewModel)
        {
            FtdbService.Save(viewModel);
        }


        public void SearchFot(ViewModel viewModel)
        {
            SearchFotService service = new SearchFotService();
            service.DoWork(viewModel);
        }
        public void CreateFot(ViewModel viewModel)
        {
            FotService.CreateFot(viewModel);
        }

        public void SaveFot(ViewModel viewModel)
        {
            FotService.Save(viewModel);
        }

        public void DeleteFot(ViewModel viewModel)
        {
            FotService.Delete(viewModel);
        }
        
        public void SetMainFt(ViewModel viewModel, int ftIndex)
        {
            FotService.SetMainFt(viewModel, ftIndex);
        }

        public void RemoveFt(ViewModel viewModel, int ftIndex)
        {
            FotService.Remove(viewModel, ftIndex);
        }

        public void BatchDeleteFt(ViewModel viewModel)
        {
            FotService.BatchRemove(viewModel);
        }

        #region  接口测试
        public List<newcodedata.SysTypecodeData> QuerySysTypecodes()
        {
            SysTypecodeService service = new SysTypecodeService();
            return service.Query();
        }

        public List<newcodedata.FaceObjectData> QueryFaceObjects()
        {
            FaceObjectService service = new FaceObjectService();
            return service.Query();
        }

        public newcodedata.FaceObjectData InsertFaceObject()
        {
            FaceObjectService service = new FaceObjectService();
            return service.Insert();
        }
        public newcodedata.FaceObjectData UpdateFaceObject()
        {
            FaceObjectService service = new FaceObjectService();
            return service.Update();
        }

        public bool DeleteFaceObject()
        {
            FaceObjectService service = new FaceObjectService();
            return service.Delete();
        }

        public newcode.Pager<newcode.FaceTemplateDb, newcode.FaceTemplateDb> QueryAllTemplates()
        {
            TemplateService tp = new TemplateService();
            return tp.QueryAll();
        }

        public newcodedata.FaceTemplateDbData InsertTemplate()
        {
            TemplateService tp = new TemplateService();
            return tp.Insert();
        }

        public bool UpdateTemplate()
        {
            TemplateService tp = new TemplateService();
            return tp.Update();
        }
        public bool DeleteTemplate()
        {
            TemplateService tp = new TemplateService();
            return tp.Delete();
        }

        public List<newcodedata.FaceTemplateDbData> QueryTemplateDetail()
        {
            TemplateService tp = new TemplateService();
            return tp.QueryDetail();
        }
        #endregion
    }
}