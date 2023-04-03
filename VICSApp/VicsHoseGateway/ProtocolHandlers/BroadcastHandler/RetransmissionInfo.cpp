// RetransmissionInfo.cpp: implementation of the CRetransmissionInfo class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "BroadcastHandler.h"
#include "RetransmissionInfo.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CRetransmissionInfo::CRetransmissionInfo()
{
	
}

CRetransmissionInfo::~CRetransmissionInfo()
{

}

int CRetransmissionInfo::reset()
{
	int nRet = RETURN_SUCCESS;
	try{
		m_stRetransmissionInfo.count = 0;

	}catch(exception exp){
		LOG_ERROR("Cannot reset Re-Transmission infomation\n");
		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
	return nRet;

}

int CRetransmissionInfo::ReadReTransmissionFile()
{
	int nRet = RETURN_SUCCESS;
				
	try{
	
		FILE *fout = fopen(g_szReTransmissionFileName, "rb");

		if (fout){
			LOG_INFO("Load ReTransmission Infomation From File(%s) \n", g_szReTransmissionFileName);
			fread((char*)&m_stRetransmissionInfo, sizeof(m_stRetransmissionInfo), 1, fout);
			fclose(fout);
			LOG_INFO("Retransmission data after reading from file: " + toString() + "\n");
		}else{
			LOG_INFO("File(%s) no exist. Reset ReTransmission Information\n", g_szReTransmissionFileName);		
			reset();
			memset(&m_stRetransmissionInfo, 0, sizeof(m_stRetransmissionInfo));
			nRet = RETURN_FAIL;
			goto finish;
		}
		
	}catch(exception exp){
		LOG_ERROR("Cannot read Re-transmission file\n");
	}
finish:	
	return nRet;
}

int CRetransmissionInfo::WriteRetransmissionFile()
{
	int nRet = RETURN_SUCCESS;
	
	FILE *fout = fopen(g_szReTransmissionFileName, "wb");

	if (fout){
		fwrite((char*)&m_stRetransmissionInfo , sizeof(m_stRetransmissionInfo), 1, fout);
		fclose(fout);
		LOG_INFO("Retransmission data after writing to file: " + toString() + "\n");
	}
	else{
		LOG_FATAL("Failed to write Re Transmission Infor %s", strerror(errno));
		nRet = RETURN_FAIL;
		goto finish;
	}

finish:
	
	return nRet;
}

int CRetransmissionInfo::CalculateRetransmisionInfo(unsigned int nUDPSequence, unsigned int nHOSEUDPSequence)
{
	int nRet = RETURN_SUCCESS;
	try{		
		Insert2RetransmissionInfo(nUDPSequence, nHOSEUDPSequence);				
	}catch (exception exp) {
		LOG_ERROR("Cannot calculate retransmission information\n");
		nRet= RETURN_FAIL;
		goto finish;
	}
finish:
	return nRet;
}

int CRetransmissionInfo::Insert2RetransmissionInfo(unsigned int nfromSequence, unsigned int nToSequence)
{
	int nRet = RETURN_SUCCESS;
	m_stRetransmissionInfo.arrRetransmissionData[m_stRetransmissionInfo.count].from_sequence_no = nfromSequence;
	if (nfromSequence + MAX_SEQUENCE_PER_RETRANSMISSION_REQUEST - 1 >= nToSequence){
		m_stRetransmissionInfo.arrRetransmissionData[m_stRetransmissionInfo.count].to_sequence_no = nToSequence;
		m_stRetransmissionInfo.count +=1;
		nRet = RETURN_SUCCESS;
		goto finish;
	}else{
		m_stRetransmissionInfo.arrRetransmissionData[m_stRetransmissionInfo.count].to_sequence_no = nfromSequence + MAX_SEQUENCE_PER_RETRANSMISSION_REQUEST - 1;
		m_stRetransmissionInfo.count +=1;
		Insert2RetransmissionInfo(m_stRetransmissionInfo.arrRetransmissionData[m_stRetransmissionInfo.count].from_sequence_no = nfromSequence + MAX_SEQUENCE_PER_RETRANSMISSION_REQUEST, nToSequence);
		nRet = RETURN_SUCCESS;
		goto finish;
	}	

finish:	
	return nRet;
}

CString CRetransmissionInfo::toString()
{
	CString output = "";
	CString strSequence;	
	for(int i = 0; i < m_stRetransmissionInfo.count; i++){
		output = output + "[";
		strSequence.Format("%d", m_stRetransmissionInfo.arrRetransmissionData[i].from_sequence_no);
		output = output + strSequence + "-->";
		 strSequence.Format("%d", m_stRetransmissionInfo.arrRetransmissionData[i].to_sequence_no);
		output = output + strSequence;
		output = output + "]";
	}
	return output;
}

int CRetransmissionInfo::DecreaseRetranmissionData()
{
	int nRet = RETURN_SUCCESS;
	if (g_stRetransmissionInfo.m_stRetransmissionInfo.count > 1){
		
		for(int i = 0; i < m_stRetransmissionInfo.count - 1; i ++){
			m_stRetransmissionInfo.arrRetransmissionData[i].from_sequence_no = m_stRetransmissionInfo.arrRetransmissionData[i+1].from_sequence_no;
			m_stRetransmissionInfo.arrRetransmissionData[i].to_sequence_no = m_stRetransmissionInfo.arrRetransmissionData[i+1].to_sequence_no;
		}	
		g_stRetransmissionInfo.m_stRetransmissionInfo.count -= 1;
	}else{
		g_stRetransmissionInfo.reset();
	}
	return nRet;
}
