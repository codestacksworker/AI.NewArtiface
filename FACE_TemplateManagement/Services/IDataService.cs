using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_TemplateManagement.ViewModels;
using SING.Data.Help;
using SING.Data.DAL.NewCode.Data;
using SING.Data.DAL.NewCode;

namespace FACE_TemplateManagement.Services
{
    public interface IDataService
    {
        void SearchFtdb(ViewModel viewModel);
        void CreateFtdb(ViewModel viewModel);
        void DeleteFtdb(ViewModel viewModel);
        void SaveFtdb(ViewModel viewModel);

        void SearchFot(ViewModel viewModel);
        void CreateFot(ViewModel viewModel);
        void DeleteFot(ViewModel viewModel);
        void SaveFot(ViewModel viewModel);

        void SetMainFt(ViewModel viewModel, int ftIndex);
        void RemoveFt(ViewModel viewModel, int ftIndex);
        void BatchDeleteFt(ViewModel viewModel);

        #region 接口测试
        List<SysTypecodeData> QuerySysTypecodes();
        List<FaceObjectData> QueryFaceObjects();
        FaceObjectData InsertFaceObject();
        FaceObjectData UpdateFaceObject();
        bool DeleteFaceObject();
        Pager<FaceTemplateDb,FaceTemplateDb> QueryAllTemplates();
        FaceTemplateDbData InsertTemplate();
        bool UpdateTemplate();
        bool DeleteTemplate();
        List<FaceTemplateDbData> QueryTemplateDetail();
        #endregion
    }
}