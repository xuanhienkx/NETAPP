// ConnectionSetting.cpp : implementation file
//

#include "stdafx.h"
#include "atlbase.h"

#include "BrokerCommunication.h"
#include "ConnectionSetting.h"
#include "BrokerCommunicationDlg.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CConnectionSetting dialog

CConnectionSetting::CConnectionSetting(CWnd* pParent /*=NULL*/)
	: CDialog(CConnectionSetting::IDD, pParent)
{
	//{{AFX_DATA_INIT(CConnectionSetting)
	m_nPort = 0;
	m_nUDPPort = 0;
	m_nRetryTimes = 0;
	m_nTimeout = 0;
	m_nMaxPacketSize = 0;
	m_nMaxPacketTime = 0;
	m_nConnectionMode = -1;
	m_strPassword = _T("");
	m_strMarketID = _T("");
	m_strFirmID = _T("");
	m_nLinkID = 0;
	m_nAckSeqNo = 0;
	m_nSeqNo = 0;
	m_stQueueAddress = _T("");
	m_stRecevingQueueAddress = _T("");
	m_nAutoConnect = FALSE;
	//}}AFX_DATA_INIT
}


void CConnectionSetting::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CConnectionSetting)
	DDX_Control(pDX, IDC_COMBO_CONNECTION_MODE, m_cbConnectionMode);
	DDX_Control(pDX, IDC_HOSE_IPADDRESS, m_HoseIPAddress);
	DDX_Text(pDX, IDC_HOSE_PORT, m_nPort);
	DDX_Text(pDX, IDC_EDIT_UDP_PORT, m_nUDPPort);
	DDV_MinMaxInt(pDX, m_nUDPPort, 0, 65536);
	DDX_Text(pDX, IDC_EDIT_RETRY_TIMES, m_nRetryTimes);
	DDV_MinMaxInt(pDX, m_nRetryTimes, 0, 100);
	DDX_Text(pDX, IDC_EDIT_TIMEOUT, m_nTimeout);
	DDV_MinMaxInt(pDX, m_nTimeout, 0, 1000);
	DDX_Text(pDX, IDC_EDIT_MAX_PACKET_SIZE, m_nMaxPacketSize);
	DDV_MinMaxInt(pDX, m_nMaxPacketSize, 0, 2048);
	DDX_Text(pDX, IDC_EDIT_MAX_PACKET_TIME, m_nMaxPacketTime);
	DDV_MinMaxInt(pDX, m_nMaxPacketTime, 0, 1000);
	DDX_CBIndex(pDX, IDC_COMBO_CONNECTION_MODE, m_nConnectionMode);
	DDX_Text(pDX, IDC_EDIT_PASSWORD, m_strPassword);
	DDV_MaxChars(pDX, m_strPassword, 50);
	DDX_Text(pDX, IDC_EDIT_MARKET_ID, m_strMarketID);
	DDV_MaxChars(pDX, m_strMarketID, 1);
	DDX_Text(pDX, IDC_EDIT_FIRM_ID, m_strFirmID);
	DDV_MaxChars(pDX, m_strFirmID, 3);
	DDX_Text(pDX, IDC_EDIT_LINK_ID, m_nLinkID);
	DDV_MinMaxInt(pDX, m_nLinkID, 0, 65535);
	DDX_Text(pDX, IDC_EDIT_ACK_SEQUENCE_NO, m_nAckSeqNo);
	DDV_MinMaxUInt(pDX, m_nAckSeqNo, 1, 4294967295);
	DDX_Text(pDX, IDC_EDIT_SEQUENCE_NO, m_nSeqNo);
	DDV_MinMaxUInt(pDX, m_nSeqNo, 1, 4294967295);
	DDX_Text(pDX, IDC_EDIT_QUEUE_ADDRESS, m_stQueueAddress);
	DDX_Text(pDX, IDC_EDIT_QUEUE_RECEIVING, m_stRecevingQueueAddress);
	DDX_Check(pDX, IDC_CHECK_AUTOCONNECT, m_nAutoConnect);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CConnectionSetting, CDialog)
	//{{AFX_MSG_MAP(CConnectionSetting)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CConnectionSetting message handlers

BOOL CConnectionSetting::OnInitDialog() 
{
	CDialog::OnInitDialog();

	unsigned char* pAddr = &g_stConnectionData.HOSEIPAddress[0];
	
	// TODO: Add extra initialization here

	m_HoseIPAddress.SetAddress(pAddr[0], pAddr[1], pAddr[2], pAddr[3]);

	m_nPort = g_stConnectionData.nTCPPort;
	m_nUDPPort = g_stConnectionData.nUDPPort;

	m_nRetryTimes = g_stConnectionData.nRetryTime;
	m_nTimeout = g_stConnectionData.nTimeout;

	m_nMaxPacketSize = g_stConnectionData.nMaxPacketSize;
	m_nMaxPacketTime = g_stConnectionData.nMaxPacketTime;

	m_nLinkID = g_stConnectionData.nLinkID;

	m_nConnectionMode = g_stConnectionData.nConnectionMode;
	m_cbConnectionMode.SetCurSel(m_nConnectionMode - APP_MODE_A);

	m_strPassword.Format("%s", g_stConnectionData.szPassword);
	
	m_strMarketID.Format("%c", g_stConnectionData.szMarketID);
	m_strFirmID.Format("%c%c%c", g_stConnectionData.szFirmID[0], 
	g_stConnectionData.szFirmID[1], g_stConnectionData.szFirmID[2]);

	m_nSeqNo = g_stTransmissionData.nAutoTSequenceNo;
	m_nAckSeqNo = g_stTransmissionData.nAutoTAckSequenceNo;

	m_stQueueAddress.Format("%s", g_stConnectionData.szSendingQueueAddress);
	m_stRecevingQueueAddress.Format("%s", g_stConnectionData.szReceivingQueueAddress);

	m_nAutoConnect = g_stConnectionData.nAutoConnect;

	UpdateData(FALSE);
	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}

void CConnectionSetting::OnOK() 
{
	// TODO: Add extra validation here
	UpdateData(TRUE);

	unsigned char* pAddr = &g_stConnectionData.HOSEIPAddress[0];
	
	// TODO: Add extra initialization here
	m_HoseIPAddress.GetAddress(pAddr[0], pAddr[1], pAddr[2], pAddr[3]);

	g_stConnectionData.nTCPPort = m_nPort;
	g_stConnectionData.nUDPPort = m_nUDPPort;

	g_stConnectionData.nRetryTime = m_nRetryTimes;
	g_stConnectionData.nTimeout = m_nTimeout;

	g_stConnectionData.nMaxPacketSize = m_nMaxPacketSize;
	g_stConnectionData.nMaxPacketTime = m_nMaxPacketTime;

	g_stConnectionData.nLinkID = m_nLinkID;

	g_stConnectionData.nConnectionMode = m_nConnectionMode + APP_MODE_A;

	g_stTransmissionData.nAutoTSequenceNo = m_nSeqNo;
	g_stTransmissionData.nAutoTAckSequenceNo = m_nAckSeqNo;

	sprintf(g_stConnectionData.szPassword, "%s", m_strPassword);
	//m_strPassword.Format("%s", g_stConnectionData.szPassword);
	
	if(m_strMarketID.GetLength() == 1)
		g_stConnectionData.szMarketID = m_strMarketID.GetAt(0);

	if(m_strFirmID.GetLength() == 3)
	{
		g_stConnectionData.szFirmID[0] = m_strFirmID.GetAt(0);
		g_stConnectionData.szFirmID[1] = m_strFirmID.GetAt(1);
		g_stConnectionData.szFirmID[2] = m_strFirmID.GetAt(2);
	}

	sprintf(g_stConnectionData.szSendingQueueAddress, "%s", m_stQueueAddress);
	sprintf(g_stConnectionData.szReceivingQueueAddress, "%s", m_stRecevingQueueAddress);

	g_stConnectionData.nAutoConnect = m_nAutoConnect;

	// Store Parameters
	WriteSettingParameters();
	CDialog::OnOK();
}
