import { Component, Input, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Permission } from 'src/app/models/permission.model';
import { Role } from 'src/app/models/role.model';
import { User } from 'src/app/models/user.model';
import { AccountService } from 'src/app/services/account.service';
import { AlertService, DialogType, MessageSeverity } from 'src/app/services/alert.service';
import { FactoryService } from 'src/app/services/factory.service';
import { Utilities } from 'src/app/services/utilities';
import { AddEditFactoryComponent } from '../add-edit-factory/add-edit-factory.component';
import { Router } from '@angular/router';
import { AddEditWorkplaceComponent } from '../add-edit-workplace/add-edit-workplace.component';
import { WorkplaceService } from 'src/app/services/workplace.service';
import { Workplace } from 'src/app/models/workplace.model';
import { isNullOrUndefined } from '@swimlane/ngx-datatable';
import { T } from '@angular/cdk/keycodes';
import { DeleteWorkplaceComponent } from '../delete-workplace/delete-workplace.component';

@Component({
    selector: 'app-workplaces-list',
    templateUrl: './workplaces-list.component.html',
    styleUrls: ['./workplaces-list.component.scss']
})

export class WorkplacesListComponent implements OnInit {
    @Input() factoryId: number = 0;
    loadingIndicator: boolean;
    columns: any[] = [];
    rows: Workplace[] = [];
    rowsCache: Workplace[] = [];
    allWorkplaces: Workplace[] = [];
    ongoing = true;
    pending = true;
    completed = true;
    totalRows = 0;
    pageSize = 5;
    currentPage = 0;
    defaultPageSize = 10; // You can set your desired default page size here
    pageSizeOptions: number[] = [5, 10, 25, 100];
    editorModalTemplate: TemplateRef<any>;

    displayedColumns: string[] = [

        'name',
        'factoryName',
        'description',
        'actions'
    ];
    dataSource = new MatTableDataSource<Workplace>([]);
    sourceUser: null;
    @ViewChild(MatPaginator) paginator!: MatPaginator;
    searchValue: string = "";
    isSubView: boolean;
    get canAssignRoles() {
        return this.accountService.userHasPermission(
            Permission.assignRolesPermission
        );
    }

    get canViewRoles() {
        return this.accountService.userHasPermission(
            Permission.viewRolesPermission
        );
    }

    get canManageUsers() {
        return this.accountService.userHasPermission(
            Permission.manageUsersPermission
        );
    }
    constructor(public dialog: MatDialog,
        private alertService: AlertService,
        private accountService: AccountService,
        private workplaceService: WorkplaceService,
        private modalService: NgbModal,
        private router: Router) { }
    ngOnInit(): void {
        if (this.factoryId > 0) {
            this.isSubView = true;
        }
        this.loadData();

    }

    loadData() {
        debugger
        this.alertService.startLoadingMessage();
        this.loadingIndicator = true;

        debugger
        if (this.canViewRoles) {
            this.workplaceService.getWorkplaces(this.factoryId, this.currentPage + 1, this.pageSize, this.searchValue, 'name', 'desc').subscribe({
                next: (results) => this.onDataLoadSuccessful(results),
                error: (error) => this.onDataLoadFailed(error),
            });
        } else {
            this.workplaceService.getWorkplaces(this.currentPage, this.pageSize).subscribe({
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
    deleteWorkplace(row: Workplace) {
        const modalRef =  this.modalService.open(
            DeleteWorkplaceComponent,
            {
                size:'lg',
                backdrop:'static'
            }
        );
        modalRef.componentInstance.row = row;
        modalRef.componentInstance.deleteChanged.subscribe((data)=>{
           if(data){
            this.modalService.dismissAll();
            this.loadData();
           }
        })
    }
    deleteWorkplaceHelper(row: Workplace) {
        this.alertService.startLoadingMessage('Deleting...');
        this.loadingIndicator = true;

        this.workplaceService.deleteWorkplace(row).subscribe({
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
    onDataLoadSuccessful(workplaces: any) {
        debugger
        this.alertService.stopLoadingMessage();
        this.loadingIndicator = false;

        this.dataSource.data = workplaces.items;
        this.totalRows = workplaces.totalCount;

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
        this.sourceUser = null;
        if (!isNullOrUndefined(this.factoryId)) {
            debugger
            this.router.navigate(['/add-edit-workplace', this.factoryId]);
        } else {
            this.router.navigate(['/add-edit-workplace']);

        }
    }
    editWorkplace(id: number) {
        debugger
        this.router.navigate(['/add-edit-workplace'], { queryParams: { id: id } })
    }
    // Rest of the component methods
    onSearchChanged(value: string) {
        this.searchValue = value;
        this.currentPage = 0;
        this.loadData();
    }
}
