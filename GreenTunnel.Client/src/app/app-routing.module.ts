import { Injectable, NgModule } from '@angular/core';
import { DefaultUrlSerializer, RouterModule, Routes, UrlSerializer, UrlTree } from '@angular/router';
import { InternalErrorComponent } from './components/common/internal-error/internal-error.component';
import { NotFoundComponent } from './components/common/not-found/not-found.component';
import { FileUploaderComponent } from './components/forms/file-uploader/file-uploader.component';
import { WizardFormComponent } from './components/forms/wizard-form/wizard-form.component';
import { AccountComponent } from './components/pages/account/account.component';
import { AnalyticsCustomersComponent } from './components/pages/analytics-customers/analytics-customers.component';
import { AnalyticsReportsComponent } from './components/pages/analytics-reports/analytics-reports.component';
import { ConnectionsComponent } from './components/pages/connections/connections.component';
import { FlaticonComponent } from './components/pages/icons/flaticon/flaticon.component';
import { MaterialIconsComponent } from './components/pages/icons/material-icons/material-icons.component';
import { MaterialSymbolsComponent } from './components/pages/icons/material-symbols/material-symbols.component';
import { RemixiconComponent } from './components/pages/icons/remixicon/remixicon.component';
import { ProfileComponent } from './components/pages/profile/profile.component';
import { SearchComponent } from './components/pages/search/search.component';
import { TimelineComponent } from './components/pages/timeline/timeline.component';
import { PKanbanBoardComponent } from './components/projects/p-kanban-board/p-kanban-board.component';
import { AutocompleteComponent } from './components/ui-kit/autocomplete/autocomplete.component';
import { ChipsComponent } from './components/ui-kit/chips/chips.component';
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth-guard.service';
import { Utilities } from './services/utilities';
import { UserInfoComponent } from './components/settings/user/user-info/user-info.component';
import { RolesManagementComponent } from './components/settings/roles/roles-mangement/roles-management/roles-management.component';
import { UsersManagementComponent } from './components/settings/user/user-mangement/app-users-management/users-management.component';
import { FactoryListComponent } from './components/views/factory-list/factory-list.component';
import { AddEditFactoryComponent } from './components/views/add-edit-factory/add-edit-factory.component';
import { ViewFactoryComponent } from './components/views/view-factory/view-factory.component';
import { WorkplaceListComponent } from './components/main/workplace/workplace-list/workplace-list.component';
import { AddEditWorkplaceComponent } from './components/views/add-edit-workplace/add-edit-workplace.component';
import { ViewWorkplaceComponent } from './components/views/view-workplace/view-workplace.component';
import { WorkspaceListComponent } from './components/main/workspace/workspace-list/workspace-list.component';
import { AddEditWorkspaceComponent } from './components/views/add-edit-workspace/add-edit-workspace.component';
import { ViewWorkspaceComponent } from './components/views/view-workspace/view-workspace.component';
import { WorkplacesListComponent } from './components/views/workplaces-list/workplaces-list.component';
import { WorkspacesListComponent } from './components/views/workspaces-list/workspaces-list.component';
import { MouldListComponent } from './components/views/moulds/mould-list/mould-list.component';
import { AddEditMouldComponent } from './components/views/moulds/add-edit-mould/add-edit-mould.component';
import { ViewMouldComponent } from './components/views/moulds/view-mould/view-mould.component';
import { LockScreenComponent } from './components/authentication/lock-screen/lock-screen.component';
import { ConfirmMailComponent } from './components/authentication/confirm-mail/confirm-mail.component';
import { LogoutComponent } from './components/authentication/logout/logout.component';
import { SigninSignupComponent } from './components/authentication/signin-signup/signin-signup.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { ResetPasswordComponent } from './components/authentication/reset-password/reset-password.component';
import { ForgotPasswordComponent } from './components/authentication/forgot-password/forgot-password.component';
import { EcommerceComponent } from './components/dashboard/ecommerce/ecommerce.component';
@Injectable()
export class LowerCaseUrlSerializer extends DefaultUrlSerializer {
    override parse(url: string): UrlTree {
    const possibleSeparators = /[?;#]/;
    const indexOfSeparator = url.search(possibleSeparators);
    let processedUrl: string;

    if (indexOfSeparator > -1) {
      const separator = url.charAt(indexOfSeparator);
      const urlParts = Utilities.splitInTwo(url, separator);
      urlParts.firstPart = urlParts.firstPart.toLowerCase();

      processedUrl = urlParts.firstPart + separator + urlParts.secondPart;
    } else {
      processedUrl = url.toLowerCase();
    }

    return super.parse(processedUrl);
  }
}
const routes: Routes = [
    {path: '', component: EcommerceComponent},
    {path: 'projects/kanban-board', component: PKanbanBoardComponent},
    {path: 'analytics/customers', component: AnalyticsCustomersComponent},
    {path: 'analytics/reports', component: AnalyticsReportsComponent},
    {path: 'ui-kit/autocomplete', component: AutocompleteComponent},
    {path: 'ui-kit/chips', component: ChipsComponent},
    {path: 'icons/flaticon', component: FlaticonComponent},
    {path: 'icons/remixicon', component: RemixiconComponent},
    {path: 'icons/material-symbols', component: MaterialSymbolsComponent},
    {path: 'icons/material', component: MaterialIconsComponent},
    {path: 'forms/file-uploader', component: FileUploaderComponent},
    {path: 'profile', component: UserInfoComponent,canActivate: [AuthGuard],data: { title: 'Profile' }},
    {path: 'user-mangement', component: UsersManagementComponent,canActivate: [AuthGuard],data: { title: 'Users' }},
    {path: 'role-mangement', component: RolesManagementComponent,canActivate: [AuthGuard],data: { title: 'Roles' }},

    {path: 'account', component: AccountComponent,canActivate: [AuthGuard], data: { title: 'Account' }},
    {path: 'connections', component: ConnectionsComponent},
    {path: 'timeline', component: TimelineComponent},
    {path: 'search', component: SearchComponent},
    {path: 'error-500', component: InternalErrorComponent},
    {path: 'authentication/forgot-password', component: ForgotPasswordComponent},
    {path: 'authentication/reset-password', component: ResetPasswordComponent},
    {path: 'authentication/login', component: LoginComponent},
    {path: 'authentication/register', component: RegisterComponent},
    {path: 'authentication/signin-signup', component: SigninSignupComponent},
    {path: 'authentication/logout', component: LogoutComponent},
    {path: 'authentication/confirm-mail', component: ConfirmMailComponent},
    {path: 'authentication/lock-screen', component: LockScreenComponent},
    { path: 'factories', component: FactoryListComponent, canActivate: [AuthGuard], data: { title: 'Factories' } },
    { path: 'add-edit-factory', component: AddEditFactoryComponent, canActivate: [AuthGuard], data: { title: 'Add Edit Factory' } },
    { path: 'view-factory', component: ViewFactoryComponent, canActivate: [AuthGuard], data: { title: 'View Factory' } },
    { path: 'workplaces', component: WorkplacesListComponent, canActivate: [AuthGuard], data: { title: 'Workplaces' } },
    { path: 'add-edit-workplace/:factoryId', component: AddEditWorkplaceComponent, canActivate: [AuthGuard], data: { title: 'Add Edit Workplace' } },
    { path: 'add-edit-workplace', component: AddEditWorkplaceComponent, canActivate: [AuthGuard], data: { title: 'Add Edit Workplace' } },
    { path: 'view-workplace', component: ViewWorkplaceComponent, canActivate: [AuthGuard], data: { title: 'View Workplace' } },
    { path: 'workspaces', component: WorkspacesListComponent, canActivate: [AuthGuard], data: { title: 'Workspaces' } },
    { path: 'add-edit-workspace/:workplaceId', component: AddEditWorkspaceComponent, canActivate: [AuthGuard], data: { title: 'Add Edit Workspace' } },
    { path: 'add-edit-workspace', component: AddEditWorkspaceComponent, canActivate: [AuthGuard], data: { title: 'Add Edit Workspace' } },
    { path: 'view-factory', component: ViewWorkspaceComponent, canActivate: [AuthGuard], data: { title: 'View Workspace' } },
    { path: 'moulds', component: MouldListComponent, canActivate: [AuthGuard], data: { title: 'Moulds' } },
    { path: 'add-edit-mould/:workspaceid', component: AddEditMouldComponent, canActivate: [AuthGuard], data: { title: 'Add Edit Mould' } },
    { path: 'add-edit-mould', component: AddEditMouldComponent, canActivate: [AuthGuard], data: { title: 'Add Edit Mould' } },
    { path: 'mould-detail', component: ViewMouldComponent, canActivate: [AuthGuard], data: { title: 'View Mould' } },
    { path: 'view-workspace', component: ViewWorkspaceComponent, canActivate: [AuthGuard], data: { title: 'View Workspace' } },

    // Here add new pages component

    {path: '**', component: NotFoundComponent} // This line will remain down from the whole pages component list
];

@NgModule({
    imports: [RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled' })],
    exports: [RouterModule],
    providers: [
        AuthService,
        AuthGuard,
        { provide: UrlSerializer, useClass: LowerCaseUrlSerializer }
]
})
export class AppRoutingModule { }
