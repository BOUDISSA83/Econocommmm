import { Component, OnInit } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, catchError, debounceTime, map, of, switchMap } from 'rxjs';
import { EntityType } from 'src/app/models/enums';
import { FactoryRequest } from 'src/app/models/factory-request.model';
import { Factory } from 'src/app/models/factory.model';
import { FactoryService } from 'src/app/services/factory.service';
import { CustomValidators } from 'src/app/shared/custom-validators';

@Component({
    selector: 'app-add-edit-factory',
    templateUrl: './add-edit-factory.component.html',
    styleUrls: ['./add-edit-factory.component.scss']
})
export class AddEditFactoryComponent implements OnInit {
    factoryForm: FormGroup;
    isEditMode = false;
    factoryData: Factory;
    factoryRequest: FactoryRequest = new FactoryRequest();
    factoryId: number = 0;
    isLoading: boolean;
    inProgress: boolean;
    constructor(
        private fb: FormBuilder,
        private factoryService: FactoryService,
        private route: ActivatedRoute,
        private router: Router,
        private toasterService:ToastrService
    ) { }

    ngOnInit(): void {
        this.route.queryParams.subscribe((queryParams) => {
            if (queryParams['id']) {
                this.factoryId = queryParams['id'];
                this.isEditMode = true;
                this.loadFactory(this.factoryId.toString());
            }
        });
        this.createForm();
    }

    private createForm(): void {
        this.factoryForm = this.fb.group({
            name: ['', [Validators.required],[CustomValidators.validateNameDuplicate(this.factoryService,EntityType.Factory,this.factoryId)]],
            email: ['', [Validators.required, Validators.email]],
            address: [''],
            description: [''],
            mobile: [''],
            phone: [''],
            support: ['']
        });
    }

    private loadFactory(id: string): void {
        this.factoryService.getFactory(id).subscribe((factory) => {
            this.factoryData = factory;
            this.factoryForm.patchValue(factory);
        });
    }

    save(): void {
        this.isLoading = true;

        if (this.factoryForm.valid) {
            if (this.inProgress) {
                return;
            }
            this.inProgress = true;
            const formData = this.factoryForm.value as Factory;
            this.factoryRequest.model = { ...this.factoryForm.value };
            this.factoryRequest.model.id = this.factoryId;
            if (this.isEditMode) {
                // Update an existing factory
                this.factoryService.updateFactory(this.factoryRequest, this.factoryId).subscribe(() => {
                    this.isLoading = false;
                    this.inProgress = false;
                    // Handle success or navigate to a different page
                    this.toasterService.success(`Factory ${this.factoryRequest.model.name} has been updated.`,'Factroy Updated',);
                    this.router.navigate(['/factories']);
                });
            } else {
                // Create a new factory
                this.factoryService.createFactory(this.factoryRequest).subscribe(() => {
                    this.isLoading = false;
                    this.inProgress = false;
                    this.toasterService.success(`Factory ${this.factoryRequest.model.name} has been created.`,'Factroy Created');
                    // Handle success or navigate to a different page
                    this.router.navigate(['/factories']);
                });
            }
        } else {
            this.isLoading = false;
            this.inProgress = false;
            this.toasterService.error(`Kindly fill the fcatory form correctly.`,'Factory Failed');
        }

    }
    cancel() {
        this.router.navigate(['/factories']);
    }
}
