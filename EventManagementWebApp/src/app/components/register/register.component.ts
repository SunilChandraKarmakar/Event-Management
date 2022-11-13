import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { RegisterViewModel } from 'src/app/models/register/register-view-model';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent implements OnInit {

  model: RegisterViewModel = new RegisterViewModel();
  constructor(private _formBuilder: FormBuilder, private _authenticationService: AuthenticationService, private _toastr: ToastrService, private _spinnerService: NgxSpinnerService, private _router: Router) { }

  registerForm: FormGroup = this._formBuilder.group({
    fullName: ['', Validators.required],
    email: ['', [Validators.email, Validators.required]],
    password: ['', Validators.required],
    mobileNumber: ['', Validators.required],
    address: ['', Validators.required]
  });

  ngOnInit() {
    this._spinnerService.show();
    this._spinnerService.hide();
  }

  onFormSubmit(): void {
    this.model = this.registerForm.value;

    if(this.model.fullName == '' || this.model.fullName == undefined || this.model.fullName == null) {
      this._toastr.warning('Please, provied full name', 'Full Name');
      return;
    }
    else if(this.model.email == '' || this.model.email == undefined || this.model == null) {
      this._toastr.warning('Please, provied valid email', 'Valid Email');
      return;
    }
    else if(this.model.password == '' || this.model.password == undefined || this.model.password == null) {
      this._toastr.warning('Please, provied pasword', 'Password');
      return;
    }
    else {
      this._spinnerService.show();
      this._authenticationService.registerUser(this.model).subscribe((res) => {
        this._spinnerService.hide();
        this._toastr.success('Register Successfull', 'Successfull');
        return this._router.navigate(['login']);
      },
      (error) => {
        this._spinnerService.hide();
        this._toastr.error(error.error.dataSet, 'Error');
        return;
      });
    }
  }
}