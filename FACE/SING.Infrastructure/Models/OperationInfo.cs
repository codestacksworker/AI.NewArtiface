using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.Controls.TreeControl.Models;
using SING.Infrastructure.Enums;

namespace SING.Infrastructure.Models
{
    public class OperationInfo
    {
        public OperationTypeEnum Type { get; set; }
        public string Id { get; set; }
        public DataItem Item { get; set; }
    }
}
