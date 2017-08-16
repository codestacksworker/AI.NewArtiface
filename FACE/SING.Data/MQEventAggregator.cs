using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Events;

namespace SING.Data
{
    public class MQEventAggregator
    {
        private static EventAggregator mqEventAggregator = null;

        private static readonly object syncLock = new object();

        private MQEventAggregator() { }

        public static EventAggregator GetEventAggregator()
        {
            lock (syncLock)
            {
                if (mqEventAggregator == null)
                {
                    mqEventAggregator = new EventAggregator();
                }
                return mqEventAggregator;
            }
        }
    }
}
