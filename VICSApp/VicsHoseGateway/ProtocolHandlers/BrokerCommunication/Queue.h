// Queue.h: interface for the CQueue class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_QUEUE_H__DC7BD473_5724_461A_895F_B2D8B7B0A00A__INCLUDED_)
#define AFX_QUEUE_H__DC7BD473_5724_461A_895F_B2D8B7B0A00A__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#define MAX_QUEUE_BUFFER_SIZE 1024

#import "mqoa.dll"
using namespace MSMQ;

class CQueue  
{
public:
	CQueue();
	virtual ~CQueue();

public:
	int InitQueue();
	int ExitQueue();

	// Queue
	int PushQueue(char* szQueueData, int nQueueLength);
	int PopQueue(char* szQueueData, int* nQueueLength);

	// CTCI Queue
	int GetCTCIQueueCount();
	int PushCTCIQueue(char* szQueueData, int nQueueLength);
	int PopCTCIQueue(char* szQueueData, int* nQueueLength);
	int ReadAllCTCIMsgFromQueue(char* szQueueData, int nQueueLength);

	// Broadcast Queue
	int GetBroadcastQueueCount();
	int PushBroadcastQueue(char* szQueueData, int nQueueLength);
	int PopBroadcastQueue(char* szQueueData, int* nQueueLength);

	void ReleaseAll();

	IMSMQQueuePtr		m_qDest;  // Represents Destination Queue
	IMSMQQueueInfoPtr	m_qInfo;	  //Represents an open instance of the destination queue
	IMSMQQueueInfoPtr	m_qRead;
	IMSMQMessagePtr     m_qMsg;     //Represents the message

	CString	m_msgLabel;
	CString	m_msgData;

	// For push queue to receving queue
	IMSMQQueuePtr		m_qRcvDest;  // Represents Destination Queue
	IMSMQQueueInfoPtr	m_qRcvInfo;	  //Represents an open instance of the destination queue
	IMSMQQueueInfoPtr	m_qRcvRead;
	IMSMQMessagePtr     m_qRcvMsg;     //Represents the message

	CString	m_msgRcvLabel;
	CString	m_msgRcvData;


	CString	m_SendingServerName;
	CString	m_RecevingingServerName;

	LPTSTR m_lpszSystemInfo;      // pointer to system information string 
	DWORD m_cchBuff;    // size of computer 
	TCHAR m_tchBuffer[MAX_QUEUE_BUFFER_SIZE];   // buffer for string
};

#endif // !defined(AFX_QUEUE_H__DC7BD473_5724_461A_895F_B2D8B7B0A00A__INCLUDED_)
