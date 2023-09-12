import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Mould } from 'src/app/models/mould.model';
import { MouldService } from 'src/app/services/mouldServices/mould.service';

@Component({
  selector: 'app-view-mould',
  templateUrl: './view-mould.component.html',
  styleUrls: ['./view-mould.component.scss']
})
export class ViewMouldComponent implements OnInit {
  mouldData: Mould;
  mouldId: any;
  constructor(
    private fb: FormBuilder,
    private mouldService: MouldService,
    private route: ActivatedRoute,
    private router: Router
  ) {

  }
  ngOnInit(): void {
            // Get the mould ID from the route parameters
            this.route.queryParams.subscribe(params => {
                debugger
                var g=params;
              this.mouldId = params['id']; // 'id' should match the parameter name in your route

              // Fetch the mould details by ID using your service
              this.loadMould(this.mouldId);
          });

  }
  private loadMould(id: number): void {debugger
    this.mouldService.getMould(id).subscribe((mould) => {
      debugger
      this.mouldData = mould;
    });
  }
  goBack(): void {
    // Navigate back to the list of factories
    // You can use the Angular Router to navigate
    // Example: this.router.navigate(['/factories']);
}
}
