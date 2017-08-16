using SING.Data.DAL.NewCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_DynamicComparison.Services.HelpService
{
  public interface ISysUserService
    {
        SysUser Login();
        void Logout();

    }
}
