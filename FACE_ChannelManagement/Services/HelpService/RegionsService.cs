using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_ChannelManagement.ViewModels;
using SING.Data.Logger;
using SING.Data.Controls.TreeControl.Models;
using System.Windows;
using FACE_ChannelManagement.Utilities;
using SING.Data.DAL;
using SING.Data.DAL.Data;
using newcode = SING.Data.DAL.NewCode;
using newcodedata = SING.Data.DAL.NewCode.Data;
using SING.Data.DAL.NewCode.Condition;

namespace FACE_ChannelManagement.Services.HelpService
{
    public class RegionsService
    {
        private ViewModel _viewmodel;
        private BackgroundWorker _work;

        public void DoWork(ViewModel viewmodel)
        {
            try
            {
                this._viewmodel = viewmodel;
                this._work = new BackgroundWorker();
                _work.WorkerReportsProgress = true;
                _work.WorkerSupportsCancellation = true;
                _work.DoWork += Do;
                _work.RunWorkerCompleted += RunWorkerCompleted;
                _work.ProgressChanged += ProgressChanged;
                _work.RunWorkerAsync();
            }
            catch (Exception err)
            {
                Logger.Error("ChannelService:通道启动查询异常", err);
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Do(object sender, DoWorkEventArgs e)
        {
            Search();
        }

        private void Search()
        {
            //GenerateTestData();
            DataEntry();
        }

        /// <summary>
        /// 设置通道管理数据源
        /// </summary>
        private void DataEntry()
        {
            var regions = Regions.ListAllRegion();
            var items = ConvertUIDate(regions);
            items?.ToList().ForEach((d) =>
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    this._viewmodel.TreeItems.Add(d);
                }));
            });
        }

        

        public Result AddRegion(DataItem item)
        {
            Regions region = RegionsData.Convert(item.Region);
            var result = Regions.AddRegion(region);
            return result;
        }

        public Result EditRegion(DataItem item)
        {
            Regions region = RegionsData.Convert(item.Region);
            var result = Regions.ModRegion(region);
            return result;
        }

        public Result DeleteRegionByID(DataItem item)
        {
            Regions region = RegionsData.Convert(item.Region);
            var result = Regions.DelRegionByID(region.ID, true);
            return result;
        }

        #region   数据处理
        List<DataItem> ConvertUIDate(List<Regions> regions)
        {
            List<DataItem> items = RecursionTree(regions);
            if (items == null || items.Count <= 0)
            {
                this._viewmodel.SetTreeMenuShowMode();
                return null;
            }
            GenerateTree(items);
            return items;
        }

        List<DataItem> RecursionTree(List<Regions> regions)
        {
            if (regions == null || regions.Count <= 0) return null;
            List<DataItem> result = new List<DataItem>();
            var Roots = regions.Where(r => r.ParentId == 0);

            foreach (var r in Roots)
            {
                var region = RegionsData.ConvertToData(r);

                var item = DataItem.Convert(region);

                result.Add(item);
            }

            GenerateTree(regions, result);

            return result;
        }

        void GenerateTree(List<Regions> regions, IEnumerable<DataItem> result)
        {
            foreach (var r in result)
            {
                var list = regions.Where(re => re.ParentId.ToString() == r.Id).ToList();
                if (list?.Count > 0)
                {
                    list.ForEach((it) =>
                    {
                        var region = RegionsData.ConvertToData(it);

                        var item = DataItem.Convert(region);

                        item.Parent = r;

                        r.Items.Add(item);
                    });
                    if (r != null && r.Items != null && r.Items.Count > 0)
                        GenerateTree(regions, r.Items);
                }
            }
        }

        void GenerateTree(IEnumerable<DataItem> result)
        {
            foreach (var r in result)
            {
                int id = 0;
                if (int.TryParse(r.Id, out id))
                {
                    var list = Channel.QueryChannel(id);
                    if (list?.Count > 0)
                    {
                        list.ForEach((it) =>
                        {
                            var region = ChannelData.ConvertToData(it);

                            var item = DataItem.Convert(region);

                            item.Parent = r;

                            r.Items.Add(item);
                        });
                    }
                }
                if (r != null && r.Items != null && r.Items.Count > 0)
                    GenerateTree(r.Items);
            }
        }
        #endregion

        #region  新接口测试
        public List<newcodedata.RegionsData> QueryRegionAndChannel()
        {
            newcode.Pager<RegionsCondition> pager = new SING.Data.DAL.NewCode.Pager<RegionsCondition> {
                PageNo=1,
                PageRows=20,
                Condition=new RegionsCondition {
                    RegionLevel="1"
                }
                //Condition=new System.Collections.Hashtable()
            };
            //pager.Condition.Add("regionLevel", "1");
            newcode.Regions region = new newcode.Regions();
            newcode.Pager<RegionsCondition,newcode.Regions> p= region.QueryRegionAndChannel(pager);
            List<newcodedata.RegionsData> result = new List<SING.Data.DAL.NewCode.Data.RegionsData>();
            List<newcode.Regions> regions = p.ResultList;
            regions.ForEach(r=> { result.Add(r.ToUIData<newcodedata.RegionsData>()); });
            return result;
        }

        public newcodedata.RegionsData Insert()
        {
            newcodedata.RegionsData data =new newcodedata.RegionsData
            {
               RegionName="区域1",
               RegionDescription="区域",
               ParentId=10,
               RegionLevel=2,
               RegionSort=1
            };
            newcode.Regions obj = data.ToData<newcode.Regions>();
            var result = obj.Insert().ToUIData<newcodedata.RegionsData>();
            return result;
        }

        public newcodedata.RegionsData Update()
        {
            newcodedata.RegionsData data = new newcodedata.RegionsData
            {
                RegionName = "区域1",
                RegionDescription = "区域",
                ParentId = 10,
                RegionLevel = 2,
                RegionSort = 1
            };
            newcode.Regions obj = data.ToData<newcode.Regions>();
            return obj.Update().ToUIData<newcodedata.RegionsData>();
        }

        public bool Delete()
        {
            string[] idarr = { "110108196608166316", "120101193010291546" };
            newcode.Regions obj = new newcode.Regions();
            var result = obj.Delete(idarr);
            return result;
        }
        #endregion
    }
}
