import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { EndpointBase } from '../endpoint-base.service';
import { ConfigurationService } from '../configuration.service';
import { AuthService } from '../auth.service';

@Injectable()
export class MouldEndpointService extends EndpointBase  {
  get mouldsUrl() { return this.configurations.baseUrl + '/api/moulds'; }

  constructor(private configurations: ConfigurationService, http: HttpClient,authService: AuthService) {
    super(http, authService)
  }
  getMouldsEndpoint<T>(workspaceId:number,page?: number, pageSize?: number): Observable<T> {
    //const endpointUrl =  this.mouldsUrl;
    debugger
    //const endpointUrl = page && pageSize ? `${this.mouldsUrl}/${page}/${pageSize}` : this.mouldsUrl;
    const endpointUrl = `${this.mouldsUrl}?id=${workspaceId}&page=${page}&pageSize=${pageSize}`;
    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>((error:any) => {
        return this.handleError(error, () => this.getMouldsEndpoint(page, pageSize));
      }));
  }
  getNewMouldEndpoint<T>(mouldObject: any): Observable<T> {

    return this.http.post<T>(this.mouldsUrl, JSON.stringify(mouldObject), this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>(error => {
        return this.handleError(error, () => this.getNewMouldEndpoint(mouldObject));
      }));
  }
  getUpdateMouldEndpoint<T>(mouldObject: any, id?: number): Observable<T> {debugger
    const endpointUrl = `${this.mouldsUrl}/${id}`;

    return this.http.put<T>(endpointUrl, JSON.stringify(mouldObject.model), this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>(error => {
        return this.handleError(error, () => this.getUpdateMouldEndpoint(mouldObject, id));
      }));
  }
  getMouldEndpoint<T>(mouldId?: number): Observable<T> {
    debugger
    const endpointUrl = `${this.mouldsUrl}/${mouldId}`;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe(
      catchError<T, Observable<T>>(error => {
        return this.handleError(error, () => this.getMouldEndpoint(mouldId));
      })
    );

  }
  getDeleteMouldEndpoint<T>(mouldId: number): Observable<T> {
    const endpointUrl = `${this.mouldsUrl}/${mouldId}`;

    return this.http.delete<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>(error => {
        return this.handleError(error, () => this.getDeleteMouldEndpoint(mouldId));
      }));
  }
}
