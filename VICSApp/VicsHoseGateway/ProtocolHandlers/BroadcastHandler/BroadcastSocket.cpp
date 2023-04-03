// BroadcastSocket.cpp: implementation of the CBroadcastSocket class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "BroadcastHandler.h"
#include "BroadcastSocket.h"
#include "Cfg.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CBroadcastSocket::CBroadcastSocket()
{
	int nRet = RETURN_SUCCESS;
	WORD WINSOCK_VERSION1=MAKEWORD(2,0);
	WSADATA wsaData;

	if( WSAStartup(WINSOCK_VERSION1, &wsaData) != 0 )
	{
		nRet = RETURN_FAIL;
		LOG_ERROR("WSAAtartup failure. Error code = %d\n", WSAGetLastError());
	}
}

CBroadcastSocket::~CBroadcastSocket()
{

}

int CBroadcastSocket::InitSocket()
{
	int nRet = RETURN_SUCCESS;

	nRet = CreateBroadcastSocket();
	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Failed to create Broadcast socket\n");
		nRet = RETURN_FAIL;
		CloseBroadcastSocket();
		goto finish;
	}

	nRet = CreateRetransmissionSocket();
	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Failed to create Retransmission socket\n");
		nRet = RETURN_FAIL;
		CloseRetransmissionSocket();
		goto finish;
	}

finish:
	return nRet;
}

int CBroadcastSocket::CreateBroadcastSocket()
{
	int nRet = RETURN_SUCCESS;
	int sock_len;

	int optval =1;

	struct sockaddr_in local_addr;

	if ((m_BroadcastSock = socket(AF_INET,SOCK_DGRAM,0)) == INVALID_SOCKET) 
	{ 
		LOG_ERROR("Failed to create UDP Socket, error Code = %d\n", WSAGetLastError());
		nRet = RETURN_FAIL;
		goto finish;
	}

	memset(&local_addr, 0, sizeof(local_addr));
	local_addr.sin_family      = AF_INET;
	local_addr.sin_addr.s_addr =htonl(INADDR_ANY);
	local_addr.sin_port        = htons(g_cfg.m_udpPort);

	sock_len = sizeof(local_addr);

	nRet = setsockopt(m_BroadcastSock, SOL_SOCKET, SO_REUSEADDR, (char *) &optval, sizeof(optval));
	if(nRet < 0)
	{
		LOG_ERROR("Failed to setsockopt, error Code = %d\n", WSAGetLastError());
	}

	nRet = bind(m_BroadcastSock,(struct sockaddr *)&local_addr, sock_len);
	if(nRet < 0)
	{
		nRet = RETURN_FAIL;
		LOG_ERROR("Failed to bind UDP Socket, error Code = %d\n", WSAGetLastError());
		goto finish;
	}

finish:
	return nRet;
}

int CBroadcastSocket::CloseBroadcastSocket()
{
	int nRet = RETURN_SUCCESS;

	if(m_BroadcastSock == NULL)
	{
		LOG_INFO("Already close Broadcast Socket\n");
		goto finish;
	}

	nRet = closesocket(m_BroadcastSock);
	if(nRet < 0)
	{
		nRet = RETURN_FAIL;
		LOG_ERROR("Failed to close UDP Socket, error Code = %d\n", WSAGetLastError());
		goto finish;
	}
	m_BroadcastSock = NULL;

finish:
	return nRet;
}

int CBroadcastSocket::ReceiveBroadcastPacket(char *szRcvData, int *nRcvLength)
{
	int nRet = RETURN_SUCCESS;
	int nLength;

	fd_set rset;
	struct timeval timeout;

	FD_ZERO(&rset);
	FD_SET(m_BroadcastSock,&rset);

	timeout.tv_sec = 3;
	timeout.tv_usec = 0;

	int nSelect = select(FD_SETSIZE, &rset, NULL, NULL, &timeout);
	if (nSelect == -1)
	{		
		LOG_ERROR("Connection UDP error!!!\n");;
		nRet = RETURN_FAIL;
		goto finish;
	}
	else if (nSelect == 0)
	{
		//LOG_INFO("ReceiveBroadcastPacket: Receive Broadcast Message Timeout\n");
	}

	if(FD_ISSET(m_BroadcastSock, &rset))
	{		
		nLength = recvfrom(m_BroadcastSock, szRcvData, MAX_SOCKET_BUFFER_SIZE, 0,(struct sockaddr *) 0, (int*)0);		
		if(nLength < 0)
		{
			LOG_ERROR("Failed to receive Broadcast Packet, error Code = %d\n", WSAGetLastError());
			nRet = RETURN_FAIL;
			goto finish;
		}
	}
	
finish:
	*nRcvLength = nLength;
	return nRet;
}

//@@@ Than add
int CBroadcastSocket::CreateRetransmissionSocket()
{
	int nRet = RETURN_SUCCESS;
	int sock_len;

	int optval =1;

	struct sockaddr_in local_addr;

	if ((m_RetransmissionRcvSock = socket(AF_INET,SOCK_DGRAM,0)) == INVALID_SOCKET) 
	{ 
		LOG_ERROR("Failed to create UDP Rcv Socket, error Code = %d\n", WSAGetLastError());
		nRet = RETURN_FAIL;
		goto finish;
	}

	if ((m_RetransmissionSndSock = socket(AF_INET,SOCK_DGRAM,0)) == INVALID_SOCKET) 
	{ 
		LOG_ERROR("Failed to create UDP Snd Socket, error Code = %d\n", WSAGetLastError());
		nRet = RETURN_FAIL;
		goto finish;
	}

	memset(&local_addr, 0, sizeof(local_addr));
	local_addr.sin_family      = AF_INET;
	//local_addr.sin_addr.s_addr =htonl(INADDR_ANY);
	local_addr.sin_addr.s_addr = inet_addr("127.0.0.1");
	local_addr.sin_port        = htons(BROADCAST_RETRANSMISSION_UDP_PORT);

	memset(&autoT_addr, 0, sizeof(autoT_addr));
	autoT_addr.sin_family      = AF_INET;
	//autoT_addr.sin_addr.s_addr = htonl(INADDR_ANY);
	autoT_addr.sin_addr.s_addr = inet_addr("127.0.0.1");
	autoT_addr.sin_port        = htons(AUTOT_RETRANSMISSION_UDP_PORT);

	sock_len = sizeof(local_addr);

	nRet = setsockopt(m_RetransmissionRcvSock, SOL_SOCKET, SO_REUSEADDR, (char *) &optval, sizeof(optval));
	if(nRet < 0)
	{
		LOG_ERROR("Failed to setsockopt, error Code = %d\n", WSAGetLastError());
	}

	nRet = bind(m_RetransmissionRcvSock,(struct sockaddr *)&local_addr, sock_len);
	if(nRet < 0)
	{
		nRet = RETURN_FAIL;
		LOG_ERROR("Failed to bind UDP Socket, error Code = %d\n", WSAGetLastError());
		goto finish;
	}

finish:
	return nRet;
}

int CBroadcastSocket::CloseRetransmissionSocket()
{
	int nRet = RETURN_SUCCESS;

	if(m_RetransmissionRcvSock == NULL)
	{
		LOG_INFO("Already close Retransmission Socket\n");
		goto finish;
	}

	nRet = closesocket(m_RetransmissionRcvSock);
	if(nRet < 0)
	{
		nRet = RETURN_FAIL;
		LOG_ERROR("Failed to close UDP Socket, error Code = %d\n", WSAGetLastError());
		goto finish;
	}
	m_RetransmissionRcvSock = NULL;

finish:
	return nRet;
}

int CBroadcastSocket::SendAndReceiveRetransmissionPacket(char* szSndData, int nSndLength, char* szRcvData, int* nRcvLength)
{
	int nRet = RETURN_SUCCESS;
	int nLength = -1;

	fd_set rset;
	struct timeval timeout;

	struct sockaddr_in rcv_addr;
	int rcv_addr_len = sizeof(rcv_addr);;

	timeout.tv_sec = 3;
	timeout.tv_usec = 0;

	int nSelect;

	nLength = sendto(m_RetransmissionSndSock, szSndData, nSndLength, 0,(struct sockaddr *) &autoT_addr, sizeof (struct sockaddr));
	//nLength = sendto(m_RetransmissionRcvSock, szSndData, nSndLength, 0,(struct sockaddr *) &autoT_addr, sizeof (autoT_addr));		
	if(nLength < 0)
	{
		LOG_ERROR("Failed to send Retransmission MSG, error Code = %d\n", WSAGetLastError());
		nRet = RETURN_FAIL;
		goto finish;
	}

	nLength = -1;
	FD_ZERO(&rset);
	FD_SET(m_RetransmissionRcvSock,&rset);

	nSelect = select(FD_SETSIZE, &rset, NULL, NULL, &timeout);
	//nSelect = select(m_RetransmissionRcvSock + 1, &rset, NULL, NULL, &timeout);
	if (nSelect == -1)
	{		
		LOG_ERROR("Connection UDP error!!!\n");;
		nRet = RETURN_FAIL;
		goto finish;
	}
	else if (nSelect == 0)
	{
		//LOG_INFO("ReceiveBroadcastPacket: Receive Broadcast Message Timeout\n");
		nRet = RETURN_FAIL;
		goto finish;
	}

	if(FD_ISSET(m_RetransmissionRcvSock, &rset))
	{		
		nLength = recvfrom(m_RetransmissionRcvSock, szRcvData, MAX_SOCKET_BUFFER_SIZE, 0,(struct sockaddr *) &rcv_addr, (int*)&rcv_addr_len);		
		if(nLength < 0)
		{
			LOG_ERROR("Failed to receive Retransmission MSG, error Code = %d\n", WSAGetLastError());
			nRet = RETURN_FAIL;
			goto finish;
		}
	}
	
finish:
	*nRcvLength = nLength;
	return nRet;
}

//@@@