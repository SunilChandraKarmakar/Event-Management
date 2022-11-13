import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { PaymentViewModel } from 'src/app/models/payment/payment-view-model';
import { PaymentService } from 'src/app/services/payment.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})

export class DashboardComponent implements OnInit {

  // Login user id
  private _loginUserId: string | undefined;
  private _loginUserInfo: any;

  // Payments
  payments: PaymentViewModel[];

  // Datatable settings
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private _paymentService: PaymentService, private _spinnerService: NgxSpinnerService, 
  private _toastrService: ToastrService, private _router: Router) { }

  ngOnInit() {
    this._spinnerService.show();
    this.getLoginUserInfo();
    this.getPayments();

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10
    };

    this._spinnerService.hide();
  }

  private getLoginUserInfo(): void {
    this._loginUserInfo = JSON.parse(localStorage.getItem("loginUserInfo")!);
    
    if(this._loginUserInfo == null || this._loginUserInfo == undefined) {
      this._toastrService.error("You can not login user! Please, login first.", "Error");
      this._router.navigate(['/login']);
    }
    else {
      this._loginUserId = this._loginUserInfo.dataSet.id;
    }
  }

  private getPayments(): void {
    this._spinnerService.show();
    this._paymentService.getPayments(this._loginUserId!).subscribe((res) => {
      this.payments = res;
      this.dtTrigger.next();
      this._spinnerService.hide();
      return;
    },
    (error) => {
      this._spinnerService.hide();
      console.log("Error :- ", error);
      this._toastrService.error(error, "Error");
      return;
    })
  }

  ngOnDestroy(): void {
    // Do not forget to unsubscribe the event
    this.dtTrigger.unsubscribe();
  }
}