export enum UserRole {
    /// <summary>
    /// The owner, who has greatest power to his resource
    /// </summary>
    MODERATOR,
    /// <summary>
    /// The administrative users
    /// </summary>
    ADMIN,
    ///
    /// The normarl user
    ///
    USER,
    ///
    /// The holder or attende access meeting
    ///
    Viewer
}

export enum Permission {
    meeting_manage_members,
    meeting_manage_documents,
    meeting_manage_electionmatters,
    meeting_manage_holders,
    meeting_complete_holders,
    meeting_open_session,
    meeting_checkin_attendees,
    meeting_manage_delegaterequests,
    meeting_manage_votes,
    meeting_close_session,
    meeting_manage_reports
}
