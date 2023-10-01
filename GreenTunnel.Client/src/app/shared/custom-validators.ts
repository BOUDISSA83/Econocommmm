import { Injectable } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, ValidationErrors, ValidatorFn } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { debounceTime, map, catchError, switchMap } from 'rxjs/operators';

import { FactoryService } from '../services/factory.service';
import { WorkplaceService } from '../services/workplace.service';
import { WorkspaceService } from '../services/workspace.service';
import { EntityType } from '../models/enums';

@Injectable({ providedIn: 'root' })
export class CustomValidators {
    constructor(private factoryService: FactoryService) {}
    // Custom async validator function to check for duplicate names
    static validateNameDuplicate(factoryService:FactoryService,entityType:EntityType,factoryId:number): AsyncValidatorFn {
        return (control: AbstractControl): Observable<ValidationErrors | null> => {
            const name = control.value;

            // Return null if the control value is empty
            if (!name) {
                return of(null);
            }

            // Use debounceTime to avoid making too many requests in a short time
            return of(name).pipe(
                debounceTime(300), // Adjust debounceTime as needed
                switchMap((value) =>
                    factoryService.getFactoryDuplicateStatus(factoryId,entityType,value).pipe(
                        map((isDuplicate) => {
                            return isDuplicate ? { nameDuplicate: true } : null;
                        }),
                        catchError(() => null) // Handle errors gracefully
                    )
                )
            );
        };
    }
    static validateConfirmPassword = (passwordControl: AbstractControl): ValidatorFn => {
        return (confirmationControl: AbstractControl) : { [key: string]: boolean } | null => {
            const confirmValue = confirmationControl.value;
            const passwordValue = passwordControl.value;
            if (confirmValue === '') {
                return null;
            }

            if (confirmValue !== passwordValue) {
                return  { mustMatch: true }
            }

            return null;
        };
    }
}
