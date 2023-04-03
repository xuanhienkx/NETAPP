import { Media, Email, PhoneNumber } from './common';
import { MeetingAccess } from './meeting.model';
import { Permission } from '../utils/auth-constant';

export interface LoggedInUser {
    id: string;
    token: string;
    role: string;
    permisions: Permission[];
    userName: string;
    displayName: string;
    meetingGroups: MeetingGroup[];
    manguage: string;
    photo?: Media;
    phoneNumber?: PhoneNumber;
    timezone: any;
    language: string;
    meetingAccesses: MeetingAccess[];
    loginTimeStamp: string;
}

export interface User {
    id: string;
    userName: string;
    displayName: string;
    email?: Email;
    meetingAccesses?: MeetingAccess[];
}

export interface MeetingGroup {
    id?: any;
    name: string;
    logo?: Media;
    header: string;
    footer: string;
}
