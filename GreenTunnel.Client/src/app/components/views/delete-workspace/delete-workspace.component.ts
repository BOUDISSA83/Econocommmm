import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Workplace } from 'src/app/models/workplace.model';
import { Workspace } from 'src/app/models/workspace.model';
import { Utilities } from 'src/app/services/utilities';
import { WorkspaceService } from 'src/app/services/workspace.service';

@Component({
  selector: 'app-delete-workspace',
  templateUrl: './delete-workspace.component.html',
  styleUrls: ['./delete-workspace.component.scss']
})
export class DeleteWorkspaceComponent {
  @Input() row: Workspace;
  @Output() deleteChanged: EventEmitter<any> = new EventEmitter();

  constructor(public activeModal: NgbActiveModal,
    private toastr: ToastrService,
    private workspaceService: WorkspaceService,

  ) { }

  ngOnInit(): void {

  }
  confirm() {
    this.deleteWorkspaceHelper(this.row);
  }
  decline() {
    this.activeModal.close();
  }
  deleteWorkspaceHelper(row: Workspace) {
    this.toastr.success('Deleting...');
    // this.loadingIndicator = true;

    this.workspaceService.deleteWorkspace(row).subscribe({
      next: (_) => {
        //  this.alertService.stopLoadingMessage();
        //this.loadingIndicator = false;
        this.toastr.success('Delete Workspace', `Workspace ${row.name} has been deleted successfully.`);
        this.deleteChanged.emit(true);
      },
      error: (error) => {
        // this.alertService.stopLoadingMessage();
        // this.loadingIndicator = false;

        this.toastr.error(
          'Delete Error',
          `An error occurred whilst deleting the user.\r\nError: "${Utilities.getHttpResponseMessages(
            error
          )}"`
        );
      },
    });
  }
}
