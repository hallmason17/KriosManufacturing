import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
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
    loggedOutRoutes = [
        'Login',
        'Register'
    ]
    loggedInRoutes = [
        'Log Out'
    ]
}
