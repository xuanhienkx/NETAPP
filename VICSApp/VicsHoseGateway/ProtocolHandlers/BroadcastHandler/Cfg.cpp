// Cfg.cpp: implementation of the CCfg class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "BroadcastHandler.h"
#include "Cfg.h"
#include "Common.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CCfg::CCfg()
{

}

CCfg::~CCfg()
{

}

int CCfg::LoadParameters(char* parameterFileName)
{
	int iRet=m_txtVar.LoadStringList(parameterFileName);

	if (iRet==TXTVAR_NOERR){
		
		// Read inbox queue address		
		if (m_txtVar.FindSectionItem("Settings","InboxQueue") == 0){			
			sprintf(m_inboxQueue, m_txtVar.GetArg(1));
			LOG_INFO("Inbox queue address is %s\n", m_txtVar.GetArg(1));
		}else{
			LOG_ERROR("Inbox queue address not found\n");
			iRet = RETURN_FAIL;
			goto finish;
		}
		// Read UDPSequence		
		if(m_txtVar.FindSectionItem("Settings","UDPSequence") == 0){
			m_udpSequence = atoi(m_txtVar.GetArg(1));
			LOG_INFO("UDP Sequence is %s\n", m_txtVar.GetArg(1));
		}else{
			LOG_ERROR("UDP Sequence not found\n");
			iRet = RETURN_FAIL;
			goto finish;
		}
		// Read UDP Port		
		if(m_txtVar.FindSectionItem("Settings","UDPPort") == 0){
			m_udpPort = atoi(m_txtVar.GetArg(1));
			LOG_INFO("UDP Port is %s\n", m_txtVar.GetArg(1));
		}else{
			LOG_ERROR("UDP Port not found\n");
			iRet = RETURN_FAIL;
			goto finish;
		}
		//Read AutoT IP Address		
		if(m_txtVar.FindSectionItem("Settings","AutoTIPAddress") == 0){
			m_autoTIPAddress[0] = atoi(m_txtVar.GetArg(1));
			m_autoTIPAddress[1] = atoi(m_txtVar.GetArg(2));
			m_autoTIPAddress[2] = atoi(m_txtVar.GetArg(3));
			m_autoTIPAddress[3] = atoi(m_txtVar.GetArg(4));
			LOG_INFO("AutoT IP Address is %s.%s.%s.%s\n", m_txtVar.GetArg(1), m_txtVar.GetArg(2), m_txtVar.GetArg(3), m_txtVar.GetArg(4));
		}else{
			LOG_ERROR("AutoT IP Address not found\n");
			iRet = RETURN_FAIL;
			goto finish;
		}
		//Read AutoT TCP Port		
		if(m_txtVar.FindSectionItem("Settings","AutoTTCPPort") == 0){
			m_autoTTCPPort = atoi(m_txtVar.GetArg(1));
			LOG_INFO("AutoT TCP Port is %s\n", m_txtVar.GetArg(1));
		}else{
			LOG_ERROR("AutoT TCP Port not found\n");
			iRet = RETURN_FAIL;
			goto finish;
		}
		
	}
finish:
	return iRet;
}

int CCfg::SaveParameters()
{
	SetUDPSequence();
	m_txtVar.Flush();
	return 0;
}

int CCfg::SetUDPSequence()
{	
	int nRet = RETURN_SUCCESS;
	if(m_txtVar.SetUDPSequence(m_udpSequence) == RETURN_FAIL) {
		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
	return nRet;
}
