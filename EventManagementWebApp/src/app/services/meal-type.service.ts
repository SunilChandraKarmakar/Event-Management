import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MealTypeViewModel } from '../models/mealtype/meal-type-view-model';

@Injectable({
  providedIn: 'root'
})

export class MealTypeService {

  private appBaseUrl: string = 'https://localhost:7054/api/';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  constructor(private _httpClient: HttpClient) { }

  getMealTypes(): Observable<MealTypeViewModel[]> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    });  

    const getMealTypesUrl: string = `${this.appBaseUrl}mealType/getMealTypes`;
    return this._httpClient.get<MealTypeViewModel[]>(getMealTypesUrl, { headers: asseccPermission });
  }
}