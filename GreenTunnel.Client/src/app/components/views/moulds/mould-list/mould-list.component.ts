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
import { Utilities } from 'src/app/services/utilities';
import { Router } from '@angular/router';
import { Mould } from 'src/app/models/mould.model';
import { MouldService } from 'src/app/services/mouldServices/mould.service';
import { AddEditMouldComponent } from '../add-edit-mould/add-edit-mould.component';
import { DeleteMouldComponent } from '../delete-mould/delete-mould.component';

@Component({
    selector: 'app-mould-list',
    templateUrl: './mould-list.component.html',
    styleUrls: ['./mould-list.component.scss']
})
export class MouldListComponent implements OnInit {
    @Input() workspaceid: number = 0;
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
    isSubView: boolean;
    searchValue: string = null;
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
        if (this.workspaceid > 0) {
            this.isSubView = true;
        }
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
            this.mouldService.getMoulds(this.workspaceid, this.currentPage, this.pageSize,this.searchValue).subscribe({
                next: (users) => this.onDataLoadSuccessful(users),
                error: (error) => this.onDataLoadFailed(error),
            });
        //}
    }
    pageChanged(event: PageEvent) {
        this.pageSize = event.pageSize;
        this.currentPage = event.pageIndex;
        this.loadData();
    }
    deleteUser(row:Mould) {
        const modalRef = this.modalService.open(DeleteMouldComponent,
            {
                size:'lg',
                backdrop:'static'
            }
        );
    modalRef.componentInstance.row = row;
    modalRef.componentInstance.deleteChanged.subscribe((data)=>{
        debugger
        if(data){
         this.modalService.dismissAll();
         this.loadData();
        }
     })
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
    onDataLoadSuccessful(moulds: any) {

        this.allMoulds = moulds.items;

        debugger
        this.alertService.stopLoadingMessage();
        this.loadingIndicator = false;

        this.dataSource.data = moulds.items;
        this.totalRows = moulds.totalCount;
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
    editMould(element:any){debugger
        var g=element.workspaceId;
        this.router.navigate(['/add-edit-mould'],{queryParams:{id:element.id,wid: element.workspaceId}})
    }
    detailMould(id:number){
        debugger
        this.router.navigate(['/mould-detail'],{queryParams:{id:id}})
    }
    // Rest of the component methods
    onSearchChanged(value: string) {
        this.searchValue = value;
       this.searchValue= this.searchValue==""?null:this.searchValue;
        this.currentPage = 0;
        this.loadData();
    }
}
