import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EntityType } from 'src/app/models/enums';
import { MouldRequest } from 'src/app/models/mould-request.model';
import { Mould } from 'src/app/models/mould.model';
import { WorkplacesList } from 'src/app/models/workplaces-list.model';
import { Workspace } from 'src/app/models/workspace.model';
import { WorkspacesList } from 'src/app/models/workspaces-list.model';
import { AccountService } from 'src/app/services/account.service';
import { FactoryService } from 'src/app/services/factory.service';
import { MouldService } from 'src/app/services/mouldServices/mould.service';
import { WorkplaceService } from 'src/app/services/workplace.service';
import { WorkspaceService } from 'src/app/services/workspace.service';
import { CustomValidators } from 'src/app/shared/custom-validators';

@Component({
    selector: 'app-add-edit-mould',
    templateUrl: './add-edit-mould.component.html',
    styleUrls: ['./add-edit-mould.component.scss']
})
export class AddEditMouldComponent {
    mouldForm: FormGroup;
    isEditMode = false;
    mouldData: Mould;
    mouldRequest: MouldRequest = new MouldRequest();
    mouldId: any;
    workspaceid: number;
    workspacesList:WorkspacesList[]=[];
    inProgress: boolean;
    isLoading: boolean;
    constructor(
        private fb: FormBuilder,
        private mouldService: MouldService,
        private workspaceService: WorkspaceService,
        private accountService: AccountService,
        private factoryService: FactoryService,
        private route: ActivatedRoute,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.createForm();
        this.getWorkspaceList();
        this.route.queryParams.subscribe((queryParams) => {
            if (queryParams['id']) {
                this.mouldId = queryParams['id'];
                this.isEditMode = true;
                debugger
                if (queryParams['wid']) {
                    this.workspaceid = Number(queryParams['wid']);
                    this.mouldForm.get('workspaceid').setValue(this.workspaceid);
                }
                this.loadMould(this.mouldId);
            }
        });
        this.route.params.subscribe((params) => {debugger
            if (params['workspaceid']) {
                this.workspaceid = Number(params['workspaceid']);
                if(this.workspaceid > 0)
                    this.mouldForm.get('workspaceid').setValue(this.workspaceid);
            }
        });

    }
    getWorkspaceList(){
        this.workspaceService.getWorkspacesList().subscribe((data:any)=>{
            debugger
            this.workspacesList = data;
        })
    }
    private createForm(): void {
        this.mouldForm = this.fb.group({
            name: ['', Validators.required,[CustomValidators.validateNameDuplicate(this.factoryService,EntityType.Mould,this.mouldId)]],
            type: ['', Validators.required],
            workspaceid: [null, Validators.required],
            //userid: ['4f5cb57a-f38a-432e-a4b1-1203d6d5719a'],
        });
    }

    private loadMould(id: number): void {
        this.mouldService.getMould(id).subscribe((mould) => {
            debugger
            this.mouldData = mould;
            this.mouldForm.patchValue(mould);
            //this.mouldForm.get('workspaceid').setValue(mould.WorkspaceId);
        });
    }

    save(): void {
        debugger

        if (this.mouldForm.valid) {
            this.isLoading = true;
            this.inProgress = true;
            const formData = this.mouldForm.value as Mould;
            this.mouldRequest.model = { ...this.mouldForm.value };
            this.mouldRequest.model.id = this.mouldId;
            this.mouldRequest.model.UserId = this.accountService.currentUser.id;
            debugger
            if (this.isEditMode) {
                // Update an existing mould
                this.mouldService.updateMould(this.mouldRequest,this.mouldId).subscribe(() => {
                    // Handle success or navigate to a different page

                    this.isLoading = false;
                    this.inProgress = false;
                    this.router.navigate(['/moulds']);
                });
            } else {
                // Create a new mould
                this.mouldService.createMould(this.mouldRequest).subscribe(() => {

                    this.isLoading = false;
                    this.inProgress = false;
                    // Handle success or navigate to a different page
                    this.router.navigate(['/moulds']);
                });
            }
        }

    }
    cancel() {
        this.router.navigate(['/moulds']);
    }
}
