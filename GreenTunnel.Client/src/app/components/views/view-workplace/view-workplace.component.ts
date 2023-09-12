import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Workplace } from 'src/app/models/workplace.model';
import { FactoryService } from 'src/app/services/factory.service';
import { WorkplaceService } from 'src/app/services/workplace.service';

@Component({
  selector: 'app-view-workplace',
  templateUrl: './view-workplace.component.html',
  styleUrls: ['./view-workplace.component.scss']
})
export class ViewWorkplaceComponent {
  workplaceData: Workplace;
  workplaceId: any;
  constructor(
    private fb: FormBuilder,
    private workplaceService: WorkplaceService,
    private factoryService: FactoryService,
    private route: ActivatedRoute,
    private router: Router
  ) { 

  }
  ngOnInit(): void {
            this.route.queryParams.subscribe(params => {
              this.workplaceId = params['id']; 
              this.loadWorkplace(this.workplaceId);
          });
  
  }
  private loadWorkplace(id: string): void {debugger
    this.workplaceService.getWorkplace(id).subscribe((workplace) => {
      debugger
      this.workplaceData = workplace;
    });
  }
  goBack(): void {
    // Navigate back to the list of factories
    // You can use the Angular Router to navigate
    // Example: this.router.navigate(['/factories']);
}

}
