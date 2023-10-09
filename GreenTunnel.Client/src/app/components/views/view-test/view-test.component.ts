import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Test } from 'src/app/models/test.model';
import { TestService } from 'src/app/services/testServices/test.service';


@Component({
  selector: 'app-view-test',
  templateUrl: './view-test.component.html',
  styleUrls: ['./view-test.component.scss']
})
export class ViewTestComponent implements OnInit {
  testData: Test;
  testId: any;
  constructor(
    private fb: FormBuilder,
    private testService: TestService,
    private route: ActivatedRoute,
    private router: Router
  ) { 

  }
  ngOnInit(): void {
            // Get the test ID from the route parameters
            this.route.queryParams.subscribe(params => {
              this.testId = params['id']; // 'id' should match the parameter name in your route
  
              // Fetch the test details by ID using your service
              this.loadTest(this.testId);
          });
  
  }
  private loadTest(id: string): void {debugger
    this.testService.getTest(id).subscribe((test) => {
      debugger
      console.log("test data are");
      console.log(test);
      this.testData= test;
    });
  }

goBack() {
  this.router.navigate(['/tests']);
}
}
