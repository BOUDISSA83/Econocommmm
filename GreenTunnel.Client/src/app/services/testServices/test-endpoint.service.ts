import { Injectable } from '@angular/core';
import { ConfigurationService } from '../configuration.service';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { EndpointBase } from '../endpoint-base.service';
import { AuthService } from '../auth.service';

@Injectable()
export class TestEndpointService extends EndpointBase  {
  get testsUrl() { return this.configurations.baseUrl + '/api/test'; }

  constructor(private configurations: ConfigurationService, http: HttpClient,authService: AuthService) {
    super(http, authService)
  }
  getTestsEndpoint<T>(page?: number, pageSize?: number,searchTerm?:string,sortColumn?:string,sortOrder?:string): Observable<T> {
    const endpointUrl = page && pageSize ? `${this.testsUrl}/Alltests?pageNumber=${page}&pageSize=${pageSize}&searchTerm=${searchTerm}&sortColumn=${sortColumn}/sortOrder?=${sortOrder}` : this.testsUrl;
    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>((error:any) => {
        return this.handleError(error, () => this.getTestsEndpoint(page, pageSize));
      }));
  }
  getTestsListEndpoint<T>(): Observable<T> {
    const endpointUrl = `${this.testsUrl}/tests`;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>((error:any) => {
        return this.handleError(error, () => this.getTestsEndpoint());
      }));
  }
  getNewTestEndpoint<T>(testObject: any): Observable<T> {

    return this.http.post<T>(this.testsUrl, JSON.stringify(testObject), this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>(error => {
        return this.handleError(error, () => this.getNewTestEndpoint(testObject));
      }));
  }
  getUpdateTestEndpoint<T>(testObject: any): Observable<T> {debugger
    const endpointUrl = `${this.testsUrl}`;

    return this.http.put<T>(endpointUrl, JSON.stringify(testObject), this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>(error => {
        return this.handleError(error, () => this.getUpdateTestEndpoint(testObject));
      }));
  }
  getTestEndpoint<T>(testId?: string): Observable<T> {
    const endpointUrl = `${this.testsUrl}/${testId}`;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe(
      catchError<T, Observable<T>>(error => {
        return this.handleError(error, () => this.getTestEndpoint(testId));
      })
    );
    
  }
  getDeleteTestEndpoint<T>(testId: string): Observable<T> {
    const endpointUrl = `${this.testsUrl}/${testId}`;

    return this.http.delete<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>(error => {
        return this.handleError(error, () => this.getDeleteTestEndpoint(testId));
      }));
  }
}
