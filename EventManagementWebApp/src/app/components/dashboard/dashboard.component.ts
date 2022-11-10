import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})

export class DashboardComponent implements OnInit {

  private _loginUserInfo: any;
  constructor() { }

  ngOnInit() {
    this._loginUserInfo = JSON.parse(localStorage.getItem("loginUserInfo")!);
    console.log("User Info :- ", this._loginUserInfo.dataSet.id);
  }

}
