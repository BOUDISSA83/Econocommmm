import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TestTypeRequest } from 'src/app/models/testType-request.model';
import { TestType } from 'src/app/models/testType.model';
import { TestTypeService } from 'src/app/services/testTypeServices/testType.service';


@Component({
  selector: 'app-add-edit-testType',
  templateUrl: './add-edit-testType.component.html',
  styleUrls: ['./add-edit-testType.component.scss']
})
export class AddEditTestTypeComponent implements OnInit {
  testTypeForm: FormGroup;
  isEditMode = false;
  testTypeData: TestType;
  testTypeRequest: TestTypeRequest = new TestTypeRequest();
  testTypeId: any;
  isLoading: boolean;
  inProgress: boolean;
  constructor(
    private fb: FormBuilder,
    private testTypeService: TestTypeService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.createForm();
    this.route.queryParams.subscribe((queryParams) => {
      if (queryParams['id']) {
        this.testTypeId = queryParams['id'];
        this.isEditMode = true;
        this.loadTestType(this.testTypeId);
      }
    });
  }

  private createForm(): void {
    this.testTypeForm = this.fb.group({
       name: ['', Validators.required],
      //  email: ['', [Validators.required, Validators.email]],
      //  address: [''],
       description: [''],
      //  mobile: [''],
      //  phone: [''],
      //  support: ['']
    });
  }

  private loadTestType(id: string): void {
    debugger
    this.testTypeService.getTestType(id).subscribe((testType) => {
      debugger
      this.testTypeData = testType;
      this.testTypeForm.patchValue(testType);
    });
  }

  save(): void {
    this.isLoading = true;

    if (this.testTypeForm.valid) {
      if (this.inProgress) {
       return;
      }
      this.inProgress = true;
      const formData = this.testTypeForm.value as TestType;
      this.testTypeRequest.model = { ...this.testTypeForm.value };
      this.testTypeRequest.model.id = this.testTypeId;
      if (this.isEditMode) {
        // Update an existing testType
        console.log ("got to the update panel");
        console.log(this.testTypeRequest);
        console.log(this.testTypeId);
        this.testTypeService.updateTestType(this.testTypeRequest).subscribe(() => {
          this.isLoading = false;
          this.inProgress = false;
          // Handle success or navigate to a different page
          this.router.navigate(['/testtypes']);
        });
      } else {
        // Create a new testType
        this.testTypeService.createTestType(this.testTypeRequest).subscribe(() => {
          this.isLoading = false;
          this.inProgress = false;
          // Handle success or navigate to a different page
          this.router.navigate(['/testtypes']);
        });
      }
    } else {
      this.isLoading = false;
      this.inProgress = false;
    }

  }
  cancel() {
    this.router.navigate(['/testtypes']);
  }
}
