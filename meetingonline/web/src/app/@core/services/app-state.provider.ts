import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { LoggedInUser } from '../models/user.model';
import { Meeting, MeetingSummary, Holder, Attendee } from '../models/meeting.model';
import { WsMessage, Message, MessageExtras } from '../models/common';
import { NbJSThemeOptions } from '@nebular/theme';

@Injectable({
  providedIn: 'root'
})
export class AppStateProvider {
  theme: NbJSThemeOptions;

  public readonly title$: Subject<string> = new Subject<string>();
  public readonly meeting$: Subject<Meeting> = new Subject<Meeting>();
  public readonly meetingSummary$: Subject<MeetingSummary> = new Subject<MeetingSummary>();
  public readonly accountSummary$: Subject<Holder| Attendee> = new Subject<Holder| Attendee>();

  public readonly user$: Subject<LoggedInUser> = new Subject<LoggedInUser>();
  public readonly logout$: Subject<MessageExtras> = new Subject<MessageExtras>();
  public readonly message$: Subject<Message> = new Subject<Message>();

  public readonly wsMessage$: Subject<WsMessage> = new Subject<WsMessage>();
  public readonly hfMessage$: Subject<WsMessage> = new Subject<WsMessage>();

  public readonly spinner$: Subject<boolean> = new Subject<boolean>();
  public readonly test$: Subject<string> = new Subject<string>();
}
