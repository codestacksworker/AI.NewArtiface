using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using SING.Service.ActiveMQ;

namespace SING.Service.ActiveMQ
{
    //消息发布
    public class Publisher
    {
        private IConnection _connection;
        private ISession _session;
        private IMessageProducer _producer;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="brokerUrl">广播地址</param>
        /// <param name="queueDestination">队列目标</param>
        public void Init(string brokerUrl = "tcp://localhost:61616", string queueDestination = "nms.msg.topic")
        {
            try
            {
                IConnectionFactory connectionFactory = new ConnectionFactory(brokerUrl);
                _connection = connectionFactory.CreateConnection();
                _connection.Start();
                _session = _connection.CreateSession();
                IDestination destination = _session.GetTopic(queueDestination);
                _producer = _session.CreateProducer(destination);
            }
            catch (Exception e)
            {
                Console.WriteLine($"activemq初始化异常：{e.InnerException.ToString()}");
            }
        }

        public void Close()
        {
            _session.Close();
            _connection.Close();
        }

        /// <summary>
        /// 发送普通字符串消息
        /// </summary>
        /// <param name="text">字符串</param>
        public void SendText(string text)
        {
            ITextMessage objecto = _producer.CreateTextMessage(text);
            _producer.Send(objecto);
        }

        /// <summary>
        /// 发送对象消息
        /// </summary>
        /// <param name="mapMessages">MapMessage对象</param>
        /// <returns></returns>
        public bool SendObject<T>(List<T> mapMessages)where T:class,new() 
        {
            bool result = true;
            if (mapMessages == null || mapMessages.Count < 0) return false;
            foreach (var mapMessage in mapMessages)
            {
                var message = _producer.CreateMapMessage();
                MqHelper.SetMapMessage(message, mapMessage);
                try
                {
                    _producer.Send(message);
                    result = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"activemq发送异常：{e.InnerException.ToString()}");
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// 获取对象XML结果
        /// </summary>
        /// <param name="m">对象</param>
        /// <returns></returns>
        public string GetXmlStr(object m)
        {
            return _producer.CreateXmlMessage(m).Text;
        }
    }
}
