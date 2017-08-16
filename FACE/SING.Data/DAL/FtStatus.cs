using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.DAL
{
    public enum FtStatus
    {
        /// <summary>
        /// 未修改
        /// </summary>
        Unchanged = 0,
        /// <summary>
        /// 新增
        /// </summary>
        Added = 1,
        /// <summary>
        /// 仅修改信息，未修改模板图片
        /// </summary>
        ModifiedOnlyInfo = 2,
        /// <summary>
        /// 修改
        /// </summary>
        Modified = 3,
        /// <summary>
        /// 移除
        /// </summary>
        Deleted = 4
    }
}
