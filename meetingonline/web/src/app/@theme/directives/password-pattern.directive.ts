import { Directive } from '@angular/core';
import { AbstractControl, Validator } from '@angular/forms';
import { CustomValidationService } from '../../@core/services/custom-validation.service';

@Directive({
  selector: '[appPasswordPattern]'
})
export class PasswordPatternDirective implements Validator {

  constructor(private customValidator: CustomValidationService) { }

  validate(control: AbstractControl): { [key: string]: any } | null {
    return this.customValidator.patternValidator()(control);
  }

}
