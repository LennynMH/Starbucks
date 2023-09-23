import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { catchError, map } from 'rxjs';
import { ServiceBase } from './serviceBase.service';
import { IncomeWebApi } from '../constant';

@Injectable({ providedIn: 'root' })

export class OrdenService extends ServiceBase {
  readonly baseURL = environment.api;

  constructor(private http: HttpClient) {
    super();
  }

  Listar(params: any) {
    const endpointUrl = this.baseURL + IncomeWebApi.OrdenListar;
    let headers = this.GetHeader();
    return this.http.post(endpointUrl, params, headers).pipe(
      map((response: any) => {
        return response;
      }), catchError(err => {
        throw err;
      }),
    );
  }

  Select(id) {
    let headers = this.GetHeader();
    const endpointUrl = this.baseURL + IncomeWebApi.OrdenListarById;
    return this.http.get(endpointUrl + "?IdOrden=" + id, headers).pipe(
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
    const endpointUrl = this.baseURL + IncomeWebApi.OrdenRegistrar;
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
    const endpointUrl = this.baseURL + IncomeWebApi.OrdenActualizar;
    return this.http.put(endpointUrl, params, headers).pipe(
      map((response: any) => {
        return response;
      }),
      catchError(err => {
        throw err;
      }),
    );
  }

  Delete(idOrden: number, idEstado: number /*params: any*/) {
    let headers = this.GetHeader();
    const endpointUrl = this.baseURL + IncomeWebApi.OrdenEliminar;
    return this.http.delete(endpointUrl + '/' + idOrden + '/' + idEstado, headers).pipe(
      map((response: any) => {
        return response;
      }),
      catchError(err => {
        throw err;
      }),
    );
  }
}
