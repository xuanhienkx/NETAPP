import { Injectable } from '@angular/core';
import { HubConnection } from '@microsoft/signalr';
import { environment } from 'src/environments/environment';
import * as signalR from '@microsoft/signalr';
import { LoggedInUser } from '../models/user.model';
import { isNullOrUndefined } from 'util';
import { AppStateProvider } from './app-state.provider';
import { Result, Message, WsMessage } from '../models/common';

@Injectable({
  providedIn: 'root'
})
export class ConnectionStateManager {
  private connection: HubConnection;
  constructor(
    private appState: AppStateProvider
  ) {
  }

  get connectionId(): string { return this.connection?.connectionId; }

  onUserChanges(user: LoggedInUser) {
    if (isNullOrUndefined(user)) {
      this.connection?.stop();
      this.connection = null;
    } else {
      // don't use ws on dev-mode
      if (!environment.production) {
        return;
      }

      if (isNullOrUndefined(this.connection)) {
        const url = `${environment.endpoint}/ws`;
        this.connect(url, user);
      }

      this.start();
    }
  }

  private connect(url: string, currentUser: LoggedInUser) {
    Object.defineProperty(WebSocket, 'OPEN', { value: 1, });

    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(url, { accessTokenFactory: () => currentUser?.token })
      .withAutomaticReconnect()
      .build();

    this.connection.on('login', (message: WsMessage) => {
      // console.log(message);

      if (message.id === this.connectionId && message.data === 'FORCE_LOGOUT') {
        this.appState.logout$.next({
          message: { msg: 'Common.forceLogout' }
        });
      } else {
        this.appState.wsMessage$.next(message);
      }
    });

    this.connection.on('hf', (message: WsMessage) => {
      this.appState.hfMessage$.next(message);
    });

    this.connection.onreconnecting(() => {
      console.log('WS reconnecting....');
    });

    this.connection.onreconnected(() => {
      console.log(`WS -> onreconnected[${this.connection.connectionId}] : ${this.connection.state}`);
    });

    this.connection.onclose(() => {
      console.log('WS closed');
    });
  }

  private start() {
    if (this.connection?.state !== signalR.HubConnectionState.Disconnected) {
      return;
    }
    this.connection.start()
      .then(() => {
        console.log(`WS -> started[${this.connection.connectionId}] : ${this.connection.state}`);
      })
      .catch((err) => {
        console.log(err);
      });
  }
}
