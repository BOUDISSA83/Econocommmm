import { Injectable } from '@angular/core';
import { RolesChangedEventArg, RolesChangedOperation } from './account.service';
import { Observable, Subject, mergeMap } from 'rxjs';
import { FactoryEndpointService } from './factory-endpoint.service';
import { Factory } from '../models/factory.model';
import { FactoryRequest } from '../models/factory-request.model';
import { FactoryList } from '../models/factories-list.model';
import { EntityType } from '../models/enums';

@Injectable()
export class FactoryService {
    public static readonly roleAddedOperation: RolesChangedOperation = 'add';
    public static readonly roleDeletedOperation: RolesChangedOperation = 'delete';
    public static readonly roleModifiedOperation: RolesChangedOperation = 'modify';

    private rolesChanged = new Subject<RolesChangedEventArg>();
    constructor( private accountEndpoint: FactoryEndpointService) { }
    getFactories(page?: number, pageSize?: number,searchTerm?:string,sortColumn?:string,sortOrder?:string) {
        return this.accountEndpoint.getFactoriesEndpoint<Factory[]>(page, pageSize,searchTerm,sortColumn,sortOrder);
    }
    getFactoriesList() {
        return this.accountEndpoint.getFactoriesListEndpoint<FactoryList[]>();
    }
    createFactory(factory: FactoryRequest) {
        return this.accountEndpoint.getNewFactoryEndpoint<Factory>(factory);
    }
    updateFactory(factory: FactoryRequest,id:number) {
        return this.accountEndpoint.getUpdateFactoryEndpoint<Factory>(factory,id);
    }
    getFactory(factoryId?: string) {
        return this.accountEndpoint.getFactoryEndpoint<Factory>(factoryId);
    }
    deleteFactory(factoryOrFactoryId: string | Factory): Observable<Factory> {
        if (typeof factoryOrFactoryId === 'string' || factoryOrFactoryId instanceof String) {
            return this.accountEndpoint.getDeleteFactoryEndpoint<Factory>(factoryOrFactoryId as string);
        } else {
            if (factoryOrFactoryId.id) {
                return this.deleteFactory(factoryOrFactoryId.id);
            } else {
                throw new Error("Invalid factoryOrFactoryId"); // Add this line to handle the case where id does not exist
            }
        }
    }
    getFactoryDuplicateStatus(factoryId:number,entityType:EntityType,factoryName?: string) {
        return this.accountEndpoint.getFactoryDuplicateStatusEndpoint<boolean>(factoryId, entityType,factoryName);
    }
}
