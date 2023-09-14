import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Factory } from 'src/app/models/factory.model';
import { FactoryService } from 'src/app/services/factory.service';
import { WorkplaceService } from 'src/app/services/workplace.service';

@Component({
  selector: 'app-view-factory',
  templateUrl: './view-factory.component.html',
  styleUrls: ['./view-factory.component.scss']
})
export class ViewFactoryComponent implements OnInit {
  factoryData: Factory;
  factoryId: any;
  constructor(
    private fb: FormBuilder,
    private workplaceService: WorkplaceService,
    private factoryService: FactoryService,
    private route: ActivatedRoute,
    private router: Router
  ) { 

  }
  ngOnInit(): void {
            // Get the factory ID from the route parameters
            this.route.queryParams.subscribe(params => {
              this.factoryId = params['id']; // 'id' should match the parameter name in your route
  
              // Fetch the factory details by ID using your service
              this.loadFactory(this.factoryId);
          });
  
  }
  private loadFactory(id: string): void {debugger
    this.factoryService.getFactory(id).subscribe((factory) => {
      debugger
      this.factoryData = factory;
    });
  }

goBack() {
  this.router.navigate(['/factories']);
}
}
