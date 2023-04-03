// BroadcastHandler.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "BroadcastHandler.h"
#include "Cfg.h"
#include "Common.h"
#include "BroadcastProtocol.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


/////////////////////////////////////////////////////////////////////////////
// The one and only application object

CWinApp theApp;
CCfg g_cfg;
CBroadcastProtocol g_broadcastProtocol;
int g_nStopBroadcast;


FILE* g_hLogFile;

HANDLE g_hMutexLogFile;
HANDLE g_hMutexRetransmissionInfo;

char* g_szLogFileName = "";
CString logFileName = "";
char* g_szReTransmissionFileName = "ReTransmission.bin";

char* g_szParameterFileName = "app.cfg";
CRetransmissionInfo g_stRetransmissionInfo;

using namespace std;

int _tmain(int argc, TCHAR* argv[], TCHAR* envp[])
{
	int nRetCode = RETURN_SUCCESS;

	// initialize MFC and print and error on failure
	if (!AfxWinInit(::GetModuleHandle(NULL), NULL, ::GetCommandLine(), 0))
	{
		// TODO: change error code to suit your needs
		cerr << _T("Fatal Error: MFC initialization failed") << endl;
		nRetCode = 1;
	}
	else
	{
		// TODO: code your application's behavior here.
		
		// Initate log file		
		if(InitLog() == RETURN_FAIL)
		{	
			cout << (LPCTSTR) "Failed to init log module, please check !!!";
			return FALSE;
		}
		
		LOG_INFO("Start Program ...\n");
		
		// Create mutex to control Re-Transmission File
		g_hMutexRetransmissionInfo = CreateMutex(0, FALSE, 0);
		
		// Load parameters from configuration file
		if (g_cfg.LoadParameters(g_szParameterFileName) == RETURN_SUCCESS)
		{
			LOG_INFO("Successful reading parameters from file\n");
			if(g_cfg.m_udpSequence == 1){
				WaitForSingleObject(g_hMutexRetransmissionInfo,INFINITE);	
				// Rewrite calculated transmission information back to file
				g_stRetransmissionInfo.reset();
				g_stRetransmissionInfo.WriteRetransmissionFile();
				ReleaseMutex(g_hMutexRetransmissionInfo);
			}	
		}else{
			LOG_ERROR("Unable to read parameters from file\n");
			nRetCode = RETURN_FAIL;
			goto finish;
		}
		
		//Initiate inbox queue
		if (g_broadcastProtocol.m_queue.InitQueue(g_cfg.m_inboxQueue) == RETURN_FAIL){
			nRetCode = RETURN_FAIL;
			goto finish;
		}else{
			LOG_TRACE("Initiating queue successful\n");
		}
				
		// Initiate stop broadcast flag
		g_nStopBroadcast = 0;

		//Initiate broadcast socket		
		if(g_broadcastProtocol.m_broadcastSocket.InitSocket() == RETURN_FAIL){
			nRetCode = RETURN_FAIL;
			goto finish;
		}else{
			LOG_TRACE("Initiating broadcast socket successful\n");
		}
		
		// Read Re-Transmission File
		g_stRetransmissionInfo.ReadReTransmissionFile();


		/********************************
		g_stRetransmissionInfo.reset();
		g_stRetransmissionInfo.CalculateRetransmisionInfo(801, 1200);
		g_stRetransmissionInfo.WriteRetransmissionFile();
		*********************************/

		//Initate Broadcast Packet Receiving Thread
		if(g_broadcastProtocol.CreateBroadcastPacketReceivingThread() == RETURN_FAIL){
			nRetCode = RETURN_FAIL;
			goto finish;
		}else{
			LOG_TRACE("Initiating broadcast packet receiving thread successful\n");
		
		}

		//Initate Retransmission Handling Thread
		if(g_broadcastProtocol.CreateRetransmissionHandlingThread() == RETURN_FAIL){
			nRetCode = RETURN_FAIL;
			goto finish;
		}else{
			LOG_TRACE("Initiating retransmission handling thread successful\n");
		
		}

		//Initate Retransmission Handling Thread
		if(g_broadcastProtocol.CreateHandlingManagerMessageThread() == RETURN_FAIL){
			nRetCode = RETURN_FAIL;
			goto finish;
		}else{
			LOG_TRACE("Initiating handling manager thread thread successful\n");
		
		}

		cout << (LPCTSTR) ">" << endl;

		while(1)
		{
			Sleep(1000);
		}

		/*
		CString strHello;
		strHello.LoadString(IDS_HELLO);
		cout << (LPCTSTR)strHello << endl;
		*/
	}
finish:
	return nRetCode;
}


int FileLogCheckSize(FILE *pFile)
{
	int iRet = RETURN_FAIL;
	long size;

	if(fseek(pFile, 0, SEEK_END) == 0)
	{
		if((size=ftell(pFile)) != -1)
		{
			if(size > MAX_FILE_SIZE)
			{
				iRet = RETURN_SUCCESS;
			}
		}
	}
	return iRet;

}

int InitLog()
{
	int nRet = RETURN_SUCCESS;

	CTime curTime = CTime::GetCurrentTime();
	CString cs = "BroadcastLog" + curTime.Format("%Y-%m-%d") + ".txt";
	g_szLogFileName = cs.GetBuffer(cs.GetLength());

	g_hLogFile = fopen(g_szLogFileName, "a+");
	if(g_hLogFile == NULL)
	{
		TRACE2("Couldn't open file %s; %s", g_szLogFileName, strerror(errno));
		nRet = RETURN_FAIL;
		goto finish;
	};                  // no attr. template

	g_hMutexLogFile = CreateMutex(0, FALSE, 0);

finish:
	return nRet;

}

int WriteLog(const char* p_szMessage, ...)
{
	int nRet = RETURN_SUCCESS;
	char	buff[2500];
	va_list args;
	int		len = 0;
	char szTime[3000];

	//char szBkFileName[300];

	CTime curTime = CTime::GetCurrentTime();

	va_start(args, p_szMessage);

	memset(buff, 0, sizeof(buff));
	len = vsprintf(buff, p_szMessage, args);

	sprintf(szTime, "%04d//%02d//%02d-%02d:%02d:%02d %s", curTime.GetYear(),curTime.GetMonth(), curTime.GetDay(),
		curTime.GetHour(), curTime.GetMinute(), curTime.GetSecond(), buff);		// 2008/06/26-10h:20

	//sprintf(szBkFileName, "%s_%04d_%02d_%02d_%02dh", g_szLogFileName, curTime.GetYear(),curTime.GetMonth(), curTime.GetDay(),
	//	curTime.GetHour());
	

	WaitForSingleObject(g_hMutexLogFile, INFINITE);

	CString cs = "Broadcast" + curTime.Format("%Y-%m-%d") + ".txt";

	if (logFileName != cs){
		fclose(g_hLogFile);
		g_szLogFileName = cs.GetBuffer(cs.GetLength());
		logFileName = cs;
		
		g_hLogFile = fopen(g_szLogFileName, "a+");
		if(g_hLogFile == NULL){
			TRACE2("Couldn't open file %s; %s", g_szLogFileName, strerror(errno));
			nRet = RETURN_FAIL;
			goto finish;
		}
	}

/*
	if(FileLogCheckSize(g_hLogFile) == RETURN_SUCCESS) // Create new File
	{
		fclose(g_hLogFile);
		if(remove(g_szLogFileName) != -1)
		{
			g_hLogFile = fopen(g_szLogFileName, "a+");
		}
	}*/

	if(fseek(g_hLogFile, 0, SEEK_END) != 0)
	{
		TRACE1("This file could't seek position to end file; %s", strerror(errno));
		nRet = RETURN_FAIL;
		goto finish;
	}

	if(fputs(szTime, g_hLogFile) == EOF)
	{
		TRACE1("This file could't write data to file; %s", strerror(errno));
		nRet = RETURN_FAIL;
		goto finish;
	}

	if(fflush(g_hLogFile)==EOF)
	{
		TRACE1("This file could't flush data to disk; %s", strerror(errno));
		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
	ReleaseMutex(g_hMutexLogFile);
	return nRet;
}

