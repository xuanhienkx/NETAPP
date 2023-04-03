using System;
using System.ComponentModel;
using System.Diagnostics;

namespace pmDHCD.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            public AuthorizationList m_AuthorizationList;

            public AuthorizationList AuthorizationList
            {
                [DebuggerHidden]
                get
                {
                    m_AuthorizationList = Create__Instance__(m_AuthorizationList);
                    return m_AuthorizationList;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_AuthorizationList))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_AuthorizationList);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public AuthorizationListForSelect m_AuthorizationListForSelect;

            public AuthorizationListForSelect AuthorizationListForSelect
            {
                [DebuggerHidden]
                get
                {
                    m_AuthorizationListForSelect = Create__Instance__(m_AuthorizationListForSelect);
                    return m_AuthorizationListForSelect;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_AuthorizationListForSelect))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_AuthorizationListForSelect);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public AuthorizationsInsert m_AuthorizationsInsert;

            public AuthorizationsInsert AuthorizationsInsert
            {
                [DebuggerHidden]
                get
                {
                    m_AuthorizationsInsert = Create__Instance__(m_AuthorizationsInsert);
                    return m_AuthorizationsInsert;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_AuthorizationsInsert))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_AuthorizationsInsert);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public CandidateList m_CandidateList;

            public CandidateList CandidateList
            {
                [DebuggerHidden]
                get
                {
                    m_CandidateList = Create__Instance__(m_CandidateList);
                    return m_CandidateList;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_CandidateList))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_CandidateList);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public Delegate_ins m_Delegate_ins;

            public Delegate_ins Delegate_ins
            {
                [DebuggerHidden]
                get
                {
                    m_Delegate_ins = Create__Instance__(m_Delegate_ins);
                    return m_Delegate_ins;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_Delegate_ins))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_Delegate_ins);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DelegateList m_DelegateList;

            public DelegateList DelegateList
            {
                [DebuggerHidden]
                get
                {
                    m_DelegateList = Create__Instance__(m_DelegateList);
                    return m_DelegateList;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_DelegateList))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DelegateList);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DelegateListForSelect m_DelegateListForSelect;

            public DelegateListForSelect DelegateListForSelect
            {
                [DebuggerHidden]
                get
                {
                    m_DelegateListForSelect = Create__Instance__(m_DelegateListForSelect);
                    return m_DelegateListForSelect;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_DelegateListForSelect))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DelegateListForSelect);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public ElectionList m_ElectionList;

            public ElectionList ElectionList
            {
                [DebuggerHidden]
                get
                {
                    m_ElectionList = Create__Instance__(m_ElectionList);
                    return m_ElectionList;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_ElectionList))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_ElectionList);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public Elections_result m_Elections_result;

            public Elections_result Elections_result
            {
                [DebuggerHidden]
                get
                {
                    m_Elections_result = Create__Instance__(m_Elections_result);
                    return m_Elections_result;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_Elections_result))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_Elections_result);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public ElectionVoteList m_ElectionVoteList;

            public ElectionVoteList ElectionVoteList
            {
                [DebuggerHidden]
                get
                {
                    m_ElectionVoteList = Create__Instance__(m_ElectionVoteList);
                    return m_ElectionVoteList;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_ElectionVoteList))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_ElectionVoteList);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmReport m_frmReport;

            public frmReport frmReport
            {
                [DebuggerHidden]
                get
                {
                    m_frmReport = Create__Instance__(m_frmReport);
                    return m_frmReport;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmReport))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmReport);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public HolderList m_HolderList;

            public HolderList HolderList
            {
                [DebuggerHidden]
                get
                {
                    m_HolderList = Create__Instance__(m_HolderList);
                    return m_HolderList;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_HolderList))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_HolderList);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public HolderListForSelect m_HolderListForSelect;

            public HolderListForSelect HolderListForSelect
            {
                [DebuggerHidden]
                get
                {
                    m_HolderListForSelect = Create__Instance__(m_HolderListForSelect);
                    return m_HolderListForSelect;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_HolderListForSelect))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_HolderListForSelect);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public IllegalElectionList m_IllegalElectionList;

            public IllegalElectionList IllegalElectionList
            {
                [DebuggerHidden]
                get
                {
                    m_IllegalElectionList = Create__Instance__(m_IllegalElectionList);
                    return m_IllegalElectionList;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_IllegalElectionList))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_IllegalElectionList);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public Mainform m_Mainform;

            public Mainform Mainform
            {
                [DebuggerHidden]
                get
                {
                    m_Mainform = Create__Instance__(m_Mainform);
                    return m_Mainform;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_Mainform))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_Mainform);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public MatterList m_MatterList;

            public MatterList MatterList
            {
                [DebuggerHidden]
                get
                {
                    m_MatterList = Create__Instance__(m_MatterList);
                    return m_MatterList;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_MatterList))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_MatterList);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public MatterVoteList m_MatterVoteList;

            public MatterVoteList MatterVoteList
            {
                [DebuggerHidden]
                get
                {
                    m_MatterVoteList = Create__Instance__(m_MatterVoteList);
                    return m_MatterVoteList;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_MatterVoteList))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_MatterVoteList);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public MatterVoteResult m_MatterVoteResult;

            public MatterVoteResult MatterVoteResult
            {
                [DebuggerHidden]
                get
                {
                    m_MatterVoteResult = Create__Instance__(m_MatterVoteResult);
                    return m_MatterVoteResult;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_MatterVoteResult))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_MatterVoteResult);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public MeetingInfoshow m_MeetingInfoshow;

            public MeetingInfoshow MeetingInfoshow
            {
                [DebuggerHidden]
                get
                {
                    m_MeetingInfoshow = Create__Instance__(m_MeetingInfoshow);
                    return m_MeetingInfoshow;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_MeetingInfoshow))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_MeetingInfoshow);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public MeetingList m_MeetingList;

            public MeetingList MeetingList
            {
                [DebuggerHidden]
                get
                {
                    m_MeetingList = Create__Instance__(m_MeetingList);
                    return m_MeetingList;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_MeetingList))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_MeetingList);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public PrintHolders m_PrintHolders;

            public PrintHolders PrintHolders
            {
                [DebuggerHidden]
                get
                {
                    m_PrintHolders = Create__Instance__(m_PrintHolders);
                    return m_PrintHolders;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_PrintHolders))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_PrintHolders);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public ReportViewer m_ReportViewer;

            public ReportViewer ReportViewer
            {
                [DebuggerHidden]
                get
                {
                    m_ReportViewer = Create__Instance__(m_ReportViewer);
                    return m_ReportViewer;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_ReportViewer))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_ReportViewer);
                }
            }
        }
    }
}