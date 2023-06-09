import { Directive, Input } from '@angular/core';
import { Validator, ValidationErrors, FormGroup } from '@angular/forms';
import { CustomValidationService } from '../../@core/services/custom-validation.service';

@Directive({
  selector: '[appMatchPassword]'
})
export class MatchPasswordDirective implements Validator {

  @Input('appMatchPassword') MatchPassword: string[] = [];

  constructor(private customValidator: CustomValidationService) { }

  validate(formGroup: FormGroup): ValidationErrors {
    return this.customValidator.MatchPassword(this.MatchPassword[0], this.MatchPassword[1])(formGroup);
  }

}
