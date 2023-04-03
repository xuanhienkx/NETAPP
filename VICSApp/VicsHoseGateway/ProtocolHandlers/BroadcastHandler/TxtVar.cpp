// TxtVar.cpp: implementation of the CTxtVar class.
//
//////////////////////////////////////////////////////////////////////

/*****************************************************************************
	CTxtVar
	
	Author:		Ruben Jönsson, ruben@pp.sbbs.se
	Version:	1.00
	Date:		2002-01-10
	
	Revision history:
	---------------------------------------------------------------------
	1.00	2002-01-10	Released

*******************************************************************************/

////// Text variables /////////////////////////////////////////////////////////////////////////////////////////////
//
//	CTxtVar handles reading and writing items of variables within sections in a textfile and is used when 
//	nonvolatile lists of information - variables, settings or strings, has to be saved for retrieval at
//	a later stage, even after the app is closed.
//
//	Format of textfile:
//
//	[Section_header1]
//	Item1 var1,var2...
//	Item2 var1,var2...
//
//	The items are retrieved using the section name and the item name using the functions FindSectionHeader(),
//	FindItem() and FindSectionItem().
//	Sometimes there could be items within a section that has the same name. In this case 
//	items has to be read from the section one by one with the function GetNextItem() after
//	a call to FindSectionHeader().
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



#include "stdafx.h"
#include "TxtVar.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

// Text strings returned by ErrorString()

static LPCTSTR CfgErrorString[]={
	"No error",
	"Can't open file",
	"Not found",
	"No valid section",
	"Index is out of range",
	"Syntax error",
	"Value is out of range",
	"No valid Item"
};

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CTxtVar::CTxtVar()
{
	m_PosSectionStart=NULL;
	m_Pos=NULL;
	m_bChanged=FALSE;
}

CTxtVar::~CTxtVar()
{
	if (m_bChanged)
		Flush();
	m_strFileName.Empty();
	Release();
}

int CTxtVar::LoadStringList(const CString strFileName)
// Read all lines of a textvariable file into m_stringList.
// Note that the text file is only opened during LoadStringList() and Flush() and
// can be shared by others. It should only be written by one instance
// though.
{
	Release();		// Reset and release string list.

	char path_buffer[_MAX_PATH];
	if (_fullpath(path_buffer,strFileName,_MAX_PATH)==NULL)
		return TXTVAR_NOFILE;
	
	m_strFileName=path_buffer;	// Save the full pathname for the text file
								// incase the current path is changed.

	CString instring;
	int iNumLines=0;

	FILE *File;
	if ((File=fopen(m_strFileName,"r"))==NULL)
		return TXTVAR_NOFILE;
		
	while  (iNumLines<5000 && fgets(instring.GetBuffer(512),512,File)!=NULL){
		iNumLines++;
		instring.ReleaseBuffer();
		instring.TrimRight();
		m_strList.AddTail(instring);
	}
	fclose(File);
	return TXTVAR_NOERR;
}

int CTxtVar::Flush()
// Write back all settings to file. Used after a setting is changed.
{
	FILE *File;
	POSITION pos;
	CString strLine;

	if (!m_strFileName.IsEmpty()){
		if ((File=fopen(m_strFileName,"w"))==NULL)
			return TXTVAR_NOFILE;
		
		pos=m_strList.GetHeadPosition();
		while(pos!=NULL){
			strLine=m_strList.GetNext(pos);
			strLine+="\n";
			fputs(strLine,File);
		}
		fclose(File);
	}
	m_bChanged=FALSE;
	return TXTVAR_NOERR;
}

int CTxtVar::FindSectionHeader(const CString strSection)
// Find a section within the string list. Must be used befora a call to FindItem().
{
	POSITION pos,this_pos;
	CString strFoundSection;

	if (strSection==m_strCurrentSection){
		m_Pos=m_PosSectionStart;
		m_strLine=m_strList.GetNext(m_Pos);
		return TXTVAR_NOERR;
	}

	pos=m_strList.GetHeadPosition();

	while(pos!=NULL){
		this_pos=pos;
		m_strLine=m_strList.GetNext(pos);

		if (IsSectionHeader(m_strLine,&strFoundSection) && strFoundSection==strSection){
			m_PosSectionStart=this_pos;
			m_Pos=pos;
			m_strCurrentSection=strSection;
			return(TXTVAR_NOERR);
		}
	}
	return(TXTVAR_NOTFOUND);
}

BOOL CTxtVar::IsSectionHeader(CString strLine, CString *strSectionName)
// Return TRUE if strLine is a section header '[section]'.
// If strSectionName is not NULL the section header without brackets is copied here.
{
	strLine.TrimLeft();
	if (strLine.IsEmpty())
		return(FALSE);
	if (strLine[0]=='['){
		for(int i=1;i<strLine.GetLength();i++){
			if (strLine[i]==']'){
				if (strSectionName!=NULL)
					*strSectionName=strLine.Mid(1,i-1);
				return(TRUE);
			}
			if (strLine[i]==';')
				break;
		}
	}
	return(FALSE);
}

void CTxtVar::Release()
// Reset cfg and clear string list.
{
	m_Pos=NULL;
	m_PosSectionStart=NULL;
	m_strList.RemoveAll();
	m_strCurrentSection.Empty();
	m_bChanged=FALSE;
}

int CTxtVar::FindItem(const CString strItem)
// Find an item in the string list within the current section.
//
// If strItem is found within the current section TXTVAR_NOERR is returned and
// m_strLine is set to this line and all arguments are copied to m_strArgs.
// This call must be preceded by a call to FindSectionHeader.
{
	if (m_PosSectionStart==NULL)
		return(TXTVAR_NOVALIDSECTION);
	
	POSITION pos=m_PosSectionStart,this_pos;
	m_strList.GetNext(pos);	// Advance to first item after header.

	while(pos!=NULL){
		this_pos=pos;
		m_strLine=m_strList.GetNext(pos);
		if (IsSectionHeader(m_strLine))
			return(TXTVAR_NOTFOUND);
		if (ConvertToArgs(m_strLine,m_strArgs,m_iNumArgs)>0 && m_strArgs[0]==strItem){
			m_Pos=this_pos;
			return(TXTVAR_NOERR);
		}
	}
	return(TXTVAR_NOTFOUND);
}


int CTxtVar::SetItem(const CString strItem, BOOL bAdd)
// Set an Item in the string list within the current section.
//
// If the item exists within the current section it is replaced.
// If it doesn't exist it is appended. strItem must contain at least two arguments
// (the item name and at least one data argument).
//
// If bAdd is TRUE the string is always appended even if it already exists. This
// is usefull if a list of variables or settings should be added to a section
// where it is valid to have the same variable name for several entries in the
// list.
{
	CString strArgs[TXTVAR_MAXARGS];
	int ret,iNumArgs;

	if (ConvertToArgs(strItem,strArgs,iNumArgs)<2)
		return TXTVAR_NOVALIDITEM;

	if (bAdd || (ret=FindItem(strArgs[0]))==TXTVAR_NOTFOUND){
		m_Pos=m_strList.InsertAfter(m_PosSectionStart,strItem);
		m_bChanged=TRUE;
		return(TXTVAR_NOERR);
	}
	else if (ret!=TXTVAR_NOERR)
		return ret;
	m_strList.SetAt(m_Pos,strItem);	
	m_bChanged=TRUE;
	return (TXTVAR_NOERR);
}

int CTxtVar::SetSectionItem(const CString strSection, const CString strItem, BOOL bAdd)
// Set an Item in the string list within the specified section.
//
// If the section doesn't exist it is added.
// See also SetItem. 
{
	CString strArgs[TXTVAR_MAXARGS];
	int ret,iNumArgs;

	if (ConvertToArgs(strItem,strArgs,iNumArgs)<2) // Check that variable contains at least one parameter
		return TXTVAR_NOVALIDITEM;
	
	if ((ret=FindSectionHeader(strSection))==TXTVAR_NOTFOUND){
		if (!m_strList.IsEmpty() && m_strList.GetTail()!="")
			m_strList.AddTail("");
		m_strList.AddTail("["+strSection+"]");
		m_Pos=NULL;
		m_strCurrentSection=strSection;
		m_PosSectionStart=m_strList.GetTailPosition();
		m_strList.AddTail(strItem);
		m_bChanged=TRUE;
		return TXTVAR_NOERR;
	}
	else if (ret!=TXTVAR_NOERR)
		return ret;
	else 
		return SetItem(strItem,bAdd);
}

int CTxtVar::ConvertToArgs(const CString strLine, CString strArgs[], int &iNumArgs)
// Break out all arguments from the string strLine and copy them to the strArgs[]
// string array. iNumArgs is also set to the number of arguments found in the line.
//
// This function is static and changes no values in the CTxtVar class. Can be used on
// any CString. Restricts number of arguments to TXTVAR_MAXARGS.
{
	int iArgstart,iIndex,strlen;
	BOOL quote,inarg;
	char terminator;

	iNumArgs=0;
	iArgstart=iIndex=0;
	strlen=strLine.GetLength();

	while(TRUE){
		quote=FALSE;
		inarg=FALSE;
		strArgs[iNumArgs].Empty();
		while(strlen>iIndex){
			if (!inarg){
				if (!isspace(strLine[iIndex])){
					iArgstart=iIndex;
					inarg=TRUE;
					if (strLine[iIndex]=='\"')
						quote=TRUE;
					else if (strLine[iIndex]==','){
						inarg=TRUE;
						break;
					}
				}
			}
			else {
				if ((quote && strLine[iIndex]=='\"') ||
					(!quote && isspace(strLine[iIndex])) ||
					(!quote && strLine[iIndex]==',')){
					terminator=strLine[iIndex];
					break;
				}
			}
			iIndex++;
		}
		if (!inarg)
			break;
		if (quote) iArgstart++;
		strArgs[iNumArgs]=strLine.Mid(iArgstart,iIndex-iArgstart);
		iNumArgs++;
		if (iNumArgs>=TXTVAR_MAXARGS)
			break;
		iIndex++;
		if (quote || isspace(terminator)){
			while(strlen>iIndex){
				if (!isspace(strLine[iIndex])){
					if (strLine[iIndex]==',')
						iIndex++;
					break;
				}
				iIndex++;
			}
		}
	}
	return(iNumArgs);
}

CString CTxtVar::GetArg(int iArg)
// Public function to retreive current argument number
// Must be preceded by a call that gets an item from the string list.
{
	return (iArg<m_iNumArgs)?m_strArgs[iArg]:CString("");
}

int CTxtVar::GetNextItem()
// Get the next item from current section in the string list.
// Returns TXTVAR_NOTFOUND when there are no more items in the current section.
//
// If next line is not a section header it is read to m_strLine and its 
// arguments are copied to m_strArgs[] array.
{
	
	if (m_PosSectionStart==NULL)
		return(TXTVAR_NOVALIDSECTION);

	while(m_Pos!=NULL){
		m_strLine=m_strList.GetNext(m_Pos);
		if (IsSectionHeader(m_strLine)){
			m_strList.GetPrev(m_Pos);
			return(TXTVAR_NOTFOUND);
		}
		if (ConvertToArgs(m_strLine,m_strArgs,m_iNumArgs)>0)
			return(TXTVAR_NOERR);
	}
	return(TXTVAR_NOTFOUND);
}

int CTxtVar::RemoveItem(BOOL bAllowHeaderDelete)
// Deletes current item from the string list.
//
// Deletes item at current position and makes next item current item.
// Returns as GetNextItem.
// bAllowHeaderDelete must be TRUE to be able to remove a header.
{

	POSITION pos=m_Pos;

	if (m_PosSectionStart==NULL)
		return TXTVAR_NOVALIDSECTION;
	if (!bAllowHeaderDelete && IsSectionHeader(m_strLine))
		return TXTVAR_SYNTAX;

	do {
		pos=m_Pos;
		if (m_Pos==NULL)
			pos=m_strList.GetTailPosition();
		else
			m_strList.GetPrev(pos); // pos now is position for element to remove.

		if (!bAllowHeaderDelete && pos==m_PosSectionStart)
			return TXTVAR_SYNTAX;
		if (pos==NULL)
			return TXTVAR_NOTFOUND;

		m_strList.RemoveAt(pos);
		m_bChanged=TRUE;
		if (m_Pos!=NULL){
			m_strLine=m_strList.GetNext(m_Pos);
			if (IsSectionHeader(m_strLine)){
				m_strList.GetPrev(m_Pos);
				return(TXTVAR_NOTFOUND);
			}
			if (ConvertToArgs(m_strLine,m_strArgs,m_iNumArgs)>0)
				return TXTVAR_NOERR;
		}
		else
			break;
	}while(TRUE);
	
	return TXTVAR_NOTFOUND;
}

int CTxtVar::EmptySection(const CString strSection)
// Removes all items from a section in the string list.
// The section header is not removed.
{
	int ret;
	if ((ret=FindSectionHeader(strSection))!=TXTVAR_NOERR)
		return ret;

	if ((ret=GetNextItem())!=TXTVAR_NOERR)
		return TXTVAR_NOERR;				// Already empty

	while(RemoveItem()==TXTVAR_NOERR);

	return TXTVAR_NOERR;
}

int CTxtVar::RemoveSection(const CString strSection)
// Removes an entire section and all it's items from the string list.
{
	int ret;
	if ((ret=EmptySection(strSection))!=TXTVAR_NOERR)
		return ret;

	FindSectionHeader(strSection);
	RemoveItem(TRUE);
	m_strCurrentSection.Empty();
	m_Pos=NULL;
	m_PosSectionStart=NULL;
	return TXTVAR_NOERR;
}

int CTxtVar::ArgToInt(int Index, int &Result)
// Converts argument in current item to an int.
// Must be preceded by a call that gets an item from the string list.
// Convert m_strArgs[index] to an integer.
{
	if (Index<m_iNumArgs){
		if (sscanf(m_strArgs[Index],"%d",&Result)==1){
			return(TXTVAR_NOERR);
		}
		else
			return(TXTVAR_SYNTAX);
	}
	else
		return(TXTVAR_INDEXOUTOFRANGE);
}

int CTxtVar::ArgToInt(int Index, int &Result, int Min, int Max)
// Convert m_strArgs[index] to an integer and also checks if it is inside the Min Max range.
{
	int ret;
	if ((ret=ArgToInt(Index,Result))!=TXTVAR_NOERR)
		return(ret);
	if (Result<Min || Result>Max)
		return(TXTVAR_OUTOFRANGE);
	return(TXTVAR_NOERR);
}

LPCTSTR CTxtVar::ErrorString(int Error)
// Return a CFG error string.
// This function is static.
{
	Error=abs(Error);
	if (Error<abs(TXTVAR_LASTERR_)){
		return(CfgErrorString[Error]);
	}
	CString str;
	str.Format("Unknown error - %d",Error);
	return(str);
}

int CTxtVar::FindSectionItem(const CString strSection, const CString strItem)
// Finds an item in a specified section in the string list.
{
	int ret;
	if ((ret=FindSectionHeader(strSection))!=TXTVAR_NOERR)
		return ret;
	return (FindItem(strItem));
}


int CTxtVar::SetArg(CString section, CString var, CString value)
{	
	m_strList.GetNext(m_Pos) = var + " " + "\"" + value + "\"";	
	return 0;

}

int CTxtVar::SetUDPSequence(int iUDPSequence)
{	
	int nRet = RETURN_SUCCESS;
	if(FindSectionItem("Settings","UDPSequence") == 0){		
		char pszNum [1] = {0};
		CString sudpSequence (_itoa (iUDPSequence, pszNum, 10));
		SetArg("Settings", "UDPSequence" , sudpSequence);
	}else{
		nRet = RETURN_FAIL;
		LOG_ERROR("Cannot update UDP Sequence Parameter\n");
		goto finish;
	}
finish:
	return nRet;
}
