import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  title = 'Event Management';

  constructor(private _toastrService: ToastrService, private _spinnerService: NgxSpinnerService, private _router: Router){}

  ngOnInit() {
  }

  logout(): void {
    this._toastrService.success('Logout Successfull', 'Successfull');
    localStorage.removeItem('loginUserInfo');
    this._router.navigate(['login']);
  }

  get isUserLogin() {
    let existUser = localStorage.getItem('loginUserInfo');
    return existUser && existUser.length > 0;
  }
}