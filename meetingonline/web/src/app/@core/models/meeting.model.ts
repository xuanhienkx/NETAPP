import { Occurrence, Media, PhoneNumber, Email } from './common';
import { MeetingRole } from './meeting-role.model';

export interface Meeting {
    id?: string;
    name: string;
    description: string;
    address: string;
    createdDate?: Occurrence | Date;
    openedDate: Occurrence | Date;
    closedDate?: Occurrence | Date;
    deletedDate?: Occurrence | Date;
    isOwner: boolean;
    type: MeetingType | string;
    status?: MeetingStatus | string;
    groupId?: any;
    userRoles: MeetingRole[];
    contents: MeetingInfo[];
    electionMatters: ElectionMatter[];
    logo?: Media;
    header?: string;
    footer?: string;
    summary?: MeetingSummary;
}

export interface MeetingSummary {
    holders?: number;
    attendConfirmed?: number;

    shares?: number;
    votes?: number;
    confirmedVotes?: number;

    checkIn?: number;
    checkInVotes?: number;
    onlineCheckIn?: number;
    onlineCheckInVotes?: number;
    holderCheckIn?: number;
    holderCheckInVotes?: number;
    holderOnlineCheckIn?: number;
    holderOnlineCheckInVotes?: number;
}

export interface MeetingAccess {
    meetingId: string;
    meetingType: MeetingType | string;
    isOwner?: boolean;
    isViewer?: boolean;
    isLocked?: boolean;
    meetingRoles?: string[];
    permissions?: string[];
}

export interface ElectionMatter extends MeetingInfo {
    options?: ElectionOption[];
    optional: boolean;
    taken: number;
}

export interface MeetingInfo {
    name: string;
    description: string;
    attachments?: Media[];
    id: string;
}

export interface ElectionOption {
    id?: string;
    name: string;
    votes?: number;
}

export enum MeetingType {
    /// <summary>
    /// Đại hội đồng cổ đông
    /// </summary>
    GeneralMeeting,
    /// <summary>
    /// Hội nghi cư dân
    /// </summary>
    ApartmentMeeting
}

export enum MeetingStatus {
    Started,
    /// when holder list are locking for invitation
    Locking,
    /// when holder list are locked for invitation
    Lock,
    /// open to receive online votes
    Open,
    /// Closing process all will look and only find report acction
    Closing,
    /// completed, only find report
    Close
}

export interface Person {
    id?: string;
    displayName: string;
    identityNumber?: string;
    normalizeIdentityNumber?: string;
    identityType?: string;
    identityIssuedDate?: string | Date;
    identityIssuer?: string;
    identityUserId?: string;
    address?: string;
    phoneNumber?: PhoneNumber;
    phone?: string;
    email?: Email;
    emailAddress?: string;
    nationality?: number;
    meetingId: string;
    avatar?: Media;
}

export interface Holder extends Person {
    shares: number;
    ownedVotes: number;
    poweredVotes?: number;
    delegatedVotes?: number;
    blockedVotes?: number;
    availableVotes?: number;
    delegatingVotes: number;
    confirmedDate?: Occurrence | Date;
    checkedInDate?: Occurrence | Date;
}

export interface ElectionVote {
    id: string;
    votes: number;
    options: ElectionVote[];
}

export interface Attendee extends Person {
    shares: number;
    ownedVotes: number;
    sharedVotes: number;
    delegatingVotes: number;
    totalVotes: number;
    createdDate: Occurrence | Date;
    checkedInDate: Occurrence | Date;
    votes: ElectionVote[];
    isRepresentative: boolean;
    isOnlineCheckIn: boolean;
    attachments?: Media[];
    repTitle: string;
    mandators: Delegation[];
    reportPrint?: Media[];

}

export interface Delegation extends Person {
    votes: number;
    createdDate?: Occurrence | Date;
    requestedDate?: Occurrence | Date;
    approvedDate?: Occurrence | Date;
    rejectedDate?: Occurrence | Date;
    attachments?: Media[];
}

