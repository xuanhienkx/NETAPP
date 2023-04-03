import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserInfoService } from 'src/app/@core/services/user-info.service';
import { ApiService } from 'src/app/@core/services/api.service';
import { LoggedInUser } from 'src/app/@core/models/user.model';

@Component({
  selector: 'vip-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  frm: FormGroup;
  user: LoggedInUser;

  constructor(
    fb: FormBuilder,
    private userInfo: UserInfoService,
    private api: ApiService
  ) {

    this.user = this.userInfo.user;
    this.frm = fb.group({
      id: [this.user?.id],
      name: [this.user?.displayName, [Validators.required]],
      language: [this.user?.language],
      vi: [this.user?.language === 'vi']
    });

    this.f.vi.valueChanges.subscribe(isVi => {
      const lang = isVi ? 'vi' : 'en';
      this.api.patchToReturn<boolean>(`user/${this.f.id.value}/language/${lang}`)
        .subscribe(x => {
          if (x) {
            this.user.language = lang;
            this.userInfo.user = this.user;
          }
        });
    });
  }

  ngOnInit(): void {
  }

  get f() {
    return this.frm.controls;
  }

  submit() {

  }
}
