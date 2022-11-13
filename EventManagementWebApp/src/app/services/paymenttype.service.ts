import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaymentTypeViewModel } from '../models/paymenttype/payment-type-view-model';

@Injectable({
  providedIn: 'root'
})

export class PaymenttypeService {

  private appBaseUrl: string = 'https://localhost:7054/api/';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  constructor(private _httpClient: HttpClient) { }

  getPaymentTypes(): Observable<PaymentTypeViewModel[]> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    });  

    const getPaymentTypesUrl: string = `${this.appBaseUrl}paymentType/getPaymentTypes`;
    return this._httpClient.get<PaymentTypeViewModel[]>(getPaymentTypesUrl, { headers: asseccPermission });
  }
}