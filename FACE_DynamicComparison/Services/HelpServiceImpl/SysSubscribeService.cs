using SING.Data.DAL.NewCode;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_DynamicComparison.Services.HelpServiceImpl
{
    [Export(typeof(HelpService.ISysSubscribeService))]
    public  class SysSubscribeService:HelpService.ISysSubscribeService
    {
        public bool SubscribeSec()
        {
            SysSubscribe sub = new SysSubscribe
            {
                Uid = "admin",
                JobId = "10"
            };
            return sub.SaveSec();
        }

        public bool UnSubscribeSec()
        {
            SysSubscribe sub = new SysSubscribe
            {
                Uid = "admin",
                JobId = "10"
            };
            return sub.CancelAlarmSub();
        }

        public bool SubscribeOriginal()
        {
            SysSubscribe sub = new SysSubscribe
            {
                Uid = "admin",
                JobId = "10"
            };
            return sub.SaveSec();
        }

        public bool UnSubscribeOriginal()
        {
            SysSubscribe sub = new SysSubscribe
            {
                Uid = "admin",
                JobId = "10"
            };
            return sub.CancelAlarmSub();
        }

    }
}
