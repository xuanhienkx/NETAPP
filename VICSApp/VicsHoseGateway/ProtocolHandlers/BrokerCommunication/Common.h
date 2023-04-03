// AutoTProtocol.h: interface for the CAutoTProtocol class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(_COMMON__INCLUDED_)
#define _COMMON__INCLUDED_


#define AUTO_T_WINDOWS_SIZE		7
#define MAX_SOCKET_BUFFER_SIZE	2048
#define OUR_MAX_SOCKET_BUFFER_SIZE	536

#define MAX_RETRANSMISSION_SIZE	100

#define PACKET_HEADER_SIZE				12
#define BROADCAST_PACKET_HEADER_SIZE	5

#define FIX_200080719					1
#define FIX_200080720					1

typedef struct _tagAUTOTMESSAGEFORMAT
{
	unsigned short	len;
	unsigned int	sequence_no;
	unsigned int	ack_sequence_number;
	unsigned short	opcode;
	unsigned short	linkID;
	char			data[MAX_SOCKET_BUFFER_SIZE];	// include EXT(03)
}stAutoTMessageFormat;

typedef struct _tagARRAYAUTOTMESSAGE
{
	unsigned int			count;	
	stAutoTMessageFormat	arrAutoTMessage[100];	
}stArrayAutoTMessage;

typedef struct _tagBROADCASTMESSAGEFORMAT
{
	unsigned int	sequence_no;
	unsigned char	market_id;
	unsigned char	msg_cnt;
	char			data[MAX_SOCKET_BUFFER_SIZE];	// include EXT(03)
}stBroadcastMessageFormat;

typedef struct _tagRESTRANSMISSION
{
	unsigned int	from_sequence_no;
	unsigned int	to_sequence_no;
}stRestransmission;

typedef struct _tagRESTRANSMISSIONINFOR
{
	unsigned int	index;
	unsigned int	count;
	stRestransmission arrRestransmission[MAX_RETRANSMISSION_SIZE];
}stRestransmissionInfor;

typedef struct _tagMARKETINFORMATION
{
	char	market_id;
	char	firm_id[3];	// include EXT(03)
}stMarketInformation;


typedef struct _tagCONNECTIONDATA
{
	int nTCPPort;
	int nUDPPort;

	int nRetryTime;
	int nTimeout;

	int nMaxPacketSize;
	int nMaxPacketTime;

	int nConnectionMode;
	unsigned short nLinkID;
	char szPassword[50];
	char szMarketID;
	char szFirmID[3];

	unsigned char HOSEIPAddress[4];

	char szSendingQueueAddress[100];
	char szReceivingQueueAddress[100];

	unsigned int nBroadcastSeq;
	int nAutoConnect;
}stConnectionData;

typedef struct _tagTransmissionData
{
	// AutoT Sequence Number
	unsigned int	nAutoTSequenceNo;
	unsigned int	nAutoTSequenceNoStart;

	unsigned int	nAutoTAckSequenceNo;
	stAutoTMessageFormat	arrSndPacket[AUTO_T_WINDOWS_SIZE];
}stTransmissionData;

typedef struct _tagUnsentData
{
	unsigned int	nCount;
	stAutoTMessageFormat arrSndPacket;
}stUnsentData;

#define APP_MODE_A			65
#define APP_MODE_B			66
#define APP_MODE_C			67

///////////////

#define HELLO_MSG			0x484C		//	HL
#define HELLO_REPLY_MSG		0x4852		//	HR
#define CONFIRM_MSG			0x4346		//	CF

#define DATA_MSG			0x4454		//	DT
#define LEFTOVER_MSG		0x4C4F		//	LO
#define LEFTOVER_LAST_MSG	0x4C4C		//	LL

#define RETRAN_REQ_MSG		0x5252		//	RR
#define RETRAN_REPLY_MSG	0x5250		//	RP


#define RETRAN_REQ_MSGTYPE	0x5152		//	RQ 


#define ACK_MSG				0x414B		//	AK
#define NACK_MSG			0x4E4B		//	NK

#define FINISH_MSG			0x464E		//	FN
#define ACKFIN_MSG			0x4146		//	AF
#define ECHO_MSG			0x4543		//	EC
#define ECHO_REPLY_MSG		0x4552		//	ER

///////////////

#define ETX_CHAR			0x03
#define US_CHAR				0x1F
#define BELL_CHAR			0x07

#define MAX_MARKET			10

#define	CHECK_SEQ_OK		0
#define	CHECK_SEQ_LEFT_OVER	1
#define	CHECK_SEQ_FAILED	-1
#define	CHECK_SEQ_WRONG		-2

#define PACKET_OK					0
#define INVALID_SEQUENCE			-1
#define INVALID_ACK_SEQUENCE		-2
#define INVALID_PACKET_LENGTH		-3
#define INVALID_DT_PACKET_LENGTH	-4
#define INVALID_DT_CONNTENT_NULL	-5

// Return Code
#define	RETURN_SUCCESS		0
#define RETURN_FAIL			-1
#define RETURN_ABNORMAL		-2
#define RETURN_TIMEOUT		-3

#define PROG_START			0
#define PROG_PROCESSING		1
#define PROG_DATA_TRANFER	2
#define PROG_STOP			3
#define PROG_STOP_FROM_HOSE	4
#define PROG_STOP_ACCEPT	5

extern stConnectionData g_stConnectionData;
extern stTransmissionData	g_stTransmissionData;
extern stUnsentData	g_stUnsentData;
extern stRestransmissionInfor g_stRestransmissionInfor;

extern int ReadSettingParameters();
extern int WriteSettingParameters();

extern int ReadTransmissionData();
extern int WriteTransmissionData();
extern int ReadUnsentData();
extern int WriteUnsentData();

int ReadReTransmissionInfor();
int WriteReTransmissionInfor();

extern int InitLog();
extern int WriteLog(const char* p_szMessage, ...);

extern unsigned short short_swap(unsigned short value);
extern unsigned long long_swap(unsigned long value);

extern char* Opcode2String(unsigned short nOpcode);
extern void DumpData(char* szData, int nLength);

extern int nEchoTime;
extern int nTestTime;
extern HANDLE g_hMutexEchoTime;

int WriteTransmissionSeqAndAckSeq(unsigned int nAutoTSequenceNo, unsigned int nAutoTAckSequenceNo);
int WriteTransmissionAckSeqAndStartSeq(unsigned int nAutoTAckSequenceNo, unsigned int nAutoTSequenceNoStart);
int WriteTransmissionSeqAndAckSeqAndPacket(unsigned int nAutoTSequenceNo, unsigned int nAutoTAckSequenceNo, int nIndex, stAutoTMessageFormat* sndPkt);

#define LOG_DEBUG	WriteLog
#define LOG_TRACE	WriteLog
#define LOG_INFO	WriteLog
#define LOG_WARNING WriteLog
#define LOG_ERROR	WriteLog
#define LOG_FATAL	WriteLog

#define NONE_STOP		0
#define TRYING_STOP		1
#define WAITING_STOP	2
#define CAN_STOP		3

#define NO_SENDING_ACK  0
#define SENDING_ACK  1

extern int nStopFlag;
extern int nSendingACKFlag;

//@@@ Than add
#define AUTOT_RETRANSMISSION_UDP_PORT			21001
#define HANDLING_MANAGER_UDP_PORT				31001
#define BROADCAST_RETRANSMISSION_UDP_PORT		11001

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

#define CAN_SEND_RETRANSMISSION				0
#define CAN_NOT_SEND_RETRANSMISSION			1

extern int g_nWaitingTS;
extern int WritePossibleReTransmission();
extern int ReadPossibleReTransmission();
//@@@

#endif // !defined(_COMMON__INCLUDED_)
