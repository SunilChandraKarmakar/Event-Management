import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VenueCreateViewModel } from '../models/venue/venue-create-view-model';
import { VenueUpdateViewModel } from '../models/venue/venue-update-view-model';
import { VenueViewModel } from '../models/venue/venue-view-model';

@Injectable({
  providedIn: 'root'
})

export class VenueService {

  private appBaseUrl: string = 'https://localhost:7054/api/';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  constructor(private _httpClient: HttpClient) { }

  getVenues(userId: string): Observable<VenueViewModel[]> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    });  

    const getAllVenuesUrl: string = `${this.appBaseUrl}venue/getVenues/${userId}`;
    return this._httpClient.get<VenueViewModel[]>(getAllVenuesUrl, { headers: asseccPermission });
  }

  create(model: VenueCreateViewModel): Observable<VenueCreateViewModel> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    }); 

    const createVenueUrl: string = `${this.appBaseUrl}venue/create`;
    return this._httpClient.post<VenueCreateViewModel>(createVenueUrl, model, { headers: asseccPermission });
  }

  getVenue(id: number): Observable<VenueUpdateViewModel> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    });

    const getVenueUrl: string = `${this.appBaseUrl}venue/getVenue/${id}`;
    return this._httpClient.get<VenueUpdateViewModel>(getVenueUrl, { headers: asseccPermission });
  }

  update(id: number, model: VenueUpdateViewModel): Observable<VenueUpdateViewModel> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    });

    const venueUpdateUrl: string = `${this.appBaseUrl}venue/update/${id}`;
    return this._httpClient.put<VenueUpdateViewModel>(venueUpdateUrl, model, { headers: asseccPermission });
  }

  delete(id: number): Observable<VenueUpdateViewModel> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    });

    const deleteVuenuUrl: string = `${this.appBaseUrl}venue/delete/${id}`;
    return this._httpClient.delete<VenueUpdateViewModel>(deleteVuenuUrl, { headers: asseccPermission });
  }
}