using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;
using FACE_TemplateManagement.ViewModels;
using SING.Data.DAL;
using SING.Data.DAL.Data;
using SING.Data.DAL.ScheduleConvert;
using SING.Data.Help;
using SING.Data.Logger;
using SING.Infrastructure.DEncrypt;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using System.Text.RegularExpressions;
using SING.Infrastructure.Regexs;
using SING.Infrastructure.Helper;
using SING.Infrastructure;
using SING.Data.BaseTools;

namespace FACE_TemplateManagement.Services.HelpService
{
    public class FotService
    {
        public static void Save(ViewModel viewModel)
        {
            try
            {
                if (viewModel.CurrentFotEdit == null)
                {
                    CreateFot(viewModel);
                    return;
                }

                string flat = string.Empty;
                if (string.IsNullOrEmpty(viewModel.CurrentFotEdit.Name))
                {
                    flat += "姓名、";
                }

                if (string.IsNullOrEmpty(viewModel.CurrentFotEdit.BirthDate))
                {
                    flat += "出生日期、";
                }

                if (viewModel.CurrentFotEdit.Sst == 0)
                {
                    flat += "敏感等级、";
                }

                if (string.IsNullOrEmpty(viewModel.CurrentFotEdit.MainFtID))
                {
                    flat += "主照片、";
                }

                if (!string.IsNullOrEmpty(flat))
                {
                    MessageBoxHelper.Show("请填写必填项：【" + flat.TrimEnd('、') + "】", "提示");
                    return;
                }

                if (viewModel.CurrentFotEdit.IdType == 0 && !string.IsNullOrEmpty(viewModel.CurrentFotEdit.IdNumb))
                {
                    MessageBoxHelper.Show("请选择证件类型", "提示");
                    return;
                }
                if (viewModel.CurrentFotEdit.IdType==1 && !string.IsNullOrEmpty(viewModel.CurrentFotEdit.IdNumb) && !RegexHelper.IsIDCard(viewModel.CurrentFotEdit.IdNumb))
                {
                    MessageBoxHelper.Show(string.Format(ResHelper.GetValue(ResKeys.Error_IdNumb), viewModel.CurrentFotEdit.IdNumb), ResHelper.GetValue(ResKeys.Title_Info));
                   
                    return;
                }
                if (viewModel.CurrentFotEdit.IdType == 1 && !string.IsNullOrEmpty(viewModel.CurrentFotEdit.IdNumb) && !RegexHelper.IsMatchIdNumb(viewModel.CurrentFotEdit.IdNumb,viewModel.CurrentFotEdit.BirthDate))
                {
                    MessageBoxHelper.Show("出生日期与身份证号不匹配", "提示");
                    return;
                }

                if (viewModel.CurrentFotEdit.Temps != null)
                {
                    if (viewModel.CurrentFtdb.TemplateDbCapacity < (viewModel.CurrentFtdb.TemplateDbSize + viewModel.CurrentFotEdit.Temps.FindAll(temp => temp!=null && (FtStatus)temp.Deed == FtStatus.Added).Count))
                    {
                        flat += "模版数量已达到模版库容量上线，请在模版库容量内使用或扩充容量！";
                    }
                    if (!string.IsNullOrEmpty(flat))
                    {
                        viewModel.CurrentFotEdit = DataConvert.CopyViewData(viewModel.CurrentFot);
                        MessageBoxHelper.Show(flat, "提示");
                        return;
                    }
                }

                Result result = null;

                List<Result> list = new List<Result>();

                if (viewModel.CurrentFotEdit.Temps != null && viewModel.CurrentFotEdit.Temps.Count > 0)
                {
                    for (int i = 0; i < viewModel.CurrentFotEdit.Temps.Count; i++)
                    {
                        FaceTemplateData ft = viewModel.CurrentFotEdit.Temps[i];
                        if (ft == null) continue;

                        switch ((FtStatus)ft.Deed)
                        {
                            case FtStatus.Added:
                                ft.FtTime = DateTime.Now.DToString();
                                ft.ImgMd = ft.FtImage.Md532();
                                result = FaceTemplate.AddFaceT(FaceTemplateData.Convert(ft));
                                break;
                            case FtStatus.ModifiedOnlyInfo:
                                ft.FtTime = DateTime.Now.DToString();
                                result = FaceTemplate.ModFaceT(FaceTemplateData.Convert(ft));
                                break;
                            case FtStatus.Modified:
                                ft.FtTime = DateTime.Now.DToString();
                                ft.ImgMd = ft.FtImage.Md532();
                                result = FaceTemplate.ModFaceT(FaceTemplateData.Convert(ft));
                                break;
                            case FtStatus.Deleted:
                                result = FaceTemplate.DelFaceT(ft.FTDBID, ft.Uuid);
                                break;
                            default:
                                Logger.Info(string.Format("【Info】：模板没有行为，模板ID:{0}：【FotService】--> Save", ft.Uuid));
                                break;
                        }

                        list.Add(result);

                        if (result != null && result.ErrorCode != StatusCode.Success)
                        {
                            RecoverFt(list, viewModel.CurrentFotEdit, viewModel.CurrentFot);
                            break;
                        }
                    }
                }

                bool isAdd = false;
                if (result == null || result.ErrorCode == StatusCode.Success)
                {
                    if (viewModel.IsAddFot)
                    {
                        isAdd = true;
                        viewModel.CurrentFotEdit.TimeStamp = DateTime.Now.DToString();
                        result = FaceObject.AddFaceObj(DataConvert.BaseFromViewData(viewModel.CurrentFotEdit));
                    }
                    else
                    {
                        result = FaceObject.ModFaceObj(DataConvert.BaseFromViewData(viewModel.CurrentFotEdit));
                    }

                    if (result != null && result.ErrorCode == StatusCode.Success)
                    {
                        if (isAdd)
                        {
                            if (viewModel.FotList == null) viewModel.FotList = new List<FaceObjTempViewData>();

                            if (viewModel.CurrentFotEdit.Temp != null && viewModel.CurrentFotEdit.Temps != null)
                            {
                                viewModel.CurrentFotEdit.Temp.Deed = (int) FtStatus.Unchanged;
                                for (int i = 0; i < viewModel.CurrentFotEdit.Temps.Count; i++)
                                {
                                    if (viewModel.CurrentFotEdit.Temps[i] == null) continue;
                                    viewModel.CurrentFotEdit.Temps[i].Deed = (int)FtStatus.Unchanged;
                                }
                            }
                            FaceObjTempViewData fot = DataConvert.CopyViewData(viewModel.CurrentFotEdit);
                            viewModel.FotList.Add(fot);

                            if (viewModel.FotCV == null)
                            {
                                viewModel.FotCV = new ListCollectionView(viewModel.FotList);
                                viewModel.FotCV.CurrentChanged += new EventHandler(viewModel.FotSelectedItemChanged);
                                viewModel.FotCV.MoveCurrentTo(fot);
                                viewModel.GetFotCurrentItem();
                            }
                            else
                            {
                                viewModel.FotCV.Refresh();
                                viewModel.FotCV.MoveCurrentTo(fot);
                            }
                        }
                        else
                        {
                            if (viewModel.CurrentFotEdit.Temp != null && viewModel.CurrentFotEdit.Temps != null)
                            {
                                viewModel.CurrentFotEdit.Temp.Deed = (int)FtStatus.Unchanged;
                                for (int i = viewModel.CurrentFotEdit.Temps.Count - 1; i >= 0; i--)
                                {
                                    if (viewModel.CurrentFotEdit.Temps[i] == null) continue;
                                    if (viewModel.CurrentFotEdit.Temps[i].Deed == (int) FtStatus.Deleted)
                                    {
                                       // viewModel.CurrentFotEdit.Temps.RemoveAt(i);
                                        viewModel.CurrentFotEdit.Temps[i] = null;//BUG 770
                                        continue;
                                    }
                                    viewModel.CurrentFotEdit.Temps[i].Deed = (int) FtStatus.Unchanged;
                                }
                            }
                            
                            FaceObjTempViewData.DeepCopyValue(viewModel.CurrentFotEdit, viewModel.CurrentFot);
                        }
                        viewModel.IsAddFot = false;
                        FtdbService.UpdateFtdb(viewModel);
                        MessageBoxHelper.Show("保存成功！", "提示",  MessageBoxImage.Information);
                    }
                    else
                    {
                        RecoverFt(list, viewModel.CurrentFotEdit, viewModel.CurrentFot);
                        viewModel.CurrentFotEdit = DataConvert.CopyViewData(viewModel.CurrentFot);
                        MessageBoxHelper.Show("保存失败！", "提示");
                    }
                }
                else
                {
                    CopyLocalFt(viewModel.CurrentFotEdit, viewModel.CurrentFot);
                    MessageBoxHelper.Show("保存失败！", "提示");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("【Error】：保存异常：【FotService】-->Save", ex);
                MessageBoxHelper.Show("保存失败！", "提示");
            }
        }

        public static void CreateFot(ViewModel viewModel)
        {
            if (viewModel.CurrentFtdb == null)
            {
                MessageBoxHelper.Show("请您先选择模板库，【新建】", "提示");
                return;
            }

            viewModel.CurrentFotEdit = new FaceObjTempViewData();
            viewModel.CurrentFotEdit.FTDBID = viewModel.CurrentFtdb.ID;
            viewModel.CurrentFotEdit.Uuid = Guid.NewGuid().ToString();
            viewModel.CurrentFotEdit.Temps = new List<FaceTemplateData>() { null, null, null, null, null };
            viewModel.IsAddFot = true;
        }

        public static void Delete(ViewModel viewModel)
        {
            try
            {
                MessageBoxResult resultBox = MessageBoxHelper.confirm("是否删除当前目标人？", "提示");

                if (resultBox != MessageBoxResult.Yes) return;

                if (viewModel.CurrentFot == null)
                {
                    MessageBoxHelper.Show("请您选择要删除的模板，【删除】", "提示");
                }

                Result result = null;
                List<Result> list = new List<Result>();
                if (viewModel.CurrentFot.Temps != null && viewModel.CurrentFot.Temps.Count > 0)
                {
                    for (int i = 0; i < viewModel.CurrentFot.Temps.Count; i++)
                    {
                        FaceTemplateData ft = viewModel.CurrentFot.Temps[i];
                        if (ft == null) continue;
                        ft.Deed = (int)FtStatus.Deleted;
                        result = FaceTemplate.DelFaceT(ft.FTDBID, ft.Uuid);

                        list.Add(result);

                        if (result.ErrorCode != StatusCode.Success)
                        {
                            RecoverFt(list, viewModel.CurrentFot);
                            break;
                        }
                    }
                }

                if (result == null || result.ErrorCode == StatusCode.Success)
                {
                    result = FaceObject.DelFaceObj(viewModel.CurrentFot.FTDBID, viewModel.CurrentFot.Uuid);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        viewModel.FotList.RemoveAll(p => p.Uuid.Equals(viewModel.CurrentFot.Uuid));
                        viewModel.FotCV.Refresh();
                        FtdbService.UpdateFtdb(viewModel);
                        MessageBoxHelper.Show("删除成功！", "提示",  MessageBoxImage.Information);
                    }
                    else
                    {
                        RecoverFt(list, viewModel.CurrentFot);
                        viewModel.CurrentFotEdit = DataConvert.CopyViewData(viewModel.CurrentFot);
                        MessageBoxHelper.Show("删除失败！", "提示");
                    }
                }
                else
                {
                    CopyLocalFt(viewModel.CurrentFotEdit, viewModel.CurrentFot);
                    MessageBoxHelper.Show("删除失败！", "提示");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("【Error】：删除失败：【FotService】-->Delete", ex);
                MessageBoxHelper.Show("删除失败！", "提示");
            }
        }

        private static void CopyLocalFt(FaceObjTempViewData data,FaceObjTempViewData oradata)
        {
            data.Temps = FaceObjTempViewData.CopyTemps(oradata.Temps);
            data.Temp = oradata.Temp != null ? FaceTemplateData.CopyData(oradata.Temp) : null;
            data.MainFtID = oradata.MainFtID;
        }



        private static void RecoverFt(List<Result> list, FaceObjTempViewData CurrentFotEdit, FaceObjTempViewData CurrentFot)
        {
            try
            {
                Result result = null;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == null) continue;

                    if (list[i].ErrorCode == StatusCode.Success)
                    {
                        FaceTemplateData ft = CurrentFotEdit.Temps[i];
                        if (ft == null) continue;
                        switch ((FtStatus)ft.Deed)
                        {
                            case FtStatus.Added:
                                result = FaceTemplate.DelFaceT(ft.FTDBID, ft.Uuid);
                                break;
                            case FtStatus.ModifiedOnlyInfo:
                                FaceTemplateData orFt1 = CurrentFot.Temps[ft.FtIndex];
                                result = FaceTemplate.ModFaceT(FaceTemplateData.Convert(orFt1));
                                break;
                            case FtStatus.Modified:
                                FaceTemplateData orFt2 = CurrentFot.Temps[ft.FtIndex];
                                result = FaceTemplate.ModFaceT(FaceTemplateData.Convert(orFt2));
                                break;
                            case FtStatus.Deleted:
                                FaceTemplateData orFt3 = CurrentFot.Temps[ft.FtIndex];
                                result = FaceTemplate.AddFaceT(FaceTemplateData.Convert(orFt3));
                                break;
                        }


                        if (result.ErrorCode != StatusCode.Success)
                        {
                            Logger.Info(string.Format("【Info】：恢复模板数据失败，模板ID:{0}：【FotService】--> RecoverFt", ft.Uuid));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("【Error】：恢复模板数据失败：【FotService】-->RecoverFt", ex);
            }
        }

        private static void RecoverFt(List<Result> list, FaceObjTempViewData CurrentFot)
        {
            try
            {
                Result result = null;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == null) continue;

                    if (list[i].ErrorCode == StatusCode.Success)
                    {
                        FaceTemplateData ft = CurrentFot.Temps[i];

                        if (ft == null) continue;

                        result = FaceTemplate.AddFaceT(FaceTemplateData.Convert(ft));

                        if (result.ErrorCode != StatusCode.Success)
                        {
                            Logger.Info(string.Format("【Info】：恢复模板数据失败，模板ID:{0}：【FotService】--> RecoverFt", ft.Uuid));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("【Error】：恢复模板数据失败：【FotService】-->RecoverFt", ex);
                //MessageBoxHelper.Show("恢复模板数据失败！", "提示");
            }
        }

        public static void SetMainFt(ViewModel viewModel, int ftIndex)
        {
            if (viewModel.CurrentFotEdit == null || viewModel.CurrentFotEdit.Temps == null) return;

            try
            {
                FaceTemplateData ftd = viewModel.CurrentFotEdit.Temps.Find(p => p != null && p.FtIndex == ftIndex);

                if (ftd == null)
                {
                  // ftd = viewModel.CurrentFotEdit.Temps.OrderBy(p => p.FtIndex).FirstOrDefault();
                }

                if (ftd != null)
                {
                    viewModel.CurrentFotEdit.MainFtID = ftd.Uuid;

                    viewModel.CurrentFotEdit.Temp = FaceTemplateData.CopyData(ftd);
                }
                else
                {
                    viewModel.CurrentFotEdit.MainFtID = null;
                    viewModel.CurrentFotEdit.Temp = null;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("【Error】：设置主模板照片异常：【FotService】-->SetMainFt", ex);
            }
        }

        public static void Remove(ViewModel viewModel, int ftIndex)
        {
            try
            {
                if (viewModel.CurrentFotEdit == null || viewModel.CurrentFotEdit.Temps == null) return;

                for (int i = viewModel.CurrentFotEdit.Temps.Count - 1; i >= 0; i--)
                {
                    FaceTemplateData ft = viewModel.CurrentFotEdit.Temps[i];

                    if (ft == null) continue;

                    if (ft.FtIndex == ftIndex)
                    {
                        if (viewModel.CurrentFotEdit.MainFtID == ft.Uuid)
                        {
                            MessageBoxHelper.Show("不能移除主模板！", "提示",  MessageBoxImage.Information);
                            return;
                        }

                        if (viewModel.CurrentFot.Temps != null && viewModel.CurrentFot.Temps.Count > 0)
                        {
                            int index = viewModel.CurrentFot.Temps.FindIndex(p => p != null && p.Uuid == ft.Uuid);

                            if (index != -1)
                            {
                                ft.Deed = (int)FtStatus.Deleted;
                                ft.FtImgTime = string.Empty;
                            }
                            else
                            {
                                //viewModel.CurrentFotEdit.Temps.RemoveAt(i);
                                viewModel.CurrentFotEdit.Temps[i] = null;
                            }
                        }
                        else
                        {
                            //viewModel.CurrentFotEdit.Temps.RemoveAt(i);
                            viewModel.CurrentFotEdit.Temps[i] = null;
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            { 
                Logger.Error("【Error】：移除模板照片异常：【FotService】-->Remove", ex);
                MessageBoxHelper.Show("移除模板照片失败！", "提示");
            }
        }

        public static void BatchRemove(ViewModel viewModel)
        {
            try
            {
                MessageBoxResult resultBox = MessageBoxHelper.confirm("是否移除当前所有非主模板？", "提示");

                if (resultBox != MessageBoxResult.Yes) return;

                if (viewModel.CurrentFotEdit == null || viewModel.CurrentFotEdit.Temps == null) return;

                for (int i = viewModel.CurrentFotEdit.Temps.Count - 1; i >= 0; i--)
                {
                    FaceTemplateData ft = viewModel.CurrentFotEdit.Temps[i];

                    if (ft == null) continue;

                    if (viewModel.CurrentFotEdit.MainFtID == ft.Uuid) continue;

                    if (viewModel.CurrentFot.Temps != null && viewModel.CurrentFot.Temps.Count > 0)
                    {
                        int index = viewModel.CurrentFot.Temps.FindIndex(p => p != null && p.Uuid == ft.Uuid);

                        if (index != -1)
                        {
                            ft.Deed = (int) FtStatus.Deleted;
                        }
                        else
                        {
                            //viewModel.CurrentFotEdit.Temps.RemoveAt(i);
                            viewModel.CurrentFotEdit.Temps[i] = null;
                        }
                    }
                    else
                    {
                        //viewModel.CurrentFotEdit.Temps.RemoveAt(i);
                        viewModel.CurrentFotEdit.Temps[i] = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("【Error】：批量移除模板照片异常：【FotService】-->BatchRemove", ex);
                MessageBoxHelper.Show("批量移除模板照片失败！", "提示");
            }
        }
    }
}
