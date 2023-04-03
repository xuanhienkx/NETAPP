// Cfg.h: interface for the CCfg class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_CFG_H__893FD65E_AD42_47BE_8361_A6D9E2A0547A__INCLUDED_)
#define AFX_CFG_H__893FD65E_AD42_47BE_8361_A6D9E2A0547A__INCLUDED_

#include "TxtVar.h"	// Added by ClassView
#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class CCfg : public CObject  
{
public:		
	int LoadParameters(char* parameterFileName);
	CCfg();
	virtual ~CCfg();

public:
	int SetUDPSequence();
	int SaveParameters();
	char m_inboxQueue [100];
	int m_udpSequence;
	int m_udpPort;
	unsigned char m_autoTIPAddress[4];
	int m_autoTTCPPort;
	CTxtVar m_txtVar;
};

#endif // !defined(AFX_CFG_H__893FD65E_AD42_47BE_8361_A6D9E2A0547A__INCLUDED_)
