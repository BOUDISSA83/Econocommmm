import { Injectable } from '@angular/core';
import { RolesChangedEventArg, RolesChangedOperation } from './account.service';
import { Observable, Subject, mergeMap } from 'rxjs';
import { WorkspaceEndpointService } from './workspace-endpoint.service';
import { WorkspaceRequest } from '../models/workspace-request.model';
import { Workspace } from '../models/workspace.model';
import { WorkspacesList } from '../models/workspaces-list.model';

@Injectable()
export class WorkspaceService {
  public static readonly roleAddedOperation: RolesChangedOperation = 'add';
  public static readonly roleDeletedOperation: RolesChangedOperation = 'delete';
  public static readonly roleModifiedOperation: RolesChangedOperation = 'modify';

  private rolesChanged = new Subject<RolesChangedEventArg>();
  constructor( private workspaceEndpoint: WorkspaceEndpointService) { }
  getWorkspaces(workplaceId?:number,page?: number, pageSize?: number,searchTerm?:string,sortColumn?:string,sortOrder?:string) {
    return this.workspaceEndpoint.getWorkspacesEndpoint<Workspace[]>(workplaceId,page, pageSize,searchTerm,sortColumn,sortOrder);
  }
  getWorkspacesList() {
    return this.workspaceEndpoint.getWorkspacesListEndpoint<WorkspacesList[]>();
  }
  createWorkspace(factory: WorkspaceRequest) {
    return this.workspaceEndpoint.getNewWorkspaceEndpoint<Workspace>(factory);
  }
  updateWorkspace(factory: WorkspaceRequest,id:number) {
    return this.workspaceEndpoint.getUpdateWorkspaceEndpoint<Workspace>(factory,id);
  }
  getWorkspace(workplaceId?: string) {
    return this.workspaceEndpoint.getWorkspaceEndpoint<Workspace>(workplaceId);
  }
  deleteWorkspace(factoryOrWorkspaceId: string | Workspace): Observable<Workspace> {
    if (typeof factoryOrWorkspaceId === 'string' || factoryOrWorkspaceId instanceof String) {
      return this.workspaceEndpoint.getDeleteWorkspaceEndpoint<Workspace>(factoryOrWorkspaceId as string);
    } else {
      if (factoryOrWorkspaceId) {
        return this.deleteWorkspace(factoryOrWorkspaceId.id);
      } else {
        throw new Error("Invalid factoryOrWorkspaceId"); // Add this line to handle the case where id does not exist
      }
    }
  }

}
