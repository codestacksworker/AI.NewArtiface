using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.Util;
using SING.Data.DAL;
using Apache.NMS.ActiveMQ.Commands;
using Newtonsoft.Json;
using SING.Data.DAL.Data;
using SING.Data.Help;

namespace SING.Data.BaseTools
{
    public static class MQHelper
    {
        private static IConnectionFactory _Factory = null;

        private static IConnectionFactory Singleton_Factory
        {
            get
            {
                if (_Factory == null)
                {
                    _Factory = new Apache.NMS.ActiveMQ.ConnectionFactory(AppConfig.Instance.RemoteMQServerAddress);

                }

                return _Factory;
            }
        }

        private static IConnection _Conn = null;

        public static IConnection Singleton_Conn
        {

            get
            {

                if (_Conn == null)
                {

                    _Conn = Singleton_Factory.CreateConnection();
                }
                if (!_Conn.IsStarted)
                {
                    _Conn.Start();
                }


                return _Conn;
            }
        }

        private static ISession _Session = null;

        public static ISession Session
        {
            get
            {
                if (_Session == null)
                {

                    _Session = MQHelper.Singleton_Conn.CreateSession();
                }

                return _Session;
            }
        }

        public static IMessageConsumer Subscriber_Topic(string topicName)
        {
            //ISession Session = MQHelper.Singleton_Conn.CreateSession();

            ITopic destinnation = Session.GetTopic(topicName);

            IMessageConsumer consumer = Session.CreateConsumer(destinnation);

            return consumer;

        }

        public static void Producer_Queue(string queueName, string content)
        {

            using (ISession session = MQHelper.Singleton_Conn.CreateSession())
            {

                IQueue destination = session.GetQueue(queueName);


                using (IMessageProducer producer = session.CreateProducer(destination))
                {
                    ITextMessage request = session.CreateTextMessage();

                    request.Text = content;

                    producer.Send(request, Apache.NMS.MsgDeliveryMode.Persistent, Apache.NMS.MsgPriority.Normal, TimeSpan.MinValue);
                }
            }
        }

        public static void Producer_Queue(string queueName_high, string queueName_low, string content, int queueType)
        {

            using (ISession session = MQHelper.Singleton_Conn.CreateSession())
            {

                IQueue destination = (queueType == 1)
                    ? session.GetQueue(queueName_high)
                    : session.GetQueue(queueName_low);


                using (IMessageProducer producer = session.CreateProducer(destination))
                {
                    ITextMessage request = session.CreateTextMessage();

                    request.Text = content;


                    if (destination.QueueName == queueName_high)
                    {
                        producer.Send(request, Apache.NMS.MsgDeliveryMode.Persistent, Apache.NMS.MsgPriority.Normal, TimeSpan.MinValue);

                    }
                    if (destination.QueueName == queueName_low)
                    {

                        producer.Send(request, Apache.NMS.MsgDeliveryMode.Persistent, Apache.NMS.MsgPriority.Low, TimeSpan.MinValue);


                    }

                }
            }
        }

        public static void Producer_Topic(string topicName, string content)
        {

            using (ISession session = MQHelper.Singleton_Conn.CreateSession())
            {

                ITopic destination = session.GetTopic(topicName);


                using (IMessageProducer producer = session.CreateProducer(destination))
                {
                    ITextMessage request = session.CreateTextMessage();

                    request.Text = content;

                    producer.Send(request, Apache.NMS.MsgDeliveryMode.Persistent, Apache.NMS.MsgPriority.High, TimeSpan.MinValue);
                }
            }
        }

        public static void Producer_Topic(string topicName, object content)
        {

            using (ISession session = MQHelper.Singleton_Conn.CreateSession())
            {

                ITopic destination = session.GetTopic(topicName);

                using (IMessageProducer producer = session.CreateProducer(destination))
                {
                    IObjectMessage request = session.CreateObjectMessage(content);
                    producer.Send(request, Apache.NMS.MsgDeliveryMode.Persistent, Apache.NMS.MsgPriority.High, TimeSpan.MinValue);
                }
            }
        }

        public static bool SendMQ<T>(string topicName, T content)
        {
            bool result = false;
            //try
            //{
                IConnectionFactory factory = new ConnectionFactory(AppConfig.Instance.RemoteMQServerAddress);
                using (IConnection connection = factory.CreateConnection())
                {
                    using (ISession session = connection.CreateSession())
                    {
                        using (IMessageProducer prod = session.CreateProducer(
                            new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic(topicName)))
                        {
                            IMapMessage request = CreateMessage<T>(content);

                            prod.Send(request, Apache.NMS.MsgDeliveryMode.Persistent, Apache.NMS.MsgPriority.High, TimeSpan.MinValue);
                            result = true;
                        }
                    }
                }
            //}
            //catch (System.Exception e)
            //{
            //    Logger.Logger.Error("【Error】：推送告警信息！【MQHelper】-->【函数名】：SendMQ", e);
            //}
            return result;
        }

        public static void Producer_Topic<T>(string topicName, T content)
        {
            //try
            //{
                using (ISession session = MQHelper.Singleton_Conn.CreateSession())
                {
                    ITopic destination = session.GetTopic(topicName);

                    using (IMessageProducer producer = session.CreateProducer(destination))
                    {

                        var request = CreateMessage(content);

                        producer.Send(request, Apache.NMS.MsgDeliveryMode.Persistent, Apache.NMS.MsgPriority.High, TimeSpan.MinValue);

                    }
                }
            //}

            //catch (System.Exception e)
            //{
            //    Logger.Logger.Error("【Error】：MQ发布消息失败！【MQHelper】-->【函数名】：Producer_Topic", e);
            //}

        }

        private static IMapMessage CreateMessage<T>(T content)
        {
            using (ISession session = MQHelper.Singleton_Conn.CreateSession())
            {

                IMapMessage request = session.CreateMapMessage();

                GetMessageBody<T>(content, request);

                return request;
            }
        }

        private static void GetMessageBody<T>(T t, IMapMessage request)
        {
            foreach (var pi in typeof(T).GetProperties())
            {
                object[] attrs = pi.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                JsonPropertyAttribute j = attrs.FirstOrDefault(a => a is JsonPropertyAttribute) as JsonPropertyAttribute;
                var propertyType = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;
                var val = pi.GetValue(t, null);
                if (val == null) continue;

                SetMsgContent(t, request, propertyType, val, j, pi);
            }
        }

        private static void SetMsgContent<T>(T t, IMapMessage request, Type propertyType, object val, JsonPropertyAttribute j,
            PropertyInfo pi)
        {
            if (propertyType == typeof(string))
            {
                var value = val.ToString();
                request.Body.SetString(j.PropertyName, value);
            }
            else if (propertyType == typeof(char))
            {
                var value = char.Parse(val.ToString());
                request.Body.SetChar(j.PropertyName, value);
            }
            else if (propertyType == typeof(long))
            {
                var value = long.Parse(val.ToString());
                request.Body.SetLong(j.PropertyName, value);
            }
            else if (propertyType == typeof(double))
            {
                var value = double.Parse(val.ToString());
                request.Body.SetDouble(j.PropertyName, value);
            }
            else if (propertyType == typeof(byte[]))
            {
                var value = val as byte[];
                request.Body.SetBytes(j.PropertyName, value);
            }
            else if (propertyType == typeof(byte))
            {
                var value = byte.Parse(val.ToString());
                request.Body.SetByte(j.PropertyName, value);
            }
            else if (propertyType == typeof(bool))
            {
                var value = bool.Parse(pi.GetValue(t, null).ToString());
                request.Body.SetBool(j.PropertyName, value);
            }
            else if (propertyType == typeof(int))
            {
                var value = int.Parse(pi.GetValue(t, null).ToString());
                request.Body.SetInt(j.PropertyName, value);
            }
            else if (propertyType == typeof(IDictionary))
            {
                var value = pi.GetValue(t, null) as IDictionary;
                request.Body.SetDictionary(j.PropertyName, value);
            }
            else if (propertyType == typeof(IList))
            {
                var value = pi.GetValue(t, null) as IList;
                request.Body.SetList(j.PropertyName, value);
            }
        }

        //public static void SetContent(TypeCode typeCode)
        //{
        //    if (value == null && (typeCode == TypeCode.Empty || typeCode == TypeCode.String || typeCode == TypeCode.Object))
        //    {
        //        return null;
        //    }
        //    IConvertible convertible = value as IConvertible;
        //    if (convertible == null)
        //    {
        //        throw new InvalidCastException(Environment.GetResourceString("InvalidCast_IConvertible"));
        //    }
        //    switch (typeCode)
        //    {
        //        case TypeCode.Empty:
        //            {
        //                throw new InvalidCastException(Environment.GetResourceString("InvalidCast_Empty"));
        //            }
        //        case TypeCode.Object:
        //            {
        //                return value;
        //            }
        //        case TypeCode.DBNull:
        //            {
        //                throw new InvalidCastException(Environment.GetResourceString("InvalidCast_DBNull"));
        //            }
        //        case TypeCode.Boolean:
        //            {
        //                return convertible.ToBoolean(provider);
        //            }
        //        case TypeCode.Char:
        //            {
        //                return convertible.ToChar(provider);
        //            }
        //        case TypeCode.SByte:
        //            {
        //                return convertible.ToSByte(provider);
        //            }
        //        case TypeCode.Byte:
        //            {
        //                return convertible.ToByte(provider);
        //            }
        //        case TypeCode.Int16:
        //            {
        //                return convertible.ToInt16(provider);
        //            }
        //        case TypeCode.UInt16:
        //            {
        //                return convertible.ToUInt16(provider);
        //            }
        //        case TypeCode.Int32:
        //            {
        //                return convertible.ToInt32(provider);
        //            }
        //        case TypeCode.UInt32:
        //            {
        //                return convertible.ToUInt32(provider);
        //            }
        //        case TypeCode.Int64:
        //            {
        //                return convertible.ToInt64(provider);
        //            }
        //        case TypeCode.UInt64:
        //            {
        //                return convertible.ToUInt64(provider);
        //            }
        //        case TypeCode.Single:
        //            {
        //                return convertible.ToSingle(provider);
        //            }
        //        case TypeCode.Double:
        //            {
        //                return convertible.ToDouble(provider);
        //            }
        //        case TypeCode.Decimal:
        //            {
        //                return convertible.ToDecimal(provider);
        //            }
        //        case TypeCode.DateTime:
        //            {
        //                return convertible.ToDateTime(provider);
        //            }
        //        case TypeCode.Object | TypeCode.DateTime:
        //            {
        //                throw new ArgumentException(Environment.GetResourceString("Arg_UnknownTypeCode"));
        //            }
        //        case TypeCode.String:
        //            {
        //                return convertible.ToString(provider);
        //            }
        //        default:
        //            {
        //                throw new ArgumentException(Environment.GetResourceString("Arg_UnknownTypeCode"));
        //            }
        //    }
    }
}
