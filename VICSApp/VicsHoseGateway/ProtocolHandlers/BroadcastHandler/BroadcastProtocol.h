// BroadcastProtocol.h: interface for the CBroadcastProtocol class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_BROADCASTPROTOCOL_H__E83ED0D0_C354_47FA_BB65_F921D7FBFED6__INCLUDED_)
#define AFX_BROADCASTPROTOCOL_H__E83ED0D0_C354_47FA_BB65_F921D7FBFED6__INCLUDED_

#include "common.h"
#include "Queue.h"	// Added by ClassView
#include "Cfg.h"	// Added by ClassView
#include "BroadcastSocket.h"	// Added by ClassView
#include "RetransmissionInfo.h"	

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class CBroadcastProtocol  
{
public:	
	int ParsingBroadcastPacketAndPushtoQueue(stBroadcastMessageFormat *rcvPkt, int iDataLength);
	unsigned char ConvertModulo96ToChar(char* szModulo96);
	int ConvertModulo96To3Bytes(char* szModulo96);
	unsigned short ConvertModulo96ToShort(char* szModulo96);
	int DecodeBroadcastPacket(stBroadcastMessageFormat* pMsg, char* szBuffer, int nLength);
	int CheckPacket(char* szBuffer, int nBufferLength);
	int ProcessingBroadcastPacket(char* szBroadcastPacket, int nBroadcastPacketLength);
	int CreateBroadcastPacketReceivingThread();
	int CreateRetransmissionHandlingThread();
	//@@@ Than add
	int SendToAutoTHander(stRetransmissionFormat_Req* pMsg);
	int CreateHandlingManagerMessageThread();
	//@@@
	unsigned int m_nBroadcastSequenceNoNext;
	unsigned int m_nBroadcastSequenceNoStart;

	CBroadcastSocket m_broadcastSocket;
	CQueue m_queue;
	CBroadcastProtocol();
	virtual ~CBroadcastProtocol();

	
	
protected:	
	HANDLE m_hBroadcastPacketReceivingThread;
	HANDLE m_hRetransmissionHandlingThread;
	static DWORD RetransmissionHandlingThread(CBroadcastProtocol* pBroadcastProtocol);
	static DWORD BroadcastPacketReceivingThread(CBroadcastProtocol* pBroadcastProtocol);
	//@@@ Than add
	static DWORD HandlingManagerMessageThread(CBroadcastProtocol* pBroadcastProtocol);
	//@@@
};

#endif // !defined(AFX_BROADCASTPROTOCOL_H__E83ED0D0_C354_47FA_BB65_F921D7FBFED6__INCLUDED_)
