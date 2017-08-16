using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.BaseTools
{
    public class StatusInterval
    {
        private bool Ispausing = false;//是否暂停中
        private int _pause_Interval = 5;//时间间隔，单位：s
        private DateTime _lastTime = DateTime.Now; //上一次暂停时间

        /// <summary>
        /// 启动监听
        /// </summary>
        /// <param name="interval">时间间隔</param>
        /// <param name="recover">状态恢复操作</param>
        public void Interval(int interval,Action recover)
        {
            _pause_Interval = interval;
            _lastTime = DateTime.Now;

            if (Ispausing) return;

            TaskAsyncHelper.RunAsync(() =>{
                do
                {
                    Ispausing = true;
                }
                while (DateTime.Now.Subtract(_lastTime).TotalSeconds < _pause_Interval);
            },
            () =>{
                if (recover != null)
                {
                    recover();
                    Ispausing = false;
                }
            });
        }
    }
}
