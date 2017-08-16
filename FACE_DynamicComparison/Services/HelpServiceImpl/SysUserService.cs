using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_DynamicComparison.Services.HelpService;
using SING.Data.DAL.NewCode;
using SING.Data.DAL.NewCode.Data;
using System.ComponentModel.Composition;

namespace FACE_DynamicComparison.Services.HelpServiceImpl
{
    [Export(typeof(HelpService.ISysUserService))]
    public class SysUserService : ISysUserService
    {
        public SysUser Login()
        {
            SysUserData data = new SysUserData
            {
                Ip = "192.168.1.120",
                UserName = "admin",
                PassWord = "123@456"
            };
            SysUser u = data.ToData<SysUser>(); ;
            SysUser user = u.Login();
            return user;
        }

        public void Logout()
        {
           
        }
    }
}
