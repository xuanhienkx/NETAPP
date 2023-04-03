import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthenService } from 'src/app/@core/services/authen.service';

@Component({
  selector: 'app-verify',
  templateUrl: './verify.component.html',
  styleUrls: ['./verify.component.scss']
})

export class VerifyComponent implements OnInit {
  model: any;
  signup = false;
  constructor(private route: ActivatedRoute, private authen: AuthenService) {

  }

  ngOnInit(): void {

    this.route.queryParamMap.subscribe(queryParams => {
      this.model = {
        type: 'email',
        userId: queryParams.get('userId'),
        token: queryParams.get('token')
      };
      if (this.model?.token) {
        this.signup = true;
      }
    });
  }
  virify() {
    this.authen.verify(this.model);
  }
}
