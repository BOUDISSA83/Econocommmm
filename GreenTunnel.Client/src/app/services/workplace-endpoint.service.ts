
import { Injectable } from '@angular/core';
import { ConfigurationService } from './configuration.service';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { EndpointBase } from './endpoint-base.service';
import { AuthService } from './auth.service';

@Injectable()
export class WorkplaceEndpointService extends EndpointBase  {
  get workplacesUrl() { return this.configurations.baseUrl + '/api/workplace'; }

  constructor(private configurations: ConfigurationService, http: HttpClient,authService: AuthService) {
    super(http, authService)
  }
  getWorkplacesEndpoint<T>(factoryId?:number,page?: number, pageSize?: number,searchTerm?:string,sortColumn?:string,sortOrder?:string): Observable<T> {debugger
    const endpointUrl = page && pageSize ? `${this.workplacesUrl}/Allworkplaces?pageNumber=${page}&pageSize=${pageSize}&searchTerm=${searchTerm}&sortColumn=${sortColumn}/sortOrder?=${sortOrder}&factoryId=${factoryId}` : this.workplacesUrl;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>((error:any) => {
        return this.handleError(error, () => this.getWorkplacesEndpoint(page, pageSize));
      }));
  }
  getWorkplacesListEndpoint<T>(): Observable<T> {debugger
    const endpointUrl = `${this.workplacesUrl}/workplaces`;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>((error:any) => {
        return this.handleError(error, () => this.getWorkplacesEndpoint());
      }));
  }
  getNewWorkplaceEndpoint<T>(workplaceObject: any): Observable<T> {

    return this.http.post<T>(this.workplacesUrl, JSON.stringify(workplaceObject), this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>(error => {
        return this.handleError(error, () => this.getNewWorkplaceEndpoint(workplaceObject));
      }));
  }
  getUpdateWorkplaceEndpoint<T>(workplaceObject: any, id?: number): Observable<T> {debugger
    const endpointUrl = `${this.workplacesUrl}/${id}`;

    return this.http.put<T>(endpointUrl, JSON.stringify(workplaceObject), this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>(error => {
        return this.handleError(error, () => this.getUpdateWorkplaceEndpoint(workplaceObject, id));
      }));
  }
  getWorkplaceEndpoint<T>(workplaceId?: string): Observable<T> {
    const endpointUrl = `${this.workplacesUrl}/${workplaceId}`;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe(
      catchError<T, Observable<T>>(error => {
        return this.handleError(error, () => this.getWorkplaceEndpoint(workplaceId));
      })
    );
    
  }
  getDeleteWorkplaceEndpoint<T>(workplaceId: string): Observable<T> {
    const endpointUrl = `${this.workplacesUrl}/${workplaceId}`;

    return this.http.delete<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>(error => {
        return this.handleError(error, () => this.getDeleteWorkplaceEndpoint(workplaceId));
      }));
  }
}
