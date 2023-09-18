import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { catchError, map } from 'rxjs';
import { ServiceBase } from './serviceBase.service';
import { IncomeWebApi } from '../../shared/constant';

@Injectable({ providedIn: 'root' })

export class RolService extends ServiceBase {
  readonly baseURL = environment.api;

  constructor(private http: HttpClient) {
    super();
  }
  Listar(params: any) {
    const endpointUrl = this.baseURL + IncomeWebApi.RolListar;
    let headers = this.GetHeader();
    return this.http.post(endpointUrl, {}, headers).pipe(
      map((response: any) => {
        return response;
      }), catchError(err => {
        throw err;
      }),
    );
  }

  Select(id) {
    let headers = this.GetHeader();
    const endpointUrl = this.baseURL + IncomeWebApi.RolListarById;
    return this.http.get(endpointUrl + "?IdRol=" + id, headers).pipe(
      map((response: any) => {
        return response;
      }),
      catchError(err => {
        throw err;
      }),
    );
  }

  Insert(params: any) {
    let headers = this.GetHeader();
    const endpointUrl = this.baseURL + IncomeWebApi.RolRegistrar;
    return this.http.post(endpointUrl, params, headers).pipe(
      map((response: any) => {
        return response;
      }),
      catchError(err => {
        throw err;
      }),
    );
  }

  Update(params: any) {
    let headers = this.GetHeader();
    const endpointUrl = this.baseURL + IncomeWebApi.RolActualizar;
    return this.http.put(endpointUrl, params, headers).pipe(
      map((response: any) => {
        return response;
      }),
      catchError(err => {
        throw err;
      }),
    );
  }

  Delete(id: number) {
    let headers = this.GetHeader();
    const endpointUrl = this.baseURL + IncomeWebApi.RolEliminar;
    return this.http.delete(endpointUrl + '/' + id, headers).pipe(
      map((response: any) => {
        return response;
      }),
      catchError(err => {
        throw err;
      }),
    );
  }
}
