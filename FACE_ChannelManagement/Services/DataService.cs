using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_ChannelManagement.ViewModels;
using FACE_ChannelManagement.Services.HelpService;
using SING.Data.Controls.TreeControl.Models;
using SING.Data.DAL;
using SING.Data.DAL.Data;
using SING.Data.Controls.VideoControl;
using newcode = SING.Data.DAL.NewCode;
using newcodedata = SING.Data.DAL.NewCode.Data;


namespace FACE_ChannelManagement.Services
{
    [Export(typeof(IDataService))]
    public class DataService : IDataService
    {
        public void InitialChannel(ViewModel viewModel)
        {
            ChannelService service = new ChannelService();
            service.DoWork(viewModel);
        }

        public void InitialRegions(ViewModel viewModel)
        {
            RegionsService service = new RegionsService();
            service.DoWork(viewModel);
        }

        public void InitialVideoView(ViewModel viewModel)
        {
            VideoViewService service = new VideoViewService();
            service.DoWork(viewModel);
        }

        public Result AddRegion(DataItem item)
        {
            RegionsService service = new RegionsService();
            return service.AddRegion(item);
        }
        public Result EditRegion(DataItem item)
        {
            RegionsService service = new RegionsService();
            return service.EditRegion(item);
        }
        public Result DeleteRegion(DataItem item)
        {
            RegionsService service = new RegionsService();
            return service.DeleteRegionByID(item);
        }

        public Result AddChannel(DataItem item)
        {
            ChannelService service = new ChannelService();
            return service.AddChannel(item);
        }

        public Result EditChannel(DataItem item)
        {
            ChannelService service = new ChannelService();
            return service.EditChannel(item);
        }

        public Result DeleteChannel(DataItem item)
        {
            ChannelService service = new ChannelService();
            return service.DeleteChannel(item);
        }

        public Result DeleteChannel(int regionId)
        {
            return ChannelService.DeleteChannel(regionId);
        }

        public bool ChannelIsExist(string channelNo)
        {
            return ChannelService.ChannelIsExist(channelNo);
        }

        public ChannelData QueryChannel(string uuid)
        {
            return ChannelService.QueryChannel(uuid);
        }

        #region  视频预览
        public void InitializeContainer(ViewModel viewModel)
        {
            VideoViewService service = new VideoViewService();
            service.InitializeContainer(viewModel);
        }
        public void ChangeVideoSource(ViewModel viewModel)
        {
            VideoViewService service = new VideoViewService();
            service.ChangeVideoSource(viewModel);
        }
        public bool CloseStream(ViewModel viewModel)
        {
            VideoViewService service = new VideoViewService();
            return service.CloseStream(viewModel);
        }
        public void SetSingleScreen(ViewModel viewModel)
        {
            VideoViewService service = new VideoViewService();
            service.SetSingleScreen(viewModel);
        }
        #endregion

        public void Notice(ViewModel viewModel, string type, string id, DataItem item)
        {
            OperationManager manager = new OperationManager();
            manager.Notice(viewModel, type, id, item);
        }

        #region  接口测试
        public List<newcodedata.ChannelData> QueryChannels()
        {
            ChannelService service = new ChannelService();
            return service.Query();
        }

        public newcodedata.ChannelData InsertChannel()
        {
            ChannelService service = new ChannelService();
            return service.Insert();
        }

        public newcodedata.ChannelData UpdateChannel()
        {
            ChannelService service = new ChannelService();
            return service.Update();
        }

        public bool DeleteChannel()
        {
            ChannelService service = new ChannelService();
            return service.Delete();
        }

        public List<newcodedata.RegionsData> QueryRegionAndChannel()
        {
            RegionsService service = new RegionsService();
            return service.QueryRegionAndChannel();
        }

        public newcodedata.RegionsData InsertRegions()
        {
            RegionsService service = new RegionsService();
            return service.Insert();
        }

        public newcodedata.RegionsData UpdateRegions()
        {
            RegionsService service = new RegionsService();
            return service.Update();
        }

        public bool DeleteRegions()
        {
            RegionsService service = new RegionsService();
            return service.Delete();
        }
        #endregion
    }
}
