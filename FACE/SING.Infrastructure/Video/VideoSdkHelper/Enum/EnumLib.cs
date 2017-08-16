using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoSdkHelper.Enum
{
    //public enum NODE_TYPE
    //{
    //    /// NODE_TYPE_DOMAIN -> 99
    //    NODE_TYPE_DOMAIN = 99, // 域类型

    //    NODE_TYPE_DEVICE, // 设备

    //    NODE_TYPE_CHANNEL, // 通道

    //    NODE_TYPE_ALARM_INPUT, // 告警输入通道

    //    NODE_TYPE_ALARM_OUTPUT, // 告警输出通道

    //    NODE_TYPE_NULL,
    //} //平台设备节点类型

    //public enum NODE_STATUS
    //{

    //    /// NODE_STATUS_OFFLINE -> 0
    //    NODE_STATUS_OFFLINE = 0,

    //    NODE_STATUS_ONLINE,
    //} //平台设备节点状态

    //public enum EXCEPTION_TYPE
    //{

    //    /// EXCEPTION_TYPE_NET_CLOSE -> 0
    //    EXCEPTION_TYPE_NET_CLOSE = 0, //服务器异常关闭视频流,回调参数pExceptionInfo如果不空则是相关错误描述

    //    EXCEPTION_TYPE_DATA_UPDATE,

    //    EXCEPTION_TYPE_USER_DELETE,
    //} //SDK异常类型

    //public enum NET_EVENT_TYPE
    //{

    //    /// NET_EVENT_TYPE_RECONNECT -> 0
    //    NET_EVENT_TYPE_RECONNECT = 0, //与服务器自动重连成功事件

    //    NET_EVENT_TYPE_CLOSE, //与服务器断开事件
    //} //网络事件类型

    //public enum SYS_INFO_TYPE
    //{

    //    /// SYS_INFO_TYPE_ALARM_TYPE -> 5
    //    SYS_INFO_TYPE_ALARM_TYPE = 5, //系统定义的告警类型

    //    /// SYS_INFO_TYPE_ALARM_LEVEL -> 6
    //    SYS_INFO_TYPE_ALARM_LEVEL = 6, //系统定义的告警级别

    //    SYS_INFO_TYPE_ALARM_SOURCE_TYPE, //系统定义的告警源类型
    //} //系统信息类型

    //public enum EnumSysAlarmSourceType
    //{

    //    /// ALARM_SYS_SOURCE_TYPE_ALL -> -1
    //    ALARM_SYS_SOURCE_TYPE_ALL = -1, //所有类型

    //    /// ALARM_SYS_SOURCE_TYPE_PMS -> 101
    //    ALARM_SYS_SOURCE_TYPE_PMS = 101, // 平台管理服务告警

    //    ALARM_SYS_SOURCE_TYPE_DAS, // 设备接入服务告警

    //    ALARM_SYS_SOURCE_TYPE_STS, // 流媒体存储服务告警

    //    ALARM_SYS_SOURCE_TYPE_LMS, // 日志管理服务告警

    //    ALARM_SYS_SOURCE_TYPE_AMS, // 告警关联服务告警

    //    ALARM_SYS_SOURCE_TYPE_CSS, // 中心存储服务告警

    //    ALARM_SYS_SOURCE_TYPE_CLI, // 客户端告警

    //    ALARM_SYS_SOURCE_TYPE_CMU, // 配置管理中心告警

    //    ALARM_SYS_SOURCE_TYPE_PU, // 前端设备告警
    //} //系统告警源类型

    //public enum EnumSysAlarmType
    //{
    //    // 没有告警填写-1
    //    /// ALARM_TYPE_ALL_ALARM -> -1
    //    ALARM_TYPE_ALL_ALARM = -1,
    //    // 所有告警
    //    // 设备 告警
    //    /// ALARM_TYPE_ALARM_IO -> 0
    //    ALARM_TYPE_ALARM_IO = 0,
    //    // IO告警开始
    //    ALARM_TYPE_ALARM_MD,
    //    // 移动侦测告警开始
    //    ALARM_TYPE_ALARM_VIDEO_COVER,
    //    // 视频遮挡告警开始
    //    ALARM_TYPE_ALARM_VIDEO_MISSING,
    //    // 视频丢失告警开始
    //    ALARM_TYPE_ALARM_VIDEO_SIGNAL_ABNORMAL,
    //    // 视频信号异常告警开始
    //    ALARM_TYPE_ALARM_DISK_DAMAGE,
    //    // 设备磁盘损坏告警
    //    ALARM_TYPE_ALARM_FLASH_FAULT,
    //    // 设备FLASH故障告警
    //    ALARM_TYPE_ALARM_DISK_FULL,
    //    // 设备磁盘满告警
    //    // CSS 告警
    //    ALARM_TYPE_ALARM_STORAGE_FULL,
    //    // CSS存储已满告警
    //    ALARM_TYPE_ALARM_RW_DISK_ERROR,
    //    // CSS读写磁盘出错告警
    //    ALARM_TYPE_ALARM_CLI,
    //    //客户端主动报警
    //} //系统告警类型

    //public enum EnumSysAlarmLevelType
    //{

    //    /// ALARM_LEVEL_ALL -> -1
    //    ALARM_LEVEL_ALL = -1,

    //    /// ALARM_LEVEL_UNKNOWN -> 0
    //    ALARM_LEVEL_UNKNOWN = 0, // 未知告警

    //    ALARM_LEVEL_NORMAL, // 一般告警

    //    ALARM_LEVEL_IMPORTANT, // 重要告警

    //    ALARM_LEVEL_EMERGENCT, // 紧急告警

    //    ALARM_LEVEL_CIRTICAL, // 严重告警
    //} //系统告警级别类型

    //public enum EnumSysAlarmHandleType
    //{

    //    /// ALARM_HANDLE_TYPE_NOTIFY -> 0
    //    ALARM_HANDLE_TYPE_NOTIFY = 0, //告警通知

    //    ALARM_HANDLE_TYPE_PLAYVIDEO, //告警点流播放视频

    //    ALARM_HANDLE_TYPE_RECORD, //告警点流并且录像

    //    ALARM_HANDLE_TYPE_STOPALARM, //告警停止
    //} //系统告警处理类型

    //public enum EnumCtrlType
    //{

    //    /// CONTROL_STOP -> 0
    //    CONTROL_STOP = 0,

    //    CONTROL_START,
    //} //控制类型

    //public enum EnumPTZCommandType //云台控制操作类型
    //{

    //    /// PTZ_COMMAND_NULL -> 0
    //    PTZ_COMMAND_NULL = 0, //云台停止,没有运动

    //    /// PTZ_COMMAND_LIGHT_PWRON -> 1
    //    PTZ_COMMAND_LIGHT_PWRON = 1, // 接通灯光电源

    //    PTZ_COMMAND_WIPER_PWRON, // 接通雨刷开关

    //    PTZ_COMMAND_ZOOM_IN, // 焦距变大(倍率变大)

    //    PTZ_COMMAND_ZOOM_OUT, // 焦距变小(倍率变小)

    //    PTZ_COMMAND_FOCUS_NEAR, // 焦点前调

    //    PTZ_COMMAND_FOCUS_FAR, // 焦点后调

    //    PTZ_COMMAND_IRIS_OPEN, // 光圈扩大

    //    PTZ_COMMAND_IRIS_CLOSE, // 光圈缩小

    //    PTZ_COMMAND_TILT_UP, // 云台上仰

    //    PTZ_COMMAND_TILT_DOWN, // 云台下俯

    //    PTZ_COMMAND_PAN_LEFT, // 云台左转

    //    PTZ_COMMAND_PAN_RIGHT, // 云台右转

    //    PTZ_COMMAND_UP_LEFT, // 云台上仰和左转

    //    PTZ_COMMAND_UP_RIGHT, // 云台上仰和右转

    //    PTZ_COMMAND_DOWN_LEFT, // 云台下俯和左转

    //    PTZ_COMMAND_DOWN_RIGHT, // 云台下俯和右转

    //    PTZ_COMMAND_PAN_AUTO, // 云台左右自动扫描

    //    PTZ_COMMAND_GOTO_PRESET, // 转到预置点
    //}

    //public enum EnumSysPTZPreset
    //{

    //    SYS_PTZ_SET_PRESET, // 设置预置点

    //    SYS_PTZ_CLE_PRESET, // 清除预置点

    //    SYS_PTZ_CLE_ALL_PRESET, // 清除所有预置点
    //} // 云台预置点操作类型

    //public enum EnumSysPresetProperty
    //{

    //    PRESET_NORMAL,

    //    PRESET_DEFAULT,
    //} //默认预置点

    //public enum EnumStorageType
    //{
    //    SYS_STORAGE_CSS_SER, // 中心服务存储

    //    SYS_STORAGE_DEVICE, // 前端设备存储

    //    SYS_STORAGE_LOCAL, // 本地硬盘存储
    //} // 录像存储类型

    //public enum EnumSysAlarmStatusType
    //{

    //    /// SYS_ALARM_NOT_CONFIRM -> 0
    //    SYS_ALARM_NOT_CONFIRM = 0, //未确认

    //    SYS_ALARM_CONFIRMED, //已确认

    //    SYS_ALARM_CLOSED, //已关闭
    //}

    //public enum EnumMediaType
    //{

    //    /// SYS_MEDIA_ALL -> -1
    //    SYS_MEDIA_ALL = -1, // 所有类型

    //    SYS_MEDIA_VIDEO, // 视频

    //    SYS_MEDIA_GRAPHIC, // 图像

    //    SYS_MEDIA_AV, // 音视频
    //} // 媒体类型

    //public enum EnumRecordType
    //{

    //    /// SYS_RECORD_ALL -> -1
    //    SYS_RECORD_ALL = -1, // 所有录像

    //    SYS_RECORD_ALARM, // 告警录像

    //    SYS_RECORD_PLAN, // 计划录像

    //    SYS_RECORD_MANUAL, // 手动录像

    //    SYS_RECORD_DOWNLOAD, // 下载录像
    //} // 录像原因

    //public enum EnumTimeLock
    //{

    //    SYS_TIME_LOCK_INVALID, // 该锁无效,即不支持锁定

    //    SYS_TIME_LOCK_OFF, // 没有被锁定

    //    SYS_TIME_LOCK_ON, // 被锁定
    //} // 是否锁定时间

    //public enum EnumSortWay
    //{

    //    SYS_SORT_ASC, // 升序

    //    SYS_SORT_DEC, // 降序
    //} // 排序方式

    //public enum EnumRecordOperate
    //{

    //    /// RECORD_PLAY -> 0
    //    RECORD_PLAY = 0,

    //    /// RECORD_DOWNLOAD -> 1
    //    RECORD_DOWNLOAD = 1,
    //} //录像下载、回放

    //public enum EnumRecordPlayCtrl
    //{
    //    RECORD_CTRL_PLAY,
    //    RECORD_CTRL_PAUSE,
    //    RECORD_CTRL_FAST,
    //    RECORD_CTRL_SLOW,
    //    RECORD_CTRL_STEP,
    //    RECORD_CTRL_VOICE,
    //    RECORD_CTRL_VOLUMN,
    //    RECORD_CTRL_SET_PLAY_PROGRESS,
    //    RECORD_CTRL_SET_PLAY_PROGRESS_BYTIME,
    //    RECORD_CTRL_STOP,
    //    RECORD_CTRL_STEP_BACKWARD
    //} //录像播放控制

    //public enum EnumSysLockOper
    //{

    //    SYS_LOCK_MATRIX_STREAM, //码流上墙

    //    SYS_LOCK_PTZ_CTRL, //云台控制

    //    SYS_LOCK_VOICE_TALK, //语音对讲
    //} //设备加锁独占操作

    //public enum EnumSysLockStatus
    //{

    //    SYS_LOCK, //加锁

    //    SYS_UNLOCK, //解锁

    //    SYS_TIMEOUT_UNLOCK, //超时解锁

    //    SYS_FORCE_LOCK, //强制加锁
    //} //设备加锁类型

    //public enum EnumGrabAuthority
    //{

    //    GRAB_DISABLE,

    //    GRAB_ENABLE,
    //} //抢占类型

    //public enum EnumTransferType
    //{

    //    TRANSFER_PLAY,

    //    TRANSFER_DOWNLOAD,
    //} //录像回放进度回调类型

    //public enum EnumDownloadMode
    //{

    //    DOWNLOAD_CLIENT, //下载到客户端，并写录像文件记录

    //    DOWNLOAD_SERVER, //下载到服务端，只下载文件不写记录

    //    DOWNLOAD_CALLBACK, //直接回调数据，不写文件，不写记录

    //    DOWNLOAD_NONE, //区分于本地录像（写文件，写记录）
    //}

    //public enum DEV_CONTROL_TYPE
    //{

    //    /// DEV_CONTROL_RESTART -> 1
    //    DEV_CONTROL_RESTART = 1, //设备重启

    //    DEV_CONTROL_SYNCHRO, //设备校时

    //    DEV_CONTROL_IO, //io控制(包括灯光，警笛等)
    //} //远程控制设备类型

    //public enum EnumControlFlag
    //{

    //    /// CONTROL_FLAG_INVALID -> -1
    //    CONTROL_FLAG_INVALID = -1, //无效

    //    /// CONTROL_FLAG_STOP -> 0
    //    CONTROL_FLAG_STOP = 0, // 停止

    //    CONTROL_FLAG_START, // 开始
    //} // 动作运行控制标志

    //public enum EnumSrvEvent
    //{

    //    SRV_ORG_DATA_UPDATE,

    //    SRV_USER_REMOVE,

    //    SRV_PRESET_UPDATE,

    //    SRV_LOGIC_GROUP_UPDATE,

    //    SRV_CIRCLE_DATA_UPDATE,
    //} // 系统通知事件

    //public enum EnumCruiseCtrl
    //{

    //    CRUISE_SET, // 设置巡航数据

    //    CRUISE_REMOVE, // 清除巡航数据

    //    CRUISE_START, //开始巡航

    //    CRUISE_STOP, //停止巡航
    //} // 云台巡航操作类型

    ////public enum PLAY_STREAM_TYPE
    ////{
    ////    STREAM__FIRST = 1,
    ////    STREAM__SECOND = 2,
    ////}

    /********************** 全局错误码 end  *****************************/


    /******************************** 参数配置结构、参数 begin ***********************/

    public enum NODE_TYPE//平台设备节点类型
    {
        NODE_TYPE_DOMAIN = 99,          // 域类型
        NODE_TYPE_DEVICE,               // 设备
        NODE_TYPE_CHANNEL,              // 通道
        NODE_TYPE_ALARM_INPUT,              // 告警输入通道
        NODE_TYPE_ALARM_OUTPUT,             // 告警输出通道
        NODE_TYPE_NULL
    }

    public enum NODE_STATUS//平台设备节点状态
    {
        NODE_STATUS_OFFLINE = 0,
        NODE_STATUS_ONLINE,

    }

    public enum DEV_CAM_SHAPE
    {
        DEV_GUN_CAM = 0,
        DEV_SPHERE_CAM,

    }

    public enum USER_STATUS
    {
        USER_STATUS_OFFLINE = 0,
        USER_STATUS_ONLINE,
    }

    public enum EXCEPTION_TYPE//SDK异常类型
    {
        EXCEPTION_TYPE_NET_CLOSE = 0,//服务器异常关闭视频流,回调参数pExceptionInfo如果不空则是相关错误描述
        EXCEPTION_TYPE_DATA_UPDATE,
        EXCEPTION_TYPE_USER_DELETE
    }

    public enum NET_EVENT_TYPE//网络事件类型
    {
        NET_EVENT_TYPE_RECONNECT = 0,//与服务器自动重连成功事件
        NET_EVENT_TYPE_CLOSE //与服务器断开事件
    }

    public enum SYS_INFO_TYPE//系统信息类型
    {
        SYS_INFO_TYPE_ALARM_TYPE = 5,//系统定义的告警类型
        SYS_INFO_TYPE_ALARM_LEVEL = 6,  //系统定义的告警级别
        SYS_INFO_TYPE_ALARM_SOURCE_TYPE //系统定义的告警源类型

    }

    public enum EnumSysAlarmSourceType//系统告警源类型
    {
        ALARM_SYS_SOURCE_TYPE_ALL = -1,                      //所有类型
        ALARM_SYS_SOURCE_TYPE_PMS = 101,                    // 平台管理服务告警
        ALARM_SYS_SOURCE_TYPE_DAS,                      // 设备接入服务告警
        ALARM_SYS_SOURCE_TYPE_STS,                      // 流媒体存储服务告警
        ALARM_SYS_SOURCE_TYPE_LMS,                          // 日志管理服务告警
        ALARM_SYS_SOURCE_TYPE_AMS,                          // 告警关联服务告警
        ALARM_SYS_SOURCE_TYPE_CSS,                          // 中心存储服务告警
        ALARM_SYS_SOURCE_TYPE_CLI,                          // 客户端告警
        ALARM_SYS_SOURCE_TYPE_CMU,                          // 配置管理中心告警
        ALARM_SYS_SOURCE_TYPE_PU                            // 前端设备告警

    }


    public enum EnumSysAlarmType//系统告警类型
    {
        //--------------------------------------------------------------------------------------------------------------------\\
        //// 没有告警填写-1
        ALARM_TYPE_ALL_ALARM = -1,                              // 所有告警

        //--------------------------------------------------------------------------------------------------------------------
        // 设备 告警
        ALARM_TYPE_ALARM_IO = 0,                            // IO告警开始

        ALARM_TYPE_ALARM_MD,                                // 移动侦测告警开始

        ALARM_TYPE_ALARM_VIDEO_COVER,                   // 视频遮挡告警开始

        ALARM_TYPE_ALARM_VIDEO_MISSING,                 // 视频丢失告警开始

        ALARM_TYPE_ALARM_VIDEO_SIGNAL_ABNORMAL,         // 视频信号异常告警开始

        ALARM_TYPE_ALARM_DISK_DAMAGE,                           // 设备磁盘损坏告警
        ALARM_TYPE_ALARM_FLASH_FAULT,                           // 设备FLASH故障告警
        ALARM_TYPE_ALARM_DISK_FULL,                         // 设备磁盘满告警

        //--------------------------------------------------------------------------------------------------------------------
        // CSS 告警
        ALARM_TYPE_ALARM_STORAGE_FULL,                          // CSS存储已满告警
        ALARM_TYPE_ALARM_RW_DISK_ERROR,                         // CSS读写磁盘出错告警


        ALARM_TYPE_ALARM_CLI                                    //客户端主动报警

    }



#if Debug
public	enum EnumSysAlarmLevelType//系统告警级别类型
{
	ALARM_LEVEL_ALL    = -1,                     //所有级别
	ALARM_LEVEL_UNKNOWN = 0,					// 未知告警
	ALARM_LEVEL_NORMAL,							// 正常告警
	ALARM_LEVEL_WITHOUT_LOSS,					// 无损告警
	ALARM_LEVEL_NOTICE,							// 通告告警
	ALARM_LEVEL_ATTENUATION,					// 衰减告警
	ALARM_LEVEL_ALERT,							// 警报告警
	ALARM_LEVEL_FAULT,							// 故障告警
	ALARM_LEVEL_CRISIS							// 危机告警

};
#endif

    public enum EnumSysAlarmLevelType//系统告警级别类型
    {
        ALARM_LEVEL_ALL = -1,
        ALARM_LEVEL_UNKNOWN = 0,                    // 未知告警
        ALARM_LEVEL_NORMAL,                         // 一般告警
        ALARM_LEVEL_IMPORTANT,                      // 重要告警
        ALARM_LEVEL_EMERGENCT,                      // 紧急告警
        ALARM_LEVEL_CIRTICAL,                       // 严重告警
    }

    public enum EnumSysAlarmHandleType//系统告警处理类型
    {
        ALARM_HANDLE_TYPE_NOTIFY = 0,       //告警通知
        ALARM_HANDLE_TYPE_PLAYVIDEO,        //告警点流播放视频
        ALARM_HANDLE_TYPE_RECORD,           //告警点流并且录像
        ALARM_HANDLE_TYPE_STOPALARM,        //告警停止

    }

    //控制类型
    public enum EnumCtrlType
    {
        CONTROL_STOP = 0,
        CONTROL_START
    }
        ;

    //布防撤防状态
    public enum EnumDefenceStatus
    {
        DEFENCE_CANCLE = 0,
        DEFENCE_START
    }

    //云台控制操作类型
    public enum EnumPTZCommandType
    {
        PTZ_COMMAND_NULL = 0,                   //云台停止,没有运动		
        PTZ_COMMAND_LIGHT_PWRON = 1,            // 接通灯光电源
        PTZ_COMMAND_WIPER_PWRON,                // 接通雨刷开关
        PTZ_COMMAND_ZOOM_IN,                    // 焦距变大(倍率变大)
        PTZ_COMMAND_ZOOM_OUT,                   // 焦距变小(倍率变小)
        PTZ_COMMAND_FOCUS_NEAR,                 // 焦点前调
        PTZ_COMMAND_FOCUS_FAR,                  // 焦点后调
        PTZ_COMMAND_IRIS_OPEN,                  // 光圈扩大
        PTZ_COMMAND_IRIS_CLOSE,                 // 光圈缩小
        PTZ_COMMAND_TILT_UP,                    // 云台上仰
        PTZ_COMMAND_TILT_DOWN,                  // 云台下俯
        PTZ_COMMAND_PAN_LEFT,                   // 云台左转
        PTZ_COMMAND_PAN_RIGHT,                  // 云台右转
        PTZ_COMMAND_UP_LEFT,                    // 云台上仰和左转
        PTZ_COMMAND_UP_RIGHT,                   // 云台上仰和右转
        PTZ_COMMAND_DOWN_LEFT,                  // 云台下俯和左转
        PTZ_COMMAND_DOWN_RIGHT,                 // 云台下俯和右转
        PTZ_COMMAND_PAN_AUTO,                   // 云台左右自动扫描
        PTZ_COMMAND_GOTO_PRESET                 // 转到预置点
    }
        ;

    // 云台预置点操作类型
    public enum EnumSysPTZPreset
    {
        SYS_PTZ_SET_PRESET,                 // 设置预置点
        SYS_PTZ_CLE_PRESET,                 // 清除预置点
        SYS_PTZ_CLE_ALL_PRESET              // 清除所有预置点

    }
        ;

    //默认预置点
    public enum EnumSysPresetProperty
    {
        PRESET_NORMAL,
        PRESET_DEFAULT
    }

    // 录像存储类型
    public enum EnumStorageType
    {
        SYS_STORAGE_CSS_SER,        // 中心服务存储
        SYS_STORAGE_DEVICE,         // 前端设备存储
        SYS_STORAGE_LOCAL           // 本地硬盘存储
    }

    // 录像来源类型
    public enum EnumRecordFromType
    {
        SYS_RECORDFROM_ALL = -1,        // 查询所有
        SYS_RECORDFROM_CSS_SER,     // 中心服务
        SYS_RECORDFROM_DEVICE,          // 前端设备
        SYS_RECORDFROM_LOCAL            // 本地客户端
    }

    //录像任务类型
    public enum EnumCssRecordTaskType
    {
        TASK_TYPE_PLAN = 1, //计划录像
        TASK_TYPE_ALARM,    //告警录像
        TASK_TYPE_MANUAL    //手动录像
    }

    public enum EnumSysAlarmStatusType
    {
        SYS_ALARM_NOT_CONFIRM = 0,      //未确认
        SYS_ALARM_CONFIRMED,            //已确认
        SYS_ALARM_CLOSED                //已关闭
    }

    // 媒体类型
    public enum EnumMediaType
    {
        SYS_MEDIA_ALL = -1,     // 所有类型
        SYS_MEDIA_VIDEO,        // 视频
        SYS_MEDIA_GRAPHIC,      // 图像
        SYS_MEDIA_AV            // 音视频
    }
    //中心录像文件加解锁的类型
    // public	enum EnumRecordFileControlType
    // {		
    // 	RECORD_FILE_INVALID = 0, //录像文件无效
    // 	RECORD_FILE_UNLOCK = 1 ,      //录像文件解锁
    // 	RECORD_FILE_LOCK  =2    
    // }ENUM_SYS_RECORDFILE_LOCKTYPE;
    // 录像原因
    public enum EnumRecordType
    {
        SYS_RECORD_ALL = -1,        // 所有录像
        SYS_RECORD_ALARM,       // 告警录像
        SYS_RECORD_PLAN,            // 计划录像
        SYS_RECORD_MANUAL,      // 手动录像
        SYS_RECORD_DOWNLOAD     // 下载录像
    }

    //录像查询类型
    public enum EnumRecordQueryType
    {
        SYS_RECORD_QUERY_FILE,
        SYS_RECORD_QUERY_TIME
    }

    // 是否锁定时间
    public enum EnumTimeLock
    {
        SYS_TIME_LOCK_INVALID = 0,          // 该锁无效,即不支持锁定
        SYS_TIME_LOCK_OFF = 1,              // 没有被锁定
        SYS_TIME_LOCK_ON = 2,               // 被锁定
    }

    // 排序方式
    public enum EnumSortWay
    {
        SYS_SORT_ASC,               // 升序
        SYS_SORT_DEC                // 降序
    }

    //录像下载、回放
    public enum EnumRecordOperate
    {
        RECORD_PLAY = 0,
        RECORD_DOWNLOAD = 1
    }

    //录像播放控制
    public enum EnumRecordPlayCtrl
    {
        RECORD_CTRL_PLAY,
        RECORD_CTRL_PAUSE,
        RECORD_CTRL_FAST,
        RECORD_CTRL_SLOW,
        RECORD_CTRL_STEP,
        RECORD_CTRL_VOICE,
        RECORD_CTRL_VOLUMN,
        RECORD_CTRL_SET_PLAY_PROGRESS,
        RECORD_CTRL_SET_PLAY_PROGRESS_BYTIME,
        RECORD_CTRL_STOP,
        RECORD_CTRL_STEP_BACKWARD
    }

    //设备加锁独占操作
    public enum EnumSysLockOper
    {
        SYS_LOCK_MATRIX_STREAM, //码流上墙
        SYS_LOCK_PTZ_CTRL,      //云台控制
        SYS_LOCK_VOICE_TALK,    //语音对讲
        SYS_LOCK_MATRIX_CTRL    //电视墙控制
    }

    //设备加锁类型
    public enum EnumSysLockStatus
    {
        SYS_LOCK,               //加锁
        SYS_UNLOCK,             //解锁
        SYS_TIMEOUT_UNLOCK,     //超时解锁
        SYS_FORCE_LOCK          //强制加锁
    }

    //抢占类型
    public enum EnumGrabAuthority
    {
        GRAB_DISABLE,
        GRAB_ENABLE
    }

    //录像回放进度回调类型
    public enum EnumTransferType
    {
        TRANSFER_PLAY,
        TRANSFER_DOWNLOAD
    }

    public enum EnumDownloadMode
    {
        DOWNLOAD_CLIENT,    //下载到客户端，并写录像文件记录
        DOWNLOAD_SERVER,    //下载到服务端，只下载文件不写记录
        DOWNLOAD_CALLBACK,  //直接回调数据，不写文件，不写记录
        DOWNLOAD_NONE       //区分于本地录像（写文件，写记录）
    }

    public enum DEV_CONTROL_TYPE//远程控制设备类型
    {
        DEV_CONTROL_RESTART = 1,        //设备重启
        DEV_CONTROL_SYNCHRO,                //设备校时
        DEV_CONTROL_IO,           //io控制(包括灯光，警笛等)
        DEV_CONTROL_ALARM_RESET       //告警复位
    }


    // 动作运行控制标志
    public enum EnumControlFlag
    {
        CONTROL_FLAG_INVALID = -1,          //无效
        CONTROL_FLAG_STOP = 0,              // 停止
        CONTROL_FLAG_START                  // 开始
    }


    // 系统通知事件
    public enum EnumSrvEvent
    {
        SRV_ORG_DATA_UPDATE,
        SRV_USER_REMOVE,
        SRV_PRESET_UPDATE,
        SRV_LOGIC_GROUP_UPDATE,
        SRV_CIRCLE_DATA_UPDATE,
        SRV_MATRIX_DATA_UPDATE,
        SRV_CRUISETRACK_UPDATE,
        SRV_MATRIXSCENARIO_UPDATE,
        SRV_MATRIX_SCENARIAO_UPDATE,
        SRV_FORCE_USER_OFFLINE,
        SRV_USER_RIGHT_UPDATE,
        SRV_INCREMENT_UPDATE_NOTIFY,            //增量更新.
        SRV_CLOSE_VIDEO_NOTIFY,                     //服务器远程关闭视频.
        SRV_CHN_STATUS_NOTIFY,
        SRV_USER_DISABLE,                       //禁用用户
    }
    // 云台巡航操作类型
    public enum EnumCruiseCtrl
    {
        CRUISE_SET,                 // 设置巡航数据
        CRUISE_REMOVE,                  // 清除巡航数据
        CRUISE_START,                   //开始巡航
        CRUISE_STOP,                  //停止巡航
        CRUISE_GET_STATUS,                          //获取云台状态
        CRUISE_EDIT_CRUISETRACK                    //编辑巡航路线
    }

    //预案数据库操作类型
    public enum SCENARIDBTYPE
    {
        enum_PlanAutioStart = 1,        //预案自动启动
        enum_PlanAutioStop,             //预案自动停止
        enum_PlanStart,                 //预案手动启动
        enum_PlanStop,                  //预案手动停止
        enum_PlanAdd,              //预案增加
        enum_PlanModify,           //预案修改
        enum_PlanDelete,           //预案删除
        enum_PlanGet,              //预案获取
        enum_PlanGetState,
    };

    public enum ENUM_DIAGNOSIS_EVENTTYPE
    {
        ENUM_DIAGNOSIS_EVENTTYPE_REALTIME_NETCLOSE = 1,  //实时流的断开
        ENUM_DIAGNOSIS_EVENTTYPE_RECORD_NETCLOSE = 2,    //录像流的断开
        ENUM_DIAGNOSIS_EVENTTYPE_BMS_NETCLOSE = 3,       //与BMS的连接断开
        ENUM_DIAGNOSIS_EVENTTYPE_BMS_NETCONNECT = 4      //与BMS的连接成功	
    }

    public enum ENUM_FACE_EVENTTYPE
    {
        ENUM_FACE_EVENTTYPE_REALTIME_NETCLOSE = 1,  //实时流的断开
        ENUM_FACE_EVENTTYPE_RECORD_NETCLOSE = 2,    //录像流的断开
        ENUM_FACE_EVENTTYPE_BMS_NETCLOSE = 3,        //与BMS的连接断开
        ENUM_FACE_EVENTTYPE_BMS_NETCONNECT = 4       //与BMS的连接成功	
    }

    public enum PLAY_STREAM_TYPE
    {
        STREAM__FIRST = 1,          // 第一码流
        STREAM__SECOND,             // 第二码流
        STREAM__THIRD               // 第三码流
    }
}
