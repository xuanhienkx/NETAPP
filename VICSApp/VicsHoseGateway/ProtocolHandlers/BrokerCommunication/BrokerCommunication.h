// BrokerCommunication.h : main header file for the BROKERCOMMUNICATION application
//

#if !defined(AFX_BROKERCOMMUNICATION_H__3F780E25_A82B_4B0A_AF8C_EBCE80B3F720__INCLUDED_)
#define AFX_BROKERCOMMUNICATION_H__3F780E25_A82B_4B0A_AF8C_EBCE80B3F720__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CBrokerCommunicationApp:
// See BrokerCommunication.cpp for the implementation of this class
//

class CBrokerCommunicationApp : public CWinApp
{
public:
	CBrokerCommunicationApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CBrokerCommunicationApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CBrokerCommunicationApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_BROKERCOMMUNICATION_H__3F780E25_A82B_4B0A_AF8C_EBCE80B3F720__INCLUDED_)
