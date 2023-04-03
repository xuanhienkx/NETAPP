import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { Attendee, ElectionMatter, ElectionOption, Meeting } from 'src/app/@core/models/meeting.model';
import { FormGroup, FormBuilder, Validators, FormArray, AbstractControl } from '@angular/forms';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { ApiService } from 'src/app/@core/services/api.service';
import { ConfirmationDialogService } from 'src/app/@core/services/confirmation-dialog.service';
import { takeWhile, startWith, pairwise } from 'rxjs/operators';
import { VipBooleanInput, convertToBoolProperty } from 'src/app/@core/utils/utils';

@Component({
  selector: 'vip-vote-confirm',
  templateUrl: './vote-confirm.component.html',
  styleUrls: ['./vote-confirm.component.scss']
})
export class VoteConfirmComponent implements OnInit, OnDestroy {
  @Input()
  get isOnline(): boolean {
    return this._checkOnline;
  }
  set isOnline(value: boolean) {
    this._checkOnline = convertToBoolProperty(value);
  }
  protected _checkOnline = false;
  // tslint:disable-next-line:member-ordering
  static ngAcceptInputType_checkOnline: VipBooleanInput;

  @Input() attendee: Attendee;
  @Input() mt: Meeting;
  @Input() items: ElectionMatter[];

  frm: FormGroup;
  submitted = false;
  isOnAir = true;
  constructor(
    private fb: FormBuilder,
    private appState: AppStateProvider,
    private api: ApiService,
    private confirm: ConfirmationDialogService
  ) {

    this.frm = this.fb.group({
      items: fb.array([])
    });

  }

  ngOnInit(): void {

    this.bindForms(this.items);
  }


  ngOnDestroy(): void {
    this.isOnAir = false;
  }


  get votes() {
    return this.frm.controls.items as FormArray;
  }

  private bindForms(matters: ElectionMatter[]) {
    matters.forEach(m => {
      this.votes.push(this.voteEditor(m));
    });
  }

  private voteEditor(matter: ElectionMatter): FormGroup {
    if (!matter.optional) {
      matter.options.forEach(x => x.votes = this.attendee.totalVotes);
      return this.fb.group({
        id: matter.id,
        optional: matter.optional,
        votes: this.attendee.totalVotes,
        option: matter.options.find(x => x.name === 'vote.options.yes')
      });
    }

    const totalVotes = matter.taken * this.attendee.totalVotes;
    const matterCtl = this.fb.group({
      id: matter.id,
      optional: matter.optional,
      votes: [0, Validators.max(totalVotes)],
      taken: [0, Validators.max(matter.taken)],
      options: this.fb.array([])
    });

    matterCtl.registerControl('selectAll', this.selector(() => this.updateEditorStatus(matterCtl, matter, totalVotes)));
    matter.options.forEach(o => {
      (matterCtl.get('options') as FormArray).push(this.optionEditor(matterCtl, matter, o, totalVotes));
    });

    matterCtl.get('selectAll').setValue(true);
    return matterCtl;
  }

  private optionEditor(matterCtl: FormGroup, matter: ElectionMatter, item: ElectionOption, totalVotes: number): FormGroup {
    const optCtl = this.fb.group({
      id: item.id,
      name: item.name,
      votes: 0,
      selector: this.selector(val => {
        const takenCtl = matterCtl.get('taken');
        if (val) {
          takenCtl.setValue(takenCtl.value + 1);
        } else {
          const votes = (matterCtl.get('options') as FormArray).controls
            .find(x => x.get('id').value === item.id)
            .get('votes');
          if (votes.value !== 0) {
            votes.setValue(0);
          }

          takenCtl.setValue(takenCtl.value - 1);
        }

        this.updateEditorStatus(matterCtl, matter, totalVotes);
      })
    });

    optCtl.get('votes').valueChanges.pipe(
      takeWhile(() => this.isOnAir),
      startWith(0),
      pairwise()
    ).subscribe(([prv, val]) => {
      if (prv !== val) {
        const voteCtl = matterCtl.get('votes');
        voteCtl.setValue(voteCtl.value - prv + val);

        if (optCtl.get('selector').value !== val > 0) {
          optCtl.get('selector').setValue(val > 0);
        }
      }
    });

    return optCtl;
  }

  private selector(valueChanged: (val: boolean) => void) {
    const ctl = this.fb.control({ value: false, disabled: false });
    ctl.valueChanges.pipe(
      takeWhile(() => this.isOnAir),
      startWith(false),
      pairwise()
    ).subscribe(([prv, val]) => {
      if (prv !== val) {
        valueChanged(val);
      }
    });

    return ctl;
  }

  private updateEditorStatus(matterCtl: FormGroup, matter: ElectionMatter, totalVotes: number) {
    const options = matterCtl.get('options') as FormArray;

    if (matterCtl.get('selectAll').value) {
      let selIds = options.controls
        .filter(x => x.get('selector').value)
        .map(x => x.get('id').value);

      if (selIds.length === 0) {
        selIds = options.controls.slice(0, matter.taken).map(x => x.get('id').value);
      } else if (selIds.length >= matter.taken) {
        selIds = selIds.slice(0, matter.taken);
      }

      const votes = totalVotes / selIds.length;
      options.controls.forEach(o => {
        if (selIds.includes(o.get('id').value)) {
          o.get('votes').setValue(votes);
          this.setEditorStatus(o, selIds.length !== 1);
        } else {
          o.get('votes').setValue(0);
          this.setEditorStatus(o, selIds.length !== matter.taken);
        }
      });
    } else {
      const taken = matterCtl.get('taken').value;
      options.controls.forEach(o => {
        if (taken >= matter.taken) {
          this.setEditorStatus(o, o.get('selector').value);
        } else {
          this.setEditorStatus(o.get('selector'), true);
        }
        this.setEditorStatus(o.get('votes'), matterCtl.get('votes').value < totalVotes);
      });
    }
  }

  private setEditorStatus(o: AbstractControl, isEnabled: boolean) {
    if (isEnabled) {
      o.enable();
    } else {
      o.disable();
    }
  }

  onSubmit() {
    this.confirm.confirmWithConfig({ message: 'vote.submit.confirm' })
      .then((confirm) => {
        if (confirm.isConfirm === true) {
          const url = this.isOnline
            ? `meeting/${this.mt.id}/vote`
            : `meeting/${this.mt.id}/attendee/${this.attendee.id}/vote`;
          const optCtls = [];
          this.votes.controls
            .filter(x => x.get('optional').value)
            .forEach(x => (x.get('options') as FormArray).controls
              .filter(o => o.get('id').disabled)
              .forEach(d => {
                d.enable();
                optCtls.push(d);
              }));

          const voteItems = this.votes.value;
          voteItems.filter(x => !x.optional)
            .forEach(x => {
              x.options = [x.option];
            });

          optCtls.forEach(x => x.disable());

          this.api.putToReturn<boolean>(url, voteItems)
            .subscribe(r => {
              if (r) {
                this.appState.message$.next({ msg: 'vote.submit.success', title: 'vote.submit.title' });
                this.attendee.votes = voteItems;
              }
            });
        }
      });
  }

}
