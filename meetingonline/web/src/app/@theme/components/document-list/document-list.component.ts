import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Media, MediaForDel } from 'src/app/@core/models/common';
import { NbDialogService } from '@nebular/theme';
import { GetMediaUrl, convertToBoolProperty, VipBooleanInput } from 'src/app/@core/utils/utils';
import { DocumentViewerComponent } from '../document-viewer/document-viewer.component';

@Component({
  selector: 'vip-document-list',
  templateUrl: './document-list.component.html',
  styleUrls: ['./document-list.component.scss']
})
export class DocumentListComponent implements OnInit {
  @Input()
  get isNoCommand(): boolean {
    return this._checkIsNoCommand;
  }
  set isNoCommand(value: boolean) {
    this._checkIsNoCommand = convertToBoolProperty(value);
  }
  protected _checkIsNoCommand = false;
  // tslint:disable-next-line:member-ordering
  static ngAcceptInputType_checkIsNoCommand: VipBooleanInput;
  @Input() public attachments?: Media[] = [];
  @Input() public contentId?: string;
  @Input() public allowEdit = true;

  @Output() deleteFileInfo = new EventEmitter<any>();

  constructor(private dialogService: NbDialogService) { }

  ngOnInit(): void {
  }

  viewDoc(ats: Media) {
    const docUrl = GetMediaUrl(ats);
    this.dialogService.open(DocumentViewerComponent, {
      context: {
        docUrl,
        fileName: ats.name
      }
    });
  }

  downloadFile(ats) {
    window.location.href = GetMediaUrl(ats);
  }

  onDeleteFile(docId: string, idx?: number) {
    const data: MediaForDel = { contentId: this.contentId, fileId: docId, idx };
    this.deleteFileInfo.emit(data);

  }
}
