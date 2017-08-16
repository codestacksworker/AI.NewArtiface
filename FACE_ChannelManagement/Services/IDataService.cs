using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_ChannelManagement.ViewModels;
using SING.Data.Controls.TreeControl.Models;
using SING.Data.Controls.VideoControl;
using SING.Data.DAL;
using SING.Data.DAL.Data;
using newcode = SING.Data.DAL.NewCode;
using newcodedata = SING.Data.DAL.NewCode.Data;

namespace FACE_ChannelManagement.Services
{
    public interface IDataService
    {

        void InitialChannel(ViewModel viewModel);

        void InitialRegions(ViewModel viewModel);

        //void AddRootRegion(ViewModel viewModel);

        Result AddRegion(DataItem item);

        Result EditRegion(DataItem item);

        Result DeleteRegion(DataItem item);

        Result AddChannel(DataItem item);

        Result EditChannel(DataItem item);

        Result DeleteChannel(DataItem item);

        Result DeleteChannel(int regionid);

        void InitializeContainer(ViewModel viewModel);

        void ChangeVideoSource(ViewModel viewModel);

        bool CloseStream(ViewModel viewModel);

        void SetSingleScreen(ViewModel viewModel);

        bool ChannelIsExist(string channelNo);

        ChannelData QueryChannel(string uuid);

        void Notice(ViewModel viewModel, string type, string id, DataItem item);

        #region  接口测试
        List<newcodedata.ChannelData> QueryChannels();
        newcodedata.ChannelData InsertChannel();
        newcodedata.ChannelData UpdateChannel();
        bool DeleteChannel();
        List<newcodedata.RegionsData> QueryRegionAndChannel();
        newcodedata.RegionsData InsertRegions();
        newcodedata.RegionsData UpdateRegions();
        bool DeleteRegions();
        #endregion
    }
}
