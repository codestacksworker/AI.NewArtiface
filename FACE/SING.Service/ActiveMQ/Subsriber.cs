using System;
using Apache.NMS;
using Apache.NMS.ActiveMQ;

namespace SING.Service.ActiveMQ
{
    //消息订阅
    public class Subsriber : BaseSubsriber,IDisposable
    {
        public override void Initialize(ConsumerMQargs args)
        {
            try
            {
                InitializeFactory(args);
                InitializeSession(args);
                args.Destination = ConnectTopic(args);
                InitializeConsumer(args);
                _consumer.Listener += _consumer_Listener;
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    Console.WriteLine($"activemq初始化异常：{e.InnerException.ToString()}");
            }
        }

        protected virtual void InitializeFactory(ConsumerMQargs args)
        {
            if (!string.IsNullOrWhiteSpace(args.BrokerUrl))
            {
                if (!string.IsNullOrWhiteSpace(args.ClientId))
                    _connectionFactory = new ConnectionFactory(args.BrokerUrl, args.ClientId);
                else
                    _connectionFactory = new ConnectionFactory(args.BrokerUrl);

                InitializeConnection(args);
            }
        }

        protected virtual void InitializeConnection(ConsumerMQargs args)
        {
            if (!string.IsNullOrWhiteSpace(args.UseName))
                _connection = _connectionFactory.CreateConnection(args.UseName, args.Possword);
            else
                _connection = _connectionFactory.CreateConnection();

            _connection.Start();
        }

        protected virtual void InitializeSession(ConsumerMQargs args)
        {
            if (args.AcknowledgementMode == AcknowledgementMode.AutoAcknowledge)
                _session = _connection.CreateSession();
            else
                _session = _connection.CreateSession(args.AcknowledgementMode);
        }

        protected virtual IDestination ConnectTopic(ConsumerMQargs args)
        {
            if (!string.IsNullOrWhiteSpace(args.TopicName))
                return _session.GetTopic(args.TopicName);

            return null;
        }

        protected virtual void InitializeConsumer(ConsumerMQargs args)
        {
            if (!string.IsNullOrWhiteSpace(args.ConsumerName) && args.Destination != null)
            {
                _consumer = _session.CreateDurableConsumer(args.Destination as ITopic, 
                    args.ConsumerName, args.Selector, args.NoLocal);
            }
            else if (args.Destination != null)
            {
                if (!string.IsNullOrWhiteSpace(args.Selector))
                    _consumer = _session.CreateConsumer(args.Destination, 
                        args.Selector, args.NoLocal);
                else
                    _consumer = _session.CreateConsumer(args.Destination);
            }
        }

        private void _consumer_Listener(IMessage message)
        {
            OnListener(message);
        }

        public void Dispose()
        {
            _session.Close();
            _connection.Stop();
            _connection.Close();
        }
    }
}
