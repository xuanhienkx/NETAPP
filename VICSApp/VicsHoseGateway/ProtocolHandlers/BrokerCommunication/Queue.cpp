// Queue.cpp: implementation of the CQueue class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "BrokerCommunication.h"
#include "Queue.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

HANDLE g_hMutexQueue;

extern HANDLE	g_hRetransmissionLock;

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CQueue::CQueue()
{
	m_cchBuff = MAX_QUEUE_BUFFER_SIZE;
}

CQueue::~CQueue()
{

}

int CQueue::InitQueue()
{
	int nRet = RETURN_SUCCESS;
 	CString tmp = g_stConnectionData.szSendingQueueAddress;
	CString tmp1 = g_stConnectionData.szReceivingQueueAddress;

	g_hMutexQueue = CreateMutex(0, FALSE, 0);

	m_qDest = NULL;
	m_qRcvDest = NULL;

	CoInitialize(NULL);
	try{
		m_qInfo.CreateInstance("MSMQ.MSMQQueueInfo");
		m_qRead.CreateInstance("MSMQ.MSMQQueueInfo");
		m_qMsg.CreateInstance("MSMQ.MSMQMessage");

		m_qRcvInfo.CreateInstance("MSMQ.MSMQQueueInfo");
		m_qRcvRead.CreateInstance("MSMQ.MSMQQueueInfo");
		m_qRcvMsg.CreateInstance("MSMQ.MSMQMessage");

	    m_lpszSystemInfo = m_tchBuffer; 
		GetComputerName(m_lpszSystemInfo,&m_cchBuff);    //  Getting the ComputerName
	}
	catch (_com_error) {
		LOG_FATAL("Failed in CreateInstance of MSMQQueueInfo","MSMQ QueueInfo",1);
		ReleaseAll();

		nRet = RETURN_FAIL;
		goto finish;
	}

	m_SendingServerName = m_lpszSystemInfo;
	m_RecevingingServerName = m_lpszSystemInfo;
	//m_SendingServerName += "\\Private$\\";

	m_SendingServerName += tmp;
	m_RecevingingServerName += tmp1;

finish:
	return nRet;
}

int CQueue::ExitQueue()
{
	int nRet = RETURN_SUCCESS;
	//ReleaseAll();
	return nRet;
}

// CTCI Queue
int CQueue::GetCTCIQueueCount()
{
	int nRet = RETURN_SUCCESS;

	return nRet;
}

// Push CTCT Message to Queue
int CQueue::PushCTCIQueue(char* szQueueData, int nQueueLength)
{
	int nRet = RETURN_SUCCESS;

	nRet = PushQueue(szQueueData, nQueueLength);

	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Failed to Push CTCI Message to Queue\n");
		nRet = RETURN_FAIL;
		goto finish;
	}

	LOG_DEBUG("Push CTCI Message(%C%C, 0x%p), Length(%d) to queue\n", szQueueData[0], szQueueData[1], szQueueData, nQueueLength);

finish:
	return nRet;
}

int nSentDataCnt2 = 0;
// Pop CTCT Message to Queue
int CQueue::PopCTCIQueue(char* szQueueData, int* nQueueLength)
{
	int nRet = RETURN_SUCCESS;

	nRet = PopQueue(szQueueData, nQueueLength);

	if(nRet != RETURN_SUCCESS)
	{
		//LOG_ERROR("Failed to Pop CTCI Message to Queue\n");
		nRet = RETURN_FAIL;
		goto finish;
	}

	LOG_DEBUG("Pop CTCI Message(%C%C, 0x%p), Length(%d) to queue. No: %d\n", szQueueData[0], szQueueData[1], szQueueData, *nQueueLength, ++nSentDataCnt2);
finish:	
	return nRet;
}

// Read All CTCI Message from Queue and Make Packet Data
int CQueue::ReadAllCTCIMsgFromQueue(char* szQueueData, int nQueueLength)
{
	int nRet = RETURN_SUCCESS;

	return nRet;
}

// Broadcast Queue
int CQueue::GetBroadcastQueueCount()
{
	int nRet = RETURN_SUCCESS;

	return nRet;
}

// Push Broadcast Message to Queue
int CQueue::PushBroadcastQueue(char* szQueueData, int nQueueLength)
{
	int nRet = RETURN_SUCCESS;

	nRet = PushQueue(szQueueData, nQueueLength);

	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Failed to Push Broadcast Message to Queue\n");
		nRet = RETURN_FAIL;
		goto finish;
	}

	LOG_DEBUG("Push Broadcast Message(%C%C, %p), Length(%d) to queue\n", szQueueData[0], szQueueData[1], szQueueData, nQueueLength);
finish:
	return nRet;
}

// Pop Broadcast Message to Queue
int CQueue::PopBroadcastQueue(char* szQueueData, int* nQueueLength)
{
	int nRet = RETURN_SUCCESS;

	nRet = PopQueue(szQueueData, nQueueLength);

	if(nRet != RETURN_SUCCESS)
	{
		LOG_ERROR("Failed to Pop Broadcast Message to Queue\n");
		nRet = RETURN_FAIL;
		goto finish;
	}

	LOG_DEBUG("Pop Broadcast Message(%p), Length(%d) to queue\n", szQueueData, nQueueLength);

finish:
	return nRet;
}

int CQueue::PushQueue(char* szQueueData, int nQueueLength)
{
	int nRet = RETURN_SUCCESS;
	CString fname;
	VARIANT vMessage;
	
	//@@@ Than add
	if((szQueueData[0] == 'T') && (szQueueData[1] == 'S'))
	{
		WaitForSingleObject(g_hRetransmissionLock, INFINITE);
		g_nWaitingTS = CAN_SEND_RETRANSMISSION;
		WritePossibleReTransmission();
		ReleaseMutex(g_hRetransmissionLock);
	}

	//@@@

	//WaitForSingleObject(g_hMutexQueue, INFINITE);
	try
	{
		// Create a direct format name of the queue, and
		// set the FormatName property of the MSMQQueueInfo object.
		fname = "DIRECT=OS:";
		fname += m_RecevingingServerName;
		m_qRcvInfo->PathName = m_RecevingingServerName.AllocSysString();
		m_qRcvInfo->FormatName = fname.AllocSysString();    

		// Open the queue.
		m_qRcvDest = m_qRcvInfo->Open(MQ_SEND_ACCESS, MQ_DENY_NONE);
		m_qRcvMsg->Label = m_msgRcvLabel.AllocSysString();

		m_msgRcvData = szQueueData;

		VariantInit(&vMessage);
		vMessage.vt=VT_BSTR;
		vMessage.bstrVal=m_msgRcvData.AllocSysString();
		m_qRcvMsg->put_Body(vMessage);
		VariantClear(&vMessage);
		m_qRcvMsg->Send(m_qRcvDest);
		m_qRcvDest->Close();
    }
	catch(_com_error)
	{
		LOG_INFO("Failed to put data to queue\n");
		nRet = RETURN_FAIL;
		goto finish;
	}

	//LOG_TRACE("Push Message(0x%p), Length(%d) to queue\n", szQueueData, nQueueLength);

finish:
	//ReleaseMutex(g_hMutexQueue);
	return nRet;
}

int CQueue::PopQueue(char* szQueueData, int* nQueueLength)
{
	int nRet = RETURN_SUCCESS;
	_variant_t vtReceiveTimeout;
	_bstr_t label,body;
	CString fname;

	//VARIANT vtValue;

	//WaitForSingleObject(g_hMutexQueue, INFINITE);
	try
	{
		m_qRead->PathName=m_SendingServerName.AllocSysString();
		fname="DIRECT=OS:";
		fname+=m_SendingServerName;

		m_qInfo->PathName = m_SendingServerName.AllocSysString();
		m_qRead->FormatName = fname.AllocSysString();
		m_qDest = m_qRead->Open(MQ_RECEIVE_ACCESS,MQ_DENY_NONE);
		m_qMsg = m_qDest->Receive(&vtMissing,&vtMissing,&vtMissing,&vtReceiveTimeout);
		if(m_qMsg == NULL)
		{
			nRet = RETURN_FAIL;
			m_qDest->Close();	
			goto finish;
		}
		label = m_qMsg->GetLabel();

		//vtValue = m_qMsg->GetBody(); // Comments by MinhDQ on June 23,2008

		body = m_qMsg->GetBody().bstrVal;
		m_msgLabel=(LPSTR)label;
		m_msgData=(LPSTR)body;

		m_qDest->Close();

		*nQueueLength = body.length();
		memcpy(szQueueData, (char*)body, *nQueueLength);
	}
	catch(_com_error)
	{
		//LOG_INFO("Queue is empty\n");
		nRet = RETURN_FAIL;
		goto finish;
	}

	// LOG_TRACE("Pop Message(%p), Length(%d) to queue\n", szQueueData, nQueueLength);

finish:
	//ReleaseMutex(g_hMutexQueue);
	return nRet;
}

void CQueue::ReleaseAll()
{
	try
	{
		m_qInfo->Release();
		m_qRead->Release();
		m_qMsg->Release();

		m_qRcvInfo->Release();
		m_qRcvRead->Release();
		m_qRcvMsg->Release();

		CoUninitialize();
	}
	catch(_com_error)
	{

	}
}
