; CLW file contains information for the MFC ClassWizard

[General Info]
Version=1
LastClass=CBrokerCommunicationDlg
LastTemplate=CDialog
NewFileInclude1=#include "stdafx.h"
NewFileInclude2=#include "BrokerCommunication.h"

ClassCount=5
Class1=CBrokerCommunicationApp
Class2=CBrokerCommunicationDlg
Class3=CAboutDlg

ResourceCount=6
Resource1=IDD_DIALOG_CONNECT
Resource2=IDR_MAINFRAME
Resource3=IDD_DIALOG_RETRANSMISSION_BROADCAST
Resource4=IDD_ABOUTBOX
Class4=CConnectionSetting
Resource5=IDD_BROKERCOMMUNICATION_DIALOG
Class5=CRestransmissionBroadcastPacket
Resource6=IDR_MENU_BROKER_COMM

[CLS:CBrokerCommunicationApp]
Type=0
HeaderFile=BrokerCommunication.h
ImplementationFile=BrokerCommunication.cpp
Filter=N

[CLS:CBrokerCommunicationDlg]
Type=0
HeaderFile=BrokerCommunicationDlg.h
ImplementationFile=BrokerCommunicationDlg.cpp
Filter=D
LastObject=ID_CONNECTIONSETUP_CONNECT
BaseClass=CDialog
VirtualFilter=dWC

[CLS:CAboutDlg]
Type=0
HeaderFile=BrokerCommunicationDlg.h
ImplementationFile=BrokerCommunicationDlg.cpp
Filter=D

[DLG:IDD_ABOUTBOX]
Type=1
Class=CAboutDlg
ControlCount=4
Control1=IDC_STATIC,static,1342177283
Control2=IDC_STATIC,static,1342308480
Control3=IDC_STATIC,static,1342308352
Control4=IDOK,button,1342373889

[DLG:IDD_BROKERCOMMUNICATION_DIALOG]
Type=1
Class=CBrokerCommunicationDlg
ControlCount=0

[MNU:IDR_MENU_BROKER_COMM]
Type=1
Class=CBrokerCommunicationDlg
Command1=ID_APP_EXIT
Command2=ID_CONNECTIONSETUP_CONNECT
Command3=ID_CONNECTIONSETUP_DISCONNECT
Command4=ID_START_NEW_DAY
Command5=ID_CONNECTIONSETUP_SETTING
Command6=ID_CONNECTIONSETUP_RETRANSMISSION
Command7=ID_CONNECTIONSETUP_TESTING
Command8=ID_HELP_ABOUT
CommandCount=8

[DLG:IDD_DIALOG_CONNECT]
Type=1
Class=CConnectionSetting
ControlCount=40
Control1=IDC_HOSE_IPADDRESS,SysIPAddress32,1342242816
Control2=IDC_HOSE_PORT,edit,1350631552
Control3=IDC_EDIT_UDP_PORT,edit,1350631552
Control4=IDC_EDIT_RETRY_TIMES,edit,1350631552
Control5=IDC_EDIT_TIMEOUT,edit,1350631552
Control6=IDC_EDIT_MAX_PACKET_SIZE,edit,1350631552
Control7=IDC_EDIT_MAX_PACKET_TIME,edit,1350631552
Control8=IDC_COMBO_CONNECTION_MODE,combobox,1344340227
Control9=IDC_EDIT_PASSWORD,edit,1350631584
Control10=IDC_EDIT_MARKET_ID,edit,1350631552
Control11=IDC_EDIT_FIRM_ID,edit,1350631552
Control12=IDOK,button,1342242817
Control13=IDCANCEL,button,1342242816
Control14=IDC_STATIC,static,1342308352
Control15=IDC_STATIC,static,1342308352
Control16=IDC_STATIC,button,1342178055
Control17=IDC_STATIC,static,1342308352
Control18=IDC_STATIC,static,1342308352
Control19=IDC_STATIC,static,1342308352
Control20=IDC_STATIC,static,1342308352
Control21=IDC_STATIC,static,1342308352
Control22=IDC_STATIC,static,1342308352
Control23=IDC_STATIC,static,1342308352
Control24=IDC_STATIC,static,1342308352
Control25=IDC_STATIC,static,1342308352
Control26=IDC_STATIC,button,1342178055
Control27=IDC_STATIC,button,1342177287
Control28=IDC_EDIT_LINK_ID,edit,1350631552
Control29=IDC_STATIC,static,1342308352
Control30=IDC_STATIC,button,1342177287
Control31=IDC_EDIT_SEQUENCE_NO,edit,1350631552
Control32=IDC_EDIT_ACK_SEQUENCE_NO,edit,1350631552
Control33=IDC_STATIC,static,1342308352
Control34=IDC_STATIC,static,1342308352
Control35=IDC_STATIC,button,1342177287
Control36=IDC_EDIT_QUEUE_ADDRESS,edit,1350631552
Control37=IDC_EDIT_QUEUE_RECEIVING,edit,1350631552
Control38=IDC_STATIC,static,1342308352
Control39=IDC_STATIC,static,1342308352
Control40=IDC_CHECK_AUTOCONNECT,button,1342242819

[CLS:CConnectionSetting]
Type=0
HeaderFile=ConnectionSetting.h
ImplementationFile=ConnectionSetting.cpp
BaseClass=CDialog
Filter=D
LastObject=IDC_CHECK_AUTOCONNECT
VirtualFilter=dWC

[DLG:IDD_DIALOG_RETRANSMISSION_BROADCAST]
Type=1
Class=CRestransmissionBroadcastPacket
ControlCount=8
Control1=IDOK,button,1342242817
Control2=IDCANCEL,button,1342242816
Control3=IDC_STATIC,static,1342308352
Control4=IDC_EDITSEQ_FROM,edit,1350631552
Control5=IDC_STATIC,static,1342308352
Control6=IDC_EDIT_SEQ_TO,edit,1350631552
Control7=IDC_STATIC_RETRANSMISSION_INFOR,static,1342308352
Control8=IDC_STATIC_BROADCAST_SEQ_NO,static,1342308352

[CLS:CRestransmissionBroadcastPacket]
Type=0
HeaderFile=RestransmissionBroadcastPacket.h
ImplementationFile=RestransmissionBroadcastPacket.cpp
BaseClass=CDialog
Filter=D
LastObject=IDOK
VirtualFilter=dWC

