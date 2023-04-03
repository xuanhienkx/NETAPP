// BrokerSocket.h: interface for the CBrokerSocket class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_BROKERSOCKET_H__3FFB7A44_AC13_471E_A473_DBB227D7709E__INCLUDED_)
#define AFX_BROKERSOCKET_H__3FFB7A44_AC13_471E_A473_DBB227D7709E__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class CBrokerSocket
{
public:
	CBrokerSocket();
	virtual ~CBrokerSocket();

public:
	int Init();
	int Exit();
	
	int InitBroadcast();
	int ExitBroadcast();

	// AutoT socket
	int CreateAutoTSocket();
	int CloseAutoTSocket();

	// Broadcast Socket
	int CreateBroadcastSocket();
	int CloseBroadcastSocket();

	// This function for receive Broadcast Packet by UDP
	int ReceiveBroadcastPacket(char* azRcvData, int* nRcvLength);

	// This function for receive Auto T Packet by TCP
	int ReceiveAutoTPacket(char* szRcvData, int* nRcvLength);
	// This function for send Auto T Packet by TCP
	int SendAutoTPacket(char* szSndData, int nSndLength);
	
	SOCKET				m_AutoTSock;
	SOCKET				m_BroadcastSock;

	struct sockaddr_in	m_HOSESocket;
	int					m_nHOSESocketLength;

	int					m_nConnected;
};

#endif // !defined(AFX_BROKERSOCKET_H__3FFB7A44_AC13_471E_A473_DBB227D7709E__INCLUDED_)
