import { Injectable } from '@angular/core';
import { ValidatorFn, AbstractControl, FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class CustomValidationService {

  patternValidator(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } => {
      if (!control.value) {
        return null;
      }
      // {6,100}           - Assert password is between 6 and 100 characters
      // (?=.*[0-9])       - Assert a string has at least one number
      const regex = new RegExp('^(?=.*[0-9])[a-zA-Z0-9!@#$%^&*]{6,20}$');
      const valid = regex.test(control.value);
      return valid ? null : { invalidPassword: true };
    };
  }

  MatchPassword(password: string, confirmPassword: string) {
    return (formGroup: FormGroup) => {
      const passwordControl = formGroup.controls[password];
      const confirmPasswordControl = formGroup.controls[confirmPassword];

      if (!passwordControl || !confirmPasswordControl) {
        return null;
      }

      if (confirmPasswordControl.errors && !confirmPasswordControl.errors.passwordMismatch) {
        return null;
      }

      if (passwordControl.value !== confirmPasswordControl.value) {
        confirmPasswordControl.setErrors({ passwordMismatch: true });
      } else {
        confirmPasswordControl.setErrors(null);
      }
    };
  }

  isLessThen(sourceKey: string, available: string) {
    return (formGroup: FormGroup) => {
      const sourceControl = formGroup.controls[sourceKey];
      const availableControl = formGroup.controls[available];
      if (!sourceControl || !availableControl) {
        return null;
      }
      if (isNaN(sourceControl.value) || isNaN(availableControl.value)) {
        return null;
      }

      if (sourceControl.value > availableControl.value) {
        sourceControl.setErrors({ invalidLessThen: true });
      } else {
        sourceControl.setErrors(null);
      }
    };
  }

  userNameValidator(userControl: AbstractControl) {
    return new Promise(resolve => {
      setTimeout(() => {
        if (this.validateUserName(userControl.value)) {
          resolve({ userNameNotAvailable: true });
        } else {
          resolve(null);
        }
      }, 1000);
    });
  }

  validateUserName(userName: string) {
    const UserList = ['manager', 'admin', 'user', 'superuser'];
    return (UserList.indexOf(userName) > -1);
  }
}
