import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { UserInfoService } from 'src/app/@core/services/user-info.service';
import { GetMediaUrl } from 'src/app/@core/utils/utils';
import { MeetingGroup } from 'src/app/@core/models/user.model';

@Pipe({
  name: 'groupLogo'
})
export class GroupLogoPipe implements PipeTransform {
  groups: MeetingGroup[];
  constructor(userInfo: UserInfoService, private sanitizer: DomSanitizer) {
    this.groups = userInfo.user.meetingGroups;
  }
  transform(groupId: string): SafeHtml {
    return this.bindLogo(groupId);
  }
  bindLogo(groupId: string): SafeHtml {

    if (!this.groups) {
      const defautImange = `D`;
      return this.sanitizer.bypassSecurityTrustHtml(defautImange);
    }
    const group: MeetingGroup = this.groups?.find(x => x?.id === groupId);
    if (group.id === groupId && group.logo) {
      if (group.logo) {
        const imageUrl = GetMediaUrl(group.logo);
        const image = `<div  class="rounded-circle"
                       style="width: 48px;height: 48px;background-image:url('${imageUrl}');
                      background-size: 46px 46px;" ></div>`;
        return this.sanitizer.bypassSecurityTrustHtml(image);
      }
    } else {
      const first = group.name.charAt(0).toUpperCase();
      return this.sanitizer.bypassSecurityTrustHtml(first);
    }
  }
}
