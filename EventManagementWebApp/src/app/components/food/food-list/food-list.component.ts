import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { FoodViewModel } from 'src/app/models/food/food-view-model';
import { FoodService } from 'src/app/services/food.service';

@Component({
  selector: 'app-food-list',
  templateUrl: './food-list.component.html',
  styleUrls: ['./food-list.component.scss']
})
export class FoodListComponent implements OnInit {

  // Login user id
  private _loginUserId: string | undefined;
  private _loginUserInfo: any;

  // Foods
  foods: FoodViewModel[];

  // Datatable settings
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private _foodService: FoodService, private _spinnerService: NgxSpinnerService, 
  private _toastrService: ToastrService, private _router: Router) { }

  ngOnInit() {
    this._spinnerService.show();
    this.getLoginUserInfo();
    this.getFoods();

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

  private getFoods(): void {
    this._spinnerService.show();
    this._foodService.getFoods(this._loginUserId!).subscribe((res) => {
      this.foods = res;
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

  onDelete(id: number): void {
    if(id == null) {
      this._toastrService.warning("Id can not find! Try again", "Warning");
      return
    }

    this._spinnerService.show();
    this._foodService.delete(id).subscribe((res) => {
      this._spinnerService.hide();
      this._toastrService.success("Food delete successfull.", "Successfull");
      this.ngOnInit();
    },
    (error) => {
      this._spinnerService.hide();
      this._toastrService.error("Food can not deleted! Try again.", "Error");
      return;
    });
  }
}