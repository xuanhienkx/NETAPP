// BrokerCommunicationDlg.h : header file
//

#if !defined(AFX_BROKERCOMMUNICATIONDLG_H__7C8CA72C_9D04_4565_9535_5A6C8B05382A__INCLUDED_)
#define AFX_BROKERCOMMUNICATIONDLG_H__7C8CA72C_9D04_4565_9535_5A6C8B05382A__INCLUDED_

#include "AutoTProtocol.h"

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CBrokerCommunicationDlg dialog

class CBrokerCommunicationDlg : public CDialog
{
// Construction
public:
	CBrokerCommunicationDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CBrokerCommunicationDlg)
	enum { IDD = IDD_BROKERCOMMUNICATION_DIALOG };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CBrokerCommunicationDlg)
	public:
	virtual BOOL DestroyWindow();
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	HBITMAP m_hBmp;

	// Generated message map functions
	//{{AFX_MSG(CBrokerCommunicationDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnConnectionsetupSetting();
	afx_msg void OnConnectionsetupConnect();
	afx_msg void OnHelpAbout();
	afx_msg void OnStartNewDay();
	afx_msg void OnConnectionsetupDisconnect();
	afx_msg void OnConnectionsetupTesting();
	afx_msg void OnConnectionsetupRetransmission();
	afx_msg void OnTimer(UINT nIDEvent);
	afx_msg void OnDestroy();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
public:
	CAutoTProtocol m_AutoTProtocol;
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_BROKERCOMMUNICATIONDLG_H__7C8CA72C_9D04_4565_9535_5A6C8B05382A__INCLUDED_)
