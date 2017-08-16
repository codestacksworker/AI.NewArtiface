#ifndef ISTREAMCONVERT_DEF_H
#define ISTREAMCONVERT_DEF_H

/**************************************************************************************************
  Copyright (C), 2010-2011, GOSUN 
  File name 	: ISTREAMCONVERT.H      
  Author 		: hf      
  Version 		: Vx.xx        
  DateTime 		: 2011/4/19 9:21
  Description 	: 转码模块接口文件
**************************************************************************************************/
#include "GSType.h"
#include "GSMediaDefs.h"

#define VIDEO_STREAM_CONVERT_API extern "C" __declspec(dllexport)

typedef	enum	EnumConvertReturnType
{
	STREAM_CONVERT_OPERATOR_SUCCESS	= 0,	//转码成功
	STREAM_CONVERT_OPERATOR_FAIL = -1,		//转码失败
}EnumConvertReturnType;

//码流格式封装类型
typedef		enum	EnumFormatVideoType
{
	VIDEO_NO_FORMAT_TYPE	= 0,					//不进行格式封装
	VIDEO_FORMAT_3GP_TYPE	= 1,					//3GP格式
	VIDEO_FORMAT_MP4_TYPE	= 2,					// MP4格式
	VIDEO_FORMAT_AVI_TYPE	=3,						// AVI格式
	VIDEO_FORMAT_M4V_TYPE	=4,						// M4V格式
	VIDEO_FORMAT_ASF_TYPE	=5,						//ASF格式
	VIDEO_FORMAT_MPEGTS_TYPE =6						//MPEGTS格式
}EnumFormatVideoType;

//码流编码类型
typedef		enum	EnumVideoType
{
	VIDEO_YUV12_TYPE = 0x00000602,				//yuv420
	VIDEO_MPEG4_TYPE = 0x00000010,				//mpeg4
	VIDEO_H264_TYPE = 0x00000011				//h264
}EnumVideoType;

//码率控制类型，EnumBitcontrolmodelType
typedef		enum	EnumBitcontrolmodelType
{
	VIDEO_BITCONTROL_CBR = 0,						//CBR
	VIDEO_BITCONTROL_VBR							//VBR	
}EnumBitcontrolmodelType;

typedef enum EnumInputStreamType
{
	INPUTSTREAM_TYPE_SYSHEADER =0,  //信息头
	INPUTSTREAM_TYPE_VIDEO,			//视频流
}EnumInputStreamType;

//码流解码参数
typedef struct StreamConvertDecodeParam 
{
	//（解码参数）码流编码类型,详细定义见EnumGSCodeID
	INT32 videoType;

}StreamConvertDecodeParam,*StreamConvertDecodeParamPtr;
//码流编码码参数结构
typedef struct StreamConvertEncodeParam 
{
	//（编码参数）码流编码类型，详细定义见EnumVideoType
	INT32 videoType;

	//（编码参数）码率控制模式,默认为CBR,详细定义见EnumBitcontrolmodelType
	INT32 bitcontrol_model;
	//（编码参数）量化系数，码率控制为VBR时需设置的参数
	INT32 quant_param;

	//（编码参数）比特率,默认为0
	INT32 bit_rate;

	//（编码参数）分辨率
	INT32 width;
	INT32 height;
	
	//（编码参数）I帧间隔，默认为12
	INT32 gop_size;

	//（编码参数）在两个非B帧之间，所允许插入的B帧的最大帧数，默认为1
	INT32 max_b_frames;

	//（编码参数）帧率,该帧率为den/num，默认为1/25;
	INT32 num;
	INT32 den;

	StreamConvertEncodeParam():videoType(0),bitcontrol_model(VIDEO_BITCONTROL_CBR),quant_param(0),
		bit_rate(0),width(0),height(0),gop_size(12),max_b_frames(1),num(1),den(25){}


}StreamConvertEncodeParam,*StreamConvertEncodeParamPtr;


/*****************************************************************************
//转码回调
参数说明：
unsigned char* pDstDataBuff:转码后的数据指针；
unsigned INT32 ulDstDataLen：转码后的数据长度
void*	pUser：用户数据；
*******************************************************************************/
typedef void (_stdcall* StreamConvertCBFun)(unsigned char* pDstDataBuff,UINT32 ulDstDataLen,UINT32 ulWidth,UINT32 ulHeight,void* pUser);

class IStreamConvert
{
public:
	IStreamConvert(){};
	virtual ~IStreamConvert(){};

public:
	/************************************************************************************************
	转换接口
	**************************************************************************************************/

	/*****************************************************************************
	初始化
	参数说明：
	OutputParam：转码之后码流的参数；
	InputParam：转码之前码流的参数；
	iFormatType：按照枚举EnumFormatVideoType指定码流封装格式
	*******************************************************************************/
	virtual INT32 StreamConvert_open(StreamConvertEncodeParam* OutputParam,StreamConvertDecodeParam* InputParam,EnumFormatVideoType iFormatType)= 0;
	
	/*****************************************************************************
	//设置转码回调
	参数说明：
	StreamConvertCBFun StreamConvertCBFun:回调函数；
	void*	pUser：用户数据；
	成功：返回STREAM_CONVERT_OPERATOR_SUCCESS，失败：返回STREAM_CONVERT_OPERATOR_FAIL；
	*******************************************************************************/
	virtual	INT32	SetStreamConvertCB(StreamConvertCBFun ConvertCBFun,void*	pUser)= 0;

	/*****************************************************************************
	执行转码
	参数说明：
	streamType：指定码流类型
	pSrcData：输入码流；
	ulSrcDataLen：输入码流的长度；
	成功：返回STREAM_CONVERT_OPERATOR_SUCCESS，失败：返回STREAM_CONVERT_OPERATOR_FAIL；
	*******************************************************************************/
	virtual	INT32 StreamConvert_execute(EnumInputStreamType streamType,const unsigned char* pSrcData,const UINT32 ulSrcDataLen)= 0;

	
	/*****************************************************************************
	关闭转码模块
	成功：返回STREAM_CONVERT_OPERATOR_SUCCESS，失败：返回STREAM_CONVERT_OPERATOR_FAIL；
	*******************************************************************************/
	virtual	INT32 StreamConvert_close() = 0;

	///*****************************************************************************
	//获取格式封装流的头信息
	//unsigned char* pHeadBuf：存放头信息的BUF；
	//UINT32 BufLen：存放头信息的BUF的长度；
	//UINT32 &HeadLen：返回实际头信息的长度
	//成功：返回STREAM_CONVERT_OPERATOR_SUCCESS，失败：返回STREAM_CONVERT_OPERATOR_FAIL；
	//*******************************************************************************/
	//virtual	INT32 GetStreamFormatHead(unsigned char* pHeadBuf,UINT32 BufLen,UINT32 &HeadLen) = 0;

	/*****************************************************************************
	获取格式封装流的尾信息
	unsigned char* pTrailBuf：存放尾信息的BUF；
	UINT32 BufLen：存放尾信息的BUF的长度
	UINT32 &TrailLen：返回实际尾信息的长度
	成功：返回STREAM_CONVERT_OPERATOR_SUCCESS，失败：返回STREAM_CONVERT_OPERATOR_FAIL；
	*******************************************************************************/
	virtual	INT32 GetStreamFormatTrailer(unsigned char* pTrailBuf,UINT32 BufLen,UINT32 &TrailLen) = 0;

};

//转码模块对象实例的获取和释放
VIDEO_STREAM_CONVERT_API IStreamConvert* GetStreamConvert();

VIDEO_STREAM_CONVERT_API INT32		ReleaseStreamConvert(IStreamConvert* pStreamConvert);

#endif // ISTREAMCONVERT_DEF_H