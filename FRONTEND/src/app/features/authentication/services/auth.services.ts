import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { map } from 'rxjs';
import { IncomeWebApi } from '../../../shared/constant';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  readonly baseURL = environment.api;

  constructor(private http: HttpClient) { }

  Autenticar(params: any) {
    const endpointUrl = this.baseURL + IncomeWebApi.Login;
    return this.http.post(encodeURI(endpointUrl), params).pipe(
      map((response: any) => {
        return response;
      })
    );
  }
}
