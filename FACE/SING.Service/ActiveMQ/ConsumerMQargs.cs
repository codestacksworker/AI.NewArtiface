using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;

namespace SING.Service.ActiveMQ
{
    public class ConsumerMQargs
    {
        public IDestination Destination { get; set; }
        /// <summary>
        /// 创建Consumer需要的参数
        /// </summary>
        public string Selector { get; set; }
        /// <summary>
        /// 创建Consumer需要的参数
        /// </summary>
        public bool NoLocal { get; set; }
        /// <summary>
        /// 初始化工厂需要的参数
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// 初始化工厂需要的参数
        /// Url值
        /// </summary>
        public string BrokerUrl { get; set; }
        /// <summary>
        /// 创建持久连接需要的参数
        /// </summary>
        public string UseName { get; set; }
        /// <summary>
        /// 创建连接需要的参数
        /// </summary>
        public string Possword { get; set; }
        /// <summary>
        /// 创建session需要的参数
        /// </summary>
        public Apache.NMS.AcknowledgementMode AcknowledgementMode { get; set; }
        /// <summary>
        /// 创建Topic需要的参数
        /// </summary>
        public string TopicName { get; set; }
        /// <summary>
        /// 创建Consumer需要的参数
        /// </summary>
        public string ConsumerName { get; set; }
    }
}
