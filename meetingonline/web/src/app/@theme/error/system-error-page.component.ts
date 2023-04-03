import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'vip-system-error-page',
  templateUrl: './system-error-page.component.html',
  styleUrls: ['./system-error-page.component.scss']
})
export class SystemErrorPageComponent implements OnInit {

  is404 = true;
  errorType = '404';
  message: string;
  constructor(private route: ActivatedRoute, private localizer: TranslateService) {
  }

  ngOnInit(): void {
    this.route
      .queryParams
      .subscribe(params => {
        // Defaults to 0 if no query param provided.
        this.errorType = params.error || '404';

        if (params?.messageKey) {
          this.localizer.get(params.messageKey).subscribe(m => {
            this.message = m;
          });
        }
      });
  }
}
