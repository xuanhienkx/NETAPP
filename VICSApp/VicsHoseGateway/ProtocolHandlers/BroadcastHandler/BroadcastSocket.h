// BroadcastSocket.h: interface for the CBroadcastSocket class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_BROADCASTSOCKET_H__0639A831_3211_44F1_B472_917539B9572A__INCLUDED_)
#define AFX_BROADCASTSOCKET_H__0639A831_3211_44F1_B472_917539B9572A__INCLUDED_

#include "Cfg.h"	// Added by ClassView
#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class CBroadcastSocket  
{
public:	
	int ReceiveBroadcastPacket(char* szRcvData, int* nRcvLength);
	int CloseBroadcastSocket();
	int CreateBroadcastSocket();
	int InitSocket();
	SOCKET m_BroadcastSock;

	int SendAndReceiveRetransmissionPacket(char* szSndData, int nSndLength, char* szRcvData, int* nRcvLength);
	int CloseRetransmissionSocket();
	int CreateRetransmissionSocket();
	SOCKET m_RetransmissionRcvSock;
	SOCKET m_RetransmissionSndSock;

	struct sockaddr_in autoT_addr;

	CBroadcastSocket();
	virtual ~CBroadcastSocket();
};

#endif // !defined(AFX_BROADCASTSOCKET_H__0639A831_3211_44F1_B472_917539B9572A__INCLUDED_)
