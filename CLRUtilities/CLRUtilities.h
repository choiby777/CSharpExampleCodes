// CLRUtilities.h : main header file for the CLRUtilities DLL
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols


// CCLRUtilitiesApp
// See CLRUtilities.cpp for the implementation of this class
//

class CCLRUtilitiesApp : public CWinApp
{
public:
	CCLRUtilitiesApp();

// Overrides
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};
