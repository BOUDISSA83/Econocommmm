import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Permission } from 'src/app/models/permission.model';
import { Role } from 'src/app/models/role.model';
import { User } from 'src/app/models/user.model';
import { AccountService } from 'src/app/services/account.service';
import { AlertService, DialogType, MessageSeverity } from 'src/app/services/alert.service';
import { Utilities } from 'src/app/services/utilities';
import { Router } from '@angular/router';
import { Mould } from 'src/app/models/mould.model';
import { MouldService } from 'src/app/services/mouldServices/mould.service';
import { AddEditMouldComponent } from '../add-edit-mould/add-edit-mould.component';

@Component({
    selector: 'app-mould-list',
    templateUrl: './mould-list.component.html',
    styleUrls: ['./mould-list.component.scss']
})
export class MouldListComponent implements OnInit {
    loadingIndicator: boolean;
    columns: any[] = [];
    rows: Mould[] = [];
    rowsCache: Mould[] = [];
    allMoulds: Mould[] = [];
    ongoing = true;
    pending = true;
    completed = true;
    totalRows = 0;
    pageSize = 5;
    currentPage = 1;
    defaultPageSize = 10; // You can set your desired default page size here
    pageSizeOptions: number[] = [4, 10, 25, 100];
    editorModalTemplate: TemplateRef<any>;
    mouldEditor: AddEditMouldComponent;

    displayedColumns: string[] = [

        'name',
        'type',
        'actions'
    ];
    dataSource = new MatTableDataSource<Mould>([]);
    editingMouldName: null;
    sourceUser: null;
    ngAfterViewInit() {
        if (this.dataSource) {
            this.dataSource.paginator = this.paginator;
        }
    }
    @ViewChild(MatPaginator) paginator!: MatPaginator;
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
        private mouldService: MouldService,
        private modalService: NgbModal,
        private router: Router) { }
    ngOnInit(): void {
        this.loadData();

    }
    loadData() {
        debugger
        this.alertService.startLoadingMessage();
        this.loadingIndicator = true;

        // debugger
        // if (this.canViewRoles) {
        //     this.mouldService.getMoulds(this.currentPage, this.pageSize).subscribe({
        //         next: (results) => this.onDataLoadSuccessful(results),
        //         error: (error) => this.onDataLoadFailed(error),
        //     });
        // } else {
            this.mouldService.getMoulds(this.currentPage, this.pageSize).subscribe({
                next: (users) => this.onDataLoadSuccessful(users),
                error: (error) => this.onDataLoadFailed(error),
            });
        //}
    }
    pageChanged(event: PageEvent) {
        console.log({ event });
        this.pageSize = event.pageSize;
        this.currentPage = event.pageIndex+1;
        this.loadData();
    }
    deleteUser(row:Mould) {
        this.alertService.showDialog(
            `Are you sure you want to delete \"${row.name}\"?`,
            DialogType.confirm,
            () => this.deleteUserHelper(row)
        );
    }
    deleteUserHelper(row: Mould) {
        this.alertService.startLoadingMessage('Deleting...');
        this.loadingIndicator = true;

        this.mouldService.deleteMould(row).subscribe({
            next: (_) => {
                this.alertService.stopLoadingMessage();
                this.loadingIndicator = false;

                this.rowsCache = this.rowsCache.filter((item) => item !== row);
                 this.dataSource.data =  this.dataSource.data.filter((item) => item !== row);
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
    onDataLoadSuccessful(moulds: Mould[]) {
        this.alertService.stopLoadingMessage();
        this.loadingIndicator = false;

        moulds.forEach((user, index) => {
            (user as any).index = index + 1;
        });

        this.rowsCache = [...moulds];
        this.dataSource.data = moulds;
        this.totalRows = moulds.length;
        setTimeout(() => {
            debugger
            this.paginator.pageIndex = this.currentPage;
            this.paginator.length = moulds.length;
        });

        this.allMoulds = moulds;
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
    newMould() {
        this.editingMouldName = null;
        this.sourceUser = null;
        this.router.navigate(['/add-edit-mould']);

    }
    editMould(id:number){debugger
        this.router.navigate(['/add-edit-mould'],{queryParams:{id:id}})
    }
    detailMould(id:number){
        debugger
        this.router.navigate(['/mould-detail'],{queryParams:{id:id}})
    }
    // Rest of the component methods
    onSearchChanged(value: string) {
        this.dataSource.data = this.rowsCache.filter((r) =>
            Utilities.searchArray(
                value,
                false,
                r.name,
                r.type
                // r.address,
                // r.email,
                // r.phone,
                // r.email,
                // r.mobile
            )
        );
    }
}
