import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Mould } from 'src/app/models/mould.model';
import { MouldService } from 'src/app/services/mouldServices/mould.service';
import { Utilities } from 'src/app/services/utilities';

@Component({
  selector: 'app-delete-mould',
  templateUrl: './delete-mould.component.html',
  styleUrls: ['./delete-mould.component.scss']
})
export class DeleteMouldComponent {
  @Input() row: Mould;
  @Output() deleteChanged: EventEmitter<any> = new EventEmitter();

  constructor(public activeModal: NgbActiveModal,
    private toastr: ToastrService,
    private mouldService: MouldService,

  ) { }

  ngOnInit(): void {

  }
  confirm() {
    this.deleteMouldHelper(this.row);
  }
  decline() {
    this.activeModal.close();
  }
  deleteMouldHelper(row: Mould) {
    this.toastr.success('Deleting...');
    // this.loadingIndicator = true;

    this.mouldService.deleteMould(row).subscribe({
      next: (_) => {
        //  this.alertService.stopLoadingMessage();
        //this.loadingIndicator = false;
        this.toastr.success('Delete Mould', `Mould ${row.name} has been deleted successfully.`);
        this.deleteChanged.emit(true);
      },
      error: (error) => {
        // this.alertService.stopLoadingMessage();
        // this.loadingIndicator = false;

        this.toastr.error(
          'Delete Error',
          `An error occurred whilst deleting the Mould.\r\nError: "${Utilities.getHttpResponseMessages(
            error
          )}"`
        );
      },
    });
  }
}
