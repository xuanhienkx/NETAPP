#if !defined(AFX_CONNECTIONSETTING_H__06AB2EFD_861E_46B8_8C5F_7C967B568FE8__INCLUDED_)
#define AFX_CONNECTIONSETTING_H__06AB2EFD_861E_46B8_8C5F_7C967B568FE8__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// ConnectionSetting.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CConnectionSetting dialog

class CConnectionSetting : public CDialog
{
// Construction
public:
	CConnectionSetting(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CConnectionSetting)
	enum { IDD = IDD_DIALOG_CONNECT };
	CComboBox	m_cbConnectionMode;
	CIPAddressCtrl	m_HoseIPAddress;
	int		m_nPort;
	int		m_nUDPPort;
	int		m_nRetryTimes;
	int		m_nTimeout;
	int		m_nMaxPacketSize;
	int		m_nMaxPacketTime;
	int		m_nConnectionMode;
	CString	m_strPassword;
	CString	m_strMarketID;
	CString	m_strFirmID;
	int		m_nLinkID;
	UINT	m_nAckSeqNo;
	UINT	m_nSeqNo;
	CString	m_stQueueAddress;
	CString	m_stRecevingQueueAddress;
	BOOL	m_nAutoConnect;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CConnectionSetting)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CConnectionSetting)
	virtual BOOL OnInitDialog();
	virtual void OnOK();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()

public:
	unsigned char m_Addr[4];
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_CONNECTIONSETTING_H__06AB2EFD_861E_46B8_8C5F_7C967B568FE8__INCLUDED_)
