`// AutoTProtocol.cpp: implementation of the CAutoTProtocol class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "BrokerCommunication.h"
#include "AutoTProtocol.h"
#include "BrokerCommunicationDlg.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

stTransmissionData	g_stTransmissionData;
stUnsentData	g_stUnsentData;

stRestransmissionInfor g_stRestransmissionInfor;

extern HANDLE g_hMutexLockStopFlag;
extern HANDLE g_hMutexLockDataTransmission;
extern HANDLE g_hMutexSendingAckFlag;

extern HANDLE	g_hRetransmissionLock;

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CAutoTProtocol::CAutoTProtocol()
{
	m_nProgState = PROG_STOP;
}

CAutoTProtocol::~CAutoTProtocol()
{

}

int CAutoTProtocol::Start()
{
	int nRet = RETURN_SUCCESS;

	m_nProgState = PROG_PROCESSING;
	// Init AutoT Protocol
	nRet = Init();
	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Failed to init AutoT protocol Handler\n");
		if((nRet = Exit()) == RETURN_SUCCESS)
		{
			LOG_INFO("Successed exit AutoT protocol Handler\n");
		}
		else
		{
			LOG_INFO("Failed exit AutoT protocol Handler\n");
		}
		nRet = RETURN_FAIL;
		goto finish;
	}

	LOG_INFO("Successed init AutoT protocol Handler\n");

	m_nProgState = PROG_START;
	LOG_INFO("Connected to HOSE, State = PROG_START\n");

	// Setup connection with HOSE
	nRet = EstablishConnection();
	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Failed to Establish Connection to HOSE\n");
		if((nRet = Exit()) == RETURN_SUCCESS)
		{
			LOG_INFO("Successed exit AutoT protocol Handler\n");
		}
		else
		{
			LOG_INFO("Failed exit AutoT protocol Handler\n");
		}

		nRet = RETURN_FAIL;
		goto finish;
	}

	m_nProgState = PROG_DATA_TRANFER;
	LOG_INFO("Establish connection to HOSE, State = PROG_DATA_TRANFER\n");

	// Starting working
	CreateWorkThread();

finish:
	return nRet;
}

int CAutoTProtocol::Stop()
{
	int nRet = RETURN_SUCCESS;

	WaitForSingleObject(g_hMutexLockStopFlag, INFINITE);
	nStopFlag = TRYING_STOP;
	ReleaseMutex(g_hMutexLockStopFlag);
	goto finish;
#if 0 // PhanMinh comment 20080720
	m_nProgState = PROG_PROCESSING;
	// Disconnection with HOSE
	nRet = TerminateConnection();
	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Failed to Terminate Connection to HOSE\n");
		goto finish;
	}
#endif
	// Exit AutoT Protocol
#if 0 // Than comment 20080711
	nRet = Exit();
	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Failed to exit AutoT protocol Handler\n");
		goto finish;
	}
#endif
finish:
	return nRet;
}

int CAutoTProtocol::Init()
{
	int nRet = RETURN_SUCCESS;

	// Init Parameters
	
	nRet = InitializeData();
	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Init Parameters Failed\n");
		goto finish;
	}
/*
	m_Queue.InitQueue();
	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Init Queue Parameters Failed\n");
		goto finish;
	}
*/
	nRet = m_Socket.Init();
	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Init Socket Parameters Failed\n");
		goto finish;
	}

finish:
	return nRet;
}

int CAutoTProtocol::Exit()
{
	int nRet = RETURN_SUCCESS;

	m_nStopAutoT = 0;
	m_nStopBroadcast = 0;
	m_nStopPoolingQueue = 0;

	m_Socket.Exit();
	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Exit Socket Failed\n");
		goto finish;
	}
/*
	m_Queue.ExitQueue();
	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Exit Queue Parameters Failed\n");
		goto finish;
	}
*/
	UnInitializeData();
	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Exit Parameters Failed\n");
		goto finish;
	}

	m_nProgState = PROG_STOP;

finish:
	return nRet;
}

// Reading Parameters from Storage Media
int CAutoTProtocol::InitializeData()
{
	int nRet = RETURN_SUCCESS, i;

	m_nStopAutoT = 0;
	m_nStopBroadcast = 0;
	m_nStopPoolingQueue = 0;

	m_nWindow_Size = AUTO_T_WINDOWS_SIZE;

	m_nAutoTSequenceNo = g_stTransmissionData.nAutoTSequenceNo;
	m_nAutoTSequenceNoStart = g_stTransmissionData.nAutoTSequenceNoStart;
	m_nAutoTSequenceNoNext = m_nAutoTSequenceNoStart;

	m_nAutoTAckSequenceNo = g_stTransmissionData.nAutoTAckSequenceNo;

	LOG_TRACE("Broker start with seq_no(%d), seq_start(%d), seq_ack(%d)\n", 
		m_nAutoTSequenceNo, m_nAutoTSequenceNoStart, m_nAutoTAckSequenceNo);

	// Check packet
	//char	debugBuffer[MAX_SOCKET_BUFFER_SIZE + 1];
	for(i = 0; i < AUTO_T_WINDOWS_SIZE; i++)
	{
/*
		// For testing
		char szMessage1C[] = {0x41, 0x21, // A !
		0x31, 0x43, //1C
		0x30, 0x30, 0x32, // 002: FIRM
		0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, // Order Number: 00000001
		0x31, 0x39, 0x30, 0x36 //1906
		};

		int nMessage1CLength = sizeof(szMessage1C)/sizeof(char);

		g_stTransmissionData.arrSndPacket[i].sequence_no = m_nAutoTSequenceNo + i - 1;
		g_stTransmissionData.arrSndPacket[i].len = PACKET_HEADER_SIZE + nMessage1CLength;
		memcpy(g_stTransmissionData.arrSndPacket[i].data, szMessage1C, nMessage1CLength);
*/
		LOG_TRACE("Packet[%d], seq_no = %d\n", i, g_stTransmissionData.arrSndPacket[i].sequence_no);	
		//memset(debugBuffer, '\0', sizeof(debugBuffer));		
		//memcpy(&debugBuffer, g_stTransmissionData.arrSndPacket[i].data, g_stTransmissionData.arrSndPacket[i].len - PACKET_HEADER_SIZE);
		//debugBuffer[g_stTransmissionData.arrSndPacket[i].len - PACKET_HEADER_SIZE] = '\n';
		//LOG_INFO(debugBuffer);

		
	}

	// Comments by MinhDQ on June 17, 2008
	/*
	if(((m_nAutoTSequenceNo - m_nAutoTSequenceNoStart) > AUTO_T_WINDOWS_SIZE) ||
		(m_nAutoTSequenceNoStart > m_nAutoTSequenceNo))
	{
		nRet = RETURN_ABNORMAL;
		goto finish;
	}*/


	// Depen on connection mode, we initilize the parameters for communication
	m_nConnection_Mode = g_stConnectionData.nConnectionMode;
	m_nLinkID = g_stConnectionData.nLinkID;

	m_strPassword.Format("%s", g_stConnectionData.szPassword);

	m_nNumOfMarket = 1;
	m_arrMarket[0].market_id = g_stConnectionData.szMarketID;
	m_arrMarket[0].firm_id[0] = g_stConnectionData.szFirmID[0];
	m_arrMarket[0].firm_id[1] = g_stConnectionData.szFirmID[1];
	m_arrMarket[0].firm_id[2] = g_stConnectionData.szFirmID[2];

	// Setting Packet Parameters
	m_nDataSizeOfPacket = g_stConnectionData.nMaxPacketSize;
	m_nTimeoutWaitingPacket = g_stConnectionData.nMaxPacketTime;
	
	m_nBroadcastSequenceNoStart = g_stConnectionData.nBroadcastSeq;
	m_nBroadcastSequenceNoNext = g_stConnectionData.nBroadcastSeq;

	LOG_TRACE("Broker start with broadcast seq_no(%d)\n", m_nBroadcastSequenceNoStart);

//finish:
	return nRet;
}

int CAutoTProtocol::UnInitializeData()
{
	int nRet = RETURN_SUCCESS;

	return nRet;
}

int CAutoTProtocol::EstablishConnection()
{
	int i, index = 0;
	int nRet = RETURN_SUCCESS;
	int nResult;

	stAutoTMessageFormat	sndPkt, rcvPkt;

	char modulo96[4];

	unsigned int nLeftOverSequenceNo;
	unsigned int nLeftOverAckSequenceNo;
	stAutoTMessageFormat *pLeftOverPacket = NULL;

	// Send HELLO msg
	sndPkt.len = PACKET_HEADER_SIZE;
	sndPkt.sequence_no = m_nAutoTSequenceNo;
	sndPkt.ack_sequence_number = m_nAutoTAckSequenceNo;
	sndPkt.opcode = HELLO_MSG;
	sndPkt.linkID = m_nLinkID;

	// Connection Mode
	sndPkt.data[0] = m_nConnection_Mode;
	memcpy(&sndPkt.data[1], m_strPassword, m_strPassword.GetLength());

	// EOS
	index = m_strPassword.GetLength() + 1;
	sndPkt.data[index] = 0;
	index += 1;
	// Number of Market
	ConvertCharToModulo96(m_nNumOfMarket, modulo96);
	sndPkt.data[index] = modulo96[0];
	index += 1;

	for(i = 0; i < m_nNumOfMarket; i++)
	{
		sndPkt.data[index] = m_arrMarket[i].market_id;
		index += 1;
		memcpy(&sndPkt.data[index], m_arrMarket[i].firm_id, 3);
		index +=3;
	}

	sndPkt.len += index;
	nRet = SendPacket(&sndPkt);

	if(nRet < 0)
	{
		LOG_ERROR("Failed to send HELLO Packet, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
		Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);
		nRet = RETURN_FAIL;
		goto finish;
	}

	LOG_TRACE("Send HELLO Packet, opcode = %s, seq_no = %d, ack_seq_no =%d, mode = %c\n", 
		Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number, m_nConnection_Mode);

	nLeftOverSequenceNo = m_nAutoTSequenceNo;
continue_receive_packet:
	nRet = ReceivePacket(&rcvPkt);
	if(nRet < 0)
	{
		LOG_ERROR("Failed to receive packet after sending HELLO Packet\n");
		nRet = RETURN_FAIL;
		goto finish;
	}

	LOG_TRACE("Receive Packet after send HELLO, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
				Opcode2String(rcvPkt.opcode), rcvPkt.sequence_no, rcvPkt.ack_sequence_number);

	// Receive LEFTOVER and LEFTOVERLAST
	if((rcvPkt.opcode == LEFTOVER_MSG) || (rcvPkt.opcode == LEFTOVER_LAST_MSG))
	{
		if (rcvPkt.opcode == LEFTOVER_MSG) 
		{
			LOG_TRACE("Receive LEFTOVER, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
				Opcode2String(rcvPkt.opcode), rcvPkt.sequence_no, rcvPkt.ack_sequence_number);
		}
		else 
		{
			LOG_TRACE("Receive LEFTOVER_LAST Packet, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
				Opcode2String(rcvPkt.opcode), rcvPkt.sequence_no, rcvPkt.ack_sequence_number);
		}
		

		m_nAutoTAckSequenceNo = rcvPkt.sequence_no + 1; // Update ACKSeq

		if(Processing_LeftoverPacket(&rcvPkt) >= 0)
		{
			// Send ACK
			sndPkt.len = PACKET_HEADER_SIZE;			

			sndPkt.sequence_no = m_nAutoTSequenceNo;
			sndPkt.ack_sequence_number = m_nAutoTAckSequenceNo;
			sndPkt.opcode = ACK_MSG;
			sndPkt.linkID = m_nLinkID;

			nRet = SendPacket(&sndPkt);
			if(nRet < 0)
			{
				LOG_ERROR("Failed to send ACK Packet, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
				Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);
				nRet = RETURN_FAIL;
				goto finish;
			}

			LOG_TRACE("Send Ack Packet response to LEFTOVER  packet, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
				Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);

			if(rcvPkt.opcode == LEFTOVER_MSG)
				goto continue_receive_packet;
		}
	}
	else
	{
		goto hello_reply_step;
	}

	// Receive HELLO REPLY
	nRet = ReceivePacket(&rcvPkt);
	if(nRet < 0)
	{
		LOG_ERROR("Failed to receive packet after sending HELLO Packet\n");
		nRet = RETURN_FAIL;
		goto finish;
	}

hello_reply_step:
	if(rcvPkt.opcode != HELLO_REPLY_MSG)
	{
		LOG_ERROR("This packet must be HELLO REPLY Packet\n");
		nRet = RETURN_FAIL;
		LOG_TRACE("Receive Hello Reply Packet, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
				Opcode2String(rcvPkt.opcode), rcvPkt.sequence_no, rcvPkt.ack_sequence_number);
		DumpData(rcvPkt.data, rcvPkt.len - PACKET_HEADER_SIZE);
		goto finish;
	}

	LOG_TRACE("Receive Hello Reply Packet, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
				Opcode2String(rcvPkt.opcode), rcvPkt.sequence_no, rcvPkt.ack_sequence_number);

	m_nServerConnection_Mode = rcvPkt.data[0];
	LOG_INFO("Server Mode [%c]\n", m_nServerConnection_Mode);

	if((m_nConnection_Mode == 'B') && (m_nServerConnection_Mode == 'C'))
	{
		m_nAutoTAckSequenceNo = rcvPkt.sequence_no;

		m_nAutoTSequenceNo = rcvPkt.ack_sequence_number;
		m_nAutoTSequenceNoStart = rcvPkt.ack_sequence_number;
		m_nAutoTSequenceNoNext = rcvPkt.ack_sequence_number;

		goto send_confirm;
	}

	// Check LEFT OVER from Broker
	LOG_INFO("CheckLeftOverPacket(%d, %d)\n", nLeftOverSequenceNo, rcvPkt.ack_sequence_number);
	nRet = CheckLeftOverPacket(nLeftOverSequenceNo, rcvPkt.ack_sequence_number);
	if((nRet == CHECK_SEQ_FAILED) || (nRet == CHECK_SEQ_WRONG))
	{
		LOG_ERROR("Wrong ack_seq_no(%d) from HOSE\n", rcvPkt.ack_sequence_number);
		nRet = RETURN_FAIL;
		goto finish;
	}

	if(nRet == CHECK_SEQ_LEFT_OVER)
	{
		// Send LEFTOVER and LEFTOVERLAST
		nLeftOverAckSequenceNo = rcvPkt.ack_sequence_number;
		//m_nAutoTAckSequenceNo = nLeftOverSequenceNo;
continue_send_packet:
		nRet = GetLeftOverPacket(nLeftOverSequenceNo, nLeftOverAckSequenceNo, &pLeftOverPacket);
		if((nRet == LEFTOVER_MSG) || (nRet == LEFTOVER_LAST_MSG)){
			sndPkt.len = pLeftOverPacket->len;
			//sndPkt.sequence_no = GetAutoTSequenceNumber();
			//sndPkt.ack_sequence_number = GetAutoTAckSequenceNumber(m_nAutoTAckSequenceNo);
			sndPkt.sequence_no = nLeftOverAckSequenceNo; // Modified by MinhDq on June 18, 2008 11:52 AM
			sndPkt.ack_sequence_number = m_nAutoTAckSequenceNo; // Modified by MinhDq
			sndPkt.opcode = (unsigned short)nRet;
			sndPkt.linkID = m_nLinkID;

			memcpy(sndPkt.data, pLeftOverPacket->data, pLeftOverPacket->len - PACKET_HEADER_SIZE);

			nResult = SendPacket(&sndPkt);
			if(nResult < 0)
			{
				LOG_ERROR("Failed to send LEFT OVER, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);

				nRet = RETURN_FAIL;
				goto finish;
			}

			if(nRet == LEFTOVER_MSG)
			{
				LOG_TRACE("Send LEFT OVER, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);
			}
			else
			{
				LOG_TRACE("Send LEFT OVER LAST, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);
			}

			nLeftOverAckSequenceNo++;

			// Waiting ACK
			nResult = ReceivePacket(&rcvPkt);
			if(nResult < 0)
			{
				LOG_ERROR("Failed to receive packet after sending LEFTOVER or LEFOVERLAST Packet\n");
				nRet = RETURN_FAIL;
				goto finish;
			}

			LOG_TRACE("Receive Packet, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
				Opcode2String(rcvPkt.opcode), rcvPkt.sequence_no, rcvPkt.ack_sequence_number);

			if(rcvPkt.opcode != ACK_MSG)
			{
				LOG_ERROR("This Packet must ACK Packet\n");
				DumpData(rcvPkt.data, rcvPkt.len - PACKET_HEADER_SIZE);
				goto finish;
			}

			//m_nAutoTAckSequenceNo = nLeftOverAckSequenceNo;

			if(nRet == LEFTOVER_MSG)
			{
				goto continue_send_packet;
			}
		}
	}else if (nRet == RETURN_FAIL){
		LOG_ERROR("Suitable recovery packet not found\n");
		nRet = RETURN_FAIL;
		goto finish;
	}

send_confirm:
	// Send Confirm
	sndPkt.len = PACKET_HEADER_SIZE;
	//sndPkt.sequence_no = GetAutoTSequenceNumber();;
	//sndPkt.ack_sequence_number = GetAutoTAckSequenceNumber(m_nAutoTAckSequenceNo);
	//sndPkt.sequence_no = m_nAutoTSequenceNo; // Modified by MinhDQ on June 18, 2008
	sndPkt.sequence_no = m_nAutoTSequenceNo; // Modified by MinhDQ on June 18, 2008
	sndPkt.ack_sequence_number = m_nAutoTAckSequenceNo;// Modified by MinhDQ on June 18, 2008
	sndPkt.opcode = CONFIRM_MSG;
	sndPkt.linkID = m_nLinkID;

	nRet = SendPacket(&sndPkt);
	if(nRet < 0)
	{
		LOG_ERROR("Failed to send CONFIRM, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);
		nRet = RETURN_FAIL;
		goto finish;
	}

	LOG_TRACE("Send CONFIRM successfully, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);

	// Next Step, DATA transmission
	m_nAutoTSequenceNoStart = m_nAutoTSequenceNo;
	m_nAutoTSequenceNoNext = m_nAutoTSequenceNoStart;
	m_nAutoCurrTAckSequenceNo = m_nAutoTAckSequenceNo;
	WriteTransmissionSeqAndAckSeq(m_nAutoTSequenceNo, m_nAutoTAckSequenceNo);

	// Send unsent data if there is
	if (g_stUnsentData.nCount > 0){
		nResult = SendPacket(&g_stUnsentData.arrSndPacket);
		// Increase ourNextSequence
		m_nAutoTSequenceNo++;
		
		//nResult = -1;
		if(nResult < 0){
			LOG_ERROR("Failed to over load send unsent packet, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
			Opcode2String(sndPkt.opcode), sndPkt.sequence_no, m_nAutoTAckSequenceNo);

			nRet = RETURN_FAIL;
			goto save_overload_unsent_data;
		}else{
			LOG_TRACE("Send over load unsent packet, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
				Opcode2String(sndPkt.opcode), sndPkt.sequence_no, m_nAutoTAckSequenceNo);
				
		}
save_overload_unsent_data:
		// Save DATA to Transmission DB		
		WaitForSingleObject(g_hMutexLockDataTransmission, INFINITE);
		WriteTransmissionSeqAndAckSeqAndPacket(m_nAutoTSequenceNo, m_nAutoTAckSequenceNo,
		m_nAutoTSequenceNo%AUTO_T_WINDOWS_SIZE, &g_stUnsentData.arrSndPacket);		
		m_nAutoCurrTAckSequenceNo = m_nAutoTAckSequenceNo;
		ReleaseMutex(g_hMutexLockDataTransmission);	

		//Delete over load unsent data
		g_stUnsentData.nCount = 0;
		WriteUnsentData();

	}

finish:
	return nRet;
}

int CAutoTProtocol::CheckLeftOverPacket(unsigned int nSequenceNo, unsigned int nAckSequenceNo)
{
	int nRet = CHECK_SEQ_WRONG;

	if(nAckSequenceNo == nSequenceNo)
	{
		nRet = CHECK_SEQ_OK;
	}
	else if	((nAckSequenceNo < nSequenceNo) && ((nAckSequenceNo + m_nWindow_Size) >= nSequenceNo))
	{
		nRet = CHECK_SEQ_LEFT_OVER;
	}
	if(nAckSequenceNo + m_nWindow_Size < nSequenceNo)
	{
		nRet = CHECK_SEQ_FAILED;
	}
	else if	(nAckSequenceNo > nSequenceNo)
	{
		nRet = CHECK_SEQ_WRONG;
	}

	return nRet;
}

int CAutoTProtocol::CheckReceivingSequenceNumber(unsigned int server_ack_seq_no)
{
	/*
	 	
	int nRet = CHECK_SEQ_WRONG;

	if(server_ack_seq_no = m_nAutoTSequenceNo)
	{
		nRet = CHECK_SEQ_OK;
	}
	else if	((server_ack_seq_no > m_nAutoTSequenceNo) &&
		((m_nAutoTSequenceNo + m_nWindow_Size) > server_ack_seq_no))
	{
		nRet = CHECK_SEQ_LEFT_OVER;
	}
	if(server_ack_seq_no + m_nWindow_Size < m_nAutoTSequenceNo)
	{
		nRet = CHECK_SEQ_FAILED;
	}
	else if	(server_ack_seq_no < m_nAutoTSequenceNo)
	{
		nRet = CHECK_SEQ_WRONG;
	}

	return nRet;
	*/

	int nRet = CHECK_SEQ_WRONG;

	if((server_ack_seq_no + AUTO_T_WINDOWS_SIZE >= m_nAutoTSequenceNo) && (m_nAutoTSequenceNo >= server_ack_seq_no)){
		nRet = CHECK_SEQ_OK;
	}

	return nRet;

}

int CAutoTProtocol::TerminateThreads()
{
	// Stop Pooling Queue
	m_nStopPoolingQueue = 1;
	
	// Stop AutoT Receive
	m_nStopAutoT = 1;
	
	// Stop Broadcast Receive
	// m_nStopBroadcast = 1;

	while(1)
	{
		//if((m_nStopPoolingQueue == 0) && (m_nStopAutoT == 0) && (m_nStopBroadcast == 0))
		//if((m_nStopPoolingQueue == 0) && (m_nStopAutoT == 0))
		if(m_nStopPoolingQueue == 0)
			break;
		Sleep(100);
	}

	return RETURN_SUCCESS;
}

int CAutoTProtocol::TerminateSendingThread()
{
	// Stop Pooling Queue
	m_nStopPoolingQueue = 1;	
	
	while(1)
	{
		
		if(m_nSendingThreadStatus == 1)
			break;
		Sleep(100);
	}

	return RETURN_SUCCESS;
}

int CAutoTProtocol::TerminateReceivingThread()
{	
	// Stop AutoT Receive
	m_nStopAutoT = 1;	
	
	while(1)
	{
		
		if(m_nReceivingThreadStatus == 1)
			break;
		Sleep(100);
	}

	return RETURN_SUCCESS;
}

int CAutoTProtocol::MakeAndSendFNPacket()
{
	int nRet = RETURN_SUCCESS;
	
	stAutoTMessageFormat	sndPkt;

	// Send FINISH msg
	sndPkt.len = PACKET_HEADER_SIZE;
	sndPkt.sequence_no = GetAutoTSequenceNumber();
	sndPkt.ack_sequence_number = GetAutoTAckSequenceNumber(m_nAutoTAckSequenceNo);;
	sndPkt.opcode = FINISH_MSG;
	sndPkt.linkID = m_nLinkID;

	nRet = SendPacket(&sndPkt);
	if(nRet < 0)
	{
		LOG_ERROR("Failed to send FINISH, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);
		nRet = RETURN_FAIL;
		goto finish;
	}

	LOG_TRACE("Send FINISH, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);

finish:
	return nRet;
}

int CAutoTProtocol::MakeAndSendAFPacket()
{
	int nRet = RETURN_SUCCESS;
	
	stAutoTMessageFormat	sndPkt;

	// Send ACK FINISH
	sndPkt.len = PACKET_HEADER_SIZE;
	sndPkt.sequence_no = GetAutoTSequenceNumber();
	sndPkt.ack_sequence_number = GetAutoTAckSequenceNumber(m_nAutoTAckSequenceNo);
	sndPkt.opcode = ACKFIN_MSG;
	sndPkt.linkID = m_nLinkID;

	nRet = SendPacket(&sndPkt);
	if(nRet < 0)
	{
		LOG_ERROR("Failed to send ACK FINISH, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);
		nRet = RETURN_FAIL; 
		goto finish;
	}
	
	LOG_TRACE("Send ACK FINISH, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);

finish:
	return nRet;
}

int CAutoTProtocol::TerminateConnection()
{
	int index = 0, nRet = RETURN_SUCCESS;

#if 0	//	Comment 20080711
	stAutoTMessageFormat	sndPkt, rcvPkt;

	if(m_nProgState == PROG_DATA_TRANFER)
		TerminateThreads();

	// Send FINISH msg
	sndPkt.len = PACKET_HEADER_SIZE;
	sndPkt.sequence_no = GetAutoTSequenceNumber();
	sndPkt.ack_sequence_number = GetAutoTAckSequenceNumber(m_nAutoTAckSequenceNo);;
	sndPkt.opcode = FINISH_MSG;
	sndPkt.linkID = m_nLinkID;

	nRet = SendPacket(&sndPkt);
	if(nRet < 0)
	{
		LOG_ERROR("Failed to send FINISH, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);
		nRet = RETURN_FAIL;
		goto finish;
	}

	LOG_TRACE("Send FINISH, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);

	// Wait ACK FINSIH
	nRet = ReceivePacket(&rcvPkt);
	if(nRet < 0)
	{
		LOG_ERROR("Failed to receive ACK FINISH from HOSE\n");
		nRet = RETURN_FAIL;
		goto finish;
	}

	LOG_TRACE("Receive Packet, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
				Opcode2String(rcvPkt.opcode), rcvPkt.sequence_no, rcvPkt.ack_sequence_number);
	if(rcvPkt.opcode != ACKFIN_MSG)
	{
		LOG_ERROR("This packet must be ACK FINISH\n");
		nRet = RETURN_FAIL;
		goto finish;
	}

	// Send ACK FINISH
	sndPkt.len = PACKET_HEADER_SIZE;
	sndPkt.sequence_no = GetAutoTSequenceNumber();
	sndPkt.ack_sequence_number = GetAutoTAckSequenceNumber(m_nAutoTAckSequenceNo);;
	sndPkt.opcode = ACKFIN_MSG;
	sndPkt.linkID = m_nLinkID;

	nRet = SendPacket(&sndPkt);
	if(nRet < 0)
	{
		LOG_ERROR("Failed to send ACK FINISH, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);
		nRet = RETURN_FAIL; 
		goto finish;
	}
	
	LOG_TRACE("Send ACK FINISH, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);

	// Disconnect
	m_Socket.CloseAutoTSocket();
	//m_Socket.CloseBroadcastSocket();

finish:

#endif
	return nRet;
}

int CAutoTProtocol::TerminatePacketProcessing(stAutoTMessageFormat* pMsg)
{
	int index = 0, nRet = 0;

	stAutoTMessageFormat	sndPkt;

	if(m_nProgState == PROG_DATA_TRANFER)
	{
		TerminateSendingThread();
		
		// Send ACK FINISH
		sndPkt.len = PACKET_HEADER_SIZE;
		sndPkt.sequence_no = GetAutoTSequenceNumber();
		sndPkt.ack_sequence_number = GetAutoTAckSequenceNumber(m_nAutoTAckSequenceNo);;
		sndPkt.opcode = ACKFIN_MSG;
		sndPkt.linkID = m_nLinkID;

		nRet = SendPacket(&sndPkt);
		if(nRet < 0)
		{
			LOG_ERROR("Failed to send ACK FINISH, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);
			nRet = RETURN_FAIL;
			goto finish;
		}
		LOG_TRACE("Send ACK FINISH, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);

		m_nProgState = PROG_STOP;

		// Disconnect
		m_Socket.CloseAutoTSocket();
		//m_Socket.CloseBroadcastSocket();
	}

finish:
	return nRet;
}

// Check Packet is Valid or Not
int	CAutoTProtocol::CheckPacketFromHOSE(char* szBuffer, int nBufferLength)
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

// From AutoT Packet, Make the buffer for send to HOSE
int	CAutoTProtocol::EncodePacket(stAutoTMessageFormat* pMsg, char* szBuffer)
{
	int nRet = RETURN_SUCCESS, index = 0;
	unsigned short	tmpShort;

	char modulo96[4];

	// Length
	ConvertShortToModulo96(pMsg->len + 1 /*one byte for ETX_CHAR*/, modulo96);
	memcpy(&szBuffer[index], &modulo96, 2);
	index+=2;

	// sequence number
	ConvertIntToModulo96(pMsg->sequence_no, modulo96);
	memcpy(&szBuffer[index], &modulo96, 4);
	index+=4;

	// ack sequence number
	ConvertIntToModulo96(pMsg->ack_sequence_number, modulo96);
	memcpy(&szBuffer[index], &modulo96, 4);
	index+=4;

	// opcode
	tmpShort = pMsg->opcode;		// Than add 20080617
	// Swap opcode
	tmpShort = short_swap(tmpShort);
	memcpy(&szBuffer[index], &tmpShort, 2);
	index+=2;

	// link id
	ConvertShortToModulo96(pMsg->linkID, modulo96);
	memcpy(&szBuffer[index], &modulo96, 2);
	index+=2;

	// Content
	memcpy(&szBuffer[index], pMsg->data, pMsg->len - PACKET_HEADER_SIZE);
	index+=pMsg->len - PACKET_HEADER_SIZE;

	// etx 
	szBuffer[index] = ETX_CHAR;

	return nRet;
}

int	CAutoTProtocol::DecodePacket2(stArrayAutoTMessage* pArrayOfMsg, char* szBuffer, int nBufferLength)
{
	int nRet = 0, index = 0;
	unsigned short	tmpShort;
	

	char modulo96[4];	
	int i = 0;
	pArrayOfMsg->count = 0;
	while(nBufferLength > index){	
		// Length
		memcpy(modulo96, &szBuffer[index], 2);
		pArrayOfMsg->arrAutoTMessage[i].len = ConvertModulo96ToShort(modulo96) - 1 /*one byte for ETX_CHAR*/;
		index+=2;

		// sequence number
		memcpy(modulo96, &szBuffer[index], 4);
		pArrayOfMsg->arrAutoTMessage[i].sequence_no = ConvertModulo96ToInt(modulo96);
		index+=4;

		// ack sequence number
		memcpy(&modulo96, &szBuffer[index], 4);
		pArrayOfMsg->arrAutoTMessage[i].ack_sequence_number = ConvertModulo96ToInt(modulo96);
		index+=4;

		// opcode
		memcpy(&tmpShort, &szBuffer[index], 2);
		// Swap opcode
		tmpShort = short_swap(tmpShort);
		pArrayOfMsg->arrAutoTMessage[i].opcode = tmpShort;
		index+=2;

		// link id
		memcpy(modulo96, &szBuffer[index], 2);
		pArrayOfMsg->arrAutoTMessage[i].linkID = ConvertModulo96ToShort(modulo96);;
		index+=2;

		// Content
		//if(MAX_SOCKET_BUFFER_SIZE >= pArrayOfMsg->arrAutoTMessage[i].len - PACKET_HEADER_SIZE){
			memcpy(pArrayOfMsg->arrAutoTMessage[i].data, &szBuffer[index], pArrayOfMsg->arrAutoTMessage[i].len - PACKET_HEADER_SIZE);
			index+=pArrayOfMsg->arrAutoTMessage[i].len - PACKET_HEADER_SIZE;
		//}
		//else
		//{
			//DumpData();
		//}
		pArrayOfMsg->count +=1;		
		i +=1;
		index+=1;
	}
	LOG_INFO("Receive data which has: Number of AutoT packet = %d, Buffer Length: %d\n", i, nBufferLength);
	return nRet;
}

// The buffer receive from HOSE, make the AutoT Packet
int	CAutoTProtocol::DecodePacket(stAutoTMessageFormat* pMsg, char* szBuffer)
{
	int nRet = 0, index = 0;
	unsigned short	tmpShort;

	char modulo96[4];

	// Length
	memcpy(modulo96, &szBuffer[index], 2);
	pMsg->len = ConvertModulo96ToShort(modulo96) - 1 /*one byte for ETX_CHAR*/;
	index+=2;

	// sequence number
	memcpy(modulo96, &szBuffer[index], 4);
	pMsg->sequence_no = ConvertModulo96ToInt(modulo96);
	index+=4;

	// ack sequence number
	memcpy(&modulo96, &szBuffer[index], 4);
	pMsg->ack_sequence_number = ConvertModulo96ToInt(modulo96);;
	index+=4;

	// opcode
	memcpy(&tmpShort, &szBuffer[index], 2);
	// Swap opcode
	tmpShort = short_swap(tmpShort);
	pMsg->opcode = tmpShort;
	index+=2;

	// link id
	memcpy(modulo96, &szBuffer[index], 2);
	pMsg->linkID = ConvertModulo96ToShort(modulo96);;
	index+=2;

	// Content
	if(MAX_SOCKET_BUFFER_SIZE >= pMsg->len - PACKET_HEADER_SIZE)
	{
		memcpy(pMsg->data, &szBuffer[index], pMsg->len - PACKET_HEADER_SIZE);
	}
	else
	{
		//DumpData();
	}

	return nRet;
}

int	CAutoTProtocol::DecodeBroadcastPacket(stBroadcastMessageFormat* pMsg, char* szBuffer, int nLength)
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

int	CAutoTProtocol::SendPacket(stAutoTMessageFormat* pMsg)
{
	int iRet = RETURN_SUCCESS, index = 0;

	char	buff[MAX_SOCKET_BUFFER_SIZE];

	EncodePacket(pMsg, buff);

	iRet = m_Socket.SendAutoTPacket(buff, pMsg->len + 2 /* 2 bytes for length */ + 1  /*1 byte for ETX char*/);
	if(iRet < 0){
		LOG_ERROR("Failed to send AutoTPacket(%p), length = %d\n", buff, pMsg->len + 2);
		iRet = RETURN_FAIL;
		goto finish;
	}

	//m_nAutoCurrTAckSequenceNo = pMsg->ack_sequence_number;

finish:
	return iRet;
}

int	CAutoTProtocol::MakeAndSendEchoPacket(stAutoTMessageFormat* pMsg)
{
	int nRet = RETURN_SUCCESS;

	pMsg->len = PACKET_HEADER_SIZE;
	pMsg->sequence_no = m_nAutoTSequenceNo; 
	pMsg->ack_sequence_number = m_nAutoTAckSequenceNo;	
	pMsg->opcode = ECHO_MSG;
	pMsg->linkID = m_nLinkID;

	nRet = SendPacket(pMsg);
	//nRet = 0;
	if(nRet < 0)
	{
		LOG_ERROR("Failed to send EC packet(%p), length = %d\n", pMsg, pMsg->len + 2);
		nRet = RETURN_FAIL;
		goto finish;
	}else{
		LOG_INFO("Send EC packet(%p), length = %d\n", pMsg, pMsg->len + 2);
		nRet = RETURN_SUCCESS;
		goto finish;
	}


finish:
	return nRet;
}

//////////////////////
// Add by MinhDq
//////////////////////
int	CAutoTProtocol::MakeAndSendRRPacket(stAutoTMessageFormat* pMsg)
{
	int nRet = RETURN_SUCCESS;

	pMsg->len = PACKET_HEADER_SIZE;
	pMsg->sequence_no = GetAutoTSequenceNumber();
	pMsg->ack_sequence_number = m_nAutoTAckSequenceNo;
	pMsg->opcode = RETRAN_REQ_MSG;
	pMsg->linkID = m_nLinkID;

	nRet = SendPacket(pMsg);
	if(nRet < 0)
	{
		LOG_ERROR("Failed to send RR packet(%p), length = %d\n", pMsg, pMsg->len + 2);
		nRet = RETURN_FAIL;
		goto finish;
	}

	LOG_TRACE("Send RR, opcode = %s, seq_no = %d, ack_seq_no =%d\n",
					Opcode2String(pMsg->opcode), pMsg->sequence_no, pMsg->ack_sequence_number);

finish:
	return nRet;
}


int	CAutoTProtocol::MakeAndSendRPPacket(stAutoTMessageFormat* pMsg)
{
	int nRet = RETURN_SUCCESS;

	//pMsg->len = PACKET_HEADER_SIZE;
	pMsg->sequence_no = GetAutoTSequenceNumber();
	pMsg->ack_sequence_number = m_nAutoTAckSequenceNo;
	pMsg->opcode = RETRAN_REPLY_MSG;
	pMsg->linkID = m_nLinkID;

	nRet = SendPacket(pMsg);
	if(nRet < 0)
	{
		LOG_ERROR("Failed to send RP packet(%p), length = %d\n", pMsg, pMsg->len + 2);
		nRet = RETURN_FAIL;
		goto finish;
	}

	LOG_TRACE("Send RP, opcode = %s, seq_no = %d, ack_seq_no =%d\n",
					Opcode2String(pMsg->opcode), pMsg->sequence_no, pMsg->ack_sequence_number);

finish:
	return nRet;
}
//////////////////////

int	CAutoTProtocol::MakeAndSendACKPacket(stAutoTMessageFormat* pMsg, unsigned int ack_sequence_number)
{
	int nRet = RETURN_SUCCESS;

	pMsg->len = PACKET_HEADER_SIZE;
	pMsg->sequence_no = m_nAutoTSequenceNo;
	pMsg->ack_sequence_number = m_nAutoTAckSequenceNo;
	pMsg->opcode = ACK_MSG;
	pMsg->linkID = m_nLinkID;

	nRet = SendPacket(pMsg);
	if(nRet < 0)
	{
		LOG_ERROR("Failed to send ACK packet(%p), length = %d\n", pMsg, pMsg->len + 2);
		nRet = RETURN_FAIL;
		goto finish;
	}

	WaitForSingleObject(g_hMutexLockDataTransmission, INFINITE);
	m_nAutoCurrTAckSequenceNo = pMsg->ack_sequence_number;
	ReleaseMutex(g_hMutexLockDataTransmission);

	LOG_TRACE("Send ACK, opcode = %s, seq_no = %d, ack_seq_no =%d\n",
					Opcode2String(pMsg->opcode), pMsg->sequence_no, pMsg->ack_sequence_number);

finish:
	return nRet;
}

int	CAutoTProtocol::MakeAndSendNACKPacket(stAutoTMessageFormat* pMsg, unsigned short nErrorCode, CString ErrorString)
{
	int nRet = RETURN_SUCCESS;
	int nIndex = 0;

	pMsg->len = PACKET_HEADER_SIZE;
	pMsg->sequence_no = m_nAutoTSequenceNo;
	pMsg->ack_sequence_number = m_nAutoTAckSequenceNo;
	pMsg->opcode = NACK_MSG;
	pMsg->linkID = m_nLinkID;
	
	//Comment by Phan Minh 20080720
	//memcpy(pMsg->data, &nErrorCode, 2);
	char modulo96[2];
	ConvertShortToModulo96(nErrorCode, modulo96);
	memcpy(pMsg->data, &modulo96, 2);
	nIndex += 2;

	memcpy(&pMsg->data[2], ErrorString, ErrorString.GetLength());
	nIndex += ErrorString.GetLength();
	
	pMsg->data[nIndex] = 0;
	nIndex += 1; // EOS

	
	pMsg->len += nIndex;

	nRet = SendPacket(pMsg);

	if(nRet < 0){
		LOG_ERROR("Failed to send NACK packet(%p), length = %d\n", pMsg, pMsg->len);
		nRet = RETURN_FAIL;
		goto finish;
	}else{
		LOG_INFO("Sent NACK packet(%p), length = %d\n", pMsg, pMsg->len);
		goto finish;
	}

finish:
	return nRet;
}

int	CAutoTProtocol::ReceivePacket(stAutoTMessageFormat* pMsg)
{
	int nRet = RETURN_SUCCESS, index = 0;
	int nCheckResult;
	int rcv_leng = -1;
	stAutoTMessageFormat sndPkt;

	char	buff[MAX_SOCKET_BUFFER_SIZE];

	nRet = m_Socket.ReceiveAutoTPacket(buff, &rcv_leng);
	if(nRet < 0)
	{
		LOG_ERROR("Failed to receive AutoTPacket\n");
		nRet = RETURN_FAIL;
		goto finish;
	}

	DecodePacket(pMsg, buff);
	
    // Comment by Phan Minh 20080720
	/*
	nRet = CheckReceivingSequenceNumber(pMsg->ack_sequence_number);
	if((nRet == CHECK_SEQ_FAILED) || (nRet == CHECK_SEQ_WRONG))
	{
		LOG_ERROR("seq_no = %d, Receive Wrong Packet, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
				m_nAutoTSequenceNo, Opcode2String(pMsg->opcode), pMsg->sequence_no, pMsg->ack_sequence_number);
		nRet = RETURN_FAIL;
		goto finish;
	}*/

	//Added by Phan Minh 20080720
	if((pMsg->opcode == DATA_MSG) 
		|| (pMsg->opcode == LEFTOVER_MSG)
		|| (pMsg->opcode == LEFTOVER_LAST_MSG)
		)
	{
		nCheckResult = CheckHOSEPacket(pMsg);
		if (nCheckResult == INVALID_SEQUENCE) {
			MakeAndSendNACKPacket(&sndPkt, 2202, "Invalid Sequence");
			nRet = RETURN_FAIL;
			goto finish;
		}
		else if (nCheckResult == INVALID_ACK_SEQUENCE){
			MakeAndSendNACKPacket(&sndPkt, 2202, "Invalid Ack Sequence");
			nRet = RETURN_FAIL;
			goto finish;
		}
	}

finish:
	return nRet;
}

// Save DATA Packet to HOSE
int	CAutoTProtocol::SaveDataPacket(char* szData, int nDataLength)
{
	int nRet = RETURN_SUCCESS;
	stAutoTMessageFormat	sndPkt;

	sndPkt.len = PACKET_HEADER_SIZE + nDataLength;
	sndPkt.sequence_no = m_nAutoTSequenceNo;
	sndPkt.ack_sequence_number = m_nAutoTAckSequenceNo;
	sndPkt.opcode = DATA_MSG;
	sndPkt.linkID = m_nLinkID;

	memcpy(sndPkt.data, szData, nDataLength);

	WaitForSingleObject(g_hMutexLockDataTransmission, INFINITE);

	WriteTransmissionSeqAndAckSeqAndPacket(m_nAutoTSequenceNo + 1, m_nAutoTAckSequenceNo,
		m_nAutoTSequenceNo%AUTO_T_WINDOWS_SIZE, &sndPkt);		
	ReleaseMutex(g_hMutexLockDataTransmission);

	return nRet;

}


// Save Unsent DATA Packet to HOSE
int	CAutoTProtocol::SaveUnsentDataPacket(char* szData, int nDataLength)
{
	int nRet = RETURN_SUCCESS;

	g_stUnsentData.arrSndPacket.len = PACKET_HEADER_SIZE + nDataLength;
	g_stUnsentData.arrSndPacket.sequence_no = m_nAutoTSequenceNo;
	g_stUnsentData.arrSndPacket.ack_sequence_number = m_nAutoTAckSequenceNo;
	g_stUnsentData.arrSndPacket.opcode = DATA_MSG;
	g_stUnsentData.arrSndPacket.linkID = m_nLinkID;

	memcpy(g_stUnsentData.arrSndPacket.data, szData, nDataLength);
	g_stUnsentData.nCount = 1;	

	WriteUnsentData();
	
	return nRet;

}


///////////////////////////// TEST /////////////////////////////////////////////////

int	CAutoTProtocol::SendDataPacket_Testcase16_5(char* szData, int nDataLength)
{
	int nRet = RETURN_SUCCESS;
	
	return nRet;
}

int	CAutoTProtocol::MakeAndSendEchoPacketWithInvalidSeq(stAutoTMessageFormat* pMsg, unsigned int nAutoTSequenceNo)
{
	int nRet = RETURN_SUCCESS;

	pMsg->len = PACKET_HEADER_SIZE;
	pMsg->sequence_no = nAutoTSequenceNo; 
	pMsg->ack_sequence_number = m_nAutoTAckSequenceNo;	
	pMsg->opcode = ECHO_MSG;
	pMsg->linkID = m_nLinkID;

	nRet = SendPacket(pMsg);
	if(nRet < 0)
	{
		LOG_ERROR("Failed to send EC packet(%p), length = %d\n", pMsg, pMsg->len + 2);
		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
	return nRet;
}

int	CAutoTProtocol::MakeAndSendEchoPacketWithInvalidAckSeq(stAutoTMessageFormat* pMsg, unsigned int nAutoTAckSequenceNo)
{
	int nRet = RETURN_SUCCESS;

	pMsg->len = PACKET_HEADER_SIZE;
	pMsg->sequence_no = m_nAutoTSequenceNo; 
	pMsg->ack_sequence_number = nAutoTAckSequenceNo;	
	pMsg->opcode = ECHO_MSG;
	pMsg->linkID = m_nLinkID;

	nRet = SendPacket(pMsg);
	if(nRet < 0)
	{
		LOG_ERROR("Failed to send EC packet(%p), length = %d\n", pMsg, pMsg->len + 2);
		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
	return nRet;
}

int	CAutoTProtocol::SendInvalidSeqTestDataPacket(char* szData, int nDataLength, unsigned int nAutoTSequenceNo)
{
	int nRet = RETURN_SUCCESS;
	stAutoTMessageFormat	sndPkt;

	sndPkt.len = PACKET_HEADER_SIZE + nDataLength;

	sndPkt.sequence_no = nAutoTSequenceNo;
	sndPkt.ack_sequence_number = m_nAutoTAckSequenceNo;

	sndPkt.opcode = DATA_MSG;
	sndPkt.linkID = m_nLinkID;

	memcpy(sndPkt.data, szData, nDataLength);

	nRet = SendPacket(&sndPkt);
	if(nRet < 0)
	{
		LOG_ERROR("Send DATA Packet, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);
		nRet = RETURN_FAIL;
		goto finish;
	}

	LOG_TRACE("Send DATA opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);

finish:
	return nRet;
}

int	CAutoTProtocol::SendInvalidAckSeqTestDataPacket(char* szData, int nDataLength, unsigned int nAutoTAckSequenceNo)
{
	int nRet = RETURN_SUCCESS;
	stAutoTMessageFormat	sndPkt;

	sndPkt.len = PACKET_HEADER_SIZE + nDataLength;

	sndPkt.sequence_no = m_nAutoTSequenceNo;
	sndPkt.ack_sequence_number = nAutoTAckSequenceNo;

	sndPkt.opcode = DATA_MSG;
	sndPkt.linkID = m_nLinkID;

	memcpy(sndPkt.data, szData, nDataLength);

	nRet = SendPacket(&sndPkt);
	if(nRet < 0)
	{
		LOG_ERROR("Send DATA Packet, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);
		nRet = RETURN_FAIL;
		goto finish;
	}

	LOG_TRACE("Send DATA, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);

finish:
	return nRet;
}
///////////////////////////// TEST /////////////////////////////////////////////////

int nSentDataCnt = 0;
// Send DATA Packet to HOSE
int	CAutoTProtocol::SendDataPacket(char* szData, int nDataLength)
{
	int nRet = RETURN_SUCCESS;
	stAutoTMessageFormat	sndPkt;

	sndPkt.len = PACKET_HEADER_SIZE + nDataLength;	
	
	// Increase sequence number

	sndPkt.sequence_no = m_nAutoTSequenceNo;
	sndPkt.ack_sequence_number = m_nAutoTAckSequenceNo;

	//sndPkt.ack_sequence_number = m_nAutoTSequenceNo + 1;
	sndPkt.opcode = DATA_MSG;
	sndPkt.linkID = m_nLinkID;

	memcpy(sndPkt.data, szData, nDataLength);

	nRet = SendPacket(&sndPkt);
	//nRet = 0;

	// Increase ourNextSequence
	m_nAutoTSequenceNo++;
	
	if(nRet < 0)
	{
		LOG_ERROR("Fail send DATA Packet, opcode = %s, seq_no = %d, ack_seq_no =%d, length = %d\n", 
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number, sndPkt.len);
		nRet = RETURN_FAIL;
		LOG_INFO("Save unsent packet for the next connection, seq_no = %d\n", sndPkt.sequence_no);
		goto save_data;
	}

	LOG_TRACE("Send DATA[%d], opcode = %s, seq_no = %d, ack_seq_no =%d, length =%d\n", ++nSentDataCnt,
					Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number, sndPkt.len);
	
	//Reset nSendingACKFlag
	WaitForSingleObject(g_hMutexSendingAckFlag, INFINITE);
	nSendingACKFlag = NO_SENDING_ACK;
	ReleaseMutex(g_hMutexSendingAckFlag);

save_data:

// Save DATA to DB
	WaitForSingleObject(g_hMutexLockDataTransmission, INFINITE);
	WriteTransmissionSeqAndAckSeqAndPacket(m_nAutoTSequenceNo, m_nAutoTAckSequenceNo,
		(m_nAutoTSequenceNo - 1)%AUTO_T_WINDOWS_SIZE, &sndPkt);	
	m_nAutoCurrTAckSequenceNo = sndPkt.ack_sequence_number;
	ReleaseMutex(g_hMutexLockDataTransmission);	
	goto finish;
//fdf
finish:
	return nRet;
}

int	CAutoTProtocol::Processing_LeftoverPacket(stAutoTMessageFormat* pMsg)
{
	int nRet = RETURN_SUCCESS;
	int i, nDataLength;

	char* pData;
//	char rpData[MAX_SOCKET_BUFFER_SIZE];
	
	char	szQueue[MAX_SOCKET_BUFFER_SIZE];
	int		nQueueLength = 0;
	
	// Parsing CTCI message and push to Queue
	nDataLength = pMsg->len - PACKET_HEADER_SIZE;
    
	/*
	pMsg->data[nDataLength] = US_CHAR;	
	nDataLength = nDataLength - 2;
	pData = &pMsg->data[2];	// Market ID, Message Count
	
	for(i = 0; i <= nDataLength; i++){
		if(pData[i] == US_CHAR){
			memcpy(szQueue, &pData[nQueueLength], i - nQueueLength);
			szQueue[i - nQueueLength] = 0;

			// Push to Queue
			m_Queue.PushCTCIQueue(szQueue, i - nQueueLength);

			// Pass US Character
			nQueueLength = i + 1;
		}
	}*/


	// Check if packet inside LO, LL is DT or RP, added by Phan Minh 20080725
	unsigned short tmpShort;
	unsigned short opcode;
	// opcode
	memcpy(&tmpShort, &pMsg->data[1], 2);
	// Swap opcode
	tmpShort = short_swap(tmpShort);
	opcode = tmpShort;
	
	if (opcode == RETRAN_REPLY_MSG){
		LOG_INFO("Receive Retransmission Reply, --> process like as broadcast packet\n");
		
		pMsg->data[nDataLength] = BELL_CHAR;
		unsigned short nMsgType;
		unsigned short nFirm;
		unsigned char nMarketID;

		unsigned int PrevSeqNo;
		unsigned int SeqNo;
		unsigned char nMsgCnt;
			
		nMsgType = ConvertModulo96ToShort(&pMsg->data[1]);
		nFirm = ConvertModulo96ToShort(&pMsg->data[3]);
		nMarketID = pMsg->data[5];
		PrevSeqNo = ConvertModulo96To3Bytes(&pMsg->data[6]);
		SeqNo = ConvertModulo96To3Bytes(&pMsg->data[9]);
		nMsgCnt = ConvertModulo96ToChar(&pMsg->data[12]);
		pData = &pMsg->data[13];
		LOG_INFO("Message RP: MsgType(%2X), Firm(%04X), PrevSeqNo(%d), SeqNo(%d), MsgCnt(%d)\n",
			nMsgType, nFirm, PrevSeqNo, SeqNo, nMsgCnt);
		int	nQueueIndex = 0;
		nDataLength = nDataLength - 12;
		for(i = 0 ; i <= nDataLength; i++){
			if(pData[i] == BELL_CHAR){	// Found one Broadcast Msg
		
				memcpy(szQueue, &pData[nQueueIndex], i - nQueueIndex);
				szQueue[i - nQueueIndex] = 0;

				// Push to Queue
				m_Queue.PushBroadcastQueue(szQueue, i - nQueueIndex);

				// Pass US Character
				nQueueIndex = i + 1;
			}
		}
	}else{

		pMsg->data[nDataLength] = US_CHAR;	
		nDataLength = nDataLength - 2;
		pData = &pMsg->data[2];	// Market ID, Message Cont
	
		for(i = 0; i <= nDataLength; i++){
			if(pData[i] == US_CHAR){
				memcpy(szQueue, &pData[nQueueLength], i - nQueueLength);
				szQueue[i - nQueueLength] = 0;

				// Push to Queue
				m_Queue.PushCTCIQueue(szQueue, i - nQueueLength);

				// Pass US Character
				nQueueLength = i + 1;
			}
		}
		
	}


	return nRet;
}

int	CAutoTProtocol::GetLeftOverPacket(unsigned int nSequenceNo, unsigned int nAckSequenceNo, stAutoTMessageFormat** pMsg)
{
	int nRet = RETURN_SUCCESS;
	int i;

	if (nSequenceNo == nAckSequenceNo){
		goto finish;
	}
	if((nSequenceNo - nAckSequenceNo) == 1){
		nRet = LEFTOVER_LAST_MSG;
	}
	else if (nSequenceNo > nAckSequenceNo){
		nRet = LEFTOVER_MSG;
	}

	for(i = 0; i < AUTO_T_WINDOWS_SIZE; i++)
	{
		if(g_stTransmissionData.arrSndPacket[i].sequence_no == nAckSequenceNo)
		{
			*pMsg = &g_stTransmissionData.arrSndPacket[i];
			break;
		}
	}

	if(i == AUTO_T_WINDOWS_SIZE)	// Not found the packet
	{
		nRet = RETURN_FAIL;
	}

finish:
	return nRet;
}

// Process Broadcast from UDP
int CAutoTProtocol::ParsingBroadcastPacketAndPushtoQueue(stAutoTMessageFormat* pMsg)
{
	int nRet = RETURN_SUCCESS;

	int i;
	char	szQueue[MAX_SOCKET_BUFFER_SIZE];
	int		nQueueIndex = 0;

	char* pData;

	int nDataLength = pMsg->len - PACKET_HEADER_SIZE;

//	unsigned short nMsgType;
	unsigned short nFirm;
	unsigned char nMarketID;

	unsigned int PrevSeqNo;
	unsigned int SeqNo;
	unsigned char nMsgCnt;

	nMarketID = ConvertModulo96ToChar(&pMsg->data[0]);
	
	CString strMsgType;
	if ((pMsg->data[1] == 'R') && (pMsg->data[2] == 'N')){
		strMsgType = "RN";
		memcpy(szQueue, &pMsg->data[1], nDataLength);
		m_Queue.PushCTCIQueue(szQueue, nDataLength);
		//DumpData(pMsg->data, pMsg->len - PACKET_HEADER_SIZE);

		WaitForSingleObject(g_hRetransmissionLock, INFINITE);
		g_nWaitingTS = CAN_SEND_RETRANSMISSION;
		WritePossibleReTransmission();
		ReleaseMutex(g_hRetransmissionLock);

	}else{
		strMsgType = "RP";
	
		nFirm = ConvertModulo96ToShort(&pMsg->data[3]);
		nMarketID = pMsg->data[5];
		PrevSeqNo = ConvertModulo96To3Bytes(&pMsg->data[6]);
		SeqNo = ConvertModulo96To3Bytes(&pMsg->data[9]);

		nMsgCnt = ConvertModulo96ToChar(&pMsg->data[12]);

		LOG_INFO("Message " + strMsgType + ", Firm(%04X), Market(%C), PrevSeqNo(%d), SeqNo(%d), MsgCnt(%d)\n",
			nFirm, nMarketID, PrevSeqNo, SeqNo, nMsgCnt);

		pMsg->data[nDataLength] = BELL_CHAR;

		pData = &pMsg->data[13];
		nDataLength = nDataLength -13;
		for(i = 0 ; i <= nDataLength; i++){
			if(pData[i] == BELL_CHAR){	// Found one Broadcast Msg
				memcpy(szQueue, &pData[nQueueIndex], i - nQueueIndex);
				szQueue[i - nQueueIndex] = 0;

				// Push to Queue
				m_Queue.PushBroadcastQueue(szQueue, i - nQueueIndex);

				// Pass US Character
				nQueueIndex = i + 1;
			}
		}
	}
	return nRet;
}

int CAutoTProtocol::MakeAndSendRequestRetransmissionBroadcastPacket(unsigned int nFromSeq, unsigned int nToSeq)
{
	int nRet = RETURN_SUCCESS;

	stAutoTMessageFormat	sndPkt;
	unsigned int			nTmpShort;
	unsigned int			nTmpInt;
	int						nIndex = 0;

	int nDataLength;
	char modulo96[4];

	if(m_nProgState != PROG_DATA_TRANFER)
	{
		//
		nRet = RETURN_FAIL;
		goto finish;
	}

	if(g_nWaitingTS == CAN_NOT_SEND_RETRANSMISSION)
	{
		//
		nRet = RETURN_FAIL;
		goto finish;
	}

	nDataLength = 12;
	sndPkt.len = PACKET_HEADER_SIZE + nDataLength;
	sndPkt.sequence_no = m_nAutoTSequenceNo;
	sndPkt.ack_sequence_number = m_nAutoTAckSequenceNo;
	// sndPkt.opcode = DATA_MSG; comments by MinhDQ on June 18,2008, 10:30 AM
	sndPkt.opcode = RETRAN_REQ_MSG; // Add by MinhDQ on June 18,2008, 10:30 AM
	sndPkt.linkID = m_nLinkID;

	// Market ID
	memcpy(&sndPkt.data[nIndex], (char*)&m_arrMarket[0].market_id, 1);
	nIndex += 1;

	// Message Type
	// nTmpShort = RETRAN_REQ_MSG; comments by MinhDQ on June 18,2008, 10:30 AM
	nTmpShort = RETRAN_REQ_MSGTYPE; // Add by MinhDQ on June 18,2008, 10:36 AM
	memcpy(&sndPkt.data[nIndex], (char*)&nTmpShort, 2);
	nIndex += 2;

	// Firm
	//memcpy(&sndPkt.data[nIndex], (char*)&m_arrMarket[0].firm_id, 2);
	sndPkt.data[nIndex] = 32;
	sndPkt.data[nIndex+1] = 34;
	nIndex += 2;

	// Market ID
	memcpy(&sndPkt.data[nIndex], (char*)&m_arrMarket[0].market_id, 1);
	nIndex += 1;

	// Retransmission Start Sequence
	nTmpInt = nFromSeq;
	ConvertIntTo3BytesModulo96(nTmpInt, modulo96);
	memcpy(&sndPkt.data[nIndex], modulo96, 3);
	nIndex += 3;

	// Retransmission End Sequence
	nTmpInt = nToSeq;
	ConvertIntTo3BytesModulo96(nTmpInt, modulo96);
	memcpy(&sndPkt.data[nIndex], modulo96, 3);
	nIndex += 3;

	nRet = SendPacket(&sndPkt);
	if(nRet < 0)
	{
		LOG_ERROR("Failed to send RETRANSMISSION, opcode = %s, seq_no = %d, ack_seq_no =%d\n", 
				Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number);
		nRet = RETURN_FAIL;
		goto finish;
	}

	WaitForSingleObject(g_hRetransmissionLock, INFINITE);
	g_nWaitingTS = CAN_NOT_SEND_RETRANSMISSION;
	WritePossibleReTransmission();
	ReleaseMutex(g_hRetransmissionLock);

	LOG_TRACE("Send RETRANSMISSION, opcode = %s, seq_no = %d, ack_seq_no =%d, from_seq = %d, to_seq = %d\n", 
				Opcode2String(sndPkt.opcode), sndPkt.sequence_no, sndPkt.ack_sequence_number,nFromSeq, nToSeq);
finish:
	return nRet;
}

// Process Broadcast from UDP
int CAutoTProtocol::ProcessingBroadcastPacket(char* szBroadcastPacket, int nBroadcastPacketLength)
{
	int nRet = RETURN_SUCCESS;
	int nDataLength;
	int	nIsFirstReceive = 0;
	stBroadcastMessageFormat rcvPkt;

	int i;
	char	szQueue[MAX_SOCKET_BUFFER_SIZE];
	int		nQueueIndex = 0;

	
	nRet = CheckPacketFromHOSE(szBroadcastPacket, nBroadcastPacketLength);
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

	// Parsing CTCI message and push to Queue
	nDataLength = nBroadcastPacketLength - BROADCAST_PACKET_HEADER_SIZE;

	g_stConnectionData.nBroadcastSeq = rcvPkt.sequence_no;
	WriteSettingParameters(); // Than add 20080705

	if((m_nBroadcastSequenceNoStart == 1) && (m_nBroadcastSequenceNoNext == 1))
	{
		m_nBroadcastSequenceNoStart = rcvPkt.sequence_no;
		m_nBroadcastSequenceNoNext = rcvPkt.sequence_no;

		nIsFirstReceive = 1;
	}

	// ParsingBroadcastPacketAndPushtoQueue(&rcvPkt);
	rcvPkt.data[nDataLength] = US_CHAR;
	for(i = 0; i <= nDataLength; i++)
	{
		if(rcvPkt.data[i] == US_CHAR)	// Found one Broadcast Msg
		{
			memcpy(szQueue, &rcvPkt.data[nQueueIndex], i - nQueueIndex);
			szQueue[i - nQueueIndex] = 0;
			// Push to Queue

			m_Queue.PushBroadcastQueue(szQueue, i - nQueueIndex);

			// Pass US Character
			nQueueIndex = i + 1;
		}
	}

#if 1
	// Checking Retransmission
	if(!nIsFirstReceive)
	{
		m_nBroadcastSequenceNoNext = rcvPkt.sequence_no;

		if((m_nProgState == PROG_DATA_TRANFER) && (g_stRestransmissionInfor.count != 0))
		{
			int nIndex;
			int nResTranCount= g_stRestransmissionInfor.count + g_stRestransmissionInfor.index;
			unsigned int nFrom, nTo;

			for(nIndex = g_stRestransmissionInfor.index; nIndex < nResTranCount; nIndex++)
			{
				nFrom = g_stRestransmissionInfor.arrRestransmission[nIndex].from_sequence_no ;
				nTo = g_stRestransmissionInfor.arrRestransmission[nIndex].to_sequence_no;

				nRet = MakeAndSendRequestRetransmissionBroadcastPacket(nFrom, nTo);
				if(nRet == RETURN_SUCCESS)
				{
					LOG_INFO("Send Retransmission Broadcast From (%d) to (%d)\n", nFrom, nTo);
				}
				else
				{
					LOG_INFO("Failed Send Retransmission Broadcast From (%d) to (%d)\n", nFrom, nTo);
				}

				g_stRestransmissionInfor.count = g_stRestransmissionInfor.count - 1;
			}

			g_stRestransmissionInfor.index = nIndex;

			if(g_stRestransmissionInfor.count == 0)
				g_stRestransmissionInfor.index = 0;
			WriteReTransmissionInfor();

		}

		//if(m_nBroadcastSequenceNoNext%2 == 0)
		//	goto finish;

		if((m_nBroadcastSequenceNoNext - m_nBroadcastSequenceNoStart) == 1)
		{
			m_nBroadcastSequenceNoStart = m_nBroadcastSequenceNoNext;
			g_stConnectionData.nBroadcastSeq = m_nBroadcastSequenceNoStart;
			WriteSettingParameters(); // Than add 20080705
			goto finish;
		}

		// Restransmittion [Start + 1, Start + 2, ..., Next -1]
		
		if(m_nProgState == PROG_DATA_TRANFER)
		{
			nRet = MakeAndSendRequestRetransmissionBroadcastPacket(m_nBroadcastSequenceNoStart + 1, m_nBroadcastSequenceNoNext - 1);
			if(nRet == RETURN_SUCCESS)
			{
				LOG_INFO("Send Retransmission Broadcast From (%d) to (%d)\n", m_nBroadcastSequenceNoStart + 1, m_nBroadcastSequenceNoNext - 1);
				m_nBroadcastSequenceNoStart = m_nBroadcastSequenceNoNext;
				g_stConnectionData.nBroadcastSeq = m_nBroadcastSequenceNoStart;
				WriteSettingParameters();
			}
			else
			{
				LOG_INFO("Failed Send Retransmission Broadcast From (%d) to (%d)\n", m_nBroadcastSequenceNoStart + 1, m_nBroadcastSequenceNoNext - 1);
			}
		}
		else // Save to file
		{
			int nIndex = g_stRestransmissionInfor.count;
			if(nIndex < MAX_RETRANSMISSION_SIZE)
			{
				g_stRestransmissionInfor.arrRestransmission[nIndex].from_sequence_no = m_nBroadcastSequenceNoStart + 1;
				g_stRestransmissionInfor.arrRestransmission[nIndex].to_sequence_no = m_nBroadcastSequenceNoNext - 1;
				g_stRestransmissionInfor.count++;
				WriteReTransmissionInfor();
			}

			m_nBroadcastSequenceNoStart = m_nBroadcastSequenceNoNext;
		}
	}
#endif

finish:
	return nRet;
}

// Process Broadcast from AutoT Packet
int CAutoTProtocol::ProcessingBroadcastPacketFromCTCI(stAutoTMessageFormat* pMsg)
{
	int nRet = RETURN_SUCCESS;

	// Push Broadcast Message to Queue
	ParsingBroadcastPacketAndPushtoQueue(pMsg);
	return nRet;
}

int CAutoTProtocol::ProcessingControlPacket(stAutoTMessageFormat* pMsg)
{
	int nRet = RETURN_SUCCESS;

	if(pMsg->opcode == ACK_MSG)
	{
		m_nAutoTSequenceNoStart = pMsg->ack_sequence_number;
	}
	else if(pMsg->opcode == ECHO_REPLY_MSG)
	{
		//stAutoTMessageFormat Msg;	
		//MakeAndSendEchoPacket(&Msg);
		
		//DumpData(pMsg->data, pMsg->len - PACKET_HEADER_SIZE);		

	}
	else if(pMsg->opcode == NACK_MSG)
	{
		DumpData(pMsg->data, pMsg->len - PACKET_HEADER_SIZE);
		//TerminateConnection();
		//nRet = PROG_STOP;
	}
	else if(pMsg->opcode == ACKFIN_MSG)
	{
		WaitForSingleObject(g_hMutexLockStopFlag, INFINITE);
		nStopFlag = CAN_STOP;
		ReleaseMutex(g_hMutexLockStopFlag);
		nRet = PROG_STOP_ACCEPT;
	}
	else if(pMsg->opcode == FINISH_MSG)
	{
		TerminatePacketProcessing(pMsg);
		//TerminateConnection();
		nRet = PROG_STOP_FROM_HOSE;
	}


	return nRet;
}

// Process AutoT Packet
int CAutoTProtocol::ProcessingAutoTPacket(char* szAutoTPacket, int nAutoTPacketLength)
{
	int nRet = RETURN_SUCCESS;
	int nCheckResult = 0;
	int i, nDataLength;
	stArrayAutoTMessage arrayOfrcvPkt;
	stAutoTMessageFormat	sndPkt;
	char* pData;

	char	szQueue[MAX_SOCKET_BUFFER_SIZE];
	int		nQueueIndex = 0;

	// Copy Packet Buffer to Structure
	
	// For testing
	//char test[MAX_SOCKET_BUFFER_SIZE];
	//memcpy(&test[0], szAutoTPacket, nAutoTPacketLength);
	//memcpy(&test[nAutoTPacketLength], szAutoTPacket, nAutoTPacketLength);
	//DecodePacket2(&arrayOfrcvPkt, test, 2*nAutoTPacketLength);

	DecodePacket2(&arrayOfrcvPkt, szAutoTPacket, nAutoTPacketLength);	
	
	for (unsigned int j = 0; j < arrayOfrcvPkt.count; j++){
		LOG_TRACE("Receive AutoT Packet, opcode = %s, seq_no = %d, ack_seq_no =%d, length: %d, buffer_length: %d\n", 
				Opcode2String(arrayOfrcvPkt.arrAutoTMessage[j].opcode), 
				arrayOfrcvPkt.arrAutoTMessage[j].sequence_no, 
				arrayOfrcvPkt.arrAutoTMessage[j].ack_sequence_number, 
				arrayOfrcvPkt.arrAutoTMessage[j].len + 1, nAutoTPacketLength);
		
		// Added by Phan Minh 20080720
	
		nCheckResult = CheckHOSEPacket(&arrayOfrcvPkt.arrAutoTMessage[j]);
		if (nCheckResult == INVALID_SEQUENCE){
			MakeAndSendNACKPacket(&sndPkt, 2202, "Invalid Sequence");
			LOG_INFO("INVALID_SEQUENCE\n");
			nRet = RETURN_ABNORMAL;
			goto finish;
		}
		else if (nCheckResult == INVALID_ACK_SEQUENCE){
			MakeAndSendNACKPacket(&sndPkt, 2202, "Invalid Ack Sequence");
			LOG_INFO("INVALID_ACK_SEQUENCE\n");
			nRet = RETURN_ABNORMAL;
			goto finish;
		}

		if((arrayOfrcvPkt.arrAutoTMessage[j].opcode != DATA_MSG) && ((arrayOfrcvPkt.arrAutoTMessage[j].opcode != RETRAN_REPLY_MSG))){			
			nRet = ProcessingControlPacket(&arrayOfrcvPkt.arrAutoTMessage[j]);
			goto continue_process;
		}
		

		WaitForSingleObject(g_hMutexLockStopFlag, INFINITE);
		nStopFlag = NONE_STOP;
		ReleaseMutex(g_hMutexLockStopFlag);
	

		WaitForSingleObject(g_hMutexLockDataTransmission, INFINITE);
		m_nAutoTSequenceNoStart = arrayOfrcvPkt.arrAutoTMessage[j].ack_sequence_number;

		m_nAutoTAckSequenceNo = arrayOfrcvPkt.arrAutoTMessage[j].sequence_no + 1;
		WriteTransmissionAckSeqAndStartSeq(m_nAutoTAckSequenceNo, m_nAutoTSequenceNoStart);

		ReleaseMutex(g_hMutexLockDataTransmission);

		if((m_nAutoTAckSequenceNo - m_nAutoCurrTAckSequenceNo)
		>= AUTO_T_WINDOWS_SIZE){
			// Send ACK Packet
			
			//MakeAndSendACKPacket(&sndPkt, m_nAutoTAckSequenceNo);

			WaitForSingleObject(g_hMutexSendingAckFlag, INFINITE);
			nSendingACKFlag = SENDING_ACK;
			ReleaseMutex(g_hMutexSendingAckFlag);	

		}
		
		// Parsing CTCI message and push to Queue
		nDataLength = arrayOfrcvPkt.arrAutoTMessage[j].len - PACKET_HEADER_SIZE;

		// Check Retransmission
		if(arrayOfrcvPkt.arrAutoTMessage[j].opcode == RETRAN_REPLY_MSG){
			LOG_INFO("Receive Retransmission Reply, --> process like as broadcast packet\n");
			ProcessingBroadcastPacketFromCTCI(&arrayOfrcvPkt.arrAutoTMessage[j]);
			nRet = RETURN_SUCCESS;
			// Push to Queue
			m_Queue.PushCTCIQueue(&arrayOfrcvPkt.arrAutoTMessage[j].data[1], arrayOfrcvPkt.arrAutoTMessage[j].len - PACKET_HEADER_SIZE -1);
			goto continue_process;

		}

		arrayOfrcvPkt.arrAutoTMessage[j].data[nDataLength] = US_CHAR;
		pData = &arrayOfrcvPkt.arrAutoTMessage[j].data[2]; //data[0] -->market ID, data[1] --> Msg Cnt
		nDataLength = nDataLength - 2;
		for(i = 0 ; i <= nDataLength; i++){
			if(pData[i] == US_CHAR){
				memcpy(szQueue, &pData[nQueueIndex], i - nQueueIndex);
				szQueue[i - nQueueIndex] = 0;

				// Push to Queue
				m_Queue.PushCTCIQueue(szQueue, i - nQueueIndex);

				// Pass US Character
				nQueueIndex = i + 1;
			}
		}
continue_process:
		nQueueIndex = 0;
	}

finish:
	return nRet;
}

// Thread for polling Queue and making packet send to HOSE
DWORD CAutoTProtocol::ThreadPollCTCIMsgFromQueue(CAutoTProtocol* pAutoTProtocol)
{
	int nRet = RETURN_SUCCESS;

	int nSleepTime = 100, nWaitingTime = 0;
	int nEchoWaitingTime = 30000; // 30 second

	char	szData[MAX_SOCKET_BUFFER_SIZE];
	int		nDataLength = 2;

	unsigned char	nDataCnt = 0;

	char	szQueue[MAX_SOCKET_BUFFER_SIZE];
	int		nQueueLength = 0;

	stAutoTMessageFormat	sndPkt;
	
	CBrokerCommunicationDlg *m_pDlg = (CBrokerCommunicationDlg*)AfxGetMainWnd();

	LOG_INFO("Start Thread: ThreadPollCTCIMsgFromQueue\n");
	
	pAutoTProtocol->m_nSendingThreadStatus = 0;

	while(!pAutoTProtocol->m_nStopPoolingQueue)
	{
		if(nStopFlag == CAN_STOP){
			// Send AF
			//pAutoTProtocol->MakeAndSendAFPacket();
			//Rem by Phan Minh 20081119
			/*
			pAutoTProtocol->m_Socket.CloseAutoTSocket();
			pAutoTProtocol->m_nProgState = PROG_STOP;				
			pAutoTProtocol->m_Socket.m_nConnected = 0;*/
			
			pAutoTProtocol->m_nStopPoolingQueue = 1;

			WaitForSingleObject(g_hMutexLockStopFlag, INFINITE);
			nStopFlag = NONE_STOP;
			ReleaseMutex(g_hMutexLockStopFlag);
			break;
		}

		if(nStopFlag == WAITING_STOP){
			Sleep(nSleepTime);
			continue;
		}

		if((nStopFlag == TRYING_STOP) && (nDataCnt == 0)){
			// Send FN
			pAutoTProtocol->MakeAndSendFNPacket();

			WaitForSingleObject(g_hMutexLockStopFlag, INFINITE);
			nStopFlag = WAITING_STOP;
			ReleaseMutex(g_hMutexLockStopFlag);
			Sleep(nSleepTime);
			continue;
		}	
		
		if((pAutoTProtocol->m_nAutoTSequenceNo - pAutoTProtocol->m_nAutoTSequenceNoStart)
			>= AUTO_T_WINDOWS_SIZE){ // Windows Size is Full		
			
			Sleep(nSleepTime);
			continue;
		}
		
		nQueueLength = 0;
		nRet = pAutoTProtocol->m_Queue.PopCTCIQueue(szQueue, &nQueueLength);
		if((nRet != RETURN_SUCCESS) && (nDataLength == 2)){ // Queue is empty, and no message waiting for being sent
			
			// Send Ack if neccessary
			if(nSendingACKFlag == SENDING_ACK){			
				if(pAutoTProtocol->MakeAndSendACKPacket(&sndPkt, pAutoTProtocol->m_nAutoTSequenceNo) != RETURN_SUCCESS)
				{
					goto save_unsent_data;
				}

				WaitForSingleObject(g_hMutexSendingAckFlag, INFINITE);
				nSendingACKFlag = NO_SENDING_ACK;
				ReleaseMutex(g_hMutexSendingAckFlag);
			}
			// Sleep
			Sleep(nSleepTime);
			nWaitingTime += nSleepTime;

			// increase echo time
			WaitForSingleObject(g_hMutexEchoTime, INFINITE);
			nEchoTime += nSleepTime;
			ReleaseMutex(g_hMutexEchoTime);
			
			if (nEchoTime >= nEchoWaitingTime){
				stAutoTMessageFormat msg;			
				if(pAutoTProtocol->MakeAndSendEchoPacket(&msg) != RETURN_SUCCESS)				{
					
					goto save_unsent_data;
				}				
			}
			
			//if (nTestTime >= 300000){
			//	pAutoTProtocol->m_Socket.CloseAutoTSocket();
			//	nTestTime = 0;
			//}
			//nTestTime +=100;
			goto continue_process;
		}else{	
		
			if(nDataLength + nQueueLength > OUR_MAX_SOCKET_BUFFER_SIZE){				
				
				LOG_INFO("Enough for sending a packet to HOSE(%p, %d), Number of Messages = %d\n", szData, nDataLength, nDataCnt);
				szData[0] = 'A';
				szData[1] = nDataCnt + 32 /*modulo 96*/;
				int iRet = pAutoTProtocol->SendDataPacket(szData, nDataLength - 1 /*delete US_CHAR*/);

				// Reset Echotime		
				WaitForSingleObject(g_hMutexEchoTime, INFINITE);
				nEchoTime = 0;
				ReleaseMutex(g_hMutexEchoTime);

				// Prepare for another Packet with the first message is this one
				nDataLength = 2;
				nWaitingTime = 0;
				nDataCnt = 1;
				memcpy(&szData[nDataLength], szQueue, nQueueLength);
				nDataLength = nDataLength + nQueueLength;
				szData[nDataLength] = US_CHAR;
				nDataLength += 1;
				if (iRet == RETURN_FAIL){
					nRet = RETURN_FAIL;
					goto save_unsent_data; // save the new message. The one which can not be sent has been saved already by the SendDataPacket function
				}

			}else{
				if (nQueueLength > 0) {
					nDataCnt++;
					memcpy(&szData[nDataLength], szQueue, nQueueLength);
					nDataLength = nDataLength + nQueueLength;
					szData[nDataLength] = US_CHAR;
					nDataLength += 1;
				}
				
				if ((nWaitingTime >= pAutoTProtocol->m_nTimeoutWaitingPacket*1000) && (nDataLength > 0)){
					LOG_INFO("Timeup, sending a packet to HOSE(%p, %d), Number of Messages = %d\n", szData, nDataLength, nDataCnt);
					
					//szData[0] = 'A';
					//szData[1] = nDataCnt + 32 /*modulo 96*/;
					//pAutoTProtocol->SaveUnsentDataPacket(szData, nDataLength - 1 /*delete US_CHAR*/);

					szData[0] = 'A';
					szData[1] = nDataCnt + 32 /*modulo 96*/;
					int iRet = pAutoTProtocol->SendDataPacket(szData, nDataLength - 1 /*delete US_CHAR*/);

					// Reset Echotime		
					WaitForSingleObject(g_hMutexEchoTime, INFINITE);
					nEchoTime = 0;
					ReleaseMutex(g_hMutexEchoTime);

					// Prepare for another Packet
					nDataLength = 2;
					nWaitingTime = 0;
					nDataCnt = 0;
					if (iRet == RETURN_FAIL){
						nRet = RETURN_FAIL;
						goto finish; // No message needs to be saved. The one which can not be sent has been saved already by the SendDataPacket function
					}
				}else{
					// Sleep
					Sleep(nSleepTime);
					nWaitingTime += nSleepTime;			
					goto continue_process;
				}
			}
		}
		
continue_process:
			;
	}
save_unsent_data:
	pAutoTProtocol->m_nStopPoolingQueue = 0;	

	if(nDataCnt > 0)
	{
		if((pAutoTProtocol->m_nAutoTSequenceNo - pAutoTProtocol->m_nAutoTSequenceNoStart)
			== AUTO_T_WINDOWS_SIZE){ // Windows Size is Full	
			LOG_ERROR("Save over load unsent packet for next time sending, because queue already pop, seq_no = %d\n", pAutoTProtocol->m_nAutoTSequenceNo);
			szData[0] = 'A';
			szData[1] = nDataCnt + 32 /*modulo 96*/;
			pAutoTProtocol->SaveUnsentDataPacket(szData, nDataLength - 1 /*delete US_CHAR*/);	
		}else{
		
			LOG_ERROR("Save unsent packet for next time sending, because queue already pop, seq_no = %d\n", pAutoTProtocol->m_nAutoTSequenceNo);
			szData[0] = 'A';
			szData[1] = nDataCnt + 32 /*modulo 96*/;
			pAutoTProtocol->SaveDataPacket(szData, nDataLength - 1 /*delete US_CHAR*/);
		}
	}

finish:
	
	pAutoTProtocol->m_nSendingThreadStatus = 1;
	LOG_INFO("Stop Thread: ThreadPollCTCIMsgFromQueue\n");
	
	pAutoTProtocol->TerminateReceivingThread();
	pAutoTProtocol->m_Socket.CloseAutoTSocket();
	pAutoTProtocol->m_nProgState = PROG_STOP;
	pAutoTProtocol->m_Socket.m_nConnected = 0;

	if(!m_pDlg)
		goto finish;
	
	m_pDlg->GetMenu()->EnableMenuItem(ID_CONNECTIONSETUP_CONNECT, MF_ENABLED);
	m_pDlg->GetMenu()->EnableMenuItem(ID_CONNECTIONSETUP_DISCONNECT, MF_GRAYED);
	m_pDlg->DrawMenuBar();


	return nRet;
}

// Thread for receiving Broadcast Packet
DWORD CAutoTProtocol::ThreadReceiveBroadcastMsgFromHOSE(CAutoTProtocol* pAutoTProtocol)
{
	int nRet = RETURN_SUCCESS;

	char	szRcvBuffer[MAX_SOCKET_BUFFER_SIZE];
	int		nRvcLength;

	LOG_INFO("Start Thread: ThreadReceiveBroadcastMsgFromHOSE\n");
	while(!pAutoTProtocol->m_nStopBroadcast)
	{
		// Receive Broadcast Message from UDP Port
		nRvcLength = -1;
		nRet = pAutoTProtocol->m_Socket.ReceiveBroadcastPacket(szRcvBuffer, &nRvcLength);
		if((nRet == RETURN_SUCCESS) && (nRvcLength > 0))
		{
			pAutoTProtocol->ProcessingBroadcastPacket(szRcvBuffer, nRvcLength);
		}
		else
		{

		}
	}

	pAutoTProtocol->m_nStopBroadcast = 0;
	LOG_INFO("Stop Thread: ThreadReceiveBroadcastMsgFromHOSE\n");

	return nRet;
}

// Thread for receiving AutoT Packet
DWORD CAutoTProtocol::ThreadReceiveAutoTPacketFromHOSE(CAutoTProtocol* pAutoTProtocol)
{
	int nRet = RETURN_SUCCESS;

	char	szRcvBuffer[MAX_SOCKET_BUFFER_SIZE];
	int		nRvcLength;	
	char	debugBuffer[MAX_SOCKET_BUFFER_SIZE];

	int		stopFromHOSE = 0;

	LOG_INFO("Start Thread: ThreadReceiveAutoTPacketFromHOSE\n");
	pAutoTProtocol->m_nReceivingThreadStatus = 0;
	while(!pAutoTProtocol->m_nStopAutoT)
	{
		// Receive AutoT Packet Packet from TCP Port
		
		//memset(szRcvBuffer, '\0', sizeof(szRcvBuffer));
		//memset(debugBuffer, '\0', sizeof(debugBuffer));
		nRet = pAutoTProtocol->m_Socket.ReceiveAutoTPacket(szRcvBuffer, &nRvcLength);		
		if((nRet == RETURN_SUCCESS) && (nRvcLength > 0)){
			//LOG_INFO("Read Buffer: \n");
			//memcpy(debugBuffer, &szRcvBuffer, nRvcLength);
			//debugBuffer[nRvcLength] = '\n';
			//LOG_INFO(debugBuffer);


			// Reset Echotime		
			WaitForSingleObject(g_hMutexEchoTime, INFINITE);
			nEchoTime = 0;
			ReleaseMutex(g_hMutexEchoTime);


			nRet = pAutoTProtocol->ProcessingAutoTPacket(szRcvBuffer, nRvcLength);
			if((nRet == PROG_STOP) || (nRet == PROG_STOP_FROM_HOSE)
				||(nRet == PROG_STOP_ACCEPT))
			{
				break;
			}
		}if (nRet == RETURN_FAIL){
			pAutoTProtocol->TerminateSendingThread();
			pAutoTProtocol->m_Socket.CloseAutoTSocket();
			pAutoTProtocol->m_Socket.m_nConnected = 0;
			pAutoTProtocol->m_nProgState = PROG_STOP;
		}
		else{			
			
			if(pAutoTProtocol->m_Socket.m_nConnected == 0){
				// Disconnect to HOSE, stop communication
				break;
			}
		}
	}

	pAutoTProtocol->m_nStopAutoT = 0;
	pAutoTProtocol->m_nReceivingThreadStatus = 1;
	LOG_INFO("Stop Thread: ThreadReceiveAutoTPacketFromHOSE\n");

	return nRet;
}

// Create Thread for processing Queue and Broadcast Packet, AutoT Packet
int CAutoTProtocol::CreateBroadcastThread()
{
	int nRet = RETURN_SUCCESS;
	DWORD dwThreadID;

	// Create Thread for handling Broadcast Packet
	m_hThreadReceiveBroadcastPacket = CreateThread(NULL, 0,(LPTHREAD_START_ROUTINE)ThreadReceiveBroadcastMsgFromHOSE,this, 0, &dwThreadID);

	return nRet;
}

// Create Thread for processing Queue and Broadcast Packet, AutoT Packet
int CAutoTProtocol::CreateHandlingThread()
{
	int nRet = RETURN_SUCCESS;
	DWORD dwThreadID;

	// Thread for handling Retransmission Message
	m_hThreadHandlingRetransmissionMessage = CreateThread(NULL, 0,(LPTHREAD_START_ROUTINE)ThreadHandlingRetransmissionMessage,this, 0, &dwThreadID);;

	// Thread for handling Manager Message
	m_hThreadHandlingManagerMessage = CreateThread(NULL, 0,(LPTHREAD_START_ROUTINE)ThreadHandlingManagerMessage,this, 0, &dwThreadID);;


	return nRet;
}
// Create Thread for processing Queue and Broadcast Packet, AutoT Packet
int CAutoTProtocol::CreateWorkThread()
{
	int nRet = RETURN_SUCCESS;
	DWORD dwThreadID;
	
	g_hMutexEchoTime = CreateMutex(0, FALSE, 0);
	g_hMutexSendingAckFlag = CreateMutex(0, FALSE, 0);

	// Create Thread for polling CTCI Messages, and Send
	m_hThreadPollCTCIMsg = CreateThread(NULL, 0,(LPTHREAD_START_ROUTINE)ThreadPollCTCIMsgFromQueue,this, 0, &dwThreadID);	

	// Create Thread for handling Broadcast Packet
	// m_hThreadReceiveBroadcastPacket = CreateThread(NULL, 0,(LPTHREAD_START_ROUTINE)ThreadReceiveBroadcastMsgFromHOSE,this, 0, &dwThreadID);

	// Create Thread for handling AutoT Packet
	m_hThreadReceiveAutoTPacket = CreateThread(NULL, 0,(LPTHREAD_START_ROUTINE)ThreadReceiveAutoTPacketFromHOSE,this, 0, &dwThreadID);

	// Thread for handling Retransmission Message
	m_hThreadHandlingRetransmissionMessage = CreateThread(NULL, 0,(LPTHREAD_START_ROUTINE)ThreadHandlingRetransmissionMessage,this, 0, &dwThreadID);;

	// Thread for handling Manager Message
	m_hThreadHandlingManagerMessage = CreateThread(NULL, 0,(LPTHREAD_START_ROUTINE)ThreadHandlingManagerMessage,this, 0, &dwThreadID);;


	return nRet;
}

// Modulo Utilites
unsigned char CAutoTProtocol::ConvertCharToModulo96(unsigned char nValue, char* szModulo96)
{
	unsigned char nModulo = 0;
	szModulo96[0] = nValue + 32;
	return nModulo;
}

unsigned short CAutoTProtocol::ConvertShortToModulo96(unsigned short nValue, char* szModulo96)
{
	unsigned short nModulo = nValue;
	int i = 0;

	char tmp[2];

	memset(tmp, 32 , 2);
	memset(szModulo96, 32 , 2);

	do {
		tmp[i] = nModulo % 96 + 32; 
		nModulo = nModulo / 96;

		if(nModulo == 0)
			break;

		i++;
	} while(1);

	szModulo96[0] = tmp[1];
	szModulo96[1] = tmp[0];

	return RETURN_SUCCESS;
}

unsigned int CAutoTProtocol::ConvertIntToModulo96(unsigned int nValue, char* szModulo96)
{
	unsigned int nModulo = nValue;
	int i = 0;

	char tmp[4];

	memset(tmp, 32 , 4);
	memset(szModulo96, 32 , 4);

	do {
		tmp[i] = nModulo % 96 + 32; 
		nModulo = nModulo / 96;

		if(nModulo == 0)
			break;

		i++;
	} while(1);

	szModulo96[0] = tmp[3];
	szModulo96[1] = tmp[2];
	szModulo96[2] = tmp[1];
	szModulo96[3] = tmp[0];

	return RETURN_SUCCESS;
}

int CAutoTProtocol::ConvertIntTo3BytesModulo96(unsigned int nValue, char* szModulo96)
{
unsigned int nModulo = nValue;
	int i = 0;

	char tmp[4];

	memset(tmp, 32 , 4);
	memset(szModulo96, 32 , 4);

	do {
		tmp[i] = nModulo % 96 + 32; 
		nModulo = nModulo / 96;

		if(nModulo == 0)
			break;

		i++;
	} while(1);

	szModulo96[0] = tmp[2];
	szModulo96[1] = tmp[1];
	szModulo96[2] = tmp[0];

	return RETURN_SUCCESS;
}

unsigned char CAutoTProtocol::ConvertModulo96ToChar(char* szModulo96)
{
	unsigned char nChar = 0;
	nChar = (szModulo96[0]-32);
	return nChar;
}

unsigned short CAutoTProtocol::ConvertModulo96ToShort(char* szModulo96)
{
	unsigned short nShort = 0;
	nShort = (szModulo96[0]-32)*96 + (szModulo96[1]-32);
	return nShort;
}

unsigned int CAutoTProtocol::ConvertModulo96ToInt(char* szModulo96)
{
	unsigned int nInt = 0;

	nInt = (szModulo96[0]-32)*96*96*96 + (szModulo96[1]-32)*96*96 + 
			(szModulo96[2]-32)*96 + (szModulo96[3]-32);

	return nInt;
}

int CAutoTProtocol::ConvertModulo96To3Bytes(char* szModulo96)
{
	unsigned int nInt = 0;

	nInt = (szModulo96[0]-32)*96*96 + (szModulo96[1]-32)*96 + 
			(szModulo96[2]-32);

	return nInt;
}

// Processing Sequence Number
unsigned int CAutoTProtocol::GetAutoTSequenceNumber()
{
	return m_nAutoTSequenceNo;
}

unsigned int CAutoTProtocol::GetAutoTExpectAckSequenceNumber()
{
	return m_nAutoTAckSequenceNo + 1;
}

// Processing ACK Sequence Number
unsigned int CAutoTProtocol::GetAutoTAckSequenceNumber(unsigned int nAckSequenceNumber)
{
	m_nAutoTAckSequenceNo = nAckSequenceNumber;
	return m_nAutoTAckSequenceNo;
}

void DumpData(char* szData, int nLength)
{
	int i;
	char buff[MAX_SOCKET_BUFFER_SIZE];

	memset(buff, 0x20, MAX_SOCKET_BUFFER_SIZE);

	if(nLength > MAX_SOCKET_BUFFER_SIZE)
		return;
	
	for(i = 0; i < nLength; i++)
	{
		sprintf(&buff[i], "%c", szData[i]);
	}
	LOG_INFO("Dump Data: %s\n", buff);
}

int CAutoTProtocol::CheckHOSEPacket(stAutoTMessageFormat *pMsg)
{
	int nRet = PACKET_OK;

#ifndef FIX_200080720
	if((pMsg->sequence_no < m_nAutoTSequenceNo) || (pMsg->sequence_no > m_nAutoTSequenceNo)){
		nRet = INVALID_SEQUENCE;
		goto finish;
	}
#else
	if((pMsg->sequence_no < m_nAutoTAckSequenceNo) || (pMsg->sequence_no > m_nAutoTAckSequenceNo)){
		nRet = INVALID_SEQUENCE;
		goto finish;
	}
#endif	
	
	if ((pMsg->ack_sequence_number - 1 + AUTO_T_WINDOWS_SIZE < m_nAutoTSequenceNo) || (m_nAutoTSequenceNo <= pMsg->ack_sequence_number - 1)){
		//nRet = INVALID_ACK_SEQUENCE;
		LOG_INFO("INVALID_ACK_SEQUENCE\n");
		goto finish;
	}

finish:
	return nRet;
}

//@@@ Than add
DWORD CAutoTProtocol::ThreadHandlingRetransmissionMessage(CAutoTProtocol *pBroadcastProtocol)
{
	int nRet = RETURN_SUCCESS;
	int rcvSock;
	int sock_len;

	char szRcvData[MAX_SOCKET_BUFFER_SIZE];

	int optval =1;

	struct sockaddr_in local_addr;
	struct sockaddr_in manager_addr;
	int manager_addr_len = sizeof(manager_addr);;

	struct sockaddr_in broadcast_retrans_addr;
	int broadcast_retrans_addr_len = sizeof(broadcast_retrans_addr);;

	int nLength;

	int nSelect;
	fd_set rset;
	struct timeval timeout;

	stRetransmissionFormat_Req* pRcvMsg;
	stRetransmissionFormat_Ack SndMsg;

	SndMsg.mgsType = MSG_RETRANSMISSION_ACK;
	SndMsg.mgsLength = 4;

	if ((rcvSock = socket(AF_INET,SOCK_DGRAM,0)) == INVALID_SOCKET) 
	{ 
		LOG_ERROR("Failed to create UDP Socket, error Code = %d\n", WSAGetLastError());
		nRet = RETURN_FAIL;
		goto finish;
	}

	memset(&local_addr, 0, sizeof(local_addr));
	local_addr.sin_family      = AF_INET;
	//local_addr.sin_addr.s_addr = htonl(INADDR_ANY);
	local_addr.sin_addr.s_addr = inet_addr("127.0.0.1");
	local_addr.sin_port        = htons(AUTOT_RETRANSMISSION_UDP_PORT);

	memset(&broadcast_retrans_addr, 0, sizeof(broadcast_retrans_addr));
	broadcast_retrans_addr.sin_family      = AF_INET;
	//local_addr.sin_addr.s_addr = htonl(INADDR_ANY);
	broadcast_retrans_addr.sin_addr.s_addr = inet_addr("127.0.0.1");
	broadcast_retrans_addr.sin_port        = htons(BROADCAST_RETRANSMISSION_UDP_PORT);

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
				LOG_ERROR("Failed to received UDP DATA, error Code = %d\n", WSAGetLastError());
				continue;
			}

			// Processing with Restranmission
			pRcvMsg = (stRetransmissionFormat_Req*)szRcvData;
			if(pRcvMsg->mgsType != MSG_RETRANSMISSION_REQ)
			{
				LOG_ERROR("REQ from Broadcast handler failed\n");
				continue;
			}

			nRet = pBroadcastProtocol->MakeAndSendRequestRetransmissionBroadcastPacket(pRcvMsg->from_sequence_no, pRcvMsg->to_sequence_no);
			if(nRet == RETURN_SUCCESS)
			{
				SndMsg.result = RETRANSMISSION_ACK_SUCCESSED;
			}
			else
			{
				SndMsg.result = RETRANSMISSION_ACK_FAIED;
			}
			
			// Send Ack with rcvSock
			//nLength = sendto(rcvSock, (char*)&SndMsg, sizeof(stRetransmissionFormat_Ack), 0,(struct sockaddr *) &manager_addr, manager_addr_len);
			nLength = sendto(rcvSock, (char*)&SndMsg, sizeof(stRetransmissionFormat_Ack), 0,(struct sockaddr *) &broadcast_retrans_addr, broadcast_retrans_addr_len);
			if(nLength < 0)
			{
				LOG_ERROR("Failed to send ACK to Broadcast Handler\n");
			}
		}
	}

finish:
	return nRet;
}

DWORD CAutoTProtocol::ThreadHandlingManagerMessage(CAutoTProtocol *pBroadcastProtocol)
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