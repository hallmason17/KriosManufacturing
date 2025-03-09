import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { MatIcon } from '@angular/material/icon';
import { AuthService } from '../../core/services/auth.service';

@Component({
    selector: 'app-nav-bar',
    imports: [RouterLink, MatIcon],
    templateUrl: './nav-bar.component.html',
    styleUrl: './nav-bar.component.scss'
})
export class NavBarComponent {
    authService: AuthService = inject(AuthService)
    router: Router = inject(Router)
    loggedOutRoutes = [
        'Login',
        'Register'
    ]
    loggedInRoutes = [
        'Log Out'
    ]

    logout() {
        this.authService.logout();
        this.router.navigate(['/login']);
    }

    get isLoggedIn(): boolean {
        return this.authService.isLoggedIn();
    }

    get loggedInUser(): string | null {
        return this.authService.loggedInUser();
    }
}
