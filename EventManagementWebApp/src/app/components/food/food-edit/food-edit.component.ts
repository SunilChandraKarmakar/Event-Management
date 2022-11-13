import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { DishTypeViewModel } from 'src/app/models/dishtype/dish-type-view-model';
import { FoodUpdateViewModel } from 'src/app/models/food/food-update-view-model';
import { FoodTypeViewModel } from 'src/app/models/foodtype/food-type-view-model';
import { MealTypeViewModel } from 'src/app/models/mealtype/meal-type-view-model';
import { DishTyprService } from 'src/app/services/dish-typr.service';
import { FoodTypeService } from 'src/app/services/food-type.service';
import { FoodService } from 'src/app/services/food.service';
import { MealTypeService } from 'src/app/services/meal-type.service';

@Component({
  selector: 'app-food-edit',
  templateUrl: './food-edit.component.html',
  styleUrls: ['./food-edit.component.scss']
})

export class FoodEditComponent implements OnInit {

  // Login user id
  private _loginUserId: string | undefined;
  private _loginUserInfo: any;
 
  // Food create view model
  model: FoodUpdateViewModel = new FoodUpdateViewModel();
 
  // Select list model
  foodTypeSelectList: FoodTypeViewModel[];
  mealTypeSelectList: MealTypeViewModel[];
  dishTypeSelectList: DishTypeViewModel[];
 
  constructor(private _foodService: FoodService, private _spinnerService: NgxSpinnerService, 
  private _toastrService: ToastrService, private _router: Router, private _foodTypeService: FoodTypeService, private _mealTypeService: MealTypeService, private _dishTypeService: DishTyprService, private _activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this._spinnerService.show();
    this.getLoginUserInfo();
    this.getFoodTypes();
    this.getMealTypes();
    this.getDishTypes();
    this.getExistFood();
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

  private getFoodTypes(): void {
    this._spinnerService.show();
    this._foodTypeService.getFoodTypes().subscribe((res) => {
      this._spinnerService.hide();
      this.foodTypeSelectList = res;
    },
    (error) => {
      this._spinnerService.hide();
      this._toastrService.error("Food Types can not load! Try again.", "Error");
    })
  }

  private getMealTypes(): void {
    this._spinnerService.show();
    this._mealTypeService.getMealTypes().subscribe((res) => {
      this._spinnerService.hide();
      this.mealTypeSelectList = res;
    },
    (error) => {
      this._spinnerService.hide();
      this._toastrService.error("Meal Types can not load! Try again.", "Error");
    })
  }

  private getDishTypes(): void {
    this._spinnerService.show();
    this._dishTypeService.getDishTypes().subscribe((res) => {
      this._spinnerService.hide();
      this.dishTypeSelectList = res;
    },
    (error) => {
      this._spinnerService.hide();
      this._toastrService.error("Dish Types can not load! Try again.", "Error");
    })
  }

  private getExistFood(): void {
    this._activatedRoute.params.subscribe(params => {
      let venueId = params['recordId']; 
      this._foodService.getFood(venueId).subscribe((res) => {
        this._spinnerService.show();
        this.model = res;
        this._spinnerService.hide();
        return;
      },
      (error) => {
        this._spinnerService.hide();
        this._toastrService.error("Food can not find! Try again", "Error");
        return;
      });
    });
  }

  onUpdateFood(): void {
    if(this.model.title == null || this.model.title == undefined) {
      this._toastrService.warning("Please, provied title.", "Warning");
      return;
    }
    else if(this.model.foodTypeId == null || this.model.foodTypeId == undefined) {
      this._toastrService.warning("Please, select food type.", "Warning");
      return;
    }
    else if(this.model.mealTypeId == null || this.model.mealTypeId == undefined) {
      this._toastrService.warning("Please, select meal type.", "Warning");
      return;
    }
    else if(this.model.dishTypeId == null || this.model.dishTypeId == undefined) {
      this._toastrService.warning("Please, select dish type.", "Warning");
      return;
    }
    else if(this.model.foodAmount == null || this.model.foodAmount == undefined) {
      this._toastrService.warning("Please, provied amount.", "Warning");
      return;
    }
    else {
      this._spinnerService.show();
      this._foodService.update(this.model.id, this.model).subscribe((res) => {
        this._spinnerService.hide();
        this._toastrService.success("Food update successfull.", "Successfull");
        this._router.navigate(['/foods']);
        return;
      }, 
      (error) => {
        this._spinnerService.hide();
        this._toastrService.error("Food can not updated! Try again.", "Error");
        return;
      })
    }
  }
}