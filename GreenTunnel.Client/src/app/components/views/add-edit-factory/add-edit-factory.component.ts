import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FactoryRequest } from 'src/app/models/factory-request.model';
import { Factory } from 'src/app/models/factory.model';
import { FactoryService } from 'src/app/services/factory.service';

@Component({
  selector: 'app-add-edit-factory',
  templateUrl: './add-edit-factory.component.html',
  styleUrls: ['./add-edit-factory.component.scss']
})
export class AddEditFactoryComponent  implements OnInit {
  factoryForm: FormGroup;
  isEditMode = false;
  factoryData: Factory;
  factoryRequest: FactoryRequest = new FactoryRequest();
  factoryId: any;
  constructor(
    private fb: FormBuilder,
    private factoryService: FactoryService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.createForm();
    this.route.queryParams.subscribe((queryParams) => {
      if (queryParams['id']) {
        this.factoryId = queryParams['id'];
        this.isEditMode = true;
        this.loadFactory(this.factoryId);
      }
    });    
  }

  private createForm(): void {
    this.factoryForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      address: [''],
      description: [''],
      mobile: [''],
      phone: [''],
      support: ['']
    });
  }

  private loadFactory(id: string): void {debugger
    this.factoryService.getFactory(id).subscribe((factory) => {
      debugger
      this.factoryData = factory;
      this.factoryForm.patchValue(factory);
    });
  }

  save(): void {
    if (this.factoryForm.valid) {
      const formData = this.factoryForm.value as Factory;
      this.factoryRequest.model = { ...this.factoryForm.value };
      this.factoryRequest.model.id = this.factoryId;
      if (this.isEditMode) {
        // Update an existing factory
        this.factoryService.updateFactory(this.factoryRequest,this.factoryId).subscribe(() => {
          // Handle success or navigate to a different page
          this.router.navigate(['/factories']);
        });
      } else {
        // Create a new factory
        this.factoryService.createFactory(this.factoryRequest).subscribe(() => {
          // Handle success or navigate to a different page
          this.router.navigate(['/factories']);
        });
      }
    }

  }
  cancel() {
    this.router.navigate(['/factories']);
  }
}
