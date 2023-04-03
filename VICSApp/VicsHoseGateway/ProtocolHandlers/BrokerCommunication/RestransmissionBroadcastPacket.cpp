// RestransmissionBroadcastPacket.cpp : implementation file
//

#include "stdafx.h"
#include "BrokerCommunication.h"
#include "RestransmissionBroadcastPacket.h"

#include "BrokerCommunicationDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CRestransmissionBroadcastPacket dialog

CRestransmissionBroadcastPacket::CRestransmissionBroadcastPacket(CWnd* pParent /*=NULL*/)
	: CDialog(CRestransmissionBroadcastPacket::IDD, pParent)
{
	//{{AFX_DATA_INIT(CRestransmissionBroadcastPacket)
	m_nFromSeq = 0;
	m_nToSeq = 0;
	m_stRetransmissionInfor = _T("");
	m_stBroadcastSeqNo = _T("");
	//}}AFX_DATA_INIT
}


void CRestransmissionBroadcastPacket::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CRestransmissionBroadcastPacket)
	DDX_Text(pDX, IDC_EDIT_SEQ_TO, m_nToSeq);
	DDV_MinMaxUInt(pDX, m_nFromSeq, 1, 4294967295);
	DDX_Text(pDX, IDC_EDITSEQ_FROM, m_nFromSeq);
	DDV_MinMaxUInt(pDX, m_nToSeq, 1, 4294967295);
	DDX_Text(pDX, IDC_STATIC_RETRANSMISSION_INFOR, m_stRetransmissionInfor);
	DDX_Text(pDX, IDC_STATIC_BROADCAST_SEQ_NO, m_stBroadcastSeqNo);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CRestransmissionBroadcastPacket, CDialog)
	//{{AFX_MSG_MAP(CRestransmissionBroadcastPacket)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CRestransmissionBroadcastPacket message handlers

void CRestransmissionBroadcastPacket::OnOK() 
{
	// TODO: Add extra validation here
	UpdateData(TRUE);

	CBrokerCommunicationDlg *m_pDlg = (CBrokerCommunicationDlg*)AfxGetMainWnd();
	m_pDlg->m_AutoTProtocol.MakeAndSendRequestRetransmissionBroadcastPacket(m_nFromSeq, m_nToSeq);
	CDialog::OnOK();
}

BOOL CRestransmissionBroadcastPacket::OnInitDialog() 
{
	CDialog::OnInitDialog();

	m_nFromSeq = 1;
	m_nToSeq = 1;

	CBrokerCommunicationDlg *m_pDlg = (CBrokerCommunicationDlg*)AfxGetMainWnd();
	if(m_pDlg->m_AutoTProtocol.m_nProgState != PROG_DATA_TRANFER)
	{
		this->GetDlgItem(IDOK)->EnableWindow(FALSE);
	}

	UpdateData(FALSE);
	
	// TODO: Add extra initialization here
	
	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}
