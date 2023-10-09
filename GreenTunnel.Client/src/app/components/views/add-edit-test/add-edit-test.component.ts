import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TestRequest } from 'src/app/models/test-request.model';
import { Test } from 'src/app/models/test.model';
import { TestTypeList } from 'src/app/models/testType-list.model';
import { TestService } from 'src/app/services/testServices/test.service';
import { TestTypeService } from 'src/app/services/testTypeServices/testType.service';


@Component({
  selector: 'app-add-edit-test',
  templateUrl: './add-edit-test.component.html',
  styleUrls: ['./add-edit-test.component.scss']
})
export class AddEditTestComponent implements OnInit {
  testForm: FormGroup;
  isEditMode = false;
  testData: Test;
  testRequest: TestRequest = new TestRequest();
  testId: any;
  testTypesList: TestTypeList[] = [];
  testTypeId : number;
  isLoading: boolean;
  inProgress: boolean;
  constructor(
    private fb: FormBuilder,
    private testService: TestService,
    private testTypeService : TestTypeService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.createForm();
    this.route.queryParams.subscribe((queryParams) => {
      if (queryParams['id']) {
        this.testId = queryParams['id'];
        this.isEditMode = true;
        this.loadTest(this.testId);
      }
    });


    this.route.params.subscribe((params) => {
      debugger
      if (params['testTypeId']) {
        this.testTypeId = Number(params['testTypeId']);
        if (this.testTypeId > 0)
          this.testForm.get('testTypeId').setValue(this.testTypeId);
      }
    });
    this.getTestTypesList();
  }
  getTestTypesList() {
    this.testTypeService.getTestTypesList().subscribe((data: any) => {
      this.testTypesList = data;
    })
  }

  private createForm(): void {
    this.testForm = this.fb.group({
      name: ['', Validators.required],
     // email: ['', [Validators.required, Validators.email]],
      //address: [''],
      description: [''],
      testTypeId: [null, Validators.required]
      //mobile: [''],
      //phone: [''],
     // support: ['']
    });
  }

  private loadTest(id: string): void {
    debugger
    this.testService.getTest(id).subscribe((test) => {
      debugger
      this.testData = test;
      this.testForm.patchValue(test);
    });
  }



  save(): void {
    this.isLoading = true;

    if (this.testForm.valid) {
      if (this.inProgress) {
        return;
      }
      this.inProgress = true;
      const formData = this.testForm.value as Test;
      this.testRequest.model = { ...this.testForm.value };
      this.testRequest.model.id = this.testId;
      this.testRequest.model.tesTypeId = formData.tesTypeId;
      if (this.isEditMode) {
        // Update an existing test
        this.testService.updateTest(this.testRequest).subscribe(() => {
          this.isLoading = false;
          this.inProgress = false;
          // Handle success or navigate to a different page
          this.router.navigate(['/tests']);
        });
      } else {
        // Create a new test
        this.testService.createTest(this.testRequest).subscribe(() => {
          this.isLoading = false;
          this.inProgress = false;
          // Handle success or navigate to a different page
          this.router.navigate(['/tests']);
        });
      }
    } else {
      this.isLoading = false;
      this.inProgress = false;
    }

  }
  cancel() {
    this.router.navigate(['/tests']);
  }
}
