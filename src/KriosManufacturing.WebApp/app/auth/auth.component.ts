import { Component, inject } from '@angular/core';
import { AuthService } from '../core/services/auth.service';

@Component({
    selector: 'app-auth',
    imports: [],
    templateUrl: './auth.component.html',
    styleUrl: './auth.component.scss'
})
export class AuthComponent {
    authService: AuthService = inject(AuthService);

    login() {
        this.authService.login();
        console.log(this.authService.isLoggedIn());
    }
    logout() {
        this.authService.logout();
        console.log(this.authService.isLoggedIn());
    }
}
