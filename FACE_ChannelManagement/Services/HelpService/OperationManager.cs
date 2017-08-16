using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_ChannelManagement.Enum;
using FACE_ChannelManagement.Models;
using FACE_ChannelManagement.ViewModels;
using SING.Infrastructure.Events;
using SING.Data.Controls.TreeControl.Models;
using SING.Infrastructure.Enums;
using SING.Infrastructure.Models;

namespace FACE_ChannelManagement.Services.HelpService
{
    public class OperationManager
    {
        public void Notice(ViewModel viewModel, string type, string id, DataItem item)
        {
            var data = ContractObj(type, id, item);
            viewModel.RaiseEvent(data);
        }


        private OperationInfo ContractObj(string type, string id, DataItem item=null)
        {
            OperationInfo result = new OperationInfo();
            switch (type)
            {
                case "添加区域":
                    result.Type = OperationTypeEnum.AddRegion;
                    break;
                case "添加子区域":
                    result.Type = OperationTypeEnum.AddChildRegion;
                    break;
                case "添加通道":
                    result.Type = OperationTypeEnum.AddChannel;
                    break;
                case "编辑":
                    result.Type = OperationTypeEnum.Edit;
                    break;
                case "删除":
                    result.Type = OperationTypeEnum.Delete;
                    break;
                default:
                    break;
            }
            result.Id = id;
            result.Item = item;

            return result;
        }
    }
}
