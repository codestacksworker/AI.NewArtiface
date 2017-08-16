using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_ChannelManagement.Enum;
using SING.Data.Controls.TreeControl.Models;

namespace FACE_ChannelManagement.Models
{
    public class OperationInfo
    {
        public OperationType Type { get; set; }
        public string Id { get; set; }
        public DataItem Item { get; set; }
    }
}
