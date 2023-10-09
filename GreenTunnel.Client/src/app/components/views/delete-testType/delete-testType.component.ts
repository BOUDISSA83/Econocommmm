import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { TestType } from 'src/app/models/testType.model';
import { TestTypeService } from 'src/app/services/testTypeServices/testType.service';
import { Utilities } from 'src/app/services/utilities';

@Component({
  selector: 'app-delete-testType',
  templateUrl: './delete-testType.component.html',
  styleUrls: ['./delete-testType.component.scss']
})
export class DeleteTestTypeComponent implements OnInit {
  @Input() row: TestType;
  @Output() deleteChanged: EventEmitter<any> = new EventEmitter();

  constructor(public activeModal: NgbActiveModal,
    private toastr: ToastrService,
    private TestTypeService: TestTypeService,

  ) { }

  ngOnInit(): void {
    // this.afterOnInit.emit(this);

  }
  confirm() {
    this.deleteTestTypeHelper(this.row);
  }
  decline() {
    this.activeModal.close();
  }
  deleteTestTypeHelper(row: TestType) {
    this.toastr.success('Deleting...');
    // this.loadingIndicator = true;

    this.TestTypeService.deleteTestType(row).subscribe({
      next: (_) => {
        //  this.alertService.stopLoadingMessage();
        //this.loadingIndicator = false;
        this.toastr.success('Delete Test Type', `Testng  ${row.name} has been deleted successfully.`);
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
