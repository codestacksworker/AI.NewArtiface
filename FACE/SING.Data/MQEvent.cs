using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Events;
using SING.Data.BaseTools;
using SING.Data.DAL.Data;

namespace SING.Data
{
    public class MQCapMessageEvent : CompositePresentationEvent<MQSubMessageParameters>
    {

    }

    public class MQCmpMessageEvent : CompositePresentationEvent<MQSubMessageParameters>
    {

    }

    public class MQAlertMessageEvent : CompositePresentationEvent<MQSubMessageParameters>
    {

    }

    public class MQAlarmMessageEvent : CompositePresentationEvent<MQSubMessageParameters>
    {

    }

    public class RealtimeCapEvent : CompositePresentationEvent<FaceCaptureData>
    {
        
    }

    public class RealtimeCmpEvent : CompositePresentationEvent<FaceCmpViewData>
    {
        
    }

    public class AlertMQEvent : CompositePresentationEvent<AlertData>
    {

    }

    public class AlarmMQEvent : CompositePresentationEvent<AlarmData>
    {

    }
}
