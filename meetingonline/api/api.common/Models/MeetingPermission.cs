using System;
using System.Collections.Generic;
using System.Text;
// ReSharper disable All

namespace api.common.Models
{
    public enum MeetingPermission
    {
        meeting_access_view,
        meeting_access_edit,
        meeting_access_remove,
        meeting_document_edit,
        meeting_document_remove,
        meeting_election_edit,
        meeting_election_remove,
        meeting_holder_view,
        meeting_holder_edit,
        meeting_holder_remove,
        meeting_holder_lock,
        meeting_holder_print,
        meeting_holder_email,
        meeting_delegation_approve,
    }
}
