// TxtVar.h: interface for the CTxtVar class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_TXTVAR_H__67C4BB00_F5F0_11D5_B4DC_BB356C76DA6A__INCLUDED_)
#define AFX_TXTVAR_H__67C4BB00_F5F0_11D5_B4DC_BB356C76DA6A__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "afxtempl.h"

// Error codes returned by TxtVar functions.

#define TXTVAR_NOERR			0
#define	TXTVAR_NOFILE			-1
#define TXTVAR_NOTFOUND			-2
#define	TXTVAR_NOVALIDSECTION	-3
#define	TXTVAR_INDEXOUTOFRANGE	-4
#define	TXTVAR_SYNTAX			-5
#define	TXTVAR_OUTOFRANGE		-6
#define	TXTVAR_NOVALIDITEM		-7
#define	TXTVAR_LASTERR_			-8

#define TXTVAR_MAXARGS	20		// Maximum number of arguments for each item.

class CTxtVar : public CObject  
{
public:	
	int SetUDPSequence(int UDPSequence);
	int SetArg(CString section, CString var, CString value);
	CString GetFileName(){return m_strFileName;}
	int FindSectionItem(const CString strSection,const CString strItem);
	LPCTSTR ErrorString(int Error);
	int ArgToInt(int Index, int &Result,int Min,int Max);
	int ArgToInt(int Index,int &Result);
	int RemoveSection(const CString strSection);
	int EmptySection(const CString strSection);
	int RemoveItem(BOOL bAllowHeaderDelete=FALSE);
	int GetNextItem();
	CString GetArg(int iArg);
	static int ConvertToArgs(const CString strLine,CString strArgs[],int &iNumArgs);
	int SetSectionItem(const CString strSection,const CString strItem,BOOL bAdd=FALSE);
	int SetItem(const CString strItem,BOOL bAdd=FALSE);
	int FindItem(const CString strItem);
	void Release();
	BOOL IsSectionHeader(CString strLine,CString *strSectionName=NULL);
	int FindSectionHeader(const CString strSection);
	virtual int Flush();
	virtual	int LoadStringList(const CString strFileName);
	CTxtVar();
	virtual ~CTxtVar();

protected:
	BOOL m_bChanged;
	int m_iNumArgs;							// Number of arguments for current variable
	POSITION m_Pos;							// Current POSITION in string list of variables
	POSITION m_PosSectionStart;				// Current POSITION for start of the current section 
											// in string list of variables.
	CString	m_strArgs[TXTVAR_MAXARGS];		// Array of strings with arguments for the current variable
											// m_strArgs[0] is the name of the variable.
	CString	m_strCurrentSection;			// Current section
	CString	m_strFileName;					// Current filename with textvariables.
	CStringList m_strList;					// CStringList with all lines from the file with textvariables.
	CString	m_strLine;						// Current line



};

#endif // !defined(AFX_TXTVAR_H__67C4BB00_F5F0_11D5_B4DC_BB356C76DA6A__INCLUDED_)
