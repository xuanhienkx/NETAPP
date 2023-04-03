import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  NbActionsModule,
  NbLayoutModule,
  NbMenuModule,
  NbSearchModule,
  NbSidebarModule,
  NbUserModule,
  NbContextMenuModule,
  NbButtonModule,
  NbSelectModule,
  NbIconModule,
  NbThemeModule,
  NbDialogModule,
  NbCardModule,
  NbListModule,
  NbInputModule,
  NbFormFieldModule
} from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';

import {
  FooterComponent,
  HeaderComponent,
  TinyMCEComponent,
} from './components';
import {
  CapitalizePipe,
  PluralPipe,
  RoundPipe,
  TimingPipe,
  NumberWithCommasPipe,
  ReplaceLineBreaksPipe,
} from './pipes';
import {
  OneColumnLayoutComponent,
} from './layouts';
import { DEFAULT_THEME } from './styles/theme.default';
import { BreadcrumbComponent } from './components/breadcrumb/breadcrumb.component';
import { RouterModule } from '@angular/router';
import { ConfirmationDialogComponent } from './components/confirmation-dialog/confirmation-dialog.component';
import { TranslateModule } from '@ngx-translate/core';
import { DocumentViewerComponent } from './components/document-viewer/document-viewer.component';
import { NgxDocViewerModule } from 'ngx-doc-viewer';
import { UploadFileComponent } from './components/upload-file/upload-file.component';
import { EmptyDataComponent } from './components/empty-data/empty-data.component';
import { DndFileUploadDirective } from './directives/dnd-file-upload.directive';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { CompareValueDirective } from './directives/compare-value.directive';
import { ItemListComponent } from './components/item-list/item-list.component';
import { HeaderListComponent } from './components/header-list/header-list.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ListComponent } from './components/list/list.component';
import { DocumentListComponent } from './components/document-list/document-list.component';
import { SearchComponent } from './components/search/search.component';

const NB_MODULES = [
  NbLayoutModule,
  NbMenuModule,
  NbUserModule,
  NbActionsModule,
  NbSearchModule,
  NbSidebarModule,
  NbSelectModule,
  NbContextMenuModule,
  NbButtonModule,
  NbIconModule,
  NbEvaIconsModule,
  NbListModule,
  NbCardModule,
  NbButtonModule,
  NbInputModule,
  NbFormFieldModule, 
  NbDialogModule.forChild()
];
const COMPONENTS = [
  HeaderComponent,
  FooterComponent,
  TinyMCEComponent,
  OneColumnLayoutComponent,
  ConfirmationDialogComponent,
  BreadcrumbComponent,
  DocumentViewerComponent,
  UploadFileComponent,
  EmptyDataComponent,
  SpinnerComponent,
  ItemListComponent,
  HeaderListComponent,
  ListComponent,
  DocumentListComponent,
  SearchComponent
];
const PIPES_AND_DIRECTIVES = [
  CapitalizePipe,
  PluralPipe,
  RoundPipe,
  TimingPipe,
  NumberWithCommasPipe,
  ReplaceLineBreaksPipe,
  DndFileUploadDirective,
  CompareValueDirective
];

@NgModule({
  imports: [CommonModule, ...NB_MODULES, RouterModule, TranslateModule, NgxDocViewerModule, ReactiveFormsModule, FormsModule],
  exports: [CommonModule, ...PIPES_AND_DIRECTIVES, ...COMPONENTS],
  declarations: [...COMPONENTS, ...PIPES_AND_DIRECTIVES],
  providers: []
})
export class ThemeModule {
  static forRoot(): ModuleWithProviders<ThemeModule> {
    return {
      ngModule: ThemeModule,
      providers: [
        ...NbThemeModule.forRoot(
          {
            name: 'default',
          },
          [DEFAULT_THEME],
        ).providers,
      ],
    };
  }
}
