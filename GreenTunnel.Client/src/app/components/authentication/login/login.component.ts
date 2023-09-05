import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { CustomizerSettingsService } from '../../customizer-settings/customizer-settings.service';
import { UserLogin } from 'src/app/models/user-login.model';
import { AlertService, DialogType, MessageSeverity } from 'src/app/services/alert.service';
import { AuthService } from 'src/app/services/auth.service';
import { ConfigurationService } from 'src/app/services/configuration.service';
import { Utilities } from 'src/app/services/utilities';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent  implements OnInit, OnDestroy{

    hide = true;
    userLogin = new UserLogin();
    isLoading = false;
    formResetToggle = true;
    modalClosedCallback: () => void;
    loginStatusSubscription: any;
  
    @Input()
    isModal = false;
    constructor(
        public themeService: CustomizerSettingsService,
        private alertService: AlertService,
         private authService: AuthService,
          private configurations: ConfigurationService
    ) {}
    ngOnInit() {

      this.userLogin.rememberMe = this.authService.rememberMe;
  
      if (this.getShouldRedirect()) {
        this.authService.redirectLoginUser();
      } else {
        this.loginStatusSubscription = this.authService.getLoginStatusEvent().subscribe(_ => {
          if (this.getShouldRedirect()) {
            this.authService.redirectLoginUser();
          }
        });
      }
    }
    toggleTheme() {
        this.themeService.toggleTheme();
    }

    toggleCardBorderTheme() {
        this.themeService.toggleCardBorderTheme();
    }

    toggleCardBorderRadiusTheme() {
        this.themeService.toggleCardBorderRadiusTheme();
    }

    toggleRTLEnabledTheme() {
        this.themeService.toggleRTLEnabledTheme();
    }
    ngOnDestroy() {
        if (this.loginStatusSubscription) {
          this.loginStatusSubscription.unsubscribe();
        }
      }
    
    
      getShouldRedirect() {
        return !this.isModal && this.authService.isLoggedIn && !this.authService.isSessionExpired;
      }
    
    
      showErrorAlert(caption: string, message: string) {
        this.alertService.showMessage(caption, message, MessageSeverity.error);
      }
    
      closeModal() {
        if (this.modalClosedCallback) {
          this.modalClosedCallback();
        }
      }
    
    
      login() {
        this.isLoading = true;
        this.alertService.startLoadingMessage('', 'Attempting login...');
    
        this.authService.loginWithPassword(this.userLogin.userName, this.userLogin.password, this.userLogin.rememberMe)
          .subscribe({
            next: user => {
              setTimeout(() => {
                this.alertService.stopLoadingMessage();
                this.isLoading = false;
                this.reset();
    
                if (!this.isModal) {
                  this.alertService.showMessage('Login', `Welcome ${user.userName}!`, MessageSeverity.success);
                } else {
                  this.alertService.showMessage('Login', `Session for ${user.userName} restored!`, MessageSeverity.success);
                  setTimeout(() => {
                    this.alertService.showStickyMessage('Session Restored', 'Please try your last operation again', MessageSeverity.default);
                  }, 500);
    
                  this.closeModal();
                }
              }, 500);
            },
            error: error => {
    
              this.alertService.stopLoadingMessage();
    
              if (Utilities.checkNoNetwork(error)) {
                this.alertService.showStickyMessage(Utilities.noNetworkMessageCaption, Utilities.noNetworkMessageDetail, MessageSeverity.error, error);
                this.offerAlternateHost();
              } else {
                const errorMessage = Utilities.getHttpResponseMessage(error);
    
                if (errorMessage) {
                  this.alertService.showStickyMessage('Unable to login', this.mapLoginErrorMessage(errorMessage), MessageSeverity.error, error);
                } else {
                  this.alertService.showStickyMessage('Unable to login', 'An error occurred whilst logging in, please try again later.\nError: ' + Utilities.getResponseBody(error), MessageSeverity.error, error);
                }
              }
    
              setTimeout(() => {
                this.isLoading = false;
              }, 500);
            }
          });
      }
    
    
      offerAlternateHost() {
        if (Utilities.checkIsLocalHost(location.origin) && Utilities.checkIsLocalHost(this.configurations.baseUrl)) {
          this.alertService.showDialog('Dear User!\nIt appears your backend service is not running...\n' +
            'We highly recommand to call the support!',
            DialogType.prompt,
            (value: string) => {
              this.configurations.baseUrl = value;
              this.alertService.showStickyMessage('API Changed!', 'The target Web API has been changed to: ' + value, MessageSeverity.warn);
            },
            null,
            null,
            null,
            this.configurations.fallbackBaseUrl);
        }
      }
    
    
      mapLoginErrorMessage(error: string) {
        if (error === 'invalid_username_or_password') {
          return 'Invalid username or password';
        }
    
        if (error === 'invalid_grant') {
          return 'This account has been disabled';
        }
    
        return error;
      }
    
    
      reset() {
        this.formResetToggle = false;
    
        setTimeout(() => {
          this.formResetToggle = true;
        });
      }
}
