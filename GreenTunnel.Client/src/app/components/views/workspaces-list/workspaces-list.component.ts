import { Component, Input, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { isNullOrUndefined } from '@swimlane/ngx-datatable';
import { Permission } from 'src/app/models/permission.model';
import { Workspace } from 'src/app/models/workspace.model';
import { AccountService } from 'src/app/services/account.service';
import { AlertService, DialogType, MessageSeverity } from 'src/app/services/alert.service';
import { Utilities } from 'src/app/services/utilities';
import { WorkspaceService } from 'src/app/services/workspace.service';

@Component({
    selector: 'app-workspaces-list',
    templateUrl: './workspaces-list.component.html',
    styleUrls: ['./workspaces-list.component.scss']
})
export class WorkspacesListComponent {
    @Input() workplaceId: number = 0;
    loadingIndicator: boolean;
    columns: any[] = [];
    rows: Workspace[] = [];
    rowsCache: Workspace[] = [];
    allWorkplaces: Workspace[] = [];
    ongoing = true;
    pending = true;
    completed = true;
    totalRows = 0;
    pageSize = 1;
    currentPage = 0;
    defaultPageSize = 10; // You can set your desired default page size here
    pageSizeOptions: number[] = [2, 10, 25, 100];
    editorModalTemplate: TemplateRef<any>;

    displayedColumns: string[] = [

        'name',
        'order',
        'description',
        'actions'
    ];
    dataSource = new MatTableDataSource<Workspace>([]);
    sourceUser: null;

    @ViewChild(MatPaginator) paginator!: MatPaginator;
    searchValue: string = "";
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
        private workspaceService: WorkspaceService,
        private modalService: NgbModal,
        private router: Router) { }
    ngOnInit(): void {
        this.loadData();

    }
    loadData() {
        debugger
        this.alertService.startLoadingMessage();
        this.loadingIndicator = true;

        debugger
        if (this.canViewRoles) {
            this.workspaceService.getWorkspaces(this.workplaceId, this.currentPage + 1, this.pageSize, this.searchValue, 'name', 'desc').subscribe({
                next: (results) => this.onDataLoadSuccessful(results),
                error: (error) => this.onDataLoadFailed(error),
            });
        } else {
            this.workspaceService.getWorkspaces(this.currentPage, this.pageSize).subscribe({
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
    deleteWorkspace(row: Workspace) {
        this.alertService.showDialog(
            `Are you sure you want to delete \"${row.name}\"?`,
            DialogType.confirm,
            () => this.deleteWorkspaceHelper(row)
        );
    }
    deleteWorkspaceHelper(row: Workspace) {
        this.alertService.startLoadingMessage('Deleting...');
        this.loadingIndicator = true;
        debugger;
        this.workspaceService.deleteWorkspace(row).subscribe({
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
        if (!isNullOrUndefined(this.workplaceId)) {
            debugger
            this.router.navigate(['/add-edit-workspace', this.workplaceId]);
        } else {
            this.router.navigate(['/add-edit-workspace']);

        }
    }
    editWorkspace(id: number) {
        debugger
        this.router.navigate(['/add-edit-workspace'], { queryParams: { id: id } })
    }
    // Rest of the component methods
    onSearchChanged(value: string) {
        this.searchValue = value;
        this.currentPage = 0;
        this.loadData();
    }
}