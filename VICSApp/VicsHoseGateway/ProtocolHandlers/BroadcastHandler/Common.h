// AutoTProtocol.h: interface for the CAutoTProtocol class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(_COMMON__INCLUDED_)
#define _COMMON__INCLUDED_

#include "Cfg.h"

#define MAX_SOCKET_BUFFER_SIZE	2048
#define PACKET_HEADER_SIZE		12
#define MAX_SEQUENCE_PER_RETRANSMISSION_REQUEST		600
#define MAX_RETRANSMISSION_SIZE 100

typedef struct _tagRETRANSMISSIONDATA
{
	unsigned int	from_sequence_no;
	unsigned int	to_sequence_no;
}stRetransmissionData;

typedef struct _tagRETRANSMISSIONINFO
{	
	int	count;	
	stRetransmissionData arrRetransmissionData[MAX_RETRANSMISSION_SIZE];
}stRetransmissionInfo;

typedef struct _tagBROADCASTMESSAGEFORMAT
{
	unsigned int	sequence_no;
	unsigned char	market_id;
	unsigned char	msg_cnt;
	char			data[MAX_SOCKET_BUFFER_SIZE];	// include EXT(03)
}stBroadcastMessageFormat;

#define LOG_DEBUG	WriteLog
#define LOG_TRACE	WriteLog
#define LOG_INFO	WriteLog
#define LOG_WARNING WriteLog
#define LOG_ERROR	WriteLog
#define LOG_FATAL	WriteLog

// Return Code
#define	RETURN_SUCCESS		0
#define RETURN_FAIL			-1
#define RETURN_ABNORMAL		-2

#define ETX_CHAR			0x03
#define US_CHAR				0x1F
#define BELL_CHAR			0x07

#define MAX_FILE_SIZE			(10*1024*1024)
#define BROADCAST_PACKET_HEADER_SIZE	5

extern int InitLog();
extern int WriteLog(const char* p_szMessage, ...);
extern CCfg g_cfg;
extern g_nStopBroadcast;
extern HANDLE g_hMutexRetransmissionFile;
extern char* g_szReTransmissionFileName;
extern HANDLE g_hMutexRetransmissionInfo;

//@@@ Than add
#define BROADCAST_RETRANSMISSION_UDP_PORT		11001
#define AUTOT_RETRANSMISSION_UDP_PORT			21001
#define HANDLING_MANAGER_UDP_PORT				31001

#define MSG_RETRANSMISSION_REQ			0x00000001
#define MSG_RETRANSMISSION_ACK			0x00000002

#define RETRANSMISSION_ACK_SUCCESSED	0x00000000
#define RETRANSMISSION_ACK_FAIED		0x00000001

typedef struct _tagRETRANSMISSIONFORMAT_REQ
{
	unsigned int	mgsType;
	unsigned int	mgsLength;
	unsigned int	from_sequence_no;
	unsigned int	to_sequence_no;
}stRetransmissionFormat_Req;

typedef struct _tagRETRANSMISSIONFORMAT_ACK
{
	unsigned int	mgsType;
	unsigned int	mgsLength;
	unsigned int	result;
}stRetransmissionFormat_Ack;

//@@@

#endif // !defined(_COMMON__INCLUDED_)
