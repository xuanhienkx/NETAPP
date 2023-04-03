import { Directive, forwardRef } from '@angular/core';
import { CustomValidationService } from '../../@core/services/custom-validation.service';
import { AbstractControl, NG_ASYNC_VALIDATORS, Validator } from '@angular/forms';
import { Observable } from 'rxjs';

@Directive({
  selector: '[appValidateUserName]',
  providers: [{ provide: NG_ASYNC_VALIDATORS, useExisting: forwardRef(() => ValidateUserNameDirective), multi: true }]
})
export class ValidateUserNameDirective implements Validator {
  constructor(private customValidator: CustomValidationService) { }

  validate(control: AbstractControl): Promise<{ [key: string]: any }> | Observable<{ [key: string]: any }> {
    return this.customValidator.userNameValidator(control);
  }

}
