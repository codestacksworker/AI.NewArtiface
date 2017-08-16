using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_AlertRecord.Models;
using FACE_AlertRecord.ViewModels;

namespace FACE_AlertRecord.Services.HelpService
{
    public class AreaChannelService
    {
        public void AreaChannelData(ViewModel viewModel)
        {
            for (int i = 0; i < 5; i++)
            {
                AreaChannelData areaChannel = new AreaChannelData
                {
                    Area = "区域" +i.ToString(),
                    Describe = "描述i" + i.ToString(),
                };
                for (int j = 0; j < 3; j++)
                {
                    AreaChannelData areaChannelChild = new AreaChannelData
                    {
                        ChannelChild = "通道" + i.ToString(),
                        Describe = "描述j" + j.ToString(),
                    };
                    areaChannel.AreaChannelChildList.Add(areaChannelChild);
                }
                viewModel.AreaChannelList.Add(areaChannel);
            }
        }
    }
}
