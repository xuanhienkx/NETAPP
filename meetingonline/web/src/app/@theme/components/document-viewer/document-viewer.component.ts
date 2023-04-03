import { Component, OnInit, Input } from '@angular/core';
import { NbDialogRef, NbSidebarService } from '@nebular/theme';
import { environment } from 'src/environments/environment';
import { Media } from 'src/app/@core/models/common';
import { GetMediaUrl } from 'src/app/@core/utils/utils';

@Component({
  selector: 'vip-document-viewer',
  templateUrl: './document-viewer.component.html',
  styleUrls: ['./document-viewer.component.scss'],
  providers: [NbSidebarService]
})
export class DocumentViewerComponent implements OnInit {
  @Input() attachments?: Media[];
  @Input() docUrl?: string;
  @Input() fileName?: string;
  viewType = 'google';
  isImage: boolean;
  isPdf: boolean;
  isShow = false;

  constructor(protected ref: NbDialogRef<DocumentViewerComponent>, private sidebarService: NbSidebarService) { }

  ngOnInit(): void {
    if (this.attachments) {
      const firstMedia = this.attachments[0];
      this.docUrl = GetMediaUrl(firstMedia);
      this.fileName = firstMedia.name;
      this.isShow = true;
    }
    const regex = new RegExp('(.*?)\.(jpg|png|jpeg)$');
    this.isImage = regex.test(this.docUrl);
    this.isPdf = /(.*?)\.pdf$/.test(this.docUrl);
    this.viewType = environment.documentViewType;
  }

  showList() {
    this.isShow = !this.isShow;
  }

  viewDoc(ats: Media) {
    this.docUrl = GetMediaUrl(ats);
    this.fileName = ats.name;

  }
  close() {
    this.ref.close();
  }
}

