 

import { Component } from '@angular/core';
import { Permission } from 'src/app/models/permission.model';
import { AccountService } from 'src/app/services/account.service';
import { AlertService, DialogType, MessageSeverity } from 'src/app/services/alert.service';
import { AppTranslationService } from 'src/app/services/app-translation.service';
import { ConfigurationService } from 'src/app/services/configuration.service';
import { ThemeManager } from 'src/app/services/theme-manager';
import { Utilities } from 'src/app/services/utilities';



@Component({
  selector: 'app-user-preferences',
  templateUrl: './user-preferences.component.html',
  styleUrls: ['./user-preferences.component.scss']
})
export class UserPreferencesComponent {

  constructor(
    private alertService: AlertService,
    private translationService: AppTranslationService,
    private accountService: AccountService,
    public themeManager: ThemeManager,
    public configurations: ConfigurationService) {
  }

  reloadFromServer() {
    this.alertService.startLoadingMessage();

    this.accountService.getUserPreferences()
      .subscribe({
        next: (results:any) => {
          this.alertService.stopLoadingMessage();

          this.configurations.import(results);

          this.alertService.showMessage('Defaults loaded!', '', MessageSeverity.info);

        },
        error: error => {
          this.alertService.stopLoadingMessage();
          this.alertService.showStickyMessage('Load Error', `Unable to retrieve user preferences from the server.\r\nErrors: "${Utilities.getHttpResponseMessages(error)}"`,
            MessageSeverity.error, error);
        }
      });
  }

  setAsDefault() {
    this.alertService.showDialog('Are you sure you want to set the current configuration as your new defaults?', DialogType.confirm,
      () => this.setAsDefaultHelper(),
      () => this.alertService.showMessage('Operation Cancelled!', '', MessageSeverity.default));
  }

  setAsDefaultHelper() {
    this.alertService.startLoadingMessage('', 'Saving new defaults');

    this.accountService.updateUserPreferences(this.configurations.export())
      .subscribe({
        next: _ => {
          this.alertService.stopLoadingMessage();
          this.alertService.showMessage('New Defaults', 'Account defaults updated successfully', MessageSeverity.success);

        },
        error: error => {
          this.alertService.stopLoadingMessage();
          this.alertService.showStickyMessage('Save Error', `An error occurred whilst saving configuration defaults.\r\nErrors: "${Utilities.getHttpResponseMessages(error)}"`,
            MessageSeverity.error, error);
        }
      });
  }



  resetDefault() {
    this.alertService.showDialog('Are you sure you want to reset your defaults?', DialogType.confirm,
      () => this.resetDefaultHelper(),
      () => this.alertService.showMessage('Operation Cancelled!', '', MessageSeverity.default));
  }

  resetDefaultHelper() {
    this.alertService.startLoadingMessage('', 'Resetting defaults');

    this.accountService.updateUserPreferences('')
      .subscribe({
        next: _ => {
          this.alertService.stopLoadingMessage();
          this.configurations.import('');
          this.alertService.showMessage('Defaults Reset', 'Account defaults reset completed successfully', MessageSeverity.success);
        },
        error: error => {
          this.alertService.stopLoadingMessage();
          this.alertService.showStickyMessage('Save Error', `An error occurred whilst resetting configuration defaults.\r\nErrors: "${Utilities.getHttpResponseMessages(error)}"`,
            MessageSeverity.error, error);
        }
      });
  }


  get canViewCustomers() {
    return this.accountService.userHasPermission(Permission.viewUsersPermission); // eg. viewCustomersPermission
  }

  get canViewProducts() {
    return this.accountService.userHasPermission(Permission.viewUsersPermission); // eg. viewProductsPermission
  }

  get canViewOrders() {
    return true; // eg. viewOrdersPermission
  }
}
