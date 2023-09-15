import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Workplace } from 'src/app/models/workplace.model';
import { Utilities } from 'src/app/services/utilities';
import { WorkplaceService } from 'src/app/services/workplace.service';

@Component({
  selector: 'app-delete-workplace',
  templateUrl: './delete-workplace.component.html',
  styleUrls: ['./delete-workplace.component.scss']
})
export class DeleteWorkplaceComponent {
  @Input() row: Workplace;
  @Output() deleteChanged: EventEmitter<any> = new EventEmitter();

  constructor(public activeModal: NgbActiveModal,
    private toastr: ToastrService,
    private workplaceService: WorkplaceService,

  ) { }

  ngOnInit(): void {

  }
  confirm() {
    this.deleteWorkplaceHelper(this.row);
  }
  decline() {
    this.activeModal.close();
  }
  deleteWorkplaceHelper(row: Workplace) {
    this.toastr.success('Deleting...');
    // this.loadingIndicator = true;

    this.workplaceService.deleteWorkplace(row).subscribe({
      next: (_) => {
        //  this.alertService.stopLoadingMessage();
        //this.loadingIndicator = false;
        this.toastr.success('Delete Workplace', `Workplace ${row.name} has been deleted successfully.`);
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
