import { Component, Input, EventEmitter, Output, OnDestroy, OnInit } from '@angular/core';

import { NotificationService } from 'src/app/@core/services/notification.service';
import { Result, Media } from 'src/app/@core/models/common';
import { Subscription, } from 'rxjs';
import { UploadFileService } from 'src/app/@core/services/upload-file.service';
import { ApiService } from 'src/app/@core/services/api.service';
import { Subject } from '@microsoft/signalr';
import { HttpEventType } from '@angular/common/http';
import { isNullOrUndefined } from 'util';

declare interface FileItem {
  file: File;
  isUploading?: boolean;
  isUploaded?: boolean;
  isSuccess?: boolean;
  isCancel?: boolean;
  isError?: boolean;
  progress: number;
}

@Component({
  selector: 'vip-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.scss']
})
export class UploadFileComponent implements OnInit, OnDestroy {
  private readonly fileUpload$: Subject<FileItem> = new Subject<FileItem>();
  private upload$: Subscription;
  private reset$: Subscription;

  media: Media[] = [];
  fileItem: FileItem[] = [];

  @Input() multiple = false;
  @Input() uploadDescription = '';
  @Input() acceptFileAllow = '';
  @Output() uploadFinished: EventEmitter<any> = new EventEmitter<Media[]>();

  constructor(
    private notifier: NotificationService,
    private uploadService: UploadFileService,
    private api: ApiService
  ) {
  }

  ngOnInit(): void {
    const self = this;
    this.upload$ = this.uploadService.upload$.subscribe(() => self.uploadFile());
    this.reset$ = this.uploadService.reset$.subscribe(() => self.resetFiles());
    this.fileUpload$.subscribe(
      {
        next: (f: FileItem) => {
          self.api.fileUploaderUpload(f.file).subscribe(event => self.onResponse(event, f));
        },
        error: null,
        complete: null
      });

  }

  onResponse(event: any, f: FileItem) {
    if (event.type === HttpEventType.UploadProgress) {
      f.progress = Math.round(100 * event.loaded / event.total);
    } else if (event.type === HttpEventType.Response) {
      const r = event.body as Result<Media>;

      if (r.succeeded) {
        f.isSuccess = true;
        this.media.push(r.value);
      } else {
        f.isError = true;
        this.notifier.errorTranslate('fileUpload.file.uploadFailed', 'fileUpload.errorTitle');
      }

      f.progress = 100;
      f.isUploaded = true;
      f.isUploading = false;
      this.uploadFile();
    }
  }

  uploadFile() {
    const items = this.fileItem.filter(f => !f.isUploaded && !f.isUploading);
    if (items.length === 0) {
      this.uploadFinished.emit(this.media);
    } else {
      const item = items[0];
      item.isUploading = true;
      this.fileUpload$.next(item);
    }
  }

  resetFiles() {
    this.media = [];
    this.fileItem = this.fileItem.filter(x => !x.isSuccess);
  }

  ngOnDestroy(): void {
    this.fileUpload$?.complete();
    this.upload$?.unsubscribe();
    this.reset$?.unsubscribe();
  }

  /**
   * on file drop handler
   */
  onFileDropped($event) {
    this.prepareFilesList($event);
  }

  /**
   * handle file from browsing
   */
  fileBrowseHandler(files) {
    this.prepareFilesList(files);
  }

  /**
   * Delete file from files list
   * @param index (File index)
   */
  deleteFile(index: number) {
    this.fileItem.splice(index, 1);
  }

  /**
   * Convert Files list to normal array list
   * @param files (Files List)
   */
  prepareFilesList(files: Array<any>) {
    if (!this.multiple) {
      const item = files[0];
      item.progress = 0;
      if (!isNullOrUndefined(this.acceptFileAllow) && this.acceptFileAllow.length > 0 && !this.acceptFileAllow.includes(item.type)) {
        console.log(item);

        this.notifier.errorTranslate(`fileUpload.file.typeInvalid`, 'fileUpload.errorTitle', { fileName: item?.file?.name ?? '' });
        return;
      }
      this.fileItem = [];
      this.fileItem.push({
        file: item,
        progress: 0,
      });
      return;
    } else {
      for (const item of files) {
        item.progress = 0;
        if (!isNullOrUndefined(this.acceptFileAllow) && this.acceptFileAllow.length > 0 && !this.acceptFileAllow.includes(item.type)) {
          this.notifier.errorTranslate(`fileUpload.file.typeInvalid`, 'fileUpload.errorTitle', { fileName: item?.file?.name ?? '' });
          item.isSuccess = false;
          continue;
        }

        this.fileItem.push({
          file: item,
          progress: 0,
        });
      }
    }

  }

  /**
   * format bytes
   * @param bytes (File size in bytes)
   * @param decimals (Decimals point)
   */
  formatBytes(bytes, decimals?) {
    if (bytes === 0) {
      return '0 Bytes';
    }
    const k = 1024;
    const dm = decimals <= 0 ? 0 : decimals || 2;
    const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];
    const i = Math.floor(Math.log(bytes) / Math.log(k));
    return parseFloat((bytes / Math.pow(k, i)).toFixed(dm)) + ' ' + sizes[i];
  }
}
