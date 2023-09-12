import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { WorkplacesList } from 'src/app/models/workplaces-list.model';
import { WorkspaceRequest } from 'src/app/models/workspace-request.model';
import { Workspace } from 'src/app/models/workspace.model';
import { FactoryService } from 'src/app/services/factory.service';
import { WorkplaceService } from 'src/app/services/workplace.service';
import { WorkspaceService } from 'src/app/services/workspace.service';

@Component({
  selector: 'app-add-edit-workspace',
  templateUrl: './add-edit-workspace.component.html',
  styleUrls: ['./add-edit-workspace.component.scss']
})
export class AddEditWorkspaceComponent {
  workplaceForm: FormGroup;
  isEditMode = false;
  factoryData: Workspace;
  workspaceRequest: WorkspaceRequest = new WorkspaceRequest();
  workspaceId: any;
  workplaceId: number;
  workplacesList:WorkplacesList[]=[];
  constructor(
    private fb: FormBuilder,
    private workspaceService: WorkspaceService,
    private workplaceService: WorkplaceService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.createForm();
    this.route.queryParams.subscribe((queryParams) => {
      if (queryParams['id']) {
        this.workspaceId = queryParams['id'];
        this.isEditMode = true;
        this.loadWorkspace(this.workspaceId);
      }
    });    
    this.route.params.subscribe((params) => {debugger
      if (params['workplaceId']) {
        this.workplaceId = Number(params['workplaceId']);
        this.workplaceForm.get('workplaceId').setValue(this.workplaceId);        
      }
    }); 
    this.getWorkplacesList();   
  }
  private createForm(): void {
    this.workplaceForm = this.fb.group({
      name: ['', Validators.required],
      description: [''],
      order:[0],
      workplaceId:[null,Validators.required]
    });
  }

  private loadWorkspace(id: string): void {debugger
    // Load factory data from your API service
    this.workspaceService.getWorkspace(id).subscribe((factory) => {
      debugger
      this.factoryData = factory;
      this.workplaceForm.patchValue(factory);
    });
  }
getWorkplacesList(){
  this.workplaceService.getWorkplacesList().subscribe((data:any)=>{
    this.workplacesList = data;
  })
}
  save(): void {
    if (this.workplaceForm.valid) {
      const formData = this.workplaceForm.value as Workspace;
      this.workspaceRequest.model = { ...this.workplaceForm.value };
      this.workspaceRequest.model.id = this.workspaceId;
      this.workspaceRequest.model.workplaceId = formData.workplaceId;
      
      if (this.isEditMode) {
        // Update an existing factory
        this.workspaceService.updateWorkspace(this.workspaceRequest,this.workspaceId).subscribe(() => {
          // Handle success or navigate to a different page
          this.router.navigate(['/workspaces']);
        });
      } else {
        // Create a new factory
        this.workspaceService.createWorkspace(this.workspaceRequest).subscribe(() => {
          // Handle success or navigate to a different page
          this.router.navigate(['/workspaces']);
        });
      }
    }

  }
}
