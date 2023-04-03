// BrokerSocket.cpp: implementation of the CBrokerSocket class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "BrokerCommunication.h"
#include "BrokerSocket.h"

#include "BrokerCommunicationDlg.h"
#include "ConnectionSetting.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

HANDLE g_hMutexAutoTSock;
HANDLE g_hMutexEchoTime;

CBrokerSocket::CBrokerSocket()
{
	int nRet = RETURN_SUCCESS;
	WORD WINSOCK_VERSION1=MAKEWORD(2,0);
	WSADATA wsaData;

	if( WSAStartup(WINSOCK_VERSION1, &wsaData) != 0 )
	{
		nRet = RETURN_FAIL;
		LOG_ERROR("WSAAtartup failure. Error code = %d\n", WSAGetLastError());
	}

	g_hMutexAutoTSock = CreateMutex(0, FALSE, 0);
	
}

CBrokerSocket::~CBrokerSocket()
{

}

// Init Broadcast
int CBrokerSocket::InitBroadcast()
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

finish:
	return nRet;
}

// Exit Broadcast
int CBrokerSocket::ExitBroadcast()
{
	int nRet = RETURN_SUCCESS;

	m_nConnected = 0;

	nRet = CloseBroadcastSocket();
	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Failed to close AutoT socket\n");
		goto finish;
	}
finish:
	return nRet;
}

// Init AutoT
int CBrokerSocket::Init()
{
	int nRet = RETURN_SUCCESS;

	m_nConnected = 0;

	nRet = CreateAutoTSocket();
	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Failed to create AutoT socket\n");
		nRet = RETURN_FAIL;
		CloseAutoTSocket();
		goto finish;
	}

/*
	nRet = CreateBroadcastSocket();
	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Failed to create Broadcast socket\n");
		nRet = RETURN_FAIL;
		CloseBroadcastSocket();
		goto finish;
	}
*/

finish:
	return nRet;
}

// Exit
int CBrokerSocket::Exit()
{
	int nRet = RETURN_SUCCESS;

	m_nConnected = 0;
/*
	nRet = CloseBroadcastSocket();
	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Failed to close AutoT socket\n");
		goto finish;
	}
*/
	nRet = CloseAutoTSocket();
	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Failed to close AutoT socket\n");
		goto finish;
	}

finish:
	return nRet;
}

// Create AutoT Packet
int CBrokerSocket::CreateAutoTSocket()
{
	int nRet = RETURN_SUCCESS;
	struct sockaddr_in  serverAddr;    // server's socket address 
    int                 sockAddrSize;  // size of socket address structure  
	char				serverName[100];\
	CString				msginfo;
	
	CString str;

	if ((m_AutoTSock = socket(AF_INET,SOCK_STREAM,0)) == INVALID_SOCKET) 
	{
		LOG_ERROR("Failed to create TCP Socket, error Code = %d\n", WSAGetLastError());
		nRet = RETURN_FAIL;
		goto finish;
	} 

	str.Format("%d.%d.%d.%d",g_stConnectionData.HOSEIPAddress[0],g_stConnectionData.HOSEIPAddress[1],
		g_stConnectionData.HOSEIPAddress[2],g_stConnectionData.HOSEIPAddress[3]);
	memcpy(serverName, str,str.GetLength());
	serverName[str.GetLength()]='\0';

	sockAddrSize = sizeof (struct sockaddr_in); 
	memset ((char *) &serverAddr, 0, sockAddrSize); 
	serverAddr.sin_family = AF_INET; 
	serverAddr.sin_port = htons (g_stConnectionData.nTCPPort); 
 
	if ((serverAddr.sin_addr.S_un.S_addr = inet_addr (serverName)) == INADDR_NONE) 
	{
		LOG_ERROR("Server name is wrong, please check, error code = %d !!!\n", WSAGetLastError());
		nRet = RETURN_FAIL;
		goto finish;
	}
		
	if(connect(m_AutoTSock,(struct sockaddr *)&serverAddr,sizeof(serverAddr))<0)
	{
		LOG_ERROR("Connect to %s, port %d failed, error code = %d\n", str, g_stConnectionData.nTCPPort, WSAGetLastError());
		nRet = RETURN_FAIL;
		goto finish;
	}

	LOG_INFO("Connect to %s, port %d successed\n", str,g_stConnectionData.nTCPPort);

	m_nConnected = 1;

finish:
	return nRet;
}

// Create Broadcast socket
int CBrokerSocket::CreateBroadcastSocket()
{
	int nRet = RETURN_SUCCESS;
	int sock_len;

	int optval =1;

	struct sockaddr_in local_sock;

	if ((m_BroadcastSock = socket(AF_INET,SOCK_DGRAM,0)) == INVALID_SOCKET) 
	{ 
		LOG_ERROR("Failed to create UDP Socket, error Code = %d\n", WSAGetLastError());
		nRet = RETURN_FAIL;
		goto finish;
	}

	memset(&local_sock, 0, sizeof(local_sock));
	local_sock.sin_family      = AF_INET;
	local_sock.sin_addr.s_addr =htonl(INADDR_ANY);
	local_sock.sin_port        = htons(g_stConnectionData.nUDPPort);

	sock_len = sizeof(local_sock);

	nRet = setsockopt(m_BroadcastSock, SOL_SOCKET, SO_REUSEADDR, (char *) &optval, sizeof(optval));
	if(nRet < 0)
	{
		LOG_ERROR("Failed to setsockopt, error Code = %d\n", WSAGetLastError());
	}

	nRet = bind(m_BroadcastSock,(struct sockaddr *)&local_sock, sock_len);
	if(nRet < 0)
	{
		nRet = RETURN_FAIL;
		LOG_ERROR("Failed to bind UDP Socket, error Code = %d\n", WSAGetLastError());
		goto finish;
	}

finish:
	return nRet;
}

// Close AutoT socket
int CBrokerSocket::CloseAutoTSocket()
{
	int nRet = RETURN_SUCCESS;

	if(m_AutoTSock == NULL)
	{
		LOG_INFO("Already close AutoT Socket\n");
		goto finish;
	}

	nRet = closesocket(m_AutoTSock);
	if(nRet < 0)
	{
		nRet = RETURN_FAIL;
		LOG_ERROR("Failed to close TCP Socket, error Code = %d\n", WSAGetLastError());
		goto finish;
	}
	m_nConnected = 0;
	m_AutoTSock = NULL;
finish:

	return nRet;
}

// Close broadcast socket
int CBrokerSocket::CloseBroadcastSocket()
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

// Send AutoT packet
int CBrokerSocket::SendAutoTPacket(char* szSndData, int nSndLength)
{
	
	int nRet = RETURN_SUCCESS;
	int nLength;

	char	debugBuffer[MAX_SOCKET_BUFFER_SIZE];
	
	//memset(debugBuffer, '\0', sizeof(debugBuffer));
	//LOG_INFO("Sent Buffer: \n");	
	//memcpy(debugBuffer, szSndData, nSndLength);
	//debugBuffer[nSndLength] = '\n';
	//LOG_INFO(debugBuffer);


	if(m_AutoTSock==NULL){		
		return -1;
	}
 
	WaitForSingleObject(g_hMutexAutoTSock, INFINITE);
	nLength = send (m_AutoTSock, szSndData, nSndLength, 0); 
	ReleaseMutex(g_hMutexAutoTSock);
	if(nLength < 0){
		LOG_ERROR("Failed to send AutoT packet, error Code = %d\n", WSAGetLastError());
		nRet = RETURN_FAIL;
		goto finish;
	}

	if(nLength != nSndLength){
		LOG_ERROR("Failed to send all AutoT packet, Sent(%d) != %\n", nLength, nSndLength);
		nRet = RETURN_FAIL;
		goto finish;
	}
finish:
	return nRet;
}


// This function for receive Broadcast Packet by UDP
int CBrokerSocket::ReceiveBroadcastPacket(char* szRcvData, int* nRcvLength)
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
		m_nConnected = 0;
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
		WaitForSingleObject(g_hMutexAutoTSock, INFINITE);
		//nLength = recvfrom(m_BroadcastSock, buff, 1000, 0,(struct sockaddr *) &m_HOSESocket,&m_nHOSESocketLength);
		//nLength = recvfrom(m_BroadcastSock, buff, 1000, 0,(struct sockaddr *) 0, (int*)0);
		nLength = recvfrom(m_BroadcastSock, szRcvData, MAX_SOCKET_BUFFER_SIZE, 0,(struct sockaddr *) 0, (int*)0);
		ReleaseMutex(g_hMutexAutoTSock);
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

// This function for receive Auto T Packet by TCP
int CBrokerSocket::ReceiveAutoTPacket(char* szRcvData, int* nRcvLength)
{
	int nRet = RETURN_SUCCESS;
	int nLength = -1;

	fd_set rset;
	struct timeval timeout;

	int nSelect;

	CBrokerCommunicationDlg *m_pDlg = (CBrokerCommunicationDlg*)AfxGetMainWnd();
	if(!m_pDlg)
		return nRet;

	FD_ZERO(&rset);
	FD_SET(m_AutoTSock,&rset);

	//if(m_nConnected == 0)
		//timeout.tv_sec = 20;
	//else
	//	timeout.tv_sec = 3;

	if(m_pDlg->m_AutoTProtocol.m_nProgState == PROG_DATA_TRANFER)
	{
		timeout.tv_usec = 500000;
		timeout.tv_sec = 0;
	}
	else
		timeout.tv_sec = 20;
	
	timeout.tv_usec = 0;
	nSelect = select(FD_SETSIZE, &rset, NULL, NULL, &timeout);
	if (nSelect == -1){
		m_nConnected = 0;
		LOG_ERROR("Connection TCP error!!!\n");
		nRet = RETURN_FAIL;
		goto finish;
	}
	else if (nSelect == 0){
		//LOG_INFO("ReceiveAutoTPacket: Receive CTCI Message Timeout\n");
		nRet = RETURN_TIMEOUT;
		goto finish;
	}

	if(FD_ISSET(m_AutoTSock, &rset)){
		nLength = recv(m_AutoTSock, szRcvData, MAX_SOCKET_BUFFER_SIZE, 0);
		if(nLength < 0)	{
			// Comments by MinhDQ: Trong truong gui RR va RP bi sai, doan code nay bi lap lai hang nghin lan
			LOG_ERROR("Failed to receive AutoT Packet, error Code = %d\n", WSAGetLastError());
			nRet = RETURN_FAIL;
			goto finish;
		}
	}

finish:
	*nRcvLength = nLength;
	return nRet;
}
