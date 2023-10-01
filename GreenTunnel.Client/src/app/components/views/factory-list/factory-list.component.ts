import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Factory } from 'src/app/models/factory.model';
import { Permission } from 'src/app/models/permission.model';
import { AccountService } from 'src/app/services/account.service';
import { AlertService, DialogType, MessageSeverity } from 'src/app/services/alert.service';
import { FactoryService } from 'src/app/services/factory.service';
import { Utilities } from 'src/app/services/utilities';
import { AddEditFactoryComponent } from '../add-edit-factory/add-edit-factory.component';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DeleteFactoryComponent } from '../delete-factory/delete-factory.component';

@Component({
    selector: 'app-factory-list',
    templateUrl: './factory-list.component.html',
    styleUrls: ['./factory-list.component.scss']
})
export class FactoryListComponent implements OnInit {
    loadingIndicator: boolean;
    allFactories: Factory[] = [];
    totalRows = 0;
    pageSize = 5;
    currentPage = 0;
    defaultPageSize = 10;
    pageSizeOptions: number[] = [5, 10, 25, 100];
    displayedColumns: string[] = [
        'name',
        'email',
        'address',
        'description',
        'mobile',
        'phone',
        'support',
        'actions'
    ];
    dataSource = new MatTableDataSource<Factory>([]);
    editingFactoryName: null;
    sourceUser: null;

    @ViewChild(MatPaginator) paginator!: MatPaginator;
    searchValue: string = "";
    constructor(
        public dialog: MatDialog,
        private alertService: AlertService,
        private accountService: AccountService,
        private factoryService: FactoryService,
        private router: Router,
        private modalService: NgbModal,
    ) { }

    ngOnInit(): void {
        this.loadData();
    }

    loadData() {
        this.alertService.startLoadingMessage();
        this.loadingIndicator = true;

        if (this.canViewRoles) {
            this.factoryService.getFactories(this.currentPage + 1, this.pageSize, this.searchValue, 'name', 'desc').subscribe({
                next: (results) => this.onDataLoadSuccessful(results),
                error: (error) => this.onDataLoadFailed(error),
            });
        } else {
            this.factoryService.getFactories(this.currentPage, this.pageSize).subscribe({
                next: (users) => this.onDataLoadSuccessful(users),
                error: (error) => this.onDataLoadFailed(error),
            });
        }
    }

    pageChanged(event: PageEvent) {
        this.pageSize = event.pageSize;
        this.currentPage = event.pageIndex;
        this.loadData();
    }

    onDataLoadSuccessful(factories: any) {
        
        this.alertService.stopLoadingMessage();
        this.loadingIndicator = false;

        this.dataSource.data = factories.items;
        this.totalRows = factories.totalCount;
    }

    onDataLoadFailed(error: any) {
        this.alertService.stopLoadingMessage();
        this.loadingIndicator = false;

        this.alertService.showStickyMessage(
            'Load Error',
            `Unable to retrieve users from the server.\r\nErrors: "${error}"`,
            MessageSeverity.error,
            error
        );
    }

    newFactory() {
        this.editingFactoryName = null;
        this.sourceUser = null;
        this.router.navigate(['/add-edit-factory']);
    }

    editFactory(id: number) {
        this.router.navigate(['/add-edit-factory'], { queryParams: { id: id } });
    }

    onSearchChanged(value: string) {
        this.searchValue = value;
        this.currentPage = 0;
        this.loadData();
    }
    deleteFactory(row: Factory) {
        const modalRef = this.modalService.open(
            DeleteFactoryComponent,
            {
                size: 'lg',
                backdrop: 'static'
            }
        );
        modalRef.componentInstance.row = row;
        modalRef.componentInstance.deleteChanged.subscribe((data) => {
            if(data){
                this.modalService.dismissAll();
                this.loadData();
               }
        })
    }

    deleteUserHelper(row: Factory) {
        this.alertService.startLoadingMessage('Deleting...');
        this.loadingIndicator = true;

        this.factoryService.deleteFactory(row).subscribe({
            next: (_) => {
                this.alertService.stopLoadingMessage();
                this.loadingIndicator = false;

                this.loadData();
                this.dataSource.data = this.dataSource.data.filter((item) => item !== row);
            },
            error: (error) => {
                this.alertService.stopLoadingMessage();
                this.loadingIndicator = false;

                this.alertService.showStickyMessage(
                    'Delete Error',
                    `An error occurred whilst deleting the user.\r\nError: "${Utilities.getHttpResponseMessages(
                        error
                    )}"`,
                    MessageSeverity.error,
                    error
                );
            },
        });
    }
    get canAssignRoles() {
        return this.accountService.userHasPermission(Permission.assignRolesPermission);
    }

    get canViewRoles() {
        return this.accountService.userHasPermission(Permission.viewRolesPermission);
    }

    get canManageUsers() {
        return this.accountService.userHasPermission(Permission.manageUsersPermission);
    }
}
