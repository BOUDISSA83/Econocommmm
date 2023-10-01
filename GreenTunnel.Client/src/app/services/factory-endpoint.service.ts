import { Injectable } from '@angular/core';
import { ConfigurationService } from './configuration.service';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { EndpointBase } from './endpoint-base.service';
import { AuthService } from './auth.service';
import { EntityType } from '../models/enums';

@Injectable()
export class FactoryEndpointService extends EndpointBase  {
    get factoriesUrl() { return this.configurations.baseUrl + '/api/factory'; }
    get workspacesUrl() { return this.configurations.baseUrl + '/api/workspace'; }
    get workplacesUrl() { return this.configurations.baseUrl + '/api/workplace'; }

    constructor(private configurations: ConfigurationService, http: HttpClient,authService: AuthService) {
        super(http, authService)
    }
    getFactoriesEndpoint<T>(page?: number, pageSize?: number,searchTerm?:string,sortColumn?:string,sortOrder?:string): Observable<T> {
        const endpointUrl = page && pageSize ? `${this.factoriesUrl}/Allfactories?pageNumber=${page}&pageSize=${pageSize}&searchTerm=${searchTerm}&sortColumn=${sortColumn}/sortOrder?=${sortOrder}` : this.factoriesUrl;

        return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
            catchError<T, Observable<T>>((error:any) => {
                return this.handleError(error, () => this.getFactoriesEndpoint(page, pageSize));
            }));
    }
    getFactoriesListEndpoint<T>(): Observable<T> {
        const endpointUrl = `${this.factoriesUrl}/factories`;

        return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
            catchError<T, Observable<T>>((error:any) => {
                return this.handleError(error, () => this.getFactoriesEndpoint());
            }));
    }
    getNewFactoryEndpoint<T>(factoriyObject: any): Observable<T> {

        return this.http.post<T>(this.factoriesUrl, JSON.stringify(factoriyObject), this.requestHeaders).pipe<T>(
            catchError<T, Observable<T>>(error => {
                return this.handleError(error, () => this.getNewFactoryEndpoint(factoriyObject));
            }));
    }
    getUpdateFactoryEndpoint<T>(factoriyObject: any, id?: number): Observable<T> {
        const endpointUrl = `${this.factoriesUrl}/${id}`;

        return this.http.put<T>(endpointUrl, JSON.stringify(factoriyObject), this.requestHeaders).pipe<T>(
            catchError<T, Observable<T>>(error => {
                return this.handleError(error, () => this.getUpdateFactoryEndpoint(factoriyObject, id));
            }));
    }
    getFactoryEndpoint<T>(factoryId?: string): Observable<T> {
        const endpointUrl = `${this.factoriesUrl}/${factoryId}`;

        return this.http.get<T>(endpointUrl, this.requestHeaders).pipe(
            catchError<T, Observable<T>>(error => {
                return this.handleError(error, () => this.getFactoryEndpoint(factoryId));
            })
        );

    }
    getDeleteFactoryEndpoint<T>(factoryId: string): Observable<T> {
        const endpointUrl = `${this.factoriesUrl}/${factoryId}`;

        return this.http.delete<T>(endpointUrl, this.requestHeaders).pipe<T>(
            catchError<T, Observable<T>>(error => {
                return this.handleError(error, () => this.getDeleteFactoryEndpoint(factoryId));
            }));
    }
    getFactoryDuplicateStatusEndpoint<T>(factoryId:number,entityType:EntityType,factoryName?: string): Observable<T> {
        let endpointUrl: string;

        switch (entityType) {
            case EntityType.Factory:
                endpointUrl = `${this.factoriesUrl}/validateDuplicateName/${factoryName}/factoryId/${factoryId}`;
                break;
            case EntityType.Workplace:
                endpointUrl = `${this.workplacesUrl}/validateDuplicateName/${factoryName}/workplaceId/${factoryId}`;
                break;
            case EntityType.Workspace:
                endpointUrl = `${this.workspacesUrl}/validateDuplicateName/${factoryName}/workspaceId/${factoryId}`;

                break;
            default:
                // Handle a default case if needed
                break;
        }

        return this.http.get<T>(endpointUrl, this.requestHeaders).pipe(
            catchError<T, Observable<T>>(error => {
                return this.handleError(error, () => this.getFactoryDuplicateStatusEndpoint(factoryId,entityType,factoryName));
            })
        );

    }
}
