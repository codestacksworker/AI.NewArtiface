#ifndef ISTREAMCONVERT_DEF_H
#define ISTREAMCONVERT_DEF_H

/**************************************************************************************************
  Copyright (C), 2010-2011, GOSUN 
  File name 	: ISTREAMCONVERT.H      
  Author 		: hf      
  Version 		: Vx.xx        
  DateTime 		: 2011/4/19 9:21
  Description 	: ת��ģ��ӿ��ļ�
**************************************************************************************************/
#include "GSType.h"
#include "GSMediaDefs.h"

#define VIDEO_STREAM_CONVERT_API extern "C" __declspec(dllexport)

typedef	enum	EnumConvertReturnType
{
	STREAM_CONVERT_OPERATOR_SUCCESS	= 0,	//ת��ɹ�
	STREAM_CONVERT_OPERATOR_FAIL = -1,		//ת��ʧ��
}EnumConvertReturnType;

//������ʽ��װ����
typedef		enum	EnumFormatVideoType
{
	VIDEO_NO_FORMAT_TYPE	= 0,					//�����и�ʽ��װ
	VIDEO_FORMAT_3GP_TYPE	= 1,					//3GP��ʽ
	VIDEO_FORMAT_MP4_TYPE	= 2,					// MP4��ʽ
	VIDEO_FORMAT_AVI_TYPE	=3,						// AVI��ʽ
	VIDEO_FORMAT_M4V_TYPE	=4,						// M4V��ʽ
	VIDEO_FORMAT_ASF_TYPE	=5,						//ASF��ʽ
	VIDEO_FORMAT_MPEGTS_TYPE =6						//MPEGTS��ʽ
}EnumFormatVideoType;

//������������
typedef		enum	EnumVideoType
{
	VIDEO_YUV12_TYPE = 0x00000602,				//yuv420
	VIDEO_MPEG4_TYPE = 0x00000010,				//mpeg4
	VIDEO_H264_TYPE = 0x00000011				//h264
}EnumVideoType;

//���ʿ������ͣ�EnumBitcontrolmodelType
typedef		enum	EnumBitcontrolmodelType
{
	VIDEO_BITCONTROL_CBR = 0,						//CBR
	VIDEO_BITCONTROL_VBR							//VBR	
}EnumBitcontrolmodelType;

typedef enum EnumInputStreamType
{
	INPUTSTREAM_TYPE_SYSHEADER =0,  //��Ϣͷ
	INPUTSTREAM_TYPE_VIDEO,			//��Ƶ��
}EnumInputStreamType;

//�����������
typedef struct StreamConvertDecodeParam 
{
	//�����������������������,��ϸ�����EnumGSCodeID
	INT32 videoType;

}StreamConvertDecodeParam,*StreamConvertDecodeParamPtr;
//��������������ṹ
typedef struct StreamConvertEncodeParam 
{
	//����������������������ͣ���ϸ�����EnumVideoType
	INT32 videoType;

	//��������������ʿ���ģʽ,Ĭ��ΪCBR,��ϸ�����EnumBitcontrolmodelType
	INT32 bitcontrol_model;
	//���������������ϵ�������ʿ���ΪVBRʱ�����õĲ���
	INT32 quant_param;

	//�����������������,Ĭ��Ϊ0
	INT32 bit_rate;

	//������������ֱ���
	INT32 width;
	INT32 height;
	
	//�����������I֡�����Ĭ��Ϊ12
	INT32 gop_size;

	//�������������������B֮֡�䣬����������B֡�����֡����Ĭ��Ϊ1
	INT32 max_b_frames;

	//�����������֡��,��֡��Ϊden/num��Ĭ��Ϊ1/25;
	INT32 num;
	INT32 den;

	StreamConvertEncodeParam():videoType(0),bitcontrol_model(VIDEO_BITCONTROL_CBR),quant_param(0),
		bit_rate(0),width(0),height(0),gop_size(12),max_b_frames(1),num(1),den(25){}


}StreamConvertEncodeParam,*StreamConvertEncodeParamPtr;


/*****************************************************************************
//ת��ص�
����˵����
unsigned char* pDstDataBuff:ת��������ָ�룻
unsigned INT32 ulDstDataLen��ת�������ݳ���
void*	pUser���û����ݣ�
*******************************************************************************/
typedef void (_stdcall* StreamConvertCBFun)(unsigned char* pDstDataBuff,UINT32 ulDstDataLen,UINT32 ulWidth,UINT32 ulHeight,void* pUser);

class IStreamConvert
{
public:
	IStreamConvert(){};
	virtual ~IStreamConvert(){};

public:
	/************************************************************************************************
	ת���ӿ�
	**************************************************************************************************/

	/*****************************************************************************
	��ʼ��
	����˵����
	OutputParam��ת��֮�������Ĳ�����
	InputParam��ת��֮ǰ�����Ĳ�����
	iFormatType������ö��EnumFormatVideoTypeָ��������װ��ʽ
	*******************************************************************************/
	virtual INT32 StreamConvert_open(StreamConvertEncodeParam* OutputParam,StreamConvertDecodeParam* InputParam,EnumFormatVideoType iFormatType)= 0;
	
	/*****************************************************************************
	//����ת��ص�
	����˵����
	StreamConvertCBFun StreamConvertCBFun:�ص�������
	void*	pUser���û����ݣ�
	�ɹ�������STREAM_CONVERT_OPERATOR_SUCCESS��ʧ�ܣ�����STREAM_CONVERT_OPERATOR_FAIL��
	*******************************************************************************/
	virtual	INT32	SetStreamConvertCB(StreamConvertCBFun ConvertCBFun,void*	pUser)= 0;

	/*****************************************************************************
	ִ��ת��
	����˵����
	streamType��ָ����������
	pSrcData������������
	ulSrcDataLen�����������ĳ��ȣ�
	�ɹ�������STREAM_CONVERT_OPERATOR_SUCCESS��ʧ�ܣ�����STREAM_CONVERT_OPERATOR_FAIL��
	*******************************************************************************/
	virtual	INT32 StreamConvert_execute(EnumInputStreamType streamType,const unsigned char* pSrcData,const UINT32 ulSrcDataLen)= 0;

	
	/*****************************************************************************
	�ر�ת��ģ��
	�ɹ�������STREAM_CONVERT_OPERATOR_SUCCESS��ʧ�ܣ�����STREAM_CONVERT_OPERATOR_FAIL��
	*******************************************************************************/
	virtual	INT32 StreamConvert_close() = 0;

	///*****************************************************************************
	//��ȡ��ʽ��װ����ͷ��Ϣ
	//unsigned char* pHeadBuf�����ͷ��Ϣ��BUF��
	//UINT32 BufLen�����ͷ��Ϣ��BUF�ĳ��ȣ�
	//UINT32 &HeadLen������ʵ��ͷ��Ϣ�ĳ���
	//�ɹ�������STREAM_CONVERT_OPERATOR_SUCCESS��ʧ�ܣ�����STREAM_CONVERT_OPERATOR_FAIL��
	//*******************************************************************************/
	//virtual	INT32 GetStreamFormatHead(unsigned char* pHeadBuf,UINT32 BufLen,UINT32 &HeadLen) = 0;

	/*****************************************************************************
	��ȡ��ʽ��װ����β��Ϣ
	unsigned char* pTrailBuf�����β��Ϣ��BUF��
	UINT32 BufLen�����β��Ϣ��BUF�ĳ���
	UINT32 &TrailLen������ʵ��β��Ϣ�ĳ���
	�ɹ�������STREAM_CONVERT_OPERATOR_SUCCESS��ʧ�ܣ�����STREAM_CONVERT_OPERATOR_FAIL��
	*******************************************************************************/
	virtual	INT32 GetStreamFormatTrailer(unsigned char* pTrailBuf,UINT32 BufLen,UINT32 &TrailLen) = 0;

};

//ת��ģ�����ʵ���Ļ�ȡ���ͷ�
VIDEO_STREAM_CONVERT_API IStreamConvert* GetStreamConvert();

VIDEO_STREAM_CONVERT_API INT32		ReleaseStreamConvert(IStreamConvert* pStreamConvert);

#endif // ISTREAMCONVERT_DEF_H