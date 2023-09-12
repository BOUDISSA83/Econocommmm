import { Injectable } from '@angular/core';
import { RolesChangedEventArg, RolesChangedOperation } from './account.service';
import { Observable, Subject, mergeMap } from 'rxjs';
import { WorkplaceEndpointService } from './workplace-endpoint.service';
import { WorkplaceRequest } from '../models/workplace-request.model';
import { Workplace } from '../models/workplace.model';
import { WorkplacesList } from '../models/workplaces-list.model';

@Injectable()
export class WorkplaceService {
  public static readonly roleAddedOperation: RolesChangedOperation = 'add';
  public static readonly roleDeletedOperation: RolesChangedOperation = 'delete';
  public static readonly roleModifiedOperation: RolesChangedOperation = 'modify';

  private rolesChanged = new Subject<RolesChangedEventArg>();
  constructor( private workplaceEndpoint: WorkplaceEndpointService) { }
  getWorkplaces(factoryId?:number,page?: number, pageSize?: number,searchTerm?:string,sortColumn?:string,sortOrder?:string) {
    return this.workplaceEndpoint.getWorkplacesEndpoint<Workplace[]>(factoryId,page, pageSize,searchTerm,sortColumn,sortOrder);
  }
  getWorkplacesList() {
    return this.workplaceEndpoint.getWorkplacesListEndpoint<WorkplacesList[]>();
  }
  createWorkplace(factory: WorkplaceRequest) {
    return this.workplaceEndpoint.getNewWorkplaceEndpoint<Workplace>(factory);
  }  
  updateWorkplace(factory: WorkplaceRequest,id:number) {
    return this.workplaceEndpoint.getUpdateWorkplaceEndpoint<Workplace>(factory,id);
  }
  getWorkplace(workplaceId?: string) {  
    return this.workplaceEndpoint.getWorkplaceEndpoint<Workplace>(workplaceId);
  }
  deleteWorkplace(factoryOrWorkplaceId: string | Workplace): Observable<Workplace> {debugger
    if (typeof factoryOrWorkplaceId === 'string' || factoryOrWorkplaceId instanceof String) {
      return this.workplaceEndpoint.getDeleteWorkplaceEndpoint<Workplace>(factoryOrWorkplaceId as string);
    } else {
      if (factoryOrWorkplaceId) { 
        return this.deleteWorkplace(factoryOrWorkplaceId.id);
      } else {
        throw new Error("Invalid factoryOrWorkplaceId"); // Add this line to handle the case where id does not exist
      }
    }
  }
  
}
