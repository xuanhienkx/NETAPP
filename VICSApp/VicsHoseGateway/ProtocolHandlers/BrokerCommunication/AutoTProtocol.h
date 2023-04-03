// AutoTProtocol.h: interface for the CAutoTProtocol class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_AUTOTPROTOCOL_H__D3283F04_0DF2_46A2_BF59_AC4E69B34591__INCLUDED_)
#define AFX_AUTOTPROTOCOL_H__D3283F04_0DF2_46A2_BF59_AC4E69B34591__INCLUDED_

#include "BrokerSocket.h"
#include "Queue.h"

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class CAutoTProtocol  
{
protected:
	HANDLE m_hThreadPollCTCIMsg;
	HANDLE m_hThreadReceiveBroadcastPacket;
	HANDLE m_hThreadReceiveAutoTPacket;

	HANDLE m_hThreadHandlingRetransmissionMessage;
	HANDLE m_hThreadHandlingManagerMessage;


	static DWORD ThreadPollCTCIMsgFromQueue(CAutoTProtocol* pAutoTProtocol);
	static DWORD ThreadReceiveBroadcastMsgFromHOSE(CAutoTProtocol* pAutoTProtocol);
	static DWORD ThreadReceiveAutoTPacketFromHOSE(CAutoTProtocol* pAutoTProtocol);

	static DWORD ThreadHandlingRetransmissionMessage(CAutoTProtocol *pBroadcastProtocol);
	static DWORD ThreadHandlingManagerMessage(CAutoTProtocol *pBroadcastProtocol);

public:
	int CheckHOSEPacket(stAutoTMessageFormat* pMsg);
	CAutoTProtocol();
	virtual ~CAutoTProtocol();

	int Init();
	int Exit();

	int Start();
	int Stop();

	int InitializeData();
	int UnInitializeData();

	int EstablishConnection();
	int TerminateConnection();
	int	SendPacket(stAutoTMessageFormat* pMsg);
	int	ReceivePacket(stAutoTMessageFormat* pMsg);
	int	Processing_LeftoverPacket(stAutoTMessageFormat* pMsg);

	int CreateBroadcastThread();

	int TerminateThreads();
	int TerminateSendingThread();
	int TerminateReceivingThread();

	int CheckReceivingSequenceNumber(unsigned int server_ack_seq_no);

	int CheckLeftOverPacket(unsigned int nSequenceNo, unsigned int nAckSequenceNo);
	int GetLeftOverPacket(unsigned int nSequenceNo, unsigned int nAckSequenceNo, stAutoTMessageFormat** pMsg);

	int TerminatePacketProcessing(stAutoTMessageFormat* pMsg);

	// Create Thread for processing Queue and Broadcast Packet, AutoT Packet
	int CreateWorkThread();

	// Parsing Proadcast Message and Push to Queue
	int ParsingBroadcastPacketAndPushtoQueue(stAutoTMessageFormat* pMsg);

	// Processing Broadcast Packet
	int ProcessingBroadcastPacket(char* szBroadcastPacket, int nBroadcastPacketLength);

	// Process Broadcast from AutoT Packet
	int ProcessingBroadcastPacketFromCTCI(stAutoTMessageFormat* pMsg);

	// Process AutoT Packet
	int ProcessingAutoTPacket(char* szAutoTPacket, int nAutoTPacketLength);

	// Send DATA Packet to HOSE
	int	SendDataPacket(char* szData, int nDataLength);

	// Make ACK packet and send
	int	MakeAndSendACKPacket(stAutoTMessageFormat* pMsg,  unsigned int ack_sequence_number);

	// Make NACK packet and send
	int MakeAndSendNACKPacket(stAutoTMessageFormat* pMsg, unsigned short nErrorCode, CString nErrorString);

	// // Make Echo packet and send
	int	MakeAndSendEchoPacket(stAutoTMessageFormat* pMsg);

	int ProcessingControlPacket(stAutoTMessageFormat* pMsg);

	int MakeAndSendFNPacket();
	int MakeAndSendAFPacket();

	//////////////////////////////////
	// Add by MinhDQ
	//////////////////////////////////
	int MakeAndSendRRPacket(stAutoTMessageFormat* pMsg);

	int MakeAndSendRPPacket(stAutoTMessageFormat* pMsg);
	//////////////////////////////////

	// Make and send Request Retransmission Broadcast Packet
	int MakeAndSendRequestRetransmissionBroadcastPacket(unsigned int nFromSeq, unsigned int nToSeq);

	// Save DATA Packet to HOSE
	int	SaveDataPacket(char* szData, int nDataLength);

	// Save UNSENT DATA Packet to HOSE
	int	SaveUnsentDataPacket(char* szData, int nDataLength);

	// From AutoT Packet, Make the buffer for send to HOSE
	int	EncodePacket(stAutoTMessageFormat* pMsg, char* szBuffer);

	int	DecodePacket2(stArrayAutoTMessage* pMsg, char* szBuffer, int nBufferLength);

	// The buffer receive from HOSE, make the AutoT Packet
	int	DecodePacket(stAutoTMessageFormat* pMsg, char* szBuffer);

	int	DecodeBroadcastPacket(stBroadcastMessageFormat* pMsg, char* szBuffer, int nLength);

	// Check Packet is Valid or Not
	int	CheckPacketFromHOSE(char* szBuffer, int nBufferLength);

	// Processing Sequence Number
	unsigned int GetAutoTSequenceNumber();

	unsigned int GetAutoTExpectAckSequenceNumber();

	// Processing ACK Sequence Number
	unsigned int GetAutoTAckSequenceNumber(unsigned int nAckSequenceNumber);


	// Modulo Utilites
	unsigned char ConvertCharToModulo96(unsigned char nValue, char* szModulo96);
	unsigned short ConvertShortToModulo96(unsigned short nValue, char* szModulo96);
	unsigned int ConvertIntToModulo96(unsigned int nValue, char* szModulo96);
	int ConvertIntTo3BytesModulo96(unsigned int nValue, char* szModulo96);

	unsigned char ConvertModulo96ToChar(char* szModulo96);
	unsigned short ConvertModulo96ToShort(char* szModulo96);
	unsigned int ConvertModulo96ToInt(char* szModulo96);
	int ConvertModulo96To3Bytes(char* szModulo96);

	// Testing
	int	SendDataPacket_Testcase16_5(char* szData, int nDataLength);
	int MakeAndSendEchoPacketWithInvalidSeq(stAutoTMessageFormat* pMsg, unsigned int nAutoTSequenceNo);
	int MakeAndSendEchoPacketWithInvalidAckSeq(stAutoTMessageFormat* pMsg, unsigned int nAutoTAckSequenceNo);
	int	SendInvalidSeqTestDataPacket(char* szData, int nDataLength, unsigned int nAutoTSequenceNo);
	int	SendInvalidAckSeqTestDataPacket(char* szData, int nDataLength, unsigned int nAutoTAckSequenceNo);

	int CreateHandlingThread();

	int				m_nWindow_Size;

	CBrokerSocket	m_Socket;
	CString			m_strPassword;

	unsigned char	m_nConnection_Mode;
	unsigned int	m_nLinkID;

	unsigned char	m_nNumOfMarket;
	stMarketInformation	m_arrMarket[MAX_MARKET];

	// Server
	unsigned char	m_nServerConnection_Mode;

	short			m_nErrorCode;
	unsigned char	m_nProgState;

	// For peocessing CTCI Queue, and Broadcast Queue
	CQueue			m_Queue;

	// Setting Packet Parameters
	int				m_nDataSizeOfPacket;			// Maximum bytes for a data packet
	int				m_nTimeoutWaitingPacket;		// Timeout for waiting for reading queue, millisecond

	// Broadcast Sequence Number
	unsigned int	m_nBroadcastSequenceNoStart;
	unsigned int	m_nBroadcastSequenceNoNext;

	// AutoT Sequence Number
	unsigned int	m_nAutoTSequenceNo;
	unsigned int	m_nAutoTSequenceNoStart;
	unsigned int	m_nAutoTSequenceNoNext;

	unsigned int	m_nAutoTAckSequenceNo;

	unsigned int	m_nAutoCurrTAckSequenceNo;

	int				m_nStopPoolingQueue;
	int				m_nStopAutoT;
	int				m_nStopBroadcast;
	int				m_nSendingThreadStatus;
	int				m_nReceivingThreadStatus;

};

#endif // !defined(AFX_AUTOTPROTOCOL_H__D3283F04_0DF2_46A2_BF59_AC4E69B34591__INCLUDED_)






















