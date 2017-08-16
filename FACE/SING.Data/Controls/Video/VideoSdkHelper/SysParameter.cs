namespace SING.Data.Controls.Video.VideoSdkHelper
{
    public enum SysParameter
    {
        #region  enum
        //TODO:重新定义CMD_PROTOCOL_DEF.H文件的EnumErrorCode，要保持定义的错误码一致！！
        /********************** 全局错误码 begin *************************/
        VIDEO_SDK_NOERROR = 0,	//操作成功
        VIDEO_SDK_OPERATE_FAIL = 1,	//操作失败
        VIDEO_SDK_UNKNOWN_ERROR = 2,	//未知错误

        ///********************** 登录请求错误码 begin *************************/
        VIDEO_SDK_LOGIN_USER_ERROR = 3,	//用户不存在

        VIDEO_SDK_LOGIN_USER_DISABLE = 4,	//用户被禁用
        VIDEO_SDK_LOGIN_PWD_ERROR = 5,	//密码错误
        VIDEO_SDK_LOGIN_HAS_EXIST = 6,	//ID已经登录
        VIDEO_SDK_LOGIN_SERVICE_FULL = 7,	//服务器容量已满
        VIDEO_LOG_RESULT_ROLE_NOTEXIST = 8,				// 角色不存在
        VIDEO_LOG_RESULT_ROLE_INVALID = 9,				// 角色时间段无效
        VIDEO_LOG_RESULT_FORBID_REPEATLOGIN = 10,				// 不允许该用户重复登录
        VIDEO_LOG_RESULT_IPADDRESS_ERROR = 11,		// IP地址不在有效范围内
        VIDEO_LOG_RESULT_SINGLE_SIGN_ON_FAIL = 12,			// 免登录失败

        ///********************** 登录请求错误码 end ***************************/

        //
        //
        ///********************** 点流请求错误码 begin *************************/
        VIDEO_SDK_GET_STREAM_NO_STREAM = 13, //流不存在

        VIDEO_SDK_GET_STREAM_NO_DEVICE = 14,   //设备不存在，或者不可以使用
        VIDEO_SDK_GET_STREAM_NO_CHANNEL = 15,   //设备对应通道不存在	
        VIDEO_SDK_GET_STREAM_TIME_OUT = 16, //点流超时
        VIDEO_SDK_GET_STREAM_NO_DEV_DAS = 17,	 // 设备对应的DAS服务没有登陆
        VIDEO_SDK_GET_STREAM_WAIT_ACK = 18,//点流等待处理保持连接

        ///********************** 点流请求错误码 end  *************************/

        //获取数据版本结果
        VIDEO_SDK_GET_DATA_VERSION_FAIL = 19,		//获取数据版本失败

        //平台录像回复结果
        VIDEO_SDK_GET_SER_RECORD_FAIL = 20,//平台录像规则获取失败

        //获取预置点信息
        VIDEO_SDK_GET_PTZ_PRESET_FAIL = 21,	// 获取预置点失败

        // 告警相关代码
        // VIDEO_SDK_GET_ALARM_RULE_FAIL=			 17,		// 告警规则获取失败
        // VIDEO_SDK_ALARM_LINKAGE_EVENT_OK=		 18	,	// 告警联动事件通知OK
        // VIDEO_SDK_ALARM_LINKAGE_EVENT_ERROR=		 19,		// 告警联动事件通知错误

        // 用户权限
        VIDEO_SDK_GET_USER_RIGHT_FAIL = 25,	//获取用户权限失败
        VIDEO_SDK_USER_NO_OPERATOR_RIGHT = 26,	//用户无操作权限

        // 录像文件操作
        VIDEO_SDK_FIND_TRANSFER_CHN_ERROR = 27,// 查找传输通道错误
        VIDEO_SDK_PACKET_LEN_CHECK_ERROR = 28,// 包长度校验错误
        VIDEO_SDK_QUERY_PARAM_ERROR = 29,		// 查询参数错非法
        VIDEO_SDK_QUERY_DBASE_ERROR = 30,		//数据库操作失败
        VIDEO_SDK_QUERY_STROAGE_ERROR = 31,		//不支持的存储类型查找参数
        VIDEO_SDK_PLAYBACK_VERSION_ERR = 32,	//不支持的版本类型
        VIDEO_SDK_PLAYBACK_FILE_NEXIST = 33,	//文件不存在
        VIDEO_SDK_PLAYBACK_FILE_NOPER = 34,    //文件不可以操作


        ////布防撤防相关代码
        //GET_DEPLOYMENT_DENFENCE_RULE_FAIL=		 30,		//获取布防撤防规则失败
        //DEPLOYMENT_DEFENCE_COMMAND_NOTICE_OK=	 31	,	//布防撤防命令通知成功
        //DEPLOYMENT_DEFENCE_COMMAND_NOTICE_FAIL=	 32	,	//布防撤防命令通知失败
        //
        VIDEO_SDK_DATA_PACKET_ILLEGAL = 38,	// 数据包错误
        VIDEO_SDK_INVALID_PARAM = 39,		// 参数非法
        VIDEO_SDK_FOUND_NO_TRANSMIT_CHANNEL = 40,		// 无法找到传输通道

        VIDEO_SDK_FOUND_DATA_FAIL = 41,		//无法找到相应数据
        VIDEO_SDK_LOCKMONOLIZE = 42,			//操作被独占控制锁定

        VIDEO_SDK_DB_OPER_FAIL = 43,			//数据库操作失败

        //电视墙
        VIDEO_SDK_MATRIX_UNABLE_DECODE = 44,			// 未能解码

        VIDEO_SDK_RECORD_REVIEW_DOWNLOAD_ACCESS_MAX = 51,    //录像回放/下载接入数已达到最大值
        VIDEO_SDK_USER_NO_PRIORITY = 54,//用户优先级低

        //布防撤防相关代码
        // VIDEO_SDK_GET_DEPLOYMENT_DENFENCE_RULE_FAIL=			28,	//获取布防撤防规则失败
        // VIDEO_SDK_DEPLOYMENT_DEFENCE_COMMAND_NOTICE_OK=		29,	//布防撤防命令通知成功
        // VIDEO_SDK_DEPLOYMENT_DEFENCE_COMMAND_NOTICE_FAIL=	30,	//布防撤防命令通知失败

        VIDEO_SDK_NOINIT = 10001,//没有初始化
        VIDEO_SDK_INIT_LOG_FAIL = 10002, //初始化日志失败
        VIDEO_SDK_INIT_NCP_FAIL = 10003, //初始化网络通信协议栈失败
        VIDEO_SDK_INIT_GSP_FAIL = 10004, //初始化gsp网络通信协议栈失败
        VIDEO_SDK_LOAD_DEVICE_FAIL = 10005, //初始化加载设备失败
        VIDEO_SDK_TIMEOUT = 10006, //处理超时
        VIDEO_SDK_REQUESTFAIL = 10007, //发送请求失败
        VIDEO_SDK_GETVIDEOFAIL = 10008, //获取视频失败
        VIDEO_SDK_CONNECTFAIL = 10009, //连接失败
        VIDEO_SDK_ERROR_RESULT = 10010, //错误的应答结果
        VIDEO_SDK_EXCEPTION = 10011, //SDK异常
        VIDEO_SDK_ERRHANDLE = 10012, //错误的平台句柄
        VIDEO_SDK_ERRPARAM = 10013, //参数错误
        VIDEO_SDK_EMPTYMSG = 10014, //平台返回空消息
        VIDEO_SDK_ERRREPLY = 10015, //平台应答出错
        VIDEO_SDK_QUERYEMPTY = 10016, //平台查询为空
        VIDEO_SDK_PLAYCTRL_FAIL = 10017,//视频播放控制失败
        VIDEO_SDK_STREAM_CAPTURE_FAIL = 10018,	//实时视频抓图失败
        VIDEO_SDK_VOICE_LISTENING_FAIL = 10019,//语音监听失败
        VIDEO_SDK_VOICE_TALK_FAIL = 10020,//语音对讲失败
        VIDEO_SDK_UNKNOWN_TYPE = 10021,	//未知类型
        VIDEO_SDK_PATH_ERROR = 10022,	//目录路径错误
        VIDEO_SDK_INIT_DB_FAIL = 10023,	//初始化本地数据库
        VIDEO_SDK_FILE_ERROR = 10024,	//录像文件有错误
        VIDEO_SDK_DB_OPER_ERROR = 10025,	//数据库操作失败
        VIDEO_SDK_MEMORY_MALLOC_ERROR = 10026,	//内存分配失败，或者创建文件失败
        VIDEO_SDK_SERVICE_CLOSE = 10027,  //与后台服务断开连接
        VIDEO_SDK_GETCOLOR_NOSUPPORT = 10028,  //设备不支持
        VIDEO_SDK_GETIMAGEFRAME_FAIL = 10029,  //获取图像失败
        VIDEO_SDK_STREAMCHANNEL_ALREADYOPEN = 10030,  //流通道已经打开
        VIDEO_SDK_REPLAY_DATATOHEAD = 10031, //数据已经到头
        VIDEO_SDK_REPLAY_DATATOEND = 10032,  //数据已经到尾
        VIDEO_SDK_REPLAY_CANNOT_STEPBACK = 10033,  //不满足单帧退的条件
        VIDEO_SDK_REPLAY_GSPCONTROL_FAIL = 10034, //gsp控制失败
        VIDEO_SDK_CAPTURE_FACE_FAIL = 10035, //人脸抓图失败
        VIDEO_SDK_CALL_ORDER_ERROR = 10036,  //调用顺序错误
        #endregion
    }
}
