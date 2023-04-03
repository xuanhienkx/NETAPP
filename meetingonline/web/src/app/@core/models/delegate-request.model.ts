import { Delegation, Holder } from './meeting.model';
import { Occurrence } from './common';

export interface DelegateRequest {
    id?: string;
    meetingId: string;
    mandator: Holder;
    delegation: Delegation;
    isOnline?: boolean;
    confirmedDate?: Occurrence | Date;
    createdDate?: Occurrence | Date;
    adminActivities?: Activity[];
}

export interface Activity {
    note?: string;
    createdDate: Occurrence;
    performedId: string;
    performedName: string;
}

export interface DelegateRequestGroup {
    mandator: Holder;
    requests: DelegateRequest[];
}

export interface MandatorDelegateRequest {
    id: string;
    mandator: Holder;
    delegations: Delegation[];
}
