import { KeyValue } from '@angular/common'; 
import { NavigationExtras } from '@angular/router';

export interface Result<T> {
    succeeded: boolean;
    errors?: string[];
    value?: T;
}

export interface Pair<T> {
    value: T;
    name: string;
}

export interface Occurrence {
    value?: Date;
}

export interface Email {
    value?: string;
}

export interface PhoneNumber {
    value?: string;
}

export interface Media {
    id: string;
    name: string;
    provider: string;
    fileId: string;
}
export interface MediaForDel {
    contentId: string;
    fileId: string;
    idx?: number;
}

export class AuthResult {
    constructor(public succeed: boolean, public hasUserLogin?: boolean) {
    }
}

export interface WsMessage {
    id: string;
    data: string;
}

export interface Message {
    msg: string;
    title?: string;
    isTranslated?: boolean;
    // type: 0 - error, 1 - warning, 2 - infor
    type?: number;
}

export interface MessageExtras {
    message?: Message;
    extras?: NavigationExtras;
}

export interface Validator {
    name: string;
    validator: any;
    message: string;
}
export enum ValidatorType {

}
export interface FieldConfig {
    label?: string;
    name?: string;
    placeholder?: string;
    inputType?: string;
    options?: KeyValue<string | number, any>[];
    optionDefault?: string;
    collections?: any;
    type: string;
    value?: any;
    required?: boolean;
    validations?: Validator[];
}
