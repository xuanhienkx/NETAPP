import { TranslateService } from '@ngx-translate/core';
import { $enum } from 'ts-enum-util';
import { map } from 'rxjs/operators';
import { StringKeyOf } from 'ts-enum-util/dist/types/types';
import { Observable } from 'rxjs';
import { Media, Pair } from '../models/common';
import { environment } from 'src/environments/environment';

export function isFunction<T>(value: any): value is T {
    return typeof value === 'function';
}

export function isPlainObject(value: any): boolean {
    if (Object.prototype.toString.call(value) !== '[object Object]') {
        return false;
    } else {
        const prototype = Object.getPrototypeOf(value);
        return prototype === null || prototype === Object.prototype;
    }
}

export function isString(value: any): value is string {
    return !!value && typeof value === 'string';
}

export function isBoolean(value: any): value is boolean {
    return typeof value === 'boolean';
}

export function isPromise(promise: any) {
    return Object.prototype.toString.call(promise) === '[object Promise]';
}

export function isOccurrence(value: any) {
    return Object.prototype.toString.call(value) === '[object Occurrence]';
}

export function notEmptyValue(value: string | string[]): boolean {
    if (Array.isArray(value)) {
        return value.length > 0;
    }
    return !!value;
}

export function transformStringToArray(value: string | string[]): string[] {
    if (isString(value)) {
        return [value];
    }
    return value;
}

export function transformToArray<T>(value: any | any[], transform: (value: any) => T): T[] {
    if (Array.isArray(value)) {
        return value.map(v => transform(v));
    }
    return [transform(value)];
}

export function localizeEnum<T extends Record<StringKeyOf<T>, number>>(
    enumeration: T, prefix: string, localizer: TranslateService
): Observable<Pair<T>[]> {
    const enumKeys = $enum(enumeration).getKeys();

    return localizer.get(enumKeys.map(k => `${prefix}.${k}`))
        .pipe(
            map((x, idx) => {
                return enumKeys.map<Pair<T>>(k => ({
                    name: x[`${prefix}.${k}`],
                    value: enumeration[k.valueOf()]
                }));
            }));
}

export function GetMediaUrl(media: Media) {
    if (media) {
        let urlBase = `${environment.mediaEndpoint}`;
        if (media.provider === 'Report') {
            urlBase += '/reports';
        }
        return `${urlBase}/${media.fileId}`;
    }
}

export function uriEscape(value: string) {
    return value.replace(/[&\/\\#,+()$~%.'":*?<>{}]/g, '');
}

export function readBase64(file: File): Promise<any> {
    const reader = new FileReader();
    const future = new Promise((resolve, reject) => {
        reader.addEventListener('load', () => {
            resolve(reader.result);
        }, false);

        reader.addEventListener('error', (event) => {
            reject(event);
        }, false);

        reader.readAsDataURL(file);
    });
    return future;
}

export type VipNullableInput = string | null | undefined;
export type VipBooleanInput = boolean | VipNullableInput;

export function convertToBoolProperty(val: any): boolean {
    if (typeof val === 'string') {
        val = val.toLowerCase().trim();

        return (val === 'true' || val === '');
    }

    return !!val;
}

export function getElementHeight(el) {
    const style = window.getComputedStyle(el);
    const marginTop = parseInt(style.getPropertyValue('margin-top'), 10);
    const marginBottom = parseInt(style.getPropertyValue('margin-bottom'), 10);
    return el.offsetHeight + marginTop + marginBottom;
}

export function firstChildNotComment(node: Node) {
    const children = Array
        .from(node.childNodes)
        .filter((child: Node) => child.nodeType !== Node.COMMENT_NODE);
    return children[0];
}

export function lastChildNotComment(node: Node) {
    const children = Array
        .from(node.childNodes)
        .filter((child: Node) => child.nodeType !== Node.COMMENT_NODE);
    return children[children.length - 1];
}

/*
 * @breaking-change Remove @6.0.0
 */
export function emptyStatusWarning(source: string) {
    console.warn(`${source}: Using empty string as a status is deprecated. Use \`basic\` instead.`);
}

