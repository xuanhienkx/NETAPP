import { Component, Input } from '@angular/core';
import { ElectionMatter, Attendee, Meeting } from 'src/app/@core/models/meeting.model';

@Component({
  selector: 'vip-vote-result',
  templateUrl: './vote-result.component.html',
  styleUrls: ['./vote-result.component.scss']
})
export class VoteResultComponent {

  @Input() attendee?: Attendee;
  @Input() items: ElectionMatter[];
  @Input() mt: Meeting;
}
