import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TestType } from 'src/app/models/testType.model';
import { Permission } from 'src/app/models/permission.model';
import { AccountService } from 'src/app/services/account.service';
import { AlertService, DialogType, MessageSeverity } from 'src/app/services/alert.service';
import { TestTypeService } from 'src/app/services/testTypeServices/testType.service';
import { Utilities } from 'src/app/services/utilities';
import { AddEditTestTypeComponent } from '../add-edit-testType/add-edit-testType.component';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DeleteTestTypeComponent } from '../delete-testType/delete-testType.component';


@Component({
    selector: 'app-testType-list',
    templateUrl: './testType-list.component.html',
    styleUrls: ['./testType-list.component.scss']
})
export class TestTypeListComponent implements OnInit {
    loadingIndicator: boolean;
    allTestTypes: TestType[] = [];
    totalRows = 0;
    pageSize = 5;
    currentPage = 0;
    defaultPageSize = 10;
    pageSizeOptions: number[] = [5, 10, 25, 100];
    displayedColumns: string[] = [
        'name',
        'description',
        // 'address',
        // 'description',
        // 'mobile',
        // 'phone',
        // 'support',
         'actions'
    ];
    dataSource = new MatTableDataSource<TestType>([]);
    editingFactoryName: null;
    sourceUser: null;

    @ViewChild(MatPaginator) paginator!: MatPaginator;
    searchValue: string = "";
    constructor(
        public dialog: MatDialog,
        private alertService: AlertService,
        private accountService: AccountService,
        private testTypeService: TestTypeService,
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
            this.testTypeService.getTestTypes(this.currentPage + 1, this.pageSize, this.searchValue, 'name', 'desc').subscribe({
                next: (results) => this.onDataLoadSuccessful(results),
                error: (error) => this.onDataLoadFailed(error),
            });
        } else {
            this.testTypeService.getTestTypes(this.currentPage, this.pageSize).subscribe({
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

    onDataLoadSuccessful(tests: any) {
        debugger
        this.alertService.stopLoadingMessage();
        this.loadingIndicator = false;

        this.dataSource.data = tests.items;
        this.totalRows = tests.totalCount;
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

    newTestType() {
        this.editingFactoryName = null;
        this.sourceUser = null;
        this.router.navigate(['/add-edit-testtype']);
    }

    editTestType(id: number) {
        this.router.navigate(['/add-edit-testtype'], { queryParams: { id: id } });
    }

    onSearchChanged(value: string) {
        this.searchValue = value;
        this.currentPage = 0;
        this.loadData();
    }
    
    deleteTestType(row: TestType) {
        const modalRef = this.modalService.open(
            DeleteTestTypeComponent,
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

    deleteUserHelper(row: TestType) {
        this.alertService.startLoadingMessage('Deleting...');
        this.loadingIndicator = true;

        this.testTypeService.deleteTestType(row).subscribe({
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
                    `An error occurred whilst deleting the testType.\r\nError: "${Utilities.getHttpResponseMessages(
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
