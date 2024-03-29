import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Workspace } from 'src/app/models/workspace.model';
import { WorkspaceService } from 'src/app/services/workspace.service';

@Component({
  selector: 'app-view-workspace',
  templateUrl: './view-workspace.component.html',
  styleUrls: ['./view-workspace.component.scss']
})
export class ViewWorkspaceComponent {
  workspaceData: Workspace;
  workspaceId: any;
  constructor(
    private workspaceService: WorkspaceService,
    private route: ActivatedRoute,
    private router: Router
  ) { 

  }
  ngOnInit(): void {
            this.route.queryParams.subscribe(params => {
              this.workspaceId = params['id']; 
              this.loadWorkplace(this.workspaceId);
          });
  
  }
  private loadWorkplace(id: string): void {
    this.workspaceService.getWorkspace(id).subscribe((workplace) => {
      
      this.workspaceData = workplace;
    });
  }
  goBack() {
    this.router.navigate(['/workspaces']);
  }
}
