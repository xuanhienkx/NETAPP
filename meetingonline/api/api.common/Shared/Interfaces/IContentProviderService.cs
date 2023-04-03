﻿using System; 
using System.Collections.Generic;
using System.Text;
using api.common.Models;
using api.common.Models.Identity;

namespace api.common.Shared.Interfaces
{
    public interface IContentProviderService
    {
        EmailContent GenerateEmailForSignUp(AccountInfo user, string loginCode, string passwordToken);
        EmailContent GenerateEmailForResetPassword(AccountInfo user, string token);
        EmailContent GenerateEmailForConfirmEmail(AccountInfo user, string emailConfirmToken);
        EmailContent GenerateEmailForRequestDelegation(MeetingLite meeting, AccountInfo holder, Delegation delegation);
        EmailContent GenerateEmailForMeetingHolder(MeetingLite requestMeeting, Holder holder);
        EmailContent GenerateEmailToInformDelegateRequest(MeetingLite meeting, AccountInfo owner, List<Delegation> delegations);
        EmailContent GenerateEmailForApprovalDelegation(MeetingLite meeting, AccountInfo holder);
        IList<PlaceHolder> GenerateReportForAttendCheckInOffline(Meeting meeting, Attendee attendee);
    }
}
