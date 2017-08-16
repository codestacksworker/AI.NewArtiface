using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using FACE_TemplateManagement.ViewModels;
using SING.Data.DAL;
using SING.Data.DAL.Data;
using SING.Data.DAL.ScheduleConvert;
using SING.Data.Help;
using SING.Data.Logger;
using SING.Infrastructure;
using SING.Data.BaseTools;

namespace FACE_TemplateManagement.Services.HelpService
{
    public static class FtdbService
    {
        public static void Save(ViewModel viewModel)
        {
            try
            {
                if (viewModel.CurrentFtdbEdit == null)
                {
                    MessageBoxResult boxResult = MessageBoxHelper.confirm("请问确认要新建模版库吗？", "提示");

                    if (boxResult == MessageBoxResult.No) return;

                    Create(viewModel);

                    return;
                }

                viewModel.CurrentFtdbEdit.CreateTime = DateTime.Now.DToString();

                Result result = null;

                if (viewModel.CurrentFtdbEdit.ID == 0)
                {
                    result = FaceTemplateDB.AddTDB(FaceTemplateDBData.Convert(viewModel.CurrentFtdbEdit));

                    if (result.ErrorCode == StatusCode.Success)
                    {
                        viewModel.CurrentFtdbEdit.ID = result.ID;

                        if (viewModel.FtdbList == null) viewModel.FtdbList = new List<FaceTemplateDBData>();
                        FaceTemplateDBData ftdb = DataConvert.CopyData(viewModel.CurrentFtdbEdit);
                        viewModel.FtdbList.Add(ftdb);

                        if (viewModel.FtdbCV == null)
                        {
                            viewModel.FtdbCV = new ListCollectionView(viewModel.FtdbList);
                            viewModel.FtdbCV.CurrentChanged += new EventHandler(viewModel.FtdbSelectedItemChanged);
                            viewModel.GetFtdbCurrentItem();
                        }
                        else
                        {
                            viewModel.FtdbCV.Refresh();
                            viewModel.FtdbCV.MoveCurrentTo(ftdb);
                        }
                    }
                }
                else
                {
                    result = FaceTemplateDB.ModTDB(FaceTemplateDBData.Convert(viewModel.CurrentFtdbEdit));
                    FaceTemplateDBData.CopyValue(viewModel.CurrentFtdbEdit, viewModel.CurrentFtdb);
                }

                if (result.ErrorCode == StatusCode.Success)
                {
                    SyncService.PublishModuleSync(viewModel.CurrentFtdb);
                    MessageBoxHelper.Show("保存成功！", "提示", MessageBoxImage.Information);
                }
                else
                {
                    MessageBoxHelper.Show("保存失败！", "提示", MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("【Error】：保存模版库异常：【FtdbService】-->Save", ex);
                MessageBoxHelper.Show("保存失败！", "提示", MessageBoxImage.Warning);
            }
        }

        public static void Create(ViewModel viewModel)
        {
            viewModel.CurrentFtdbEdit = new FaceTemplateDBData();
            viewModel.CurrentFtdbEdit.IsUsed = 1;
        }

        public static void Delete(ViewModel viewModel)
        {
            try
            {
                if (viewModel.CurrentFtdb == null || viewModel.CurrentFtdb.ID == 0)
                {
                    MessageBoxHelper.Show("请您选择要删除的模版库，【删除】", "提示");
                    return;
                }

                if (MessageBoxHelper.confirm("确认删除？", "提示") == MessageBoxResult.Yes)
                {

                    int pos = viewModel.FtdbCV.CurrentPosition; 

                    Result result = FaceTemplateDB.DelTDB(viewModel.CurrentFtdb.ID);

                    if (result.ErrorCode == StatusCode.Success)
                    {
                        viewModel.FtdbList.RemoveAll(p => p.ID == viewModel.CurrentFtdb.ID);

                        if (pos == viewModel.FtdbList.Count) pos -= 1;

                        viewModel.FtdbCV = new ListCollectionView(viewModel.FtdbList);
                        viewModel.FtdbCV.CurrentChanged += new EventHandler(viewModel.FtdbSelectedItemChanged);
                        viewModel.GetFtdbCurrentItem();
                        viewModel.FtdbCV.MoveCurrentToPosition(pos);

                        SyncService.PublishModuleSync(viewModel.FtdbList);
                        MessageBoxHelper.Show("删除成功！", "提示", MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBoxHelper.Show("删除失败！", "提示", MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("【Error】：删除模版库异常：【FtdbService】-->Save", ex);
                MessageBoxHelper.Show("删除失败！", "提示", MessageBoxImage.Warning);
            }
        }

        public static void UpdateFtdb(ViewModel viewModel)
        {
            if (viewModel.CurrentFtdb != null)
            {
                FaceTemplateDB ftdb = FaceTemplateDB.QueryTDBByID(viewModel.CurrentFtdb.ID);
                if (ftdb != null)
                {
                    var item = FaceTemplateDBData.ConvertToData(ftdb);
                    FaceTemplateDBData.CopyValue(item, viewModel.CurrentFtdb);
                    SyncService.PublishModuleSync(item);
                }
            }
        }
    }
}
