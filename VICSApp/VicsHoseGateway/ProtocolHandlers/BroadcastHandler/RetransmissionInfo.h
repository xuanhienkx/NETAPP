// RetransmissionInfo.h: interface for the CRetransmissionInfo class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_RETRANSMISSIONINFO_H__78F07AC6_D23C_4A25_B9A9_E9879A26E4FC__INCLUDED_)
#define AFX_RETRANSMISSIONINFO_H__78F07AC6_D23C_4A25_B9A9_E9879A26E4FC__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


#include "Common.h"
class CRetransmissionInfo  
{
public:	
	int DecreaseRetranmissionData();
	CString toString();
	int Insert2RetransmissionInfo(unsigned int nfromSequence, unsigned int nToSequence);
	int CalculateRetransmisionInfo(unsigned int nUDPSequence, unsigned int nHOSEUDPSequence);
	stRetransmissionInfo m_stRetransmissionInfo;
	int WriteRetransmissionFile();
	int ReadReTransmissionFile();
	int reset();	
	CRetransmissionInfo();
	virtual ~CRetransmissionInfo();
};

#endif // !defined(AFX_RETRANSMISSIONINFO_H__78F07AC6_D23C_4A25_B9A9_E9879A26E4FC__INCLUDED_)
