import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DishTypeViewModel } from '../models/dishtype/dish-type-view-model';

@Injectable({
  providedIn: 'root'
})

export class DishTyprService {

  private appBaseUrl: string = 'https://localhost:7054/api/';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  constructor(private _httpClient: HttpClient) { }

  getDishTypes(): Observable<DishTypeViewModel[]> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    });  

    const getDishTypesUrl: string = `${this.appBaseUrl}dishType/getDishTypes`;
    return this._httpClient.get<DishTypeViewModel[]>(getDishTypesUrl, { headers: asseccPermission });
  }
}