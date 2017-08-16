using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using SING.Service.ActiveMQ;

namespace SING.Service.ActiveMQ
{
    public class BaseSubsriber
    {
        protected IConnectionFactory _connectionFactory;
        protected IConnection _connection;
        protected ISession _session;
        protected IMessageConsumer _consumer;

        public event Apache.NMS.MessageListener Listener;

        public virtual void Initialize(ConsumerMQargs args)
        {

        }

        protected virtual void OnListener(IMessage message)
        {
            Listener?.Invoke(message);
        }
    }
}
