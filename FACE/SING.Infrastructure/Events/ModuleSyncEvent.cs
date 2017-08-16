using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Infrastructure.Events
{
    public class ChannelModuleSyncEvent : CompositePresentationEvent<ChannelSyncParameters>
    {
    }
    public class FtDbModuleSyncEvent : CompositePresentationEvent<FtDbSyncParameters>
    {
    }
    public class FtDbUpdateModuleSyncEvent : CompositePresentationEvent<FtDbUpdateSyncParameters>
    {
    }
}
