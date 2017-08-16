using SING.Data.Controls.TreeControl.Models;
using SING.Data.DAL;
using SING.Data.DAL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FACE_DynamicComparison.Services.HelpServiceImpl
{
    [Export(typeof(HelpService.IRegionService))]
    public class RegionService:SearchServiceBase,HelpService.IRegionService
    {
        public override void Search()
        {
            
            var regions = Regions.ListAllRegion();
            var items = ConvertUIDate(regions);
            items?.ToList().ForEach((d) =>
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    this.VM.TreeItems.Add(d);
                }));
            });
        }


        #region   数据处理
        List<DataItem> ConvertUIDate(List<Regions> regions)
        {
            List<DataItem> items = RecursionTree(regions);
            if (items == null || items.Count <= 0)
            {
                //this._viewmodel.SetTreeMenuShowMode();
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
    }
}
