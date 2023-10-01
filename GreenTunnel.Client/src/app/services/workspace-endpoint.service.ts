import { Injectable } from '@angular/core';
import { ConfigurationService } from './configuration.service';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { EndpointBase } from './endpoint-base.service';
import { AuthService } from './auth.service';

@Injectable()
export class WorkspaceEndpointService extends EndpointBase  {
  get workspacesUrl() { return this.configurations.baseUrl + '/api/workspace'; }

  constructor(private configurations: ConfigurationService, http: HttpClient,authService: AuthService) {
    super(http, authService)
  }
  getWorkspacesEndpoint<T>(workplaceId?:number,page?: number, pageSize?: number,searchTerm?:string,sortColumn?:string,sortOrder?:string): Observable<T> {
    const endpointUrl = page && pageSize ? `${this.workspacesUrl}/Allworkspaces?pageNumber=${page}&pageSize=${pageSize}&searchTerm=${searchTerm}&sortColumn=${sortColumn}/sortOrder?=${sortOrder}&workplaceId=${workplaceId}` : this.workspacesUrl;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>((error:any) => {
        return this.handleError(error, () => this.getWorkspacesEndpoint(page, pageSize));
      }));
  }
  getWorkspacesListEndpoint<T>(): Observable<T> {debugger
    const endpointUrl = `${this.workspacesUrl}/workspaces`;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>((error:any) => {
        return this.handleError(error, () => this.getWorkspacesEndpoint());
      }));
  }
  getNewWorkspaceEndpoint<T>(workspaceObject: any): Observable<T> {

    return this.http.post<T>(this.workspacesUrl, JSON.stringify(workspaceObject), this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>(error => {
        return this.handleError(error, () => this.getNewWorkspaceEndpoint(workspaceObject));
      }));
  }
  getUpdateWorkspaceEndpoint<T>(workspaceObject: any, id?: number): Observable<T> {
    const endpointUrl = `${this.workspacesUrl}/${id}`;

    return this.http.put<T>(endpointUrl, JSON.stringify(workspaceObject), this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>(error => {
        return this.handleError(error, () => this.getUpdateWorkspaceEndpoint(workspaceObject, id));
      }));
  }
  getWorkspaceEndpoint<T>(WorkspaceId?: string): Observable<T> {
    const endpointUrl = `${this.workspacesUrl}/${WorkspaceId}`;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe(
      catchError<T, Observable<T>>(error => {
        return this.handleError(error, () => this.getWorkspaceEndpoint(WorkspaceId));
      })
    );

  }
  getDeleteWorkspaceEndpoint<T>(WorkspaceId: string): Observable<T> {
    const endpointUrl = `${this.workspacesUrl}/${WorkspaceId}`;

    return this.http.delete<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError<T, Observable<T>>(error => {
        return this.handleError(error, () => this.getDeleteWorkspaceEndpoint(WorkspaceId));
      }));
  }
  getWorkplaceDuplicateStatusEndpoint<T>(workspacName?: string): Observable<T> {
    const endpointUrl = `${this.workspacesUrl}/validateDuplicateName/${workspacName}`;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe(
      catchError<T, Observable<T>>(error => { 
        return this.handleError(error, () => this.getWorkplaceDuplicateStatusEndpoint(workspacName));
      })
    );
    
  }
}
