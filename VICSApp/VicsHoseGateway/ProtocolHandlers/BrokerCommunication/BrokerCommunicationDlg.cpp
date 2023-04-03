// BrokerCommunicationDlg.cpp : implementation file
//

#include "stdafx.h"
#include "BrokerCommunication.h"
#include "BrokerCommunicationDlg.h"

#include "ConnectionSetting.h"
#include "BrokerSocket.h"

#include "RestransmissionBroadcastPacket.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

stConnectionData g_stConnectionData;

int g_nWaitingTS = CAN_SEND_RETRANSMISSION;

FILE* g_hLogFile;
HANDLE g_hMutexLogFile;

char* g_szTransmissionDataFileName = "TransmissionD.bin";
char* g_szUnsentDataFileName = "UnSentData.bin";
char* g_szReTransmissionFileName = "ReTransmission.bin";
char* g_szSettingParametersFileName = "Setting.bin";
char* g_szLogFileName = "";
CString logFileName = "";

char* g_szPossibleReTransmissionFileName = "TSReTransmission.bin";

char *szOpcodeData[] = {"HL", "HR", "CF", "DT", "LO", "LL", 
				"RR", "RP", "RQ", "AK", "NK", "FN", "AF", "EC", "ER", "UNKNOWN"};

int nOpcodeCnt = sizeof(szOpcodeData)/sizeof(char*);

int nEchoTime = 0;
int nTestTime = 0;

HANDLE g_hMutexLockStopFlag;
int nStopFlag = NONE_STOP;

HANDLE g_hMutexSendingAckFlag;
int nSendingACKFlag = NO_SENDING_ACK;

HANDLE g_hMutexLockDataTransmission;

HANDLE	g_hRetransmissionLock;

char* Opcode2String(unsigned short nOpcode)
{
	int i;
	char* pstrOpcode;

	for(i = 0; i < nOpcodeCnt; i++)
	{
		if((szOpcodeData[i][0]*256 + szOpcodeData[i][1]) == nOpcode)
		{
			pstrOpcode = szOpcodeData[i];
			break;
		}
	}

	if(i == nOpcodeCnt)
	{
		pstrOpcode = szOpcodeData[nOpcodeCnt - 1];
	}

	return pstrOpcode;
}

// ab --> ba
unsigned short short_swap(unsigned short value)
{
    return (unsigned short)(((value&0x00ff) << 8) | ((value&0xff00) >> 8));
}

// abcd --> dcba
unsigned long long_swap(unsigned long value)
{
    return (unsigned long)(((value&0x000000ff) << 24)|((value&0x0000ff00) << 8)|((value&0x00ff0000) >> 8)|((value&0xff000000) >> 24));
}

int SetDefaultParameters()
	{
	int nRet = RETURN_SUCCESS;
	char* defaultpass = "hovanthan";

	g_stConnectionData.nTCPPort = 2000;
	g_stConnectionData.nUDPPort = 3000;

	g_stConnectionData.nRetryTime = 3;
	g_stConnectionData.nTimeout = 3;

	g_stConnectionData.nMaxPacketSize = 600;
	g_stConnectionData.nMaxPacketTime = 500;

	g_stConnectionData.nLinkID = 1000;

	g_stConnectionData.nConnectionMode = APP_MODE_A;
	sprintf(g_stConnectionData.szPassword, "hovanthan");
	g_stConnectionData.szMarketID = 'A';
	g_stConnectionData.szFirmID[0] = 'A';
	g_stConnectionData.szFirmID[1] = 'B';
	g_stConnectionData.szFirmID[2]= 'C';

	g_stConnectionData.HOSEIPAddress[0] = 192;
	g_stConnectionData.HOSEIPAddress[1] = 168;
	g_stConnectionData.HOSEIPAddress[2] = 1;
	g_stConnectionData.HOSEIPAddress[3] = 100;

	sprintf(g_stConnectionData.szSendingQueueAddress, "\\Private$\\sendingqueue");
	sprintf(g_stConnectionData.szReceivingQueueAddress, "\\Private$\\receivingqueue");

	g_stConnectionData.nBroadcastSeq = 1;

	g_stConnectionData.nAutoConnect = 0;

	return nRet;
}


int WriteSettingParameters()
{
	int nRet = RETURN_SUCCESS;
	FILE *fout = fopen(g_szSettingParametersFileName, "wb");

	if (fout)
	{
		fwrite((char*)&g_stConnectionData, sizeof(g_stConnectionData), 1, fout);
		fclose(fout);
	}
	else
	{
		LOG_FATAL("Failed to write Setting Parameters %s", strerror(errno));
		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
	return nRet;
}

int ReadSettingParameters()
{
	int nRet = RETURN_SUCCESS;
	FILE *fout = fopen(g_szSettingParametersFileName, "rb");

	if (fout)
	{
		LOG_INFO("Load Setting Parameters From File(%s) \n", g_szSettingParametersFileName);
		fread((char*)&g_stConnectionData, sizeof(g_stConnectionData), 1, fout);

		g_stConnectionData.nConnectionMode = APP_MODE_C;

		fclose(fout);
	}
	else
	{
		LOG_INFO("Setting Parameters set to default, File(%s) no exist\n", g_szSettingParametersFileName);
		SetDefaultParameters();
		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
	return nRet;
}

int WriteTransmissionData()
{
	int nRet = RETURN_SUCCESS;
	FILE *fout = fopen(g_szTransmissionDataFileName, "wb");

	if (fout)
	{
		fwrite((char*)&g_stTransmissionData , sizeof(g_stTransmissionData), 1, fout);
		fclose(fout);
	}
	else
	{
		LOG_FATAL("Failed to write Transmission Data %s", strerror(errno));
		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
	return nRet;
}

int WriteUnsentData()
{
	int nRet = RETURN_SUCCESS;
	FILE *fout = fopen(g_szUnsentDataFileName, "wb");

	if (fout)
	{
		fwrite((char*)&g_stUnsentData , sizeof(g_stUnsentData), 1, fout);
		fclose(fout);
	}
	else
	{
		LOG_FATAL("Failed to write Unsent Data %s", strerror(errno));
		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
	return nRet;
}

int WriteTransmissionSeqAndAckSeq(unsigned int nAutoTSequenceNo, unsigned int nAutoTAckSequenceNo)
{
	g_stTransmissionData.nAutoTSequenceNo = nAutoTSequenceNo;
	g_stTransmissionData.nAutoTAckSequenceNo = nAutoTAckSequenceNo;
	return WriteTransmissionData();
}

int WriteTransmissionAckSeqAndStartSeq(unsigned int nAutoTAckSequenceNo, unsigned int nAutoTSequenceNoStart)
{
	g_stTransmissionData.nAutoTAckSequenceNo = nAutoTAckSequenceNo;
	g_stTransmissionData.nAutoTSequenceNoStart = nAutoTSequenceNoStart;
	return WriteTransmissionData();
}

int WriteTransmissionSeqAndAckSeqAndPacket(unsigned int nAutoTSequenceNo, unsigned int nAutoTAckSequenceNo, int nIndex, stAutoTMessageFormat* sndPkt)
{
	g_stTransmissionData.nAutoTSequenceNo = nAutoTSequenceNo;
	g_stTransmissionData.nAutoTAckSequenceNo = nAutoTAckSequenceNo;

	g_stTransmissionData.arrSndPacket[nIndex] = *sndPkt;	

	return WriteTransmissionData();
}

int SetDefaultTransmissionData()
{
	int nRet = RETURN_SUCCESS;

	memset((char*)&g_stTransmissionData, 0, sizeof(g_stTransmissionData));

	g_stTransmissionData.nAutoTSequenceNo = 1;
	g_stTransmissionData.nAutoTSequenceNoStart = 1;

	g_stTransmissionData.nAutoTAckSequenceNo = 1;

	g_stConnectionData.nConnectionMode = APP_MODE_A;

	return nRet;
}

int ReadTransmissionData()
{
	int nRet = RETURN_SUCCESS;
	FILE *fout = fopen(g_szTransmissionDataFileName, "rb");

	if (fout)
	{
		LOG_INFO("Load Transmission Data From File(%s) \n", g_szTransmissionDataFileName);
		fread((char*)&g_stTransmissionData, sizeof(g_stTransmissionData), 1, fout);
		fclose(fout);
	}
	else
	{
		LOG_INFO("Transmission Data set to Default value, File(%s) no exist\n", g_szSettingParametersFileName);
		
		SetDefaultTransmissionData();

		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
	return nRet;
}

int ReadUnsentData()
{
	int nRet = RETURN_SUCCESS;
	FILE *fout = fopen(g_szUnsentDataFileName, "rb");

	if (fout)
	{
		LOG_INFO("Load Unsent Data From File(%s) \n", g_szUnsentDataFileName);
		fread((char*)&g_stUnsentData, sizeof(g_stUnsentData), 1, fout);
		fclose(fout);
	}
	else
	{
		LOG_INFO("File(%s) no exist\n", g_szUnsentDataFileName);
		g_stUnsentData.nCount = 0;
		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
	return nRet;
}


int WriteReTransmissionInfor()
{
	int nRet = RETURN_SUCCESS;
	FILE *fout = fopen(g_szReTransmissionFileName, "wb");

	if (fout)
	{
		fwrite((char*)&g_stRestransmissionInfor , sizeof(g_stRestransmissionInfor), 1, fout);
		fclose(fout);
	}
	else
	{
		LOG_FATAL("Failed to write Re Transmission Infor %s", strerror(errno));
		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
	return nRet;
}

int ReadReTransmissionInfor()
{
	int nRet = RETURN_SUCCESS;
	FILE *fout = fopen(g_szReTransmissionFileName, "rb");

	if (fout)
	{
		LOG_INFO("Load ReTransmission Infor From File(%s) \n", g_szReTransmissionFileName);
		fread((char*)&g_stRestransmissionInfor, sizeof(g_stRestransmissionInfor), 1, fout);
		fclose(fout);
	}
	else
	{
		LOG_INFO("ReTransmission Infor set to Default value, File(%s) no exist\n", g_szReTransmissionFileName);
		memset(&g_stRestransmissionInfor, 0, sizeof(g_stRestransmissionInfor));
		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
	return nRet;
}

int InitLog()
{
	int nRet = RETURN_SUCCESS;

	CTime curTime = CTime::GetCurrentTime();
	logFileName = "AutoTLog" + curTime.Format("%Y-%m-%d") + ".txt";
	g_szLogFileName = logFileName.GetBuffer(logFileName.GetLength());

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

#define MAX_FILE_SIZE (10*1024*1024)

int FileLogCheckSize(FILE* pFile)
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

	sprintf(szTime, "%04d/%02d/%02d-%02d:%02d:%02d %s", curTime.GetYear(),curTime.GetMonth(), curTime.GetDay(),
		curTime.GetHour(), curTime.GetMinute(), curTime.GetSecond(), buff);		// 2008/06/26-10h:20

	//sprintf(szBkFileName, "%s_%04d_%02d_%02d_%02dh", g_szLogFileName, curTime.GetYear(),curTime.GetMonth(), curTime.GetDay(),
	//	curTime.GetHour());
	

	WaitForSingleObject(g_hMutexLogFile, INFINITE);

	CString cs = "AutoTLog" + curTime.Format("%Y-%m-%d") + ".txt";

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

int WritePossibleReTransmission()
{
	int nRet = RETURN_SUCCESS;
	FILE *fout = fopen(g_szPossibleReTransmissionFileName, "wb");

	if (fout)
	{
		fwrite((char*)&g_nWaitingTS , sizeof(int), 1, fout);
		fclose(fout);
	}
	else
	{
		LOG_FATAL("Failed to write Re Transmission Infor %s", strerror(errno));
		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
	return nRet;
}

int ReadPossibleReTransmission()
{
	int nRet = RETURN_SUCCESS;
	FILE *fout = fopen(g_szPossibleReTransmissionFileName, "r+t");

	if (fout)
	{
		LOG_INFO("Load Possible ReTransmission Infor From File(%s) \n", g_szReTransmissionFileName);
		fread((char*)&g_nWaitingTS, sizeof(int), 1, fout);
		fclose(fout);
	}
	else
	{
		LOG_INFO("Possible ReTransmission Infor set to Default value, File(%s) no exist\n", g_szReTransmissionFileName);
		g_nWaitingTS = CAN_SEND_RETRANSMISSION;
		nRet = RETURN_FAIL;
		WritePossibleReTransmission();
		goto finish;
	}

finish:
	return nRet;
}
/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	//{{AFX_DATA(CAboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(CAboutDlg)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CBrokerCommunicationDlg dialog

CBrokerCommunicationDlg::CBrokerCommunicationDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CBrokerCommunicationDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CBrokerCommunicationDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CBrokerCommunicationDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CBrokerCommunicationDlg)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CBrokerCommunicationDlg, CDialog)
	//{{AFX_MSG_MAP(CBrokerCommunicationDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_COMMAND(ID_CONNECTIONSETUP_SETTING, OnConnectionsetupSetting)
	ON_COMMAND(ID_CONNECTIONSETUP_CONNECT, OnConnectionsetupConnect)
	ON_COMMAND(ID_HELP_ABOUT, OnHelpAbout)
	ON_COMMAND(ID_START_NEW_DAY, OnStartNewDay)
	ON_COMMAND(ID_CONNECTIONSETUP_DISCONNECT, OnConnectionsetupDisconnect)
	ON_COMMAND(ID_CONNECTIONSETUP_TESTING, OnConnectionsetupTesting)
	ON_COMMAND(ID_CONNECTIONSETUP_RETRANSMISSION, OnConnectionsetupRetransmission)
	ON_WM_TIMER()
	ON_WM_DESTROY()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CBrokerCommunicationDlg message handlers

BOOL CBrokerCommunicationDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	int nRet = RETURN_SUCCESS;


	char tmp[4];
	m_AutoTProtocol.ConvertIntToModulo96(1577, tmp);

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	// TODO: Add extra initialization here
	g_hMutexLockStopFlag = CreateMutex(0, FALSE, 0);

	g_hMutexLockDataTransmission = CreateMutex(0, FALSE, 0);

	g_hRetransmissionLock = CreateMutex(0, FALSE, 0);

	if(InitLog() == RETURN_FAIL)
	{
		MessageBox("Failed to init log module, please check !!!");
		return FALSE;
	}

	LOG_INFO("Start Program ...\n");

	if(ReadSettingParameters() == RETURN_SUCCESS)
	{
		LOG_INFO("Setting Parameters read from File\n");
	}
	else
	{
		LOG_INFO("Using Default Parameters\n");
	}

	if(ReadTransmissionData() == RETURN_SUCCESS)
	{
		LOG_INFO("Transmission Data read from File\n");
	}
	else
	{
		LOG_INFO("Using Default Transmission Data\n");
	}

	if(ReadReTransmissionInfor() == RETURN_SUCCESS)
	{
		LOG_INFO("ReTransmission Infor read from File\n");
	}
	else
	{
		LOG_INFO("Using Default ReTransmission Info\n");
	}

	if(ReadPossibleReTransmission() == RETURN_SUCCESS)
	{
		LOG_INFO("Possible ReTransmission Infor read from File\n");
	}
	else
	{
		LOG_INFO("Using Default ReTransmission Info\n");
	}

	if(ReadUnsentData() == RETURN_SUCCESS)
	{
		LOG_INFO("Unsent Data read from File\n");
	}else{
		LOG_INFO("Using Default Unsent Info\n");
	}
	m_AutoTProtocol.m_Queue.InitQueue();

	m_AutoTProtocol.InitializeData();

	m_AutoTProtocol.CreateHandlingThread();
	//m_AutoTProtocol.m_Socket.InitBroadcast();
	//m_AutoTProtocol.CreateBroadcastThread();

	// Tu dong ket noi
#if 1
	SetTimer(1, 5000, 0);
#endif

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CBrokerCommunicationDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CBrokerCommunicationDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
#if 1
		CPaintDC dc(this);
        CRect rect;
        GetClientRect(&rect);
        //ScreenToClient(rect);
        BITMAP bmp;
		m_hBmp = ::LoadBitmap(::AfxGetInstanceHandle(), 
				MAKEINTRESOURCE(IDB_BITMAP_BACKGROUND));
        ::GetObject(m_hBmp, sizeof(bmp), &bmp);
        HDC hDC = ::CreateCompatibleDC(NULL);
        SelectObject(hDC, m_hBmp);

		::StretchBlt(dc.m_hDC, 0, 0, rect.Width(), rect.Height(), hDC, 0, 0, bmp.bmWidth, bmp.bmHeight,  
            SRCCOPY);
#endif
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CBrokerCommunicationDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CBrokerCommunicationDlg::OnConnectionsetupSetting() 
{
	// TODO: Add your command handler code here
	CConnectionSetting dlg;	
	if(dlg.DoModal()!=IDOK)
		return;
}

void CBrokerCommunicationDlg::OnConnectionsetupConnect() 
{
	if((m_AutoTProtocol.m_nProgState == PROG_STOP) && (m_AutoTProtocol.Start() == RETURN_SUCCESS))
	{
		GetMenu()->EnableMenuItem(ID_CONNECTIONSETUP_CONNECT, MF_GRAYED);
		GetMenu()->EnableMenuItem(ID_CONNECTIONSETUP_DISCONNECT, MF_ENABLED);
		DrawMenuBar();	
	}
}

void CBrokerCommunicationDlg::OnHelpAbout() 
{
	CAboutDlg dlgAbout;
	dlgAbout.DoModal();	// TODO: Add your command handler code here
	
}

void CBrokerCommunicationDlg::OnStartNewDay() 
{
	// TODO: Add your command handler code here
	m_AutoTProtocol.Stop();
	m_AutoTProtocol.Start();
}

void CBrokerCommunicationDlg::OnConnectionsetupDisconnect() 
{
	if(nStopFlag == NONE_STOP)
	{
		if((m_AutoTProtocol.m_nProgState == PROG_DATA_TRANFER) && (m_AutoTProtocol.Stop() == RETURN_SUCCESS))
		{
			GetMenu()->EnableMenuItem(ID_CONNECTIONSETUP_DISCONNECT, MF_GRAYED);
			GetMenu()->EnableMenuItem(ID_CONNECTIONSETUP_CONNECT, MF_ENABLED);
			DrawMenuBar();		
		}
	}
}

void CBrokerCommunicationDlg::OnConnectionsetupTesting() 
{
		LOG_TRACE("Enter Test\n");

	// TODO: Add your command handler code here
	// MessageBox("Testing ...");
	
	char szCTCIMsg[] = {0x30, 0x30, 0x30, 0x30, 0x30};
	char message1C[] = {0x41, 0x21, // A !
		0x31, 0x43, //1C
		0x30, 0x30, 0x32, // 002: FIRM
		0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, // Order Number: 00000001
		0x31, 0x39, 0x30, 0x36 //1906
	};
	char message1C_B[] = {0x42, 0x21, // B !
		0x31, 0x43, //1C
		0x30, 0x30, 0x32, // 002: FIRM
		0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, // Order Number: 00000001
		0x31, 0x39, 0x30, 0x36 //1906
	};
	char messageRQ[] = {0x41, // A
		0x52, 0x51, //RQ
		0xA0, 0x22, // 02: FIRM (Mod-96)
		0x41, // MarketID:A
		0xA0, 0xA0, 0x21, // Start Sequence: 001
		0xA0, 0xA0, 0x28 // End Sequence: 008		
	};
	char messageRP[] = {0x41, // A
		0x52, 0x50, //RP
		0xA0, 0x22, // 02: FIRM (Mod-96)
		0x41, // MarketID:A
		0xA0, 0xA0, 0x21, // Previous Sequence Number: 001
		0x31, // Message Count: 1
		0xA0, 0xA0, 0x28, // Sequence Number: 008	
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73,
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73,
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73,
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73,
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73,
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 0x73, 
		0x73, 0x73, 0x73, 0x73, 0x73
	};
	char message1I[] = {0x41, 0x21,
		0x31, 0x49, //1I
		0x30, 0x30, 0x32, // 002: FIRM
		0x32,0x31,0x35,0x35, // TRADER ID : 2151
		0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, // Order Number: 00000001
		0x30, 0x30, 0x32,0x43, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, // CLIENT ID: 002C000001
		0x53, 0x53, 0x49, 0x20, 0x20, 0x20, 0x20, 0x20, // SECURITY SYMBOL: BBC
		0x42, // SIDE: B
		0x30, 0x30, 0x30, 0x30, 0x30, 0x31,0x30, 0x30, // VOLUME: 100
		0x30, 0x30, 0x30, 0x30, 0x30, 0x31,0x30, 0x30, // PUBLISHED VOLUME: 100
		0x20, 0x20, 0x20, 0x20, 0x32, 0x39, // PRICE: 000123
		0x4D, // BOARD: M
		0x20, 0x20, 0x20,0x20,0x20, //FILLER
		0x43, // PORT/CLIENT FLAG: C
		0x20, 0x20, 0x20,0x20,0x20 //FILLER		
	};

	char RPMsg[] = {0x41, 0x52, 0x4E, 0x20, 0x22, 0x30, 0x34, 0x52, 0x51, 0x20, 0x22, 0x41,
		0x20, 0x2A, 0x48, 0x20, 0x2A, 0x52};
	int RPMsgLen = sizeof(RPMsg)/sizeof(char);

	int nCTCILength = sizeof(szCTCIMsg)/sizeof(char);
	int nMessage1CLength = sizeof(message1C)/sizeof(char);
	int nMessage1ILength = sizeof(message1I)/sizeof(char);
	int nMessageRQLength = sizeof(messageRQ)/sizeof(char);
	int nMessageRPLength = sizeof(messageRP)/sizeof(char);

	int nRet = RETURN_SUCCESS;
	stAutoTMessageFormat	rcvPkt;
	stAutoTMessageFormat	sndDTPkt;
	stAutoTMessageFormat	sndRRPkt;
	stAutoTMessageFormat	sndECPkt;
	stAutoTMessageFormat	sndACKPkt;
	stAutoTMessageFormat	sndNACKPkt;
	stAutoTMessageFormat	sndRPPkt;

	if(m_AutoTProtocol.m_nProgState == PROG_DATA_TRANFER)
	{
		// Testcase 10: Send DT; passed
		//m_AutoTProtocol.SendDataPacket(message1C, nMessage1CLength);

		// Testcase 11: Send RR; failed: Data format is wrong
		//memcpy(sndRRPkt.data, messageRQ, nMessageRQLength);
		//m_AutoTProtocol.MakeAndSendRRPacket(&sndRRPkt);
	
		// Testcase 12: Send EC; passed
		//m_AutoTProtocol.MakeAndSendEchoPacket(&sndECPkt); 

		// Testcase 13: Send ACK; Gui ACK nhung coc thay HOSE reply ACK
		//unsigned int ack_sequence_number = 10; 
		//m_AutoTProtocol.MakeAndSendACKPacket(&sndACKPkt, ack_sequence_number);

		// Testcase 14: Send NACK; Hix! Sau khi gui NACK, 
		// --> Broker nhan duoc hang nghin messages, Length = 0;
		// unsigned short nErrorCode = 2202;
		// CString sErrorString = "Just send NACK for Test Case";
		// m_AutoTProtocol.MakeAndSendNACKPacket(&sndACKPkt, nErrorCode, sErrorString);

		// Testcase 15: Send RP; OK 
		// memcpy(sndRPPkt.data, RPMsg, RPMsgLen);
		// sndRPPkt.len = PACKET_HEADER_SIZE + RPMsgLen;
		// m_AutoTProtocol.MakeAndSendRPPacket(&sndRPPkt);

		// Testcase 16.1: Send DT with invalid sequence; Passed
		 //unsigned int nAutoTSequenceNo = 101; 
		 //m_AutoTProtocol.MakeAndSendEchoPacketWithInvalidSeq(&sndECPkt, nAutoTSequenceNo);
		 //m_AutoTProtocol.SendInvalidSeqTestDataPacket(message1C, nMessage1CLength, nAutoTSequenceNo);

		// Testcase 16.2: Send DT with invalid ack sequence; Mia no lai tra ve 2G vi Market bi Close
		 //unsigned int nAutoTAckSequenceNo = 1010;
		 // m_AutoTProtocol.MakeAndSendEchoPacketWithInvalidAckSeq(&sndECPkt, nAutoTAckSequenceNo);
		 //m_AutoTProtocol.SendInvalidAckSeqTestDataPacket(message1C, nMessage1CLength, nAutoTAckSequenceNo);

		// Testcase 16.3: Send DT with invalid market id 'B'; Passed
		 //m_AutoTProtocol.SendDataPacket(message1C_B, nMessage1CLength);

		// Testcase 16.4: Send DT with length more than 485; HOSE reply 2G
		//m_AutoTProtocol.SendDataPacket(message1C, 486);

		// Testcase 16.5; Me no toan reply 2G
		
			char message1C_16_4[] = {0x41, 0x21, // A !
			0x31, 0x43, //1C
			0x30, 0x30, 0x32, // 002: FIRM
			0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x36, 0x31, // Order Number: 00000001
			//0x31, 0x39, 0x30, 0x36 //1906
			};
		// m_AutoTProtocol.SendDataPacket_Testcase16_5(message1C_16_4, nMessage1CLength);

		// Testcase 16.6: Content is null
		// m_AutoTProtocol.SendDataPacket_Testcase16_5(message1C, 0);
	}
	
	if(m_AutoTProtocol.m_nProgState == PROG_DATA_TRANFER)
	{
		// Send DT package

		// Send Message 1C
		/*
		m_AutoTProtocol.SendDataPacket(message1C, nMessage1CLength);
		m_AutoTProtocol.SendDataPacket(message1C, nMessage1CLength);
		m_AutoTProtocol.SendDataPacket(message1C, nMessage1CLength);
		m_AutoTProtocol.SendDataPacket(message1C, nMessage1CLength);
		m_AutoTProtocol.SendDataPacket(message1C, nMessage1CLength);
		m_AutoTProtocol.SendDataPacket(message1C, nMessage1CLength);
		m_AutoTProtocol.SendDataPacket(message1C, nMessage1CLength);
		m_AutoTProtocol.SendDataPacket(message1C, nMessage1CLength);
		m_AutoTProtocol.SendDataPacket(message1C, nMessage1CLength);
		*/
		/*
		nRet = m_AutoTProtocol.ReceivePacket(&rcvPkt);
		if(nRet < 0)
		{
			LOG_ERROR("Failed to receive DT/ACK package after sending DT Packet\n");
			nRet = RETURN_FAIL;
			goto finish;
		}
		LOG_TRACE("Testing: Receive DT Packet, opcode = x%04x, seq_no = %d, ack_seq_no =%d\n", 
					rcvPkt.opcode, rcvPkt.sequence_no, rcvPkt.ack_sequence_number);
		*/
		/*
		// Send message RR
		memcpy(sndRRPkt.data, messageRQ, nMessageRQLength);
		m_AutoTProtocol.MakeAndSendRRPacket(&sndRRPkt);

		// Send message RP
		memcpy(sndRPPkt.data, messageRP, nMessageRPLength);
		m_AutoTProtocol.MakeAndSendRPPacket(&sndRPPkt);
		m_AutoTProtocol.MakeAndSendRPPacket(&sndRPPkt);
		m_AutoTProtocol.MakeAndSendRPPacket(&sndRPPkt);
		*/

		// Send Message 1I
		
		//m_AutoTProtocol.SendDataPacket(message1I, nMessage1ILength);
		//m_AutoTProtocol.SendDataPacket(message1I, nMessage1ILength);
		//m_AutoTProtocol.SendDataPacket(message1I, nMessage1ILength);
		//m_AutoTProtocol.SendDataPacket(message1I, nMessage1ILength);
		//m_AutoTProtocol.SendDataPacket(message1I, nMessage1ILength);
		//m_AutoTProtocol.SendDataPacket(message1I, nMessage1ILength);
		//m_AutoTProtocol.SendDataPacket(message1I, nMessage1ILength);

		//m_AutoTProtocol.SendDataPacket(message1I, nMessage1ILength);
		//m_AutoTProtocol.SendDataPacket(message1I, nMessage1ILength);
		
		//m_AutoTProtocol.SendDataPacket(message1I, nMessage1ILength);
		
		/*
		m_AutoTProtocol.SendDataPacket(message1I, nMessage1ILength);
		m_AutoTProtocol.SendDataPacket(message1I, nMessage1ILength);
		m_AutoTProtocol.SendDataPacket(message1I, nMessage1ILength);
		m_AutoTProtocol.SendDataPacket(message1I, nMessage1ILength);
		m_AutoTProtocol.SendDataPacket(message1I, nMessage1ILength);
		m_AutoTProtocol.SendDataPacket(message1I, nMessage1ILength);
		m_AutoTProtocol.SendDataPacket(message1I, nMessage1ILength);
	
		/*
		nRet = m_AutoTProtocol.ReceivePacket(&rcvPkt);
		if(nRet < 0)
		{
			LOG_ERROR("Failed to receive DT/ACK package after sending DT Packet\n");
			nRet = RETURN_FAIL;
			goto finish;
		}
		LOG_TRACE("Testing: Receive DT Packet, opcode = x%04x, seq_no = %d, ack_seq_no =%d\n", 
					rcvPkt.opcode, rcvPkt.sequence_no, rcvPkt.ack_sequence_number);
		*/

		// Send ECHO package
		/*
		m_AutoTProtocol.MakeAndSendEchoPacket(&sndECPkt);
		m_AutoTProtocol.MakeAndSendEchoPacket(&sndECPkt);
		nRet = m_AutoTProtocol.ReceivePacket(&rcvPkt);
		if(nRet < 0)
		{
			LOG_ERROR("Failed to receive ER package after sending EC Packet\n");
			nRet =  RETURN_FAIL;
			goto finish;
		}
		LOG_TRACE("Testing: Receive ER Packet, opcode = x%04x, seq_no = %d, ack_seq_no =%d\n", 
					rcvPkt.opcode, rcvPkt.sequence_no, rcvPkt.ack_sequence_number);
		*/
		
		// Send ACK package
		/*
		m_AutoTProtocol.MakeAndSendACKPacket(&sndACKPkt);
		m_AutoTProtocol.MakeAndSendACKPacket(&sndACKPkt);
		m_AutoTProtocol.MakeAndSendACKPacket(&sndACKPkt);
		m_AutoTProtocol.MakeAndSendACKPacket(&sndACKPkt);
		m_AutoTProtocol.MakeAndSendACKPacket(&sndACKPkt);
		m_AutoTProtocol.MakeAndSendACKPacket(&sndACKPkt);
		m_AutoTProtocol.MakeAndSendACKPacket(&sndACKPkt);
		m_AutoTProtocol.MakeAndSendACKPacket(&sndACKPkt);
		m_AutoTProtocol.MakeAndSendACKPacket(&sndACKPkt);
		m_AutoTProtocol.MakeAndSendACKPacket(&sndACKPkt);
		m_AutoTProtocol.MakeAndSendACKPacket(&sndACKPkt);
		m_AutoTProtocol.MakeAndSendACKPacket(&sndACKPkt);
		m_AutoTProtocol.MakeAndSendACKPacket(&sndACKPkt);
		m_AutoTProtocol.MakeAndSendACKPacket(&sndACKPkt);
		m_AutoTProtocol.MakeAndSendACKPacket(&sndACKPkt);
		m_AutoTProtocol.MakeAndSendACKPacket(&sndACKPkt);
		nRet = m_AutoTProtocol.ReceivePacket(&rcvPkt);
		if(nRet < 0)
		{
			LOG_ERROR("Failed to receive ACK package after sending ACK Packet\n");
			nRet = RETURN_FAIL;
			LOG_ERROR("Error: Receive Packet, opcode = x%04x, seq_no = %d, ack_seq_no =%d\n", 
					rcvPkt.opcode, rcvPkt.sequence_no, rcvPkt.ack_sequence_number);
			goto finish;
		}
		LOG_TRACE("Testing: Receive ACK Packet, opcode = x%04x, seq_no = %d, ack_seq_no =%d\n", 
					rcvPkt.opcode, rcvPkt.sequence_no, rcvPkt.ack_sequence_number);
		*/		
		
		// Send NACK package
		/*
		m_AutoTProtocol.MakeAndSendNACKPacket(&sndNACKPkt, 2001);
		m_AutoTProtocol.MakeAndSendEchoPacket(&sndECPkt);
		m_AutoTProtocol.MakeAndSendEchoPacket(&sndECPkt);
		m_AutoTProtocol.MakeAndSendEchoPacket(&sndECPkt);
		m_AutoTProtocol.MakeAndSendEchoPacket(&sndECPkt);
		nRet = m_AutoTProtocol.ReceivePacket(&rcvPkt);
		if(nRet < 0)
		{
			LOG_ERROR("Failed to receive NACK package after sending NACK Packet\n");
			nRet = RETURN_FAIL;
			goto finish;
		}
		LOG_TRACE("Testing: Receive NACK Packet, opcode = x%04x, seq_no = %d, ack_seq_no =%d\n", 
					rcvPkt.opcode, rcvPkt.sequence_no, rcvPkt.ack_sequence_number);
*/
	}	
finish:
	LOG_TRACE("Leaving Test\n");
}

BOOL CBrokerCommunicationDlg::DestroyWindow() 
{
	// TODO: Add your specialized code here and/or call the base class
	m_AutoTProtocol.m_Queue.ExitQueue();

	if(nStopFlag == NONE_STOP)
	{
		if((m_AutoTProtocol.m_nProgState == PROG_DATA_TRANFER) && (m_AutoTProtocol.Stop() == RETURN_SUCCESS))
		{
			GetMenu()->EnableMenuItem(ID_CONNECTIONSETUP_DISCONNECT, MF_GRAYED);
			GetMenu()->EnableMenuItem(ID_CONNECTIONSETUP_CONNECT, MF_ENABLED);
			DrawMenuBar();		
		}
	}

	return CDialog::DestroyWindow();
}

void CBrokerCommunicationDlg::OnConnectionsetupRetransmission() 
{
	CString stTmp = "[No need Restranmission]";
	char szTmp[500];
	int nIndex = g_stRestransmissionInfor.index;

	if(g_stRestransmissionInfor.count > 0)
		stTmp = "";
	for(unsigned int i = 0; i < g_stRestransmissionInfor.count; i++)
	{
		sprintf(szTmp, "[%d, %d] ", g_stRestransmissionInfor.arrRestransmission[nIndex+i].from_sequence_no,
			g_stRestransmissionInfor.arrRestransmission[nIndex+i].to_sequence_no);
		stTmp = stTmp + szTmp;
	}
	// TODO: Add your command handler code here
	//if(m_AutoTProtocol.m_nProgState == PROG_DATA_TRANFER)
	{
		CRestransmissionBroadcastPacket dlg;
		dlg.m_stRetransmissionInfor = stTmp;
		dlg.m_stBroadcastSeqNo.Format("Broadcast Seq No: %d", g_stConnectionData.nBroadcastSeq);

		if(dlg.DoModal()!=IDOK)
			return;
	}
}

void CBrokerCommunicationDlg::OnTimer(UINT nIDEvent) 
{
	// TODO: Add your message handler code here and/or call default
	if(g_stConnectionData.nAutoConnect == FALSE)
		goto finish;

	if(m_AutoTProtocol.m_nProgState == PROG_PROCESSING)
		goto finish;

	if(m_AutoTProtocol.m_nProgState == PROG_STOP)
	{
		if(m_AutoTProtocol.Start() == RETURN_SUCCESS)
		{
			GetMenu()->EnableMenuItem(ID_CONNECTIONSETUP_CONNECT, MF_GRAYED);
			GetMenu()->EnableMenuItem(ID_CONNECTIONSETUP_DISCONNECT, MF_ENABLED);
			DrawMenuBar();
		}
	}
	else
	{
		if(m_AutoTProtocol.m_Socket.m_nConnected == 0)
		{
			GetMenu()->EnableMenuItem(ID_CONNECTIONSETUP_DISCONNECT, MF_GRAYED);
			GetMenu()->EnableMenuItem(ID_CONNECTIONSETUP_CONNECT, MF_ENABLED);
			DrawMenuBar();		
		}
	}

finish:
	CDialog::OnTimer(nIDEvent);
}

void CBrokerCommunicationDlg::OnDestroy() 
{
	if (m_AutoTProtocol.m_nProgState == PROG_DATA_TRANFER){
		m_AutoTProtocol.m_nStopPoolingQueue = 1;
		m_AutoTProtocol.m_nStopAutoT = 1;
		while(1){
			if((m_AutoTProtocol.m_nStopPoolingQueue == 0) &&(m_AutoTProtocol.m_nStopAutoT == 0)){
				break;
				Sleep(100);
			}
		}
	}
	CDialog::OnDestroy();
		
}

