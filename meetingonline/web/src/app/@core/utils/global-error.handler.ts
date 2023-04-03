import { Injectable, ErrorHandler, Injector } from '@angular/core';
import { NotificationService } from '../services/notification.service';
@Injectable()
export class GlobalErrorHandler implements ErrorHandler {
    constructor(private injector: Injector) { }
    handleError(error) {
        console.log(error);
        const notifyService = this.injector.get(NotificationService);
        const message = error.message ? error.message : error.toString();
        notifyService.error(message);
    }
}