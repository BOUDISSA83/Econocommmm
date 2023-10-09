import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Test } from 'src/app/models/test.model';
import { TestService } from 'src/app/services/testServices/test.service';
import { Utilities } from 'src/app/services/utilities';

@Component({
  selector: 'app-delete-test',
  templateUrl: './delete-test.component.html',
  styleUrls: ['./delete-test.component.scss']
})
export class DeleteTestComponent implements OnInit {
  @Input() row: Test;
  @Output() deleteChanged: EventEmitter<any> = new EventEmitter();

  constructor(public activeModal: NgbActiveModal,
    private toastr: ToastrService,
    private testService: TestService,

  ) { }

  ngOnInit(): void {
    // this.afterOnInit.emit(this);

  }
  confirm() {
    this.deleteTestHelper(this.row);
  }
  decline() {
    this.activeModal.close();
  }
  deleteTestHelper(row: Test) {
    this.toastr.success('Deleting...');
    // this.loadingIndicator = true;

    this.testService.deleteTest(row).subscribe({
      next: (_) => {
        //  this.alertService.stopLoadingMessage();
        //this.loadingIndicator = false;
        this.toastr.success('Delete Test', `Testng  ${row.name} has been deleted successfully.`);
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
