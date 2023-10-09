import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TestType } from 'src/app/models/testType.model';
import { TestTypeService } from 'src/app/services/testTypeServices/testType.service';


@Component({
  selector: 'app-view-testType',
  templateUrl: './view-testType.component.html',
  styleUrls: ['./view-testType.component.scss']
})
export class ViewTestTypeComponent implements OnInit {
  testTypeData: TestType;
  testTypeId: any;
  constructor (
    private fb: FormBuilder,
    private testTypeService: TestTypeService,
    private route: ActivatedRoute,
    private router: Router
  ) { 

  }
  ngOnInit(): void {
            // Get the testType ID from the route parameters
            this.route.queryParams.subscribe(params => {
              this.testTypeId = params['id']; // 'id' should match the parameter name in your route 
              // Fetch the testType details by ID using your service
              this.loadTestType(this.testTypeId);
          });
  
  }
  private loadTestType(id: string): void {debugger
    this.testTypeService.getTestType(id).subscribe((testType) => {
      debugger
      this.testTypeData= testType;
      console.log("the test type value is : " , testType);
    });
  }

goBack() {
  this.router.navigate(['/testtypes']);
}
}
