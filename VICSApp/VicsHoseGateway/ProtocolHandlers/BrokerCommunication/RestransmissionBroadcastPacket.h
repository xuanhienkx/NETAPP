#if !defined(AFX_RESTRANSMISSIONBROADCASTPACKET_H__5590192C_5C87_4163_9448_D7EE01632027__INCLUDED_)
#define AFX_RESTRANSMISSIONBROADCASTPACKET_H__5590192C_5C87_4163_9448_D7EE01632027__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// RestransmissionBroadcastPacket.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CRestransmissionBroadcastPacket dialog

class CRestransmissionBroadcastPacket : public CDialog
{
// Construction
public:
	CRestransmissionBroadcastPacket(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CRestransmissionBroadcastPacket)
	enum { IDD = IDD_DIALOG_RETRANSMISSION_BROADCAST };
	UINT	m_nFromSeq;
	UINT	m_nToSeq;
	CString	m_stRetransmissionInfor;
	CString	m_stBroadcastSeqNo;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CRestransmissionBroadcastPacket)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CRestransmissionBroadcastPacket)
	virtual void OnOK();
	virtual BOOL OnInitDialog();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_RESTRANSMISSIONBROADCASTPACKET_H__5590192C_5C87_4163_9448_D7EE01632027__INCLUDED_)
