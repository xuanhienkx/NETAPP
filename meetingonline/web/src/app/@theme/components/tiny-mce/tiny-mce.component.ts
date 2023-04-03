import { Component, OnDestroy, AfterViewInit, Output, EventEmitter, ElementRef, Input, OnInit } from '@angular/core';
import { LocationStrategy } from '@angular/common';
import { Subject } from 'rxjs';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { takeUntil } from 'rxjs/operators';
import { SubjectedEditorService } from 'src/app/@core/services/subjected-editor.service';

declare var tinymce: any;
@Component({
  selector: 'vip-tiny-mce',
  template: '<textarea id="{{elementId}}" >{{content}}</textarea>'
})
export class TinyMCEComponent implements OnDestroy, AfterViewInit, OnInit {
  private readonly destroy$: Subject<void> = new Subject<void>();

  @Output() editorKeyup = new EventEmitter<any>();
  @Input() elementId: string;
  @Input() content: string;
  @Input() statusbarText?: string;
  @Input() status?: 'basic';
  @Input() height?: number;

  editor: any;

  constructor(
    private host: ElementRef,
    private locationStrategy: LocationStrategy,
    private subjected: SubjectedEditorService
  ) { }
  ngOnInit(): void {
    const self = this;
    this.subjected.content$.pipe(
      takeUntil(this.destroy$)
    ).subscribe(x => {
      if (x.name === this.elementId) {
        self.editor.setContent(x.value);
      }
    });
  }

  ngAfterViewInit() {
    tinymce.init({
      selector: `#${this.elementId}`,
      target: this.host.nativeElement,
      plugins: ['link', 'paste', 'table'],
      skin_url: `${this.locationStrategy.getBaseHref()}assets/skins/lightgray`,
      toolbar: 'undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | outdent indent',
      menubar: '',
      body_class: this.status,
      statusbar: false,
      schema: 'html5',
      setup: editor => {
        this.editor = editor;
        editor.on('keyup change', () => {
          this.editorKeyup.emit(editor.getContent());
        });
        editor.on('callback', (e) => {
          console.log('callback==>', e, this.content);
        });
        editor.on('init', () => {
          if (this.content && this.content.length > 0) {
            this.editor.setContent(this.content, { format: 'raw' });
          }
        });
      },
      height: this.height ?? 320,
    });
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
    tinymce.remove(this.editor);
  }
}
