import { Pipe, PipeTransform } from '@angular/core';
import { UserInfoService } from 'src/app/@core/services/user-info.service';
import { MeetingGroup } from 'src/app/@core/models/user.model';

@Pipe({
  name: 'groupPipe'
})
export class GroupPipePipe implements PipeTransform {

  groups: MeetingGroup[];
  constructor(userInfo: UserInfoService) {
    this.groups = userInfo.user?.meetingGroups;
  }

  transform(groupId: string): any {
    if (!this.groups) {
      return 'no-name';
    }
    const group: MeetingGroup = this.groups?.find(x => x?.id === groupId);
    if (group.id === groupId) {
      return group.name;
    }
    return 'no-name';
  }
}

