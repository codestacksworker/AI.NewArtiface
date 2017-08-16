using SING.Data.Controls.TreeControl.Models;
using SING.Data.DAL.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Infrastructure.Events
{
    public abstract class SyncParameters
    {
        public string ProductPrimaryName { get; set; }

        public string ProductSecondaryName { get; set; }

    }

    public class ChannelSyncParameters : SyncParameters
    {
        public ObservableCollection<DataItem> newValue { get; set; }
    }

    public class FtDbSyncParameters : SyncParameters
    {
        public List<FaceTemplateDBData> newValue { get; set; }
    }

    public class FtDbUpdateSyncParameters : SyncParameters
    {
        public FaceTemplateDBData newValue { get; set; }
    }

}
