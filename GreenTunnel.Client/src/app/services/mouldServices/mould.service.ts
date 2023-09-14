import { Injectable } from '@angular/core';
import { Observable, Subject, mergeMap } from 'rxjs';
import { RolesChangedEventArg, RolesChangedOperation } from '../account.service';
import { MouldEndpointService } from './mould-endpoint.service';
import { Mould } from 'src/app/models/mould.model';
import { MouldRequest } from 'src/app/models/mould-request.model';

@Injectable()
export class MouldService {
  public static readonly roleAddedOperation: RolesChangedOperation = 'add';
  public static readonly roleDeletedOperation: RolesChangedOperation = 'delete';
  public static readonly roleModifiedOperation: RolesChangedOperation = 'modify';

  private rolesChanged = new Subject<RolesChangedEventArg>();
  constructor( private accountEndpoint: MouldEndpointService) { }
  getMoulds(workspaceId:number,page?: number, pageSize?: number) {
    return this.accountEndpoint.getMouldsEndpoint<Mould[]>(workspaceId,page, pageSize);
  }
  createMould(mould: MouldRequest) {
    return this.accountEndpoint.getNewMouldEndpoint<Mould>(mould);
  }
  updateMould(mould: MouldRequest,id:number) {
    return this.accountEndpoint.getUpdateMouldEndpoint<Mould>(mould,id);
  }
  getMould(mouldId?: number) {
    return this.accountEndpoint.getMouldEndpoint<Mould>(mouldId);
  }
  deleteMould(mouldOrMouldId: number | Mould): Observable<Mould> {
    if (typeof mouldOrMouldId === 'number' ) {
      return this.accountEndpoint.getDeleteMouldEndpoint<Mould>(mouldOrMouldId);
    } else {
      if (mouldOrMouldId.id) {
        return this.deleteMould(mouldOrMouldId.id);
      } else {
        throw new Error("Invalid mouldOrMouldId"); // Add this line to handle the case where id does not exist
      }
    }
  }

}
