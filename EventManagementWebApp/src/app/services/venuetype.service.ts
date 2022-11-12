import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VenueTypeViewModel } from '../models/venuetype/venuetype-view-model';

@Injectable({
  providedIn: 'root'
})
export class VenuetypeService {

  private appBaseUrl: string = 'https://localhost:7054/api/';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  constructor(private _httpClient: HttpClient) { }

  getVenueTypes(): Observable<VenueTypeViewModel[]> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    });  

    const getVenueTypesUrl: string = `${this.appBaseUrl}venueType/getVenueTypes`;
    return this._httpClient.get<VenueTypeViewModel[]>(getVenueTypesUrl, { headers: asseccPermission });
  }
}