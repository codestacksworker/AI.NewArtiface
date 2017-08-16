using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.DAL
{
    public enum StatusCode
    {
        True = 1, // 1为真，0为假
        Success = 0,
        Fail = -1,
        Exception = -2
    }
}
