import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FactoryList } from 'src/app/models/factories-list.model';
import { WorkplaceRequest } from 'src/app/models/workplace-request.model';
import { Workplace } from 'src/app/models/workplace.model';
import { FactoryService } from 'src/app/services/factory.service';
import { WorkplaceService } from 'src/app/services/workplace.service';

@Component({
  selector: 'app-add-edit-workplace',
  templateUrl: './add-edit-workplace.component.html',
  styleUrls: ['./add-edit-workplace.component.scss']
})
export class AddEditWorkplaceComponent {
  workplaceForm: FormGroup;
  isEditMode = false;
  factoryData: Workplace;
  workplaceRequest: WorkplaceRequest = new WorkplaceRequest();
  workplaceId: any;
  factoryId: number;
  factoriesList:FactoryList[]=[];
  constructor(
    private fb: FormBuilder,
    private workplaceService: WorkplaceService,
    private factoryService:FactoryService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.createForm();
    this.route.queryParams.subscribe((queryParams) => {debugger
      if (queryParams['id']) {
        this.workplaceId = queryParams['id'];
        this.isEditMode = true;
        this.loadWorkplace(this.workplaceId);
      }
    });
    this.route.params.subscribe((params) => {debugger
      if (params['factoryId']) {
        this.factoryId = Number(params['factoryId']);
        if(this.factoryId > 0)
        this.workplaceForm.get('factoryId').setValue(this.factoryId);
      }
    });
    this.getFactoriesList();
  }
  getFactoriesList(){
    this.factoryService.getFactoriesList().subscribe((data:any)=>{
      this.factoriesList = data;
    })
  }
  private createForm(): void {
    this.workplaceForm = this.fb.group({
      name: ['', Validators.required],
      description: [''],
      factoryId:[null,Validators.required]
    });
  }

  private loadWorkplace(id: string): void {debugger
    // Load factory data from your API service
    this.workplaceService.getWorkplace(id).subscribe((factory) => {
      debugger
      this.factoryData = factory;
      this.workplaceForm.patchValue(factory);
    });
  }

  save(): void {
    if (this.workplaceForm.valid) {debugger
      const formData = this.workplaceForm.value as Workplace;
      this.workplaceRequest.model = { ...this.workplaceForm.value };
      this.workplaceRequest.model.id = this.workplaceId;
      this.workplaceRequest.model.factoryId = formData.factoryId;
      if (this.isEditMode) {
        // Update an existing factory
        this.workplaceService.updateWorkplace(this.workplaceRequest,this.workplaceId).subscribe(() => {
          // Handle success or navigate to a different page
          this.router.navigate(['/workplaces']);
        });
      } else {
        // Create a new factory
        this.workplaceService.createWorkplace(this.workplaceRequest).subscribe(() => {
          // Handle success or navigate to a different page
          this.router.navigate(['/workplaces']);
        });
      }
    }

  }
  cancel() {
    this.router.navigate(['/workplaces']);
  }
}
