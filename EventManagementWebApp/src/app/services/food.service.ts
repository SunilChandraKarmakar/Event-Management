import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FoodCreateViewModel } from '../models/food/food-create-view-model';
import { FoodUpdateViewModel } from '../models/food/food-update-view-model';
import { FoodViewModel } from '../models/food/food-view-model';

@Injectable({
  providedIn: 'root'
})

export class FoodService {

  private appBaseUrl: string = 'https://localhost:7054/api/';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  constructor(private _httpClient: HttpClient) { }

  getFoods(userId: string): Observable<FoodViewModel[]> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    });  

    const getAllFoodsUrl: string = `${this.appBaseUrl}food/getFoods/${userId}`;
    return this._httpClient.get<FoodViewModel[]>(getAllFoodsUrl, { headers: asseccPermission });
  }

  create(model: FoodCreateViewModel): Observable<FoodCreateViewModel> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    }); 

    const createFoodUrl: string = `${this.appBaseUrl}food/create`;
    return this._httpClient.post<FoodCreateViewModel>(createFoodUrl, model, { headers: asseccPermission });
  }

  getFood(id: number): Observable<FoodUpdateViewModel> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    });

    const getFoodUrl: string = `${this.appBaseUrl}food/getFood/${id}`;
    return this._httpClient.get<FoodUpdateViewModel>(getFoodUrl, { headers: asseccPermission });
  }

  update(id: number, model: FoodUpdateViewModel): Observable<FoodUpdateViewModel> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    });

    const foodUpdateUrl: string = `${this.appBaseUrl}food/update/${id}`;
    return this._httpClient.put<FoodUpdateViewModel>(foodUpdateUrl, model, { headers: asseccPermission });
  }

  delete(id: number): Observable<FoodUpdateViewModel> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    });

    const deleteFoodUrl: string = `${this.appBaseUrl}food/delete/${id}`;
    return this._httpClient.delete<FoodUpdateViewModel>(deleteFoodUrl, { headers: asseccPermission });
  }
}