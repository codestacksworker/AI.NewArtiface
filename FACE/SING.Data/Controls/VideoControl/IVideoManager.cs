using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Controls.VideoControl
{
    public interface IVideoManager : IDisposable
    {
        /// <summary>
        /// 传入参数stOcxPara为json形式的字符串。具体传输那些参数值，两边要定义一致。
        ///“{
        ///	“OcxID”: “1111111111111”,
        ///	“其它参数1”: “”,
        ///	“其它参数2”: “”
        /// }”
        /// </summary>
        /// <param name="controlName"></param>
        void Initialize(VideoParameter paras, string controlName = "");
        /// <summary>
        /// "192.168.1.146", 10002, "admin", "123@456"
        /// </summary>
        /// <param name="sIP"></param>
        /// <param name="nPort"></param>
        /// <param name="sUserName"></param>
        /// <param name="sPassword"></param>
        byte Login();
        /// <summary>
        /// 
        /// </summary>
        ICollection<IVideoBase> Items { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        byte LogOut();
    }
}
