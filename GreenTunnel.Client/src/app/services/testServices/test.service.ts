import { Injectable } from '@angular/core';
import { RolesChangedEventArg, RolesChangedOperation } from '../account.service';
import { Observable, Subject, mergeMap } from 'rxjs';
import { TestEndpointService } from './test-endpoint.service';
import { Test } from '../../models/test.model'


import { TestRequest } from '../../models/test-request.model';
import { TestList } from '../../models/test-list.model';

@Injectable()
export class TestService {
  public static readonly roleAddedOperation: RolesChangedOperation = 'add';
  public static readonly roleDeletedOperation: RolesChangedOperation = 'delete';
  public static readonly roleModifiedOperation: RolesChangedOperation = 'modify';

  private rolesChanged = new Subject<RolesChangedEventArg>();
  constructor( private testEndpoint: TestEndpointService) { }
  getTests(page?: number, pageSize?: number,searchTerm?:string,sortColumn?:string,sortOrder?:string) {
    return this.testEndpoint.getTestsEndpoint<Test[]>(page, pageSize,searchTerm,sortColumn,sortOrder);
  }
  getTestsList() {
    return this.testEndpoint.getTestsListEndpoint<TestList[]>();
  }
  createTest(test: TestRequest) {
    return this.testEndpoint.getNewTestEndpoint<Test>(test);
  }  
  updateTest(test: TestRequest) {
    return this.testEndpoint.getUpdateTestEndpoint<Test>(test);
  }
  getTest(testId?: string) {  
    return this.testEndpoint.getTestEndpoint<Test>(testId);
  }
  deleteTest(testOrTestId: string | Test): Observable<Test> {
    if (typeof testOrTestId === 'string' || testOrTestId instanceof String) {
      console.log ("got to delete section");
      return this.testEndpoint.getDeleteTestEndpoint<Test>(testOrTestId as string);
    } else {
      if (testOrTestId.id) {
        return this.deleteTest(testOrTestId.id);
      } else {
        throw new Error("Invalid TestTestId"); // Add this line to handle the case where id does not exist
      }
    }
  }
  
}
