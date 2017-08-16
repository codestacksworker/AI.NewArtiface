using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using VideoSdkHelper.Enum;
using VideoSdkHelper.Struct;

namespace VideoSdkHelper
{
    public class VideoClient
    {
        static VideoClient()
        {
            string lacalPath = Path.Combine(Environment.CurrentDirectory, "SDKdll");
            AddEnvironmentPaths(new List<string> { lacalPath });
        }

        static void AddEnvironmentPaths(IEnumerable<string> paths)
        {
            var path = new[] { Environment.GetEnvironmentVariable("PATH") ?? string.Empty };

            string newPath = string.Join(Path.PathSeparator.ToString(), path.Concat(paths));

            Environment.SetEnvironmentVariable("PATH", newPath);
        }

        [DllImport("kernel32")]
        public static extern int GetModuleHandle(string lpModuleName);

        #region    CallBack
        #endregion

        #region  基础接口

        /// <summary>
        /// 初始化SDK，分配资源.
        /// 此接口只能调用一次.
        /// </summary>
        /// <param name="hModule">hModule:Dll的句柄，只做标识用，可以不传递</param>
        /// <returns></returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_Init", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Video_SDK_Init(int hModule);

        /// <summary>
        /// SDK资源释放
        /// 此接口配合Video_SDK_Init，程序退出时调用
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_Cleanup", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Video_SDK_Cleanup();

        /// <summary>
        /// 获取SDK当前版本号
        /// </summary>
        /// <returns>
        /// 返回的版本号是这种格式“1.0.1.1095”
        /// 从左往右，第一个小数点前的是SDK的主版本号；第二个小数点前的是SDK的小版本号；第三个小数点前的是SDK的内部版本号，第三个小数点后边的是版本机上的revision号
        ///</returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_GetVersion", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Video_SDK_GetVersion();

        /// <summary>
        /// 网络事件通知回调函数
        /// </summary>
        /// <param name="handle">handle：登陆成功之后由SDK返回的句柄</param>
        /// <param name="eNetEventType">网络事件类型</param>
        /// <param name="pUserData">用户在设置回调函数时候传递的自定义数据指针</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void NetEventNotifyCallBack(int handle, NET_EVENT_TYPE eNetEventType, IntPtr pUserData);

        /// <summary>
        /// 注册网络事件通知回调函数
        /// </summary>
        /// <param name="pNetEventNotifyCbFun">有网络事件到达的时候会调用的函数</param>
        /// <param name="pUserData">用户传递给回调函数的自定义数据</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        ///</returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_SetNetEventNotify", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Video_SDK_SetNetEventNotify(
            [MarshalAs(UnmanagedType.FunctionPtr)] NetEventNotifyCallBack pNetEventNotifyCbFun, IntPtr pUserData);

        /// <summary>
        /// 告警事件通知回调函数
        /// </summary>
        /// <param name="handle">在成功登陆PMS之后得到的SDK操作句柄</param>
        /// <param name="nAlarmID">此条报警的唯一ID</param>
        /// <param name="eAlarmSourceType">报警源类型，可参考EnumSysAlarmSourceType的定义</param>
        /// <param name="sAlarmSourceID">报警源的ID</param>
        /// <param name="eSysAlarmType">系统告警类型，可参考EnumSysAlarmType的定义</param>
        /// <param name="eSysAlarmLevelType">系统告警级别，可参考EnumSysAlarmLevelType的定义</param>
        /// <param name="eSysAlarmHandleType">系统告警处理类型，可参考EnumSysAlarmHandleType的定义</param>
        /// <param name="sLinkedCameraID">该报警关联的通道ID</param>
        /// <param name="sAlarmTime">报警时间</param>
        /// <param name="nDispIndex">指定在第几个窗口显示报警视频</param>
        /// <param name="pUserData">用户数据</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void AlarmEventNotifyCallBack(
            IntPtr handle, long nAlarmID, EnumSysAlarmSourceType eAlarmSourceType, IntPtr sAlarmSourceID,
            EnumSysAlarmType eSysAlarmType, EnumSysAlarmLevelType eSysAlarmLevelType,
            EnumSysAlarmHandleType eSysAlarmHandleType, IntPtr sLinkedCameraID, IntPtr sAlarmTime, int nDispIndex,
            IntPtr pUserData);

        /// <summary>
        /// 注册告警事件通知回调函数
        /// </summary>
        /// <param name="pAlarmEventNotifyCBFun">有报警事件到达的时候会调用的函数</param>
        /// <param name="pUserData">用户数据</param>
        /// <returns></returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_SetAlarmEventNotify", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Video_SDK_SetAlarmEventNotify(
            [MarshalAs(UnmanagedType.FunctionPtr)] AlarmEventNotifyCallBack pAlarmEventNotifyCBFun, IntPtr pUserData);

        /// <summary>
        ///  设备上下线通知回调函数
        /// 请不要再此回调函数里面迭代调用Video_SDK_GetDeviceList以免造成死锁
        /// </summary>
        /// <param name="handle">成功登陆PMS之后返回的句柄</param>
        /// <param name="szNodeID">设备的节点ID</param>
        /// <param name="eNodeStatus">节点当前状态，可参考枚举型NODE_STATUS的声明</param>
        /// <param name="pUserData">用户在设置回调函数时候传递进来的自定义数据指针</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void DeviceStatusNotifyCallBack(
            int handle, IntPtr szNodeId, NODE_STATUS eNodeStatus, IntPtr pUserData);

        /// <summary>
        ///注册设备上下线通知回调函数
        /// 最好在获取组织结构树之后再调用
        /// </summary>
        /// <param name="pDeviceStatusNotifyCBFun">有设备发生上下线事件的时候会调用的函数</param>
        /// <param name="pUserData">传递给回调函数的用户数据</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_SetDeviceStatusNotify", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Video_SDK_SetDeviceStatusNotify(
            [MarshalAs(UnmanagedType.FunctionPtr)] DeviceStatusNotifyCallBack pDeviceStatusNotifyCBFun, IntPtr pUserData);

        /// <summary>
        /// 登陆PMS
        /// </summary>
        /// <param name="handle"> 登陆成功之后会得到SDK的句柄信息，后续操作的函数都会用到此句柄</param>
        /// <param name="sIp">PMS的IP地址</param>
        /// <param name="nPort">PMS的侦听端口</param>
        /// <param name="sName">登陆PMS的用户名</param>
        /// <param name="sPassword">登陆PMS的密码</param>
        /// <param name="nLoginID">登录对象，可使用2-单点登录（推荐），3-OCX登录</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_CONNECTFAIL
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_Login", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Video_SDK_Login(out int handle, string sIp, int nPort, string sName, string sPassword, int nLoginID = 0);

        /// <summary>
        /// 重登陆PMS
        /// </summary>
        /// <param name="handle">上次登陆PMS成功之后返回的句柄</param>
        /// <returns>
        /// 成功返回：VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// VIDEO_SDK_ERRHANDLE：用户传递的handle参数有误，无法找到匹配的上一次登陆信息，也有可能之前没有登陆成功
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_Relogin", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Video_SDK_Relogin(int handle);

        /// <summary>
        /// 注销视频管理平台
        /// </summary>
        /// <param name="handle">上次登陆平台成功之后返回的句柄</param>
        /// <returns>
        /// 成功返回：VIDEO_SDK_NOERROR
        /// 失败可能返回：错误码
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_Logout", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Video_SDK_Logout(int handle);

        /// <summary>
        /// 获取组织机构树设备列表
        /// </summary>
        /// <param name="nTotalNodeNum">获取组织机构树设备列表</param>
        /// <param name="szNodeId">节点ID</param>
        /// <param name="sNodeName">节点名称</param>
        /// <param name="eNodeType">节点类型（域、设备、报警通道、视频通道），可参考NODE_TYPE的定义</param>
        /// <param name="eNodeStatus">节点状态（设备在线状态，通道没有标识状态）</param>
        /// <param name="sPrivilege">对该节点的操作权限(暂无用)</param>
        /// <param name="pUserData">传递给回调函数的用户数据</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void NodeInfoCallBack(
            int nTotalNodeNum, IntPtr szNodeId, IntPtr sNodeName, NODE_TYPE eNodeType, NODE_STATUS eNodeStatus,
            IntPtr sPrivilege, IntPtr pUserData);

        /// <summary>
        /// 获取组织机构树设备列表
        /// </summary>
        /// <param name="handle">上次登陆PMS成功之后返回的句柄</param>
        /// <param name="szNodeId">分层获取机构树时，父节点的ID，根节点的父节点为0_#_#_#_99</param>
        /// <param name="fNodeDataCallBack">获取机构树信息的回调函数</param>
        /// <param name="pUserData">传递给回调函数的用户数据</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_ERRPARAM：传递的参数有误，回调函数指针为NULL或者节点字符串长度超过MAX_NODE_LEN定义长度
        /// VIDEO_SDK_EXCEPTION：在SDK内部分配存放节点树的内存时发生异常
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_GetDeviceList")]
        public static extern int Video_SDK_GetDeviceList(int handle, IntPtr szNodeId,
            [MarshalAs(UnmanagedType.FunctionPtr)] NodeInfoCallBack fNodeDataCallBack, IntPtr pUserData);
        #endregion

        #region  实时视频控制接口

        /// <summary>
        /// 启动某个视频通道的实时预览
        /// </summary>
        /// <param name="handle">登陆PMS成功之后获得的句柄</param>
        /// <param name="hWnd">需要在此窗口上播放实时视频的窗体句柄</param>
        /// <param name="szNodeID">需要点流的视频通道节点ID</param>
        /// <param name="WaitOutTime">播放等待超时时长</param>
        /// <param name="StreamType">播放码流类型，STREAM__FIRST:第一码流;STREAM__SECOND:第二码流</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// VIDEO_SDK_ERRPARAM：节点ID错误
        /// VIDEO_SDK_EXCEPTION：窗体句柄为NULL
        /// VIDEO_SDK_GETVIDEOFAIL：服务器返回的URI有误；已经打开过相同的URI；打开URI的过程中超时
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_PlayRealVideo")]
        public static extern int Video_SDK_PlayRealVideo(int handle, IntPtr hWnd, string szNodeID, int WaitOutTime = 2000, PLAY_STREAM_TYPE StreamType = PLAY_STREAM_TYPE.STREAM__FIRST);

        /// <summary>
        /// 关闭某个窗口上的实时视频预览
        /// </summary>
        /// <param name="handle">登陆PMS成功之后获得的句柄</param>
        /// <param name="hWnd">需要结束实时视频播放的窗体句柄</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// VIDEO_SDK_ERRPARAM：窗体句柄为空或者在该窗体句柄上没有调用过Video_SDK_PlayRealVideo
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_CloseVideo")]
        public static extern int Video_SDK_CloseVideo(int handle, IntPtr hWnd);

        /// <summary>
        /// 关闭所有窗口上的实时视频预览
        /// </summary>
        /// <param name="handle">登陆PMS成功之后获得的句柄</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_CloseAllVideo")]
        public static extern int Video_SDK_CloseAllVideo(int handle);

        /// <summary>
        /// 实现云台控制
        /// </summary>
        /// <param name="handle">登陆PMS成功之后获得的句柄</param>
        /// <param name="szNodeID">设备通道ID</param>
        /// <param name="ePTZControl">启动/停止云台控制</param>
        /// <param name="ePTZCommandType">控制云台进行的操作，可参考EnumPTZCommandType的定义</param>
        /// <param name="nCommandParam">转到预置点操作的时候是传ID，云台转动操作的时候是速度</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// VIDEO_SDK_ERRPARAM：节点ID为空；节点ID错误，在节点树上找不到对应的节点ID
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_PTZControl")]
        public static extern int Video_SDK_PTZControl(int handle, string szNodeID, EnumCtrlType ePTZControl,
            EnumPTZCommandType ePTZCommandType, int nCommandParam);

        /// <summary>
        /// 设置预置点操作
        /// </summary>
        /// <param name="handle">登陆PMS成功之后获得的句柄</param>
        /// <param name="szNodeID">设备通道ID</param>
        /// <param name="eSysPTZPreset">云台预置点操作的类型，可参考EnumSysPTZPreset的定义</param>
        /// <param name="nPresetIndex">当EnumSysPTZPreset为SYS_PTZ_CLE_ALL_PRESET时，置0</param>
        /// <param name="sPresetName">当EnumSysPTZPreset为SYS_PTZ_CLE_ALL_PRESET或SYS_PTZ_CLE_PRESET时，置NULL</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// VIDEO_SDK_ERRPARAM：节点ID为空；节点ID错误，在节点树上找不到对应的节点ID；预置点名称为NULL或者名称长度超过MAX_NAME_LEN(128个Byte)
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_SetPTZPreset")]
        public static extern int Video_SDK_SetPTZPreset(int handle, string szNodeID, EnumSysPTZPreset eSysPTZPreset,
            int nPresetIndex, IntPtr sPresetName);

        /// <summary>
        /// 获取预置点设置信息回调函数
        /// </summary>
        /// <param name="nPresetIndex">预置点索引值ID</param>
        /// <param name="sPresetName">预置点名称</param>
        /// <param name="ePresetProperty">预置点的属性类型，可参考ENUM_SYS_PRESET_PROPERTY的定义</param>
        /// <param name="pUserData">用户传递给回调函数的数据</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void GetPTZPresetCallBack(
            int nPresetIndex, IntPtr sPresetName, EnumSysPresetProperty ePresetProperty, IntPtr pUserData);

        /// <summary>
        /// 获取预置点设置
        /// </summary>
        /// <param name="handle">登陆PMS成功之后获得的句柄</param>
        /// <param name="szNodeID">设备通道ID</param>
        /// <param name="pPTZPresetCBFun">预置点信息获取的回调函数</param>
        /// <param name="pUserData">用户需要传递给回调函数的数据</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// VIDEO_SDK_ERRPARAM：节点ID为空；节点ID错误，在节点树上找不到对应的节点ID
        /// VIDEO_SDK_EXCEPTION：SDK内部分配内存存放预置点信息失败
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_GetPTZPreset")]
        public static extern int Video_SDK_GetPTZPreset(int handle, string szNodeID,
            [MarshalAs(UnmanagedType.FunctionPtr)] GetPTZPresetCallBack pPTZPresetCBFun, IntPtr pUserData);

        /// <summary>
        /// 视频抓图
        /// 该函数在实时浏览或者录像回放阶段皆可调用
        /// </summary>
        /// <param name="handle">登陆PMS成功之后获得的句柄</param>
        /// <param name="hWnd">启动实时浏览或者录像回放的窗口句柄</param>
        /// <param name="sPicName">需要保存的文件名，格式应为“c:\\CapturePic\\” 或“\\CapturePic”支持绝对路径名称或者相对路径名称</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// VIDEO_SDK_ERRPARAM：窗体句柄为空或者文件名的字符串为NULL
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_StreamCapture")]
        public static extern int Video_SDK_StreamCapture(int handle, IntPtr hWnd, IntPtr sPicName);

        #endregion

        #region 录像、播放控制接口

        /// <summary>
        /// 查询录像文件信息回调函数
        /// </summary>
        /// <param name="szNodeID">查询成功之后跟返回结果关联的通道节点ID</param>
        /// <param name="eStorageType">被查询的录像存储类型，可参考ENUM_SYS_STORAGE_TYPE的定义</param>
        /// <param name="eMediaType">被查询的媒体类型，可参考ENUM_SYS_MEDIA_TYPE的定义</param>
        /// <param name="eRecordType">被查询的录像类型，可参考ENUM_SYS_RECORD_TYPE的定义</param>
        /// <param name="eLock">暂无使用</param>
        /// <param name="uiFileSize">文件长度，以Byte为单位</param>
        /// <param name="sTimeStart">该文件的起始时间</param>
        /// <param name="sTimeEnd">该文件的结束时间</param>
        /// <param name="sLockTimeStart">暂无使用</param>
        /// <param name="sLockTimeEnd">暂无使用</param>
        /// <param name="sFileID">该文件的ID，唯一标识</param>
        /// <param name="uiRowIndex">表示该条录像记录在DB中是第几条</param>
        /// <param name="nQueryResultCount">实际查询结果包含记录数</param>
        /// <param name="pUserData">用户在设置回调函数时候传递的自定义数据指针</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void RecordQueryInfoCallBack(
            IntPtr szNodeID, EnumStorageType eStorageType, EnumMediaType eMediaType, EnumRecordType eRecordType,
            EnumTimeLock eLock, uint uiFileSize, IntPtr sTimeStart, IntPtr sTimeEnd, IntPtr sLockTimeStart,
            IntPtr sLockTimeEnd, IntPtr sFileID, ulong uiRowIndex, int nQueryResultCount, System.IntPtr pUserData);

        /// <summary>
        /// 查询录像文件
        /// 1.录像查询的起始时间和结束时间，是录像查询时返回的时间，用于录像查询时使用，
        /// 这两个时间是录像真实的录像时间 ，不是用户下载录像时的时间，所以录像查询的时候，
        /// 查询时间段选择也是录像的真实时间，不是下载时的时间，
        /// 如果不使用客户端本地录像和下载录像查询功能，这两个可以传空。
        /// </summary>
        /// <param name="handle">登陆PMS成功之后获得的句柄</param>
        /// <param name="szNodeID">需要查询的节点ID，该节点类型可以是域、设备、通道</param>
        /// <param name="eNodeType">节点的类型</param>
        /// <param name="eStorageType">需要查询的录像存储类型，可参考ENUM_SYS_STORAGE_TYPE的定义</param>
        /// <param name="eMediaType">需要查询的媒体类型，可参考ENUM_SYS_MEDIA_TYPE的定义</param>
        /// <param name="eRecordType">需要查询的录像类型，可参考ENUM_SYS_RECORD_TYPE的定义</param>
        /// <param name="sTimeStart">需要查询的起始时间，时间格式为“2012_01_11 11:09:22”</param>
        /// <param name="sTimeEnd">需要查询的结束时间</param>
        /// <param name="eLock">暂无使用</param>
        /// <param name="eSort">查询返回结果的排序方式，可参考ENUM_SYS_SORT的定义</param>
        /// <param name="uiStartRowIndex">表示从哪一条记录开始查询，如果是-1，则表示从第一条记录开始查询。</param>
        /// <param name="PageSize">查询返回的每页的记录数</param>
        /// <param name="pRecordQueryInfoCBFun">查询结果返回会调用的函数指针，函数原型及说明请参考RecordQueryInfoCallBack的函数说明</param>
        /// <param name="pUserData">用户在设置回调函数时候传递的自定义数据指针</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// VIDEO_SDK_ERRPARAM：节点ID为空；节点ID错误，在节点树上找不到对应的节点ID；录像检索时间参数的格式有误
        /// VIDEO_SDK_QUERYEMPTY：查询结果为空
        /// VIDEO_SDK_EXCEPTION：SDK分配内存存放PMS返回的查询结果失败
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_RecordQuery")]
        public static extern int Video_SDK_RecordQuery(int handle, string szNodeID, NODE_TYPE eNodeType,
            EnumStorageType eStorageType, EnumMediaType eMediaType, EnumRecordType eRecordType, string sTimeStart,
            string sTimeEnd, EnumTimeLock eLock, EnumSortWay eSort, ulong uiStartRowIndex, int PageSize,
            [MarshalAs(UnmanagedType.FunctionPtr)] RecordQueryInfoCallBack pRecordQueryInfoCBFun, IntPtr pUserData);

        /// <summary>
        /// 播放/下载录像文件
        /// </summary>
        /// <param name="handle">登陆PMS成功之后获得的句柄</param>
        /// <param name="szNodeID">需要播放的文件所属的通道节点ID</param>
        /// <param name="eOperate">操作类型，可参考ENUM_RECORD_OPERATE的定义</param>
        /// <param name="sFileID">需要操作的文件ID</param>
        /// <param name="eStorageType">录像文件的存储类型，可参考ENUM_SYS_STROAGE_TYPE的定义</param>
        /// <param name="hWnd">如果是播放操作，则表示需要播放的窗口；如果是下载操作，可置为NULL</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// VIDEO_SDK_ERRPARAM：窗体句柄为空；
        /// 文件ID为空；
        /// 当检索存储类型不是本地文件的时候，节点ID为空；
        /// 节点ID无效；
        /// VIDEO_SDK_EXCEPTION： 没有可使用的视频通道了
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_PlayRecordVideo")]
        public static extern int Video_SDK_PlayRecordVideo(int handle, string szNodeID,
            EnumRecordOperate eOperate, ref string sFileID, EnumStorageType eStorageType, IntPtr hWnd);

        /// <summary>
        /// 按照时间段回放录像文件
        /// </summary>
        /// <param name="handle">登录平台之后获得的句柄</param>
        /// <param name="szNodeID">需要播放的文件所属的通道节点ID</param>
        /// <param name="szStartTime">回放开始时间</param>
        /// <param name="szEndTime">回放结束时间</param>
        /// <param name="szCurrentPlayTime">回放当前时间，常规与szStartTime相同；</param>
        /// <param name="eStorage">录像文件的存储类型，可参考ENUM_SYS_STROAGE_TYPE的定义</param>
        /// <param name="eRecordType">录像类型，可参考ENUM_SYS_RECORD_TYPE的定义</param>
        /// <param name="hWnd">播放的窗口；</param>
        /// <param name="nPlatID">平台ID</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// VIDEO_SDK_EXCEPTION： 没有可使用的视频通道了
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_PlayRecordVideoByTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Video_SDK_PlayRecordVideoByTime(int handle, string szNodeID, string szStartTime, string szEndTime, string szCurrentPlayTime,
        EnumStorageType eStorage, EnumRecordType eRecordType, IntPtr hWnd, int nPlatID = 0);

        /// <summary>
        /// 录像回放播放控制
        /// </summary>
        /// <param name="handle">在成功登录平台之后得到的SDK操作句柄</param>
        /// <param name="hWnd">正在进行视频回放的窗口句柄</param>
        /// <param name="ePlayCtrl">录像播放控制操作类型</param>
        /// <param name="lParam">默认为0</param>
        /// <param name="wParam">默认为0</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_RecordPlayCtrl", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Video_SDK_RecordPlayCtrl(int handle, IntPtr hWnd, EnumRecordPlayCtrl ePlayCtrl, int lParam, int wParam);

        /// <summary>
        /// 获取录像当前播放进度
        /// </summary>
        /// <param name="handle">在成功登录平台之后得到的SDK操作句柄</param>
        /// <param name="hWnd">正在进行视频预览的窗口句柄</param>
        /// <param name="nPos">返回进度</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_GetPlayProgress")]
        public static extern int Video_SDK_GetPlayProgress(int handle, IntPtr hWnd, ref int nPos);

        /// <summary>
        /// 按回放时间设置播放进度
        /// </summary>
        /// <param name="handle">在成功登录平台之后得到的SDK操作句柄</param>
        /// <param name="hWnd">正在进行视频回放窗口的句柄</param>
        /// <param name="nTotleSeconds">从该时间点回放 </param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_SetRecordPlayProgressByTime")]
        public static extern int Video_SDK_SetRecordPlayProgressByTime(int handle, IntPtr hWnd, int nTotleSeconds);

        /// <summary>
        /// 启动本地录像
        /// </summary>
        /// <param name="handle">在成功登陆PMS之后得到的SDK操作句柄</param>
        /// <param name="hWnd">正在进行视频预览的窗口句柄</param>
        /// <param name="szFileName">需要保存的文件名</param>
        /// <param name="szBelongtoDomainID">该文件需要关联的域ID</param>
        /// <param name="eRecordType">录像的类型，可参考ENUM_SYS_RECORD_TYPE的定义</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// VIDEO_SDK_ERRPARAM：窗体句柄为空；
        /// 文件名为空
        /// 文件关联的域ID无效
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_StartLocalRecord")]
        public static extern int Video_SDK_StartLocalRecord(int handle, IntPtr hWnd, ref string szFileName,
            ref string szBelongtoDomainID, EnumRecordType eRecordType);

        /// <summary>
        /// 停止本地录像
        /// </summary>
        /// <param name="handle">在成功登陆PMS之后得到的SDK操作句柄</param>
        /// <param name="hWnd">正在进行录像的窗口句柄</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// VIDEO_SDK_ERRPARAM：窗体句柄为空
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_StopLocalRecord")]
        public static extern int Video_SDK_StopLocalRecord(int handle, IntPtr hWnd);

        /// <summary>
        /// 手动录像下载的回调函数（同步回调）
        /// </summary>
        /// <param name="resultCount"></param>
        /// <param name="strRcdFileID"></param>
        /// <param name="iPlatformID"></param>
        /// <param name="iDevID"></param>
        /// <param name="iChnID"></param>
        /// <param name="iChnType"></param>
        /// <param name="pUserData"></param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void StartCSSRecordCallBack(
            int resultCount, IntPtr strRcdFileID, int iPlatformID, int iDevID, int iChnID, int iChnType,
            IntPtr pUserData);

        /// <summary>
        ///  启动平台中心(CSS)录像
        /// 像时间单位为分钟，在录像的过程中需要手动停止录像可以调用Video_SDK_StopCSSRecord，否则超时自动停止
        /// 
        /// </summary>
        /// <param name="handle">在成功登陆PMS之后得到的SDK操作句柄</param>
        /// <param name="szNodeIDCount">通道节点的数量</param>
        /// <param name="szNodeIDArray">通道节点的数组</param>
        /// <param name="fCSSRecordDataCallBack">录像成功的回调函数</param>
        /// <param name="pUserData">用户数据</param>
        /// <param name="nRecordMinute">录像时间，默认十分钟</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// VIDEO_SDK_ERRPARAM：窗体句柄为空；
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_StartCSSRecord")]
        public static extern int Video_SDK_StartCSSRecord(int handle, int szNodeIDCount, ref IntPtr szNodeIDArray,
            [MarshalAs(UnmanagedType.FunctionPtr)] StartCSSRecordCallBack fCSSRecordDataCallBack, IntPtr pUserData,
            int nRecordMinute = 10);

        /// <summary>
        /// 停止平台中心(CSS)录像
        /// </summary>
        /// <param name="handle">在成功登陆PMS之后得到的SDK操作句柄</param>
        /// <param name="szNodeIDCount">通道节点的数量</param>
        /// <param name="szNodeIDArray">通道节点的数组</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_StopCSSRecord")]
        public static extern int Video_SDK_StopCSSRecord(int handle, int szNodeIDCount, ref IntPtr szNodeIDArray);

        #endregion

        #region 报警相关接口
        /// <summary>
        /// 客户端手动发起报警
        /// 报警描述信息的最大长度为MAX_REMARKS_LEN(256个字节)
        /// </summary>
        /// <param name="handle">在成功登陆PMS之后得到的SDK操作句柄</param>
        /// <param name="szNodeID">节点ID，表明是哪个设备的报警</param>
        /// <param name="szAlarmTime">报警时间，时间格式为“2012_01_11 11:09:22”</param>
        /// <param name="szAlarmDesc">报警描述信息</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// VIDEO_SDK_ERRPARAM：参数中有存在NULL；
        /// handle无效，查找不到SDK的登录信息
        /// 节点ID无效
        /// 报警的节点不是一个通道
        /// 报警查询时间格式无效
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_ClientManualAlarm")]
        public static extern int Video_SDK_ClientManualAlarm(int handle, string szNodeID, string szAlarmTime,
            string szAlarmDesc);

        /// <summary>
        /// 报警确认
        /// </summary>
        /// <param name="handle">在成功登陆PMS之后得到的SDK操作句柄</param>
        /// <param name="nItemCount">一次确认多个报警</param>
        /// <param name="nAlarID">每条报警的唯一ID（报警发过来的时候带的，现在带回去）</param>
        /// <param name="eStatus">状态（确认、关闭）</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_AlarmConfirm")]
        public static extern int Video_SDK_AlarmConfirm(int handle, int nItemCount, long[] nAlarID,
            EnumSysAlarmStatusType[] eStatus);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nAlarmID"></param>
        /// <param name="nBelongDomainID"></param>
        /// <param name="nRepeatCount"></param>
        /// <param name="nShieldTime"></param>
        /// <param name="eSysAlarmType"></param>
        /// <param name="eSysAlarmLevelType"></param>
        /// <param name="eSysAlarmSourceType"></param>
        /// <param name="eSysAlarmStatusType"></param>
        /// <param name="sAlarmTime"></param>
        /// <param name="sDomainName"></param>
        /// <param name="sDeviceName"></param>
        /// <param name="sChannelName"></param>
        /// <param name="sAlarmDesc"></param>
        /// <param name="szNodeID"></param>
        /// <param name="nPageIndex"></param>
        /// <param name="nItemCount"></param>
        /// <param name="pUserData"></param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void QueryAlarmInfoCallBack(
            long nAlarmID, int nBelongDomainID, int nRepeatCount, int nShieldTime, EnumSysAlarmType eSysAlarmType,
            EnumSysAlarmLevelType eSysAlarmLevelType, EnumSysAlarmSourceType eSysAlarmSourceType,
            EnumSysAlarmStatusType eSysAlarmStatusType, IntPtr sAlarmTime, IntPtr sDomainName, IntPtr sDeviceName,
            IntPtr sChannelName, IntPtr sAlarmDesc, IntPtr szNodeID, int nPageIndex, int nItemCount, IntPtr pUserData);

        /// <summary>
        /// 按节点类型查询告警信息
        /// MAX_REMARKS_LEN目前定义为256个Byte
        /// </summary>
        /// <param name="handle">在成功登陆PMS之后得到的SDK操作句柄</param>
        /// <param name="sNodeID">需要查询的节点ID</param>
        /// <param name="eNodeType">节点的类型，可参考NODE_TYPE的定义</param>
        /// <param name="eSysAlarmType">系统报警类型，可参考EnumSysAlarmType的定义</param>
        /// <param name="eSysAlarmLevelType">系统报警级别类型，可参考EnumSysAlarmLevelType的定义</param>
        /// <param name="eSysAlarmSourceType">系统报警源的类型，可参考EnumSysAlarmSourceType的定义</param>
        /// <param name="eSysAlarmStatusType">系统报警状态类型，参考EnumSysAlarmStatusType的定义</param>
        /// <param name="sTimeStart">报警开始时间，时间格式为“2012_01_11 11:09:22”</param>
        /// <param name="sTimeEnd">报警结束时间</param>
        /// <param name="nPageNo">返回的页码</param>
        /// <param name="nPageSize">返回中每页的记录数</param>
        /// <param name="pQueryAlarmInfoCBFun">用户在回调函数里面传递的数据</param>
        /// <param name="pUserData">用户数据</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败可能返回：
        /// VIDEO_SDK_NOINIT：SDK还没进行初始化
        /// VIDEO_SDK_ERRPARAM：时间格式无效；
        /// 节点为NULL；
        /// handle无效，查找不到SDK的登录信息
        /// 节点名称关键词无效
        /// 节点名称关键词长度超过MAX_REMARKS_LEN
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_QueryAlarmInfoByNode")]
        public static extern int Video_SDK_QueryAlarmInfoByNode(int handle, string sNodeID, NODE_TYPE eNodeType,
            EnumSysAlarmType eSysAlarmType, EnumSysAlarmLevelType eSysAlarmLevelType,
            EnumSysAlarmSourceType eSysAlarmSourceType, EnumSysAlarmStatusType eSysAlarmStatusType, string sTimeStart,
            string sTimeEnd, int nPageNo, int nPageSize,
            [MarshalAs(UnmanagedType.FunctionPtr)] QueryAlarmInfoCallBack pQueryAlarmInfoCBFun, IntPtr pUserData);

        /// <summary>
        /// 打开透明传输报警消息通道
        /// </summary>
        /// <param name="handle">在成功登陆PMS之后得到的SDK操作句柄</param>
        /// <param name="bEnable">TRUE打开通道，FALSE关闭通道</param>
        /// <returns>
        /// 
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_OpenTransparentAlarm")]
        public static extern int Video_SDK_OpenTransparentAlarm(int handle,
            [MarshalAs(UnmanagedType.Bool)] bool bEnable);

        /// <summary>
        /// 告警事件通知回调函数
        /// </summary>
        /// <param name="handle">在成功登陆PMS之后得到的SDK操作句柄</param>
        /// <param name="nAlarmID">此条报警的唯一ID</param>
        /// <param name="eAlarmSourceType">报警源类型，可参考EnumSysAlarmSourceType的定义</param>
        /// <param name="sAlarmSourceID">报警源的ID</param>
        /// <param name="eSysAlarmType">系统告警类型，可参考EnumSysAlarmType的定义</param>
        /// <param name="eSysAlarmLevelType">系统告警级别，可参考EnumSysAlarmLevelType的定义</param>
        /// <param name="eSysAlarmHandleType">系统告警处理类型，可参考EnumSysAlarmHandleType的定义</param>
        /// <param name="sLinkedCameraID">该报警关联的通道ID</param>
        /// <param name="sAlarmTime">报警时间，时间格式为“2012_01_11 11:09:22”</param>
        /// <param name="pUserData">用户传递回来的数据</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void TransAlarmNotifyCallBack(
            int handle, long nAlarmID, EnumSysAlarmSourceType eAlarmSourceType, IntPtr sAlarmSourceID,
            EnumSysAlarmType eSysAlarmType, EnumSysAlarmLevelType eSysAlarmLevelType,
            EnumSysAlarmHandleType eSysAlarmHandleType, string sLinkedCameraID, string sAlarmTime, IntPtr pUserData);

        /// <summary>
        /// 注册透明传输报警消息通知回调函数
        /// </summary>
        /// <param name="pTransAlarmNotifyCBFun">当DAS接收到报警消息之后通过PMS透明转发过来的报警消息回调函数</param>
        /// <param name="pUserData">用户传递给回调函数的数据</param>
        /// <returns></returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_SetTransparentAlarmNotify")]
        public static extern int Video_SDK_SetTransparentAlarmNotify(
            [MarshalAs(UnmanagedType.FunctionPtr)] TransAlarmNotifyCallBack pTransAlarmNotifyCBFun, IntPtr pUserData);

        #endregion

        #region   人脸检测取码流相关接口
        /// <summary>
        /// 人脸取码流过程中事件的回调函数
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败返回其它值：返回值的意思参考接口错误码声明中的定义或者VideoSDK.h的定义
        /// </summary>
        /// <param name="nEventType">事件类型参考VideoSDK.h中ENUM_FACE_EVENTTYPE的定义</param>
        /// <param name="szNodeID">摄像头的拼接ID,当ENUM_FACE_EVENTTYPE为1和2时有效</param>
        /// <param name="nReserved">保留参数，目前没有使用</param>
        /// <param name="pUserData">用户自定义的回调数据指针</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void SDK_Face_FaceEventCallBack(int nEventType, string szNodeID, int nReserved, IntPtr pUserData);

        /// <summary>
        /// 设置人脸取码流过程中事件的回调函数
        /// </summary>
        /// <param name="pFaceEventCallBackFun">回调函数</param>
        /// <param name="pUserData">用户自定义的回调数据指针</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败返回其它值：返回值的意思参考接口错误码声明中的定义或者VideoSDK.h的定义
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_Face_SetFaceEventCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Video_SDK_Face_SetFaceEventCallBack([MarshalAs(UnmanagedType.FunctionPtr)]SDK_Face_FaceEventCallBack pFaceEventCallBackFun, IntPtr pUserData);

        /// <summary>
        /// 视频流回调函数的定义--用于人脸项目，增加了时间戳信息
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败返回其它值：返回值的意思参考接口错误码声明中的定义或者VideoSDK.h的定义
        /// </summary>
        /// <param name="nPort">表示流的类型（1实时流,2  平台录像流,3  DVR前端设备录像流）</param>
        /// <param name="pBuf">解码后的视频数据</param>
        /// <param name="nSize">解码后的音视频数据pBuf的长度</param>
        /// <param name="pFrameInfo">图像信息。</param>
        /// <param name="sdt">时间戳信息，绝对时间。</param>
        /// <param name="nReserved1">对应用户自定义回调参数</param>
        /// <param name="nReserved2">当取实时码流时为：szNodeID + "_" + iStreamType2；当取平台录像码流时为：szNodeID + "_" + szBeginTime + "_" + szEndTime</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void SDK_Face_DecCBFun(int nPort, IntPtr pBuf, int nSize, ref SDK_FRAME_INFO pFrameInfo, SDK_StruDateTime sdt, int nReserved1, int nReserved2);

        /// <summary>
        /// 设置人脸的视频流回调函数
        /// </summary>
        /// <param name="pFaceDecCallBackFun">回调函数</param>
        /// <param name="pUserData">用户自定义的回调数据指针</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败返回其它值：返回值的意思参考接口错误码声明中的定义或者VideoSDK.h的定义
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_Face_SetFaceDecCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Video_SDK_Face_SetFaceDecCallBack(SDK_Face_DecCBFun pFaceDecCallBackFun, IntPtr pUserData);

        /// <summary>
        /// 取得实时流---人脸项目使用
        /// </summary>
        /// <param name="handle">登录句柄</param>
        /// <param name="szNodeID">NodeID</param>
        /// <param name="StreamType">流的类型（1主码流,2  子码流）</param>
        /// <param name="pUserData">用户自定义的回调数据指针</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败返回其它值：返回值的意思参考接口错误码声明中的定义或者VideoSDK.h的定义
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_Face_OpenRealTimeStream", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Video_SDK_Face_OpenRealTimeStream(int handle, string szNodeID, PLAY_STREAM_TYPE StreamType, IntPtr pUserData);

        /// <summary>
        /// 取得平台录像流---人脸项目使用
        /// </summary>
        /// <param name="handle">登录句柄</param>
        /// <param name="szNodeID">NodeID</param>
        /// <param name="szBeginTime">开始时间，格式为："年-月-日-时-分-秒"</param>
        /// <param name="szEndTime">结束时间，格式为："年-月-日-时-分-秒"</param>
        /// <param name="pUserData">用户自定义的回调数据指针</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败返回其它值：返回值的意思参考接口错误码声明中的定义或者VideoSDK.h的定义
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_Face_OpenPlatformRecordStream")]
        public static extern int Video_SDK_Face_OpenPlatformRecordStream(int handle, string szNodeID, string szBeginTime, string szEndTime, IntPtr pUserData);

        /// <summary>
        /// 关闭实时流---人脸项目使用
        /// </summary>
        /// <param name="handle">登录句柄</param>
        /// <param name="szNodeID">NodeID</param>
        /// <param name="StreamType">流的类型（1主码流,2  子码流）</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败返回其它值：返回值的意思参考接口错误码声明中的定义或者VideoSDK.h的定义
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_Face_CloseRealTimeStream")]
        public static extern int Video_SDK_Face_CloseRealTimeStream(int handle, string szNodeID, PLAY_STREAM_TYPE StreamType);

        /// <summary>
        /// 关闭平台录像流---人脸项目使用
        /// </summary>
        /// <param name="handle">登录句柄</param>
        /// <param name="szNodeID">NodeID</param>
        /// <param name="szBeginTime">开始时间，格式为："年-月-日-时-分-秒"</param>
        /// <param name="szEndTime">结束时间，格式为："年-月-日-时-分-秒"</param>
        /// <returns>
        /// 成功返回VIDEO_SDK_NOERROR
        /// 失败返回其它值：返回值的意思参考接口错误码声明中的定义或者VideoSDK.h的定义
        /// </returns>
        [DllImport("VideoSDK.dll", EntryPoint = "Video_SDK_Face_ClosePlatformRecordStream")]
        public static extern int Video_SDK_Face_ClosePlatformRecordStream(int handle, string szNodeID, string szBeginTime, string szEndTime);
        #endregion
    }
}
