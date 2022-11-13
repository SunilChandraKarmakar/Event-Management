import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { FoodViewModel } from 'src/app/models/food/food-view-model';
import { PaymentCreateViewModel } from 'src/app/models/payment/payment-create-view-model';
import { PaymentTypeViewModel } from 'src/app/models/paymenttype/payment-type-view-model';
import { VenueViewModel } from 'src/app/models/venue/venue-view-model';
import { FoodService } from 'src/app/services/food.service';
import { PaymentService } from 'src/app/services/payment.service';
import { PaymenttypeService } from 'src/app/services/paymenttype.service';
import { VenueService } from 'src/app/services/venue.service';

@Component({
  selector: 'app-payment-create',
  templateUrl: './payment-create.component.html',
  styleUrls: ['./payment-create.component.scss']
})

export class PaymentCreateComponent implements OnInit {

  // Login user id
  private _loginUserId: string | undefined;
  private _loginUserInfo: any;

  // Payment create view model
  model: PaymentCreateViewModel = new PaymentCreateViewModel();

  // Select list model
  paymentTypeSelectList: PaymentTypeViewModel[];
  foodSelectList: FoodViewModel[];
  venueSelectList: VenueViewModel[];
  
  constructor(private _paymentService: PaymentService, private _spinnerService: NgxSpinnerService, 
  private _toastrService: ToastrService, private _router: Router, private _paymentTypeService: PaymenttypeService, private _foodService: FoodService, private _venueService: VenueService) { }

  ngOnInit() {
    this._spinnerService.show();
    this.getLoginUserInfo();
    this.getPaymentTypes();
    this.getFoods();
    this.getVenues();
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

  private getPaymentTypes(): void {
    this._spinnerService.show();
    this._paymentTypeService.getPaymentTypes().subscribe((res) => {
      this._spinnerService.hide();
      this.paymentTypeSelectList = res;
    },
    (error) => {
      this._spinnerService.hide();
      this._toastrService.error("Payment Types can not load! Try again.", "Error");
    })
  }

  private getFoods(): void {
    this._spinnerService.show();
    this._foodService.getFoods(this._loginUserId!).subscribe((res) => {
      this._spinnerService.hide();
      this.foodSelectList = res;
    },
    (error) => {
      this._spinnerService.hide();
      this._toastrService.error("Food can not load! Try again.", "Error");
    })
  }

  private getVenues(): void {
    this._spinnerService.show();
    this._venueService.getVenues(this._loginUserId!).subscribe((res) => {
      this._spinnerService.hide();
      this.venueSelectList = res;
    },
    (error) => {
      this._spinnerService.hide();
      this._toastrService.error("Venue can not load! Try again.", "Error");
    })
  }

  onSavePayment(): void {
    if(this.model.foodId == null || this.model.foodId == undefined) {
      this._toastrService.warning("Please, select food.", "Warning");
      return;
    }
    else if(this.model.venueId == null || this.model.venueId == undefined) {
      this._toastrService.warning("Please, select venue type.", "Warning");
      return;
    }
    else if(this.model.paymentTypeId == null || this.model.paymentTypeId == undefined) {
      this._toastrService.warning("Please, select payment type.", "Warning");
      return;
    }
    else if(this.model.totalAmmount == null || this.model.totalAmmount == undefined) {
      this._toastrService.warning("Please, provied total amount.", "Warning");
      return;
    }
    else {
      this._spinnerService.show();
      this.model.userId = this._loginUserId!;
      this.model.isPaymentComplete = true;
      this._paymentService.create(this.model).subscribe((res) => {
        this._spinnerService.hide();
        this._toastrService.success("Payment successfull.", "Successfull");
        this._router.navigate(['/dashboard']);
        return;
      }, 
      (error) => {
        this._spinnerService.hide();
        this._toastrService.error("Payment can not created! Try again.", "Error");
        return;
      })
    }
  }
}