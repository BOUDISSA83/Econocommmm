import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Factory } from 'src/app/models/factory.model';
import { FactoryService } from 'src/app/services/factory.service';
import { Utilities } from 'src/app/services/utilities';

@Component({
  selector: 'app-delete-factory',
  templateUrl: './delete-factory.component.html',
  styleUrls: ['./delete-factory.component.scss']
})
export class DeleteFactoryComponent implements OnInit {
  // Outupt to broadcast this instance so it can be accessible from within ng-bootstrap modal template
  @Output()
  afterOnInit = new EventEmitter<DeleteFactoryComponent>();
  @Input() row: Factory;
  @Output() deleteChanged: EventEmitter<any> = new EventEmitter();

  constructor(public activeModal: NgbActiveModal,
    private toastr: ToastrService,
    private factoryService: FactoryService,

  ) { }

  ngOnInit(): void {
    // this.afterOnInit.emit(this);

  }
  confirm() {
    this.deleteUserHelper(this.row);
  }
  decline() {
    this.activeModal.close();
  }
  deleteUserHelper(row: Factory) {
    this.toastr.success('Deleting...');
    // this.loadingIndicator = true;

    this.factoryService.deleteFactory(row).subscribe({
      next: (_) => {
        //  this.alertService.stopLoadingMessage();
        //this.loadingIndicator = false;
        this.toastr.success('Delete Factory', `Factory ${row.name} has been deleted successfully.`);
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
