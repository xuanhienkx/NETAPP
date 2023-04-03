import {
    ChangeDetectorRef,
    Directive,
    Input,
    OnChanges,
    OnInit,
    SimpleChanges,
    TemplateRef,
    ViewContainerRef
} from '@angular/core';

import { notEmptyValue, isBoolean, transformStringToArray } from '../../@core/utils/utils';
import { isArray } from 'util';
import { UserInfoService } from 'src/app/@core/services/user-info.service';

@Directive({ selector: '[allow]' })
export class AllowAccessDirective implements OnInit, OnChanges {

    @Input() allow: string | string[];
    @Input() then: TemplateRef<any>;
    @Input() else: TemplateRef<any>;

    private currentAuthorizedState: boolean;

    constructor(
        private userInfo: UserInfoService,
        private viewContainer: ViewContainerRef,
        private changeDetector: ChangeDetectorRef,
        private templateRef: TemplateRef<any>
    ) {
    }

    ngOnInit(): void {
        this.viewContainer.clear();
    }

    ngOnChanges(changes: SimpleChanges): void {
        const allowChanges = changes.allow;
        if (allowChanges) {
            if (notEmptyValue(this.allow)) {
                this.validateAllowPermissions();
                return;
            }

            this.handleAuthorisedPermission(this.getAuthorisedTemplates());
        }
    }

    private validateAllowPermissions(): void {
        if (!!this.allow || isArray(this.allow) && this.allow.length > 0) {
            const roles: string[] = [];
            const permissions: string[] = [];

            transformStringToArray(this.allow)
                .forEach(x => {
                    if (x.startsWith('@')) {
                        roles.push(x.slice(1));
                    } else {
                        permissions.push(x);
                    }
                });

            Promise.all([
                this.userInfo.isInRoles(roles),
                this.userInfo.hasPermissions(permissions)
            ]).then(([roleResult, permResult]) => {
                if (!roleResult.succeed || !permResult.succeed) {
                    this.handleUnauthorisedPermission(this.else);
                } else {
                    this.handleAuthorisedPermission(this.getAuthorisedTemplates());
                }
            }).catch(() => {
                if (!!this.allow) {
                    this.validateAllowPermissions();
                } else {
                    this.handleAuthorisedPermission(this.getAuthorisedTemplates());
                }
            });
        }
    }

    private handleUnauthorisedPermission(template: TemplateRef<any>): void {
        if (isBoolean(this.currentAuthorizedState) && !this.currentAuthorizedState) {
            return;
        }

        this.currentAuthorizedState = false;
        this.showTemplateBlockInView(template);
    }

    private handleAuthorisedPermission(template: TemplateRef<any>): void {
        if (isBoolean(this.currentAuthorizedState) && this.currentAuthorizedState) {
            return;
        }

        this.currentAuthorizedState = true;
        this.showTemplateBlockInView(template);
    }

    private showTemplateBlockInView(template: TemplateRef<any>): void {
        this.viewContainer.clear();
        if (!template) {
            console.log('showTemplateBlockInView return');
            return;
        }

        this.viewContainer.createEmbeddedView(template);
        this.changeDetector.markForCheck();
    }

    private getAuthorisedTemplates(): TemplateRef<any> {
        return this.then
            || this.templateRef;
    }
}
