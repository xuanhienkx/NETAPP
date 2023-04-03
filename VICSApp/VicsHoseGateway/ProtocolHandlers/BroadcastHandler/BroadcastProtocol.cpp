// BroadcastProtocol.cpp: implementation of the CBroadcastProtocol class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "BroadcastHandler.h"
#include "BroadcastProtocol.h"
#include "Cfg.h"
#include "BroadcastSocket.h"



#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CBroadcastProtocol::CBroadcastProtocol()
{
	
}

CBroadcastProtocol::~CBroadcastProtocol()
{

}

int CBroadcastProtocol::CreateBroadcastPacketReceivingThread()
{
	int nRet = RETURN_SUCCESS;
	DWORD dwThreadID;

	// Create Thread for handling Broadcast Packet
	try{
		m_hBroadcastPacketReceivingThread = CreateThread(NULL, 0,(LPTHREAD_START_ROUTINE) BroadcastPacketReceivingThread,this, 0, &dwThreadID);
	}catch(CException exp){
		nRet = RETURN_FAIL;
		goto finish;
	}

	// Create Thread handling retransmission request
	/*@@@ Than comment
	try{
		m_hRetransmissionHandlingThread = CreateThread(NULL, 0,(LPTHREAD_START_ROUTINE) RetransmissionHandlingThread,this, 0, &dwThreadID);
	}catch(CException exp){
		nRet = RETURN_FAIL;
		goto finish;
	}
	*/

finish:
	return nRet;
}

int CBroadcastProtocol::CreateRetransmissionHandlingThread()
{
	int nRet = RETURN_SUCCESS;
	DWORD dwThreadID;

	// Create Thread handling retransmission request
	try{
		m_hRetransmissionHandlingThread = CreateThread(NULL, 0,(LPTHREAD_START_ROUTINE) RetransmissionHandlingThread,this, 0, &dwThreadID);
	}catch(CException exp){
		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
	return nRet;
}

//@@@ Than add
int CBroadcastProtocol::CreateHandlingManagerMessageThread()
{
	int nRet = RETURN_SUCCESS;
	DWORD dwThreadID;

	// Create Thread handling retransmission request
	try{
		m_hRetransmissionHandlingThread = CreateThread(NULL, 0,(LPTHREAD_START_ROUTINE) HandlingManagerMessageThread,this, 0, &dwThreadID);
	}catch(CException exp){
		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
	return nRet;
}
//@@@

DWORD CBroadcastProtocol::BroadcastPacketReceivingThread(CBroadcastProtocol *pBroadcastProtocol)
{

	int nRet = RETURN_SUCCESS;
	
	//return nRet;
	

	char	szRcvBuffer[MAX_SOCKET_BUFFER_SIZE];
	int		nRvcLength;	
	
	LOG_INFO("Start Thread: ThreadReceiveBroadcastMsgFromHOSE\n");	

	pBroadcastProtocol->m_nBroadcastSequenceNoStart = g_cfg.m_udpSequence;
	pBroadcastProtocol->m_nBroadcastSequenceNoNext = g_cfg.m_udpSequence;

	LOG_TRACE("Broker start with broadcast seq_no(%d)\n", g_cfg.m_udpSequence);	

	while(!g_nStopBroadcast)
	{
		// Receive Broadcast Message from UDP Port
		nRvcLength = -1;
		nRet = pBroadcastProtocol->m_broadcastSocket.ReceiveBroadcastPacket(szRcvBuffer, &nRvcLength);
		if((nRet == RETURN_SUCCESS) && (nRvcLength > 0))
		{
			pBroadcastProtocol->ProcessingBroadcastPacket(szRcvBuffer, nRvcLength);
		}
		else
		{

		}
	}

	g_nStopBroadcast = 0;
	LOG_INFO("Stop Broadcast packet receiving thread\n");

	return nRet;

}

//@@@ Than add
int CBroadcastProtocol::SendToAutoTHander(stRetransmissionFormat_Req* pMsg)
{
	int nRet = RETURN_SUCCESS;
	char rcvBuff[MAX_SOCKET_BUFFER_SIZE];
	int rcvLength;
	stRetransmissionFormat_Ack* pRcvMsg = (stRetransmissionFormat_Ack*)rcvBuff;

	nRet = m_broadcastSocket.SendAndReceiveRetransmissionPacket((char*)pMsg, sizeof(stRetransmissionFormat_Req), 
		rcvBuff, &rcvLength);
	if(nRet != RETURN_SUCCESS)
	{
		nRet = RETURN_FAIL;
		LOG_ERROR("Send or receive from autoT handler failed\n");
		goto finish;
	}

	if(pRcvMsg->result == RETRANSMISSION_ACK_SUCCESSED)
	{
		nRet = RETURN_SUCCESS;
		LOG_ERROR("Receive ACK from AutoT Handler.\n");
		goto finish;
	}
	if(pRcvMsg->result == RETRANSMISSION_ACK_FAIED)
	{
		nRet = RETURN_FAIL;
		LOG_ERROR("Receive NACK from AutoT Handler.\n");
		goto finish;
	}
finish:
	return nRet;
}
//@@@

DWORD CBroadcastProtocol::RetransmissionHandlingThread(CBroadcastProtocol *pBroadcastProtocol)
{
	int nRet = RETURN_SUCCESS;
	stRetransmissionFormat_Req RetransmissionMsg;

	RetransmissionMsg.mgsType = MSG_RETRANSMISSION_REQ;
	RetransmissionMsg.mgsLength = 16;
	
	LOG_INFO("Start Thread: RetransmissionHandlingThread\n");

	// Than add for testing
	/*
	while(1)
	{
		Sleep(1000);

		RetransmissionMsg.from_sequence_no = 1;
		RetransmissionMsg.to_sequence_no = 100;

		if(pBroadcastProtocol->SendToAutoTHander(&RetransmissionMsg) == RETURN_SUCCESS)
		{			
			LOG_INFO("OK --------- Send Retransmission request to Auto-t module. From sequence = %d, To sequence = %d\n", RetransmissionMsg.from_sequence_no, RetransmissionMsg.to_sequence_no);
		}
		else
		{
			LOG_INFO("Failed ----------- Send Retransmission request to Auto-t module. From sequence = %d, To sequence = %d\n", RetransmissionMsg.from_sequence_no, RetransmissionMsg.to_sequence_no);
		}
	}
	*/

	
	
	while(1)
	{
		Sleep(10000);
		// Checking if retransmission need it
		if (g_stRetransmissionInfo.m_stRetransmissionInfo.count == 0){
			//LOG_INFO("There is no required retransmission\n");
			continue;
		}

		// Get retransmision information [from_seq, to_seq]

		WaitForSingleObject(g_hMutexRetransmissionInfo,INFINITE);	
		g_stRetransmissionInfo.ReadReTransmissionFile();
		RetransmissionMsg.from_sequence_no = g_stRetransmissionInfo.m_stRetransmissionInfo.arrRetransmissionData[0].from_sequence_no;
		RetransmissionMsg.to_sequence_no = g_stRetransmissionInfo.m_stRetransmissionInfo.arrRetransmissionData[0].to_sequence_no;
		// Send to AutoTHandler
		LOG_INFO("Send Retransmission request to Auto-t module. From sequence = %d, To sequence = %d\n", RetransmissionMsg.from_sequence_no, RetransmissionMsg.to_sequence_no);
		if(pBroadcastProtocol->SendToAutoTHander(&RetransmissionMsg) == RETURN_SUCCESS)
		{			
			// Remove this retransmission information
			g_stRetransmissionInfo.DecreaseRetranmissionData();
		}
		g_stRetransmissionInfo.WriteRetransmissionFile();
		ReleaseMutex(g_hMutexRetransmissionInfo);

		
	}
	
	g_nStopBroadcast = 0;
	LOG_INFO("Stop Retransmission Handling thread\n");

finish:

	return nRet;
}

int CBroadcastProtocol::ProcessingBroadcastPacket(char *szBroadcastPacket, int nBroadcastPacketLength)
{
	int nRet = RETURN_SUCCESS;
	int nDataLength;
	int	nIsFirstReceive = 0;
	stBroadcastMessageFormat rcvPkt;
	unsigned int nSequenceNo;
	
	nRet = CheckPacket(szBroadcastPacket, nBroadcastPacketLength);
	if(nRet != RETURN_SUCCESS)
	{
		ERROR("Wrong broadcast(%p, %d) packet from HOSE\n", szBroadcastPacket, nBroadcastPacketLength);
		nRet = RETURN_FAIL;
		goto finish;
	}

	// Copy Packet Buffer to Structure
	DecodeBroadcastPacket(&rcvPkt, szBroadcastPacket, nBroadcastPacketLength);
	LOG_TRACE("Receive Broadcast Packet, seq_no = %d, market_id =%c, msg_cnt = %d\n", 
				rcvPkt.sequence_no, rcvPkt.market_id, rcvPkt.msg_cnt);

	nDataLength = nBroadcastPacketLength - BROADCAST_PACKET_HEADER_SIZE;
	nSequenceNo = rcvPkt.sequence_no;
	
	// Check wheather we need to request retransmission or not

	// This case happens if Broadcast Handler is started first time on a new day
	if (g_cfg.m_udpSequence > rcvPkt.sequence_no){
		// Reset UDP Sequence to 1
		g_cfg.m_udpSequence = 1;
		
		WaitForSingleObject(g_hMutexRetransmissionInfo,INFINITE);	
		// Rewrite calculated transmission information back to file
		g_stRetransmissionInfo.reset();
		g_stRetransmissionInfo.WriteRetransmissionFile();
		ReleaseMutex(g_hMutexRetransmissionInfo);

		goto ReTransmissionProcessing;
	}
	
	// This case happens if Broadcast Handler is restarted
	if (g_cfg.m_udpSequence < rcvPkt.sequence_no){
		goto ReTransmissionProcessing;
	} 
	
	// No need Retransmission
	if (g_cfg.m_udpSequence = rcvPkt.sequence_no){
		goto ParsingBroadcastPacket;
	} 
ReTransmissionProcessing:
	
	WaitForSingleObject(g_hMutexRetransmissionInfo,INFINITE);
	// Read Re-Transmission file for transmission information which has not been processed	
	g_stRetransmissionInfo.ReadReTransmissionFile();	
	
	// Caculate transmission information
	if (rcvPkt.sequence_no == 1){
		g_stRetransmissionInfo.WriteRetransmissionFile();
		ReleaseMutex(g_hMutexRetransmissionInfo);
		goto ParsingBroadcastPacket;
	}else{
		g_stRetransmissionInfo.CalculateRetransmisionInfo(g_cfg.m_udpSequence, rcvPkt.sequence_no - 1);
	}	
	
	// Rewrite calculated transmission information back to file
	g_stRetransmissionInfo.WriteRetransmissionFile();
	
	ReleaseMutex(g_hMutexRetransmissionInfo);
	
ParsingBroadcastPacket:
	// Parsing Broadcast Packet And Push to Queue
	if (ParsingBroadcastPacketAndPushtoQueue(&rcvPkt, nDataLength) == RETURN_FAIL){
		nRet = RETURN_FAIL;
		LOG_ERROR("Error when parsing broadcast Packet and pushing to queue\n");
		goto finish;
	}

	// Save last received udp sequence to parameter file	
	g_cfg.m_udpSequence = nSequenceNo + 1;
	g_cfg.SaveParameters();

finish:
	return nRet;
}

int CBroadcastProtocol::CheckPacket(char *szBuffer, int nBufferLength)
{
	int nRet = RETURN_SUCCESS;
	unsigned short	tmpShort;

	// memcpy(&tmpShort, &szBuffer[0], 2);

	tmpShort = ConvertModulo96ToShort(szBuffer);

	//if((tmpShort + 2 /*length*/ + 1/*etx char*/) != nBufferLength)
/*
	if((tmpShort + 2) != nBufferLength)
	{
		LOG_ERROR("Packet Length Mismatch [%d != %d]\n", tmpShort+2, nBufferLength);
		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
*/
	return nRet;
}

int CBroadcastProtocol::DecodeBroadcastPacket(stBroadcastMessageFormat *pMsg, char *szBuffer, int nLength)
{
	int nRet = 0, index = 0;

	char modulo96[4];
	memset(modulo96, 0, sizeof(modulo96));

	// sequence number
	memcpy(modulo96, &szBuffer[index], 3);
	pMsg->sequence_no = ConvertModulo96To3Bytes(modulo96);
	index+=3;

	// market id
	pMsg->market_id = szBuffer[index];
	index+=1;

	// market count
	pMsg->msg_cnt = ConvertModulo96ToChar(&szBuffer[index]);
	index+=1;

	if(MAX_SOCKET_BUFFER_SIZE >= nLength - PACKET_HEADER_SIZE)
		memcpy(pMsg->data, &szBuffer[index], nLength - BROADCAST_PACKET_HEADER_SIZE);

	return nRet;
}

unsigned short CBroadcastProtocol::ConvertModulo96ToShort(char *szModulo96)
{
	unsigned short nShort = 0;
	nShort = (szModulo96[0]-32)*96 + (szModulo96[1]-32);
	return nShort;
}

int CBroadcastProtocol::ConvertModulo96To3Bytes(char *szModulo96)
{
	unsigned int nInt = 0;

	nInt = (szModulo96[0]-32)*96*96 + (szModulo96[1]-32)*96 + 
			(szModulo96[2]-32);

	return nInt;

}

unsigned char CBroadcastProtocol::ConvertModulo96ToChar(char *szModulo96)
{
	unsigned char nChar = 0;
	nChar = (szModulo96[0]-32);
	return nChar;
}

int CBroadcastProtocol::ParsingBroadcastPacketAndPushtoQueue(stBroadcastMessageFormat *rcvPkt, int iDataLength)
{	

	char	szQueue[MAX_SOCKET_BUFFER_SIZE];
	int		nQueueIndex = 0;
	int nRet = RETURN_SUCCESS;

	rcvPkt->data[iDataLength] = US_CHAR;

	for(int i = 0; i <= iDataLength; i++){
		if(rcvPkt->data[i] == US_CHAR){ // Found one Broadcast Msg		
			memcpy(szQueue, &rcvPkt->data[nQueueIndex], i - nQueueIndex);
			szQueue[i - nQueueIndex] = 0;
			// Push to Queue

			if (m_queue.PushBroadcastQueue(szQueue, i - nQueueIndex) == RETURN_FAIL){
				nRet = RETURN_FAIL;
				goto finish;
			}

			// Pass US Character
			nQueueIndex = i + 1;
		}
	}
finish:
	return nRet;
}

//@@@ Than add
// This function for handling the Message from Manager Program
DWORD CBroadcastProtocol::HandlingManagerMessageThread(CBroadcastProtocol *pBroadcastProtocol)
{
	int nRet = RETURN_SUCCESS;
	int rcvSock;
	int sock_len;

	char szRcvData[MAX_SOCKET_BUFFER_SIZE];

	int optval =1;

	struct sockaddr_in local_addr;
	struct sockaddr_in manager_addr;
	int manager_addr_len;

	int nLength;

	int nSelect;
	fd_set rset;
	struct timeval timeout;

	if ((rcvSock = socket(AF_INET,SOCK_DGRAM,0)) == INVALID_SOCKET) 
	{ 
		LOG_ERROR("Failed to create UDP Socket, error Code = %d\n", WSAGetLastError());
		nRet = RETURN_FAIL;
		goto finish;
	}

	memset(&local_addr, 0, sizeof(local_addr));
	local_addr.sin_family      = AF_INET;
	local_addr.sin_addr.s_addr =htonl(INADDR_ANY);
	local_addr.sin_port        = htons(HANDLING_MANAGER_UDP_PORT);

	sock_len = sizeof(local_addr);

	nRet = setsockopt(rcvSock, SOL_SOCKET, SO_REUSEADDR, (char *) &optval, sizeof(optval));
	if(nRet < 0)
	{
		LOG_ERROR("Failed to setsockopt, error Code = %d\n", WSAGetLastError());
	}

	nRet = bind(rcvSock,(struct sockaddr *)&local_addr, sock_len);
	if(nRet < 0)
	{
		nRet = RETURN_FAIL;
		LOG_ERROR("Failed to bind UDP Socket, error Code = %d\n", WSAGetLastError());
		goto finish;
	}


	timeout.tv_sec = 3;
	timeout.tv_usec = 0;

	// Loop for receiving the message
	while (1)
	{
		FD_ZERO(&rset);
		FD_SET(rcvSock,&rset);

		nSelect = select(FD_SETSIZE, &rset, NULL, NULL, &timeout);
		if (nSelect == -1)
		{		
			LOG_ERROR("Connection UDP error!!!\n");;
			nRet = RETURN_FAIL;
		}
		else if (nSelect == 0)
		{
			//LOG_INFO("ReceiveBroadcastPacket: Receive Broadcast Message Timeout\n");
		}
		if(FD_ISSET(rcvSock, &rset))
		{		
			nLength = recvfrom(rcvSock, szRcvData, MAX_SOCKET_BUFFER_SIZE, 0,(struct sockaddr *) &manager_addr, &manager_addr_len);
			if(nLength < 0)
			{
				continue;
			}
		}

		// Processing with szRcvData and nLength receved from Manager

		// Send Ack with rcvSock [Manager Socket]
		// nLength = sendto(rcvSock, szRcvData, MAX_SOCKET_BUFFER_SIZE, 0,(struct sockaddr *) &manager_addr, manager_addr_len);		
	}

finish:
	return nRet;
}
//@@@