import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EventTypeViewModel } from '../models/eventtype/eventtype-view-model';

@Injectable({
  providedIn: 'root'
})

export class EventtypeService {

  private appBaseUrl: string = 'https://localhost:7054/api/';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  constructor(private _httpClient: HttpClient) { }

  getEventTypes(): Observable<EventTypeViewModel[]> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    });  

    const getEventTypesUrl: string = `${this.appBaseUrl}eventType/getEventTypes`;
    return this._httpClient.get<EventTypeViewModel[]>(getEventTypesUrl, { headers: asseccPermission });
  }
}