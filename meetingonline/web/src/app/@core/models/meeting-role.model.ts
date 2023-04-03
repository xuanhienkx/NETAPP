import { MeetingType } from './meeting.model';

export interface MeetingRole {
    id: string;
    name: string;
    meetingType: MeetingType;
    description?: string;
    permissions?: string[];
    createdDate: Date;
    isDisabled: boolean;
}


