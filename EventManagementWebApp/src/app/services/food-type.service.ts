import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FoodTypeViewModel } from '../models/foodtype/food-type-view-model';

@Injectable({
  providedIn: 'root'
})

export class FoodTypeService {

  private appBaseUrl: string = 'https://localhost:7054/api/';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  constructor(private _httpClient: HttpClient) { }

  getFoodTypes(): Observable<FoodTypeViewModel[]> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    });  

    const getFoodTypesUrl: string = `${this.appBaseUrl}foodType/getFoodTypes`;
    return this._httpClient.get<FoodTypeViewModel[]>(getFoodTypesUrl, { headers: asseccPermission });
  }
}