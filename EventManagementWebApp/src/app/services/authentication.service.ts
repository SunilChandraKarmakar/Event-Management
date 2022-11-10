import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginViewModel } from '../models/login/login-view-model';
import { RegisterViewModel } from '../models/register/register-view-model';
import { UserViewModel } from '../models/user/user-view-model';

@Injectable({
  providedIn: 'root'
})

export class AuthenticationService {

  private appBaseUrl: string = 'https://localhost:7054/api/';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  constructor(private _httpClient: HttpClient) { }

  registerUser(model: RegisterViewModel): Observable<RegisterViewModel> {
    const registerUserUrl: string = `${this.appBaseUrl}authentication/registerUser`;
    return this._httpClient.post<RegisterViewModel>(registerUserUrl, model, this.httpOptions);
  }

  login(model: LoginViewModel): Observable<UserViewModel> {
    const loginUserUrl: string = `${this.appBaseUrl}authentication/login`;
    return this._httpClient.post<UserViewModel>(loginUserUrl, model, this.httpOptions);
  }
}