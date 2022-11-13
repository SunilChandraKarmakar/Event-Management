import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaymentCreateViewModel } from '../models/payment/payment-create-view-model';
import { PaymentViewModel } from '../models/payment/payment-view-model';

@Injectable({
  providedIn: 'root'
})

export class PaymentService {

  private appBaseUrl: string = 'https://localhost:7054/api/';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  constructor(private _httpClient: HttpClient) { }

  getPayments(userId: string): Observable<PaymentViewModel[]> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    });  

    const getAllpaymentsUrl: string = `${this.appBaseUrl}payment/getPayments/${userId}`;
    return this._httpClient.get<PaymentViewModel[]>(getAllpaymentsUrl, { headers: asseccPermission });
  }

  create(model: PaymentCreateViewModel): Observable<PaymentCreateViewModel> {
    let userInfo = JSON.parse(localStorage.getItem('loginUserInfo')!);
    const asseccPermission = new HttpHeaders ({
      'Authorization' : `Bearer ${userInfo.dataSet.token}`
    }); 

    const createPaymentUrl: string = `${this.appBaseUrl}payment/create`;
    return this._httpClient.post<PaymentCreateViewModel>(createPaymentUrl, model, { headers: asseccPermission });
  }
}